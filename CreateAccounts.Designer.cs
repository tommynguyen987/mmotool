namespace MyTool
{
    partial class frmCreateAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateAccounts));
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupTypes = new System.Windows.Forms.GroupBox();
            this.rdBigshare = new System.Windows.Forms.RadioButton();
            this.rdGlobalNX = new System.Windows.Forms.RadioButton();
            this.rdPresearch = new System.Windows.Forms.RadioButton();
            this.rdTimebucks = new System.Windows.Forms.RadioButton();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.rdGenderFemale = new System.Windows.Forms.RadioButton();
            this.rdGenderMale = new System.Windows.Forms.RadioButton();
            this.chkIsUseVirtualEmails = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtToProfile = new System.Windows.Forms.TextBox();
            this.txtFromProfile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblLastname = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupTypes.SuspendLayout();
            this.groupSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Location = new System.Drawing.Point(200, 594);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(134, 32);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 645);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(531, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatus.Text = "Ready!";
            this.toolStripStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupTypes
            // 
            this.groupTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTypes.Controls.Add(this.rdBigshare);
            this.groupTypes.Controls.Add(this.rdGlobalNX);
            this.groupTypes.Controls.Add(this.rdPresearch);
            this.groupTypes.Controls.Add(this.rdTimebucks);
            this.groupTypes.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupTypes.Location = new System.Drawing.Point(23, 16);
            this.groupTypes.Name = "groupTypes";
            this.groupTypes.Size = new System.Drawing.Size(484, 109);
            this.groupTypes.TabIndex = 20;
            this.groupTypes.TabStop = false;
            this.groupTypes.Text = "Type";
            // 
            // rdBigshare
            // 
            this.rdBigshare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdBigshare.AutoSize = true;
            this.rdBigshare.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBigshare.Location = new System.Drawing.Point(25, 69);
            this.rdBigshare.Name = "rdBigshare";
            this.rdBigshare.Size = new System.Drawing.Size(78, 21);
            this.rdBigshare.TabIndex = 2;
            this.rdBigshare.Text = "Bigshare";
            this.rdBigshare.UseVisualStyleBackColor = true;
            this.rdBigshare.CheckedChanged += new System.EventHandler(this.rdSearchServices_CheckedChanged);
            // 
            // rdGlobalNX
            // 
            this.rdGlobalNX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdGlobalNX.AutoSize = true;
            this.rdGlobalNX.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGlobalNX.Location = new System.Drawing.Point(380, 37);
            this.rdGlobalNX.Name = "rdGlobalNX";
            this.rdGlobalNX.Size = new System.Drawing.Size(84, 21);
            this.rdGlobalNX.TabIndex = 2;
            this.rdGlobalNX.Text = "GlobalNX";
            this.rdGlobalNX.UseVisualStyleBackColor = true;
            this.rdGlobalNX.CheckedChanged += new System.EventHandler(this.rdGlobalNX_CheckedChanged);
            // 
            // rdPresearch
            // 
            this.rdPresearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdPresearch.AutoSize = true;
            this.rdPresearch.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPresearch.Location = new System.Drawing.Point(212, 37);
            this.rdPresearch.Name = "rdPresearch";
            this.rdPresearch.Size = new System.Drawing.Size(86, 21);
            this.rdPresearch.TabIndex = 2;
            this.rdPresearch.Text = "Presearch";
            this.rdPresearch.UseVisualStyleBackColor = true;
            this.rdPresearch.CheckedChanged += new System.EventHandler(this.rdSearchServices_CheckedChanged);
            // 
            // rdTimebucks
            // 
            this.rdTimebucks.AutoSize = true;
            this.rdTimebucks.Checked = true;
            this.rdTimebucks.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTimebucks.Location = new System.Drawing.Point(25, 37);
            this.rdTimebucks.Name = "rdTimebucks";
            this.rdTimebucks.Size = new System.Drawing.Size(89, 21);
            this.rdTimebucks.TabIndex = 1;
            this.rdTimebucks.TabStop = true;
            this.rdTimebucks.Text = "Timebucks";
            this.rdTimebucks.UseVisualStyleBackColor = true;
            this.rdTimebucks.CheckedChanged += new System.EventHandler(this.rdTimebucks_CheckedChanged);
            // 
            // groupSettings
            // 
            this.groupSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupSettings.Controls.Add(this.rdGenderFemale);
            this.groupSettings.Controls.Add(this.rdGenderMale);
            this.groupSettings.Controls.Add(this.chkIsUseVirtualEmails);
            this.groupSettings.Controls.Add(this.label8);
            this.groupSettings.Controls.Add(this.txtToProfile);
            this.groupSettings.Controls.Add(this.txtFromProfile);
            this.groupSettings.Controls.Add(this.label7);
            this.groupSettings.Controls.Add(this.label6);
            this.groupSettings.Controls.Add(this.txtState);
            this.groupSettings.Controls.Add(this.txtPassword);
            this.groupSettings.Controls.Add(this.txtLastname);
            this.groupSettings.Controls.Add(this.txtFirstname);
            this.groupSettings.Controls.Add(this.txtEmail);
            this.groupSettings.Controls.Add(this.lblState);
            this.groupSettings.Controls.Add(this.txtUsername);
            this.groupSettings.Controls.Add(this.lblLastname);
            this.groupSettings.Controls.Add(this.label5);
            this.groupSettings.Controls.Add(this.lblGender);
            this.groupSettings.Controls.Add(this.lblFirstname);
            this.groupSettings.Controls.Add(this.lblPassword);
            this.groupSettings.Controls.Add(this.lblUsername);
            this.groupSettings.Location = new System.Drawing.Point(23, 143);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(484, 434);
            this.groupSettings.TabIndex = 21;
            this.groupSettings.TabStop = false;
            this.groupSettings.Text = "Settings";
            // 
            // rdGenderFemale
            // 
            this.rdGenderFemale.AutoSize = true;
            this.rdGenderFemale.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGenderFemale.Location = new System.Drawing.Point(260, 395);
            this.rdGenderFemale.Name = "rdGenderFemale";
            this.rdGenderFemale.Size = new System.Drawing.Size(69, 21);
            this.rdGenderFemale.TabIndex = 41;
            this.rdGenderFemale.TabStop = true;
            this.rdGenderFemale.Text = "Female";
            this.rdGenderFemale.UseVisualStyleBackColor = true;
            // 
            // rdGenderMale
            // 
            this.rdGenderMale.AutoSize = true;
            this.rdGenderMale.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGenderMale.Location = new System.Drawing.Point(108, 395);
            this.rdGenderMale.Name = "rdGenderMale";
            this.rdGenderMale.Size = new System.Drawing.Size(56, 21);
            this.rdGenderMale.TabIndex = 40;
            this.rdGenderMale.TabStop = true;
            this.rdGenderMale.Text = "Male";
            this.rdGenderMale.UseVisualStyleBackColor = true;
            // 
            // chkIsUseVirtualEmails
            // 
            this.chkIsUseVirtualEmails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsUseVirtualEmails.AutoSize = true;
            this.chkIsUseVirtualEmails.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsUseVirtualEmails.Location = new System.Drawing.Point(26, 181);
            this.chkIsUseVirtualEmails.Name = "chkIsUseVirtualEmails";
            this.chkIsUseVirtualEmails.Size = new System.Drawing.Size(209, 21);
            this.chkIsUseVirtualEmails.TabIndex = 36;
            this.chkIsUseVirtualEmails.Text = "Use virtual emails for accounts";
            this.chkIsUseVirtualEmails.UseVisualStyleBackColor = true;
            this.chkIsUseVirtualEmails.CheckedChanged += new System.EventHandler(this.chkIsUseVirtualEmails_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(275, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "To: ";
            // 
            // txtToProfile
            // 
            this.txtToProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToProfile.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToProfile.Location = new System.Drawing.Point(311, 62);
            this.txtToProfile.Name = "txtToProfile";
            this.txtToProfile.Size = new System.Drawing.Size(148, 24);
            this.txtToProfile.TabIndex = 21;
            // 
            // txtFromProfile
            // 
            this.txtFromProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromProfile.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromProfile.Location = new System.Drawing.Point(108, 61);
            this.txtFromProfile.Name = "txtFromProfile";
            this.txtFromProfile.Size = new System.Drawing.Size(148, 24);
            this.txtFromProfile.TabIndex = 20;
            this.txtFromProfile.TextChanged += new System.EventHandler(this.txtFromProfile_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "From: ";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Enter number of profiles to create accounts";
            // 
            // txtState
            // 
            this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtState.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.Location = new System.Drawing.Point(108, 354);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(351, 24);
            this.txtState.TabIndex = 26;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(108, 309);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(351, 24);
            this.txtPassword.TabIndex = 27;
            // 
            // txtLastname
            // 
            this.txtLastname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastname.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastname.Location = new System.Drawing.Point(108, 263);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(351, 24);
            this.txtLastname.TabIndex = 26;
            // 
            // txtFirstname
            // 
            this.txtFirstname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstname.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstname.Location = new System.Drawing.Point(108, 219);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(351, 24);
            this.txtFirstname.TabIndex = 25;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(108, 150);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(351, 24);
            this.txtEmail.TabIndex = 24;
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(23, 356);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(41, 17);
            this.lblState.TabIndex = 34;
            this.lblState.Text = "State:";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(108, 105);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(351, 24);
            this.txtUsername.TabIndex = 23;
            // 
            // lblLastname
            // 
            this.lblLastname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastname.AutoSize = true;
            this.lblLastname.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastname.Location = new System.Drawing.Point(23, 266);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(69, 17);
            this.lblLastname.TabIndex = 34;
            this.lblLastname.Text = "Lastname:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Email: ";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(23, 397);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(58, 17);
            this.lblGender.TabIndex = 35;
            this.lblGender.Text = "Gender: ";
            // 
            // lblFirstname
            // 
            this.lblFirstname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstname.Location = new System.Drawing.Point(23, 221);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(73, 17);
            this.lblFirstname.TabIndex = 33;
            this.lblFirstname.Text = "Firstname: ";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(23, 311);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 35;
            this.lblPassword.Text = "Password: ";
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(23, 109);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(76, 17);
            this.lblUsername.TabIndex = 31;
            this.lblUsername.Text = "Username: ";
            // 
            // frmCreateAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 667);
            this.Controls.Add(this.groupSettings);
            this.Controls.Add(this.groupTypes);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmCreateAccounts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Accounts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCreateAccounts_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupTypes.ResumeLayout(false);
            this.groupTypes.PerformLayout();
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.GroupBox groupTypes;
        private System.Windows.Forms.RadioButton rdPresearch;
        private System.Windows.Forms.RadioButton rdTimebucks;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.CheckBox chkIsUseVirtualEmails;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtToProfile;
        private System.Windows.Forms.TextBox txtFromProfile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFirstname;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rdGenderFemale;
        private System.Windows.Forms.RadioButton rdGenderMale;
        private System.Windows.Forms.RadioButton rdGlobalNX;
        private System.Windows.Forms.RadioButton rdBigshare;
    }
}