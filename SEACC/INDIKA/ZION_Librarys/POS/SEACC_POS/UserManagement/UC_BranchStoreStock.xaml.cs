using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using SEACC_POS.Search_Forms;
using Digiteq_Logic_POS;

namespace SEACC_POS.UserManagement
{
    /// <summary>
    /// Interaction logic for UC_BranchStoreStock.xaml
    /// </summary>
    public partial class UC_BranchStoreStock : UserControl
    {
        #region Initialize Form
        public UC_BranchStoreStock()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.POS_BranchWiseStoreStock;
            SEACC_Form.Initialize();
            #endregion

            string[] sFGStore_List = clsConfig_POS.sFinishedGoodStores.Trim().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            #region Item Table Initialize with Data Grid
            dgr_Main.dt.Columns.Add("LineNo", typeof(int));
            dgr_Main.dt.Columns.Add("Item_ID");
            dgr_Main.dt.Columns.Add("Item_Name");
            dgr_Main.dt.Columns.Add("UoM");
            dgr_Main.dt.Columns.Add("Item_Description");


            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LineNo", 35, true, true);
            dgr_Main.Add_DatagridColoumn("Item Code", "Item_ID", 80);
            dgr_Main.Add_DatagridColoumn("Item Name", "Item_Name", 200);
            dgr_Main.Add_DatagridColoumn("UoM", "UoM", 50);
            dgr_Main.Add_DatagridColoumn("Description", "Item_Description", 100, false);

            foreach (tbl_genCompanyBranchMaster oBranch in tbl_genCompanyBranchMaster.SelectAll().Where(r => r.CompanyBranch_ID != "default").OrderBy(r => r.LineNO))
            {
                List<tbl_genStoreMaster> oList = null;
                if (clsConfig_POS.bEnableFilterSpecificStoresInStoreStock)
                    oList = tbl_genStoreMaster.SelectAllByCompanyBranch_ID(oBranch.CompanyBranch_ID).Where(r => !r.IsDeleted && r.Store_ID != "default" && r.IsMainStore || r.IsShowRoom || sFGStore_List.Contains(r.Store_ID.Trim())).ToList();
                else
                    oList = tbl_genStoreMaster.SelectAllByCompanyBranch_ID(oBranch.CompanyBranch_ID).Where(r => !r.IsDeleted && r.Store_ID != "default").ToList();

                foreach (tbl_genStoreMaster oStore in oList.OrderBy(r => r.Line_No))
                {
                    DataColumn dcStore = new DataColumn(oStore.Store_ID.Replace('/', '_'), typeof(decimal));
                    dcStore.DefaultValue = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);


                    dgr_Main.dt.Columns.Add(dcStore);
                    dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, oBranch.BranchName + "\n" + oStore.StoreName, oStore.Store_ID.Replace('/', '_'), 135, true, false);
                }
            }

            dgr_Main.dt.Columns.Add("Total_Amount");
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Total Amount", "Total_Amount", 100, true, true);
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, false, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                ColumnA.Width = new GridLength(400);
            else
                ColumnA.Width = new GridLength(800);
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItem_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItem_Name, true, false, true);

            txtItem_ID.Tag = null;
            txtItem_Name.Tag = null;

            txtItem_ID.Text = "";
            txtItem_Name.Text = "";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
            try
            {
                int iLineNo = 0;
                dgr_Main.dt.Clear();
                foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(r => !r.IsDeleted && !r.IsGiftVoucher && r.IsSalesItem))
                {
                    dgr_Main.dt.Rows.Add(++iLineNo, oItem.Item_ID, oItem.ItemName, clsGenaralName.getName_Uom(oItem.Uom_ID), oItem.Description);
                }

                foreach (DataRow dtRow in dgr_Main.dt.Rows)
                {
                    // On all tables' columns
                    decimal dStoresTotalAmount = 0;
                    foreach (DataColumn dc in dgr_Main.dt.Columns)
                    {
                        if (dc.ColumnName == "LineNo" || dc.ColumnName == "Item_ID" || dc.ColumnName == "Item_Name" || dc.ColumnName == "UoM" || dc.ColumnName == "Item_Description")
                            continue;

                        decimal dStoreAmount = clsProcessMethods.Get_StoreStockBalance_Qty(dc.ColumnName.Replace('_', '/'), dtRow["Item_ID"].ToString(), "default", "default", "default", "0", "0");
                        dStoresTotalAmount += dStoreAmount;

                        if (dc.ColumnName != "Total_Amount")
                            dtRow[dc.ColumnName] = cls_Formater.FormatDecimal(dStoreAmount, clsConfig.sDecimalPlaces_Quantity);
                        else
                            dtRow[dc.ColumnName] = cls_Formater.FormatDecimal(dStoresTotalAmount, clsConfig.sDecimalPlaces_Quantity);

                    }
                }

                dgr_Main.RefreshGrid();

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                FrmWaiting.Close();
            }
        }

        private void RefreshGrid(string sItem_ID)
        {
            try
            {
                int iLineNo = 0;
                dgr_Main.dt.Clear();
                foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(r => r.Item_ID == txtItem_ID.Tag.ToString()))
                {
                    dgr_Main.dt.Rows.Add(++iLineNo, oItem.Item_ID, oItem.ItemName, clsGenaralName.getName_Uom(oItem.Uom_ID), oItem.Description);
                }

                foreach (DataRow dtRow in dgr_Main.dt.Rows)
                {
                    // On all tables' columns
                    foreach (DataColumn dc in dgr_Main.dt.Columns)
                    {
                        if (dc.ColumnName == "LineNo" || dc.ColumnName == "Item_ID" || dc.ColumnName == "Item_Name" || dc.ColumnName == "UoM" || dc.ColumnName == "Item_Description")
                            continue;

                        dtRow[dc.ColumnName] = cls_Formater.FormatDecimal(
                                                    clsProcessMethods.Get_StoreStockBalance_Qty(dc.ColumnName.Replace('_', '/'), dtRow["Item_ID"].ToString(), "default", "default", "default", "0", "0")
                                                    , clsConfig.sDecimalPlaces_Quantity);
                    }
                }

                dgr_Main.RefreshGrid();

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events
        private void txtItem_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ItemMasterByItemCode);
            if (RowDataSearch.DialogResult == true)
            {
                txtItem_ID.Tag = lstResult[0];
                txtItem_ID.Text = lstResult[0];
                txtItem_Name.Text = lstResult[1];

                RefreshGrid(lstResult[0]);
            }
        }

        private void txtItem_Name_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ItemMasterByItemCode);
            if (RowDataSearch.DialogResult == true)
            {
                txtItem_ID.Tag = lstResult[0];
                txtItem_ID.Text = lstResult[0];
                txtItem_Name.Text = lstResult[1];

                RefreshGrid(lstResult[0]);
            }
        }
        #endregion

    }
}
