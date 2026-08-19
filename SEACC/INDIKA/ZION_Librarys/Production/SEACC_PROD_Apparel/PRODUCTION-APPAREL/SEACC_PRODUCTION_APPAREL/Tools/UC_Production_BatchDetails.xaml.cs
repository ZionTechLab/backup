using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Digiteq_Logic;
using SEACC_WPFControls;
using DataTire;
using System.Data;
using SEACC_PRODUCTION_APPAREL.Search;

namespace SEACC_PRODUCTION_APPAREL.Tools
{
    public partial class UC_Production_BatchDetails : UserControl
    {
        #region Class Variables
        DataTable dt_JobDetail = new DataTable();
        DataTable dt_JobDetail_pagination = new DataTable();

        private int iCurrentPageIndex = 1;
        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4, RowCountPerPage_Change = 5 };
        #endregion

        #region Form Load
        public UC_Production_BatchDetails()
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_BOM_PostCosting;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Full Data Table
            dt_JobDetail.Columns.Add("LineNo", typeof(int));
            dt_JobDetail.Columns.Add("item_ID_FG");
            dt_JobDetail.Columns.Add("itemName");
            dt_JobDetail.Columns.Add("prodJob_ID");
            dt_JobDetail.Columns.Add("prodBatch_ID");
            dt_JobDetail.Columns.Add("batchQty", typeof(decimal));
            dt_JobDetail.Columns.Add("uom_ID");
            dt_JobDetail.Columns.Add("uomCode");
            dt_JobDetail.Columns.Add("customerName");
            dt_JobDetail.Columns.Add("ProdBatchMRs", typeof(DataTable));
            dt_JobDetail.Columns.Add("ProdBatchPGINs", typeof(DataTable));
            dt_JobDetail.Columns.Add("ProdBatchPGRNs", typeof(DataTable));
            dt_JobDetail.Columns.Add("ProdBatchSOUTs", typeof(DataTable));
            dt_JobDetail.Columns.Add("ProdBatchSINs", typeof(DataTable));
            dt_JobDetail.Columns.Add("ProdBatchWIPs", typeof(DataTable));
            dt_JobDetail.Columns.Add("ProdBatchFGTNs", typeof(DataTable));
            dt_JobDetail.Columns.Add("ProdBatchFGTNACCPTs", typeof(DataTable));
            dt_JobDetail.Columns.Add("closure_ID");
            #endregion

            #region Pagination - No of Rows Per Page
            cmbNumberOfRecords.Items.Add("10");
            cmbNumberOfRecords.Items.Add("15");
            cmbNumberOfRecords.Items.Add("20");
            cmbNumberOfRecords.Items.Add("30");
            cmbNumberOfRecords.Items.Add("40");
            cmbNumberOfRecords.Items.Add("50");
            cmbNumberOfRecords.Items.Add("100");
            cmbNumberOfRecords.SelectedIndex = 1;//Default 15
            #endregion

