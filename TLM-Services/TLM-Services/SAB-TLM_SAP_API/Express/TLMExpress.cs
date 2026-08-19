using Express.UI.Common.Enum;
using Express.UI.Inquiry;
using Express.UI.Invoice.View;
using Express.UI.Operation.View;
using Express.UI.Pricing.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI
{
    public partial class TLMExpress : Form
    {
       

        public TLMExpress()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form ExchangeRates = new ExchangeRates(ExchangeRateStatus.CLEARENCE);
            ExchangeRates.MdiParent = this;
           //ExchangeRates.Text = "Window " + childFormNumber++;
            ExchangeRates.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            Manifest_Inbound inboundManifest = new Manifest_Inbound();
            inboundManifest.MdiParent = this;
            inboundManifest.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void mnuCleInvPrint_Click(object sender, EventArgs e)
        {
            ClrInvPrinting clearencePrint = new ClrInvPrinting();
            clearencePrint.MdiParent = this;
            clearencePrint.Show();
        }

        private void webManifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Web_Manifest webManifest = new Operation.View.Web_Manifest();
            webManifest.MdiParent = this;
            webManifest.Show();
        }

        private void fedexManfestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manifest_Upload_Fedex obj = new Operation.View.Manifest_Upload_Fedex();
            obj.MdiParent = this;
            obj.Show();
        }

        private void tNTManifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manifest_Upload_Tnt obj = new Operation.View.Manifest_Upload_Tnt();
            obj.MdiParent = this;
            obj.Show();
        }

        private void aWBEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AWBManual AWBManual = new AWBManual();
            AWBManual.MdiParent = this;
            AWBManual.Show();
        }

        private void gateWayPreAlertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clearance_PreAlert obj = new Operation.View.Clearance_PreAlert();
            obj.MdiParent = this;
            obj.Show();
        }

        private void dutyInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DutyManualInvoice dutyInv = new Invoice.View.DutyManualInvoice();
            dutyInv.MdiParent = this;
            dutyInv.Show();
        }

        private void manfiestUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManifestUpload manUpload = new Operation.View.ManifestUpload();
            manUpload.MdiParent = this;
            manUpload.Show();
        }

        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InvoiceSummary invsummary = new InvoiceSummary();
            invsummary.MdiParent = this;
            invsummary.Show();
        }

        private void invoiceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceSummary invsummary = new InvoiceSummary();
            invsummary.MdiParent = this;
            invsummary.Show();
        }

        private void sAPInvoiceResendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InvoiceResend manUpload = new Operation.View.InvoiceResend();
            //manUpload.MdiParent = this;
            //manUpload.Show();
        }

        private void paymetSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PaymetSummary invsummary = new PaymetSummary();
            invsummary.MdiParent = this;
            invsummary.Show();

        }

        private void notInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotInvoiceReport invsummary = new NotInvoiceReport();
            invsummary.MdiParent = this;
            invsummary.Show();
        }

        private void orgChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrgCharges orgcharge = new OrgCharges();
            orgcharge.MdiParent = this;
            orgcharge.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DutyManualInvoice dutyInv = new Invoice.View.DutyManualInvoice();
            dutyInv.MdiParent = this;
            dutyInv.Show();
        }

        private void clearancePaymentSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymetSummary invsummary = new PaymetSummary();
            invsummary.MdiParent = this;
            invsummary.Show();
        }

        private void clearanceInvoiceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceSummary invsummary = new InvoiceSummary();
            invsummary.MdiParent = this;
            invsummary.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void clearnaceNotInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotInvoiceReport invsummary = new NotInvoiceReport();
            invsummary.MdiParent = this;
            invsummary.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            OrgCharges orgcharge = new OrgCharges();
            orgcharge.MdiParent = this;
            orgcharge.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Clearance_PreAlert obj = new Operation.View.Clearance_PreAlert();
            obj.MdiParent = this;
            obj.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ManifestUpload manUpload = new Operation.View.ManifestUpload();
            manUpload.MdiParent = this;
            manUpload.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            AWBManual AWBManual = new AWBManual();
            AWBManual.MdiParent = this;
            AWBManual.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Web_Manifest webManifest = new Operation.View.Web_Manifest();
            webManifest.MdiParent = this;
            webManifest.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NotInvoiceReport invsummary = new NotInvoiceReport();
            invsummary.MdiParent = this;
            invsummary.Show();
        }

        private void clearanceAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ClearanceAnalysis ClearanceAnalysis = new ClearanceAnalysis();
            //ClearanceAnalysis.MdiParent = this;
            //ClearanceAnalysis.Show();
        }

        private void sAPTESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SAPInvoiceResend webManifest = new Operation.View.SAPInvoiceResend();
            webManifest.MdiParent = this;
            webManifest.Show();
        }

        private void dutyOutstandingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DutyOutStanding dutyots = new DutyOutStanding();
            dutyots.MdiParent = this;
            dutyots.Show();
        }

        private void sendSAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SAPTest SendSAP = new Operation.View.SAPTest();
            SendSAP.MdiParent = this;
            SendSAP.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_Master emp = new Operation.View.Employee_Master();
            emp.MdiParent = this;
            emp.Show();
        }

        private void routeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Route_Master route = new Operation.View.Route_Master();
            route.MdiParent = this;
            route.Show();
        }

        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RevenueReport revrep = new Inquiry.RevenueReport();
            revrep.MdiParent = this;
            revrep.Show();
        }

        private void spotRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpotRate sprate = new Pricing.View.SpotRate();
            sprate.MdiParent = this;
            sprate.Show();
        }

        private void principalAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal_Accounts PrncAcc = new Operation.View.Principal_Accounts();
            PrncAcc.MdiParent = this;
            PrncAcc.Show();
        }

        private void aWBCreditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AWB_Credit_Note AWBCR = new Pricing.View.AWB_Credit_Note();
            AWBCR.MdiParent = this;
            AWBCR.Show();

        }

        private void aWBCreditNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AWB_Credit_Note AWBCR = new Pricing.View.AWB_Credit_Note();
            AWBCR.MdiParent = this;
            AWBCR.Show();
        }

        private void productMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FreightProductMapping fmap = new Operation.View.FreightProductMapping();
            fmap.MdiParent = this;
            fmap.Show();
        }

        private void freghtPrintAndProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
          // InvFrtInvPorcessPrint frt = new Invoice.View.InvFrtInvPorcessPrint();
          // frt.MdiParent = this;
          //frt.Show();
        }

        private void pODProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvDelInvoice obj = new Invoice.View.InvDelInvoice();
            obj.MdiParent = this;
            obj.Show();
        }

        private void pODUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PodScanUpload obj = new Operation.View.PodScanUpload();
            obj.MdiParent = this;
            obj.Show();
        }

        private void pODInvoicingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvDelInvoice obj = new Invoice.View.InvDelInvoice();
            obj.MdiParent = this;
            obj.Show();
        }

        private void thirdPartyManifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManifestUpload3rd obj = new Operation.View.ManifestUpload3rd();
            obj.MdiParent = this;
            obj.Show();
        }

        private void pickupInvoicingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvPickupInvoice obj = new Invoice.View.InvPickupInvoice();
            obj.MdiParent = this;
            obj.Show();
        }
    }
}
