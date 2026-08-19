using Express.Interfaces.SAP;
using Express.UI.Factory.SAP;
using Express.View.Domain.SAP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Operation.View
{
    public partial class SAPInvoiceResend : Form
    {
        private readonly ISAPInvoice _extProvider;
        private List<InvoiceResendHeader> invoiceList = null;

        public SAPInvoiceResend()
        {
            try
            {
                if (_extProvider == null)
                {
                    _extProvider = SAPFactory.GetService<ISAPInvoice>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            InitializeComponent();
        }

        private void SAPInvoiceResend_Load(object sender, EventArgs e)
        {
            invoiceList = _extProvider.GetInvoiceResendList("").ToList();
            dgvResendList.DataSource = invoiceList;
        }

        private void dgvResendList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SAPGLUpdate manUpload = new Operation.View.SAPGLUpdate();
                manUpload.MdiParent = this.MdiParent;
                manUpload.Show();
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
    }
}