            #region Intialize Pagination Data Table
            dt_JobDetail_pagination = dt_JobDetail.Copy();
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false, false, false);
            SEACC_Form.btn_New.Click += btn_Clear_Click;
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Buttons
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            RefreshFullDataTable();
            Navigate((int)PagingMode.First);
        }
        #endregion

        #region Refresh Grid
        private void RefreshFullDataTable()
        {
            try
            {
                Cursor = Cursors.Wait;

                dt_JobDetail.Clear();

                var oBatches = tbl_prodTxBatch.SelectAll().Where(r => !r.IsCanceled && r.ProdBatch_ID != "default").ToList();

                if (txtProdJobID.Tag != null)
                    oBatches = oBatches.Where(r => r.ProdJob_ID == txtProdJobID.Tag.ToString()).ToList();
                if (txtBatch_ID.Tag != null)
                    oBatches = oBatches.Where(r => r.ProdBatch_ID == txtBatch_ID.Tag.ToString()).ToList();
                if (txtFinishGoodSalesName.Tag != null)
                    oBatches = oBatches.Where(r => r.Item_ID == txtFinishGoodSalesName.Tag.ToString()).ToList();
                if (txtBatch_ID.Tag == null && txtCustomer.Tag != null)
                    oBatches = oBatches.Where(r => tbl_prodTxJobCard.Select(r.ProdJob_ID).Customer_ID == txtCustomer.Tag.ToString()).ToList();

                int iLineNo = 0;
                foreach (var vBatch in oBatches)
                {
                    tbl_prodTxBatch_Closure_Detail oClosure = tbl_prodTxBatch_Closure_Detail.SelectAllByProdJob_ID(vBatch.ProdJob_ID).Where(r => r.ProdBatch_ID == vBatch.ProdBatch_ID).FirstOrDefault();
                    dt_JobDetail.Rows.Add(++iLineNo,
                        vBatch.Item_ID, clsGenaralName.getName_Item(vBatch.Item_ID),
                        vBatch.ProdJob_ID, vBatch.ProdBatch_ID,
                        vBatch.BatchQty, vBatch.Uom_ID, clsGenaralName.getName_Uom(vBatch.Uom_ID),
                        clsGenaralName.getName_Customer(clsGenaralName.getCustomerID_FromCO(vBatch.CustomerOrder_ID)),
                        DBHandling.ExecQuery("select * from [dbo].[func_Prod_Apparel_GetAllMRsFromBatch]('" + vBatch.ProdBatch_ID + "')").Tables[0],
                        DBHandling.ExecQuery("select * from [dbo].[func_Prod_Apparel_GetAllPGINsFromBatch]('" + vBatch.ProdBatch_ID + "')").Tables[0],
                        DBHandling.ExecQuery("select * from [dbo].[func_Prod_Apparel_GetAllPGRNsFromBatch]('" + vBatch.ProdBatch_ID + "')").Tables[0],
                        DBHandling.ExecQuery("select * from [dbo].[func_Prod_Apparel_GetAllSOUTsFromBatch]('" + vBatch.ProdBatch_ID + "')").Tables[0],
                        DBHandling.ExecQuery("select * from [dbo].[func_Prod_Apparel_GetAllSINsFromBatch]('" + vBatch.ProdBatch_ID + "')").Tables[0],
                        DBHandling.ExecQuery("select * from [dbo].[func_Prod_Apparel_GetAllWIPsFromBatch]('" + vBatch.ProdBatch_ID + "')").Tables[0],
                        DBHandling.ExecQuery("select * from [dbo].[func_Prod_Apparel_GetAllFGTNsFromBatch]('" + vBatch.ProdBatch_ID + "')").Tables[0],
                        DBHandling.ExecQuery("select * from [dbo].[func_Prod_Apparel_GetAllFGTNACPTsFromBatch]('" + vBatch.ProdBatch_ID + "')").Tables[0],
                        oClosure != null ? oClosure.Closure_ID : ""
                        );
                }

                RefreshDataGrid(0, int.Parse(cmbNumberOfRecords.SelectedItem.ToString()));
                Navigate((int)PagingMode.First);
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

        private void RefreshDataGrid(long lStarting_index, long lEnding_index)
        {
            try
            {
                dt_JobDetail_pagination.Rows.Clear();
                var vPaginationResult = dt_JobDetail.AsEnumerable().Where(dr => dr.Field<int>("LineNo") >= lStarting_index && dr.Field<int>("LineNo") <= lEnding_index);
                foreach (DataRow dr in vPaginationResult)
                {
                    dt_JobDetail_pagination.ImportRow(dr);
                }

                CollectionViewSource mycollection = new CollectionViewSource();
                mycollection.Source = dt_JobDetail_pagination;
                dgr_Batches.ItemsSource = mycollection.View;
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBatch_ID, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, true);

            txtProdJobID.Tag = null;
            txtBatch_ID.Tag = null;
            txtCustomer.Tag = null;
            txtFinishGoodSalesName.Tag = null;

            txtProdJobID.Text = "";
            txtBatch_ID.Text = "";
            txtCustomer.Text = "";
            txtFinishGoodSalesName.Text = "";

            dt_JobDetail.Clear();
            dt_JobDetail_pagination.Rows.Clear();

            stpNavigation.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Key Press Events
        private void SEACC_Form_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_Clear_Click(sender, e);
            }
        }
        #endregion

        #region Pagination Events
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Navigate((int)PagingMode.First);
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            Navigate((int)PagingMode.Previous);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Navigate((int)PagingMode.Next);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            Navigate((int)PagingMode.Last);
        }

        private void cbNumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigate((int)PagingMode.RowCountPerPage_Change);
        }
        #endregion

        #region Help Methods
        private void Navigate(int mode)
        {
            int iRowsCountPerPage = int.Parse(cmbNumberOfRecords.SelectedItem.ToString());
            switch (mode)
            {
                case (int)PagingMode.Next:
                    SelectPage(iRowsCountPerPage, ++iCurrentPageIndex);
                    break;

                case (int)PagingMode.Previous:
                    if (iCurrentPageIndex > 1)
                        SelectPage(iRowsCountPerPage, --iCurrentPageIndex);
                    break;

                case (int)PagingMode.First:
                case (int)PagingMode.RowCountPerPage_Change:
                    RefreshDataGrid(0, iRowsCountPerPage);
                    iCurrentPageIndex = 1;
                    break;

                case (int)PagingMode.Last:
                    RefreshDataGrid(dt_JobDetail.Rows.Count - iRowsCountPerPage, dt_JobDetail.Rows.Count);
                    iCurrentPageIndex = (dt_JobDetail.Rows.Count / iRowsCountPerPage) + 1;
                    break;
            }

            int iTotal_Pages = ((dt_JobDetail.Rows.Count / iRowsCountPerPage) + 1);
            lblpageInformation.Content = iCurrentPageIndex + " of " + iTotal_Pages;
            if (iTotal_Pages < 2)
                stpNavigation.Visibility = Visibility.Collapsed;
            else
                stpNavigation.Visibility = Visibility.Visible;
        }

        private void SelectPage(int iRowsPerPage, int iPageIndex)
        {
            try
            {
                Cursor = Cursors.Wait;

                int iTotalPages = (dt_JobDetail.Rows.Count / iRowsPerPage) + 1;
                if (iTotalPages >= iPageIndex)
                {
                    int iPageLastRowIndex = iPageIndex * iRowsPerPage;
                    int iPageFirstRowIndex = (iPageLastRowIndex - iRowsPerPage) + 1;

                    RefreshDataGrid(iPageFirstRowIndex, iPageLastRowIndex);
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

        #region Search Events
        private void txtProdJobID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs_Locked);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobID.Tag = lstResult[0];
                txtProdJobID.Text = lstResult[0];

                txtFinishGoodSalesName.Tag = lstResult[2];
                txtFinishGoodSalesName.Text = lstResult[3];
                txtFinishGoodSalesName.IsEnabled = false;

                txtCustomer.Tag = clsGenaralName.getID_ApparelBoM_Customer(lstResult[0]);
                txtCustomer.Text = clsGenaralName.getName_Customer(txtCustomer.Tag.ToString());
                txtCustomer.IsEnabled = false;

            }
        }

        private void txtBatch_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtProdJobID.Tag != null)
                lstParameeters.Add(txtProdJobID.Tag.ToString());

            frm_search RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_Batch);
            if (RowDataSearch.DialogResult == true)
            {
                txtBatch_ID.Tag = lstResult[0];
                txtBatch_ID.Text = lstResult[0];

                tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(lstResult[0]);
                if (oBatch != null)
                {
                    txtFinishGoodSalesName.Tag = oBatch.Item_ID;
                    txtFinishGoodSalesName.Text = clsGenaralName.getName_Item(oBatch.Item_ID);
                    txtFinishGoodSalesName.IsEnabled = false;

                    txtCustomer.Tag = clsGenaralName.getID_ApparelBoM_Customer(oBatch.ProdJob_ID);
                    txtCustomer.Text = clsGenaralName.getName_Customer(txtCustomer.Tag.ToString());
                    txtCustomer.IsEnabled = false;
                }
            }
        }

        private void txtFinishGoodSalesName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs_Locked);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobID.Tag = lstResult[0];
                txtProdJobID.Text = lstResult[0];

                txtFinishGoodSalesName.Tag = lstResult[2];
                txtFinishGoodSalesName.Text = lstResult[3];
                txtFinishGoodSalesName.IsEnabled = false;

                txtCustomer.Tag = clsGenaralName.getID_ApparelBoM_Customer(lstResult[0]);
                txtCustomer.Text = clsGenaralName.getName_Customer(txtCustomer.Tag.ToString());
                txtCustomer.IsEnabled = false;

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
                txtCustomer.Text = lstResult[1];
            }
        }
        #endregion
    }
}
