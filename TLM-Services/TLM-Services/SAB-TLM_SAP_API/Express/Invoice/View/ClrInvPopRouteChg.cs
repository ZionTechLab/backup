using Express.Domain.Message;
using Express.Interfaces.Invoice;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Invoice;
using Express.UI.Factory.Operations;
using Express.UI.Helpers;
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
    public partial class ClrInvPopRouteChg : Form
    {
        private readonly IClrInvOpsRouteChg _extProvider;
        private readonly ClrInvRoutePopParam _param;
        private List<ClrInvDomainView> _tempClrInvoice;
        private ClrInvDomainView _clrinvoice = null;
        List<RefSvcRootsDomainView> listRoots = null;      

        public ClrInvPopRouteChg(ClrInvDomainView _clrinvoice , ref List<ClrInvDomainView> _tempClrInvoice , IList<RefSvcRootsDomainView> _listRoots , AgencyDomainViewcs _agency)
        {
            InitializeComponent();
            if (_extProvider == null)
            {
                _extProvider = InvoiceUIFactory.GetService<IClrInvOpsRouteChg>();
            }
            this._clrinvoice = _clrinvoice;
            this._tempClrInvoice = _tempClrInvoice;
            _param = new ClrInvRoutePopParam();
            listRoots = _listRoots.ToList();
            txtInvoiceNo.Text = _clrinvoice.InvNo.ToString();
            _param.CompanyID = _agency.CompID;
            _param.AgencyCode = _agency.AgncyCode;
            _param.UserID = LoginInfoView.USERID;
            _param.InvoiceNo = Convert.ToInt32( _clrinvoice.InvNo);
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ClrInvPrinting_RouteChn_Load(object sender, EventArgs e)
        {
           // listRoots = _extProvider.GetRefSvcRoots(oInvoiceDTAXDomainView.CMPY).ToList<RefSvcRootsDomainView>();
            cmbRoute.DataSource = listRoots;
            cmbRoute.SelectedItem = listRoots.Find(c => c.SvcRootID == _clrinvoice.RouteID);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _param.ExpressID = _clrinvoice.ExpressID.Trim();
            if(cmbRoute.SelectedItem ==null )
            {
                MessageNotification.MessageBoxError("Please select route", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            ResponseMessage responce = new ResponseMessage();
            try
            {
                var _root = ((RefSvcRootsDomainView)cmbRoute.SelectedItem);
                _param.RouteID = _root.SvcRootID;
                
                responce = _extProvider.UpdateDutyInvoiceRoute(_param);
                if (responce.IsSuccess)
                {
                    _tempClrInvoice.Where(ex => ex.InvNo == Convert.ToInt32(txtInvoiceNo.Text)).FirstOrDefault().RouteID = _param.RouteID;
                    _tempClrInvoice.Where(ex => ex.InvNo == Convert.ToInt32(txtInvoiceNo.Text)).FirstOrDefault().RouteN  = _root.SvcRootName ;
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
    }
}
