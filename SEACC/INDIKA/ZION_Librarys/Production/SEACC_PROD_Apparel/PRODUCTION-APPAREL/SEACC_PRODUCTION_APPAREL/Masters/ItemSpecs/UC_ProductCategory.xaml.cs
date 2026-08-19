using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_APPAREL.Masters
{
    /// <summary>
    /// Interaction logic for UC_ProductionCategory.xaml
    /// </summary>
    public partial class UC_ProductCategory : UserControl
    {
        #region Form Initialization
        public UC_ProductCategory()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_ProductCategory;
            SEACC_Form.Initialize();

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("CategoryID");
            dgr_Main.dt.Columns.Add("CategoryName");
            dgr_Main.dt.Columns.Add("Prefix");
            dgr_Main.dt.Columns.Add("Remarks");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            //this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Category ID", "CategoryID", 75, false);
            dgr_Main.Add_DatagridColoumn("Prefix", "Prefix", 75);
            dgr_Main.Add_DatagridColoumn("Description", "CategoryName", 150);
            dgr_Main.Add_DatagridColoumn("Remark", "Remarks", 300);
            #endregion

            ClearFields();
            RefreshGrid();

        }        
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
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
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_zItemCategory oOldCategory = tbl_zItemCategory.Select(txtCategoryID.Tag.ToString());
                            if (oOldCategory != null)
                            {
                                tbl_zItemCategory oCategory = new tbl_zItemCategory(txtCategoryID.Tag.ToString(), txtCategoryName.Text, oOldCategory.ItemType_ID, txtPrefix.Text ,txtShortPrefix.Text, oOldCategory.IsItemSubCategoryEnabled, oOldCategory.IsItemSubCategory2Enabled, oOldCategory.IsItemSerialNoEnabled, oOldCategory.IsItemSerialNo2Enabled, oOldCategory.CategoryCounter, oOldCategory.CategoryLength, txtRemark.Text);
                                oCategory.Update();
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
                            tbl_zItemCategory oNewCategory = new tbl_zItemCategory(txtCategoryID.Tag.ToString(), txtCategoryName.Text, "default", txtPrefix.Text, txtShortPrefix.Text, false, false, false, false, 0, 0, txtRemark.Text);
                            oNewCategory.Insert();
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
                }
            }



        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                             tbl_zItemCategory oOldCategory = tbl_zItemCategory.Select(txtCategoryID.Tag.ToString());
                             if (oOldCategory != null)
                             {
                                 
                             }
                        }
                    }
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
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCategoryID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCategoryName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtShortPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);


            txtCategoryID.Tag = null;

            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            txtPrefix.Text = "";
            txtShortPrefix.Text = "";
            txtRemark.Text = "";

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCategoryID.setReadOnlyStatus(true);
                txtCategoryID.Text = "<Auto Generate>";
            }
            else
                txtCategoryID.setReadOnlyStatus(false);
            #endregion


        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_zItemCategory oCategory in tbl_zItemCategory.SelectAll().Where(p => p.ItemCategory_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oCategory.ItemCategory_ID, oCategory.CategoryName, oCategory.Prefrix, oCategory.Remark);
                }
                dgr_Main.RefreshGrid();
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
                    if (ChekValidity_DuplicateNames())
                        bStatus = true;
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtCategoryID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCategoryName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPrefix))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtCategoryID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtCategoryID.Text = txtCategoryID.Tag.ToString();
                }

                tbl_zItemCategory oCategory = tbl_zItemCategory.Select(txtCategoryID.Text);
                if (oCategory != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            foreach (tbl_zItemCategory oCategory in tbl_zItemCategory.SelectAll().Where(p => p.CategoryName == txtCategoryName.Text && p.ItemType_ID != txtCategoryID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                break;
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                tbl_zItemCategory oCategory = tbl_zItemCategory.Select(sID);
                if (oCategory != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtCategoryID.Tag = oCategory.ItemCategory_ID;

                    txtCategoryID.Text = oCategory.ItemCategory_ID;
                    txtCategoryName.Text = oCategory.CategoryName;
                    txtPrefix.Text = oCategory.Prefrix;
                    txtShortPrefix.Text = oCategory.Prefrix2;
                    txtRemark.Text = oCategory.Remark;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
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
        private void txtCategoryID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductCategory);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        #region Key Press Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        } 
        #endregion
    }
}
