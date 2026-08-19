using Express.UI.Common.Helpers;
using Express.UI.Filters.View;
using Express.UI.Helpers;
using Express.UI.Invoice.InvoiceHelper.FrightInvoiceProcess;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Filters;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using FedexExpress.View.Domain.Pricing;
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
    public partial class InvFrtInvPorcessPrint : Form
    {
        private IList<AgencyDomainViewcs> _agencies;
        private IList<InvProcessModeDomainView> _invmodes;
        private IFrtProcessLoad _frtLoad;
        private IFrtProcess _frtProcess;
        private IList<InvFrtPrintProcessDomainView> _invdetails;
        private IList<InvoiceTypeCategoryDomainView> _frtdoctypes;
        private int MenuCode = 0;
        private int AgencyCode = 0;
        private InvFrtInvPrintTypes _PrintTypes;
        private InvFrtShipTypes _ShipType;
        
        private string AgencyN;
        public InvFrtInvPorcessPrint()
        {
            InitializeComponent();
            _frtLoad = new InvFrtPocessLoad();
            _frtProcess = new InvFrtPorcess();
            this.cmb_agency.SelectedValueChanged -= new EventHandler(cmb_agency_SelectedValueChanged);
            this.cmbInvModes.SelectedValueChanged -= new EventHandler(cmbInvModes_SelectedValueChanged);
            _invdetails = new List<InvFrtPrintProcessDomainView>();
            MenuCode = LoginInfoView.MENUCODE;
            rdCustomer.Checked = true;
            rdOutbound.Checked = true;
            rdPrintInvoices.Checked = true;
            rdNumberRange.Checked = true;
            chkAWB.Checked = true;
           
            gridFrtPendingInv.AutoGenerateColumns = false;
             frtPrintBgWork.RunWorkerAsync();
        }

        private void frtPrintBgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            _agencies = _frtLoad.GetAgencyDetail(LoginInfoView.USERID, LoginInfoView.MODULEID, MenuCode);
            _invmodes = _frtLoad.GetInvProcessMode();
            
        }

        private void frtPrintBgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyID";

            cmb_agency.DataSource = _agencies;
            if(_agencies!=null && _agencies.Count >0)
            {
                cmb_agency.SelectedIndex = -1;
            }            
            this.cmb_agency.SelectedValueChanged += new EventHandler(cmb_agency_SelectedValueChanged);

            cmbInvModes.DisplayMember = "InvModeN";
            cmbInvModes.ValueMember = "InvMode";
            cmbInvModes.DataSource = _invmodes;
            ResetCmbInvoiceModes();

            this.cmbInvModes.SelectedValueChanged += new EventHandler(cmbInvModes_SelectedValueChanged);

        }

        private void cmb_agency_SelectedValueChanged(object sender, EventArgs e)
        {
            var agencyValue = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            if (agencyValue != null)
            {
                txt_company.Text = agencyValue.CompName;
                AgencyN = agencyValue.AgncyName;
                AgencyCode = agencyValue.AgncyCode;
                _frtdoctypes = _frtLoad.DocumentTypes(LoginInfoView.COMPANYID, AgencyCode);
                cmbFrtDocTypes.DisplayMember = "InvoiceTypeN";
                cmbFrtDocTypes.ValueMember = "InvoiceType";
                cmbFrtDocTypes.DataSource = _frtdoctypes;
                if (_frtdoctypes != null && _frtdoctypes.Count > 0)
                {
                    cmbFrtDocTypes.SelectedIndex = -1;
                }
                ClearFrtGrid();
            }
        }

        private void cmbInvModes_SelectedValueChanged(object sender, EventArgs e)
        {
            var _invmode = (InvProcessModeDomainView)cmbInvModes.SelectedItem;
            if(_invmode !=null )
            {
                ClearFrtGrid();
            }
        }

        private void btnOrgSearch_Click(object sender, EventArgs e)
        {
            var _search = new OrgSearchValueDomainView
            {
                OrgName = txtOrgName.Text
            };
            new CustomerSearch(ref _search).ShowDialog();

            if (_search.OrgCode != 0)
            {
                SetDutyOrgnization(_search);
            }           
        }


        private void SetDutyOrgnization(OrgSearchValueDomainView _search)
        {
            txtOrgCode.Text = _search.OrgCode.ToString();
            txtOrgName.Text = _search.OrgName;
            ClearFrtGrid();
        }

        private void rdCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if(rdCustomer.Checked )
            {
                btnOrgSearch.Enabled = true;
                cmbInvModes.Enabled = false;               
            }
            ClearFrtGrid();
        }

        private void rdPeriodic_CheckedChanged(object sender, EventArgs e)
        {
            if(rdPeriodic.Checked )
            {
                txtOrgCode.Text = "";
                txtOrgName.Text = "";
                btnOrgSearch.Enabled = false ;
                cmbInvModes.Enabled = true ;
            }
            ClearFrtGrid();
        }

        private void rdNumberRange_CheckedChanged(object sender, EventArgs e)
        {
            if(rdNumberRange.Checked )
            {
                txtInvFrom.Visible = true;
                txtInvTo.Visible = true;
                txtInvFrom.Text = "";
                txtInvTo.Text = "";
                dtInvFrom.Visible = false;
                dtInvTo.Visible = false;
               
            }
            ClearFrtGrid();
        }

        private void rdDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDateRange.Checked)
            {
                txtInvFrom.Visible = false ;
                txtInvTo.Visible = false ;
                txtInvFrom.Text = "";
                txtInvTo.Text = "";
                dtInvFrom.Visible = true ;
                dtInvTo.Visible = true ;

            }
            ClearFrtGrid();
        }

        private void podDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRetrive_Click(object sender, EventArgs e)
        {
            RetriveDetail();
        }

        private void RetriveDetail()
        {
            var _para = new InvFrtPrintProcessParaDomainView()
            {
                CompanyID = LoginInfoView.COMPANYID,
                AgencyCode = AgencyCode,
                AwbNumber = (chkAWB.Checked == true) ? "" : txtAwbnumber.Text,
                AllAwb = (chkAWB.Checked == true) ? 0 : 1,
                DteUpto = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                InvMode = (cmbInvModes.SelectedItem != null) ? ((InvProcessModeDomainView)cmbInvModes.SelectedItem).InvMode : "",
                IsCutormer = (rdCustomer.Checked == true) ? 1 : 0,
                IsPeriodic = (rdPeriodic.Checked == true) ? 1 : 0,
                UserID = LoginInfoView.USERID,
                DocType = (cmbFrtDocTypes.SelectedItem != null) ? ((InvoiceTypeCategoryDomainView)cmbFrtDocTypes.SelectedItem).InvoiceType : "",
                OrgCode = (rdCustomer.Checked == true) ? (txtOrgCode.Text == "") ? 0 : Convert.ToInt32(txtOrgCode.Text) : 0


            };
            ClearFrtGrid();
            _invdetails = _frtLoad.GetFrtBillingDetail(_para, _ShipType);
            gridFrtPendingInv.DataSource = null;
            gridFrtPendingInv.DataSource = _invdetails;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MessageNotification.MessageBoxConfirm("Are sure want to process ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            {
                var custCode = (txtOrgCode.Text == null || txtOrgCode.Text == "") ? "0" : txtOrgCode.Text;
                var _para = new InvFrtPrintProcessParaDomainView()
                {
                    CompanyID = LoginInfoView.COMPANYID,
                    AgencyCode = AgencyCode,
                    AwbNumber = (chkAWB.Checked == true) ? "" : txtAwbnumber.Text,
                    AllAwb = (chkAWB.Checked == true) ? 0 : 1,
                    DteUpto = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                    InvMode = (cmbInvModes.SelectedItem != null) ? ((InvProcessModeDomainView)cmbInvModes.SelectedItem).InvMode : "",
                    IsCutormer = (rdCustomer.Checked == true) ? 1 : 0,
                    IsPeriodic = (rdPeriodic.Checked == true) ? 1 : 0,
                    DocType = (cmbFrtDocTypes.SelectedItem != null) ? ((InvoiceTypeCategoryDomainView)cmbFrtDocTypes.SelectedItem).InvoiceType : "",
                    DocDate = dteInvoiceDate.Value.Date.Year.ToString() + "-" + dteInvoiceDate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteInvoiceDate.Value.Day.ToString().PadLeft(2, '0'),
                    UserID = LoginInfoView.USERID,
                    OrgCode = (rdCustomer.Checked == true) ? Convert.ToInt32(custCode) : 0

                };

                var responce = _frtProcess.InvBulkProcess(_para);
                if(responce !=null)
                {
                    if (responce.IsSuccess)
                    {
                        txtInvFrom.Text = responce.ReturnValue.ToString();
                        txtInvTo.Text = responce.ReturnValue2.ToString();
                        MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                        RetriveDetail();
                    }
                    else
                    {
                        ErrorProcess(responce.StrMessage );
                    }
                }
                else
                {                   
                    ErrorProcess("Error in Invoice proccessing");
                }
                
            }
        }

        private void ErrorProcess(string msg)
        {
            txtInvFrom.Text = "0";
            txtInvTo.Text = "0";
            dtInvFrom.Value = DateTime.Now.Date;
            dtInvTo.Value = DateTime.Now.Date;
            MessageNotification.MessageBoxError(msg, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var _para = new InvFrtPrintProcessParaDomainView()
            {
                CompanyID = LoginInfoView.COMPANYID,
                AgencyCode = AgencyCode,
                CompanyN = txt_company.Text,
                AgencyN = AgencyN,
                OrgName = txt_company.Text,
                AwbNumber = (chkAWB.Checked == true) ? "" : txtAwbnumber.Text,
                AllAwb = (chkAWB.Checked == true) ? 0 : 1,
                DteUpto = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                InvMode = (cmbInvModes.SelectedItem != null) ? ((InvProcessModeDomainView)cmbInvModes.SelectedItem).InvMode : "",
                IsCutormer = (rdCustomer.Checked == true) ? 1 : 0,
                IsPeriodic = (rdPeriodic.Checked == true) ? 1 : 0,
                DocType = (cmbFrtDocTypes.SelectedItem != null) ? ((InvoiceTypeCategoryDomainView)cmbFrtDocTypes.SelectedItem).InvoiceType : "",
                DocDate = dteInvoiceDate.Value.Date.Year.ToString() + "-" + dteInvoiceDate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteInvoiceDate.Value.Day.ToString().PadLeft(2, '0'),
                UserID = LoginInfoView.USERID,
               

            };

            _frtProcess.PrintAirwabilDetail(_invdetails.Where(val=>val.InvoiceNo=="0").OrderBy(ex=>ex.TransDate ).ToList(), _para);

        }

        private void btnPrintRetrive_Click(object sender, EventArgs e)
        {
            var _para = new InvFrtPrintProcessParaDomainView()
            {
                CompanyID = LoginInfoView.COMPANYID,
                AgencyCode = AgencyCode,                
                DteUpto = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                IsInvDateRange = (rdDateRange.Checked) ? 1 : 0,
                IsInvNumberRange = (rdNumberRange.Checked )? 1 :0,
                AllAwb = (chkAWB.Checked == true) ? 0 : 1,
                DtFrom = dtInvFrom.Value.Date.Year.ToString() + "-" + dtInvFrom.Value.Month.ToString().PadLeft(2, '0') + "-" + dtInvFrom.Value.Day.ToString().PadLeft(2, '0'),
                DtTo = dtInvTo.Value.Date.Year.ToString() + "-" + dtInvTo.Value.Month.ToString().PadLeft(2, '0') + "-" + dtInvTo.Value.Day.ToString().PadLeft(2, '0'),
                FromInvNo =  txtInvFrom.Text ,
                ToInvNo = txtInvTo.Text,
                AwbNumber = (chkAWB.Checked == true) ? "" : txtAwbnumber.Text,                
                DocType = (cmbFrtDocTypes.SelectedItem != null) ? ((InvoiceTypeCategoryDomainView)cmbFrtDocTypes.SelectedItem).InvoiceType : "",               

            };
            ClearFrtGrid();
             _invdetails=  _frtLoad.GetFrtInvoiceDetail(_para, _ShipType);
            gridFrtPendingInv.DataSource = null;
            gridFrtPendingInv.DataSource = _invdetails;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            var _para = new InvFrtPrintProcessParaDomainView()
            {
                CompanyID = LoginInfoView.COMPANYID,
                AgencyCode = AgencyCode,
                AgencyN = AgencyN,
                DteUpto = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                IsInvDateRange = (rdDateRange.Checked) ? 1 : 0,
                IsInvNumberRange = (rdNumberRange.Checked) ? 1 : 0,
                AllAwb = (chkAWB.Checked == true) ? 0 : 1,
                DtFrom = dtInvFrom.Value.Date.Year.ToString() + "-" + dtInvFrom.Value.Month.ToString().PadLeft(2, '0') + "-" + dtInvFrom.Value.Day.ToString().PadLeft(2, '0'),
                DtTo = dtInvTo.Value.Date.Year.ToString() + "-" + dtInvTo.Value.Month.ToString().PadLeft(2, '0') + "-" + dtInvTo.Value.Day.ToString().PadLeft(2, '0'),
                FromInvNo = txtInvFrom.Text,
                ToInvNo = txtInvTo.Text,
                AwbNumber = (chkAWB.Checked == true) ? "" : txtAwbnumber.Text,
                DocType = (cmbFrtDocTypes.SelectedItem != null) ? ((InvoiceTypeCategoryDomainView)cmbFrtDocTypes.SelectedItem).InvoiceType : "",

            };
            _frtProcess.PrintFrtInvoicePreview(_para, _PrintTypes);
        }

        private void btnPrinttoPrint_Click(object sender, EventArgs e)
        {
            if (MessageNotification.MessageBoxConfirm("Are sure want to direct print report without preview ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            {
                var _para = new InvFrtPrintProcessParaDomainView()
                {
                    CompanyID = LoginInfoView.COMPANYID,
                    AgencyCode = AgencyCode,
                    AgencyN = AgencyN,
                    DteUpto = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                    IsInvDateRange = (rdDateRange.Checked) ? 1 : 0,
                    IsInvNumberRange = (rdNumberRange.Checked) ? 1 : 0,
                    AllAwb = (chkAWB.Checked == true) ? 0 : 1,
                    DtFrom = dtInvFrom.Value.Date.Year.ToString() + "-" + dtInvFrom.Value.Month.ToString().PadLeft(2, '0') + "-" + dtInvFrom.Value.Day.ToString().PadLeft(2, '0'),
                    DtTo = dtInvTo.Value.Date.Year.ToString() + "-" + dtInvTo.Value.Month.ToString().PadLeft(2, '0') + "-" + dtInvTo.Value.Day.ToString().PadLeft(2, '0'),
                    FromInvNo = txtInvFrom.Text,
                    ToInvNo = txtInvTo.Text,
                    AwbNumber = (chkAWB.Checked == true) ? "" : txtAwbnumber.Text,
                    DocType = (cmbFrtDocTypes.SelectedItem != null) ? ((InvoiceTypeCategoryDomainView)cmbFrtDocTypes.SelectedItem).InvoiceType : "",
                    IsDirectPrint = true

                };
                _frtProcess.PrintFrtInvoicePreview(_para, _PrintTypes);
            }
        }

        private void rdPrintInvoices_CheckedChanged(object sender, EventArgs e)
        {
            if(rdPrintInvoices.Checked)
            {
                _PrintTypes = InvFrtInvPrintTypes.INVOICE;
            }
        }

        private void rdPrintInvoiceList_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPrintInvoiceList.Checked)
            {
                _PrintTypes = InvFrtInvPrintTypes.INVOICE_LIST;
            }
        }

        private void rdAwbList_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAwbList.Checked)
            {
                _PrintTypes = InvFrtInvPrintTypes.AWB_DETAIL;
            }
        }

        private void rdOutbound_CheckedChanged(object sender, EventArgs e)
        {
            if(rdOutbound.Checked )
            {
                _ShipType = InvFrtShipTypes.OUTBOUND;
            }
            ClearFrtGrid();
        }

        private void rdInbound_CheckedChanged(object sender, EventArgs e)
        {
            if(rdInbound.Checked)
            {
                _ShipType = InvFrtShipTypes.INBOUND;
            }
            ClearFrtGrid();
        }

        private void rdTparty_CheckedChanged(object sender, EventArgs e)
        {
            if(rdTparty.Checked)
            {
                _ShipType = InvFrtShipTypes.TPARTY;
            }
            ClearFrtGrid();
        }

        private void rdDomestic_CheckedChanged(object sender, EventArgs e)
        {
            if(rdDomestic.Checked)
            {
                _ShipType = InvFrtShipTypes.DOMESTIC;
            }
            ClearFrtGrid();
        }

        private void ClearFrtGrid()
        {
            gridFrtPendingInv.DataSource = null;
            if(_invdetails !=null)
            {
                _invdetails.Clear();
            }
        }

        private void dteUptodate_ValueChanged(object sender, EventArgs e)
        {
            ClearFrtGrid();
        }

        private void dtInvFrom_ValueChanged(object sender, EventArgs e)
        {
            ClearFrtGrid();
        }

        private void dtInvTo_ValueChanged(object sender, EventArgs e)
        {
            ClearFrtGrid();
        }

        private void txtAwbnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void chkAWB_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAWB.Checked )
            {
                txtAwbnumber.Enabled = false  ;
            }
            else
            {
                txtAwbnumber.Enabled = true ;
            }
            txtAwbnumber.Text = "";
           
        }

        private void btnProcessClear_Click(object sender, EventArgs e)
        {
            ClearFrtGrid();
            dteUptodate.Value = DateTime.Now;
            rdCustomer.Checked = true;
            dteInvoiceDate.Value = DateTime.Now;
            ResetCmbInvoiceModes();
            txtOrgCode.Text = "";
            txtOrgName.Text = "";
        }

        private void ResetCmbInvoiceModes()
        {
            if (_invmodes != null && _invmodes.Count > 0)
            {
                cmbInvModes.SelectedIndex = -1;
            }
        }

        private void btnPrintingClear_Click(object sender, EventArgs e)
        {
            dtInvFrom.Value = DateTime.Now;
            dtInvTo.Value = DateTime.Now;
            txtInvFrom.Text = "";
            txtInvTo.Text = "";
            rdNumberRange.Checked = true;
            chkAWB.Checked = true;
            txtAwbnumber.Text = "";
            ClearFrtGrid();
        }
    }
}
