using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Common;
using SEACC_PRODUCTION_PHARMA.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_PHARMA.Controls
{
    /// <summary>
    /// Developped by Gayan
    /// On 2017-05-04
    /// </summary>
    public partial class frm_RawMeterial_FGTN_Input : Window
    {
        #region Class Variables
        public DataTable dtMeterialInput = new DataTable();

        private string sStore_ID = "";
        #endregion

        #region Form Load
        public frm_RawMeterial_FGTN_Input(string sRequestedStore_ID)
        {
            InitializeComponent();
            sStore_ID = sRequestedStore_ID;

            #region Input Material Grid
            dtMeterialInput.Columns.Add("LineNo");
            dtMeterialInput.Columns.Add("Item_ID");
            dtMeterialInput.Columns.Add("ItemNameMat");
            dtMeterialInput.Columns.Add("UoM_ID");
            dtMeterialInput.Columns.Add("UoM");
            dtMeterialInput.Columns.Add("FloorQty");
            dtMeterialInput.Columns.Add("Qty");
            dtMeterialInput.Columns.Add("Remarks");
            #endregion

            dgr_MererialInput.ItemsSource = dtMeterialInput.DefaultView;
        }
        #endregion

        #region Action Buttons
        private void btnCloseTop_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dtMeterialInput.Clear();
            dgr_MererialInput.ItemsSource = dtMeterialInput.DefaultView;
        }

        private void btnGridItemAdd_Click_1(object sender, RoutedEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionMaterials, true);
            RowDataSearch.RowSelected += RowDataSearch_RowSelected;

        }

        private void RowDataSearch_RowSelected(List<string> lstResult)
        {
            try
            {
                bool bAddItem = false;
                DataRow[] items = dtMeterialInput.Select("Item_ID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    if (SEACCMessageBox.Show("Item Already Exist in Line No: " + sLineNo, "Do you need to add it again? ", MessageBoxButton.YesNo, "Red"))
                        bAddItem = true;
                }

                if (bAddItem)
                {
                    string sItemID = lstResult[0];
                    string sItemName = clsGenaralName.getName_Item(sItemID);
                    string sItemUoM_ID = clsGenaralName.getName_ItemUOMID(sItemID);
                    string sItemUoM_Name = clsGenaralName.getName_Uom(sItemUoM_ID);
                    decimal dFloorQty = 0;
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
                    tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(sStore_ID);
                    if (oItem != null && oStore != null )
                    {
                        dFloorQty = clsHelpMethods_Prod.Get_StoreStockBalance_Qty(oStore.Store_ID, oItem.Item_ID);
                    }

                    dtMeterialInput.Rows.Add(
                        "0",
                        sItemID,
                        sItemName,
                        sItemUoM_ID,
                        sItemUoM_Name,
                        cls_Formater.FormatDecimal(dFloorQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                        "");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);

            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_MererialInput.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_MererialInput.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtMeterialInput.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtMeterialInput.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterialInput);
            }
        }
        #endregion

        #region Grid Events

        private void dgr_MererialReq_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterialInput);
        }

        private void dgr_MererialReq_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnName == "Qty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    dQty = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }

                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
            }
        }
        #endregion

        #region Other Events
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion


        public int ShowDialogBox()
        {
            ShowDialog();
            return dtMeterialInput.Rows.Count;
        }
    }
}
