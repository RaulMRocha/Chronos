using Chronos.Data.DBAccess.BLogic;
using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Chronos.Data.Shared.Model.Enumerations;

namespace Chronos.Modules.EmployeeValidation
{
    public partial class EmployeeValidation : UserControl
    {
        SqlConnection _chronosDBConnection;
        private IChronosGlobal _chronosGlobal;
        private string _userLoggedStatus = "";


        public EmployeeValidation(IChronosGlobal chronosGlobal, bool ValidPreconfig)
        {
            InitializeComponent();
            _chronosGlobal = chronosGlobal;
            _chronosDBConnection = DBConnection.GetConnection(_chronosGlobal.ConnectToProd, _chronosGlobal.ServerName, _chronosGlobal.DatabaseName);

            if (_chronosGlobal.ConnectToProd)
                lblAppEnvironment.Text = "Production Environment - " + _chronosGlobal.FacilityName;
            else
                lblAppEnvironment.Text = "Test Environment - " + _chronosGlobal.FacilityName;

            lblAppVersion.Text = _chronosGlobal.AppVersionName;
            if (!ValidPreconfig)
            {
                lblInvalid.Visible = true;
                pnlControls.Visible = false;
            }
            else
            {
                lblInvalid.Visible = false;
                pnlControls.Visible = true;
            }

            lblStationName.Text = _chronosGlobal.StationConfiguration.StationName_es;
            txtEmployeeBadge.Select();
        }

        public void ForceFocus()
        {
            txtEmployeeBadge.Select();
            txtEmployeeBadge.Focus();
        }

        private void TxtEmployeeBadge_KeyUp(object sender, KeyEventArgs e)
        {
            txtEmployeeBadge.BackColor = System.Drawing.Color.White;
            lblInstruction.ForeColor = System.Drawing.Color.White;
            lblInstruction.Text = "Escanea tu credencial";
            if (e.KeyCode == Keys.Enter)
            {
                string inputText = txtEmployeeBadge.Text.Trim();
                string inputType = ChronosValidations.GetInputType(inputText, _chronosGlobal.FacilityId).ToString();

                if(inputType == UserInputs.BadgeID.ToString())
                {
                    UpdateInstruction("Validando credencial...");

                    VerifyEmployee(ChronosValidations.GetBadgeId(inputText, _chronosGlobal.FacilityId));

                    if(_userLoggedStatus == "OK")
                    {
                        txtEmployeeBadge.Text = "";
                        txtEmployeeBadge.Enabled = true;

                        lblInstruction.Text = "Escanea tu credencial";
                        txtEmployeeBadge.Focus();
                    }
                    else
                    {
                        txtEmployeeBadge.Text = "";
                        txtEmployeeBadge.BackColor = System.Drawing.Color.DarkRed;
                        lblInstruction.ForeColor = System.Drawing.Color.DarkRed;
                        UpdateInstruction(_userLoggedStatus);
                        txtEmployeeBadge.Enabled = true;
                        txtEmployeeBadge.Focus();
                    }
                }
                else
                {
                    txtEmployeeBadge.Text = "";
                    txtEmployeeBadge.BackColor = System.Drawing.Color.DarkRed;
                    lblInstruction.ForeColor = System.Drawing.Color.DarkRed;
                    UpdateInstruction("Credencial inválida");
                    txtEmployeeBadge.Enabled = true;
                    txtEmployeeBadge.Focus();
                }
            }
        }

        private void VerifyEmployee(string EmployeeBadge)
        {
            DataTable config = EmployeesLogic.GetEmployeeData(_chronosGlobal, EmployeeBadge, _chronosGlobal.FacilityId);
            if (config.Rows.Count > 0)
            {
                Employees lclUser = new Employees();

                UpdateInstruction("Buscando Certificaciones...");

                DataTable certif = EmployeesLogic.GetEmployeeCertificationData(_chronosGlobal, EmployeeBadge, _chronosGlobal.FacilityId, _chronosGlobal.OperationsByCellConfiguration.TRESSOperationCode);
                if (certif.Rows.Count > 0)
                {
                    lclUser.IsCertified = true;
                    lclUser.CertificationLevel = "Certificado";
                }
                else
                {
                    lclUser.IsCertified = false;
                    lclUser.CertificationLevel = "NONE";
                }

                if (_chronosGlobal.OperationsByCellConfiguration.ForceCertification && !lclUser.IsCertified)
                {
                    _userLoggedStatus = "Usuario no certificado";
                    return;
                }

                UpdateInstruction("Cargando configuración...");

                foreach (DataRow row in config.Rows)
                {
                    lclUser.EmployeeName = row["Names"].ToString() + " " + row["LastNameFather"].ToString();
                    lclUser.EmployeeBadge = EmployeeBadge;
                    lclUser.ProcessName = row["Area"].ToString();
                    lclUser.SubProcessName = row["Operation"].ToString();
                }
                _chronosGlobal.MainUser = lclUser;
                _chronosGlobal.LogInLogOutUser(true);
                _userLoggedStatus = "OK";
            }
            else
            {
                _userLoggedStatus = "Usuario no encontrado";
            }
        }

        private void UpdateInstruction(string text)
        {
            lblInstruction.Text = text;
            lblInstruction.Invalidate();
            lblInstruction.Update();
            lblInstruction.Refresh();
            txtEmployeeBadge.Enabled = false;
            txtEmployeeBadge.Invalidate();
            txtEmployeeBadge.Update();
            txtEmployeeBadge.Refresh();
            Application.DoEvents();
        }

        private void EmployeeValidation_Paint(object sender, PaintEventArgs e)
        {
            ForceFocus();
        }
    }
}
