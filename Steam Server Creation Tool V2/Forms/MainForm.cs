using Steam_Server_Creation_Tool_V2.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    public partial class MainForm : Form
    {
        public SteamAppListResponse SteamList = null;

        public Settings settings = null;

        public MainForm()
        {
            InitializeComponent();

            // Setup UI Panels
            UIHandler.Setup(this);
            ClearDefaultNSetup();

#pragma warning disable CS4014 // Not awaited warning disabled
            InitializeAsyncStart();
#pragma warning restore CS4014
        }

        private void ClearDefaultNSetup()
        {
            SteamCMD_InstallLocation_Textbox.Text = "";
            NewInstall_Dropbox.Items.Clear();
            NewServerAppName_Label.Text = "";
            NewServerAppId_Label.Text = "";
            NewServerName_Textbox.Text = "";
            NewServerInstallLocation_Textbox.Text = "";
        }

        private async Task InitializeAsyncStart()
        {
            if (!Core.CheckNetwork())
            {
                MessageBox.Show($"{Core.softwareNameShort} requires an active internet connection to operate.{Environment.NewLine}{Environment.NewLine}Please ensure that your network settings are configured correctly and attempt to start the application again.{Environment.NewLine}{Environment.NewLine}If the issue persists, you can post an issue at the github repository.", "Internet Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            //Load settings
            settings = Core.LoadSettings();

            if (settings == null)
            {
                settings = new Settings();
            }

            InstallFound();

            ApplyLoadedSettings();

            //Activate default panel
            SteamCMD_Button_Click(null, null);

            // Start downloading Steam API data
            await RefreshAPIData();

            // Disable progressbar
            App_ProgressBar.Visible = false;
        }

        private void ApplyLoadedSettings()
        {
            SteamCMD_InstallLocation_Textbox.Text = settings.steamCMD_installLocation;
            SteamCMD_SettingsInstallLocation_Textbox.Text = settings.steamCMD_installLocation;

            Validate_Checkbox.Checked = settings.validate;
            AutoClose_Checkbox.Checked = settings.autoClose;

            if (settings.useAnonymousAuth)
            {
                Anon_Radio.Checked = true;
                UserAuth_Radio.Checked = false;
            }
            else
            {
                Anon_Radio.Checked = false;
                UserAuth_Radio.Checked = true;
            }

            if (settings.userData != null)
            {
                UsernameField_Textbox.Text = settings.userData.Username;
                PasswordField_Textbox.Text = settings.userData.Password;
            }

            foreach (var item in settings.installedServer) InstalledServerList.Items.Add(item.name);

        }

        public async Task RefreshAppList()
        {
            using (var httpClient = new HttpClient())
            {
                var client = new SteamAppListClient(httpClient);
                try
                {
                    SteamList = await client.GetAppListAsync();
                    // Use the response here

                    NewInstall_Dropbox.Items.Clear();

                    foreach (var item in SteamList.AppList.Apps)
                    {
                        NewInstall_Dropbox.Items.Add(item.IdAppName);
                    }

                    NewInstall_Dropbox.SelectedIndex = 0;

                    Install_New_Server_Label.Text = $"Install New Server ({SteamList.AppList.Apps.Count})";
                }
                catch (Exception e)
                {
                    // Handle or log the exception here
                    MessageBox.Show(e.Message, "Error reading data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void SteamCMD_InstallAuto_Button_Click(object sender, EventArgs e)
        {
            App_ProgressBar.Visible = true;

            if (string.IsNullOrEmpty(SteamCMD_InstallLocation_Textbox.Text) || !Directory.Exists(SteamCMD_InstallLocation_Textbox.Text))
            {
                SteamCMD_InstallLocation_Textbox.Text = Core.SelectFolder();
            }

            FileDownloader downloader = new FileDownloader();

            string zipFilePath = "";

            // Download data and unpack
            try
            {
                // Download the file with progress reporting.
                await downloader.DownloadFileAsync(Core.steamCMDURL_Download, SteamCMD_InstallLocation_Textbox.Text);

                // Assuming the zip file is named 'steamcmd.zip' and is located in the downloadPath.
                zipFilePath = Path.Combine(SteamCMD_InstallLocation_Textbox.Text, "steamcmd.zip");

                // Unpack the zip file with progress reporting.
                await downloader.UnpackZipFileAsync(zipFilePath, SteamCMD_InstallLocation_Textbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error reading data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                App_ProgressBar.Visible = false;
            }

            // Delete file
            try
            {
                if (File.Exists(zipFilePath)) File.Delete(zipFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error reading data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                App_ProgressBar.Visible = false;
            }

            // Add steam installation location to settings data
            if (File.Exists(Path.Combine(SteamCMD_InstallLocation_Textbox.Text, "steamcmd.exe")))
            {
                settings.steamCMD_installLocation = Path.Combine(SteamCMD_InstallLocation_Textbox.Text, "steamcmd.exe");
            }

            Core.SaveSettings(settings);

            InstallFound();
        }

        private void NewServerInstallLocation_Button_Click(object sender, EventArgs e) => NewServerInstallLocation_Textbox.Text = Core.SelectFolder();
        private async void RefreshAPI_Button_Click(object sender, EventArgs e) => await RefreshAPIData();
        private void ManageServers_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(UIHandler.Panel.ManageServers, this);
        private void Settings_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(UIHandler.Panel.Settings, this);
        private void SteamCMD_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(UIHandler.Panel.SteamCMD, this);
        private void NewServer_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(UIHandler.Panel.NewServer, this);
        private void SteamCMD_DownloadWebsite_Buttons_Click(object sender, EventArgs e) => Process.Start(Core.steamCMDURL);
        private void SteamCMD_Button_MouseEnter(object sender, EventArgs e) => UIHandler.Label_MouseHover(sender, e);
        private void NewServer_Button_MouseEnter(object sender, EventArgs e) => UIHandler.Label_MouseHover(sender, e);
        private void ManageServers_Button_MouseEnter(object sender, EventArgs e) => UIHandler.Label_MouseHover(sender, e);
        private void Settings_Button_MouseEnter(object sender, EventArgs e) => UIHandler.Label_MouseHover(sender, e);
        private void SteamCMD_Button_MouseLeave(object sender, EventArgs e) => UIHandler.Label_MouseLeave(sender, e);
        private void NewServer_Button_MouseLeave(object sender, EventArgs e) => UIHandler.Label_MouseLeave(sender, e);
        private void ManageServers_Button_MouseLeave(object sender, EventArgs e) => UIHandler.Label_MouseLeave(sender, e);
        private void Settings_Button_MouseLeave(object sender, EventArgs e) => UIHandler.Label_MouseLeave(sender, e);
        private void GSLT_Button_Click(object sender, EventArgs e) => Process.Start("https://steamcommunity.com/dev/managegameservers?l=english");
        private void Close_Button_Click(object sender, EventArgs e) => Environment.Exit(0);
        private void Minimize_Button_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);

        private void ManualLocateSteamCMD_Button_Click(object sender, EventArgs e)
        {
            //Initiate a OpenFileDialog
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                //Set OpenFileDialog info
                ofd.InitialDirectory = "c:\\";
                ofd.FileName = "steamcmd";
                ofd.Filter = "Exe Files (.exe)|steamcmd.exe";
                ofd.FilterIndex = 1;

                //Show dialogue and check if file exist
                if (ofd.ShowDialog() == DialogResult.OK && ofd.CheckFileExists)
                {
                    //Update location of steamcmd
                    SteamCMD_InstallLocation_Textbox.Text = ofd.FileName;
                    SteamCMD_SettingsInstallLocation_Textbox.Text = ofd.FileName;
                    settings.steamCMD_installLocation = ofd.FileName;

                    //Set button information OK

                    Core.SaveSettings(settings);
                }
            }

            InstallFound();
        }

        private async Task RefreshAPIData()
        {
            App_ProgressBar.Visible = true;

            NewInstall_Dropbox.Items.Clear();

            NewInstall_Dropbox.Enabled = false;
            RefreshAPI_Button.Enabled = false;
            SearchServer_Button.Enabled = false;
            InstallServer_Button.Enabled = false;

            SteamCMD_Button.Enabled = false;
            NewServer_Button.Enabled = false;
            ManageServers_Button.Enabled = false;
            Settings_Button.Enabled = false;

            //RefreshAPI_Button
            await RefreshAppList();

            RefreshAPI_Button.Enabled = true;
            SearchServer_Button.Enabled = true;
            InstallServer_Button.Enabled = true;

            NewInstall_Dropbox.Enabled = true;
            SteamCMD_Button.Enabled = true;
            NewServer_Button.Enabled = true;
            ManageServers_Button.Enabled = true;
            Settings_Button.Enabled = true;

            NewInstall_Dropbox.SelectedIndex = 0;

            App_ProgressBar.Visible = false;
        }

        private void ServerSetupHelp_Button_Click(object sender, EventArgs e)
        {
            App app = GetSelectedApp();

            if (NewInstall_Dropbox.Items.Count > 0 && app != null)
            {
                string query = app.Name.Replace(' ', '+');
                Process.Start("https://www.google.com/search?q=" + query + "+server+setup");
            }
            else
            {
                MessageBox.Show("There was an error loading data from selection. Please try again.", "Error Getting Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private App GetSelectedApp()
        {
            string selectedItem = NewInstall_Dropbox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedItem)) return null;
            else
            {
                foreach (var item in SteamList.AppList.Apps)
                {
                    if (selectedItem.Equals(item.IdAppName, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
                return null;
            }
        }

        private void NewInstall_Dropbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            App app = GetSelectedApp();

            if (app == null || NewInstall_Dropbox.SelectedIndex == -1) 
            {
                InstallServer_Button.Enabled = false;
                return;
            }

            if (app != null)
            {
                //Check if server is installed
                int numberOfInstalls = 0;

                foreach (var item in settings.installedServer)
                {
                    if (item.app.AppId == app.AppId) numberOfInstalls++;
                }

                // Set information from the app
                NewServerAppName_Label.Text = app.Name;
                NewServerAppId_Label.Text = app.AppId.ToString();
                Installs_Label.Text = $"Installs found: {numberOfInstalls}";

                NewServerName_Textbox.Text = app.Name;
                InstallServer_Button.Enabled = true;
            }
            else
            {
                NewServerAppName_Label.Text = "";
                NewServerAppId_Label.Text = "";
                NewServerName_Textbox.Text = "";
                InstallServer_Button.Enabled = false;
            }
        }

        public void InstallFound()
        {
            if(File.Exists(settings.steamCMD_installLocation))
            {
                FoundInstallationLogo_Picturebox.Visible = true;
                FoundInstallationLogo2.Visible = true;
                InstallFound_Label2.Visible = true;
                InstallFound_Label.Visible = true;
            }
            else
            {
                FoundInstallationLogo_Picturebox.Visible = false;
                FoundInstallationLogo2.Visible = false;
                InstallFound_Label2.Visible = false;
                InstallFound_Label.Visible = false;
            }
        }

        

        private void InstallServer_Button_Click(object sender, EventArgs e)
        {
            App app = GetSelectedApp();

            if (string.IsNullOrEmpty(NewServerName_Textbox.Text) || string.IsNullOrEmpty(NewServerInstallLocation_Textbox.Text) || app == null)
            {
                MessageBox.Show($"Required fields are not filled in:{Environment.NewLine}Server Name{Environment.NewLine}Server Install Location{Environment.NewLine}Selected Server{Environment.NewLine}{Environment.NewLine}Please fill in all fields and select a valid server from the list.", "Required field missing information!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool unique = true;
            foreach (var installed in settings.installedServer)
            {
                if (installed.name == NewServerName_Textbox.Text)
                {
                    unique = false;
                    break;
                }
            }

            if(!unique)
            {
                MessageBox.Show($"The name you have set for the installation is not unique. This is not allowed.", "Not a unique name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Core.IsFolderEmpty(NewServerInstallLocation_Textbox.Text))
            {
                if(MessageBox.Show($"The installation directory is not empty.{Environment.NewLine}This will overwrite files and may potentially destroy a server or important files.{Environment.NewLine}{Environment.NewLine}Do you want to proceed?", "Selected folder not empty!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            SteamCMDHelper.StartNewDownload(this, app, NewServerName_Textbox.Text, NewServerInstallLocation_Textbox.Text);
        }

        private void SearchServer_Button_Click(object sender, EventArgs e)
        {
            using (SearchForm s = new SearchForm(this))
            {
                s.ShowDialog();
            }
        }

        private void TogglePassword_Button_Click(object sender, EventArgs e)
        {
            if (PasswordField_Textbox.PasswordChar == '*') PasswordField_Textbox.PasswordChar = '\0';
            else PasswordField_Textbox.PasswordChar = '*';
        }

        private void SaveSettings_Button_Click(object sender, EventArgs e)
        {
            if(UsernameField_Textbox.Text != "" && PasswordField_Textbox.Text != "") {
                settings.userData = new UserData();
                settings.userData.SetUsername(UsernameField_Textbox.Text);
                settings.userData.SetPassword(PasswordField_Textbox.Text);
            }

            settings.useAnonymousAuth = Anon_Radio.Checked;

            settings.validate = Validate_Checkbox.Checked;
            settings.autoClose = AutoClose_Checkbox.Checked;

            settings.steamCMD_installLocation = SteamCMD_SettingsInstallLocation_Textbox.Text;

            Core.SaveSettings(settings);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(settings.userData.Username);
        }
    }
}
