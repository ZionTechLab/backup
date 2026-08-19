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
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;
namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_PayrollLevel.xaml
    /// </summary>
    public partial class UC_PayrollLevel : UserControl
    {
        #region Form Laod
        public UC_PayrollLevel()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Leave_Apply;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("PayrollLevelID");
            dgr_Main.dt.Columns.Add("PayrollLevel");
            dgr_Main.dt.Columns.Add("PayrollDate");
            #endregion

            #region Initialize Action Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Code", "PayrollLevelID", 70);
            dgr_Main.Add_DatagridColoumn("Lavel", "PayrollLevel", 150);
            dgr_Main.Add_DatagridColoumn("Payroll Date", "PayrollDate", 150); 
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

        #region Action Button
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
                    if (txtPayrollLevelID.Tag != null)
                    {
                        bool MessageBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (true)
                        {
                            tbl_PayMasPayrollLaval oBankMaster = tbl_PayMasPayrollLaval.Select(txtPayrollLevelID.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (oBankMaster != null)
                            {
                                oBankMaster.IsCanceled = true;
                                oBankMaster.Date_Canceled = clsSecurity.getServerDateTime();
                                oBankMaster.UserID_Canceled = clsSecurity.UserIDLoged;
                                oBankMaster.TerminalID_Canceled = clsSecurity.TerminalID;
                                oBankMaster.Update();

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
                SEACCExeption.Show(ex);
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

                            tbl_PayMasPayrollLaval oldRecord = tbl_PayMasPayrollLaval.Select(txtPayrollLevelID.Text.Trim(),clsSecurity.CompanyID,clsSecurity.BranchID);
                            if (oldRecord != null)
                            {
                                tbl_PayMasPayrollLaval oBankBranch = new tbl_PayMasPayrollLaval(clsSecurity.CompanyID, clsSecurity.BranchID,txtPayrollLevelID.Text, txtPayrollLevelName.Text, dtp_PayrollDate.GetDateTime(), false, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                oBankBranch.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }

                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtPayrollLevelID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_PayMasPayrollLaval oBankBranch = new tbl_PayMasPayrollLaval(clsSecurity.CompanyID, clsSecurity.BranchID,txtPayrollLevelID.Text, txtPayrollLevelName.Text, dtp_PayrollDate.GetDateTime(), false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        oBankBranch.Insert();
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
                    RefreshGrid();
                    ClearFields();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayrollLevelID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPayrollLevelName, true, false, false);
           // clsCommon.SetEnableDisable_LabelDateSelector(dtp_PayrollDate, true);

            txtPayrollLevelID.Text = "";
            txtPayrollLevelName.Text = "";
            dtp_PayrollDate.SetTime(DateTime.Now);
            txtPayrollLevelID.Tag = null;

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtPayrollLevelID.Text = "<Auto Generate>";
                txtPayrollLevelID.setReadOnlyStatus(true);
            }
            else
                txtPayrollLevelID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_PayMasPayrollLaval oBankBranch in tbl_PayMasPayrollLaval.SelectAll().Where(p => p.PayrollLevelID != "Default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oBankBranch.PayrollLevelID, oBankBranch.PayrollLavel, oBankBranch.PayrollDate.ToString("dd/MM"));
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
                    if (CheckValidity_DuplicateName())
                        bStatus = true;
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtPayrollLevelID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPayrollLevelName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_PayMasPayrollLaval oDetail = tbl_PayMasPayrollLaval.Select(txtPayrollLevelID.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool CheckValidity_DuplicateName()
        {
            bool bStatus = true;
            foreach (tbl_PayMasPayrollLaval item in tbl_PayMasPayrollLaval.SelectAll().Where(x=> x.PayrollLavel==txtPayrollLevelName.Text && x.IsCanceled==false && x.PayrollLevelID != txtPayrollLevelID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist,"Payroll Leavel");
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
                if (sID != null)
                {
                    tbl_PayMasPayrollLaval details = tbl_PayMasPayrollLaval.Select(sID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtPayrollLevelID.Text = details.PayrollLevelID;
                        txtPayrollLevelID.Tag = details.PayrollLevelID;
                        txtPayrollLevelName.Text = details.PayrollLavel;
                        dtp_PayrollDate.SetTime(details.PayrollDate);
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
        private void grd_PayrollLevel_MouseLeftButtonUp1(object sender, EventArgs e)
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
        private void txtPayrollLevelID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayrollLevel);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtPayrollLevelID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        } 
        #endregion
    }
}
