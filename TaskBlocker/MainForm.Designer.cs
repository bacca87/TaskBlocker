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
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllCountersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enableAllCheckBox = new System.Windows.Forms.CheckBox();
            this.taskDataGrid = new System.Windows.Forms.DataGridView();
            this.enabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.resetCounterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusDescriptionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.blockedTaskLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.blockedTaskCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.refreshTaskToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolButton = new System.Windows.Forms.ToolStripButton();
            this.stopToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolButton = new System.Windows.Forms.ToolStripButton();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataGrid)).BeginInit();
            this.taskMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editMenuItem,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(360, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.toolStripMenuItem2,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logFileMenuItem,
            this.logDirectoryMenuItem});
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openMenuItem.Text = "&Open";
            // 
            // logFileMenuItem
            // 
            this.logFileMenuItem.Name = "logFileMenuItem";
            this.logFileMenuItem.Size = new System.Drawing.Size(145, 22);
            this.logFileMenuItem.Text = "Log &File";
            this.logFileMenuItem.Click += new System.EventHandler(this.logFileMenuItem_Click);
            // 
            // logDirectoryMenuItem
            // 
            this.logDirectoryMenuItem.Name = "logDirectoryMenuItem";
            this.logDirectoryMenuItem.Size = new System.Drawing.Size(145, 22);
            this.logDirectoryMenuItem.Text = "Log &Directory";
            this.logDirectoryMenuItem.Click += new System.EventHandler(this.logDirectoryMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllCountersMenuItem,
            this.toolStripMenuItem3,
            this.preferencesMenuItem});
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editMenuItem.Text = "&Edit";
            // 
            // resetAllCountersMenuItem
            // 
            this.resetAllCountersMenuItem.Name = "resetAllCountersMenuItem";
            this.resetAllCountersMenuItem.Size = new System.Drawing.Size(166, 22);
            this.resetAllCountersMenuItem.Text = "Reset all counters";
            this.resetAllCountersMenuItem.Click += new System.EventHandler(this.resetAllCountersMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 6);
            // 
            // preferencesMenuItem
            // 
            this.preferencesMenuItem.Name = "preferencesMenuItem";
            this.preferencesMenuItem.Size = new System.Drawing.Size(166, 22);
            this.preferencesMenuItem.Text = "Preferences";
            this.preferencesMenuItem.Click += new System.EventHandler(this.preferencesMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "&Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enableAllCheckBox);
            this.groupBox1.Controls.Add(this.taskDataGrid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 281);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blocked Tasks List";
            // 
            // enableAllCheckBox
            // 
            this.enableAllCheckBox.AutoSize = true;
            this.enableAllCheckBox.Location = new System.Drawing.Point(8, 21);
            this.enableAllCheckBox.Name = "enableAllCheckBox";
            this.enableAllCheckBox.Size = new System.Drawing.Size(15, 14);
            this.enableAllCheckBox.TabIndex = 6;
            this.enableAllCheckBox.Tag = "dfgdf";
            this.enableAllCheckBox.UseVisualStyleBackColor = true;
            this.enableAllCheckBox.CheckedChanged += new System.EventHandler(this.enableAllCheckBox_CheckedChanged);
            // 
            // taskDataGrid
            // 
            this.taskDataGrid.AllowUserToAddRows = false;
            this.taskDataGrid.AllowUserToDeleteRows = false;
            this.taskDataGrid.AllowUserToResizeColumns = false;
            this.taskDataGrid.AllowUserToResizeRows = false;
            this.taskDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.taskDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledColumn,
            this.nameColumn,
            this.countColumn});
            this.taskDataGrid.ContextMenuStrip = this.taskMenu;
            this.taskDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskDataGrid.Location = new System.Drawing.Point(3, 16);
            this.taskDataGrid.MultiSelect = false;
            this.taskDataGrid.Name = "taskDataGrid";
            this.taskDataGrid.RowHeadersVisible = false;
            this.taskDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taskDataGrid.Size = new System.Drawing.Size(354, 262);
            this.taskDataGrid.TabIndex = 5;
            this.taskDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskDataGrid_CellContentClick);
            this.taskDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskDataGrid_CellValueChanged);
            this.taskDataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.taskDataGrid_MouseDown);
            // 
            // enabledColumn
            // 
            this.enabledColumn.FillWeight = 22.84264F;
            this.enabledColumn.HeaderText = "";
            this.enabledColumn.Name = "enabledColumn";
            this.enabledColumn.Width = 20;
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameColumn.FillWeight = 138.5787F;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // countColumn
            // 
            this.countColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countColumn.FillWeight = 138.5787F;
            this.countColumn.HeaderText = "Blocked";
            this.countColumn.Name = "countColumn";
            this.countColumn.ReadOnly = true;
            // 
            // taskMenu
            // 
            this.taskMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripMenuItem4,
            this.resetCounterMenuItem});
            this.taskMenu.Name = "taskMenu";
            this.taskMenu.Size = new System.Drawing.Size(149, 76);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Image = global::TaskBlocker.Properties.Resources.add;
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addMenuItem.Text = "&Add";
            this.addMenuItem.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::TaskBlocker.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.removeToolStripMenuItem.Text = "&Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(145, 6);
            // 
            // resetCounterMenuItem
            // 
            this.resetCounterMenuItem.Name = "resetCounterMenuItem";
            this.resetCounterMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetCounterMenuItem.Text = "Reset Counter";
            this.resetCounterMenuItem.Click += new System.EventHandler(this.resetCounterMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusDescriptionLabel,
            this.statusLabel,
            this.spacerLabel,
            this.blockedTaskLabel,
            this.blockedTaskCountLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 330);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(360, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusDescriptionLabel
            // 
            this.statusDescriptionLabel.Name = "statusDescriptionLabel";
            this.statusDescriptionLabel.Size = new System.Drawing.Size(42, 17);
            this.statusDescriptionLabel.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(51, 17);
            this.statusLabel.Text = "Stopped";
            // 
            // spacerLabel
            // 
            this.spacerLabel.Name = "spacerLabel";
            this.spacerLabel.Size = new System.Drawing.Size(155, 17);
            this.spacerLabel.Spring = true;
            // 
            // blockedTaskLabel
            // 
            this.blockedTaskLabel.Name = "blockedTaskLabel";
            this.blockedTaskLabel.Size = new System.Drawing.Size(84, 17);
            this.blockedTaskLabel.Text = "Blocked Tasks:";
            // 
            // blockedTaskCountLabel
            // 
            this.blockedTaskCountLabel.Name = "blockedTaskCountLabel";
            this.blockedTaskCountLabel.Size = new System.Drawing.Size(13, 17);
            this.blockedTaskCountLabel.Text = "0";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshTaskToolButton,
            this.toolStripSeparator1,
            this.startToolButton,
            this.stopToolButton,
            this.toolStripSeparator2,
            this.addToolButton,
            this.removeToolButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(360, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // refreshTaskToolButton
            // 
            this.refreshTaskToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshTaskToolButton.Image = global::TaskBlocker.Properties.Resources.arrow_refresh;
            this.refreshTaskToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshTaskToolButton.Name = "refreshTaskToolButton";
            this.refreshTaskToolButton.Size = new System.Drawing.Size(23, 22);
            this.refreshTaskToolButton.Text = "Refresh List";
            this.refreshTaskToolButton.Click += new System.EventHandler(this.refreshTaskToolButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // startToolButton
            // 
            this.startToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startToolButton.Image = global::TaskBlocker.Properties.Resources.control_play;
            this.startToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startToolButton.Name = "startToolButton";
            this.startToolButton.Size = new System.Drawing.Size(23, 22);
            this.startToolButton.Text = "Start Monitoring";
            this.startToolButton.Click += new System.EventHandler(this.startToolButton_Click);
            // 
            // stopToolButton
            // 
            this.stopToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopToolButton.Image = global::TaskBlocker.Properties.Resources.control_stop;
            this.stopToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolButton.Name = "stopToolButton";
            this.stopToolButton.Size = new System.Drawing.Size(23, 22);
            this.stopToolButton.Text = "Stop Monitoring";
            this.stopToolButton.Click += new System.EventHandler(this.stopToolButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // addToolButton
            // 
            this.addToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolButton.Image = global::TaskBlocker.Properties.Resources.add;
            this.addToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolButton.Name = "addToolButton";
            this.addToolButton.Size = new System.Drawing.Size(23, 22);
            this.addToolButton.Text = "Add Task";
            this.addToolButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeToolButton
            // 
            this.removeToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeToolButton.Image = global::TaskBlocker.Properties.Resources.delete;
            this.removeToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolButton.Name = "removeToolButton";
            this.removeToolButton.Size = new System.Drawing.Size(23, 22);
            this.removeToolButton.Text = "Remove Task";
            this.removeToolButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // statusTimer
            // 
            this.statusTimer.Interval = 500;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Task Blocker: Running.";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.startToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(153, 98);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.stopToolStripMenuItem1});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "Monitoring";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Image = global::TaskBlocker.Properties.Resources.control_play;
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem1.Text = "&Start";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolButton_Click);
            // 
            // stopToolStripMenuItem1
            // 
            this.stopToolStripMenuItem1.Image = global::TaskBlocker.Properties.Resources.control_stop;
            this.stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
            this.stopToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem1.Text = "&Stop";
            this.stopToolStripMenuItem1.Click += new System.EventHandler(this.stopToolButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 352);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Blocker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataGrid)).EndInit();
            this.taskMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton startToolButton;
        private System.Windows.Forms.ToolStripButton stopToolButton;
        private System.Windows.Forms.ToolStripStatusLabel statusDescriptionLabel;
        private System.Windows.Forms.ToolStripMenuItem preferencesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripStatusLabel spacerLabel;
        private System.Windows.Forms.ToolStripStatusLabel blockedTaskLabel;
        private System.Windows.Forms.ToolStripStatusLabel blockedTaskCountLabel;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logDirectoryMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.DataGridView taskDataGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshTaskToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton addToolButton;
        private System.Windows.Forms.ToolStripButton removeToolButton;
        private System.Windows.Forms.ContextMenuStrip taskMenu;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.CheckBox enableAllCheckBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countColumn;
        private System.Windows.Forms.ToolStripMenuItem resetAllCountersMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem resetCounterMenuItem;
    }
}

