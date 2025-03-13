namespace Chronos.Modules.LabelManager
{
    partial class LabelPrintingManual
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
            this.lblUnityLabel = new System.Windows.Forms.Label();
            this.lblRunText = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblRun = new System.Windows.Forms.Label();
            this.txtWorktag = new System.Windows.Forms.TextBox();
            this.lblTitleWorktag = new System.Windows.Forms.Label();
            this.txtNumberOfLables = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlWorktag = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.lblLastRun = new System.Windows.Forms.Label();
            this.lblLastWorktag = new System.Windows.Forms.Label();
            this.btnF10 = new System.Windows.Forms.Button();
            this.btnF9 = new System.Windows.Forms.Button();
            this.btnF8 = new System.Windows.Forms.Button();
            this.BtnF7 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlRun = new System.Windows.Forms.Panel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtRun = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlWorktag.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.pnlRun.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUnityLabel
            // 
            this.lblUnityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnityLabel.AutoSize = true;
            this.lblUnityLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblUnityLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnityLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnityLabel.Location = new System.Drawing.Point(686, 11);
            this.lblUnityLabel.Name = "lblUnityLabel";
            this.lblUnityLabel.Size = new System.Drawing.Size(265, 18);
            this.lblUnityLabel.TabIndex = 101;
            this.lblUnityLabel.Text = "Springs Window Fashions Unity";
            this.lblUnityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRunText
            // 
            this.lblRunText.AutoSize = true;
            this.lblRunText.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunText.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRunText.Location = new System.Drawing.Point(5, 11);
            this.lblRunText.Name = "lblRunText";
            this.lblRunText.Size = new System.Drawing.Size(79, 18);
            this.lblRunText.TabIndex = 102;
            this.lblRunText.Text = "Corrida:";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.lblRun);
            this.pnlHeader.Controls.Add(this.lblRunText);
            this.pnlHeader.Controls.Add(this.lblUnityLabel);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 38);
            this.pnlHeader.TabIndex = 100;
            // 
            // lblRun
            // 
            this.lblRun.AutoSize = true;
            this.lblRun.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRun.ForeColor = System.Drawing.Color.Black;
            this.lblRun.Location = new System.Drawing.Point(104, 11);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(40, 18);
            this.lblRun.TabIndex = 103;
            this.lblRun.Text = "----";
            // 
            // txtWorktag
            // 
            this.txtWorktag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorktag.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorktag.Location = new System.Drawing.Point(316, 17);
            this.txtWorktag.Name = "txtWorktag";
            this.txtWorktag.Size = new System.Drawing.Size(285, 44);
            this.txtWorktag.TabIndex = 1;
            this.txtWorktag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWorktag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtWorktag_KeyUp);
            // 
            // lblTitleWorktag
            // 
            this.lblTitleWorktag.AutoSize = true;
            this.lblTitleWorktag.Font = new System.Drawing.Font("Verdana", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleWorktag.ForeColor = System.Drawing.Color.Black;
            this.lblTitleWorktag.Location = new System.Drawing.Point(15, 16);
            this.lblTitleWorktag.Name = "lblTitleWorktag";
            this.lblTitleWorktag.Size = new System.Drawing.Size(196, 40);
            this.lblTitleWorktag.TabIndex = 90;
            this.lblTitleWorktag.Text = "WorkTag:";
            // 
            // txtNumberOfLables
            // 
            this.txtNumberOfLables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumberOfLables.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfLables.Location = new System.Drawing.Point(316, 80);
            this.txtNumberOfLables.Name = "txtNumberOfLables";
            this.txtNumberOfLables.Size = new System.Drawing.Size(285, 44);
            this.txtNumberOfLables.TabIndex = 2;
            this.txtNumberOfLables.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumberOfLables.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtNumberOfLables_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 40);
            this.label3.TabIndex = 91;
            this.label3.Text = "Unidades:";
            // 
            // pnlWorktag
            // 
            this.pnlWorktag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWorktag.Controls.Add(this.lblMessage);
            this.pnlWorktag.Controls.Add(this.label3);
            this.pnlWorktag.Controls.Add(this.txtNumberOfLables);
            this.pnlWorktag.Controls.Add(this.lblTitleWorktag);
            this.pnlWorktag.Controls.Add(this.txtWorktag);
            this.pnlWorktag.Location = new System.Drawing.Point(188, 130);
            this.pnlWorktag.Name = "pnlWorktag";
            this.pnlWorktag.Size = new System.Drawing.Size(618, 224);
            this.pnlWorktag.TabIndex = 120;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("Arial", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Location = new System.Drawing.Point(21, 147);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(581, 72);
            this.lblMessage.TabIndex = 122;
            this.lblMessage.Text = "Error: This is an error";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tlpFooter
            // 
            this.tlpFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpFooter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpFooter.ColumnCount = 6;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tlpFooter.Controls.Add(this.lblLastRun, 0, 0);
            this.tlpFooter.Controls.Add(this.lblLastWorktag, 1, 0);
            this.tlpFooter.Controls.Add(this.btnF10, 5, 0);
            this.tlpFooter.Controls.Add(this.btnF9, 4, 0);
            this.tlpFooter.Controls.Add(this.btnF8, 3, 0);
            this.tlpFooter.Controls.Add(this.BtnF7, 2, 0);
            this.tlpFooter.ForeColor = System.Drawing.Color.White;
            this.tlpFooter.Location = new System.Drawing.Point(0, 471);
            this.tlpFooter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(1000, 50);
            this.tlpFooter.TabIndex = 105;
            // 
            // lblLastRun
            // 
            this.lblLastRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastRun.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastRun.Location = new System.Drawing.Point(2, 2);
            this.lblLastRun.Margin = new System.Windows.Forms.Padding(1);
            this.lblLastRun.Name = "lblLastRun";
            this.lblLastRun.Size = new System.Drawing.Size(145, 46);
            this.lblLastRun.TabIndex = 434;
            this.lblLastRun.Text = "UC: ----";
            this.lblLastRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastWorktag
            // 
            this.lblLastWorktag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastWorktag.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastWorktag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastWorktag.Location = new System.Drawing.Point(150, 2);
            this.lblLastWorktag.Margin = new System.Windows.Forms.Padding(1);
            this.lblLastWorktag.Name = "lblLastWorktag";
            this.lblLastWorktag.Size = new System.Drawing.Size(145, 46);
            this.lblLastWorktag.TabIndex = 433;
            this.lblLastWorktag.Text = "UW: ----";
            this.lblLastWorktag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnF10
            // 
            this.btnF10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF10.BackColor = System.Drawing.Color.Transparent;
            this.btnF10.FlatAppearance.BorderSize = 0;
            this.btnF10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnF10.Location = new System.Drawing.Point(840, 4);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(156, 42);
            this.btnF10.TabIndex = 6;
            this.btnF10.Text = "F10: Salir";
            this.btnF10.UseVisualStyleBackColor = false;
            this.btnF10.Click += new System.EventHandler(this.BtnF10_Click);
            // 
            // btnF9
            // 
            this.btnF9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF9.BackColor = System.Drawing.Color.Transparent;
            this.btnF9.FlatAppearance.BorderSize = 0;
            this.btnF9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnF9.Location = new System.Drawing.Point(629, 4);
            this.btnF9.Name = "btnF9";
            this.btnF9.Size = new System.Drawing.Size(204, 42);
            this.btnF9.TabIndex = 5;
            this.btnF9.Text = "F9: Cambiar Corrida";
            this.btnF9.UseVisualStyleBackColor = false;
            this.btnF9.Click += new System.EventHandler(this.BtnF9_Click);
            // 
            // btnF8
            // 
            this.btnF8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF8.BackColor = System.Drawing.Color.Transparent;
            this.btnF8.FlatAppearance.BorderSize = 0;
            this.btnF8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnF8.Location = new System.Drawing.Point(453, 4);
            this.btnF8.Name = "btnF8";
            this.btnF8.Size = new System.Drawing.Size(169, 42);
            this.btnF8.TabIndex = 435;
            this.btnF8.Text = "F8: Reimprimir";
            this.btnF8.UseVisualStyleBackColor = false;
            this.btnF8.Click += new System.EventHandler(this.BtnF8_Click);
            // 
            // BtnF7
            // 
            this.BtnF7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnF7.BackColor = System.Drawing.Color.Transparent;
            this.BtnF7.FlatAppearance.BorderSize = 0;
            this.BtnF7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnF7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnF7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnF7.Location = new System.Drawing.Point(300, 4);
            this.BtnF7.Name = "BtnF7";
            this.BtnF7.Size = new System.Drawing.Size(146, 42);
            this.BtnF7.TabIndex = 436;
            this.BtnF7.Text = "F7: Reportes";
            this.BtnF7.UseVisualStyleBackColor = false;
            this.BtnF7.Click += new System.EventHandler(this.BtnF7_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.BackColor = System.Drawing.Color.DarkGreen;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(316, 400);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(365, 50);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // pnlRun
            // 
            this.pnlRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRun.Controls.Add(this.lblInstruction);
            this.pnlRun.Controls.Add(this.txtRun);
            this.pnlRun.Location = new System.Drawing.Point(139, 189);
            this.pnlRun.Name = "pnlRun";
            this.pnlRun.Size = new System.Drawing.Size(700, 112);
            this.pnlRun.TabIndex = 112;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblInstruction.Font = new System.Drawing.Font("Verdana", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblInstruction.Location = new System.Drawing.Point(36, 68);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(618, 28);
            this.lblInstruction.TabIndex = 123;
            this.lblInstruction.Text = "Ingresa el número de corrida";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRun
            // 
            this.txtRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRun.Location = new System.Drawing.Point(36, 21);
            this.txtRun.Name = "txtRun";
            this.txtRun.Size = new System.Drawing.Size(617, 44);
            this.txtRun.TabIndex = 0;
            this.txtRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRun.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtRun_KeyUp);
            // 
            // LabelPrintingManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlRun);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.tlpFooter);
            this.Controls.Add(this.pnlWorktag);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LabelPrintingManual";
            this.Size = new System.Drawing.Size(1000, 521);
            this.Load += new System.EventHandler(this.LabelPrintingManual_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlWorktag.ResumeLayout(false);
            this.pnlWorktag.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            this.pnlRun.ResumeLayout(false);
            this.pnlRun.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUnityLabel;
        private System.Windows.Forms.Label lblRunText;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.TextBox txtWorktag;
        private System.Windows.Forms.Label lblTitleWorktag;
        private System.Windows.Forms.TextBox txtNumberOfLables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlWorktag;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.Button btnF9;
        private System.Windows.Forms.Label lblLastWorktag;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlRun;
        private System.Windows.Forms.TextBox txtRun;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblLastRun;
        private System.Windows.Forms.Button btnF8;
        private System.Windows.Forms.Button BtnF7;
    }
}
