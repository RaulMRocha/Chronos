namespace Chronos.Modules.DownTime
{
    partial class DownTime
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
            this.lblDTStatus = new System.Windows.Forms.Label();
            this.pnlTimer = new System.Windows.Forms.Panel();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.pnlDTReason = new System.Windows.Forms.Panel();
            this.lblDTReason = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAction = new System.Windows.Forms.Button();
            this.pnlTimer.SuspendLayout();
            this.pnlDTReason.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDTStatus
            // 
            this.lblDTStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDTStatus.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDTStatus.ForeColor = System.Drawing.Color.Yellow;
            this.lblDTStatus.Location = new System.Drawing.Point(3, 0);
            this.lblDTStatus.Name = "lblDTStatus";
            this.lblDTStatus.Size = new System.Drawing.Size(991, 53);
            this.lblDTStatus.TabIndex = 101;
            this.lblDTStatus.Text = "[Downtime Status]";
            this.lblDTStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTimer
            // 
            this.pnlTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimer.Controls.Add(this.lblElapsedTime);
            this.pnlTimer.Location = new System.Drawing.Point(3, 123);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(994, 112);
            this.pnlTimer.TabIndex = 103;
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblElapsedTime.Font = new System.Drawing.Font("Verdana", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsedTime.ForeColor = System.Drawing.Color.Yellow;
            this.lblElapsedTime.Location = new System.Drawing.Point(3, 6);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(988, 99);
            this.lblElapsedTime.TabIndex = 100;
            this.lblElapsedTime.Text = "00:00:00";
            this.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDTReason
            // 
            this.pnlDTReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDTReason.Controls.Add(this.lblDTReason);
            this.pnlDTReason.Location = new System.Drawing.Point(3, 60);
            this.pnlDTReason.Name = "pnlDTReason";
            this.pnlDTReason.Size = new System.Drawing.Size(994, 62);
            this.pnlDTReason.TabIndex = 102;
            // 
            // lblDTReason
            // 
            this.lblDTReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDTReason.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDTReason.ForeColor = System.Drawing.Color.Yellow;
            this.lblDTReason.Location = new System.Drawing.Point(3, 4);
            this.lblDTReason.Name = "lblDTReason";
            this.lblDTReason.Size = new System.Drawing.Size(988, 53);
            this.lblDTReason.TabIndex = 100;
            this.lblDTReason.Text = "[Downtime Reason]";
            this.lblDTReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblInstruction);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Location = new System.Drawing.Point(97, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 128);
            this.panel1.TabIndex = 104;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblInstruction.Font = new System.Drawing.Font("Verdana", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblInstruction.Location = new System.Drawing.Point(80, 74);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(646, 28);
            this.lblInstruction.TabIndex = 9;
            this.lblInstruction.Text = "[Instruction]";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInput.Font = new System.Drawing.Font("Verdana", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(80, 25);
            this.txtInput.MaxLength = 50;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(646, 48);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtInput_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 423);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 98);
            this.panel2.TabIndex = 105;
            // 
            // btnAction
            // 
            this.btnAction.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAction.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(347, 21);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(305, 62);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "[Action]";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // DownTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTimer);
            this.Controls.Add(this.pnlDTReason);
            this.Controls.Add(this.lblDTStatus);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DownTime";
            this.Size = new System.Drawing.Size(1000, 521);
            this.Load += new System.EventHandler(this.DownTime_Load);
            this.pnlTimer.ResumeLayout(false);
            this.pnlDTReason.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDTStatus;
        private System.Windows.Forms.Panel pnlTimer;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Panel pnlDTReason;
        private System.Windows.Forms.Label lblDTReason;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAction;
    }
}
