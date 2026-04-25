namespace Steam_Server_Creation_Tool_V2.Forms
{
    partial class ImportServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportServerForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AppNameLabel = new System.Windows.Forms.Label();
            this.MovePanel = new System.Windows.Forms.Panel();
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Radio_Manual = new System.Windows.Forms.RadioButton();
            this.Radio_Auto = new System.Windows.Forms.RadioButton();
            this.Manual_Box = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Manual_NameTextbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Manual_InstallDirTextbox = new System.Windows.Forms.TextBox();
            this.Manual_SelectLocationButton = new System.Windows.Forms.Button();
            this.Auto_Box = new System.Windows.Forms.GroupBox();
            this.AutoImportEditSelectionsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBoxManifests = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoImportSelectLocationButton = new System.Windows.Forms.Button();
            this.Auto_Step2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Step2_ServerName_Textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Step2_InstallDirLabel = new System.Windows.Forms.Label();
            this.Step2_NextButton = new System.Windows.Forms.Button();
            this.Manual_AppID_num = new System.Windows.Forms.NumericUpDown();
            this.Manual_ImportButton = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.MovePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.Manual_Box.SuspendLayout();
            this.Auto_Box.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Auto_Step2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Manual_AppID_num)).BeginInit();
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
            this.TopPanel.Size = new System.Drawing.Size(414, 68);
            this.TopPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel1.Location = new System.Drawing.Point(-10, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 10);
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
            this.AppNameLabel.Size = new System.Drawing.Size(184, 29);
            this.AppNameLabel.TabIndex = 9;
            this.AppNameLabel.Text = "Import Servers";
            // 
            // MovePanel
            // 
            this.MovePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.MovePanel.Controls.Add(this.Close_Button);
            this.MovePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MovePanel.Location = new System.Drawing.Point(0, 0);
            this.MovePanel.Name = "MovePanel";
            this.MovePanel.Size = new System.Drawing.Size(414, 23);
            this.MovePanel.TabIndex = 10;
            this.MovePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseDown);
            // 
            // Close_Button
            // 
            this.Close_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_Button.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources.close;
            this.Close_Button.Location = new System.Drawing.Point(390, 3);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(18, 18);
            this.Close_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel2.Location = new System.Drawing.Point(-5, 580);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 10);
            this.panel2.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel3.Location = new System.Drawing.Point(412, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 579);
            this.panel3.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel4.Location = new System.Drawing.Point(-8, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 576);
            this.panel4.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(5, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 124);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(382, 105);
            this.label3.TabIndex = 39;
            this.label3.Text = "Entering the incorrect information in this field may completely corrupt your inst" +
    "allation. Please double check your installation AppID and installation location " +
    "at least twice.";
            // 
            // Radio_Manual
            // 
            this.Radio_Manual.AutoSize = true;
            this.Radio_Manual.ForeColor = System.Drawing.Color.White;
            this.Radio_Manual.Location = new System.Drawing.Point(14, 80);
            this.Radio_Manual.Name = "Radio_Manual";
            this.Radio_Manual.Size = new System.Drawing.Size(91, 17);
            this.Radio_Manual.TabIndex = 37;
            this.Radio_Manual.TabStop = true;
            this.Radio_Manual.Text = "Manual import";
            this.Radio_Manual.UseVisualStyleBackColor = true;
            this.Radio_Manual.CheckedChanged += new System.EventHandler(this.Radio_Manual_CheckedChanged);
            // 
            // Radio_Auto
            // 
            this.Radio_Auto.AutoSize = true;
            this.Radio_Auto.ForeColor = System.Drawing.Color.White;
            this.Radio_Auto.Location = new System.Drawing.Point(14, 103);
            this.Radio_Auto.Name = "Radio_Auto";
            this.Radio_Auto.Size = new System.Drawing.Size(111, 17);
            this.Radio_Auto.TabIndex = 38;
            this.Radio_Auto.TabStop = true;
            this.Radio_Auto.Text = "SteamCMD Import";
            this.Radio_Auto.UseVisualStyleBackColor = true;
            // 
            // Manual_Box
            // 
            this.Manual_Box.Controls.Add(this.Manual_ImportButton);
            this.Manual_Box.Controls.Add(this.Manual_AppID_num);
            this.Manual_Box.Controls.Add(this.label2);
            this.Manual_Box.Controls.Add(this.label10);
            this.Manual_Box.Controls.Add(this.Manual_NameTextbox);
            this.Manual_Box.Controls.Add(this.groupBox2);
            this.Manual_Box.Controls.Add(this.label12);
            this.Manual_Box.Controls.Add(this.Manual_InstallDirTextbox);
            this.Manual_Box.Controls.Add(this.Manual_SelectLocationButton);
            this.Manual_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manual_Box.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Manual_Box.Location = new System.Drawing.Point(10, 126);
            this.Manual_Box.Name = "Manual_Box";
            this.Manual_Box.Size = new System.Drawing.Size(398, 285);
            this.Manual_Box.TabIndex = 39;
            this.Manual_Box.TabStop = false;
            this.Manual_Box.Text = "Manual Import";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "AppID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(6, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(338, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "Install Location";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Manual_NameTextbox
            // 
            this.Manual_NameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.Manual_NameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manual_NameTextbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Manual_NameTextbox.Location = new System.Drawing.Point(6, 35);
            this.Manual_NameTextbox.Name = "Manual_NameTextbox";
            this.Manual_NameTextbox.Size = new System.Drawing.Size(386, 20);
            this.Manual_NameTextbox.TabIndex = 26;
            this.Manual_NameTextbox.Text = "Server Name";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(338, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "Server Name";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Manual_InstallDirTextbox
            // 
            this.Manual_InstallDirTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.Manual_InstallDirTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manual_InstallDirTextbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Manual_InstallDirTextbox.Location = new System.Drawing.Point(6, 77);
            this.Manual_InstallDirTextbox.Name = "Manual_InstallDirTextbox";
            this.Manual_InstallDirTextbox.Size = new System.Drawing.Size(306, 20);
            this.Manual_InstallDirTextbox.TabIndex = 18;
            this.Manual_InstallDirTextbox.Text = "Location...";
            // 
            // Manual_SelectLocationButton
            // 
            this.Manual_SelectLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.Manual_SelectLocationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Manual_SelectLocationButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Manual_SelectLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manual_SelectLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manual_SelectLocationButton.ForeColor = System.Drawing.Color.White;
            this.Manual_SelectLocationButton.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._016_folder_24;
            this.Manual_SelectLocationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Manual_SelectLocationButton.Location = new System.Drawing.Point(318, 74);
            this.Manual_SelectLocationButton.Name = "Manual_SelectLocationButton";
            this.Manual_SelectLocationButton.Size = new System.Drawing.Size(74, 24);
            this.Manual_SelectLocationButton.TabIndex = 25;
            this.Manual_SelectLocationButton.Text = "Locate";
            this.Manual_SelectLocationButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Manual_SelectLocationButton.UseVisualStyleBackColor = false;
            this.Manual_SelectLocationButton.Click += new System.EventHandler(this.Manual_SelectLocationButton_Click);
            // 
            // Auto_Box
            // 
            this.Auto_Box.Controls.Add(this.AutoImportEditSelectionsButton);
            this.Auto_Box.Controls.Add(this.groupBox1);
            this.Auto_Box.Controls.Add(this.checkedListBoxManifests);
            this.Auto_Box.Controls.Add(this.label1);
            this.Auto_Box.Controls.Add(this.AutoImportSelectLocationButton);
            this.Auto_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Auto_Box.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Auto_Box.Location = new System.Drawing.Point(96, 150);
            this.Auto_Box.Name = "Auto_Box";
            this.Auto_Box.Size = new System.Drawing.Size(402, 285);
            this.Auto_Box.TabIndex = 40;
            this.Auto_Box.TabStop = false;
            this.Auto_Box.Text = "Auto Import";
            // 
            // AutoImportEditSelectionsButton
            // 
            this.AutoImportEditSelectionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.AutoImportEditSelectionsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoImportEditSelectionsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AutoImportEditSelectionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoImportEditSelectionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoImportEditSelectionsButton.ForeColor = System.Drawing.Color.White;
            this.AutoImportEditSelectionsButton.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._016_double_chevron;
            this.AutoImportEditSelectionsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AutoImportEditSelectionsButton.Location = new System.Drawing.Point(310, 33);
            this.AutoImportEditSelectionsButton.Name = "AutoImportEditSelectionsButton";
            this.AutoImportEditSelectionsButton.Size = new System.Drawing.Size(86, 24);
            this.AutoImportEditSelectionsButton.TabIndex = 38;
            this.AutoImportEditSelectionsButton.Text = "Next Step";
            this.AutoImportEditSelectionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoImportEditSelectionsButton.UseVisualStyleBackColor = false;
            this.AutoImportEditSelectionsButton.Click += new System.EventHandler(this.AutoImportEditSelectionsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(8, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 124);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(382, 105);
            this.label4.TabIndex = 39;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // checkedListBoxManifests
            // 
            this.checkedListBoxManifests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.checkedListBoxManifests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkedListBoxManifests.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBoxManifests.FormattingEnabled = true;
            this.checkedListBoxManifests.Location = new System.Drawing.Point(8, 61);
            this.checkedListBoxManifests.Name = "checkedListBoxManifests";
            this.checkedListBoxManifests.Size = new System.Drawing.Size(388, 94);
            this.checkedListBoxManifests.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Server Install Location";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoImportSelectLocationButton
            // 
            this.AutoImportSelectLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.AutoImportSelectLocationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoImportSelectLocationButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AutoImportSelectLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoImportSelectLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoImportSelectLocationButton.ForeColor = System.Drawing.Color.White;
            this.AutoImportSelectLocationButton.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._016_folder_24;
            this.AutoImportSelectLocationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AutoImportSelectLocationButton.Location = new System.Drawing.Point(9, 33);
            this.AutoImportSelectLocationButton.Name = "AutoImportSelectLocationButton";
            this.AutoImportSelectLocationButton.Size = new System.Drawing.Size(74, 24);
            this.AutoImportSelectLocationButton.TabIndex = 25;
            this.AutoImportSelectLocationButton.Text = "Locate";
            this.AutoImportSelectLocationButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoImportSelectLocationButton.UseVisualStyleBackColor = false;
            this.AutoImportSelectLocationButton.Click += new System.EventHandler(this.AutoImportSelectLocationButton_Click);
            // 
            // Auto_Step2
            // 
            this.Auto_Step2.Controls.Add(this.Step2_NextButton);
            this.Auto_Step2.Controls.Add(this.Step2_InstallDirLabel);
            this.Auto_Step2.Controls.Add(this.label5);
            this.Auto_Step2.Controls.Add(this.Step2_ServerName_Textbox);
            this.Auto_Step2.Controls.Add(this.label6);
            this.Auto_Step2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Auto_Step2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Auto_Step2.Location = new System.Drawing.Point(381, 80);
            this.Auto_Step2.Name = "Auto_Step2";
            this.Auto_Step2.Size = new System.Drawing.Size(402, 285);
            this.Auto_Step2.TabIndex = 41;
            this.Auto_Step2.TabStop = false;
            this.Auto_Step2.Text = "Auto Import - Fix references";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(338, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Server Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Step2_ServerName_Textbox
            // 
            this.Step2_ServerName_Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.Step2_ServerName_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step2_ServerName_Textbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Step2_ServerName_Textbox.Location = new System.Drawing.Point(8, 35);
            this.Step2_ServerName_Textbox.Name = "Step2_ServerName_Textbox";
            this.Step2_ServerName_Textbox.Size = new System.Drawing.Size(386, 20);
            this.Step2_ServerName_Textbox.TabIndex = 28;
            this.Step2_ServerName_Textbox.Text = "Server Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Install Location/Regarding";
            // 
            // Step2_InstallDirLabel
            // 
            this.Step2_InstallDirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step2_InstallDirLabel.Location = new System.Drawing.Point(8, 74);
            this.Step2_InstallDirLabel.Name = "Step2_InstallDirLabel";
            this.Step2_InstallDirLabel.Size = new System.Drawing.Size(386, 133);
            this.Step2_InstallDirLabel.TabIndex = 30;
            this.Step2_InstallDirLabel.Text = "Install Location/Regarding";
            // 
            // Step2_NextButton
            // 
            this.Step2_NextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.Step2_NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Step2_NextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Step2_NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Step2_NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step2_NextButton.ForeColor = System.Drawing.Color.White;
            this.Step2_NextButton.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._016_double_chevron;
            this.Step2_NextButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Step2_NextButton.Location = new System.Drawing.Point(310, 254);
            this.Step2_NextButton.Name = "Step2_NextButton";
            this.Step2_NextButton.Size = new System.Drawing.Size(86, 24);
            this.Step2_NextButton.TabIndex = 39;
            this.Step2_NextButton.Text = "Next Step";
            this.Step2_NextButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Step2_NextButton.UseVisualStyleBackColor = false;
            this.Step2_NextButton.Click += new System.EventHandler(this.Step2_NextButton_Click);
            // 
            // Manual_AppID_num
            // 
            this.Manual_AppID_num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.Manual_AppID_num.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Manual_AppID_num.Location = new System.Drawing.Point(6, 120);
            this.Manual_AppID_num.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Manual_AppID_num.Name = "Manual_AppID_num";
            this.Manual_AppID_num.Size = new System.Drawing.Size(120, 20);
            this.Manual_AppID_num.TabIndex = 37;
            // 
            // Manual_ImportButton
            // 
            this.Manual_ImportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.Manual_ImportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Manual_ImportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Manual_ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manual_ImportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manual_ImportButton.ForeColor = System.Drawing.Color.White;
            this.Manual_ImportButton.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._028_download;
            this.Manual_ImportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Manual_ImportButton.Location = new System.Drawing.Point(318, 117);
            this.Manual_ImportButton.Name = "Manual_ImportButton";
            this.Manual_ImportButton.Size = new System.Drawing.Size(74, 24);
            this.Manual_ImportButton.TabIndex = 39;
            this.Manual_ImportButton.Text = "Import";
            this.Manual_ImportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Manual_ImportButton.UseVisualStyleBackColor = false;
            this.Manual_ImportButton.Click += new System.EventHandler(this.Manual_ImportButton_Click);
            // 
            // ImportServerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(414, 434);
            this.Controls.Add(this.Auto_Step2);
            this.Controls.Add(this.Manual_Box);
            this.Controls.Add(this.Auto_Box);
            this.Controls.Add(this.Radio_Auto);
            this.Controls.Add(this.Radio_Manual);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImportServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutForm";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.MovePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.Manual_Box.ResumeLayout(false);
            this.Manual_Box.PerformLayout();
            this.Auto_Box.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.Auto_Step2.ResumeLayout(false);
            this.Auto_Step2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Manual_AppID_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label AppNameLabel;
        private System.Windows.Forms.Panel MovePanel;
        private System.Windows.Forms.PictureBox Close_Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Radio_Manual;
        private System.Windows.Forms.RadioButton Radio_Auto;
        private System.Windows.Forms.GroupBox Manual_Box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Manual_NameTextbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Manual_InstallDirTextbox;
        private System.Windows.Forms.Button Manual_SelectLocationButton;
        private System.Windows.Forms.GroupBox Auto_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AutoImportSelectLocationButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxManifests;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AutoImportEditSelectionsButton;
        private System.Windows.Forms.GroupBox Auto_Step2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Step2_ServerName_Textbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Step2_InstallDirLabel;
        private System.Windows.Forms.Button Step2_NextButton;
        private System.Windows.Forms.NumericUpDown Manual_AppID_num;
        private System.Windows.Forms.Button Manual_ImportButton;
    }
}