using System;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using static Chronos.Data.Shared.Model.Enumerations;

namespace Chronos.Data.Shared
{
    public static class ChronosValidations
    {
        public static bool IsNetworkAvailable()
        {
            bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            return networkUp;
        }

        public static bool PrinterExists(string printerName)
        {
            if (string.IsNullOrEmpty(printerName)) { throw new ArgumentNullException("printerName"); }
            return PrinterSettings.InstalledPrinters.Cast<string>().Any(name => printerName.ToUpper().Trim() == name.ToUpper().Trim());
        }

        /// <summary>
        /// Defines what type of input the user is providing.
        /// </summary>
        /// <param name="UserInput"></param>
        /// <returns></returns>
        public static UserInputs GetInputType(string UserInput, int PlantId)
        {
            string formattedData = UserInput.Trim(' ', '\t', '\r', '\n');

            if (formattedData.Length == 7 && formattedData.Substring(0, 2).ToUpper() == "DC") //Defect Validation
            {
                return UserInputs.Defect;
            }
            else if (formattedData.Length == 7 && formattedData.Substring(0, 2).ToUpper() == "DT") //Downtime Validation
            {
                return UserInputs.DownTime;
            }
            else if (IsLevel0Label(formattedData)) //SalesOrder Validation
            {
                return UserInputs.LabelLevel0;
            }
            else if (IsLevel1Label(formattedData)) //WorkTag Validation
            {
                return UserInputs.LabelLevel1;
            }
            else if (IsLevel2Label(formattedData)) //Unit Validation
            {
                return UserInputs.LabelLevel2;
            }
            else if (IsLevel3Label(formattedData)) //Subassy Validation
            {
                return UserInputs.LabelLevel3;
            }
            else if (IsLevel4Label(formattedData)) //Comp Set Validation
            {
                return UserInputs.LabelLevel4;
            }
            else if (IsEmployee(formattedData, PlantId)) //Try as user
            {
                return UserInputs.BadgeID;
            }
            return UserInputs.Unknown;
        }

        public static ChronosLabelTypes GetLabelType(string LabelTypeString)
        {
            ChronosLabelTypes result = ChronosLabelTypes.Unknown;
            switch (LabelTypeString)
            {
                case "LabelLevel0": result = ChronosLabelTypes.LabelLevel0; break;
                case "LabelLevel1": result = ChronosLabelTypes.LabelLevel1; break;
                case "LabelLevel2": result = ChronosLabelTypes.LabelLevel2; break;
                case "LabelLevel3": result = ChronosLabelTypes.LabelLevel3; break;
                case "LabelLevel4": result = ChronosLabelTypes.LabelLevel4; break;
                case "LabelLevel5": result = ChronosLabelTypes.LabelLevel5; break;
                case "LabelLevel6": result = ChronosLabelTypes.LabelLevel6; break;
            }
            return result;
        }

        public static ChronosLabelTypes GetLabelType(UserInputs userInput)
        {
            ChronosLabelTypes result = ChronosLabelTypes.Unknown;
            switch (userInput)
            {
                case UserInputs.LabelLevel0: result = ChronosLabelTypes.LabelLevel0; break;
                case UserInputs.LabelLevel1: result = ChronosLabelTypes.LabelLevel1; break;
                case UserInputs.LabelLevel2: result = ChronosLabelTypes.LabelLevel2; break;
                case UserInputs.LabelLevel3: result = ChronosLabelTypes.LabelLevel3; break;
                case UserInputs.LabelLevel4: result = ChronosLabelTypes.LabelLevel4; break;
                case UserInputs.LabelLevel5: result = ChronosLabelTypes.LabelLevel5; break;
                case UserInputs.LabelLevel6: result = ChronosLabelTypes.LabelLevel6; break;
            }
            return result;
        }

        public static string GetOrderNumberFromTrackingCode(string LicensePlate)
        {
            return LicensePlate.Substring(0, LicensePlate.IndexOf("."));
        }

        public static string GeLineNumberFromTrackingCode(string LicensePlate)
        {
            return LicensePlate.Substring(LicensePlate.IndexOf(".") + 1, 3);
        }

        public static string GetWorkTagFromTrackingCode(string LicensePlate)
        {
            return LicensePlate.Substring(0, LicensePlate.IndexOf(".") + 4);
        }

        public static string GetComponentFromTrackingCode(string LicensePlate)
        {
            return LicensePlate.Substring(LicensePlate.LastIndexOf(".") + 1, LicensePlate.Length - LicensePlate.LastIndexOf(".") - 1);
        }


        private static bool IsLevel0Label(string formattedData)
        {
            /*Format: 12345678*/
            string ManufacturingNumberPattern = @"(\d{4,})$";
            Match match = Regex.Match(formattedData, ManufacturingNumberPattern);
            if (match.Success)
            {
                if (decimal.TryParse(match.Value, out decimal manufacturingNumber))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsLevel1Label(string formattedData)
        {
            /*Format: 12345678.001*/
            string ManufacturingNumberPattern = @"(\d{4,}\.\d{3})$";
            Match match = Regex.Match(formattedData, ManufacturingNumberPattern);
            if (match.Success)
            {
                if (decimal.TryParse(match.Value, out decimal manufacturingNumber))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsLevel2Label(string formattedData)
        {
            /*Format: 12345678.001.001*/
            string ManufacturingNumberPattern = @"(\d{4,}\.\d{3}\.\d{3})$";
            Match match = Regex.Match(formattedData, ManufacturingNumberPattern);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private static bool IsLevel3Label(string formattedData)
        {
            /*Format: 12345678.001.001.PNL01*/
            string ManufacturingNumberPattern = @"(\d{4,}\.\d{3}\.\d{3}\.[a-zA-Z0-9]{5})$";
            Match match = Regex.Match(formattedData, ManufacturingNumberPattern);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private static bool IsLevel4Label(string formattedData)
        {
            /*Format: 12345678.001.001.PNLSET*/
            string ManufacturingNumberPattern = @"(\d{4,}\.\d{3}\.\d{3}\.[a-zA-Z]{6})$";
            Match match = Regex.Match(formattedData, ManufacturingNumberPattern);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private static bool IsEmployee(string formattedData, int PlantId)
        {
            formattedData = formattedData.Trim(' ', '\t', '\r', '\n');
            formattedData = Regex.Replace(formattedData, "[^0-9]", "");

            if ((formattedData.Length > 5 && formattedData.Substring(0,1) == PlantId.ToString()) ||(formattedData.Length > 5))
            {
                string badgeId = formattedData.Substring(formattedData.Length - 5, 5);
                return true;
            }
            return false;
        }

        public static string GetBadgeId(string formattedData, int PlantId)
        {
            formattedData = formattedData.Trim(' ', '\t', '\r', '\n');
            formattedData = Regex.Replace(formattedData, "[^0-9]", "");

            if (formattedData.Length > 5)
            {
                return int.Parse(formattedData.Substring(formattedData.Length - 5, 5)).ToString();
            }
            return null;
        }
        
    }
}
