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
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Common;
using SEACC_PRODUCTION_POLY.Search;
using SEACC_PRODUCTION_POLY.UserManagement;
using SEACC_WPFControls;

namespace SEACC_PRODUCTION_POLY
{
    /// <summary>
    /// Interaction logic for UC_BOMRemoving.xaml
    /// </summary>
    public partial class UC_BOMRemoving : UserControl
    {
        #region Class Variables
        DataTable dtBoM = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_BOMRemoving()
        {
            #region Usercontrol Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Prod_BOMRemoving;
            SEACC_Form.Initialize();
            #endregion

            #region BoM Table Initialize
            dtBoM.Columns.Add("LineNo", typeof(int));
            dtBoM.Columns.Add("IsSelect");
            dtBoM.Columns.Add("BoM_No");
            dtBoM.Columns.Add("Customer");
            dtBoM.Columns.Add("JobType");
            dtBoM.Columns.Add("FG_Item");
            dtBoM.Columns.Add("FG_SalesCode");
            dtBoM.Columns.Add("FG_SalesName");
            dtBoM.Columns.Add("FG_UoM");
            dtBoM.Columns.Add("FG_Qty");
            dtBoM.Columns.Add("BoM_CreateDate");
            dtBoM.Columns.Add("BoM_StartDate");
            dgr_BoMs.ItemsSource = dtBoM.DefaultView;
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.btn_Save.Content = "Obsolete";
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Date Set to Last Month
            //get data form last month and set date to date picker
            DateTime dtNow = DateTime.Now;
            TimeSpan tsDays = new TimeSpan(30, 0, 0, 0);
            DateTime dtBeforeMonth = dtNow - tsDays;
            dtpProdPlan_Date_From.SetTime(dtBeforeMonth);
            #endregion

            ClearFields();
            RefreshGrid();

        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.Wait;
                    #region Update
                    foreach (DataRow row in dtBoM.Rows)
                    {
                        string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                        string bIsSelect = clsValidate.ValidateRowValue(row, "IsSelect", "\uE003");

                        tbl_prod_polyTxJobCard oProJob = tbl_prod_polyTxJobCard.Select(sBoM_No);
                        if (oProJob != null && bIsSelect == "\uE0A2")
                        {
                            oProJob.ProdJobStatus = (int)prod_JobStatus.Obsolete;
                            oProJob.Update();
                        }
                    }

                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);

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
                }
            }
        }

        #endregion

        #region Refresh Grid
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            try
            {
                Cursor = Cursors.Wait;
                dtBoM.Clear();

                foreach (tbl_prod_polyTxJobCard oJob in tbl_prod_polyTxJobCard.SelectAll().Where(p => p.ProdJobStatus != (int)prod_JobStatus.Obsolete && p.ProdJobDate >= dtpProdPlan_Date_From.GetDateTime().Date && p.ProdJobDate <= dtpProdPlan_Date_To.GetDateTime().Date && p.ProdJob_ID != "default"))
                {
                    dtBoM.Rows.Add(
                        0,
                        "\uE003",
                        oJob.ProdJob_ID,
                        clsGenaralName.getName_Customer(oJob.Customer_ID),
                        clsGenaralName.getName_ItemClass(oJob.JobType_ID),
                        clsGenaralName.getDescription_Item(oJob.Item_ID_FG),
                        clsGenaralName.getCode_Item(oJob.Item_ID_FG),
                        clsGenaralName.getName_Item(oJob.Item_ID_FG),
                        clsGenaralName.getName_Uom(oJob.Uom_ID),
                        cls_Formater.FormatDecimal(oJob.FGoodQty, clsConfig.sDecimalPlaces_Quantity),
                        clsFormatter.FormatDate_SL(oJob.ProdJobDate),
                        clsFormatter.FormatDate_SL(oJob.ProdStartDate)
                        );
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

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodDescription, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtType, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomer, true, false, true);

            txtProdJobID.Text = "";
            txtType.Text = "";
            txtCustomer.Text = "";
            txtFinishGoodDescription.Text = "";

            txtProdJobID.Tag = null;

        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyGrid())
            {
                bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyGrid()
        {
            bool bStatus = true;

            if (dtBoM.Rows.Count <= 0)
            {
                SEACCMessageBox.Show("Information", "Please select items..", MessageBoxButton.OK);
                bStatus = false;
            }

            return bStatus;
        }
        #endregion

        #region Check Box Checked for Select and Unselect All
        private void chk_selectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE0A2");
        }
        private void chk_selectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE003");
        }
        #endregion

        #region Grid Events
        private void dgr_BoMs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_BoMs.SelectedIndex;
            var vDG_Cell = dgr_BoMs.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "IsSelect")
                {
                    bool bIsChecked = false;
                    bIsChecked = dtBoM.Rows[irowID]["IsSelect"].ToString() == "\uE003" ? true : false;
                    dtBoM.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE0A2" : "\uE003";
                }
            }
            catch (Exception) { }
        }

        private void dgr_BoMs_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM);
        }

        #endregion

        #region Text Changed Event
        private void txtFinishGoodDescription_KeyUp(object sender, KeyEventArgs e)
        {
            string sFinalQuary = "";

            if (txtFinishGoodDescription.TextBox1.Text != "" && txtFinishGoodDescription.TextBox1.Text.Length > 0)
                sFinalQuary = " FG_Item LIKE '%" + txtFinishGoodDescription.TextBox1.Text.Trim() + "%'";
            if (txtCustomer.TextBox1.Text != "" && txtCustomer.TextBox1.Text.Length > 0)
                sFinalQuary = " Customer LIKE '%" + txtCustomer.TextBox1.Text.Trim() + "%'";
            if (txtType.TextBox1.Text != "" && txtType.TextBox1.Text.Length > 0)
                sFinalQuary = " JobType LIKE '%" + txtType.TextBox1.Text.Trim() + "%'";
            if (txtProdJobID.TextBox1.Text != "" && txtProdJobID.TextBox1.Text.Length > 0)
                sFinalQuary = " BoM_No LIKE '%" + txtProdJobID.TextBox1.Text.Trim() + "%'";

            try
            {
                dtBoM.DefaultView.RowFilter = sFinalQuary;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

        }
        #endregion

       
    }
}
