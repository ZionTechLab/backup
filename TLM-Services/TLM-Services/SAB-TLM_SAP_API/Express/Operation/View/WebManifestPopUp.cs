using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
using Express.UI.Filters.View;
using Express.UI.Helpers;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Filters;
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
    public partial class WebManifestPopUp : Form
    {
        private readonly IWebManifestPopups _webPopAccess;
        private readonly WebManifestDomainView _manifest;
        private readonly List<WebManifestDomainView> _manifestList;
        private readonly AgencyDomainViewcs _comAgency;
        private readonly WebManiPopParamDomainView _param;

        private IList<StationDomainView> _stations;
        private IList<RouteDomainView> _routes;
        private IList<ClearenceTypeDomainView> _clearenceTypes;
        private IList<ClearenceStatusDomainView> _clearenceStatus;
        private IList<ConsoleTypeDomainView> _consoleTypes;

        public WebManifestPopUp(WebManifestDomainView _manifest , ref List<WebManifestDomainView> _manifestList , AgencyDomainViewcs _comAgency)
        {
            InitializeComponent();
            if(_webPopAccess ==null )
            {
                _webPopAccess = OperationsUIFacotry.GetService<IWebManifestPopups>();
            }
            _param = new WebManiPopParamDomainView();
            this._manifest = _manifest;
            this._manifestList = _manifestList;
            this._comAgency = _comAgency;
            _param.CompanyID = _comAgency.CompID;
            _param.AgencyID = _comAgency.AgncyCode;
            txtTrackNo.Text = _manifest.AgnTrackNo;
            _param.AgnTrackNum = _manifest.AgnTrackNo;
            _param.ShipType = _manifest.ShipType;
            _param.IsCredit = "";
            txtDutyTreshol.Text = Convert.ToString( _manifest.DutythreshLC);
            txtDutyValue.Text = Convert.ToString(_manifest.TotalDutyVal);
            txtCode.Text =  Convert.ToString( _manifest.BillOrgCode);
            txtName.Text = Convert.ToString(_manifest.BillOrgName);
            txtRemarks.Text = _manifest.Remarks;
            chkDutyExt.Checked = (_manifest.DutyExcemptY.Trim() == "") ? false : true;
            chkCrdAllow.Checked = (_manifest.BillDTaxCreditY.Trim() == "") ? false : true;
            SetOrganization();
            bgWork.RunWorkerAsync();
           
        }

        private void SetOrganization()
        {
            if (_manifest.BillOrgCode == 0)
            {
                txtCode.Text = "100000000";
                txtName.Text = _manifest.RecCompany;
            }
            else
            {
                txtCode.Text = _manifest.BillOrgCode.ToString();
                txtName.Text = _manifest.BillOrgName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #region background works
        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            _stations =  _webPopAccess.GetStations(_comAgency.CompID);
            _routes = _webPopAccess.GetRoute(_comAgency.CompID);
            _clearenceTypes = _webPopAccess.GetClearenceType();
            _clearenceStatus = _webPopAccess.GetClearenceStatus();
            _consoleTypes = _webPopAccess.GetConsoleTypes();
        }

        private void bgWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbStation.DataSource = _stations;
            cmbRoute.DataSource = _routes;
            cmbClearenceType.DataSource = _clearenceTypes;
            cmbClearStatus.DataSource = _clearenceStatus;
            cmbConsolType.DataSource = _consoleTypes;

            cmbStation.SelectedIndex = -1;
            cmbRoute.SelectedIndex = -1;
            cmbClearenceType.SelectedIndex = -1;
            cmbClearStatus.SelectedIndex = -1;
            cmbConsolType.SelectedIndex = -1;

            cmbStation.SelectedValue = _manifest.StationID;
            cmbRoute.SelectedValue = _manifest.RouteID;
            cmbClearenceType.SelectedValue = _manifest.ShipValueType;
            cmbClearStatus.SelectedValue = _manifest.ClearStatuesCode;
            cmbConsolType.SelectedValue = _manifest.ConsoleType;
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            

            var _search = new OrgSearchValueDomainView
            {
                OrgCode =  ( txtCode.Text==null || txtCode.Text =="")? 0 : Convert.ToInt32(txtCode.Text ) ,
                OrgName =txtName.Text 
            };

            new CustomerSearch(ref _search).ShowDialog();
            if(_search.OrgCode ==0)
            {
                txtCode.Text = "";
            
            }
            else
            {
                txtCode.Text = _search.OrgCode.ToString();
            }
            txtName.Text = _search.OrgName;
            _param.OrgCode = txtCode.Text;
            _param.OrgName = txtName.Text;
            _param.OrgAdd1 = _search.OrgAdd1;
            _param.OrgAdd2 = _search.OrgAdd2;
            _param.OrgCity = _search.OrgCity;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (!NumberValidator.TryPassDecimal(txtDutyValue.Text))
                {
                    MessageNotification.MessageBoxError("Please enter valid number to Duty Value", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError );
                   
                }


                if (!NumberValidator.TryPassDecimal(txtDutyTreshol.Text))
                {
                    MessageNotification.MessageBoxError("Please enter valid number to Duty Threshold ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);

                }


                SetComboValues();
                _param.Remarks = txtRemarks.Text;
                _param.DutyValue = Convert.ToDecimal(txtDutyValue.Text);
                _param.DutyTreshold  = Convert.ToDecimal(txtDutyTreshol.Text);
                _param.OrgCode = txtCode.Text;
                _param.OrgName = txtName.Text;
                _param.DustyExempt = (chkDutyExt.Checked == false) ? "" : "Y";

                ResponseMessage responce = new ResponseMessage();
                var vResult = CustomValidate.Instance.ValidateModel(_param);

                if (vResult == "")
                {

                    responce = _webPopAccess.UpdateAwbs(_param);
                    if (responce.IsSuccess)
                    {
                        MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().StationID = _param.StationID;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().RouteID  = _param.RouteID ;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().ShipValueType = _param.ClearenceType;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().DutyExcemptY = _param.DustyExempt;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().TotalDutyVal  = _param.DutyValue ;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().DutythreshLC = _param.DutyTreshold;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().BillOrgCode =Convert.ToInt32( _param.OrgCode);
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().BillOrgName = _param.OrgName;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().BillDTaxCreditY = _param.IsCredit;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().Remarks = _param.Remarks;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().ClearStatuesCode = Convert.ToInt32( (_param.ClearenceStatus=="")?"0": _param.ClearenceStatus);
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().ClearStatusN = (cmbClearStatus.SelectedItem ==null)? "" : cmbClearStatus.Text;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().ConsoleType =  _param.ConsolType;
                        _manifestList.Where(pre => pre.AgnTrackNo == _manifest.AgnTrackNo && pre.ShipType == _manifest.ShipType).FirstOrDefault().ConsoleTypeN = (cmbConsolType.SelectedItem == null) ? "" : cmbConsolType.Text;

                        //remark
                        //treshold
                        //clearenceStatus
                        //consol type
                        //
                    }
                    else
                    {
                        MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    }
                }
                else
                {
                    MessageNotification.MessageBoxError(vResult, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
                return;
            }
        }

        private void chkCrdAllow_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCrdAllow.Checked )
            {
                _param.IsCredit = "Y";
            }
            else
            {
                _param.IsCredit = "";
            }
        }

        private void txtDutyValue_KeyPress(object sender, KeyPressEventArgs e)
        {
           if( NumberValidator.TryPassDecimal(txtDutyValue.Text))
            {
                _param.DutyValue = Convert.ToDecimal(txtDutyValue.Text);
            }
           else
            {
                txtDutyValue.Text = "";
                _param.DutyValue = 0;
            }
        }

        private void txtDutyTreshol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidator.TryPassDecimal(txtDutyTreshol.Text))
            {
                _param.DutyTreshold = Convert.ToDecimal(txtDutyTreshol.Text);
            }
            else
            {
                txtDutyTreshol.Text = "";
                _param.DutyTreshold = 0;
            }
        }

        private void SetComboValues()
        {
            _param.StationID = (cmbStation.SelectedValue == null) ? "" : cmbStation.SelectedValue.ToString();
            _param.RouteID = (cmbRoute.SelectedValue == null) ? "" : cmbRoute.SelectedValue.ToString();
            _param.ConsolType = (cmbConsolType.SelectedValue == null ) ? 0 : Convert.ToInt32( cmbConsolType.SelectedValue.ToString());
            _param.ClearenceStatus = (cmbClearStatus.SelectedValue == null) ? "" : cmbClearStatus.SelectedValue.ToString();
            _param.ClearenceType = (cmbClearenceType.SelectedValue == null) ? "" : cmbClearenceType.SelectedValue.ToString();


        }

        
    }
}
