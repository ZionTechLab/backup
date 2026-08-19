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

namespace Digiteq.Transaction_Forms.PAY
{
    /// <summary>
    /// Interaction logic for UC_Payslip_Items_Statutary.xaml
    /// </summary>
    public partial class UC_Payslip_Items_Statutary : UserControl
    {
        #region Form Load
        public UC_Payslip_Items_Statutary()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payslip_Items_Statutary;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("StatItemID");
            dgr_Main.dt.Columns.Add("StatCode");
            dgr_Main.dt.Columns.Add("StatTitle");
            dgr_Main.dt.Columns.Add("StatPercentage");
            dgr_Main.dt.Columns.Add("FlatRate");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("ID", "StatItemID", 70, false);
            dgr_Main.Add_DatagridColoumn("Code", "StatCode", 75);
            dgr_Main.Add_DatagridColoumn("Title", "StatTitle", 200);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Percentage", "StatPercentage", 100, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Flat Rate", "FlatRate", 70, false, true);
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
                coloumnA.Width = new GridLength(470);
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
                    if (txtStatCode.Tag != null && txtStatCode.Tag.ToString() !="")
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_payMas_StatutaryItems detail = tbl_payMas_StatutaryItems.Select(clsSecurity.CompanyID,clsSecurity.BranchID,txtStatCode.Tag.ToString());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                //detail.Date_Canceled = clsSecurity.getServerDateTime();
                                //detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                //detail.UserID_Canceled = clsSecurity.UserIDLoged;
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
                            tbl_payMas_StatutaryItems oldRecord = tbl_payMas_StatutaryItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtStatCode.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_payMas_StatutaryItems detail = new tbl_payMas_StatutaryItems(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, oldRecord.StatutaryPayItem_ID, txtStatCode.Text, txtStatTitle.Text,decimal.Parse(txtStatPercentage.Text), decimal.Parse(txtFlatRate.Text), chkIsFlatRate.IsChecked, oldRecord.IsCanceled);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {                        
                        tbl_payMas_StatutaryItems detail = new tbl_payMas_StatutaryItems(clsSecurity.CompanyID, clsSecurity.BranchID, txtStatCode.Tag.ToString(), txtStatCode.Text, txtStatTitle.Text, decimal.Parse(txtStatPercentage.Text), decimal.Parse(txtFlatRate.Text), chkIsFlatRate.IsChecked, false);
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

            cls_Formater.SetEnableDisable_LableTextbox(txtStatCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtStatTitle, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtStatPercentage, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFlatRate, true, true, false);

            txtStatCode.Tag = null;

            txtStatCode.Text = "";
            txtStatTitle.Text = "";
            txtStatPercentage.Text = "0";
            txtFlatRate.Text = "0";

            chkIsFlatRate.IsChecked = false;
            txtFlatRate.Visibility = Visibility.Collapsed;           
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_payMas_StatutaryItems detail in tbl_payMas_StatutaryItems.SelectAll().Where(p => p.IsCanceled == false && p.StatutaryPayItem_ID != "Default"))
                {
                    dgr_Main.dt.Rows.Add(detail.StatutaryPayItem_ID, detail.StatutaryPayItem_Code, detail.StatutaryPayItem_Title, cls_Formater.FormatDecimal( detail.Percentage,2), cls_Formater.FormatDecimal(detail.FlatRate,2));
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
                if (!clsValidation.Validate_EmptyValue(txtStatCode))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtStatTitle))
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
                    txtStatCode.Tag = SEACC_Form.getAutoGeneratedCode();
                tbl_payMas_StatutaryItems detail = tbl_payMas_StatutaryItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtStatCode.Tag.ToString());
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
            foreach (tbl_payMas_StatutaryItems detail1 in tbl_payMas_StatutaryItems.SelectAll().Where(p => p.StatutaryPayItem_Code == txtStatCode.Text && p.IsCanceled == false && p.StatutaryPayItem_ID != txtStatCode.Tag.ToString()))
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
                    tbl_payMas_StatutaryItems detail = tbl_payMas_StatutaryItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtStatCode.Tag = detail.StatutaryPayItem_ID;

                        txtStatCode.Text = detail.StatutaryPayItem_Code;
                        txtStatTitle.Text = detail.StatutaryPayItem_Title;
                        txtStatPercentage.Text = cls_Formater.FormatDecimal(detail.Percentage,2).ToString();
                        txtFlatRate.Text = cls_Formater.FormatDecimal(detail.FlatRate,2).ToString();

                        chkIsFlatRate.IsChecked = detail.IsFlatRate;
                        if (detail.IsFlatRate)
                            txtFlatRate.Visibility = Visibility.Visible;
                        else
                            txtFlatRate.Visibility = Visibility.Collapsed;
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
        private void txtStatCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PaySlipItemsStatutary);
            if (RowDataSearch.DialogResult == true)
            {
                txtStatCode.Tag = lstResult[0];
                txtStatCode.Text = lstResult[1];
                fillDetails(lstResult[0]);
            }
        }

        #endregion

        #region Check events
        private void chkIsFlatRate_checkBox_Checked(object sender, EventArgs e)
        {
            txtFlatRate.Visibility = Visibility.Visible;
        }

        private void chkIsFlatRate_checkBox_Unchecked(object sender, EventArgs e)
        {
            txtFlatRate.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
