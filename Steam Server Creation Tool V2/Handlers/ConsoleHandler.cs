using System;

namespace Steam_Server_Creation_Tool_V2
{
    /// <summary>
    /// Console handler and controller
    /// </summary>
    public class ConsoleHandler
    {
        MainForm form;

        /// <summary>
        /// Initiator/Setup
        /// </summary>
        /// <param name="form"></param>
        public ConsoleHandler(MainForm form)
        {
            this.form = form;

            AddMessage($"{Core.softwareName} {Core.GetVersion()} has been initialized...", false);
        }

        /// <summary>
        /// Add message to the console with timestamp
        /// </summary>
        /// <param name="message"></param>
        /// <param name="append"></param>
        public void AddMessage(string message, bool append = true)
        {
            if (append)
                form.Console.AppendText($"{Environment.NewLine}[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}] {message}");
            else
                form.Console.AppendText($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}] {message}");
        }
    }
}
