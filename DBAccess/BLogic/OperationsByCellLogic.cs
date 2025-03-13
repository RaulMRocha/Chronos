using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class OperationsByCellLogic
    {
        public static OperationsByCell GetOperationByCellById(IChronosGlobal chronosGlobal, int OBCId)
        {
            OperationsByCell RecDataList = null;
            DataTable obcMainInfo = OperationsByCellData.GetOperationByCellById(chronosGlobal, OBCId);
            if (obcMainInfo.Rows.Count > 0)
            {
                OperationsByCell lclOBC = new OperationsByCell();
                foreach (DataRow row in obcMainInfo.Rows)
                {
                    RecDataList = new OperationsByCell
                    {
                        OBCId = int.Parse(row["OBCId"].ToString()),
                        CellId = int.Parse(row["CellId"].ToString()),
                        UnityFacilityId = int.Parse(row["UnityFacilityId"].ToString()),
                        UnityCellId = int.Parse(row["UnityCellId"].ToString()),
                        BUId = int.Parse(row["BUId"].ToString()),
                        CellName = row["CellName"].ToString(),
                        WorkCenter = row["WorkCenter"].ToString(),
                        DepartmentNumber = int.Parse(row["DepartmentNumber"].ToString()),
                        OperationId = int.Parse(row["OperationId"].ToString()),
                        OperationName_en = row["OperationName_en"].ToString(),
                        OperationName_es = row["OperationName_es"].ToString(),
                        TRESSOperationCode = row["TRESSOperationCode"].ToString(),
                        ForceCertification = bool.Parse(row["ForceCertification"].ToString()),
                        IsStartOfCell = bool.Parse(row["IsStartOfCell"].ToString()),
                        IsEndOfCell = bool.Parse(row["IsEndOfCell"].ToString()),
                        Active = bool.Parse(row["Active"].ToString())
                    };
                }
            }
            return RecDataList;
        }

        public static DataTable GetOperationByCellConfigById(IChronosGlobal chronosGlobal, int OBCId)
        {
            return OperationsByCellData.GetOperationByCellConfigById(chronosGlobal, OBCId);
        }
    }
}
