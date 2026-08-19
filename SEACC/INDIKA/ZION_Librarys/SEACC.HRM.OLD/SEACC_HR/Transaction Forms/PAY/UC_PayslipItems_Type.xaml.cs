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
    public partial class UC_PayslipItems_Type : UserControl
    {
        #region Form Load
        public UC_PayslipItems_Type()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payslip_Items_Type;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("PayslipItemsClassID");
            dgr_Main.dt.Columns.Add("PayslipItemsClassCode");
            dgr_Main.dt.Columns.Add("PayslipItemsTypeID");
            dgr_Main.dt.Columns.Add("PayslipItemsTypeCode");
            dgr_Main.dt.Columns.Add("PayslipItemsTypeTitle");
            #endregion

            #region  Button Initialize
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Type ID", "PayslipItemsTypeID", 70, false);
            dgr_Main.Add_DatagridColoumn("Type Code", "PayslipItemsTypeCode", 75);
            dgr_Main.Add_DatagridColoumn("Class ID", "PayslipItemsClassID", 70, false);
            dgr_Main.Add_DatagridColoumn("Class Code", "PayslipItemsClassCode", 70);
            dgr_Main.Add_DatagridColoumn("Title", "PayslipItemsTypeTitle", 200);
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
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtTypeCode.Tag != null && txtClass.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_payMas_PaySlipItems_Type detail = tbl_payMas_PaySlipItems_Type.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtClass.Tag.ToString(), txtTypeCode.Tag.ToString());
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

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
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
                            tbl_payMas_PaySlipItems_Type oldRecord = tbl_payMas_PaySlipItems_Type.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtClass.Tag.ToString(), txtTypeCode.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_payMas_PaySlipItems_Type detail = new tbl_payMas_PaySlipItems_Type(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, txtClass.Tag.ToString(), txtTypeCode.Tag.ToString(), txtTypeCode.Text, txtTypeTitle.Text, oldRecord.IsCanceled);                            
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        tbl_payMas_PaySlipItems_Type detail = new tbl_payMas_PaySlipItems_Type(clsSecurity.CompanyID, clsSecurity.BranchID, txtClass.Tag.ToString(), txtTypeCode.Tag.ToString(), txtTypeCode.Text, txtTypeTitle.Text, false);
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

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtClass, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTypeCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTypeTitle, true, false, false);

            txtClass.Tag = null;
            txtTypeCode.Tag = null;

            txtClass.Text = "";
            txtTypeCode.Text = "";
            txtTypeTitle.Text = "";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_payMas_PaySlipItems_Type detail in tbl_payMas_PaySlipItems_Type.SelectAll().Where(p => p.IsCanceled == false && p.PayItem_Type_ID != "Default"))
                {
                    dgr_Main.dt.Rows.Add(detail.PayItem_Class_ID, clsRef_Name.get_PaySlipItem_Class_Code(detail.PayItem_Class_ID), detail.PayItem_Type_ID, detail.PayItem_Type_Code, detail.PayItem_Type_Title);
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
                if (!clsValidation.Validate_EmptyValue(txtClass))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtTypeCode))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtTypeTitle))
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
                    txtTypeCode.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_payMas_PaySlipItems_Type detail = tbl_payMas_PaySlipItems_Type.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtClass.Tag.ToString(), txtTypeCode.Tag.ToString());
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
            foreach (tbl_payMas_PaySlipItems_Type detail1 in tbl_payMas_PaySlipItems_Type.SelectAll().Where(p => p.PayItem_Type_Code == txtTypeCode.Text && p.IsCanceled == false && p.PayItem_Type_ID != txtTypeCode.Tag.ToString()))
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
        private void fillDetails(string classID, string typeID)
        {
            try
            {
                if (typeID != null)
                {
                    tbl_payMas_PaySlipItems_Type detail = tbl_payMas_PaySlipItems_Type.Select(clsSecurity.CompanyID, clsSecurity.BranchID, classID, typeID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtClass.Tag = detail.PayItem_Class_ID;
                        txtTypeCode.Tag = detail.PayItem_Type_ID;

                        txtClass.Text = clsRef_Name.get_PaySlipItem_Class_Code(detail.PayItem_Class_ID);
                        txtTypeCode.Text = detail.PayItem_Type_Code;
                        txtTypeTitle.Text = detail.PayItem_Type_Title;
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
                    string typeID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string classID = (dgr_Main.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(classID, typeID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event

        private void txtClass_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PaySlipItemsClass);
            if (RowDataSearch.DialogResult == true)
            {
                txtClass.Tag = lstResult[0];
                txtClass.Text = lstResult[1];
            }
        }

        private void txtTypeCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PaySlipItemsType);
            if (RowDataSearch.DialogResult == true)
            {
                txtClass.Tag = lstResult[0];
                txtTypeCode.Tag = lstResult[2];

                txtClass.Text = lstResult[1];
                txtTypeCode.Text = lstResult[3];

                fillDetails(lstResult[0],lstResult[2]);
            }
        }
        #endregion
    }
}
