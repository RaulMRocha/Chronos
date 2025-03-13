using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Chronos.Data.Shared.Model.Enumerations;
using static Chronos.Data.Shared.Model.ERP;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class FlowsLogic
    {
        public static void ValidateFlow(IChronosGlobal chronosGlobal, string LicensePlate, int CurrentOBCId, int ComponentId, string ModelName, List<Flows> StationFlow, out bool IsValidFlow, out string NextOpName, out string ErrorMessage)
        {
            IsValidFlow = false;
            NextOpName = "";
            ErrorMessage = "";
            
            TrackingLogs LastRecord = TrackingLogsLogic.GetRecordData(chronosGlobal, LicensePlate);
            
            Flows flow = GetFlowByCurrentOBCId(chronosGlobal, LastRecord.OperationByCellId).Where(r => r.ModelSettingValue == ModelName && r.ComponentId == ComponentId).FirstOrDefault();
            if(flow == null)
            {
                ErrorMessage = "Error: Flujo inválido para el componente escaneado";
                return;
            }

            if(flow.Next_OBCId == 0)
            {
                ErrorMessage = "Error de flujo: el componente escaneado ya terminó su proceso o se convirtió en otro componente";
                return;
            }

            if(CurrentOBCId == flow.Next_OBCId)
            {
                IsValidFlow = true;
                NextOpName = "";
                ErrorMessage = "";
            }
            else
            {
                OperationsByCell lclOBC = OperationsByCellLogic.GetOperationByCellById(chronosGlobal, flow.Next_OBCId);
                IsValidFlow = false;
                NextOpName = lclOBC.OperationName_es;
                ErrorMessage = "";
            }
        }

        public static List<Flows> GetFlowByCurrentOBCId(IChronosGlobal chronosGlobal, int CurrentOBCId)
        {
            List<Flows> RecDataList = new List<Flows>();
            DataTable dtFlows = FlowsData.GetFlowByCurrentOBCId(chronosGlobal, CurrentOBCId);
            if (dtFlows.Rows.Count > 0)
            {
                foreach (DataRow row in dtFlows.Rows)
                {
                    Flows flow = new Flows
                    {
                        FlowId = int.Parse(row["FlowId"].ToString()),
                        ModelId = int.Parse(row["ModelId"].ToString()),
                        ModelName = row["ModelName"].ToString(),
                        ModelSettingKey = row["ModelSettingKey"].ToString(),
                        ModelSettingValue = row["ModelSettingValue"].ToString(),
                        ModelComments = row["ModelComments"].ToString(),
                        ComponentId = int.Parse(row["ComponentId"].ToString()),
                        ComponentName = row["ComponentName"].ToString(),
                        ComponentDesc = row["ComponentDesc"].ToString(),
                        OnePerOrder = bool.Parse(row["OnePerOrder"].ToString()),
                        UsesFRN = bool.Parse(row["UsesFRN"].ToString()),
                        LabelTypeId = int.Parse(row["LabelTypeId"].ToString()),
                        LabelTypeCode = row["LabelTypeCode"].ToString(),
                        LabelTypeName = row["LabelTypeName"].ToString(),
                        LabelTypeTemplateId = int.Parse(row["LabelTypeTemplateId"].ToString()),
                        LabelTemplateName = row["LabelTemplateName"].ToString(),
                        LabelTemplateCode = row["LabelTemplateCode"].ToString(),
                        DataSlots = int.Parse(row["DataSlots"].ToString()),
                        LabelCode = row["LabelCode"].ToString(),
                        LabelQtyFRNSegment = row["LabelQtyFRNSegment"].ToString(),
                        Current_OBCId = int.Parse(row["CurrentOBCId"].ToString()),
                        Current_CellId = int.Parse(row["CurrentCellId"].ToString()),
                        Current_UnityFacilityId = int.Parse(row["CurrentUnityFacilityId"].ToString()),
                        Current_UnityCellId = int.Parse(row["CurrentUnityCellId"].ToString()),
                        Current_BUId = int.Parse(row["CurrentBUId"].ToString()),
                        Current_OperationId = int.Parse(row["CurrentOperationId"].ToString()),
                        Prev_OBCId = int.Parse(row["PrevOperationByCellId"].ToString()),
                        Prev_CellId = int.Parse(row["PrevCellId"].ToString()),
                        Prev_UnityFacilityId = int.Parse(row["PrevUnityFacilityId"].ToString()),
                        Prev_UnityCellId = int.Parse(row["PrevUnityCellId"].ToString()),
                        Prev_BUId = int.Parse(row["PrevBUId"].ToString()),
                        Prev_OperationId = int.Parse(row["PrevOperationId"].ToString()),
                        Next_OBCId = int.Parse(row["NextOperationByCellId"].ToString()),
                        Next_CellId = int.Parse(row["NextCellId"].ToString()),
                        Next_UnityFacilityId = int.Parse(row["NextUnityFacilityId"].ToString()),
                        Next_UnityCellId = int.Parse(row["NextUnityCellId"].ToString()),
                        Next_BUId = int.Parse(row["NextBUId"].ToString()),
                        Next_OperationId = int.Parse(row["NextOperationId"].ToString())
                    };
                    RecDataList.Add(flow);
                }
            }

            return RecDataList;
        }

        public static void IsModelFlowValid(IChronosGlobal chronosGlobal, ChronosLabelTypes LabelType, string LabelBarcode, bool UsesFRN, List<Flows> StationFlow, out bool IsValidModelFlow, out string ModelName)
        {
            IsValidModelFlow = false;
            ModelName = "";

            //Exit Validation if not uses FRN
            if (!UsesFRN)
            {
                IsValidModelFlow = true;
                ModelName = "";
            }

            if (LabelType != ChronosLabelTypes.LabelLevel0) /*Sales Order*/
            {
                string WorkTag = ChronosValidations.GetWorkTagFromTrackingCode(LabelBarcode);
                List<SGP_WorkOrderSegments> WorkTagSegments = ERPLogic.GetBuildInstructions(chronosGlobal, WorkTag);

                //FIND * in models
                Flows starModel = StationFlow.Find(r => r.ModelSettingKey == "*");

                if (starModel == null) //Accepts only especific models
                    foreach (Flows flow in StationFlow)
                    {
                        SGP_WorkOrderSegments FRNModelInfo = WorkTagSegments.Find(r => r.SegmentName == flow.ModelSettingKey);
                        if (FRNModelInfo == null)
                            return;
                        if (FRNModelInfo.CfgCodeENU == flow.ModelSettingValue)
                        {
                            IsValidModelFlow = true;
                            ModelName = FRNModelInfo.CfgCodeENU;
                            return;
                        }
                        else
                        {
                            ModelName = FRNModelInfo.CfgCodeENU;
                        }


                    }
                else
                    IsValidModelFlow = true;
            }
        }
    }
}
