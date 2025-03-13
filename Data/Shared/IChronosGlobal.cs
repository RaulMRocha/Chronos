using Chronos.Data.Shared.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Chronos.Data.Shared.Model.Enumerations;

namespace Chronos.Data.Shared
{
    public interface IChronosGlobal
    {
        SqlConnection ChronosDBConnection { get; set; }
        ChronosScreens MainScreen { get; set; }
        ChronosScreens CurrentScreen { get; set; }

        Employees MainUser { get; set; }
        ChronosStation StationConfiguration { get; set; }
        OperationsByCell OperationsByCellConfiguration { get; set; }
        Cells CellsInformation { get; set; }
        List<Flows> FlowConfiguration{get; set; }

        bool IsUserLogged { get; set; }
        void LogInLogOutUser(bool IsUserLogged);

        void SwitchScreens(ChronosScreens Screen, ChronosScreensActions Action, string Param1 = null, string param2 = null, string param3 = null);
        
        bool ConnectToProd { get; set; }
        string ServerName { get; set; }
        string DatabaseName { get; set; }
        string AppVersionName { get; set; }
        int FacilityId { get; set; }
        string FacilityName { get; set; }
        string[] Roles { get; set; }
        
        string CustomBarStatus1 { get; set; }
        string CustomBarStatus2 { get; set; }
    }
}
