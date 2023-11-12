namespace Steam_Server_Creation_Tool_V2.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Version_Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AppNameLabel = new System.Windows.Forms.Label();
            this.MovePanel = new System.Windows.Forms.Panel();
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Donate_Button = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ProjectURL_Label = new System.Windows.Forms.Label();
            this.Discord_Label = new System.Windows.Forms.Label();
            this.Author_Label = new System.Windows.Forms.Label();
            this.AppName_Label = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.MovePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Donate_Button)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.TopPanel.Controls.Add(this.Version_Label);
            this.TopPanel.Controls.Add(this.panel1);
            this.TopPanel.Controls.Add(this.AppNameLabel);
            this.TopPanel.Controls.Add(this.MovePanel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(414, 68);
            this.TopPanel.TabIndex = 1;
            // 
            // Version_Label
            // 
            this.Version_Label.BackColor = System.Drawing.Color.Transparent;
            this.Version_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Version_Label.ForeColor = System.Drawing.Color.White;
            this.Version_Label.Location = new System.Drawing.Point(83, 37);
            this.Version_Label.Name = "Version_Label";
            this.Version_Label.Size = new System.Drawing.Size(253, 18);
            this.Version_Label.TabIndex = 38;
            this.Version_Label.Text = "Version 0.0.1 Alpha";
            this.Version_Label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.AppNameLabel.Size = new System.Drawing.Size(80, 29);
            this.AppNameLabel.TabIndex = 9;
            this.AppNameLabel.Text = "About";
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
            this.panel3.Location = new System.Drawing.Point(412, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 524);
            this.panel3.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(24)))));
            this.panel4.Location = new System.Drawing.Point(-8, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 533);
            this.panel4.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(8, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 179);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 160);
            this.label2.TabIndex = 38;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(8, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 114);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backstory";
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
            this.label3.Size = new System.Drawing.Size(391, 95);
            this.label3.TabIndex = 39;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // Donate_Button
            // 
            this.Donate_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Donate_Button.Image = global::Steam_Server_Creation_Tool_V2.Properties.Resources.Donate;
            this.Donate_Button.Location = new System.Drawing.Point(134, 518);
            this.Donate_Button.Name = "Donate_Button";
            this.Donate_Button.Size = new System.Drawing.Size(142, 55);
            this.Donate_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Donate_Button.TabIndex = 37;
            this.Donate_Button.TabStop = false;
            this.Donate_Button.Click += new System.EventHandler(this.Donate_Button_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Donations are not forced upon you but greatly appreciated!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ProjectURL_Label);
            this.groupBox3.Controls.Add(this.Discord_Label);
            this.groupBox3.Controls.Add(this.Author_Label);
            this.groupBox3.Controls.Add(this.AppName_Label);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(8, 379);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 114);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Backstory";
            // 
            // ProjectURL_Label
            // 
            this.ProjectURL_Label.AutoEllipsis = true;
            this.ProjectURL_Label.BackColor = System.Drawing.Color.Transparent;
            this.ProjectURL_Label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProjectURL_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectURL_Label.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.ProjectURL_Label.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ProjectURL_Label.Location = new System.Drawing.Point(6, 67);
            this.ProjectURL_Label.Name = "ProjectURL_Label";
            this.ProjectURL_Label.Size = new System.Drawing.Size(391, 16);
            this.ProjectURL_Label.TabIndex = 42;
            this.ProjectURL_Label.Text = "ProjectURL";
            this.ProjectURL_Label.Click += new System.EventHandler(this.ProjectURL_Label_Click);
            // 
            // Discord_Label
            // 
            this.Discord_Label.BackColor = System.Drawing.Color.Transparent;
            this.Discord_Label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Discord_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Discord_Label.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.Discord_Label.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Discord_Label.Location = new System.Drawing.Point(6, 48);
            this.Discord_Label.Name = "Discord_Label";
            this.Discord_Label.Size = new System.Drawing.Size(391, 16);
            this.Discord_Label.TabIndex = 41;
            this.Discord_Label.Text = "DiscordURL";
            this.Discord_Label.Click += new System.EventHandler(this.Discord_Label_Click);
            // 
            // Author_Label
            // 
            this.Author_Label.BackColor = System.Drawing.Color.Transparent;
            this.Author_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Author_Label.ForeColor = System.Drawing.Color.White;
            this.Author_Label.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Author_Label.Location = new System.Drawing.Point(6, 32);
            this.Author_Label.Name = "Author_Label";
            this.Author_Label.Size = new System.Drawing.Size(391, 16);
            this.Author_Label.TabIndex = 40;
            this.Author_Label.Text = "AuthorName";
            // 
            // AppName_Label
            // 
            this.AppName_Label.BackColor = System.Drawing.Color.Transparent;
            this.AppName_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppName_Label.ForeColor = System.Drawing.Color.White;
            this.AppName_Label.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.AppName_Label.Location = new System.Drawing.Point(6, 16);
            this.AppName_Label.Name = "AppName_Label";
            this.AppName_Label.Size = new System.Drawing.Size(391, 16);
            this.AppName_Label.TabIndex = 39;
            this.AppName_Label.Text = "Author";
            // 
            // AboutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(414, 582);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Donate_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutForm";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.MovePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Donate_Button)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox Donate_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Version_Label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label AppName_Label;
        private System.Windows.Forms.Label ProjectURL_Label;
        private System.Windows.Forms.Label Discord_Label;
        private System.Windows.Forms.Label Author_Label;
    }
}