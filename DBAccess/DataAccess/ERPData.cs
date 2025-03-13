using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Chronos.Data.Shared.Model.ERP;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class ERPData
    {
        public static List<SGP_WorkOrderSegments> GetBuildInstructions(IChronosGlobal chronosGlobal, string WorkTag)
        {
            string SelectBuildInstructionsSegments = @"SELECT [SGRUN_RunNumber] AS 'RunNumber'
                                                              ,[SGMWO_MFGOrderNumber] AS 'MFGOrderNumber'
                                                              ,[SGSEG_SegmentName] AS 'SegmentName'
                                                              ,[SGCFGE_CfgCodeENU] AS 'CfgCodeENU'
                                                              ,[SGCFGN_CfgCodeNumeric] AS 'CfgCodeNumeric'
                                                              ,[SGDSCE_ConfigDescENU] AS 'ConfigDescENU'
                                                          FROM [Chronos].[dbo].[SGP_WorkOrderSegments]
                                                          WHERE SGMWO_MFGOrderNumber = @MFGOrderNumber";

            List<SGP_WorkOrderSegments> RS = new List<SGP_WorkOrderSegments>();
            using (SqlConnection connection = DBConnection.GetConnection(chronosGlobal.ConnectToProd, chronosGlobal.ServerName, chronosGlobal.DatabaseName))
            {
                using (SqlCommand command = new SqlCommand(SelectBuildInstructionsSegments, connection))
                {
                    command.Parameters.AddWithValue("@MFGOrderNumber", WorkTag);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RS.Add(new SGP_WorkOrderSegments
                            {
                                RunNumber = reader["RunNumber"].ToString(),
                                MFGOrderNumber = reader["MFGOrderNumber"].ToString(),
                                SegmentName = reader["SegmentName"].ToString(),
                                CfgCodeENU = reader["CfgCodeENU"].ToString(),
                                CfgCodeNumeric = reader["CfgCodeNumeric"].ToString(),
                                ConfigDescENU = reader["ConfigDescENU"].ToString()
                            });
                        }
                    }
                }
            }
            return RS;
        }

        public static M1P_WorkOrderHeader GetMFGOrderNumberInfoByOrder(IChronosGlobal chronosGlobal, string WorkTag)
        {
            string SelectOPTRunInfo = @"SELECT [M1RUN_RunNumber],[M1MWO_MFGOrderNumber],[M1ORD_SalesOrderNumber],[M1WH_Warehouse],[M1WHADDR_WarehouseAddress]
                                                    ,[M1PN_ProductNumber],[M1DESC_ProductDescription],[M1OQ_OrderQuantity],[M1TOQ_TotalOrderQuantity],[M1STRT_ScheduledStartDate]
                                                    ,[M1DUE_ScheduledDueDate],[M1CRQD_CustomerRequestedDeliveryDate],[M1OPDT_OrigPrintTimeStamp],[M1PRDT_PrintTimeStamp]
                                                    ,[M1BTKY_SoldToCustomer],[M1STKY_ShipToCustomer],[M1CMNAME_CustomerName],[M1PRKY_PriceAsCustomer],[M1SPO_CustomerPO]
                                                    ,[M1FF3_GuaranteedDelivery],[M1CANO_CanadianOrder],[BlindNumber],[M1EORD_ExternalOrderNumber],[M1EITM_ExternalOrderLine],[M1OHBPO_MarkFor]
                                                FROM [Chronos].[dbo].[M1P_WorkOrderHeader] WITH(NOLOCK) 
                                                WHERE M1MWO_MFGOrderNumber = @M1MWO_MFGOrderNumber ";

            using (SqlConnection connection = DBConnection.GetConnection(chronosGlobal.ConnectToProd, chronosGlobal.ServerName, chronosGlobal.DatabaseName))
            {
                using (SqlCommand command = new SqlCommand(SelectOPTRunInfo, connection))
                {
                    command.Parameters.AddWithValue("@M1MWO_MFGOrderNumber", WorkTag);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new M1P_WorkOrderHeader
                            {
                                M1RUN_RunNumber = reader["M1RUN_RunNumber"].ToString(),
                                M1MWO_MFGOrderNumber = reader["M1MWO_MFGOrderNumber"].ToString(),
                                M1ORD_SalesOrderNumber = reader["M1ORD_SalesOrderNumber"].ToString(),
                                M1WH_Warehouse = reader["M1WH_Warehouse"].ToString(),
                                M1WHADDR_WarehouseAddress = reader["M1WHADDR_WarehouseAddress"].ToString(),
                                M1PN_ProductNumber = reader["M1PN_ProductNumber"].ToString(),
                                M1DESC_ProductDescription = reader["M1DESC_ProductDescription"].ToString(),
                                M1OQ_OrderQuantity = reader["M1OQ_OrderQuantity"].ToString(),
                                M1TOQ_TotalOrderQuantity = reader["M1TOQ_TotalOrderQuantity"].ToString(),
                                M1STRT_ScheduledStartDate = reader["M1STRT_ScheduledStartDate"].ToString(),
                                M1DUE_ScheduledDueDate = reader["M1DUE_ScheduledDueDate"].ToString(),
                                M1CRQD_CustomerRequestedDeliveryDate = reader["M1CRQD_CustomerRequestedDeliveryDate"].ToString(),
                                M1OPDT_OrigPrintTimeStamp = reader["M1OPDT_OrigPrintTimeStamp"].ToString(),
                                M1PRDT_PrintTimeStamp = reader["M1PRDT_PrintTimeStamp"].ToString(),
                                M1BTKY_SoldToCustomer = reader["M1BTKY_SoldToCustomer"].ToString(),
                                M1STKY_ShipToCustomer = reader["M1STKY_ShipToCustomer"].ToString(),
                                M1CMNAME_CustomerName = reader["M1CMNAME_CustomerName"].ToString(),
                                M1PRKY_PriceAsCustomer = reader["M1PRKY_PriceAsCustomer"].ToString(),
                                M1SPO_CustomerPO = reader["M1SPO_CustomerPO"].ToString(),
                                M1FF3_GuaranteedDelivery = reader["M1FF3_GuaranteedDelivery"].ToString(),
                                M1CANO_CanadianOrder = reader["M1CANO_CanadianOrder"].ToString(),
                                BlindNumber = int.Parse(reader["BlindNumber"].ToString()),
                                M1EORD_ExternalOrderNumber = reader["M1EORD_ExternalOrderNumber"].ToString(),
                                M1EITM_ExternalOrderLine = reader["M1EITM_ExternalOrderLine"].ToString(),
                                M1OHBPO_MarkFor = reader["M1OHBPO_MarkFor"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void UpdateERPData(IChronosGlobal chronosGlobal, string WorkTag)
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection(chronosGlobal.ConnectToProd, chronosGlobal.ServerName, chronosGlobal.DatabaseName))
                {
                    using (SqlCommand command = new SqlCommand("sp_ERPData_Edit", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        command.Parameters.AddWithValue("@WorkTag", WorkTag);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (SqlException)
            {
                return;
            }
        }
    }
}
