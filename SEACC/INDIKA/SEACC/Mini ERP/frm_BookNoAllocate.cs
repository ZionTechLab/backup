using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_BookNoAllocate : MettroForm
    {

        public frm_BookNoAllocate()
        {
            iFormID = clsSecurity.getFormID(FormName.BookNoAllocation);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRoute);
        }

        void clearFields()
        {
            txtRoute.Tag = null;
            txtRoute.Clear();
            txtBookNO.Clear();
            txtRemarks.Clear();
            txtSeperator.Clear();
            //   txtPrefix.Clear();
            txtlength.Text = "3";
            txtStart.Text = "0";
            txtEnd.Text = "0";
            dataGridView1.Rows.Clear();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                int iStartSerial = 0;
                int iEndSerial = 0;
                int iLength = 0;

                if (txtBookNO.Text == "")
                {
                    MessageBox.Show("Please enter the book No");
                    return;
                }
                if (txtRoute.Tag == null)
                {
                    MessageBox.Show("Please enter the Route");
                    return;
                }
                int.TryParse(txtStart.Text, out iStartSerial);
                int.TryParse(txtEnd.Text, out iEndSerial);
                int.TryParse(txtlength.Text, out iLength);

                if (iStartSerial >= iEndSerial)
                {
                    MessageBox.Show("Please Check the serial range");
                    return;
                }
                tbl_RefBooks Books = tbl_RefBooks.SelectAll().Where(p => p.Book_No == txtBookNO.Text && p.Route_ID == int.Parse(txtRoute.Tag.ToString())).FirstOrDefault();
                if (Books != null)
                {
                    MessageBox.Show("This Book no is Exist. Please enter another book no");
                    return;
                    //DialogResult msgResult = MessageBox.Show("This Book no is Exist. Please enter another book no", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    //if (msgResult == DialogResult.Yes)
                    //{

                    //}
                }
                string sRouteID = txtRoute.Text.ToString();
                string sBookID = txtBookNO.Text;

                for (int i = iStartSerial; i <= iEndSerial; i++)
                {
                    dataGridView1.Rows.Add();
                    int iRow = dataGridView1.Rows.Count - 1;

                    dataGridView1["Route", iRow].Value = sRouteID;
                    dataGridView1["BookNo", iRow].Value = sBookID;
                    dataGridView1["Page", iRow].Value =txtRoute.Text+txtSeperator.Text + i.ToString(clsAutocode.getWidthFormat(iLength));

                }


            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void frm_BookNoAllocate_Load(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please process serial numbers");
                return;
            }

            int iStartSerial = 0;
            int iEndSerial = 0;
            int iLength = 0;
            int iRouteID = int.Parse(txtRoute.Tag.ToString());
            int.TryParse(txtStart.Text, out iStartSerial);
            int.TryParse(txtEnd.Text, out iEndSerial);
            int.TryParse(txtlength.Text, out iLength);

            tbl_RefBooks Books = new tbl_RefBooks(0, iRouteID, txtBookNO.Text,txtSeperator .Text, iStartSerial, iEndSerial, iLength,txtRemarks.Text);
         //   Books.Insert();

            int s = int.Parse(Books.Insert());

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string Page = clsValidate.ValidateGridValue(dataGridView1, "Page", row.Index, "");

                tbl_RefBook_Pages page = new tbl_RefBook_Pages(s, Page);
                page.Insert();

            }
            MessageBox.Show("Save Successfully");
            clearFields();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            frm_BookNoShowAll frm = new frm_BookNoShowAll();
            frm.ShowDialog();
        }
    }
}
