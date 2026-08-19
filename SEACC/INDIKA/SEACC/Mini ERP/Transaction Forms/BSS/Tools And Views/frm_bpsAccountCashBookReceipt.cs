using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_bpsAccountCashBookReceipt : Form
    {
        
        //form manage
           public int iFormID;
        //for security handle
        public bool bNoAccess;
        //string sFormConfigCode;
   

        #region Form Load
        public frm_bpsAccountCashBookReceipt()
        {
            iFormID = clsSecurity.getFormID(FormName.AccountCashBookReceipt);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsAccountCashBook_Load(object sender, EventArgs e)
        {
            CusDataGridViewFormat();
        } 
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

    }
}
