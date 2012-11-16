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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TaskBlocker
{
    public partial class MainForm : Form
    {
        private TaskBlocker m_taskBlocker;        
        private int m_blockedTaskCount;
        private bool lastThreadStatus;

        public string CurrentTaskName
        {
            get
            {
                try
                {
                    return taskDataGrid.SelectedRows[0].Cells["nameColumn"].Value.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public string NameAndVersion
        {
            get
            {
                string nameversion = string.Empty;
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);

                if (attributes.Length != 0)
                    nameversion = ((AssemblyProductAttribute)attributes[0]).Product + " ";

                nameversion += "v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

                return nameversion;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            Text = NameAndVersion;
            
            m_blockedTaskCount = 0;
            
            m_taskBlocker = new TaskBlocker();
            m_taskBlocker.BlockedTask += new TaskBlocker.BlockedTaskHandler(taskBlocker_BlockedTask);

            lastThreadStatus = m_taskBlocker.IsRunning;

            if (!Preferences.startInForeground)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
        }

        private void refreshTaskList()
        {   
            try
            {
                taskDataGrid.Rows.Clear();

                List<Task> tmpList = m_taskBlocker.TaskList;

                foreach (Task task in tmpList)
                {
                    taskDataGrid.Rows.Add(new object[] { task.Enabled, task.Name, task.Count });
                }
            }
            catch (Exception ex)
            {
                Logger.Istance.fatal(ex.ToString());
                MessageBox.Show("An error occurred while trying to refresh the task list.\nCheck the log file for more informations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }
        }

        private void startMonitoring()
        {
            try
            {
                Logger.Istance.debug("Start monitoring.");
                m_taskBlocker.isKiller = !Preferences.MonitorMode;
                m_taskBlocker.start();                
            }
            catch (Exception ex)
            {
                Logger.Istance.exception(ex);
            }
        }

        private void stopMonitoring()
        {
            try
            {
                Logger.Istance.debug("Stop monitoring.");
                m_taskBlocker.stop();
            }
            catch (Exception ex)
            {
                Logger.Istance.exception(ex);
            }
        }
        
        private delegate void Invoker(object sender, BlockedTaskEventArgs e);
        private void taskBlocker_BlockedTask(object sender, BlockedTaskEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Invoker(taskBlocker_BlockedTask), new object[] {sender, e});
            }
            else
            {
                blockedTaskCountLabel.Text = (++m_blockedTaskCount).ToString();

                Logger.Istance.info("The task " + e.Task.Name + " was successfully blocked!");

                if (Preferences.showNotifications)
                {
                    notifyIcon.BalloonTipTitle = "Task Blocker - " + e.Task.Name;
                    notifyIcon.BalloonTipText = "The task " + e.Task.Name + " was successfully blocked!";
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.ShowBalloonTip(500);
                }

                refreshTaskList();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshTaskList();

            if (Preferences.runOnStart)
                startMonitoring();

            if (Preferences.logSizeWarning && Logger.Istance.FileSize > Preferences.maxLogFileSize)
            {
                notifyIcon.BalloonTipTitle = "Task Blocker - Warning";
                notifyIcon.BalloonTipText = "The log file filename exceeds its maximum size!\n (" + Logger.Istance.FileSize.ToString() + " Bytes)";
                notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                notifyIcon.ShowBalloonTip(500);

                Logger.Istance.warning(notifyIcon.BalloonTipText);
            }

            statusTimer.Enabled = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm add = new AddForm();
            add.Owner = this;
            add.ShowDialog();

            if (add.TaskName != string.Empty)
            {
                if (m_taskBlocker.taskExist(add.TaskName))
                {
                    MessageBox.Show("The selected process already exists in the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    m_taskBlocker.addTask(add.TaskName);
                    refreshTaskList();
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    MessageBox.Show("An error occurred while trying to add a new task to list.\nCheck the log file for more informations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (taskDataGrid.SelectedRows.Count > 0)
            {
                try
                {
                    string taskName = taskDataGrid.SelectedRows[0].Cells["nameColumn"].Value.ToString();

                    DialogResult result = MessageBox.Show("Do you really want to remove the " + taskName + " from the task list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                        return;

                    m_taskBlocker.removeTask(taskName);
                    refreshTaskList();
                }                
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    MessageBox.Show("An error occurred while trying to remove the selected task from list.\nCheck the log file for more informations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startToolButton_Click(object sender, EventArgs e)
        {
            startMonitoring();
        }

        private void stopToolButton_Click(object sender, EventArgs e)
        {
            stopMonitoring();
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            if (lastThreadStatus != m_taskBlocker.IsRunning)
            {
                lastThreadStatus = m_taskBlocker.IsRunning;

                if (m_taskBlocker.IsRunning)
                {
                    statusLabel.Text = "Running.";
                    notifyIcon.BalloonTipText = statusLabel.Text;
                    notifyIcon.Text = "Task Blocker: Running.";
                }
                else
                {
                    statusLabel.Text = "Stopped.";
                    notifyIcon.BalloonTipText = statusLabel.Text;
                    notifyIcon.Text = "Task Blocker: Stopped.";
                }

                notifyIcon.BalloonTipTitle = "Task Blocker - Info";
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.ShowBalloonTip(500);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;

                notifyIcon.BalloonTipTitle = "Task Blocker - Info";
                notifyIcon.BalloonTipText = "Minimized to tray.";
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.ShowBalloonTip(500);
            }
            else
                stopMonitoring();
        }

        private void preferencesMenuItem_Click(object sender, EventArgs e)
        {
            PreferencesForm pref = new PreferencesForm();
            pref.Owner = this;
            pref.ShowDialog();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Owner = this;
            about.ShowDialog();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
            else
                ShowInTaskbar = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void logFileMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Logger.FILENAME))
                    Process.Start(Preferences.logEditor, Logger.FILENAME);
                else
                    MessageBox.Show("Log file not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Logger.Istance.exception(ex);
            }
        }

        private void logDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(Application.ExecutablePath));
            }
            catch (Exception ex)
            {
                Logger.Istance.exception(ex);
            }
        }

        private void refreshTaskToolButton_Click(object sender, EventArgs e)
        {
            refreshTaskList();
        }

        private void taskDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            taskDataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void taskDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    m_taskBlocker.enableTask(CurrentTaskName, Convert.ToBoolean(taskDataGrid.Rows[e.RowIndex].Cells[0].Value));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        private void enableAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                m_taskBlocker.enableAllTasks(enableAllCheckBox.Checked);
                refreshTaskList();
            }
            catch (Exception ex)
            {
                Logger.Istance.exception(ex);
            }
        }

        private void resetAllCountersMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want reset all task counters?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;

                m_taskBlocker.resetAllCounters();
                m_blockedTaskCount = 0;
                refreshTaskList();
            }
            catch (Exception ex)
            {
                Logger.Istance.exception(ex);
            }
        }

        private void taskDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo test = taskDataGrid.HitTest(e.X, e.Y);

                if (test.Type == DataGridViewHitTestType.Cell)
                    taskDataGrid.Rows[test.RowIndex].Selected = true;
            }
        }

        private void resetCounterMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want reset " + CurrentTaskName + " counter?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;

                m_taskBlocker.resetTaskCounter(CurrentTaskName);
                refreshTaskList();
            }
            catch (Exception ex)
            {
                Logger.Istance.exception(ex);
            }
        }
    }
}
