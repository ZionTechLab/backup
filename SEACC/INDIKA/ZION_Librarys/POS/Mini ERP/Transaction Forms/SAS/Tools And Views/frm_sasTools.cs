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
    public partial class frm_sasTools : MettroForm
    {
        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;
        //static bool bIsWeightCalculation = false;

        //for security handle
        public bool bNoAccess;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        #endregion 

        public frm_sasTools()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.SalesTools);
            iFormID = clsSecurity.getFormID(FormName.SalesTools);
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
            DisplayDoManulSettle();
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
        private void DisplayCustomerOrderEdit2()
        {
            frm_sasCustomerOrder_EditPO frm = new frm_sasCustomerOrder_EditPO();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayDoManulSettle()
        {
            frm_sasDeliveryOrderManuslSettle frm = new frm_sasDeliveryOrderManuslSettle();
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
            clsFormatter.setFormatForm(this, "Sales Tools", 2, iFormID);
        }

        private void btnCusOrderEdit2_Click(object sender, EventArgs e)
        {
            DisplayCustomerOrderEdit2();
        }

        private void btnProOManualSet_Click(object sender, EventArgs e)
        {
            frm_pmsProductionJobClose frm = new frm_pmsProductionJobClose();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_sasInvoiceOrderRefEdit frm = new frm_sasInvoiceOrderRefEdit();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void btnAllocationRemove_Click(object sender, EventArgs e)
        {
            frm_sasAllocationRemoveTool frm = new frm_sasAllocationRemoveTool();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
             frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm_sasDeliveryOrderEditRemark frm = new frm_sasDeliveryOrderEditRemark();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    frm_toolChequeToNewMode frm = new frm_toolChequeToNewMode();
        //    frm.MdiParent = this.MdiParent;
        //    if (frm.bNoAccess)
        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    else
        //        frm.Show();
        //}
    }
}
