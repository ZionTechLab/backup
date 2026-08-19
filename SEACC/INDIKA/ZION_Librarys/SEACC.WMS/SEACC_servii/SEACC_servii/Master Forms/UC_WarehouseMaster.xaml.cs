using DataTire;
using Digiteq_Logic;
using SEACC_servii.Search_Forms;
using SEACC_WPFControls;
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

namespace SEACC_servii.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_WarehouseMaster.xaml
    /// </summary>
    public partial class UC_WarehouseMaster : UserControl
    {
        #region Form Load
        public UC_WarehouseMaster()
        {
            InitializeComponent();

            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.WarehouseMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("store_ID");
            dgr_Main.dt.Columns.Add("storeName");
            dgr_Main.dt.Columns.Add("address");
            dgr_Main.dt.Columns.Add("contactPerson");
            dgr_Main.dt.Columns.Add("telephone");
            dgr_Main.dt.Columns.Add("fax");
            dgr_Main.dt.Columns.Add("isDamagedStore", typeof(bool));
            dgr_Main.dt.Columns.Add("isSingleItemStockStore", typeof(bool));
            dgr_Main.dt.Columns.Add("isMainStore", typeof(bool));
            dgr_Main.dt.Columns.Add("isTradingStore", typeof(bool));
            dgr_Main.dt.Columns.Add("isShowRoom", typeof(bool));
            dgr_Main.dt.Columns.Add("isReturnedStore", typeof(bool));
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Code", "store_ID", 80);
            dgr_Main.Add_DatagridColoumn("Name", "storeName", 100);
            dgr_Main.Add_DatagridColoumn("Address", "address", 80, true);
            dgr_Main.Add_DatagridColoumn("Contact Person", "contactPerson", 150);
            #endregion

            ClearFields();
            RefreshGrid();
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
                            tbl_genStoreMaster OldDetails = tbl_genStoreMaster.Select(txtWarehouseCode.Text);
                            if (OldDetails != null)
                            {
                                tbl_genStoreMaster oWarehouse = new tbl_genStoreMaster(0, txtWarehouseCode.Text, txtWarehouseName.Text, txtAddress.Text, txtWarehousePhone.Text, txtWarehouseFax.Text, txtContactPersonName.Text, chkIsDamageStore.IsChecked, chkIsSingleItemStock.IsChecked, chkIsMainStore.IsChecked, chkIsTradingStore.IsChecked, chkIsShowRoom.IsChecked, OldDetails.IsDeleted, chkIsReturnedStore.IsChecked);
                                oWarehouse.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    else
                    {                        
                        tbl_genStoreMaster nWarehouse = new tbl_genStoreMaster(0, txtWarehouseCode.Tag.ToString(), txtWarehouseName.Text, txtAddress.Text, txtWarehousePhone.Text, txtWarehouseFax.Text, txtContactPersonName.Text, chkIsDamageStore.IsChecked, chkIsSingleItemStock.IsChecked, chkIsMainStore.IsChecked, chkIsTradingStore.IsChecked, chkIsShowRoom.IsChecked, false, chkIsReturnedStore.IsChecked);
                        nWarehouse.Insert();
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
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genStoreMaster item in tbl_genStoreMaster.SelectAll().Where(p => p.Store_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(item.Store_ID, item.StoreName, item.Adress,item.ContactPerson);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtWarehouseCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtWarehouseName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtContactPersonName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtWarehousePhone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtWarehouseFax, true, false, false);

            txtWarehouseCode.Text = "";
            txtWarehouseName.Text = "";
            txtAddress.Text = "";
            txtContactPersonName.Text = "";
            txtWarehousePhone.Text = "";
            txtWarehouseFax.Text = "";

            txtWarehouseCode.Tag = null;

            chkIsDamageStore.IsChecked = false;
            chkIsSingleItemStock.IsChecked = false;
            chkIsMainStore.IsChecked = false;
            chkIsTradingStore.IsChecked = false;
            chkIsShowRoom.IsChecked = false;
            chkIsReturnedStore.IsChecked = false;

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtWarehouseCode.setReadOnlyStatus(true);
                txtWarehouseCode.Text = "<Auto Generate>";
            }
            else
                txtWarehouseCode.setReadOnlyStatus(false);
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

            if (!clsValidation.Validate_EmptyValue(txtWarehouseCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtWarehouseName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtAddress))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtContactPersonName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtWarehousePhone))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtWarehouseCode.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_zUom oDetail = tbl_zUom.Select(txtWarehouseCode.Tag.ToString());
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
                    tbl_genStoreMaster FillDetails = tbl_genStoreMaster.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtWarehouseCode.IsEnabled = false;
                        txtWarehouseCode.Text = FillDetails.Store_ID;
                        txtWarehouseName.Text = FillDetails.StoreName;
                        txtAddress.Text = FillDetails.Adress;
                        txtContactPersonName.Text = FillDetails.ContactPerson;
                        txtWarehousePhone.Text = FillDetails.Telephone;
                        txtWarehouseFax.Text = FillDetails.Fax;

                        txtWarehouseCode.Tag = FillDetails.Store_ID;

                        chkIsDamageStore.IsChecked = FillDetails.IsDamagedStore;
                        chkIsSingleItemStock.IsChecked = FillDetails.IsSingleItemStockStore;
                        chkIsMainStore.IsChecked = FillDetails.IsMainStore;
                        chkIsTradingStore.IsChecked = FillDetails.IsTradingStore;
                        chkIsShowRoom.IsChecked = FillDetails.IsShowRoom;
                        chkIsReturnedStore.IsChecked = FillDetails.IsReturnedStore;
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

        private void txtWarehouseCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Warehouse);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtWarehouseCode.Text = lstResult[0];
                txtWarehouseCode.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        } 
        #endregion
    }
}
