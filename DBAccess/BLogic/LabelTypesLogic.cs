using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class LabelTypesLogic
    {
        public static DataTable GetLabelTypeById(IChronosGlobal chronosGlobal, int LabelTypeId)
        {
            return LabelTypesData.GetLabelTypeById(chronosGlobal, LabelTypeId);
        }

        public static DataTable GetLabelTypeTemplateById(IChronosGlobal chronosGlobal, int LabelTypeTemplateId)
        {
            return LabelTypesData.GetLabelTypeTemplateById(chronosGlobal, LabelTypeTemplateId);
        }

        public static DataTable GetLabelTypeTemplateByTypeId(IChronosGlobal chronosGlobal, int LabelTypeId)
        {
            return LabelTypesData.GetLabelTypeTemplateByTypeId(chronosGlobal, LabelTypeId);
        }
    }
}
