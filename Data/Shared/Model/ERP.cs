namespace Chronos.Data.Shared.Model
{
    public class ERP
    {
        public class WorkOrderHeader
        {
            public string M1RUN_RunNumber { get; set; }
            public string M1MWO_MFGOrderNumber { get; set; }
            public string M1ORD_SalesOrderNumber { get; set; }
            public string M1WH_Warehouse { get; set; }
            public string M1WHADDR_WarehouseAddress { get; set; }
            public string M1PN_ProductNumber { get; set; }
            public string M1DESC_ProductDescription { get; set; }
            public string M1OQ_OrderQuantity { get; set; }
            public string M1TOQ_TotalOrderQuantity { get; set; }
            public string M1STRT_ScheduledStartDate { get; set; }
            public string M1DUE_ScheduledDueDate { get; set; }
            public string M1CRQD_CustomerRequestedDeliveryDate { get; set; }
            public string M1OPDT_OrigPrintTimeStamp { get; set; }
            public string M1PRDT_PrintTimeStamp { get; set; }
            public string M1BTKY_SoldToCustomer { get; set; }
            public string M1STKY_ShipToCustomer { get; set; }
            public string M1CMNAME_CustomerName { get; set; }
            public string M1PRKY_PriceAsCustomer { get; set; }
            public string M1SPO_CustomerPO { get; set; }
            public string M1FF3_GuaranteedDelivery { get; set; }
            public string M1CANO_CanadianOrder { get; set; }
            public int BlindNumber { get; set; }
            public string M1EORD_ExternalOrderNumber { get; set; }
            public string M1EITM_ExternalOrderLine { get; set; }
            public string M1OHBPO_MarkFor { get; set; }
        }

        public class SGP_WorkOrderSegments
        {
            public string RunNumber { get; set; }
            public string MFGOrderNumber { get; set; }
            public string SegmentName { get; set; }
            public string CfgCodeENU { get; set; }
            public string CfgCodeNumeric { get; set; }
            public string ConfigDescENU { get; set; }
        }
    }
}
