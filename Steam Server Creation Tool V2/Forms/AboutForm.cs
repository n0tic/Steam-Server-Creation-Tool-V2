using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            Version_Label.Text = $"Version {Core.GetVersion()}";
            AppName_Label.Text = $"Application: {Core.softwareName} ({Core.softwareNameShort})";
            Author_Label.Text = $"Author: {Core.authorName} ({Core.authorRealName})";
            Discord_Label.Text = $"Discord: {Core.discordCommunity}";
            ProjectURL_Label.Text = $"Project URL: {Core.projectURL}";
        }

        private void Close_Button_Click(object sender, EventArgs e) => Close();
        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);
        private void Donate_Button_Click(object sender, EventArgs e) => Process.Start(Core.donateURL);
        private void Discord_Label_Click(object sender, EventArgs e) => Process.Start(Core.discordCommunity);
        private void ProjectURL_Label_Click(object sender, EventArgs e) => Process.Start(Core.projectURL);
    }
}
