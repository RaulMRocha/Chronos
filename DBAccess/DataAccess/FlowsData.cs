using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class FlowsData
    {
        public static DataTable GetFlowByCurrentOBCId(IChronosGlobal _chronosGlobal, int CurrentOBCId)
        {
            string Select = @"SELECT [FlowDetailId]
                                      ,[FlowId]
                                      ,[ModelId]
                                      ,[ModelName]
                                      ,[ModelSettingKey]
                                      ,[ModelSettingValue]
                                      ,[ModelComments]
                                      ,[ComponentId]
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
                                      ,[HtmlData]
                                      ,[CurrentOBCId]
                                      ,[CurrentCellId]
                                      ,[CurrentUnityFacilityId]
                                      ,[CurrentUnityCellId]
                                      ,[CurrentBUId]
                                      ,[CurrentOperationId]
                                      ,[PrevOperationByCellId]
                                      ,[PrevCellId]
                                      ,[PrevUnityFacilityId]
                                      ,[PrevUnityCellId]
                                      ,[PrevBUId]
                                      ,[PrevOperationId]
                                      ,[NextOperationByCellId]
                                      ,[NextCellId]
                                      ,[NextUnityFacilityId]
                                      ,[NextUnityCellId]
                                      ,[NextBUId]
                                      ,[NextOperationId] 
                                FROM [Chronos].[dbo].[vw_Flows] 
	                            WHERE CurrentOBCId = '" + CurrentOBCId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
    }
}
