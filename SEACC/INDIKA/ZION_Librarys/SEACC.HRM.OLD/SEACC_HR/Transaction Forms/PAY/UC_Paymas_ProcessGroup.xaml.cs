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
using Digiteq_Logic;
using SEACC_WPFControls;
using Digiteq.Transaction_Forms.PAY;

namespace Digiteq
{
    public partial class UC_Paymas_ProcessGroup : UserControl
    {
        #region Form Load
        public UC_Paymas_ProcessGroup()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payroll_Process_Group;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ProcessGroupID");
            dgr_Main.dt.Columns.Add("ProcessGroupTitle");
            dgr_Main.dt.Columns.Add("PayPeriod");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("ID", "ProcessGroupID", 70);
            dgr_Main.Add_DatagridColoumn("Group Title", "ProcessGroupTitle", 270);
            dgr_Main.Add_DatagridColoumn("Pay Period", "PayPeriod", 70, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(650);
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtGroupID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_payMas_ProcessGroup detail = tbl_payMas_ProcessGroup.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGroupID.Tag.ToString());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFields();
                                RefreshGrid();
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

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_payMas_ProcessGroup oldRecord = tbl_payMas_ProcessGroup.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGroupID.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_payMas_ProcessGroup detail = new tbl_payMas_ProcessGroup(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, oldRecord.ProcessGroup_ID, txtGroupTitle.Text, cmbPayPeriod.GetSelectedIndex(), decimal.Parse(txtNopayStdHrs.Text) * 60, decimal.Parse(txtLateStdHrs.Text) * 60, decimal.Parse(txtLateMaxMins.Text), decimal.Parse(txtLateMaxDays.Text), decimal.Parse(txtLateGraceMins.Text), decimal.Parse(txtOT_StdHrs.Text) * 60, decimal.Parse(txtDobOT_StdHrs.Text) * 60, oldRecord.IsCanceled);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        tbl_payMas_ProcessGroup detail = new tbl_payMas_ProcessGroup(clsSecurity.CompanyID, clsSecurity.BranchID, txtGroupID.Tag.ToString(), txtGroupTitle.Text, cmbPayPeriod.GetSelectedIndex(), decimal.Parse(txtNopayStdHrs.Text) * 60, decimal.Parse(txtLateStdHrs.Text) * 60, decimal.Parse(txtLateMaxMins.Text), decimal.Parse(txtLateMaxDays.Text), decimal.Parse(txtLateGraceMins.Text), decimal.Parse(txtOT_StdHrs.Text) * 60, decimal.Parse(txtDobOT_StdHrs.Text) * 60, false);
                        detail.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtGroupID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGroupTitle, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNopayStdHrs, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLateStdHrs, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLateMaxMins, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLateMaxDays, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLateGraceMins, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOT_StdHrs, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDobOT_StdHrs, true, true, false);

            txtGroupID.Tag = null;

            txtGroupID.Text = "";
            txtGroupTitle.Text = "";
            txtNopayStdHrs.Text = "0.00";
            txtLateStdHrs.Text = "0.00";
            txtLateMaxMins.Text = "0.00";
            txtLateMaxDays.Text = "0.00";
            txtLateGraceMins.Text = "0.00";
            txtOT_StdHrs.Text = "0.00";
            txtDobOT_StdHrs.Text = "0.00";

