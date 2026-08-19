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
using DataTire;
using SEACC_WPFControls;
using Digiteq_Logic;
using System.Data;
using SEACC_servii.Search_Forms;

namespace SEACC_servii.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_ItemCategoryMaster.xaml
    /// </summary>
    public partial class UC_ItemCategoryMaster : UserControl
    {
        public UC_ItemCategoryMaster()
        {

            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.ItemCategoryMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ItemCategory_ID");
            dgr_Main.dt.Columns.Add("CategoryName");
            dgr_Main.dt.Columns.Add("ItemType");
            dgr_Main.dt.Columns.Add("Prefrix");
            dgr_Main.dt.Columns.Add("IsItemSubCategoryEnabled",typeof(bool));
            dgr_Main.dt.Columns.Add("IsItemSubCategory2Enabled", typeof(bool));
            dgr_Main.dt.Columns.Add("IsItemSerialNoEnabled", typeof(bool));
            dgr_Main.dt.Columns.Add("IsItemSerialNo2Enabled", typeof(bool));
            dgr_Main.dt.Columns.Add("CategoryCounter");
            dgr_Main.dt.Columns.Add("CategoryLength");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("ID", "ItemCategory_ID", 80);
            dgr_Main.Add_DatagridColoumn("Name", "CategoryName", 150);
            dgr_Main.Add_DatagridColoumn("Item Type", "ItemType", 150);
            dgr_Main.Add_DatagridColoumn("Prefrix", "Prefrix", 80);
            dgr_Main.Add_DatagridColoumn("Is Sub Cat.", "IsItemSubCategoryEnabled", 80);
            dgr_Main.Add_DatagridColoumn("Is Sub Cat.2", "IsItemSubCategory2Enabled", 80);
            dgr_Main.Add_DatagridColoumn("Is Serial No.", "IsItemSerialNoEnabled", 80);
            dgr_Main.Add_DatagridColoumn("Is Serial No.2", "IsItemSerialNo2Enabled", 80);
            dgr_Main.Add_DatagridColoumn("Counter", "CategoryCounter", 80);
            dgr_Main.Add_DatagridColoumn("Length", "CategoryLength", 80);
            #endregion

            ClearFields();
            RefreshGrid();
        }


        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_zItemCategory itemCat in tbl_zItemCategory.SelectAll().Where(p => p.ItemCategory_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(itemCat.ItemCategory_ID, itemCat.CategoryName, clsRef_Name.get_ItemType_Name(itemCat.ItemType_ID), itemCat.Prefrix, itemCat.IsItemSubCategoryEnabled, itemCat.IsItemSubCategory2Enabled, itemCat.IsItemSerialNoEnabled, itemCat.IsItemSerialNo2Enabled, itemCat.CategoryCounter, itemCat.CategoryLength);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Action Buttons
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_zItemCategory OldDetails = tbl_zItemCategory.Select(txtItemCatID.Text.Trim());
                            if (OldDetails != null)
                            {
                                tbl_zItemCategory oItemCat = new tbl_zItemCategory(txtItemCatID.Text, txtItemCatName.Text, txtItemTypeName.Tag.ToString(), txtCatPrefix.Text, chkSubCatEnable.IsChecked, chkSubCat2Enable.IsChecked, chkSerialNoEnable.IsChecked, chkSerialNo2Enable.IsChecked, int.Parse(txtCatCounter.Text),int.Parse(txtCatLength.Text));
                                oItemCat.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                        {
                            txtItemCatID.Text = SEACC_Form.getAutoGeneratedCode();
                            txtItemCatID.Tag = txtItemCatID.Text;
                        }
                        tbl_zItemCategory oItemCat = new tbl_zItemCategory(txtItemCatID.Text, txtItemCatName.Text, txtItemTypeName.Tag.ToString(), txtCatPrefix.Text, chkSubCatEnable.IsChecked, chkSubCat2Enable.IsChecked, chkSerialNoEnable.IsChecked, chkSerialNo2Enable.IsChecked, int.Parse(txtCatCounter.Text), int.Parse(txtCatLength.Text));
                        oItemCat.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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
        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.IsUpdateMode)
            {
                if (txtItemCatID.Tag != null)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                    if (bMessegeBoxResult)
                    {
                        tbl_zItemCategory oItemCat = tbl_zItemCategory.Select(txtItemCatID.Text.Trim());
                        if (oItemCat != null)
                        {
                            oItemCat.Delete();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                            ClearFields();
                            RefreshGrid();
                        }
                    }
                }
            }
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtItemCatID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox( txtItemCatName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItemTypeName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCatPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCatCounter, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCatLength, true, true, false);

            txtItemCatID.Text = "";
            txtItemCatID.Tag = null;
            txtItemCatName.Text = "";
            txtItemTypeName.Text = "";
            txtItemTypeName.Tag = null;
            txtCatPrefix.Text = "";
            txtCatCounter.Text = "";
            txtCatLength.Text = "";

            chkSubCatEnable.IsChecked = false;
            chkSubCat2Enable.IsChecked = false;
            chkSerialNoEnable.IsChecked = false;
            chkSerialNo2Enable.IsChecked = false;

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtItemCatID.setReadOnlyStatus(true);
                txtItemCatID.Text = "<Auto Generate>";
            }
            else
                txtItemCatID.setReadOnlyStatus(false);
        }
        #endregion

        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtItemCatID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtItemCatName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtItemTypeName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCatPrefix))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCatCounter))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCatLength))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_zItemCategory oDetail = tbl_zItemCategory.Select(txtItemCatName.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_zItemCategory FillDetails = tbl_zItemCategory.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtItemCatID.IsEnabled = false;
                        txtItemCatID.Text = FillDetails.ItemCategory_ID;
                        txtItemCatID.Tag = FillDetails.ItemCategory_ID;
                        txtItemCatName.Text = FillDetails.CategoryName;
                        txtItemTypeName.Text = clsRef_Name.get_ItemType_Name(FillDetails.ItemType_ID);
                        txtItemTypeName.Tag = FillDetails.ItemType_ID;
                        txtCatPrefix.Text = FillDetails.Prefrix;
                        txtCatCounter.Text = FillDetails.CategoryCounter.ToString();
                        txtCatLength.Text = FillDetails.CategoryLength.ToString();

                        chkSubCatEnable.IsChecked = FillDetails.IsItemSubCategoryEnabled;
                        chkSubCat2Enable.IsChecked = FillDetails.IsItemSubCategory2Enabled;
                        chkSerialNoEnable.IsChecked = FillDetails.IsItemSerialNoEnabled;
                        chkSerialNo2Enable.IsChecked = FillDetails.IsItemSerialNo2Enabled;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        #region Search Event
        private void txtItemCatID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtItemCatID.Text = lstResult[0];
                txtItemCatID.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }

        }

        private void txtItemTypeName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemType);
            if (RowDataSearch.DialogResult == true)
            {
                txtItemTypeName.Text = lstResult[1];
                txtItemTypeName.Tag = lstResult[0];
            }
        }
        #endregion

        
    }
}
