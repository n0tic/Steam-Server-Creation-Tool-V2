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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Minimize_Button = new System.Windows.Forms.PictureBox();
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Settings_Button = new System.Windows.Forms.Label();
            this.ManageServers_Button = new System.Windows.Forms.Label();
            this.NewServer_Button = new System.Windows.Forms.Label();
            this.SteamCMD_Button = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Settings_Button);
            this.panel1.Controls.Add(this.ManageServers_Button);
            this.panel1.Controls.Add(this.NewServer_Button);
            this.panel1.Controls.Add(this.SteamCMD_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 89);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(95, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(338, 29);
            this.label8.TabIndex = 9;
            this.label8.Text = "Steam Server Creation Tool";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources.LogoSSCT;
            this.pictureBox1.Location = new System.Drawing.Point(12, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(41)))));
            this.panel2.Controls.Add(this.Minimize_Button);
            this.panel2.Controls.Add(this.Close_Button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(642, 24);
            this.panel2.TabIndex = 10;
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
            this.label7.Location = new System.Drawing.Point(496, 56);
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
            this.label6.Location = new System.Drawing.Point(330, 56);
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
            this.label5.Location = new System.Drawing.Point(203, 56);
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
            this.Settings_Button.Location = new System.Drawing.Point(517, 56);
            this.Settings_Button.Name = "Settings_Button";
            this.Settings_Button.Size = new System.Drawing.Size(76, 20);
            this.Settings_Button.TabIndex = 5;
            this.Settings_Button.Text = "Settings";
            // 
            // ManageServers_Button
            // 
            this.ManageServers_Button.AutoSize = true;
            this.ManageServers_Button.BackColor = System.Drawing.Color.Transparent;
            this.ManageServers_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ManageServers_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageServers_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ManageServers_Button.Location = new System.Drawing.Point(351, 56);
            this.ManageServers_Button.Name = "ManageServers_Button";
            this.ManageServers_Button.Size = new System.Drawing.Size(139, 20);
            this.ManageServers_Button.TabIndex = 4;
            this.ManageServers_Button.Text = "Manage Servers";
            // 
            // NewServer_Button
            // 
            this.NewServer_Button.AutoSize = true;
            this.NewServer_Button.BackColor = System.Drawing.Color.Transparent;
            this.NewServer_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewServer_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewServer_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.NewServer_Button.Location = new System.Drawing.Point(224, 56);
            this.NewServer_Button.Name = "NewServer_Button";
            this.NewServer_Button.Size = new System.Drawing.Size(100, 20);
            this.NewServer_Button.TabIndex = 3;
            this.NewServer_Button.Text = "New Server";
            // 
            // SteamCMD_Button
            // 
            this.SteamCMD_Button.AutoSize = true;
            this.SteamCMD_Button.BackColor = System.Drawing.Color.Transparent;
            this.SteamCMD_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SteamCMD_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteamCMD_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SteamCMD_Button.Location = new System.Drawing.Point(97, 56);
            this.SteamCMD_Button.Name = "SteamCMD_Button";
            this.SteamCMD_Button.Size = new System.Drawing.Size(100, 20);
            this.SteamCMD_Button.TabIndex = 2;
            this.SteamCMD_Button.Text = "SteamCMD";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.Color.White;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "test",
            "some",
            "things",
            "out"});
            this.comboBox2.Location = new System.Drawing.Point(161, 189);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(283, 23);
            this.comboBox2.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(642, 589);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SteamCMD_Button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Settings_Button;
        private System.Windows.Forms.Label ManageServers_Button;
        private System.Windows.Forms.Label NewServer_Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Close_Button;
        private System.Windows.Forms.PictureBox Minimize_Button;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

