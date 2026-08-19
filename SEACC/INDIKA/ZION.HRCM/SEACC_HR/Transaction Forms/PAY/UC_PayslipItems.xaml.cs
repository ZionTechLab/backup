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
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    public partial class UC_PayslipItems : UserControl
    {
        #region Class Variables
        DataTable dt_StatutaryItems = new DataTable();
        #endregion

        #region Form Load
        public UC_PayslipItems()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payslip_Items;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Datatable
            dgr_Main.dt.Columns.Add("ItemId");
            dgr_Main.dt.Columns.Add("ItemCode");
            dgr_Main.dt.Columns.Add("ItemTitle");
            dgr_Main.dt.Columns.Add("ItemClass");
            dgr_Main.dt.Columns.Add("ItemType");

            dt_StatutaryItems.Columns.Add("apply", typeof(bool));
            dt_StatutaryItems.Columns.Add("statutaryPayItem_ID");
            dt_StatutaryItems.Columns.Add("statutaryPayItem_Code");
            dt_StatutaryItems.Columns.Add("statutaryPayItem_Title");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("#", "ItemId", 70, false);
            dgr_Main.Add_DatagridColoumn("Code", "ItemCode", 70);
            dgr_Main.Add_DatagridColoumn("Title", "ItemTitle", 200);
            dgr_Main.Add_DatagridColoumn("Class", "ItemClass", 70);
            dgr_Main.Add_DatagridColoumn("Type", "ItemType", 70);

            dgrStatutary.ItemsSource = dt_StatutaryItems.DefaultView;
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
                coloumnA.Width = new GridLength(550);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtPayCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_payMas_PaySlipItems detail = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtPayCode.Tag.ToString());
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
                            tbl_payMas_PaySlipItems oldRecord = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtPayCode.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_payMas_PaySlipItems detail = new tbl_payMas_PaySlipItems(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, oldRecord.PayItem_ID, txtPayCode.Text,
                                    txtPayTitle.Text, txtPayClass.Tag.ToString(), txtPayType.Tag.ToString(), cmbPayMode.GetSelectedIndex(), chkIsEarning.IsChecked,
                                    cmbPayPeriod.GetSelectedIndex(), chkIsOneTimePay.IsChecked, int.Parse(txtPayYear.Tag.ToString()), int.Parse(txtPayMoth.Tag.ToString()), oldRecord.IsCanceled, chkNoPayApplicable.IsChecked, chkZeroValueShow.IsChecked, chkPayslipApplicable.IsChecked);

                                detail.Update();
                                Insert_PaySlipItems_Statutary();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        tbl_payMas_PaySlipItems detail = new tbl_payMas_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, txtPayCode.Tag.ToString(), txtPayCode.Text,
                            txtPayTitle.Text, txtPayClass.Tag.ToString(), txtPayType.Tag.ToString(), cmbPayMode.GetSelectedIndex(), chkIsEarning.IsChecked,
                            cmbPayPeriod.GetSelectedIndex(), chkIsOneTimePay.IsChecked, int.Parse(txtPayYear.Tag.ToString()), int.Parse(txtPayMoth.Tag.ToString()), false, chkNoPayApplicable.IsChecked, chkZeroValueShow.IsChecked, chkPayslipApplicable.IsChecked);

                        detail.Insert();
                        Insert_PaySlipItems_Statutary();
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

            cls_Formater.SetEnableDisable_LableTextbox(txtPayCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPayTitle, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayClass, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayType, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayYear, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayMoth, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGLCode_Credit, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGLCode_Debit, true, false, false);

            txtPayCode.Tag = null;
            txtPayClass.Tag = null;
            txtPayType.Tag = null;
            txtPayYear.Tag = 0;
            txtPayMoth.Tag = 0;

            txtPayCode.Text = "";
            txtPayTitle.Text = "";
            txtPayClass.Text = "";
            txtPayType.Text = "";
            txtPayYear.Text = "";
            txtPayMoth.Text = "";
            txtGLCode_Credit.Text = "";
            txtGLCode_Debit.Text = "";

            chkIsEarning.IsChecked = false;
            chkIsOneTimePay.IsChecked = false;
            chkNoPayApplicable.IsChecked = false;
            chkZeroValueShow.IsChecked = true;
            chkPayslipApplicable.IsChecked = true;

            txtPayYear.Visibility = Visibility.Collapsed;
            txtPayMoth.Visibility = Visibility.Collapsed;

            cmbPayMode.comboBox.ItemsSource = clsCommon.GetEnumDescription(typeof(Digiteq_Logic.InputMode));
            cmbPayMode.SetSelectedIndex(-1);

            cmbPayPeriod.SetValues(typeof(Digiteq_Logic.PaymentPeriod));
            cmbPayPeriod.SetSelectedIndex(-1);

            #region Set Statutary Items
            dt_StatutaryItems.Clear();
            foreach (tbl_payMas_StatutaryItems oItem in tbl_payMas_StatutaryItems.SelectAll().Where(p => p.StatutaryPayItem_ID != "Default" && p.IsCanceled == false))
            {
                dt_StatutaryItems.Rows.Add(false, oItem.StatutaryPayItem_ID, oItem.StatutaryPayItem_Code, oItem.StatutaryPayItem_Title);
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
                foreach (tbl_payMas_PaySlipItems oItem in tbl_payMas_PaySlipItems.SelectAll().Where(p => p.PayItem_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oItem.PayItem_ID, oItem.PayItem_Code, oItem.PayItem_Title, clsRef_Name.get_PaySlipItem_Class_Code(oItem.PayItem_Class_ID), clsRef_Name.get_PaySlipItem_Type_Code(oItem.PayItem_Type_ID));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateKey())
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

            if (!clsValidation.Validate_EmptyValue(txtPayCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPayTitle))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPayClass))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPayType))
                bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtPayYear))
            //    bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtPayMoth))
            //    bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtPayCode.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_payMas_PaySlipItems detail = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtPayCode.Tag.ToString());
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
            foreach (tbl_payMas_PaySlipItems detail1 in tbl_payMas_PaySlipItems.SelectAll().Where(p => p.PayItem_Code == txtPayCode.Text && p.IsCanceled == false && p.PayItem_ID != txtPayCode.Tag.ToString()))
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
                tbl_payMas_PaySlipItems oPayslipItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                if (oPayslipItem != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtPayCode.Tag = oPayslipItem.PayItem_ID;
                    txtPayClass.Tag = oPayslipItem.PayItem_Class_ID;
                    txtPayType.Tag = oPayslipItem.PayItem_Type_ID;
                    txtPayYear.Tag = oPayslipItem.OneTime_PayrollYear;
                    txtPayMoth.Tag = oPayslipItem.OneTime_PayrollMonth;

                    txtPayCode.Text = oPayslipItem.PayItem_Code;
                    txtPayTitle.Text = oPayslipItem.PayItem_Title;
                    txtPayClass.Text = clsRef_Name.get_PaySlipItem_Class_Code(oPayslipItem.PayItem_Class_ID);
                    txtPayType.Text = clsRef_Name.get_PaySlipItem_Type_Code(oPayslipItem.PayItem_Type_ID);
                    txtPayYear.Text = clsRef_Name.get_YearName(oPayslipItem.OneTime_PayrollYear.ToString());
                    txtPayMoth.Text = clsRef_Name.get_MonthName(oPayslipItem.OneTime_PayrollMonth.ToString());

                    chkIsEarning.IsChecked = oPayslipItem.IsEarning;
                    chkIsOneTimePay.IsChecked = oPayslipItem.Is_OneTimePayment;
                    chkZeroValueShow.IsChecked = oPayslipItem.IsZeroValueShow;
                    if (oPayslipItem.Is_OneTimePayment)
                    {
                        txtPayYear.Visibility = Visibility.Visible;
                        txtPayMoth.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        txtPayYear.Visibility = Visibility.Collapsed;
                        txtPayMoth.Visibility = Visibility.Collapsed;
                    }

                    chkNoPayApplicable.IsChecked = oPayslipItem.IsNoPayable;
                    chkPayslipApplicable.IsChecked = oPayslipItem.IsPayslipApplicable;

                    cmbPayMode.SetSelectedIndex(oPayslipItem.InputMode);
                    cmbPayPeriod.SetSelectedIndex(oPayslipItem.Pay_Period);

                    fill_StatutaryItems(sID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void fill_StatutaryItems(string sPaySlipItem_ID)
        {
            try
            {
                dt_StatutaryItems.Clear();
                foreach (tbl_payMas_StatutaryItems oItem in tbl_payMas_StatutaryItems.SelectAll().Where(p => p.StatutaryPayItem_ID != "Default" && p.IsCanceled == false))
                {
                    dt_StatutaryItems.Rows.Add(CheckStatItem_Applicability(sPaySlipItem_ID, oItem.StatutaryPayItem_ID), oItem.StatutaryPayItem_ID, oItem.StatutaryPayItem_Code, oItem.StatutaryPayItem_Title);
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

        private void dgrStatutary_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgrStatutary.SelectedIndex;
            var vDG_Cell = dgrStatutary.CurrentCell;
            try
            {
                if (vDG_Cell.Column.Header.ToString() == "Apply")
                {
                    dt_StatutaryItems.Rows[irowID]["Apply"] = dt_StatutaryItems.Rows[irowID]["Apply"].ToString() == "True" ? false : true;
                }
            }
            catch (Exception)
            { }
        }
        #endregion

        #region Search Events
        private void txtPayCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayslipItems);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtPayCode.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtPayClass_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PaySlipItemsClass);
            if (RowDataSearch.DialogResult == true)
            {
                txtPayClass.Tag = lstResult[0];
                txtPayClass.Text = lstResult[1];
            }
        }

        private void txtPayType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PaySlipItemsType);
            if (RowDataSearch.DialogResult == true)
            {
                txtPayClass.Tag = lstResult[0];
                txtPayType.Tag = lstResult[2];

                txtPayClass.Text = lstResult[1];
                txtPayType.Text = lstResult[3];
            }
        }

        private void txtPayYear_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                txtPayYear.Tag = lstResult[0];
                txtPayYear.Text = lstResult[1];
            }
        }

        private void txtPayMoth_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRMonth);
            if (RowDataSearch.DialogResult == true)
            {
                txtPayMoth.Tag = lstResult[0];
                txtPayMoth.Text = lstResult[1];
            }
        }
        #endregion

        #region Help Methods
        private bool CheckStatItem_Applicability(string payItem, string statutaryItem)
        {
            bool result = false;
            tbl_payMas_PaySlipItems_Statutary oItem = tbl_payMas_PaySlipItems_Statutary.Select(clsSecurity.CompanyID, clsSecurity.BranchID, payItem, statutaryItem);
            if (oItem != null)
                result = oItem.IsApplicable;
            return result;
        }


        private void Insert_PaySlipItems_Statutary()
        {
            try
            {
                foreach (tbl_payMas_PaySlipItems_Statutary obj in tbl_payMas_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_PayItem_ID(clsSecurity.CompanyID, clsSecurity.BranchID, txtPayCode.Tag.ToString()))
                    obj.Delete();

                foreach (DataRow row in dt_StatutaryItems.Rows)
                {
                    bool apply = bool.Parse(row["apply"].ToString());
                    if (apply)
                    {
                        tbl_payMas_PaySlipItems_Statutary nStatItem = new tbl_payMas_PaySlipItems_Statutary(clsSecurity.CompanyID, clsSecurity.BranchID, txtPayCode.Tag.ToString(), row["statutaryPayItem_ID"].ToString(), apply);
                        nStatItem.Insert();
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Box One Time Payment
        private void chkIsOneTimePay_checkBox_Checked(object sender, EventArgs e)
        {
            try
            {
                txtPayYear.Visibility = Visibility.Visible;
                txtPayMoth.Visibility = Visibility.Visible;
            }
            catch (Exception)
            { }
        }

        private void chkIsOneTimePay_checkBox_Unchecked(object sender, EventArgs e)
        {
            try
            {
                txtPayYear.Visibility = Visibility.Collapsed;
                txtPayMoth.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            { }
        } 
        #endregion

    }
}