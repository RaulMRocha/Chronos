using Chronos.Data.IkarusWS.Calls;
using System.Collections.Generic;
using System.Data;

namespace Chronos.Data.IkarusWS
{
    public class DowntimeLogs
    {
        WebServiceCall _webServiceCall;

        public DowntimeLogs(bool ConnectToProd)
        {
            _webServiceCall = new WebServiceCall(ConnectToProd);
        }


        public DataTable DownTimeLogs_ValidateTechnician(int CodeId, string TechnicianBadge)
        {
            return _webServiceCall.CallGETService(_webServiceCall.UtilitiesServiceURI + string.Format("DownTime/ValidateTechnician?CodeId={0}&TechnicianBadge={1}", CodeId, TechnicianBadge));
        }

        public DataTable DownTimeLogs_ValidateCode(int FacilityId, string Code)
        {
            return _webServiceCall.CallGETService(_webServiceCall.UtilitiesServiceURI + string.Format("DownTime/ValidateCode?FacilityId={0}&Code={1}", FacilityId, Code));
        }


        public DataTable DownTimeLogs_Get(string FacilityId, string CellId)
        {
            return _webServiceCall.CallGETService(_webServiceCall.UtilitiesServiceURI + string.Format("DownTime/Get?FacilityId={0}&CellId={1}", FacilityId, CellId));
        }
        
        public string DownTimeLogs_Create(string FacilityId, string CellId, string OperationId, string Code, string StartedBy)
        {
            var values = new Dictionary<string, string>
            {
                  { "FacilityId", FacilityId },
                  { "CellId", CellId },
                  { "OperationId", OperationId },
                  { "Code", Code },
                  { "StartedBy", StartedBy }
            };

            return _webServiceCall.CallPOSTService(_webServiceCall.UtilitiesServiceURI + "DownTime/Create", values);
        }

        public string DownTimeLogs_Attend(string DowntimeId, string AttendedBy)
        {
            var values = new Dictionary<string, string>
            {
                  { "Id", DowntimeId },
                  { "AttendedBy", AttendedBy }
            };

            return _webServiceCall.CallPOSTService(_webServiceCall.UtilitiesServiceURI + "DownTime/Attend", values);
        }

        public string DownTimeLogs_Close(string DowntimeId, string ClosedBy)
        {
            var values = new Dictionary<string, string>
            {
                  { "Id", DowntimeId },
                  { "ClosedBy", ClosedBy }
            };

            return _webServiceCall.CallPOSTService(_webServiceCall.UtilitiesServiceURI + "DownTime/Close", values);
        }
    }
}
