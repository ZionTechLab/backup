using Express.Domain.Message;
using Express.Interfaces.Invoice;
using Express.Interfaces.Mail;
using Express.Interfaces.Report;
using Express.Interfaces.Report.Invoice;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Common.SrvReference;
using Express.UI.Factory.Invoice;
using Express.UI.Factory.Mail;
using Express.UI.Factory.Report;
using Express.UI.Factory.Report.Invoice;
using Express.UI.Filters.View;
using Express.UI.Helpers;
using Express.View.Domain.Filters;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Mail;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Invoice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Invoice.View
{
    public partial class DutyManualInvoice : Form, IDataManipulate
    {
        private  IInvDutyProvider<InvDutyDomainView> _dutyData;
        private  IGeneralReport _generalRpt;
        private  IInvoiceReportProvider _report;
        private InvDutyDomainView _param;
        private InvDutyJobDomainView _jobDet;
        private InvDutyConsAwbDomainView _consDet;
        private ManifestClearenceDomainView _manifestConfig;
        private List<InvDutyChargeDomainView> _charge;
        private List<InvDutyAutoChargeDomainView> _autochgCal;
        private InvDutyJobtransactDomainView _jobtransact;
        private IMail<SendMailDomainView> MailDataProvider;
        Dictionary<string, decimal> _existVal;
        private InvDutyDomainView _invDtax;
        private FormStateEnum FormState;
        private InvoiceProcess InvStatus;
        private string ShipType;
        private string BilTo;
        private string BranchCode;
        private string SenRefNotes;
        private string StationID;
        private string GateWayID;
        private string RouteID;
        private int ShipValCate;
        private string ShipValType;
        private string agencyRpt;

        private decimal _payamount;
        private decimal _invamount;

        private decimal _invLAmount;
        //private string _chageDet;
        private string _AccIcpc;
        private int hasIcpcAccountDet; /// 0 --no val ,1 has , 
        private int _DocFixOrgCode;
        private string _baseCurrency;
        private string _foriengCurrency;
        
        public DutyManualInvoice()
        {
            InitializeComponent();
            InitFormLoad();
            if (MailDataProvider == null)
            {
                MailDataProvider = MailUIFacotry.GetService<IMail<SendMailDomainView>>();
            }
        }


        public DutyManualInvoice(string _awbnumber)
        {
            InitializeComponent();
            InitFormLoad();
            txtAwbNo.Text = _awbnumber;
            GetDutyAirwabilDetails();
        }

        private void InitFormLoad()
        {
            if (_dutyData == null)
            {
                _dutyData = InvoiceUIFactory.GetService<IInvDutyProvider<InvDutyDomainView>>();
            }
            if (_generalRpt == null)
            {
                _generalRpt = GeneralnvoiceUIFactrory.GetService<IGeneralReport>();
            }

            if (_report == null)
            {
                _report = RptInvoiceUIFactory.GetService<IInvoiceReportProvider>();
            }

           

            _param = new InvDutyDomainView();
            _consDet = new InvDutyConsAwbDomainView();
            _jobDet = new InvDutyJobDomainView();
            _charge = new List<InvDutyChargeDomainView>();
            _invDtax = new InvDutyDomainView();
            _autochgCal = new List<InvDutyAutoChargeDomainView>();
            _manifestConfig = new ManifestClearenceDomainView();
            _jobtransact = new InvDutyJobtransactDomainView();
            _existVal = new Dictionary<string, decimal>();
            dutyDataManup.NewButtonClick += new EventHandler(NewMethod);
            dutyDataManup.SaveButtonClick += new EventHandler(SaveMethod);
            dutyDataManup.EditButtonClick += new EventHandler(EditMethod);
            dutyDataManup.CancelButtonClick += new EventHandler(ClearMethod);
            dutyDataManup.CloseButtonClick += new EventHandler(CloseForm);
            dutyDataManup.PreviewButtonClick += new EventHandler(previewMethod);

            dutyDataManup.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.PREVIEW, true, ButtonCustomState.DISABLEENABBLE);

            dutyDataManup.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            ////dutyDataManup.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.HIDEVISIBLE);

            grvDutyCharge.AutoGenerateColumns = false;
            FormState = FormStateEnum.Initial;
            InvStatus = InvoiceProcess.NEW;
            _param.UserID = LoginInfoView.USERID;
            _payamount = 0;
            _invamount = 0;
            txtAmtPayLC.Text = "0";
            txtAmtPayFC.Text = "0";
            txtAmtInvFC.Text = "0";
            txtAmtInvLC.Text = "0";
            ShipType = "";
            BilTo = "";
            BranchCode = "";
            SenRefNotes = "";
            StationID = "";
            GateWayID = "";
            RouteID = "";
            ShipValCate = 0;
            ShipValType = "";
            agencyRpt = "";
            GroupEnable(false);
            btnInvoice.Enabled = true;
            btnPayment.Enabled = true;
            chkOneTime.Checked = true;
            _AccIcpc = "";
            _DocFixOrgCode = 0;
            // btnOrgSearch.Enabled = false;
        }

        private void GroupEnable(bool _enble)
        {
            groupCustomer.Enabled = _enble;
            groupOther.Enabled = _enble;
            groupCharge.Enabled = _enble;
            cmbInvDocumet.Enabled = _enble;
            cmbPayDocument.Enabled = _enble;
            if (_DocFixOrgCode > 0 )
            {
                btnOrgSearch.Enabled = false;
                chkOneTime.Enabled = false;
            }
        }


        #region common button component events
        public void ClearMethod(object param, EventArgs e)
        {
            txtAwbNo.ReadOnly = false;
            ClearAirbillDetail();
            ClearCharges();
            ClearInvDetail();
            ClearOrgDetail();
            txtAwbNo.Text = "";
            FormState = FormStateEnum.Initial;
            InvStatus = InvoiceProcess.NEW;
            GroupEnable(false);
            dutyDataManup.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
        }

        public void CloseForm(object param, EventArgs e)
        {
            this.Dispose();
        }

        public void DeleteMethod(object param, EventArgs e)
        {

        }

        public void EditMethod(object param, EventArgs e)
        {
            if (InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.INVPAY)
            {
                MessageNotification.MessageBoxError("This airwaybill allready invoiced", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (InvStatus == InvoiceProcess.NEW)
            {
                MessageNotification.MessageBoxError("This airwaybill was not saved", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if(InvStatus == InvoiceProcess.INVPAY || InvStatus == InvoiceProcess.PAYMENT)
            {
                BindChargesValidateData(_charge);
            }

          

            SetBayRefRead();
            FormState = FormStateEnum.Update;
            GroupEnable(true);
            SetDoctypeEnable();
            dutyDataManup.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
        }

        public void FilterMethod(object param, EventArgs e)
        {

        }

        public void ImportMethod(object param, EventArgs e)
        {

        }

        public void NewMethod(object param, EventArgs e)
        {
            if (InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.INVPAY)
            {
                MessageNotification.MessageBoxError("This airwaybill allready invoiced", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (InvStatus == InvoiceProcess.BILL || InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.INVPAY || InvStatus==InvoiceProcess.PAYMENT )
            {
                MessageNotification.MessageBoxError("This airwaybill allready saved, please edit", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            FormState = FormStateEnum.New;
            dutyDataManup.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dutyDataManup.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            GroupEnable(true);
        }

        public void previewMethod(object param, EventArgs e)
        {
            if(txtInvNo.Text =="" || txtInvNo.Text =="0")
            {
                MessageNotification.MessageBoxError("Please process invoice first", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            var _paramR = new InvoiceDutyClearencePara()
            {
                AgencyID = Convert.ToInt32(txtAgnCode.Text),
                CompanyID =Convert.ToInt32(txtCmpCode.Text ),
                InvoiceNo = txtInvNo.Text ,
                UserID = LoginInfoView.USERID 
            };

            var _invDuty = _dutyData.GetDutyPrint(_paramR);
            var _company = _generalRpt.GetCompany(_paramR.CompanyID);
            if (_invDuty != null && _company != null)
            {
                _report.ClearenceDutyPrint(_invDuty, _company);
            }


        }

        public void PrintMethod(object param, EventArgs e)
        {

        }

        public void ProccessMethod(object param, EventArgs e)
        {

        }

        public void SaveMethod(object param, EventArgs e)
        {
            FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
            ResponseMessage responce = null;

            if (InvStatus == InvoiceProcess.INVOICE)
            {
                MessageNotification.MessageBoxError("Invoice already procceed", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }


            if (!HasCharge())
            {
                MessageNotification.MessageBoxError("Please enter charge amout", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }


            if (!NumberValidator.TryPassDecimal(txtClrRate.Text))
            {
                MessageNotification.MessageBoxError("Manifested exchange rate can not be 0", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (!NumberValidator.TryPassDecimal(txtSellConvR.Text))
            {
                MessageNotification.MessageBoxError("Sell currency rate can not be empty", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (_invamount <= 0 && _payamount <= 0)
            {
                MessageNotification.MessageBoxError("Please enter values to charge code", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (cmbInvDocumet.SelectedItem == null)
            {
                MessageNotification.MessageBoxError("Please select payment acc number", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (!(cmbInvDocumet.SelectedIndex > -1))
            {
                MessageNotification.MessageBoxError("Please select invoice doc type", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }


            try
            {
                SetParameters();

                var vResult = CustomValidate.Instance.ValidateModel(_param);
                if (vResult == "")
                {
                    if (FormState == FormStateEnum.Save)
                    {
                        responce = _dutyData.SaveDetails(_param);
                    }
                    if (FormState == FormStateEnum.Update)
                    {
                        responce = _dutyData.EditDetails(_param);
                    }


                    if (responce.IsSuccess)
                    {
                        MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                        txtJobNo.Text = responce.ReturnValue;
                        InvStatus = InvoiceProcess.BILL;
                        btnInvoice.Enabled = true;
                        btnPayment.Enabled = true;
                        dutyDataManup.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                        dutyDataManup.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                        dutyDataManup.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                        dutyDataManup.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                        dutyDataManup.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                        GroupEnable(false);
                        _jobtransact = _dutyData.GetDutyJobtrasact(Convert.ToInt32(txtCmpCode.Text), Convert.ToInt32(txtAgnCode.Text), txtShipID.Text , txtDoctypeCode.Text , txtInvNo.Text);
                    }
                    else
                    {
                        MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    }
                }
                else
                {
                    MessageNotification.MessageBoxError(vResult, LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        private void label28_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region control envents
        private void txtAwbNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetDutyAirwabilDetails();
            }
        }

        private void GetDutyAirwabilDetails()
        {
            if (!TextValidator.IsSpecialChar(txtAwbNo.Text))
            {
                MessageNotification.MessageBoxError("Please remove special characters", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (FormState == FormStateEnum.New || FormState == FormStateEnum.Update)
            {
                MessageNotification.MessageBoxError("Please reset form before retrive ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            txtAwbNo.ReadOnly = true;
            ClearAirbillDetail();
            ClearOrgDetail();
            ClearCharges();
            ClearInvDetail();
            GetAwbDetail(txtAwbNo.Text);
           
        }

        private void cmbInvoiceType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbInvDocumet.SelectedItem != null)
            {
                var dType = ((InvDutyDoctypeDomainView)cmbInvDocumet.SelectedItem);
                txtDoctypeCode.Text = dType.DocType.Trim();
                if(FormState !=FormStateEnum.Initial )
                {
                    GetDutyExchangeRate(_consDet, _invDtax);
                }

                if (dType != null)
                {
                    ShipValType = dType.ShipValuType;
                }
                   
                GetCharges();
                SetFixOrgnization(dType);

            }
            else
            {
                txtDoctypeCode.Text = "";
            }
        }

        private void cmbPayDocument_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPayDocument.SelectedItem != null)
            {
                var dType = ((InvDutyDoctypeDomainView)cmbPayDocument.SelectedItem);
                txtPayDocCode.Text = dType.DocType.Trim();
                ////GetCharges();
                ////SetFixOrgnization(dType);

            }
            else
            {
                txtPayDocCode.Text = "";
            }
        }
        private void cmbStation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbStation.SelectedItem != null)
            {
                var _selectedV = ((InvDutySalesAreaDomainView)cmbStation.SelectedItem);
                txtStation.Text = _selectedV.SalesAreaID.Trim();
                BranchCode = _selectedV.BranchCode.Trim();
            }
        }
        private void chkOneTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOneTime.Checked)
            {
                btnOrgSearch.Enabled = false;
                txtOrgCode.Text = Convert.ToString(LoginInfoView.ONECUSTCODE);
                SetOrgReadOnly(CheckInvStusOrg());
                chkPayTerm.Checked = true ;
                txtInvMode.Text = "D";
                GetCharges();

            }
            else
            {
                btnOrgSearch.Enabled = true;
                txtOrgCode.Text = "";
                SetOrgReadOnly(true);
                txtInvMode.Text = "";
            }
        }

        private bool CheckInvStusOrg()
        {
            bool _isReadOnly = false;
            if (InvStatus == InvoiceProcess.INVPAY || InvStatus == InvoiceProcess.INVOICE)
            {
                _isReadOnly = true;
            }
            return _isReadOnly;
        }
        private void btnOrgSearch_Click(object sender, EventArgs e)
        {
            var _search = new OrgSearchValueDomainView
            {
                OrgName = txtOrgName.Text 
            };
            new CustomerSearch(ref _search).ShowDialog();

            if (_search.OrgCode == 0)
            {
                
                
            }
            else
            {
                SetDutyOrgnization(_search);
                GetOrgFinace(Convert.ToInt32(txtOrgCode.Text));
                GetCharges();
                GetOrgnizCharges(_search.OrgCode);
            }
        }

        private void grvDutyCharge_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            grvDutyCharge.CommitEdit(DataGridViewDataErrorContexts.Commit);
            

            try
            {
                if (e.ColumnIndex == 2)
                {
                    var payV = Convert.ToDecimal(grvDutyCharge.Rows[e.RowIndex].Cells["clPayAmount"].Value);
                   var glAcc= _charge.Where(chg => chg.ChargeCode.Trim() == grvDutyCharge.Rows[e.RowIndex].Cells["clChargCode"].Value.ToString().Trim()).FirstOrDefault();
                    if(glAcc !=null)
                    {     
                        if (glAcc.GlRevAc.Trim() != "")
                        {
                            grvDutyCharge.Rows[e.RowIndex].Cells["clInvAmount"].Value = NumberValidator.RoundPrecision(Convert.ToDecimal(grvDutyCharge.Rows[e.RowIndex].Cells["clPayAmount"].Value));
                        }    
                    }
               

                }

                _invLAmount = 0;
                _invLAmount = Convert.ToDecimal(grvDutyCharge.Rows[e.RowIndex].Cells["clInvAmount"].Value);

                if (e.ColumnIndex == 3)
                {
                    ////_invLAmount = 0;
                    ////_invLAmount = Convert.ToDecimal(grvDutyCharge.Rows[e.RowIndex].Cells["clInvAmount"].Value);
                    /////var autoCharges = _dutyData.GetAutoCharges("SELL", ShipValCate, txtDoctypeCode.Text, grvDutyCharge.Rows[e.RowIndex].Cells["clChargCode"].Value.ToString());

                    ///_invamount = _invamount + lineSellAmount;
                    //if (_autochgCal != null)
                    //{
                    //    if (_autochgCal.Count > 0)
                    //    {
                    //        //_autoPrec = autoCharges.FirstOrDefault().ValueP;
                    //        //_chageDet = autoCharges.FirstOrDefault().ChargeCode;
                    //        //_autoPrec = autoCharges.Where(chg => chg.ChargeCode.Trim() == grvDutyCharge.Rows[e.RowIndex].Cells["clChargCode"].Value.ToString().Trim()).FirstOrDefault().ValueP;
                    //        SetAutoCalCharge(_autochgCal);
                    //    }
                    //}

                    // txtAmtInvLC.Text = _invamount.ToString();
                    ///SetChgAmount();

                    ////_invamount = _invamount + Convert.ToDecimal(grvDutyCharge.Rows[e.RowIndex].Cells["clInvAmount"].Value);
                    ////txtAmtInvLC.Text = _invamount.ToString();
                    ////SetFcAmount();
                }

                if (_autochgCal != null)
                {
                    if (_autochgCal.Count > 0)
                    {                      
                        SetAutoCalCharge(_autochgCal , grvDutyCharge.Rows[e.RowIndex].Cells["clChargCode"].Value.ToString().Trim() , _invLAmount);
                    }
                }

                SetChgAmount();
            }
            catch (Exception ex)
            {

            }

        }

        private void grvDutyCharge_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 2)
            {
                var value = Convert.ToDecimal(0.0);
                var isNotValid = !(decimal.TryParse(e.FormattedValue.ToString(), out value));
                e.Cancel = isNotValid;
                if (isNotValid)
                {
                    MessageNotification.MessageBoxError("Please enter valid value", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                }

            }
           

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            ResponseMessage responce = null;
            if (InvStatus == InvoiceProcess.NEW)
            {
                MessageNotification.MessageBoxError("please save the AWB , before the payment process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (Convert.ToDecimal(txtAmtPayLC.Text) <= 0)
            {
                MessageNotification.MessageBoxError("Payment amount should be greater than 0", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            
            if (PayInvValid().Count() > 2)
            {
                btnPayment.Enabled = false;
                return;
            }

            if (cmbInvDocumet.SelectedItem == null)
            {
                MessageNotification.MessageBoxError("Please select payment acc number", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            try
            {
                if ((txtPayNo.Text != "0" && txtPayNo.Text != ""))
                {
                    MessageNotification.MessageBoxError("Payment already procceed..", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if ( _jobtransact ==null)
                {
                    MessageNotification.MessageBoxError("Please save payment detail before process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if( string.IsNullOrEmpty(_jobtransact.PayDocType.Trim()) )
                {
                    MessageNotification.MessageBoxError("Please save payment detail before process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                SetParameters();

             

                var vResult = CustomValidate.Instance.ValidateModel(_param);
                if (vResult != "")
                {
                    MessageNotification.MessageBoxError(vResult, LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }


                    responce = _dutyData.PaymentProccess(_param);
                if (responce.IsSuccess)
                {
                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                    txtPayNo.Text = responce.ReturnValue;
                    ////////////////InvStatus = InvoiceProcess.INVOICE;
                    var pn = (txtPayNo.Text.Trim() == "") ? 0 : Convert.ToInt32(txtPayNo.Text);
                    var inv = txtInvNo.Text;
                    SetInvoiceStatus(pn, inv);
                    SetDoctypeEnable();
                    dutyDataManup.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                    dutyDataManup.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                    dutyDataManup.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    dutyDataManup.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                    dutyDataManup.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                    HttpSapReference.SapSend();
                }
                else
                {
                    MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private string PayInvValid()
        {
            string msg = "";
            if (txtBayanNo.Text == null || txtBayanNo.Text == "")
            {
                msg = "Please enter Bayan no";
            }
            if (txtPayRef.Text == null || txtPayRef.Text == "")
            {
                msg = msg + "\n" + "Please enter payment ref";

            }
            if (msg != "")
            {
                MessageNotification.MessageBoxError(msg, LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            }

            return msg;

        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            ResponseMessage responce = null;

            try
            {
                if (InvStatus == InvoiceProcess.NEW)
                {
                    MessageNotification.MessageBoxError("please save the AWB , before the invoice process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
                if ((txtInvNo.Text != "0" && txtInvNo.Text != ""))
                {
                    MessageNotification.MessageBoxError("Invoice already procceed..", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if (Convert.ToDecimal(txtAmtInvLC.Text) <= 0)
                {
                    MessageNotification.MessageBoxError("Invoice amount should be greater than 0", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                ////if (txtBayanNo.Text == null || txtBayanNo.Text == "")
                ////{
                ////    MessageNotification.MessageBoxError("Please enter Bayan no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                ////    btnInvoice.Enabled = false;
                ////    return;
                ////}
                ////if (txtPayRef.Text == null || txtPayRef.Text == "")
                ////{
                ////    MessageNotification.MessageBoxError("Please enter payment ref", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                ////    btnInvoice.Enabled = false;
                ////    return;
                ////}
                if (PayInvValid().Count() > 2)
                {
                    btnInvoice.Enabled = false;
                    return;
                }

                if (cmbInvDocumet.SelectedItem == null)
                {
                    MessageNotification.MessageBoxError("Please select payment acc number", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

               

                SetParameters();
                responce = _dutyData.InoviceProccess(_param);
                if (responce.IsSuccess)
                {
                    txtInvNo.Text = responce.ReturnValue;
                    var pn = (txtPayNo.Text.Trim() == "") ? 0 : Convert.ToInt32(txtPayNo.Text);
                    var inv = txtInvNo.Text;
                    SetInvoiceStatus(pn, inv);

                    //var _paramR = new InvoiceDutyClearencePara()
                    //{
                    //    AgencyID = Convert.ToInt32(txtAgnCode.Text),
                    //    CompanyID = Convert.ToInt32(txtCmpCode.Text),
                    //    InvoiceNo = txtInvNo.Text,
                    //    UserID = LoginInfoView.USERID

                    //};

                    //var _invDuty = _dutyData.GetDutyPrint(_paramR);
                    //var _company = _generalRpt.GetCompany(_paramR.CompanyID);
                    //if (_invDuty != null && _company != null)
                    //{


                    //    var email = _dutyData.GetEmailAddress(int.Parse(_param.OrgnizCode), _param.GroupID);
                    //    SendMailDomainView _mail = new SendMailDomainView();
                    //    if (email != "")
                    //    {
                    //        _report.ClearenceDutyPrintExport(_invDuty, _company, _paramR.InvoiceNo);
                    //        byte[] byteArray = null;
                    //        byteArray = System.IO.File.ReadAllBytes(@"C:\TLM\Freight\" + _paramR.InvoiceNo + ".pdf");
                    //        _mail.ReferenceNo = int.Parse(_paramR.InvoiceNo);
                    //        _mail.ToEmail = email;
                    //        _mail.FromEmail = "sa.cc@sab-express.com";
                    //        _mail.FromEmailPassword = "SaB12345!";
                    //        _mail.EmailSubject = "Subject – Invoice No " + _paramR.InvoiceNo + " Dated " + _param.InvoiceDate.Date + " – Invoice " + _param.InvoiceType;
                    //        _mail.EmailBody = "<table><tr><td>&nbsp;</td><tr><td><p> Dear Customer,</p><p> At Sab Express, we are constantly looking to improve the way we do business with you.</p><p> Your new invoice is now ready, please find below the attached invoice.</p><p> For any assistance required please send us the queries to email: sa.cc @sab-express.com </p><p></p><p> Thank You </p><p> SAB Express LLC .</p></td></tr><td>&nbsp;</td></tr></table> ";
                    //        _mail.Attachment = byteArray;
                    //        _mail.Email_Area = "Invoicing";
                    //        _mail.USM_ID = LoginInfoView.USERID;
                    //        _mail.USM_DATE = System.DateTime.Now;
                    //        ResponseMessage message = MailDataProvider.SendMail(_mail);
                    //        if (message.IsSuccess == true)
                    //        {
                    //            if (File.Exists(@"C:\TLM\Freight\" + _paramR.InvoiceNo + ".pdf"))
                    //            {
                    //                File.Create(@"C:\TLM\Freight\" + _paramR.InvoiceNo + ".pdf").Close();
                    //                File.Delete(@"C:\TLM\Freight\" + _paramR.InvoiceNo + ".pdf");
                    //            }
                    //        }
                    //    }
                    //}

                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                    GroupEnable(false);
                    dutyDataManup.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                    dutyDataManup.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                    dutyDataManup.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    dutyDataManup.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                    dutyDataManup.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);


                    HttpSapReference.SapSend();
                }
                else
                {
                    MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region  methods

        /// <summary>
        /// Set airwabil detail , charge etc
        /// </summary>
        /// <param name="airbillNo">string</param>
        private void GetAwbDetail(string airbillNo)
        {
            if (airbillNo == "")
            {
                MessageNotification.MessageBoxError("Please enter airwaybil number", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            _consDet = _dutyData.GetAwbDetail(airbillNo.Trim());
            if (_consDet != null)
            {
                var _job = _dutyData.GetJobDetail(_consDet.CompanyID, _consDet.AgencyID, _consDet.ExpressID.Trim());
                var _trans = _dutyData.GetInvDutyDetail(_consDet.CompanyID, _consDet.AgencyID, _consDet.ExpressID.Trim());
                var agency = _dutyData.GetAgencyDetail(LoginInfoView.USERID, LoginInfoView.MODULEID, LoginInfoView.MENUCODE);

                if (agency != null && agency.Count > 0)
                {
                    agencyRpt = agency.Where(cmpx => cmpx.CompID == _consDet.CompanyID && cmpx.AgncyCode == _consDet.AgencyID).FirstOrDefault().AgncyID;
                }

                if (_trans != null)
                {
                    _jobtransact = _dutyData.GetDutyJobtrasact(_trans.CompanyID, _trans.AgncyCode, _trans.ExpressID.Trim(), _trans.InvoiceType.Trim(), _trans.InvoiceNo);
                    if (_jobtransact != null)
                    {
                        dteInvoiced.Value = _jobtransact.InvoiceDate;
                        dtePayment.Value = _jobtransact.PayDocDate;
                        ////if (_jobtransact.PayDocType.Trim() !="")
                        ////{
                        ////    cmbPayDocument.SelectedValue = _jobtransact.PayDocType.Trim();
                        ////}
                    }
                    if (_trans.InvoiceNo != "0")
                    {
                        

                        if (MessageNotification.MessageBoxConfirm("Invoice already processed , Do you want process new invoice ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
                        {
                            _trans = null;
                            InvStatus = InvoiceProcess.NEW;
                            btnInvoice.Enabled = true;
                            dteInvoiced.Value = DateTime.Now.Date;
                            dtePayment.Value = DateTime.Now.Date;
                        }
                    }
                }

                SetDutyDetails(_consDet, _trans, _job);
            }
            else
            {
                MessageNotification.MessageBoxError("Airwaybil number is not exists", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            }
        }

        /// <summary>
        /// Get duty document type detail
        /// </summary>
        /// <param name="_awb">type of InvDutyConsAwbDomainView</param>
        private void GetDutyDoctypes(InvDutyConsAwbDomainView _awb)
        {
            var _documentTypes = _dutyData.GetDutyDoctypes(_awb.CompanyID, _awb.AgencyID, _awb.ShipType, _awb.BillTaxChgType);
            var _payDocumentTypes = _dutyData.GetDutyDoctypes(_awb.CompanyID, _awb.AgencyID, _awb.ShipType, _awb.BillTaxChgType);
            cmbInvDocumet.DataSource = _documentTypes;
            cmbPayDocument.DataSource = _payDocumentTypes;
        }

        /// <summary>
        /// Set duty document type , fix bill organization
        /// </summary>
        /// <param name="_awb"></param>
        /// <param name="_invduty"></param>
        private void GetDutyDocument(InvDutyConsAwbDomainView _awb, InvDutyDomainView _invduty)
        {
            var lcShipValue = Convert.ToDecimal( ((txtShipValLC.Text == "") ? "0" : txtShipValLC.Text));
            var initDoc = _dutyData.GetDutyDocument(_awb.CompanyID, _awb.AgencyID, lcShipValue, _awb.BillTaxChgType, _awb.DutyExcemptY, _awb.ShipType);
            if (initDoc != null)
            {
                //nees
                SetDutyDocument(initDoc, _invduty);
                ShipValCate = initDoc.ShipValueTypeCata;
                ShipValType = initDoc.ShipValuType;
                _DocFixOrgCode = initDoc.BillOrgCode;
            }
            else
            {
                MessageNotification.MessageBoxError("Can not find document type", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            }

            if (_invduty == null)
            {
                if(initDoc != null)
                {
                    cmbPayDocument.SelectedValue = initDoc.DocType.Trim();
                }               
            }
            else
            {
                SetDutyDocument(null, _invduty);
            }

            if(_jobtransact !=null )
            {
                cmbPayDocument.SelectedValue = _jobtransact.PayDocType.Trim();
            }
        }

        private void GetDutyDocument()
        {
            var lcShipValue = Convert.ToDecimal(((txtShipValLC.Text == "") ? "0" : txtShipValLC.Text));
            var initDoc = _dutyData.GetDutyDocument(_consDet.CompanyID, _consDet.AgencyID, lcShipValue, _consDet.BillTaxChgType, _consDet.DutyExcemptY, _consDet.ShipType);
            if (initDoc != null)
            {
                //nees
                SetDutyDocument(initDoc, _invDtax);
                ShipValCate = initDoc.ShipValueTypeCata;
                ShipValType = initDoc.ShipValuType;
                _DocFixOrgCode = initDoc.BillOrgCode;
            }
            else
            {
               // MessageNotification.MessageBoxError("Can not find document type", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            }

           
        }

        private void SetFixOrgnization(InvDutyDoctypeDomainView initDoc)
        {
            _DocFixOrgCode = 0;
            if (_invDtax == null)
            {
                if (initDoc.BillOrgCode > 0)
                {
                    _DocFixOrgCode = initDoc.BillOrgCode;
                    GetDutyOrgnization(initDoc.BillOrgCode, "");
                }
                else if (_AccIcpc != "")
                {
                    GetDutyOrgnization(0, _AccIcpc);
                }
            }

        }
       
        /// <summary>
        /// Get dutly clearence exchange rate( onanda rate)
        /// </summary>
        /// <param name="_awb">type of InvDutyConsAwbDomainView </param>
        /// <param name="_invduty">of InvDutyDomainView</param>
        private void GetDutyClearenceExtrate(InvDutyConsAwbDomainView _awb, InvDutyDomainView _invduty)
        {
            if (_invduty == null)
            {
                var _para = new InvDutyExtrateDomainView()
                {
                    companyID = Convert.ToInt32(txtCmpCode.Text),
                    EffectDate = _awb.TransDate,
                    DefCurrency = _awb.ManiCurrCode
                };
                var _rates = _dutyData.GetDutyClearenceExtrate(_para);
                if (_rates != null)
                {
                    txtClrRate.Text = Convert.ToString(_rates.ExgRate);
                    txtLCurr.Text = _rates.ClearCurrency;
                    txtShipValLC.Text = NumberValidator.RoundPrecision( Convert.ToDecimal(_rates.ExgRate * _awb.ShipperValue)).ToString();
                }
                else
                {
                    /// add status -- can't process
                    MessageNotification.MessageBoxError("Can not find exchange rate for manifested currency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                }

            }
        }

        /// <summary>
        /// Get duty sell exchange rate
        /// </summary>
        /// <param name="_awb">type of InvDutyConsAwbDomainView</param>
        /// <param name="_invduty">type of InvDutyDomainView</param>
        private void GetDutyExchangeRate(InvDutyConsAwbDomainView _awb, InvDutyDomainView _invduty)
        {
            if(_awb==null)
            {
                return;
            }

            if (txtDoctypeCode.Text != "")
            {
                var _para = new InvDutyExtrateDomainView
                {
                    EffectDate = _awb.TransDate,
                    InvDocType = txtDoctypeCode.Text,
                    companyID = Convert.ToInt32(txtCmpCode.Text)
                };

                var _dRate = _dutyData.GetDutyExchangerate(_para);
                if (_dRate != null)
                {
                    txtSellConvR.Text = Convert.ToString(_dRate.ExgRate);
                    _baseCurrency = _dRate.BaseCurrency;
                    _foriengCurrency = _dRate.DefCurrency;
                }
                else
                {
                    // block proc
                    MessageNotification.MessageBoxError("Can't get exchange rate", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                }
            }
            else
            {
                // block proc
                MessageNotification.MessageBoxError("Please select invoice document type", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            }

        }

        /// <summary>
        /// Get sales area detail (station list)
        /// </summary>
        private void GetSalesLocation()
        {
            // local country shoud get from 
            //cmbStation.DataSource = null;
            cmbStation.DataSource = _dutyData.GetDutyLocations(Convert.ToInt32(txtCmpCode.Text), Convert.ToInt32(txtAgnCode.Text), "SA");
            cmbStation.SelectedIndex = -1;
            txtStation.Text = "";
            BranchCode = "";
        }


        /// <summary>
        /// Get charge detail according invoice document 
        /// </summary>
        private void GetCharges()
        {
        
            //if (InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.PAYMENT || InvStatus == InvoiceProcess.INVPAY || InvStatus == InvoiceProcess.BLOCK )
            //{
            //    return;
            //}

            if (Convert.ToInt32( (txtCmpCode.Text=="")? "0" : txtCmpCode.Text) <=0 || Convert.ToInt32( (txtAgnCode.Text=="")?"0" : txtAgnCode.Text) <=0)
            {
                return;
            }

            if (txtShipID.Text.Trim() =="")
            {
                return;
            }

            //if(Convert.ToDecimal(txtShipValLC.Text)<=0)
            //{
            //    return;
            //}

            if(ShipValCate <=0)
            {
                return;
            }

            if(txtDoctypeCode.Text ==null || txtDoctypeCode.Text =="")
            {
                return;
            }

            var charge = new InvChargeParamDomainView()
            {
                CompanyID = Convert.ToInt32(txtCmpCode.Text),
                AgencyID = Convert.ToInt32(txtAgnCode.Text),
                DocDate = DateTimeValidator.GetAppDateformat(dteTransDate.Value),
                ExpressID = txtShipID.Text.Trim(),
                ClrShipValue = Convert.ToDecimal(txtShipValLC.Text),
                ShipValCat = ShipValCate, // need to assing
                InvDocType = txtDoctypeCode.Text,
                PayDocType = txtPayDocCode.Text ,
                OrgCode = Convert.ToInt32( (txtOrgCode.Text=="")? "0" : txtOrgCode.Text ),
                InvoiceNo = txtInvNo.Text,
                paymentNo = txtPayNo.Text,
                IsDutyExcempt = _consDet.DutyExcemptY.Trim()
                
            };
            List<InvDutyChargeDomainView> _tempCharges = new List<InvDutyChargeDomainView>();
            _tempCharges.AddRange(_charge);
            _charge.Clear();           
            _charge = _dutyData.GetCharges(charge).ToList();

            List<InvDutyChargeDomainView> jobcharge = _dutyData.GetJobCharges(charge).ToList();
            foreach (InvDutyChargeDomainView item in jobcharge)
            {
                //_charge.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().PayLC = item.PayLC;
                _charge.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().SellLC = item.SellLC;
            }

            BindChargesData(_charge , _tempCharges);
            grvDutyCharge.CommitEdit(DataGridViewDataErrorContexts.Commit);
            SetChargesAmount();

        }


        /// <summary>
        /// Get Orgnize assing special charge
        /// </summary>
        /// <param name="_orgcode">int</param>
        private void GetOrgnizCharges(int _orgcode)
        {
            if(InvStatus ==InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.INVPAY)
            {
                return;
            }

            if( InvStatus == InvoiceProcess.BLOCK || InvStatus == InvoiceProcess.BLOCKINV)
            {
                return;
            }

            if(FormState != FormStateEnum.Update)
            {
                return;
            }

           var _orgcharges=  _dutyData.GetOrnizCharges(Convert.ToInt32(txtCmpCode.Text), _orgcode, _consDet.DutyExcemptY);
            foreach(InvDutyOrgnizChargeDomainView citem in _orgcharges)
            {
                _charge.Where(chg => chg.ChargeCode.Trim() == citem.ChargeCode.Trim()).FirstOrDefault().SellLC = citem.Amount;
            }

            if(_orgcharges!=null && _orgcharges.Count > 0)
            {
                BindChargesData(_charge);
                grvDutyCharge.CommitEdit(DataGridViewDataErrorContexts.Commit);
                SetChargesAmount();
            }
        }
        /// <summary>
        /// Pick charge details 
        /// </summary>
        /// <param name="_awb">type of InvDutyConsAwbDomainView</param>
        /// <param name="_invduty">type of InvDutyDomainView</param>
        private void GetCharges(InvDutyConsAwbDomainView _awb, InvDutyDomainView _invduty)
        {

            var charge = new InvChargeParamDomainView()
            {
                CompanyID = Convert.ToInt32(txtCmpCode.Text),
                AgencyID = Convert.ToInt32(txtAgnCode.Text),
                DocDate = _awb.TransDate,
                ExpressID = txtShipID.Text.Trim(),
                ClrShipValue = Convert.ToDecimal(txtShipValLC.Text),
                ShipValCat = ShipValCate, // need to assing
                InvDocType = txtDoctypeCode.Text,
                PayDocType = txtPayDocCode.Text ,
                OrgCode = Convert.ToInt32((txtOrgCode.Text == "") ? "0" : txtOrgCode.Text),
                InvoiceNo = txtInvNo.Text ,
                paymentNo = txtPayNo.Text ,
                IsDutyExcempt = _consDet.DutyExcemptY.Trim()
            };
            _charge.Clear();
            if (_invduty==null)
            {
                _charge = _dutyData.GetCharges(charge).ToList();              
                ///BindChargesData(_charge);
            } 
            else
            {
                if(InvStatus ==InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.INVPAY )
                {                                  
                    _charge = _dutyData.GetJobCharges(charge).ToList();                 
                    ///BindChargesData(_charge);
                }
                else
                {
                    
                    _charge = _dutyData.GetCharges(charge).ToList();
                    List<InvDutyChargeDomainView> jobcharge = _dutyData.GetJobCharges(charge).ToList();
                    foreach(InvDutyChargeDomainView item in jobcharge)
                    {
                        _charge.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().PayLC = item.PayLC;
                        _charge.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().SellLC = item.SellLC;
                    }
                    ///BindChargesData(_charge);
                }                
               
            }

            BindChargesData(_charge);
            grvDutyCharge.CommitEdit(DataGridViewDataErrorContexts.Commit);
            SetChargesAmount();

        }

        /// <summary>
        /// Set charges detail to charge grid
        /// </summary>
        /// <param name="_chargedetails"></param>
        private void BindChargesData(List<InvDutyChargeDomainView> _chargedetails)
        {
            //grvDutyCharge.Rows.Clear();
            string chgList = "";
            grvDutyCharge.DataSource = null;
            grvDutyCharge.DataSource = _chargedetails;
            int index = 0;
            foreach (InvDutyChargeDomainView chg in _chargedetails)
            {
                //grvDutyCharge.Rows.Add(chg.ChargeCode , chg.ChargeDesc ,chg.PayLC , chg.SellLC , chg.TaxCode1 , chg.TaxCode1Rate ,
                //         chg.TaxCode1Value  ,chg.TaxCode2 , chg.TaxCode2Rate , chg.TaxCode2Value );
                var glcA = chg.GlCosAc.Trim();
                if (glcA.Trim()=="")
                {
                    grvDutyCharge.Rows[index].Cells["clPayAmount"].ReadOnly = true;
                }

                if(InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.PAYMENT || InvStatus == InvoiceProcess.INVPAY )
                {
                    grvDutyCharge.Rows[index].Cells["clPayAmount"].ReadOnly = true;
                }

                if (InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.INVPAY)
                {
                    grvDutyCharge.Rows[index].Cells["clInvAmount"].ReadOnly = true;
                }


                var glrA = chg.GlRevAc.Trim();
                if (glrA.Trim() == "")
                {
                    grvDutyCharge.Rows[index].Cells["clInvAmount"].ReadOnly = true;
                }

                chgList = chgList + chg.ChargeCode.Trim()+",";
               
                index = index + 1;

            }
            GetAutoChargeCal(chgList , _chargedetails);
        }

        private void BindChargesData(List<InvDutyChargeDomainView> _chargedetails , List<InvDutyChargeDomainView> _tempCharge)
        {
            //grvDutyCharge.Rows.Clear();
            string chgList = "";

            foreach (InvDutyChargeDomainView item in _tempCharge)
            {
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().PayLC = item.PayLC;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().GlCosAc = item.GlCosAc;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().IsCostFix = item.IsCostFix;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().PayFC = item.PayFC;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().Seqno = item.Seqno;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().ConvRate = item.ConvRate;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().CurrencyRate = item.CurrencyRate;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().FCurrType = item.FCurrType;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().DocType = item.DocType;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().TaxCode1 = item.TaxCode1;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().TaxCode1Rate = item.TaxCode1Rate;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().TaxCode1Value = item.TaxCode1Value;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().TaxCode2 = item.TaxCode2;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().TaxCode2Rate = item.TaxCode2Rate;
                _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.ChargeCode.Trim()).FirstOrDefault().TaxCode3Value = item.TaxCode3Value;
            }


            grvDutyCharge.DataSource = null;
            grvDutyCharge.DataSource = _chargedetails;
            int index = 0;
            foreach (InvDutyChargeDomainView chg in _chargedetails)
            {
                //grvDutyCharge.Rows.Add(chg.ChargeCode , chg.ChargeDesc ,chg.PayLC , chg.SellLC , chg.TaxCode1 , chg.TaxCode1Rate ,
                //         chg.TaxCode1Value  ,chg.TaxCode2 , chg.TaxCode2Rate , chg.TaxCode2Value );
                var glcA = chg.GlCosAc.Trim();
                if (glcA.Trim() == "")
                {
                    grvDutyCharge.Rows[index].Cells["clPayAmount"].ReadOnly = true;
                }

                if (InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.PAYMENT || InvStatus == InvoiceProcess.INVPAY)
                {
                    grvDutyCharge.Rows[index].Cells["clPayAmount"].ReadOnly = true;
                }

                if (InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.INVPAY)
                {
                    grvDutyCharge.Rows[index].Cells["clInvAmount"].ReadOnly = true;
                }


                var glrA = chg.GlRevAc.Trim();
                if (glrA.Trim() == "")
                {
                    grvDutyCharge.Rows[index].Cells["clInvAmount"].ReadOnly = true;
                }

                chgList = chgList + chg.ChargeCode.Trim() + ",";

                index = index + 1;

            }
            GetAutoChargeCal(chgList, _chargedetails);
        }


        private void BindChargesValidateData(List<InvDutyChargeDomainView> _chargedetails)
        {
            //grvDutyCharge.Rows.Clear();
            string chgList = "";
            grvDutyCharge.DataSource = null;
            grvDutyCharge.DataSource = _chargedetails;
            int index = 0;
            foreach (InvDutyChargeDomainView chg in _chargedetails)
            {
               
                var glcA = chg.GlCosAc.Trim();
                if (glcA.Trim() == "")
                {
                    grvDutyCharge.Rows[index].Cells["clPayAmount"].ReadOnly = true;
                }

                if (InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.PAYMENT || InvStatus == InvoiceProcess.INVPAY)
                {
                    grvDutyCharge.Rows[index].Cells["clPayAmount"].ReadOnly = true;
                }

                if (InvStatus == InvoiceProcess.INVOICE || InvStatus == InvoiceProcess.INVPAY)
                {
                    grvDutyCharge.Rows[index].Cells["clInvAmount"].ReadOnly = true;
                }


                var glrA = chg.GlRevAc.Trim();
                if (glrA.Trim() == "")
                {
                    grvDutyCharge.Rows[index].Cells["clInvAmount"].ReadOnly = true;
                }

                index = index + 1;

            }
           
        }

        private void GetAutoChargeCal(string cList , List<InvDutyChargeDomainView> _chargedetails)
        {
            _autochgCal.Clear();
            _existVal.Clear();

            _autochgCal = _dutyData.GetAutoCharges("SELL", ShipValCate, txtDoctypeCode.Text, cList ,_consDet.DutyExcemptY.Trim() , Convert.ToDecimal( txtShipValLC.Text)).ToList();
            if(_autochgCal !=null)
            {
                foreach(string  item in _autochgCal.Select(chg=>chg.ChargeCode).Distinct())
                {
                    var val = _chargedetails.Where(chg => chg.ChargeCode.Trim() == item.Trim());
                    if(val !=null)
                    {
                        if(val.FirstOrDefault()!=null)
                        {
                            _existVal.Add(item.Trim(), val.FirstOrDefault().SellLC);
                        }                        
                    }
                }
            }
        }

        private void SetAutoCalCharge( List<InvDutyAutoChargeDomainView> chgAuto ,string currCharge , decimal invAmt)
        {
            decimal tempV = 0;      


            foreach (InvDutyAutoChargeDomainView item in chgAuto)
            {
                foreach (DataGridViewRow chg in grvDutyCharge.Rows)
                {
                    var rowVal = (InvDutyChargeDomainView)chg.DataBoundItem;
                    if (rowVal.ChargeCode.Trim() == item.ChargeCodeCal.Trim())
                    {
                        tempV = tempV + Convert.ToDecimal(Convert.ToDecimal( chg.Cells["clInvAmount"].Value) * (item.ValueP / 100));
                    }                  
                }
            }

           foreach(var item in _existVal)
            {
                foreach (DataGridViewRow chg in grvDutyCharge.Rows)
                {
                    var rowVal = (InvDutyChargeDomainView)chg.DataBoundItem;
                    if (rowVal.ChargeCode.Trim() == item.Key.Trim())
                    {
                        if(rowVal.IsSellFix !="Y")
                        {
                            if (tempV > item.Value)
                            {
                                chg.Cells["clInvAmount"].Value = NumberValidator.RoundPrecision( tempV );
                            }
                            else
                            {
                                chg.Cells["clInvAmount"].Value = NumberValidator.RoundPrecision(item.Value);
                            }
                        }                     
                       
                    }
                }
            }

            var isExistCalChg =  chgAuto.Where(autoC => autoC.ChargeCodeCal.Trim() == currCharge.Trim()).ToList();
            if(isExistCalChg.Count ==0)
            {
                foreach (DataGridViewRow chg in grvDutyCharge.Rows)
                {
                    var rowVal = (InvDutyChargeDomainView)chg.DataBoundItem;
                    if (rowVal.ChargeCode.Trim() == currCharge.Trim())
                    {
                        chg.Cells["clInvAmount"].Value = invAmt;

                    }
                }
            }

             SetChgAmount();
        }

        ////private void D(int companyID, int orgCode)
        ////{
        ////    if (orgCode > 0)
        ////    {
        ////        //_dutyData.GetOrgCharges(companyID, orgCode);
        ////    }
        ////}

        private void SetDoctypeEnable()
        {
            if(InvStatus == InvoiceProcess.PAYMENT || InvStatus == InvoiceProcess.INVPAY )
            {
                cmbPayDocument.Enabled = false;
            }
            else
            {
                cmbPayDocument.Enabled = true ;
            }


            if (InvStatus == InvoiceProcess.INVPAY  || InvStatus == InvoiceProcess.INVOICE)
            {
                cmbInvDocumet.Enabled = false;
            }
            else
            {
                cmbInvDocumet.Enabled = true;
            }
        }

        /// <summary>
        /// Set charge code amount
        /// </summary>
        private void SetChargesAmount()
        {
            if (_charge != null)
            {
                _payamount = _charge.Sum(su => su.PayLC);
                _invamount = _charge.Sum(su => su.SellLC);

                txtAmtInvLC.Text = _invamount.ToString();
                txtAmtPayLC.Text = _payamount.ToString();
                SetChgAmount();
            }
        }

        /// <summary>
        /// Set duty invoice detail 
        /// </summary>
        /// <param name="_awb">type of InvDutyConsAwbDomainView</param>
        /// <param name="_invduty">type of InvDutyDomainView</param>
        /// <param name="_job">type of InvDutyJobDomainView</param>
        private void SetDutyDetails(InvDutyConsAwbDomainView _awb, InvDutyDomainView _invduty, InvDutyJobDomainView _job)
        {
            _invDtax = _invduty;
            SetInvoiceStatus(_awb, _invduty);

            txtShipID.Text = (_invduty == null) ? _awb.ExpressID.Trim() : _invduty.ExpressID.Trim();
            txtCmpCode.Text = (_invduty == null) ? _awb.CompanyID.ToString() : _invduty.CompanyID.ToString();
            txtCmpN.Text = (_invduty == null) ? _awb.CompanyName : _invduty.CompanyN;
            txtAgnCode.Text = (_invduty == null) ? _awb.AgencyID.ToString() : _invduty.AgncyCode.ToString();
            txtAgnName.Text = (_invduty == null) ? _awb.AgencyName : _invduty.AgencyN;
            txtOrginCntr.Text = _awb.ShipCntr;
            txtOrginCntrN.Text = _awb.ShipCntrN;
            txtDestCntr.Text = _awb.DestiCntr;
            txtDestCntrN.Text = _awb.DestiCntrN;
            txtOrgGateway.Text = _awb.OrginGateWay;
            txtDestGateway.Text = _awb.DestGateWay;
            txtOrgStation.Text = _awb.OrgStation;
            txtDestStation.Text = _awb.DesStation;
            txtConsoleID.Text = _awb.ConsoleID;

            ShipType = (_invduty == null) ? _awb.ShipType : _invduty.ShipType;
            BilTo = (_invduty == null) ? _awb.BillTaxChgType : _invduty.BillTaxChgType;
            SenRefNotes = (_invduty == null) ? _awb.SenRefNotes : _invduty.SenRefNotes;

            txtStation.Text = (_invduty == null) ? _awb.StationID : _invduty.StationID;
            txtPayBy.Text = (_invduty == null) ? _awb.PayBy : _invduty.PaidBy;
            txtAccount.Text = _awb.AccountNo;
            _AccIcpc  = _awb.AccountNo;
            dteTransDate.Value = (_invduty == null) ?  _awb.TransDate :  _invduty.TransDate;
            txtMAWB.Text = (_invduty == null) ? _awb.MasterAwbNo : _invduty.MasterAwbNo;
            txtConsID.Text = (_invduty == null) ? _awb.ConsID : _invduty.ConsID;
            txtBayanNo.Text = (_invduty == null) ? _awb.CusdecNo : _invduty.CusdecNo;
            txtDesc.Text = (_invduty == null) ? _awb.GoodDescp : _invduty.GoodDescp;
            txtShipValFC.Text = (_invduty == null) ? Convert.ToString(_awb.ShipperValue) : Convert.ToString(_invduty.ShipperValue);
            txtFCurr.Text = (_invduty == null) ? _awb.ManiCurrCode : _invduty.ManiCurrCode;
            txtShipValLC.Text = (_invduty == null) ? Convert.ToString(_awb.ClrShipValue) : Convert.ToString( _invduty.ShipValueLoc);
            txtLCurr.Text  = (_invduty == null) ? _awb.ClrShipCurr : _invduty.CustomValCur;
            txtClrRate.Text  = (_invduty == null) ? "" :Convert.ToString(  _invduty.ManExtRate);
            txtJobNo.Text = (_job == null) ? "" : _job.JobNo;
            txtPayNo.Text = (_invduty == null) ? "0" :Convert.ToString(  _invduty.PayNo);
            txtInvNo.Text = (_invduty == null) ? "0" : Convert.ToString(_invduty.InvoiceNo);
            txtInvMode.Text = (_invduty == null) ? "D" : _invduty.InvMode;
            txtPayRef.Text = (_invduty == null) ? "" : _invduty.PayRefno;

            if(_jobtransact==null)
            {
                dtePayment.Value = DateTime.Now.Date;
                if (_invduty != null)
                {
                    if (_invduty.PayNo > 0)
                    {
                        dtePayment.Value = _invduty.PayDate;
                    }
                }
            }
            

            StationID = (_invduty == null) ? _awb.StationID : _invduty.StationID  ;
            GateWayID = (_invduty == null) ? _awb.GateWayID: _invduty.GateWayID  ;
            RouteID = (_invduty == null) ? _awb.RouteID : _invduty.RouteID ;


            GetSalesLocation();
            GetDutyDoctypes(_awb);
            GetDutyPayAccounts();            
            GetDutyClearenceExtrate(_awb, _invduty);
            GetDutyDocument(_awb, _invduty);
            GetDutyExchangeRate(_awb, _invduty);
            SetDutyOrgnization(_awb, _invduty);
            ////GetSalesLocation();
            GetCharges(_awb, _invduty);
            SetBayRefRead();
        }

        private void SetBayRefRead()
        {
           if( InvStatus == InvoiceProcess.INVPAY || InvStatus == InvoiceProcess.PAYMENT || InvStatus == InvoiceProcess.INVOICE )
            {
                txtBayanNo.ReadOnly = true;
                txtPayRef.ReadOnly = true;
            }
           else
            {
                txtBayanNo.ReadOnly = false ;
                txtPayRef.ReadOnly = false ;
            }
        }


        /// <summary>
        /// Set invoice stauts 
        /// </summary>
        /// <param name="_awb">type of InvDutyConsAwbDomainView</param>
        /// <param name="_invduty"> type of InvDutyDomainView</param>
        private void SetInvoiceStatus(InvDutyConsAwbDomainView _awb, InvDutyDomainView _invduty)
        {
            if(_invduty==null)
            {
                InvStatus = InvoiceProcess.NEW;
            }
            else
            {
                if( (_invduty.InvoiceNo == "0" || _invduty.InvoiceNo == "" ) )
                {
                    InvStatus = InvoiceProcess.BILL;
                }

                if ((_invduty.InvoiceNo != "0" && _invduty.InvoiceNo != "") && (_invduty.PayNo == 0))
                {
                    InvStatus = InvoiceProcess.INVOICE;
                   
                    btnInvoice.Enabled = false;
                }

                if ((_invduty.PayNo  != 0 )  && (_invduty.InvoiceNo == "0" || _invduty.InvoiceNo == ""))
                {
                    InvStatus = InvoiceProcess.PAYMENT;
                }

                if((_invduty.InvoiceNo != "0" && _invduty.InvoiceNo != "") && (_invduty.PayNo != 0))
                {
                    InvStatus = InvoiceProcess.INVPAY;
                   
                    btnInvoice.Enabled = false;
                }



            }
            //else if (_invduty.InvoiceNo =="0" || _invduty.InvoiceNo =="")
            //{
            //    InvStatus = InvoiceProcess.BILL;
            //}
            //else if()
            
           
        }

        private void SetInvoiceStatus(int  PayNo, string  InvoiceNo)
        {
            
                if ((InvoiceNo == "0" || InvoiceNo == ""))
                {
                    InvStatus = InvoiceProcess.BILL;
                }

                if ((InvoiceNo != "0" && InvoiceNo != "") && (PayNo == 0))
                {
                    InvStatus = InvoiceProcess.INVOICE;

                    btnInvoice.Enabled = false;
                }

                if ((PayNo != 0) && (InvoiceNo == "0" || InvoiceNo == ""))
                {
                    InvStatus = InvoiceProcess.PAYMENT;
                }

                if ((InvoiceNo != "0" && InvoiceNo != "") && (PayNo != 0))
                {
                    InvStatus = InvoiceProcess.INVPAY;

                    btnInvoice.Enabled = false;
                }
        }

        /// <summary>
        /// Set invoice document detail
        /// </summary>
        /// <param name="_docT"></param>
        /// <param name="_invduty"></param>
        private void SetDutyDocument(InvDutyDoctypeDomainView _docT, InvDutyDomainView _invduty)
        {
            txtDoctypeCode.Text = (_invduty == null) ? _docT.DocType : _invduty.InvoiceType.Trim();
            cmbInvDocumet.SelectedValue = (_invduty == null) ? _docT.DocType : _invduty.InvoiceType.Trim();
        }

        /// <summary>
        /// Set organization from search
        /// </summary>
        /// <param name="_search">OrgSearchValueDomainView</param>
        private void SetDutyOrgnization(OrgSearchValueDomainView _search)
        {
            //chkOneTime.Checked = (_invduty == null) ? true : false;
            chkOneTime.Checked = (_search.OrgCode == LoginInfoView.ONECUSTCODE) ? true : false;
            txtOrgCode.Text = _search.OrgCode.ToString();
            txtOrgName.Text = _search.OrgName;
            txtOrgAdd1.Text = _search.OrgAdd1;
            txtOrgAdd2.Text = _search.OrgAdd2;
            txtOrgCity.Text = _search.OrgCity;
            txtOrgCountry.Text = _search.OrgCountry;
            txtOrgCountryN.Text = _search.OrgCountryN;
            txtOrgTel.Text = _search.OrgCountryN;

            //cmbStation.SelectedValue = _search.SalesAreaID;

            // phone 
            // sales area 
            // cash or cr
            // inv pro module
            // var reg no
        }

        /// <summary>
        /// Set organization from airwaybil search and exist bill
        /// </summary>
        /// <param name="_awb"></param>
        /// <param name="_invduty"></param>
        private void SetDutyOrgnization(InvDutyConsAwbDomainView _awb, InvDutyDomainView _invduty)
        {
            ///if(_invduty==null && _AccIcpc.Trim() =="" && _DocFixOrgCode ==0 )
            if (_invduty==null && hasIcpcAccountDet == 0 && _DocFixOrgCode ==0 )
            {
                chkOneTime.Checked = (_invduty == null) ? true : ((_invduty.OrgnizCode == LoginInfoView.ONECUSTCODE.ToString()) ? true : false);
                txtOrgCode.Text = (_invduty == null) ? LoginInfoView.ONECUSTCODE.ToString() : _invduty.OrgnizCode.ToString();
                txtOrgName.Text = (_invduty == null) ? _awb.OrgName : _invduty.OrgnizName;
                txtOrgAdd1.Text = (_invduty == null) ? _awb.Address1 : _invduty.OrgAddr1;
                txtOrgAdd2.Text = (_invduty == null) ? _awb.Address2 : _invduty.OrgAddr2;
                txtOrgCity.Text = (_invduty == null) ? _awb.City : _invduty.OrgCity;
                txtOrgCountry.Text = (_invduty == null) ? _awb.CountryC : _invduty.OrgCntrCode;
                txtOrgCountryN.Text = (_invduty == null) ? _awb.CountryN : _invduty.OrgCntrN;
                txtOrgTel.Text = (_invduty == null) ? _awb.PhoneN : _invduty.OrgCntrN;
                cmbStation.SelectedValue = (_invduty == null) ? _awb.StationID.Trim() : _invduty.SalesAreaID.Trim();
                txtInvMode.Text = (_invduty == null)? "D" : _invduty.InvMode;
            }  
            else if(_invduty == null && (hasIcpcAccountDet != 0 || _DocFixOrgCode != 0))
            {
                cmbStation.SelectedValue = _awb.StationID.Trim() ;
            }          
            else if(_invduty!=null)
            {
                chkOneTime.Checked = ((_invduty.OrgnizCode == LoginInfoView.ONECUSTCODE.ToString()) ? true : false);
                txtOrgCode.Text = _invduty.OrgnizCode.ToString();
                txtOrgName.Text = _invduty.OrgnizName;
                txtOrgAdd1.Text = _invduty.OrgAddr1;
                txtOrgAdd2.Text =  _invduty.OrgAddr2;
                txtOrgCity.Text = _invduty.OrgCity;
                txtOrgCountry.Text =  _invduty.OrgCntrCode;
                txtOrgCountryN.Text =_invduty.OrgCntrN;
                txtOrgTel.Text =  _invduty.OrgCntrN;
                if(_invduty.SalesAreaID!=null)
                {
                    cmbStation.SelectedValue = _invduty.SalesAreaID.Trim();
                }
               
                txtInvMode.Text = _invduty.InvMode;

            }         
           
            
            //inv mode
            // pay term
            // exist bill org phone
        }

        /// <summary>
        /// Set organization from icpc or fix org
        /// </summary>
        /// <param name="_org">type of InvDutyOrgnizDomainView</param>
        private void SetDutyOrgnization(InvDutyOrgnizDomainView _org)
        {
            // chkOneTime.Checked = (_invduty == null) ? true : ((_invduty.OrgnizCode == LoginInfoView.ONECUSTCODE.ToString()) ? true : false);
            chkOneTime.Checked = false;
            txtOrgCode.Text = _org.CompanyCode.ToString();
            txtOrgName.Text = _org.CompanyName ;
            txtOrgAdd1.Text = _org.Address1 ;
            txtOrgAdd2.Text =  _org.Address2;
            txtOrgCity.Text =  _org.CityName ;
            txtOrgCountry.Text =  _org.CountryCode;
            txtOrgCountryN.Text =  _org.CountryName;
            txtOrgTel.Text =  _org.OrgPhone;
            ///cmbStation.SelectedValue =  _org.SalesAreaID;
        }

        /// <summary>
        /// Get organization finance detail
        /// </summary>
        /// <param name="orgCode">int</param>
        private void GetOrgFinace(int orgCode)
        {
            var orgFinaceD = _dutyData.GetDutyOrgnizFinance(Convert.ToInt32(txtCmpCode.Text), orgCode);
            if (orgFinaceD != null)
            {
               ///// cmbStation.SelectedValue = orgFinaceD.SalesAreaID.Trim();
                txtOrgTaxReg.Text = orgFinaceD.TaxCodeOne;
                txtInvMode.Text = orgFinaceD.InvMode;
                chkPayTerm.Checked = (orgFinaceD.IsCredit == "Y") ? false  : true ;
            }
            else
            {
                txtInvMode.Text = "D";
                chkPayTerm.Checked = true   ;
            }
        }

        /// <summary>
        /// Get organinzation detail using icpc or orgnization code
        /// </summary>
        /// <param name="orgcode">int</param>
        /// <param name="icpc">string</param>
        private void GetDutyOrgnization(int orgcode , string icpc)
        {
            var _org = _dutyData.GetDutyOrgnization(Convert.ToInt32(txtCmpCode.Text), orgcode, icpc);
            if (_org != null)
            {
                SetDutyOrgnization(_org);
                GetOrgFinace(_org.CompanyCode);

                if(icpc!=null && icpc !="")
                {
                    btnOrgSearch.Enabled = true ;
                    chkOneTime.Enabled = true ;
                    hasIcpcAccountDet = 1;
                }
                else
                {
                    btnOrgSearch.Enabled = false;
                    chkOneTime.Enabled = false;
                    hasIcpcAccountDet = 0;
                    //chkOneTime.Checked = true;
                }
               
            }
            else
            {
                if(orgcode>0)
                {
                    MessageNotification.MessageBoxError("Can not find billing organization", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);
                }

                if (icpc != null && icpc != "")
                {
                    hasIcpcAccountDet = 0;
                }

            }
        }

        private void GetDutyPayAccounts()
        {
            var payaccdet = _dutyData.GetClrPayAccounts(Convert.ToInt32(txtCmpCode.Text));
            cmbPayAccount.DataSource = payaccdet;
            if(payaccdet.Where(pay => pay.DefV == "Y").Count()>0)
            {
                cmbPayAccount.SelectedValue = payaccdet.Where(pay => pay.DefV == "Y").FirstOrDefault().AccountCode;
            }
         
        }


        /// <summary>
        /// Calculate Forieng currency charge amount
        /// </summary>
        private void SetChgAmount()
        {
            CalculateCharges();

            txtAmtPayLC.Text = _payamount.ToString();
            txtAmtInvLC.Text = _invamount.ToString();
            if (_payamount != 0)
            {
                if (txtSellConvR.Text != "")
                {
                    txtAmtPayFC.Text = Convert.ToString(NumberValidator.RoundPrecision(_payamount / Convert.ToDecimal((txtSellConvR.Text))));
                }
            }
            else
            {
                txtAmtPayFC.Text = "0";
            }

            if (_invamount != 0)
            {
                if (txtSellConvR.Text != "")
                {
                    txtAmtInvFC.Text = Convert.ToString(NumberValidator.RoundPrecision(  _invamount / Convert.ToDecimal((txtSellConvR.Text)))  );
                }
            }
            else
            {
                txtAmtInvFC.Text = "0";
            }
           
        }

        private void CalculateCharges()
        {
            _invamount = 0;
            _payamount = 0;
            foreach (DataGridViewRow chg in grvDutyCharge.Rows)
            {
                _invamount = _invamount + Convert.ToDecimal(chg.Cells["clInvAmount"].Value);
                _payamount = _payamount + Convert.ToDecimal(chg.Cells["clPayAmount"].Value);
            }
        }

        /// <summary>
        /// Calculate local currency charge amount
        /// </summary>
        /// <param name="_val"></param>
        //private void SetLcAmount(decimal _val)
        //{
        //    _invamount= _val+Convert.ToDecimal( (txtAmtInvLC.Text=="" || txtAmtInvLC.Text ==null) ? "0" : txtAmtInvLC.Text);
        //    txtAmtInvLC.Text = _invamount.ToString();
        //}

        /// <summary>
        /// Set Orgnization field read only property
        /// </summary>
        /// <param name="_isReadOnly"></param>
        private void SetOrgReadOnly(bool _isReadOnly)
        {
            txtOrgAdd1.ReadOnly = _isReadOnly;
            txtOrgAdd2.ReadOnly = _isReadOnly;
            txtOrgCity.ReadOnly = _isReadOnly;
            txtOrgName.ReadOnly = _isReadOnly;
            txtOrgTaxReg.ReadOnly = _isReadOnly;
            txtOrgTel.ReadOnly = _isReadOnly;
            txtOrgCountry.ReadOnly = _isReadOnly;
            txtOrgCountryN.ReadOnly = _isReadOnly;

           // cmbStation.Enabled = (_isReadOnly == true) ? false : true;

        }


        /// <summary>
        /// set duty invoice details
        /// </summary>
        private void SetParameters()
        {
            

            _param.GroupID = 1;
            _param.CompanyID = Convert.ToInt32(txtCmpCode.Text);
            _param.AgncyCode = Convert.ToInt32(txtAgnCode.Text);
            _param.AgencyRpt = agencyRpt;             
            _param.AirWayBill = txtAwbNo.Text.Trim();
            _param.ExpressID = txtShipID.Text.Trim();
            _param.ConsID = txtConsID.Text;
            _param.MasterAwbNo = txtMAWB.Text;
            _param.TransDate = DateTimeValidator.GetAppDateformat(dteTransDate.Value); /// convert format
            _param.InvoiceDate = DateTimeValidator.GetAppDateformat(dteInvoiced.Value); /// convert format
            _param.ShipType = ShipType;
            //misroot
            //detain
            _param.BillTaxChgType = BilTo;
            _param.CusdecNo = txtBayanNo.Text;
            _param.GoodDescp = txtDesc.Text;
            // hscode
            _param.ShipperValue = Convert.ToDecimal(txtShipValFC.Text);
            _param.ManiCurrCode = txtFCurr.Text;
            _param.ShipValueLoc = Convert.ToDecimal(txtShipValLC.Text);
            _param.CustomValCur = txtLCurr.Text;
            _param.ManExtRate = Convert.ToDecimal(txtClrRate.Text);
            _param.Remarks = txtRemark.Text;
            _param.TaxCodeOne = txtOrgTaxReg.Text;
            _param.InvoiceType = txtDoctypeCode.Text;
            _param.PaymentType = txtPayDocCode.Text;
            _param.OrgnizCode = txtOrgCode.Text;
            _param.OrgnizName = txtOrgName.Text;
            _param.OrgCntrCode = txtOrgCountry.Text;
            _param.InvMode = txtInvMode.Text;
            // dpt code
            _param.charges = _charge;
            _param.JobNo = txtJobNo.Text;
            _param.SalesAreaID = txtStation.Text;
            _param.BranchCode = BranchCode;
            _param.InvoiceNo = txtInvNo.Text;
            //_param.OrgPerson = txto
            _param.OrgAddr1 = txtOrgAdd1.Text;
            _param.OrgAddr2 = txtOrgAdd2.Text;
            _param.OrgCityCode = 0;
            _param.OrgCity = txtOrgCity.Text;
            // flight no
            //svat
            _param.SenRefNotes = SenRefNotes;
            _param.PayNo = Convert.ToDecimal(((txtPayNo.Text == "" || txtPayNo.Text == "0") ? 0 : Convert.ToDecimal(txtPayNo.Text)));
            _param.PayDate = DateTimeValidator.GetAppDateformat( dtePayment.Value); // pay date
            _param.PayAccount = ((InvDutyClrPayAccountDomainView)cmbPayAccount.SelectedItem).AccountCode;/// need to pick
            _param.PayRefno = txtPayRef.Text;
            _param.StationID = StationID;
            _param.GateWayID = GateWayID;
            _param.RouteID = RouteID;

            _param.ShipCntr = txtOrginCntr.Text;
            _param.DestiCntr = txtDestCntr.Text;
            _param.PaidBy = BilTo;
            _param.SellCurrRate = Convert.ToDecimal(txtSellConvR.Text);
            _param.LLCurrency = _baseCurrency; 
            _param.FCCurrency = _foriengCurrency; 
            _param.PayMode = (chkPayTerm.Checked == true) ? "CSH" : "CRD";
            _param.ShipValType = ShipValType.Trim();
        }


        private void ClearAirbillDetail()
        {
            agencyRpt = "";
            txtShipID.Text = "";
            txtCmpCode.Text = "";
            txtCmpN.Text = "";
            txtAgnCode.Text = "";
            txtAgnName.Text = "";
            txtOrginCntr.Text = "";
            txtOrginCntrN.Text = "";
            txtDestCntr.Text = "";
            txtDestCntrN.Text = "";
            txtOrgGateway.Text = "";
            txtDestGateway.Text = "";
            txtStation.Text = "";
            txtPayBy.Text = "";
            txtAccount.Text = "";
            dteTransDate.Value = DateTime.Now.Date;
            txtMAWB.Text = "";
            txtConsID.Text = "";
            txtBayanNo.Text = "";
            txtDesc.Text = "";
            txtFCurr.Text = "";
            txtShipValLC.Text = "";
            txtShipValFC.Text = "";
            txtSellConvR.Text = "";
            txtClrRate.Text = "";
            ShipType = "";
            BilTo = "";
            SenRefNotes = "";
            StationID = "";
            GateWayID = "";
            RouteID = "";
            ShipValCate = 0;
            ShipValType = "";
            txtJobNo.Text = "";
            _AccIcpc = "";
            _DocFixOrgCode = 0;
            hasIcpcAccountDet = 0;
            txtPayRef.Text = "";
            txtConsoleID.Text = "";
            if (cmbInvDocumet.SelectedItem != null)
            {
                cmbInvDocumet.SelectedIndex = -1;
            }

            if (cmbPayDocument.SelectedItem != null)
            {
                cmbPayDocument.SelectedIndex = -1;
            }
            txtDoctypeCode.Text = "";
            txtPayDocCode.Text = "";
            _jobtransact = null;
        }
        private void ClearOrgDetail()
        {
            txtOrgAdd1.Text = "";
            txtOrgAdd2.Text = "";
            txtOrgCity.Text = "";
            txtOrgName.Text = "";
            txtOrgTaxReg.Text = "";
            txtOrgTel.Text = "";
            txtStation.Text = "";
            txtRemark.Text = "";
            txtOrgCountry.Text = "";
            txtOrgCountryN.Text = "";
            // txtPayTerm.Text = "";
            chkPayTerm.Checked = true  ;
            chkOneTime.Enabled = true ;
            txtOrgCode.Text = "";
           if( cmbStation.SelectedItem !=null )
            {
                cmbStation.SelectedIndex = -1;
            }
            BranchCode = "";
        }
        private void ClearCharges()
        {
            grvDutyCharge.DataSource = null;
           
        }
        private void ClearInvDetail()
        {
            txtAmtPayLC.Text = "0";
            txtAmtPayFC.Text = "0";
            txtAmtInvFC.Text = "0";
            txtAmtInvLC.Text = "0";
            txtInvNo.Text = "";
            txtPayNo.Text = "";
            dteInvoiced.Value = DateTime.Now.Date;
            dtePayment.Value = DateTime.Now.Date;
            InvStatus = InvoiceProcess.NEW;
            FormState = FormStateEnum.Initial;
            btnInvoice.Enabled = true;
            btnPayment.Enabled = true ;
            _baseCurrency = "";
            _foriengCurrency = "";

            if (cmbPayAccount.SelectedItem != null)
            {
                cmbPayAccount.SelectedIndex = -1;
            }
            
        }


        private bool HasCharge()
        {
            bool _hasval = false;
           
            foreach (InvDutyChargeDomainView item in _charge)
            {
                if(item.PayLC >0 || item.SellLC >0)
                {
                    _hasval = true;
                }
            }

            return _hasval;
        }















        #endregion

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtShipID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPayment_Click_1(object sender, EventArgs e)
        {

        }
    }
}
