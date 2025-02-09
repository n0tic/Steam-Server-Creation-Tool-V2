#pragma warning disable CS4014 // Not awaited warning disabled
using Steam_Server_Creation_Tool_V2.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    public partial class MainForm : Form
    {
        // Settings data - Servers, User auth etc
        public Settings settings = null;

        // Console feature
        public ConsoleHandler console = null;

        // Steam API data
        public SteamAppListResponse SteamList = null;

        // Have we recieved Steam API data?
        public bool updateRecieved = false;

        // Have we recieved IP data?
        PortScanIP_Result ipData = null;
        public bool hasIP = false;

        // Are we running a process/task?
        public bool workInProgress = false;

        public MainForm()
        {
            InitializeComponent();

            // Setup UI Panels
            UIHandler.Setup(this);

            //Activate default panel
            SteamCMD_Button_Click(SteamCMD_Button, null);

            //Set default values to labels and fields
            ClearDefaultNSetup();

            //We do not await this async command
            InitializeAsyncStart();

        }

        #region System

        /// <summary>
        /// Clear and set default values for placeholder values
        /// </summary>
        private void ClearDefaultNSetup()
        {
            Version_Label.Text = $"Version: {Core.GetVersion()}";
            SetNewVersionStatus(false);
            SteamCMD_InstallLocation_Textbox.Text = "";
            NewInstall_Dropbox.Items.Clear();
            NewServerAppName_Label.Text = "";
            NewServerAppId_Label.Text = "";
            NewServerName_Textbox.Text = "";
            NewServerInstallLocation_Textbox.Text = "";
            PortResult_Label.Text = "";
            PortScanLoading_PictureBox.Enabled = false;
            PortScanLoading_PictureBox.Visible = false;
            Setup_Button.Enabled = false;
            InstalledServerList_SelectedIndexChanged(null, null);

            Port_Numeric.Minimum = 0;
            Port_Numeric.Maximum = 65535;
            Port_Numeric.Value = 27015;
        }

        /// <summary>
        /// Activate/Deactivate version update availability status
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        private void SetNewVersionStatus(bool state, string message = "")
        {
            NewVersion_Panel.Visible = state;
            NewVersion_Label.Text = $"New version ({message}) available"; ;
            NewVersion_Label.Visible = state;
        }

        /// <summary>
        /// Async startup initiator
        /// </summary>
        /// <returns></returns>
        private async Task InitializeAsyncStart()
        {
            if (!Core.CheckNetwork())
            {
                MessageBox.Show($"{Core.softwareNameShort} requires an active internet connection to operate.{Environment.NewLine}{Environment.NewLine}Please ensure that your network settings are configured correctly and attempt to start the application again.{Environment.NewLine}{Environment.NewLine}If the issue persists, you can post an issue at the github repository.", "Internet Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            // Load settings
            settings = Core.LoadSettings();

            // Start a new data container for settings
            if (settings == null) settings = new Settings();

            // Check if installation was found
            InstallFound();

            // Load settings data into UI
            ApplyLoadedSettings();

            // Start console handler and functions
            console = new ConsoleHandler(this);

            //Check for updates
            if (settings.CheckUpdates)
            {
                await Core.CheckForUpdatesAsync(this);
                SetNewVersionStatus(Core.updateAvailable, Core.newUpdateVersion);
            }

            bottom_border_panel.BringToFront();

            // Disable progressbar
            App_ProgressBar.Visible = false;
        }

        /// <summary>
        /// Apply loaded settings to UI elements
        /// </summary>
        private void ApplyLoadedSettings()
        {
            SteamCMD_InstallLocation_Textbox.Text = settings.steamCMD_installLocation;
            SteamCMD_SettingsInstallLocation_Textbox.Text = settings.steamCMD_installLocation;

            Validate_Checkbox.Checked = settings.validate;
            AutoClose_Checkbox.Checked = settings.autoClose;
            CheckForUpdates_Checkbox.Checked = settings.CheckUpdates;
            AllowUpdater_Checkbox.Checked = settings.allowAutoUpdate;
            WrapSteamCMD_Checkbox.Checked = settings.wrapSteamCMD;

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
                PasswordField_Textbox.Text = Core.Base64Decode(settings.userData.Password);
            }

            UpdateInstalledServersInfo();
        }

        /// <summary>
        /// Attempt to shut down application
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void CloseApplication()
        {
            if (workInProgress)
            {
                if (MessageBox.Show($"The application is currently performing a task.{Environment.NewLine}I strongly suggest that you wait untill the application finish the task before shutting down.{Environment.NewLine}{Environment.NewLine}Do you wish to force the application to shut down?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
            }
            else Environment.Exit(0);
        }

        /// <summary>
        /// Reset values, lock UI - Update Steam API data
        /// </summary>
        /// <returns></returns>
        public async Task RefreshAPIData()
        {
            workInProgress = true;
            App_ProgressBar.Visible = true;

            NewInstall_Dropbox.Items.Clear();

            Install_New_Server_Label.Text = "Install New Server";

            ServerSetupHelp_Button.Enabled = false;
            GSLT_Button.Enabled = false;
            NewServerInstallLocation_Button.Enabled = false;
            NewServerName_Textbox.Enabled = false;
            NewServerInstallLocation_Textbox.Enabled = false;
            NewInstall_Dropbox.Enabled = false;
            RefreshAPI_Button.Enabled = false;
            SearchServer_Button.Enabled = false;
            InstallServer_Button.Enabled = false;

            SteamCMD_Button.Enabled = false;
            NewServer_Button.Enabled = false;
            ManageServers_Button.Enabled = false;
            PortScan_Button.Enabled = false;
            PanelConsole_button.Enabled = false;
            SettingsButton.Enabled = false;

            //RefreshAPI_Button
            await RefreshAppList();

            ServerSetupHelp_Button.Enabled = true;
            NewServerInstallLocation_Button.Enabled = true;
            NewServerName_Textbox.Enabled = true;
            NewServerInstallLocation_Textbox.Enabled = true;
            GSLT_Button.Enabled = true;
            RefreshAPI_Button.Enabled = true;
            SearchServer_Button.Enabled = true;
            InstallServer_Button.Enabled = true;

            NewInstall_Dropbox.Enabled = true;
            SteamCMD_Button.Enabled = true;
            NewServer_Button.Enabled = true;
            ManageServers_Button.Enabled = true;
            PortScan_Button.Enabled = true;
            PanelConsole_button.Enabled = true;
            SettingsButton.Enabled = true;

            NewInstall_Dropbox.SelectedIndex = 0;

            App_ProgressBar.Visible = false;
            workInProgress = false;
        }

        /// <summary>
        /// steamcmd.exe found indicator
        /// </summary>
        public void InstallFound()
        {
            if (File.Exists(settings.steamCMD_installLocation))
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

        #endregion System

        #region SteamCMD

        /// <summary>
        /// Start download/unpack steamcmd into a directory automatically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SteamCMD_InstallAuto_Button_Click(object sender, EventArgs e)
        {
            workInProgress = true;
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
                workInProgress = false;
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
                workInProgress = false;
            }

            // Add steam installation location to settings data
            if (File.Exists(Path.Combine(SteamCMD_InstallLocation_Textbox.Text, "steamcmd.exe")))
            {
                settings.steamCMD_installLocation = Path.Combine(SteamCMD_InstallLocation_Textbox.Text, "steamcmd.exe");
            }

            Core.SaveSettings(settings);

            InstallFound();

            App_ProgressBar.Visible = false;
            workInProgress = false;
        }

        /// <summary>
        /// Allow for manual locating of steamcmd.exe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    SteamCMD_SettingsInstallLocation_Textbox.Text = ofd.FileName;
                    SteamCMD_InstallLocation_Textbox.Text = ofd.FileName;
                    settings.steamCMD_installLocation = ofd.FileName;

                    InstallFound();

                    Core.SaveSettings(settings);
                }
            }
        }

        #endregion SteamCMD

        #region New Server

        /// <summary>
        /// Get Steam API data from request
        /// </summary>
        /// <returns></returns>
        public async Task RefreshAppList()
        {
            using (var httpClient = new HttpClient())
            {
                var client = new SteamAppListClient(httpClient);
                try
                {
                    SteamList = await client.GetAppListAsync();

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

        /// <summary>
        /// Google query search for selected game regarding server setup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Get selected app from dropbox in SteamCMD section
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Selection change logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Start installation of server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void InstallServer_Button_Click(object sender, EventArgs e)
        {
            App app = GetSelectedApp();

            if (NewServerName_Textbox.Text == "" || NewServerInstallLocation_Textbox.Text == "" || app == null)
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

            if (!unique)
            {
                MessageBox.Show($"The name you have set for the installation is not unique. This is not allowed.", "Not a unique name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(NewServerInstallLocation_Textbox.Text))
            {
                MessageBox.Show($"The selected folder for installation doesnt exist. Try again.", "Directory missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(settings.steamCMD_installLocation))
            {
                MessageBox.Show($"It looks like SteamCMD installation is missing. Visit SteamCMD and reference it manually or use the automatic feature.", "SteamCMD missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Core.IsFolderEmpty(NewServerInstallLocation_Textbox.Text))
            {
                if (MessageBox.Show($"The installation directory is not empty.{Environment.NewLine}This will overwrite files and may potentially destroy a server or important files.{Environment.NewLine}{Environment.NewLine}Do you want to proceed?", "Selected folder not empty!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            workInProgress = true;
            App_ProgressBar.Visible = true;
            InstallServer_Button.Enabled = false;

            NewServerInstallLocation_Textbox.Text = "";

            await SteamCMDHelper.RunSteamCMD(this, app, NewServerName_Textbox.Text, NewServerInstallLocation_Textbox.Text);

            UpdateInstalledServersInfo();

            InstallServer_Button.Enabled = true;
            App_ProgressBar.Visible = false;
            workInProgress = false;
        }

        /// <summary>
        /// Open search form dialogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchServer_Button_Click(object sender, EventArgs e)
        {
            using (SearchForm s = new SearchForm(this))
            {
                s.ShowDialog();
            }
        }

        #endregion New Server

        #region Manage Servers

        /// <summary>
        /// Update installed server information into listbox of Manage section
        /// </summary>
        private void UpdateInstalledServersInfo()
        {
            InstalledServerList.Items.Clear();
            foreach (var item in settings.installedServer) InstalledServerList.Items.Add(item.name);
        }

        /// <summary>
        /// Installed server selection logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstalledServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InstalledServerList.SelectedIndex != -1)
            {
                InstalledServer server = null;

                foreach (var item in settings.installedServer)
                {
                    if (item.name == (string)InstalledServerList.SelectedItem)
                    {
                        server = item;
                        break;
                    }
                }

                ManageName_Button.Enabled = true;
                ManageMoveServerLocation_Button.Enabled = true;
                ManageGenerateScript_Button.Enabled = true;
                ManageUpdate_Button.Enabled = true;
                ManageDelete_Button.Enabled = true;
                ManageOpenDirectory_Button.Enabled = true;
                ManageGuide_Button.Enabled = true;
                ManageServerName_Textbox.Enabled = true;
                ManageInstallDirectory_Textbox.Enabled = true;
                if (server.app.AppId == 90) Setup_Button.Enabled = true;
                else Setup_Button.Enabled = false;

                if (server != null)
                {
                    ManageServerName_Textbox.Text = server.name;
                    ManageInstallDirectory_Textbox.Text = server.installPath;
                    ManageAppName_Label.Text = server.app.Name;
                    ManageAppId_Label.Text = server.app.AppId.ToString();
                    ManageInstallDate_Label.Text = server.installDate;
                }
            }
            else
            {
                ManageName_Button.Enabled = false;
                ManageMoveServerLocation_Button.Enabled = false;
                ManageGenerateScript_Button.Enabled = false;
                ManageUpdate_Button.Enabled = false;
                ManageDelete_Button.Enabled = false;
                ManageOpenDirectory_Button.Enabled = false;
                ManageGuide_Button.Enabled = false;
                ManageServerName_Textbox.Enabled = false;
                ManageInstallDirectory_Textbox.Enabled = false;
                Setup_Button.Enabled = false;

                ManageServerName_Textbox.Text = "";
                ManageInstallDirectory_Textbox.Text = "";
                ManageAppName_Label.Text = "";
                ManageAppId_Label.Text = "";
                ManageInstallDate_Label.Text = "";
            }
        }

        /// <summary>
        /// Generate StartServerScript for selected server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageGenerateScript_Button_Click(object sender, EventArgs e)
        {
            int server = Manage_FindServer();

            if (server != -1)
            {
                if (settings.installedServer[server] != null)
                {
                    if (File.Exists(settings.installedServer[server].installPath + @"\StartServerScript.bat"))
                    {
                        if (MessageBox.Show("There is already a generated script in this directory. \n\rAre you sure you want to overwrite?", "Overwrite Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    workInProgress = true;

                    string startScript = Properties.Resources.StartServerScript_bat;
                    startScript = startScript.Replace("{steamcmd_dir}", "\"" + Path.GetDirectoryName(settings.steamCMD_installLocation) + "\"");
                    startScript = startScript.Replace("{server_dir}", settings.installedServer[server].installPath);
                    startScript = startScript.Replace("{app_id}", settings.installedServer[server].app.AppId.ToString());
                    startScript = startScript.Replace("{app_name}", settings.installedServer[server].app.Name);
                    startScript = startScript.Replace("{login_cred}", settings.GetLogin());

                    Core.SaveToFile(settings.installedServer[server].installPath + @"\StartServerScript.bat", startScript);

                    workInProgress = false;
                }
            }
        }

        /// <summary>
        /// Change name of selected server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageName_Button_Click(object sender, EventArgs e)
        {
            int server = Manage_FindServer();

            if (server != -1 && settings.installedServer[server].name != ManageServerName_Textbox.Text && ManageServerName_Textbox.Text != "")
            {
                workInProgress = true;
                settings.installedServer[server].name = ManageServerName_Textbox.Text;
                UpdateInstalledServersInfo();
                Core.SaveSettings(settings);
                workInProgress = false;
            }
        }

        /// <summary>
        /// Move selected server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ManageMoveServerLocation_Button_Click(object sender, EventArgs e)
        {
            workInProgress = true;
            App_ProgressBar.Visible = true;

            int server = Manage_FindServer();

            if (server != -1)
            {
                string sourceDirectory = settings.installedServer[server].installPath;
                string targetDirectory = Core.SelectFolder();

                try
                {
                    await Core.MoveFolderAsync(sourceDirectory, targetDirectory);
                    settings.installedServer[server].installPath = targetDirectory;
                    UpdateInstalledServersInfo();
                    Core.SaveSettings(settings);
                }
                catch { }
            }

            App_ProgressBar.Visible = false;
            workInProgress = false;
        }

        /// <summary>
        /// Open file explorer of selected server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageOpenDirectory_Button_Click(object sender, EventArgs e)
        {
            int server = Manage_FindServer();

            if (server != -1)
            {
                string sourceDirectory = settings.installedServer[server].installPath;

                // Check if the directory exists before attempting to open it
                if (Directory.Exists(sourceDirectory))
                {
                    // Open the directory using the default file manager
                    Process.Start(sourceDirectory);
                }
                else
                {
                    // Handle the case where the directory does not exist
                    MessageBox.Show($"The directory '{sourceDirectory}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Find selected server from Manage section
        /// </summary>
        /// <returns></returns>
        private int Manage_FindServer()
        {
            for (int i = 0; i < settings.installedServer.Count; i++)
            {
                if (InstalledServerList.SelectedItem.ToString() == settings.installedServer[i].name)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Update selected server from Manage section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ManageUpdate_Button_Click(object sender, EventArgs e)
        {
            int server = Manage_FindServer();

            if (server != -1 && settings.installedServer[server] != null)
            {
                if (MessageBox.Show("Make sure the server is offline before proceeding. Otherwise, this may result in server corruption.", "Server Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                workInProgress = true;
                await SteamCMDHelper.RunSteamCMD(this, settings.installedServer[server].app, settings.installedServer[server].name, settings.installedServer[server].installPath, SteamCMDHelper.InstallationType.Update);
                workInProgress = false;
            }
        }

        /// <summary>
        /// Delete selected server from Manage section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageDelete_Button_Click(object sender, EventArgs e)
        {
            int server = Manage_FindServer();

            if (server != -1 && settings.installedServer[server] != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the install server?\n\rThis will completely remove files and database references.", "Deletion Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Initiate new Thread to async the move of server files.
                    new Thread(() =>
                    {
                        //Start progressbar
                        Invoke(new Action(() =>
                        {
                            InstalledServerList.SelectedIndex = -1;
                            workInProgress = true;
                        }));

                        try
                        {
                            //Delete directory with all files.
                            try
                            {
                                Directory.Delete(settings.installedServer[server].installPath, true);
                            }
                            catch (PathTooLongException x) { MessageBox.Show(x.Message); }
                            catch (DirectoryNotFoundException x) { MessageBox.Show(x.Message); }
                            catch (IOException x) { MessageBox.Show(x.Message); }
                            catch (UnauthorizedAccessException x) { MessageBox.Show(x.Message); }
                            catch (ArgumentNullException x) { MessageBox.Show(x.Message); }
                            catch (ArgumentException x) { MessageBox.Show(x.Message); }

                            settings.installedServer.RemoveAt(server);
                        }
                        catch (ArgumentNullException x) { MessageBox.Show(x.Message); }
                        catch (PathTooLongException x) { MessageBox.Show(x.Message); }
                        catch (DirectoryNotFoundException x) { MessageBox.Show(x.Message); }
                        catch (IOException x) { MessageBox.Show(x.Message); }
                        catch (UnauthorizedAccessException x) { MessageBox.Show(x.Message); }
                        catch (ArgumentException x) { MessageBox.Show(x.Message); }

                        //Stop progressbar, modify button, save new settings and lastly, refresh list.
                        Invoke(new Action(() =>
                        {
                            Core.SaveSettings(settings);

                            UpdateInstalledServersInfo();

                            workInProgress = false;
                        }));
                    }).Start();
                }
            }
        }

        /// <summary>
        /// Google query search for selected game regarding server setup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageGuide_Button_Click(object sender, EventArgs e)
        {
            int server = Manage_FindServer();

            if (server != -1 && settings.installedServer[server] != null)
            {
                string query = settings.installedServer[server].name.Replace(' ', '+');
                Process.Start("https://www.google.com/search?q=" + query + "+server+setup");
            }
            else
            {
                MessageBox.Show("There was an error loading data from selection. Please try again.", "Error Getting Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Manage Servers

        #region Portscan

        /// <summary>
        /// Set UI data with port-scan information
        /// </summary>
        /// <param name="result"></param>
        public void SetIP(PortScanIP_Result result)
        {
            ipData = result;
            PortScan_IP.Text = $"Your IP: {result.IP}";
        }

        /// <summary>
        /// Send request to check UDP/TCP results on ports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PortScanSend_Button_Click(object sender, EventArgs e)
        {
            PortScanSend_Button.Enabled = false;
            PortScanSend_Button.Visible = false;
            PortScanLoading_PictureBox.Enabled = true;
            PortScanLoading_PictureBox.Visible = true;

            ipData = await PortScanHelper.GetPortScanAsync(ipData.IP, Port_Numeric.Value.ToString());
            PortResult_Label.Text = $"{ipData.TCP}{Environment.NewLine}{ipData.UDP}";

            PortScanLoading_PictureBox.Visible = false;
            PortScanLoading_PictureBox.Enabled = false;
            PortScanSend_Button.Enabled = true;
            PortScanSend_Button.Visible = true;
        }

        #endregion Portscan

        #region Settings
        /// <summary>
        /// Toggle visibility of password field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TogglePassword_Button_Click(object sender, EventArgs e)
        {
            if (PasswordField_Textbox.PasswordChar == '*') PasswordField_Textbox.PasswordChar = '\0';
            else PasswordField_Textbox.PasswordChar = '*';
        }

        /// <summary>
        /// Save settings logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSettings_Button_Click(object sender, EventArgs e)
        {
            workInProgress = true;

            if (UsernameField_Textbox.Text != "" && PasswordField_Textbox.Text != "")
            {
                settings.userData = new UserData();
                settings.userData.SetUsername(UsernameField_Textbox.Text);
                settings.userData.SetPassword(PasswordField_Textbox.Text);
            }

            settings.useAnonymousAuth = Anon_Radio.Checked;

            settings.validate = Validate_Checkbox.Checked;
            settings.autoClose = AutoClose_Checkbox.Checked;
            settings.CheckUpdates = CheckForUpdates_Checkbox.Checked;
            settings.allowAutoUpdate = AllowUpdater_Checkbox.Checked;
            settings.wrapSteamCMD = WrapSteamCMD_Checkbox.Checked;

            settings.steamCMD_installLocation = SteamCMD_SettingsInstallLocation_Textbox.Text;

            Core.SaveSettings(settings);
            workInProgress = false;
        }

        /// <summary>
        /// Check for updates button logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CheckUpdates_Button_Click(object sender, EventArgs e)
        {
            // Work in progress only works if repo is public
            workInProgress = true;
            App_ProgressBar.Visible = true;
            await Core.CheckForUpdatesAsync(this, true);
            SetNewVersionStatus(Core.updateAvailable, Core.newUpdateVersion);
            App_ProgressBar.Visible = false;
            workInProgress = false;
        }

        /// <summary>
        /// Open up AboutForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Information_Button_Click(object sender, EventArgs e)
        {
            using (AboutForm f = new AboutForm())
            {
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Reset settings data and overwrite the old data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ResetSettings_Button_Click(object sender, EventArgs e)
        {
            settings = null;
            GC.Collect();

            settings = new Settings();
            Core.SaveSettings(settings);

            MessageBox.Show("Settings reset was successful.", "Reset result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Set default values to labels and fields
            ClearDefaultNSetup();

            Console.Clear();
            await InitializeAsyncStart();
        }

        #endregion Settings

        #region Console

        /// <summary>
        /// Update console when new text is added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Console_TextChanged(object sender, EventArgs e)
        {
            if (ConsoleAutoScroll_checkbox.Checked)
            {
                Console.SelectionStart = Console.Text.Length;
                Console.ScrollToCaret();
            }
        }

        /// <summary>
        /// Autoscroll setting changer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsoleAutoScroll_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.AutoScroll = ConsoleAutoScroll_checkbox.Checked;

            Core.SaveSettings(settings);
        }

        #endregion Console

        #region One-line Buttons
        private void WrapSteamCMD_Checkbox_CheckedChanged(object sender, EventArgs e) => settings.wrapSteamCMD = WrapSteamCMD_Checkbox.Checked;
        private void PanelConsole_button_MouseEnter(object sender, EventArgs e) => UIHandler.Label_MouseHover(sender, e);
        private void PanelConsole_button_MouseLeave(object sender, EventArgs e) => UIHandler.Label_MouseLeave(sender, e);
        public void PanelConsole_button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(sender, UIHandler.Panel.Console, this);
        private void AllowUpdater_Checkbox_CheckedChanged(object sender, EventArgs e) => settings.allowAutoUpdate = AllowUpdater_Checkbox.Checked;
        private void CheckForUpdates_Checkbox_CheckedChanged(object sender, EventArgs e) => settings.CheckUpdates = CheckForUpdates_Checkbox.Checked;
        private void Anon_Radio_CheckedChanged(object sender, EventArgs e) => settings.useAnonymousAuth = Anon_Radio.Checked;
        private void Validate_Checkbox_CheckedChanged(object sender, EventArgs e) => settings.validate = Validate_Checkbox.Checked;
        private void AutoClose_Checkbox_CheckedChanged(object sender, EventArgs e) => settings.autoClose = AutoClose_Checkbox.Checked;
        private void NewServerInstallLocation_Button_Click(object sender, EventArgs e) => NewServerInstallLocation_Textbox.Text = Core.SelectFolder();
        private async void RefreshAPI_Button_Click(object sender, EventArgs e) => await RefreshAPIData();
        private void ManageServers_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(sender, UIHandler.Panel.ManageServers, this);
        private void Settings_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(null, UIHandler.Panel.Settings, this);
        private void SteamCMD_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(sender, UIHandler.Panel.SteamCMD, this);
        private void NewServer_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(sender, UIHandler.Panel.NewServer, this);
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
        private void Close_Button_Click(object sender, EventArgs e) => CloseApplication();
        private void Minimize_Button_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);
        private void PortScan_Button_Click(object sender, EventArgs e) => UIHandler.ChangePanel(sender, UIHandler.Panel.PortScan, this);
        private void PortScan_Button_MouseEnter(object sender, EventArgs e) => UIHandler.Label_MouseHover(sender, e);
        private void PortScan_Button_MouseLeave(object sender, EventArgs e) => UIHandler.Label_MouseLeave(sender, e);
        #endregion One-line buttons

        private void Setup_Button_Click(object sender, EventArgs e)
        {
            if (InstalledServerList.SelectedIndex != -1)
            {
                InstalledServer server = null;

                foreach (var item in settings.installedServer)
                {
                    if (item.name == (string)InstalledServerList.SelectedItem)
                    {
                        server = item;
                        break;
                    }
                }

                if (server != null)
                {
                    using (CS16_Config configManager = new CS16_Config(server))
                    {
                        configManager.ShowDialog();
                        GC.Collect();
                    }
                }
            }
        }
    }
}
