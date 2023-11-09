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
    internal class SteamCMDHelper
    {
        internal static void StartNewDownload(MainForm form, App app, string installName, string installDir)
        {
            //Keep track of success
            bool install = true;

            //This needs no explanation, no? It simply updates data with provided defaults if new install
            string validated = "";
            if (form.settings.validate) validated = "validate ";
            else validated = "";

            string appID = app.AppId.ToString();

            string login = form.settings.GetLogin();
            if (string.IsNullOrEmpty(login)) if (MessageBox.Show("Login information has failed validation.\n\rContinue with anonymous download?", "Login Information Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) return;

            string quit = "";
            if (form.settings.autoQuit) quit = "+quit";
            else quit = "";

            // Start a new thread with the installation as async using user input
            new Thread(() =>
            {
                //Initiating process
                using (Process process = new Process
                {
                    //Setting startinfo
                    StartInfo =
                        {
                            UseShellExecute = false,
                            FileName = form.settings.steamCMD_installLocation,
                            Arguments = $"+force_install_dir \"{installDir}\" +login " + login + " +app_update " + appID + " " + validated + quit // Building argument string
                        }
                })
                {
                    //Try starting the process
                    try
                    {
                        process.Start();
                    }
                    catch (ObjectDisposedException x) { MessageBox.Show(x.Message); install = false; }
                    catch (InvalidOperationException x) { MessageBox.Show(x.Message); install = false; }
                    catch (Win32Exception x) { MessageBox.Show(x.Message); install = false; }

                    //Wait for process to stop, if it exists.
                    try
                    {
                        process?.WaitForExit();
                    }
                    catch (Win32Exception x) { MessageBox.Show(x.Message); install = false; }
                    catch (OutOfMemoryException x) { MessageBox.Show(x.Message); install = false; }
                    catch (IOException x) { MessageBox.Show(x.Message); install = false; }
                    catch (SystemException x) { MessageBox.Show(x.Message); install = false; }

                    // Register installation if new and save settings.
                    if (install)
                    {
                        string startScript = Properties.Resources.StartServerScript_txt;
                        startScript = startScript.Replace("{steamcmd_dir}", "\"" + Path.GetDirectoryName(form.settings.steamCMD_installLocation) + "\"");
                        startScript = startScript.Replace("{server_dir}", installDir);
                        startScript = startScript.Replace("{app_id}", appID);
                        startScript = startScript.Replace("{app_name}", app.Name);
                        startScript = startScript.Replace("{login_cred}", form.settings.GetLogin());

                        Core.SaveToFile(installDir + @"\StartServerScript.bat", startScript);

                        form.settings.installedServer.Add(new InstalledServer(installName, installDir, DateTime.Now.ToString("dd/MM/yyyy HH:mm"), app));
                        Core.SaveSettings(form.settings);

                        System.Media.SystemSounds.Exclamation.Play();
                    }
                }
            }).Start();
        }
    }
}
