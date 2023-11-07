namespace Steam_Server_Creation_Tool_V2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.AppNameLabel = new System.Windows.Forms.Label();
            this.BigLogo = new System.Windows.Forms.PictureBox();
            this.MovePanel = new System.Windows.Forms.Panel();
            this.Minimize_Button = new System.Windows.Forms.PictureBox();
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Settings_Button = new System.Windows.Forms.Label();
            this.ManageServers_Button = new System.Windows.Forms.Label();
            this.NewServer_Button = new System.Windows.Forms.Label();
            this.SteamCMD_Button = new System.Windows.Forms.Label();
            this.App_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SteamCMD_InstallLocation_Textbox = new System.Windows.Forms.TextBox();
            this.Panel_SteamCMD = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SteamCMD_DownloadWebsite_Buttons = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SteamCMD_InstallAuto_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel_NewServer = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Install_New_Server_Label = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigLogo)).BeginInit();
            this.MovePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            this.Panel_SteamCMD.SuspendLayout();
            this.Panel_NewServer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.TopPanel.Controls.Add(this.AppNameLabel);
            this.TopPanel.Controls.Add(this.BigLogo);
            this.TopPanel.Controls.Add(this.MovePanel);
            this.TopPanel.Controls.Add(this.label7);
            this.TopPanel.Controls.Add(this.label6);
            this.TopPanel.Controls.Add(this.label5);
            this.TopPanel.Controls.Add(this.Settings_Button);
            this.TopPanel.Controls.Add(this.ManageServers_Button);
            this.TopPanel.Controls.Add(this.NewServer_Button);
            this.TopPanel.Controls.Add(this.SteamCMD_Button);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(642, 89);
            this.TopPanel.TabIndex = 0;
            // 
            // AppNameLabel
            // 
            this.AppNameLabel.AutoSize = true;
            this.AppNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.AppNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppNameLabel.ForeColor = System.Drawing.Color.White;
            this.AppNameLabel.Location = new System.Drawing.Point(95, 26);
            this.AppNameLabel.Name = "AppNameLabel";
            this.AppNameLabel.Size = new System.Drawing.Size(338, 29);
            this.AppNameLabel.TabIndex = 9;
            this.AppNameLabel.Text = "Steam Server Creation Tool";
            // 
            // BigLogo
            // 
            this.BigLogo.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources.LogoSSCT;
            this.BigLogo.Location = new System.Drawing.Point(12, 29);
            this.BigLogo.Name = "BigLogo";
            this.BigLogo.Size = new System.Drawing.Size(68, 54);
            this.BigLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BigLogo.TabIndex = 1;
            this.BigLogo.TabStop = false;
            // 
            // MovePanel
            // 
            this.MovePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.MovePanel.Controls.Add(this.Minimize_Button);
            this.MovePanel.Controls.Add(this.Close_Button);
            this.MovePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MovePanel.Location = new System.Drawing.Point(0, 0);
            this.MovePanel.Name = "MovePanel";
            this.MovePanel.Size = new System.Drawing.Size(642, 23);
            this.MovePanel.TabIndex = 10;
            this.MovePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseDown);
            // 
            // Minimize_Button
            // 
            this.Minimize_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimize_Button.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources.minimize;
            this.Minimize_Button.Location = new System.Drawing.Point(597, 3);
            this.Minimize_Button.Name = "Minimize_Button";
            this.Minimize_Button.Size = new System.Drawing.Size(18, 18);
            this.Minimize_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Minimize_Button.TabIndex = 4;
            this.Minimize_Button.TabStop = false;
            this.Minimize_Button.Click += new System.EventHandler(this.Minimize_Button_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_Button.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources.close;
            this.Close_Button.Location = new System.Drawing.Point(621, 3);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(18, 18);
            this.Close_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(496, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "|";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(330, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "|";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(203, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "|";
            // 
            // Settings_Button
            // 
            this.Settings_Button.AutoSize = true;
            this.Settings_Button.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Settings_Button.Location = new System.Drawing.Point(517, 58);
            this.Settings_Button.Name = "Settings_Button";
            this.Settings_Button.Size = new System.Drawing.Size(76, 20);
            this.Settings_Button.TabIndex = 5;
            this.Settings_Button.Text = "Settings";
            this.Settings_Button.MouseEnter += new System.EventHandler(this.Settings_Button_MouseEnter);
            this.Settings_Button.MouseLeave += new System.EventHandler(this.Settings_Button_MouseLeave);
            // 
            // ManageServers_Button
            // 
            this.ManageServers_Button.AutoSize = true;
            this.ManageServers_Button.BackColor = System.Drawing.Color.Transparent;
            this.ManageServers_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ManageServers_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageServers_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ManageServers_Button.Location = new System.Drawing.Point(351, 58);
            this.ManageServers_Button.Name = "ManageServers_Button";
            this.ManageServers_Button.Size = new System.Drawing.Size(139, 20);
            this.ManageServers_Button.TabIndex = 4;
            this.ManageServers_Button.Text = "Manage Servers";
            this.ManageServers_Button.MouseEnter += new System.EventHandler(this.ManageServers_Button_MouseEnter);
            this.ManageServers_Button.MouseLeave += new System.EventHandler(this.ManageServers_Button_MouseLeave);
            // 
            // NewServer_Button
            // 
            this.NewServer_Button.AutoSize = true;
            this.NewServer_Button.BackColor = System.Drawing.Color.Transparent;
            this.NewServer_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewServer_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewServer_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.NewServer_Button.Location = new System.Drawing.Point(224, 58);
            this.NewServer_Button.Name = "NewServer_Button";
            this.NewServer_Button.Size = new System.Drawing.Size(100, 20);
            this.NewServer_Button.TabIndex = 3;
            this.NewServer_Button.Text = "New Server";
            this.NewServer_Button.Click += new System.EventHandler(this.NewServer_Button_Click);
            this.NewServer_Button.MouseEnter += new System.EventHandler(this.NewServer_Button_MouseEnter);
            this.NewServer_Button.MouseLeave += new System.EventHandler(this.NewServer_Button_MouseLeave);
            // 
            // SteamCMD_Button
            // 
            this.SteamCMD_Button.AutoSize = true;
            this.SteamCMD_Button.BackColor = System.Drawing.Color.Transparent;
            this.SteamCMD_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SteamCMD_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteamCMD_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SteamCMD_Button.Location = new System.Drawing.Point(97, 58);
            this.SteamCMD_Button.Name = "SteamCMD_Button";
            this.SteamCMD_Button.Size = new System.Drawing.Size(100, 20);
            this.SteamCMD_Button.TabIndex = 2;
            this.SteamCMD_Button.Text = "SteamCMD";
            this.SteamCMD_Button.Click += new System.EventHandler(this.SteamCMD_Button_Click);
            this.SteamCMD_Button.MouseEnter += new System.EventHandler(this.SteamCMD_Button_MouseEnter);
            this.SteamCMD_Button.MouseLeave += new System.EventHandler(this.SteamCMD_Button_MouseLeave);
            // 
            // App_ProgressBar
            // 
            this.App_ProgressBar.Location = new System.Drawing.Point(0, 89);
            this.App_ProgressBar.MarqueeAnimationSpeed = 1;
            this.App_ProgressBar.Name = "App_ProgressBar";
            this.App_ProgressBar.Size = new System.Drawing.Size(642, 5);
            this.App_ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.App_ProgressBar.TabIndex = 4;
            // 
            // SteamCMD_InstallLocation_Textbox
            // 
            this.SteamCMD_InstallLocation_Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.SteamCMD_InstallLocation_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteamCMD_InstallLocation_Textbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SteamCMD_InstallLocation_Textbox.Location = new System.Drawing.Point(12, 201);
            this.SteamCMD_InstallLocation_Textbox.Name = "SteamCMD_InstallLocation_Textbox";
            this.SteamCMD_InstallLocation_Textbox.Size = new System.Drawing.Size(455, 20);
            this.SteamCMD_InstallLocation_Textbox.TabIndex = 5;
            this.SteamCMD_InstallLocation_Textbox.Text = "Testing this shit";
            // 
            // Panel_SteamCMD
            // 
            this.Panel_SteamCMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.Panel_SteamCMD.Controls.Add(this.button2);
            this.Panel_SteamCMD.Controls.Add(this.SteamCMD_InstallLocation_Textbox);
            this.Panel_SteamCMD.Controls.Add(this.label3);
            this.Panel_SteamCMD.Controls.Add(this.panel3);
            this.Panel_SteamCMD.Controls.Add(this.SteamCMD_DownloadWebsite_Buttons);
            this.Panel_SteamCMD.Controls.Add(this.label2);
            this.Panel_SteamCMD.Controls.Add(this.panel2);
            this.Panel_SteamCMD.Controls.Add(this.SteamCMD_InstallAuto_Button);
            this.Panel_SteamCMD.Controls.Add(this.label1);
            this.Panel_SteamCMD.Controls.Add(this.panel1);
            this.Panel_SteamCMD.Location = new System.Drawing.Point(0, 95);
            this.Panel_SteamCMD.Name = "Panel_SteamCMD";
            this.Panel_SteamCMD.Size = new System.Drawing.Size(642, 494);
            this.Panel_SteamCMD.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._033_folder_7_EDIT;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(473, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 27);
            this.button2.TabIndex = 15;
            this.button2.Text = "Locate SteamCMD";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Locate SteamCMD Installation";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Location = new System.Drawing.Point(9, 192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(618, 2);
            this.panel3.TabIndex = 16;
            // 
            // SteamCMD_DownloadWebsite_Buttons
            // 
            this.SteamCMD_DownloadWebsite_Buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.SteamCMD_DownloadWebsite_Buttons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SteamCMD_DownloadWebsite_Buttons.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SteamCMD_DownloadWebsite_Buttons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SteamCMD_DownloadWebsite_Buttons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteamCMD_DownloadWebsite_Buttons.ForeColor = System.Drawing.Color.White;
            this.SteamCMD_DownloadWebsite_Buttons.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._021_browser;
            this.SteamCMD_DownloadWebsite_Buttons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SteamCMD_DownloadWebsite_Buttons.Location = new System.Drawing.Point(12, 129);
            this.SteamCMD_DownloadWebsite_Buttons.Name = "SteamCMD_DownloadWebsite_Buttons";
            this.SteamCMD_DownloadWebsite_Buttons.Size = new System.Drawing.Size(189, 29);
            this.SteamCMD_DownloadWebsite_Buttons.TabIndex = 3;
            this.SteamCMD_DownloadWebsite_Buttons.Text = "Visit SteamCMD Download";
            this.SteamCMD_DownloadWebsite_Buttons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SteamCMD_DownloadWebsite_Buttons.UseVisualStyleBackColor = false;
            this.SteamCMD_DownloadWebsite_Buttons.Click += new System.EventHandler(this.SteamCMD_DownloadWebsite_Buttons_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Manual Download";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(9, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 2);
            this.panel2.TabIndex = 13;
            // 
            // SteamCMD_InstallAuto_Button
            // 
            this.SteamCMD_InstallAuto_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.SteamCMD_InstallAuto_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SteamCMD_InstallAuto_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SteamCMD_InstallAuto_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SteamCMD_InstallAuto_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteamCMD_InstallAuto_Button.ForeColor = System.Drawing.Color.White;
            this.SteamCMD_InstallAuto_Button.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._016_double_chevron;
            this.SteamCMD_InstallAuto_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SteamCMD_InstallAuto_Button.Location = new System.Drawing.Point(15, 39);
            this.SteamCMD_InstallAuto_Button.Name = "SteamCMD_InstallAuto_Button";
            this.SteamCMD_InstallAuto_Button.Size = new System.Drawing.Size(135, 29);
            this.SteamCMD_InstallAuto_Button.TabIndex = 3;
            this.SteamCMD_InstallAuto_Button.Text = "Install SteamCMD";
            this.SteamCMD_InstallAuto_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SteamCMD_InstallAuto_Button.UseVisualStyleBackColor = false;
            this.SteamCMD_InstallAuto_Button.Click += new System.EventHandler(this.SteamCMD_InstallAuto_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Automatic Installation";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(9, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 2);
            this.panel1.TabIndex = 10;
            // 
            // Panel_NewServer
            // 
            this.Panel_NewServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.Panel_NewServer.Controls.Add(this.groupBox2);
            this.Panel_NewServer.Controls.Add(this.groupBox1);
            this.Panel_NewServer.Controls.Add(this.button4);
            this.Panel_NewServer.Controls.Add(this.button3);
            this.Panel_NewServer.Controls.Add(this.button1);
            this.Panel_NewServer.Controls.Add(this.Install_New_Server_Label);
            this.Panel_NewServer.Controls.Add(this.panel5);
            this.Panel_NewServer.Controls.Add(this.comboBox1);
            this.Panel_NewServer.Location = new System.Drawing.Point(0, 95);
            this.Panel_NewServer.Name = "Panel_NewServer";
            this.Panel_NewServer.Size = new System.Drawing.Size(642, 494);
            this.Panel_NewServer.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 104);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Installation Settings";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox3.Location = new System.Drawing.Point(6, 40);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(603, 20);
            this.textBox3.TabIndex = 26;
            this.textBox3.Text = "Server Name";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._033_folder_7_EDIT;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(301, 70);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(130, 24);
            this.button9.TabIndex = 25;
            this.button9.Text = "Server Location";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(6, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(338, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "Placeholder";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(6, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "Location...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 96);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Information";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._031_ellipsis;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(151, 61);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(229, 29);
            this.button6.TabIndex = 24;
            this.button6.Text = "Gameserver Login Token (GSLTs)";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._021_browser;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(6, 61);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(139, 29);
            this.button5.TabIndex = 20;
            this.button5.Text = "Server Setup Help";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(64, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(545, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Placeholder";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(6, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "App ID:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(93, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(516, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Placeholder";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(6, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "App Name:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._075_reload_EDIT;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(455, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 29);
            this.button4.TabIndex = 16;
            this.button4.Text = "Update";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._079_search_EDIT;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(544, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 29);
            this.button3.TabIndex = 15;
            this.button3.Text = "Search";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources._016_double_chevron;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(521, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "Install Server";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Install_New_Server_Label
            // 
            this.Install_New_Server_Label.AutoSize = true;
            this.Install_New_Server_Label.BackColor = System.Drawing.Color.Transparent;
            this.Install_New_Server_Label.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Install_New_Server_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Install_New_Server_Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Install_New_Server_Label.Location = new System.Drawing.Point(12, 12);
            this.Install_New_Server_Label.Name = "Install_New_Server_Label";
            this.Install_New_Server_Label.Size = new System.Drawing.Size(132, 16);
            this.Install_New_Server_Label.TabIndex = 14;
            this.Install_New_Server_Label.Text = "Install New Server";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.Location = new System.Drawing.Point(9, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(618, 2);
            this.panel5.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Loading..."});
            this.comboBox1.Location = new System.Drawing.Point(12, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(437, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(642, 589);
            this.Controls.Add(this.App_ProgressBar);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.Panel_SteamCMD);
            this.Controls.Add(this.Panel_NewServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigLogo)).EndInit();
            this.MovePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            this.Panel_SteamCMD.ResumeLayout(false);
            this.Panel_SteamCMD.PerformLayout();
            this.Panel_NewServer.ResumeLayout(false);
            this.Panel_NewServer.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.PictureBox BigLogo;
        private System.Windows.Forms.Label SteamCMD_Button;
        private System.Windows.Forms.Label AppNameLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Settings_Button;
        private System.Windows.Forms.Label ManageServers_Button;
        private System.Windows.Forms.Label NewServer_Button;
        private System.Windows.Forms.Panel MovePanel;
        private System.Windows.Forms.PictureBox Close_Button;
        private System.Windows.Forms.PictureBox Minimize_Button;
        private System.Windows.Forms.Button SteamCMD_InstallAuto_Button;
        private System.Windows.Forms.ProgressBar App_ProgressBar;
        private System.Windows.Forms.TextBox SteamCMD_InstallLocation_Textbox;
        private System.Windows.Forms.Button SteamCMD_DownloadWebsite_Buttons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Install_New_Server_Label;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Panel Panel_NewServer;
        public System.Windows.Forms.Panel Panel_SteamCMD;
    }
}

