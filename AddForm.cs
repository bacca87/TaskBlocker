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
using System.Diagnostics;
using System.IO;

namespace TaskBlocker
{
    public partial class AddForm : Form
    {
        public string TaskName { get; internal set; }

        private string CurrentProcessName
        {
            get
            {
                if (taskDataGrid != null && taskDataGrid.SelectedRows.Count > 0)
                    return taskDataGrid.SelectedRows[0].Cells["nameColumn"].Value.ToString();
                else
                    return string.Empty;
            }
        }

        public AddForm()
        {
            InitializeComponent();

            manualRadioButton.Checked = true;
            TaskName = string.Empty;
        }        

        private void refreshTaskList()
        {
            taskDataGrid.Rows.Clear();

            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                string processName = string.Empty;                
                int processId = -1;
                string processDescription = string.Empty;

                try
                {
                    processName = process.ProcessName + ".exe";
                    processId = process.Id;
                    processDescription = process.MainModule.FileVersionInfo.FileDescription;                    
                }
                catch { }
                               
                if (processName == string.Empty)
                    continue;

                taskDataGrid.Rows.Add(new object[] { processName, processId, processDescription });
            }

            processCountLabel.Text = taskDataGrid.Rows.Count.ToString();
        }

        private void refreshState()
        {
            manualTextBox.Enabled = false;
            fileTextBox.Enabled = false;
            selectFileButton.Enabled = false;
            refreshButton.Enabled = false;
            taskDataGrid.Enabled = false;
            taskDataGrid.Rows.Clear();

            if(manualRadioButton.Checked)
            {
                manualTextBox.Enabled = true;
                manualTextBox.Focus();
            }
            else if(fileRadioButton.Checked)
            {
                fileTextBox.Enabled = true;
                selectFileButton.Enabled = true;
                selectFileButton.Focus();
            }
            else if (processListRadioButton.Checked)
            {
                refreshButton.Enabled = true;
                taskDataGrid.Enabled = true;
                taskDataGrid.Focus();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshTaskList();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            refreshState();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            TaskName = string.Empty;
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (manualRadioButton.Checked)
            {
                if (manualTextBox.Text.Trim() != string.Empty)
                {
                    TaskName = manualTextBox.Text.Trim().ToLower();
                    if (!TaskName.Contains(".exe"))
                        TaskName += ".exe";
                }
                else
                    error = true;
            }
            else if (fileRadioButton.Checked)
            {
                if (fileTextBox.Text.Trim() != string.Empty)
                    TaskName = Path.GetFileName(fileTextBox.Text).ToLower();
                else
                    error = true;
            }
            else if (processListRadioButton.Checked)
            {
                if (CurrentProcessName != string.Empty)
                    TaskName = CurrentProcessName.ToLower();
                else
                    error = true;
            }

            if (TaskName == Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName).ToLower())
                error = true;
            
            if(error)
                MessageBox.Show("You must select a valid process name before continue!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                Close();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();            

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void manualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            refreshState();
        }

        private void fileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            refreshState();
        }

        private void processListRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            refreshState();
            if(processListRadioButton.Checked)
                refreshTaskList();
        }
    }
}
