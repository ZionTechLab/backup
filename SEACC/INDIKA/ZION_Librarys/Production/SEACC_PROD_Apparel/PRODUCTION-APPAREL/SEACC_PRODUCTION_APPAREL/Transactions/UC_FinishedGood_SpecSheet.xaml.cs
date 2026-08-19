using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Common;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_PRODUCTION_APPAREL.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_APPAREL
{
    public partial class UC_FinishedGood_SpecSheet : UserControl
    {
        #region Class Variables
        DataTable dt_ComptetProduct = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_FinishedGood_SpecSheet()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_ProductSpecSheet;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("LN");
            dgr_Main.dt.Columns.Add("ItemID");
            dgr_Main.dt.Columns.Add("ItemCode");
            dgr_Main.dt.Columns.Add("ItemName");
            dgr_Main.dt.Columns.Add("ItemDescription");
            dgr_Main.dt.Columns.Add("Prepared_By");
            dgr_Main.dt.Columns.Add("Prepared_Date");
            dgr_Main.dt.Columns.Add("Modified_By");
            dgr_Main.dt.Columns.Add("Modified_Date");
            dgr_Main.dt.Columns.Add("Is_Cancelled");
            #endregion

            #region Initialize Compettive Product Detail Table
            dt_ComptetProduct.Columns.Add("LineNo");
            dt_ComptetProduct.Columns.Add("Brand_ID");
            dt_ComptetProduct.Columns.Add("Brand_Name");
            dt_ComptetProduct.Columns.Add("Model_ID");
            dt_ComptetProduct.Columns.Add("Model_Name");
            dt_ComptetProduct.Columns.Add("Competitor_Name");
            dt_ComptetProduct.Columns.Add("Country_ID");
            dt_ComptetProduct.Columns.Add("Country_Name");
            dt_ComptetProduct.Columns.Add("MRP");
            dt_ComptetProduct.Columns.Add("Price1");
            dt_ComptetProduct.Columns.Add("Price2");
            dt_ComptetProduct.Columns.Add("Price3");
            dt_ComptetProduct.Columns.Add("Price4");
            dt_ComptetProduct.Columns.Add("Remarks");
            #endregion

            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, false, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LN", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Finished Good ID", "ItemID", 80, false);
            dgr_Main.Add_DatagridColoumn("Finished Good Code", "ItemCode", 200, false);
            dgr_Main.Add_DatagridColoumn("Finished Good Name", "ItemName", 200);
            dgr_Main.Add_DatagridColoumn("Finished Good Description", "ItemDescription", 250);
            dgr_Main.Add_DatagridColoumn("Prepared By", "Prepared_By", 100);
            dgr_Main.Add_DatagridColoumn("Prepared Date", "Prepared_Date", 100);
            dgr_Main.Add_DatagridColoumn("Modified By", "Modified_By", 100);
            dgr_Main.Add_DatagridColoumn("Modified Date", "Modified_Date", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "Is_Cancelled", 100, false);
            #endregion

            #region Initialize Compettive Product Detail Grid
            dgr_CopmeteProdInfo.ItemsSource = dt_ComptetProduct.DefaultView;
            #endregion

            #endregion

            Clearfields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }

        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            Clearfields();
            RefreshGrid();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (txtItemID.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_apparelTxFinishedGoodSpecsSheet oItemSpec = tbl_prod_apparelTxFinishedGoodSpecsSheet.Select(txtItemID.Tag.ToString());
                            if (oItemSpec != null)
                            {
                                int iProdJobBoM_Count = tbl_prodTxJobCard.SelectAllByItem_ID_FG(oItemSpec.Item_ID_FG).Where(r => r.ProdJobStatus != (int)prod_BoM_Status.Obsolete).ToList().Count;
                                if (iProdJobBoM_Count == 0)
                                {
                                    if (!oItemSpec.IsApproved)
                                    {
                                        if (!oItemSpec.IsCanceled)
                                        {
                                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                            if (bMessegeBoxResult)
                                            {
                                                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                                frmTwoStepVerify.ShowDialog();
                                                if (frmTwoStepVerify.bVerified)
                                                {
                                                    oItemSpec.IsCanceled = true;
                                                    oItemSpec.DateCanceled = clsSecurity.getServerDateTime();
                                                    oItemSpec.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                    oItemSpec.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                    oItemSpec.Update();

                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oItemSpec.Item_ID_FG);
                                                    if (oItem != null)
                                                    {
                                                        oItem.IsDeleted = true;
                                                        oItem.Update();
                                                    }

                                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                                }
                                                frmTwoStepVerify.Close();
                                            }
                                            Clearfields();
                                            RefreshGrid();
                                        }
                                        else
                                        {
                                            SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyCanceled);
                                        }
                                    }
                                    else
                                    {
                                        SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyApproved);
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Cannot Cancel..", "Selected Finised Good has already been attached to BoMs.", MessageBoxButton.OK, "Red");
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string sItem_ID_FG = "";
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.Wait;
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_genItemMaster oOldFG_Item = tbl_genItemMaster.Select(txtItemID.Tag.ToString());
                            tbl_prod_apparelTxFinishedGoodSpecsSheet oOldFG_Sepec = tbl_prod_apparelTxFinishedGoodSpecsSheet.Select(txtItemID.Text);
                            if (oOldFG_Item != null && oOldFG_Sepec != null)
                            {
                                //Need to check if BoM has been attached or not.
                                int iProdJobBoM_Count = tbl_prodTxJobCard.SelectAllByItem_ID_FG(oOldFG_Item.Item_ID).Where(r => r.ProdJobStatus != (int)prod_BoM_Status.Obsolete).ToList().Count;
                                if (iProdJobBoM_Count == 0)
                                {
                                    tbl_genItemMaster oFGItem = new tbl_genItemMaster(txtItemID.Text, txtFinishGoodSalesCode.Text, txtFinishGoodSalesName.Text, txtFinishGoodDescription.Text,
                                        oOldFG_Item.Description1, oOldFG_Item.ItemHS_code, oOldFG_Item.Remark, oOldFG_Item.Origin,
                                        oOldFG_Item.MinStockLevel, oOldFG_Item.MaxStockLevel, oOldFG_Item.ReReoverLevel, oOldFG_Item.ReOrderQty, oOldFG_Item.IsTIEPItem, oOldFG_Item.IsImportItem, oOldFG_Item.IsExportSalesItem, oOldFG_Item.IsCombinationMaterail, oOldFG_Item.IsServiceItem, oOldFG_Item.ItemCategorySub_ID,
                                        txtProdCategory.Tag != null ? txtProdCategory.Tag.ToString() : "default",
                                        txtJobName.Tag != null ? txtJobName.Tag.ToString() : "default",
                                        txtProdRange.Tag != null ? txtProdRange.Tag.ToString() : "default",
                                        oOldFG_Item.RoleType_ID, oOldFG_Item.Brand_ID, oOldFG_Item.SubItem_ID, txtFinishGoodQtyUOM.Tag.ToString(), oOldFG_Item.Width, oOldFG_Item.Height, oOldFG_Item.Thickness, oOldFG_Item.Gusset, oOldFG_Item.Qty, oOldFG_Item.CalculationRate_Weight, oOldFG_Item.CalculationRate_LFeet, oOldFG_Item.MeasureType_ID,
                                        oOldFG_Item.IsWeightCalculation_Sales, oOldFG_Item.IsWeightCalculation_Purchase, oOldFG_Item.IsDeleted, oOldFG_Item.IsVatinclusive, oOldFG_Item.IsNBTinclusive, oOldFG_Item.ImagePath, oOldFG_Item.ItemModel1, oOldFG_Item.ItemModel2, clsSecurity.CompanyID, clsSecurity.BranchID, oOldFG_Item.Tag1_ID, oOldFG_Item.Tag2_ID, true, oOldFG_Item.IsSemiFinishGood, oOldFG_Item.IsRawMeterial, oOldFG_Item.IsAccessories, oOldFG_Item.IsPackingMaterial, oOldFG_Item.IsStationary, oOldFG_Item.IsSalesItem, oOldFG_Item.IsFixedAsset, oOldFG_Item.IsGiftVoucher, oOldFG_Item.IsOther, oOldFG_Item.Asset_GL_ID, oOldFG_Item.AssetPrefix, oOldFG_Item.Counter, oOldFG_Item.ControlAcc);
                                    oFGItem.Update();

                                    tbl_prod_apparelTxFinishedGoodSpecsSheet oNewFGItem_Spec = new tbl_prod_apparelTxFinishedGoodSpecsSheet(txtItemID.Text,
                                        txtItemID_Template.Tag != null ? txtItemID_Template.Tag.ToString() : "default",
                                       cmbProdIndustry.GetSelectedIndex(), //Production Industry
                                        txtCustomer.Tag != null ? txtCustomer.Tag.ToString() : "default",
                                        txtRemark1.Text, txtRemark2.Text, txtRemark3.Text, txtRemark4.Text, txtRemark5.Text, txtFinishGoodQtyUOM.Tag != null ? txtFinishGoodQtyUOM.Tag.ToString() : "default", txtFinishGoodWeiUOM.Tag != null ? txtFinishGoodWeiUOM.Tag.ToString() : "default",
                                        txtProdSize.Tag != null ? txtProdSize.Tag.ToString() : "default",
                                        txtJobType.Tag != null ? txtJobType.Tag.ToString() : "default",
                                        txtProdColour.Tag != null ? txtProdColour.Tag.ToString() : "default", oOldFG_Sepec.MeltingPoint, oOldFG_Sepec.ChemFormula, oOldFG_Sepec.Density,
                                        oOldFG_Sepec.IsChecked, oOldFG_Sepec.IsApproved, oOldFG_Sepec.IsCanceled, oOldFG_Sepec.CreateUser_ID, clsSecurity.UserIDLoged, oOldFG_Sepec.CheckedUser_ID, oOldFG_Sepec.ApprovedUser_ID, oOldFG_Sepec.CanceldUser_ID, oOldFG_Sepec.DateCreate,
                                        clsSecurity.getServerDateTime(), oOldFG_Sepec.DateChecked, oOldFG_Sepec.DateApproved, oOldFG_Sepec.DateCanceled,
                                        oOldFG_Sepec.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldFG_Sepec.CheckedUserTerminal_ID, oOldFG_Sepec.ApprovedUserTerminal_ID, oOldFG_Sepec.CanceledUserTerminal_ID, clsSecurity.CompanyID, clsSecurity.BranchID,
                                        oOldFG_Sepec.Prefix,
                                        txtDescriptionSuffix.IsChecked ? txtDescriptionSuffix.Text : "",
                                        txtFabricLayer1.IsChecked ? txtFabricLayer1.Tag.ToString() : "default",
                                        txtFabricLayer2.IsChecked ? txtFabricLayer2.Tag.ToString() : "default",
                                        txtFabricLayer3.IsChecked ? txtFabricLayer3.Tag.ToString() : "default",
                                        txtPaddingLayer1.IsChecked ? txtPaddingLayer1.Tag.ToString() : "default",
                                        txtPaddingLayer2.IsChecked ? txtPaddingLayer2.Tag.ToString() : "default",
                                        oOldFG_Sepec.Layer6,
                                        txtFilling1.IsChecked ? txtFilling1.Tag.ToString() : "default",
                                        txtFilling2.IsChecked ? txtFilling2.Tag.ToString() : "default",
                                        oOldFG_Sepec.Filling3
                                        );
                                    oNewFGItem_Spec.Update();

                                    tbl_prod_apparelTxCompetitiveProductInfo.DeleteAllByItem_ID_FG(txtItemID.Tag.ToString());
                                    foreach (DataRow row in dt_ComptetProduct.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        string sBrand_ID = clsValidate.ValidateRowValue(row, "Brand_ID", "");
                                        string sModel_ID = clsValidate.ValidateRowValue(row, "Model_ID", "default");
                                        string sCountry_ID = clsValidate.ValidateRowValue(row, "Country_ID", "default");
                                        string sCompany = clsValidate.ValidateRowValue(row, "Competitor_Name", "");
                                        string sRemark = clsValidate.ValidateRowValue(row, "Remarks", "");
                                        decimal dMRP = clsValidate.ValidateRowValue(row, "MRP", 0);
                                        decimal dPrice1 = clsValidate.ValidateRowValue(row, "Price1", 0m);
                                        decimal dPrice2 = clsValidate.ValidateRowValue(row, "Price2", 0m);
                                        decimal dPrice3 = clsValidate.ValidateRowValue(row, "Price3", 0m);
                                        decimal dPrice4 = clsValidate.ValidateRowValue(row, "Price4", 0m);

                                        tbl_prod_apparelTxCompetitiveProductInfo oItemCopmtInfo = new tbl_prod_apparelTxCompetitiveProductInfo(iLine_no, txtItemID.Tag.ToString(), sBrand_ID, sModel_ID, sCompany, sCountry_ID, sRemark, dPrice1, dPrice2, dPrice3, dPrice4, dMRP, false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID);
                                        oItemCopmtInfo.Insert();
                                    }

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Cannot Update..", "BoM has already been created for this selected finished good", MessageBoxButton.OK, "Red");
                                }
                            }
                            sItem_ID_FG = oOldFG_Item.Item_ID;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_genItemMaster oNewFGItem = new tbl_genItemMaster(txtItemID.Text, txtFinishGoodSalesCode.Text, txtFinishGoodSalesName.Text, txtFinishGoodDescription.Text,
                                   "", "", "", "",
                                   0, 0, 0, 0, false, false, false, false, false, "default",
                                   txtProdCategory.Tag != null ? txtProdCategory.Tag.ToString() : "default",
                                   txtJobName.Tag != null ? txtJobName.Tag.ToString() : "default",
                                   txtProdRange.Tag != null ? txtProdRange.Tag.ToString() : "default",
                                   "default", "default", "default", txtFinishGoodQtyUOM.Tag.ToString(), 0, 0, 0, 0, 0, 0, 0, "default",
                                   false, false, false, false, false, "", false, false, clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default", true, false, false, false, false, false, true, false, false, false, "default", "", 0, "default");
                            oNewFGItem.Insert();

                            tbl_genItemMaster_Pricing oNewFGItem_Finance = new tbl_genItemMaster_Pricing(oNewFGItem.Item_ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, false);
                            oNewFGItem_Finance.Insert();

                            tbl_prod_apparelTxFinishedGoodSpecsSheet oNewFGItem_Spec = new tbl_prod_apparelTxFinishedGoodSpecsSheet(txtItemID.Text,
                                txtItemID_Template.Tag != null ? txtItemID_Template.Tag.ToString() : "default",
                                cmbProdIndustry.GetSelectedIndex(), //Production Industry
                                txtCustomer.Tag != null ? txtCustomer.Tag.ToString() : "default",
                                txtRemark1.Text, txtRemark2.Text, txtRemark3.Text, txtRemark4.Text, txtRemark5.Text, txtFinishGoodQtyUOM.Tag != null ? txtFinishGoodQtyUOM.Tag.ToString() : "default", txtFinishGoodWeiUOM.Tag != null ? txtFinishGoodWeiUOM.Tag.ToString() : "default",
                                txtProdSize.Tag != null ? txtProdSize.Tag.ToString() : "default",
                                txtJobType.Tag != null ? txtJobType.Tag.ToString() : "default",
                                txtProdColour.Tag != null ? txtProdColour.Tag.ToString() : "default", "", "", "",
                                false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID,
                                "",
                                txtDescriptionSuffix.IsChecked ? txtDescriptionSuffix.Text : "",
                                txtFabricLayer1.IsChecked ? txtFabricLayer1.Tag.ToString() : "default",
                                txtFabricLayer2.IsChecked ? txtFabricLayer2.Tag.ToString() : "default",
                                txtFabricLayer3.IsChecked ? txtFabricLayer3.Tag.ToString() : "default",
                                txtPaddingLayer1.IsChecked ? txtPaddingLayer1.Tag.ToString() : "default",
                                txtPaddingLayer2.IsChecked ? txtPaddingLayer2.Tag.ToString() : "default",
                                "default",
                                txtFilling1.IsChecked ? txtFilling1.Tag.ToString() : "default",
                                txtFilling2.IsChecked ? txtFilling2.Tag.ToString() : "default",
                                "default"
                                );
                            oNewFGItem_Spec.Insert();

                            foreach (DataRow row in dt_ComptetProduct.Rows)
                            {
                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                string sBrand_ID = clsValidate.ValidateRowValue(row, "Brand_ID", "");
                                string sModel_ID = clsValidate.ValidateRowValue(row, "Model_ID", "default");
                                string sCountry_ID = clsValidate.ValidateRowValue(row, "Country_ID", "default");
                                string sCompany = clsValidate.ValidateRowValue(row, "Competitor_Name", "");
                                string sRemark = clsValidate.ValidateRowValue(row, "Remarks", "");
                                decimal dMRP = clsValidate.ValidateRowValue(row, "MRP", 0);
                                decimal dPrice1 = clsValidate.ValidateRowValue(row, "Price1", 0m);
                                decimal dPrice2 = clsValidate.ValidateRowValue(row, "Price2", 0m);
                                decimal dPrice3 = clsValidate.ValidateRowValue(row, "Price3", 0m);
                                decimal dPrice4 = clsValidate.ValidateRowValue(row, "Price4", 0m);

                                tbl_prod_apparelTxCompetitiveProductInfo oItemCopmtInfo = new tbl_prod_apparelTxCompetitiveProductInfo(iLine_no, txtItemID.Text, sBrand_ID, sModel_ID, sCompany, sCountry_ID, sRemark, dPrice1, dPrice2, dPrice3, dPrice4, dMRP, false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID);
                                oItemCopmtInfo.Insert();
                            }

                            sItem_ID_FG = oNewFGItem_Spec.Item_ID_FG;
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    Clearfields();
                    RefreshGrid();
                    FillDetails(sItem_ID_FG);
                    Cursor = Cursors.Arrow;
                }
            }
        }

        private void btn_Approved_click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (SEACC_Form.CheckPermission_ToApproved())
                {
                    //if (CheckValidity())
                    {
                        //if (SEACC_Form.IsUpdateMode)
                        {
                            // tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
                            // if (oJob != null)
                            {
                                // if (!oJob.IsApproved1)
                                {
                                    //bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    //if (bMessegeBoxResult)
                                    //{
                                    //    frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                    //    frmTwoStepVerify.ShowDialog();
                                    //    if (frmTwoStepVerify.bVerified)
                                    //    {
                                    //        SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                    //    }
                                    //    frmTwoStepVerify.Close();
                                    //}
                                    //ClearFields();
                                    //RefreshGrid();
                                    //fillDetails(oJob.ProdJob_ID);
                                }
                                //else
                                //{
                                //    SEACCMessageBox.Show("Alreay Approved", "Selected BoM has already been approved", MessageBoxButton.OK, "Red");
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        #region Competitive Product Grid Buttons
        private void btnCPInfoAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity_CompetProdInfo())
            {
                dt_ComptetProduct.Rows.Add("0", txtBrand.Tag.ToString(), txtBrand.Text, txtModel.Tag.ToString(), txtModel.Text, txtCompany.Text, txtCountry.Tag.ToString(), txtCountry.Text,
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtMRP.Text), clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtPrice1.Text), clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtPrice2.Text), clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtPrice3.Text), clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtPrice4.Text), clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                    txtRemark6.Text);
                Clearfield_CompettiveProdInfo();
            }
        }

        private void btnCPInfoDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_CopmeteProdInfo.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_CopmeteProdInfo.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dt_ComptetProduct.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dt_ComptetProduct.Rows.Remove(item);

                    Clearfield_CompettiveProdInfo();
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dt_ComptetProduct);
            }
        }
        #endregion

        #endregion

        #region Clear Fields
        private void Clearfields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtItemID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItemID_Template, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtJobName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtJobType, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdRange, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdCategory, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdSize, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdColour, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(txtFabricLayer1, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(txtFabricLayer2, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(txtFabricLayer3, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(txtPaddingLayer1, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(txtPaddingLayer2, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(txtFilling1, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(txtFilling2, true, false, true);
            cls_Formater.SetEnableDisable_LableTextboxWithCheckBox(txtDescriptionSuffix, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodSalesCode, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodQtyUOM, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodWeiUOM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark1, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark2, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark3, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark4, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark5, true, false, true);

            txtItemID.Tag = null;
            txtItemID_Template.Tag = null;
            txtJobName.Tag = null;
            txtJobType.Tag = null;
            txtCustomer.Tag = null;
            txtProdRange.Tag = null;
            txtProdCategory.Tag = null;
            txtFabricLayer1.Tag = null;
            txtFabricLayer2.Tag = null;
            txtFabricLayer3.Tag = null;
            txtPaddingLayer1.Tag = null;
            txtPaddingLayer2.Tag = null;
            txtFilling1.Tag = null;
            txtFilling2.Tag = null;
            txtProdSize.Tag = null;
            txtProdColour.Tag = null;
            txtFinishGoodQtyUOM.Tag = null;
            txtFinishGoodWeiUOM.Tag = null;

            txtItemID.ToolTip = null;
            txtItemID_Template.ToolTip = null;
            txtJobName.ToolTip = null;
            txtJobType.ToolTip = null;
            txtCustomer.ToolTip = null;
            txtProdRange.ToolTip = null;
            txtProdCategory.ToolTip = null;
            txtFabricLayer1.ToolTip = null;
            txtFabricLayer2.ToolTip = null;
            txtFabricLayer3.ToolTip = null;
            txtPaddingLayer1.ToolTip = null;
            txtPaddingLayer2.ToolTip = null;
            txtFilling1.ToolTip = null;
            txtFilling2.ToolTip = null;
            txtProdSize.ToolTip = null;
            txtProdColour.ToolTip = null;
            txtFinishGoodQtyUOM.ToolTip = null;
            txtFinishGoodWeiUOM.ToolTip = null;

            txtItemID.Uid = "";
            txtItemID_Template.Uid = "";
            txtJobName.Uid = "";
            txtJobType.Uid = "";
            txtCustomer.Uid = "";
            txtProdRange.Uid = "";
            txtProdCategory.Uid = "";
            txtProdCategory.Uid = "";
            txtFabricLayer1.Uid = "";
            txtFabricLayer2.Uid = "";
            txtFabricLayer3.Uid = "";
            txtPaddingLayer1.Uid = "";
            txtPaddingLayer2.Uid = "";
            txtFilling1.Uid = "";
            txtFilling2.Uid = "";
            txtProdSize.Uid = "";
            txtProdColour.Uid = "";
            txtFinishGoodQtyUOM.Uid = "";
            txtFinishGoodWeiUOM.Uid = "";

            txtItemID.Text = "";
            txtItemID_Template.Text = "";
            txtJobName.Text = "";
            txtJobType.Text = "";
            txtCustomer.Text = "";
            txtProdRange.Text = "";
            txtProdCategory.Text = "";
            txtProdSize.Text = "";
            txtProdColour.Text = "";
            txtDescriptionSuffix.Text = "";
            txtFinishGoodDescription.Text = "";
            txtFinishGoodSalesCode.Text = "";
            txtFinishGoodSalesName.Text = "";
            txtFinishGoodQtyUOM.Text = "";
            txtFinishGoodWeiUOM.Text = "";
            txtFabricLayer1.Text = "";
            txtFabricLayer2.Text = "";
            txtFabricLayer3.Text = "";
            txtPaddingLayer1.Text = "";
            txtPaddingLayer2.Text = "";
            txtFilling1.Text = "";
            txtFilling2.Text = "";
            txtRemark1.Text = "";
            txtRemark2.Text = "";
            txtRemark3.Text = "";
            txtRemark4.Text = "";
            txtRemark5.Text = "";
            txtBrand.Text = "";
            txtModel.Text = "";
            txtCompany.Text = "";
            txtCountry.Text = "";

            txtDescriptionSuffix.IsChecked = false;
            txtFabricLayer1.IsChecked = false;
            txtFabricLayer2.IsChecked = false;
            txtFabricLayer3.IsChecked = false;
            txtPaddingLayer1.IsChecked = false;
            txtPaddingLayer2.IsChecked = false;
            txtFilling1.IsChecked = false;
            txtFilling2.IsChecked = false;

            txtDescriptionSuffix.TextBox1.CharacterCasing = CharacterCasing.Upper;
            txtDescriptionSuffix.TextBox1.IsEnabled = false;

            cmbProdIndustry.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(ProdIndustry));
            cmbProdIndustry.SetSelectedIndex(0);

            dgr_Main.SetFilterValue("Finished Good Name", "ItemName", null);

            Clearfield_CompettiveProdInfo();
            dt_ComptetProduct.Rows.Clear();

            expCompetProduct.Visibility = clsConfig.b_Prod_View_Competitive_ProductComparison ? Visibility.Visible : Visibility.Collapsed;

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtItemID.setReadOnlyStatus(true);
                txtItemID.Text = "<Auto Generate>";
            }
            else
                txtItemID.setReadOnlyStatus(false);
            #endregion
        }

        private void Clearfield_CompettiveProdInfo()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBrand, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtModel, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCompany, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountry, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMRP, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrice1, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrice2, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrice3, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrice4, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark6, true, false, true);

            txtBrand.Tag = null;
            txtModel.Tag = null;

            txtBrand.ToolTip = null;
            txtModel.ToolTip = null;

            txtBrand.Uid = "";
            txtModel.Uid = "";

            txtBrand.Text = "";
            txtModel.Text = "";
            txtCompany.Text = "";
            txtCountry.Text = "";
            txtPrice1.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            txtPrice2.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            txtPrice3.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            txtPrice4.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            txtPrice2.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            txtMRP.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            txtRemark6.Text = "";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dgr_Main.dt.Clear();
            dgr_Main.SetFilterValue("Finished Good Name", "ItemName", null);
            //int iCount = 0;
            //foreach (tbl_prod_apparelTxFinishedGoodSpecsSheet oItem_FG_Spec in tbl_prod_apparelTxFinishedGoodSpecsSheet.SelectAll().OrderByDescending(o => o.DateCreate))
            //{
            //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oItem_FG_Spec.Item_ID_FG);
            //    if (oItem != null)
            //        dgr_Main.dt.Rows.Add(++iCount, oItem.Item_ID, oItem.GenerateCode, oItem.ItemName, oItem.Description,
            //            clsGenaralName.getName_User(oItem_FG_Spec.CreateUser_ID), clsHelpMethods_Prod.Format_DateTime(oItem_FG_Spec.DateCreate),
            //            clsGenaralName.getName_User(oItem_FG_Spec.ModifiedUser_ID), clsHelpMethods_Prod.Format_DateTime(oItem_FG_Spec.DateModified),
            //            oItem_FG_Spec.IsCanceled);
            //}
            dgr_Main.dt.Merge(DBHandling.ExecQuery("Exec sp_FinishedGood_Details").Tables[0]);
            dgr_Main.RefreshGrid();
        }
        #endregion

        #region CheckValidity

        #region Prod Specs
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (ChekValidity_DuplicateSalesNames())
                {
                    if (ChekValidity_DuplicateSalesCodes())
                    {
                        if (ChekValidity_DuplicateFGDescription())
                        {
                            if (CheckValidity_DuplicateFiled())
                            {
                                if (clsValidate.CheckValidity_TransactionCodeLength(txtItemID.Text))
                                {
                                    bStatus = true;
                                }
                            }
                        }
                    }
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtItemID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtJobName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdRange))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdCategory))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdSize))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdColour))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodDescription))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodSalesCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodSalesName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodQtyUOM))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodWeiUOM))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtItemID.Tag = clsAutocode.getAutoGeneratedCode("CON/001");//Item Master Next Item ID  //SEACC_Form.getAutoGeneratedCode();
                    txtItemID.Text = txtItemID.Tag.ToString();
                }

                tbl_genItemMaster oJob = tbl_genItemMaster.Select(txtItemID.Text);
                if (oJob != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateSalesNames()
        {
            bool bStatus = true;
            foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(p =>
                                        (p.ItemName != null ? p.ItemName.Trim().ToUpper() : p.ItemName) == txtFinishGoodSalesName.Text.Trim().ToUpper() &&
                                        p.Item_ID != txtItemID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show("Alreay Exist", "FG ID : " + oItem.Item_ID + "\n" + "FG Sales Name : \" " + txtFinishGoodSalesName.Text + " \" is already exsiting", MessageBoxButton.OK, "Red");
                break;
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateSalesCodes()
        {
            bool bStatus = true;
            foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(p =>
                                        (p.GenerateCode != null ? p.GenerateCode.Trim().ToUpper() : p.GenerateCode) == txtFinishGoodSalesCode.Text.Trim().ToUpper() &&
                                        p.Item_ID != txtItemID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show("Alreay Exist", "FG ID : " + oItem.Item_ID + "\n" + "FG Sales Code : \" " + txtFinishGoodSalesName.Text + " \" is already exsiting", MessageBoxButton.OK, "Red");
                break;
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateFGDescription()
        {
            bool bStatus = true;
            foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(p =>
                                        (p.Description != null ? p.Description.Trim().ToUpper() : p.Description) == txtFinishGoodDescription.Text.Trim().ToUpper() &&
                                        p.Item_ID != txtItemID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show("Alreay Exist", "FG ID : " + oItem.Item_ID + "\n" + "FG Description : \" " + txtFinishGoodDescription.Text + " \" is already exsiting", MessageBoxButton.OK, "Red");
                break;
            }
            return bStatus;
        }

        #endregion

        #region Prod Compet Info
        private bool CheckValidity_CompetProdInfo()
        {
            bool bStatus = false;
            if (CheckValidity_CompetProdInfo_EmptyField())
                bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_CompetProdInfo_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtBrand))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtModel))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCompany))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCountry))
                bStatus = false;

            return bStatus;
        }

        #endregion

        #endregion

        #region Fill Details
        private void FillDetails(string sItem_ID)
        {
            try
            {
                Cursor = Cursors.Wait;

                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                tbl_prod_apparelTxFinishedGoodSpecsSheet oFG_Sepcs = tbl_prod_apparelTxFinishedGoodSpecsSheet.Select(sItem_ID);
                if (oItem != null && oFG_Sepcs != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtItemID.Tag = oItem.Item_ID;
                    txtItemID_Template.Tag = oFG_Sepcs.Item_ID_Template;
                    txtCustomer.Tag = oFG_Sepcs.Customer_ID;
                    txtJobName.Tag = oItem.ItemClass_ID;
                    txtJobType.Tag = oFG_Sepcs.Tag4_ID;
                    txtProdRange.Tag = oItem.ItemType_ID;
                    txtProdCategory.Tag = oItem.ItemCategory_ID;
                    txtProdSize.Tag = oFG_Sepcs.Tag3_ID;
                    txtProdColour.Tag = oFG_Sepcs.Colour_ID;
                    txtFinishGoodQtyUOM.Tag = oFG_Sepcs.Uom_ID;
                    txtFinishGoodWeiUOM.Tag = oFG_Sepcs.Uom_ID_Weight;
                    txtFabricLayer1.Tag = oFG_Sepcs.Layer1;
                    txtFabricLayer2.Tag = oFG_Sepcs.Layer2;
                    txtFabricLayer3.Tag = oFG_Sepcs.Layer3;
                    txtPaddingLayer1.Tag = oFG_Sepcs.Layer4;
                    txtPaddingLayer2.Tag = oFG_Sepcs.Layer5;
                    txtFilling1.Tag = oFG_Sepcs.Filling1;
                    txtFilling2.Tag = oFG_Sepcs.Filling2;

                    txtDescriptionSuffix.IsChecked = (oFG_Sepcs.Suffix != null && oFG_Sepcs.Suffix.Length > 0 && oFG_Sepcs.Suffix != "") ? true : false;
                    txtFabricLayer1.IsChecked = (oFG_Sepcs.Layer1 != null && oFG_Sepcs.Layer1.Length > 0 && oFG_Sepcs.Layer1 != "default") ? true : false;
                    txtFabricLayer2.IsChecked = (oFG_Sepcs.Layer2 != null && oFG_Sepcs.Layer2.Length > 0 && oFG_Sepcs.Layer2 != "default") ? true : false;
                    txtFabricLayer3.IsChecked = (oFG_Sepcs.Layer3 != null && oFG_Sepcs.Layer3.Length > 0 && oFG_Sepcs.Layer3 != "default") ? true : false;
                    txtPaddingLayer1.IsChecked = (oFG_Sepcs.Layer4 != null && oFG_Sepcs.Layer4.Length > 0 && oFG_Sepcs.Layer4 != "default") ? true : false;
                    txtPaddingLayer2.IsChecked = (oFG_Sepcs.Layer5 != null && oFG_Sepcs.Layer5.Length > 0 && oFG_Sepcs.Layer5 != "default") ? true : false;
                    txtFilling1.IsChecked = (oFG_Sepcs.Filling1 != null && oFG_Sepcs.Filling1.Length > 0 && oFG_Sepcs.Filling1 != "default") ? true : false;
                    txtFilling2.IsChecked = (oFG_Sepcs.Filling2 != null && oFG_Sepcs.Filling2.Length > 0 && oFG_Sepcs.Filling2 != "default") ? true : false;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oFG_Sepcs.Customer_ID);
                    txtJobName.Uid = clsGenaralName.getName_ItemClassPrefix(oItem.ItemClass_ID);
                    txtJobType.Uid = clsGenaralName.getName_Tag4Prefix(oFG_Sepcs.Tag4_ID);
                    txtProdRange.Uid = clsGenaralName.getName_ItemTypePrefix(oItem.ItemType_ID);
                    txtProdCategory.Uid = clsGenaralName.getName_ItemCategoryPrefix(oItem.ItemCategory_ID);
                    txtProdSize.Uid = clsGenaralName.getName_Tag3Prefix(oFG_Sepcs.Tag3_ID);
                    txtProdColour.Uid = clsGenaralName.getName_ColourPrefix(oFG_Sepcs.Colour_ID);
                    txtFabricLayer1.Uid = clsGenaralName.getName_Item(oFG_Sepcs.Layer1);
                    txtFabricLayer2.Uid = clsGenaralName.getName_Item(oFG_Sepcs.Layer2);
                    txtFabricLayer3.Uid = clsGenaralName.getName_Item(oFG_Sepcs.Layer3);
                    txtPaddingLayer1.Uid = clsGenaralName.getName_Item(oFG_Sepcs.Layer4);
                    txtPaddingLayer2.Uid = clsGenaralName.getName_Item(oFG_Sepcs.Layer5);
                    txtFilling1.Uid = clsGenaralName.getName_Item(oFG_Sepcs.Filling1);
                    txtFilling2.Uid = clsGenaralName.getName_Item(oFG_Sepcs.Filling2);

                    txtCustomer.ToolTip = txtCustomer.Uid;
                    txtJobName.ToolTip = clsGenaralName.getName_ItemClassPrefix2(oItem.ItemClass_ID);
                    txtJobType.ToolTip = clsGenaralName.getName_Tag4Prefix2(oFG_Sepcs.Tag4_ID);
                    txtProdRange.ToolTip = clsGenaralName.getName_ItemTypePrefix2(oItem.ItemType_ID);
                    txtProdCategory.ToolTip = clsGenaralName.getName_ItemCategoryPrefix2(oItem.ItemCategory_ID);
                    txtProdSize.ToolTip = clsGenaralName.getName_Tag3Prefix2(oFG_Sepcs.Tag3_ID);
                    txtProdColour.ToolTip = clsGenaralName.getName_ColourPrefix2(oFG_Sepcs.Colour_ID);
                    txtFabricLayer1.ToolTip = clsGenaralName.getName_Item(oFG_Sepcs.Layer1);
                    txtFabricLayer2.ToolTip = clsGenaralName.getName_Item(oFG_Sepcs.Layer2);
                    txtFabricLayer3.ToolTip = clsGenaralName.getName_Item(oFG_Sepcs.Layer3);
                    txtPaddingLayer1.ToolTip = clsGenaralName.getName_Item(oFG_Sepcs.Layer4);
                    txtPaddingLayer2.ToolTip = clsGenaralName.getName_Item(oFG_Sepcs.Layer5);
                    txtFilling1.ToolTip = clsGenaralName.getName_Item(oFG_Sepcs.Filling1);
                    txtFilling2.ToolTip = clsGenaralName.getName_Item(oFG_Sepcs.Filling2);

                    txtItemID.Text = oItem.Item_ID;
                    txtItemID_Template.Text = oFG_Sepcs.Item_ID_Template == "default" ? "-" : clsGenaralName.getDescription_Item(oFG_Sepcs.Item_ID_Template);
                    cmbProdIndustry.SetSelectedIndex(oFG_Sepcs.Industry_ID);
                    txtJobName.Text = txtJobName.Uid + " - " + clsGenaralName.getName_ItemClass(oItem.ItemClass_ID);
                    txtJobType.Text = txtJobType.Uid + " - " + clsGenaralName.getName_Tag4(oFG_Sepcs.Tag4_ID);
                    txtCustomer.Text = txtCustomer.Uid + " - " + clsGenaralName.getName_Customer(oFG_Sepcs.Customer_ID);
                    txtProdRange.Text = txtProdRange.Uid + " - " + clsGenaralName.getName_ItemType(oItem.ItemType_ID);
                    txtProdCategory.Text = txtProdCategory.Uid + " - " + clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID);
                    txtProdSize.Text = txtProdSize.Uid + " - " + clsGenaralName.getName_Tag3(oFG_Sepcs.Tag3_ID);
                    txtProdColour.Text = txtProdColour.Uid + " - " + clsGenaralName.getName_Colour(oFG_Sepcs.Colour_ID);
                    txtFinishGoodSalesName.Text = oItem.ItemName;
                    txtDescriptionSuffix.Text = oFG_Sepcs.Suffix;
                    txtFinishGoodQtyUOM.Text = clsGenaralName.getName_UomAndCode(oFG_Sepcs.Uom_ID);
                    txtFinishGoodWeiUOM.Text = clsGenaralName.getName_UomAndCode(oFG_Sepcs.Uom_ID_Weight);
                    txtFabricLayer1.Text = clsGenaralName.getName_Item(oFG_Sepcs.Layer1);
                    txtFabricLayer2.Text = clsGenaralName.getName_Item(oFG_Sepcs.Layer2);
                    txtFabricLayer3.Text = clsGenaralName.getName_Item(oFG_Sepcs.Layer3);
                    txtPaddingLayer1.Text = clsGenaralName.getName_Item(oFG_Sepcs.Layer4);
                    txtPaddingLayer2.Text = clsGenaralName.getName_Item(oFG_Sepcs.Layer5);
                    txtFilling1.Text = clsGenaralName.getName_Item(oFG_Sepcs.Filling1);
                    txtFilling2.Text = clsGenaralName.getName_Item(oFG_Sepcs.Filling2);
                    txtRemark1.Text = oFG_Sepcs.Instruction_Sales;
                    txtRemark2.Text = oFG_Sepcs.Instruction_Prod;
                    txtRemark3.Text = oFG_Sepcs.Instruction_Accounts;
                    txtRemark4.Text = oFG_Sepcs.Instruction_Stores;
                    txtRemark5.Text = oFG_Sepcs.Instruction_Supplier;

                    dt_ComptetProduct.Rows.Clear();
                    foreach (tbl_prod_apparelTxCompetitiveProductInfo oItemCoptInfo in tbl_prod_apparelTxCompetitiveProductInfo.SelectAllByItem_ID_FG(sItem_ID))
                    {
                        dt_ComptetProduct.Rows.Add(oItemCoptInfo.Line_No, oItemCoptInfo.Brand_ID, clsGenaralName.getName_Brand(oItemCoptInfo.Brand_ID),
                            oItemCoptInfo.Model_ID, clsGenaralName.getName_Model(oItemCoptInfo.Model_ID),
                            oItemCoptInfo.Company,
                            oItemCoptInfo.Country_ID, clsGenaralName.getName_Country(oItemCoptInfo.Country_ID),
                            cls_Formater.FormatDecimal(oItemCoptInfo.Price_MPR, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                            cls_Formater.FormatDecimal(oItemCoptInfo.Price1, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                            cls_Formater.FormatDecimal(oItemCoptInfo.Price2, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                            cls_Formater.FormatDecimal(oItemCoptInfo.Price3, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                            cls_Formater.FormatDecimal(oItemCoptInfo.Price4, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                            oItemCoptInfo.Remarks);
                    }

                    txtFinishGoodSalesCode.Text = oItem.GenerateCode;
                    txtFinishGoodDescription.Text = oItem.Description;
                    dgr_Main.SetFilterValue("Finished Good Name", "ItemName", null);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region Grid Events

        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    Clearfields();
                    FillDetails(GridID);
                    exp_FGspecs.IsExpanded = true;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row["Is_Cancelled"].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_CopmeteProdInfo_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dt_ComptetProduct);
        }

        #endregion

        #region Search Events
        private void txtItemID_Template_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionFinishedGoods);
            if (RowDataSearch.DialogResult == true)
            {
                FillDetails(lstResult[0]);
                SEACC_Form.IsUpdateMode = false;

                #region Auto Generate
                txtItemID.Tag = null;
                txtItemID.Text = "";

                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtItemID.setReadOnlyStatus(true);
                    txtItemID.Text = "<Auto Generate>";
                }
                else
                    txtItemID.setReadOnlyStatus(false);
                #endregion

                txtItemID_Template.Tag = lstResult[0];
                txtItemID_Template.Text = lstResult[2];
            }
        }

        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Customer);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Uid = lstResult[2];
                txtCustomer.ToolTip = lstResult[2];
                txtCustomer.Text = lstResult[1];
            }
        }

        private void txtJobName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionJobName);
            if (RowDataSearch.DialogResult == true)
            {
                txtJobName.Tag = lstResult[0];
                txtJobName.Uid = lstResult[1];
                txtJobName.ToolTip = lstResult[2];
                txtJobName.Text = lstResult[1] + " - " + lstResult[3];

                if (clsHelpMethods_Prod.IsJobType_MakeToSupply(lstResult[0]))
                {
                    txtCustomer.Tag = "CUS/00000";
                    txtCustomer.Uid = "";
                    txtCustomer.ToolTip = "";
                    txtCustomer.IsEnabled = false;
                }
                else
                {
                    if (txtCustomer.Tag != null && txtCustomer.Tag.ToString() == "CUS/00000")
                    {
                        txtCustomer.Tag = "default";
                        txtCustomer.Uid = "";
                        txtCustomer.ToolTip = "";
                    }
                    txtCustomer.IsEnabled = true;
                }

                if (txtCustomer.Tag != null)
                    txtCustomer.Text = clsGenaralName.getName_Customer(txtCustomer.Tag.ToString());
            }
        }

        private void txtJobType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_JobTypes);
            if (RowDataSearch.DialogResult == true)
            {
                txtJobType.Tag = lstResult[0];
                txtJobType.Uid = lstResult[1];
                txtJobType.ToolTip = lstResult[2];
                txtJobType.Text = lstResult[1] + " - " + lstResult[3];
            }
        }

        private void txtProdRange_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_productRange);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdRange.Tag = lstResult[0];
                txtProdRange.Uid = lstResult[1];
                txtProdRange.ToolTip = lstResult[2];
                txtProdRange.Text = lstResult[1] + " - " + lstResult[3];
            }
        }

        private void txtProdCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdCategory.Tag = lstResult[0];
                txtProdCategory.Uid = lstResult[1];
                txtProdCategory.ToolTip = lstResult[2];
                txtProdCategory.Text = lstResult[1] + " - " + lstResult[3];
            }
        }

        private void txtProdSize_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductSize);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdSize.Tag = lstResult[0];
                txtProdSize.Uid = lstResult[1];
                txtProdSize.ToolTip = lstResult[2];
                txtProdSize.Text = lstResult[1] + " - " + lstResult[3];

                tbl_zItemTag3 oSize = tbl_zItemTag3.Select(lstResult[0]);
                if (oSize != null)
                {
                    txtFinishGoodWeiUOM.Tag = oSize.Uom_ID_weight;
                    txtFinishGoodWeiUOM.Text = clsGenaralName.getName_UomAndCode(oSize.Uom_ID_weight);
                }
            }
        }

        private void txtProdColour_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductColour);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdColour.Tag = lstResult[0];
                txtProdColour.Uid = lstResult[1];
                txtProdColour.ToolTip = lstResult[2];
                txtProdColour.Text = lstResult[1] + " - " + lstResult[3];
            }
        }

        private void txtFinishGoodUOM_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtFinishGoodQtyUOM.Tag = lstResult[0];
                txtFinishGoodQtyUOM.Uid = lstResult[2];
                txtFinishGoodQtyUOM.Text = lstResult[1] + " - " + lstResult[2];
            }
        }

        private void txtFinishGoodWeiUOM_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtFinishGoodWeiUOM.Tag = lstResult[0];
                txtFinishGoodWeiUOM.Uid = lstResult[2];
                txtFinishGoodWeiUOM.Text = lstResult[1] + " - " + lstResult[2];
            }
        }

        private void txtFabricLayer1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtFabricLayer1.IsChecked)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials);
                if (RowDataSearch.DialogResult == true)
                {
                    txtFabricLayer1.Tag = lstResult[0];
                    txtFabricLayer1.Uid = lstResult[2];
                    txtFabricLayer1.ToolTip = lstResult[2];
                    txtFabricLayer1.Text = lstResult[2];
                }
            }
        }

        private void txtFabricLayer2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtFabricLayer2.IsChecked)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials);
                if (RowDataSearch.DialogResult == true)
                {
                    txtFabricLayer2.Tag = lstResult[0];
                    txtFabricLayer2.Uid = lstResult[2];
                    txtFabricLayer2.ToolTip = lstResult[2];
                    txtFabricLayer2.Text = lstResult[2];
                }
            }
        }

        private void txtFabricLayer3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtFabricLayer3.IsChecked)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials);
                if (RowDataSearch.DialogResult == true)
                {
                    txtFabricLayer3.Tag = lstResult[0];
                    txtFabricLayer3.Uid = lstResult[2];
                    txtFabricLayer3.ToolTip = lstResult[2];
                    txtFabricLayer3.Text = lstResult[2];
                }
            }
        }

        private void txtPaddingLayer1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtPaddingLayer1.IsChecked)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials);
                if (RowDataSearch.DialogResult == true)
                {
                    txtPaddingLayer1.Tag = lstResult[0];
                    txtPaddingLayer1.Uid = lstResult[2];
                    txtPaddingLayer1.ToolTip = lstResult[2];
                    txtPaddingLayer1.Text = lstResult[2];
                }
            }
        }

        private void txtPaddingLayer2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtPaddingLayer2.IsChecked)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials);
                if (RowDataSearch.DialogResult == true)
                {
                    txtPaddingLayer2.Tag = lstResult[0];
                    txtPaddingLayer2.Uid = lstResult[2];
                    txtPaddingLayer2.ToolTip = lstResult[2];
                    txtPaddingLayer2.Text = lstResult[2];
                }
            }
        }

        private void txtFilling1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtFilling1.IsChecked)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials);
                if (RowDataSearch.DialogResult == true)
                {
                    txtFilling1.Tag = lstResult[0];
                    txtFilling1.Uid = lstResult[2];
                    txtFilling1.ToolTip = lstResult[2];
                    txtFilling1.Text = lstResult[2];
                }
            }
        }

        private void txtFilling2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtFilling2.IsChecked)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials);
                if (RowDataSearch.DialogResult == true)
                {
                    txtFilling2.Tag = lstResult[0];
                    txtFilling2.Uid = lstResult[2];
                    txtFilling2.ToolTip = lstResult[2];
                    txtFilling2.Text = lstResult[2];
                }
            }
        }


        private void txtBrand_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Brand);
            if (RowDataSearch.DialogResult == true)
            {
                txtBrand.Tag = lstResult[0];
                txtBrand.Text = lstResult[1];
            }
        }

        private void txtModel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Model);
            if (RowDataSearch.DialogResult == true)
            {
                txtModel.Tag = lstResult[0];
                txtModel.Text = lstResult[1];
            }
        }

        private void txtCountry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Country);
            if (RowDataSearch.DialogResult == true)
            {
                txtCountry.Tag = lstResult[0];
                txtCountry.Text = lstResult[1];
            }
        }

        #endregion

        #region Key Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
        #endregion

        #region Scroll Event
        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scv = sender as ScrollViewer;
            if (scv == null) return;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        #endregion

        #region Other Text Box Events

        private void txt_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (txtDescriptionSuffix.IsChecked)
                txtDescriptionSuffix.TextBox1.IsEnabled = true;
            else
                txtDescriptionSuffix.TextBox1.IsEnabled = false;


            if (txtFinishGoodDescription.IsEnabled && txtFinishGoodSalesCode.IsEnabled)
            {
                string sNewFG_Description = "";
                string sNewFG_SalesCode = "";

                if (txtJobName.Tag != null && txtJobName.Tag.ToString() != "default")
                {
                    sNewFG_Description = txtJobName.Uid.ToString();
                    if (txtJobName.ToolTip != null)
                        sNewFG_SalesCode = txtJobName.ToolTip.ToString();
                }

                if (txtJobType.Tag != null && txtJobType.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtJobType.Uid.ToString();
                    if (txtJobType.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtJobType.ToolTip.ToString();
                }

                if (txtProdRange.Tag != null && txtProdRange.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtProdRange.Uid.ToString();
                    if (txtProdRange.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtProdRange.ToolTip.ToString();
                }

                if (txtProdCategory.Tag != null && txtProdCategory.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtProdCategory.Uid.ToString();
                    if (txtProdCategory.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtProdCategory.ToolTip.ToString();
                }

                if (txtProdSize.Tag != null && txtProdSize.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtProdSize.Uid.ToString();
                    if (txtProdSize.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtProdSize.ToolTip.ToString();
                }

                if (txtProdColour.Tag != null && txtProdColour.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtProdColour.Uid.ToString();
                    if (txtProdColour.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtProdColour.ToolTip.ToString();
                }

                if (txtFabricLayer1.IsChecked && txtFabricLayer1.Tag != null && txtFabricLayer1.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtFabricLayer1.Uid.ToString();
                    if (txtFabricLayer1.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtFabricLayer1.ToolTip.ToString();
                }
                if (txtFabricLayer2.IsChecked && txtFabricLayer2.Tag != null && txtFabricLayer1.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtFabricLayer2.Uid.ToString();
                    if (txtFabricLayer2.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtFabricLayer2.ToolTip.ToString();
                }
                if (txtFabricLayer3.IsChecked && txtFabricLayer3.Tag != null && txtFabricLayer3.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtFabricLayer3.Uid.ToString();
                    if (txtFabricLayer3.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtFabricLayer3.ToolTip.ToString();
                }
                if (txtFabricLayer1.IsChecked && txtPaddingLayer1.Tag != null && txtPaddingLayer1.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtPaddingLayer1.Uid.ToString();
                    if (txtPaddingLayer1.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtPaddingLayer1.ToolTip.ToString();
                }
                if (txtPaddingLayer2.IsChecked && txtPaddingLayer2.Tag != null && txtPaddingLayer2.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtPaddingLayer2.Uid.ToString();
                    if (txtPaddingLayer2.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtPaddingLayer2.ToolTip.ToString();
                }
                if (txtFilling1.IsChecked && txtFilling1.Tag != null && txtFilling1.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtFilling1.Uid.ToString();
                    if (txtFilling1.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtFilling1.ToolTip.ToString();
                }
                if (txtFilling2.IsChecked && txtFilling2.Tag != null && txtFilling2.Tag.ToString() != "default")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtFilling2.Uid.ToString();
                    if (txtFilling2.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtFilling2.ToolTip.ToString();
                }


                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString() != "default" && txtCustomer.Tag.ToString() != "CUS/00000")
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtCustomer.Uid.ToString();
                    if (txtCustomer.ToolTip != null)
                        sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtCustomer.ToolTip.ToString();
                }

                if (txtDescriptionSuffix.IsChecked && txtDescriptionSuffix.TextBox1.Text.Length > 0)
                {
                    sNewFG_Description += (sNewFG_Description != "" ? "/" : "") + txtDescriptionSuffix.TextBox1.Text;
                    sNewFG_SalesCode += (sNewFG_SalesCode != "" ? "/" : "") + txtDescriptionSuffix.TextBox1.Text;
                }

                txtFinishGoodDescription.Text = sNewFG_Description.Trim();
                txtFinishGoodSalesCode.Text = sNewFG_SalesCode.Trim();
            }
        }

        private void txtFinishGoodSalesName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (txtFinishGoodSalesName.TextBox1.Text.Length > 0)
                dgr_Main.SetFilterValue("Finished Good Name", "ItemName", txtFinishGoodSalesName.TextBox1.Text, true);
            else
                dgr_Main.SetFilterValue("Finished Good Name", "ItemName", null);
        }

        #endregion
    }
}
