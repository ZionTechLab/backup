using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using Digiteq.Transaction_Forms.BSS;

using Digiteq.Transaction_Forms.BSS.Tools_And_Views;

namespace Digiteq
{
    public partial class frm_bpsTools : MettroForm
    {
                
        public bool bNoAccess;
        string sFormConfigCode;
        public int iFormID;
 

        public frm_bpsTools()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.BillsTools);
            iFormID = clsSecurity.getFormID(FormName.BillsTools);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_bpsTools_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Bills Tools", 2, iFormID);
            ThemeColor = clsFormatter.colorBills;

            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.ChequeToNewMode_NewVersion)))
            //    btn_ChequesToNew_new.Visible = false;
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.CashDepositCancelation_NewVersion)))
            //    btn_CashDepositCancelation_new.Visible = false;
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.ChequeToNewMode)))
                btn_ChequesToNew_old.Visible = false;
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.CashDepositCancelation)))
                btn_CashDepositCancelation_old.Visible = false;
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.RepresentableChqUpdate)))
                btnRtnChqEdit.Visible = false;
        }

        private void btn_ChequesToNew_Click(object sender, EventArgs e)
        {
            frm_toolChequeToNewMode frm = new frm_toolChequeToNewMode();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void btn_CashDepositCancelation_Click(object sender, EventArgs e)
        {
            frm_bpsCashDepositCancelation frm = new frm_bpsCashDepositCancelation();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }




        private void btnRtnChqEdit_Click(object sender, EventArgs e)
        {
            var frm = new frm_RepresentableChqUpdate();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
    }
}