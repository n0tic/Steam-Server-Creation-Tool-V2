using System;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2.Forms
{
    public partial class CS16_Config : Form
    {
        public CS16_Config()
        {
            InitializeComponent();
        }

        private void Close_Button_Click(object sender, EventArgs e) => Close();
        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);

        private void CS16_Config_Load(object sender, EventArgs e)
        {
            sv_rcon_banpenalty_combobox.SelectedIndex = 0;
            sv_rcon_minfaliuretime_combobox.SelectedIndex = 5;
        }

        private void ConfigBase_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ConfigBase_combobox.SelectedIndex == 0)
            {

            }
            else if (ConfigBase_combobox.SelectedIndex == 0)
            {

            }
            else
            {

            }
        }
    }
}
