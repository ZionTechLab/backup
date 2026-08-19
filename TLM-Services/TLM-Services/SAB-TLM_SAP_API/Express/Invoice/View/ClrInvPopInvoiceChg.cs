using Express.Domain.Message;
using Express.Interfaces.Invoice;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Invoice;
using Express.UI.Factory.Operations;
using Express.UI.Filters.View;
using Express.UI.Helpers;
using Express.View.Domain.Filters;
using Express.View.Domain.Invoice;
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

namespace Express.UI.Invoice.View
{
    public partial class ClrInvPopInvoiceChg : Form
    {
        private readonly IClrInvOpsInvoiceChg _extProvider;
        private ClrInvDomainView _clrinvoice = null;
        private List<ClrInvDomainView> _tempClrInvoice;
        private OpsConsAWBDomainView _manifestAwb = null;
        private readonly ClrInvOrgnPopParam _param;
        //public ClrInvPopInvoiceChg()
        //{
        //    InitializeComponent();
        //    if (_extProvider == null)
        //    {
        //        _extProvider = InvoiceUIFactory.GetService<IClrInvOpsInvoiceChg>();
        //    }

        //}

        public ClrInvPopInvoiceChg(ClrInvDomainView _clrinvoice ,ref List<ClrInvDomainView> _tempClrInvoice, AgencyDomainViewcs _agency)
        {
            InitializeComponent();
            if (_extProvider == null)
            {
                _extProvider = InvoiceUIFactory.GetService<IClrInvOpsInvoiceChg>();
            }
            _param = new ClrInvOrgnPopParam();
            _manifestAwb = new OpsConsAWBDomainView();
            this._clrinvoice = _clrinvoice;
            this._tempClrInvoice = _tempClrInvoice;
           // chkCreAllow.Checked = (_clrinvoice.PayMode.Trim() == "CSH") ? false : true; 
            _param.CompanyID = _agency.CompID;
            _param.AgencyCode = _agency.AgncyCode;
            _param.UserID = LoginInfoView.USERID;
            _param.InvoiceNo = Convert.ToInt32(_clrinvoice.InvNo);
            _param.IscrdAllow = "";
             txtInvoiceNo.Text = Convert.ToString(_clrinvoice.InvNo);

             if(LoginInfoView.REPORTPATH =="KSA")
            {
                chkCreAllow.Enabled = false;
            }
             else
            {

                chkCreAllow.Enabled = true;
                chkCreAllow.Checked = (_clrinvoice.PayMode.Trim() == "CSH") ? false : true;
            }

            }

        private void ClrInvPrinting_InvoiceChn_Load(object sender, EventArgs e)
        {
            try
            {
                this.displayData();
                ////_manifestAwb = _extProvider.GetOpsConsAWB(oInvoiceDTAXDomainView.ConsId.ToString(), oInvoiceDTAXDomainView.AgncyCode, oInvoiceDTAXDomainView.CMPY).FirstOrDefault<OpsConsAWBDomainView>();
                //oOpsConsAWBDomainView = _extProvider.GetOpsConsAWB("17699124222".ToString(), oInvoiceDTAXDomainView.AgncyCode, oInvoiceDTAXDomainView.CMPY).FirstOrDefault<OpsConsAWBDomainView>();
                ////if(_manifestAwb != null)
                ////{
                ////    if(_manifestAwb.BillDTaxCreditY=="Y"){ chkCreAllow.Checked = true; }
                ////    else { chkCreAllow.Checked = false; }
                ////}
              
            }
            catch(Exception ex)
            {
                MessageNotification.MessageBoxError("Loading Error", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _manifestAwb.BillOrgCode = _clrinvoice.OrgCode;
            _manifestAwb.RecCompany = _clrinvoice.OrgName;


            var search = new OrgSearchValueDomainView
            {
                OrgCode = _clrinvoice.OrgCode,
                OrgName = _clrinvoice.OrgName
            };

            if (_manifestAwb == null) { return; }
            new CustomerSearch(ref search).ShowDialog();
            if (search.OrgCode == 0)
            {
                txtCode.Text = _manifestAwb.BillOrgCode.ToString();
                txtName.Text = _manifestAwb.RecCompany;
            }
            else
            {
                txtCode.Text = search.OrgCode.ToString();
                txtName.Text = search.OrgName;
            }

            IsCustomerCreditAllow(Convert.ToString(search.OrgCode));


        }

        private void chkCreAllow_CheckedChanged(object sender, EventArgs e)
        {
           

            if (chkCreAllow.Checked) {
                _param.IscrdAllow = "Y";
            }
            else {
                _param.IscrdAllow = "";
            }
        }

        private void displayData()
        {
            txtCode.Text = _clrinvoice.OrgCode.ToString();
            txtName.Text = _clrinvoice.OrgName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var pVal = (_param.IscrdAllow == "Y") ? "CRD" : "CSH";
            //  var Taxr = (_clrinvoice.TaxRegNo == null) ? "" : _clrinvoice.TaxRegNo;

            //if (_clrinvoice.OrgCode == Convert.ToInt32(txtCode.Text) && _clrinvoice.PayMode.Trim() == pVal)
            //{
            //    MessageNotification.MessageBoxOK("Please change data to update", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
            //    return;
            //}
            _param.ExpressID = _clrinvoice.ExpressID.Trim();
            _param.OrgCode = Convert.ToInt32(txtCode.Text);
            _param.OrgName = txtName.Text;
           _param.TaxRegNo = TaxRegNo.Text;

            ResponseMessage responce = new ResponseMessage();
            try
            {               

                responce = _extProvider.UpdateDutyInvoiceOrginization(_param);
                if (responce.IsSuccess)
                {
                    _tempClrInvoice.Where(ex => ex.InvNo == Convert.ToInt32(txtInvoiceNo.Text)).FirstOrDefault().OrgCode = _param.OrgCode;
                    _tempClrInvoice.Where(ex => ex.InvNo == Convert.ToInt32(txtInvoiceNo.Text)).FirstOrDefault().OrgName  = _param.OrgName ;
                    _tempClrInvoice.Where(ex => ex.InvNo == Convert.ToInt32(txtInvoiceNo.Text)).FirstOrDefault().PayMode = pVal;
                    _tempClrInvoice.Where(ex => ex.InvNo == Convert.ToInt32(txtInvoiceNo.Text)).FirstOrDefault().TaxRegNo= _param.TaxRegNo;
                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                }
                else
                {
                    MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }


        }

        private void IsCustomerCreditAllow(string _orgCode)
        {
            try
            {
                var crdDetai= _extProvider.GetOrgnizCreditDetail(_param.CompanyID, _orgCode);
                if(crdDetai !=null )
                {
                    chkCreAllow.Checked = (crdDetai.IsDutyCredit == "Y") ? true : false;
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
