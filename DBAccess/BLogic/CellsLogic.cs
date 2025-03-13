using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class CellsLogic
    {
        public static DataTable GetCellById(IChronosGlobal chronosGlobal, int CellId)
        {
            return CellsData.GetCellById(chronosGlobal, CellId);
        }

        public static DataTable GetCellsSettingsByCellId(IChronosGlobal chronosGlobal, int CellId)
        {
            return CellsData.GetCellsSettingsByCellId(chronosGlobal, CellId);
        }
    }
}
