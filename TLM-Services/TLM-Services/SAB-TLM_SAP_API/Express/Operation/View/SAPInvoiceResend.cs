using Express.Interfaces.SAP;
using Express.UI.Factory.SAP;
using Express.UI.Insfastructure.SAP;
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
        private List<SapResend> ResendList = null;

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


            lblResult.Text = "";

            invoiceList = _extProvider.GetInvoiceResendList("").ToList();
           

           // dgvResendList.DataSource = invoiceList;

            int i = 0;

            if (invoiceList.Count > 0)
            {

                foreach (var item in invoiceList)
                {


                    dgvResendList.Rows.Add();



                    dgvResendList.Rows[i].Cells[1].Value = item.AcDocNo;
                    dgvResendList.Rows[i].Cells[3].Value = item.ErrorMessage;
                    dgvResendList.Rows[i].Cells[2].Value = item.TransDate;



                    i++;


                }
            }


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

        private void btnResend_Click(object sender, EventArgs e)
        {

            lblResult.Text = "Please wait while processing...";

            lblResult.ForeColor = Color.Red;

            try
            {
                ResendList = new List<SapResend>();
                
                SapResend resend;

                SapInvoiceResend sr = new SapInvoiceResend();

                for (int i = 0; i < dgvResendList.Rows.Count; i++)
                {

                    if (dgvResendList.Rows[i].Cells[0].Value == null?false:(bool)dgvResendList.Rows[i].Cells[0].Value == true)
                    {

                        resend = new SapResend();
                        resend.ACDocNo = dgvResendList.Rows[i].Cells[1].Value.ToString();

                        ResendList.Add(resend);

                    }



                }

                if (ResendList.Count > 0)
                {
                    sr.ResendList = ResendList;
                    SAPRest<SapInvoiceResend> RST = new SAPRest<SapInvoiceResend>();
                    var result = RST.Post("INVOICEResend", sr).Result;

                    RefreshGrid();

                   // MessageBox.Show(result.Message);

                }
                else
                {
                    MessageBox.Show("There are no selected invoiced for processed.");
                }
            }
            catch (Exception ex)
            {

               
            }




            lblResult.Text = "Process completed";

            lblResult.ForeColor = Color.Green;





        }



        private void RefreshGrid()
        {

            dgvResendList.Rows.Clear();

            invoiceList = _extProvider.GetInvoiceResendList("").ToList();


            // dgvResendList.DataSource = invoiceList;

            int i = 0;

            if (invoiceList.Count > 0)
            {

                foreach (var item in invoiceList)
                {


                    dgvResendList.Rows.Add();



                    dgvResendList.Rows[i].Cells[1].Value = item.AcDocNo;
                    dgvResendList.Rows[i].Cells[3].Value = item.ErrorMessage;
                    dgvResendList.Rows[i].Cells[2].Value = item.TransDate;



                    i++;


                }
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            lblResult.Text = "";
            int i = 0;

            if (dgvResendList.Rows.Count > 0)
            {

                foreach (var item in invoiceList)
                {


               


                    dgvResendList.Rows[i].Cells[0].Value = true;             


                    i++;


                }
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";

            int i = 0;

            if (dgvResendList.Rows.Count > 0)
            {

                foreach (var item in invoiceList)
                {


                 


                    dgvResendList.Rows[i].Cells[0].Value = false;


                    i++;


                }
            }
        }
    }
}
