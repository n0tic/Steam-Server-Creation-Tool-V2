using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Server_Creation_Tool_V2
{
    public class ConsoleHandler
    {
        MainForm form;

        public ConsoleHandler(MainForm form) 
        { 
            this.form = form;

            AddMessage($"{Core.softwareName} {Core.GetVersion()} has been initialized...", false);
        }

        public void AddMessage(string message, bool append = true)
        {
            if(append)
                form.Console.AppendText($"{Environment.NewLine}[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}] {message}");
            else
                form.Console.AppendText($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}] {message}");
        }
    }
}
