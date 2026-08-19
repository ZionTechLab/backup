using DataTire;
using Digiteq_Logic;
using Newtonsoft.Json;
using SEACC.DATA.Data.Com;
using SEACC.DATA.Domain.Com;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.COM
{
    public partial class frm_txComComissionCalculation_Collectors : MettroForm
    {
        string selesRep_ID;
        int CommishionPeriod;
        List<comCommissionCalculation_Detail> GridData;
        CommishionData commishion = new CommishionData();
        public frm_txComComissionCalculation_Collectors()
        {
            InitializeComponent();
        }

        public frm_txComComissionCalculation_Collectors(string _selesRep_ID, int _CommishionPeriod)
        {
            InitializeComponent();

            dgvDateSlab.AutoGenerateColumns = false;

            selesRep_ID = _selesRep_ID;
            CommishionPeriod = _CommishionPeriod;

            lblRAP.Tag = _CommishionPeriod;
            lblCollecter.Tag = _selesRep_ID;
            lblCollecter.Text = clsGenaralName.getName_SalesRep(_selesRep_ID);
            tbl_comCommissionPeriodMaster oCom = tbl_comCommissionPeriodMaster.Select(_CommishionPeriod);

            if (oCom != null)
                lblRAP.Text = oCom.PeriodName;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            clear();
            decimal DeductionAmount = 0;

            if (selesRep_ID != "" && CommishionPeriod != -1)
            {

                var xx = commishion.get_CommissionCollecters(CommishionPeriod, selesRep_ID);

                txtTotalCommission.Text = xx.TotalCommishion.ToString("#,##0.00");
                dgvDateSlab.DataSource = xx.dateSlab;

               GridData = xx.TxnList;
              

                var json = JsonConvert.SerializeObject(GridData);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                grdTxn.DataSource = dt;
                DeductionAmount = clsValidate.ValidateGridValue(dgvDateSlab, "deductionAmount", 0, DeductionAmount);
                txtChequeDateDed.Text = DeductionAmount.ToString("#,##0.00");
                calculate();
            }
        }
        private void clear()
        {
            txtTotalCommission.Text = "0.00";
            txtChequeDateDed.Text = "0.00";
            txtSecDepositDed.Text = "0.00";
            txtAdvDed.Text = "0.00";
            txtLoanDed.Text = "0.00";
            txtNetComm.Text = "0.00";
        }

        private void calculate()
        {
            var TotCom = decimal.Parse(txtTotalCommission.Text);
            var ChqDed = 0;// decimal.Parse(txtChequeDateDed.Text);
            var SecDepDed = decimal.Parse(txtSecDepositDed.Text);
            var AdvDed = decimal.Parse(txtAdvDed.Text);
            var loanDed = decimal.Parse(txtLoanDed.Text);

            txtNetComm.Text = (TotCom - ChqDed - SecDepDed - AdvDed - loanDed).ToString("#,##0.00");
        }
        private void dgvDateSlab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgvDateSlab.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        decimal DeductionAmount = 0;
                        row.Cells["isSelected"].Value = true;
                        DeductionAmount = clsValidate.ValidateGridValue(dgvDateSlab, "deductionAmount", row.Index, DeductionAmount);
                        txtChequeDateDed.Text = DeductionAmount.ToString("#,##0.00");
                        calculate();
                    }
                    else
                        row.Cells["isSelected"].Value = false;
                }
            }
        }

        private void txtSecDepositDed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                calculate();
        }

        private void txtAdvDed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                calculate();
        }

        private void txtLoanDed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                calculate();
        }

        private void txtSecDepositDed_Leave(object sender, EventArgs e)
        {
            calculate();
        }

        private void txtAdvDed_Leave(object sender, EventArgs e)
        {
            calculate();
        }

        private void txtLoanDed_Leave(object sender, EventArgs e)
        {
            calculate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selesRep_ID == "")
            {
                MessageBox.Show("Sales rep not found");
                return;
            }
            if (CommishionPeriod == -1)
            {
                MessageBox.Show("Commission period not found");
                return;
            }
            if (GridData == null)
            {
                MessageBox.Show("Detail records not found");
                return;
            }


            var para = new CommissionCollectors_SavePara();

            para.PeriodIndex = CommishionPeriod;
            para.Collector_ID = selesRep_ID;
            para.totalAmount = decimal.Parse(txtTotalCommission.Text);
            para.dateDeduction = decimal.Parse(txtChequeDateDed.Text);
            para.securityDeduction = decimal.Parse(txtSecDepositDed.Text);
            para.advDeduction = decimal.Parse(txtAdvDed.Text);
            para.loanDeduction = decimal.Parse(txtLoanDed.Text);
            para.netAmount = decimal.Parse(txtNetComm.Text);
            para.User_ID = clsSecurity.UserIDLoged;
            para.Terminal_ID = clsSecurity.TerminalID;
            para.Detail = GridData;
            para.DateSlab = new List<CommishionDateSlab>();

            foreach (DataGridViewRow row in dgvDateSlab.Rows)
            {
                var o = new CommishionDateSlab
                {
                    isSelected = clsValidate.ValidateGridValue(dgvDateSlab, "isSelected", row.Index, false),
                    id = clsValidate.ValidateGridValue(dgvDateSlab, "id", row.Index, 0),
                    slabName = clsValidate.ValidateGridValue(dgvDateSlab, "slabName", row.Index, ""),
                    deductionAmount = clsValidate.ValidateGridDecimalValue(dgvDateSlab, "deductionAmount", row.Index),
                };

                para.DateSlab.Add(o);
            }

          //  var result = commishion.Save_CommissionCollecters(para);

            //if (result.IsSuccess)
            //{
            //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption() , MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //    MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption() , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}