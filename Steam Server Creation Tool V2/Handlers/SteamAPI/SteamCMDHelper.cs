using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    public enum InstallationType
    {
        NewInstall,
        Update
    }

    internal class SteamCMDHelper
    {
        internal static async Task StartNewDownload(MainForm form, App app, string installName, string installDir, InstallationType steamCMD_type = InstallationType.NewInstall)
        {
            //Keep track of success
            bool install = true;

            //This needs no explanation, no? It simply updates data with provided defaults if new install
            string validated = "";
            if (form.settings.validate) validated = "validate ";
            else validated = "";

            string appID = app.AppId.ToString();

            string login = form.settings.GetLogin();
            if (login == null) if (MessageBox.Show("Login information has failed validation.\n\rContinue with anonymous download?", "Login Information Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) return;

            string quit = "";
            if (form.settings.autoClose) quit = "+quit";
            else quit = "";

            // Start a new thread with the installation as async using user input
            await Task.Run(() =>
            {
                // Initiating process
                using (Process process = new Process
                {
                    // Setting startinfo
                    StartInfo =
                    {
                        UseShellExecute = false,
                        FileName = form.settings.steamCMD_installLocation,
                        Arguments = $"+force_install_dir \"{installDir}\" +login " + login + " +app_update " + appID + " " + validated + quit // Building argument string
                    }
                })
                {
                    // Try starting the process
                    try
                    {
                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        install = false;
                    }

                    // Wait for process to stop, if it exists.
                    try
                    {
                        process?.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        install = false;
                    }
                    
                    // Register installation if new and save settings.
                    if (install && steamCMD_type == InstallationType.NewInstall)
                    {
                        string startScript = Properties.Resources.StartServerScript_txt;
                        startScript = startScript.Replace("{steamcmd_dir}", $"\"{Path.GetDirectoryName(form.settings.steamCMD_installLocation)}\"")
                            .Replace("{server_dir}", installDir)
                           .Replace("{app_id}", appID)
                           .Replace("{app_name}", app.Name)
                           .Replace("{login_cred}", form.settings.GetLogin());

                        Core.SaveToFile(installDir + @"\StartServerScript.bat", startScript);

                        form.settings.installedServer.Add(new InstalledServer(installName, installDir, DateTime.Now.ToString("dd/MM/yyyy HH:mm"), app));
                        Core.SaveSettings(form.settings);
                    }

                    System.Media.SystemSounds.Exclamation.Play();
                }
            });
        }
    }
}
