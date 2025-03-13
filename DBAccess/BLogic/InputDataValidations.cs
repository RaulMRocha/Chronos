using Chronos.Data.Shared;
using static Chronos.Data.Shared.Model.Enumerations;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class InputDataValidations
    {
        public static void ValidateUserDataInput(IChronosGlobal chronosGlobal, string input, int FacilityId, out UserInputs InputType, out bool IsValid)
        {
            UserInputs userInput = ChronosValidations.GetInputType(input, FacilityId);
            InputType = userInput;
            IsValid = false;
            switch (userInput)
            {
                case UserInputs.BadgeID:
                    IsValid = EmployeesLogic.IsValidEmployeeBadge(chronosGlobal, input, FacilityId);
                    break;
                case UserInputs.Defect:

                    break;
                case UserInputs.DownTime:

                    break;
                case UserInputs.LabelLevel0: /*Sales Order*/

                    break;
                case UserInputs.LabelLevel1: /*Worktag*/
                    IsValid = ERPLogic.IsValidWorkTag(chronosGlobal, input);
                    break;
                case UserInputs.LabelLevel2: /*Unit*/

                    break;
                case UserInputs.LabelLevel3: /*Unit Subassy*/
                    var data = TrackingLogsLogic.GetRecordData(chronosGlobal, input);
                    if (data != null)
                        IsValid = true;
                    break;
                case UserInputs.LabelLevel4: /*Component Set*/
                    var data2 = TrackingLogsLogic.GetRecordData(chronosGlobal, input);
                    if (data2 != null)
                        IsValid = true;
                    break;
                case UserInputs.LabelLevel5: /*Cut Number*/

                    break;
                case UserInputs.LabelLevel6: /*Box*/
                    var data3 = TrackingLogsLogic.GetRecordData(chronosGlobal, input);
                    if (data3 != null)
                        IsValid = true;
                    break;
                case UserInputs.Unknown:
                    IsValid = false;
                    break;
                default:
                    break;
            }
        }
    }
}
