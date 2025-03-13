namespace Chronos.Modules.LabelManager.LabelTemplates
{
    partial class LabelTemplate_ComponentSet128
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.lblSlot2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSlot1 = new DevExpress.XtraReports.UI.XRLabel();
            this.bcBarCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.lblSlot3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSlot4 = new DevExpress.XtraReports.UI.XRLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblSlot4,
            this.lblSlot3,
            this.bcBarCode,
            this.lblSlot1,
            this.lblSlot2});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 64F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 2F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 2F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblSlot2
            // 
            this.lblSlot2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DataSlot2")});
            this.lblSlot2.Dpi = 100F;
            this.lblSlot2.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlot2.LocationFloat = new DevExpress.Utils.PointFloat(207.24F, 0F);
            this.lblSlot2.Name = "lblSlot2";
            this.lblSlot2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSlot2.SizeF = new System.Drawing.SizeF(186.7606F, 12.19392F);
            this.lblSlot2.StylePriority.UseFont = false;
            this.lblSlot2.StylePriority.UseTextAlignment = false;
            this.lblSlot2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblSlot1
            // 
            this.lblSlot1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DataSlot1")});
            this.lblSlot1.Dpi = 100F;
            this.lblSlot1.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlot1.LocationFloat = new DevExpress.Utils.PointFloat(7.000008F, 0F);
            this.lblSlot1.Name = "lblSlot1";
            this.lblSlot1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSlot1.SizeF = new System.Drawing.SizeF(179.8438F, 12.19392F);
            this.lblSlot1.StylePriority.UseFont = false;
            this.lblSlot1.StylePriority.UseTextAlignment = false;
            this.lblSlot1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // bcBarCode
            // 
            this.bcBarCode.AutoModule = true;
            this.bcBarCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BarCodeValue")});
            this.bcBarCode.Dpi = 100F;
            this.bcBarCode.Font = new System.Drawing.Font("Verdana", 6F);
            this.bcBarCode.LocationFloat = new DevExpress.Utils.PointFloat(96.69F, 15.19F);
            this.bcBarCode.Name = "bcBarCode";
            this.bcBarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.bcBarCode.SizeF = new System.Drawing.SizeF(298F, 31F);
            this.bcBarCode.StylePriority.UseFont = false;
            this.bcBarCode.StylePriority.UseTextAlignment = false;
            this.bcBarCode.Symbology = code128Generator1;
            this.bcBarCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblSlot3
            // 
            this.lblSlot3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DataSlot3")});
            this.lblSlot3.Dpi = 100F;
            this.lblSlot3.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlot3.LocationFloat = new DevExpress.Utils.PointFloat(4.999995F, 47.81F);
            this.lblSlot3.Name = "lblSlot3";
            this.lblSlot3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSlot3.SizeF = new System.Drawing.SizeF(181.8438F, 12.19392F);
            this.lblSlot3.StylePriority.UseFont = false;
            this.lblSlot3.StylePriority.UseTextAlignment = false;
            this.lblSlot3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblSlot4
            // 
            this.lblSlot4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DataSlot4")});
            this.lblSlot4.Dpi = 100F;
            this.lblSlot4.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlot4.LocationFloat = new DevExpress.Utils.PointFloat(207.24F, 47.81F);
            this.lblSlot4.Name = "lblSlot4";
            this.lblSlot4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSlot4.SizeF = new System.Drawing.SizeF(187.7574F, 12.19392F);
            this.lblSlot4.StylePriority.UseFont = false;
            this.lblSlot4.StylePriority.UseTextAlignment = false;
            this.lblSlot4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Chronos.Data.Shared.Model.Template_ComponentSet128_Data);
            // 
            // LabelTemplate_ComponentSet128
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.DataSource = this.bindingSource1;
            this.Margins = new System.Drawing.Printing.Margins(1, 1, 2, 2);
            this.PageHeight = 150;
            this.PageWidth = 400;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "16.2";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel lblSlot2;
        private DevExpress.XtraReports.UI.XRLabel lblSlot1;
        private DevExpress.XtraReports.UI.XRBarCode bcBarCode;
        private DevExpress.XtraReports.UI.XRLabel lblSlot3;
        private DevExpress.XtraReports.UI.XRLabel lblSlot4;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
