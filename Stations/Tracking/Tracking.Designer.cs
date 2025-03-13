namespace Chronos.Modules.Tracking
{
    partial class Tracking
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblLastScanned = new System.Windows.Forms.Label();
            this.btnF10 = new System.Windows.Forms.Button();
            this.btnF9 = new System.Windows.Forms.Button();
            this.BtnF7 = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblUnityLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.lblInstruction);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Location = new System.Drawing.Point(114, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 155);
            this.panel1.TabIndex = 105;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("Arial", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Location = new System.Drawing.Point(3, 115);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(763, 32);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "Error: This is an error";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblInstruction.Font = new System.Drawing.Font("Verdana", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblInstruction.Location = new System.Drawing.Point(93, 76);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(587, 28);
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
            this.txtInput.Location = new System.Drawing.Point(93, 25);
            this.txtInput.MaxLength = 50;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(586, 48);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtInput_KeyUp);
            // 
            // tlpFooter
            // 
            this.tlpFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpFooter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpFooter.ColumnCount = 5;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpFooter.Controls.Add(this.lblTotal, 0, 0);
            this.tlpFooter.Controls.Add(this.lblLastScanned, 1, 0);
            this.tlpFooter.Controls.Add(this.btnF10, 4, 0);
            this.tlpFooter.Controls.Add(this.btnF9, 3, 0);
            this.tlpFooter.Controls.Add(this.BtnF7, 2, 0);
            this.tlpFooter.Location = new System.Drawing.Point(0, 471);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(1000, 50);
            this.tlpFooter.TabIndex = 107;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotal.Location = new System.Drawing.Point(2, 2);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(1);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(262, 46);
            this.lblTotal.TabIndex = 436;
            this.lblTotal.Text = "Total: 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastScanned
            // 
            this.lblLastScanned.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastScanned.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastScanned.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastScanned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastScanned.Location = new System.Drawing.Point(267, 2);
            this.lblLastScanned.Margin = new System.Windows.Forms.Padding(1);
            this.lblLastScanned.Name = "lblLastScanned";
            this.lblLastScanned.Size = new System.Drawing.Size(262, 46);
            this.lblLastScanned.TabIndex = 435;
            this.lblLastScanned.Text = "Ultimo Escaneado: ----";
            this.lblLastScanned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnF10.TabIndex = 7;
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
            this.btnF9.Location = new System.Drawing.Point(687, 4);
            this.btnF9.Name = "btnF9";
            this.btnF9.Size = new System.Drawing.Size(146, 42);
            this.btnF9.TabIndex = 437;
            this.btnF9.Text = "F9: Reiniciar";
            this.btnF9.UseVisualStyleBackColor = false;
            this.btnF9.Click += new System.EventHandler(this.BtnF9_Click);
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
            this.BtnF7.Location = new System.Drawing.Point(534, 4);
            this.BtnF7.Name = "BtnF7";
            this.BtnF7.Size = new System.Drawing.Size(146, 42);
            this.BtnF7.TabIndex = 439;
            this.BtnF7.Text = "F7: Reportes";
            this.BtnF7.UseVisualStyleBackColor = false;
            this.BtnF7.Click += new System.EventHandler(this.BtnF7_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.lblStation);
            this.pnlHeader.Controls.Add(this.lblUnityLabel);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 38);
            this.pnlHeader.TabIndex = 108;
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.BackColor = System.Drawing.Color.Transparent;
            this.lblStation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStation.Location = new System.Drawing.Point(14, 11);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(22, 18);
            this.lblStation.TabIndex = 102;
            this.lblStation.Text = "--";
            this.lblStation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // Tracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tlpFooter);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Tracking";
            this.Size = new System.Drawing.Size(1000, 521);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUnityLabel;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblLastScanned;
        private System.Windows.Forms.Button btnF9;
        private System.Windows.Forms.Button BtnF7;
        private System.Windows.Forms.Label lblStation;
    }
}
