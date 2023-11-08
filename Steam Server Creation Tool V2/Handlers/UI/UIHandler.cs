using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    static class UIHandler
    {
        static List<System.Windows.Forms.Panel> panels = new List<System.Windows.Forms.Panel>();

        public enum Panel
        {
            SteamCMD = 0,
            NewServer = 1,
            ManageServers = 2,
            Settings = 3
        }

        public static void Setup(MainForm form)
        {
            panels.Add(form.Panel_SteamCMD);
            panels.Add(form.Panel_NewServer);
            panels.Add(form.Panel_ManageServers);
            panels.Add(form.Panel_Settings);
        }

        public static void ChangePanel(Panel panel)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                if (i == (int)panel)
                {
                    panels[i].Enabled = true;
                    panels[i].Visible = true;
                }
                else
                {
                    panels[i].Enabled = false;
                    panels[i].Visible = false;
                }
            }
        }

        public static void Label_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label) { label.Font = new Font(label.Font, label.Font.Style | FontStyle.Underline); }
        }

        public static void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label) { label.Font = new Font(label.Font, label.Font.Style & ~FontStyle.Underline); }
        }
    }
}
