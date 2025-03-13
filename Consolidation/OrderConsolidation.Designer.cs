namespace Chronos.Modules.Consolidation
{
    partial class OrderConsolidation
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression4 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblRackScanning = new System.Windows.Forms.Label();
            this.lblUnityLabel = new System.Windows.Forms.Label();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.lblLastRun = new System.Windows.Forms.Label();
            this.lblLastWorktag = new System.Windows.Forms.Label();
            this.btnF10 = new System.Windows.Forms.Button();
            this.btnF9 = new System.Windows.Forms.Button();
            this.btnF8 = new System.Windows.Forms.Button();
            this.BtnF7 = new System.Windows.Forms.Button();
            this.pnlScanContainer = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.pnlGridHolder = new System.Windows.Forms.Panel();
            this.gcConsBySO = new DevExpress.XtraGrid.GridControl();
            this.gvRack = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRackName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWorkTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLicensePlate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAssignedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcComp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlComponentSetProgress = new System.Windows.Forms.Panel();
            this.pnlSetGridHolder = new System.Windows.Forms.Panel();
            this.gcCompSetList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRackRackName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRackRackLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRackWorkTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRackLicensePlate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRackCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlHeader.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.pnlScanContainer.SuspendLayout();
            this.pnlGridHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsBySO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRack)).BeginInit();
            this.pnlComponentSetProgress.SuspendLayout();
            this.pnlSetGridHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCompSetList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.lblRackScanning);
            this.pnlHeader.Controls.Add(this.lblUnityLabel);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 38);
            this.pnlHeader.TabIndex = 104;
            // 
            // lblRackScanning
            // 
            this.lblRackScanning.AutoSize = true;
            this.lblRackScanning.BackColor = System.Drawing.Color.Transparent;
            this.lblRackScanning.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRackScanning.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblRackScanning.Location = new System.Drawing.Point(18, 11);
            this.lblRackScanning.Name = "lblRackScanning";
            this.lblRackScanning.Size = new System.Drawing.Size(153, 18);
            this.lblRackScanning.TabIndex = 102;
            this.lblRackScanning.Text = "Scanning Rack...";
            this.lblRackScanning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tlpFooter.ColumnCount = 6;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
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
            this.tlpFooter.TabIndex = 109;
            // 
            // lblLastRun
            // 
            this.lblLastRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastRun.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastRun.Location = new System.Drawing.Point(2, 2);
            this.lblLastRun.Margin = new System.Windows.Forms.Padding(1);
            this.lblLastRun.Name = "lblLastRun";
            this.lblLastRun.Size = new System.Drawing.Size(134, 46);
            this.lblLastRun.TabIndex = 434;
            this.lblLastRun.Text = "UC: ----";
            this.lblLastRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastWorktag
            // 
            this.lblLastWorktag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastWorktag.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastWorktag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastWorktag.Location = new System.Drawing.Point(139, 2);
            this.lblLastWorktag.Margin = new System.Windows.Forms.Padding(1);
            this.lblLastWorktag.Name = "lblLastWorktag";
            this.lblLastWorktag.Size = new System.Drawing.Size(134, 46);
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
            this.btnF10.Location = new System.Drawing.Point(818, 4);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(178, 42);
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
            this.btnF9.Enabled = false;
            this.btnF9.FlatAppearance.BorderSize = 0;
            this.btnF9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnF9.Location = new System.Drawing.Point(607, 4);
            this.btnF9.Name = "btnF9";
            this.btnF9.Size = new System.Drawing.Size(204, 42);
            this.btnF9.TabIndex = 5;
            this.btnF9.Text = "F9: ---";
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
            this.btnF8.Location = new System.Drawing.Point(431, 4);
            this.btnF8.Name = "btnF8";
            this.btnF8.Size = new System.Drawing.Size(169, 42);
            this.btnF8.TabIndex = 435;
            this.btnF8.Text = "F8: ---";
            this.btnF8.UseVisualStyleBackColor = false;
            this.btnF8.Click += new System.EventHandler(this.BtnF8_Click);
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
            this.BtnF7.Location = new System.Drawing.Point(278, 4);
            this.BtnF7.Name = "BtnF7";
            this.BtnF7.Size = new System.Drawing.Size(146, 42);
            this.BtnF7.TabIndex = 436;
            this.BtnF7.Text = "F7: ---";
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
            this.pnlScanContainer.TabIndex = 115;
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
            this.lblMessage.TabIndex = 124;
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
            this.lblInstruction.TabIndex = 123;
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
            // pnlGridHolder
            // 
            this.pnlGridHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridHolder.Controls.Add(this.gcConsBySO);
            this.pnlGridHolder.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnlGridHolder.Location = new System.Drawing.Point(5, 44);
            this.pnlGridHolder.Name = "pnlGridHolder";
            this.pnlGridHolder.Size = new System.Drawing.Size(991, 424);
            this.pnlGridHolder.TabIndex = 116;
            // 
            // gcConsBySO
            // 
            this.gcConsBySO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcConsBySO.Font = new System.Drawing.Font("Verdana", 15F);
            this.gcConsBySO.Location = new System.Drawing.Point(3, 3);
            this.gcConsBySO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.gcConsBySO.MainView = this.gvRack;
            this.gcConsBySO.Name = "gcConsBySO";
            this.gcConsBySO.Size = new System.Drawing.Size(985, 418);
            this.gcConsBySO.TabIndex = 20;
            this.gcConsBySO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRack});
            // 
            // gvRack
            // 
            this.gvRack.Appearance.EvenRow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRack.Appearance.EvenRow.Options.UseFont = true;
            this.gvRack.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.gvRack.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvRack.Appearance.GroupButton.BackColor = System.Drawing.Color.Black;
            this.gvRack.Appearance.GroupButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRack.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.gvRack.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvRack.Appearance.GroupButton.Options.UseFont = true;
            this.gvRack.Appearance.GroupButton.Options.UseForeColor = true;
            this.gvRack.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.gvRack.Appearance.GroupRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gvRack.Appearance.GroupRow.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRack.Appearance.GroupRow.ForeColor = System.Drawing.Color.White;
            this.gvRack.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvRack.Appearance.GroupRow.Options.UseFont = true;
            this.gvRack.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvRack.Appearance.HeaderPanel.Font = new System.Drawing.Font("Verdana", 15F);
            this.gvRack.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvRack.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvRack.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvRack.Appearance.HorzLine.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRack.Appearance.HorzLine.Options.UseFont = true;
            this.gvRack.Appearance.OddRow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRack.Appearance.OddRow.Options.UseFont = true;
            this.gvRack.Appearance.Row.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRack.Appearance.Row.Options.UseFont = true;
            this.gvRack.Appearance.RowSeparator.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gvRack.Appearance.RowSeparator.Options.UseFont = true;
            this.gvRack.Appearance.VertLine.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gvRack.Appearance.VertLine.Options.UseFont = true;
            this.gvRack.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvRack.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcRackName,
            this.gcOrderNumber,
            this.gcWorkTag,
            this.gcLicensePlate,
            this.gcSlot,
            this.gcLoc,
            this.gcBin,
            this.gcAssignedOn,
            this.gcComp});
            this.gvRack.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.OrangeRed;
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F);
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[LineCompleted] = 0";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Completed";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F);
            formatConditionRuleExpression2.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression2.Expression = "[LineCompleted] = 1";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gvRack.FormatRules.Add(gridFormatRule1);
            this.gvRack.FormatRules.Add(gridFormatRule2);
            this.gvRack.GridControl = this.gcConsBySO;
            this.gvRack.GroupCount = 3;
            this.gvRack.Name = "gvRack";
            this.gvRack.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvRack.OptionsBehavior.AutoPopulateColumns = false;
            this.gvRack.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvRack.OptionsBehavior.Editable = false;
            this.gvRack.OptionsCustomization.AllowGroup = false;
            this.gvRack.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvRack.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvRack.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.gvRack.OptionsView.ShowGroupPanel = false;
            this.gvRack.OptionsView.ShowIndicator = false;
            this.gvRack.RowHeight = 40;
            this.gvRack.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcRackName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcOrderNumber, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcWorkTag, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcRackName
            // 
            this.gcRackName.Caption = "Rack";
            this.gcRackName.FieldName = "RackName";
            this.gcRackName.Name = "gcRackName";
            this.gcRackName.OptionsColumn.ReadOnly = true;
            this.gcRackName.Visible = true;
            this.gcRackName.VisibleIndex = 0;
            // 
            // gcOrderNumber
            // 
            this.gcOrderNumber.Caption = "Orden";
            this.gcOrderNumber.FieldName = "OrderNumberWithDesc";
            this.gcOrderNumber.Name = "gcOrderNumber";
            this.gcOrderNumber.OptionsColumn.ReadOnly = true;
            this.gcOrderNumber.Visible = true;
            this.gcOrderNumber.VisibleIndex = 0;
            // 
            // gcWorkTag
            // 
            this.gcWorkTag.Caption = "Linea";
            this.gcWorkTag.FieldName = "WorktagWithDesc";
            this.gcWorkTag.Name = "gcWorkTag";
            this.gcWorkTag.OptionsColumn.ReadOnly = true;
            this.gcWorkTag.Visible = true;
            this.gcWorkTag.VisibleIndex = 0;
            this.gcWorkTag.Width = 212;
            // 
            // gcLicensePlate
            // 
            this.gcLicensePlate.Caption = "Componente";
            this.gcLicensePlate.FieldName = "LicensePlate";
            this.gcLicensePlate.Name = "gcLicensePlate";
            this.gcLicensePlate.Visible = true;
            this.gcLicensePlate.VisibleIndex = 0;
            // 
            // gcSlot
            // 
            this.gcSlot.Caption = "Slot";
            this.gcSlot.FieldName = "RackSlotCode";
            this.gcSlot.Name = "gcSlot";
            this.gcSlot.Visible = true;
            this.gcSlot.VisibleIndex = 1;
            // 
            // gcLoc
            // 
            this.gcLoc.Caption = "Locación";
            this.gcLoc.FieldName = "RackLocation";
            this.gcLoc.Name = "gcLoc";
            this.gcLoc.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gcLoc.Visible = true;
            this.gcLoc.VisibleIndex = 2;
            // 
            // gcBin
            // 
            this.gcBin.Caption = "Bin";
            this.gcBin.FieldName = "RackLocationBin";
            this.gcBin.Name = "gcBin";
            this.gcBin.Visible = true;
            this.gcBin.VisibleIndex = 3;
            // 
            // gcAssignedOn
            // 
            this.gcAssignedOn.Caption = "Asignado";
            this.gcAssignedOn.DisplayFormat.FormatString = "G";
            this.gcAssignedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcAssignedOn.FieldName = "AssignedOn";
            this.gcAssignedOn.Name = "gcAssignedOn";
            this.gcAssignedOn.Visible = true;
            this.gcAssignedOn.VisibleIndex = 4;
            // 
            // gcComp
            // 
            this.gcComp.Caption = "Completado";
            this.gcComp.FieldName = "Completed";
            this.gcComp.Name = "gcComp";
            // 
            // pnlComponentSetProgress
            // 
            this.pnlComponentSetProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlComponentSetProgress.BackColor = System.Drawing.Color.Black;
            this.pnlComponentSetProgress.Controls.Add(this.pnlSetGridHolder);
            this.pnlComponentSetProgress.Location = new System.Drawing.Point(0, 1000);
            this.pnlComponentSetProgress.Name = "pnlComponentSetProgress";
            this.pnlComponentSetProgress.Size = new System.Drawing.Size(1000, 260);
            this.pnlComponentSetProgress.TabIndex = 117;
            // 
            // pnlSetGridHolder
            // 
            this.pnlSetGridHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSetGridHolder.Controls.Add(this.gcCompSetList);
            this.pnlSetGridHolder.Location = new System.Drawing.Point(61, 13);
            this.pnlSetGridHolder.Name = "pnlSetGridHolder";
            this.pnlSetGridHolder.Size = new System.Drawing.Size(858, 241);
            this.pnlSetGridHolder.TabIndex = 114;
            // 
            // gcCompSetList
            // 
            this.gcCompSetList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcCompSetList.Location = new System.Drawing.Point(3, 0);
            this.gcCompSetList.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.gcCompSetList.MainView = this.gridView1;
            this.gcCompSetList.Name = "gcCompSetList";
            this.gcCompSetList.Size = new System.Drawing.Size(851, 238);
            this.gcCompSetList.TabIndex = 100;
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
            this.gcRackRackName,
            this.gcRackRackLocation,
            this.gcRackWorkTag,
            this.gcRackLicensePlate,
            this.gcRackCompleted});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "Processed";
            formatConditionRuleExpression3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            formatConditionRuleExpression3.Appearance.Font = new System.Drawing.Font("Verdana", 10F);
            formatConditionRuleExpression3.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleExpression3.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression3.Appearance.Options.UseFont = true;
            formatConditionRuleExpression3.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression3.Expression = "[Completed] = 1";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Name = "Not Processed";
            formatConditionRuleExpression4.Appearance.BackColor = System.Drawing.Color.OrangeRed;
            formatConditionRuleExpression4.Appearance.Font = new System.Drawing.Font("Verdana", 10F);
            formatConditionRuleExpression4.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleExpression4.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression4.Appearance.Options.UseFont = true;
            formatConditionRuleExpression4.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression4.Expression = "[Completed] = 0";
            gridFormatRule4.Rule = formatConditionRuleExpression4;
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.FormatRules.Add(gridFormatRule4);
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
            // gcRackRackName
            // 
            this.gcRackRackName.Caption = "Rack";
            this.gcRackRackName.FieldName = "RackName";
            this.gcRackRackName.Name = "gcRackRackName";
            this.gcRackRackName.Visible = true;
            this.gcRackRackName.VisibleIndex = 0;
            // 
            // gcRackRackLocation
            // 
            this.gcRackRackLocation.Caption = "Locación";
            this.gcRackRackLocation.FieldName = "RackLocation";
            this.gcRackRackLocation.Name = "gcRackRackLocation";
            this.gcRackRackLocation.Visible = true;
            this.gcRackRackLocation.VisibleIndex = 1;
            // 
            // gcRackWorkTag
            // 
            this.gcRackWorkTag.Caption = "WorkTag";
            this.gcRackWorkTag.FieldName = "WorkTag";
            this.gcRackWorkTag.Name = "gcRackWorkTag";
            this.gcRackWorkTag.Visible = true;
            this.gcRackWorkTag.VisibleIndex = 3;
            // 
            // gcRackLicensePlate
            // 
            this.gcRackLicensePlate.Caption = "Componente";
            this.gcRackLicensePlate.FieldName = "LicensePlate";
            this.gcRackLicensePlate.Name = "gcRackLicensePlate";
            this.gcRackLicensePlate.OptionsColumn.ReadOnly = true;
            this.gcRackLicensePlate.Visible = true;
            this.gcRackLicensePlate.VisibleIndex = 2;
            // 
            // gcRackCompleted
            // 
            this.gcRackCompleted.Caption = "Completado";
            this.gcRackCompleted.FieldName = "Completed";
            this.gcRackCompleted.Name = "gcRackCompleted";
            // 
            // OrderConsolidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlGridHolder);
            this.Controls.Add(this.tlpFooter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlComponentSetProgress);
            this.Controls.Add(this.pnlScanContainer);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrderConsolidation";
            this.Size = new System.Drawing.Size(1000, 521);
            this.Load += new System.EventHandler(this.OrderConsolidation_Load);
            this.Resize += new System.EventHandler(this.OrderConsolidation_Resize);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            this.pnlScanContainer.ResumeLayout(false);
            this.pnlScanContainer.PerformLayout();
            this.pnlGridHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcConsBySO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRack)).EndInit();
            this.pnlComponentSetProgress.ResumeLayout(false);
            this.pnlSetGridHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCompSetList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblRackScanning;
        private System.Windows.Forms.Label lblUnityLabel;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Label lblLastRun;
        private System.Windows.Forms.Label lblLastWorktag;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.Button btnF9;
        private System.Windows.Forms.Button btnF8;
        private System.Windows.Forms.Button BtnF7;
        private System.Windows.Forms.Panel pnlScanContainer;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel pnlGridHolder;
        private DevExpress.XtraGrid.GridControl gcConsBySO;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRack;
        private DevExpress.XtraGrid.Columns.GridColumn gcRackName;
        private DevExpress.XtraGrid.Columns.GridColumn gcWorkTag;
        private DevExpress.XtraGrid.Columns.GridColumn gcLicensePlate;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlot;
        private DevExpress.XtraGrid.Columns.GridColumn gcLoc;
        private DevExpress.XtraGrid.Columns.GridColumn gcBin;
        private DevExpress.XtraGrid.Columns.GridColumn gcAssignedOn;
        private DevExpress.XtraGrid.Columns.GridColumn gcComp;
        private DevExpress.XtraGrid.Columns.GridColumn gcOrderNumber;
        private System.Windows.Forms.Panel pnlComponentSetProgress;
        private System.Windows.Forms.Panel pnlSetGridHolder;
        private DevExpress.XtraGrid.GridControl gcCompSetList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcRackLicensePlate;
        private DevExpress.XtraGrid.Columns.GridColumn gcRackRackName;
        private DevExpress.XtraGrid.Columns.GridColumn gcRackRackLocation;
        private DevExpress.XtraGrid.Columns.GridColumn gcRackWorkTag;
        private DevExpress.XtraGrid.Columns.GridColumn gcRackCompleted;
    }
}
