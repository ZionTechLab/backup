using Express.UI.Common.Helpers;
using Express.UI.Helpers;
using Express.UI.Invoice.InvoiceHelper.PickupInvioceProcess;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
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
    public partial class InvPickupInvoice : Form
    {
        private readonly IPickInvoiceProcess _process;
        private readonly IPickInvoicePreview _preview;
        private IList<AgencyDomainViewcs> _agencies;
        private InvPickProcessDomainView _properties;

        private int MenuCode = 0;
        private int CompanyID = 0;
        private int AgencyCode = 0;
        private int BillOrgCode = 0;
        public InvPickupInvoice()
        {
            InitializeComponent();
            _process = PickInvoiceLocator.GetService<IPickInvoiceProcess>();
            _preview = PickInvoiceLocator.GetService<IPickInvoicePreview>();
            MenuCode = LoginInfoView.MENUCODE;
            dteInvDate.Value = DateTime.Now;
            SetIntialValue();
            this.cmb_agency.SelectedValueChanged -= new EventHandler(cmb_agency_SelectedValueChanged);
            this.cmbDocTypes.SelectedValueChanged -= new EventHandler(cmbDocTypes_SelectedValueChanged);
            bgPickupProcess.RunWorkerAsync();
        }

        private void InvPickupInvoice_Load(object sender, EventArgs e)
        {

        }

        private void btnPendingRetrive_Click(object sender, EventArgs e)
        {
            RefreshRetriveValue();
        }

        private void SetIntialValue()
        {

            txtBillPendingAwb.Text = "0";
            txtBillPendingWgt.Text = "0.0";

            txtBilledAwb.Text = "0";
            txtBilledWgt.Text = "0.0";
            txtBilledAmt.Text = "0.0";
            txtInvPendingFC.Text = "0.0";

            txtConvertRate.Text = "0.0";
            CleareBillingOrg();
            BillOrgCode = 0;
            txtInvAwb.Text = "0";
            txtInvoiceWgt.Text = "0.0";
            txtInvAmtFc.Text = "0.0";
            txtInvAmtLc.Text = "0.0";
        }

        private void RefreshRetriveValue()
        {
            var para = new InvPickProcessPramDomainView
            {
                //CompanyID = CompanyID,
                //AgencyID = AgencyCode,
                //BillOrgCode = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? 0 : ((InvDelDocTypes)cmbDocTypes.SelectedItem).BillOrgCode,
                //DocType = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? "" : ((InvDelDocTypes)cmbDocTypes.SelectedItem).DocType.Trim(),
                //Uptodate = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),

                CompanyID = 201,
                AgencyID = 20101,
                BillOrgCode = 3000001,
                DocType = "XPKUOB",
                Uptodate = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),

            };
            _properties = _preview.GetPickSummeryDetail(para);
           
            SetIntialInvoiceDetail();
            if (_properties != null)
            {
               
                txtBillPendingAwb.Text = Convert.ToString(_properties.CountPendingAwb);
                txtBillPendingWgt.Text = Convert.ToString(_properties.CountPendingWgt);

                txtBilledAwb.Text = Convert.ToString(_properties.CountBillAwb);
                txtBilledWgt.Text = Convert.ToString(_properties.CountBillWgt);
                txtBilledAmt.Text = Convert.ToString(_properties.CountBillAmt);
                txtInvPendingFC.Text = _properties.SellCurrencyFC;
                txtLcCurr.Text = _properties.SellCurrencyLC;
                txtFcCurr.Text = _properties.SellCurrencyFC;
                txtConvertRate.Text = Convert.ToString(_properties.ExtRate);
                ///txtBillto.Text = _properties.BillParty;
                SetBillOrg(_properties);
                BillOrgCode = _properties.BillOrgCode;
            }
            else
            {
                MessageNotification.MessageBoxError("Can not find data to refresh", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                txtBillPendingAwb.Text = "0";
                txtBillPendingWgt.Text = "0";

                txtBilledAwb.Text = "0";
                txtBilledWgt.Text = "0";
                txtBilledAmt.Text = "0";
                txtInvPendingFC.Text = "";
                CleareBillingOrg();
                BillOrgCode = 0;

            }
        }

        private void SetIntialInvoiceDetail()
        {
            txtInvAwb.Text = "0";
           // txtInvNo.Text = "";
            txtInvoiceWgt.Text = "0.0";
            txtInvAmtFc.Text = "0.0";
            txtInvAmtLc.Text = "0.0";

            txtConvertRate.Text = "0.0";
            txtLcCurr.Text = "";
            txtFcCurr.Text = "";

            txtOrgCode.Text = "";
            txtOrgName.Text = "";
            txtOrgAdd1.Text = "";
            txtOrgAdd2.Text = "";
            txtOrgCity.Text = "";
            txtOrgCountry.Text = "";
            txtBillPendingAwb.Text = "0";
            txtBillPendingWgt.Text = "0.0";

            dteInvDate.Value = DateTime.Now.Date;
        }

        private void CleareBillingOrg()
        {
            txtOrgCode.Text = "";
            txtOrgAdd1.Text = "";
            txtOrgAdd2.Text = "";
            txtOrgCity.Text = "";
            txtOrgCountry.Text = "";
            txtOrgName.Text = "";
        }

        private void SetBillOrg(InvPickProcessDomainView _bill)
        {
            txtOrgCode.Text = Convert.ToString(_bill.BillOrgCode);
            txtOrgAdd1.Text = _bill.BillOrgAdd1;
            txtOrgAdd2.Text = _bill.BillOrgAdd2;
            txtOrgCity.Text = _bill.BillOrgCity;
            txtOrgCountry.Text = _bill.BillOrgCountry;
            txtOrgName.Text = _bill.BillOrgName;
        }

        private void btnPendingBillProcess_Click(object sender, EventArgs e)
        {
            if (!MessageNotification.MessageBoxConfirm("Are you sure you want to process ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            {
                return;
            }

            txtBilledAwb.Text = "0";
            txtBilledAmt.Text = "0";
            txtBilledWgt.Text = "0";

            var para = new InvPickProcessPramDomainView
            {
                AgencyID = AgencyCode,
                CompanyID = CompanyID,
                Uptodate = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                BillOrgCode = BillOrgCode,
                DocType =  ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? "" : ((InvDelDocTypes)cmbDocTypes.SelectedItem).DocType.Trim(),
                
                UserID = LoginInfoView.USERID,
                ToBillAwbCount = Convert.ToInt32(txtBillPendingAwb.Text)
            };

            var responce = _process.PickBillingProcess(para);
            if (responce.IsSuccess)
            {
                MessageNotification.MessageBoxOK("Successfully process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
                RefreshRetriveValue();
            }
            else
            {
                MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void btnInvDetProcess_Click(object sender, EventArgs e)
        {
            if (!MessageNotification.MessageBoxConfirm("Are you sure you want to process ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            {
                return;
            }
            var dDate = dteInvDate.Value;
            if (DateTime.Now.Date < dteInvDate.Value.Date)
            {
                MessageNotification.MessageBoxError("Invoice Date is incorrect", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            var para = new InvPickProcessPramDomainView
            {
                AgencyID = AgencyCode,
                CompanyID = CompanyID,
                Uptodate = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                DocDate = dDate.Date.Year.ToString() + "-" + dDate.Month.ToString().PadLeft(2, '0') + "-" + dDate.Day.ToString().PadLeft(2, '0'),
                BillOrgCode = BillOrgCode,
                DocType =  ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? "" : ((InvDelDocTypes)cmbDocTypes.SelectedItem).DocType.Trim(),
                UserID = LoginInfoView.USERID,
                ToBillAwbCount = Convert.ToInt32(txtBilledAwb.Text)
            };

            var responce = _process.PickInvProcess(para);
            if (responce.IsSuccess)
            {
                txtInvNo.Text = responce.ReturnValue;
                txtInvAwb.Text = txtBilledAwb.Text;
                txtInvoiceWgt.Text = txtBilledWgt.Text;
                txtInvAmtFc.Text = txtBilledAmt.Text;
                txtInvAmtLc.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtBilledAmt.Text) * Convert.ToDecimal(txtConvertRate.Text), 3));

                txtBilledAmt.Text = "0";
                txtBilledAwb.Text = "0";
                txtBilledWgt.Text = "0";
                MessageNotification.MessageBoxOK("Successfully process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
            }
            else
            {
                MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void cmb_agency_SelectedValueChanged(object sender, EventArgs e)
        {
            var agencyValue = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            SetIntialInvoiceDetail();
            if (agencyValue != null)
            {
                txtCompanyN.Text = agencyValue.CompName;
                CompanyID = agencyValue.CompID;
                AgencyCode = agencyValue.AgncyCode;
                GetPickupDoctypes(CompanyID, AgencyCode);
            }
        }

        private void GetPickupDoctypes(int companyID , int agecnyID)
        {
            cmbDocTypes.DisplayMember = "DocTypeN";
            cmbDocTypes.ValueMember = "DocType";

            var _doctypes = _preview.GetPickDocTypes(companyID, agecnyID, "PUP");
            cmbDocTypes.DataSource = _doctypes;
            if (_doctypes != null && _doctypes.Count > 0)
            {
                cmbDocTypes.SelectedIndex = -1;
            }
            this.cmbDocTypes.SelectedValueChanged += new EventHandler(cmbDocTypes_SelectedValueChanged);
        }

        private void bgPickupProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            _agencies = _preview.GetAgencyDetail(LoginInfoView.USERID, LoginInfoView.MODULEID, MenuCode);
        }

        private void bgPickupProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyID";

            cmb_agency.DataSource = _agencies;
            if (_agencies != null && _agencies.Count > 0)
            {
                cmb_agency.SelectedIndex = -1;
            }
            this.cmb_agency.SelectedValueChanged += new EventHandler(cmb_agency_SelectedValueChanged);

        }

        private void cmbDocTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            SetIntialInvoiceDetail();
        }

        private void btnPendingBillPrv_Click(object sender, EventArgs e)
        {
            var para = new InvPickProcessPramDomainView
            {
                CompanyID = CompanyID,
                AgencyID = AgencyCode,
                BillOrgCode = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? 0 : ((InvDelDocTypes)cmbDocTypes.SelectedItem).BillOrgCode,
                DocType = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? "" : ((InvDelDocTypes)cmbDocTypes.SelectedItem).DocType.Trim(),
                Uptodate = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
            };
            _preview.GetRptPickupBillingPending(para);
        }

        private void btnPendingInvPrv_Click(object sender, EventArgs e)
        {
            var para = new InvPickProcessPramDomainView
            {
                CompanyID = CompanyID,
                AgencyID = AgencyCode,
                BillOrgCode = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? 0 : ((InvDelDocTypes)cmbDocTypes.SelectedItem).BillOrgCode,
                DocType = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? "" : ((InvDelDocTypes)cmbDocTypes.SelectedItem).DocType.Trim(),
                Uptodate = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
            };
            _preview.GetRptPickupInvoicePending(para);
        }

        private void btnInvDetPrint_Click(object sender, EventArgs e)
        {
            var para = new InvPickProcessPramDomainView
            {
                CompanyID = CompanyID,
                AgencyID = AgencyCode,
                BillOrgCode = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? 0 : ((InvDelDocTypes)cmbDocTypes.SelectedItem).BillOrgCode,
                DocType = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? "" : ((InvDelDocTypes)cmbDocTypes.SelectedItem).DocType.Trim(),
                Uptodate = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                InvoiceNo = (txtInvNo.Text == "") ? "" : txtInvNo.Text ,
                CompanyN = txtCompanyN.Text
            };

            if(chkInvDetAwbList.Checked )
            {
                _preview.GetRptPickupDetail(para);
            }
            else
            {
                _preview.GetRptPickupSummary(para);
            }
        }

        private void txtInvNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var dDate = DateTime.Now.Date;
                var para = new InvPickProcessPramDomainView
                {
                    AgencyID = AgencyCode,
                    CompanyID = CompanyID,
                    InvoiceNo = txtInvNo.Text,
                    Uptodate = dteUptodate.Value.Date.Year.ToString() + "-" + dteUptodate.Value.Month.ToString().PadLeft(2, '0') + "-" + dteUptodate.Value.Day.ToString().PadLeft(2, '0'),
                    DocDate = dDate.Date.Year.ToString() + "-" + dDate.Month.ToString().PadLeft(2, '0') + "-" + dDate.Day.ToString().PadLeft(2, '0'),
                    BillOrgCode = BillOrgCode,
                    DocType = ((InvDelDocTypes)cmbDocTypes.SelectedItem == null) ? "" : ((InvDelDocTypes)cmbDocTypes.SelectedItem).DocType.Trim(),
                    UserID = LoginInfoView.USERID,
                    ToBillAwbCount = Convert.ToInt32(txtBilledAwb.Text)
                };

                var _invdet = _preview.GetPickInvoiceDetail(para);
                SetIntialInvoiceDetail();
                if (_invdet != null)
                {

                    txtInvAwb.Text = Convert.ToString(_invdet.InvoiceAWBCount);
                    txtInvoiceWgt.Text = Convert.ToString(_invdet.InvoiceBillWgt);
                    txtInvAmtFc.Text = Convert.ToString(_invdet.InvoiceFCValue);
                    txtInvAmtLc.Text = Convert.ToString(_invdet.InvoiceLCValue);

                    txtConvertRate.Text = Convert.ToString(_invdet.ExtRate);
                    txtLcCurr.Text = _invdet.SellCurrencyLC;
                    txtFcCurr.Text = _invdet.SellCurrencyFC;

                    txtOrgCode.Text = Convert.ToString(_invdet.BillOrgCode);
                    txtOrgName.Text = _invdet.BillOrgName;
                    txtOrgAdd1.Text = _invdet.BillOrgAdd1;
                    txtOrgAdd2.Text = _invdet.BillOrgAdd2;
                    txtOrgCity.Text = _invdet.BillOrgCity;
                    txtOrgCountry.Text = _invdet.BillOrgCountry;
                    dteInvDate.Value = _invdet.InvoiceDate;
                    ///txtInvAmtLc.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtBilledAmt.Text) * Convert.ToDecimal(txtConvertRate.Text), 3));
                }
            }
        }

    }
}
