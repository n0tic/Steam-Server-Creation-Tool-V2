using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Steam_Server_Creation_Tool_V2.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            Version_Label.Text = $"Version {Core.GetVersion()}";
        }

        private void Close_Button_Click(object sender, EventArgs e) => Close();
        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);
        private void Donate_Button_Click(object sender, EventArgs e) => Process.Start(Core.donateURL);
    }
}
