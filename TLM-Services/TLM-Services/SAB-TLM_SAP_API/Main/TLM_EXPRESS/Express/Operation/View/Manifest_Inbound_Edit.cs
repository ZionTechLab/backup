using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
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
    public partial class Manifest_Inbound_Edit : Form
    {
        private readonly IManifestInboundEdit<ManifestInboundDomainView> _extProvider;

        private OpsConsAWBDomainView ObjOpsConsAWBDomainView = null;
        private List<string> listCfgDtaxCal = null;
        private List<RefLocationsDomainView> stations = new List<RefLocationsDomainView>();
        private List<RefSvcRootsDomainView> route = new List<RefSvcRootsDomainView>();
        private List<CurrencyDetailDomainView> currency = new List<CurrencyDetailDomainView>();
        private List<string> SO = new List<string>();
        private List<string> MRoute = new List<string>();
        private FormStateEnum FormState;
        ////public Manifest_Inbound_Edit()
        ////{
        ////    InitializeComponent();

        ////    if (_extProvider == null)
        ////    {
        ////        _extProvider = OperationsUIFacotry.GetService<IManifestInboundEdit<ManifestInboundDomainView>>();
        ////    }
        ////}

        public Manifest_Inbound_Edit(OpsConsAWBDomainView ConsAWBDomainView)
        {
            InitializeComponent();
            
            if (_extProvider == null)
            {
                _extProvider = OperationsUIFacotry.GetService<IManifestInboundEdit<ManifestInboundDomainView>>();
            }
            ObjOpsConsAWBDomainView = ConsAWBDomainView;
            FormState = FormStateEnum.Initial;
        }

        private void Manifest_Inbound_Edit_Load(object sender, EventArgs e)
        {
            
            if(ObjOpsConsAWBDomainView.BillOrgCode ==0 )
            {
                txtCode.Text =Convert.ToString(  LoginInfoView.ONECUSTCODE); // "100000000";
                chkOnetime.Checked = true;
                txtName.Text = ObjOpsConsAWBDomainView.RecCompany ;
                txtOrgAdd1.Text = ObjOpsConsAWBDomainView.RecAddr1;
                txtOrgAdd2.Text = ObjOpsConsAWBDomainView.RecAddr2;
                txtCity.Text = ObjOpsConsAWBDomainView.RecCityN;
                EnableOrganization(true );

            }
            else if( ObjOpsConsAWBDomainView.BillOrgCode == LoginInfoView.ONECUSTCODE)
            {
                chkOnetime.Checked = true ;
                txtCode.Text = ObjOpsConsAWBDomainView.BillOrgCode.ToString();
                txtName.Text = ObjOpsConsAWBDomainView.BillOrgName;
                txtOrgAdd1.Text = ObjOpsConsAWBDomainView.BillOrgAddr1;
                txtOrgAdd2.Text = ObjOpsConsAWBDomainView.BillOrgAddr2;
                txtCity.Text = ObjOpsConsAWBDomainView.BillOrgCity;
                EnableOrganization(true );
            }
            else
            {
                chkOnetime.Checked = false ;
                txtCode.Text = ObjOpsConsAWBDomainView.BillOrgCode.ToString();
                txtName.Text = ObjOpsConsAWBDomainView.BillOrgName;
                txtOrgAdd1.Text = ObjOpsConsAWBDomainView.BillOrgAddr1 ;
                txtOrgAdd2.Text = ObjOpsConsAWBDomainView.BillOrgAddr2 ;
                txtCity.Text = ObjOpsConsAWBDomainView.BillOrgCity ;
                EnableOrganization(false);
            }

            currency = _extProvider.GetCurrencyDetail("ALL").ToList();
            cmbCurrencey.DataSource = currency;
            txtCustomeValue.Text = Convert.ToString( ObjOpsConsAWBDomainView.CustomVal);
            cmbCurrencey.SelectedValue = ObjOpsConsAWBDomainView.CustomValCur;
            txtCrrCode.Text = ObjOpsConsAWBDomainView.CustomValCur;
            txtAwbNo.Text = ObjOpsConsAWBDomainView.AgnAWBNo;

            #region credit allowed
            if (ObjOpsConsAWBDomainView.BillDTaxCreditY!=null)
            {
                if(ObjOpsConsAWBDomainView.BillDTaxCreditY.Trim()=="Y")
                {
                    chkCreAllow.Text = "Yes";
                    chkCreAllow.Checked = true;
                }
                else if (ObjOpsConsAWBDomainView.BillDTaxCreditY.Trim() == "N")
                {
                    chkCreAllow.Text = "No";
                }
                else
                {
                    chkCreAllow.Text = "";
                }
            }
            else
            {
                chkCreAllow.Text = "";
            }
            #endregion

            #region detained
            if (ObjOpsConsAWBDomainView.DetainedY != null)
            {
                if (ObjOpsConsAWBDomainView.DetainedY.Trim() == "Y")
                {
                    chkDetained.Text = "Yes";
                    chkDetained.Checked = true;
                }
                else if (ObjOpsConsAWBDomainView.DetainedY.Trim() == "N")
                {
                    chkDetained.Text = "No";
                }
                else
                {
                    chkDetained.Text = "";
                }
            }
            else
            {
                chkDetained.Text = "";
            }
            #endregion

            #region duty exempt
            
            if (ObjOpsConsAWBDomainView.DutyExcemptY != null)
            {
                if (ObjOpsConsAWBDomainView.DutyExcemptY.Trim() == "Y")
                {
                    chkDutyEx.Text = "Yes";
                    chkDutyEx.Checked = true;
                }
                else if (ObjOpsConsAWBDomainView.DutyExcemptY.Trim() == "N")
                {
                    chkDutyEx.Text = "No";
                }
                else
                {
                    chkDutyEx.Text = "";
                }
            }
            else
            {
                chkDutyEx.Text = "";
            }

            #endregion

            #region shipValType
            listCfgDtaxCal = _extProvider.GetCfgDtaxCal().ToList<CfgDtaxCalDomainView>().Select(c => c.ShipValueType.Trim()).Distinct().ToList<string>();
            cmbClr.DataSource = listCfgDtaxCal;
            cmbClr.SelectedItem = null;
            if (ObjOpsConsAWBDomainView.ShipValueType != null)
            {
                if(listCfgDtaxCal.Contains(ObjOpsConsAWBDomainView.ShipValueType.Trim()))
                {
                    cmbClr.SelectedItem = ObjOpsConsAWBDomainView.ShipValueType.Trim();
                }                 
            }
            #endregion

            #region station and route

            stations = _extProvider.GetRefLocationsStations().ToList<RefLocationsDomainView>();
            route = _extProvider.GetRefSvcRoots(ObjOpsConsAWBDomainView.CMPY).ToList<RefSvcRootsDomainView>(); 

            cmbStation.DataSource = stations;
            cmbStation.SelectedItem = null;
            if (ObjOpsConsAWBDomainView.StationID != null)
            {
                if (stations.Find(c=>c.LocationID.Trim() == ObjOpsConsAWBDomainView.StationID.Trim())!=null)
                {
                    cmbStation.SelectedItem = stations.FindAll(c => c.LocationID.Trim() == ObjOpsConsAWBDomainView.StationID.Trim()).FirstOrDefault<RefLocationsDomainView>();
                }
            }
            cmbRoute.DataSource = route;
            cmbRoute.SelectedItem = null;
            if (ObjOpsConsAWBDomainView.RouteID != null)
            {
                if (route.Find(c=>c.SvcRootID.Trim()== ObjOpsConsAWBDomainView.RouteID.Trim())!=null)
                {
                    cmbRoute.SelectedItem = route.FindAll(c => c.SvcRootID.Trim() == ObjOpsConsAWBDomainView.RouteID.Trim()).FirstOrDefault<RefSvcRootsDomainView>();
                }
            }
            #endregion

            #region SO and MRoute
            SO.Add("S");SO.Add("O");
            cmbSO.DataSource = SO;
            cmbSO.SelectedItem = null;
            if(ObjOpsConsAWBDomainView.ShoOvr!=null)
            {
                if(SO.Contains(ObjOpsConsAWBDomainView.ShoOvr.Trim()))
                {
                    cmbSO.SelectedItem = SO.Find(c => c == ObjOpsConsAWBDomainView.ShoOvr.Trim());
                }
            }

            MRoute.Add("Y"); MRoute.Add("N");
            cmbMRoute.DataSource = MRoute;
            cmbMRoute.SelectedItem = null;
            if (ObjOpsConsAWBDomainView.MissRoute != null)
            {
                if (MRoute.Contains(ObjOpsConsAWBDomainView.MissRoute.Trim()))
                {
                    cmbMRoute.SelectedItem = MRoute.Find(c => c == ObjOpsConsAWBDomainView.MissRoute.Trim());
                }
            }
            #endregion            

        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ObjOpsConsAWBDomainView.BillOrgAddr1 = txtOrgAdd1.Text;
                ObjOpsConsAWBDomainView.BillOrgAddr2 = txtOrgAdd2.Text;
                ObjOpsConsAWBDomainView.BillOrgCity = txtCity.Text;

                if (cmbClr.SelectedValue != null) { ObjOpsConsAWBDomainView.ShipValueType = cmbClr.SelectedValue.ToString(); }
                if (cmbRoute.SelectedValue != null) { ObjOpsConsAWBDomainView.RouteID = cmbRoute.SelectedValue.ToString(); }
                if (cmbStation.SelectedValue != null) { ObjOpsConsAWBDomainView.StationID = cmbStation.SelectedValue.ToString(); }

                if(!NumberValidator.TryPassInteger(txtCode.Text))
                {
                    MessageNotification.MessageBoxError("Please select valid customer details", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                ObjOpsConsAWBDomainView.BillOrgCode = int.Parse(txtCode.Text);
                ObjOpsConsAWBDomainView.RecCompany = txtName.Text;
                if (cmbSO.SelectedItem != null)
                {
                    ObjOpsConsAWBDomainView.ShoOvr = cmbSO.SelectedItem.ToString();
                }
                if (cmbMRoute.SelectedItem != null)
                {
                    ObjOpsConsAWBDomainView.MissRoute = cmbMRoute.SelectedItem.ToString();
                }

                if(cmbCurrencey.SelectedItem !=null)
                {
                    ObjOpsConsAWBDomainView.CustomVal = Convert.ToDecimal(txtCustomeValue.Text);
                    ObjOpsConsAWBDomainView.CustomValCur = cmbCurrencey.SelectedValue.ToString();
                }
                else
                {
                    MessageNotification.MessageBoxOK("Please select manifested currency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                var vCurr = currency.Where(curr => curr.Currency.ToUpper() == txtCrrCode.Text.ToUpper());
                if (vCurr == null || vCurr.Count() == 0)
                {
                    MessageNotification.MessageBoxError("Please select valid currency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                ResponseMessage msg = _extProvider.UpdateManifestInbound(ObjOpsConsAWBDomainView);
                if(msg.IsSuccess)
                {
                    MessageNotification.MessageBoxOK(msg.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                    this.Close();
                }
                else
                {
                    MessageNotification.MessageBoxError(msg.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }

            }
            catch(Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void chkCreAllow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreAllow.Checked)
            {
                chkCreAllow.Text = "Yes";
                ObjOpsConsAWBDomainView.BillDTaxCreditY = "Y";
            }
            else
            {
                chkCreAllow.Text = "No";
                ObjOpsConsAWBDomainView.BillDTaxCreditY = "";
            }
        }

        private void chkDetained_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDetained.Checked)
            {
                chkDetained.Text = "Yes";
                ObjOpsConsAWBDomainView.DetainedY = "Y";
            }
            else
            {
                chkDetained.Text = "No";
                ObjOpsConsAWBDomainView.DetainedY = "";
            }
        }

        private void chkDutyEx_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDutyEx.Checked)
            {
                chkDutyEx.Text = "Yes";
                ObjOpsConsAWBDomainView.DutyExcemptY = "Y";
            }
            else
            {
                chkDutyEx.Text = "No";
                ObjOpsConsAWBDomainView.DutyExcemptY = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FormState = FormStateEnum.Import;
            var search = new OrgSearchValueDomainView
            {

                OrgName = txtName.Text ,
            };
            new CustomerSearch(ref search).ShowDialog();

            if (search.OrgCode == 0)
            {
               /// txtCode.Text = "";
            }
            else
            {
                txtCode.Text = search.OrgCode.ToString();
                txtName.Text = search.OrgName;
                txtOrgAdd1.Text = search.OrgAdd1;
                txtOrgAdd2.Text = search.OrgAdd2;
                txtCity.Text = search.OrgCity;
            }            
           
           

        }

        private void txtCrrCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if (currency != null && currency.Count > 0)
                {
                    var currValues = currency.FindAll(curr => curr.Currency.ToUpper().Contains(txtCrrCode.Text.ToUpper()));

                    if (currValues == null || currValues.Count == 0)
                    {
                        txtCrrCode.Text = "";
                    }
                    else
                    {
                        cmbCurrencey.DataSource = currValues;
                        txtCrrCode.Text = cmbCurrencey.SelectedValue.ToString();
                    }


                }
                else
                {
                    txtCrrCode.Text = "";
                }
            }
        }

        private void cmbCurrencey_SelectedValueChanged(object sender, EventArgs e)
        {
           if( cmbCurrencey.SelectedItem !=null )
            {
               txtCrrCode.Text =  cmbCurrencey.SelectedValue.ToString();
            }
        }

        private void chkOnetime_CheckedChanged(object sender, EventArgs e)
        {
            if(chkOnetime.Checked )
            {
                button1.Enabled = false;
                txtCode.Text = Convert.ToString(LoginInfoView.ONECUSTCODE); // "100000000";                
                txtName.Text = ObjOpsConsAWBDomainView.RecCompany;
                txtOrgAdd1.Text = ObjOpsConsAWBDomainView.RecAddr1;
                txtOrgAdd2.Text = ObjOpsConsAWBDomainView.RecAddr2;
                txtCity.Text = ObjOpsConsAWBDomainView.RecCityN;
                EnableOrganization(true);
            }
            else
            {
                button1.Enabled = true;
                EnableOrganization(false);
            }
            CleareOrgnize();
        }

        private void EnableOrganization(bool _value)
        {
            txtName.Enabled = _value;
            txtOrgAdd1.Enabled = _value;
            txtOrgAdd2.Enabled = _value;
            txtCity.Enabled = _value;
        }

        private void CleareOrgnize()
        {
            if(FormState ==FormStateEnum.Import)
            {
                txtCode.Text = "";
                txtName.Text = "";
                txtOrgAdd1.Text = "";
                txtOrgAdd2.Text = "";
                txtCity.Text = "";
            }
           
        }
    }
}
