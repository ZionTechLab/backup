using DataTire;
using digiteq;
using Digiteq_Logic;
using SEACC_servii.Search_Forms;
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

namespace SEACC_servii.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_ItemMaster.xaml
    /// </summary>
    public partial class UC_ItemMaster : UserControl
    {
        #region Form Load
        public UC_ItemMaster()
        {
            #region User Control Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.ItemCreationMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("CommodityCode");
            dgr_Main.dt.Columns.Add("CommodityName");
            dgr_Main.dt.Columns.Add("UoM");
            dgr_Main.dt.Columns.Add("CommodityClass");
            dgr_Main.dt.Columns.Add("CommodityType");
            dgr_Main.dt.Columns.Add("CommodityCategory");
            dgr_Main.dt.Columns.Add("CommodityBrand");
            dgr_Main.dt.Columns.Add("dailyRate");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Code", "CommodityCode", 80, false);
            dgr_Main.Add_DatagridColoumn("Name", "CommodityName", 150);
            dgr_Main.Add_DatagridColoumn("UoM", "UoM", 80);
            dgr_Main.Add_DatagridColoumn("Class", "CommodityClass", 80, false);
            dgr_Main.Add_DatagridColoumn("Type", "CommodityType", 80);
            dgr_Main.Add_DatagridColoumn("Category", "CommodityCategory", 80, false);
            dgr_Main.Add_DatagridColoumn("Brand", "CommodityBrand", 80, false);
            dgr_Main.Add_DatagridColoumn("Daily Rate", "dailyRate", 80);
            #endregion

            ClearFields();
            RefreshGrid();

        } 
        #endregion

        #region Action Buttons

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_genItemMaster OldItem = tbl_genItemMaster.Select(txtCommodityCode.Text.Trim());
                            if (OldItem != null)
                            {
                                tbl_genItemMaster oItem = new tbl_genItemMaster(txtCommodityCode.Text, OldItem.GenerateCode, txtCommodityName.Text, txtCommodityDescription.Text, OldItem.Description1, OldItem.Remark, OldItem.Origin, OldItem.CostPrice, OldItem.KiloPrice, OldItem.WaitedAverageCostPrice, OldItem.RecentCostPrice,
                                    decimal.Parse(txtGenPrice15.Text), decimal.Parse(txtGenPrice30.Text), decimal.Parse(txtExtPrice15.Text), decimal.Parse(txtExtPrice30.Text), OldItem.WholesalePrice, OldItem.MinStockLevel, OldItem.MaxStockLevel, OldItem.ReReoverLevel,
                                    OldItem.ReOrderQty, OldItem.IsTIEPItem, OldItem.IsImportItem, OldItem.IsExportSalesItem, OldItem.IsCombinationMaterail, OldItem.IsServiceItem, OldItem.ItemCategorySub_ID, txtCommodityCategory.Tag.ToString(), txtCommodityClass.Tag.ToString(), txtCommodityType.Tag.ToString(), OldItem.RoleType_ID, txtCommodityBrand.Tag.ToString(), OldItem.SubItem_ID, txtUOM.Tag.ToString(), OldItem.Width, OldItem.Height, OldItem.Thickness, decimal.Parse(txtDailyRate.Text), decimal.Parse(txtUnitWeight.Text), OldItem.Gusset, OldItem.Qty, OldItem.CalculationRate_Weight, OldItem.CalculationRate_LFeet, OldItem.MeasureType_ID, OldItem.IsWeightCalculation_Sales, OldItem.IsWeightCalculation_Purchase, OldItem.IsDeleted, OldItem.IsVATinclusive, OldItem.IsNBTinclusive, OldItem.ImagePath);
                                oItem.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    else
                    {                        
                        tbl_genItemMaster nItem = new tbl_genItemMaster(txtCommodityCode.Tag.ToString(), "default", txtCommodityName.Text, txtCommodityDescription.Text, "", "", "", 0, 0, 0, 0, decimal.Parse(txtGenPrice15.Text), decimal.Parse(txtGenPrice30.Text), decimal.Parse(txtExtPrice15.Text), decimal.Parse(txtExtPrice30.Text), 0, 0, 0, 0, 0, false, false, false, false, false, "default", txtCommodityCategory.Tag.ToString(), txtCommodityClass.Tag.ToString(), txtCommodityType.Tag.ToString(), "", txtCommodityBrand.Tag.ToString(), "", txtUOM.Tag.ToString(), 0, 0, 0, decimal.Parse(txtDailyRate.Text), decimal.Parse(txtUnitWeight.Text), 0, 0, 0, 0, "default", false, false, false, false, false, "");
                        nItem.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                }
            }
        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
        }
        
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCommodityCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCommodityName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUOM, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCommodityClass, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCommodityType, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCommodityCategory, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCommodityBrand, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCommodityDescription, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtGenPrice15, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtGenPrice30, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtExtPrice15, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtExtPrice30, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtUnitWeight, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtDailyRate, true, true, true);


            txtCommodityCode.Text = "";
            txtCommodityName.Text = "";
            txtUOM.Text = "";
            txtCommodityClass.Text = "";
            txtCommodityType.Text = "";
            txtCommodityCategory.Text = "";
            txtCommodityBrand.Text = "";
            txtCommodityDescription.Text = "";
            txtGenPrice15.Text = "0.00";
            txtGenPrice30.Text = "0.00";
            txtExtPrice15.Text = "0.00";
            txtExtPrice30.Text = "0.00";
            txtUnitWeight.Text = "0.00";
            txtDailyRate.Text = "0.00";

            txtCommodityCode.Tag = null;
            txtUOM.Tag = null;
            txtCommodityClass.Tag = "default";
            txtCommodityType.Tag = null;
            txtCommodityCategory.Tag = "default";
            txtCommodityBrand.Tag = "default";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCommodityCode.setReadOnlyStatus(true);
                txtCommodityCode.Text = "<Auto Generate>";
            }
            else
                txtCommodityCode.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genItemMaster item in tbl_genItemMaster.SelectAll().Where(p => p.Item_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(item.Item_ID, item.ItemName, clsRef_Name.get_UoM_Name(item.Uom_ID), clsRef_Name.get_ItemClass_Name(item.ItemClass_ID), clsRef_Name.get_ItemType_Name(item.ItemType_ID), clsRef_Name.get_ItemCategory_Name(item.ItemCategory_ID), clsRef_Name.get_ItemBrand_Name(item.Brand_ID), cls_Formater.FormatDecimal(decimal.Parse(item.DailyRate.ToString()), 2));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtCommodityCode))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCommodityName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtUOM))
                bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtCommodityClass))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCommodityType))
                bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtCommodityCategory))
            //    bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtCommodityBrand))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtGenPrice15))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtGenPrice30))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtExtPrice15))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtExtPrice30))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtUnitWeight))
                bStatus = false;
            

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtCommodityCode.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_genItemMaster oDetail = tbl_genItemMaster.Select(txtCommodityCode.Tag.ToString());
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
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
                    tbl_genItemMaster FillDetails = tbl_genItemMaster.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtCommodityCode.IsEnabled = false;

                        txtCommodityCode.Text = FillDetails.Item_ID;
                        txtCommodityName.Text = FillDetails.ItemName;
                        txtUOM.Text = FillDetails.Uom_ID + " - " + clsRef_Name.get_UoM_Name(FillDetails.Uom_ID);
                        txtCommodityClass.Text = FillDetails.ItemClass_ID + " - " + clsRef_Name.get_ItemClass_Name(FillDetails.ItemClass_ID);
                        txtCommodityType.Text = FillDetails.ItemType_ID + " - " + clsRef_Name.get_ItemType_Name(FillDetails.ItemType_ID);
                        txtCommodityCategory.Text = FillDetails.ItemCategory_ID + " - " + clsRef_Name.get_ItemCategory_Name(FillDetails.ItemCategory_ID);
                        txtCommodityBrand.Text = FillDetails.Brand_ID + " - " + clsRef_Name.get_ItemBrand_Name(FillDetails.Brand_ID);
                        txtCommodityDescription.Text = FillDetails.Description;
                        txtGenPrice15.Text = cls_Formater.FormatDecimal(decimal.Parse(FillDetails.SellingPrice1.ToString()),2);
                        txtGenPrice30.Text = cls_Formater.FormatDecimal(decimal.Parse(FillDetails.SellingPrice2.ToString()),2);
                        txtExtPrice15.Text = cls_Formater.FormatDecimal(decimal.Parse(FillDetails.SellingPrice3.ToString()),2);
                        txtExtPrice30.Text = cls_Formater.FormatDecimal(decimal.Parse(FillDetails.SellingPrice4.ToString()),2);
                        txtUnitWeight.Text = cls_Formater.FormatDecimal(decimal.Parse(FillDetails.UnitWeight.ToString()),2);
                        txtDailyRate.Text = cls_Formater.FormatDecimal(decimal.Parse(FillDetails.DailyRate.ToString()), 2);

                        txtCommodityCode.Tag = FillDetails.Item_ID;
                        txtUOM.Tag = FillDetails.Uom_ID;
                        txtCommodityClass.Tag = FillDetails.ItemClass_ID;
                        txtCommodityType.Tag = FillDetails.ItemType_ID;
                        txtCommodityCategory.Tag = FillDetails.ItemCategory_ID;
                        txtCommodityBrand.Tag = FillDetails.Brand_ID;
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events

        private void txtCommodityCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Items);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtCommodityCode.Text = lstResult[0];
                txtCommodityCode.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtUOM_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtUOM.Text = lstResult[0] + " - " + lstResult[1];
                txtUOM.Tag = lstResult[0];
            }
        }

        private void txtCommodityClass_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemClass);
            if (RowDataSearch.DialogResult == true)
            {
                txtCommodityClass.Text = lstResult[0] + " - " + lstResult[1];
                txtCommodityClass.Tag = lstResult[0];
            }
        }

        private void txtCommodityType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemType);
            if (RowDataSearch.DialogResult == true)
            {
                txtCommodityType.Text = lstResult[0] + " - " + lstResult[1];
                txtCommodityType.Tag = lstResult[0];
            }
        }

        private void txtCommodityCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtCommodityCategory.Text = lstResult[0] + " - " + lstResult[1];
                txtCommodityCategory.Tag = lstResult[0];
            }
        }

        private void txtCommodityBrand_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemBrand);
            if (RowDataSearch.DialogResult == true)
            {
                txtCommodityBrand.Text = lstResult[0] + " - " + lstResult[1];
                txtCommodityBrand.Tag = lstResult[0];
            }
        }
        #endregion

    }
}
