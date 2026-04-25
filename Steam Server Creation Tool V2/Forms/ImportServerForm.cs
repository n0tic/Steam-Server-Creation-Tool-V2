using Steam_Server_Creation_Tool_V2.Handlers.SteamAPI;
using Steam_Server_Creation_Tool_V2.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace Steam_Server_Creation_Tool_V2.Forms
{
    public partial class ImportServerForm : Form
    {
        private MainForm mainForm = null;

        private List<SteamServerEntry> _foundEntries = new List<SteamServerEntry>();
        private List<InstalledServer> _serversToHandle = new List<InstalledServer>();

        private int handleIndex = 0;

        public ImportServerForm(MainForm form)
        {
            InitializeComponent();

            this.mainForm = form;

            Manual_Box.Location = new Point(8, 131);
            Auto_Box.Location = new Point(8, 131);
            Auto_Step2.Location = new Point(8, 131);
        }

        private void Close_Button_Click(object sender, EventArgs e) => Close();
        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);

        private void Radio_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if(Radio_Manual.Checked)
            {
                Manual_Box.Visible = true;
                Manual_Box.Enabled = true;
                Auto_Box.Visible = false;
                Auto_Box.Enabled = false;
                Auto_Step2.Enabled = false;
                Auto_Step2.Visible = false;
            }
            else
            {
                Manual_Box.Visible = false;
                Manual_Box.Enabled = false;
                Auto_Box.Visible = true;
                Auto_Box.Enabled = true;
                Auto_Step2.Enabled = false;
                Auto_Step2.Visible = false;
            }
        }

        private void AutoImportSelectLocationButton_Click(object sender, EventArgs e)
        {
            _foundEntries.Clear();
            GC.Collect();

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select root folder to scan (SteamCMD or servers folder)";
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                _foundEntries = SteamServerScanner.Scan(dialog.SelectedPath);

                checkedListBoxManifests.Items.Clear();

                foreach (var s in _foundEntries)
                {
                    checkedListBoxManifests.Items.Add(s, true);
                }
            }
        }

        private bool CanImportServer(string name, string installPath)
        {
            if (mainForm.settings == null || mainForm.settings.installedServer == null)
                return false;

            foreach (InstalledServer server in mainForm.settings.installedServer)
            {
                if (string.Equals(server.name, name, StringComparison.OrdinalIgnoreCase))
                    return false;

                if (string.Equals(server.installPath, installPath, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }

        private bool CheckNewName(string name)
        {
            if (mainForm.settings == null || mainForm.settings.installedServer == null)
                return false;

            foreach (InstalledServer server in mainForm.settings.installedServer)
            {
                if (string.Equals(server.name, name, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }

        private void AutoImportEditSelectionsButton_Click(object sender, EventArgs e)
        {
            _serversToHandle = new List<InstalledServer>();
            GC.Collect();
            List<SteamServerEntry> selectedServers = SteamServerScanner.GetCheckedSteamServerEntries(checkedListBoxManifests);

            if (selectedServers.Count == 0)
            {
                MessageBox.Show("No servers selected.");
                return;
            }

            int importedCount = 0;
            int skippedCount = 0;

            foreach (SteamServerEntry server in selectedServers)
            {
                string name = "AppID " + server.AppId; // fallback name
                string installPath = server.InstallPath;

                if (!CanImportServer(name, installPath))
                {
                    skippedCount++;
                    MessageBox.Show("Selected server cannot be imported. It seems to already be registered.");
                    continue;
                }

                App app = new App();
                app.Name = "Imported, Not verified!";
                app.AppId = (uint)server.AppId;

                InstalledServer installedServer = new InstalledServer(name, installPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), app);

                _serversToHandle.Add(installedServer);
                importedCount++;
            }

            if(importedCount > 0 && _serversToHandle.Count > 0)
            {
                Auto_Step2.Text = $"Auto Import - Fix references {handleIndex + 1}/{_serversToHandle.Count}";

                Step2_ServerName_Textbox.Text = _serversToHandle[handleIndex].name;
                Step2_InstallDirLabel.Text = _serversToHandle[handleIndex].installPath;

                Auto_Box.Enabled = false;
                Auto_Box.Visible = false;
                Auto_Step2.Enabled = true;
                Auto_Step2.Visible = true;
            }
        }

        private void Step2_NextButton_Click(object sender, EventArgs e)
        {
            string newName = Step2_ServerName_Textbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Server name cannot be empty.");
                return;
            }

            if (!CheckNewName(newName))
            {
                MessageBox.Show("Name or install path already exists.");
                return;
            }

            if(MessageBox.Show($"Save name '{newName}' for server at '{_serversToHandle[handleIndex].installPath}'?", "Confirm name", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            // Save current fix
            _serversToHandle[handleIndex].name = newName;

            // Move to next
            handleIndex++;

            // Done?
            if (handleIndex >= _serversToHandle.Count)
            {
                foreach (var handle in _serversToHandle)
                {
                    mainForm.settings.installedServer.Add(handle);
                }

                Core.SaveSettings(mainForm.settings);

                MessageBox.Show($"All imports completed successfully.", "Import completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                mainForm.UpdateInstalledServersInfo();

                this.Close();

                return;
            }

            // Load next item
            Auto_Step2.Text = $"Auto Import - Fix references {handleIndex + 1}/{_serversToHandle.Count}";

            Step2_ServerName_Textbox.Text = _serversToHandle[handleIndex].name;
            Step2_InstallDirLabel.Text = _serversToHandle[handleIndex].installPath;
        }

        private void Manual_SelectLocationButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select server root folder to add";
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                Manual_InstallDirTextbox.Text = dialog.SelectedPath;
            }
        }

        private void Manual_ImportButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"You are about to import a manual server. SSCTV2 will not verify information and if the information you have entered is not correct it may completely destroy your server files. Would you like to continue?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(Manual_NameTextbox.Text))
            {
                MessageBox.Show("Server name cannot be empty.");
                return;
            }

            if (!CheckNewName(Manual_NameTextbox.Text))
            {
                MessageBox.Show("Name already exists. Name must be unique.");
                return;
            }

            if (!CanImportServer(Manual_NameTextbox.Text, Manual_InstallDirTextbox.Text))
            {
                MessageBox.Show("Server name and path must be unique. Cannot import current settings.");
                return;
            }

            if(!Directory.Exists(Manual_InstallDirTextbox.Text))
            {
                MessageBox.Show("Cannot find the specific install location directory.");
                return;
            }

            App app = new App();
            app.Name = "Imported, Not verified!";
            app.AppId = (uint)Manual_AppID_num.Value;

            InstalledServer installedServer = new InstalledServer(Manual_NameTextbox.Text, Manual_InstallDirTextbox.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), app);

            mainForm.settings.installedServer.Add(installedServer);

            Core.SaveSettings(mainForm.settings);

            MessageBox.Show($"Import completed successfully.", "Import completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            mainForm.UpdateInstalledServersInfo();

            this.Close();
        }
    }
}