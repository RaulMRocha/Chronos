namespace Chronos.Modules.EmployeeValidation
{
    partial class EmployeeValidation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAppEnvironment = new System.Windows.Forms.Label();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtEmployeeBadge = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInvalid = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStationName = new System.Windows.Forms.Label();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAppEnvironment
            // 
            this.lblAppEnvironment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppEnvironment.BackColor = System.Drawing.Color.Transparent;
            this.lblAppEnvironment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppEnvironment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.lblAppEnvironment.Location = new System.Drawing.Point(677, 573);
            this.lblAppEnvironment.Name = "lblAppEnvironment";
            this.lblAppEnvironment.Size = new System.Drawing.Size(309, 16);
            this.lblAppEnvironment.TabIndex = 6;
            this.lblAppEnvironment.Text = "[Environment]";
            this.lblAppEnvironment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblAppVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.lblAppVersion.Location = new System.Drawing.Point(12, 573);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(66, 16);
            this.lblAppVersion.TabIndex = 5;
            this.lblAppVersion.Text = "[Version]";
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlControls.Controls.Add(this.lblInstruction);
            this.pnlControls.Controls.Add(this.txtEmployeeBadge);
            this.pnlControls.Controls.Add(this.pictureBox1);
            this.pnlControls.Location = new System.Drawing.Point(169, 437);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(674, 116);
            this.pnlControls.TabIndex = 4;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblInstruction.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.White;
            this.lblInstruction.Location = new System.Drawing.Point(9, 70);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(600, 32);
            this.lblInstruction.TabIndex = 2;
            this.lblInstruction.Text = "Escanea tu credencial";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmployeeBadge
            // 
            this.txtEmployeeBadge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmployeeBadge.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeBadge.Location = new System.Drawing.Point(9, 14);
            this.txtEmployeeBadge.Name = "txtEmployeeBadge";
            this.txtEmployeeBadge.Size = new System.Drawing.Size(600, 53);
            this.txtEmployeeBadge.TabIndex = 0;
            this.txtEmployeeBadge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmployeeBadge.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtEmployeeBadge_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackgroundImage = global::Chronos.Modules.EmployeeValidation.Properties.Resources.lock_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = global::Chronos.Modules.EmployeeValidation.Properties.Resources.lock_icon;
            this.pictureBox1.Location = new System.Drawing.Point(615, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(15, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(971, 214);
            this.panel2.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::Chronos.Modules.EmployeeValidation.Properties.Resources.LogoWhiteLight;
            this.pictureBox2.Location = new System.Drawing.Point(86, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(786, 163);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(86, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(767, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Springs Window Fashions Unity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvalid
            // 
            this.lblInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvalid.BackColor = System.Drawing.Color.Transparent;
            this.lblInvalid.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalid.ForeColor = System.Drawing.Color.White;
            this.lblInvalid.Location = new System.Drawing.Point(120, 520);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(767, 33);
            this.lblInvalid.TabIndex = 8;
            this.lblInvalid.Text = "Invalid Configuration";
            this.lblInvalid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblStationName);
            this.panel1.Location = new System.Drawing.Point(15, 348);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 83);
            this.panel1.TabIndex = 9;
            // 
            // lblStationName
            // 
            this.lblStationName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStationName.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationName.ForeColor = System.Drawing.Color.White;
            this.lblStationName.Location = new System.Drawing.Point(3, 0);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(965, 83);
            this.lblStationName.TabIndex = 3;
            this.lblStationName.Text = "[Sin Nombre]";
            this.lblStationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Chronos.Modules.EmployeeValidation.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblAppEnvironment);
            this.Controls.Add(this.lblAppVersion);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.lblInvalid);
            this.Name = "EmployeeValidation";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EmployeeValidation_Paint);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppEnvironment;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtEmployeeBadge;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblInvalid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStationName;
    }
}
