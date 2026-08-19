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
    public partial class frm_masAccountsMaster : MettroForm
    {
        #region Form Load
        public frm_masAccountsMaster()
        {
            iFormID = clsSecurity.getFormID(FormName.AccountsMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_masAccountsMaster_Load(object sender, EventArgs e)
        {

        } 
        #endregion

        #region Variables
        //form manage
           public int iFormID;
        //for security handle
        public bool bNoAccess;
        string sFormConfigCode;
        #endregion


        #region Btn Financial Year Master
        private void btnFinancialYearMaster_Click(object sender, EventArgs e)
        {
            frm_masAccFinancialYear_New detail = new frm_masAccFinancialYear_New();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }
        #endregion

        #region Btn Chart of Accounts
        private void btnChartofAccounts_Click(object sender, EventArgs e)
        {
            frm_masAccChartOfAccount detail = new frm_masAccChartOfAccount();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }
        #endregion

        #region Btn Account Note Master
        private void btnAccountNoteMaster_Click(object sender, EventArgs e)
        {
            frm_mtrAccountGLNote detail = new frm_mtrAccountGLNote();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }
        #endregion

        #region Btn Account Slot Master
        private void btnAccountSlotMaster_Click(object sender, EventArgs e)
        {
                     frm_AccPostingConfigaration detail = new frm_AccPostingConfigaration();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }
        #endregion

        #region Btn Cost Center 01
        private void btnCostCenter01_Click(object sender, EventArgs e)
        {
            frm_mtrAccCostCenter1 detail = new frm_mtrAccCostCenter1();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }
        #endregion

        #region Btn Cost Center 02
        private void btnCostCenter02_Click(object sender, EventArgs e)
        {
            frm_mtrAccCostCenter2 detail = new frm_mtrAccCostCenter2();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //frm_mtrAccCostCenter detail = new frm_mtrAccCostCenter();
            //detail.MdiParent = this.MdiParent;
            //detail.Show();
        }

        //private void btnReportBuilder_Click(object sender, EventArgs e)
        //{
        //    frm_masAccReportMasterForAccount detail = new frm_masAccReportMasterForAccount();
        //    detail.MdiParent = this.MdiParent;
        //    detail.Show();
        //}

        private void btnIncomeStatement_Click(object sender, EventArgs e)
        {
            frm_AccProfitAndLoss detail = new frm_AccProfitAndLoss();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }

        private void btnSlotChange_Click(object sender, EventArgs e)
        {
            frm_AccSlotChange detail = new frm_AccSlotChange();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }   
    }
}
