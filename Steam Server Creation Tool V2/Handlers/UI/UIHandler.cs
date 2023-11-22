using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    /// <summary>
    /// UI Handler and helping tool
    /// </summary>
    public static class UIHandler
    {
        public static MainForm form;
        private static Label activeLabel = null;
        static List<System.Windows.Forms.Panel> panels = new List<System.Windows.Forms.Panel>();

        public enum Panel
        {
            SteamCMD = 0,
            NewServer = 1,
            ManageServers = 2,
            PortScan = 3,
            Console = 4,
            Settings = 5
        }

        public static void Setup(MainForm f)
        {
            form = f;
            panels.Add(form.Panel_SteamCMD);
            panels.Add(form.Panel_NewServer);
            panels.Add(form.Panel_ManageServers);
            panels.Add(form.Panel_PortScan);
            panels.Add(form.Panel_Console);
            panels.Add(form.Panel_Settings);
        }

        /// <summary>
        /// Change panel based on object clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="panel"></param>
        /// <param name="form"></param>
        public static async void ChangePanel(object sender, Panel panel, MainForm form)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                if (i == (int)panel) panels[i].Visible = true;
                else panels[i].Visible = false;
            }

            if (sender != null) // If a menu item was clicked (label)
            {
                if (activeLabel != null) Label_MouseLeave((object)activeLabel, null, true);
                SetActiveLabel((Label)sender, null);
            }
            else // If the picturebox was clicked
            {
                if (activeLabel != null) activeLabel.Font = new Font(activeLabel.Font, activeLabel.Font.Style & ~FontStyle.Underline);
            }

            switch ((int)panel)
            {
                case (int)Panel.SteamCMD:
                    form.Size = new Size(642, 327);
                    break;
                case (int)Panel.NewServer:
                    form.Size = new Size(642, 436);
                    if (!form.updateRecieved)
                    {
                        await form.RefreshAPIData();
                        form.updateRecieved = true;
                    }
                    break;
                case (int)Panel.ManageServers:
                    form.Size = new Size(642, 589);
                    break;
                case (int)Panel.Console:
                    form.Size = new Size(642, 460);
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

        /// <summary>
        /// Add underline to menu item which we hoover over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Label_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label) { label.Font = new Font(label.Font, label.Font.Style | FontStyle.Underline); }
        }

        /// <summary>
        /// Remove underline from menu item which we hoover over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="_override"></param>
        public static void Label_MouseLeave(object sender, EventArgs e, bool _override = false)
        {
            if (sender is Label label)
            {
                if (!_override) if (activeLabel.Name == label.Name) return;
                label.Font = new Font(label.Font, label.Font.Style & ~FontStyle.Underline);
            }
        }

        /// <summary>
        /// Switch to always underline to indicate active selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SetActiveLabel(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                activeLabel = label;
                label.Font = new Font(label.Font, label.Font.Style | FontStyle.Underline);
            }
        }
    }
}
