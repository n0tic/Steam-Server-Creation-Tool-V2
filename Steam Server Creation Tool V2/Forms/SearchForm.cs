using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Steam_Server_Creation_Tool_V2.Forms
{
    public partial class SearchForm : Form
    {
        MainForm mainForm;

        public SearchForm(MainForm form)
        {
            InitializeComponent();

            this.mainForm = form;
        }
        private void SearchForm_Load(object sender, EventArgs e)
        {
            foreach (var item in mainForm.SteamList.AppList.Apps)
            {
                SearchServerList_Listbox.Items.Add(item.IdAppName);
            }

            Search_Textbox.Select();
            Search_Textbox.Focus();
        }

        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);

        private void Close_Button_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void Search_Textbox_TextChanged(object sender, EventArgs e)
        {
            SearchServerList_Listbox.Items.Clear();

            List<string> results = new List<string>();

            foreach (var item in mainForm.SteamList.AppList.Apps)
            {
                if (Core.Contains(item.IdAppName, Search_Textbox.Text, StringComparison.OrdinalIgnoreCase)) results.Add(item.IdAppName);
            }

            foreach (var item in results)
            {
                SearchServerList_Listbox.Items.Add(item);
            }
        }

        private void SearchServerList_Listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the SearchServerList_Listbox
            string selectedServer = SearchServerList_Listbox.SelectedItem?.ToString();

            // Find the corresponding item in NewInstall_combobox
            int index = mainForm.NewInstall_Dropbox.FindStringExact(selectedServer);

            // Set the selection in NewInstall_combobox
            if (index != -1)
            {
                mainForm.NewInstall_Dropbox.SelectedIndex = index;
            }
        }

        private void SetSelectedItem_Button_Click(object sender, EventArgs e)
        {
            // Get the selected item from the SearchServerList_Listbox
            string selectedServer = SearchServerList_Listbox.SelectedItem?.ToString();

            // Find the corresponding item in NewInstall_combobox
            int index = mainForm.NewInstall_Dropbox.FindStringExact(selectedServer);

            // Set the selection in NewInstall_combobox
            if (index != -1)
            {
                mainForm.NewInstall_Dropbox.SelectedIndex = index;
            }

            Close();
        }

        private void SearchServerList_Listbox_KeyUp(object sender, KeyEventArgs e)
        {
            // Check if Enter key is pressed and there is only one item in the ListBox
            if (e.KeyCode == Keys.Enter && SearchServerList_Listbox.Items.Count == 1)
            {
                // Prevent the default button press sound
                e.Handled = true;

                SearchServerList_Listbox.SelectedIndex = 0;

                SetSelectedItem_Button_Click(null, null);
            }
        }

        private void Search_Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && SearchServerList_Listbox.Items.Count == 1)
            {
                // Prevent the default button press sound
                e.Handled = true;

                SearchServerList_Listbox.SelectedIndex = 0;

                SetSelectedItem_Button_Click(null, null);
            }
        }
    }
}
