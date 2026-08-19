using Express.Interfaces.Inquiry;
using Express.Interfaces.Report.Inquiry;
using Express.Interfaces.Report.Invoice;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Inquiry;
using Express.UI.Factory.Report.Inquiry;
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
    public partial class InvoiceSummary : Form
    {
        private readonly IInvoiceSummary<InvoiceSummaryDomainView> dataProvider;
        private List<ClrInvDocTypesDomainView> listCfgDoctypes = null;
        private readonly ClrInvParamDomainView _clearencePara;
        string FilterByString = "";

        List<InvoiceSummaryDomainView> InvoiceSummaryList = new List<InvoiceSummaryDomainView>();
        public InvoiceSummary()
        {
            InitializeComponent();

            if (dataProvider == null)
            {
                dataProvider = InquryUIFacotry.GetService<IInvoiceSummary<InvoiceSummaryDomainView>>();
            }
            _clearencePara = new ClrInvParamDomainView();
            checkBox4.Checked = true;
            checkBox2.Checked = true;
            checkBox1.Checked = true;
            dateTimePicker1.Value = System.DateTime.Now.Date;
            dateTimePicker1.Value = System.DateTime.Now.Date;
        }

        private void InvoiceSummary_Load(object sender, EventArgs e)
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                date_transaction.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker1.Value = System.DateTime.Now.Date;
                dateTimePicker1.Value = System.DateTime.Now.Date;

            }
            else
            {
                date_transaction.Enabled = true;
                dateTimePicker1.Enabled = true;
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;

                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;

            DateTime paraFdeate = date_transaction.Value;
            DateTime paraTodate = dateTimePicker1.Value;
            string ParaFromInvoice = "";
            string ParaToInvoice = "";
            string ParaGate = "";
            string ParaStation = "";
            string paraDoctype = "";
            bool paraInvoiceRange = false;
           
            FilterByString = "Agency -" + SelectedAgency.AgncyName;

            if (checkBox4.Checked==false)
            {
                 ParaFromInvoice = textBox1.Text;
                 ParaToInvoice = textBox2.Text;
                 paraInvoiceRange = true;
                 FilterByString += ",Invoice Range -" + textBox1.Text +" to "+ textBox2.Text;
            }
            else
            {
                paraInvoiceRange = false;
            }
            if(checkBox2.Checked==false)
            {
                var Selectedgate = (GatewayDomainView)combo_Destin_Gate.SelectedItem;
                ParaGate = Selectedgate.LocationID;
                FilterByString += ",Gateway -" + ParaGate;
            }
            if(checkBox1.Checked==false)
            {
                var Selectedgate = (GatewayDomainView)comboBox1.SelectedItem;
                ParaStation = Selectedgate.LocationID;
                FilterByString += ",Station -" + ParaStation;
            }
            
            SetSelectedInvoiceType();
            paraDoctype = _clearencePara.InvDocTypes;
            InvoiceSummaryList.Clear();
            InvoiceSummaryList = dataProvider.GetInvoiceList(paraFdeate.ToString("MM-dd-yyyy"), ParaFromInvoice, ParaToInvoice, paraTodate.ToString("MM-dd-yyyy"), SelectedAgency.CompID, SelectedAgency.AgncyCode, SelectedAgency.GroupID,ParaGate,ParaStation,paraDoctype, paraInvoiceRange).ToList();
            grdinvoice.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grdinvoice.AutoGenerateColumns = false;
            grdinvoice.DataSource = null;
            grdinvoice.DataSource = InvoiceSummaryList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

                _report.InvoiceSummaryPrint(InvoiceSummaryList);
            }
            else
            {
                MessageNotification.MessageBoxOK("No Awb Found", "Express");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }
    }
}
