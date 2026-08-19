using Express.Interfaces.Inquiry;
using Express.Interfaces.Report.Inquiry;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Inquiry;
using Express.UI.Factory.Report.Inquiry;
using Express.View.Domain.Inquiry;
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
    public partial class DutyOutStanding : Form
    {

        private readonly IDutyOutstanding dataProvider;
        private List<DutyOutstandingViewModel> InvoiceList = null;
        int MenuCode = 0;

        public DutyOutStanding()
        {


            if (dataProvider == null)
            {
                dataProvider = InquryUIFacotry.GetService<IDutyOutstanding>();
            }
            InitializeComponent();
            MenuCode = LoginInfoView.MENUCODE;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DutyOutStanding_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            IList<AgencyDomainViewcs> agencyList = dataProvider.GetAgencyDetail(LoginInfoView.USERID, LoginInfoView.MODULEID, MenuCode).ToList();
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyCode";
            cmb_agency.DataSource = agencyList;
           

            IList<RefSvcRootsDomainView> routeList = dataProvider.GetRoutes("").ToList();
            cmbRoute.DisplayMember = "SvcRootName";
            cmbRoute.ValueMember = "SvcRootID";
            cmbRoute.DataSource = routeList;
          



            IList<CourrierDomainView> CourrierList = dataProvider.GetCourrier("").ToList();
            cmbCourier.DisplayMember = "EmployeeName";
            cmbCourier.ValueMember = "EmployeeID";
            cmbCourier.DataSource = CourrierList;
            



            chkCourierAll.Checked = true;
            chkGatewayAll.Checked = true;
            chkRouteAll.Checked = true;
            chkStationAll.Checked = true;
            chkAgencyAll.Checked = true;

            radCash.Checked = true;
        }

        private void cmb_agency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            //txt_company.Text = SelectedAgency.CompName;

            cmbGateWay.DataSource = null;
            cmbGateWay.DataSource = dataProvider.GetGateways(SelectedAgency.CountryCode).ToList();
            cmbGateWay.DisplayMember = "LocationName";
            cmbGateWay.ValueMember = "LocationID";

            cmbStation.DataSource = null;
            cmbStation.DataSource = dataProvider.GetStations(SelectedAgency.CountryCode).ToList();
            cmbStation.DisplayMember = "LocationName";
            cmbStation.ValueMember = "LocationID";




        }

        private void button1_Click(object sender, EventArgs e)
        {

            dgvDutyInv.Rows.Clear();

            InvoiceList = new List<DutyOutstandingViewModel>();





            InvoiceList = dataProvider.GetOutstaindingInvoice(dteFromDate.Value.ToLocalTime(), dteToDate.Value.ToLocalTime(), 0, int.Parse(cmb_agency.SelectedValue.ToString()), 0, cmbGateWay.SelectedValue == null ? "" : cmbGateWay.SelectedValue.ToString(), cmbStation.SelectedValue == null ? "" : cmbStation.SelectedValue.ToString(), cmbRoute.SelectedValue == null ? "" : cmbRoute.SelectedValue.ToString(), cmbCourier.SelectedValue == null ? "" : cmbCourier.SelectedValue.ToString(), radCash.Checked ? "CSH" : "CRD", chkDeliveredPackage.Checked, chkOutstandingOnly.Checked, chkGatewayAll.Checked, chkStationAll.Checked, chkRouteAll.Checked, chkCourierAll.Checked, chkAgencyAll.Checked).ToList();

            // InvoiceList = dataProvider.GetOutstaindingInvoice(dteFromDate, dteToDate, 0, 0, 0, cmbGateWay.SelectedValue, cmbGateWay.SelectedValue, cmbStation.SelectedValue, cmbRoute.SelectedValue, cmbCourier, radCash.Checked ? "CAS" : "CHK", radDeliveryPackage.Checked ? true : false, radOutstandingOnly.Checked ? true : false, chkGatewayAll.Checked, chkStationAll.Checked, chkRouteAll.Checked, chkCourierAll.Checked);

            //for (int i = 0; i < InvoiceList.Count - 1; i++)
            //{ 

            //    dgvDutyInv.Rows[i].Cells[0].Value =  ;
            //    dgvDutyInv.Rows[i].Cells[1].Value = item.ExpressMpsNo;
            //    dgvDutyInv.Rows[i].Cells[2].Value = false;
            //    dgvDutyInv.Rows[i].Cells[0].ReadOnly = true;
            //}

            int i = 0;

            foreach (var item in InvoiceList)
            {
                dgvDutyInv.Rows.Add();

                dgvDutyInv.Rows[i].Cells[0].Value = item.No;
                dgvDutyInv.Rows[i].Cells[1].Value = item.Delivered;
                dgvDutyInv.Rows[i].Cells[2].Value = item.GateWayID;
                dgvDutyInv.Rows[i].Cells[3].Value = item.StationID;
                dgvDutyInv.Rows[i].Cells[4].Value = item.RouteID;
                dgvDutyInv.Rows[i].Cells[5].Value = item.Courier;
                dgvDutyInv.Rows[i].Cells[6].Value = item.InvDate.ToShortDateString();
                dgvDutyInv.Rows[i].Cells[7].Value = item.InvNo;
                dgvDutyInv.Rows[i].Cells[8].Value = item.AgnAwbNo;
                dgvDutyInv.Rows[i].Cells[9].Value = item.OrgCode;
                dgvDutyInv.Rows[i].Cells[10].Value = item.OrgName;
                dgvDutyInv.Rows[i].Cells[11].Value = item.PayMode;
                dgvDutyInv.Rows[i].Cells[12].Value = item.InvAmt;




                i++;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (InvoiceList.Count > 0)
                {
                    var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;



                    IInquiryReportProvider _report = RptInquiryUIFactory.GetService<IInquiryReportProvider>();


                    _report.DutyOutStandingPrint(InvoiceList);
                }
                else
                {
                    MessageNotification.MessageBoxOK("No Invoices Found", "Express");
                }
            }
            catch (Exception ex)
            {


            }

        }

        private void chkGatewayAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGatewayAll.Checked)
            {
                cmbGateWay.Enabled = false;
            }
            else
            {
                cmbGateWay.Enabled = true;
            }
        }

        private void chkStationAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStationAll.Checked)
            {
                cmbStation.Enabled = false;
            }
            else
            {
                cmbStation.Enabled = true;
            }
        }

        private void chkRouteAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRouteAll.Checked)
            {
                cmbRoute.Enabled = false;
            }
            else
            {
                cmbRoute.Enabled = true;
            }
        }

        private void chkCourierAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCourierAll.Checked)
            {
                cmbCourier.Enabled = false;
            }
            else
            {
                cmbCourier.Enabled = true;
            }
        }

        private void chkAgencyAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgencyAll.Checked)
            {
                cmb_agency.Enabled = false;
            }
            else
            {
                cmb_agency.Enabled = true;
            }
        }

        private void cmb_agency_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            //txt_company.Text = SelectedAgency.CompName;

            cmbGateWay.DataSource = null;
            cmbGateWay.DataSource = dataProvider.GetGateways(SelectedAgency.CountryCode).ToList();
            cmbGateWay.DisplayMember = "LocationName";
            cmbGateWay.ValueMember = "LocationID";

            cmbStation.DataSource = null;
            cmbStation.DataSource = dataProvider.GetStations(SelectedAgency.CountryCode).ToList();
            cmbStation.DisplayMember = "LocationName";
            cmbStation.ValueMember = "LocationID";
        }
    }
}
