namespace Steam_Server_Creation_Tool_V2.Forms
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AppNameLabel = new System.Windows.Forms.Label();
            this.MovePanel = new System.Windows.Forms.Panel();
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.SearchServerList_Listbox = new System.Windows.Forms.ListBox();
            this.Search_Textbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SetSelectedItem_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            this.MovePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.TopPanel.Controls.Add(this.panel1);
            this.TopPanel.Controls.Add(this.AppNameLabel);
            this.TopPanel.Controls.Add(this.MovePanel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(362, 68);
            this.TopPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel1.Location = new System.Drawing.Point(-10, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 10);
            this.panel1.TabIndex = 30;
            // 
            // AppNameLabel
            // 
            this.AppNameLabel.AutoSize = true;
            this.AppNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.AppNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppNameLabel.ForeColor = System.Drawing.Color.White;
            this.AppNameLabel.Location = new System.Drawing.Point(3, 29);
            this.AppNameLabel.Name = "AppNameLabel";
            this.AppNameLabel.Size = new System.Drawing.Size(226, 29);
            this.AppNameLabel.TabIndex = 9;
            this.AppNameLabel.Text = "Search For Server";
            // 
            // MovePanel
            // 
            this.MovePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.MovePanel.Controls.Add(this.Close_Button);
            this.MovePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MovePanel.Location = new System.Drawing.Point(0, 0);
            this.MovePanel.Name = "MovePanel";
            this.MovePanel.Size = new System.Drawing.Size(362, 23);
            this.MovePanel.TabIndex = 10;
            this.MovePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseDown);
            // 
            // Close_Button
            // 
            this.Close_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_Button.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources.close;
            this.Close_Button.Location = new System.Drawing.Point(341, 3);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(18, 18);
            this.Close_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // SearchServerList_Listbox
            // 
            this.SearchServerList_Listbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.SearchServerList_Listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchServerList_Listbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SearchServerList_Listbox.FormattingEnabled = true;
            this.SearchServerList_Listbox.Location = new System.Drawing.Point(12, 116);
            this.SearchServerList_Listbox.Name = "SearchServerList_Listbox";
            this.SearchServerList_Listbox.ScrollAlwaysVisible = true;
            this.SearchServerList_Listbox.Size = new System.Drawing.Size(338, 199);
            this.SearchServerList_Listbox.TabIndex = 16;
            this.SearchServerList_Listbox.SelectedIndexChanged += new System.EventHandler(this.SearchServerList_Listbox_SelectedIndexChanged);
            this.SearchServerList_Listbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchServerList_Listbox_KeyUp);
            // 
            // Search_Textbox
            // 
            this.Search_Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.Search_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Textbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Search_Textbox.Location = new System.Drawing.Point(12, 90);
            this.Search_Textbox.Name = "Search_Textbox";
            this.Search_Textbox.Size = new System.Drawing.Size(338, 20);
            this.Search_Textbox.TabIndex = 27;
            this.Search_Textbox.TextChanged += new System.EventHandler(this.Search_Textbox_TextChanged);
            this.Search_Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Search_Textbox_KeyPress);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(9, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(338, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "Searchfield";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetSelectedItem_Button
            // 
            this.SetSelectedItem_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.SetSelectedItem_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetSelectedItem_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SetSelectedItem_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetSelectedItem_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetSelectedItem_Button.ForeColor = System.Drawing.Color.White;
            this.SetSelectedItem_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SetSelectedItem_Button.Location = new System.Drawing.Point(12, 321);
            this.SetSelectedItem_Button.Name = "SetSelectedItem_Button";
            this.SetSelectedItem_Button.Size = new System.Drawing.Size(338, 24);
            this.SetSelectedItem_Button.TabIndex = 29;
            this.SetSelectedItem_Button.Text = "Set Selected Item";
            this.SetSelectedItem_Button.UseVisualStyleBackColor = false;
            this.SetSelectedItem_Button.Click += new System.EventHandler(this.SetSelectedItem_Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel2.Location = new System.Drawing.Point(-8, 353);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 10);
            this.panel2.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel3.Location = new System.Drawing.Point(360, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 386);
            this.panel3.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel4.Location = new System.Drawing.Point(-8, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 386);
            this.panel4.TabIndex = 33;
            // 
            // SearchForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(362, 355);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.SetSelectedItem_Button);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Search_Textbox);
            this.Controls.Add(this.SearchServerList_Listbox);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.MovePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label AppNameLabel;
        private System.Windows.Forms.Panel MovePanel;
        private System.Windows.Forms.PictureBox Close_Button;
        private System.Windows.Forms.ListBox SearchServerList_Listbox;
        private System.Windows.Forms.TextBox Search_Textbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button SetSelectedItem_Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}