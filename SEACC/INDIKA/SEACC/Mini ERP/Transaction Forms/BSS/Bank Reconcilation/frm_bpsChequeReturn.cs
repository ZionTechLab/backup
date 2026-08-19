using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;

namespace Digiteq.Transaction_Forms.BSS.Bank_Reconcilation
{
    public partial class frm_bpsChequeReturn : SEACC_Form
    {
        public frm_bpsChequeReturn()
        {
            InitializeComponent();
        }
        public frm_bpsChequeReturn(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
            dgvDetail.AutoGenerateColumns = false;
        }

        private void frm_bpsChequeReturn_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, false, false, true, false, false, false, false, false);
          //  Refresh_BranchCmb();
            ClearFields();
        }

        #region Clear Fields
        private void ClearFields()
        {
            //lblDepositBankName.Tag = null;
            //lblDepositBranchName.Tag = null;
            //txtDepositAccountNo.Tag = null;

            //txtDepositAccountHolder.Clear();
            //txtDepositAccountNo.Clear();
            //lblDepositBankName.Text = "";
            //lblDepositBranchName.Text = "";
            //txtDepositRemark.Clear();

            //dtpDepositDate.Value = clsSecurity.getServerDateTime();

            //txtCountChequeSelected.Text = "0";
            //txtAmountChequeSelected.Text = "0.00";

            //clsCommon.SetEnableDisable_NormalTextbox(txtFillter, true);

            //RefreshGridAllForChequeDeposit();
        }
        #endregion


    }
}
