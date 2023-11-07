using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Steam_Server_Creation_Tool_V2
{
    public partial class MainForm : Form
    {

        public enum ProgressType
        {
            Marquee,
            Blocks
        }
        public MainForm()
        {
            InitializeComponent();

            InitializeAsyncStart();
        }

        private async Task InitializeAsyncStart()
        {
            if (!Core.CheckNetwork())
            {
                MessageBox.Show($"{Core.softwareNameShort} need an internet connection to function.{Environment.NewLine}{Environment.NewLine}Please try again later.", "Internet Connection Required!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            SteamCMD_Button_Click(null, null);

            await RefreshAppList();

            ProgressBar(false, ProgressType.Marquee, 0);
        }

        public async Task RefreshAppList()
        {
            using (var httpClient = new HttpClient())
            {
                var client = new SteamAppListClient(httpClient);
                try
                {
                    var response = await client.GetAppListAsync();
                    // Use the response here

                    comboBox1.Items.Clear();

                    foreach (var item in response.AppList.Apps) 
                    {
                        comboBox1.Items.Add(item.AppNameId);
                    }

                    comboBox1.SelectedIndex = 0;

                    Install_New_Server_Label.Text = $"Install New Server ({response.AppList.Apps.Count})";
                }
                catch (Exception e)
                {
                    // Handle or log the exception here
                    Console.WriteLine($"An error occurred: {e.Message}");
                }
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);

        private async void SteamCMD_InstallAuto_Button_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(SteamCMD_InstallLocation_Textbox.Text) || !Directory.Exists(SteamCMD_InstallLocation_Textbox.Text))
            {
                SteamCMD_InstallLocation_Textbox.Text = Core.SelectFolder();
            }

            FileDownloader downloader = new FileDownloader();

            // Create the progress reporter and handler.
            var downloadProgress = new Progress<double>(percent =>
            {
                // Update your progress bar here.
                Console.WriteLine($"Download progress: {percent:P2}");

                ProgressBar(true, ProgressType.Blocks, (int)percent);
            });

            var unpackProgress = new Progress<double>(percent =>
            {
                // Update your progress bar here.
                Console.WriteLine($"Unpack progress: {percent:P2}");
                ProgressBar(true, ProgressType.Blocks, (int)percent);
            });

            try
            {
                // Download the file with progress reporting.
                await downloader.DownloadFileAsync(Core.steamCMDURL_Download, SteamCMD_InstallLocation_Textbox.Text, downloadProgress);

                // Assuming the zip file is named 'steamcmd.zip' and is located in the downloadPath.
                string zipFilePath = Path.Combine(SteamCMD_InstallLocation_Textbox.Text, "steamcmd.zip");

                // Unpack the zip file with progress reporting.
                await downloader.UnpackZipFileAsync(zipFilePath, SteamCMD_InstallLocation_Textbox.Text, unpackProgress);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                ProgressBar(false, ProgressType.Marquee, 0);
            }

        }

        private void SteamCMD_DownloadWebsite_Buttons_Click(object sender, EventArgs e)
        {
            Process.Start(Core.steamCMDURL);
        }

        public void ProgressBar(bool enabled, ProgressType style, int progress)
        {
            if(!enabled)
            {
                App_ProgressBar.Visible = false;
                App_ProgressBar.Enabled = false;
                return;
            }

            if(style == ProgressType.Blocks)
            {
                App_ProgressBar.Style = ProgressBarStyle.Blocks;
                App_ProgressBar.Value = progress;
            }
            else if(style == ProgressType.Marquee)
            {
                App_ProgressBar.Style = ProgressBarStyle.Marquee;
            }
        }

        private void SteamCMD_Button_Click(object sender, EventArgs e)
        {
            Panel_SteamCMD.Enabled = true;
            Panel_SteamCMD.Visible = true;

            Panel_NewServer.Enabled = false;
            Panel_NewServer.Visible = false;
        }

        private void NewServer_Button_Click(object sender, EventArgs e)
        {
            Panel_NewServer.Enabled = true;
            Panel_NewServer.Visible = true;

            Panel_SteamCMD.Enabled = false;
            Panel_SteamCMD.Visible = false;
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.Font = new Font(label.Font, label.Font.Style | FontStyle.Underline);
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.Font = new Font(label.Font, label.Font.Style & ~FontStyle.Underline);
            }
        }
    }
}
