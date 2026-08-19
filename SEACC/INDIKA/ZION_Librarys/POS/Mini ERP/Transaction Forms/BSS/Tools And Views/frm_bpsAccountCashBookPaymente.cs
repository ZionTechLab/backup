using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_bpsAccountCashBook : Form
    {
        #region Variables
        //form manage
           public int iFormID;
        //for security handle
        public bool bNoAccess;
        string sFormConfigCode;
        #endregion

        #region Form Load
        public frm_bpsAccountCashBook()
        {
            iFormID = clsSecurity.getFormID(FormName.AccountCashBookPaymente);
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
