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
using DataTire;

namespace Digiteq
{
    public partial class UC_Supplier : UserControl
    {
        public delegate void valueChanged();
        public event valueChanged SupplierChanged;

        public bool IsNBTenable = false;
        public bool IsVATenable = false;
        public bool IsSVATenable = false;
        public decimal CreditPeriod = 0;

        public string Supplier_ID = "default";
      

        public UC_Supplier()
        {
            InitializeComponent();
        }

        private void rdoSupplier_CheckedChanged(object sender, EventArgs e)
        {
            txtSupplierID.Tag = null;
            txtSupplierID.Clear();
          //  Refresh_PostingEntys();
        }

        public void ClearFields()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
            txtSupplierID.Tag = null;
            txtSupplierID.Clear();

            rdoOtherCr.Enabled = true;
            rdoSupplier.Enabled = true;
            rdoSupplier.Checked = true;

            IsNBTenable = false;
            IsVATenable = false;
            IsSVATenable = false;

            CreditPeriod = 0;
            Supplier_ID = "default";
        }

        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            Search_Supplier();
        }

        private void Search_Supplier()
        {
            if (rdoSupplier.Checked)
            {
                clsSearch.Search_MasterSupplier(ref txtSupplierID);
            }
            else
            {
                clsSearch.Search_MasterAccountGLCode(ref txtSupplierID, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other));
                if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
                {
                    List<tbl_accGLMaster_Supplier> oAccLink = tbl_accGLMaster_Supplier.SelectAllByGl_ID(txtSupplierID.Tag.ToString());

                    if (oAccLink.Count > 1)
                    {
                        MessageBox.Show("Sorry..! You cannot use this ledger code as a creaditor, As it is linked to more than one suppliers", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSupplierID.Tag = null;
                        txtSupplierID.Text = "";
                    }
                    else if (oAccLink.Count == 1)
                    {
                        txtSupplierID.Tag = oAccLink.FirstOrDefault().Supplier_ID;
                    }
                    else
                    {
                        tbl_genSupplierMaster oSupplier = new tbl_genSupplierMaster(txtSupplierID.Tag.ToString(), clsGenaralName.getName_AccountName(txtSupplierID.Tag.ToString()), "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, false, false, false, "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", txtSupplierID.Tag.ToString(), new byte[1], 0, false, false, false, "default", "default", "default", true);
                        oSupplier.Insert();
                        tbl_accGLMaster_Supplier oAcc = new tbl_accGLMaster_Supplier(txtSupplierID.Tag.ToString(), txtSupplierID.Tag.ToString(), true);
                        oAcc.Insert();
                    }
                }
            }

            if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
            {
                if (clsMethods_GL.CheckAccountLink_Supplier(txtSupplierID.Tag.ToString().Trim()))
                {
                    tbl_genSupplierMaster osup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString().Trim());
                    if (osup != null)
                    {
                        rdoOtherCr.Enabled = false;
                        rdoSupplier.Enabled = false;
                        if (osup.IsOtherCreditor)
                            rdoOtherCr.Checked = true;

                        txtSupplierID.Text = osup.SupplierName;
                        txtSupplierID.Tag = osup.Supplier_ID;

                        Supplier_ID = osup.Supplier_ID;
                        IsNBTenable = osup.IsNBTenable;
                        IsVATenable = osup.IsVATenable;
                        IsSVATenable = osup.IsSVATenable;
                        CreditPeriod = osup.CreditPeriod;

                        try
                        {
                            SupplierChanged();
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                    }
                }
                else
                {
                    txtSupplierID.Tag = null;
                    txtSupplierID.Clear();
                }
            }
            // Refresh_PostingEntys();
        }

        private void txtSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSupplierID_DoubleClick(sender, e);
        }

        private void btnSettlement_Click(object sender, EventArgs e)
        {
            if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString() != "default")
            {
                frm_accCreditorSettlement frm = new frm_accCreditorSettlement(FormName.accCreditorSettlement);
                frm.glbSupplier_ID = txtSupplierID.Tag.ToString();
                clsHelpMethods_Local.DisplayForm_2(frm, clsFormatter.colorAccounts);
            }
        }

        public bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierID, "Supplier"))
            {
                bStatus = true;
            }
            return bStatus;
        }

        public void SetSupplier(string _Supplier_ID,bool ISupdateMode)
        {
            Supplier_ID = _Supplier_ID;
               tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(Supplier_ID);
            if (oSupplier != null)
            {
                txtSupplierID.Tag = Supplier_ID;
                txtSupplierID.Text = clsCommon.GetForeignKeyValue(oSupplier.SupplierName);
                if (oSupplier.IsOtherCreditor)
                    rdoOtherCr.Checked = true;
            }
            rdoOtherCr.Enabled = false;
            rdoSupplier.Enabled = false;
            
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, !ISupdateMode);
        }
    }
}
