using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chronos.Machinery.AndonLights;
using Chronos.Data.IkarusWS;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using static Chronos.Data.Shared.Model.Enumerations;
using Chronos.Modules.DownTime.Model;
using Newtonsoft.Json;

namespace Chronos.Modules.DownTime
{
    public partial class DownTime : UserControl
    {
        private IChronosGlobal _chronosGlobal;
        private DowntimeLogs _unityService;
        public DownTimeCommands DownTimeScreenStatus { get; set; } = DownTimeCommands.NOT_OPEN;
        public AndonLights AndonControls { get; set; }

        private DateTime StartTime;
        private Timer downTimeTimer;

        private int _dTCodeTicketId;
        private int _dTCodeId;
        private string _dTCodeDesc_EN;
        private string _dTCodeDesc_ES;
        private int _dTSupportDeptId;
        private string _dTSupportDeptName;

        public DownTime(IChronosGlobal chronosGlobal, string DownTimeCode)
        {
            InitializeComponent();
            downTimeTimer = new Timer()
            {
                Interval = 1000
            };
            downTimeTimer.Tick += DowntimeTimer_Tick;

            _chronosGlobal = chronosGlobal;

            try
            {
                _unityService = new DowntimeLogs(_chronosGlobal.ConnectToProd);

                if (AndonControls == null)
                    AndonControls = new AndonLights();

                ConnectToAndon();

                if (DownTimeCode != null)
                    ScreenManager(DownTimeCode);
                else
                    RefreshScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConnectToAndon()
        {
            if (AndonControls.IsConnected())
            {

                _chronosGlobal.CustomBarStatus1 = "Andon Conectado";
                AndonControls.Reset();
                AndonControls.TurnGreenLightOn(false);
            }
            else
                _chronosGlobal.CustomBarStatus1 = "Andon Desconectado";
        }

        #region Screen Status
        public void RefreshScreen()
        {
            switch (DownTimeScreenStatus)
            {
                case DownTimeCommands.NOT_OPEN:
                    ShowDefaultScreen();
                    break;
                case DownTimeCommands.OPEN:
                    ShowDTOpenScreen();
                    break;
                case DownTimeCommands.ATTEND:
                    ShowDTAttendScreen();
                    break;
                case DownTimeCommands.CLOSE:
                    ShowDTCloseScreen();
                    break;
            }
        }

        private void ShowDefaultScreen()
        {
            if(_chronosGlobal.MainScreen == ChronosScreens.DownTime)
            {
                DownTimeScreenStatus = DownTimeCommands.NOT_OPEN;
                downTimeTimer.Stop();
                if (AndonControls != null)
                {
                    AndonControls.Reset();
                    AndonControls.TurnGreenLightOn(false);
                    AndonControls.SoundOff();
                }

                BackColor = DownTime_Default.ScreenColor;

                lblDTStatus.Visible = DownTime_Default.StatusLabelVisible;
                lblDTStatus.Text = DownTime_Default.StatusLabelText;

                lblDTReason.Visible = DownTime_Default.ReasonLabelVisible;
                lblDTReason.Text = "";

                lblElapsedTime.Visible = DownTime_Default.ElapsedLabelVisible;
                lblElapsedTime.Text = "00:00:00";

                lblInstruction.ForeColor = DownTime_Default.InstructionLabelColor;
                lblInstruction.Text = DownTime_Default.InstructionLabelText;

                btnAction.Text = DownTime_Default.ActionButtonText;
                btnAction.BackColor = DownTime_Default.ActionButtonColor;
            }
            else
            {
                _chronosGlobal.CurrentScreen = ChronosScreens.None;
                Dispose();
            }
        }

        private void ShowDTOpenScreen()
        {
            DownTimeScreenStatus = DownTimeCommands.OPEN;
            StartTime = DateTime.Now;
            downTimeTimer.Stop();
            downTimeTimer.Start();
            if (AndonControls != null)
            {
                AndonControls.Reset();
                AndonControls.TurnRedLightOn(true);
                AndonControls.SoundOn();
            }

            BackColor = DownTime_Open.ScreenColor;

            lblDTStatus.Visible = DownTime_Open.StatusLabelVisible;
            lblDTStatus.Text = DownTime_Open.StatusLabelText;

            lblDTReason.Visible = DownTime_Open.ReasonLabelVisible;
            lblDTReason.Text = _dTSupportDeptName + ": " +_dTCodeDesc_ES;

            lblElapsedTime.Visible = DownTime_Open.ElapsedLabelVisible;
            lblElapsedTime.Text = "00:00:00";

            lblInstruction.ForeColor = DownTime_Open.InstructionLabelColor;
            lblInstruction.Text = DownTime_Open.InstructionLabelText;

            btnAction.Text = DownTime_Open.ActionButtonText;
            btnAction.BackColor = DownTime_Open.ActionButtonColor;

        }

        private void ShowDTAttendScreen()
        {
            DownTimeScreenStatus = DownTimeCommands.ATTEND;
            StartTime = DateTime.Now;
            downTimeTimer.Stop();
            downTimeTimer.Start();
            if(AndonControls != null)
            {
                AndonControls.Reset();
                AndonControls.TurnBlueLightOn(true);
                AndonControls.SoundOff();
            }

            BackColor = DownTime_Attend.ScreenColor;

            lblDTStatus.Visible = DownTime_Attend.StatusLabelVisible;
            lblDTStatus.Text = DownTime_Attend.StatusLabelText;

            lblDTReason.Visible = DownTime_Attend.ReasonLabelVisible;
            lblDTReason.Text = _dTSupportDeptName + ": " + _dTCodeDesc_ES;

            lblElapsedTime.Visible = DownTime_Attend.ElapsedLabelVisible;
            lblElapsedTime.Text = "00:00:00";

            lblInstruction.ForeColor = DownTime_Attend.InstructionLabelColor;
            lblInstruction.Text = DownTime_Attend.InstructionLabelText;

            btnAction.Text = DownTime_Attend.ActionButtonText;
            btnAction.BackColor = DownTime_Attend.ActionButtonColor;
        }

        private void ShowDTCloseScreen()
        {
            DownTimeScreenStatus = DownTimeCommands.CLOSE;
            ShowDefaultScreen();
        }
        #endregion

        private void TxtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string UserInput = txtInput.Text.ToUpper().Trim();
                ScreenManager(UserInput);
                txtInput.Text = "";
            }
        }

