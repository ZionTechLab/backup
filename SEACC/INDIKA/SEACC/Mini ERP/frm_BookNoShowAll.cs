using DataTire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_BookNoShowAll : MettroForm
    {
        DataTable dtCashDeposite = new DataTable();
        public frm_BookNoShowAll()
        {
            InitializeComponent();
           

        }

        private void frm_BookNoShowAll_Load(object sender, EventArgs e)
        {
          
            

         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dtCashDeposite.Clear();
            string Filter = "";
            string Quary = "SELECT        RUT.route_Code AS Route, BUK.book_No AS Book, BUK.Remarks, PAG.Page,(case when co_1.orderRefNo is null then 0 else 1 end) allocated FROM tbl_genRoute AS RUT RIGHT OUTER JOIN               tbl_RefBooks AS BUK RIGHT OUTER JOIN              tbl_RefBook_Pages AS PAG LEFT OUTER JOIN                  (SELECT        ORF.orderRefNo_ID, ORF.orderRefNo                    FROM            tbl_zOrderRefNo AS ORF INNER JOIN                                              tbl_sasCustomerOrder AS CO ON ORF.orderRefNo_ID = CO.orderRefNo_ID                    WHERE(CO.isDeleted = 0)) AS co_1 ON PAG.Page = co_1.orderRefNo ON BUK.book_ID = PAG.book_ID ON RUT.route_ID = BUK.route_ID";
                //"SELECT        RUT.route_Code AS Route, BUK.book_No AS Book, BUK.Remarks, PAG.Page FROM            tbl_genRoute AS RUT RIGHT OUTER JOIN                         tbl_RefBook_Pages AS PAG LEFT OUTER JOIN                         tbl_RefBooks AS BUK ON PAG.book_ID = BUK.book_ID ON RUT.route_ID = BUK.route_ID ";
            if (txtRoute.Text != "")
            {
                Filter += (Filter != "" ? " AND ":"") +  "RUT.route_Code LIKE '%" + txtRoute.Text + "%' ";
            }
            if (txtBookNO.Text != "")
            {
                Filter += (Filter != "" ? " AND " : "") + "BUK.book_NO LIKE '%" + txtBookNO.Text + "%' ";
            }
            if (txtRemarks.Text != "")
            {
                Filter += (Filter != "" ? " AND " : "") + "BUK.Remarks LIKE '%" + txtRemarks.Text + "%' ";
            }

            if (Filter != "")
                Quary += " WHERE " + Filter;

            dtCashDeposite.Merge(DBHandling.ExecQuery(Quary).Tables[0]);
            seacC_DataGrid1.DataSource = dtCashDeposite;
        }
    }
}
