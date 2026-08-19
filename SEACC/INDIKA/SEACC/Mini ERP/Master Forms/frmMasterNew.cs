using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using Digiteq.Master_Forms.ZMaster;

namespace Digiteq
{
    public partial class frmMasterNew : MettroForm
    {


        #region Form Load
        public frmMasterNew()
        {
            iFormID = clsSecurity.getFormID(FormName.MasterOther);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }

            InitializeComponent();

        }

        private void SetVisibility_Buttons(FormName enmForm, ref Button btn)
        {
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(enmForm)))
                btn.Visible = false;
        }

        private void frmMasterNew_Load(object sender, EventArgs e)
        {
            btnItemSubCategory.Text = clsConfig.sItemSubCategory;


            SetVisibility_Buttons(FormName.ZCustomerClass, ref btnCustomerClass);
            SetVisibility_Buttons(FormName.ZTwon, ref btnTown);
            SetVisibility_Buttons(FormName.ZItemSpecification, ref btnItemSpesification);
            SetVisibility_Buttons(FormName.ZItemType, ref btnItem);
            SetVisibility_Buttons(FormName.ZMachineSubCategory, ref btnMachineSubCategory);
            SetVisibility_Buttons(FormName.ZItemSubSpecification, ref btnItemSubspesification);
            SetVisibility_Buttons(FormName.ZItemCategory, ref btnItemCategory);
            SetVisibility_Buttons(FormName.zBrand, ref btnBrand);
            SetVisibility_Buttons(FormName.ZDistrict, ref btnDistrict);
            SetVisibility_Buttons(FormName.ZProvince, ref btnProvince);
            SetVisibility_Buttons(FormName.ZMachineSpecification, ref BtnMachineSpecification);
            //SetVisibility_Buttons(FormName.ZGem, ref btnGem);
            //SetVisibility_Buttons(FormName.ZMettle, ref btnMettle);
            SetVisibility_Buttons(FormName.ZRoute, ref btnRoute);
            SetVisibility_Buttons(FormName.ZArea, ref btnArea);
            SetVisibility_Buttons(FormName.zGiftVoucherMaster, ref btnGiftVoucherMaster);
            SetVisibility_Buttons(FormName.itemSubCateogry1, ref btnItemSubCategory);
            SetVisibility_Buttons(FormName.EmployeeSlabSettings, ref btnSlabCommission);
            SetVisibility_Buttons(FormName.DebitNoteType, ref btnDebitNoteType);
            SetVisibility_Buttons(FormName.ZMachineCategory, ref BtnMachineCategory);
            SetVisibility_Buttons(FormName.ChequeType, ref btnChequeType);
            SetVisibility_Buttons(FormName.ZMachineType, ref BtnMachineType);
            SetVisibility_Buttons(FormName.ZSupplierClass, ref btnSupplier);
            SetVisibility_Buttons(FormName.ZLaminationType, ref txtLaminationType);
            SetVisibility_Buttons(FormName.ZUom, ref btnUOM);
            //  SetVisibility_Buttons(FormName.PatternLength, ref btnPatternLength);
            //   SetVisibility_Buttons(FormName.PatternSize, ref btnPatternSize);
            SetVisibility_Buttons(FormName.ZUomCategory, ref BtnUomCategory);
            SetVisibility_Buttons(FormName.ZLaminationMaterialType, ref txtLaminationMaterialType);
            SetVisibility_Buttons(FormName.ZCustomerCategory, ref btnCategory);
            SetVisibility_Buttons(FormName.ZSupplierType, ref btnSupplierType);
            SetVisibility_Buttons(FormName.ZCustomerType, ref btnCategoryType);
            SetVisibility_Buttons(FormName.ZSupplierCategory, ref btnSupplierCategory);
            SetVisibility_Buttons(FormName.JobPolytheneMeterialType, ref txtPolytheneMaterialType);
            SetVisibility_Buttons(FormName.zCommissionSlabSetting, ref btnSlabCommission);
            SetVisibility_Buttons(FormName.ZMachineClass, ref BtnMachineClass);
            SetVisibility_Buttons(FormName.ZCity, ref btnCity);
            SetVisibility_Buttons(FormName.ZCountry, ref btnCountry);
            SetVisibility_Buttons(FormName.CreditNoteType, ref btnCreditNoteType);
            SetVisibility_Buttons(FormName.ZItemSubCategory, ref txtItemCategorySub);
            SetVisibility_Buttons(FormName.ZItemClass, ref btnClass);
            SetVisibility_Buttons(FormName.ZMachineSubSpecification, ref btnMachineSubSpesification);
            SetVisibility_Buttons(FormName.Cost_Center1, ref btnCostCenter1);
            SetVisibility_Buttons(FormName.Cost_Center2, ref btnCostCenter2);
            SetVisibility_Buttons(FormName.ZItemTag1, ref btnTag1);
            SetVisibility_Buttons(FormName.ZItemTag2, ref btnTag2);
            SetVisibility_Buttons(FormName.zCommissionSlabSetting, ref btnEmployeeSlabSettings);
            SetVisibility_Buttons(FormName.Cost_Center3, ref btnCostCenter3);
            SetVisibility_Buttons(FormName.Cost_Center4, ref btnCostCenter4);
            //btnCostCenter2.Text =  clsConfig.sCostCenter2;
            //btnCostCenter3.Text = clsConfig.sCostCenter3;
            //btnCostCenter4.Text = clsConfig.sCostCenter4;
        }
        #endregion

        #region Color Changes
        //create janith 2017-10-07 - to design this ui as metro ui. - just not implement this
        private void ColorChanges()
        {
            //flowLayoutPanel1.BackColor = Color.Blue;
            //flowLayoutPanel2.BackColor = Color.Blue;
            //flowLayoutPanel3.BackColor = Color.Blue;
            //flowLayoutPanel4.BackColor = Color.Blue;
            //flowLayoutPanel5.BackColor = Color.Blue;
            //flowLayoutPanel6.BackColor = Color.Blue;
            //flowLayoutPanel7.BackColor = Color.Blue;
            //flowLayoutPanel8.BackColor = Color.Blue;
            //flowLayoutPanel9.BackColor = Color.Blue;
            //flowLayoutPanel10.BackColor = Color.Blue;
            //flowLayoutPanel11.BackColor = Color.Blue;
            //flowLayoutPanel12.BackColor = Color.Blue;
        }
        #endregion

        #region Btn Machine Sub Spesification
        private void btnMachineSubSpesification_Click(object sender, EventArgs e)
        {
            frm_mtrMachineSubSpecification detail = new frm_mtrMachineSubSpecification();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region btn Customer
        private void btnCustomerClass_Click(object sender, EventArgs e)
        {
            frm_mtrCustomerClass detail = new frm_mtrCustomerClass();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region  Btn Twon
        private void btnTown_Click(object sender, EventArgs e)
        {
            frm_mtrTwon detail = new frm_mtrTwon();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region ItemSpecification
        private void btnItemSpesification_Click(object sender, EventArgs e)
        {
            frm_mtrItemSpecification detail = new frm_mtrItemSpecification();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Item
        private void btnItem_Click(object sender, EventArgs e)
        {
            frm_mtrItemType detail = new frm_mtrItemType();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();

        }
        #endregion

        #region Btn Machine Sub Category
        private void btnMachineSubCategory_Click(object sender, EventArgs e)
        {
            frm_mtrMachineSubCategory detail = new frm_mtrMachineSubCategory();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Item Sub Specification
        private void btnItemSubspesification_Click(object sender, EventArgs e)
        {
            frm_mtrItemSubSpecification detail = new frm_mtrItemSubSpecification();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn ItemCategory
        private void btnItemCategory_Click(object sender, EventArgs e)
        {
            frm_mtrItemCategory detail = new frm_mtrItemCategory();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();

        }
        #endregion

        #region Btn Brand
        private void btnBrand_Click(object sender, EventArgs e)
        {
            frm_mtrBrand detail = new frm_mtrBrand();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region  Btn District
        private void btnDistrict_Click(object sender, EventArgs e)
        {
            frm_mtrDistrict detail = new frm_mtrDistrict();
            detail.MdiParent = this.MdiParent;
            detail.Show();
        }
        #endregion

        #region  Btn Province
        private void btnProvince_Click(object sender, EventArgs e)
        {
            frm_mtrProvince detail = new frm_mtrProvince();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region MachineSpecification
        private void BtnMachineSpecification_Click(object sender, EventArgs e)
        {
            frm_mtrMachineSpecification detail = new frm_mtrMachineSpecification();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion


        #region  Btn Route
        private void btnRoute_Click(object sender, EventArgs e)
        {
            frm_masSalesAreaMaster detail = new frm_masSalesAreaMaster();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region  Btn Area
        private void btnArea_Click(object sender, EventArgs e)
        {
            frm_mtrArea detail = new frm_mtrArea();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Gift Voucher Master
        private void btnGiftVoucherMaster_Click(object sender, EventArgs e)
        {
            frm_ItemSerialNo_GiftVoucher frm = new frm_ItemSerialNo_GiftVoucher();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();

        }
        #endregion

        #region Btn ItemSubCategory 
        private void txtItemCategorySub_Click(object sender, EventArgs e)
        {
            frm_mtrItemSubCategory_New frm = new frm_mtrItemSubCategory_New(FormName.ZItemSubCategory);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorMasters, this.MdiParent);
        }
        #endregion

        #region Btn Employee Slab Settings
        private void btnEmployeeSlabSettings_Click(object sender, EventArgs e)
        {
            frm_mtrEmployeeSlabSettings frm = new frm_mtrEmployeeSlabSettings();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region btnDebitNoteType
        private void btnDebitNoteType_Click(object sender, EventArgs e)
        {
            frmDebitNoteTypeMaster detail = new frmDebitNoteTypeMaster();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Machine Category
        private void BtnMachineCategory_Click(object sender, EventArgs e)
        {
            frm_mtrMachineCategory detail = new frm_mtrMachineCategory();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        # region btnChequeType
        private void btnChequeType_Click(object sender, EventArgs e)
        {
            frm_masChequeMaster detail = new frm_masChequeMaster();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Machine Type
        private void BtnMachineType_Click(object sender, EventArgs e)
        {
            frm_mtrMachineType detail = new frm_mtrMachineType();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Supplier
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frm_mtrSupplierClass detail = new frm_mtrSupplierClass();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Job Lamination Type
        private void txtLaminationType_Click(object sender, EventArgs e)
        {
            frm_mtrJobLaminationType detail = new frm_mtrJobLaminationType();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn UOM
        private void btnUOM_Click(object sender, EventArgs e)
        {
            frm_mtrUom detail = new frm_mtrUom();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn UOM Category
        private void BtnUomCategory_Click(object sender, EventArgs e)
        {
            frm_mtrUomCategory detail = new frm_mtrUomCategory();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Lamination MaterialType
        private void txtLaminationMaterialType_Click(object sender, EventArgs e)
        {
            frm_mtrJobLaminationMaterialType detail = new frm_mtrJobLaminationMaterialType();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn category
        private void btnCategory_Click(object sender, EventArgs e)
        {
            frm_mtrCustomerCategory detail = new frm_mtrCustomerCategory();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region BtnSupplier Type
        private void btnSupplierType_Click(object sender, EventArgs e)
        {
            frm_mtrSupplierType detail = new frm_mtrSupplierType();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn category Type
        private void btnCategoryType_Click(object sender, EventArgs e)
        {
            frm_mtrCustomerCategoryType detail = new frm_mtrCustomerCategoryType();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();

        }
        #endregion

        #region Btn SupplierCategory
        private void btnSupplierCategory_Click(object sender, EventArgs e)
        {
            frm_mtrSupplierCategory detail = new frm_mtrSupplierCategory();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Polythene Material Type
        private void txtPolytheneMaterialType_Click(object sender, EventArgs e)
        {
            frm_mtrJobPolytheneMaterialType detail = new frm_mtrJobPolytheneMaterialType();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Commission Slab Settings
        private void btnSlabCommission_Click(object sender, EventArgs e)
        {
            frm_CommissionSlabSetting frm = new frm_CommissionSlabSetting();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Btn Machine Class
        private void BtnMachineClass_Click(object sender, EventArgs e)
        {
            frm_mtrMachineClass detail = new frm_mtrMachineClass();

            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region  Btn City
        private void btnCity_Click(object sender, EventArgs e)
        {
            frm_mtrCity detail = new frm_mtrCity();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Country
        private void btnCountry_Click(object sender, EventArgs e)
        {
            frm_mtrCountry detail = new frm_mtrCountry();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn ItemClass
        private void btnClass_Click(object sender, EventArgs e)
        {
            frm_mtrItemClass detail = new frm_mtrItemClass();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();

        }
        #endregion

        #region Btn Tag 1
        private void btnTag1_Click(object sender, EventArgs e)
        {
            //frm_mtrItemTag1 detail = new frm_mtrItemTag1();
            //detail.Show();

            frm_mtrItemTag1 frm = new frm_mtrItemTag1();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Btn Tag 2
        private void btnTag2_Click(object sender, EventArgs e)
        {
            //frm_mtrItemTag2 detail = new frm_mtrItemTag2();
            //detail.Show();

            frm_mtrItemTag2 frm = new frm_mtrItemTag2();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region btnCreditNoteType
        private void btnCreditNoteType_Click(object sender, EventArgs e)
        {

            frm_CreditNoteTypeMaster detail = new frm_CreditNoteTypeMaster();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }
        #endregion

        #region Btn Item Category Sub
        private void btnItemSubCategory_Click(object sender, EventArgs e)
        {
            frm_mtrItemCategory_Sub detail = new frm_mtrItemCategory_Sub();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
            //frm_mtrItemCategory_Sub frm = new frm_mtrItemCategory_Sub();
            //frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();
        }


        #endregion

        private void btnCostCenter1_Click(object sender, EventArgs e)
        {
            UC_MtrCostCenter1 frm = new UC_MtrCostCenter1();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void btnCostCenter2_Click(object sender, EventArgs e)
        {
            UC_MtrCostCenter2 frm = new UC_MtrCostCenter2();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void btnCostCenter3_Click(object sender, EventArgs e)
        {
            UC_MtrCostCenter3 frm = new UC_MtrCostCenter3();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void btnCostCenter4_Click(object sender, EventArgs e)
        {
            frm_mtrCostCenter4 detail = new frm_mtrCostCenter4();
            detail.MdiParent = this.MdiParent;
            if (detail.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), detail.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                detail.Show();
        }

        private void btnEmployeeSlabSettings_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFontType_Click(object sender, EventArgs e)
        {
            frm_mtrFont dis = new frm_mtrFont();
            dis.MdiParent = this.MdiParent;

            if (dis.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), dis.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                dis.Show();

        }

        private void btnChequeFormat_Click(object sender, EventArgs e)
        {
            frm_mtrChequeFormat frm = new frm_mtrChequeFormat();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();

        }
    }
}