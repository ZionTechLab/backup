using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Search;
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

namespace SEACC_PRODUCTION_POLY.Masters.Item
{
    /// <summary>
    /// Interaction logic for UC_SemiFinished_Outsource.xaml
    /// </summary>
    public partial class UC_SemiFinished_Outsource : UserControl
    {
        public UC_SemiFinished_Outsource()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_SemiFinishedOutsource;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ItemID");
            dgr_Main.dt.Columns.Add("ItemName");
            dgr_Main.dt.Columns.Add("SupplierID");
            dgr_Main.dt.Columns.Add("SupplierName");
            dgr_Main.dt.Columns.Add("OutsourceRate");
            dgr_Main.dt.Columns.Add("LastUpdateDate");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("SF Item ID", "ItemID", 75, false);
            dgr_Main.Add_DatagridColoumn("Semi Finished Name", "ItemName", 250);
            dgr_Main.Add_DatagridColoumn("Contractor/Supplier ID", "SupplierID", 75, false);
            dgr_Main.Add_DatagridColoumn("Contractor/Supplier Name", "SupplierName", 150);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Rate", "OutsourceRate", 75, true, true);
            dgr_Main.Add_DatagridColoumn("Last Update Time", "LastUpdateDate", 150);
            #endregion

            ClearFields();
            RefreshGrid();

        }

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genItemMaster_Outsorce oItem_Outsource in tbl_genItemMaster_Outsorce.SelectAll().Where(p => p.Item_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oItem_Outsource.Item_ID, clsGenaralName.getName_Item(oItem_Outsource.Item_ID), oItem_Outsource.Supplier_ID, clsGenaralName.getName_Supplier(oItem_Outsource.Supplier_ID), cls_Formater.FormatDecimal(oItem_Outsource.Outsource_Rate, clsConfig.sCurrencyDecimalPlaces_UnitPrice), oItem_Outsource.LastUpdate_Date.ToString(cls_Formater.Format_Date2));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSF_Item, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSuppier, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOutsourceRate, true, true, false);

            txtSF_Item.Tag = null;
            txtSuppier.Tag = null;

            txtSF_Item.Text = "";
            txtSuppier.Text = "";
            txtOutsourceRate.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);

        }
        #endregion

        #region Action Buttons
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                string sSF_Item_ID = "", sSupplier_ID = "";

                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_genItemMaster_Outsorce oOldItem_Outsource = tbl_genItemMaster_Outsorce.Select(txtSF_Item.Tag.ToString(), txtSuppier.Tag.ToString());
                            if (oOldItem_Outsource != null)
                            {
                                tbl_genItemMaster_Outsorce oItem_Outsource = new tbl_genItemMaster_Outsorce(txtSF_Item.Tag.ToString(), txtSuppier.Tag.ToString(), clsValidation.Validate_DecimalNumber(txtOutsourceRate.Text), clsSecurity.getServerDateTime());
                                oItem_Outsource.Update();

                                sSF_Item_ID = oOldItem_Outsource.Item_ID;
                                sSupplier_ID = oOldItem_Outsource.Supplier_ID;

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_genItemMaster_Outsorce oNewItem_Outsource = new tbl_genItemMaster_Outsorce(txtSF_Item.Tag.ToString(), txtSuppier.Tag.ToString(), clsValidation.Validate_DecimalNumber(txtOutsourceRate.Text), clsSecurity.getServerDateTime());
                            oNewItem_Outsource.Insert();

                            sSF_Item_ID = oNewItem_Outsource.Item_ID;
                            sSupplier_ID = oNewItem_Outsource.Supplier_ID;

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
                    ClearFields();
                    RefreshGrid();
                    fillDetails(sSF_Item_ID, sSupplier_ID);
                }
            }
        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sSF_ItemID, string sSupplierID)
        {
            try
            {
                tbl_genItemMaster_Outsorce oItem_Outsource = tbl_genItemMaster_Outsorce.Select(sSF_ItemID, sSupplierID);
                if (oItem_Outsource != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtSF_Item.Tag = oItem_Outsource.Item_ID;
                    txtSuppier.Tag = oItem_Outsource.Supplier_ID;

                    txtSF_Item.Text = clsGenaralName.getName_Item(oItem_Outsource.Item_ID);
                    txtSuppier.Text = clsGenaralName.getName_Supplier(oItem_Outsource.Supplier_ID);
                    txtOutsourceRate.Text = cls_Formater.FormatDecimal(oItem_Outsource.Outsource_Rate, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
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

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string sItem_ID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string sSupplier_ID = (dgr_Main.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(sItem_ID, sSupplier_ID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
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
                {
                    bStatus = true;
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtSF_Item))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSuppier))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtOutsourceRate))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genItemMaster_Outsorce oRange = tbl_genItemMaster_Outsorce.Select(txtSF_Item.Tag.ToString(), txtSuppier.Tag.ToString());
                if (oRange != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        #endregion

        #region Search Events
        private void txtSF_Item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionSemiFinisheds);
            if (RowDataSearch.DialogResult == true)
            {
                txtSF_Item.Tag = lstResult[0];
                txtSF_Item.Text = lstResult[1];

                if (txtSuppier.Tag != null)
                {
                    fillDetails(lstResult[0], txtSuppier.Tag.ToString());
                }
            }
        }

        private void txtSuppier_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionContractor);
            if (RowDataSearch.DialogResult == true)
            {
                txtSuppier.Tag = lstResult[0];
                txtSuppier.Text = lstResult[1];

                if (txtSF_Item.Tag != null)
                {
                    fillDetails(txtSF_Item.Tag.ToString(), lstResult[0]);
                }
            }
        }
        #endregion
    }
}
