using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class LabelTypesData
    {
        public static DataTable GetLabelTypeById(IChronosGlobal _chronosGlobal, int LabelTypeId)
        {
            string Select = @"SELECT [Id]
                                    ,[LabelTypeCode]
                                    ,[LabelTypeName] 
                            FROM [Chronos].[dbo].[LabelTypes]  
	                        WHERE Id = '" + LabelTypeId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetLabelTypeTemplateById(IChronosGlobal _chronosGlobal, int LabelTypeTemplateId)
        {
            string Select = @"SELECT [Id]
                                  ,[LabelTypeId]
                                  ,[LabelTemplateName]
                                  ,[LabelTemplateCode]
                                  ,[DataSlots] 
                            FROM [Chronos].[dbo].[LabelTypesTemplates] 
                            WHERE Id = '" + LabelTypeTemplateId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetLabelTypeTemplateByTypeId(IChronosGlobal _chronosGlobal, int LabelTypeId)
        {
            string Select = @"SELECT [Id]
                                  ,[LabelTypeId]
                                  ,[LabelTemplateName]
                                  ,[LabelTemplateCode]
                                  ,[DataSlots] 
                            FROM [Chronos].[dbo].[LabelTypesTemplates] 
                            WHERE LabelTypeId = '" + LabelTypeId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
    }
}
