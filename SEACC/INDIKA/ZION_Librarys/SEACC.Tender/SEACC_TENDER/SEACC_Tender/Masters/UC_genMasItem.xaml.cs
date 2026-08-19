using DataTire;
using Digiteq_Logic;
using SEACC_Tender.Search_Forms;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEACC_Tender
{
    /// <summary>
    /// Interaction logic for UC_ItemMaster.xaml
    /// </summary>
    public partial class UC_genMasItem : UserControl
    {
        #region Form Load
        public UC_genMasItem()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Item;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("Item_ID");
            dgr_Main.dt.Columns.Add("Item_Code");
            dgr_Main.dt.Columns.Add("Item_GenericName");
            dgr_Main.dt.Columns.Add("Item_Brand");
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Item ID", "Item_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Item Code", "Item_Code", 90);
            dgr_Main.Add_DatagridColoumn("Item Generic Name", "Item_GenericName", 200);
            dgr_Main.Add_DatagridColoumn("Item Brand Name", "Item_Brand", 100);
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                coloumnA.Width = new GridLength(200);
            else
                coloumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Buttons
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtItem_ID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_genItemMaster Details = tbl_genItemMaster.Select(txtItem_ID.Tag.ToString());
                            if (Details != null)
                            {
                                Details.IsDeleted = true;
                                Details.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFields();
                                RefreshGrid();
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

        private void Btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Print Failed", ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    string sSd = "";
                    try
                    {
                        Cursor = Cursors.Wait;
                        sSd = txtItem_ID.Tag.ToString(); ;

                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_genItemMaster OldRecord = tbl_genItemMaster.Select(txtItem_ID.Tag.ToString());
                            if (OldRecord != null)
                            {
                                tbl_genItemMaster odetail = new tbl_genItemMaster(txtItem_ID.Tag.ToString(), txtItem_code.Text, txtItem_name.Text, txtItem_des1.Text, txtItem_des2.Text, txtHS_code.Text, txtRemarks.Text, "", decimal.Parse(txtCost_price.Text), decimal.Parse(txtKilo_price.Text), decimal.Parse(txtWght_avg_cost.Text), decimal.Parse(txtHeighest_cost.Text), decimal.Parse(txtSelling_price.Text),
                                    decimal.Parse(txtDutyFree_price.Text), decimal.Parse(txtSVAT_price.Text), decimal.Parse(txtAllinclusive_price.Text), decimal.Parse(txtWholesale_price.Text), decimal.Parse(txtMin_stock_level.Text), 0, decimal.Parse(txtReorder_level.Text), decimal.Parse(txtReorder_qty.Text), chkIsTIEPItem.IsChecked, chkIsImportItem.IsChecked, chkIsExportSalesItem.IsChecked, false, false,
                                    "default", txtItem_category.Tag.ToString(), txtItem_class.Tag.ToString(), txtItem_type.Tag.ToString(), "default", txtBrand.Tag.ToString(), txtSubstitute_item.Tag.ToString(), txtUom.Tag.ToString(), 0, 0, 0, 0, 0, 0, 0, clsAutocode.getMeasuermentTypeID(JobMeasurementType.Milimeter), chkIsUnitQtyPricing1.IsChecked, chkIsUnitQtyPricing.IsChecked,
                                    OldRecord.IsDeleted, false, false, "", chkIsUnitQtyPricing2.IsChecked, chkIsUnitQtyPricing3.IsChecked,
                                    OldRecord.CompanyID, OldRecord.CompanyBranch_ID, txtTag1.Tag.ToString(), txtTag2.Tag.ToString(),false,false,false);
                                odetail.Update();

                                //tbl_genItemMaster oDetails = new tbl_genItemMaster(txtItem_ID.Tag.ToString(), txtItem_code.Text, txtGenericname.Text, txtSpecification.Text, txtPackSize.Text, "", "", "", decimal.Parse(txtCost_price.Text), decimal.Parse(txtKilo_price.Text), decimal.Parse(txtWght_avg_cost.Text), decimal.Parse(txtHeighest_cost.Text), decimal.Parse(txtSelling_price.Text),
                                //    decimal.Parse(txtDutyFree_price.Text), decimal.Parse(txtSVAT_price.Text), decimal.Parse(txtAllinclusive_price.Text), decimal.Parse(txtWholesale_price.Text), decimal.Parse(txtMin_stock_level.Text), 0, decimal.Parse(txtReorder_level.Text), decimal.Parse(txtReorder_qty.Text), chkIsTIEPItem.IsChecked, chkIsImportItem.IsChecked, chkIsExportSalesItem.IsChecked, false, false "default",
                                //    txtCategory.Tag.ToString(), txtClass.Tag.ToString(), txtItem_type.Tag.ToString(), "default", txtBrand.Tag.ToString(), "default", txtUoM.Tag.ToString(), 0, 0, 0, 0, 0, 0, 0, "default", false, false, false, false, false, "", false, false, clsSecurity.CompanyID, "",
                                //    txtTag1.Tag.ToString(), txtTag2.Tag.ToString(), false, false, false);
                                //oDetails.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            tbl_genItemMaster odetail = new tbl_genItemMaster(txtItem_ID.Tag.ToString(), txtItem_code.Text, txtItem_name.Text, txtItem_des1.Text, txtItem_des2.Text, txtHS_code.Text, txtRemarks.Text, "", decimal.Parse(txtCost_price.Text), decimal.Parse(txtKilo_price.Text), decimal.Parse(txtWght_avg_cost.Text), decimal.Parse(txtHeighest_cost.Text), decimal.Parse(txtSelling_price.Text),
                                    decimal.Parse(txtDutyFree_price.Text), decimal.Parse(txtSVAT_price.Text), decimal.Parse(txtAllinclusive_price.Text), decimal.Parse(txtWholesale_price.Text), decimal.Parse(txtMin_stock_level.Text), 0, decimal.Parse(txtReorder_level.Text), decimal.Parse(txtReorder_qty.Text), chkIsTIEPItem.IsChecked, chkIsImportItem.IsChecked, chkIsExportSalesItem.IsChecked, false, false,
                                    "default", txtItem_category.Tag.ToString(), txtItem_class.Tag.ToString(), txtItem_type.Tag.ToString(), "default", txtBrand.Tag.ToString(), "default", txtUom.Tag.ToString(), 0, 0, 0, 0, 0, 0, 0, "default", chkIsUnitQtyPricing1.IsChecked, chkIsUnitQtyPricing.IsChecked,
                                    false, false, false, "", chkIsUnitQtyPricing2.IsChecked, chkIsUnitQtyPricing3.IsChecked,
                                    clsSecurity.CompanyID, clsSecurity.BranchID, txtTag1.Tag.ToString(), txtTag2.Tag.ToString(),false,false,false);
                            odetail.Insert();

                            //tbl_genItemMaster oDetails = new tbl_genItemMaster(txtItem_ID.Tag.ToString(), txtItem_code.Text, txtGenericname.Text, txtSpecification.Text, txtPackSize.Text, "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, false, false, false, false, "default",
                            //    txtCategory.Tag.ToString(), txtClass.Tag.ToString(), txtItem_type.Tag.ToString(), "default", txtBrand.Tag.ToString(), "default", txtUoM.Tag.ToString(), 0, 0, 0, 0, 0, 0, 0, "default", false, false, false, false, false, "", false, false, clsSecurity.CompanyID, "",
                            //    txtTag1.Tag.ToString(), txtTag2.Tag.ToString(), false, false, false);
                            //oDetails.Insert();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);

                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Arrow;
                        ClearFields();
                        RefreshGrid();
                        fillDetails(sSd);
                    }
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtItem_ID, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtItem_code, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtItem_name, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtItem_des1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtItem_des2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtHS_code, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItem_class, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItem_type, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItem_category, true, false, false);                  
            
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSub_category, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubstitute_item, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrand, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUom, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTag1, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTag2, true, false, false);

            cls_Formater.SetEnableDisable_LableTextbox(txtMin_stock_level, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReorder_level, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReorder_qty, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCost_price, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtWght_avg_cost, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtHeighest_cost, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLIFO_cost, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFIFO_cost, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLowest_cost, true, false, false);
            chkIsTIEPItem.IsChecked = false;
            chkIsImportItem.IsChecked = false;
            chkIsExportSalesItem.IsChecked = false;
            chkIsUnitQtyPricing.IsChecked = false;

            cls_Formater.SetEnableDisable_LableTextbox(txtKilo_price, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSelling_price, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtWholesale_price, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDutyFree_price, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSVAT_price, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAllinclusive_price, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOther_price, true, false, false);
            chkIsUnitQtyPricing1.IsChecked = false;
            chkIsUnitQtyPricing2.IsChecked = false;
            chkIsUnitQtyPricing3.IsChecked = false;
            

            txtItem_ID.Tag = null;
            txtItem_ID.Text = "";
            txtItem_code.Text = "";
            txtItem_name.Text = "";
            txtItem_des1.Text = "";
            txtItem_des2.Text = "";
            txtHS_code.Text = "";
            txtItem_class.Tag = null;
            txtItem_class.Text = "";
            txtItem_type.Tag = null;
            txtItem_type.Text = "";
            txtItem_category.Tag = null;
            txtItem_category.Text = "";
                       
            txtSub_category.Tag = null;
            txtSub_category.Text = "";
            txtSubstitute_item.Tag = null;
            txtSubstitute_item.Text = "";
            txtRemarks.Text = "";
            txtBrand.Tag = null;
            txtBrand.Text = "";
            txtUom.Tag = null;
            txtUom.Text = "";
            txtTag1.Tag = null;
            txtTag1.Text = "";
            txtTag2.Tag = null;
            txtTag2.Text = "";

            txtMin_stock_level.Text = "00.00";
            txtReorder_level.Text = "00.00";
            txtReorder_qty.Text = "00.00";
            txtCost_price.Text = "00.00";
            txtWght_avg_cost.Text = "00.00";
            txtHeighest_cost.Text = "00.00";
            txtLIFO_cost.Text = "00.00";
            txtFIFO_cost.Text = "00.00";
            txtLowest_cost.Text = "00.00";
                       
            txtKilo_price.Text = "00.00";
            txtSelling_price.Text = "00.00";
            txtWholesale_price.Text = "00.00";
            txtDutyFree_price.Text = "00.00";
            txtSVAT_price.Text = "00.00";
            txtAllinclusive_price.Text = "00.00";
            txtOther_price.Text = "00.00";

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_genItemMaster detail in tbl_genItemMaster.SelectAll().Where(p => !p.IsDeleted))
                {
                    dgr_Main.dt.Rows.Add(detail.Item_ID, detail.GenerateCode, clsRef_Name.get_Item_Category(detail.ItemCategory_ID), clsRef_Name.get_Item_Name(detail.Item_ID));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                if (CheckValidity_DuplicateKey())
                {
                    if (CheckNumberValidity())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            //if (!clsValidation.Validate_EmptyValue(txtCustomer_code, ref strMessage))
            //    bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtName, ref strMessage))
            //    bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtCustomer_cls, ref strMessage))
            //    bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtCustomer_tp, ref strMessage))
            //    bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtCategory, ref strMessage))
            //    bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtBranch, ref strMessage))
            //    bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Fields cannot be Empty", strMessage);

            return bStatus;
        }

        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtItem_ID.Text = SEACC_Form.getAutoGeneratedCode();

                txtItem_ID.Tag = txtItem_ID.Text;

                if (txtItem_ID.Tag.ToString() != "")
                {
                    tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItem_ID.Tag.ToString());
                    if (detail != null)
                    {
                        bStatus = false;
                        SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                    }
                }
                else
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Fields cannot be Empty", "Customer ID", MessageBoxButton.OK);
                }
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                //if (!clsValidation.isCurrency(txtDep_amnt, ref strMessage))
                //    bStatus = false;
                //if (!clsValidation.isCurrency(txtCredit_limit, ref strMessage))
                //    bStatus = false;
                //if (!clsValidation.isInteger(txtCredit_period, ref strMessage))
                //    bStatus = false;
                //if (!clsValidation.isInteger(txtCommission, ref strMessage))
                //    bStatus = false;
                //if (!clsValidation.isCurrency(txtSales_dues, ref strMessage))
                //    bStatus = false;
                //if (!clsValidation.isCurrency(txtCredit_balance, ref strMessage))
                //    bStatus = false;
                //if (!clsValidation.isCurrency(txtTot_sales, ref strMessage))
                //    bStatus = false;

                //if (bStatus == false)
                //    SEACCMessageBox.Show("invalied curency value", strMessage);
            }
            catch (Exception ex)
            {
                //  clsValidate.WriteErrorLog(ex.Message, iFormID);
                //   MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (bStatus == false)
            {
                //  MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_genItemMaster details = tbl_genItemMaster.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtItem_ID.IsEnabled = false;

                        txtItem_code.Text = details.GenerateCode;
                        txtItem_ID.Tag = details.Item_ID;

                        txtItem_name.Text = details.ItemName;
                        txtItem_des1.Text = details.Description;
                        txtItem_des2.Text = details.Description1;
                        txtHS_code.Text = details.ItemHS_code;

                        txtItem_class.Tag = details.ItemClass_ID;
                        txtItem_class.Text = clsRef_Name.get_Item_Class(details.ItemClass_ID);
                        txtItem_type.Tag = details.ItemType_ID;
                        txtItem_type.Text = clsRef_Name.get_Item_Type(details.ItemType_ID);
                        txtItem_category.Tag = details.ItemCategory_ID;
                        txtItem_category.Text = clsRef_Name.get_Item_Category(details.ItemCategory_ID);

                        txtSub_category.Tag = details.ItemCategorySub_ID;
                        txtSub_category.Text = details.ItemCategorySub_ID;
                        txtSubstitute_item.Tag = details.SubItem_ID;
                        txtSubstitute_item.Text = details.SubItem_ID;
                        txtRemarks.Text = details.Remark;
                        txtBrand.Tag = details.Brand_ID;
                        txtBrand.Text = clsRef_Name.get_Item_Brand(details.Brand_ID);
                        txtUom.Tag = details.Uom_ID;
                        txtUom.Text = clsRef_Name.get_Item_Uom(details.Uom_ID);
                        txtTag1.Tag = details.Tag1_ID;
                        txtTag1.Text = clsRef_Name.get_Item_Tag1(details.Tag1_ID);
                        txtTag2.Tag = details.Tag1_ID;
                        txtTag2.Text = clsRef_Name.get_Item_Tag2(details.Tag1_ID);

                        txtMin_stock_level.Text = cls_Formater.FormatDecimal(decimal.Parse(details.MinStockLevel.ToString()), 2);
                        txtReorder_level.Text = cls_Formater.FormatDecimal(decimal.Parse(details.ReReoverLevel.ToString()), 0);
                        txtReorder_qty.Text = cls_Formater.FormatDecimal(decimal.Parse(details.ReOrderQty.ToString()), 0);
                        txtCost_price.Text = cls_Formater.FormatDecimal(decimal.Parse(details.CostPrice.ToString()), 0);
                        
                        tbl_genItemMaster_Finance oFin = tbl_genItemMaster_Finance.Select(details.Item_ID, "default", "default", "0", "0");
                        if (oFin != null && oFin.Item_ID != "default")
                        {
                            txtWght_avg_cost.Text = cls_Formater.FormatDecimal(decimal.Parse(oFin.WeightedAverageCostPrice.ToString()), 2);
                            txtHeighest_cost.Text = cls_Formater.FormatDecimal(decimal.Parse(oFin.HighestPurchaseCostPrice.ToString()), 2);
                            txtLIFO_cost.Text = cls_Formater.FormatDecimal(decimal.Parse(oFin.LIFOCostPrice.ToString()), 2);
                            txtFIFO_cost.Text = cls_Formater.FormatDecimal(decimal.Parse(oFin.FIFOCostPrice.ToString()), 2);
                            txtLowest_cost.Text = cls_Formater.FormatDecimal(decimal.Parse(oFin.LovesetPurchaseCostPrice.ToString()), 2);
                        }
                        else
                        {
                            txtWght_avg_cost.Text = "0.00";
                            txtHeighest_cost.Text = "0.00";
                            txtLIFO_cost.Text = "0.00";
                            txtFIFO_cost.Text = "0.00";
                            txtLowest_cost.Text = "0.00";
                        }

                        chkIsTIEPItem.IsChecked = details.IsTIEPItem;
                        chkIsImportItem.IsChecked = details.IsImportItem;
                        chkIsExportSalesItem.IsChecked = details.IsExportSalesItem;
                        chkIsUnitQtyPricing.IsChecked = !details.IsWeightCalculation_Purchase;

                        txtKilo_price.Text = cls_Formater.FormatDecimal(decimal.Parse(details.KiloPrice.ToString()), 2);
                        txtSelling_price.Text = cls_Formater.FormatDecimal(decimal.Parse(details.SellingPrice1.ToString()), 2);
                        txtWholesale_price.Text = cls_Formater.FormatDecimal(decimal.Parse(details.WholesalePrice.ToString()), 2);
                        txtDutyFree_price.Text = cls_Formater.FormatDecimal(decimal.Parse(details.SellingPrice2.ToString()), 2);
                        txtSVAT_price.Text = cls_Formater.FormatDecimal(decimal.Parse(details.SellingPrice3.ToString()), 2);
                        txtAllinclusive_price.Text = cls_Formater.FormatDecimal(decimal.Parse(details.SellingPrice4.ToString()), 2);
                        //txtOther_price.Text = cls_Formater.FormatDecimal(decimal.Parse(details.LovesetPurchaseCostPrice.ToString()), 2);

                        chkIsUnitQtyPricing1.IsChecked = details.IsWeightCalculation_Sales;
                        chkIsUnitQtyPricing2.IsChecked = details.ItemModel1;
                        chkIsUnitQtyPricing3.IsChecked = details.ItemModel2;

                    }
                }

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Genarate Search Code
        private void GenarateCode()
        {
            try
            {
                string sCode = "";
                if (txtItem_class.Tag != null)
                {
                    tbl_zItemClass clsDetail = tbl_zItemClass.Select(txtItem_class.Tag.ToString());
                    if (clsDetail.Prefrix != null)
                        sCode += clsDetail.Prefrix.ToUpper() + "/";
                }
                if (txtItem_type.Tag != null)
                {
                    tbl_zItemType typDetail = tbl_zItemType.Select(txtItem_type.Tag.ToString());
                    if (typDetail.Prefrix != null)
                        sCode += typDetail.Prefrix.ToUpper() + "/";
                }
                if (txtItem_category.Tag != null)
                {
                    tbl_zItemCategory catDetail = tbl_zItemCategory.Select(txtItem_category.Tag.ToString());
                    if (catDetail.Prefrix != null)
                        sCode += catDetail.Prefrix.ToUpper() + "/";
                }
                if (txtSub_category.Tag != null)
                {
                    tbl_zItemCategory_Sub subDetail = tbl_zItemCategory_Sub.Select(txtSub_category.Tag.ToString());
                    if (subDetail.Prefrix != null)
                        sCode += subDetail.Prefrix.ToUpper() + "/";
                }
                //if ((txtTypeID.Tag != null) && ((txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemSemiFinishedGood)) ||
                //(txtTypeID.Tag.ToString() == clsAutocode.getFormConfigCode(FormName.ItemFinishedGood))))
                //{
                //    string sTmp = "";
                //    decimal dWidth = 0, dThickness = 0;
                //    if (clsCommon.isCurrency(txtWidth.Text.Trim()) && txtWidth.Text.Trim().Length > 0)
                //        dWidth = decimal.Parse(txtWidth.Text.Trim());
                //    if (clsCommon.isCurrency(txtThickness.Text.Trim()) && txtThickness.Text.Trim().Length > 0)
                //        dThickness = decimal.Parse(txtThickness.Text.Trim());
                //    if (dWidth > 0)
                //    {
                //        sTmp = clsCommon.FormatToNumberNoDecimal(dWidth) + "X" + sTmp;
                //    }
                //    if (dThickness > 0 && sTmp.Trim().Length > 0)
                //    {
                //        sTmp = sTmp + clsCommon.FormatToNumberNoDecimal(dThickness);
                //    }
                //    else if (dThickness > 0)
                //    {
                //        sTmp = sTmp + "X" + clsCommon.FormatToNumberNoDecimal(dThickness);
                //    }

                //    if (sTmp.Trim().Length > 0)
                //    {
                //        sCode += sTmp;
                //    }

                //}
                //else
                //{
                //    sCode += txtItemName.Text.Trim().ToUpper();
                //}

                txtItem_code.Text = sCode.Trim();

            }
            catch (Exception ex)
            {
                //clsValidate.WriteErrorLog(iFormID.ToString() + " - " + ex.Message);
                //clsValidate.WriteErrorLog(ex.Message, iFormID);
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
                    string periodID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    fillDetails(periodID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events
        private void txtItem_class_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemClass);
            if (RowDataSearch.DialogResult == true)
            {
                txtItem_class.Tag = lstResult[0];
                txtItem_class.Text = lstResult[1];
            }

            GenarateCode();
        }        

        private void txtItem_type_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemType);
            if (RowDataSearch.DialogResult == true)
            {
                txtItem_type.Tag = lstResult[0];
                txtItem_type.Text = lstResult[1];
            }
            GenarateCode();
        }

        private void txtItem_category_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtItem_category.Tag = lstResult[0];
                txtItem_category.Text = lstResult[1];
            }
            GenarateCode();
        }

        private void txtBrand_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Brand);
            if (RowDataSearch.DialogResult == true)
            {
                txtBrand.Tag = lstResult[0];
                txtBrand.Text = lstResult[1];
            }
        }

        private void txtUom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtUom.Tag = lstResult[0];
                txtUom.Text = lstResult[1];
            }
        }

        private void txtTag1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tag1);
            if (RowDataSearch.DialogResult == true)
            {
                txtTag1.Tag = lstResult[0];
                txtTag1.Text = lstResult[1];
            }
        }

        private void txtTag2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tag2);
            if (RowDataSearch.DialogResult == true)
            {
                txtTag2.Tag = lstResult[0];
                txtTag2.Text = lstResult[1];
            }
        }
        #endregion
    }
}
