using Express.Interfaces.Inquiry;
using Express.Interfaces.Report.Inquiry;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Inquiry;
using Express.UI.Factory.Report.Inquiry;
using Express.UI.Helpers;
using Express.UI.Invoice.View;
using Express.View.Domain.Inquiry;
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

namespace Express.UI.Inquiry
{
    public partial class NotInvoiceReport : Form
    {
        private readonly INotInvoice<NotInvoiceReportDomainView> dataProvider;
        private List<ClrInvDocTypesDomainView> listCfgDoctypes = null;
        private readonly ClrInvParamDomainView _clearencePara;
        string FilterByString = "";
        List<NotInvoiceReportDomainView> InvoiceSummaryList = new List<NotInvoiceReportDomainView>();
        public NotInvoiceReport()
        {
            InitializeComponent();
            if (dataProvider == null)
            {
                dataProvider = InquryUIFacotry.GetService<INotInvoice<NotInvoiceReportDomainView>>();
            }
            _clearencePara = new ClrInvParamDomainView();
            checkBox2.Checked = true;
            checkBox1.Checked = true;
            date_transaction.Value = System.DateTime.Now.Date;
        }

        private void NotInvoiceReport_Load(object sender, EventArgs e)
        {
            IList<AgencyDomainViewcs> agencyList = dataProvider.GetAgencyDetail(1, 200, 1002).ToList();
            cmb_agency.DataSource = agencyList;
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyID";
        }

        private void cmb_agency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            txt_company.Text = SelectedAgency.CompName;

            combo_Destin_Gate.DataSource = null;
            combo_Destin_Gate.DataSource = dataProvider.GetGateways(SelectedAgency.CountryCode).ToList();
            combo_Destin_Gate.DisplayMember = "LocationName";
            combo_Destin_Gate.ValueMember = "LocationID";

            comboBox1.DataSource = null;
            comboBox1.DataSource = dataProvider.GetStations(SelectedAgency.CountryCode).ToList();
            comboBox1.DisplayMember = "LocationName";
            comboBox1.ValueMember = "LocationID";
            listCfgDoctypes = dataProvider.GetCfgDoctypes(SelectedAgency.CompID, SelectedAgency.AgncyCode).ToList();
            loadgrdInvType();
        }

        private void loadgrdInvType()
        {

            grdInvType.Rows.Clear();
            _clearencePara.InvDocTypes = "";
            foreach (var type in listCfgDoctypes)
            {
                grdInvType.Rows.Add(true, type.Doctype, type.DoctypeN);
                _clearencePara.InvDocTypes = _clearencePara.InvDocTypes + type.Doctype.Trim() + ",";
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                combo_Destin_Gate.Enabled = false;


            }
            else
            {
                combo_Destin_Gate.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = false;


            }
            else
            {
                comboBox1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;

            ////DateTime paraFdeate = date_transaction.Value;

            ////string ParaGate = "";
            ////string ParaStation = "";
            ////string paraDoctype = "";
            ////FilterByString = "Agency -" + SelectedAgency.AgncyName;

            ////if (checkBox2.Checked == false)
            ////{
            ////    var Selectedgate = (GatewayDomainView)combo_Destin_Gate.SelectedItem;
            ////    ParaGate = Selectedgate.LocationID;
            ////    FilterByString += ",Gateway -" + ParaGate;
            ////}
            ////if (checkBox1.Checked == false)
            ////{
            ////    var Selectedgate = (GatewayDomainView)comboBox1.SelectedItem;
            ////    ParaStation = Selectedgate.LocationID;
            ////    FilterByString += ",Station -" + ParaStation;
            ////}

            ////SetSelectedInvoiceType();
            ////paraDoctype = _clearencePara.InvDocTypes;
            ////InvoiceSummaryList.Clear();
            ////InvoiceSummaryList = dataProvider.GetInvoiceList(paraFdeate.ToString("MM-dd-yyyy"), SelectedAgency.CompID, SelectedAgency.AgncyCode, SelectedAgency.GroupID, ParaGate, ParaStation, paraDoctype).ToList();
            ////grdinvoice.AutoGenerateColumns = false;
            ////grdinvoice.DataSource = null;
            ////grdinvoice.DataSource = InvoiceSummaryList;
            RetriveData();
        }

        private void RetriveData()
        {
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;

            DateTime paraFdeate = date_transaction.Value;

            string ParaGate = "";
            string ParaStation = "";
            string paraDoctype = "";
            FilterByString = "Agency -" + SelectedAgency.AgncyName;

            if (checkBox2.Checked == false)
            {
                var Selectedgate = (GatewayDomainView)combo_Destin_Gate.SelectedItem;
                ParaGate = Selectedgate.LocationID;
                FilterByString += ",Gateway -" + ParaGate;
            }
            if (checkBox1.Checked == false)
            {
                var Selectedgate = (GatewayDomainView)comboBox1.SelectedItem;
                ParaStation = Selectedgate.LocationID;
                FilterByString += ",Station -" + ParaStation;
            }

            SetSelectedInvoiceType();
            paraDoctype = _clearencePara.InvDocTypes;
            InvoiceSummaryList.Clear();
            InvoiceSummaryList = dataProvider.GetInvoiceList(paraFdeate.ToString("MM-dd-yyyy"), SelectedAgency.CompID, SelectedAgency.AgncyCode, SelectedAgency.GroupID, ParaGate, ParaStation, paraDoctype).ToList();
            grdinvoice.AutoGenerateColumns = false;
            grdinvoice.DataSource = null;
            grdinvoice.DataSource = InvoiceSummaryList;
        }

        private void SetSelectedInvoiceType()
        {
            _clearencePara.InvDocTypes = "";
            grdInvType.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow _dr in grdInvType.Rows)
            {
                if (_dr.Cells["InvTSelect"].Value.ToString().ToUpper().Equals("TRUE"))
                {
                    _clearencePara.InvDocTypes = _clearencePara.InvDocTypes + _dr.Cells["InvType"].Value.ToString().Trim() + ",";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (InvoiceSummaryList.Count > 0)
            {
                var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                IInquiryReportProvider _report = RptInquiryUIFactory.GetService<IInquiryReportProvider>();
                InvoiceSummaryList.ForEach(cc => cc.CompanyName = SelectedAgency == null ? "All Company" : SelectedAgency.CompName);
                InvoiceSummaryList.ForEach(cc => cc.FilterValue = FilterByString);
                _report.NotInvoiceSummaryPrint(InvoiceSummaryList);
            }
            else
            {
                MessageNotification.MessageBoxOK("No Awb Found", "Express");
            }
        }

        private void grdinvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string  awbno = grdinvoice.SelectedRows[0].Cells["clsAwgNo"].Value.ToString();

            if(awbno ==null || awbno.Trim()=="")
            {
                MessageNotification.MessageBoxError("Please select airwabill number", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            DutyManualInvoice _dutInv = new Invoice.View.DutyManualInvoice(awbno);
            _dutInv.ShowDialog();
            RetriveData();
        }

        private void grdinvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
