using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using System.Collections.Generic;
using static Chronos.Data.Shared.Model.ERP;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class ERPLogic
    {
        public static bool IsValidWorkTag(IChronosGlobal chronosGlobal, string WorkTag)
        {
            return (GetMFGOrderNumberInfoByOrder(chronosGlobal, WorkTag) != null ? true : false);
        }
        
        public static List<SGP_WorkOrderSegments> GetBuildInstructions(IChronosGlobal chronosGlobal, string WorkTag)
        {
            List<SGP_WorkOrderSegments> ERPInfo = ERPData.GetBuildInstructions(chronosGlobal, WorkTag);
            if(ERPInfo == null)
                ERPData.UpdateERPData(chronosGlobal, WorkTag);

            return ERPData.GetBuildInstructions(chronosGlobal, WorkTag);
        }

        public static M1P_WorkOrderHeader GetMFGOrderNumberInfoByOrder(IChronosGlobal chronosGlobal, string WorkTag)
        {
            M1P_WorkOrderHeader ERPInfo = ERPData.GetMFGOrderNumberInfoByOrder(chronosGlobal, WorkTag);
            if (ERPInfo == null)
                ERPData.UpdateERPData(chronosGlobal, WorkTag);

            return ERPData.GetMFGOrderNumberInfoByOrder(chronosGlobal, WorkTag);
        }
    }
}
