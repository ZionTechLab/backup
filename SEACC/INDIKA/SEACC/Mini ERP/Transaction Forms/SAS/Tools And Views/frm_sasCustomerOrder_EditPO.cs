using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;


namespace Digiteq
{
    public partial class frm_sasCustomerOrder_EditPO : Form
    {

        
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
 

        #region frm Load
        public frm_sasCustomerOrder_EditPO()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.sasCustomerOrderEditPO);
            iFormID = clsSecurity.getFormID(FormName.sasCustomerOrderEditPO);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasCustomerOrder_EditPO_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Customer Order Edit", 2, iFormID);
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
            if (txtCustomerOrderID.Tag != null && txtProductionJobID.Tag != null)
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    tbl_sasCustomerOrder COdetail = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Tag.ToString());
                    COdetail.PurchaseOrder_ID = txtPurchaseOrderID.Text.Trim();
                    COdetail.Remark = txtRemarks.Text;
                    COdetail.DeliveryDate = dtpDeliveryDate.Value;
                    COdetail.Update();
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please Check Following Fields... \n Customer Order No \n Production Job ID", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerOrderID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtProductionJobID, true);

            txtCustomerOrderID.Tag = null;
            txtProductionJobID.Tag = null;
           

            txtCustomerOrderID.Clear();
            txtProductionJobID.Clear();
            txtPurchaseOrderID.Clear();
            txtCustomerName.Clear();
            txtRemarks.Clear();

            dtpOrderDate.Value = clsSecurity.getServerDateTime();
        } 
        #endregion        

        #region Event Double Clicks
        private void txtCustomerOrderID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionCustomerOrder_Direct(ref txtCustomerOrderID, true);
            if (txtCustomerOrderID.Tag != null)
            {
                FillDetails(txtCustomerOrderID.Tag.ToString());
            }
        }

        private void txtProductionJobID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_ProductionJobAndCOID(ref txtProductionJobID);
            if (txtProductionJobID.Tag != null)
            {
                FillDetails(txtProductionJobID.Tag.ToString());
            }
        } 
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_sasCustomerOrder COdetail = tbl_sasCustomerOrder.Select(sID);
                if (COdetail != null)
                {
                    txtCoID.Tag = COdetail.CustomerOrder_ID;
                    txtCoID.Text = COdetail.CustomerOrder_ID;
                    txtCustomerOrderID.Tag = COdetail.CustomerOrder_ID;
                    txtCustomerOrderID.Text = COdetail.CustomerOrder_ID;
                    dtpOrderDate.Value = COdetail.CustomerOrderDate;
                    dtpDeliveryDate.Value = COdetail.DeliveryDate;
                    txtCustomerName.Text = clsGenaralName.getName_Customer(COdetail.Customer_ID);
                    txtPurchaseOrderID.Text = COdetail.PurchaseOrder_ID;
                    txtRemarks.Text = COdetail.Remark;
                }
            }
        }    
        #endregion     

      
    }
}
