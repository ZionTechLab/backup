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

namespace Digiteq
{
    public partial class UC_PayslipItems_Class : UserControl
    {
        #region Form Load
        public UC_PayslipItems_Class()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payslip_Items_Class;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ClassID");
            dgr_Main.dt.Columns.Add("ClassCode");
            dgr_Main.dt.Columns.Add("ClassTitle");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("#", "ClassID", 70 , false);
            dgr_Main.Add_DatagridColoumn("Code", "ClassCode", 75);
            dgr_Main.Add_DatagridColoumn("Title", "ClassTitle", 200);
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
                    if (txtClassID.Tag != null && txtClassID.Tag != "")
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_payMas_PaySlipItems_Class detail = tbl_payMas_PaySlipItems_Class.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtClassID.Tag.ToString());
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
                            tbl_payMas_PaySlipItems_Class oldRecord = tbl_payMas_PaySlipItems_Class.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtClassID.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_payMas_PaySlipItems_Class detail = new tbl_payMas_PaySlipItems_Class(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, oldRecord.PayItem_Class_ID, txtClassCode.Text, txtClassTitle.Text, oldRecord.IsCanceled);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion
                    #region Insert Data
                    else
                    {
                        tbl_payMas_PaySlipItems_Class detail = new tbl_payMas_PaySlipItems_Class(clsSecurity.CompanyID, clsSecurity.BranchID, txtClassID.Tag.ToString(), txtClassCode.Text, txtClassTitle.Text, false);
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtClassID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtClassCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtClassTitle, true, false, false);

            txtClassID.Tag = null;

            txtClassID.Text = "";
            txtClassCode.Text = "";
            txtClassTitle.Text = "";

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtClassID.setReadOnlyStatus(true);
                txtClassID.Text = "<Auto Generate>";
            }
            else
                txtClassID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_payMas_PaySlipItems_Class detail in tbl_payMas_PaySlipItems_Class.SelectAll().Where(p => p.IsCanceled == false && p.PayItem_Class_ID != "Default"))
                {
                    dgr_Main.dt.Rows.Add(detail.PayItem_Class_ID, detail.PayItem_Class_Code, detail.PayItem_Class_Title);
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

            if (!clsValidation.Validate_EmptyValue(txtClassID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtClassCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtClassTitle))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtClassID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtClassID.Text = txtClassID.Tag.ToString();
                }

                tbl_payMas_PaySlipItems_Class detail = tbl_payMas_PaySlipItems_Class.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtClassID.Tag.ToString());
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
            foreach (tbl_payMas_PaySlipItems_Class detail1 in tbl_payMas_PaySlipItems_Class.SelectAll().Where(p => p.PayItem_Class_Code == txtClassCode.Text && !p.IsCanceled && p.PayItem_Class_ID != txtClassID.Tag.ToString()))
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
                    tbl_payMas_PaySlipItems_Class detail = tbl_payMas_PaySlipItems_Class.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtClassID.Tag = detail.PayItem_Class_ID;

                        txtClassID.Text = detail.PayItem_Class_ID;
                        txtClassCode.Text = detail.PayItem_Class_Code;
                        txtClassTitle.Text = detail.PayItem_Class_Title;
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
        private void dgr_Main_MouseLeftButtonUp1_1(object sender, EventArgs e)
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
        private void txtClassID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PaySlipItemsClass);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0]);
            }
        }

        private void txtClassCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PaySlipItemsClass);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0]);
            }
        }
        #endregion
    }
}