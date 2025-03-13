namespace Chronos.Modules.StationReports
{
    partial class TrackingHistoryReport
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
            this.gvTracking = new DevExpress.XtraGrid.GridControl();
            this.MainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRunNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWorkTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOperation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCellName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbSelection = new System.Windows.Forms.ComboBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTracking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainView)).BeginInit();
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
            this.pnlHeader.TabIndex = 109;
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
            this.lblRunText.Text = "Rastreo de Material";
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
            this.tlpFooter.TabIndex = 110;
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
            this.btnF10.Click += new System.EventHandler(this.BtnF10_Click);
            // 
            // gvTracking
            // 
            this.gvTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvTracking.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTracking.Location = new System.Drawing.Point(6, 88);
            this.gvTracking.MainView = this.MainView;
            this.gvTracking.Name = "gvTracking";
            this.gvTracking.Size = new System.Drawing.Size(990, 381);
            this.gvTracking.TabIndex = 111;
            this.gvTracking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MainView});
            // 
            // MainView
            // 
            this.MainView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainView.Appearance.HeaderPanel.Options.UseFont = true;
            this.MainView.Appearance.OddRow.BackColor = System.Drawing.Color.Silver;
            this.MainView.Appearance.OddRow.Options.UseBackColor = true;
            this.MainView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcRunNumber,
            this.gcWorkTag,
            this.gcLabel,
            this.gcEmployee,
            this.gcStation,
            this.gcOperation,
            this.gcCellName,
            this.gcDate});
            this.MainView.GridControl = this.gvTracking;
            this.MainView.Name = "MainView";
            // 
            // gcRunNumber
            // 
            this.gcRunNumber.AppearanceCell.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcRunNumber.AppearanceCell.Options.UseFont = true;
            this.gcRunNumber.Caption = "Corrida";
            this.gcRunNumber.FieldName = "RunNumber";
            this.gcRunNumber.Name = "gcRunNumber";
            this.gcRunNumber.OptionsColumn.AllowEdit = false;
            this.gcRunNumber.OptionsColumn.ReadOnly = true;
            this.gcRunNumber.Visible = true;
            this.gcRunNumber.VisibleIndex = 0;
            // 
            // gcWorkTag
            // 
            this.gcWorkTag.AppearanceCell.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.gcWorkTag.AppearanceCell.Options.UseFont = true;
            this.gcWorkTag.Caption = "Worktag";
            this.gcWorkTag.FieldName = "WorkTag";
            this.gcWorkTag.Name = "gcWorkTag";
            this.gcWorkTag.OptionsColumn.AllowEdit = false;
            this.gcWorkTag.OptionsColumn.ReadOnly = true;
            this.gcWorkTag.Visible = true;
            this.gcWorkTag.VisibleIndex = 1;
            // 
            // gcLabel
            // 
            this.gcLabel.AppearanceCell.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.gcLabel.AppearanceCell.Options.UseFont = true;
            this.gcLabel.Caption = "Etiqueta";
            this.gcLabel.FieldName = "InputLicensePlate";
            this.gcLabel.Name = "gcLabel";
            this.gcLabel.OptionsColumn.AllowEdit = false;
            this.gcLabel.OptionsColumn.ReadOnly = true;
            this.gcLabel.Visible = true;
            this.gcLabel.VisibleIndex = 2;
            // 
            // gcEmployee
            // 
            this.gcEmployee.AppearanceCell.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.gcEmployee.AppearanceCell.Options.UseFont = true;
            this.gcEmployee.Caption = "Asociado";
            this.gcEmployee.FieldName = "StartProcessBy";
            this.gcEmployee.Name = "gcEmployee";
            this.gcEmployee.OptionsColumn.AllowEdit = false;
            this.gcEmployee.OptionsColumn.ReadOnly = true;
            this.gcEmployee.Visible = true;
            this.gcEmployee.VisibleIndex = 3;
            // 
            // gcStation
            // 
            this.gcStation.AppearanceCell.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.gcStation.AppearanceCell.Options.UseFont = true;
            this.gcStation.Caption = "Estación";
            this.gcStation.FieldName = "StationName_es";
            this.gcStation.Name = "gcStation";
            this.gcStation.OptionsColumn.AllowEdit = false;
            this.gcStation.OptionsColumn.ReadOnly = true;
            this.gcStation.Visible = true;
            this.gcStation.VisibleIndex = 4;
            // 
            // gcOperation
            // 
            this.gcOperation.AppearanceCell.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.gcOperation.AppearanceCell.Options.UseFont = true;
            this.gcOperation.Caption = "Operación";
            this.gcOperation.FieldName = "OperationName_es";
            this.gcOperation.Name = "gcOperation";
            this.gcOperation.OptionsColumn.AllowEdit = false;
            this.gcOperation.OptionsColumn.ReadOnly = true;
            this.gcOperation.Visible = true;
            this.gcOperation.VisibleIndex = 5;
            // 
            // gcCellName
            // 
            this.gcCellName.AppearanceCell.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.gcCellName.AppearanceCell.Options.UseFont = true;
            this.gcCellName.Caption = "Celda";
            this.gcCellName.FieldName = "CellName";
            this.gcCellName.Name = "gcCellName";
            this.gcCellName.OptionsColumn.AllowEdit = false;
            this.gcCellName.OptionsColumn.ReadOnly = true;
            this.gcCellName.Visible = true;
            this.gcCellName.VisibleIndex = 6;
            // 
            // gcDate
            // 
            this.gcDate.AppearanceCell.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.gcDate.AppearanceCell.Options.UseFont = true;
            this.gcDate.Caption = "Fecha";
            this.gcDate.DisplayFormat.FormatString = "dd/MMM/yyyy HH:mm";
            this.gcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcDate.FieldName = "StartProcessDate";
            this.gcDate.Name = "gcDate";
            this.gcDate.OptionsColumn.AllowEdit = false;
            this.gcDate.OptionsColumn.ReadOnly = true;
            this.gcDate.Visible = true;
            this.gcDate.VisibleIndex = 7;
            this.gcDate.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cbSelection);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Location = new System.Drawing.Point(6, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 38);
            this.panel1.TabIndex = 112;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(523, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // cbSelection
            // 
            this.cbSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelection.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelection.FormattingEnabled = true;
            this.cbSelection.Items.AddRange(new object[] {
            "Asociado",
            "Corrida",
            "Etiqueta",
            "Número de orden"});
            this.cbSelection.Location = new System.Drawing.Point(4, 5);
            this.cbSelection.Name = "cbSelection";
            this.cbSelection.Size = new System.Drawing.Size(194, 26);
            this.cbSelection.TabIndex = 2;
            // 
            // txtInput
            // 
            this.txtInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInput.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(204, 4);
            this.txtInput.MaxLength = 50;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(313, 27);
            this.txtInput.TabIndex = 1;
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtInput_KeyUp);
            // 
            // TrackingHistoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gvTracking);
            this.Controls.Add(this.tlpFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "TrackingHistoryReport";
            this.Size = new System.Drawing.Size(1000, 521);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTracking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUnityLabel;
        private System.Windows.Forms.Label lblRunText;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Button btnF10;
        private DevExpress.XtraGrid.GridControl gvTracking;
        private DevExpress.XtraGrid.Views.Grid.GridView MainView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtInput;
        private DevExpress.XtraGrid.Columns.GridColumn gcCellName;
        private DevExpress.XtraGrid.Columns.GridColumn gcRunNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcWorkTag;
        private DevExpress.XtraGrid.Columns.GridColumn gcLabel;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn gcStation;
        private DevExpress.XtraGrid.Columns.GridColumn gcOperation;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate;
        private System.Windows.Forms.ComboBox cbSelection;
        private System.Windows.Forms.Button btnSearch;
    }
}
