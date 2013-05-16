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
using TaskBlocker.Tools;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace TaskBlocker
{
    public class Preferences
    {
        static IniFile ini = new IniFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location ) + "\\config.ini");

        public static bool launchAtStartup
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ini.readValue("General", "LaunchAtStartup", "False"));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return false;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("General", "LaunchAtStartup", value ? "True" : "False");

                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                    if (value)
                        rk.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
                    else
                        rk.DeleteValue(Application.ProductName, false);
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static bool startInForeground
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ini.readValue("General", "StartMinimized", "True"));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return false;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("General", "StartMinimized", value ? "True" : "False");
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static bool enableLog
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ini.readValue("Log", "EnableLog", "False"));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return false;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("Log", "EnableLog", value ? "True" : "False");
                    Logger.Istance.EnableLogOnFile = value;
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static bool logSizeWarning
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ini.readValue("Log", "SizeWarning", "True"));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return false;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("Log", "SizeWarning", value ? "True" : "False");
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static long maxLogFileSize
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ini.readValue("Log", "MaxFileSize", Convert.ToString(5*1024*1024)));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return 5*1024*1024;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("Log", "MaxFileSize", value.ToString());
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static string logEditor
        {
            get
            {
                try
                {
                    return ini.readValue("Log", "LogEditor", "notepad.exe");
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return "notepad.exe";
                }
            }

            set
            {
                try
                {
                    ini.writeValue("Log", "LogEditor", value);
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static bool runOnStart
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ini.readValue("Task", "RunOnStart", "False"));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return false;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("Task", "RunOnStart", value ? "True" : "False");
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static bool showNotifications
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ini.readValue("Task", "ShowNotifications", "True"));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return false;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("Task", "ShowNotifications", value ? "True" : "False");
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static bool MonitorMode
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ini.readValue("Task", "MonitorMode", "False"));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return false;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("Task", "MonitorMode", value ? "True" : "False");
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }

        public static bool RealTimeCheck
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ini.readValue("Task", "RealTimeCheck", "False"));
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                    return false;
                }
            }

            set
            {
                try
                {
                    ini.writeValue("Task", "RealTimeCheck", value ? "True" : "False");
                }
                catch (Exception ex)
                {
                    Logger.Istance.exception(ex);
                }
            }
        }
    }
}
