namespace Chronos.Data.Shared.Model
{
    public class Enumerations
    {
        public enum ChronosLabelTypes
        {
            LabelLevel0, /*Sales Order*/
            LabelLevel1, /*Worktag*/
            LabelLevel2, /*Unit*/
            LabelLevel3,  /*Unit Subassy*/
            LabelLevel4,  /*Component Set*/
            LabelLevel5,  /*Cut Number*/
            LabelLevel6,  /*Box*/
            Unknown
        }

        public enum UserInputs
        {
            BadgeID,
            Defect,
            DownTime,
            LabelLevel0,  /*Sales Order*/
            LabelLevel1,  /*Worktag*/
            LabelLevel2,  /*Unit*/
            LabelLevel3,  /*Unit Subassy*/
            LabelLevel4,  /*Component Set*/
            LabelLevel5,  /*Cut Number*/
            LabelLevel6,  /*Box*/
            Unknown
        }

        public enum DownTimeCommands
        {
            NOT_OPEN,
            OPEN,
            ATTEND,
            CLOSE
        }

        public enum ChronosScreens
        {
            None,
            DownTime,
            EmployeeValidation,
            RackManagement,
            Tracking,
            OrderConsolidation,
            LineConsolidation,
            PrintLabels,
            TrackingReport
        }

        public enum ChronosScreensActions
        {
            Replace,
            OnTop,
            PopOver
        }
    }
}

