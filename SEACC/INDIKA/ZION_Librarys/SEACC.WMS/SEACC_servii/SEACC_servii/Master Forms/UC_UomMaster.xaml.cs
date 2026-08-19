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
    /// Interaction logic for UC_UomMaster.xaml
    /// </summary>
    public partial class UC_UomMaster : UserControl
    {
        #region Form Load
        public UC_UomMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.UnitOfMeasureMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("UoM_ID");
            dgr_Main.dt.Columns.Add("UoM_Code");
            dgr_Main.dt.Columns.Add("UoM_Name");
            dgr_Main.dt.Columns.Add("UoM_Category");            
            dgr_Main.dt.Columns.Add("IsVisible", typeof(bool));
            dgr_Main.dt.Columns.Add("IsForSale", typeof(bool));
            dgr_Main.dt.Columns.Add("IsForPacking", typeof(bool));
            dgr_Main.dt.Columns.Add("IsForKiloCalculation", typeof(bool));
            dgr_Main.dt.Columns.Add("IsForBagCalculation", typeof(bool));
            dgr_Main.dt.Columns.Add("IsQty", typeof(bool));
            dgr_Main.dt.Columns.Add("IsWeight", typeof(bool));
            dgr_Main.dt.Columns.Add("IsLength", typeof(bool));
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("ID", "UoM_ID", 80, false);
            dgr_Main.Add_DatagridColoumn("Code", "UoM_Code", 100);
            dgr_Main.Add_DatagridColoumn("Name", "UoM_Name", 150);
            dgr_Main.Add_DatagridColoumn("Category", "UoM_Category", 80);            
            dgr_Main.Add_DatagridColoumn("Is Visible", "IsVisible", 80, false);
            dgr_Main.Add_DatagridColoumn("IS For Sale", "IsForSale", 80, false);
            dgr_Main.Add_DatagridColoumn("Is For Packing", "IsForPacking", 80, false);
            dgr_Main.Add_DatagridColoumn("Is Kg. Clac", "IsForKiloCalculation", 80, false);
            dgr_Main.Add_DatagridColoumn("Is Bag Calc", "IsForBagCalculation", 80, false);
            dgr_Main.Add_DatagridColoumn("Is Quantity", "IsQty", 80, false);
            dgr_Main.Add_DatagridColoumn("Is Weight", "IsWeight", 80, false);
            dgr_Main.Add_DatagridColoumn("Is Length", "IsLength", 80, false);
            #endregion

            ClearFields();
            RefreshGrid();
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_zUom item in tbl_zUom.SelectAll().Where(p => p.Uom_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(item.Uom_ID, item.UomCode, item.UomName, clsRef_Name.get_UomCategory_Name(item.UomCategory_ID),  item.IsVisible, item.IsForSales, item.IsForPacking, item.IsForKiloCalculation, item.IsForBagCalculation, item.IsQty, item.IsWeight, item.IsLength);
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
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtUomID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtUomName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUomCategoryID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtUomCode, true, false, false);

            txtUomID.Text = "";
            txtUomName.Text = "";
            txtUomCategoryID.Text = "";
            txtUomCode.Text = "";

            txtUomID.Tag = null;
            txtUomCategoryID.Tag = null;

            chkIsVisible.IsChecked = false;
            chkIsforsale.IsChecked = false;
            chkIsforPacking.IsChecked = false;
            chkIsForKiloCalculation.IsChecked = false;
            chkIsforBagCalculation.IsChecked = false;
            chkIsQty.IsChecked = false;
            chkIsWeight.IsChecked = false;
            chkIsLength.IsChecked = false;

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtUomID.setReadOnlyStatus(true);
                txtUomID.Text = "<Auto Generate>";
            }
            else
                txtUomID.setReadOnlyStatus(false);
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
                            tbl_zUom OldDetails = tbl_zUom.Select(txtUomID.Text.Trim());
                            if (OldDetails != null)
                            {
                                tbl_zUom oUOM = new tbl_zUom(txtUomID.Text, txtUomName.Text, txtUomCategoryID.Tag.ToString(), txtUomCode.Text, chkIsVisible.IsChecked, chkIsforsale.IsChecked, chkIsforPacking.IsChecked, chkIsForKiloCalculation.IsChecked, chkIsforBagCalculation.IsChecked, chkIsQty.IsChecked, chkIsWeight.IsChecked, chkIsLength.IsChecked);
                                oUOM.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    else
                    {                    
                        //if (SEACC_Form.isAutoGenaratedCode)
                        //    txtUomCategoryID.Text = SEACC_Form.getAutoGeneratedCode();
                        tbl_zUom nUoM = new tbl_zUom(txtUomID.Tag.ToString(), txtUomName.Text, txtUomCategoryID.Tag.ToString(), txtUomCode.Text, chkIsVisible.IsChecked, chkIsforsale.IsChecked, chkIsforPacking.IsChecked, chkIsForKiloCalculation.IsChecked, chkIsforBagCalculation.IsChecked, chkIsQty.IsChecked, chkIsWeight.IsChecked, chkIsLength.IsChecked);
                        nUoM.Insert();
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

            if (!clsValidation.Validate_EmptyValue(txtUomID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtUomName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtUomCategoryID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtUomCode))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtUomID.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_zUom oDetail = tbl_zUom.Select(txtUomID.Text);
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
                    tbl_zUom FillDetails = tbl_zUom.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtUomID.IsEnabled = false;
                        txtUomID.Text = FillDetails.Uom_ID;
                        txtUomName.Text = FillDetails.UomName;
                        txtUomCategoryID.Text = FillDetails.UomCategory_ID + " - " + clsRef_Name.get_UomCategory_Name(FillDetails.UomCategory_ID);
                        txtUomCode.Text = FillDetails.UomCode;

                        txtUomCategoryID.Tag = FillDetails.UomCategory_ID;
                        txtUomID.Tag = FillDetails.UomCategory_ID;

                        chkIsVisible.IsChecked = FillDetails.IsVisible;
                        chkIsforsale.IsChecked = FillDetails.IsForSales; 
                        chkIsforPacking.IsChecked = FillDetails.IsForPacking;
                        chkIsForKiloCalculation.IsChecked = FillDetails.IsForKiloCalculation;
                        chkIsforBagCalculation.IsChecked = FillDetails.IsForBagCalculation;
                        chkIsQty.IsChecked = FillDetails.IsQty;
                        chkIsWeight.IsChecked = FillDetails.IsWeight;
                        chkIsLength.IsChecked = FillDetails.IsLength;
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
        private void grd_UoM_MouseLeftButtonUp1(object sender, EventArgs e)
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
        private void txtUomID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtUomID.Text = lstResult[0];
                txtUomID.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        private void txtUomCategoryID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.UOM_Categories);
            if (RowDataSearch.DialogResult == true)
            {
                txtUomCategoryID.Text = lstResult[0] + " - " + lstResult[1];
                txtUomCategoryID.Tag = lstResult[0];
            }
        } 
        #endregion

    }
}
