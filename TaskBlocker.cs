//
//  This file is part of Task Blocker, 
//  an administration tool which can prevent running any application in Windows
//
//  Author: Copyright (C) 2010  Marco "SNaKE" Baccarani, <bacca87@gmail.com>
//
//  Task Blocker is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by 
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Task Blocker is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with Task Blocker.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Management;

namespace TaskBlocker
{
    public class BlockedTaskEventArgs : EventArgs
    {   
        public Task Task { get; internal set; }

        public BlockedTaskEventArgs(Task task)
        {
            Task = task;
        }
    }

    public class Task
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public long Count { get; set; }        

        public Task()
        {
            Name = string.Empty;
            Count = 0;
            Enabled = false;
        }

        public Task(string name, bool enabled, long count)
        {
            Name = name;
            Count = count;
            Enabled = enabled;
        }
    }

    public class TaskBlocker
    {        
        private Thread m_thread;

        private ManagementEventWatcher startWatch;
        private ManagementEventWatcher stopWatch;

        List<Process> m_activeProcess;

        private const string FILENAME = "tasklist.dat";
        private const char SEPARATOR = '|';
        private const int ENABLE_INDEX = 0;
        private const int NAME_INDEX = 1;
        private const int COUNT_INDEX = 2;
                
        private object m_fileLock;
        private object m_taskLock;
        private object m_exitLock;

        private bool m_eventRunning;

        private bool m_exit;
        public bool Exit
        {
            get
            {
                lock (m_exitLock)
                {
                    return m_exit;
                }
            }

            internal set
            {
                lock (m_exitLock)
                {
                    m_exit = value;
                }
            }
        }

        private List<Task> m_taskList;
        public List<Task> TaskList
        {
            get
            {
                lock (m_taskLock)
                {
                    return m_taskList;
                }
            }

            internal set
            {
                lock (m_taskLock)
                {
                    m_taskList = value;
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                if(RealTimeCheck && m_thread != null)
                    return m_thread.IsAlive;
                else
                    return m_eventRunning;
            }
        }

        private bool m_isKiller;
        public bool isKiller 
        {
            get
            {
                lock (m_taskLock)
                {
                    return m_isKiller;
                }
            }

            set
            {
                lock (m_taskLock)
                {
                    if (value)
                        m_activeProcess.Clear();
                    
                    m_isKiller = value;
                }
            }
        }

        public bool RealTimeCheck { get; set; }

        #region Events

        public delegate void BlockedTaskHandler(object sender, BlockedTaskEventArgs e);
        public event BlockedTaskHandler BlockedTask;

        protected void OnBlockedTask(object sender, BlockedTaskEventArgs e)
        {
            // Check if there are any Subscribers
            if (BlockedTask != null)
            {
                // Call the Event
                BlockedTask(this, e);
            }
        }

        #endregion
  
        public TaskBlocker()
        {   
            m_exit = false;
            m_fileLock = new object();
            m_taskLock = new object();
            m_exitLock = new object();
            m_activeProcess = new List<Process>();
            m_taskList = loadTaskList();
            m_isKiller = true;
            RealTimeCheck = false;
            m_eventRunning = false;

            startWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace WITHIN 0.01"));                    
            stopWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace WITHIN 0.01"));
            startWatch. EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
            stopWatch.EventArrived += new EventArrivedEventHandler(stopWatch_EventArrived);
            startWatch.Stopped += new StoppedEventHandler(startWatch_stopped);
        }

        public void start()
        {
            if (RealTimeCheck)
            {
                m_thread = new Thread(run);
                m_thread.Name = "Task Blocker";
                //m_thread.IsBackground = true;
                m_thread.Start();
            }
            else
            {
                TaskList = loadTaskList();
                startWatch.Start();
                stopWatch.Start();
                m_eventRunning = true;

                checkProcesses();
            }
        }

        public void stop()
        {
            if(RealTimeCheck)
            {
                Exit = true;
                // Use the Join method to block the current thread 
                // until the object's thread terminates.
                m_thread.Join();
            }
            else
            {
                startWatch.Stop();
                stopWatch.Stop();
            }
        }

        private void run()
        {
            Process[] processlist;

            Exit = false;

            TaskList = loadTaskList();

            while (!Exit)
            {
                try
                {
                    lock (m_taskLock)
                    {   
                        processlist = Process.GetProcesses();

                        for (int i = 0; i < processlist.Length; i++)
                        {
                            for (int j = 0; j < m_taskList.Count; j++)
                            {
                                // i dont use the method taskExist() for performance reasons
                                if (m_taskList[j].Enabled && m_taskList[j].Name == processlist[i].ProcessName.ToLower() + ".exe")
                                {
                                    if (isKiller)
                                    {
                                        processlist[i].Kill();
                                        processlist[i].WaitForExit(1000);
                                    }
                                    else
                                    {
                                        if (processExist(processlist[i]))
                                            continue;

                                        m_activeProcess.Add(processlist[i]);
                                    }

                                    m_taskList[j].Count++;
                                    saveTaskList(true);
                                    OnBlockedTask(this, new BlockedTaskEventArgs(m_taskList[j]));
                                    break;
                                }
                            }                            
                        }

                        /* Alternative method 
                        for (int j = 0; j < m_taskList.Count; j++)
                        {
                            if (m_taskList[j].Enabled)
                            {
                                processlist = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(m_taskList[j].Name));

                                for (int i = 0; i < processlist.Length; i++)
                                {
                                    if (isKiller)
                                    {
                                        processlist[i].Kill();
                                        processlist[i].WaitForExit(1000);
                                    }
                                    else
                                    {
                                        if (processExist(processlist[i]))
                                            continue;

                                        m_activeProcess.Add(processlist[i]);
                                    }

                                    m_taskList[j].Count++;
                                    saveTaskList(true);
                                    OnBlockedTask(this, new BlockedTaskEventArgs(m_taskList[j]));
                                }
                            }
                        } */

                        // check if tasks are still alive
                        if (!isKiller)
                        {
                            foreach (Process proc in m_activeProcess.ToList())
                            {
                                if (proc.HasExited)
                                    m_activeProcess.Remove(proc);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }

                Thread.Sleep(1);
            }
        }

        private bool processExist(Process process)
        {
            foreach (Process proc in m_activeProcess)
            {
                if (proc.Id == process.Id)
                    return true;
            }

            return false;
        }

        public int taskExist(string taskName)
        {
            lock (m_taskLock)
            {
                for (int i = 0; i < m_taskList.Count(); i++)
                {
                    if (m_taskList[i].Name == taskName)
                        return i;
                }
            }

            return -1;
        }
        
        private List<Task> loadTaskList()
        {
            List<Task> taskList = new List<Task>();

            lock (m_fileLock)
            {
                if (!File.Exists(FILENAME))
                    File.Create(FILENAME).Dispose();

                using (StreamReader sr = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + FILENAME))
                {
                    while (sr.Peek() >= 0)
                    {
                        Task task = new Task();
                        string[] data = sr.ReadLine().Split(new char[] { SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);

                        task.Enabled = Convert.ToBoolean(data[ENABLE_INDEX]);
                        task.Name = data[NAME_INDEX];                        
                        task.Count = Convert.ToInt64(data[COUNT_INDEX]);

                        taskList.Add(task);
                    }
                }
            }

            return taskList;
        }

        private void saveTaskList(bool quietlog = false)
        {
            lock (m_fileLock)
            {
                if (!File.Exists(FILENAME))
                    File.Create(FILENAME).Dispose();

                using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + FILENAME))
                {
                    foreach (Task task in m_taskList)
                    {
                        sw.WriteLine(task.Enabled.ToString() + SEPARATOR + task.Name + SEPARATOR + task.Count);
                    }
                }
            }
            
            if(!quietlog)
                Logger.Istance.debug("The task list was successfully saved.");
        }

        public void addTask(string taskName)
        {
            lock (m_taskLock)
            {
                m_taskList.Add(new Task(taskName, true, 0));
                Logger.Istance.debug(taskName + " added to the task list.");

                saveTaskList();
            }
        }

        public void removeTask(string taskName)
        {
            lock (m_taskLock)
            {
                foreach (Task task in m_taskList)
                {
                    if (task.Name == taskName)
                    {
                        m_taskList.Remove(task);
                        Logger.Istance.debug(taskName + " removed from the task list.");

                        saveTaskList();                        
                        return;
                    }
                }
            }
        }

        public void enableAllTasks(bool enable)
        {
            lock (m_taskLock)
            {
                foreach (Task task in m_taskList)
                    task.Enabled = enable;

                Logger.Istance.debug("All tasks " + (enable ? " enabled." : " disabled."));
                saveTaskList();
            }
        }

        public void enableTask(string taskName, bool enable)
        {
            lock (m_taskLock)
            {
                foreach (Task task in m_taskList)
                {   
                    if (task.Name == taskName)
                    {
                        task.Enabled = enable;
                        Logger.Istance.debug(taskName + (enable ? " enabled." : " disabled."));
                        saveTaskList();
                        return;
                    }
                }
            }
        }

        public void resetAllCounters()
        {
            lock (m_taskLock)
            {
                foreach (Task task in m_taskList)
                    task.Count = 0;

                Logger.Istance.debug("Reset all task counters.");
                saveTaskList();
            }
        }

        public void resetTaskCounter(string taskName)
        {
            lock (m_taskLock)
            {
                foreach (Task task in m_taskList)
                {
                    if (task.Name == taskName)
                    {
                        task.Count = 0;
                        Logger.Istance.debug("Reset " + taskName + " counter.");
                        saveTaskList();
                        return;
                    }
                }
            }
        }

        private void checkProcesses()
        {
            lock (m_taskLock)
            {
                for (int j = 0; j < m_taskList.Count; j++)
                {
                    if (m_taskList[j].Enabled)
                    {
                        Process[] processlist = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(m_taskList[j].Name));

                        for (int i = 0; i < processlist.Length; i++)
                        {
                            if (isKiller)
                            {
                                processlist[i].Kill();
                                processlist[i].WaitForExit(1000);
                            }

                            m_taskList[j].Count++;
                            saveTaskList(true);
                            OnBlockedTask(this, new BlockedTaskEventArgs(m_taskList[j]));
                        }
                    }
                }
            }
        }

        private void stopWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            // unused
        }

        private void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                lock (m_taskLock)
                {
                    string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
                    int processId = Convert.ToInt32(e.NewEvent.Properties["ProcessId"].Value);
                    int taskIndex = taskExist(processName.ToLower());
                    
                    if (taskIndex != -1 && m_taskList[taskIndex].Enabled)
                    {
                        Process targetProcess = Process.GetProcessById(processId);

                        if (targetProcess != null && isKiller)
                        {
                            targetProcess.Kill();
                            targetProcess.WaitForExit(1000);
                        }

                        m_taskList[taskIndex].Count++;
                        saveTaskList(true);
                        OnBlockedTask(this, new BlockedTaskEventArgs(m_taskList[taskIndex]));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Istance.exception(ex);
            }
        }

        private void startWatch_stopped(Object sender, StoppedEventArgs e)
        {
            m_eventRunning = false;
        }
    }
}
