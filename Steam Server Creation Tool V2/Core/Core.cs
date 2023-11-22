using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    public static class Core
    {
        //Debug feature
        public static bool debug = false;

        //System settings
        public static string softwareName = "Steam Server Creation Tool V2";
        public static string softwareNameShort = "SSCTV2";

        public static string authorRealName = "Victor";
        public static string authorName = "N0tiC";
        public static string discordCommunity = "https://discord.gg/WypdXXJ34p";

        public static string projectURL = "https://github.com/n0tic/Steam-Server-Creation-Tool-V2";
        public static string reposURL = "https://api.github.com/repos/n0tic/Steam-Server-Creation-Tool-V2/releases";
        public static string releaseURL = "https://github.com/n0tic/Steam-Server-Creation-Tool-V2/releases/";

        public static string steamCMDURL = "https://developer.valvesoftware.com/wiki/SteamCMD#Downloading_SteamCMD";
        public static string steamCMDURL_Download = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";
        public static string serversURL = "https://api.steampowered.com/ISteamApps/GetAppList/v2?utc=";
        public static string donateURL = "https://www.paypal.com/donate/?hosted_button_id=PTYHDUJBUJGA2";

        #region Version

        public static BuildTypes buildType = BuildTypes.Alpha;
        public static int majorVersion = 0;
        public static int minorVersion = 0;
        public static int buildVersion = 4;

        private static bool checkingUpdate = false;
        public static bool updateAvailable = false;

        public static string newUpdateVersion = "No data";

        public enum BuildTypes
        {
            Alpha,
            Beta,
            Normal
        }

        /// <summary>
        /// Get version in format Major.Minor.Build Build-type
        /// </summary>
        /// <returns></returns>
        public static string GetVersion() => $"{majorVersion}.{minorVersion}.{buildVersion} {buildType}";

        #endregion Version

        #region Network

        public static async Task CheckForUpdatesAsync(MainForm form, bool message = false)
        {
            if (checkingUpdate) return;

            checkingUpdate = true;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "request");

                    string result = await wc.DownloadStringTaskAsync(new Uri(reposURL));

                    var releasesData = GithubReleasesData.FromJson(result);

                    if (releasesData != null)
                    {
                        int latestMajorVersion = Int32.Parse(releasesData[0].TagName.Split('.')[0]);
                        int latestMinorVersion = Int32.Parse(releasesData[0].TagName.Split('.')[1]);
                        int latestBuildVersion = Int32.Parse(releasesData[0].TagName.Split('.')[2]);

                        bool requiresUpdate = (latestMajorVersion > majorVersion) ||
                                              (latestMinorVersion > minorVersion) ||
                                              (latestMinorVersion >= minorVersion && latestBuildVersion > buildVersion);

                        if (!requiresUpdate)
                        {
                            if (message) MessageBox.Show("You are using the latest version.", "No Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            checkingUpdate = false;
                            form.workInProgress = false;
                            return;
                        }

                        updateAvailable = true;
                        newUpdateVersion = $"{latestMajorVersion}.{latestMinorVersion}.{latestBuildVersion}";

                        if (MessageBox.Show("An update is available. Would you like to update?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            if (form.settings.allowAutoUpdate)
                            {
                                form.App_ProgressBar.Visible = true;

                                string updater = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AutoUpdater.exe");

                                if (File.Exists(updater))
                                {
                                    // Start the process and exit the application
                                    Process.Start(new ProcessStartInfo
                                    {
                                        FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AutoUpdater.exe"),
                                        Arguments = $"{releasesData[0].Assets[0].BrowserDownloadUrl}",
                                        UseShellExecute = false,
                                        CreateNoWindow = true
                                    });

                                    // Exit the application
                                    Application.Exit();
                                }
                                else
                                {
                                    MessageBox.Show($"AutoUpdater.exe was not located. Download it and try again.{Environment.NewLine}{Environment.NewLine}False positive and does not come with the software by default.", "AutoUpdater Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    checkingUpdate = false;
                                    form.workInProgress = false;
                                    return;
                                }
                            }
                            else Process.Start(releaseURL);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong. Private repository or no release found.");
                        form.workInProgress = false;
                    }
                }
            }
            catch { checkingUpdate = false; form.workInProgress = false; }
            finally { checkingUpdate = false; form.workInProgress = false; }
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

        /// <summary>
        /// Move the window by holding down mouse 1 (left click, mouse down) on the object
        /// </summary>
        /// <param name="form"></param>
        /// <param name="e"></param>
        public static void MoveWindow(Form form, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion Move Window

        #region IO

        public static async Task MoveFolderAsync(string sourceDirectoryName, string targetDirectoryName)
        {
            await Task.Run(() =>
            {
                Directory.CreateDirectory(targetDirectoryName);

                DirectoryInfo source = new DirectoryInfo(sourceDirectoryName);
                DirectoryInfo target = new DirectoryInfo(targetDirectoryName);

                MoveWork(source, target);

                foreach (var item in source.GetDirectories("*", SearchOption.AllDirectories))
                {
                    try
                    {
                        item.Delete(true);
                    }
                    catch { }
                }
            });
        }

        private static void MoveWork(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                MoveWork(dir, target.CreateSubdirectory(dir.Name));
            }

            foreach (FileInfo file in source.GetFiles())
            {
                file.MoveTo(Path.Combine(target.FullName, file.Name));
            }
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp) => source?.IndexOf(toCheck, comp) >= 0;

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

        public static void SaveToFile(string fullPath, string data)
        {
            using (StreamWriter writer = new StreamWriter(fullPath)) writer.Write(data);
        }

        public static void SaveSettings(Settings data)
        {
            try
            {
                using (FileStream dataStream = new FileStream("data", FileMode.Create))
                {
                    BinaryFormatter converter = new BinaryFormatter();
                    converter.Serialize(dataStream, data);
                }
            }
            catch (Exception ex)
            {
                // Log or provide detailed information for debugging
                MessageBox.Show($"Error saving settings and data: {ex.Message}", "Error Saving Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Settings LoadSettings()
        {
            if (File.Exists("data"))
            {
                using (FileStream dataStream = new FileStream("data", FileMode.Open))
                {
                    try
                    {
                        BinaryFormatter converter = new BinaryFormatter();
                        Settings data = converter.Deserialize(dataStream) as Settings;
                        return data;
                    }
                    catch (Exception ex)
                    {
                        // Log or provide detailed information for debugging
                        MessageBox.Show($"Error reading binary data: {ex.Message}", "Error Reading Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public static bool IsFolderEmpty(string path)
        {
            if (Directory.GetFiles(path).Length < 1) return true;
            else return false;
        }

        #endregion IO

        #region Encode

        /// <summary>
        /// Decode password
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Encode password
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        #endregion Encode
    }
}
