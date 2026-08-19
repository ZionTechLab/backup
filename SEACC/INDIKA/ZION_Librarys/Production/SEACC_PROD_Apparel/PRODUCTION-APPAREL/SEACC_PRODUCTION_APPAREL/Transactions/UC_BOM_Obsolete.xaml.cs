using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Common;
using SEACC_WPFControls;
using SEACC_PRODUCTION_APPAREL.UserManagement;

namespace SEACC_PRODUCTION_APPAREL
{
    /// <summary>
    /// Interaction logic for UC_BOMRemoving.xaml
    /// </summary>
    public partial class UC_BOM_Obsolete : UserControl
    {
        #region Class Variables
        DataTable dtBoM = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_BOM_Obsolete()
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
                bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation..", "Are you sure to obsolete selected BoM(s)?", MessageBoxButton.YesNo, "#FF5B6B76");
                if (bMessegeBoxResult)
                {
                    try
                    {
                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                        frmTwoStepVerify.ShowDialog();
                        if (frmTwoStepVerify.bVerified)
                        {
                            Cursor = Cursors.Wait;

                            #region Update
                            foreach (DataRow row in dtBoM.Rows)
                            {
                                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                string bIsSelect = clsValidate.ValidateRowValue(row, "IsSelect", "\uE003");

                                tbl_prodTxJobCard oProJob = tbl_prodTxJobCard.Select(sBoM_No);
                                if (oProJob != null && bIsSelect == "\uE0A2")
                                {
                                    oProJob.ProdJobStatus = (int)prod_BoM_Status.Obsolete;
                                    oProJob.Update();
                                }
                            }

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);

                            #endregion
                        }
                        frmTwoStepVerify.Close();
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
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodSalesName, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtType, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomer, true, false, true);

            txtProdJobID.Tag = null;

            txtProdJobID.Text = "";
            txtType.Text = "";
            txtCustomer.Text = "";
            txtFinishGoodSalesName.Text = "";


            dtBoM.DefaultView.RowFilter = null;
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

                foreach (tbl_prodTxJobCard oJob in tbl_prodTxJobCard.SelectAll().Where(p => p.ProdJobStatus != (int)prod_BoM_Status.Obsolete && p.ProdJobDate >= dtpProdPlan_Date_From.GetDateTime().Date && p.ProdJobDate <= dtpProdPlan_Date_To.GetDateTime().Date && p.ProdJob_ID != "default"))
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

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = CheckValidity_EmptyGrid();
            return bStatus;
        }

        private bool CheckValidity_EmptyGrid()
        {
            bool bStatus = true;

            if (dtBoM.Rows.Count <= 0)
            {
                SEACCMessageBox.Show("Ops...", "Please select items..", MessageBoxButton.OK);
                bStatus = false;
            }

            return bStatus;
        }
        #endregion

        #region Grid Events
        private void dgr_BoMs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            object item = dgr_BoMs.SelectedItem;
            if (item != null)
            {
                var vDG_Cell = dgr_BoMs.CurrentCell;
                string sGridID = (dgr_BoMs.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                try
                {
                    if (vDG_Cell.Column.SortMemberPath == "IsSelect")
                    {
                        bool bIsChecked = false;
                        var vRow = dtBoM.Select("LineNo = " + sGridID + " ").FirstOrDefault();
                        if (vRow != null)
                        {
                            bIsChecked = vRow["IsSelect"].ToString() == "\uE003" ? true : false;
                            vRow["IsSelect"] = bIsChecked ? "\uE0A2" : "\uE003";
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void dgr_BoMs_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM);
        }

        #endregion

        #region Check Box Events  ( Select All and Unselect All)
        private void chk_selectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE0A2");
        }
        private void chk_selectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE003");
        }
        #endregion

        #region Text Changed Event
        private void txtFinishGoodDescription_KeyUp(object sender, KeyEventArgs e)
        {
            string sFinalQuary = "";

            if (txtFinishGoodSalesName.TextBox1.Text != "" && txtFinishGoodSalesName.TextBox1.Text.Length > 0)
                sFinalQuary = " FG_SalesName LIKE '%" + txtFinishGoodSalesName.TextBox1.Text.Trim() + "%'";
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
