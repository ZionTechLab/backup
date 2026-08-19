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
    /// Coded by Gayan
    /// 2017-04-17
    /// </summary>
    public partial class UC_JobName : UserControl
    {
        #region Form Load
        public UC_JobName()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_JobNames;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("TypeID");
            dgr_Main.dt.Columns.Add("TypeName");
            dgr_Main.dt.Columns.Add("Prefix");
            dgr_Main.dt.Columns.Add("Remark");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Type ID", "TypeID", 75, false);
            dgr_Main.Add_DatagridColoumn("Prefix", "Prefix", 75);
            dgr_Main.Add_DatagridColoumn("Description", "TypeName", 150);
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

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (SEACC_Form.CheckPermission_ToCancel())
                    {
                        if (txtJobNameID.Tag != null)
                        {
                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                            if (bMessegeBoxResult)
                            {
                                tbl_zItemClass oOldType = tbl_zItemClass.Select(txtJobNameID.Tag.ToString());
                                if (oOldType != null)
                                {
                                    //oOldType.IsDeleted = true;
                                    //oOldType.Update();

                                    //SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                    //ClearFields();
                                    //RefreshGrid();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
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
                            tbl_zItemClass oJobName = tbl_zItemClass.Select(txtJobNameID.Tag.ToString());
                            if (oJobName != null)
                            {
                                tbl_zItemClass oOldName = new tbl_zItemClass(txtJobNameID.Tag.ToString(), txtJobName.Text, txtPrefix.Text, txtShortPrefix.Text, txtRemark.Text, oJobName.IsProd_Class);
                                oOldName.Update();
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
                            tbl_zItemClass oNewName = new tbl_zItemClass(txtJobNameID.Tag.ToString(), txtJobName.Text, txtPrefix.Text, txtShortPrefix.Text, txtRemark.Text, true);
                            oNewName.Insert();
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

        #region Clearfield
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtJobNameID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtJobName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtShortPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);

            txtJobNameID.Tag = null;

            txtJobNameID.Text = "";
            txtJobName.Text = "";
            txtPrefix.Text = "";
            txtShortPrefix.Text = "";
            txtRemark.Text = "";

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtJobNameID.setReadOnlyStatus(true);
                txtJobNameID.Text = "<Auto Generate>";
            }
            else
                txtJobNameID.setReadOnlyStatus(false);
            #endregion

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_zItemClass oType in tbl_zItemClass.SelectAll().Where(p => p.ItemClass_ID != "default" && p.IsProd_Class))
                {
                    dgr_Main.dt.Rows.Add(oType.ItemClass_ID, oType.ClassName, oType.Prefrix, oType.Remark);
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

            if (!clsValidation.Validate_EmptyValue(txtJobNameID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtJobName))
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
                    txtJobNameID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtJobNameID.Text = txtJobNameID.Tag.ToString();
                }

                tbl_zItemClass oType = tbl_zItemClass.Select(txtJobNameID.Text);
                if (oType != null)
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
            foreach (tbl_zItemClass detail1 in tbl_zItemClass.SelectAll().Where(p => p.ClassName == txtJobName.Text && p.ItemClass_ID != txtJobNameID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                break;
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                tbl_zItemClass oJobType = tbl_zItemClass.Select(sID);
                if (oJobType != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtJobNameID.Tag = oJobType.ItemClass_ID;

                    txtJobNameID.Text = oJobType.ItemClass_ID;
                    txtJobName.Text = oJobType.ClassName;
                    txtPrefix.Text = oJobType.Prefrix;
                    txtShortPrefix.Text = oJobType.Prefrix2;
                    txtRemark.Text = oJobType.Remark;
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
                    FillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Search Events
        private void txtJobTypeID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionJobName);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                FillDetails(lstResult[0]);
            }
        }
        #endregion

        #region Key Events
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
