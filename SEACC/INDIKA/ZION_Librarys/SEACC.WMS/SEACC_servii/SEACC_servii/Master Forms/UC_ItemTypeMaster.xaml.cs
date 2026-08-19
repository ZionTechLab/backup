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
    /// Interaction logic for UC_ItemTypeMaster.xaml
    /// </summary>
    public partial class UC_ItemTypeMaster : UserControl
    {
        public UC_ItemTypeMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.ItemTypeMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ItemType_ID");
            dgr_Main.dt.Columns.Add("TypeName");
            dgr_Main.dt.Columns.Add("ItemClass");
            dgr_Main.dt.Columns.Add("Prefrix");
            dgr_Main.dt.Columns.Add("TypeCounter");
            dgr_Main.dt.Columns.Add("TypeLength");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Type ID", "ItemType_ID", 75);
            dgr_Main.Add_DatagridColoumn("Type Name", "TypeName", 200);
            dgr_Main.Add_DatagridColoumn("Class", "ItemClass", 100, false);
            dgr_Main.Add_DatagridColoumn("Prefrix", "Prefrix", 75, false);
            dgr_Main.Add_DatagridColoumn("Counter", "TypeCounter", 60, false);
            dgr_Main.Add_DatagridColoumn("Length", "TypeLength", 60, false);
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
                foreach (tbl_zItemType itemType in tbl_zItemType.SelectAll().Where(p => p.ItemType_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(itemType.ItemType_ID, itemType.TypeName, clsRef_Name.get_ItemClass_Name(itemType.ItemClass_ID), itemType.Prefrix,itemType.TypeCounter,itemType.TypeLength);
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
                            tbl_zItemType OldDetails = tbl_zItemType.Select(txtItemTypeID.Text.Trim());
                            if (OldDetails != null)
                            {
                                tbl_zItemType oItemType = new tbl_zItemType(txtItemTypeID.Text, txtItemTypeName.Text, txtItemClassName.Tag.ToString(), txtItemTypePrefix.Text, int.Parse(txtTypeCounter.Text), int.Parse(txtTypeLegnth.Text));
                                oItemType.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    else
                    {                        
                        tbl_zItemType oItemType = new tbl_zItemType(txtItemTypeID.Tag.ToString(), txtItemTypeName.Text, txtItemClassName.Tag.ToString(), txtItemTypePrefix.Text, int.Parse(txtTypeCounter.Text), int.Parse(txtTypeLegnth.Text));
                        oItemType.Insert();
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
                if (txtItemTypeID.Tag != null)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                    if (bMessegeBoxResult)
                    {
                        tbl_zItemType oItemType = tbl_zItemType.Select(txtItemTypeID.Text.Trim());
                        if (oItemType != null)
                        {
                            oItemType.Delete();
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
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtItemTypeID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtItemTypeName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItemClassName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtItemTypePrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTypeCounter, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTypeLegnth, true, true, false);

            txtItemTypeID.Text = "";
            txtItemTypeID.Tag = null;
            txtItemTypeName.Text = "";
            txtItemClassName.Text = "";
            txtItemClassName.Tag = "default";
            txtItemTypePrefix.Text = "";
            txtTypeCounter.Text = "0";
            txtTypeLegnth.Text = "0";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtItemTypeID.setReadOnlyStatus(true);
                txtItemTypeID.Text = "<Auto Generate>";
            }
            else
                txtItemTypeID.setReadOnlyStatus(false);
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

            if (!clsValidation.Validate_EmptyValue(txtItemTypeID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtItemTypeName))
                bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtItemClassName))
            //    bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtItemTypePrefix))
            //    bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtTypeCounter))
            //    bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtTypeLegnth))
            //    bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtItemTypeID.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_zItemType oDetail = tbl_zItemType.Select(txtItemTypeID.Tag.ToString());
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
                    tbl_zItemType FillDetails = tbl_zItemType.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtItemTypeID.IsEnabled = false;
                        txtItemTypeID.Text = FillDetails.ItemType_ID;
                        txtItemTypeID.Tag = FillDetails.ItemType_ID;
                        txtItemTypeName.Text = FillDetails.TypeName;
                        txtItemClassName.Text = clsRef_Name.get_ItemClass_Name(FillDetails.ItemClass_ID);
                        txtItemClassName.Tag = FillDetails.ItemClass_ID;
                        txtItemTypePrefix.Text = FillDetails.Prefrix;
                        txtTypeCounter.Text = FillDetails.TypeCounter.ToString();
                        txtTypeLegnth.Text = FillDetails.TypeLength.ToString();
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
        private void grd_District_MouseLeftButtonUp1(object sender, EventArgs e)
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
        private void txtItemTypeID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemType);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtItemTypeID.Text = lstResult[0];
                txtItemTypeID.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtItemClass_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemClass);
            if (RowDataSearch.DialogResult == true)
            {
                txtItemClassName.Text = lstResult[1];
                txtItemClassName.Tag = lstResult[0];
            }
        }
        #endregion
    }
}
