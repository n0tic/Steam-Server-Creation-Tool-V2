using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    /// <summary>
    /// Helper class to run SteamCMD and control the system integration
    /// </summary>
    internal class SteamCMDHelper
    {
        private static bool failed = false;

        public enum InstallationType
        {
            NewInstall,
            Update
        }

        /// <summary>
        /// Controls the SteamCMD process with arguments and system integration features
        /// </summary>
        /// <param name="form"></param>
        /// <param name="app"></param>
        /// <param name="installName"></param>
        /// <param name="installDir"></param>
        /// <param name="steamCMD_type"></param>
        /// <returns></returns>
        internal static async Task RunSteamCMD(MainForm form, App app, string installName, string installDir, InstallationType steamCMD_type = InstallationType.NewInstall)
        {
            if (form.settings.wrapSteamCMD) form.PanelConsole_button_Click(null, null);

            //Keep track of success
            bool install = true;
            failed = false; // Reset bug fix

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

                    if (form.settings.wrapSteamCMD)
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
                                    install = CheckForSpecificLines(e.Data, form);
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
                                    install = CheckForSpecificLines(e.Data, form);
                                });
                            }
                        };
                    }

                    // Try starting the process
                    try
                    {
                        process.Start();
                        if (form.settings.wrapSteamCMD)
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
                    if (!failed && install && steamCMD_type == InstallationType.NewInstall)
                    {
                        string startScript = Properties.Resources.StartServerScript_bat;
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

        /// <summary>
        /// Create process for SteamCMD based on user settings
        /// </summary>
        /// <param name="wrapSteamCMD"></param>
        /// <param name="form"></param>
        /// <param name="installDir"></param>
        /// <param name="login"></param>
        /// <param name="appID"></param>
        /// <param name="validated"></param>
        /// <param name="quit"></param>
        /// <returns></returns>
        private static Process CreateProcess(bool wrapSteamCMD, MainForm form, string installDir, string login, string appID, string validated, string quit)
        {
            Process process = null;

            if (wrapSteamCMD)
            {
                process = new Process()
                {
                    StartInfo = {
                        FileName = form.settings.steamCMD_installLocation,
                        Arguments = $"+force_install_dir \"{installDir}\" +login " + login + " +app_update " + appID + " " + validated + " +quit",
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };
            }
            else
            {
                process = new Process()
                {
                    StartInfo = {
                        UseShellExecute = false,
                        FileName = form.settings.steamCMD_installLocation,
                        Arguments = $"+force_install_dir \"{installDir}\" +login " + login + " +app_update " + appID + " " + validated + quit // Building argument string
                    }
                };

            }

            return process;
        }

        /// <summary>
        /// SteamCMD integration/Wrap controlling the software and its response to SteamCMD output/behaviour
        /// </summary>
        /// <param name="line"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private static bool CheckForSpecificLines(string line, MainForm form = null)
        {
            // Use Regex to match the patterns of the success and error messages
            Regex message = new Regex(@"Waiting for client config...OK");
            Regex successRegex = new Regex(@"Success! App '\d+' fully installed.");
            Regex errorRegex = new Regex(@"Error! App '\d+' state is 0x[0-9A-Fa-f]+ after update job.");
            Regex errorOwnCopy = new Regex(@"ERROR! Failed to install app '(\d+)' \(No subscription\)");

            if (successRegex.IsMatch(line))
            {
                // Take action based on the specific line
                // For example, update UI or log the information

                //Console.WriteLine($"Found success line: {line}");

                return true;
            }
            else if (errorOwnCopy.IsMatch(line))
            {
                MessageBox.Show($"'No subscription' error occured!{Environment.NewLine}{Environment.NewLine}The server you are trying to install either requires a login or that you have purchased the game. You will therefore have to log in with a Steam username and password. You can do this in the application settings panel.", "Subscription required!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                failed = true;
                return false;
            }
            else if (errorRegex.IsMatch(line))
            {
                // Take action based on the specific line
                // For example, update UI or log the information

                MessageBox.Show($"Something went wrong during installation. Please read console content for more information.", "Error during installation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                failed = true;
                return false;
            }
            else if (message.IsMatch(line))
            {
                // Take action based on the specific line
                // For example, update UI or log the information

                form.console.AddMessage($"Please wait while SteamCMD is installing the server...{Environment.NewLine}");
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
