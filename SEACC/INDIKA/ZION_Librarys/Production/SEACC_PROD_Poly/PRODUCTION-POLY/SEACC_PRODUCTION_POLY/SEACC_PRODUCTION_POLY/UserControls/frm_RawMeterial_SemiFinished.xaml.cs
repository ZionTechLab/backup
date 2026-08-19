using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Common;
using SEACC_PRODUCTION_POLY.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace SEACC_PRODUCTION_POLY.UserControls
{
    /// <summary>
    /// Developped by Gayan
    /// On 2017-05-04
    /// </summary>
    public partial class frm_RawMeterial_SemiFinished : Window
    {
        #region Class Variables
        string sFinishedGood_ID = "";

        public DataTable dtMeterialReq = new DataTable();
        #endregion

        #region Form Load
        public frm_RawMeterial_SemiFinished(string sItem_FG)
        {
            InitializeComponent();
            sFinishedGood_ID = sItem_FG;

            #region Meterial Table
            dtMeterialReq.Columns.Add("LineNo");
            dtMeterialReq.Columns.Add("Item_ID");
            dtMeterialReq.Columns.Add("ItemName");
            dtMeterialReq.Columns.Add("UoM_ID");
            dtMeterialReq.Columns.Add("UoM");
            dtMeterialReq.Columns.Add("UoM_ID_Weight");
            dtMeterialReq.Columns.Add("UoM_Weight");
            dtMeterialReq.Columns.Add("Qty");
            dtMeterialReq.Columns.Add("Weight");
            dtMeterialReq.Columns.Add("Wastage");
            dtMeterialReq.Columns.Add("TotalQty");
            dtMeterialReq.Columns.Add("TotalWeight");
            dtMeterialReq.Columns.Add("SectionID");
            dtMeterialReq.Columns.Add("SectionName");
            dtMeterialReq.Columns.Add("EstTime");
            dtMeterialReq.Columns.Add("LabourCount");
            #endregion

            dgr_MererialReq.ItemsSource = dtMeterialReq.DefaultView;
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
            dtMeterialReq.Clear();
            dgr_MererialReq.ItemsSource = dtMeterialReq.DefaultView;
        }

        private void btnGridItemAdd_Click_1(object sender, RoutedEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionMaterials, true);
            RowDataSearch.RowSelected += RowDataSearch_RowSelected;

        }

        private void RowDataSearch_RowSelected(List<string> lstResult)
        {
            try
            {
                bool bAddItem = false;
                DataRow[] items = dtMeterialReq.Select("Item_ID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    if (SEACCMessageBox.Show("Meterial Already Exist in Line No: " + sLineNo, "Do you need to add it again? ", MessageBoxButton.YesNo, "Red"))
                        bAddItem = true;
                }

                if (bAddItem)
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(lstResult[0]);
                    tbl_prod_polyTxFinishedGoodSpecsSheet oFG = tbl_prod_polyTxFinishedGoodSpecsSheet.Select(sFinishedGood_ID);
                    if (oItem != null && oFG != null)
                    {
                        dtMeterialReq.Rows.Add("", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID),
                            oItem.Uom_ID,
                            clsGenaralName.getName_Uom(oItem.Uom_ID),
                            oFG.Uom_ID_Weight,
                            clsGenaralName.getName_Uom(oFG.Uom_ID_Weight),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Weight),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Weight),
                            "default", "<Select Section>", "0.00", "0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_MererialReq.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_MererialReq.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtMeterialReq.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtMeterialReq.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterialReq);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_MererialReq_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void dgr_MererialReq_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterialReq);
        }

        private void dgr_MererialReq_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_MererialReq.CurrentCell;
                int irowID = dgr_MererialReq.SelectedIndex;

                if (vDG_Cell.Column.Header.ToString() == "Prod. Section")
                {
                    frm_search RowDataSearch = new frm_search();
                    RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                    RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
                    if (RowDataSearch.DialogResult == true)
                    {
                        dtMeterialReq.Rows[irowID]["SectionID"] = lstResult[0];
                        dtMeterialReq.Rows[irowID]["SectionName"] = lstResult[1];
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void dgr_MererialReq_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //string sColumnName = e.Column.Header.ToString();
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnName == "Qty" || sColumnName == "Weight" || sColumnName == "Wastage" || sColumnName == "LabourCount" || sColumnName == "EstTime")
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

                if (sColumnName == "EstTime" || sColumnName == "LabourCount")
                    t.Text = cls_Formater.FormatDecimal(dQty, 2);
                else
                    t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
            }

            CalculateTotalQty();
        }
        #endregion

        #region Help Method
        private void CalculateTotalQty()
        {
            try
            {
                foreach (DataRow row in dtMeterialReq.Rows)
                {
                    decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0);
                    decimal dWeight = clsValidate.ValidateRowValue(row, "Weight", 0);
                    decimal dwastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0);

                    row["TotalQty"] = cls_Formater.FormatDecimal(dQty * (100 + dwastage_Pct) / 100, clsConfig.sDecimalPlaces_Quantity);
                    row["TotalWeight"] = cls_Formater.FormatDecimal(dWeight * (100 + dwastage_Pct) / 100, clsConfig.sDecimalPlaces_Weight);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

        }
        #endregion

        #region Other Events
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion

    }
}
