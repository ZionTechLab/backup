using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Common;
using SEACC_PRODUCTION_PHARMA.Controls;
using SEACC_PRODUCTION_PHARMA.Search;
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

namespace SEACC_PRODUCTION_PHARMA
{
    /// <summary>
    /// Interaction logic for frm_RawMeterialGroups_SemiFinished.xaml
    /// </summary>
    public partial class frm_RawMeterialGroups_SemiFinished : Window
    {
        #region Class Variables
        public DataTable dtMeterialReq = new DataTable();

        //public string sSection_ID = "default";
        //public string sSection_Name = "<Select Section>";
        //public string sActicity_ID = "default";
        //public string sActivity_Name = "<Select Activity>";
        #endregion

        public frm_RawMeterialGroups_SemiFinished(string sTitle)
        {
            InitializeComponent();
            lblTitle.Content = sTitle;

            #region Meterial Table
            dtMeterialReq.Columns.Add("LineNo");
            dtMeterialReq.Columns.Add("LineNoMain");
            dtMeterialReq.Columns.Add("LineNoSub1");
            dtMeterialReq.Columns.Add("LineNoSub2");

            DataColumn dcSelectColumn = new DataColumn("IsSelect", typeof(string));
            dcSelectColumn.DefaultValue = "\uE003";
            dtMeterialReq.Columns.Add(dcSelectColumn);

            dtMeterialReq.Columns.Add("Item_ID");
            dtMeterialReq.Columns.Add("ItemName");
            dtMeterialReq.Columns.Add("UoM_ID");
            dtMeterialReq.Columns.Add("UoM");
            dtMeterialReq.Columns.Add("Qty");
            dtMeterialReq.Columns.Add("Wastage");
            dtMeterialReq.Columns.Add("TotalQty");
            dtMeterialReq.Columns.Add("SectionID");
            dtMeterialReq.Columns.Add("SectionName");
            dtMeterialReq.Columns.Add("ActivityID");
            dtMeterialReq.Columns.Add("ActivityName");
            dtMeterialReq.Columns.Add("SubstitueGroup");

            //Total Qty with respect to Batch Qty
            dtMeterialReq.Columns.Add("TotalQtyWithRespectBatchQty");
            #endregion

            #region Material Grid Binding
            dtMeterialReq.Clear();
            CollectionViewSource mycollection = new CollectionViewSource();
            mycollection.Source = dtMeterialReq;
            mycollection.GroupDescriptions.Add(new PropertyGroupDescription("SubstitueGroup"));
            dgr_MererialReq.ItemsSource = mycollection.View;
            #endregion
        }

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

          
        private void dgr_MererialReq_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oSelectedItem = dgr_MererialReq.SelectedItem;
                var vDG_Cell = dgr_MererialReq.CurrentCell;
                if (oSelectedItem != null)
                {
                    string Grid_LineNo = (dgr_MererialReq.SelectedCells[0].Column.GetCellContent(oSelectedItem) as TextBlock)?.Text;
                    DataRow drRow = dtMeterialReq.Select("LineNo = '" + Grid_LineNo + "'").FirstOrDefault();
                    if (drRow != null && (vDG_Cell.Column.SortMemberPath == "IsSelect" || vDG_Cell.Column.SortMemberPath == "Item_ID" || vDG_Cell.Column.SortMemberPath == "ItemName"))
                    {
                        string sSubstitueGroup = drRow["SubstitueGroup"].ToString();
                        var drSustituteRows = dtMeterialReq.AsEnumerable().Where(row => row.Field<string>("SubstitueGroup") == sSubstitueGroup);
                        foreach (var vdr in drSustituteRows)
                            vdr["IsSelect"] = "\uE003";

                        bool bIsChecked = false;
                        bIsChecked = drRow["IsSelect"].ToString() == "\uE0A2" ? true : false;
                        drRow["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";
                    }

                }
            }
            catch (Exception) { }
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
                else if (vDG_Cell.Column.Header.ToString() == "Material")
                {
                    frm_RawMeterial_SemiFinished frmSubstitute = dtMeterialReq.Rows[irowID].Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                    if (frmSubstitute != null)
                    {
                        frmSubstitute.sSection_ID = dtMeterialReq.Rows[irowID].Field<string>("SectionID");
                        frmSubstitute.sSection_Name = dtMeterialReq.Rows[irowID].Field<string>("SectionName");
                        frmSubstitute.Show();
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void dgr_MererialReq_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
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

            CalculateTotalQty();
        }

        #region Help Method
        private void CalculateTotalQty()
        {
            try
            {
                foreach (DataRow row in dtMeterialReq.Rows)
                {
                    decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                    decimal dwastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                    row["TotalQty"] = cls_Formater.FormatDecimal(dQty * (100m + dwastage_Pct) / 100, clsConfig.sDecimalPlaces_Quantity);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

        }

        #endregion

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
