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
    public partial class frm_scsTools : Form
    {
        #region Variables
        //to manage update and insert
     //   static bool IsUpdate = false;
      //  static bool bIsWeightCalculation = false;

        //for security handle
        public bool bNoAccess;

        //form manage
      //  string sFormConfigCode;
           public int iFormID;

        #endregion 

        public frm_scsTools()
        {            
            iFormID = clsSecurity.getFormID(FormName.StockTool);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void btnCusOrderEdit_Click(object sender, EventArgs e)
        {
            DisplayCustomerOrderEdit();
        }

        private void btnDoManualSettle_Click(object sender, EventArgs e)
        {
            DisplayStockTransferManulSettle();
        }

        #region Display Form
        private void DisplayCustomerOrderEdit()
        {
            frm_sasCustomerOrder_Edit frm = new frm_sasCustomerOrder_Edit();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void DisplayStockTransferManulSettle()
        {
            frm_sasStockTransfer_ManualSettle frm = new frm_sasStockTransfer_ManualSettle();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void btnSubAgentPaymentAdvice_Click(object sender, EventArgs e)
        {
            frm_bpsReceipt_PaymentAdvice_SubAgent frm = new frm_bpsReceipt_PaymentAdvice_SubAgent();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        private void frm_sasTools_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Manual Proecess Adjustment Tools", 2, iFormID);
        }

        private void btnPoEdit_Click(object sender, EventArgs e)
        {
            frm_PurchaseOrderDiscountEdit frm = new frm_PurchaseOrderDiscountEdit();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
    }
}
