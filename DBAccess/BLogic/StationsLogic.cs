using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class StationsLogic
    {
        public static void UpdateStationData(IChronosGlobal chronosGlobal, string PCName, string VersionName, string ADUser)
        {
            StationsData.UpdateStationData(chronosGlobal, PCName, VersionName, ADUser);
        }

        public static DataTable GetMainConfiguration(IChronosGlobal chronosGlobal, string ADUser, int UnityFacilityId)
        {
            return StationsData.GetMainConfiguration(chronosGlobal, ADUser, UnityFacilityId);
        }

        public static DataTable GetSecondaryConfiguration(IChronosGlobal chronosGlobal, int StationId)
        {
            return StationsData.GetSecondaryConfiguration(chronosGlobal, StationId);
        }

        public static DataTable GetStationInstructions(IChronosGlobal chronosGlobal, string InputName)
        {
            return StationsData.GetStationInstructions(chronosGlobal, InputName);
        }
    }
}
