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
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace TaskBlocker.Tools
{
    public class IniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private string m_path;

        public IniFile(string iniPath)
        {
            m_path = iniPath;
        }

        public void writeValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, m_path);
        }

        public string readValue(string section, string key)
        {
            return readValue(section, key, string.Empty);
        }

        public string readValue(string section, string key, string defaultValue)
        {
            StringBuilder temp = new StringBuilder(255);
                        
            GetPrivateProfileString(section, key, defaultValue, temp, 255, m_path);                
            
            return temp.ToString();
        }        
    }
}
