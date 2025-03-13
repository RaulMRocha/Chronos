using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Data;


namespace Chronos.Data.DBAccess.DataAccess
{
    public static class EmployeesData
    {
        public static DataTable GetEmployeeData(IChronosGlobal _chronosGlobal, string EmpBadge, int UnityFacilityId)
        {
            string Select = @"SELECT [FacilityNumber]
                              ,[UnityFacilityId]
                              ,[FacilityId]
                              ,[EmpNumber]
                              ,[CostCenter]
                              ,[LastNameFather]
                              ,[LastNameMother]
                              ,[Names]
                              ,[Gender]
                              ,[EmpType]
                              ,[EmpShift]
                              ,[Cell]
                              ,[AreaCode]
                              ,[Area]
                              ,[OperationCode]
                              ,[Operation]
                              ,[Puesto]
                              ,[SupEmpNumber]
                              ,[SupEmpFullName]
                              ,[DateOfBirth]
                              ,[StartDate]
                              ,[PermDate]
                              ,[EndDate]
                              ,[IsActive]
                              ,[InFacility] 
                          FROM [Chronos].[dbo].[vw_TRESS_AllPlants_Employees] 
                          WHERE UnityFacilityId = " + UnityFacilityId + " AND EmpNumber = '" + EmpBadge + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
        public static DataTable GetEmployeeCertificationData(IChronosGlobal _chronosGlobal, string EmpBadge, int UnityFacilityId, string CertifiedOperationCode)
        {
            string Select = @"SELECT [UnityFacilityId]
                              ,[FacilityNumber]
                              ,[MainCostCenter]
                              ,[MainCell]
                              ,[MainAreaCode]
                              ,[MainAreaName]
                              ,[MainOperationCode]
                              ,[MainOperation]
                              ,[EmpNumber]
                              ,[Names]
                              ,[LastNameFather]
                              ,[LastNameMother]
                              ,[Gender]
                              ,[EmpShift]
                              ,[SupEmpNumber]
                              ,[SupEmpFullName]
                              ,[CertifiedOperationCode]
                              ,[CertifiedOperationName]
                              ,[Score1]
                              ,[Score2]
                              ,[Score3]
                              ,[Text1]
                              ,[Text2]
                              ,[Text3]
                              ,[CertificationDate]
                              ,[InFacility] 
                          FROM [Chronos].[dbo].[vw_TRESS_AllPlants_EmployeesCertifications] 
                          WHERE UnityFacilityId = " + UnityFacilityId + " AND EmpNumber = '" + EmpBadge + "' AND [CertifiedOperationCode] = '" + CertifiedOperationCode + "' AND [Text3] = 'CERTIFICACION'  ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
    }
}

