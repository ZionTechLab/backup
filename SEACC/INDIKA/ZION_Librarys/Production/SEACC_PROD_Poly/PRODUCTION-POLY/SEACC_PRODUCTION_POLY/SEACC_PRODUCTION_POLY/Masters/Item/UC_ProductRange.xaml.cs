using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Search;
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

namespace SEACC_PRODUCTION_POLY.Masters
{
    /// <summary>
    /// Coded by Gayan
    /// 2017.04.18
    /// </summary>
    public partial class UC_ProductRange : UserControl
    {
        #region Initialize Form
        public UC_ProductRange()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_ProductRanges;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("RangeID");
            dgr_Main.dt.Columns.Add("RangeName");
            dgr_Main.dt.Columns.Add("Prefix");
            dgr_Main.dt.Columns.Add("Remark");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            //this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Range ID", "RangeID", 75, false);
            dgr_Main.Add_DatagridColoumn("Prefix", "Prefix", 75);
            dgr_Main.Add_DatagridColoumn("Description", "RangeName", 150);
            dgr_Main.Add_DatagridColoumn("Remark", "Remark", 350);
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
                            tbl_zItemType oOldRange = tbl_zItemType.Select(txtRangeID.Tag.ToString());
                            if (oOldRange != null)
                            {
                                tbl_zItemType oRange = new tbl_zItemType(txtRangeID.Tag.ToString(), txtRangeName.Text, oOldRange.ItemClass_ID, txtPrefix.Text, txtShortPrefix.Text, oOldRange.TypeCounter, oOldRange.TypeLength, oOldRange.CompanyID, oOldRange.CompanyBranch_ID, txtRemark.Text);
                                oRange.Update();
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
                            tbl_zItemType oNewRange = new tbl_zItemType(txtRangeID.Tag.ToString(), txtRangeName.Text, "default", txtPrefix.Text, txtShortPrefix.Text, 0, 0, clsSecurity.CompanyID, clsSecurity.BranchID, txtRemark.Text);
                            oNewRange.Insert();
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

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtRangeID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRangeName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtShortPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);

            txtRangeID.Tag = null;

            txtRangeID.Text = "";
            txtRangeName.Text = "";
            txtPrefix.Text = "";
            txtShortPrefix.Text = "";
            txtRemark.Text = "";

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtRangeID.setReadOnlyStatus(true);
                txtRangeID.Text = "<Auto Generate>";
            }
            else
                txtRangeID.setReadOnlyStatus(false);
            #endregion

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_zItemType oProdRange in tbl_zItemType.SelectAll().Where(p => p.ItemType_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oProdRange.ItemType_ID, oProdRange.TypeName, oProdRange.Prefrix, oProdRange.Remark);
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

            if (!clsValidation.Validate_EmptyValue(txtRangeID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtRangeName))
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
                    txtRangeID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtRangeID.Text = txtRangeID.Tag.ToString();
                }

                tbl_zItemType oRange = tbl_zItemType.Select(txtRangeID.Text);
                if (oRange != null)
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
            foreach (tbl_zItemType oRange in tbl_zItemType.SelectAll().Where(p => p.TypeName == txtRangeName.Text && p.ItemType_ID != txtRangeID.Text))
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
                tbl_zItemType oRange = tbl_zItemType.Select(sID);
                if (oRange != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtRangeID.Tag = oRange.ItemType_ID;

                    txtRangeID.Text = oRange.ItemType_ID;
                    txtRangeName.Text = oRange.TypeName;
                    txtPrefix.Text = oRange.Prefrix;
                    txtShortPrefix.Text = oRange.Prefrix2;
                    txtRemark.Text = oRange.Remark;
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

        #region Search Event
        private void txtRangeID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_productRange);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
    }
}
