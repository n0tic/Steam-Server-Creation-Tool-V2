using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2
{
    static class UIHandler
    {
        public enum Panel
        {
            SteamCMD = 0,
            NewServer = 1,
            ManageServers = 2,
            Settings = 3
        }

        public enum ProgressType
        {
            Marquee,
            Blocks
        }

        static List<System.Windows.Forms.Panel> panels = new List<System.Windows.Forms.Panel> ();

        public static void Setup(MainForm form)
        {

        }

        public static void Label_MouseHover(object sender, EventArgs e) {
            if (sender is Label label) { label.Font = new Font(label.Font, label.Font.Style | FontStyle.Underline); }
        }

        public static void Label_MouseLeave(object sender, EventArgs e) {
            if (sender is Label label) { label.Font = new Font(label.Font, label.Font.Style & ~FontStyle.Underline); }
        }
    }
}
