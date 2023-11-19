using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (form.settings.wrapSteamCMD) form.PanelConsole_button_Click(null, null);

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
                Process process = CreateProcess(form.settings.wrapSteamCMD, form, installDir, login, appID, validated, quit);

                // Initiating process
                using (process)
                {

                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            // Update the RichTextBox in the UI thread
                            form.Invoke((MethodInvoker)delegate
                            {
                                form.console.AddMessage(e.Data + Environment.NewLine);

                                // Check for specific lines using Regex
                                CheckForSpecificLines(e.Data, form);
                            });
                        }
                    };

                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            // Update the RichTextBox in the UI thread
                            form.Invoke((MethodInvoker)delegate
                            {
                                form.console.AddMessage($"Error: {e.Data}" + Environment.NewLine);

                                // Check for specific lines using Regex
                                CheckForSpecificLines(e.Data, form);
                            });
                        }
                    };

                    // Try starting the process
                    try
                    {
                        process.Start();
                        if(form.settings.wrapSteamCMD)
                        {
                            process.BeginOutputReadLine();
                            process.BeginErrorReadLine();
                        }
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
                        startScript = startScript
                            .Replace("{steamcmd_dir}", $"\"{Path.GetDirectoryName(form.settings.steamCMD_installLocation)}\"")
                            .Replace("{server_dir}", installDir)
                            .Replace("{app_id}", appID)
                            .Replace("{app_name}", app.Name)
                            .Replace("{login_cred}", form.settings.GetLogin());

                        Core.SaveToFile(installDir + @"\StartServerScript.bat", startScript);

                        form.settings.installedServer.Add(new InstalledServer(installName, installDir, DateTime.Now.ToString("dd/MM/yyyy HH:mm"), app));
                        Core.SaveSettings(form.settings);
                    }

                    // Update the RichTextBox in the UI thread
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.console.AddMessage($"SteamCMD has completed the task!");
                    });

                    System.Media.SystemSounds.Exclamation.Play();
                }
            });
        }

        private static Process CreateProcess(bool wrapSteamCMD, MainForm form, string installDir, string login, string appID, string validated, string quit)
        {
            Process process = null;

            if(wrapSteamCMD) {
                process = new Process() {
                    StartInfo = {
                        FileName = form.settings.steamCMD_installLocation,
                        Arguments = $"+force_install_dir \"{installDir}\" +login " + login + " +app_update " + appID + " " + validated + quit,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };
            }
            else {
                process = new Process() {
                    StartInfo = {
                        UseShellExecute = false,
                        FileName = form.settings.steamCMD_installLocation,
                        Arguments = $"+force_install_dir \"{installDir}\" +login " + login + " +app_update " + appID + " " + validated + quit // Building argument string
                    }
                };
                
            }

            return process;
        }

        private static void CheckForSpecificLines(string line, MainForm form = null)
        {
            // Use Regex to match the patterns of the success and error messages
            Regex message = new Regex(@"Waiting for client config...OK");
            Regex successRegex = new Regex(@"Success! App '\d+' fully installed.");
            Regex errorRegex = new Regex(@"Error! App '\d+' state is 0x[0-9A-Fa-f]+ after update job.");

            if (successRegex.IsMatch(line))
            {
                // Take action based on the specific line
                // For example, update UI or log the information
                
                //Console.WriteLine($"Found success line: {line}");
            }
            else if (errorRegex.IsMatch(line))
            {
                // Take action based on the specific line
                // For example, update UI or log the information
                
                //Console.WriteLine($"Found error line: {line}");
            }
            else if (message.IsMatch(line))
            {
                // Take action based on the specific line
                // For example, update UI or log the information
                
                form.console.AddMessage($"Please wait while SteamCMD is installing the server...{Environment.NewLine}");
            }
        }
    }
}
