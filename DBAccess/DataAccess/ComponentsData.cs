using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class ComponentsData
    {
        public static DataTable GetComponentById(IChronosGlobal _chronosGlobal, int ComponentId)
        {
            string Select = @"SELECT [ComponentId]
                                      ,[ModelId]
                                      ,[ModelName]
                                      ,[ComponentName]
                                      ,[ComponentDesc]
                                      ,[OnePerOrder]
                                      ,[UsesFRN]
                                      ,[LabelTypeId]
                                      ,[LabelTypeCode]
                                      ,[LabelTypeName]
                                      ,[LabelTypeTemplateId]
                                      ,[LabelTemplateName]
                                      ,[LabelTemplateCode]
                                      ,[DataSlots]
                                      ,[LabelCode]
                                      ,[LabelQtyFRNSegment]
                                      ,[CreationDate]
                                      ,[CreatedBy]
                                      ,[LastUpdatedDate]
                                      ,[LastUpdatedBy]
                                      ,[Active] 
                                FROM [Chronos].[dbo].[vw_Components]  
	                            WHERE ComponentId = '" + ComponentId + "' AND Active = 1 ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetComponentIdByLicensePlate(IChronosGlobal _chronosGlobal, string LicensePlate)
        {
            string Select = @"SELECT TOP 1 [ComponentId] 
                              FROM [Chronos].[dbo].[TrackingLogs] 
                              WHERE InputLicensePlate = '" + LicensePlate + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetComponentByLabelTypeCode(IChronosGlobal _chronosGlobal, string LabelTypeCode)
        {
            string Select = @"SELECT [ComponentId]
                                      ,[ModelId]
                                      ,[ModelName]
                                      ,[ComponentName]
                                      ,[ComponentDesc]
                                      ,[OnePerOrder]
                                      ,[UsesFRN]
                                      ,[LabelTypeId]
                                      ,[LabelTypeCode]
                                      ,[LabelTypeName]
                                      ,[LabelTypeTemplateId]
                                      ,[LabelTemplateName]
                                      ,[LabelTemplateCode]
                                      ,[DataSlots]
                                      ,[LabelCode]
                                      ,[LabelQtyFRNSegment]
                                      ,[CreationDate]
                                      ,[CreatedBy]
                                      ,[LastUpdatedDate]
                                      ,[LastUpdatedBy]
                                      ,[Active] 
                                FROM [Chronos].[dbo].[vw_Components]  
	                            WHERE LabelTypeCode = '" + LabelTypeCode + "' AND Active = 1 ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetComponentLabelConfigByComponentId(IChronosGlobal _chronosGlobal, int ComponentId)
        {
            string Select = @"SELECT [Id]
                                      ,[ComponentId]
                                      ,[DataSlotNumber]
                                      ,[ConstantValue]
                                      ,[VariableValue] 
                                  FROM [Chronos].[dbo].[ComponentsLabelsConfig] 
	                            WHERE ComponentId = '" + ComponentId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetComponentSetComponents(IChronosGlobal chronosGlobal, string ComponentIds, string WorkTag)
        {
            ComponentIds = ComponentIds.Replace(",", "','");

            string WT2 = ChronosValidations.GetOrderNumberFromTrackingCode(WorkTag) + ".000";

            string Select = @"SELECT [ComponentId]
                                    ,[ModelId]
                                    ,[ModelName]
                                    ,[ComponentName]
                                    ,[ComponentDesc]
	                                ,[RunNumber]
	                                ,[WorkTag]
	                                ,[InputLicensePlate]
                                    ,[OutputLicensePlate]
                                    ,[OnePerOrder]
                                    ,[UsesFRN]
                                    ,[LabelTypeId]
                                    ,[LabelTypeCode]
                                    ,[LabelTypeName]
                                    ,[LabelTypeTemplateId]
                                    ,[LabelTemplateName]
                                    ,[LabelTemplateCode]
                                    ,[DataSlots]
                                    ,[LabelCode]
                                    ,[LabelQtyFRNSegment] 
                                FROM (
                                    SELECT DISTINCT comp.[ComponentId]
                                        ,comp.[ModelId]
                                        ,comp.[ModelName]
                                        ,comp.[ComponentName]
                                        ,[ComponentDesc]
	                                    ,[RunNumber]
	                                    ,[WorkTag]
	                                    ,[LicensePlate] AS 'InputLicensePlate'
		                                ,CASE WHEN [LicensePlate] = [LastReportedOutputLicensePlate] THEN NULL ELSE [LastReportedOutputLicensePlate] END AS 'OutputLicensePlate'
                                        ,[OnePerOrder]
                                        ,[UsesFRN]
                                        ,[LabelTypeId]
                                        ,[LabelTypeCode]
                                        ,[LabelTypeName]
                                        ,[LabelTypeTemplateId]
                                        ,[LabelTemplateName]
                                        ,[LabelTemplateCode]
                                        ,[DataSlots]
                                        ,[LabelCode]
                                        ,[LabelQtyFRNSegment]   
                                    FROM [Chronos].[dbo].[vw_Components] comp  
	                                    INNER JOIN [dbo].[fn_GetLicensePlatesInProcessAll]() wip ON wip.ComponentId = comp.ComponentId 
                                    WHERE (WorkTag = '" + WorkTag + "' OR WorkTag = '" + WT2 + "') AND comp.ComponentId in ('" + ComponentIds + "')  AND comp.Active = 1) a ";
            
            //Select = Select + "WHERE OnePerOrder = 0 OR (OnePerOrder = 1 AND WorkTag NOT IN (SELECT WorkTag FROM [Chronos].[dbo].[TrackingLogs] WHERE WorkTag = '" + WT2 + "' AND InputLicensePlate != OutputLicensePlate)) ";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }
    }
}
