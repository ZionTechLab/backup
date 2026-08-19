using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using System.Collections;
using System.Diagnostics;
using Digiteq_Logic; 
using SEACC.WinFormControls.Forms;
using System.Text.RegularExpressions;
using SEACC.DATA.Data.MAS;
using SEACC.DATA.Domain.MAS;

namespace Digiteq
{
    public partial class frm_masItemMaster : SEACC_Form
    {
        
        string s_FileName = "";
        bool isImageUpdated = false;

        private BindingSource source = new BindingSource();
        private string sFilteQuary = "";
        public DataTable dtAllRecodes = new DataTable();
        string sid = "";

        ItemMaster oData = new ItemMaster();


        #region Form Load
        public frm_masItemMaster()
        {
         //   enmForm = _enmForm;
            InitializeComponent();
          //  Initialize();
        }
        public void init(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, false, false, true, false, false, false, false, false);

            if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 2010))
                expanderPurchaseDetails.Visible = true;
            else
                expanderPurchaseDetails.Visible = false;

            if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 2011))
                expanderSalesDetails.Visible = true;
            else
                expanderSalesDetails.Visible = false;

            if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 2012))
                expanderDiscountDetails.Visible = true;
            else
                expanderDiscountDetails.Visible = false;

            if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 2013))
                expanderAdvancedSettings.Visible = true;
            else
                expanderAdvancedSettings.Visible = false;

            if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 2014))
                expanderComponent.Visible = true;
            else
                expanderComponent.Visible = false;

            if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 2015))
                expanderSpecification.Visible = true;
            else
                expanderSpecification.Visible = false;

            if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 2016))
                expanderImportCosting.Visible = true;
            else
                expanderImportCosting.Visible = false;

            if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 2017))
                expanderOthers.Visible = true;
            else
                expanderOthers.Visible = false;

            CusDataGridViewFormat();
            CusExpanderFormat();
            CreateDataTable();
            dgvDetail.DataSource = source;
            ClearFields();
        }
        #endregion

        #region Btn New
        private void frm_masItemMaster_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
            IndicateItems_ComesToReOrderLevel();
        }
        private void UpdatePermission()
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 2010, true, false))
                pnlCost.Enabled = true;
            else
                pnlCost.Enabled = false;

            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 2011, IsUpdate,false))
                pnlSales.Enabled = true;
            else
                pnlSales.Enabled = false;

            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 2012, IsUpdate, false))
                pnlDiscount.Enabled = true;
            else
                pnlDiscount.Enabled = false;

            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 2013, IsUpdate, false))
                pnlAdvSett.Enabled = true;
            else
                pnlAdvSett.Enabled = false;

            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 2014, IsUpdate, false))
                pnlComponent.Enabled = true;
            else
                pnlComponent.Enabled = false;

            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 2015, IsUpdate, false))
                pnlSpec.Enabled = true;
            else
                pnlSpec.Enabled = false;

            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 2016, IsUpdate, false))
                pnlImpCosting.Enabled = true;
            else
                pnlImpCosting.Enabled = false;

            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 2017, IsUpdate, false))
                pnlOther.Enabled = true;
            else
                pnlOther.Enabled = false;
        }
        #endregion

        #region Btn Save
        private void frm_masItemMaster_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (ChekValidity_DuplicateNames())
                {
                    if (CheckFinishedGoodValidity())
                    {
                        if (CheckNumberValidity())
                        {
                            if (CheckAdvancedSettingsValidity())
                            {
                                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        Byte[] img = new byte[0];
                                        ValidateEmptyForeignKey();
                                        ValidateNumberInputs();

                                        if (txtItemID.TextLength > 0)
                                        {
                                            #region Update
                                            if (IsUpdate)
                                            {
                                                tbl_genItemMaster oldRecord = tbl_genItemMaster.Select(txtItemID.Text.Trim());
                                                if (oldRecord != null)
                                                {
                                                    clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.ItemMaster), oldRecord.Item_ID, "Item Master - Update - 1 : " + txtSellingPrice1.Text.Trim() + " 2 : " + txtSellingPrice2.Text.Trim() + " 3 : " + txtSellingPrice3.Text.Trim() + " 4: " + txtSellingPrice4.Text.Trim() + " WholeSales : " + txtSellingPrice5.Text.Trim() + " KiloPrice : " + txtSellingPrice6.Text.Trim());

                                                    decimal dWidth = 0, dHeight = 0, dThickness = 0, dGusset = 0;
                                                    dWidth = decimal.Parse(txtWidth.Text.Trim());
                                                    dHeight = decimal.Parse(txtHeight.Text.Trim());
                                                    dThickness = decimal.Parse(txtThickness.Text.Trim());
                                                    dGusset = decimal.Parse(txtGusset.Text.Trim());

                                                    tbl_genItemMaster detail = new tbl_genItemMaster(txtItemID.Text.Trim(), txtGenerateCode.Text.Trim(), txtItemName.Text.Trim(), txtDescription.Text.Trim(), txtDescription1.Text.Trim(), txtHS_code.Text,
                                                        txtRemarks.Text.Trim(), txtOrigion.Text.Trim(), decimal.Parse(txtMinStockLevel.Text.Trim()),
                                                    decimal.Parse(txtMaxStockLevel.Text.Trim()), decimal.Parse(txtReOrderLevel.Text.Trim()), decimal.Parse(txtReOrderQty.Text.Trim()), chkIsTIEPItem.Checked, chkImportItem.Checked, chkExporSalesItem.Checked, false, chkIsServiceItem.Checked, txtSubCategoryID.Tag.ToString(), txtCategoryID.Tag.ToString(),
                                                    txtClassID.Tag.ToString(), txtTypeID.Tag.ToString(), "default", txtBrandID.Tag.ToString(), txtSubItemID.Tag.ToString(), txtUomID.Tag.ToString(), dWidth, dHeight, dThickness,
                                                    dGusset,decimal.Parse(txtPackingSize.Text.Trim()), decimal.Parse(txtCalRateForWeight.Text.Trim()), decimal.Parse(txtCalRateForLFeat.Text.Trim()), clsAutocode.getMeasuermentTypeID(JobMeasurementType.Milimeter), !chkUnitPricing_Sales.Checked, !chkUnitPricing_Purchase.Checked,
                                                    chkDelete.Checked, chkVATInclusive.Checked, chkNBTInclusive.Checked, s_FileName, chkItemModel1.Checked, chkItemModel2.Checked, oldRecord.CompanyID, oldRecord.CompanyBranch_ID, txtTag1ID.Tag.ToString(), txtTag2ID.Tag.ToString(),
                                                    chkFinishedGood.Checked, chkSemiFinishedGood.Checked, chkRawMaterial.Checked, chkAccessories.Checked, chkPackingMaterial.Checked, chkStationary.Checked, chkSalesItem.Checked, chkFixedAsset.Checked, oldRecord.IsGiftVoucher, chkOther.Checked, txtFixedAsset.Tag.ToString(), txtPrefix.Text, int.Parse(txtCounter.Text), txtPurchaceAcc.Tag.ToString(), chkBlackList.Checked
                                                    ,txtStore.Tag.ToString(), (isImageUpdated?"U":""));
                                                    detail.Update();

                                                    var priceing = new ItemMaster_Pricing();

                                                    priceing.item_ID = detail.Item_ID;
                                                    priceing.costPrice1 = decimal.Parse(txtCostPrice.Text.Trim());
                                                    priceing.costPrice2 = 0;
                                                    priceing.lifoCostPrice = 0;
                                                    priceing.fifoCostPrice = 0;
                                                    priceing.weightedAverageCostPrice = decimal.Parse(txtWaitedAvgCost.Text.Trim());
                                                    priceing.highestPurchaseCostPrice = decimal.Parse(txtHighestCost.Text.Trim());
                                                    priceing.lowestPurchaseCostPrice = 0;
                                                    priceing.sellingPrice1 = decimal.Parse(txtSellingPrice1.Text.Trim());
                                                    priceing.sellingPrice2 = decimal.Parse(txtSellingPrice2.Text.Trim());
                                                    priceing.sellingPrice3 = decimal.Parse(txtSellingPrice3.Text.Trim());
                                                    priceing.sellingPrice4 = decimal.Parse(txtSellingPrice4.Text.Trim());
                                                    priceing.sellingPrice5 = decimal.Parse(txtSellingPrice5.Text.Trim());
                                                    priceing.sellingPrice6 = decimal.Parse(txtSellingPrice6.Text.Trim());
                                                    priceing.isVATinclusive = chkVATInclusive.Checked;
                                                    priceing.isNBTinclusive = chkNBTInclusive.Checked;
                                                    priceing.maxDiscountPct = clsValidate.Validate_DecimalNumber(txtMaxDiscountPct.Text);
                                                    priceing.maxDiscountAmt = clsValidate.Validate_DecimalNumber(txtMaxDiscountAmt.Text);
                                                    priceing.createUser_ID = clsSecurity.UserIDLoged;
                                                    priceing.createTerminal_ID = clsSecurity.TerminalID;

                                                    var result = oData.Update(priceing);

                                                    if (!result.IsSuccess)
                                                        MessageBox.Show(result.OutMsg);

                                                    #region Check Inactivated Items
                                                    if (chkDelete.Checked)
                                                    {
                                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtItemID.Text.ToString(), TxnActivity.Cancel);
                                                    }
                                                    else
                                                    {
                                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtItemID.Text.ToString(), TxnActivity.Update);
                                                    }
                                                    #endregion

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }

                                            }
                                            #endregion

                                            #region Insert
                                            else
                                            {
                                                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                    txtItemID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                                if (txtItemID.TextLength > 0)
                                                {
                                                    clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.ItemMaster), txtItemID.Text.Trim(), "Item Master - Insert - 1 : " + txtSellingPrice1.Text.Trim() + " 2 : " + txtSellingPrice2.Text.Trim() + " 3 : " + txtSellingPrice3.Text.Trim() + " 4: " + txtSellingPrice4.Text.Trim() + " WholeSales : " + txtSellingPrice5.Text.Trim() + " KiloPrice : " + txtSellingPrice6.Text.Trim());

                                                    decimal dWidth = 0, dHeight = 0, dThickness = 0, dGusset = 0;
                                                    dWidth = decimal.Parse(txtWidth.Text.Trim());
                                                    dHeight = decimal.Parse(txtHeight.Text.Trim());
                                                    dThickness = decimal.Parse(txtThickness.Text.Trim());
                                                    dGusset = decimal.Parse(txtGusset.Text.Trim());

                                                    tbl_genItemMaster detail = new tbl_genItemMaster(txtItemID.Text.Trim(), txtGenerateCode.Text.Trim(), txtItemName.Text.Trim(), txtDescription.Text.Trim(), s_FileName,// txtDescription1.Text.Trim(),
                                                        txtHS_code.Text, txtRemarks.Text.Trim(), txtOrigion.Text.Trim()
                                                      , decimal.Parse(txtMinStockLevel.Text.Trim()),
                                                        decimal.Parse(txtMaxStockLevel.Text.Trim()), decimal.Parse(txtReOrderLevel.Text.Trim()), decimal.Parse(txtReOrderQty.Text.Trim()), chkIsTIEPItem.Checked, chkImportItem.Checked, chkExporSalesItem.Checked, false, chkIsServiceItem.Checked, txtSubCategoryID.Tag.ToString(), txtCategoryID.Tag.ToString(),
                                                        txtClassID.Tag.ToString(), txtTypeID.Tag.ToString(), "default", txtBrandID.Tag.ToString(), txtSubItemID.Tag.ToString(), txtUomID.Tag.ToString(), dWidth, dHeight, dThickness,
                                                        dGusset, decimal.Parse(txtPackingSize.Text.Trim()), decimal.Parse(txtCalRateForWeight.Text.Trim()), decimal.Parse(txtCalRateForLFeat.Text.Trim()), clsAutocode.getMeasuermentTypeID(JobMeasurementType.Milimeter), !chkUnitPricing_Sales.Checked, !chkUnitPricing_Purchase.Checked, chkDelete.Checked, chkVATInclusive.Checked, chkNBTInclusive.Checked,
                                                        s_FileName, chkItemModel1.Checked, chkItemModel2.Checked, clsSecurity.CompanyID, clsSecurity.BranchID, txtTag1ID.Tag != null ? txtTag1ID.Tag.ToString() : "default", txtTag2ID.Tag != null ? txtTag2ID.Tag.ToString() : "default", chkFinishedGood.Checked, chkSemiFinishedGood.Checked, chkRawMaterial.Checked,
                                                        chkAccessories.Checked, chkPackingMaterial.Checked, chkStationary.Checked, chkSalesItem.Checked, chkFixedAsset.Checked, false, chkOther.Checked, txtFixedAsset.Tag.ToString(), txtPrefix.Text, int.Parse(txtCounter.Text), txtPurchaceAcc.Tag.ToString(), chkBlackList.Checked,txtStore.Tag.ToString(), (isImageUpdated ? "U" : ""));
                                                    detail.Insert();


                                                    var priceing = new ItemMaster_Pricing();

                                                    priceing.item_ID = detail.Item_ID;
                                                    priceing.costPrice1 = decimal.Parse(txtCostPrice.Text.Trim());
                                                    priceing.costPrice2 = 0;
                                                    priceing.lifoCostPrice = 0;
                                                    priceing.fifoCostPrice = 0;
                                                    priceing.weightedAverageCostPrice = decimal.Parse(txtWaitedAvgCost.Text.Trim());
                                                    priceing.highestPurchaseCostPrice = decimal.Parse(txtHighestCost.Text.Trim());
                                                    priceing.lowestPurchaseCostPrice = 0;
                                                    priceing.sellingPrice1 = decimal.Parse(txtSellingPrice1.Text.Trim());
                                                    priceing.sellingPrice2 = decimal.Parse(txtSellingPrice2.Text.Trim());
                                                    priceing.sellingPrice3 = decimal.Parse(txtSellingPrice3.Text.Trim());
                                                    priceing.sellingPrice4 = decimal.Parse(txtSellingPrice4.Text.Trim());
                                                    priceing.sellingPrice5 = decimal.Parse(txtSellingPrice5.Text.Trim());
                                                    priceing.sellingPrice6 = decimal.Parse(txtSellingPrice6.Text.Trim());
                                                    priceing.isVATinclusive = chkVATInclusive.Checked;
                                                    priceing.isNBTinclusive = chkNBTInclusive.Checked;
                                                    priceing.maxDiscountPct =  clsValidate.Validate_DecimalNumber(txtMaxDiscountPct.Text);
                                                    priceing.maxDiscountAmt =  clsValidate.Validate_DecimalNumber(txtMaxDiscountAmt.Text);
                                                    priceing.createUser_ID = clsSecurity.UserIDLoged;
                                                    priceing.createTerminal_ID = clsSecurity.TerminalID;

                                                    var result = oData.Update(priceing);

                                                    if (!result.IsSuccess)
                                                        MessageBox.Show(result.OutMsg);

                                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtItemID.Text.ToString(), TxnActivity.Insert);
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                    MessageBox.Show("Customer Order " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            #endregion
                                        }
                                        else
                                            MessageBox.Show("Item " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        RefreshGrid();
                                        ClearFields();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn Load Image
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("Images") == false)
            {
                Directory.CreateDirectory("Images");
            }

            try
            {
                FileDialog filedialog = new OpenFileDialog();
                filedialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.* ";
                filedialog.ShowDialog();
                s_FileName = sid.Replace("/", "-").Replace("*","-") + ".jpg";

                for (int i = 0; i < 100; i++)
                {
                    if (File.Exists("Images\\" + s_FileName))
                        s_FileName = sid.Replace("/", "-") + i + ".jpg";
                    else
                        break;
                }
                System.IO.File.Copy(filedialog.FileName, "Images\\" + s_FileName, true);
                pbxImage.Image = System.Drawing.Image.FromFile("Images\\" + s_FileName);
                isImageUpdated= true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }



        }
        #endregion

        #region Btn Expand All
        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            ItemTree.ExpandAll();
        }
        #endregion

        #region Btn Collapse
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            ItemTree.CollapseAll();
        }
        #endregion

        #region Btn Sort
        private void btnSort_Click(object sender, EventArgs e)
        {
            ItemTree.Sort();
        }
        #endregion

        #region Btn Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ItemTree.Refresh();
        }
        #endregion

        #region Btn Info
        private void btnInfor_Click(object sender, EventArgs e)
        {
            Process.Start("osk.exe");
        }
        #endregion

        #region Btn Component Add/Remove
        private void btnComponentAdd_Click(object sender, EventArgs e)
        {
            clsSearch.Search_ItemMasterByBranch(ref txtComponentID);
            if (txtComponentID.Tag != null)
            {
                if (CheckDuplicateComponent(txtComponentID.Tag.ToString()))
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(txtComponentID.Tag.ToString());
                    if (oItem != null)
                    {
                        int iRow;

                        dgvComponent.Rows.Add();
                        iRow = dgvComponent.Rows.Count - 1;

                        dgvComponent["ComponentID", iRow].Value = oItem.Item_ID;
                        dgvComponent["ComponentName", iRow].Value = oItem.ItemName;
                        dgvComponent["Remarks", iRow].Value = "";
                        dgvComponent["Qty", iRow].Value = "0";
                        dgvComponent["Price", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse("0"));
                    }
                }
            }
        }

        private void btnComponentRemove_Click(object sender, EventArgs e)
        {
            //if (dgvComponent.SelectedCells.Count != 0)
            //{
            //    if (dgvComponent.Rows.Count > 0)
            //    {
            //        dgvComponent.Rows.RemoveAt(dgvComponent.SelectedRows[0].Index);
            //    }
            //}
        }
        #endregion

        #region Treeview Tab Click
        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl2.SelectedTab == tabItemTreeView)
            {
                ItemTree.Nodes.Clear();
                populateTree();
            }
        }
        #endregion

        #region Expander Format
        private void CusExpanderFormat()
        {
            expanderAdvancedSettings.InitializeSize();
            expanderComponent.InitializeSize();
            expanderImportCosting.InitializeSize();
            expanderOthers.InitializeSize();
            expanderPurchaseDetails.InitializeSize();
            expanderSalesDetails.InitializeSize();
            expanderSpecification.InitializeSize();
            expanderDiscountDetails.InitializeSize();

            //expanderAdvancedSettings.FontColor = UI_Color;
            //expanderComponent.FontColor = UI_Color;
            //expanderImportCosting.FontColor = UI_Color;
            //expanderOthers.FontColor = UI_Color;
            //expanderPurchaseDetails.FontColor = UI_Color;
            //expanderSalesDetails.FontColor = UI_Color;
            //expanderSpecification.FontColor = UI_Color;

            //expanderAdvancedSettings.ThemeColor = clsFormatter.colorGrid;
            //expanderComponent.ThemeColor = clsFormatter.colorGrid;
            //expanderImportCosting.ThemeColor = clsFormatter.colorGrid;
            //expanderOthers.ThemeColor = clsFormatter.colorGrid;
            //expanderPurchaseDetails.ThemeColor = clsFormatter.colorGrid;
            //expanderSalesDetails.ThemeColor = clsFormatter.colorGrid;
            //expanderSpecification.ThemeColor = clsFormatter.colorGrid;
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvStores, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvSpecification, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvComponent, clsFormatter.colorGrid, UI_Color);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtItemID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtClassID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtTypeID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCategoryID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSubCategoryID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblItmID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblClassID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblTypeID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCategoryID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSubCategoryID, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGenerateCode, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPurchaceAcc, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStore, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIC_No, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtimportCostprice, true);

            if ((txtTypeID.Tag != null) && ((txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemSemiFinishedGood)) ||
                (txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemFinishedGood))))
            {
                clsCommon.SetEnableDisable_NormalTextbox(txtWidth, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtThickness, true);
                clsCommon.SetEnableDisable_NormalLabel(lblWidth, true);
                clsCommon.SetEnableDisable_NormalLabel(lblThikness, true);
            }

            txtBrandID.Tag = null;
            txtCategoryID.Tag = null;
            txtClassID.Tag = null;
            txtSubItemID.Tag = null;
            txtTypeID.Tag = null;
            txtUomID.Tag = null;
            txtSubCategoryID.Tag = null;
            txtIC_No.Tag = null;
            txtTag1ID.Tag = null;
            txtTag2ID.Tag = null;
            txtPurchaceAcc.Tag = null;
            txtFixedAsset.Tag = null;
            txtStore.Tag = null;

            txtBrandID.Clear();
            txtCategoryID.Clear();
            txtSubCategoryID.Clear();
            txtClassID.Clear();
            txtDescription.Clear();
            txtDescription1.Clear();
            txtHS_code.Clear();
            txtRemarks.Clear();
            txtItemID.Clear();
            txtItemName.Clear();
            txtOrigion.Clear();



    
            txtSellingPrice6.Clear();
            txtHighestCost.Clear();
            txtGenerateCode.Clear();
            txtCalRateForLFeat.Text = "0";
            txtCalRateForWeight.Text = "0";
            txtIC_No.Clear();
            txtimportCostprice.Clear();
            txtFixedAsset.Clear();
            txtStore.Clear();

            txtPurchaceAcc.Text = "";
            txtPrefix.Text = "";
            txtCounter.Text = "0";

            txtSubItemID.Clear();
            txtTypeID.Clear();
            txtUomID.Clear();

            txtTag1ID.Clear();
            txtTag2ID.Clear();

            txtWaitedAvgCost.Text = "0.00";
            txtFIFOCost.Text = "0.00";
            txtLIFOCost.Text = "0.00";
            txtLowestCost.Text = "0.00";
            txtHighestCost.Text = "0.00";
            txtReOrderLevel.Text = "0.00";
            txtReOrderQty.Text = "0.00";
            txtSellingPrice1.Text = "0.00";
            txtSellingPrice2.Text = "0.00";
            txtSellingPrice3.Text = "0.00";
            txtSellingPrice4.Text = "0.00";
            txtSellingPrice5.Text = "0.00";
            txtMaxStockLevel.Text = "0.00";
            txtMinStockLevel.Text = "0.00";
            txtCostPrice.Text = "0.00";
            txtSellingPrice6.Text = "0.00";
            txtimportCostprice.Text = "0.00";
            txtMaxDiscountAmt.Text = "0.00";
            txtMaxDiscountPct.Text = "0.00";
            txtWidth.Text = "0.00";
            txtThickness.Text = "0.00";
            txtHeight.Text = "0.00";
            txtGusset.Text = "0.00";
            txtPackingSize.Text = "0.00";
            chkExporSalesItem.Checked = false;
            chkImportItem.Checked = false;
            chkIsTIEPItem.Checked = false;
            chkIsServiceItem.Checked = false;
            chkUnitPricing_Sales.Checked = true;
            chkUnitPricing_Purchase.Checked = true;
            chkDelete.Checked = false;
            chkVATInclusive.Checked = false;
            chkNBTInclusive.Checked = false;
            chkFinishedGood.Checked = false;
            chkSemiFinishedGood.Checked = false;
            chkRawMaterial.Checked = false;
            chkAccessories.Checked = false;
            chkPackingMaterial.Checked = false;
            chkStationary.Checked = false;
            chkSalesItem.Checked = false;
            chkFixedAsset.Checked = false;
            chkOther.Checked = false;
            chkBlackList.Checked = false;
            HideFixedAssetFields();

            lbl_SellingPrice1.Text = clsConfig.sItemPrice1_Name;
            lbl_SellingPrice2.Text = clsConfig.sItemPrice2_Name;
            lbl_SellingPrice3.Text = clsConfig.sItemPrice3_Name;
            lbl_SellingPrice4.Text = clsConfig.sItemPrice4_Name;
            lbl_SellingPrice5.Text = clsConfig.sItemPrice5_Name;
            lbl_SellingPrice6.Text = clsConfig.sItemPrice6_Name;

            expanderComponent.Visible = clsConfig.bShowItemComponents;
            expanderImportCosting.Visible = false;
            expanderSpecification.Visible = false;


            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtItemID.Text = "<Auto Generate>";
            else
                txtItemID.Clear();

            pbxImage.Image = null;
            dgvStores.Rows.Clear();
            dgvComponent.Rows.Clear();

            txtComponentID.Clear();

            s_FileName = "";
            isImageUpdated = false;

            source.Filter = "";

            RefreshGrid();

            if (txtItemID.Enabled)
            {
                txtItemID.SelectAll();
                txtItemID.Focus();
            }

            #region Item Model
            chkItemModel1.Visible = false;
            chkItemModel2.Visible = false;

            chkItemModel1.Checked = false;
            chkItemModel2.Checked = false;
            #endregion

            UpdatePermission();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dtAllRecodes.Clear();
                dtAllRecodes.Merge(DBHandling.ExecQuery("exec tbl_genItemMasterBy_BranchID '" + clsSecurity.BranchID + "'").Tables[0]);
                source.DataSource = dtAllRecodes;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("itemCode", typeof(string));
            dtAllRecodes.Columns.Add("itemName", typeof(string));

        }

        private void RefreshGrid_Spec(string sID)
        {
            int iRow;
            dgvSpecification.Rows.Clear();

            List<tbl_zItemCategory_Sub_Specification> details = tbl_zItemCategory_Sub_Specification.SelectAllByItemCategorySub_ID(sID);
            foreach (tbl_zItemCategory_Sub_Specification detail in details)
            {
                dgvSpecification.Rows.Add();
                iRow = dgvSpecification.Rows.Count - 1;
                dgvSpecification["CategoryID", iRow].Value = detail.ItemCategorySub_ID;
                dgvSpecification["SpecificationID", iRow].Value = detail.ItemSepcification_ID;
                dgvSpecification["SpecificationValue", iRow].Value = detail.SpecificationValue;
                //dgvSpecification.Rows[iRow].DefaultCellStyle.ForeColor = GetColorForItem(detail.Item_ID);
            }
        }

        private bool IsValidItemType(string sTypeID)
        {
            bool value = false;
            if (Application.ProductName.Trim() == "epack")
            {
                if (sTypeID.Length > 0 && sTypeID != "default" && sTypeID == clsAutocode.getItemTypeID(ItemTypes.RawMaterial))
                    value = true;
            }
            else if (Application.ProductName.Trim() == "crystal")
            {
                if (sTypeID.Length > 0 && sTypeID != "default")
                    value = true;
            }
            return value;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            sid = sID;
            if (sID.Length > 0)
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    //txtItemID.Enabled = false;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtItemID, false);
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIC_No, false);

                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGenerateCode, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtClassID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtTypeID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCategoryID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSubCategoryID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtTag1ID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtTag2ID, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblItmID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblClassID, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblTypeID, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblCategoryID, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblSubCategoryID, true);

                    //asign values                    
                    txtBrandID.Tag = detail.Brand_ID;
                    txtCategoryID.Tag = detail.ItemCategory_ID;
                    txtClassID.Tag = detail.ItemClass_ID;
                    txtSubItemID.Tag = detail.SubItem_ID;
                    txtTypeID.Tag = detail.ItemType_ID;
                    txtUomID.Tag = detail.Uom_ID;
                    txtSubCategoryID.Tag = detail.ItemCategorySub_ID;
                    txtTag1ID.Tag = detail.Tag1_ID;
                    txtTag2ID.Tag = detail.Tag2_ID;
                    txtStore.Tag = detail.store_ID;

                    txtItemID.Text = detail.Item_ID;
                    txtBrandID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Brand(detail.Brand_ID));
                    txtCategoryID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemCategory(detail.ItemCategory_ID));
                    txtSubCategoryID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemCategorySub(detail.ItemCategorySub_ID));
                    txtClassID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemClass(detail.ItemClass_ID));
                    txtSubItemID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Item(detail.SubItem_ID));
                    txtTypeID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemType(detail.ItemType_ID));
                    txtUomID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(detail.Uom_ID));
                    txtStore.Text= clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.store_ID));
                    txtPurchaceAcc.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccountName(detail.ControlAcc.ToString()));
                    txtPurchaceAcc.Tag = detail.ControlAcc;

                    txtTag1ID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Tag1(detail.Tag1_ID));
                    txtTag2ID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Tag2(detail.Tag2_ID));

                    txtGenerateCode.Text = detail.GenerateCode;
                    txtDescription.Text = detail.Description;
                    txtDescription1.Text = detail.Description1;
                    txtHS_code.Text = detail.ItemHS_code;
                    txtRemarks.Text = detail.Remark;
                    txtItemID.Text = detail.Item_ID;
                    txtItemName.Text = detail.ItemName;
                    txtMaxStockLevel.Text = detail.MaxStockLevel.ToString("0.00");
                    txtMinStockLevel.Text = detail.MinStockLevel.ToString("0.00");
                    txtOrigion.Text = detail.Origin;
                    txtReOrderLevel.Text = detail.ReReoverLevel.ToString("0.00");
                    txtReOrderQty.Text = detail.ReOrderQty.ToString("0.00");
                    txtPackingSize.Text = detail.Qty.ToString("0.00");
                    txtWidth.Text = detail.Width.ToString("0.00");
                    txtHeight.Text = detail.Height.ToString("0.00");
                    txtThickness.Text = detail.Thickness.ToString("0.00");
                    txtGusset.Text = detail.Gusset.ToString("0.00");
                    txtCalRateForLFeat.Text = detail.CalculationRate_LFeet.ToString("0.00");
                    txtCalRateForWeight.Text = detail.CalculationRate_Weight.ToString("0.00");

                    //Discount details
                    tbl_genItemMaster_Discount oDisc = tbl_genItemMaster_Discount.Select(sID);
                    if (oDisc != null)
                    {
                        txtMaxDiscountAmt.Text = clsFormatter.FormatDecimal(oDisc.MaxDiscountAmt, 2);
                        txtMaxDiscountPct.Text = clsFormatter.FormatDecimal(oDisc.MaxDiscountPct, 2);
                    }
                    else
                    {
                        txtMaxDiscountAmt.Text = clsFormatter.FormatDecimal(0, 2);
                        txtMaxDiscountPct.Text = clsFormatter.FormatDecimal(0, 2);
                    }

                    //finance detail
                    tbl_genItemMaster_Pricing oFin = tbl_genItemMaster_Pricing.Select(detail.Item_ID);
                    if (oFin != null && oFin.Item_ID != "default")
                    {
                        txtCostPrice.Text = oFin.CostPrice1.ToString("0.00");
                        txtWaitedAvgCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(oFin.WeightedAverageCostPrice);
                        txtFIFOCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(oFin.FifoCostPrice);
                        txtLIFOCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(oFin.LifoCostPrice);
                        txtHighestCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(oFin.HighestPurchaseCostPrice);
                        txtLowestCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(oFin.LowestPurchaseCostPrice);

                        txtSellingPrice1.Text = oFin.SellingPrice1.ToString("0.00");
                        txtSellingPrice2.Text = oFin.SellingPrice2.ToString("0.00");
                        txtSellingPrice3.Text = oFin.SellingPrice3.ToString("0.00");
                        txtSellingPrice4.Text = oFin.SellingPrice4.ToString("0.00");
                        txtSellingPrice5.Text = oFin.SellingPrice5.ToString("0.00");
                        txtSellingPrice6.Text = oFin.SellingPrice6.ToString("0.00");
                    }
                    else
                    {
                        txtWaitedAvgCost.Text = "0.00";
                        txtFIFOCost.Text = "0.00";
                        txtLIFOCost.Text = "0.00";
                        txtHighestCost.Text = "0.00";
                        txtLowestCost.Text = "0.00";
                    }

                    chkExporSalesItem.Checked = detail.IsExportSalesItem;
                    chkImportItem.Checked = detail.IsImportItem;
                    chkIsTIEPItem.Checked = detail.IsTIEPItem;
                    chkIsServiceItem.Checked = detail.IsServiceItem;
                    chkUnitPricing_Sales.Checked = !detail.IsWeightCalculation_Sales;
                    chkUnitPricing_Purchase.Checked = !detail.IsWeightCalculation_Purchase;
                    chkDelete.Checked = detail.IsDeleted;
                    chkVATInclusive.Checked = detail.IsVatinclusive;
                    chkNBTInclusive.Checked = detail.IsNBTinclusive;
                    chkFinishedGood.Checked = detail.IsFinishGood;
                    chkSemiFinishedGood.Checked = detail.IsSemiFinishGood;
                    chkRawMaterial.Checked = detail.IsRawMeterial;
                    chkAccessories.Checked = detail.IsAccessories;
                    chkPackingMaterial.Checked = detail.IsPackingMaterial;
                    chkStationary.Checked = detail.IsStationary;
                    chkSalesItem.Checked = detail.IsSalesItem;
                    chkOther.Checked = detail.IsOther;
                    chkBlackList.Checked = detail.isBlackList;

                    chkFixedAsset.Checked = detail.IsFixedAsset;
                    txtFixedAsset.Tag = detail.Asset_GL_ID;
                    txtFixedAsset.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccountName(detail.Asset_GL_ID));
                    txtPrefix.Text = detail.AssetPrefix;
                    txtCounter.Text = detail.Counter.ToString(); ;

                    if (detail.ImagePath.Trim() != "" || detail.ImagePath != "Default")
                    {
                        if (File.Exists("Images\\" + detail.ImagePath.Trim()))
                        {
                            s_FileName = detail.ImagePath.Trim();
                            pbxImage.Image = System.Drawing.Image.FromFile("Images\\" + s_FileName);
                        }
                        else
                            pbxImage.Image = Digiteq.Properties.Resources.no_image;

                    }
                    else
                        pbxImage.Image = Digiteq.Properties.Resources.no_image;


                    if ((txtTypeID.Tag != null) && ((txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemSemiFinishedGood)) ||
                        (txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemFinishedGood))))
                    {
                        clsCommon.SetEnableDisable_NormalTextbox(txtWidth, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtThickness, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblWidth, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblThikness, false);
                    }
                    else
                    {
                        clsCommon.SetEnableDisable_NormalTextbox(txtWidth, true);
                        clsCommon.SetEnableDisable_NormalTextbox(txtThickness, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblWidth, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblThikness, true);
                    }

                    #region fill Import Costing
                    tbl_scsImportCosting oImportCosting = tbl_scsImportCosting.SelectAllByItem_ID(detail.Item_ID).FirstOrDefault();
                    if (oImportCosting != null)
                    {
                        txtIC_No.Text = oImportCosting.Ic_ID.ToString();
                        txtimportCostprice.Text = clsFormatter.FormatToCurrecyWithThousendSep(oImportCosting.ItemCost);
                    }
                    else
                    {
                        txtIC_No.Text = "";
                        txtimportCostprice.Text = "0.00";
                    }
                    #endregion

                    #region Item Model
                    chkItemModel1.Checked = detail.ItemModel1;
                    chkItemModel2.Checked = detail.ItemModel2;
                    #endregion

                    UpdatePermission();
                }
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtItemName.TextLength == 0)
            {
                strMessage += "\n" + "Item Name ";
                bStatus = false;
            }
            if (txtClassID.Text.Trim().Length == 0)
            {
                strMessage += "\n" + "Item Class ";
                bStatus = false;
            }
            if (txtTypeID.Text.Trim().Length == 0)
            {
                strMessage += "\n" + "Item Type ";
                bStatus = false;
            }
            if (txtCategoryID.Text.Trim().Length == 0)
            {
                strMessage += "\n" + "Item Category ";
                bStatus = false;
            }
            if ((txtTypeID.Tag != null) && ((txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemSemiFinishedGood)) ||
               (txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemFinishedGood))))
            {

                if (txtWidth.Text.Trim().Length == 0)
                {
                    strMessage += "\n" + "Width ";
                    bStatus = false;
                }
                if (txtThickness.Text.Trim().Length == 0)
                {
                    strMessage += "\n" + "Thickness ";
                    bStatus = false;
                }
            }
            if (txtUomID.TextLength == 0)
            {
                strMessage += "\n" + "Item UOM ";
                bStatus = false;
            }
            if (txtPurchaceAcc.TextLength == 0)
            {
                strMessage += "\n" + "Control Acc. ";
                bStatus = false;
            }

            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;

            int iCount = 0;
            foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(p => !p.IsDeleted))
            {
                if (IsUpdate)
                {
                    if (oItem.ItemName == txtItemName.Text && oItem.Item_ID != txtItemID.Text)
                        iCount++;
                }
                else
                {
                    if (oItem.ItemName == txtItemName.Text)
                    {
                        bStatus = false;
                        MessageBox.Show("This Item is already exist", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }

            if (iCount >= 1)
            {
                MessageBox.Show("This Item is already exist", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                bStatus = false;
            }

            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtCostPrice.Text.Trim()))
                {
                    strMessage += "\n Cost Price";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtMaxStockLevel.Text.Trim()))
                {
                    strMessage += "\n MaxStock Level";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtMinStockLevel.Text.Trim()))
                {
                    strMessage += "\n MinStock Level";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtReOrderLevel.Text.Trim()))
                {
                    strMessage += "\n Reorder Level";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtReOrderQty.Text.Trim()))
                {
                    strMessage += "\n Reorder Qty";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtSellingPrice1.Text.Trim()))
                {
                    strMessage += "\n Selling Price";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtSellingPrice5.Text.Trim()))
                {
                    strMessage += "\n Wholesale Price";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtimportCostprice.Text.Trim()))
                {
                    strMessage += "\n Import Cost Price";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }

        private bool CheckFinishedGoodValidity()
        {
            bool bStatus = true;
            try
            {
                if (clsConfig.bEnableFinishedGood_Validation)
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(txtItemID.Text);
                    if (oItem != null && oItem.IsFinishGood)
                    {
                        if (clsHelpMethods.Check_ProdApparel_Enable())
                        {
                            //if (tbl_prodTxJobCard.SelectAllByItem_ID_FG(oItem.Item_ID).Count > 0)
                            //{
                            //    bStatus = false;
                            //    MessageBox.Show("Can not update... \n\"" + oItem.ItemName + "\" has already been attached to BoM ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }

        private bool CheckAdvancedSettingsValidity()
        {
            bool bStatus = true;
            if (chkFinishedGood.Checked || chkSemiFinishedGood.Checked || chkRawMaterial.Checked || chkAccessories.Checked || chkPackingMaterial.Checked || chkStationary.Checked || chkFixedAsset.Checked || chkSalesItem.Checked || chkOther.Checked || chkIsServiceItem.Checked)
                bStatus = true;
            else
            {
                bStatus = false;
                MessageBox.Show("Please select at least one item from Advanced Settings..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return bStatus;
        }

        #endregion

        #region Events KeyDown
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Items();
        }

        private void txtCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //if (txtTypeID.Tag != null)
                //    Search_CategoryIDbyTypeID();
                //else
                Search_CategoryID();

                GenarateReversTreeOrder(txtCategoryID);
                GenarateCode();
            }
        }

        private void txtClassID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ClassID();
                GenarateReversTreeOrder(txtClassID);
                GenarateCode();
            }
        }

        private void txtTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //if (txtClassID.Tag != null && txtClassID.Tag.ToString().Trim().Length > 0)
                //    clsSearch.Search_MasterItemTypeByClassID(ref txtTypeID, txtClassID.Tag.ToString().Trim());
                //else
                //{
                clsSearch.Search_MasterItemType(ref txtTypeID);
                //    GenarateReversTreeOrder(txtTypeID);
                //}
                GenarateReversTreeOrder(txtTypeID);
                GenarateCode();
            }
        }

        private void txtSubCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtCategoryID != null)
                    Search_SubCategoryIDbyCategoryID(txtCategoryID.Tag.ToString().Trim());
                else
                    Search_SubCategoryID();

                GenarateReversTreeOrder(txtSubCategoryID);
                GenarateCode();
                RefreshGrid_Spec(txtSubCategoryID.Tag.ToString());
            }
        }

        private void txtBrandID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_BrandID();

        }

        private void txtSubItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SubItemID();

        }

        private void txtUom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Uom();

        }

        private void frmItemMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        #endregion

        #region Events DoubleClick
        private void txtCategoryID_DoubleClick(object sender, EventArgs e)
        {
            Search_CategoryID();
            GenarateCode();
        }

        private void txtClassID_DoubleClick(object sender, EventArgs e)
        {
            Search_ClassID();
            GenarateReversTreeOrder(txtClassID);
            GenarateCode();
        }

        private void txtTypeID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemType(ref txtTypeID);
            GenarateCode();
        }

        private void txtSubCategory_DoubleClick(object sender, EventArgs e)
        {
            Search_SubCategoryID();
            GenarateCode();
            if (txtSubCategoryID.Tag != null && txtSubCategoryID.Tag.ToString().Trim().Length > 0)
                RefreshGrid_Spec(txtSubCategoryID.Tag.ToString());
        }

        private void txtBrandID_DoubleClick(object sender, EventArgs e)
        {
            Search_BrandID();
        }

        private void txtSubItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_SubItemID();
        }

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_Items();
        }
        private void txtUom_DoubleClick(object sender, EventArgs e)
        {
            Search_Uom();
        }

        private void txtTag1ID_DoubleClick(object sender, EventArgs e)
        {
            Search_Tag1();
        }

        private void txtTag2ID_DoubleClick(object sender, EventArgs e)
        {
            Search_Tag2();
        }
        private void txtControlAccType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode_ControlTypes(ref txtPurchaceAcc,clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtFixedAsset_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode_ControlTypes(ref txtFixedAsset, clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["itemCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                        FillDetails(sID.Trim());
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["itemCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                        ShowStores_ComesToReOrderLevel(sID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events Keyup
        private void txtItemID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemID);
        }

        #endregion

        #region Events Keyleave
        private void txtItemID_Leave(object sender, EventArgs e)
        {
            if (txtItemID.TextLength > 0 && txtItemID.Text != "<Auto Generate>")
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItemID.Text.Trim());
                if (detail != null)
                    FillDetails(txtItemID.Text.Trim());
            }
        }
        #endregion

        #region Event Leave
        private void txtThickness_Leave(object sender, EventArgs e)
        {
            GenarateCode();
        }

        private void txtWidth_Leave(object sender, EventArgs e)
        {
            GenarateCode();
        }
        #endregion

        #region Event Key Press
        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtGusset_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtMaxStockLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtMinStockLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtReOrderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtReOrderQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }



        private void txtWaitedAvgCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtRecentCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtKiloPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        #endregion

        #region Event SelectedIndexChanged

        #endregion

        #region Search Methods
        private void Search_Items()
        {
            clsSearch.Search_ItemMasterByBranch(ref txtItemID);
            if (txtItemID.Tag != null)
                FillDetails(txtItemID.Tag.ToString());
        }
        private void Search_ClassID()
        {
            clsSearch.Search_MasterItemClass(ref txtClassID);
        }
        private void Search_CategoryID()
        {
            clsSearch.Search_MasterItemCategory(ref txtCategoryID);
        }

        private void Search_CategoryIDbyTypeID()
        {
            clsSearch.Search_MasterItemCategory_ByType(ref txtCategoryID, txtTypeID.Tag.ToString());
        }

        private void Search_SubCategoryID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_ItemCategorySub();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSubCategoryID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtSubCategoryID.Tag = frmSearchMaster.s_SearchID;
                //GenarateReversTreeOrder(txtSubCategoryID);
            }
        }
        private void Search_SubCategoryIDbyCategoryID(string sID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_ItemCategorySubByCategoryID(sID);
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSubCategoryID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSubCategoryID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_BrandID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Brand();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBrandID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBrandID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_SubItemID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_ItemMaster();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSubItemID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSubItemID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_Uom()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_UomForSales();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtUomID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtUomID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_Tag1()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Tag1();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtTag1ID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtTag1ID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_Tag2()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Tag2();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtTag2ID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtTag2ID.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtUomID);
            clsCommon.ValidateForeignKey(ref txtClassID);
            clsCommon.ValidateForeignKey(ref txtCategoryID);
            clsCommon.ValidateForeignKey(ref txtSubCategoryID);
            clsCommon.ValidateForeignKey(ref txtTypeID);
            clsCommon.ValidateForeignKey(ref txtBrandID);
            clsCommon.ValidateForeignKey(ref txtSubItemID);
            //clsCommon.ValidateForeignKey(ref txtControlAccType);
            clsCommon.ValidateForeignKey(ref txtFixedAsset);
            clsCommon.ValidateForeignKey(ref txtStore);
        }
        #endregion

        #region Validate Empty Number Fields
        private void ValidateNumberInputs()
        {
            clsCommon.ValidateDeciamlValue(ref txtSellingPrice1);
            clsCommon.ValidateDeciamlValue(ref txtSellingPrice2);
            clsCommon.ValidateDeciamlValue(ref txtSellingPrice3);
            clsCommon.ValidateDeciamlValue(ref txtSellingPrice4);
            clsCommon.ValidateDeciamlValue(ref txtMinStockLevel);
            clsCommon.ValidateDeciamlValue(ref txtMaxStockLevel);
            clsCommon.ValidateDeciamlValue(ref txtReOrderLevel);
            clsCommon.ValidateDeciamlValue(ref txtReOrderQty);
            clsCommon.ValidateDeciamlValue(ref txtSellingPrice5);
            clsCommon.ValidateDeciamlValue(ref txtWaitedAvgCost);
            clsCommon.ValidateDeciamlValue(ref txtHighestCost);
            clsCommon.ValidateDeciamlValue(ref txtSellingPrice6);
            clsCommon.ValidateDeciamlValue(ref txtCostPrice);
            clsCommon.ValidateDeciamlValue(ref txtWidth);
            clsCommon.ValidateDeciamlValue(ref txtHeight);
            clsCommon.ValidateDeciamlValue(ref txtThickness);
            clsCommon.ValidateDeciamlValue(ref txtGusset);
            clsCommon.ValidateDeciamlValue(ref textBox6);
        }
        #endregion

        #region Check Duplicate Component Validity
        private bool CheckDuplicateComponent(string sComponent)
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                foreach (DataGridViewRow row in dgvComponent.Rows)
                {
                    string sComponent_Grid = clsValidate.ValidateGridValue(dgvComponent, "ComponentID", row.Index, "").ToString();
                    if (sComponent_Grid == sComponent)
                    {
                        strMessage += "\n" + " You Cannot Enter Same Items ";
                        bStatus = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Genarate Search Code
        private void GenarateCode()
        {
            try
            {
                string sCode = "";
                if (txtClassID.Tag != null)
                {
                    tbl_zItemClass clsDetail = tbl_zItemClass.Select(txtClassID.Tag.ToString());
                    if (clsDetail.Prefrix != null)
                        sCode += clsDetail.Prefrix.ToUpper() + "/";
                }
                if (txtTypeID.Tag != null)
                {
                    tbl_zItemType typDetail = tbl_zItemType.Select(txtTypeID.Tag.ToString());
                    if (typDetail.Prefrix != null)
                        sCode += typDetail.Prefrix.ToUpper() + "/";
                }
                if (txtCategoryID.Tag != null)
                {
                    tbl_zItemCategory catDetail = tbl_zItemCategory.Select(txtCategoryID.Tag.ToString());
                    if (catDetail.Prefrix != null)
                        sCode += catDetail.Prefrix.ToUpper() + "/";
                }
                if (txtSubCategoryID.Tag != null)
                {
                    tbl_zItemCategory_Sub subDetail = tbl_zItemCategory_Sub.Select(txtSubCategoryID.Tag.ToString());
                    if (subDetail.Prefrix != null)
                        sCode += subDetail.Prefrix.ToUpper() + "/";
                }
                if ((txtTypeID.Tag != null) && ((txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemSemiFinishedGood)) ||
                (txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemFinishedGood))))
                {
                    string sTmp = "";
                    decimal dWidth = 0, dThickness = 0;
                    if (clsCommon.isCurrency(txtWidth.Text.Trim()) && txtWidth.Text.Trim().Length > 0)
                        dWidth = decimal.Parse(txtWidth.Text.Trim());
                    if (clsCommon.isCurrency(txtThickness.Text.Trim()) && txtThickness.Text.Trim().Length > 0)
                        dThickness = decimal.Parse(txtThickness.Text.Trim());
                    if (dWidth > 0)
                    {
                        sTmp = clsFormatter.FormatToNumberNoDecimal(dWidth) + "X" + sTmp;
                    }
                    if (dThickness > 0 && sTmp.Trim().Length > 0)
                    {
                        sTmp = sTmp + clsFormatter.FormatToNumberNoDecimal(dThickness);
                    }
                    else if (dThickness > 0)
                    {
                        sTmp = sTmp + "X" + clsFormatter.FormatToNumberNoDecimal(dThickness);
                    }

                    if (sTmp.Trim().Length > 0)
                    {
                        sCode += sTmp;
                    }

                }
                else
                {
                    sCode += txtItemName.Text.Trim().ToUpper();
                }

                txtGenerateCode.Text = sCode.Trim();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Genarate Revers Tree Order
        private void GenarateReversTreeOrder(TextBox argTextBox)
        {
            string sTag = "Null";
            if (argTextBox.Tag != null)
                sTag = argTextBox.Tag.ToString();

            txtSubCategoryID.Tag = null;
            txtSubCategoryID.Clear();
            txtCategoryID.Tag = null;
            txtCategoryID.Clear();
            txtTypeID.Tag = null;
            txtTypeID.Clear();
            txtClassID.Tag = null;
            txtClassID.Clear();
            argTextBox.Tag = sTag;
            try
            {
                if (argTextBox.Name == txtSubCategoryID.Name && argTextBox.Tag != null)
                {
                    tbl_zItemCategory_Sub subDetail = tbl_zItemCategory_Sub.Select(argTextBox.Tag.ToString());
                    if (subDetail != null)
                    {
                        txtSubCategoryID.Tag = subDetail.ItemCategorySub_ID;
                        txtSubCategoryID.Text = subDetail.CategorySubName;
                        tbl_zItemCategory catDetail = tbl_zItemCategory.Select(subDetail.ItemCategory_ID);
                        if (catDetail != null)
                        {
                            txtCategoryID.Tag = catDetail.ItemCategory_ID;
                            txtCategoryID.Text = catDetail.CategoryName;
                            tbl_zItemType typDetail = tbl_zItemType.Select(catDetail.ItemType_ID);
                            if (typDetail != null)
                            {
                                txtTypeID.Tag = typDetail.ItemType_ID;
                                txtTypeID.Text = typDetail.TypeName;
                                tbl_zItemClass clsDetail = tbl_zItemClass.Select(typDetail.ItemClass_ID);
                                if (clsDetail != null)
                                {
                                    txtClassID.Tag = clsDetail.ItemClass_ID;
                                    txtClassID.Text = clsDetail.ClassName;
                                }
                            }
                        }
                    }
                }
                if (argTextBox.Name == txtCategoryID.Name && argTextBox.Tag != null)
                {
                    tbl_zItemCategory catDetail = tbl_zItemCategory.Select(argTextBox.Tag.ToString());
                    if (catDetail != null)
                    {
                        txtCategoryID.Tag = catDetail.ItemCategory_ID;
                        txtCategoryID.Text = catDetail.CategoryName;
                        tbl_zItemType typDetail = tbl_zItemType.Select(catDetail.ItemType_ID);
                        if (typDetail != null)
                        {
                            txtTypeID.Tag = typDetail.ItemType_ID;
                            txtTypeID.Text = typDetail.TypeName;
                            tbl_zItemClass clsDetail = tbl_zItemClass.Select(typDetail.ItemClass_ID);
                            if (clsDetail != null)
                            {
                                txtClassID.Tag = clsDetail.ItemClass_ID;
                                txtClassID.Text = clsDetail.ClassName;
                            }
                        }
                    }
                }
                if (argTextBox.Name == txtTypeID.Name && argTextBox.Tag != null)
                {
                    tbl_zItemType typDetail = tbl_zItemType.Select(argTextBox.Tag.ToString());
                    if (typDetail != null)
                    {
                        txtTypeID.Tag = typDetail.ItemType_ID;
                        txtTypeID.Text = typDetail.TypeName;
                        tbl_zItemClass clsDetail = tbl_zItemClass.Select(typDetail.ItemClass_ID);
                        if (clsDetail != null)
                        {
                            txtClassID.Tag = clsDetail.ItemClass_ID;
                            txtClassID.Text = clsDetail.ClassName;
                        }
                    }
                }
                if (argTextBox.Name == txtClassID.Name && argTextBox.Tag != null)
                {
                    tbl_zItemClass clsDetail = tbl_zItemClass.Select(argTextBox.Tag.ToString());
                    if (clsDetail != null)
                    {
                        txtClassID.Tag = clsDetail.ItemClass_ID;
                        txtClassID.Text = clsDetail.ClassName;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog(iFormID.ToString() + " - ", -1, ex);
            }
        }
        #endregion

        #region Check Change Events
        private void chkFinishedGood_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFinishedGood.Checked)
                chkSalesItem.Checked = true;
        }

        private void chkFixedAsset_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFixedAsset.Checked)
                VisibleFixedAssetFields();
            else
                HideFixedAssetFields();
        }
        #endregion

        #region Enable / Disable Fixed asset fields
        private void VisibleFixedAssetFields()
        {
            txtFixedAsset.Visible = true;
            txtPrefix.Visible = true;
            txtCounter.Visible = true;
            label29.Visible = true;
            label25.Visible = true;
        }

        private void HideFixedAssetFields()
        {
            txtFixedAsset.Visible = false;
            txtPrefix.Visible = false;
            txtCounter.Visible = false;
            label29.Visible = false;
            label25.Visible = false;
        }
        #endregion


        #region BindingSource Filtering
        private void createFilterQuary(TextBox argText)
        {
            try
            {
                 string value = txtItemName.Text.Trim();
                string sCheckedValue = clsHelpMethods.CheckValue(value);
                source.Filter = " itemName LIKE '%" + sCheckedValue + "%'";
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            string value = txtItemName.Text.Trim();
            string sCheckedValue = clsHelpMethods.CheckValue(value);
            source.Filter = " itemName LIKE '%" + sCheckedValue + "%'";
        }

        #region populate Tree
        private void populateTree()
        {
            List<tbl_zItemClass> mainDetails = tbl_zItemClass.SelectAll();

            foreach (tbl_zItemClass detail in mainDetails)
            {
                if (detail.ItemClass_ID != "default")
                {

                    TreeNode TParent = new TreeNode(detail.ClassName, 2, 2);
                    TParent.ForeColor = Color.Blue;

                    List<tbl_zItemType> subDetails = tbl_zItemType.SelectAllByItemClass_ID(detail.ItemClass_ID);
                    foreach (tbl_zItemType Sdetail in subDetails)
                    {
                        TreeNode SubItem = new TreeNode(Sdetail.TypeName, 6, 6);
                        SubItem.ForeColor = Color.BlueViolet;

                        List<tbl_zItemCategory> subsubDetails = tbl_zItemCategory.SelectAllByItemType_ID(Sdetail.ItemType_ID);
                        foreach (tbl_zItemCategory ssdetail in subsubDetails)
                        {
                            TreeNode SubSubItem = new TreeNode(ssdetail.CategoryName, 7, 7);
                            SubSubItem.ForeColor = Color.DarkCyan;

                            foreach (tbl_genItemMaster item in tbl_genItemMaster.SelectAllByItemCategory_ID(ssdetail.ItemCategory_ID).Where(p => p.CompanyBranch_ID == clsSecurity.BranchID))
                            {
                                TreeNode oItem = new TreeNode(item.ItemName, 8, 8);
                                oItem.Tag = item.Item_ID;
                                oItem.ForeColor = Color.Black;

                                SubSubItem.Nodes.Add(oItem);
                            }
                            SubItem.Nodes.Add(SubSubItem);
                        }
                        TParent.Nodes.Add(SubItem);
                    }
                    ItemTree.Nodes.Add(TParent);
                }
            }
        }
        #endregion

        #region Treeview Event
        private void ItemTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
                FillDetails(e.Node.Tag.ToString());
        }
        #endregion


        #region Validate Selling Price Vs Cost Price
        private void txtSellingPrice1_Leave(object sender, EventArgs e)
        {
            CheckSellAndCostPrices(ref txtCostPrice, ref txtSellingPrice1);
        }

        private void txtKiloPrice_Leave(object sender, EventArgs e)
        {
            CheckSellAndCostPrices(ref txtCostPrice, ref txtSellingPrice6);
        }

        private void txtWholeSalePrice_Leave(object sender, EventArgs e)
        {
            CheckSellAndCostPrices(ref txtCostPrice, ref txtSellingPrice5);
        }

        private void txtSellingPrice2_Leave(object sender, EventArgs e)
        {
            CheckSellAndCostPrices(ref txtCostPrice, ref txtSellingPrice2);
        }

        private void txtSellingPrice3_Leave(object sender, EventArgs e)
        {
            CheckSellAndCostPrices(ref txtCostPrice, ref txtSellingPrice3);
        }

        private void txtSellingPrice4_Leave(object sender, EventArgs e)
        {
            CheckSellAndCostPrices(ref txtCostPrice, ref txtSellingPrice4);
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            CheckSellAndCostPrices(ref txtCostPrice, ref textBox6);
        }

        private void CheckSellAndCostPrices(ref TextBox tbox_Cost, ref TextBox tbox_Sell)
        {
            decimal dSell = clsValidate.DecimalValidate(tbox_Sell);
            decimal dCost = clsValidate.DecimalValidate(tbox_Cost);

            if (clsConfig.bValidateCostPriceVsSellPrice && dSell != 0 && dSell < dCost)
            {
                MessageBox.Show("Selling Price can't be less than Cost Price", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbox_Sell.Text = "0.00";
                tbox_Sell.Focus();
            }
            else
                tbox_Sell.Text = clsFormatter.FormatDecimalPlaces_UnitPrice(dSell);
        }
        #endregion

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                createFilterQuary(txtItemName);
        }

        private void txtItemName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                createFilterQuary(txtItemName);
        }

        private void IndicateItems_ComesToReOrderLevel()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = clsValidate.ValidateGridValue(dgvDetail, "itemCode", row.Index, "default");
                    if (clsHelpMethods.Is_ReachtoReOrderLevel(sItemID))
                    {
                        this.dgvDetail.Rows[row.Index].DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#673800");
                    }
                }
            }
            catch (Exception e)
            {
                SEACCException.Show(e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ShowStores_ComesToReOrderLevel(string sItemId)
        {
            string sMsg = "";
            foreach (DataRow row in clsHelpMethods.GetItemList_ReachtoReOrderLevel(sItemId).Rows)
            {
                //string sItemCode = clsValidate.ValidateRowValue(row, "Item_ID", "");
                //string sItem_Name = clsValidate.ValidateRowValue(row, "Item_Name", "");
                string sStore_ID = clsValidate.ValidateRowValue(row, "Store_ID", "");
                string sStore_Name = clsValidate.ValidateRowValue(row, "Store_Name", "");
                string sUoM_Name = clsValidate.ValidateRowValue(row, "UoM_Name", "");
                string sReorderLevelQty = clsValidate.ValidateRowValue(row, "ReorderLevelQty", "0.00");
                string sCurrentQty = clsValidate.ValidateRowValue(row, "CurrentQty", "0.00");

                sMsg += "<<" + sStore_ID + " - " + sStore_Name + ">> " + "\n - Reorder Level:" + sReorderLevelQty + " || Current Qty:" + sCurrentQty + " " + sUoM_Name + "\n";
            }

            if (sMsg.Length > 3)
                MessageBox.Show(sMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPackingSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtStore_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtStore, true);
        }
    }
}