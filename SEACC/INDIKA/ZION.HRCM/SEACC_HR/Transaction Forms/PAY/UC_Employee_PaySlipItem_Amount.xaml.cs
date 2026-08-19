using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Digiteq.Transaction_Forms.PAY
{
    /// <summary>
    /// Interaction logic for UC_Employee_PaySlipItems.xaml
    /// </summary>
    public partial class UC_Employee_PaySlipItems : UserControl
    {
        #region Form Load
        public UC_Employee_PaySlipItems()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Employee_PayslipItem_Amounts;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Datatable
            dgr_Main.dt.Columns.Add("EmpId");
            dgr_Main.dt.Columns.Add("EPFno");
            dgr_Main.dt.Columns.Add("EmpName");
            dgr_Main.dt.Columns.Add("EmpAliasName");
            dgr_Main.dt.Columns.Add("PaySlipAmount");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Emp. Id", "EmpId", 70);
            dgr_Main.Add_DatagridColoumn("EPF No.", "EPFno", 70);
            dgr_Main.Add_DatagridColoumn("Employee Name", "EmpName", 200);
            dgr_Main.Add_DatagridColoumn("Alias Name", "EmpAliasName", 100);
            dgr_Main.Add_DatagridColoumn(SEACC_WPFControls.ColoumnType.Numaric, "Amount", "PaySlipAmount", 70, true, false);
            #endregion

            ClearFields();
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

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (txtPaySlipItem.Tag != null)
            {
                try
                {

                    tbl_payMas_PaySlipItems oPayItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtPaySlipItem.Tag.ToString());
                    if (oPayItem != null)
                    {
                        this.Cursor = Cursors.Wait;
                        foreach (DataRow row in dgr_Main.dt.Rows)
                        {
                            string sEmployee_ID = row["EmpId"].ToString();
                            decimal dAmount = clsValidation.Validate_DecimalNumber(row["PaySlipAmount"].ToString());

                            if (!oPayItem.IsEarning)
                                dAmount = -dAmount;

                            tbl_genMasEmployee_PaySlipItems oPayslipItem = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, txtPaySlipItem.Tag.ToString());
                            if (oPayslipItem != null)
                            {
                                tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, oPayslipItem.PayItem_ID, (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.Save, oPayslipItem.Rate, dAmount, clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                                oAud_EmpPayItems.Insert();

                                oPayslipItem.Rate = dAmount;
                                oPayslipItem.Update();
                            }
                            else
                            {
                                tbl_genMasEmployee_PaySlipItems detail = new tbl_genMasEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, txtPaySlipItem.Tag.ToString(), 0, dAmount);
                                detail.Insert();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    btnLoad.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    this.Cursor = Cursors.Arrow;
                }
            }
            else
                SEACCMessageBox.Show("Payslip Item is not slected!!!", "Please select a payslip item before loading the data", MessageBoxButton.OK, "Red");
        }

        private void SEACC_Load_Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtPaySlipItem.Tag != null)
            {
                try
                {
                    tbl_payMas_PaySlipItems oPayItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtPaySlipItem.Tag.ToString());
                    if (oPayItem != null)
                    {
                        decimal dAmount = 0;
                        dgr_Main.dt.Clear();
                        List<tbl_genMasEmployee> oEmployees = new List<tbl_genMasEmployee>();

                        #region Filters
                        if (txtEmpNo.Tag != null)
                            oEmployees.Add(tbl_genMasEmployee.Select(txtEmpNo.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                        else
                        {
                            oEmployees = tbl_genMasEmployee.SelectAll().Where(r => r.Employee_ID != "default" && r.Emp_statusID.Trim() != ((int)EmployeeStatus.Resigned).ToString().Trim()).ToList();

                            if (txtDivision.Tag != null)
                                oEmployees = oEmployees.Where(r => r.Division_ID == txtDivision.Tag.ToString()).ToList();
                            if (txtDepartment.Tag != null)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            if (txtsection.Tag != null)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtsection.Tag.ToString()).ToList();
                        }
                        #endregion

                        foreach (tbl_genMasEmployee oEmp in oEmployees.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                        {
                            tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oEmp.Payroll_ProcessGroupID);
                            if (oGrpPermission != null && oGrpPermission.AllowEdit)
                            {
                                tbl_genMasEmployee_PaySlipItems oPayslipItem = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, txtPaySlipItem.Tag.ToString());
                                if (oPayslipItem != null)
                                {
                                    if (!oPayItem.IsEarning)
                                        dAmount = oPayslipItem.Rate * -1;
                                    else
                                        dAmount = oPayslipItem.Rate;

                                    dgr_Main.dt.Rows.Add(oEmp.Employee_ID, oEmp.EpfNo.PadLeft(4, '0'), oEmp.Initails + " " + oEmp.SurName, oEmp.AliasName, cls_Formater.FormatDecimal(dAmount, 2));
                                }
                            }
                        }
                        dgr_Main.RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            }
            else
                SEACCMessageBox.Show("Payslip Item is not slected!!!", "Please select a payslip item before loading the data", MessageBoxButton.OK, "Red");
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            dgr_Main.dt.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtsection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPaySlipItem, true, false, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPayslipAmount, true, true, false);

            txtDivision.Tag = null;
            txtDepartment.Tag = null;
            txtsection.Tag = null;
            txtEmpNo.Tag = null;
            txtPaySlipItem.Tag = null;

            txtDivision.Text = "<All Divisions>";
            txtDepartment.Text = "<All Department>";
            txtsection.Text = "<All Section>";
            txtEmpNo.Text = "<All Employees>";
            txtPaySlipItem.Text = "<Select a Payslip Item>";

            if (!clsConfig.bEnableDivision)
                txtDivision.Visibility = Visibility.Collapsed;
            else
                txtDivision.Visibility = Visibility.Visible;
            if (!clsConfig.bEnableDepartment)
                txtDepartment.Visibility = Visibility.Collapsed;
            else
                txtDepartment.Visibility = Visibility.Visible;
            if (!clsConfig.bEnableSection)
                txtsection.Visibility = Visibility.Collapsed;
            else
                txtsection.Visibility = Visibility.Visible;
        }
        #endregion

        #region Grid Event

        private void dgr_Main_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumnIndex = e.Column.DisplayIndex;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;

            #region Validate Payslip Amount
            if (iColumnIndex == 4)
            {
                t = e.EditingElement as TextBox;
                decimal dAmt = 0m;
                try
                {
                    dAmt = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dAmt, 2);
            }
            #endregion
        }
        private void dgr_Main_CellEditBegining(object sender, DataGridBeginningEditEventArgs e)
        {
            if (txtPaySlipItem.Tag != null)
            {
                string payItemID = txtPaySlipItem.Tag.ToString();
                tbl_payMas_PaySlipItems oPayItm = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, payItemID);
                if (oPayItm.InputMode == (int)(Digiteq_Logic.InputMode.Auto_NoEdit))
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
        }
        #endregion

        #region Search Events
        private void txtDevision_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Division);
            if (RowDataSearch.DialogResult == true)
            {
                txtDivision.Text = lstResult[1];
                txtDivision.Tag = lstResult[0];
            }
        }

        private void txtDepartment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Departments);
            if (RowDataSearch.DialogResult == true)
            {
                txtDepartment.Text = lstResult[1];
                txtDepartment.Tag = lstResult[0];

                txtDivision.IsEnabled = false;
            }
        }

        private void txtsection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Sections);
            if (RowDataSearch.DialogResult == true)
            {
                txtsection.Text = lstResult[1];
                txtsection.Tag = lstResult[0];

                txtDivision.IsEnabled = false;
                txtDepartment.IsEnabled = false;
            }
        }

        private void txtEmpNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                sp_genMasEmployee oEmployee = sp_genMasEmployee.Select(lstResult[0]);
                if (oEmployee != null)
                {
                    txtEmpNo.Tag = oEmployee.Employee_ID;
                    txtEmpNo.Text = oEmployee.Employee_ID + " - " + oEmployee.FullName;

                    txtDivision.Tag = oEmployee.Division_ID;
                    txtDivision.Text = oEmployee.DivisionName;
                    txtDivision.IsEnabled = false;

                    txtDepartment.Tag = oEmployee.Department_ID;
                    txtDepartment.Text = oEmployee.DepartmentName;
                    txtDepartment.IsEnabled = false;

                    txtsection.Tag = oEmployee.SectionID;
                    txtsection.Text = oEmployee.Section_Name;
                    txtsection.IsEnabled = false;
                }
            }

        }

        private void txtPaySlipItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayslipItems);
            if (RowDataSearch.DialogResult == true)
            {
                txtPaySlipItem.Tag = lstResult[0];
                txtPaySlipItem.Text = lstResult[2];
            }
        }
        #endregion

        #region User Controls
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default", (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.Open, 0, 0, clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            oAud_EmpPayItems.Insert();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default", (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.Close, 0, 0, clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            oAud_EmpPayItems.Insert();
        }
        #endregion

        #region Pop Up Item
        private void btnGridItemAddAll_Click(object sender, RoutedEventArgs e)
        {
            pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event.IsOpen = true;
            txtPayslipAmount.Text = "";
        }
        private void btn_PoPSave_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            int iRow = 0;
            foreach (DataRow sRow in dgr_Main.dt.Rows)
            {
                dgr_Main.dt.Rows[iRow]["PaySlipAmount"] = cls_Formater.FormatDecimal(decimal.Parse(txtPayslipAmount.Text.Trim()), 2);
                iRow++;
            }
            this.Cursor = Cursors.Arrow;
        }
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event.IsOpen = false;
            txtPayslipAmount.Text = "";
        }
        #endregion

        #region Btn Payslip Add
        private void btnGridPaySlipAddAll_Click(object sender, RoutedEventArgs e)
        {
            if (txtPaySlipItem.Tag != null)
            {
                try
                {
                    if (dgr_Main.dt.Rows.Count > 0)
                    {
                        tbl_payMas_PaySlipItems oPayItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtPaySlipItem.Tag.ToString());
                        if (oPayItem != null)
                        {
                            decimal dAmount = 0;
                            List<tbl_genMasEmployee> oEmployees = new List<tbl_genMasEmployee>();

                            #region Filters
                            if (txtEmpNo.Tag != null)
                                oEmployees.Add(tbl_genMasEmployee.Select(txtEmpNo.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                            else
                            {
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(r => r.Employee_ID != "default" && r.Emp_statusID.Trim() != ((int)EmployeeStatus.Resigned).ToString().Trim()).ToList();

                                if (txtDivision.Tag != null)
                                    oEmployees = oEmployees.Where(r => r.Division_ID == txtDivision.Tag.ToString()).ToList();
                                if (txtDepartment.Tag != null)
                                    oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                if (txtsection.Tag != null)
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtsection.Tag.ToString()).ToList();
                            }
                            #endregion

                            foreach (tbl_genMasEmployee oEmp in oEmployees.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                            {
                                DataRow[] drItems = dgr_Main.dt.Select("EmpId ='" + oEmp.Employee_ID + "'");
                                if (drItems.Length == 0)
                                {
                                    tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oEmp.Payroll_ProcessGroupID);
                                    if (oGrpPermission != null && oGrpPermission.AllowEdit)
                                    {
                                        tbl_genMasEmployee_PaySlipItems oPayslipItem = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, txtPaySlipItem.Tag.ToString());
                                        if (oPayslipItem == null)
                                        {
                                            dgr_Main.dt.Rows.Add(oEmp.Employee_ID, oEmp.EpfNo.PadLeft(4, '0'), oEmp.Initails + " " + oEmp.SurName, oEmp.AliasName, cls_Formater.FormatDecimal(dAmount, 2));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        tbl_payMas_PaySlipItems oPayItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtPaySlipItem.Tag.ToString());
                        if (oPayItem != null)
                        {
                            decimal dAmount = 0;
                            dgr_Main.dt.Clear();
                            List<tbl_genMasEmployee> oEmployees = new List<tbl_genMasEmployee>();

                            #region Filters
                            if (txtEmpNo.Tag != null)
                                oEmployees.Add(tbl_genMasEmployee.Select(txtEmpNo.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                            else
                            {
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(r => r.Employee_ID != "default" && r.Emp_statusID.Trim() != ((int)EmployeeStatus.Resigned).ToString().Trim()).ToList();

                                if (txtDivision.Tag != null)
                                    oEmployees = oEmployees.Where(r => r.Division_ID == txtDivision.Tag.ToString()).ToList();
                                if (txtDepartment.Tag != null)
                                    oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                if (txtsection.Tag != null)
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtsection.Tag.ToString()).ToList();
                            }
                            #endregion

                            foreach (tbl_genMasEmployee oEmp in oEmployees.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                            {
                                tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oEmp.Payroll_ProcessGroupID);
                                if (oGrpPermission != null && oGrpPermission.AllowSave)
                                {
                                    tbl_genMasEmployee_PaySlipItems oPayslipItem = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, txtPaySlipItem.Tag.ToString());
                                    if (oPayslipItem == null)
                                    {
                                        dgr_Main.dt.Rows.Add(oEmp.Employee_ID, oEmp.EpfNo.PadLeft(4, '0'), oEmp.Initails + " " + oEmp.SurName, oEmp.AliasName, cls_Formater.FormatDecimal(dAmount, 2));
                                    }
                                }
                            }
                        }
                    }
                    dgr_Main.RefreshGrid();
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }

            }
            else
                SEACCMessageBox.Show("Payslip Item is not slected!!!", "Please select a payslip item before loading the data", MessageBoxButton.OK, "Red");

        } 
        #endregion

    }
}
