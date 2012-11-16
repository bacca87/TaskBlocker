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
using System.IO;

namespace TaskBlocker
{
    public class Logger
    {
        #region Singleton

        private static Logger singleton = null;
        public static Logger Istance
        {
            get
            {
                if (singleton == null)
                    singleton = new Logger();

                return singleton;
            }
        }

        #endregion

        private object m_fileLock;
        private object m_propertyLock;
        public const string FILENAME = "history.log";

        private bool m_enableLogOnFile;
        public bool EnableLogOnFile
        {
            get
            {
                lock (m_propertyLock)
                {
                    return m_enableLogOnFile;
                }
            }
            set
            {
                lock (m_propertyLock)
                {
                    m_enableLogOnFile = value;
                }
            }
        }
        
        public long FileSize
        {
            get
            {
                FileInfo info = new FileInfo(FILENAME);
                return info.Length;
            }
        }        

        public Logger()
        {
            m_fileLock = new object();
            m_propertyLock = new object();
            EnableLogOnFile = false;
        }
                
        public void debug(string text)
        {
            write(string.Format("[debug] {0}", text));
        }

        public void info(string text)
        {
            write(string.Format("[Info] {0}", text));
        }   

        public void warning(string text)
        {
            write(string.Format("[warning] {0}", text));
        }
        
        public void error(string text)
        {
            write(string.Format("[error] {0}", text));
        }

        public void exception(Exception e)
        {
            write(string.Format("[exception] {0}",
                "\rException classes: " + e.GetType().ToString() +
                "\rException messages: " + e.Message +
                "\rHelp Link: " + e.HelpLink +
                "\rStack Traces: " + e.StackTrace));
        }

        public void fatal(string text)
        {
            write(string.Format("[fatal] {0}", text));
        }

        private void write(string text)
        {
            string logtext = string.Format("[{0}] {1}", DateTime.Now, text).Replace("\n", "");

            lock (m_fileLock)
            {
                try
                {
                    Console.WriteLine(logtext);

                    if (!File.Exists(FILENAME))
                        File.Create(FILENAME).Dispose();

                    if (EnableLogOnFile)
                    {
                        using (StreamWriter sw = new StreamWriter(FILENAME, true))
                        {
                            sw.WriteLine(logtext);
                        }
                    }
                }
                catch { }
            }
        }
    }
}
