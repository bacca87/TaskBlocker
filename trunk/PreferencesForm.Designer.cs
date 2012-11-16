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

namespace TaskBlocker
{
    partial class PreferencesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.launchAtStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.showNotificationsGroupBox = new System.Windows.Forms.CheckBox();
            this.enableLogCheckBox = new System.Windows.Forms.CheckBox();
            this.generalGroup = new System.Windows.Forms.GroupBox();
            this.startInForegroundCheckBox = new System.Windows.Forms.CheckBox();
            this.taskGroup = new System.Windows.Forms.GroupBox();
            this.monitorModeCheckBox = new System.Windows.Forms.CheckBox();
            this.runOnStartCheckBox = new System.Windows.Forms.CheckBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.selectEditorButton = new System.Windows.Forms.Button();
            this.logEditorLabel = new System.Windows.Forms.Label();
            this.logEditorTextBox = new System.Windows.Forms.TextBox();
            this.mbLabel = new System.Windows.Forms.Label();
            this.maxFileSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.sizeWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.generalGroup.SuspendLayout();
            this.taskGroup.SuspendLayout();
            this.logGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxFileSizeNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // launchAtStartupCheckBox
            // 
            this.launchAtStartupCheckBox.AutoSize = true;
            this.launchAtStartupCheckBox.Location = new System.Drawing.Point(14, 19);
            this.launchAtStartupCheckBox.Name = "launchAtStartupCheckBox";
            this.launchAtStartupCheckBox.Size = new System.Drawing.Size(228, 17);
            this.launchAtStartupCheckBox.TabIndex = 0;
            this.launchAtStartupCheckBox.Text = "Launch the application at windows startup.";
            this.launchAtStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // showNotificationsGroupBox
            // 
            this.showNotificationsGroupBox.AutoSize = true;
            this.showNotificationsGroupBox.Location = new System.Drawing.Point(14, 43);
            this.showNotificationsGroupBox.Name = "showNotificationsGroupBox";
            this.showNotificationsGroupBox.Size = new System.Drawing.Size(231, 17);
            this.showNotificationsGroupBox.TabIndex = 1;
            this.showNotificationsGroupBox.Text = "Show a notification when a task is blocked.";
            this.showNotificationsGroupBox.UseVisualStyleBackColor = true;
            // 
            // enableLogCheckBox
            // 
            this.enableLogCheckBox.AutoSize = true;
            this.enableLogCheckBox.Location = new System.Drawing.Point(14, 19);
            this.enableLogCheckBox.Name = "enableLogCheckBox";
            this.enableLogCheckBox.Size = new System.Drawing.Size(110, 17);
            this.enableLogCheckBox.TabIndex = 2;
            this.enableLogCheckBox.Text = "Enable log on file.";
            this.enableLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // generalGroup
            // 
            this.generalGroup.Controls.Add(this.startInForegroundCheckBox);
            this.generalGroup.Controls.Add(this.launchAtStartupCheckBox);
            this.generalGroup.Location = new System.Drawing.Point(12, 12);
            this.generalGroup.Name = "generalGroup";
            this.generalGroup.Size = new System.Drawing.Size(296, 70);
            this.generalGroup.TabIndex = 3;
            this.generalGroup.TabStop = false;
            this.generalGroup.Text = "General Options";
            // 
            // startInForegroundCheckBox
            // 
            this.startInForegroundCheckBox.AutoSize = true;
            this.startInForegroundCheckBox.Location = new System.Drawing.Point(14, 44);
            this.startInForegroundCheckBox.Name = "startInForegroundCheckBox";
            this.startInForegroundCheckBox.Size = new System.Drawing.Size(186, 17);
            this.startInForegroundCheckBox.TabIndex = 3;
            this.startInForegroundCheckBox.Text = "Show in foreground when it starts.";
            this.startInForegroundCheckBox.UseVisualStyleBackColor = true;
            // 
            // taskGroup
            // 
            this.taskGroup.Controls.Add(this.monitorModeCheckBox);
            this.taskGroup.Controls.Add(this.runOnStartCheckBox);
            this.taskGroup.Controls.Add(this.showNotificationsGroupBox);
            this.taskGroup.Location = new System.Drawing.Point(12, 197);
            this.taskGroup.Name = "taskGroup";
            this.taskGroup.Size = new System.Drawing.Size(296, 91);
            this.taskGroup.TabIndex = 4;
            this.taskGroup.TabStop = false;
            this.taskGroup.Text = "Task";
            // 
            // monitorModeCheckBox
            // 
            this.monitorModeCheckBox.AutoSize = true;
            this.monitorModeCheckBox.Location = new System.Drawing.Point(14, 66);
            this.monitorModeCheckBox.Name = "monitorModeCheckBox";
            this.monitorModeCheckBox.Size = new System.Drawing.Size(208, 17);
            this.monitorModeCheckBox.TabIndex = 2;
            this.monitorModeCheckBox.Text = "Monitor mode. (Tasks will not be killed)";
            this.monitorModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // runOnStartCheckBox
            // 
            this.runOnStartCheckBox.AutoSize = true;
            this.runOnStartCheckBox.Location = new System.Drawing.Point(14, 20);
            this.runOnStartCheckBox.Name = "runOnStartCheckBox";
            this.runOnStartCheckBox.Size = new System.Drawing.Size(194, 17);
            this.runOnStartCheckBox.TabIndex = 0;
            this.runOnStartCheckBox.Text = "Start monitoring on application start.";
            this.runOnStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(233, 294);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "&Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(152, 294);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.selectEditorButton);
            this.logGroupBox.Controls.Add(this.logEditorLabel);
            this.logGroupBox.Controls.Add(this.logEditorTextBox);
            this.logGroupBox.Controls.Add(this.mbLabel);
            this.logGroupBox.Controls.Add(this.maxFileSizeNumeric);
            this.logGroupBox.Controls.Add(this.sizeWarningCheckBox);
            this.logGroupBox.Controls.Add(this.enableLogCheckBox);
            this.logGroupBox.Location = new System.Drawing.Point(12, 88);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(296, 103);
            this.logGroupBox.TabIndex = 7;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log";
            // 
            // selectEditorButton
            // 
            this.selectEditorButton.Location = new System.Drawing.Point(259, 71);
            this.selectEditorButton.Name = "selectEditorButton";
            this.selectEditorButton.Size = new System.Drawing.Size(26, 19);
            this.selectEditorButton.TabIndex = 9;
            this.selectEditorButton.Text = "...";
            this.selectEditorButton.UseVisualStyleBackColor = true;
            this.selectEditorButton.Click += new System.EventHandler(this.selectEditorButton_Click);
            // 
            // logEditorLabel
            // 
            this.logEditorLabel.AutoSize = true;
            this.logEditorLabel.Location = new System.Drawing.Point(8, 74);
            this.logEditorLabel.Name = "logEditorLabel";
            this.logEditorLabel.Size = new System.Drawing.Size(90, 13);
            this.logEditorLabel.TabIndex = 8;
            this.logEditorLabel.Text = "Default log editor:";
            // 
            // logEditorTextBox
            // 
            this.logEditorTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.logEditorTextBox.Location = new System.Drawing.Point(104, 71);
            this.logEditorTextBox.Name = "logEditorTextBox";
            this.logEditorTextBox.ReadOnly = true;
            this.logEditorTextBox.Size = new System.Drawing.Size(153, 20);
            this.logEditorTextBox.TabIndex = 7;
            // 
            // mbLabel
            // 
            this.mbLabel.AutoSize = true;
            this.mbLabel.Location = new System.Drawing.Point(257, 43);
            this.mbLabel.Name = "mbLabel";
            this.mbLabel.Size = new System.Drawing.Size(23, 13);
            this.mbLabel.TabIndex = 5;
            this.mbLabel.Text = "MB";
            // 
            // maxFileSizeNumeric
            // 
            this.maxFileSizeNumeric.DecimalPlaces = 1;
            this.maxFileSizeNumeric.Location = new System.Drawing.Point(168, 41);
            this.maxFileSizeNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.maxFileSizeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxFileSizeNumeric.Name = "maxFileSizeNumeric";
            this.maxFileSizeNumeric.Size = new System.Drawing.Size(89, 20);
            this.maxFileSizeNumeric.TabIndex = 4;
            this.maxFileSizeNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // sizeWarningCheckBox
            // 
            this.sizeWarningCheckBox.AutoSize = true;
            this.sizeWarningCheckBox.Location = new System.Drawing.Point(14, 42);
            this.sizeWarningCheckBox.Name = "sizeWarningCheckBox";
            this.sizeWarningCheckBox.Size = new System.Drawing.Size(157, 17);
            this.sizeWarningCheckBox.TabIndex = 3;
            this.sizeWarningCheckBox.Text = "Warning if file size exceeds:";
            this.sizeWarningCheckBox.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "exe";
            this.openFileDialog.Filter = "exe files (*.exe)|*.exe";
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 324);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.taskGroup);
            this.Controls.Add(this.generalGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.generalGroup.ResumeLayout(false);
            this.generalGroup.PerformLayout();
            this.taskGroup.ResumeLayout(false);
            this.taskGroup.PerformLayout();
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxFileSizeNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox launchAtStartupCheckBox;
        private System.Windows.Forms.CheckBox showNotificationsGroupBox;
        private System.Windows.Forms.CheckBox enableLogCheckBox;
        private System.Windows.Forms.GroupBox generalGroup;
        private System.Windows.Forms.GroupBox taskGroup;
        private System.Windows.Forms.CheckBox runOnStartCheckBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox startInForegroundCheckBox;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.Label mbLabel;
        private System.Windows.Forms.NumericUpDown maxFileSizeNumeric;
        private System.Windows.Forms.CheckBox sizeWarningCheckBox;
        private System.Windows.Forms.Button selectEditorButton;
        private System.Windows.Forms.Label logEditorLabel;
        private System.Windows.Forms.TextBox logEditorTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox monitorModeCheckBox;
    }
}