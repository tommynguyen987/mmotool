using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyTool
{
    public partial class frmCreateAccounts : Form
    {
        static int fromProfile = 1;
        static int toProfile = 1;
        static bool stopped = false;
        static bool checkAdsStopped = false;
        static bool checkSearchservicesStopped = false;
        public static AccountType accountType = AccountType.Presearch;
        public static bool isClosed = false;
        public static bool successful = false;
        public enum AccountType
        {
            Timebucks = 1,       
            Presearch = 2,
            Tixuma = 3,
            Bigshare = 4
        }

        static string getAccountByProfileFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\BatFiles\\getaccounts_{0}_byprofiles_{1}.bat";
        static string createAccountByProfileFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\BatFiles\\createaccounts_{0}_byprofiles_{1}.bat";

        public static string getRefInfoFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Macros\\getrefinfo_{0}_{1}.iim";
        public static string registerFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Macros\\register_{0}_{1}.iim";
        public static string refInfoProfileFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Downloads\\{0}_info_profile_{1}";
        static string getAdsInfoFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Downloads\\getadsinfo";
        static string getSearchServicesInfoFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Downloads\\get{0}info";

        public frmCreateAccounts()
        {
            InitializeComponent();                        
            var fromProfile = frmAutoClicker.numOfProfilesTimebucks + 1;
            if (fromProfile > Properties.Settings.Default.NumOfProfilesInstalled) fromProfile = Properties.Settings.Default.NumOfProfilesInstalled;
            txtFromProfile.Text = fromProfile.ToString();
            ShowControls(true);
            System.Threading.Tasks.Task.Factory.StartNew(() => CheckTimeToRunForAds());
        }

        private void CheckTimeToRunForAds()
        {
            var path = string.Format(refInfoProfileFilePath, "timebucks", int.Parse(txtFromProfile.Text.Trim()) - 1);            
            if (File.Exists(path))
            {
                var lastWriteTime = File.GetLastWriteTime(path);
                var time = DateTime.Now - lastWriteTime.AddDays(0.8);
                if (time.Hours < 0)
                {
                    EnableControls(false);
                    var h = Math.Abs(time.Hours);
                    var m = Math.Abs(time.Minutes);
                    var s = Math.Abs((int)time.Seconds);
                    do
                    {
                        s--;
                        if (s == 0 && m > 0)
                        {
                            m--;
                            s = 59;
                        }
                        if (m == 0 && h > 0)
                        {
                            h--;
                            m = 59;
                        }
                        toolStripStatus.Text = "You can't create timebucks account now. Please wait in " + h + ":" + m + ":" + s;
                        Thread.Sleep(1000);
                    } while (h >= 0 && m > 0 && s > 0 && !checkAdsStopped);
                    if (h == 0 && m == 0 && s == 0) EnableControls(true);
                }
                else EnableControls(true);
            }
            else EnableControls(true);
            toolStripStatus.Text = "Ready!";
        }

        private void CheckTimeToRunForSearchservices()
        {
            var type = (accountType == AccountType.Presearch ? "presearch" : "tixuma");
            var path = string.Format(refInfoProfileFilePath, type, int.Parse(txtFromProfile.Text.Trim()) - 1);
            if (File.Exists(path))
            {
                var lastWriteTime = File.GetLastWriteTime(path);
                var time = DateTime.Now - lastWriteTime.AddDays(0.6);
                if (time.Hours < 0)
                {
                    EnableControls(false);                    
                    var h = Math.Abs(time.Hours);
                    var m = Math.Abs(time.Minutes);
                    var s = Math.Abs((int)time.Seconds);
                    do
                    {
                        s--;
                        if (s == 0 && m > 0)
                        {
                            m--;
                            s = 59;
                        }
                        if (m == 0 && h > 0)
                        {
                            h--;
                            m = 59;
                        }
                        toolStripStatus.Text = "You can't create searchservices accounts now. Please wait in " + h + ":" + m + ":" + s;
                        Thread.Sleep(1000);
                    } while (h >= 0 && m > 0 && s > 0 && !checkSearchservicesStopped);
                    if (h == 0 && m == 0 && s == 0) EnableControls(true);
                }
                else EnableControls(true);
            }
            else EnableControls(true);
            toolStripStatus.Text = "Ready!";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFromProfile.Text.Trim()))
            {
                MessageBox.Show("From Profile can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFromProfile.Focus();
            }
            else if (string.IsNullOrEmpty(txtToProfile.Text.Trim()) && txtToProfile.Enabled)
            {
                MessageBox.Show("To Profile can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToProfile.Focus();
            }
            else if (string.IsNullOrEmpty(txtUsername.Text.Trim()) && !rdTimebucks.Checked)
            {
                var text = "Username";
                if (lblUsername.Text == "Fullname") text = "Fullname";
                MessageBox.Show( text + " can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text.Trim()) && !chkIsUseVirtualEmails.Checked)
            {
                MessageBox.Show("Email can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
            else if (string.IsNullOrEmpty(txtFirstname.Text.Trim()) && !rdTimebucks.Checked)
            {
                var text = "Firstname";
                if (lblUsername.Text == "Address") text = "Address";
                MessageBox.Show(text + " can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstname.Focus();
            }
            else if (string.IsNullOrEmpty(txtLastname.Text.Trim()) && !rdTimebucks.Checked)
            {
                var text = "Lastname";
                if (lblUsername.Text == "Birthdate") text = "Birthdate";
                MessageBox.Show(text + " can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastname.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtState.Text.Trim()) && rdTimebucks.Checked)
            {
                MessageBox.Show("State can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtState.Focus();
            }
            else if (!rdGenderMale.Checked && !rdGenderFemale.Checked && rdTimebucks.Checked)
            {
                MessageBox.Show("Gender must be checked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdGenderMale.Focus();
            }
            else
            {
                if (btnStart.Text == "Start")
                {                    
                    btnStart.Text = "Stop";
                    stopped = false;
                    checkAdsStopped = checkSearchservicesStopped = true;
                    EnableControls(false);
                    System.Threading.Tasks.Task.Factory.StartNew(() => CreateAccounts());
                }
                else
                {
                    var r = MessageBox.Show("Do you really want to stop ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        btnStart.Text = "Start";
                        stopped = rdTimebucks.Enabled = rdPresearch.Enabled = true;
                        EnableControls(true);
                        KillProcesses();
                    }                    
                }
            }            
        }

        private void CreateAccounts()
        {
            if (stopped) return;
            fromProfile = int.Parse(txtFromProfile.Text.Trim());
            toProfile = int.Parse(txtToProfile.Text.Trim());
            var links = new string[] { "http://ouo.io/s/AlZSaAcd?s=", "https://123link.co/st?api=14aaf57a0b9a07f64a3e7d781179aad9dbbe9f01&url=", "http://bc.vc/202242/", 
                "http://sh.st/st/edaaa359cadcb9f904640c2c484ea8d4/", "https://megaurl.in/st?api=0011ba62add6ef650b09bb22048ce689fab7af4f&url=", 
                "https://zagl.info/st?api=0e584bbc920c061a5d4a59d74207f8242a650543&url=", "https://clik.pw/st?api=faaffc83dc84216f9748b18d5fc84d7d519ef6b1&url=" };
            var indexRan = new Random().Next(0, links.Length - 1);
            switch (accountType)
            {
                case AccountType.Timebucks:
                    CreateTimebuckAccounts(links[indexRan]);
                    break;
                case AccountType.Presearch:
                    CreateSearchServiceAccounts("presearch", links[indexRan]);
                    break;
                case AccountType.Tixuma:
                    CreateSearchServiceAccounts("tixuma", links[indexRan]);
                    break;                
            }

            //if (accountType == AccountType.Searchservices) CreateSearchServiceAccounts(links[indexRan]);
            //else CreateTimebuckAccounts(links[indexRan]);
            if(successful) MessageBox.Show("Create accounts successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripStatus.Text = "Ready!";
            btnStart.Text = "Start";
            EnableControls(true);
            checkAdsStopped = checkSearchservicesStopped = false;
        }

        private void CreateSearchServiceAccounts(string type, string link)
        {
            #region Get info of previous profile
            //var type = (accountType == AccountType.Presearch ? "presearch" : "tixuma");
            if (fromProfile > 1)
            {
                var from = fromProfile - 3;
                if (fromProfile < 4) from = 1;
                toolStripStatus.Text = "Getting info of profile User" + from;
                var actions = new StringBuilder();
                var infoProfilePath = string.Format(refInfoProfileFilePath, type, from);
                if (!File.Exists(infoProfilePath))
                {
                    // Create imacros file                        
                    var fileName = string.Format(getRefInfoFilePath, type, from);
                    if (!File.Exists(fileName))
                    {
                        actions.AppendLine("VERSION BUILD=9030808 RECORDER=FX");
                        actions.AppendLine("SET !REPLAYSPEED FAST");
                        actions.AppendLine("SET !EXTRACT_TEST_POPUP NO");
                        actions.AppendLine("SET !ERRORIGNORE YES");
                        actions.AppendLine("SET !LOOP  1");
                        actions.AppendLine("'Extract and save ref info into a file");
                        actions.AppendLine("TAB T=1");
                        actions.AppendLine("TAB CLOSEALLOTHERS");
                        actions.AppendLine("'Save ref info of tixuma");
                        actions.AppendLine("URL GOTO=http://www.tixuma.de/mein-konto.htm");
                        actions.AppendLine("'Save username");
                        actions.AppendLine("TAG POS=1 TYPE=b ATTR=TXT:* EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=" + type + "_info_profile_" + from);
                        actions.AppendLine("'Save ref link");
                        actions.AppendLine("TAG POS=14 TYPE=div ATTR=TXT:* EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=" + type + "_info_profile_" + from);
                        actions.AppendLine("'Save ref code");
                        actions.AppendLine("TAG POS=16 TYPE=DIV ATTR=TXT:* EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=" + type + "_info_profile_" + from);
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("'Save ref info of presearch");
                        actions.AppendLine("URL GOTO=https://www.presearch.org/account/referral-terms");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT:CHECKBOX ATTR=NAME:agreed_to_referral_terms CONTENT=YES");
                        actions.AppendLine("TAG POS=1 TYPE=BUTTON ATTR=TYPE:submit");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("URL GOTO=https://www.presearch.org/account/referrals");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("'Save ref link");
                        actions.AppendLine("TAG POS=1 TYPE=SPAN ATTR=ID:beta-ref EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=" + type + "_info_profile_" + from);
                        actions.AppendLine("WAIT SECONDS=600");
                        Handler.CreateBatFile(actions.ToString(), fileName);
                    }
                    var profile = "-p \"User" + from + "\" -no-remote \"imacros://run/?m=getrefinfo_" + type + "_" + from + ".iim\"";
                    Handler.StartProcess(frmAutoClicker.OperationType.CreateAccounts, frmAutoClicker.GetAppPath(frmAutoClicker.BrowserType.Firefox), profile, false, true, "");
                    Thread.Sleep(30000);
                    KillProcesses();
                }
            }            
            #endregion

            #region Create accounts
            var refLink_Tixuma = "";
            var refCode_Tixuma = "";
            var refLink_Presearch = "";
            var index = fromProfile - 3;
            var endIndex = fromProfile + 2;
            var count = 1;
            var servicePath = string.Format(getSearchServicesInfoFilePath, type);
            Handler.Log("//===============REGISTER " + type.ToUpper() + " ACCOUNTS==============//");
            for (int i = fromProfile; i <= toProfile; i++)
            {
                if (stopped) return;
                Handler.Log("-----------------------Registration Info-----------------------");
                if (!File.Exists(servicePath))
                {
                    if (i < 4) index = 1;
                    File.WriteAllText(servicePath, index.ToString());
                }
                else
                {
                    var countAds = File.ReadAllText(servicePath);
                    int.TryParse(countAds, out index);
                }

                if (i == 1)
                {
                    if (type == "tixuma")
                    {
                        refLink_Tixuma = Properties.Settings.Default.Link_Paidviewpoint;
                        refCode_Tixuma = Properties.Settings.Default.Link_Indexbitco;
                        Handler.Log("Tixuma default link: " + refLink_Tixuma);
                        Handler.Log("Tixuma default code: " + refCode_Tixuma);
                    }
                    else
                    {
                        refLink_Presearch = Properties.Settings.Default.Link_Presearch;
                        Handler.Log("Presearch default link: " + refLink_Presearch);
                    }
                }
                else
                {
                    var path = string.Format(refInfoProfileFilePath, type, index);
                    if (type == "tixuma")
                    {
                        refLink_Tixuma = (string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[1]) ? Properties.Settings.Default.Link_Paidviewpoint : Handler.GetInfo(path).Split(';')[1]);
                        refCode_Tixuma = string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[2]) ? Properties.Settings.Default.Link_Indexbitco : Handler.GetInfo(path).Split(';')[2];
                        Handler.Log("Tixuma profile User" + index + " link: " + refLink_Tixuma);
                        Handler.Log("Tixuma profile User" + index + " code: " + refCode_Tixuma);
                    }
                    else
                    {
                        refLink_Presearch = (string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[0]) ? Properties.Settings.Default.Link_Presearch : Handler.GetInfo(path).Split(';')[1]);
                        Handler.Log("Presearch profile User" + index + " link: " + refLink_Presearch);
                    }                    
                }

                var fileName = string.Format(registerFilePath, type, i);
                var actions = new StringBuilder();
                // Create imacros file                        
                if (!File.Exists(fileName))
                {
                    actions.AppendLine("VERSION BUILD=9030808 RECORDER=FX");
                    actions.AppendLine("SET !REPLAYSPEED FAST");
                    actions.AppendLine("SET !EXTRACT_TEST_POPUP NO");
                    actions.AppendLine("SET !ERRORIGNORE YES");
                    actions.AppendLine("SET !LOOP  1");

                    #region Tixuma
                    if(type == "tixuma")
                    {
                        actions.AppendLine("'Register account Tixuma");
                        actions.AppendLine("TAB T=1");
                        actions.AppendLine("TAB CLOSEALLOTHERS");
                        //actions.AppendLine("URL GOTO=http://www.tixuma.de/logout.htm");
                        //actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("URL GOTO=" + link + refLink_Tixuma.Replace("http://www.", ""));
                        actions.AppendLine("WAIT SECONDS=20");
                        actions.AppendLine("TAB T=1");
                        actions.AppendLine("TAB CLOSEALLOTHERS");
                        actions.AppendLine("URL GOTO=" + refLink_Tixuma);
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("URL GOTO=http://www.tixuma.de/registrieren.htm");
                        actions.AppendLine("SET !VAR1 " + txtUsername.Text.Trim() + "{{!NOW:yymmddhhnnss}}_p" + i);
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:username CONTENT={{!VAR1}}");
                        actions.AppendLine("'Get temp email from email service");
                        if (i == 1 && !chkIsUseVirtualEmails.Checked)
                        {
                            actions.AppendLine("SET !VAR2 " + txtEmail.Text.Trim());
                        }
                        else
                        {
                            actions.AppendLine("TAB OPEN");
                            actions.AppendLine("TAB T=2");
                            actions.AppendLine("URL GOTO=https://dropmail.me/en/");
                            actions.AppendLine("TAG POS=1 TYPE=SPAN ATTR=CLASS:email EXTRACT=TXT");
                            actions.AppendLine("SET !VAR2 {{!EXTRACT}}");
                            actions.AppendLine("SET !EXTRACT NULL");
                        }
                        actions.AppendLine("WAIT SECONDS=2");
                        actions.AppendLine("'Set values into register form");
                        actions.AppendLine("TAB T=1");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:email CONTENT={{!VAR2}}");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:vorname CONTENT=\"" + txtLastname.Text.Trim() + "\"");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:name CONTENT=\"" + txtFirstname.Text.Trim() + "\"");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:pwd1 CONTENT=\"" + txtPassword.Text.Trim() + "\"");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:pwd2 CONTENT=\"" + txtPassword.Text.Trim() + "\"");
                        actions.AppendLine("TAG POS=1 TYPE=SELECT ATTR=NAME:country CONTENT=%USA");
                        actions.AppendLine("TAG POS=2 TYPE=INPUT:RADIO ATTR=NAME:lng CONTENT=YES");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:gutschein CONTENT=\"" + refCode_Tixuma + "\"");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT:CHECKBOX ATTR=NAME:sw_agb CONTENT=YES");
                        actions.AppendLine("WAIT SECONDS=15");
                        actions.AppendLine("'Login tixuma");
                        actions.AppendLine("URL GOTO=http://www.tixuma.de/login.htm");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:eml CONTENT={{!VAR1}}");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:pwd CONTENT=\"" + txtPassword.Text.Trim() + "\"");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT:CHECKBOX ATTR=NAME:savepwd CONTENT=YES");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=TYPE:submit");
                        actions.AppendLine("WAIT SECONDS=2");
                        actions.AppendLine("'Verify email");
                        actions.AppendLine("URL GOTO=http://www.tixuma.de/index.php?mp=checkemail");
                        actions.AppendLine("WAIT SECONDS=2");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT:CHECKBOX ATTR=NAME:sw_ok CONTENT=YES");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=TYPE:submit");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("'Get verify email and execute");
                        if (i == 1 && !chkIsUseVirtualEmails.Checked) actions.AppendLine("TAB OPEN");
                        actions.AppendLine("TAB T=2");
                        if (i == 1 && !chkIsUseVirtualEmails.Checked)
                        {
                            if (txtEmail.Text.Trim().Contains("gmail.com")) actions.AppendLine("URL GOTO=http://gmail.com");
                            else if (txtEmail.Text.Trim().Contains("yahoo.com")) actions.AppendLine("URL GOTO=http://mail.yahoo.com");
                            actions.AppendLine("WAIT SECONDS=50");
                        }
                        else
                        {
                            actions.AppendLine("TAG POS=1 TYPE=A ATTR=TXT:http://www.tixuma.de/* EXTRACT=HREF");
                            actions.AppendLine("SET !VAR3 {{!EXTRACT}}");
                            actions.AppendLine("SET !EXTRACT NULL");
                            actions.AppendLine("WAIT SECONDS=1");
                            actions.AppendLine("URL GOTO={{!VAR3}}");
                            actions.AppendLine("WAIT SECONDS=2");
                        }
                        actions.AppendLine("'Extract and save ref info into a file");
                        actions.AppendLine("TAB T=1");
                        actions.AppendLine("TAB CLOSEALLOTHERS");
                        actions.AppendLine("URL GOTO=http://www.tixuma.de/mein-konto.htm");
                        actions.AppendLine("'Save username");
                        actions.AppendLine("TAG POS=1 TYPE=b ATTR=TXT:* EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=searchservices_info_profile_" + i);
                        actions.AppendLine("'Save ref link");
                        actions.AppendLine("TAG POS=14 TYPE=div ATTR=TXT:* EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=searchservices_info_profile_" + i);
                        actions.AppendLine("'Save ref code");
                        actions.AppendLine("TAG POS=16 TYPE=DIV ATTR=TXT:* EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=searchservices_info_profile_" + i);
                        actions.AppendLine("WAIT SECONDS=1");
                    }                    
                    #endregion

                    #region Presearch
                    else
                    {
                        actions.AppendLine("'Register account Presearch");
                        //actions.AppendLine("URL GOTO=https://presearch.org/logout");
                        //actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("URL GOTO=" + link + refLink_Presearch.Replace("https://", ""));
                        actions.AppendLine("WAIT SECONDS=20");
                        actions.AppendLine("TAB T=1");
                        actions.AppendLine("TAB CLOSEALLOTHERS");
                        actions.AppendLine("URL GOTO=" + refLink_Presearch);
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("URL GOTO=https://www.presearch.org/register");
                        actions.AppendLine("'Get temp email from email service");
                        actions.AppendLine("' Set values got into regsiter form");
                        if (i == 1 && !chkIsUseVirtualEmails.Checked)
                        {
                            actions.AppendLine("SET !VAR4 " + txtEmail.Text.Trim());
                            actions.AppendLine("TAG POS=2 TYPE=INPUT ATTR=NAME:email CONTENT={{!VAR4}}");
                        }
                        else
                        {
                            actions.AppendLine("TAG POS=2 TYPE=INPUT ATTR=NAME:email CONTENT={{!VAR2}}");
                        }
                        actions.AppendLine("TAG POS=2 TYPE=INPUT ATTR=NAME:password CONTENT=\"" + txtPassword.Text.Trim() + "\"");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=NAME:password_confirmation CONTENT=\"" + txtPassword.Text.Trim() + "\"");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT:CHECKBOX ATTR=NAME:agreed_to_terms CONTENT=YES");
                        actions.AppendLine("WAIT SECONDS=40");
                        actions.AppendLine("'Extract and save ref info into a file");
                        actions.AppendLine("TAB T=1");
                        actions.AppendLine("TAB CLOSEALLOTHERS");
                        actions.AppendLine("WAIT SECONDS=10");
                        actions.AppendLine("URL GOTO=https://www.presearch.org/account/referral-terms");
                        actions.AppendLine("TAG POS=1 TYPE=INPUT:CHECKBOX ATTR=NAME:agreed_to_referral_terms CONTENT=YES");
                        actions.AppendLine("TAG POS=1 TYPE=BUTTON ATTR=TYPE:submit");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("URL GOTO=https://www.presearch.org/account/referrals");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("TAG POS=1 TYPE=SPAN ATTR=ID:beta-ref EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=presearch_info_profile_" + i);
                        actions.AppendLine("WAIT SECONDS=400");
                    }                    
                    #endregion

                    Handler.CreateBatFile(actions.ToString(), fileName);
                }
                var profile =  "-p \"User" + i + "\" -no-remote \"imacros://run/?m=register_" + type + "_" + i + ".iim\"";
                Handler.StartProcess(frmAutoClicker.OperationType.CreateAccounts, frmAutoClicker.GetAppPath(frmAutoClicker.BrowserType.Firefox), profile, true, true, "");
                toolStripStatus.Text = "Openning profile User" + i;
                Thread.Sleep(10000);                
                var timer = 600;
                var m = timer / 60 - 1;
                var s = 60;
                if (count == 3) m = 6;
                do
                {
                    s--;
                    if (s == 0 && m > 0)
                    {
                        m--;
                        s = 59;
                    }
                    if (m == 5 && s == 59)
                    {
                        Properties.Settings.Default.TotalProfilesPresearch = i;
                        Properties.Settings.Default.Save();
                        successful = true;
                        Handler.Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                        Handler.Log("Create account for profile User" + i);
                    }
                    if ((count == 3 || i == Properties.Settings.Default.NumOfProfilesInstalled) && m == 1 && s == 1)
                    {
                        if (type == "tixuma")
                        {
                            Properties.Settings.Default.Link_Paidviewpoint = Handler.GetInfo(string.Format(refInfoProfileFilePath, type, i)).Split(';')[1].Replace("http://", "");
                            Properties.Settings.Default.Link_Indexbitco = Handler.GetInfo(string.Format(refInfoProfileFilePath, type, i)).Split(';')[2];
                        }
                        else Properties.Settings.Default.Link_Presearch = Handler.GetInfo(string.Format(refInfoProfileFilePath, type, i)).Split(';')[1].Replace("https://", "");
                        Properties.Settings.Default.Save();
                        File.WriteAllText(servicePath, (index + 1).ToString());
                        Handler.DeleteFiles(false, fromProfile, toProfile, true, false);
                    }
                    if (count < 3) toolStripStatus.Text = "Openning profile User" + i + ", please wait for next profile in ... " + m + ":" + s;
                    else toolStripStatus.Text = "Profile User" + i + " will finish in ... " + m + ":" + s;
                    Thread.Sleep(1000);
                } while (m >= 0 && s > 0 && !stopped);
                KillProcesses();
                count++;
            }                        
            #endregion
        }

        private void CreateTimebuckAccounts(string link)
        {
            #region Get info of previous profile
            if (fromProfile > 1)
            {
                var from = fromProfile - 3;
                if (fromProfile < 4) from = 1;
                toolStripStatus.Text = "Getting info of profile User" + from;
                var actions = new StringBuilder();
                var infoProfilePath = string.Format(refInfoProfileFilePath, "ads", from);
                if (!File.Exists(infoProfilePath))
                {
                    // Create imacros file                        
                    var fileName = string.Format(getRefInfoFilePath, "ads", from);
                    if (!File.Exists(fileName))
                    {
                        actions.AppendLine("VERSION BUILD=9030808 RECORDER=FX");
                        actions.AppendLine("SET !REPLAYSPEED FAST");
                        actions.AppendLine("SET !EXTRACT_TEST_POPUP NO");
                        actions.AppendLine("SET !ERRORIGNORE YES");
                        actions.AppendLine("SET !LOOP  1");
                        actions.AppendLine("'Extract and save ref info into a file");
                        actions.AppendLine("TAB T=1");
                        actions.AppendLine("TAB CLOSEALLOTHERS");
                        actions.AppendLine("'Save ref info of timebucks");
                        actions.AppendLine("URL GOTO=https://timebucks.com/publishers/index.php?pg=setting");
                        actions.AppendLine("'Save username");
                        actions.AppendLine("TAG POS=3 TYPE=a ATTR=CLASS:settingMenuItem");
                        actions.AppendLine("TAG POS=1 TYPE=span ATTR=STYLE:font-weight:<SP>bold; EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=ads_info_profile_" + from);
                        actions.AppendLine("URL GOTO=https://timebucks.com/publishers/index.php?pg=dashboard");
                        actions.AppendLine("'Save ref link");
                        actions.AppendLine("TAG POS=1 TYPE=input ATTR=ID:ref_link EXTRACT=TXT");
                        actions.AppendLine("WAIT SECONDS=1");
                        actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=ads_info_profile_" + from);
                        actions.AppendLine("WAIT SECONDS=600");
                        Handler.CreateBatFile(actions.ToString(), fileName);
                    }
                    var profile = "-p \"User" + from + "\" -no-remote \"imacros://run/?m=getrefinfo_ads_" + from + ".iim\"";
                    Handler.StartProcess(frmAutoClicker.OperationType.CreateAccounts, frmAutoClicker.GetAppPath(frmAutoClicker.BrowserType.Firefox), profile, false, true, "");
                    Thread.Sleep(30000);
                    Handler.StopProcess(frmAutoClicker.OperationType.CreateAccounts, frmAutoClicker.FIREFOX, false, false);
                }
            }
            #endregion

            #region Create accounts
            var refLink_Timebucks = "";
            var index = fromProfile - 3;
            var endIndex = fromProfile + 2;
            var count = 0;
            var ii = 0;
            var emails = txtEmail.Text;//.IndexOf(";") != -1 ? txtEmail.Text.Split(';')[0].Trim() : txtEmail.Text.Trim();
            Handler.Log("//==================REGISTER TIMEBUCKS ACCOUNT=================//");
            for (int i = fromProfile; i <= toProfile; i++)
            {
                if (stopped) return;
                if (string.IsNullOrEmpty(emails)) continue;
                Handler.Log("-----------------------Registration Info-----------------------");
                if (!File.Exists(getAdsInfoFilePath))
                {
                    if (i < 4) index = 1;
                    File.WriteAllText(getAdsInfoFilePath, (++count).ToString() + ";" + index);
                }
                else
                {
                    var countAds = File.ReadAllText(getAdsInfoFilePath);                    
                    int.TryParse(countAds.Split(';')[0], out count);
                    int.TryParse(countAds.Split(';')[1], out index);
                    File.WriteAllText(getAdsInfoFilePath, (++count).ToString() + ";" + index);
                }

                if (i == 1)
                {
                    refLink_Timebucks = Properties.Settings.Default.Link_Timebucks;
                    Handler.Log("Timebucks default link: " + refLink_Timebucks);
                }
                else
                {
                    var path = string.Format(refInfoProfileFilePath, "ads", index);
                    refLink_Timebucks = (string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[1]) ? Properties.Settings.Default.Link_Timebucks : Handler.GetInfo(path).Split(';')[1]);
                    Handler.Log("Timebucks profile User" + index + " link: " + refLink_Timebucks);
                }
                txtUsername.Text = emails.Substring(0, emails.IndexOf('@')-1);
                while (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    //MessageBox.Show("Please enter new email!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }                
                var fileName = string.Format(registerFilePath, "ads", i);
                var actions = new StringBuilder();
                // Create imacros file                        
                if (!File.Exists(fileName))
                {
                    actions.AppendLine("VERSION BUILD=9030808 RECORDER=FX");
                    actions.AppendLine("SET !REPLAYSPEED FAST");
                    actions.AppendLine("SET !EXTRACT_TEST_POPUP NO");
                    actions.AppendLine("SET !ERRORIGNORE YES");
                    actions.AppendLine("SET !LOOP  1");
                    // Timebucks
                    actions.AppendLine("'Register account timebucks");
                    actions.AppendLine("TAB T=1");
                    actions.AppendLine("TAB CLOSEALLOTHERS");
                    //actions.AppendLine("URL GOTO=https://timebucks.com/publishers/lib/scripts/php/action.php?action=logout");
                    //actions.AppendLine("WAIT SECONDS=2");
                    actions.AppendLine("URL GOTO=" + link + refLink_Timebucks);
                    actions.AppendLine("WAIT SECONDS=20");
                    actions.AppendLine("TAB T=1");
                    actions.AppendLine("TAB CLOSEALLOTHERS");
                    actions.AppendLine("URL GOTO=" + refLink_Timebucks);
                    actions.AppendLine("SET !VAR1 " + emails);
                    actions.AppendLine("'Set values into register form");
                    actions.AppendLine("TAB T=1");
                    actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=ID:signup_email CONTENT={{!VAR1}}");
                    actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=ID:signup_password CONTENT=\"" + txtPassword.Text.Trim() + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=ID:signup_confirm_password CONTENT=\"" + txtPassword.Text.Trim() + "\"");
                    actions.AppendLine("WAIT SECONDS=20");
                    actions.AppendLine("TAG POS=1 TYPE=a ATTR=CLASS:btnAcceptAgreement<SP>btn<SP>btn-green");
                    actions.AppendLine("WAIT SECONDS=2");
                    actions.AppendLine("URL GOTO=https://timebucks.com/publishers/lib/scripts/php/action.php?action=resend_confirmation_email");
                    actions.AppendLine("WAIT SECONDS=2");
                    actions.AppendLine("'Verify email");
                    actions.AppendLine("TAB OPEN");
                    actions.AppendLine("TAB T=2");
                    if (emails.Contains("gmail.com")) actions.AppendLine("URL GOTO=https://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&service=mail&sacu=1&rip=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
                    else if (emails.Contains("yahoo.com")) actions.AppendLine("URL GOTO=https://login.yahoo.com/");
                    actions.AppendLine("WAIT SECONDS=60");
                    actions.AppendLine("'Extract and save ref info into a file");
                    actions.AppendLine("TAB T=1");
                    actions.AppendLine("TAB CLOSEALLOTHERS");
                    actions.AppendLine("URL GOTO=https://timebucks.com/publishers/index.php?pg=setting");
                    actions.AppendLine("'Save username");
                    actions.AppendLine("TAG POS=3 TYPE=a ATTR=CLASS:settingMenuItem");
                    actions.AppendLine("TAG POS=1 TYPE=span ATTR=STYLE:font-weight:<SP>bold; EXTRACT=TXT");
                    actions.AppendLine("WAIT SECONDS=1");
                    actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=ads_info_profile_" + i);
                    actions.AppendLine("URL GOTO=https://timebucks.com/publishers/index.php?pg=dashboard");
                    actions.AppendLine("'Save ref link");
                    actions.AppendLine("TAG POS=1 TYPE=input ATTR=ID:ref_link EXTRACT=TXT");
                    actions.AppendLine("WAIT SECONDS=1");
                    actions.AppendLine("SAVEAS TYPE=EXTRACT FOLDER=* FILE=ads_info_profile_" + i);
                    actions.AppendLine("URL GOTO=https://timebucks.com/publishers/index.php?pg=setting");
                    actions.AppendLine("'Complete profile");
                    actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=ID:fullname CONTENT=\"" + txtUsername.Text.Trim() + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=ID:address CONTENT=\"" + txtFirstname.Text.Trim() + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=ID:dob CONTENT=\"" + txtLastname.Text.Trim() + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=SELECT ATTR=ID:dobMonth CONTENT=\"" + GetMonth(int.Parse(txtLastname.Text.Trim().Split('/')[0])) + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=SELECT ATTR=ID:dobDay CONTENT=\"" + txtLastname.Text.Trim().Split('/')[1] + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=SELECT ATTR=ID:dobYear CONTENT=\"" + txtLastname.Text.Trim().Split('/')[2] + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=SPAN ATTR=ID: CONTENT=\"" + txtState.Text.Trim() + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=DIV ATTR=CLASS:cuselText CONTENT=\"" + (rdGenderMale.Checked ? rdGenderMale.Text : rdGenderFemale.Text) + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=ID:gender CONTENT=\"" + (rdGenderMale.Checked ? rdGenderMale.Text.ToLower() : rdGenderFemale.Text.ToLower()) + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=SPAN ATTR=ID:select2-state2-container CONTENT=\"" + txtState.Text.Trim() + "\"");
                    actions.AppendLine("TAG POS=1 TYPE=INPUT ATTR=TYPE:button");
                    actions.AppendLine("WAIT SECONDS=5");
                    actions.AppendLine("TAG POS=2 TYPE=INPUT ATTR=TYPE:button");
                    actions.AppendLine("WAIT SECONDS=300");
                    Handler.CreateBatFile(actions.ToString(), fileName);
                }
                var profile = "-p \"User" + i + "\" -no-remote \"imacros://run/?m=register_ads_" + i + ".iim\"";
                Handler.StartProcess(frmAutoClicker.OperationType.CreateAccounts, frmAutoClicker.GetAppPath(frmAutoClicker.BrowserType.Firefox), profile, true, true, "");
                toolStripStatus.Text = "Openning profile User" + i;
                Thread.Sleep(10000);                
                //txtEmail.Text = txtEmail.Text.Remove(0, txtEmail.Text.Substring(0, txtEmail.Text.IndexOf(";")).Length + 1);
                ii++;
                var timer = 1000;
                var m = timer/60;
                var s = 60;
                m = 6;
                do
                {
                    s--;
                    if (s == 0 && m > 0)
                    {
                        m--;
                        s = 59;
                    }
                    if (m == 1 && s == 1)
                    {
                        Properties.Settings.Default.TotalProfilesTimebucks = i;
                        Properties.Settings.Default.Save();
                        successful = true;
                        Handler.Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                        Handler.Log("Create account for profile User" + i);
                        if (count == 3)
                        {
                            Properties.Settings.Default.Link_Timebucks = Handler.GetInfo(string.Format(refInfoProfileFilePath, "ads", i)).Split(';')[1].Replace("https://", "");
                            Properties.Settings.Default.Save();
                            //File.Delete(getAdsInfoFilePath);
                            File.WriteAllText(getAdsInfoFilePath, "0;" + (index + 1));
                            Handler.DeleteFiles(false, fromProfile, toProfile, false, true);
                        }
                    }
                    toolStripStatus.Text = "Profile User" + i + " will finish in ... " + m + ":" + s;
                    Thread.Sleep(1000);
                } while (m >= 0 && s > 0 && !stopped);
                KillProcesses();
            }
            #endregion            
        }

        private static string GetMonth(int month)
        {
            var sMonth = "";
            switch (month)
            {
                case 1:
                    sMonth = "January";
                    break;
                case 2:
                    sMonth = "February";
                    break;
                case 3:
                    sMonth = "March";
                    break;
                case 4:
                    sMonth = "April";
                    break;
                case 5:
                    sMonth = "May";
                    break;
                case 6:
                    sMonth = "June";
                    break;
                case 7:
                    sMonth = "July";
                    break;
                case 8:
                    sMonth = "August";
                    break;
                case 9:
                    sMonth = "September";
                    break;
                case 10:
                    sMonth = "October";
                    break;
                case 11:
                    sMonth = "November";
                    break;
                case 12:
                    sMonth = "December";
                    break;                    
            }
            return sMonth;
        }

        private void EnableControls(bool isEnabled)
        {
            if (btnStart.Text == "Start") btnStart.Enabled = isEnabled;
            foreach (Control ctr in groupTypes.Controls) ctr.Enabled = (btnStart.Text == "Start");
            foreach (Control ctr in groupSettings.Controls)
                if (ctr is TextBox || ctr is CheckBox || ctr is RadioButton) ctr.Enabled = isEnabled;                       
            if (rdPresearch.Checked || rdGlobalNX.Checked)
            {
                if (chkIsUseVirtualEmails.Checked && chkIsUseVirtualEmails.Enabled) txtEmail.Enabled = false;
                var toProfile = int.Parse(txtFromProfile.Text.Trim()) + 2;
                if (toProfile > Properties.Settings.Default.NumOfProfilesInstalled) toProfile = Properties.Settings.Default.NumOfProfilesInstalled;
                txtToProfile.Text = toProfile.ToString();
            }               
            else txtToProfile.Text = txtFromProfile.Text.Trim();
            txtToProfile.Enabled = false;
        }
                
        private void chkIsUseVirtualEmails_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsUseVirtualEmails.Checked) txtEmail.Enabled = false;
            else txtEmail.Enabled = true;
        }

        private void KillProcesses()
        {
            if(stopped) toolStripStatus.Text = "Ready!";
            Handler.StopProcess(frmAutoClicker.OperationType.CreateAccounts, frmAutoClicker.FIREFOX, false, false);
        }

        private void frmCreateAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosed = stopped = checkAdsStopped = checkSearchservicesStopped = true;
            KillProcesses();
        }

        private void rdTimebucks_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTimebucks.Checked)
            {
                ShowControls(true);
                if (frmAutoClicker.isTimebucksRunning)
                {
                    EnableControls(false);
                    MessageBox.Show("You can't create accounts when running timebucks." + System.Environment.NewLine + "Please stop and create accounts again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var fromProfile = frmAutoClicker.numOfProfilesTimebucks + 1;
                if (fromProfile > Properties.Settings.Default.NumOfProfilesInstalled) fromProfile = Properties.Settings.Default.NumOfProfilesInstalled;
                txtFromProfile.Text = fromProfile.ToString();
                accountType = AccountType.Timebucks;
                checkSearchservicesStopped = true;
                checkAdsStopped = false;
                System.Threading.Tasks.Task.Factory.StartNew(() => CheckTimeToRunForAds());
            }        
        }

        private void rdSearchServices_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPresearch.Checked)
            {
                ShowControls(false);
                var fromProfile = frmAutoClicker.numOfProfilesPresearch + 1;
                if (fromProfile > Properties.Settings.Default.NumOfProfilesInstalled) fromProfile = Properties.Settings.Default.NumOfProfilesInstalled;
                txtFromProfile.Text = fromProfile.ToString();                
                accountType = AccountType.Presearch;
                checkAdsStopped = true;
                checkSearchservicesStopped = false;
                System.Threading.Tasks.Task.Factory.StartNew(() => CheckTimeToRunForSearchservices());
            }
        }

        private void ShowControls(bool isShow)
        {
            var xx = btnStart.Location.X;
            var yy = btnStart.Location.Y;            
            if (isShow) //Ads checked
            {
                this.ClientSize = new System.Drawing.Size(547, 706);//611
                groupSettings.Height = 410;                
                btnStart.Location = new System.Drawing.Point(xx, 558 - 22);
            }
            else //Searchservices checked
            {
                this.ClientSize = new System.Drawing.Size(547, 555);
                groupSettings.Height = 355;
                btnStart.Location = new System.Drawing.Point(xx, 558 - 77);        
            }
            foreach (Control ctr in groupSettings.Controls)
            {
                ctr.Show();
                if (isShow)
                {
                    if (ctr.Name == "chkIsUseVirtualEmails") ctr.Hide();
                    if (ctr.Name.Contains("Firstname") || ctr.Name.Contains("Lastname") || ctr.Name.Contains("Password"))
                    {
                        var x = ctr.Location.X;
                        var y = ctr.Location.Y;
                        ctr.Location = new System.Drawing.Point(x, y - 22);
                    }
                    if(ctr.Name.Contains("State"))
                    {
                        var x = ctr.Location.X;
                        var y = ctr.Location.Y;
                        if (ctr is Label) y = 354;
                        else y = 352;
                        ctr.Location = new System.Drawing.Point(x, y - 22);
                    }
                    if (ctr.Name.Contains("Gender"))
                    {
                        var x = ctr.Location.X;
                        var y = ctr.Location.Y;
                        if (ctr is Label) y = 395;
                        else y = 393;
                        ctr.Location = new System.Drawing.Point(x, y - 22);
                    }
                    if (ctr is Label)
                    {
                        Label lbl = (Label)ctr;
                        if (lbl.Name == "lblUsername") lbl.Text = "Fullname";
                        if (lbl.Name == "lblFirstname") lbl.Text = "Address";
                        if (lbl.Name == "lblLastname") lbl.Text = "Birthdate";
                    }
                }
                else
                {
                    if (ctr.Name == "chkIsUseVirtualEmails") ctr.Show();
                    if (ctr.Name.Contains("State") || ctr.Name.Contains("Gender")) ctr.Hide();                                        
                    if (ctr.Name.Contains("Firstname"))
                    {
                        var x = ctr.Location.X;
                        var y = ctr.Location.Y;
                        if (ctr is Label) y = 219;
                        else y = 217;
                        ctr.Location = new System.Drawing.Point(x, y);
                    }
                    if (ctr.Name.Contains("Lastname"))
                    {
                        var x = ctr.Location.X;
                        var y = ctr.Location.Y;
                        if (ctr is Label) y = 262;
                        else y = 260;
                        ctr.Location = new System.Drawing.Point(x, y);
                    }
                    if (ctr.Name.Contains("Password"))
                    {
                        var x = ctr.Location.X;
                        var y = ctr.Location.Y;
                        if (ctr is Label) y = 308;
                        else y = 306;
                        ctr.Location = new System.Drawing.Point(x, y);
                    }
                    if (ctr is Label)
                    {
                        Label lbl = (Label)ctr;
                        if (lbl.Name == "lblUsername") lbl.Text = "Username";
                        if (lbl.Name == "lblFirstname") lbl.Text = "Firstname";
                        if (lbl.Name == "lblLastname") lbl.Text = "Lastname";
                    }
                }
            }
        }
                
        private void txtFromProfile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFromProfile.Text.Trim()))
            {
                if (int.Parse(txtFromProfile.Text.Trim()) >= Properties.Settings.Default.NumOfProfilesInstalled) txtFromProfile.Text = Properties.Settings.Default.NumOfProfilesInstalled.ToString();
                if (rdPresearch.Checked || rdGlobalNX.Checked)
                {
                    var toProfile = int.Parse(txtFromProfile.Text.Trim()) + 2;
                    if (toProfile > Properties.Settings.Default.NumOfProfilesInstalled) toProfile = Properties.Settings.Default.NumOfProfilesInstalled;
                    txtToProfile.Text = toProfile.ToString();
                }
                else txtToProfile.Text = txtFromProfile.Text.Trim();
            }
        }

        private void rdGlobalNX_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
