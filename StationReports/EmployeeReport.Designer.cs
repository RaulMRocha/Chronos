namespace Chronos.Modules.StationReports
{
    partial class EmployeeReport
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblRunText = new System.Windows.Forms.Label();
            this.lblUnityLabel = new System.Windows.Forms.Label();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnF10 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSelection = new System.Windows.Forms.ComboBox();
            this.pnlHeader.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.lblRunText);
            this.pnlHeader.Controls.Add(this.lblUnityLabel);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 38);
            this.pnlHeader.TabIndex = 110;
            // 
            // lblRunText
            // 
            this.lblRunText.AutoSize = true;
            this.lblRunText.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunText.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRunText.Location = new System.Drawing.Point(3, 11);
            this.lblRunText.Name = "lblRunText";
            this.lblRunText.Size = new System.Drawing.Size(223, 18);
            this.lblRunText.TabIndex = 103;
            this.lblRunText.Text = "Producción por Asociado";
            // 
            // lblUnityLabel
            // 
            this.lblUnityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnityLabel.AutoSize = true;
            this.lblUnityLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblUnityLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnityLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnityLabel.Location = new System.Drawing.Point(731, 11);
            this.lblUnityLabel.Name = "lblUnityLabel";
            this.lblUnityLabel.Size = new System.Drawing.Size(265, 18);
            this.lblUnityLabel.TabIndex = 101;
            this.lblUnityLabel.Text = "Springs Window Fashions Unity";
            this.lblUnityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpFooter
            // 
            this.tlpFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpFooter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpFooter.ColumnCount = 2;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tlpFooter.Controls.Add(this.btnF10, 1, 0);
            this.tlpFooter.Location = new System.Drawing.Point(0, 471);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(1000, 50);
            this.tlpFooter.TabIndex = 111;
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
            this.btnF10.Location = new System.Drawing.Point(793, 4);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(203, 42);
            this.btnF10.TabIndex = 7;
            this.btnF10.Text = "Salir";
            this.btnF10.UseVisualStyleBackColor = false;
            this.btnF10.Click += new System.EventHandler(this.BtnF10_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cbSelection);
            this.panel1.Location = new System.Drawing.Point(6, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 38);
            this.panel1.TabIndex = 113;
            // 
            // cbSelection
            // 
            this.cbSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelection.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelection.FormattingEnabled = true;
            this.cbSelection.Items.AddRange(new object[] {
            "Corrida",
            "WorkTag",
            "Etiqueta",
            "Asociado"});
            this.cbSelection.Location = new System.Drawing.Point(4, 5);
            this.cbSelection.Name = "cbSelection";
            this.cbSelection.Size = new System.Drawing.Size(194, 26);
            this.cbSelection.TabIndex = 2;
            // 
            // EmployeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlpFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "EmployeeReport";
            this.Size = new System.Drawing.Size(1000, 521);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblRunText;
        private System.Windows.Forms.Label lblUnityLabel;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSelection;
    }
}
