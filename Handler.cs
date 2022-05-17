using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace MyTool
{
    public static class Handler
    {
        // Check if Internet is connected?
        public static bool NetworkIsAvailable()
        {
            var all = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var item in all)
            {
                if (item.NetworkInterfaceType == NetworkInterfaceType.Loopback || item.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                    continue;
                if (item.OperationalStatus == OperationalStatus.Up)
                {
                    return true;
                }
            }
            return false;
        }

        // Start/stop specific process
        public static void StartProcess(frmAutoClicker.OperationType taskType, string appPath, string profile, bool isShowWindow, bool isSaveProcessed, string description)
        {
            switch (taskType)
            {
                case frmAutoClicker.OperationType.STARTAUTO:
                    Log("//========================RUN AUTO TASKS=======================//");
                    break;
                case frmAutoClicker.OperationType.STARTMANUAL:
                    Log("//=======================RUN MANUAL TASKS======================//");
                    break;
                case frmAutoClicker.OperationType.CreateProfiles:
                    Log("//=======================CREATE PROFILES=======================//");
                    break;
                case frmAutoClicker.OperationType.CreateAccounts:
                    Log("//=======================CREATE ACCOUNTS=======================//");
                    break;
            }           
            Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
            if(!string.IsNullOrEmpty(description)) Log(description);
            var process = new Process();
            if (isShowWindow) process.StartInfo = new ProcessStartInfo(appPath, profile);
            else
            {
                process.StartInfo = new ProcessStartInfo(appPath, profile)
                {
                    UseShellExecute = false,   // CreateNoWindow only works, if shell is not used
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
            }        
            process.Start();
            if(isSaveProcessed) SaveProcessIds(taskType, process.Id, process.ProcessName);
        }
        public static void SaveProcessIds(frmAutoClicker.OperationType taskType, int id, string processName)
        {            
            var c = ";";
            var ids = "";
            switch (taskType)
            {
                case frmAutoClicker.OperationType.STARTAUTO:
                    ids = Properties.Settings.Default.AutoProcesses;
                    if (!string.IsNullOrEmpty(ids)) Properties.Settings.Default.AutoProcesses = ids + c + id;
                    else Properties.Settings.Default.AutoProcesses = id.ToString();
                    break;
                case frmAutoClicker.OperationType.STARTMANUAL:
                    ids = Properties.Settings.Default.ManualProcesses;
                    if (!string.IsNullOrEmpty(ids)) Properties.Settings.Default.ManualProcesses = ids + c + id;
                    else Properties.Settings.Default.ManualProcesses = id.ToString();
                    break;
                case frmAutoClicker.OperationType.CreateProfiles:
                    ids = Properties.Settings.Default.CreateProfilesProcesses;
                    if (!string.IsNullOrEmpty(ids)) Properties.Settings.Default.CreateProfilesProcesses = ids + c + id;
                    else Properties.Settings.Default.CreateProfilesProcesses = id.ToString();
                    break;
                case frmAutoClicker.OperationType.CreateAccounts:
                    ids = Properties.Settings.Default.CreateAccountsProcesses;
                    if (!string.IsNullOrEmpty(ids)) Properties.Settings.Default.CreateAccountsProcesses = ids + c + id;
                    else Properties.Settings.Default.CreateAccountsProcesses = id.ToString();
                    break;
            }            
            Properties.Settings.Default.Save();            
            var tw = new StreamWriter(frmAutoClicker.processIdsFilePath,true);
            if(ids != "") tw.WriteLine(ids+c+id);
            tw.WriteLine(processName+':'+id);
            tw.Close();
        }
        public static void DeleteProcessIds()
        {
            if (File.Exists(frmAutoClicker.processIdsFilePath)) File.Delete(frmAutoClicker.processIdsFilePath);
        }
        public static List<int> GetProcessIds()
        {
            var listProcessIds = new List<int>();
            try
            {
                var processIds = File.ReadLines(frmAutoClicker.processIdsFilePath);
                foreach (var id in processIds)
                {
                    if (string.IsNullOrEmpty(id)) continue;
                    listProcessIds.Add(int.Parse(id));
                }
                return listProcessIds;
            }
            catch (Exception)
            {
                return listProcessIds;
            }
        }
        public static void StopProcess(frmAutoClicker.OperationType taskType, string browserName, bool isDeleted, bool isStopped)
        {
            try
            {
                var processIds = Properties.Settings.Default.AutoProcesses.Split(';');
                switch (taskType)
                {
                    case frmAutoClicker.OperationType.STARTAUTO:
                        if(isStopped) Properties.Settings.Default.AutoProcesses = string.Empty;
                        break;
                    case frmAutoClicker.OperationType.STARTMANUAL:
                        processIds = Properties.Settings.Default.ManualProcesses.Split(';');
                        if (isStopped) Properties.Settings.Default.ManualProcesses = string.Empty;
                        break;
                    case frmAutoClicker.OperationType.CreateProfiles:
                        processIds = Properties.Settings.Default.CreateProfilesProcesses.Split(';');
                        if (isStopped) Properties.Settings.Default.CreateProfilesProcesses = string.Empty;
                        break;
                    case frmAutoClicker.OperationType.CreateAccounts:
                        processIds = Properties.Settings.Default.CreateAccountsProcesses.Split(';');
                        if (isStopped) Properties.Settings.Default.CreateAccountsProcesses = string.Empty;
                        break;
                }
                Properties.Settings.Default.Save();
                foreach (var id in processIds)
                {
                    if (string.IsNullOrEmpty(id)) continue;
                    var pId = 0;
                    int.TryParse(id, out pId);
                    if (pId == 0) continue;
                    var process = new Process();
                    if (!string.IsNullOrEmpty(browserName)) process = Process.GetProcesses().Where(p => p.Id == pId && p.ProcessName == browserName).FirstOrDefault();
                    else process = Process.GetProcessesByName(browserName).Where(p => p.Id == pId).FirstOrDefault();
                    if (process == null || process.HasExited) continue;                    
                    process.Kill();
                    switch (taskType)
                    {
                        case frmAutoClicker.OperationType.STARTAUTO:
                            Log("//=====================KILL AUTO PROCESSES=====================//");
                            break;
                        case frmAutoClicker.OperationType.STARTMANUAL:
                            Log("//====================KILL MANUAL PROCESSES====================//");
                            break;
                        case frmAutoClicker.OperationType.CreateProfiles:
                            Log("//========================KILL PROCESSES=======================//");
                            break;
                        case frmAutoClicker.OperationType.CreateAccounts:
                            Log("//========================KILL PROCESSES=======================//");
                            break;
                    }
                    Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                    Log("Kill process name: " + process.ProcessName);
                    Log("Kill process id: " + pId);
                }
                if (isDeleted && File.Exists(frmAutoClicker.processIdsFilePath)) File.Delete(frmAutoClicker.processIdsFilePath);
            }
            catch (Exception ex)
            {
                Log("//====================ERROR KILL PROCESSES=====================//");
                Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                Log("There's error when stopping processes!" + Environment.NewLine + ex.Message);
                Log("Stack trace:" + Environment.NewLine + ex.StackTrace);
            }            
        }
        public static void StopProcessByBatFile(string appPath, frmAutoClicker.OperationType taskType, string browser)
        {            
            var pro = Process.GetProcessesByName(browser == "yandex" ? "browser" : browser).FirstOrDefault();
            if (pro == null || pro.HasExited) return;
            if (!File.Exists(appPath)) return;
            switch (browser)
            {
                case "chrome":
                    browser = "Google Chrome";
                    break;
                case "brave":
                    browser = browser.ToUpperInvariant();
                    break;
                case "msedge":
                    browser = "Miscrosoft Edge";
                    break;
                case "browser":
                    browser = "Coc Coc";
                    break;
                case "yandex":
                    browser = browser.ToUpperInvariant();
                    break;
            }
            switch (taskType)
            {
                case frmAutoClicker.OperationType.STARTAUTO:
                    Log("//=====================KILL AUTO PROCESSES=====================//");
                    break;
                case frmAutoClicker.OperationType.STARTMANUAL:
                    Log("//====================KILL MANUAL PROCESSES====================//");                    
                    break;
                case frmAutoClicker.OperationType.CreateProfiles:
                case frmAutoClicker.OperationType.CreateAccounts:
                    Log("//=======================KILL PROCESSES========================//");
                    break;
            }
            Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
            Log("Kill processes of " + browser);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo(appPath, "")
                {
                    UseShellExecute = false,   // CreateNoWindow only works, if shell is not used
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            process.Start();
            process.WaitForExit(1000*10);
        }

        // Check if a file in use
        public static bool IsFileLocked(string file)
        {
            try
            {
                using (var stream = File.OpenRead(file))
                    return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        // Save log of operations
        public static void Log(string operation)
        {
            if (IsFileLocked(frmAutoClicker.logFilePath))
                System.Threading.Thread.Sleep(1000 * 3);
            var tw = new StreamWriter(frmAutoClicker.logFilePath, true);
            tw.WriteLine(operation);
            tw.Close();            
        }

        // Set/Get positions of steps
        public static void SetPositions(string positions)
        {
            var tw = new StreamWriter(frmAutoClicker.positionsFilePath, true);
            tw.WriteLine(positions);
            tw.Close();
        }
        public static List<Point> GetPositions()
        {
            var listPositions = new List<Point>();
            try
            {
                var lines = File.ReadLines(frmAutoClicker.positionsFilePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrEmpty(line)) continue;
                    var step = line.Replace("point: ", "").Replace("x: ", "").Replace("y: ", "").Trim();
                    var p = new Point(int.Parse(step.Split(';')[0]), int.Parse(step.Split(';')[1]));
                    listPositions.Add(p);
                }
                return listPositions;
            }
            catch (Exception)
            {
                return listPositions;
            }
        }
        public static void ClearPositions()
        {
            if (File.Exists(frmAutoClicker.positionsFilePath)) File.Delete(frmAutoClicker.positionsFilePath);
        }

        // Get number of profiles
        public static int GetNumOfProfilesInstalled()
        {
            try
            {
                var countProfilesInstalled = Directory.GetDirectories(frmCreateProfiles.profilesFolderPath, "*.User*", SearchOption.TopDirectoryOnly).Length;
                Properties.Settings.Default.NumOfProfilesInstalled = countProfilesInstalled;
                Properties.Settings.Default.Save();
                return countProfilesInstalled;
            }
            catch (Exception ex)
            {
                Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                Log("There's error when getting profiles installed!" + System.Environment.NewLine + ex.StackTrace);
                return 0;
            }
        }
        public static int GetNumOfProfiles()
        {
            var numOfProfile = 0;
            try
            {
                var objNumOfProfile = "19";//File.ReadAllText(frmAutoClicker.numOfProfilesAdsFilePath);
                int.TryParse(objNumOfProfile.Trim(), out numOfProfile);
                Properties.Settings.Default.TotalProfilesTimebucks = numOfProfile;
                Properties.Settings.Default.Save();
                //File.WriteAllText(frmAutoClicker.numOfProfilesAdsFilePath, numOfProfile.ToString());
            }
            catch (Exception)
            {
                return Properties.Settings.Default.TotalProfilesTimebucks;
            }            
            return numOfProfile;            
        }

        // Create bat file to run firefox profiles
        public static void CreateBatFile(string actions, string fileName)
        {
            var tw = new StreamWriter(fileName, true);
            tw.WriteLine(actions);
            tw.Close();
        }
        
        // Get ref info from file
        public static string GetInfo(string path)
        {
            var info = "";
            try
            {
                var lines = File.ReadLines(path);
                foreach (var line in lines)
                {
                    if (string.IsNullOrEmpty(line)) continue;
                    if (string.IsNullOrEmpty(info)) info = line.Replace("\"", "");
                    else info += ";" +line.Replace("\"", "");
                }
                return info;
            }
            catch (Exception ex)
            {
                Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                Log("There's error when getting info!" + System.Environment.NewLine + ex.StackTrace);
                return info;
            }            
        }
        public static void UpdateInfo(string path, string info)
        {
            try
            {
                // Write data into file
                File.WriteAllText(path, info);                
            }
            catch (Exception ex)
            {
                Log("-----------------------" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "-----------------------");
                Log("There's error when updating info!" + System.Environment.NewLine + ex.StackTrace);
            }
        }

        // Delete data/info file
        public static void DeleteFiles(bool isData, int startIndex, int endIndex, bool isSearchServices, bool isAds)
        {
            var adsFilePath = "";
            var searchservicesFilePath = "";
            var adsRegisterFilePath = "";
            var searchservicesRegisterFilePath = "";
            if (!isData)
            {
                endIndex = startIndex - 4;
                startIndex = 1;
            }
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (isData)
                {
                    adsFilePath = string.Format(frmAutoClicker.timebucksDataFilePath, i);
                    searchservicesFilePath = string.Format(frmAutoClicker.searchservicesDataFilePath, i);
                }
                else
                {                    
                    adsRegisterFilePath = string.Format(frmCreateAccounts.registerFilePath, "ads", i);
                    searchservicesRegisterFilePath = string.Format(frmCreateAccounts.registerFilePath, "searchservices", i);
                }
                if (isSearchServices && isAds)
                {
                    if (File.Exists(adsFilePath)) File.Delete(adsFilePath);
                    if (File.Exists(searchservicesFilePath)) File.Delete(searchservicesFilePath);                    
                }
                else if (isAds)
                {
                    if (File.Exists(adsFilePath)) File.Delete(adsFilePath);
                }
                else if (isSearchServices)
                {
                    if (File.Exists(searchservicesFilePath)) File.Delete(searchservicesFilePath);
                }
                if (File.Exists(adsRegisterFilePath)) File.Delete(adsRegisterFilePath);
                if (File.Exists(searchservicesRegisterFilePath)) File.Delete(searchservicesRegisterFilePath);
            }
        }
    }
}
