using static Chronos.Data.Shared.Model.Enumerations;

namespace Chronos.Modules.LabelManager.Manager
{
    public static class BarCodes
    {
        public static string CreateBarCodeForLabel(ChronosLabelTypes labelType, string OrderNumber, int LineNumber, int UnitNumber, string ComponentCode, int ComponentNumber)
        {
            string Barcode = "";
            string sLineNumber = string.Format("{0:000}", LineNumber);
            string sUnitNumber = string.Format("{0:000}", UnitNumber);
            string sComponentNumber = string.Format("{0:00}", ComponentNumber);
            switch (labelType)
            {
                case ChronosLabelTypes.LabelLevel0:
                    Barcode = OrderNumber;
                    break;
                case ChronosLabelTypes.LabelLevel1:
                    Barcode = OrderNumber + "." + sLineNumber;
                    break;
                case ChronosLabelTypes.LabelLevel2:
                    Barcode = OrderNumber + "." + sLineNumber + "." + sUnitNumber;
                    break;
                case ChronosLabelTypes.LabelLevel3:
                    Barcode = OrderNumber + "." + sLineNumber + "." + sUnitNumber + "." + ComponentCode + sComponentNumber;
                    break;
                case ChronosLabelTypes.LabelLevel4: //SET
                    Barcode = OrderNumber + "." + sLineNumber + "." + sUnitNumber + "." + ComponentCode + sComponentNumber;
                    break;
                case ChronosLabelTypes.LabelLevel5:
                    Barcode = "";
                    break;
                case ChronosLabelTypes.LabelLevel6: //BOX
                    Barcode = OrderNumber + "." + sLineNumber + "." + sUnitNumber + "." + ComponentCode +  sComponentNumber;
                    break;

            }
            return Barcode;
        }
    }
}
