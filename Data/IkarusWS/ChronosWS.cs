using Chronos.Data.IkarusWS.Calls;
using System.Data;


namespace Chronos.Data.IkarusWS
{
    public class ChronosWS
    {
        WebServiceCall _webServiceCall;
        public ChronosWS(bool ConnectToProd)
        {
            _webServiceCall = new WebServiceCall(ConnectToProd);
        }

        public DataTable Chronos_GetStationPreConfig(string ADUser)
        {
            ADUser = ADUser.ToLower();
            return _webServiceCall.CallGETService(_webServiceCall.AppsServiceURI + string.Format("Chronos_StationPreConfig/Get?ADUser={0}", ADUser));
        }

        public DataTable Chronos_GetShiftsByCell(string FacilityId)
        {
            return _webServiceCall.CallGETService(_webServiceCall.MasterServiceURI + string.Format("ShiftsByFacility/Get?FacilityId={0}", FacilityId));
        }

    }
}
