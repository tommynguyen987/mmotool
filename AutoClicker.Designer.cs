namespace MyTool
{
    partial class frmAutoClicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoClicker));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAutorunTasks = new System.Windows.Forms.TabPage();
            this.groupAutoTasks = new System.Windows.Forms.GroupBox();
            this.chkPaidviewpoint = new System.Windows.Forms.CheckBox();
            this.chkPresearch = new System.Windows.Forms.CheckBox();
            this.chkAutoFreebitco = new System.Windows.Forms.CheckBox();
            this.chkFreeBitcoin = new System.Windows.Forms.CheckBox();
            this.chkIndexBitco = new System.Windows.Forms.CheckBox();
            this.chkTimebucks = new System.Windows.Forms.CheckBox();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.chkIsAutoRunServices = new System.Windows.Forms.CheckBox();
            this.chkIsRunProfilesInstalled = new System.Windows.Forms.CheckBox();
            this.txtFromProfile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalProfiles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProfilesEveryRunning = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateProfiles = new System.Windows.Forms.Button();
            this.btnCreateAccounts = new System.Windows.Forms.Button();
            this.btnStartTasks = new System.Windows.Forms.Button();
            this.tabManualTasks = new System.Windows.Forms.TabPage();
            this.groupManualSettings = new System.Windows.Forms.GroupBox();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.groupProxyTasks = new System.Windows.Forms.GroupBox();
            this.chkAdbtc = new System.Windows.Forms.CheckBox();
            this.chkHashingadSpace = new System.Windows.Forms.CheckBox();
            this.chkBtcVic = new System.Windows.Forms.CheckBox();
            this.chkBitpick = new System.Windows.Forms.CheckBox();
            this.chkBtcClicks = new System.Windows.Forms.CheckBox();
            this.chkBither = new System.Windows.Forms.CheckBox();
            this.chkFreeLitecoin = new System.Windows.Forms.CheckBox();
            this.chkFreeBitco = new System.Windows.Forms.CheckBox();
            this.btnCreateProfilesManual = new System.Windows.Forms.Button();
            this.btnCreateAccountsManual = new System.Windows.Forms.Button();
            this.btnStartManual = new System.Windows.Forms.Button();
            this.lstStatus = new System.Windows.Forms.TextBox();
            this.lstStatus2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabAutorunTasks.SuspendLayout();
            this.groupAutoTasks.SuspendLayout();
            this.groupSettings.SuspendLayout();
            this.tabManualTasks.SuspendLayout();
            this.groupManualSettings.SuspendLayout();
            this.groupProxyTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAutorunTasks);
            this.tabControl1.Controls.Add(this.tabManualTasks);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(708, 584);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAutorunTasks
            // 
            this.tabAutorunTasks.Controls.Add(this.lstStatus);
            this.tabAutorunTasks.Controls.Add(this.groupAutoTasks);
            this.tabAutorunTasks.Controls.Add(this.groupSettings);
            this.tabAutorunTasks.Controls.Add(this.btnCreateProfiles);
            this.tabAutorunTasks.Controls.Add(this.btnCreateAccounts);
            this.tabAutorunTasks.Controls.Add(this.btnStartTasks);
            this.tabAutorunTasks.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAutorunTasks.Location = new System.Drawing.Point(4, 26);
            this.tabAutorunTasks.Margin = new System.Windows.Forms.Padding(4);
            this.tabAutorunTasks.Name = "tabAutorunTasks";
            this.tabAutorunTasks.Padding = new System.Windows.Forms.Padding(4);
            this.tabAutorunTasks.Size = new System.Drawing.Size(700, 554);
            this.tabAutorunTasks.TabIndex = 0;
            this.tabAutorunTasks.Text = "Autorun Tasks";
            this.tabAutorunTasks.UseVisualStyleBackColor = true;
            // 
            // groupAutoTasks
            // 
            this.groupAutoTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAutoTasks.Controls.Add(this.chkPaidviewpoint);
            this.groupAutoTasks.Controls.Add(this.chkPresearch);
            this.groupAutoTasks.Controls.Add(this.chkAutoFreebitco);
            this.groupAutoTasks.Controls.Add(this.chkFreeBitcoin);
            this.groupAutoTasks.Controls.Add(this.chkIndexBitco);
            this.groupAutoTasks.Controls.Add(this.chkTimebucks);
            this.groupAutoTasks.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAutoTasks.Location = new System.Drawing.Point(18, 13);
            this.groupAutoTasks.Name = "groupAutoTasks";
            this.groupAutoTasks.Size = new System.Drawing.Size(662, 102);
            this.groupAutoTasks.TabIndex = 8;
            this.groupAutoTasks.TabStop = false;
            this.groupAutoTasks.Text = "Tasks";
            // 
            // chkPaidviewpoint
            // 
            this.chkPaidviewpoint.AutoSize = true;
            this.chkPaidviewpoint.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPaidviewpoint.Location = new System.Drawing.Point(386, 30);
            this.chkPaidviewpoint.Name = "chkPaidviewpoint";
            this.chkPaidviewpoint.Size = new System.Drawing.Size(109, 21);
            this.chkPaidviewpoint.TabIndex = 1;
            this.chkPaidviewpoint.Text = "Paidviewpoint";
            this.chkPaidviewpoint.UseVisualStyleBackColor = true;
            this.chkPaidviewpoint.CheckedChanged += new System.EventHandler(this.chkPaidviewpoint_CheckedChanged);
            this.chkPaidviewpoint.Click += new System.EventHandler(this.chkPaidviewpoint_Click);
            // 
            // chkPresearch
            // 
            this.chkPresearch.AutoSize = true;
            this.chkPresearch.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPresearch.Location = new System.Drawing.Point(267, 30);
            this.chkPresearch.Name = "chkPresearch";
            this.chkPresearch.Size = new System.Drawing.Size(87, 21);
            this.chkPresearch.TabIndex = 3;
            this.chkPresearch.Text = "Presearch";
            this.chkPresearch.UseVisualStyleBackColor = true;
            this.chkPresearch.CheckedChanged += new System.EventHandler(this.chkPresearch_CheckedChanged);
            this.chkPresearch.Click += new System.EventHandler(this.chkPresearch_Click);
            // 
            // chkAutoFreebitco
            // 
            this.chkAutoFreebitco.AutoSize = true;
            this.chkAutoFreebitco.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoFreebitco.Location = new System.Drawing.Point(25, 30);
            this.chkAutoFreebitco.Name = "chkAutoFreebitco";
            this.chkAutoFreebitco.Size = new System.Drawing.Size(85, 21);
            this.chkAutoFreebitco.TabIndex = 0;
            this.chkAutoFreebitco.Text = "FreeBitco";
            this.chkAutoFreebitco.UseVisualStyleBackColor = true;
            this.chkAutoFreebitco.CheckedChanged += new System.EventHandler(this.chkAutoFreebitco_CheckedChanged);
            this.chkAutoFreebitco.Click += new System.EventHandler(this.chkAutoFreebitco_Click);
            // 
            // chkFreeBitcoin
            // 
            this.chkFreeBitcoin.AutoSize = true;
            this.chkFreeBitcoin.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFreeBitcoin.Location = new System.Drawing.Point(25, 64);
            this.chkFreeBitcoin.Name = "chkFreeBitcoin";
            this.chkFreeBitcoin.Size = new System.Drawing.Size(95, 21);
            this.chkFreeBitcoin.TabIndex = 0;
            this.chkFreeBitcoin.Text = "FreeBitcoin";
            this.chkFreeBitcoin.UseVisualStyleBackColor = true;
            this.chkFreeBitcoin.CheckedChanged += new System.EventHandler(this.chkFreeBitcoin_CheckedChanged);
            this.chkFreeBitcoin.Click += new System.EventHandler(this.chkFreeBitcoin_Click);
            // 
            // chkIndexBitco
            // 
            this.chkIndexBitco.AutoSize = true;
            this.chkIndexBitco.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndexBitco.Location = new System.Drawing.Point(526, 30);
            this.chkIndexBitco.Name = "chkIndexBitco";
            this.chkIndexBitco.Size = new System.Drawing.Size(91, 21);
            this.chkIndexBitco.TabIndex = 0;
            this.chkIndexBitco.Text = "IndexBitco";
            this.chkIndexBitco.UseVisualStyleBackColor = true;
            this.chkIndexBitco.CheckedChanged += new System.EventHandler(this.chkIndexBitco_CheckedChanged);
            this.chkIndexBitco.Click += new System.EventHandler(this.chkIndexBitco_Click);
            // 
            // chkTimebucks
            // 
            this.chkTimebucks.AutoSize = true;
            this.chkTimebucks.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTimebucks.Location = new System.Drawing.Point(147, 30);
            this.chkTimebucks.Name = "chkTimebucks";
            this.chkTimebucks.Size = new System.Drawing.Size(90, 21);
            this.chkTimebucks.TabIndex = 0;
            this.chkTimebucks.Text = "Timebucks";
            this.chkTimebucks.UseVisualStyleBackColor = true;
            this.chkTimebucks.CheckedChanged += new System.EventHandler(this.chkTimebucks_CheckedChanged);
            this.chkTimebucks.Click += new System.EventHandler(this.chkTimebucks_Click);
            // 
            // groupSettings
            // 
            this.groupSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSettings.Controls.Add(this.chkIsAutoRunServices);
            this.groupSettings.Controls.Add(this.chkIsRunProfilesInstalled);
            this.groupSettings.Controls.Add(this.txtFromProfile);
            this.groupSettings.Controls.Add(this.label3);
            this.groupSettings.Controls.Add(this.txtTotalProfiles);
            this.groupSettings.Controls.Add(this.label2);
            this.groupSettings.Controls.Add(this.txtProfilesEveryRunning);
            this.groupSettings.Controls.Add(this.label1);
            this.groupSettings.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSettings.Location = new System.Drawing.Point(18, 130);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(662, 194);
            this.groupSettings.TabIndex = 2;
            this.groupSettings.TabStop = false;
            this.groupSettings.Text = "Settings";
            // 
            // chkIsAutoRunServices
            // 
            this.chkIsAutoRunServices.AutoSize = true;
            this.chkIsAutoRunServices.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsAutoRunServices.Location = new System.Drawing.Point(23, 161);
            this.chkIsAutoRunServices.Name = "chkIsAutoRunServices";
            this.chkIsAutoRunServices.Size = new System.Drawing.Size(252, 21);
            this.chkIsAutoRunServices.TabIndex = 4;
            this.chkIsAutoRunServices.Text = "Autorun services when program starts";
            this.chkIsAutoRunServices.UseVisualStyleBackColor = true;
            this.chkIsAutoRunServices.CheckedChanged += new System.EventHandler(this.chkIsAutoRunServices_CheckedChanged);
            // 
            // chkIsRunProfilesInstalled
            // 
            this.chkIsRunProfilesInstalled.AutoSize = true;
            this.chkIsRunProfilesInstalled.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsRunProfilesInstalled.Location = new System.Drawing.Point(23, 133);
            this.chkIsRunProfilesInstalled.Name = "chkIsRunProfilesInstalled";
            this.chkIsRunProfilesInstalled.Size = new System.Drawing.Size(259, 21);
            this.chkIsRunProfilesInstalled.TabIndex = 3;
            this.chkIsRunProfilesInstalled.Text = "Run all of profiles installed on computer";
            this.chkIsRunProfilesInstalled.UseVisualStyleBackColor = true;
            this.chkIsRunProfilesInstalled.CheckedChanged += new System.EventHandler(this.chkIsRunProfilesInstalled_CheckedChanged);
            // 
            // txtFromProfile
            // 
            this.txtFromProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromProfile.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromProfile.Location = new System.Drawing.Point(266, 63);
            this.txtFromProfile.Name = "txtFromProfile";
            this.txtFromProfile.Size = new System.Drawing.Size(372, 24);
            this.txtFromProfile.TabIndex = 2;
            this.txtFromProfile.Text = "1";
            this.txtFromProfile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFromProfile_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Profile start:";
            // 
            // txtTotalProfiles
            // 
            this.txtTotalProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalProfiles.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalProfiles.Location = new System.Drawing.Point(266, 100);
            this.txtTotalProfiles.Name = "txtTotalProfiles";
            this.txtTotalProfiles.Size = new System.Drawing.Size(372, 24);
            this.txtTotalProfiles.TabIndex = 2;
            this.txtTotalProfiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTotalProfiles_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total profiles:";
            // 
            // txtProfilesEveryRunning
            // 
            this.txtProfilesEveryRunning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfilesEveryRunning.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfilesEveryRunning.Location = new System.Drawing.Point(266, 25);
            this.txtProfilesEveryRunning.Name = "txtProfilesEveryRunning";
            this.txtProfilesEveryRunning.Size = new System.Drawing.Size(372, 24);
            this.txtProfilesEveryRunning.TabIndex = 1;
            this.txtProfilesEveryRunning.Text = "1";
            this.txtProfilesEveryRunning.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProfilesEveryRunning_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of profiles for every running : ";
            // 
            // btnCreateProfiles
            // 
            this.btnCreateProfiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateProfiles.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateProfiles.Location = new System.Drawing.Point(103, 344);
            this.btnCreateProfiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateProfiles.Name = "btnCreateProfiles";
            this.btnCreateProfiles.Size = new System.Drawing.Size(150, 35);
            this.btnCreateProfiles.TabIndex = 5;
            this.btnCreateProfiles.Text = "Create profiles";
            this.btnCreateProfiles.UseVisualStyleBackColor = true;
            this.btnCreateProfiles.Click += new System.EventHandler(this.btnCreateProfiles_Click);
            // 
            // btnCreateAccounts
            // 
            this.btnCreateAccounts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateAccounts.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccounts.ForeColor = System.Drawing.Color.Black;
            this.btnCreateAccounts.Location = new System.Drawing.Point(449, 344);
            this.btnCreateAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateAccounts.Name = "btnCreateAccounts";
            this.btnCreateAccounts.Size = new System.Drawing.Size(145, 35);
            this.btnCreateAccounts.TabIndex = 7;
            this.btnCreateAccounts.Text = "Create accounts";
            this.btnCreateAccounts.UseVisualStyleBackColor = true;
            this.btnCreateAccounts.Click += new System.EventHandler(this.btnCreateAccounts_Click);
            // 
            // btnStartTasks
            // 
            this.btnStartTasks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartTasks.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTasks.ForeColor = System.Drawing.Color.Black;
            this.btnStartTasks.Location = new System.Drawing.Point(279, 344);
            this.btnStartTasks.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartTasks.Name = "btnStartTasks";
            this.btnStartTasks.Size = new System.Drawing.Size(145, 35);
            this.btnStartTasks.TabIndex = 6;
            this.btnStartTasks.Text = "START";
            this.btnStartTasks.UseVisualStyleBackColor = true;
            this.btnStartTasks.Click += new System.EventHandler(this.btnStartTasks_Click);
            // 
            // tabManualTasks
            // 
            this.tabManualTasks.Controls.Add(this.lstStatus2);
            this.tabManualTasks.Controls.Add(this.groupManualSettings);
            this.tabManualTasks.Controls.Add(this.groupProxyTasks);
            this.tabManualTasks.Controls.Add(this.btnCreateProfilesManual);
            this.tabManualTasks.Controls.Add(this.btnCreateAccountsManual);
            this.tabManualTasks.Controls.Add(this.btnStartManual);
            this.tabManualTasks.Location = new System.Drawing.Point(4, 26);
            this.tabManualTasks.Name = "tabManualTasks";
            this.tabManualTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabManualTasks.Size = new System.Drawing.Size(700, 554);
            this.tabManualTasks.TabIndex = 1;
            this.tabManualTasks.Text = "Manual Tasks";
            this.tabManualTasks.UseVisualStyleBackColor = true;
            // 
            // groupManualSettings
            // 
            this.groupManualSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupManualSettings.Controls.Add(this.chkReminder);
            this.groupManualSettings.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupManualSettings.Location = new System.Drawing.Point(18, 130);
            this.groupManualSettings.Name = "groupManualSettings";
            this.groupManualSettings.Size = new System.Drawing.Size(662, 76);
            this.groupManualSettings.TabIndex = 15;
            this.groupManualSettings.TabStop = false;
            this.groupManualSettings.Text = "Settings";
            // 
            // chkReminder
            // 
            this.chkReminder.AutoSize = true;
            this.chkReminder.Checked = true;
            this.chkReminder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReminder.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReminder.Location = new System.Drawing.Point(25, 37);
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Size = new System.Drawing.Size(265, 21);
            this.chkReminder.TabIndex = 9;
            this.chkReminder.Text = "Reminder for next running after stopping";
            this.chkReminder.UseVisualStyleBackColor = true;
            // 
            // groupProxyTasks
            // 
            this.groupProxyTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupProxyTasks.Controls.Add(this.chkAdbtc);
            this.groupProxyTasks.Controls.Add(this.chkHashingadSpace);
            this.groupProxyTasks.Controls.Add(this.chkBtcVic);
            this.groupProxyTasks.Controls.Add(this.chkBitpick);
            this.groupProxyTasks.Controls.Add(this.chkBtcClicks);
            this.groupProxyTasks.Controls.Add(this.chkBither);
            this.groupProxyTasks.Controls.Add(this.chkFreeLitecoin);
            this.groupProxyTasks.Controls.Add(this.chkFreeBitco);
            this.groupProxyTasks.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupProxyTasks.Location = new System.Drawing.Point(18, 13);
            this.groupProxyTasks.Name = "groupProxyTasks";
            this.groupProxyTasks.Size = new System.Drawing.Size(662, 102);
            this.groupProxyTasks.TabIndex = 14;
            this.groupProxyTasks.TabStop = false;
            this.groupProxyTasks.Text = "Tasks";
            // 
            // chkAdbtc
            // 
            this.chkAdbtc.AutoSize = true;
            this.chkAdbtc.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdbtc.Location = new System.Drawing.Point(25, 65);
            this.chkAdbtc.Name = "chkAdbtc";
            this.chkAdbtc.Size = new System.Drawing.Size(66, 21);
            this.chkAdbtc.TabIndex = 7;
            this.chkAdbtc.Text = "AdBtc";
            this.chkAdbtc.UseVisualStyleBackColor = true;
            this.chkAdbtc.CheckedChanged += new System.EventHandler(this.chkAdbtc_CheckedChanged);
            // 
            // chkHashingadSpace
            // 
            this.chkHashingadSpace.AutoSize = true;
            this.chkHashingadSpace.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHashingadSpace.Location = new System.Drawing.Point(138, 65);
            this.chkHashingadSpace.Name = "chkHashingadSpace";
            this.chkHashingadSpace.Size = new System.Drawing.Size(125, 21);
            this.chkHashingadSpace.TabIndex = 8;
            this.chkHashingadSpace.Text = "HashingadSpace";
            this.chkHashingadSpace.UseVisualStyleBackColor = true;
            this.chkHashingadSpace.CheckedChanged += new System.EventHandler(this.chkHashingadSpace_CheckedChanged);
            // 
            // chkBtcVic
            // 
            this.chkBtcVic.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBtcVic.Location = new System.Drawing.Point(441, 32);
            this.chkBtcVic.Name = "chkBtcVic";
            this.chkBtcVic.Size = new System.Drawing.Size(68, 21);
            this.chkBtcVic.TabIndex = 6;
            this.chkBtcVic.Text = "BtcVic";
            this.chkBtcVic.UseVisualStyleBackColor = true;
            this.chkBtcVic.CheckedChanged += new System.EventHandler(this.chkBtcVic_CheckedChanged);
            // 
            // chkBitpick
            // 
            this.chkBitpick.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBitpick.Location = new System.Drawing.Point(264, 32);
            this.chkBitpick.Name = "chkBitpick";
            this.chkBitpick.Size = new System.Drawing.Size(84, 21);
            this.chkBitpick.TabIndex = 3;
            this.chkBitpick.Text = "Bitpick";
            this.chkBitpick.UseVisualStyleBackColor = true;
            this.chkBitpick.CheckedChanged += new System.EventHandler(this.chkBitpick_CheckedChanged);
            // 
            // chkBtcClicks
            // 
            this.chkBtcClicks.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBtcClicks.Location = new System.Drawing.Point(534, 32);
            this.chkBtcClicks.Name = "chkBtcClicks";
            this.chkBtcClicks.Size = new System.Drawing.Size(84, 21);
            this.chkBtcClicks.TabIndex = 5;
            this.chkBtcClicks.Text = "BtcClicks";
            this.chkBtcClicks.UseVisualStyleBackColor = true;
            this.chkBtcClicks.CheckedChanged += new System.EventHandler(this.chkBtcClicks_CheckedChanged);
            // 
            // chkBither
            // 
            this.chkBither.AutoSize = true;
            this.chkBither.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBither.Location = new System.Drawing.Point(355, 32);
            this.chkBither.Name = "chkBither";
            this.chkBither.Size = new System.Drawing.Size(63, 21);
            this.chkBither.TabIndex = 4;
            this.chkBither.Text = "Bither";
            this.chkBither.UseVisualStyleBackColor = true;
            this.chkBither.CheckedChanged += new System.EventHandler(this.chkBither_CheckedChanged);
            // 
            // chkFreeLitecoin
            // 
            this.chkFreeLitecoin.AutoSize = true;
            this.chkFreeLitecoin.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFreeLitecoin.Location = new System.Drawing.Point(138, 32);
            this.chkFreeLitecoin.Name = "chkFreeLitecoin";
            this.chkFreeLitecoin.Size = new System.Drawing.Size(101, 21);
            this.chkFreeLitecoin.TabIndex = 2;
            this.chkFreeLitecoin.Text = "FreeLitecoin";
            this.chkFreeLitecoin.UseVisualStyleBackColor = true;
            this.chkFreeLitecoin.CheckedChanged += new System.EventHandler(this.chkFreeLitecoin_CheckedChanged);
            // 
            // chkFreeBitco
            // 
            this.chkFreeBitco.AutoSize = true;
            this.chkFreeBitco.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFreeBitco.Location = new System.Drawing.Point(25, 32);
            this.chkFreeBitco.Name = "chkFreeBitco";
            this.chkFreeBitco.Size = new System.Drawing.Size(85, 21);
            this.chkFreeBitco.TabIndex = 1;
            this.chkFreeBitco.Text = "FreeBitco";
            this.chkFreeBitco.UseVisualStyleBackColor = true;
            this.chkFreeBitco.CheckedChanged += new System.EventHandler(this.chkFreeBitco_CheckedChanged);
            // 
            // btnCreateProfilesManual
            // 
            this.btnCreateProfilesManual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateProfilesManual.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateProfilesManual.Location = new System.Drawing.Point(103, 311);
            this.btnCreateProfilesManual.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateProfilesManual.Name = "btnCreateProfilesManual";
            this.btnCreateProfilesManual.Size = new System.Drawing.Size(150, 35);
            this.btnCreateProfilesManual.TabIndex = 10;
            this.btnCreateProfilesManual.Text = "Create profiles";
            this.btnCreateProfilesManual.UseVisualStyleBackColor = true;
            this.btnCreateProfilesManual.Click += new System.EventHandler(this.btnCreateProfilesManual_Click);
            // 
            // btnCreateAccountsManual
            // 
            this.btnCreateAccountsManual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateAccountsManual.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccountsManual.ForeColor = System.Drawing.Color.Black;
            this.btnCreateAccountsManual.Location = new System.Drawing.Point(444, 311);
            this.btnCreateAccountsManual.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateAccountsManual.Name = "btnCreateAccountsManual";
            this.btnCreateAccountsManual.Size = new System.Drawing.Size(150, 35);
            this.btnCreateAccountsManual.TabIndex = 12;
            this.btnCreateAccountsManual.Text = "Create accounts";
            this.btnCreateAccountsManual.UseVisualStyleBackColor = true;
            this.btnCreateAccountsManual.Click += new System.EventHandler(this.btnCreateAccountsManual_Click);
            // 
            // btnStartManual
            // 
            this.btnStartManual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartManual.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartManual.ForeColor = System.Drawing.Color.Black;
            this.btnStartManual.Location = new System.Drawing.Point(273, 311);
            this.btnStartManual.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartManual.Name = "btnStartManual";
            this.btnStartManual.Size = new System.Drawing.Size(150, 35);
            this.btnStartManual.TabIndex = 11;
            this.btnStartManual.Text = "START";
            this.btnStartManual.UseVisualStyleBackColor = true;
            this.btnStartManual.Click += new System.EventHandler(this.btnStartManual_Click);
            // 
            // lstStatus
            // 
            this.lstStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStatus.Location = new System.Drawing.Point(0, 399);
            this.lstStatus.Margin = new System.Windows.Forms.Padding(5);
            this.lstStatus.Multiline = true;
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.ReadOnly = true;
            this.lstStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lstStatus.Size = new System.Drawing.Size(701, 152);
            this.lstStatus.TabIndex = 20;
            // 
            // lstStatus2
            // 
            this.lstStatus2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStatus2.Location = new System.Drawing.Point(0, 365);
            this.lstStatus2.Margin = new System.Windows.Forms.Padding(5);
            this.lstStatus2.Multiline = true;
            this.lstStatus2.Name = "lstStatus2";
            this.lstStatus2.ReadOnly = true;
            this.lstStatus2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lstStatus2.Size = new System.Drawing.Size(701, 186);
            this.lstStatus2.TabIndex = 21;
            // 
            // frmAutoClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 580);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmAutoClicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMO TOOL";
            this.Activated += new System.EventHandler(this.frmAutoClicker_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAutoClicker_FormClosing);
            this.Load += new System.EventHandler(this.frmAutoClicker_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAutorunTasks.ResumeLayout(false);
            this.tabAutorunTasks.PerformLayout();
            this.groupAutoTasks.ResumeLayout(false);
            this.groupAutoTasks.PerformLayout();
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            this.tabManualTasks.ResumeLayout(false);
            this.tabManualTasks.PerformLayout();
            this.groupManualSettings.ResumeLayout(false);
            this.groupManualSettings.PerformLayout();
            this.groupProxyTasks.ResumeLayout(false);
            this.groupProxyTasks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAutorunTasks;
        private System.Windows.Forms.Button btnStartTasks;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProfilesEveryRunning;
        private System.Windows.Forms.Button btnCreateProfiles;
        private System.Windows.Forms.TextBox txtTotalProfiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIsRunProfilesInstalled;
        private System.Windows.Forms.Button btnCreateAccounts;
        private System.Windows.Forms.CheckBox chkIsAutoRunServices;
        private System.Windows.Forms.GroupBox groupAutoTasks;
        private System.Windows.Forms.CheckBox chkTimebucks;
        private System.Windows.Forms.TabPage tabManualTasks;
        private System.Windows.Forms.GroupBox groupProxyTasks;
        private System.Windows.Forms.CheckBox chkFreeBitco;
        private System.Windows.Forms.Button btnCreateProfilesManual;
        private System.Windows.Forms.Button btnCreateAccountsManual;
        private System.Windows.Forms.Button btnStartManual;
        private System.Windows.Forms.CheckBox chkPaidviewpoint;
        private System.Windows.Forms.CheckBox chkPresearch;
        private System.Windows.Forms.CheckBox chkBtcVic;
        private System.Windows.Forms.CheckBox chkBtcClicks;
        private System.Windows.Forms.CheckBox chkIndexBitco;
        private System.Windows.Forms.CheckBox chkFreeBitcoin;
        private System.Windows.Forms.CheckBox chkBither;
        private System.Windows.Forms.GroupBox groupManualSettings;
        private System.Windows.Forms.CheckBox chkHashingadSpace;
        private System.Windows.Forms.CheckBox chkAutoFreebitco;
        private System.Windows.Forms.CheckBox chkFreeLitecoin;
        private System.Windows.Forms.CheckBox chkBitpick;
        private System.Windows.Forms.CheckBox chkAdbtc;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.TextBox txtFromProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lstStatus;
        private System.Windows.Forms.TextBox lstStatus2;
    }
}