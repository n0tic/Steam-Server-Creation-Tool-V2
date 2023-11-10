using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    public static class Core
    {
        public static bool debug = false;

        public static string softwareName = "Steam Server Creation Tool";
        public static string softwareNameShort = "SSCT";

        public static string authorRealName = "Victor";
        public static string authorName = "N0tiC";
        public static string authorContact = "contact@bytevaultstudio.se";

        public static string projectURL = "https://github.com/n0tic/Steam-Server-Creation-Tool-V2";
        public static string reposURL = "https://api.github.com/repos/n0tic/Steam-Server-Creation-Tool-V2/releases";

        public static string steamCMDURL = "https://developer.valvesoftware.com/wiki/SteamCMD#Downloading_SteamCMD";
        public static string steamCMDURL_Download = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";
        public static string serversURL = "https://api.steampowered.com/ISteamApps/GetAppList/v2?utc=";

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

            if (!e.Cancelled && e.Error == null)
            {
                var releasesData = GithubReleasesData.FromJson(e.Result);

                if (releasesData != null)
                {
                    int latestMajorVersion = Int32.Parse(releasesData[0].TagName.Split('.')[0]);
                    int latestMinorVersion = Int32.Parse(releasesData[0].TagName.Split('.')[1]);
                    int latestBuildVersion = Int32.Parse(releasesData[0].TagName.Split('.')[2]);

                    bool requiresUpdate = (latestMajorVersion > majorVersion) || (latestMinorVersion > minorVersion) || (latestMinorVersion >= minorVersion && latestBuildVersion > buildVersion);

                    if (!requiresUpdate)
                    {
                        if (message) MessageBox.Show("You are using the latest version.", "No Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        checkingUpdate = false;
                        return;
                    }

                    if (MessageBox.Show("An update is available. Would you like to update?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        // Start the process and exit the application
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Steam Server Creation Tool V2.exe"),
                            Arguments = $"{releasesData[0].Assets[0].BrowserDownloadUrl}",
                            UseShellExecute = false,
                            CreateNoWindow = true
                        });

                        // Exit the application
                        Environment.Exit(0);
                    }
                }
            }

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

        public static void SaveToFile(string fullPath, string data)
        {
            using (StreamWriter writer = new StreamWriter(fullPath)) writer.Write(data);
        }

        public static void SaveSettings(Settings data)
        {
            string json_data = "";
            try
            {
                json_data = JsonConvert.SerializeObject(data);
            }
            catch { MessageBox.Show("The settings and data could not be saved!", "Error Saving Data!", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            if (!String.IsNullOrEmpty(json_data))
            {
                try
                {
                    File.WriteAllText("data.json", json_data);
                }
                catch { MessageBox.Show("Could not save settings and data!", "Error Saving Data!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("Settings data seems empty. This should not be visible...", "Error Saving Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static Settings LoadSettings()
        {
            string stringData = null;

            if (System.IO.File.Exists("data.json"))
            {
                try
                {
                    stringData = File.ReadAllText("data.json");
                    return JsonConvert.DeserializeObject<Settings>(stringData);
                }
                catch (Exception e) { MessageBox.Show(e.Message, "Error reading data!", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
            }
            else if (System.IO.File.Exists("data"))
            {
                using (FileStream dataStream = new FileStream("data", FileMode.Open))
                {
                    try
                    {
                        BinaryFormatter converter = new BinaryFormatter();
                        Settings data = converter.Deserialize(dataStream) as Settings;
                        return data;
                    }
                    catch (ArgumentNullException x) { MessageBox.Show(x.Message, "Error reading data!", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
                    catch (SerializationException x) { MessageBox.Show("Saved data is corrupt and could not be loaded.\n\rSave file will automatically be overwritten on next save. \n\r\n\r" + x.Message, "Load Data Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
                    catch (SecurityException x) { MessageBox.Show(x.Message, "Error reading data!", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
                }
            }
            else return null;
        }

        public static bool IsFolderEmpty(string path)
        {
            if (Directory.GetFiles(path).Length > 0) return true;
            else return false;
        }

        #endregion IO

        public static bool Contains(this string source, string toCheck, StringComparison comp) => source?.IndexOf(toCheck, comp) >= 0;

        #region Encode

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        #endregion Encode
    }
}