        private void ScreenManager(string UserInput)
        {
            switch (DownTimeScreenStatus)
            {
                case DownTimeCommands.OPEN:
                    if (ChronosValidations.GetInputType(UserInput, _chronosGlobal.FacilityId) == UserInputs.BadgeID)
                    {
                        DataTable dt = _unityService.DownTimeLogs_ValidateTechnician(_dTCodeId, ChronosValidations.GetBadgeId(UserInput, _chronosGlobal.FacilityId));
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                _unityService.DownTimeLogs_Attend(_dTCodeTicketId.ToString(), ChronosValidations.GetBadgeId(UserInput, _chronosGlobal.FacilityId));
                                DownTimeScreenStatus = DownTimeCommands.ATTEND;
                                RefreshScreen();
                                break;
                            }
                        }
                    }
                    MessageBox.Show("Credencial no autorizada");
                    break;
                case DownTimeCommands.ATTEND:
                    if (ChronosValidations.GetInputType(UserInput, _chronosGlobal.FacilityId) == UserInputs.BadgeID)
                    {
                        DataTable dt = _unityService.DownTimeLogs_ValidateTechnician(_dTCodeId, ChronosValidations.GetBadgeId(UserInput, _chronosGlobal.FacilityId));
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                _unityService.DownTimeLogs_Close(_dTCodeTicketId.ToString(), ChronosValidations.GetBadgeId(UserInput, _chronosGlobal.FacilityId));
                                DownTimeScreenStatus = DownTimeCommands.CLOSE;
                                RefreshScreen();
                                break;
                            }
                        }
                    }
                    MessageBox.Show("Credencial no autorizada");
                    break;
                default:
                    if (ChronosValidations.GetInputType(UserInput, _chronosGlobal.FacilityId) == UserInputs.DownTime)
                    {
                        DataTable dt = _unityService.DownTimeLogs_ValidateCode(_chronosGlobal.FacilityId, UserInput);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    _dTCodeId = int.Parse(row["Id"].ToString());
                                    _dTCodeDesc_EN = row["Description_es"].ToString();
                                    _dTCodeDesc_ES = row["Description_en"].ToString();
                                    _dTSupportDeptId = int.Parse(row["SupportDepartmentId"].ToString());
                                    _dTSupportDeptName = row["DepartmentName"].ToString();
                                }
                                var DT = _unityService.DownTimeLogs_Create(_chronosGlobal.FacilityId.ToString(),
                                                                            _chronosGlobal.StationConfiguration.CellId.ToString(),
                                                                            _chronosGlobal.StationConfiguration.OperationId.ToString(),
                                                                            UserInput,
                                                                            _chronosGlobal.MainUser.EmployeeBadge);

                                if (int.TryParse(JsonConvert.DeserializeObject<string>(DT), out _dTCodeTicketId))
                                {
                                    DownTimeScreenStatus = DownTimeCommands.OPEN;
                                    RefreshScreen();
                                }
                                else
                                {
                                    MessageBox.Show("Error Inesperado, favor de reportar a MIS");
                                }
                                break;
                            }
                        }
                    }else if (ChronosValidations.GetInputType(UserInput, _chronosGlobal.FacilityId) == UserInputs.BadgeID)
                    {
                        _chronosGlobal.IsUserLogged = false;
                        break;
                    }
                    MessageBox.Show("Código inválido");
                    break;
            }
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            switch (DownTimeScreenStatus)
            {
                case DownTimeCommands.OPEN:
                    _unityService.DownTimeLogs_Attend(_dTCodeTicketId.ToString(), "00000");
                    _unityService.DownTimeLogs_Close(_dTCodeTicketId.ToString(), "00000");
                    RefreshScreen();
                    break;
                case DownTimeCommands.ATTEND:
                    _unityService.DownTimeLogs_Close(_dTCodeTicketId.ToString(), "00000");
                    RefreshScreen();
                    break;
                default:
                    _chronosGlobal.IsUserLogged = false;
                    break;
            }
        }

        private void DowntimeTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - StartTime;
            lblElapsedTime.Text = ts.ToString(@"hh\:mm\:ss");
        }

        private void DownTime_Load(object sender, EventArgs e)
        {
            ActiveControl = txtInput;
        }
    }

}
