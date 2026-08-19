using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Common;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_APPAREL.Controls
{
    /// <summary>
    /// Developped by Gayan
    /// On 2017-05-04
    /// </summary>
    public partial class frm_RawMeterial_SemiFinished : Window
    {
        #region Class Variables
        public DataTable dtMeterialReq = new DataTable();
        private bool bIsSubstituteItemsShow = false;

        public string sSection_ID = "default";
        public string sSection_Name = "<Select Section>";
        #endregion

        #region Form Load
        public frm_RawMeterial_SemiFinished(string sTitle, bool isSubstituteItemsShow)
        {
            InitializeComponent();
            lblTitle.Content = sTitle;

            #region Meterial Table
            dtMeterialReq.Columns.Add("LineNo");
            dtMeterialReq.Columns.Add("Item_ID");
            dtMeterialReq.Columns.Add("ItemName");
            dtMeterialReq.Columns.Add("UoM_ID");
            dtMeterialReq.Columns.Add("UoM");
            dtMeterialReq.Columns.Add("Qty");
            dtMeterialReq.Columns.Add("Wastage");
            dtMeterialReq.Columns.Add("TotalQty");
            dtMeterialReq.Columns.Add("SectionID");
            dtMeterialReq.Columns.Add("SectionName");
            dtMeterialReq.Columns.Add("EstTime");
            dtMeterialReq.Columns.Add("LabourCount");
            dtMeterialReq.Columns.Add("Substitute_RawMeterials", typeof(frm_RawMeterial_SemiFinished));
            dtMeterialReq.Columns.Add("MatOption_Count");
            #endregion

            bIsSubstituteItemsShow = isSubstituteItemsShow;

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
            RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials, true);
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
                    if (oItem != null)
                    {
                        frm_RawMeterial_SemiFinished frmSubstituteMats = new frm_RawMeterial_SemiFinished("Substituting Meterial List ", true);
                        dtMeterialReq.Rows.Add("", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Uom_ID, clsGenaralName.getName_Uom(oItem.Uom_ID),
                            "0.000", "0.000", "0.000", sSection_ID, sSection_Name, "0.00", "0.00", frmSubstituteMats, "1 Option");
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
                else if (vDG_Cell.Column.Header.ToString() == "Material" || vDG_Cell.Column.Header.ToString() == "Option(s)")
                {
                    frm_RawMeterial_SemiFinished frmSubstitute = dtMeterialReq.Rows[irowID].Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                    if (frmSubstitute != null)
                    {
                        frmSubstitute.sSection_ID = dtMeterialReq.Rows[irowID].Field<string>("SectionID");
                        frmSubstitute.sSection_Name = dtMeterialReq.Rows[irowID].Field<string>("SectionName");
                        frmSubstitute.WindowStartupLocation = WindowStartupLocation.Manual;
                        int iSubstituteMats = frmSubstitute.ShowDialogBox();
                        dtMeterialReq.Rows[irowID]["MatOption_Count"] = iSubstituteMats == 0 ? "1 Option" : (iSubstituteMats + 1) + " Options";
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
            if (sColumnName == "Qty" || sColumnName == "Wastage" || sColumnName == "LabourCount" || sColumnName == "EstTime")
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
            //else if (sColumnName == "EstTime")
            //{
            //    t = e.EditingElement as TextBox;
            //    if (t.Text == "0" || t.Text == "00")
            //    {
            //        t.Text = "00:00";
            //    }
            //    else
            //    {
            //        try
            //        {
            //            int iSMV_Mins = clsValidation.GetMinutes(t.Text);
            //        }
            //        catch (Exception)
            //        {
            //            SEACCMessageBox.Show("Oops..!", "Invalid Format", MessageBoxButton.OK);
            //        }
            //    }
            //}
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
                    decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                    decimal dwastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                    row["TotalQty"] = cls_Formater.FormatDecimal(dQty * (100 + dwastage_Pct) / 100, clsConfig.sDecimalPlaces_Quantity);
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

        public int ShowDialogBox()
        {
            ShowDialog();
            return dtMeterialReq.Rows.Count;
        }

        private void frmWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (bIsSubstituteItemsShow)
                dgr_MererialReq.Columns[dgr_MererialReq.Columns.Count - 1].MaxWidth = 0;
        }
    }
}
