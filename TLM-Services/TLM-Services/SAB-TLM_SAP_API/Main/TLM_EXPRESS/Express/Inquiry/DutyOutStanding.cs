using Express.Interfaces.Inquiry;
using Express.View.Domain.Inquiry;
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

namespace Express.UI.Inquiry
{
    public partial class DutyOutStanding : Form
    {

        private readonly IInvoiceSummary<InvoiceSummaryDomainView> dataProvider;

        public DutyOutStanding()
        {
            InitializeComponent();
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

            IList<AgencyDomainViewcs> agencyList = dataProvider.GetAgencyDetail(1, 200, 1002).ToList();
            cmb_agency.DataSource = agencyList;
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyID";
        }
    }
}
