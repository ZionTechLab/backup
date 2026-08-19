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
    public partial class frm_BookNoShowAll_Receipt : MettroForm
    {
        DataTable dtCashDeposite = new DataTable();
        public frm_BookNoShowAll_Receipt()
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
            string Quary = "SELECT  B.[selesRep_ID], R.selesRepName      ,B.[book_No]      ,P.[PageNo]	  ,case when Rec.[PageNo] is null then 'NO' else 'YES' END 'Allocated'  FROM    [dbo].[tbl_RefBooks_Receipt] B    inner join[dbo].[tbl_RefBooks_Receipt_Pages] P ON P.book_No = B.book_No    left outer join[dbo].[tbl_ZEmpSalesRep] R on R.selesRep_ID = B.selesRep_ID    left outer join[dbo].[tbl_bpsReceipt] REC ON Rec.[PageNo] = P.[PageNo] and REC.isDeleted = 0 ";

            //"SELECT        RUT.route_Code AS Route, BUK.book_No AS Book, BUK.Remarks, PAG.Page FROM            tbl_genRoute AS RUT RIGHT OUTER JOIN                         tbl_RefBook_Pages AS PAG LEFT OUTER JOIN                         tbl_RefBooks AS BUK ON PAG.book_ID = BUK.book_ID ON RUT.route_ID = BUK.route_ID ";
            if (txtRoute.Text != "")
            {
                Filter += (Filter != "" ? " AND ":"") + "R.selesRepName LIKE '%" + txtRoute.Text + "%' ";
            }
            //if (txtBookNO.Text != "")
            //{
            //    Filter += (Filter != "" ? " AND " : "") + "BUK.book_NO LIKE '%" + txtBookNO.Text + "%' ";
            //}
            //if (txtRemarks.Text != "")
            //{
            //    Filter += (Filter != "" ? " AND " : "") + "BUK.Remarks LIKE '%" + txtRemarks.Text + "%' ";
            //}

            if (Filter != "")
                Quary += " WHERE " + Filter;

            dtCashDeposite.Merge(DBHandling.ExecQuery(Quary).Tables[0]);
            seacC_DataGrid1.DataSource = dtCashDeposite;
        }
    }
}
