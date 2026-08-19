using Express.Domain.Message;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Helpers;
using Express.UI.Helpers;
using Express.UI.Operation.OpsHelper.POD;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Operation.View
{
    public partial class PodScanUpload : Form
    {
        private readonly IPodCreate _podcreate;
        private readonly IPodRetrive  _podRetrive;
    
        private List<PodScanUploadDomainView> _importPods;
        private IList<RefSvcRootsDomainView> _roots;
        private IList<CourrierDomainView> _couries;
        private IList<AgencyDomainViewcs> _agencies;
        private int MenuCode;
        private int AgencyCode;
        public PodScanUpload()
        {
            InitializeComponent();
            _podcreate = PodScanSrvLocator.GetService< IPodCreate>();
            _podRetrive = PodScanSrvLocator.GetService< IPodRetrive>();
           
            podDataGrid.AutoGenerateColumns = false;
            MenuCode = LoginInfoView.MENUCODE;
            chkCourierAll.Checked = true;
            chkRouteAll.Checked = true;
            txtScanType.Text = "POD";
            btnAdd.Enabled = false;
            btnImport.Enabled = false;
            btnSaveProcess.Enabled = false;
            this.cmb_agency.SelectedValueChanged -= new EventHandler(cmb_agency_SelectedValueChanged);
            this.cmbCourier.SelectedValueChanged -= new EventHandler(cmbCourier_SelectedValueChanged);
            this.cmbRoute.SelectedIndexChanged -= new EventHandler(cmbRoute_SelectedIndexChanged);
            bgwPodScan.RunWorkerAsync();
        }
        
        private void PodScanUpload_Load(object sender, EventArgs e)
        {

        }   
      
        private void bgwPodScan_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _agencies = _podRetrive.GetAgencyDetail(LoginInfoView.USERID, LoginInfoView.MODULEID, MenuCode);
                _roots = _podRetrive.GetRefSvcRoots(LoginInfoView.COMPANYID);
                _couries = _podRetrive.GetCourrier("");
            }
            catch(Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message , LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
          

        }

        private void bgwPodScan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyID";
          
            cmb_agency.DataSource = _agencies;
            cmb_agency.SelectedIndex = -1;
           this.cmb_agency.SelectedValueChanged += new EventHandler(cmb_agency_SelectedValueChanged);

            cmbRoute.DisplayMember = "SvcRootName";
            cmbRoute.ValueMember = "SvcRootID";
            cmbRoute.DataSource = _roots;
            this.cmbRoute.SelectedValueChanged += new EventHandler(cmbRoute_SelectedIndexChanged);

            cmbCourier.DisplayMember = "EmployeeName";
            cmbCourier.ValueMember = "EmployeeID";
            cmbCourier.DataSource = _couries;
            this.cmbCourier.SelectedValueChanged += new EventHandler(cmbCourier_SelectedValueChanged);

        }

        private void chkRouteAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRouteAll.Checked )
            {
                cmbRoute.Enabled = false;
            }
            else
            {
                cmbRoute.Enabled = true;
            }
            RefeshChange();
        }

        private void chkCourierAll_CheckedChanged(object sender, EventArgs e)
        {
           if( chkCourierAll.Checked )
            {
                cmbCourier.Enabled = false;
            }
           else
            {
                cmbCourier.Enabled = true;
            }

            RefeshChange();
        }

        private void cmb_agency_SelectedValueChanged(object sender, EventArgs e)
        {
            var agencyValue = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            if(agencyValue!=null)
            {
                txt_company.Text = agencyValue.CompName;
                AgencyCode = agencyValue.AgncyCode;
                RefeshChange();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan scan_time = new TimeSpan(dtePodScanTime.Value.Hour, dtePodScanTime.Value.Minute, 0);
                var _para = new PodScanUploadDomainView
                {
                    AgencyID = AgencyCode,
                    CompanyID = LoginInfoView.COMPANYID,
                    ScanTypeS = TextValidator.FixSpecialCharacters(txtScanType.Text.Trim()),
                    EmployeeID = TextValidator.FixSpecialCharacters(txtEmpNo.Text.Trim()),
                    RoutID = TextValidator.FixSpecialCharacters(txtRouteNo.Text.Trim()),
                    Trackno = TextValidator.FixSpecialCharacters(txtTrackNo.Text.Trim()),
                    ScanProcess = "X",
                    ScanCapture = "DE",
                    ScanDateTimeObj = dtePodScanDate.Value.Year + "-" + dtePodScanDate.Value.Month.ToString().PadLeft(2, '0') + "-" + dtePodScanDate.Value.Day.ToString().PadLeft(2, '0') + ' ' + scan_time.ToString()

                };

                var pod = _podcreate.AddPods(_para, _importPods);
                if (pod != null)
                {
                    if (_importPods == null)
                    {
                        _importPods = new List<PodScanUploadDomainView>();
                    }                  
                    _importPods.Add(pod);
                    podDataGrid.DataSource = null;
                    podDataGrid.DataSource = _importPods;
                    ClearManualEntry();
                }

            }
            catch(Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageNotification.MessageBoxConfirm("Are sure want to clear detail ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            {
                btnAdd.Enabled = false;
                btnImport.Enabled = false;
                btnSaveProcess.Enabled = false;
                ClearDetails();
            }             

        }

        private void ClearDetails()
        {
            RefeshChange();
            chkCourierAll.Checked = true;
            chkRouteAll.Checked = true;
            chkUnprocess.Checked = false;
            chkSummaryPrint.Checked = false;
            chkUnprocess.Checked = false;
            dtePodScanDate.Value = DateTime.Now.Date;
            dtePodScanTime.Value = DateTime.Now;
            txtEmpNo.Text = "";
            txtComment.Text = "";
            txtRouteNo.Text = "";
            txtScanType.Text = "POD";
            txtTrackNo.Text = "";
           
            dteFrom.Value = DateTime.Now;
            dteTo.Value = DateTime.Now;
           
          

        }

        private void RefeshChange()
        {
            podDataGrid.DataSource = null;
            if( _importPods !=null)
            {
                _importPods.Clear();
                SetAwbCount();
            }
           
                       
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnImport.Enabled = true;
            btnSaveProcess.Enabled = true ;
            ClearDetails();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_importPods != null)
                {
                    _importPods.Clear();
                }
                _importPods = _podcreate.ImportPods(LoginInfoView.COMPANYID, AgencyCode, txtScanType.Text);
                podDataGrid.DataSource = _importPods;
                if(_importPods!=null &&  _importPods.Count>0)
                {
                    btnSaveProcess.Enabled = true ;
                }
                SetAwbCount();
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError("Error reading excel file" , LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            if (podDataGrid.SelectedRows == null)
            {
                MessageNotification.MessageBoxError("Select a record to delete", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if(podDataGrid.RowCount ==0)
            {
                MessageNotification.MessageBoxError("No data to delete", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
           
            try

            {
                var plist = _podcreate.DeletePod(_importPods, podDataGrid.SelectedRows[0].Index);
                podDataGrid.DataSource = null;
                podDataGrid.DataSource = plist;
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
           
        }

        private void btnRetrive_Click(object sender, EventArgs e)
        {            
            RetriveDetails();
        }

        private void btnSaveProcess_Click(object sender, EventArgs e)
        {
            ResponseMessage responce = new ResponseMessage();
            responce= _podcreate.SavePods(_importPods);
            if(responce.StrMessage == AppMessage.SaveSuccess)
            {
                MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                RetriveDetails();
            }
            else
            {
                MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
           
        }

        private void dteFrom_ValueChanged(object sender, EventArgs e)
        {
            RefeshChange();
        }

        private void dteTo_ValueChanged(object sender, EventArgs e)
        {
            RefeshChange();
        }

        private void chkUnprocess_CheckedChanged(object sender, EventArgs e)
        {
            RefeshChange();
        }

        private void cmbCourier_SelectedValueChanged(object sender, EventArgs e)
        {
            RefeshChange();
        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefeshChange();
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {

            if (MessageNotification.MessageBoxConfirm("Are sure want to re-process ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            {
                ResponseMessage responce = new ResponseMessage();
                var _para = new PodScanUploadParaDomainView
                {
                    CompanyID = LoginInfoView.COMPANYID,
                    AgencyID = AgencyCode,
                    AllCurrier = (chkCourierAll.Checked == true) ? 1 : 0,
                    AllRoute = (chkRouteAll.Checked == true) ? 1 : 0,
                    CurrierID = cmbCourier.SelectedValue.ToString(),
                    RoutID = cmbRoute.SelectedValue.ToString(),
                    UnprocessScan = (chkUnprocess.Checked == true) ? 1 : 0,
                    DateFrom = dteFrom.Value.Year + "-" + dteFrom.Value.Month.ToString().PadLeft(2, '0') + "-" + dteFrom.Value.Day.ToString().PadLeft(2, '0'),
                    DateTo = dteTo.Value.Year + "-" + dteTo.Value.Month.ToString().PadLeft(2, '0') + "-" + dteTo.Value.Day.ToString().PadLeft(2, '0'),

                };

                responce = _podcreate.ReprocessPods( _importPods,_para);
                if (responce.StrMessage == AppMessage.SaveSuccess)
                {
                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                }
                else
                {
                    MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
        }

        private void SetAwbCount()
        {
            txtAwbCount.Text = _podRetrive.GetAwbCount(_importPods).ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var _para = new PodScanUploadParaDomainView
            {
                CompanyID = LoginInfoView.COMPANYID,
                AgencyID = AgencyCode,
                AllCurrier = (chkCourierAll.Checked == true) ? 1 : 0,
                AllRoute = (chkRouteAll.Checked == true) ? 1 : 0,
                CurrierID = cmbCourier.SelectedValue.ToString(),
                RoutID = cmbRoute.SelectedValue.ToString(),
                UnprocessScan = (chkUnprocess.Checked == true) ? 1 : 0,
                DateFrom = dteFrom.Value.Year + "-" + dteFrom.Value.Month.ToString().PadLeft(2, '0') + "-" + dteFrom.Value.Day.ToString().PadLeft(2, '0'),
                DateTo = dteTo.Value.Year + "-" + dteTo.Value.Month.ToString().PadLeft(2, '0') + "-" + dteTo.Value.Day.ToString().PadLeft(2, '0'),

            };
            _podRetrive.GetPodScanReport(_para);
        }

        private void RetriveDetails()
        {
            try
            {
                var _para = new PodScanUploadParaDomainView
                {
                    CompanyID = LoginInfoView.COMPANYID,
                    AgencyID = AgencyCode,
                    AllCurrier = (chkCourierAll.Checked == true) ? 1 : 0,
                    AllRoute = (chkRouteAll.Checked == true) ? 1 : 0,
                    CurrierID = cmbCourier.SelectedValue.ToString(),
                    RoutID = cmbRoute.SelectedValue.ToString(),
                    UnprocessScan = (chkUnprocess.Checked == true) ? 1 : 0,
                    DateFrom = dteFrom.Value.Year + "-" + dteFrom.Value.Month.ToString().PadLeft(2, '0') + "-" + dteFrom.Value.Day.ToString().PadLeft(2, '0'),
                    DateTo = dteTo.Value.Year + "-" + dteTo.Value.Month.ToString().PadLeft(2, '0') + "-" + dteTo.Value.Day.ToString().PadLeft(2, '0'),

                };
                if (_importPods != null)
                {
                    if (_importPods.Count > 0)
                    {
                        _importPods.Clear();
                    }
                }

                _importPods = _podRetrive.RetrivePods(_para);
                podDataGrid.DataSource = null;
                podDataGrid.DataSource = _importPods;
                SetAwbCount();
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }

        }

        private void ClearManualEntry()
        {
            txtEmpNo.Text = "";
            txtComment.Text = "";
            txtRouteNo.Text = "";
            txtScanType.Text = "POD";
            txtTrackNo.Text = "";
            dtePodScanDate.Value = DateTime.Now;
            dtePodScanTime.Value = DateTime.Now;
        }

       
    }
}