            cmbPayPeriod.SetValues(typeof(Digiteq_Logic.PaymentPeriod));
            cmbPayPeriod.SetSelectedIndex(-1);

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtGroupID.setReadOnlyStatus(true);
                txtGroupID.Text = "<Auto Generate>";
            }
            else
                txtGroupID.setReadOnlyStatus(false);

            #region Visible Late min, Late days and Grace min textboxes
            if (clsConfig.bEnable_LateMins_LateDays_GraceMins)
            {
                txtLateMaxMins.Visibility = Visibility.Visible;
                txtLateMaxDays.Visibility = Visibility.Visible;
                txtLateGraceMins.Visibility = Visibility.Visible;
            }
            else
            {
                txtLateMaxMins.Visibility = Visibility.Collapsed;
                txtLateMaxDays.Visibility = Visibility.Collapsed;
                txtLateGraceMins.Visibility = Visibility.Collapsed;
            } 
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_payMas_ProcessGroup detail in tbl_payMas_ProcessGroup.SelectAll().Where(p => p.IsCanceled == false && p.ProcessGroup_ID != "Default"))
                {
                    dgr_Main.dt.Rows.Add(detail.ProcessGroup_ID, detail.ProcessGroup_Title, detail.Pay_Period);
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
                    bStatus = true;
                if (!ChekValidity_DuplicateNames())
                    bStatus = false;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtGroupTitle))
                    bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtGroupID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtGroupID.Text = txtGroupID.Tag.ToString();
                }

                tbl_payMas_ProcessGroup detail = tbl_payMas_ProcessGroup.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGroupID.Tag.ToString());
                if (detail != null)
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
            foreach (tbl_payMas_ProcessGroup detail1 in tbl_payMas_ProcessGroup.SelectAll().Where(p => p.ProcessGroup_Title == txtGroupTitle.Text && p.IsCanceled == false && p.ProcessGroup_ID != txtGroupID.Tag.ToString()))
            {
                if (detail1 != null)
                {
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                    bStatus = false;
                    break;
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
                    tbl_payMas_ProcessGroup detail = tbl_payMas_ProcessGroup.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtGroupID.Text = detail.ProcessGroup_ID;
                        txtGroupTitle.Text = detail.ProcessGroup_Title;
                        txtNopayStdHrs.Text = cls_Formater.FormatDecimal(detail.DivRate_Nopay / 60, 2);
                        txtLateStdHrs.Text = cls_Formater.FormatDecimal(detail.DivRate_Late / 60, 2);
                        txtLateMaxMins.Text = cls_Formater.FormatDecimal(detail.MaxMins_Late, 2);
                        txtLateMaxDays.Text = cls_Formater.FormatDecimal(detail.MaxDays_Late, 2);
                        txtLateGraceMins.Text = cls_Formater.FormatDecimal(detail.GraceMins_Late, 2);
                        txtOT_StdHrs.Text = cls_Formater.FormatDecimal(detail.DivRate_OT / 60, 2);
                        txtDobOT_StdHrs.Text = cls_Formater.FormatDecimal(detail.DivRate_DOT / 60, 2);

                        cmbPayPeriod.SetSelectedIndex(detail.Pay_Period);

                        txtGroupID.Tag = detail.ProcessGroup_ID;

                    }
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
        private void txtGroupID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();

            List<string> lstResult = RowDataSearch.Show(Search.PayrollProcessGroup);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        //private void btn_ProcessGroup_Click(object sender, RoutedEventArgs e)
        //{
        //    if (txtGroupID.Tag != null)
        //    {
        //        UC_Paymass_ProcessPeriod_Main UC = new UC_Paymass_ProcessPeriod_Main(txtGroupID.Tag.ToString());
        //        frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
        //        SW.ShowDialog();
        //    }
        //    else
        //    {
        //        SEACCMessageBox.Show("Oops....", " Please Select a Process Group First...", MessageBoxButton.OK);
        //    }
        //}

        private void lblProcessPeriod_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (txtGroupID.Tag != null)
            {
                UC_Paymass_ProcessPeriod_Main UC = new UC_Paymass_ProcessPeriod_Main(txtGroupID.Tag.ToString());
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
            else
            {
                SEACCMessageBox.Show("Oops....", " Please Select a Process Group First...", MessageBoxButton.OK);
            }
        }

        private void lblEmpSalary_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (txtGroupID.Tag != null)
            {
                UC_PayrollUserPermissions UC = new UC_PayrollUserPermissions();
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
            else
            {
                SEACCMessageBox.Show("Oops....", " Please Select a Process Group First...", MessageBoxButton.OK);
            }
        }
    }
}