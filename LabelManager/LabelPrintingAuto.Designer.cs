namespace Chronos.Modules.LabelManager
{
    partial class LabelPrintingAuto
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUnityLabel = new System.Windows.Forms.Label();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnF10 = new System.Windows.Forms.Button();
            this.btnF9 = new System.Windows.Forms.Button();
            this.BtnF7 = new System.Windows.Forms.Button();
            this.pnlScanContainer = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.pnlSetGridHolder = new System.Windows.Forms.Panel();
            this.gcCompSetList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcComponentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRunNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWorkTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlComponentSetProgress = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblLastScanned = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.pnlScanContainer.SuspendLayout();
            this.pnlSetGridHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCompSetList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnlComponentSetProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.lblUnityLabel);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 38);
            this.pnlHeader.TabIndex = 100;
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
            // tlpFooter
            // 
            this.tlpFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpFooter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpFooter.ColumnCount = 5;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tlpFooter.Controls.Add(this.lblLastScanned, 0, 0);
            this.tlpFooter.Controls.Add(this.lblTotal, 0, 0);
            this.tlpFooter.Controls.Add(this.btnF10, 4, 0);
            this.tlpFooter.Controls.Add(this.btnF9, 3, 0);
            this.tlpFooter.Controls.Add(this.BtnF7, 2, 0);
            this.tlpFooter.ForeColor = System.Drawing.Color.White;
            this.tlpFooter.Location = new System.Drawing.Point(0, 471);
            this.tlpFooter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(1000, 50);
            this.tlpFooter.TabIndex = 200;
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
            this.btnF10.TabIndex = 206;
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
            this.btnF9.Enabled = false;
            this.btnF9.FlatAppearance.BorderSize = 0;
            this.btnF9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnF9.Location = new System.Drawing.Point(669, 4);
            this.btnF9.Name = "btnF9";
            this.btnF9.Size = new System.Drawing.Size(164, 42);
            this.btnF9.TabIndex = 205;
            this.btnF9.Text = "F9: Completar Set";
            this.btnF9.UseVisualStyleBackColor = false;
            this.btnF9.Click += new System.EventHandler(this.BtnF9_Click);
            // 
            // BtnF7
            // 
            this.BtnF7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnF7.BackColor = System.Drawing.Color.Transparent;
            this.BtnF7.Enabled = false;
            this.BtnF7.FlatAppearance.BorderSize = 0;
            this.BtnF7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnF7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnF7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnF7.Location = new System.Drawing.Point(516, 4);
            this.BtnF7.Name = "BtnF7";
            this.BtnF7.Size = new System.Drawing.Size(146, 42);
            this.BtnF7.TabIndex = 203;
            this.BtnF7.Text = "F7: Reportes";
            this.BtnF7.UseVisualStyleBackColor = false;
            this.BtnF7.Click += new System.EventHandler(this.BtnF7_Click);
            // 
            // pnlScanContainer
            // 
            this.pnlScanContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScanContainer.Controls.Add(this.lblMessage);
            this.pnlScanContainer.Controls.Add(this.lblInstruction);
            this.pnlScanContainer.Controls.Add(this.txtInput);
            this.pnlScanContainer.Location = new System.Drawing.Point(136, 179);
            this.pnlScanContainer.Name = "pnlScanContainer";
            this.pnlScanContainer.Size = new System.Drawing.Size(700, 194);
            this.pnlScanContainer.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("Arial", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Location = new System.Drawing.Point(36, 112);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(618, 72);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "[Error: This is an error]";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "[Instructions]";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(36, 21);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(617, 44);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtInput_KeyUp);
            // 
            // pnlSetGridHolder
            // 
            this.pnlSetGridHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSetGridHolder.Controls.Add(this.gcCompSetList);
            this.pnlSetGridHolder.Location = new System.Drawing.Point(125, 9);
            this.pnlSetGridHolder.Name = "pnlSetGridHolder";
            this.pnlSetGridHolder.Size = new System.Drawing.Size(722, 239);
            this.pnlSetGridHolder.TabIndex = 401;
            // 
            // gcCompSetList
            // 
            this.gcCompSetList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcCompSetList.Location = new System.Drawing.Point(3, 3);
            this.gcCompSetList.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.gcCompSetList.MainView = this.gridView1;
            this.gcCompSetList.Name = "gcCompSetList";
            this.gcCompSetList.Size = new System.Drawing.Size(715, 233);
            this.gcCompSetList.TabIndex = 402;
            this.gcCompSetList.TabStop = false;
            this.gcCompSetList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Verdana", 10F);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Verdana", 12F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Verdana", 10F);
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Verdana", 10F);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Verdana", 10F);
            this.gridView1.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Verdana", 10F);
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Verdana", 10F);
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcComponentName,
            this.gcRunNumber,
            this.gcWorkTag,
            this.gcSet,
            this.gcStatus});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Processed";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Verdana", 10F);
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[Processed] = True";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Not Processed";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.OrangeRed;
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Verdana", 10F);
            formatConditionRuleExpression2.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression2.Expression = "[Processed] = False";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gcCompSetList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 40;
            // 
            // gcComponentName
            // 
            this.gcComponentName.Caption = "Componente";
            this.gcComponentName.FieldName = "ComponentName";
            this.gcComponentName.Name = "gcComponentName";
            this.gcComponentName.OptionsColumn.ReadOnly = true;
            this.gcComponentName.Visible = true;
            this.gcComponentName.VisibleIndex = 0;
            // 
            // gcRunNumber
            // 
            this.gcRunNumber.Caption = "Corrida";
            this.gcRunNumber.FieldName = "RunNumber";
            this.gcRunNumber.Name = "gcRunNumber";
            this.gcRunNumber.OptionsColumn.ReadOnly = true;
            this.gcRunNumber.Visible = true;
            this.gcRunNumber.VisibleIndex = 1;
            this.gcRunNumber.Width = 163;
            // 
            // gcWorkTag
            // 
            this.gcWorkTag.Caption = "Worktag";
            this.gcWorkTag.FieldName = "WorkTag";
            this.gcWorkTag.Name = "gcWorkTag";
            this.gcWorkTag.OptionsColumn.ReadOnly = true;
            this.gcWorkTag.Visible = true;
            this.gcWorkTag.VisibleIndex = 2;
            this.gcWorkTag.Width = 163;
            // 
            // gcSet
            // 
            this.gcSet.Caption = "Set";
            this.gcSet.FieldName = "OutputLicensePlate";
            this.gcSet.Name = "gcSet";
            this.gcSet.Visible = true;
            this.gcSet.VisibleIndex = 3;
            // 
            // gcStatus
            // 
            this.gcStatus.Caption = "Procesado";
            this.gcStatus.FieldName = "Processed";
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.OptionsColumn.ReadOnly = true;
            this.gcStatus.Visible = true;
            this.gcStatus.VisibleIndex = 4;
            this.gcStatus.Width = 80;
            // 
            // pnlComponentSetProgress
            // 
            this.pnlComponentSetProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlComponentSetProgress.BackColor = System.Drawing.Color.Black;
            this.pnlComponentSetProgress.Controls.Add(this.pnlSetGridHolder);
            this.pnlComponentSetProgress.Location = new System.Drawing.Point(0, 1000);
            this.pnlComponentSetProgress.Name = "pnlComponentSetProgress";
            this.pnlComponentSetProgress.Size = new System.Drawing.Size(1000, 254);
            this.pnlComponentSetProgress.TabIndex = 400;
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
            this.lblTotal.Size = new System.Drawing.Size(202, 46);
            this.lblTotal.TabIndex = 437;
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
            this.lblLastScanned.Location = new System.Drawing.Point(207, 2);
            this.lblLastScanned.Margin = new System.Windows.Forms.Padding(1);
            this.lblLastScanned.Name = "lblLastScanned";
            this.lblLastScanned.Size = new System.Drawing.Size(304, 46);
            this.lblLastScanned.TabIndex = 438;
            this.lblLastScanned.Text = "Ultimo: ----";
            this.lblLastScanned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelPrintingAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlScanContainer);
            this.Controls.Add(this.tlpFooter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlComponentSetProgress);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LabelPrintingAuto";
            this.Size = new System.Drawing.Size(1000, 521);
            this.Resize += new System.EventHandler(this.LabelPrintingAuto_Resize);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            this.pnlScanContainer.ResumeLayout(false);
            this.pnlScanContainer.PerformLayout();
            this.pnlSetGridHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCompSetList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnlComponentSetProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUnityLabel;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.Button btnF9;
        private System.Windows.Forms.Button BtnF7;
        private System.Windows.Forms.Panel pnlScanContainer;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlSetGridHolder;
        private DevExpress.XtraGrid.GridControl gcCompSetList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcRunNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcWorkTag;
        private System.Windows.Forms.Panel pnlComponentSetProgress;
        private DevExpress.XtraGrid.Columns.GridColumn gcComponentName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSet;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblLastScanned;
    }
}
