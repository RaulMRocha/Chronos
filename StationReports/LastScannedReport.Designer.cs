namespace Chronos.Modules.StationReports
{
    partial class LastScannedReport
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
            this.gvLastScanned = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlHeader.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLastScanned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.pnlHeader.TabIndex = 111;
            // 
            // lblRunText
            // 
            this.lblRunText.AutoSize = true;
            this.lblRunText.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunText.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRunText.Location = new System.Drawing.Point(3, 11);
            this.lblRunText.Name = "lblRunText";
            this.lblRunText.Size = new System.Drawing.Size(181, 18);
            this.lblRunText.TabIndex = 103;
            this.lblRunText.Text = "Últimos Escaneados";
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
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpFooter.Controls.Add(this.btnF10, 1, 0);
            this.tlpFooter.Location = new System.Drawing.Point(0, 471);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(1000, 50);
            this.tlpFooter.TabIndex = 112;
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
            this.btnF10.Location = new System.Drawing.Point(792, 4);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(204, 42);
            this.btnF10.TabIndex = 7;
            this.btnF10.Text = "Salir";
            this.btnF10.UseVisualStyleBackColor = false;
            // 
            // gvLastScanned
            // 
            this.gvLastScanned.Location = new System.Drawing.Point(6, 44);
            this.gvLastScanned.MainView = this.gridView1;
            this.gvLastScanned.Name = "gvLastScanned";
            this.gvLastScanned.Size = new System.Drawing.Size(990, 421);
            this.gvLastScanned.TabIndex = 113;
            this.gvLastScanned.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gvLastScanned;
            this.gridView1.Name = "gridView1";
            // 
            // LastScannedReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gvLastScanned);
            this.Controls.Add(this.tlpFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "LastScannedReport";
            this.Size = new System.Drawing.Size(1000, 521);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLastScanned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblRunText;
        private System.Windows.Forms.Label lblUnityLabel;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Button btnF10;
        private DevExpress.XtraGrid.GridControl gvLastScanned;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
