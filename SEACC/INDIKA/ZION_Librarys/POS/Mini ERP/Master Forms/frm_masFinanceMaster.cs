using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_masFinanceMaster : MettroForm
    {

        #region Variables
        
        //for security handle
        public bool bNoAccess;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        #endregion 

        public frm_masFinanceMaster()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.FinanceMaster);
            iFormID = clsSecurity.getFormID(FormName.FinanceMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_masFinanceMaster_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Finance Master", 2, iFormID);
        }

        #region Btn Bank
        private void btnBank_Click(object sender, EventArgs e)
        {
            frm_mtrBank detail = new frm_mtrBank();
            detail.ShowDialog();
        }
        #endregion

        #region Btn Branch
        private void btnBranch_Click(object sender, EventArgs e)
        {
            frm_mtrBranch detail = new frm_mtrBranch();
            detail.ShowDialog();
        }
        #endregion

        #region Tax Master
        private void btnTax_Click(object sender, EventArgs e)
        {
            frm_mtrTax detail = new frm_mtrTax();
            detail.ShowDialog();
        }
        #endregion

        #region Btn Currency
        private void btnCurrencyMaster_Click(object sender, EventArgs e)
        {
            frm_mtrCurrency detail = new frm_mtrCurrency();
            detail.ShowDialog();
        } 
        #endregion
    }
}
