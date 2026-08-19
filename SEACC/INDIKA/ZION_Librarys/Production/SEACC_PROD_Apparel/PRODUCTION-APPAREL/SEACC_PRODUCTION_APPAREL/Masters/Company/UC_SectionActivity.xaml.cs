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
    /// Interaction logic for UC_JobStatus.xaml
    /// </summary>
    public partial class UC_SectionActivity : UserControl
    {
        #region Form Load
        public UC_SectionActivity()
        {
            #region Initialize Unsercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_SectionActivity;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ActivityID");
            dgr_Main.dt.Columns.Add("ActivityName");
            dgr_Main.dt.Columns.Add("Section");
            dgr_Main.dt.Columns.Add("Remarks");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Activity ID", "ActivityID", 75, false);
            dgr_Main.Add_DatagridColoumn("Description", "ActivityName", 150);
            dgr_Main.Add_DatagridColoumn("Section", "Section", 150);
            dgr_Main.Add_DatagridColoumn("Remarks", "Remarks", 300);
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
                            tbl_prodMasSectionActivity oOldActivity = tbl_prodMasSectionActivity.Select(txtActivityID.Tag.ToString());
                            if (oOldActivity != null)
                            {
                                tbl_prodMasSectionActivity oActivity = new tbl_prodMasSectionActivity(txtActivityID.Tag.ToString(), txtActivitydescription.Text, txtSectionName.Tag != null ? txtSectionName.Tag.ToString() : "default", tsShiftHrs.GetMinutes(), tsShiftHrsNight.GetMinutes(), txtRemark.Text, decimal.Parse(txtLabourRate.Text), decimal.Parse(txtLabourRateNight.Text), decimal.Parse(txtFactoryOH_Rate.Text), decimal.Parse(txtOtherCostRate.Text));
                                oActivity.Update();
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
                            tbl_prodMasSectionActivity oNewActivity = new tbl_prodMasSectionActivity(txtActivityID.Tag.ToString(), txtActivitydescription.Text, txtSectionName.Tag != null ? txtSectionName.Tag.ToString() : "default", tsShiftHrs.GetMinutes(), tsShiftHrsNight.GetMinutes(), txtRemark.Text, decimal.Parse(txtLabourRate.Text), decimal.Parse(txtLabourRateNight.Text), decimal.Parse(txtFactoryOH_Rate.Text), decimal.Parse(txtOtherCostRate.Text));
                            oNewActivity.Insert();
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

        #region Clear Feilds
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtActivityID, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtActivitydescription, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSectionName, true, false, true);
            cls_Formater.SetEnableDisable_LableTimeSpan(tsShiftHrs, true);
            cls_Formater.SetEnableDisable_LableTimeSpan(tsShiftHrsNight, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtLabourRate, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLabourRateNight, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFactoryOH_Rate, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOtherCostRate, true, true, false);

            txtActivityID.Tag = null;
            txtSectionName.Tag = null;

            txtActivityID.Text = "";
            txtActivitydescription.Text = "";
            txtRemark.Text = "";
            txtSectionName.Text = "";

            txtLabourRate.Text = "0.00";
            txtLabourRateNight.Text = "0.00";
            txtFactoryOH_Rate.Text = "0.00";
            txtOtherCostRate.Text = "0.00";

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtActivityID.setReadOnlyStatus(true);
                txtActivityID.Text = "<Auto Generate>";
            }
            else
                txtActivityID.setReadOnlyStatus(false);
            #endregion

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_prodMasSectionActivity oActivity in tbl_prodMasSectionActivity.SelectAll().Where(p => p.Activity_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oActivity.Activity_ID, oActivity.Description, clsGenaralName.getName_Section(oActivity.Section_ID), oActivity.Remarks);
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

            if (!clsValidation.Validate_EmptyValue(txtActivityID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtActivitydescription))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSectionName))
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
                    txtActivityID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtActivityID.Text = txtActivityID.Tag.ToString();
                }

                tbl_prodMasSectionActivity oActivity = tbl_prodMasSectionActivity.Select(txtActivityID.Text);
                if (oActivity != null)
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
            foreach (tbl_prodMasSectionActivity oActiviy in tbl_prodMasSectionActivity.SelectAll().Where(p => p.Description == txtActivitydescription.Text && p.Activity_ID != txtActivityID.Text))
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
                tbl_prodMasSectionActivity oActivity = tbl_prodMasSectionActivity.Select(sID);
                if (oActivity != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtActivityID.Tag = oActivity.Activity_ID;
                    txtSectionName.Tag = oActivity.Section_ID;

                    txtActivityID.Text = oActivity.Activity_ID;
                    txtActivitydescription.Text = oActivity.Description;
                    txtSectionName.Text = clsGenaralName.getName_Section(oActivity.Section_ID);
                    tsShiftHrs.setMinutes(Convert.ToInt32(oActivity.ShiftMinutes_Day));
                    tsShiftHrsNight.setMinutes(Convert.ToInt32(oActivity.ShiftMinutes_Night));
                    txtRemark.Text = oActivity.Remarks;
                    txtLabourRate.Text = clsFormatter.FormatDecimalPlaces_Quantity(oActivity.LabourRatePerHour_Day);
                    txtLabourRateNight.Text = clsFormatter.FormatDecimalPlaces_Quantity(oActivity.LabourRatePerHour_Night);
                    txtFactoryOH_Rate.Text = clsFormatter.FormatDecimalPlaces_Quantity(oActivity.OHRatePerHour);
                    txtOtherCostRate.Text = clsFormatter.FormatDecimalPlaces_Quantity(oActivity.OtherCostRatePerHour);
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
        private void txtActivityID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionSectionActivities);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[2]);
            }
        }
        

        private void txtSectionName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSectionName.Tag = lstResult[0];
                txtSectionName.Text = lstResult[1];
            }
        }
        #endregion

        #region Key Key Event
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
