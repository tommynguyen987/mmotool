using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyTool
{
    public partial class frmAutoClicker : Form
    {
        #region Variables
        public static string logFilePath = Application.StartupPath + "\\logs";
        public static string settingsFilePath = Application.StartupPath + "\\settings.ini";
        public static string positionsFilePath = Application.StartupPath + "\\positions";
        public static string processIdsFilePath = Application.StartupPath + "\\processIds";
        public static string timebucksDataFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Downloads\\adsdata_profile_{0}";
        public static string searchservicesDataFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Downloads\\searchservicesdata_profile_{0}";
        public const string FIREFOX = "firefox";
        public const string MICROSOFTEDGE = "msedge";
        public const string COCCOC = "browser";
        public const string CHROME = "chrome";
        public const string YANDEX = "yandex";        
        public const string BRAVE = "brave";

        static readonly string firefoxPath1 = "C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe";
        static readonly string firefoxPath2 = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
        static readonly string msEdgePath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe";
        static readonly string cococPath = "C:\\Users\\phatnguyen\\AppData\\Local\\CocCoc\\Browser\\Application\\browser.exe";
        static readonly string chromePath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
        static readonly string yandexPath = @"C:\Users\phatnguyen\AppData\Local\Yandex\YandexBrowser\Application\browser.exe";
        static readonly string bravePath = @"C:\Program Files(x86)\BraveSoftware\Brave-Browser\Application\brave.exe";
        static string openFirefoxOnMinimizedFilePath = Application.StartupPath + "\\openfirefoxonminimized_{0}-{1}.bat";        
        static string getAdsDataFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Macros\\getadsdata_profile_{0}.iim";
        static string profileIndexFilePath = "C:\\Users\\" + Environment.UserName.ToLower() + "\\Documents\\iMacros\\Datasources\\profile.txt";
        static string startProcessPath = Application.StartupPath + "\\handlers\\startprocess_{0}.bat";
        static string killProcessPath = Application.StartupPath + "\\handlers\\killprocesses_{0}.bat";

        static bool autoStopped = false;
        static bool manualStopped = false;
        static bool changed = false;
        static bool isRunningAuto = false;
        static bool isRunningManual = false;
        static bool isRunningFreebitco = false;
        static bool isRunningFreebitcoin = false;
        static int numOfProfiles = 0;
        static int startIndex = 0;
        static int endIndex = 1;
        static int counterFreebitcoinTaskTimer = 0;
        static int counterFreebitcoTaskTimer = 0;

        public static int currentProfile = 1;        
        public static int numOfProfilesTimebucks = 0;
        public static int numOfProfilesPresearch = 0;
        public static int numOfProfilesPaidviewpoint = 0;
        public static int numOfProfilesIndexbitco = 0;
        public static int numOfProfilesFreebitcoin = 0;
        public static int numOfProfilesAdbtc = 0;
        public static int numOfProfilesAuto = 0;
        public static int numOfProfilesAutoProxy = 0;
        public static int numOfProfilesManual = 0;
        public static int numOfProfilesManualProxy = 0;

        public static int waitTime = 0;
        public static bool isRunning = false;
        public static bool isTimebucksRunning = false;
        public static TaskType taskType = TaskType.Auto;
                
        public enum MyWindowState
        {
            MINIMIZED = 1,
            NORMAL = 2
        }

        public enum OperationType
        {
            STARTAUTO = 0,
            STARTMANUAL = 1,
            CreateProfiles = 2,
            CreateAccounts = 3
        }

        public enum TaskType
        {
            Auto = 1,
            Manual = 0
        }

        public enum BrowserType
        {
            Firefox = 1,
            Chrome = 2,
            Brave = 3,
            MsEdge = 4,
            CocCoc = 5,
            Yandex = 6
        }

        public enum AutoTasks
        {
            Timebucks = 1,
            Presearch = 2,
            Paidviewpoint = 3,
            Indexbitco = 4,
            Freebitcoin = 5,
            Adbtc = 6,
            AutoFreebitco = 7
        }

        public enum ManualTasks
        {
            Freebitco = 1,
            Freelitecoin = 2,
            Bitpick = 3,
            Bither = 4,
            Btcclicks = 5,
            Btcvic = 6,            
            Adbtc = 7,
            Hashingadspace = 8
        }
        
        [DllImport("user32.dll")]
        static extern bool AnimateWindow(System.IntPtr hWnd, int time, AnimateWindowFlags flags);
        [System.Flags]
        enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }
        
        public frmAutoClicker()
        {
            InitializeComponent();
            StartUpManager.AddApplicationToCurrentUserStartup("MMOTOOL");
        }
        #endregion
                       
        #region Other methods of main form   
        private void frmAutoClicker_Load(object sender, EventArgs e)
        {
            GetSettings();
            Thread.Sleep(2000);
            if (chkIsAutoRunServices.Checked)
            {
                StartTasks(true);
                SetWindowsState(MyWindowState.MINIMIZED);
            }
        }
        private void frmAutoClicker_Activated(object sender, EventArgs e)
        {
            if (frmCreateAccounts.isClosed)
            {
                btnCreateAccounts.Enabled = true;
                if (frmCreateAccounts.successful)
                {
                    var total = (frmCreateAccounts.accountType == frmCreateAccounts.AccountType.Timebucks ? Properties.Settings.Default.TotalProfilesTimebucks : Properties.Settings.Default.TotalProfilesPresearch);
                    if (int.Parse(txtTotalProfiles.Text.Trim()) < total)
                    {
                        txtTotalProfiles.Text = total.ToString();
                        numOfProfiles = total;
                    }
                    else numOfProfiles = int.Parse(txtTotalProfiles.Text.Trim());
                    UpdateSettings();
                }
            }
            if (frmCreateProfiles.isClosed) btnCreateProfiles.Enabled = true;
            if (frmCreateAccounts.accountType == frmCreateAccounts.AccountType.Timebucks && chkTimebucks.Checked) btnStartTasks.Enabled = false;
        }
        private void frmAutoClicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExit()) e.Cancel = true;
        }
        private bool isExit()
        {
            var confirm = MessageBox.Show(this, "Do you really want to exit application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                if (changed) UpdateSettings();
                KillProcesses(true, true);
                KillProcesses(true, false);
                Handler.DeleteFiles(false, startIndex, endIndex, chkPresearch.Checked, chkTimebucks.Checked);
                this.Dispose();
                this.Close();
                return true;
            }
            return false;
        }        
        #endregion

        #region Methods of autorun tasks
        private void btnStartTasks_Click(object sender, EventArgs e)
        {
            if (btnStartTasks.Text == "START") StartTasks(true);
            else
            {
                lstStatus.Text += System.Environment.NewLine + "Stopped tasks!" + System.Environment.NewLine;
                Application.DoEvents();
                autoStopped = true;
                isRunning = isTimebucksRunning = isRunningFreebitcoin = isRunningFreebitco = false;
                KillProcesses(true, true);
                KillProcesses(true, false);
                EnableControls(true, true);
                btnStartTasks.Text = "START";                
            }
        }
        private void StartTasks(bool isAuto)
        {            
            if (isAuto)
            {
                autoStopped = false;
                isRunning = true;
                btnStartTasks.Text = "STOP";
                EnableControls(false, true);
                lstStatus.Text += System.Environment.NewLine + "//====================AUTO TASKS====================//" + System.Environment.NewLine;
                lstStatus.Text += System.Environment.NewLine + "Starting auto tasks..." + System.Environment.NewLine;
                Application.DoEvents();
                if (chkTimebucks.Checked) isTimebucksRunning = true;
                if (changed)
                {
                    changed = false;
                    UpdateSettings();
                }
                if (chkTimebucks.Checked || chkPresearch.Checked || chkPaidviewpoint.Checked || chkIndexBitco.Checked || chkFreeBitcoin.Checked || chkAutoFreebitco.Checked)
                    Task.Factory.StartNew(() => HandleAutoClicker(true, false));
            }
            else
            {
                manualStopped = false;
                isRunningManual = true;
                btnStartManual.Text = "STOP";                
                EnableControls(false, false);
                //toolStripStatus2.Text += "Starting manual tasks..." + System.Environment.NewLine;
                if (chkFreeBitco.Checked || chkFreeLitecoin.Checked || chkBitpick.Checked || chkBither.Checked ||
                    chkBtcClicks.Checked || chkBtcVic.Checked || chkAdbtc.Checked || chkHashingadSpace.Checked)
                    Task.Factory.StartNew(() => HandleAutoClicker(false, false));
            }            
        }
        private void HandleAutoClicker(bool isAuto, bool isProxy)
        {
            if (isAuto)
            {
                while (!autoStopped)
                {
                    var isInternetConnected = true;
                    do
                    {
                        isInternetConnected = Handler.NetworkIsAvailable();
                        if (!isInternetConnected)
                        {
                            lstStatus.Text += System.Environment.NewLine + "No internet connection. Please check connection..." + System.Environment.NewLine;
                            Application.DoEvents();
                            Thread.Sleep(5000);
                        }
                    } while (!isInternetConnected);
                    Thread.Sleep(1000 * 5);
                    if (chkFreeBitcoin.Checked && !isRunningFreebitcoin) Task.Factory.StartNew(() => StartAutoTasks(AutoTasks.Freebitcoin));
                    Thread.Sleep(1000 * 5);
                    if (chkAutoFreebitco.Checked && !isRunningFreebitco) Task.Factory.StartNew(() => StartAutoTasks(AutoTasks.AutoFreebitco));                                            
                    Thread.Sleep(1000 * 5);
                    if ((chkTimebucks.Checked || chkPresearch.Checked || chkPaidviewpoint.Checked || chkIndexBitco.Checked) && !isRunningAuto) Task.Factory.StartNew(() => AutoClickerByProfiles(true, false));                        
                }
            }
            else Task.Factory.StartNew(() => StartManualTasks());
        }
        private void AutoClickerByProfiles(bool isAuto, bool isProxy)
        {
            isRunningAuto = true;

            #region Check if exists appPath
            var appPath = GetAppPath(BrowserType.Firefox);
            if (string.IsNullOrEmpty(appPath))
            {
                autoStopped = true;
                MessageBox.Show("You haven't installed Firefox!" + Environment.NewLine + "Please install Firefox and run again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (isAuto) btnStartTasks.Text = "START";
                //EnableControls(true, isAuto);
                return;
            }            
            #endregion

            #region Variables
            numOfProfilesTimebucks = Properties.Settings.Default.TotalProfilesTimebucks;
            numOfProfilesPresearch = Properties.Settings.Default.TotalProfilesPresearch;
            numOfProfilesPaidviewpoint = Properties.Settings.Default.TotalProfilesPaidviewpoint;
            numOfProfilesIndexbitco = Properties.Settings.Default.TotalProfilesIndexbitco;
            numOfProfilesFreebitcoin = Properties.Settings.Default.TotalProfilesFreebitcoin;
            numOfProfilesAdbtc = Properties.Settings.Default.TotalProfilesAdbtc;

            numOfProfilesAuto = Properties.Settings.Default.TotalProfilesAuto;
            numOfProfilesAutoProxy = Properties.Settings.Default.TotalProfilesAutoProxy;
            numOfProfilesManual = Properties.Settings.Default.TotalProfilesManual;
            numOfProfilesManualProxy = Properties.Settings.Default.TotalProfilesManualProxy;

            var numProfilesEveryRunning = 1;                        
            var count = 1;
            var runningCount = 0;            

            if (!isProxy)
            {
                txtFromProfile.Text = Properties.Settings.Default.FromProfile.ToString();
                txtTotalProfiles.Text = Properties.Settings.Default.TotalProfiles.ToString();
            }
            else
            {
                txtFromProfile.Text = Properties.Settings.Default.FromProfile.ToString();
                txtTotalProfiles.Text = Properties.Settings.Default.TotalProfilesAutoProxy.ToString();
            }

            int.TryParse(txtProfilesEveryRunning.Text.Trim(), out numProfilesEveryRunning);
            int.TryParse(txtFromProfile.Text.Trim(), out startIndex);
            int.TryParse(txtTotalProfiles.Text.Trim(), out numOfProfiles);            
            var isRunning = false;
            var runS_T = false;
            var runS = false;
            var runT = false;
            var countAds = "1";
            var countSlideshows = "1";
            var serviceType = "Total profiles: ";
            var auto = "Auto.";
            var user = "";
            var dicProfiles = new Dictionary<string, bool>();
            var dicRunnings = new Dictionary<string, bool>();
            waitTime = 0;
            endIndex = startIndex + numProfilesEveryRunning - 1;
            #endregion

            #region Loop profiles                
            for (int i = startIndex; i <= numOfProfiles;)
            {
                try
                {
                    if (autoStopped) return;
                    if (!chkTimebucks.Checked && !chkPresearch.Checked && !chkPaidviewpoint.Checked && !chkIndexBitco.Checked)
                    {
                        lstStatus.Text += System.Environment.NewLine + "Please choose at lease a task to run." + System.Environment.NewLine;
                        Application.DoEvents();
                        Thread.Sleep(1000 * 5);
                        return;
                    }                    
                    if (!string.IsNullOrEmpty(appPath))
                    {
                        var profile = "";
                        if (!isRunning)
                        {
                            if (i == 1) user = auto;
                            else user = auto + "User";
                            for (var j = 1; j <= numProfilesEveryRunning; j++)
                            {
                                var jj = (j + i - 1).ToString();
                                var k = 0;
                                var isDefault = true;
                                if (jj == "1")
                                    jj = "Default";
                                else
                                {
                                    isDefault = false;
                                    k = int.Parse(jj);
                                }                                        
                                    
                                if (dicProfiles.ContainsKey(jj))
                                {
                                    var v = false;
                                    dicProfiles.TryGetValue(jj, out v);
                                    if (v)
                                    {
                                        //Handler.Log("Continued because of duplicating");
                                        //lstStatus.Text += serviceType + numOfProfiles + ", openning profiles..." + System.Environment.NewLine;
                                        Thread.Sleep(5000);
                                        //continue;
                                    }
                                }
                                var path = "";
                                dicRunnings.Add(jj, false);                                

                                // Timebucks
                                var pathAds = string.Format(frmCreateAccounts.refInfoProfileFilePath, "timebucks", jj);
                                if (chkTimebucks.Checked && ((k <= numOfProfilesTimebucks && !isDefault) || isDefault))
                                {
                                    path = string.Format(timebucksDataFilePath, jj);
                                    if (File.Exists(path))
                                    {
                                        var lastWriteTime = File.GetLastWriteTime(path);
                                        var isCompared = (DateTime.Now - lastWriteTime.AddDays(0.6)).Hours > 0;
                                        if (!isCompared)
                                        {
                                            try
                                            {
                                                if (Handler.GetInfo(path).Split(';').Length >= 3)
                                                {
                                                    countAds = (string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[0]) ? "0" : Handler.GetInfo(path).Split(';')[0]).Trim();
                                                    countSlideshows = (string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[1]) ? "0" : Handler.GetInfo(path).Split(';')[1]).Substring(Handler.GetInfo(path).Split(';')[1].IndexOf("f") + 1).Replace(" entries", "").Trim();
                                                }
                                                else if (Handler.GetInfo(path).Split(';').Length == 2)
                                                {
                                                    countAds = (string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[0]) ? "0" : Handler.GetInfo(path).Split(';')[0]).Trim();
                                                    countSlideshows = (string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[1]) ? "0" : Handler.GetInfo(path).Split(';')[1]).Substring(Handler.GetInfo(path).Split(';')[1].IndexOf("f") + 1).Replace(" entries", "").Trim();
                                                }
                                                else if (Handler.GetInfo(path).Split(';').Length == 1)
                                                {
                                                    countAds = (string.IsNullOrEmpty(Handler.GetInfo(path).Split(';')[0]) ? "0" : Handler.GetInfo(path).Split(';')[0]).Trim();
                                                    countSlideshows = "1";
                                                }
                                                else
                                                {
                                                    countAds = "1";
                                                    countSlideshows = "1";
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Handler.Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                                                Handler.Log("There's an error when getting ads info on timebucks!" + System.Environment.NewLine + ex.StackTrace);
                                                lstStatus.Text += System.Environment.NewLine + "There's an error when getting ads info on timebucks!" + System.Environment.NewLine;
                                                Application.DoEvents();
                                                File.Delete(path);
                                                countAds = "1";
                                                countSlideshows = "1";
                                            }
                                        }
                                        var isDeleted = ((countAds != "0" && countAds != "#EANF#") || (countSlideshows != "0" && countSlideshows != "#EANF#") || isCompared);
                                        if (isDeleted) File.Delete(path);
                                    }
                                    else countAds = countSlideshows = "1";
                                }
                                if (chkPresearch.Checked && chkTimebucks.Checked && ((k <= numOfProfilesTimebucks && k <= numOfProfilesPresearch && !isDefault) || isDefault))
                                {
                                    lstStatus.Text += System.Environment.NewLine + "Openning Timebucks.com and Presearch.org..." + System.Environment.NewLine;
                                    Application.DoEvents();
                                    var isContinued = ((countAds == "0" || countAds == "#EANF#") && (countSlideshows == "0" || countSlideshows == "#EANF#"));
                                    if (isContinued)
                                    {
                                        //Handler.Log("Continued searchservices and ads ?" + isContinued);
                                        //lstStatus.Text += serviceType + numOfProfiles + ", openning profiles..." + System.Environment.NewLine;
                                        profile = "";
                                        Thread.Sleep(5000);
                                        //continue;
                                    }
                                    else
                                    {
                                        var searchService = "";
                                        runS = runT = false;
                                        searchService = "SearchServices_Presearch&";                                        
                                        if (countAds != "0" && countAds != "#EANF#" && countSlideshows != "0" && countSlideshows != "#EANF#")
                                        {
                                            runS_T = true;
                                            profile = "-p \"" + user + jj + "\" -no-remote \"imacros://run/?m=" + searchService + "Timebucks_Ads_Slideshows.iim\"";
                                        }
                                        else if (countAds != "0" && countAds != "#EANF#")
                                        {
                                            runS_T = true;
                                            profile = "-p \"" + user + jj + "\" -no-remote \"imacros://run/?m=" + searchService + "Timebucks_Ads.iim\"";
                                        }
                                        else if (countSlideshows != "0" && countSlideshows != "#EANF#")
                                        {
                                            runS_T = true;
                                            profile = "-p \"" + user + jj + "\" -no-remote \"imacros://run/?m=" + searchService + "Timebucks_Slideshows.iim\"";
                                        }
                                        else
                                        {
                                            runS = true;
                                            runS_T = runT = false;
                                            profile = "-p \"" + user + jj + "\" -no-remote \"imacros://run/?m=SearchServices_Presearch.iim\"";
                                        }
                                    }
                                }
                                else if (chkPresearch.Checked)
                                {
                                    lstStatus.Text += System.Environment.NewLine + "Openning Presearch.org..." + System.Environment.NewLine;                                    
                                    if ((k <= numOfProfilesPresearch && !isDefault) || isDefault)
                                    {
                                        runS = true;
                                        runS_T = runT = false;
                                        profile = "-p \"" + user + jj + "\" -no-remote \"imacros://run/?m=SearchServices_Presearch.iim\"";
                                    }
                                    else
                                    {
                                        //Handler.Log("User" + jj + " not existed!");
                                        lstStatus.Text += System.Environment.NewLine + "User" + jj + " not existed!" + System.Environment.NewLine;
                                        profile = "";
                                        Thread.Sleep(5000);
                                    }
                                    Application.DoEvents();
                                }
                                else if (chkTimebucks.Checked)
                                {
                                    lstStatus.Text += System.Environment.NewLine + "Openning Timebucks.com..." + System.Environment.NewLine;
                                    if ((k <= numOfProfilesTimebucks && !isDefault) || isDefault)
                                    {
                                        var isContinued = ((countAds == "0" || countAds == "#EANF#") && (countSlideshows == "0" || countSlideshows == "#EANF#"));
                                        if (isContinued)
                                        {
                                            //Handler.Log("Continued ads ?" + isContinued);
                                            //lstStatus. = serviceType + numOfProfiles + ", openning profiles...";
                                            profile = "";
                                            Thread.Sleep(5000);
                                            //continue;
                                        }
                                        else
                                        {
                                            if (countAds != "0" && countAds != "#EANF#" && countSlideshows != "0" && countSlideshows != "#EANF#")
                                            {
                                                runS_T = true;
                                                runS = runT = false;
                                                profile = "-p \"" + user + jj + "\" -no-remote \"imacros://run/?m=Timebucks_Ads_Slideshows.iim\"";
                                            }
                                            else
                                            {
                                                runS_T = runS = false;
                                                if (countAds != "0" && countAds != "#EANF#")
                                                {
                                                    runT = true;
                                                    profile = "-p \"" + user + jj + "\" -no-remote \"imacros://run/?m=Timebucks_Ads.iim\"";
                                                }
                                                else if (countSlideshows != "0" && countSlideshows != "#EANF#")
                                                {
                                                    runT = true;
                                                    profile = "-p \"" + user + jj + "\" -no-remote \"imacros://run/?m=Timebucks_Slideshows.iim\"";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Handler.Log("User" + jj + " not existed!");
                                        lstStatus.Text += System.Environment.NewLine + "User" + jj + " not existed!" + System.Environment.NewLine;
                                        profile = "";
                                        Thread.Sleep(5000);
                                    }
                                    Application.DoEvents();
                                }                                
                                runningCount++;
                                if (dicProfiles.ContainsKey(jj))
                                {
                                    dicProfiles.Remove(jj);
                                    dicProfiles.Add(jj, true);
                                }                                    
                                else dicProfiles.Add(jj, true);
                                if (runningCount == numProfilesEveryRunning) startIndex = (jj == "Default" ? 1 : int.Parse(jj));
                                if (!string.IsNullOrEmpty(profile))
                                {
                                    isRunning = true;
                                    dicRunnings.Remove(jj);
                                    dicRunnings.Add(jj, true);
                                    File.WriteAllText(profileIndexFilePath, jj.ToString());                                    
                                }
                            }
                        }
                        if (runningCount == numProfilesEveryRunning || (runningCount < numProfilesEveryRunning && numProfilesEveryRunning > numOfProfiles - endIndex))
                        {
                            waitTime = (new Random()).Next(20 * 60 * 1000, 30 * 60 * 1000) + 300;
                            isRunning = dicRunnings.ContainsValue(true) ? true : false;
                            dicRunnings = new Dictionary<string, bool>();
                            runningCount = 0;
                            count++;
                            if (i < numOfProfiles)
                            {
                                i = (i + numProfilesEveryRunning) > numOfProfiles ? (endIndex + 1) : (i + numProfilesEveryRunning);
                                i = i > numOfProfiles ? numOfProfiles : i;
                            }
                            else i += numProfilesEveryRunning;
                            endIndex = (numProfilesEveryRunning * count) > numOfProfiles ? numOfProfiles : (numProfilesEveryRunning * count);
                            if (isRunning)
                            {
                                var desc = "Open profile " + profile + Environment.NewLine; 
                                desc += "-----------------------------------------------------------------" + Environment.NewLine;                                
                                desc += "Running the task with profile " + (startIndex == 1 ? "Default" : "User" + startIndex) + (startIndex < endIndex ? (" to User" + endIndex) : "");                                
                                Handler.StartProcess(OperationType.STARTAUTO, appPath, profile, false, true, desc);                                
                                var timer = 40 * 60;
                                if (runT && !runS_T && runS) timer = 30 * 60;
                                else if (runS || runT && !runS_T) timer = 20 * 60;
                                var m = timer / 60 - 1;
                                var s = 60;
                                if(numOfProfiles > 1)
                                {
                                    while (m >= 0 && s > 0 && !autoStopped && (chkTimebucks.Checked || chkPresearch.Checked || chkPaidviewpoint.Checked || chkAdbtc.Checked || chkIndexBitco.Checked))
                                    {
                                        s--;
                                        if (s == 0 && m > 0)
                                        {
                                            m--;
                                            s = 59;
                                        }
                                        lstStatus.Text += System.Environment.NewLine + serviceType + numOfProfiles + ", openning profile " + (startIndex == 1 ? "Default" : "User" + startIndex) + (startIndex < endIndex ? (" to User" + endIndex) : "") + ", please wait for next profiles in ... " + m + ":" + s + System.Environment.NewLine;
                                        Application.DoEvents();
                                        Thread.Sleep(1000);
                                    }                                    
                                    Handler.StopProcess(OperationType.STARTAUTO, FIREFOX, false, false);
                                    isRunning = false;
                                    isRunningAuto = false;
                                }
                                else
                                {
                                    lstStatus.Text += System.Environment.NewLine + serviceType + numOfProfiles + ", openning profile Default" + System.Environment.NewLine;
                                    Application.DoEvents();
                                }                                    
                            }
                        }
                        currentProfile = i;
                    }
                }
                catch (Exception ex)
                {
                    autoStopped = true;
                    Handler.Log("//===========================ERRORS============================//");
                    Handler.Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                    Handler.Log("There's an error when running profiles!" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace);
                    Handler.StopProcess(OperationType.STARTAUTO, FIREFOX, false, false);
                    if (isAuto)
                    {
                        lstStatus.Text += System.Environment.NewLine + "There's an error when running profiles!" + System.Environment.NewLine;
                        Application.DoEvents();
                        btnStartTasks.Text = "START";
                    }      
                    return;
                }
            }
            #endregion                        
        }
        private void StartAutoTasks(AutoTasks tasks)
        {
            if (autoStopped) return;
            var path = "";
            var url = "";
            var desc = "";
            if (tasks == AutoTasks.Freebitcoin)
            {
                if (!chkFreeBitcoin.Checked) return;
                isRunningFreebitcoin = true;
                path = GetAppPath(BrowserType.CocCoc);
                url = "https://freebitcoin.io/free";
                lstStatus.Text += System.Environment.NewLine + "Openning Freebitcoin.io..." + System.Environment.NewLine;                
                /*
                path = string.Format(startProcessPath, COCCOC);
                if (!File.Exists(path))
                {
                    var action = "START \"\" /min \"" + msEdgePath + "\"  --profile-directory=Default \"" + url + "\"";
                    Handler.CreateBatFile(action, path);
                }
                */
                desc = "Open Freebitcoin.io by Coc Coc";
                Handler.StartProcess(OperationType.STARTAUTO, path, url, false, true, desc);                
                Thread.Sleep(1000 * 60 * 10);
                lstStatus.Text += System.Environment.NewLine + "Closed Freebitcoin.io." + System.Environment.NewLine;
                Application.DoEvents();
                //Handler.StopProcess(OperationType.STARTAUTO, COCCOC, false, false);
                path = string.Format(killProcessPath, COCCOC);
                if (!File.Exists(path)) 
                {
                    var action = "taskkill /F /IM " + COCCOC + ".exe";
                    Handler.CreateBatFile(action, path);
                }
                Handler.StopProcessByBatFile(path, OperationType.STARTAUTO, COCCOC);                                
            }
            else
            {
                if (!chkAutoFreebitco.Checked) return;
                isRunningFreebitco = true;
                url = "https://freebitco.in/?op=home";
                lstStatus.Text += System.Environment.NewLine + "Openning Freebitco.in..." + System.Environment.NewLine;                
                path = GetAppPath(BrowserType.Chrome);
                /*
                path = string.Format(startProcessPath, CHROME);
                if (!File.Exists(path))
                {
                    var action = "START \"\" /min \"" + chromePath + "\"  --profile-directory=Default \"" + url + "\"";
                    Handler.CreateBatFile(action, path);
                }
                */
                desc = "Open Freebitco.in by Google Chrome";
                Handler.StartProcess(OperationType.STARTAUTO, path, " --profile-directory=Default " + url, false, true, desc);
                Thread.Sleep(1000 * 60 * 10);
                //Handler.StopProcess(OperationType.STARTAUTO, CHROME, false, false);
                lstStatus.Text += System.Environment.NewLine + "Closed Freebitco.in." + System.Environment.NewLine;
                Application.DoEvents();
                path = string.Format(killProcessPath, CHROME);
                if (!File.Exists(path))
                {
                    var action = "taskkill /F /IM " + CHROME + ".exe";
                    Handler.CreateBatFile(action, path);
                }
                Handler.StopProcessByBatFile(path, OperationType.STARTAUTO, CHROME);                
            }
            LoopAutoTasks(tasks);
        }
        private void LoopAutoTasks(AutoTasks tasks)
        {
            var counterAutoTaskTimer = 0;
            Handler.Log("//======================WAIT FOR NEXT RUN======================//");
            Handler.Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
            switch (tasks)
            {
                case AutoTasks.Freebitcoin:
                    counterAutoTaskTimer = counterFreebitcoinTaskTimer;
                    Handler.Log("Wait 1 hour for next running of task Freebitcoin.io");
                    lstStatus.Text += System.Environment.NewLine + "Wait 1 hour for next running of task Freebitcoin.io..." + System.Environment.NewLine;
                    Application.DoEvents();
                    break;
                case AutoTasks.AutoFreebitco:
                    counterAutoTaskTimer = counterFreebitcoTaskTimer;
                    Handler.Log("Wait 1 hour for next running of task Freebitco.in");
                    lstStatus.Text += System.Environment.NewLine + "Wait 1 hour for next running of task Freebitco.io..." + System.Environment.NewLine;
                    Application.DoEvents();
                    break;
            }                        
            do
            {
                if (autoStopped || (!isRunningFreebitcoin && tasks == AutoTasks.Freebitcoin) || (!isRunningFreebitco && tasks == AutoTasks.AutoFreebitco)) return;
                counterAutoTaskTimer++;
                Thread.Sleep(1000 * 60);
            } while (counterAutoTaskTimer <= 61);
            Task.Factory.StartNew(() => StartAutoTasks(tasks));
        }
        private void btnCreateProfiles_Click(object sender, EventArgs e)
        {
            btnCreateProfiles.Enabled = false;            
            Task.Factory.StartNew(() => CreateProfiles());
        }
        private static void CreateProfiles()
        {
            var createProfiles = new frmCreateProfiles();
            createProfiles.ShowDialog();
        }
        private void btnCreateAccounts_Click(object sender, EventArgs e)
        {            
            btnCreateAccounts.Enabled = false; 
            Task.Factory.StartNew(() => CreateAccounts());
        }
        private static void CreateAccounts()
        {
            var createAccounts = new frmCreateAccounts();
            createAccounts.ShowDialog();
        }
        #endregion

        #region Methods of manual tasks
        private void btnStartManual_Click(object sender, EventArgs e)
        {
            taskType = TaskType.Manual;
            if (btnStartManual.Text == "START") StartTasks(false);
            else StopManual();
        }
        private void StartManualTasks()
        {
            var isInternetConnected = Handler.NetworkIsAvailable();
            if (!isInternetConnected)
            {
                lstStatus2.Text += System.Environment.NewLine + "No internet connection. Please check connection..." + System.Environment.NewLine;
                manualStopped = true;
                isRunningManual = false;
                btnStartManual.Text = "START";
                EnableControls(true, false);
                return;
            }
            var path = GetAppPath(BrowserType.Brave);
            var killPath = string.Format(killProcessPath, BRAVE);
            if (!File.Exists(killPath))
            {
                var action = "taskkill /F /IM " + BRAVE + ".exe";
                Handler.CreateBatFile(action, killPath);
            }
            var url = "http://free-litecoin.com/";
            var desc = "";                                    
            lstStatus2.Text += System.Environment.NewLine + "//====================MANUAL TASKS====================//" + System.Environment.NewLine;
            lstStatus2.Text += System.Environment.NewLine + "Starting manual tasks..." + System.Environment.NewLine;
            if (chkFreeBitco.Checked)
            {
                lstStatus2.Text += System.Environment.NewLine + "Openning Freebitco.in..." + System.Environment.NewLine;
                url = "https://freebitco.in/?op=home";
                desc = "Open Freebitco.in by Brave";
                Handler.StartProcess(OperationType.STARTMANUAL, path, url, false, false, desc);                
            }
            else if(chkFreeLitecoin.Checked)
            {
                lstStatus2.Text += System.Environment.NewLine + "Openning Free-litecoin.com..." + System.Environment.NewLine;
                url = "http://free-litecoin.com/";
                desc = "Open Free-litecoin.com by Brave";
                Handler.StartProcess(OperationType.STARTMANUAL, path, url, false, false, desc);
            }
            else if(chkBitpick.Checked)
            {
                lstStatus2.Text += System.Environment.NewLine + "Openning Bitpick.co..." + System.Environment.NewLine;
                url = "http://bitpick.co/";
                desc = "Open Bitpick.co by Brave";
                Handler.StartProcess(OperationType.STARTMANUAL, path, url, false, false, desc);
            }
            else if(chkBither.Checked)
            {
                lstStatus2.Text += System.Environment.NewLine + "Openning Bither.one..." + System.Environment.NewLine;
                url = "http://panel.bither.one/getbither/";
                desc = "Open Bither.one by Brave";
                Handler.StartProcess(OperationType.STARTMANUAL, path, url, false, false, desc);
            }
            else if (chkBtcClicks.Checked)
            {
                lstStatus2.Text += System.Environment.NewLine + "Openning Btcclicks.com..." + System.Environment.NewLine;
                url = "http://btcclicks.com/ads";
                desc = "Open Btcclicks.com by Brave";
                Handler.StartProcess(OperationType.STARTMANUAL, path, url, false, false, desc);
            }
            else if(chkBtcVic.Checked)
            {
                lstStatus2.Text += System.Environment.NewLine + "Openning Btcvic.com..." + System.Environment.NewLine;
                url = "http://btcvic.com/ads";
                desc = "Open Btcvic.com by Brave";
                Handler.StartProcess(OperationType.STARTMANUAL, path, url, false, false, desc);
            }
            else if (chkAdbtc.Checked)
            {
                lstStatus2.Text += System.Environment.NewLine + "Openning Adbtc.top..." + System.Environment.NewLine;
                url = "http://adbtc.top/";
                desc = "Open Adbtc.top by Brave";
                Handler.StartProcess(OperationType.STARTMANUAL, path, url, false, false, desc);
            }
            else if (chkHashingadSpace.Checked)
            {
                lstStatus2.Text += System.Environment.NewLine + "Openning Hashingadspace.com..." + System.Environment.NewLine;
                url = "https://www.hashingadspace.com/dashboard.php";
                desc = "Open Hashingadspace.com by Yandex";
                Handler.StartProcess(OperationType.STARTMANUAL, path, url, false, false, desc);
            }
            Application.DoEvents();
        }
        private void StopManual()
        {
            KillProcesses(false, true);
            manualStopped = true;
            isRunningManual = false;
            EnableControls(true, false);
            btnStartManual.Text = "START";
            if (chkReminder.Checked) Task.Factory.StartNew(() => ReminderManualTasks());            
        }
        private void ReminderManualTasks()
        {            
            Handler.Log("//======================WAIT FOR NEXT RUN======================//");
            Handler.Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
            Handler.Log("Wait 1 hour for next running of manual tasks");
            lstStatus2.Text += System.Environment.NewLine + "//======================WAIT FOR NEXT RUN======================//" + System.Environment.NewLine;
            lstStatus2.Text += System.Environment.NewLine + "Wait 1 hour for next running of manual tasks" + System.Environment.NewLine;
            Application.DoEvents();
            var counterManualTaskTimer = 0;
            do
            {
                if (!chkFreeBitco.Checked && !chkFreeLitecoin.Checked && !chkBitpick.Checked &&
                    !chkBither.Checked && !chkBtcClicks.Checked && !chkBtcVic.Checked &&
                    !chkAdbtc.Checked && !chkHashingadSpace.Checked)
                {
                    //toolStripStatus2.Text = "Ready!";
                    return;
                }
                counterManualTaskTimer++;
                Thread.Sleep(1000 * 60);
            } while (counterManualTaskTimer <= 61);
            MessageBox.Show("It's time to run task!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //toolStripStatus2.Text = "Ready!";
            SetWindowsState(MyWindowState.NORMAL);
            tabManualTasks.Select();
            tabManualTasks.Focus();
        }
        private void btnCreateProfilesManual_Click(object sender, EventArgs e)
        {
            taskType = TaskType.Manual;
            btnCreateProfiles.Enabled = false;
            Task.Factory.StartNew(() => CreateProfiles());
        }
        private void btnCreateAccountsManual_Click(object sender, EventArgs e)
        {
            taskType = TaskType.Manual;
            btnCreateAccounts.Enabled = false;
            Task.Factory.StartNew(() => CreateAccounts());
        }
        #endregion

        #region Autorun Tasks
        private void chkTimebucks_CheckedChanged(object sender, EventArgs e)
        {
            if (frmCreateAccounts.accountType == frmCreateAccounts.AccountType.Timebucks && chkTimebucks.Checked)
            {
                btnStartTasks.Enabled = false;
                MessageBox.Show("You can't run Timebucks when creating accounts." + System.Environment.NewLine + "Please stop or wait until finishing creating accounts !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Properties.Settings.Default.isTimebucksTask = chkTimebucks.Checked;
            Properties.Settings.Default.Save();
            changed = true;
            EnableControls(false, true);            
        }
        private void chkPresearch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isPresearchTask = chkPresearch.Checked;
            Properties.Settings.Default.Save();
            changed = true;
            EnableControls(false, true);
        }
        private void chkFreeBitcoin_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isFreebitcoinTask = chkFreeBitcoin.Checked;
            Properties.Settings.Default.Save();
            changed = true;
            EnableControls(false, true); 
        }        
        private void chkIndexBitco_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isIndexbitcoTask = chkIndexBitco.Checked;
            Properties.Settings.Default.Save();
            changed = true;
            EnableControls(false, true);
        }
        private void chkPaidviewpoint_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isPaidviewpointTask = chkPaidviewpoint.Checked;
            Properties.Settings.Default.Save();
            changed = true;
            EnableControls(false, true);
        }
        private void chkAutoFreebitco_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoFreebitcoTask = chkAutoFreebitco.Checked;
            Properties.Settings.Default.Save();
            changed = true;
            if (chkAutoFreebitco.Checked) chkFreeBitco.Enabled = chkFreeBitco.Checked = false;
            else chkFreeBitco.Enabled = true;
            EnableControls(false, true);         
        }
        private void chkTimebucks_Click(object sender, EventArgs e)
        {
            if (btnStartTasks.Text == "STOP")
            {
                if (!chkTimebucks.Checked)
                {
                    isRunningAuto = true;
                    Task.Factory.StartNew(() => Handler.StopProcess(OperationType.STARTAUTO, FIREFOX, false, false));
                    Handler.DeleteFiles(true, startIndex, endIndex, chkPresearch.Checked, chkTimebucks.Checked);
                }
                else isRunningAuto = false;
            }            
        }
        private void chkPresearch_Click(object sender, EventArgs e)
        {
            if (!chkPresearch.Checked && btnStartTasks.Text == "STOP")
            {
                Task.Factory.StartNew(() => Handler.StopProcess(OperationType.STARTAUTO, FIREFOX, false, false));
                Handler.DeleteFiles(true, startIndex, endIndex, chkPresearch.Checked, chkTimebucks.Checked);
            }
        }
        private void chkPaidviewpoint_Click(object sender, EventArgs e)
        {
            if (!chkPaidviewpoint.Checked && btnStartTasks.Text == "STOP")
            { 
                Task.Factory.StartNew(() => Handler.StopProcess(OperationType.STARTAUTO, FIREFOX, false, false));
                //Handler.DeleteFiles(true, startIndex, endIndex, chkPresearch.Checked, chkTimebucks.Checked);
            }
        }
        private void chkIndexBitco_Click(object sender, EventArgs e)
        {
            if (!chkIndexBitco.Checked && btnStartTasks.Text == "STOP")
            {
                Task.Factory.StartNew(() => Handler.StopProcess(OperationType.STARTAUTO, FIREFOX, false, false));
                //Handler.DeleteFiles(true, startIndex, endIndex, chkPresearch.Checked, chkTimebucks.Checked);
            }
        }
        private void chkFreeBitcoin_Click(object sender, EventArgs e)
        {
            if(btnStartTasks.Text == "STOP")
            {
                if (!chkFreeBitcoin.Checked)
                {
                    isRunningFreebitcoin = true;
                    Task.Factory.StartNew(() => Handler.StopProcess(OperationType.STARTAUTO, MICROSOFTEDGE, false, false));
                    Task.Factory.StartNew(() => Handler.StopProcess(OperationType.STARTAUTO, COCCOC, false, false));
                }
                else isRunningFreebitcoin = false;
            }
        }
        private void chkAutoFreebitco_Click(object sender, EventArgs e)
        {
            if (btnStartTasks.Text == "STOP")
            {
                if (!chkAutoFreebitco.Checked)
                {
                    isRunningFreebitco = true;
                    chkFreeBitco.Enabled = true;
                    Task.Factory.StartNew(() => Handler.StopProcess(OperationType.STARTAUTO, CHROME, false, false));
                }
                else isRunningFreebitco = false;
            }
        }
        #endregion

        #region Manual Tasks
        private void chkFreeBitco_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFreeBitco.Checked) chkAutoFreebitco.Enabled = chkAutoFreebitco.Checked = false;
            else chkAutoFreebitco.Enabled = true;
            EnableControls(false, false);
        }
        private void chkBtcClicks_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(false, false);
        }
        private void chkBtcVic_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(false, false);
        }
        private void chkBither_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(false, false);
        }
        private void chkHashingadSpace_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(false, false);
        }
        private void chkFreeLitecoin_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(false, false);
        }        
        private void chkBitpick_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(false, false);
        }
        private void chkAdbtc_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(false, false);            
        }
        #endregion

        #region Settings
        private void chkIsRunProfilesInstalled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsRunProfilesInstalled.Checked)
            {
                var totalProfiles = Properties.Settings.Default.NumOfProfilesInstalled;
                if (totalProfiles == 0)
                {
                    MessageBox.Show("There're no profiles created!" + Environment.NewLine + "Please create profiles and check again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkIsRunProfilesInstalled.Checked = false;
                    return;
                }
                txtTotalProfiles.Text = totalProfiles.ToString();
                txtTotalProfiles.Enabled = false;
            }
            else
            {
                txtTotalProfiles.Enabled = true;
                txtTotalProfiles.Text = numOfProfiles.ToString();
            }
            Properties.Settings.Default.IsRunProfilesInstalled = chkIsRunProfilesInstalled.Checked;
            Properties.Settings.Default.Save();
            changed = true;
        }
        private void chkIsAutoRunServices_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsAutoRunServices = chkIsAutoRunServices.Checked;
            Properties.Settings.Default.Save();
            changed = true;
        }
        private void txtProfilesEveryRunning_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) return;
            if (!string.IsNullOrEmpty(txtProfilesEveryRunning.Text.Trim()))
            {
                Properties.Settings.Default.NumProfilesEveryRunning = int.Parse(txtProfilesEveryRunning.Text.Trim());
                Properties.Settings.Default.Save();
                changed = true;
            }
        }
        private void txtFromProfile_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) return;
            if (!string.IsNullOrEmpty(txtFromProfile.Text.Trim()))
            {
                if (int.Parse(txtFromProfile.Text.Trim()) > Properties.Settings.Default.NumOfProfilesInstalled)
                {
                    MessageBox.Show("From profile cannot larger than number of profiles installed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFromProfile.Text = numOfProfiles.ToString();
                }
                Properties.Settings.Default.FromProfile = startIndex = int.Parse(txtFromProfile.Text.Trim());
                Properties.Settings.Default.Save();
                changed = true;
            }
        }
        private void txtTotalProfiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) return;
            if (!string.IsNullOrEmpty(txtTotalProfiles.Text.Trim()))
            {
                if (int.Parse(txtTotalProfiles.Text.Trim()) > Properties.Settings.Default.NumOfProfilesInstalled)
                {
                    MessageBox.Show("Total profiles cannot larger than number of profiles installed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotalProfiles.Text = numOfProfiles.ToString();
                }
                Properties.Settings.Default.TotalProfiles = numOfProfiles = int.Parse(txtTotalProfiles.Text.Trim());
                Properties.Settings.Default.Save();
                changed = true;
            }
        }
        #endregion

        #region Other Methods
        public static string GetAppPath(BrowserType type)
        {
            var path = "";
            switch (type)
            {
                case BrowserType.Firefox:
                    path = (File.Exists(firefoxPath1) ? firefoxPath1 : (File.Exists(firefoxPath2) ? firefoxPath2 : ""));
                    break;
                case BrowserType.MsEdge:
                    path = (File.Exists(msEdgePath) ? msEdgePath : "");
                    break;
                case BrowserType.CocCoc:
                    path = (File.Exists(cococPath) ? cococPath : "");
                    break;
                case BrowserType.Yandex:
                    path = (File.Exists(yandexPath) ? yandexPath : "");
                    break;
                case BrowserType.Chrome:
                    path = (File.Exists(chromePath) ? chromePath : "");
                    break;
                case BrowserType.Brave:
                    path = (File.Exists(bravePath) ? bravePath : "");
                    break;
            }           
            return path;
        }        
        private void SetWindowsState(MyWindowState windowsState)
        {
            if (windowsState == MyWindowState.MINIMIZED)
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                AnimateWindow(this.Handle, 700, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_ACTIVATE);
                this.Activate();
            }
        }
        private void EnableControls(bool isEnabled, bool isAuto)
        {
            var countCheck = 0;
            CheckBox temp = new CheckBox();
            if (isAuto)
            {
                if (btnStartTasks.Text == "START") return;
                foreach (Control ctr in groupAutoTasks.Controls)
                {
                    CheckBox chk = (CheckBox)ctr;
                    if (chk.Checked)
                    {
                        countCheck++;
                        temp = chk;
                    } 
                }
                if (countCheck == 1) temp.Enabled = isEnabled;
                else if (countCheck > 1)
                {
                    foreach (Control ctr in groupAutoTasks.Controls)
                    {
                        CheckBox chk = (CheckBox)ctr;
                        if (!chk.Checked) continue;
                        chk.Enabled = true;
                    }
                } 
                //foreach (Control ctr in groupSettings.Controls)
                //{
                //if (ctr is TextBox || ctr is CheckBox) ctr.Enabled = isEnabled;
                //}
            }
            else
            {
                if (btnStartManual.Text == "START") return;
                //btnCreateProfilesManual.Enabled = btnCreateAccountsManual.Enabled = isEnabled;                
                foreach (Control ctr in groupProxyTasks.Controls)
                {
                    CheckBox chk = (CheckBox)ctr;
                    if (chk.Checked)
                    {
                        countCheck++;
                        temp = chk;
                    }
                    //ctr.Enabled = isEnabled;                    
                }
                if (countCheck == 1) temp.Enabled = isEnabled;
                else if (countCheck > 1)
                {
                    foreach (Control ctr in groupAutoTasks.Controls)
                    {
                        CheckBox chk = (CheckBox)ctr;
                        if (!chk.Checked) continue;
                        chk.Enabled = true;
                    }
                }                
                //foreach (Control ctr in groupNoProxyTasks.Controls) ctr.Enabled = isEnabled;
            }
        }
        private void GetSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                var settings = Handler.GetInfo(settingsFilePath);
                if (settings.Split(';').Length == 27)
                {                    
                    Properties.Settings.Default.isTimebucksTask = chkTimebucks.Checked = bool.Parse(settings.Split(';')[0].Split(':')[1].Trim());
                    Properties.Settings.Default.isPresearchTask = chkPresearch.Checked = bool.Parse(settings.Split(';')[1].Split(':')[1].Trim());
                    Properties.Settings.Default.isPaidviewpointTask = chkPaidviewpoint.Checked = bool.Parse(settings.Split(';')[2].Split(':')[1].Trim());
                    Properties.Settings.Default.isIndexbitcoTask = chkIndexBitco.Checked = bool.Parse(settings.Split(';')[3].Split(':')[1].Trim());
                    Properties.Settings.Default.isFreebitcoinTask = chkFreeBitcoin.Checked = bool.Parse(settings.Split(';')[4].Split(':')[1].Trim());
                    Properties.Settings.Default.isAutoFreebitcoTask = chkAutoFreebitco.Checked = bool.Parse(settings.Split(';')[5].Split(':')[1].Trim());

                    txtProfilesEveryRunning.Text = settings.Split(';')[6].Split(':')[1].ToString();
                    Properties.Settings.Default.NumProfilesEveryRunning = int.Parse(settings.Split(';')[6].Split(':')[1]);
                    Properties.Settings.Default.FromProfile = startIndex = int.Parse(settings.Split(';')[7].Split(':')[1]);
                    txtFromProfile.Text = settings.Split(';')[7].Split(':')[1].ToString();
                    txtTotalProfiles.Text = settings.Split(';')[8].Split(':')[1].ToString();                    
                    Properties.Settings.Default.TotalProfiles = numOfProfiles = int.Parse(settings.Split(';')[8].Split(':')[1]);
                    Properties.Settings.Default.IsRunProfilesInstalled = chkIsRunProfilesInstalled.Checked = bool.Parse(settings.Split(';')[9].Split(':')[1].Trim());
                    Properties.Settings.Default.IsAutoRunServices = chkIsAutoRunServices.Checked = bool.Parse(settings.Split(';')[10].Split(':')[1].Trim());

                    Properties.Settings.Default.TotalProfilesTimebucks = numOfProfilesTimebucks = int.Parse(settings.Split(';')[11].Split(':')[1]);
                    Properties.Settings.Default.TotalProfilesPresearch = numOfProfilesPresearch = int.Parse(settings.Split(';')[12].Split(':')[1]);
                    Properties.Settings.Default.TotalProfilesPaidviewpoint = numOfProfilesPaidviewpoint = int.Parse(settings.Split(';')[13].Split(':')[1]);
                    Properties.Settings.Default.TotalProfilesIndexbitco = numOfProfilesIndexbitco = int.Parse(settings.Split(';')[14].Split(':')[1]);
                    Properties.Settings.Default.TotalProfilesFreebitcoin = numOfProfilesFreebitcoin = int.Parse(settings.Split(';')[15].Split(':')[1]);
                    Properties.Settings.Default.TotalProfilesAdbtc = numOfProfilesAdbtc = int.Parse(settings.Split(';')[16].Split(':')[1]);

                    Properties.Settings.Default.TotalProfilesAuto = numOfProfilesAuto = int.Parse(settings.Split(';')[17].Split(':')[1]);
                    Properties.Settings.Default.TotalProfilesAutoProxy = numOfProfilesAutoProxy = int.Parse(settings.Split(';')[18].Split(':')[1]);
                    Properties.Settings.Default.TotalProfilesManual = numOfProfilesManual = int.Parse(settings.Split(';')[19].Split(':')[1]);
                    Properties.Settings.Default.TotalProfilesManualProxy = numOfProfilesManualProxy = int.Parse(settings.Split(';')[20].Split(':')[1]);

                    if (!string.IsNullOrEmpty(settings.Split(';')[21].Split(':')[1])) Properties.Settings.Default.Link_Timebucks = settings.Split(';')[21].Split(':')[1];
                    if (!string.IsNullOrEmpty(settings.Split(';')[22].Split(':')[1])) Properties.Settings.Default.Link_Presearch = settings.Split(';')[22].Split(':')[1];
                    if (!string.IsNullOrEmpty(settings.Split(';')[23].Split(':')[1])) Properties.Settings.Default.Link_Paidviewpoint = settings.Split(';')[23].Split(':')[1];
                    if (!string.IsNullOrEmpty(settings.Split(';')[24].Split(':')[1])) Properties.Settings.Default.Link_Indexbitco = settings.Split(';')[24].Split(':')[1];
                    if (!string.IsNullOrEmpty(settings.Split(';')[25].Split(':')[1])) Properties.Settings.Default.Link_Freebitcoin = settings.Split(';')[25].Split(':')[1];
                    if (!string.IsNullOrEmpty(settings.Split(';')[26].Split(':')[1])) Properties.Settings.Default.Link_Adbtc= settings.Split(';')[26].Split(':')[1];
                }                
                else GetInfoFromSettings();  
            }
            else GetInfoFromSettings();
            Properties.Settings.Default.NumOfProfilesInstalled = Handler.GetNumOfProfilesInstalled();
            Properties.Settings.Default.Save();            
        }
        private void UpdateSettings()
        {
            var info = new StringBuilder();
            info.AppendLine("istimebuckstask:" + chkTimebucks.Checked);
            info.AppendLine("ispresearchtask:" + chkPresearch.Checked);
            info.AppendLine("ispaidviewpointtask:" + chkPaidviewpoint.Checked);
            info.AppendLine("isindexbitcotask:" + chkIndexBitco.Checked);
            info.AppendLine("isfreebitcointask:" + chkFreeBitcoin.Checked);
            info.AppendLine("isautofreebitcotask:" + chkAutoFreebitco.Checked);

            info.AppendLine("numofprofileseveryrunning:" + txtProfilesEveryRunning.Text.Trim());
            info.AppendLine("fromprofileindex:" + txtFromProfile.Text.Trim());
            info.AppendLine("totalprofilesrunning:" + txtTotalProfiles.Text.Trim());
            info.AppendLine("isrunprofilesinstalled:" + chkIsRunProfilesInstalled.Checked);
            info.AppendLine("isautorunservices:" + chkIsAutoRunServices.Checked);

            info.AppendLine("totalprofilestimebucks:" + Properties.Settings.Default.TotalProfilesTimebucks);
            info.AppendLine("totalprofilespresearch:" + Properties.Settings.Default.TotalProfilesPresearch);
            info.AppendLine("totalprofilespaidviewpoint:" + Properties.Settings.Default.TotalProfiles);
            info.AppendLine("totalprofilesindexbitco:" + Properties.Settings.Default.TotalProfilesTimebucks);
            info.AppendLine("totalprofilesfreebitcoin:" + Properties.Settings.Default.TotalProfilesPresearch);
            info.AppendLine("totalprofilesadbtc:" + Properties.Settings.Default.TotalProfiles);

            info.AppendLine("totalprofilesauto:" + Properties.Settings.Default.TotalProfilesAuto);
            info.AppendLine("totalprofilesautoproxy:" + Properties.Settings.Default.TotalProfilesAutoProxy);
            info.AppendLine("totalprofilesmanual:" + Properties.Settings.Default.TotalProfilesManual);
            info.AppendLine("totalprofilesmanualproxy:" + Properties.Settings.Default.TotalProfilesManualProxy);

            info.AppendLine("linktimebucks:" + Properties.Settings.Default.Link_Timebucks);
            info.AppendLine("linkpresearch:" + Properties.Settings.Default.Link_Presearch);
            info.AppendLine("linkpaidviewpoint:" + Properties.Settings.Default.Link_Paidviewpoint);
            info.AppendLine("linkindexbitco:" + Properties.Settings.Default.Link_Indexbitco);
            info.AppendLine("linkfreebitcoin:" + Properties.Settings.Default.Link_Paidviewpoint);
            info.AppendLine("linkadbtc:" + Properties.Settings.Default.Link_Indexbitco);
            Handler.UpdateInfo(settingsFilePath, info.ToString());
            //File.WriteAllText(settingsFilePath, info.ToString());
        }
        private void GetInfoFromSettings()
        {
            chkTimebucks.Checked = Properties.Settings.Default.isTimebucksTask;
            chkPresearch.Checked = Properties.Settings.Default.isPresearchTask;
            chkPaidviewpoint.Checked = Properties.Settings.Default.isPaidviewpointTask;
            chkIndexBitco.Checked = Properties.Settings.Default.isIndexbitcoTask;
            chkFreeBitco.Checked = Properties.Settings.Default.isFreebitcoinTask;
            chkAutoFreebitco.Checked = Properties.Settings.Default.isAutoFreebitcoTask;

            txtProfilesEveryRunning.Text = Properties.Settings.Default.NumProfilesEveryRunning.ToString();
            txtFromProfile.Text = Properties.Settings.Default.FromProfile.ToString();
            txtTotalProfiles.Text = Properties.Settings.Default.TotalProfiles.ToString();
            chkIsRunProfilesInstalled.Checked = Properties.Settings.Default.IsRunProfilesInstalled;
            chkIsAutoRunServices.Checked = Properties.Settings.Default.IsAutoRunServices;

            startIndex = Properties.Settings.Default.FromProfile;
            numOfProfiles = Properties.Settings.Default.TotalProfiles;
            numOfProfilesTimebucks = Properties.Settings.Default.TotalProfilesTimebucks;
            numOfProfilesPresearch = Properties.Settings.Default.TotalProfilesPresearch;
            numOfProfilesPaidviewpoint = Properties.Settings.Default.TotalProfilesPaidviewpoint;
            numOfProfilesIndexbitco = Properties.Settings.Default.TotalProfilesIndexbitco;
            numOfProfilesFreebitcoin = Properties.Settings.Default.TotalProfilesFreebitcoin;
            numOfProfilesAdbtc = Properties.Settings.Default.TotalProfilesAdbtc;
            numOfProfilesAuto = Properties.Settings.Default.TotalProfilesAuto;
            numOfProfilesAutoProxy = Properties.Settings.Default.TotalProfilesAutoProxy;
            numOfProfilesManual = Properties.Settings.Default.TotalProfilesManual;
            numOfProfilesManualProxy = Properties.Settings.Default.TotalProfilesManualProxy;
        }
        private void KillProcesses(bool isAuto, bool isUsedBatFile)
        {   
            if (isUsedBatFile)
            {
                var path = string.Format(killProcessPath, BRAVE);
                if (File.Exists(path) && !isAuto) Handler.StopProcessByBatFile(path, OperationType.STARTMANUAL, BRAVE);
                if (isAuto)
                {
                    path = string.Format(killProcessPath, COCCOC);
                    if (File.Exists(path)) Handler.StopProcessByBatFile(path, OperationType.STARTAUTO, COCCOC);
                    path = string.Format(killProcessPath, CHROME);
                    if (File.Exists(path)) Handler.StopProcessByBatFile(path, OperationType.STARTAUTO, CHROME);
                }                
            }
            else Handler.StopProcess(OperationType.STARTAUTO, FIREFOX, true, true);            
            if (isAuto) Handler.DeleteFiles(true, startIndex, endIndex, chkPresearch.Checked, chkTimebucks.Checked);
        }
        #endregion        
    }
}