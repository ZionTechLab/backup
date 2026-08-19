using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_sasInvoiceOrderRefEdit : Form
    {
        #region Variables
        static bool IsUpdate = false;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbInquiryID = "", glbQuotationID = "";

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        //for handle Revers Calculation
        bool isDonVatReversCalculation = false;
        bool isDonNbtReversCalculation = false; 
        #endregion

        #region frm Load
        public frm_sasInvoiceOrderRefEdit()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.sasInvoiceOrderRefEdit);
            iFormID = clsSecurity.getFormID(FormName.sasInvoiceOrderRefEdit);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasInvoiceOrderRefEdit_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Invoice Order Reference No. Edit", 2, iFormID);
            ClearFields();
        } 
        #endregion

        #region btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceID.Tag != null)
                {
                    if (CheckValidity())
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                            if (oInvoice != null && oInvoice.Invoice_ID != "default")
                            {
                                oInvoice.CustomerGrnNo = txtGrnNo.Text.ToString();
                                oInvoice.Update();

                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                if (oRef != null && oRef.OrderRefNo_ID != "default")
                                {
                                    tbl_trcInvoiceEdit detail = new tbl_trcInvoiceEdit(txtInvoiceID.Tag.ToString(), oRef.OrderRefNo, txtOrderRefNo.Text.Trim(),
                                        clsSecurity.getServerDateTime().Date, clsSecurity.UserIDLoged, clsSecurity.TerminalID, "default");
                                    detail.Insert();

                                    oRef.OrderRefNo = txtOrderRefNo.Text.Trim();
                                    oRef.Update();
                                }
                                if (txtProductJobID.Tag != null)
                                {
                                    tbl_trcInvoiceEdit detail = new tbl_trcInvoiceEdit(txtInvoiceID.Tag.ToString(), "default", "default",
                                        clsSecurity.getServerDateTime().Date, clsSecurity.UserIDLoged, clsSecurity.TerminalID, txtProductJobID.Tag.ToString());
                                    detail.Insert();

                                    oInvoice.Job_ID = txtProductJobID.Tag.ToString();
                                    oInvoice.Update();
                                }                                 
                            }
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Following Field(s)... \n Order Reference No.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, true);
            txtInvoiceID.Tag = null;
            txtProductJobID.Tag = null;

            txtInvoiceID.Clear();
            txtOrderRefNo.Clear();
            txtCustomerName.Clear();
            txtProductJobID.Clear();
            txtRemarks.Clear();
            txtGrnNo.Clear();
            dtpInvoiceDate.Value = clsSecurity.getServerDateTime();
        } 
        #endregion        

        #region Event Double Clicks
        private void txtCustomerOrderID_DoubleClick(object sender, EventArgs e)
        {    
            clsSearch.Search_TransactionInvoice_Use(ref txtInvoiceID, false, string.Empty, true, false, false, true);
            if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtInvoiceID.Tag.ToString());
        }
        private void txtProductJobID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionProductionJobRegister(ref txtProductJobID);
            if (txtProductJobID.Text.Length > 0)
                FillDetails(txtProductJobID.Text.Trim());
        }
        #endregion

        #region Event KeyDown
        private void txtProductJobID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionProductionJobRegister(ref txtProductJobID);
                if (txtProductJobID.Text.Length > 0)
                    FillDetails(txtProductJobID.Text.Trim());
            }
        } 
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sID);
                if (oInvoice != null)
                {
                    txtInvoiceID.Tag = oInvoice.Invoice_ID;
                    txtInvoiceID.Text = oInvoice.Invoice_ID;
                    dtpInvoiceDate.Value = oInvoice.InvoiceDate;
                    txtCustomerName.Text = clsGenaralName.getName_Customer(oInvoice.Customer_ID);
                    txtOrderRefNo.Text = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                    txtRemarks.Text = oInvoice.Remark;
                    txtGrnNo.Text = oInvoice.CustomerGrnNo;
                }
            }
        }    
        #endregion     

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtOrderRefNo.TextLength == 0)
                {
                    strMessage += "\n" + "Order Reference No. ";
                    bStatus = false;
                }
                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        #endregion

        

       
    }
}
