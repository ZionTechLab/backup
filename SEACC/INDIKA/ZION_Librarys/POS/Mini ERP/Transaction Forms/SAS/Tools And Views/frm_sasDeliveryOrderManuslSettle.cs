using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_sasDeliveryOrderManuslSettle : Form
    {

        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_sasDeliveryOrderManuslSettle()
        {
            iFormID = clsSecurity.getFormID(FormName.DeliveryOrderMenualSettings);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasDeliveryOrderManuslSettle_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "D/O Settle", 2, iFormID);
           CusDataGridViewFormat();
           ClearFields();

        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();

        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                if (bool.Parse(dgvDetail["Settle", row.Index].Value.ToString()))
                                {
                                    string sDCode=dgvDetail["DOCode", row.Index].Value.ToString();
                                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sDCode);
                                    if (detail != null)
                                    {
                                        detail.IsSeattled = true;
                                        detail.Update();
                                    }
                                }
                            }
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID,ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            //RefreshGrid();
                        }
                    }
                }
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtJobNo.Tag = null;

            txtJobNo.Clear();
            txtDoCode.Clear();

            dgvDetail.Rows.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridByDeliveryOredrID(string sID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sID);
                if (detail != null)
                {
                    if (detail.DeliveryOrder_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["DOCode", iRow].Value = detail.DeliveryOrder_ID;
                        dgvDetail["DODate", iRow].Value = detail.DeliveryOrderDate.ToString("yyyy-MM-dd");
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
           // string strMessage = "";
            bool bStatus = false;

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (bool.Parse(dgvDetail["Settle", row.Index].Value.ToString()))
                    bStatus = true;
            }

            if (bStatus == false)
            {
                MessageBox.Show("User Needs To Select Atleast One Delivery Order No To Settle", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion



        #region Events KeyDown
        private void txtJobNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ClearFields();
                clsSearch.Search_MasterOrderReferance(ref txtJobNo, true);
                if (txtJobNo.Tag != null && txtJobNo.Tag.ToString().Trim().Length > 0)
                {
                    dgvDetail.Rows.Clear();
                    List<tbl_sasDeliveryOrder > details=tbl_sasDeliveryOrder.SelectAllByOrderRefNo_ID(txtJobNo.Tag.ToString());
                    foreach (tbl_sasDeliveryOrder detail in details)
                    {
                        RefreshGridByDeliveryOredrID(detail.DeliveryOrder_ID);
                    }
                }
                
            }   
        }

        private void txtDoCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                ClearFields();
                Search_DeliveryOrderID();
            }
        }

        private void frm_sasDeliveryOrderManuslSettle_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtJobNo_DoubleClick(object sender, EventArgs e)
        {
            ClearFields();
            clsSearch.Search_MasterOrderReferance(ref txtJobNo, true);
            if (txtJobNo.Tag != null && txtJobNo.Tag.ToString().Trim().Length > 0)
            {
                dgvDetail.Rows.Clear();
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAllByOrderRefNo_ID(txtJobNo.Tag.ToString());

                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (!detail.IsSeattled)
                        RefreshGridByDeliveryOredrID(detail.DeliveryOrder_ID);
                }
            }
        }

        private void txtDoCode_DoubleClick(object sender, EventArgs e)
        {
            ClearFields();
            Search_DeliveryOrderID();
        }
        #endregion

        #region Search Methods
        private void Search_DeliveryOrderID()
        {
            clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDoCode, "", false);
            if (txtDoCode.Tag != null && txtDoCode.Tag.ToString().Trim().Length > 0)
            {
                RefreshGridByDeliveryOredrID(txtDoCode.Text);
            }            
        }
        #endregion
    }
}
