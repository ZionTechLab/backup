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
using SEACC.WinFormControls.Forms;
using DataTire;
using SEACC.DATA.Data.BSS;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.BSS;

namespace Digiteq.Transaction_Forms.BSS.Bank_Reconcilation
{
    public partial class frm_bpsChequeReturn_New : SEACC_Form
    {
        public DataTable dtCashDeposite = new DataTable();
        ChequeData oData = new ChequeData();
        public frm_bpsChequeReturn_New()
        {
            InitializeComponent();
        }
        public frm_bpsChequeReturn_New(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
            dgvDetail.AutoGenerateColumns = false;
            dgvDetail.Columns["IsSelected"].DisplayIndex = 7;
        }

        private void frm_bpsChequeReturn_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, false, false, true, false, false, false, false, false);
            ClearFields();
        }

        #region Clear Fields
        private void ClearFields()
        {
            txtDepositAccountNo.Clear();
            txtDepositAccountNo.Tag = null;
            if (dgvDetail.DataSource!=null)
            dgvDetail.DataSource = (dgvDetail.DataSource as DataTable).Clone();
        }

        #endregion

        private void txtDepositAccountNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.SearchMaster_CompanyAccount(ref txtDepositAccountNo, "", "");
                if (txtDepositAccountNo.Tag != null)
                {
                    dtCashDeposite = DBHandling.ExecQuery("exec sp_PReg_ChequesToBeReconcile '" + clsSecurity.CompanyID + "','" + "" + "','" + clsSecurity.UserIDLoged + "','" + txtDepositAccountNo.Tag + "'").Tables[0];
                    dgvDetail.DataSource = dtCashDeposite;
                }
            }

            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "RegisterCode" || sColName == "RTSRegisterCode")
                {
                    string sRegisterID = dgvDetail[e.ColumnIndex, e.RowIndex].Value.ToString();
                    tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(sRegisterID);
                    if (detail != null)
                    {
                        frm_bpsChequeViewer cheque = new frm_bpsChequeViewer();
                        cheque.glbChequeRegisterID = detail.ChequeRegister_ID;
                        cheque.ShowDialog();
                    }
                }

                else if (sColName == "ReceiptID" || sColName == "RTSReceiptID")
                {
                    string sReceiptID = dgvDetail[e.ColumnIndex, e.RowIndex].Value.ToString();
                    tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
                    if (detail != null)
                    {
                        if (detail.IsSalesReceipt)
                        {
                            UC_bpsReceiptSales cheque = new UC_bpsReceiptSales(FormName.UCReceipt);

                            cheque.glbReceiptID = detail.Receipt_ID;
                            clsHelpMethods_Local.DisplayForm(cheque, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                        }
                        else
                        {
                        }
                    }
                }
                else if (sColName == "IsSelected")
                {
                    bool bstatus = clsValidate.ValidateGridValue(dgvDetail, "IsSelected", e.RowIndex, false);
                    dgvDetail[e.ColumnIndex, e.RowIndex].Value = !bstatus;
                    if (!bstatus)
                        oContextMenuChq.Show(Cursor.Position);
                }
                else if (sColName == "GridChequeStatus")
                {
                    oContextMenuChq.Show(Cursor.Position);
                }
            }
        }

        private void frm_bpsChequeReturn_New_SF_saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    return;

                DialogResult msgResult = MessageBox.Show("Are you sure you want to Proceed ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgResult != DialogResult.Yes)
                    return;

                var arr = new List<tmptbl_ChqReconcilation>();

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    bool bIsSelected = clsValidate.ValidateGridValue(dgvDetail, "IsSelected", row.Index, false);

                    if (!bIsSelected)
                        continue;

                    var _chequeStatus_ID = clsValidate.ValidateGridValue(dgvDetail, "chequeStatus_ID", row.Index, 0);
                    var _chequeRegister_ID = clsValidate.ValidateGridValue(dgvDetail, "RegisterCode", row.Index, "");

                    if (!(_chequeStatus_ID == 4 || _chequeStatus_ID == 5))
                    {
                        MessageBox.Show("Please select the Cheque status <"+ _chequeRegister_ID+">");
                        return;
                    }
                    arr.Add(
                        new tmptbl_ChqReconcilation
                        {
                            chequeRegister_ID = _chequeRegister_ID,
                            chequeStatus_ID = _chequeStatus_ID,
                            chequeDeposit_ID = clsValidate.ValidateGridValue(dgvDetail, "chequeDeposit_ID", row.Index, "")
                        }
                       );
                }

                if (arr.Count == 0)
                {
                    MessageBox.Show("Please select one or more cheques to return", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var recponce = oData.Save_ReturnedCheques(arr, txtDepositRemark.Text, dtpDepositDate.Value, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (!recponce.IsSuccess)
                    MessageBox.Show(recponce.OutMsg);
                else
                {
                    MessageBox.Show("Record Saved Successfully. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                ClearFields();
            }
        }

        private void frm_bpsChequeReturn_New_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void oContextMenuChq_Click(object sender, EventArgs e)
        {
            string sSelectedStatus = sender.ToString();
            if (sSelectedStatus != null && sSelectedStatus != "")
            {
                string StatusId = "default";
                if (sSelectedStatus == "Returned [R]")
                    StatusId = "4";
                else if (sSelectedStatus == "Returned [NR/C]")
                    StatusId = "5";

                var row = dgvDetail.SelectedRows[0];
                row.Cells["chequeStatus_ID"].Value = StatusId;
                row.Cells["GridChequeStatus"].Value = sSelectedStatus;
            }
        }

        private void txtFillter_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                StringBuilder sFilter = new StringBuilder();

                string sFilteredValue = clsHelpMethods.CheckValue(txtFillter.Text.Trim());


               sFilter.Append("depositDate LIKE '%" + sFilteredValue + "%' ");
                sFilter.Append("or receiptID LIKE '%" + sFilteredValue + "%' ");
       //         sFilter.Append("OR invoiceList LIKE '%" + sFilteredValue + "%' ");
                sFilter.Append("OR Amount LIKE '%" + sFilteredValue + "%' ");
                sFilter.Append("OR ChequeNo LIKE '%" + sFilteredValue + "%' ");
                dtCashDeposite.DefaultView.RowFilter = sFilter.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }


            //string sCheckedValue = clsHelpMethods.CheckValue(value);
        }
    }
}