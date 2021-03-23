using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MyTool
{
    public partial class frmCreateProfiles : Form
    {
        static int fromProfile = 1;
        static int toProfile = 1;
        static bool stopped = false;
        public static bool isClosed = false;
        public static string profilesFolderPath = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Mozilla\Firefox\Profiles";

        public frmCreateProfiles()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFromProfile.Text.Trim()))
            {
                MessageBox.Show("From Profile can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFromProfile.Focus();
            }
            else if (string.IsNullOrEmpty(txtToProfile.Text.Trim()))
            {
                MessageBox.Show("To Profile can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToProfile.Focus();
            }            
            else
            {
                if (btnStart.Text == "Start")
                {
                    stopped = txtFromProfile.Enabled = txtToProfile.Enabled = false;
                    btnStart.Text = "Stop";
                    var task = System.Threading.Tasks.Task.Factory.StartNew(() => CreateProfiles());
                    if(task.IsCanceled || task.IsCompleted) stopped = txtFromProfile.Enabled = txtToProfile.Enabled = true;
                }
                else
                {
                    btnStart.Text = "Start";
                    stopped = txtFromProfile.Enabled = txtToProfile.Enabled = true;
                    KillProcesses();
                }
            }            
        }

        private void CreateProfiles()
        {
            if (stopped) return;
            fromProfile = int.Parse(txtFromProfile.Text.Trim());
            toProfile = int.Parse(txtToProfile.Text.Trim());
            var profile = "";
            var isExisted = false;
            for (int i = fromProfile; i <= toProfile; i++)
            {
                var files = Directory.GetDirectories(profilesFolderPath, "*.User" + i);
                if (files.Length > 0)
                {
                    toolStripStatus.Text = "Profile User"+i + " exists!";
                    isExisted = true;
                    Thread.Sleep(1000);
                    continue;
                }
                profile = "-CreateProfile \"User" + i + "\"";
                Handler.StartProcess(frmAutoClicker.OperationType.CreateProfiles, frmAutoClicker.GetAppPath(frmAutoClicker.BrowserType.Firefox), profile, false, true, "");
                toolStripStatus.Text = "Creating profile User"+i;
                Thread.Sleep(2000);
                KillProcesses();
            }
            if (!isExisted)
            {
                MessageBox.Show("Create profiles successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Properties.Settings.Default.NumOfProfilesInstalled = toProfile;
                Properties.Settings.Default.Save();                
            }
            btnStart.Text = "Start";
            stopped = txtFromProfile.Enabled = txtToProfile.Enabled = true;
            KillProcesses();
        }

        private void KillProcesses()
        {
            if(stopped) toolStripStatus.Text = "Ready!";
            Handler.StopProcess(frmAutoClicker.OperationType.CreateProfiles, frmAutoClicker.FIREFOX, false, false);
        }

        private void frmCreateAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosed = true;
            KillProcesses();            
        }
    }
}
