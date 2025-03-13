namespace Chronos
{
    partial class StationHolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationHolder));
            this.pnlStationHeader = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStationName = new System.Windows.Forms.Label();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tslblFacility = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblCellName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblUserLogged = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblUserCertified = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblStatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblAppVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlStationHolder = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStartupError = new System.Windows.Forms.Label();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.lblAppEnvironment = new System.Windows.Forms.Label();
            this.pnlMainHolder = new System.Windows.Forms.Panel();
            this.pnlStationHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ssStatus.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlMainHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStationHeader
            // 
            this.pnlStationHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStationHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.pnlStationHeader.Controls.Add(this.pictureBox2);
            this.pnlStationHeader.Controls.Add(this.pictureBox1);
            this.pnlStationHeader.Controls.Add(this.lblStationName);
            this.pnlStationHeader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStationHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlStationHeader.Name = "pnlStationHeader";
            this.pnlStationHeader.Size = new System.Drawing.Size(1000, 57);
            this.pnlStationHeader.TabIndex = 99;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Chronos.Properties.Resources.chronos_white_light__45_;
            this.pictureBox2.Location = new System.Drawing.Point(765, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(220, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Chronos.Properties.Resources.StationIcon;
            this.pictureBox1.Location = new System.Drawing.Point(14, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblStationName
            // 
            this.lblStationName.AutoSize = true;
            this.lblStationName.BackColor = System.Drawing.Color.Transparent;
            this.lblStationName.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationName.ForeColor = System.Drawing.Color.White;
            this.lblStationName.Location = new System.Drawing.Point(73, 6);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(289, 42);
            this.lblStationName.TabIndex = 0;
            this.lblStationName.Text = "[Station Name]";
            // 
            // ssStatus
            // 
            this.ssStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ssStatus.AutoSize = false;
            this.ssStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ssStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.ssStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblFacility,
            this.tslblCellName,
            this.tslblUserLogged,
            this.tslblUserCertified,
            this.tslblStatus1,
            this.tslblStatus2,
            this.tslblAppVersion});
            this.ssStatus.Location = new System.Drawing.Point(0, 578);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ssStatus.Size = new System.Drawing.Size(1000, 22);
            this.ssStatus.TabIndex = 199;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tslblFacility
            // 
            this.tslblFacility.BackColor = System.Drawing.Color.Transparent;
            this.tslblFacility.ForeColor = System.Drawing.Color.White;
            this.tslblFacility.Image = ((System.Drawing.Image)(resources.GetObject("tslblFacility.Image")));
            this.tslblFacility.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tslblFacility.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.tslblFacility.Name = "tslblFacility";
            this.tslblFacility.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tslblFacility.Size = new System.Drawing.Size(36, 17);
            this.tslblFacility.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslblCellName
            // 
            this.tslblCellName.BackColor = System.Drawing.Color.Transparent;
            this.tslblCellName.ForeColor = System.Drawing.Color.White;
            this.tslblCellName.Image = ((System.Drawing.Image)(resources.GetObject("tslblCellName.Image")));
            this.tslblCellName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tslblCellName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.tslblCellName.Name = "tslblCellName";
            this.tslblCellName.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tslblCellName.Size = new System.Drawing.Size(36, 17);
            this.tslblCellName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslblUserLogged
            // 
            this.tslblUserLogged.BackColor = System.Drawing.Color.Transparent;
            this.tslblUserLogged.ForeColor = System.Drawing.Color.White;
            this.tslblUserLogged.Image = global::Chronos.Properties.Resources.user;
            this.tslblUserLogged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tslblUserLogged.Name = "tslblUserLogged";
            this.tslblUserLogged.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tslblUserLogged.Size = new System.Drawing.Size(36, 17);
            this.tslblUserLogged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslblUserCertified
            // 
            this.tslblUserCertified.BackColor = System.Drawing.Color.Transparent;
            this.tslblUserCertified.ForeColor = System.Drawing.Color.White;
            this.tslblUserCertified.Image = global::Chronos.Properties.Resources.certified;
            this.tslblUserCertified.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tslblUserCertified.Name = "tslblUserCertified";
            this.tslblUserCertified.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tslblUserCertified.Size = new System.Drawing.Size(760, 17);
            this.tslblUserCertified.Spring = true;
            this.tslblUserCertified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslblStatus1
            // 
            this.tslblStatus1.BackColor = System.Drawing.Color.Transparent;
            this.tslblStatus1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslblStatus1.ForeColor = System.Drawing.Color.White;
            this.tslblStatus1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.tslblStatus1.Name = "tslblStatus1";
            this.tslblStatus1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tslblStatus1.Size = new System.Drawing.Size(20, 17);
            // 
            // tslblStatus2
            // 
            this.tslblStatus2.BackColor = System.Drawing.Color.Transparent;
            this.tslblStatus2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslblStatus2.ForeColor = System.Drawing.Color.White;
            this.tslblStatus2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.tslblStatus2.Name = "tslblStatus2";
            this.tslblStatus2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tslblStatus2.Size = new System.Drawing.Size(20, 17);
            // 
            // tslblAppVersion
            // 
            this.tslblAppVersion.BackColor = System.Drawing.Color.Transparent;
            this.tslblAppVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslblAppVersion.ForeColor = System.Drawing.Color.White;
            this.tslblAppVersion.Name = "tslblAppVersion";
            this.tslblAppVersion.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tslblAppVersion.Size = new System.Drawing.Size(20, 17);
            this.tslblAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlStationHolder
            // 
            this.pnlStationHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStationHolder.BackColor = System.Drawing.Color.Black;
            this.pnlStationHolder.Location = new System.Drawing.Point(0, 57);
            this.pnlStationHolder.Name = "pnlStationHolder";
            this.pnlStationHolder.Size = new System.Drawing.Size(1000, 521);
            this.pnlStationHolder.TabIndex = 98;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(17, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 214);
            this.panel2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(100, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(750, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Springs Window Fashions Unity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackgroundImage = global::Chronos.Properties.Resources.chronos_white_light;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(100, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(750, 163);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblStartupError);
            this.panel1.Location = new System.Drawing.Point(17, 409);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 83);
            this.panel1.TabIndex = 10;
            // 
            // lblStartupError
            // 
            this.lblStartupError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartupError.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartupError.ForeColor = System.Drawing.Color.White;
            this.lblStartupError.Location = new System.Drawing.Point(3, 0);
            this.lblStartupError.Name = "lblStartupError";
            this.lblStartupError.Size = new System.Drawing.Size(959, 83);
            this.lblStartupError.TabIndex = 3;
            this.lblStartupError.Text = "[Error-Desc]";
            this.lblStartupError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblAppVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.lblAppVersion.Location = new System.Drawing.Point(14, 575);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(66, 16);
            this.lblAppVersion.TabIndex = 11;
            this.lblAppVersion.Text = "[Version]";
            // 
            // lblAppEnvironment
            // 
            this.lblAppEnvironment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppEnvironment.BackColor = System.Drawing.Color.Transparent;
            this.lblAppEnvironment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppEnvironment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.lblAppEnvironment.Location = new System.Drawing.Point(623, 575);
            this.lblAppEnvironment.Name = "lblAppEnvironment";
            this.lblAppEnvironment.Size = new System.Drawing.Size(360, 16);
            this.lblAppEnvironment.TabIndex = 12;
            this.lblAppEnvironment.Text = "[Environment]";
            this.lblAppEnvironment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMainHolder
            // 
            this.pnlMainHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(142)))), ((int)(((byte)(155)))));
            this.pnlMainHolder.BackgroundImage = global::Chronos.Properties.Resources.background;
            this.pnlMainHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainHolder.Controls.Add(this.lblAppEnvironment);
            this.pnlMainHolder.Controls.Add(this.lblAppVersion);
            this.pnlMainHolder.Controls.Add(this.panel1);
            this.pnlMainHolder.Controls.Add(this.panel2);
            this.pnlMainHolder.Location = new System.Drawing.Point(0, 0);
            this.pnlMainHolder.Name = "pnlMainHolder";
            this.pnlMainHolder.Size = new System.Drawing.Size(1000, 600);
            this.pnlMainHolder.TabIndex = 100;
            // 
            // StationHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlMainHolder);
            this.Controls.Add(this.pnlStationHolder);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.pnlStationHeader);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StationHolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Chronos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StationHolder_FormClosing);
            this.pnlStationHeader.ResumeLayout(false);
            this.pnlStationHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlMainHolder.ResumeLayout(false);
            this.pnlMainHolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlStationHeader;
        private System.Windows.Forms.Label lblStationName;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslblCellName;
        private System.Windows.Forms.ToolStripStatusLabel tslblUserLogged;
        private System.Windows.Forms.Panel pnlStationHolder;
        private System.Windows.Forms.ToolStripStatusLabel tslblAppVersion;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus1;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus2;
        private System.Windows.Forms.ToolStripStatusLabel tslblFacility;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripStatusLabel tslblUserCertified;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStartupError;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Label lblAppEnvironment;
        private System.Windows.Forms.Panel pnlMainHolder;
    }
}