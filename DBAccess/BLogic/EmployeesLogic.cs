using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class EmployeesLogic
    {
        public static bool IsValidEmployeeBadge(IChronosGlobal chronosGlobal, string EmpBadge, int UnityFacilityId)
        {
            if (GetEmployeeData(chronosGlobal, EmpBadge, UnityFacilityId).Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static DataTable GetEmployeeData(IChronosGlobal chronosGlobal, string EmpBadge, int UnityFacilityId)
        {
            return EmployeesData.GetEmployeeData(chronosGlobal, EmpBadge, UnityFacilityId);
        }

        public static DataTable GetEmployeeCertificationData(IChronosGlobal chronosGlobal, string EmpBadge, int UnityFacilityId, string CertifiedOperationCode)
        {
            return EmployeesData.GetEmployeeCertificationData(chronosGlobal, EmpBadge, UnityFacilityId, CertifiedOperationCode);
        }
    }
}
