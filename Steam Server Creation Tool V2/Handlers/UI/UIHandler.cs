using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    public static class UIHandler
    {
        public static MainForm form;
        static List<System.Windows.Forms.Panel> panels = new List<System.Windows.Forms.Panel>();

        public enum Panel
        {
            SteamCMD = 0,
            NewServer = 1,
            ManageServers = 2,
            PortScan = 3,
            Settings = 4
        }

        public static void Setup(MainForm f)
        {
            form = f;
            panels.Add(form.Panel_SteamCMD);
            panels.Add(form.Panel_NewServer);
            panels.Add(form.Panel_ManageServers);
            panels.Add(form.Panel_PortScan);
            panels.Add(form.Panel_Settings);
        }

        public static async void ChangePanel(Panel panel, MainForm form, object label = null)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                if (i == (int)panel) panels[i].Visible = true;
                else panels[i].Visible = false;
            }

            switch ((int)panel)
            {
                case (int)Panel.SteamCMD:
                    form.Size = new Size(642, 327);
                    break;
                case (int)Panel.NewServer:
                    form.Size = new Size(642, 436);
                    if(!form.updateRecieved)
                    {
                        await form.RefreshAPIData();
                        form.updateRecieved = true;
                    }
                    break;
                case (int)Panel.ManageServers:
                    form.Size = new Size(642, 589);
                    break;
                case (int)Panel.PortScan:
                    form.Size = new Size(642, 225);
                    if (!form.hasIP)
                    {
                        PortScanIP_Result data = await PortScanHelper.GetIpAddressAsync();
                        form.SetIP(data);
                        form.hasIP = true;
                    }
                    break;
                case (int)Panel.Settings:
                    form.Size = new Size(642, 497);
                    break;
            }

            form.InstalledServerList.SelectedIndex = -1;
        }

        public static void Label_MouseHover(object sender, EventArgs e)
        {
            // TODO: Fix logic for this to stay upon selection
            if (sender is Label label) { label.Font = new Font(label.Font, label.Font.Style | FontStyle.Underline); }
        }

        public static void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label) 
            { 
                // TODO: Add visible selection on menu
                //if(!IsActive(label.Text))
                label.Font = new Font(label.Font, label.Font.Style & ~FontStyle.Underline); 
            }
        }
        /*
        private static bool IsActive(string labelText)
        {
            switch(labelText)
            {
                case "SteamCMD":
                    if (panels[(int)Panel.SteamCMD].Visible) return true;
                    break;
                case "New Server":
                    if (panels[(int)Panel.NewServer].Visible) return true;
                    break;
                case "Manage Servers":
                    if (panels[(int)Panel.ManageServers].Visible) return true;
                    break;
                case "Settings":
                    if (panels[(int)Panel.Settings].Visible) return true;
                    break;
                default: return false;
            }

            return false;
        }
        */
    }
}
