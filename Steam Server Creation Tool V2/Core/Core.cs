using System;
using System.Net;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    internal class Core
    {
        public static bool debug = false;

        public static string softwareName = "Steam Server Creation Tool";
        public static string softwareNameShort = "SSCT";

        public static string authorRealName = "Victor";
        public static string authorName = "N0tiC";
        public static string authorContact = "contact@bytevaultstudio.se";

        public static string projectURL = "https://github.com/n0tic/SteamServerCreationTool";
        public static string reposURL = "https://api.github.com/repos/n0tic/SteamServerCreationTool/releases";

        public static string steamCMDURL = "https://developer.valvesoftware.com/wiki/SteamCMD#Downloading_SteamCMD";
        public static string steamCMDURL_Download = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";
        public static string serversURL = "https://api.steampowered.com/ISteamApps/GetAppList/v2?utc=" + Core.GetUTCTime();

        #region Version

        public static BuildTypes buildType = BuildTypes.Alpha;
        public static int majorVersion = 0;
        public static int minorVersion = 0;
        public static int buildVersion = 1;

        private static bool checkingUpdate;

        public enum BuildTypes
        {
            Alpha,
            Beta,
            Normal
        }

        public static string GetVersion() => $"{majorVersion}.{minorVersion}.{buildVersion} {buildType}";

        #endregion Version

        #region Network

        public static void CheckForUpdates(bool message = false)
        {
            if (checkingUpdate) return;

            checkingUpdate = true;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "request");

                    wc.DownloadStringCompleted += (sender, e) => Wc_DownloadStringCompleted(e, message);
                    wc.DownloadStringAsync(new Uri(reposURL));
                }
            }
            catch { checkingUpdate = false; }
        }

        private static void Wc_DownloadStringCompleted(DownloadStringCompletedEventArgs e, bool message)
        {
            /*
            if (!e.Cancelled && e.Error == null)
            {
                var data = GithubReleasesData.FromJson(e.Result);
                if (data != null)
                {
                    int majorversion = Int32.Parse(data[0].TagName.Split('.')[0]),
                        minorversion = Int32.Parse(data[0].TagName.Split('.')[1]),
                        buildversion = Int32.Parse(data[0].TagName.Split('.')[2]);

                    bool update = false;

                    // Previous update verification logic was flawed:
                    // Simplified string "020" would become 2.
                    // Simplified string "019" would be 19.
                    // 2 < 19 so previous logic was flawed.
                    if (majorversion > majorVersion) update = true;
                    if (!update && minorversion > minorVersion) update = true;
                    if (!update && minorversion >= minorVersion && buildversion > buildVersion) update = true;

                    if (!update)
                    {
                        if (message) MessageBox.Show("You seem to be running the newest version!", "No Update Available!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        checkingUpdate = false;
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("There seem to be an update available.\n\rWould you like to go to the download location?", "Update Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Process.Start(projectURL + "/releases");
                        }
                    }
                }
            
            }
            */
            checkingUpdate = false;
        }

        public static bool CheckNetwork()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            catch
            {
                MessageBox.Show("SSL/TSL(12) connection could not be established. Networking disabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                using (var client = new WebClient().OpenRead("http://www.google.com/")) return true;
            }
            catch
            {
                MessageBox.Show("Could not detect a valid Internet connection. Networking disabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string GetUTCTime()
        {
            System.Int32 unixTimestamp = (System.Int32)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp.ToString();
        }

        #endregion Network

        #region Move Window

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void MoveWindow(Form main, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(main.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion Move Window

        #region IO

        public static string SelectFolder(string previousPath = "")
        {
            string folderPath = string.Empty;
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the directory that you want to use.";
                folderBrowserDialog.ShowNewFolderButton = true;

                // Show the FolderBrowserDialog.
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog.SelectedPath;
                }
            }
            return folderPath;
        }

        #endregion IO
    }
}
