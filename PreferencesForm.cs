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
using System.IO;

namespace TaskBlocker
{
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            launchAtStartupCheckBox.Checked = Preferences.launchAtStartup;
            startInForegroundCheckBox.Checked = Preferences.startInForeground;
            enableLogCheckBox.Checked = Preferences.enableLog;
            sizeWarningCheckBox.Checked = Preferences.logSizeWarning;
            maxFileSizeNumeric.Value = (Preferences.maxLogFileSize / 1024) / 1024;
            logEditorTextBox.Text = Preferences.logEditor;
            runOnStartCheckBox.Checked = Preferences.runOnStart;
            showNotificationsGroupBox.Checked = Preferences.showNotifications;
            monitorModeCheckBox.Checked = Preferences.MonitorMode;
            realtimeCheckBox.Checked = Preferences.RealTimeCheck;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Preferences.launchAtStartup = launchAtStartupCheckBox.Checked;
            Preferences.startInForeground = startInForegroundCheckBox.Checked;
            Preferences.enableLog = enableLogCheckBox.Checked;
            Preferences.logSizeWarning = sizeWarningCheckBox.Checked;
            Preferences.maxLogFileSize = Convert.ToInt64(maxFileSizeNumeric.Value) * 1024 * 1024;
            Preferences.logEditor = logEditorTextBox.Text.Trim();
            Preferences.runOnStart = runOnStartCheckBox.Checked;
            Preferences.showNotifications = showNotificationsGroupBox.Checked;            

            if (Preferences.MonitorMode != monitorModeCheckBox.Checked)
                MessageBox.Show("Monitor mode has been changed. Restart for applying your changes!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Preferences.MonitorMode = monitorModeCheckBox.Checked;

            if (Preferences.RealTimeCheck != realtimeCheckBox.Checked)
                MessageBox.Show("RealTimeCheck has been changed. Restart for applying your changes!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Preferences.RealTimeCheck = realtimeCheckBox.Checked;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectEditorButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                logEditorTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
