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
using System.Windows.Shapes;

namespace Digiteq.Master_Forms
{
    public partial class frm_Employee_PaySlipItems : Window
    {
        #region Class Variables
        string sEmployeeID = "";
        DataTable dt_EmpStatutaryItems = new DataTable();
        bool bInitState = false;
        DateTime dtmPeriStart = clsValidation.defaultDateTime;
        DateTime dtmPeriEnd = clsValidation.defaultDateTime;

        public tbl_payMas_ProcessGroup oPayrollGroup;
        bool isDeffinetionUI = false;
        #endregion

        #region Form Load
        public frm_Employee_PaySlipItems(string sEmpID, bool initState, bool bAllowSave, DateTime dtmPeriodStartDate, DateTime dtmPeriodEndDate,bool _isDeffinetionUI)
        {
            InitializeComponent();
            AppDomainInitializer(sEmpID, initState, bAllowSave);
            dtmPeriStart = dtmPeriodStartDate;
            dtmPeriEnd = dtmPeriodEndDate;
            isDeffinetionUI = _isDeffinetionUI;
        }

        private void AppDomainInitializer(string sEmpID, bool initState, bool bAllowSave)
        {
            #region Initialize Usercontrol
            SEACC_Form.enmFormName = FormName.Employee_PaySlipItems;
            SEACC_Form.Initialize();

            sEmployeeID = sEmpID;
            lblEmpName.Content = sEmployeeID + " - " + clsRef_Name.get_EmployeeName(sEmployeeID);
            bInitState = initState;
            #endregion

            #region Initialize Payslip Items Data Table
            dgr_PayItems.dt.Columns.Add("ItemID");
            dgr_PayItems.dt.Columns.Add("ItemCode");
            dgr_PayItems.dt.Columns.Add("Title");
            dgr_PayItems.dt.Columns.Add("Class");
            dgr_PayItems.dt.Columns.Add("Type");
            dgr_PayItems.dt.Columns.Add("Rate");
            dgr_PayItems.dt.Columns.Add("isEarning", typeof(bool));
            dgr_PayItems.dt.Columns.Add("LineNo", typeof(int));
            #endregion

            #region Initialize Payslip Items Statutary Data Table
            dt_EmpStatutaryItems.Columns.Add("apply", typeof(bool));
            dt_EmpStatutaryItems.Columns.Add("payItem_ID");
            dt_EmpStatutaryItems.Columns.Add("payItem_Code");
            dt_EmpStatutaryItems.Columns.Add("payItem_Title");
            dt_EmpStatutaryItems.Columns.Add("statutaryPayItem_ID");
            dt_EmpStatutaryItems.Columns.Add("statutaryPayItem_Code");
            dt_EmpStatutaryItems.Columns.Add("statutaryPayItem_Title");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(bAllowSave, false, bAllowSave, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            btnGridItemAdd.IsEnabled = bAllowSave;
            btnGridItemAddAll.IsEnabled = bAllowSave;
            btnGridItemDelete.IsEnabled = bAllowSave;
            #endregion

            #region Initialize Payslip Items DataGrid
            dgr_PayItems.Add_DatagridColoumn("Item Id", "ItemID", 70, false);
            dgr_PayItems.Add_DatagridColoumn("Code", "ItemCode", 70);
            dgr_PayItems.Add_DatagridColoumn("Title", "Title", 150);
            dgr_PayItems.Add_DatagridColoumn("Class", "Class", 75);
            dgr_PayItems.Add_DatagridColoumn("Type", "Type", 75);
            dgr_PayItems.Add_DatagridColoumn(ColoumnType.Numaric, "Rate", "Rate", 75, true, false);
            dgr_PayItems.Add_DatagridColoumn(ColoumnType.CheckBox, "Earn/Ded", "isEarning", 50, false, false);
            dgr_PayItems.Add_DatagridColoumn(ColoumnType.Numaric, "Line No", "LineNo", 75, false, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Clear Fiels
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dgr_PayItems.grdMain.UnselectAll();
            dgrStatutary.ItemsSource = null;

            oPayrollGroup = null;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dt_EmpStatutaryItems.Clear();
                dgr_PayItems.dt.Clear();
                if (dtmPeriStart == clsValidation.defaultDateTime && dtmPeriEnd == clsValidation.defaultDateTime)
                {
                    decimal dAmount = 0;
                    dt_EmpStatutaryItems.Merge(DBHandling.ExecQuery("select * from vw_payslipItemsStatutaries").Tables[0]);
                    foreach (tbl_genMasEmployee_PaySlipItems detail in tbl_genMasEmployee_PaySlipItems.SelectAll_Items(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID,isDeffinetionUI).OrderBy(o => o.LineNo))
                    {
                        tbl_payMas_PaySlipItems oPayslipItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, detail.PayItem_ID);

                        if (!oPayslipItem.IsEarning)
                            dAmount = detail.Rate * -1;
                        else
                            dAmount = detail.Rate;

                        dgr_PayItems.dt.Rows.Add(oPayslipItem.PayItem_ID, oPayslipItem.PayItem_Code, oPayslipItem.PayItem_Title, clsRef_Name.get_PaySlipItem_Class_Code(oPayslipItem.PayItem_Class_ID), clsRef_Name.get_PaySlipItem_Type_Code(oPayslipItem.PayItem_Type_ID), cls_Formater.FormatDecimal(dAmount, 2), oPayslipItem.IsEarning, detail.LineNo);

                        foreach (tbl_genMasEmployee_PaySlipItems_Statutary stst in tbl_genMasEmployee_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID_PayItem_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, oPayslipItem.PayItem_ID))
                        {
                            DataRow[] rows = dt_EmpStatutaryItems.Select("payItem_ID ='" + stst.PayItem_ID + "'  AND statutaryPayItem_ID = '" + stst.StatutaryPayItem_ID + "'");
                            if (rows.Length > 0)
                            {
                                rows[0]["apply"] = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (tbl_payTxSIPRawData oDetail in tbl_payTxSIPRawData.SelectAll().Where(r => r.ProcessPeriod_Sub_startDate.Date == dtmPeriStart.Date && r.ProcessPeriod_Sub_endDate.Date == dtmPeriEnd.Date && r.Employee_ID == sEmployeeID))
                    {
                        List<tbl_payTxSIPRawData_PaySlipItems> oPayItems = tbl_payTxSIPRawData_PaySlipItems.SelectAll().Where(r => r.Company_ID == oDetail.Company_ID && r.CompanyBranch_ID == oDetail.CompanyBranch_ID && r.SIP_ID == oDetail.SIP_ID).ToList();
                        oPayItems.ForEach((oPayItem) => dgr_PayItems.dt.Rows.Add(oPayItem.PayItem_ID, oPayItem.PayItem_Code, clsRef_Name.get_PaySlipItem_Title(oPayItem.PayItem_ID), clsRef_Name.get_PaySlipItem_Class_Code(oPayItem.PayItem_Class_ID), clsRef_Name.get_PaySlipItem_Type_Code(oPayItem.PayItem_Type_ID), !oPayItem.IsEarning ? cls_Formater.FormatDecimal(oPayItem.Amount * -1, 2) : cls_Formater.FormatDecimal(oPayItem.Amount, 2), oPayItem.IsEarning, oPayItem.LineNo));

                        List<tbl_payTxSIPRawData_PaySlipItems_Statutary> oPayStats = tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAll().Where(r1 => oPayItems.Any(r2 => r2.Company_ID == r1.Company_ID && r2.CompanyBranch_ID == r1.CompanyBranch_ID && r2.SIP_ID == r1.SIP_ID && r2.PayItem_ID == r1.PayItem_ID)).ToList();
                        oPayStats.ForEach((oPayStat) => dt_EmpStatutaryItems.Rows.Add(true, oPayStat.PayItem_ID, "", "", oPayStat.StatutaryPayItem_ID, "", clsRef_Name.get_PaySlipItems_Statutary_Title(oPayStat.StatutaryPayItem_ID)));
                    }
                }
                dgr_PayItems.RefreshGrid();
                dgr_PayItems.grdMain.UnselectAll();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

        }
        #endregion

        #region Fill Statutary Items
        private void fill_StatutaryItems(string sPaySlipItem_ID)
        {
            try
            {
                dt_EmpStatutaryItems.DefaultView.RowFilter = string.Empty;
                string sFilter = "payItem_ID ='" + sPaySlipItem_ID + "'";
                dt_EmpStatutaryItems.DefaultView.RowFilter = sFilter;
                dgrStatutary.ItemsSource = dt_EmpStatutaryItems.DefaultView;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Action Buttons
        private void grdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Insert Data
                foreach (tbl_genMasEmployee_PaySlipItems_Statutary sobj in tbl_genMasEmployee_PaySlipItems_Statutary.SelectAll().Where(p => p.Employee_ID == sEmployeeID))
                    sobj.Delete();

                foreach (tbl_genMasEmployee_PaySlipItems pobj in tbl_genMasEmployee_PaySlipItems.SelectAll().Where(p => p.Employee_ID == sEmployeeID))
                    pobj.Delete();

                foreach (DataRow row in dgr_PayItems.dt.Rows)
                {
                    string sItemID = row["ItemID"].ToString();
                    int iLineNo = int.Parse(row["LineNo"].ToString());
                    decimal dAmount = decimal.Parse(row["Rate"].ToString());
                    bool bIsEarning = bool.Parse(row["isEarning"].ToString());

                    if (!bIsEarning)
                        dAmount = -dAmount;

                    tbl_genMasEmployee_PaySlipItems detail = new tbl_genMasEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, sItemID, iLineNo, dAmount);
                    detail.Insert();
                }


                foreach (DataRow sRow in dt_EmpStatutaryItems.Rows)
                {
                    bool apply = bool.Parse(sRow["apply"].ToString());
                    if (apply)
                    {
                        string sPayItemID = sRow["payItem_ID"].ToString();
                        string sSatItemID = sRow["statutaryPayItem_ID"].ToString();
                        tbl_payMas_StatutaryItems oDetail = tbl_payMas_StatutaryItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sSatItemID);

                        tbl_genMasEmployee_PaySlipItems_Statutary sDetails = new tbl_genMasEmployee_PaySlipItems_Statutary(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, sPayItemID, sSatItemID, oDetail.IsFlatRate, oDetail.Percentage, oDetail.FlatRate);
                        sDetails.Insert();
                    }
                }
                tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, "default", (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.Save, 0, 0, clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                oAud_EmpPayItems.Insert();

                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            List<string> oList = new List<string>();
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayslipItems);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_payMas_PaySlipItems oPayslipItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, lstResult[0]);
                if (oPayslipItem != null)
                    PayItemsAddtoGrid(oPayslipItem, oList);
            }

            if (oList.Count > 0)
            {
                string sMessageBody_ShiftErrorEmployees = "";
                foreach (string sEmp in oList)
                    sMessageBody_ShiftErrorEmployees += sEmp + " \n";

                SEACCMessageBox.Show("Pay Slip Items Already Exist!!!", sMessageBody_ShiftErrorEmployees, MessageBoxButton.OK);
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_PayItems.grdMain.SelectedItem;
            if (selectedItem != null)
            {
                string GridID = (dgr_PayItems.grdMain.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                string sAmount = (dgr_PayItems.grdMain.SelectedCells[5].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dgr_PayItems.dt.Select("ItemID ='" + GridID + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dgr_PayItems.dt.Rows.Remove(item);

                    DataRow[] i = dt_EmpStatutaryItems.Select("payItem_ID ='" + GridID + "'");
                    foreach (DataRow ii in i)
                        dt_EmpStatutaryItems.Rows.Remove(ii);

                    tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, GridID, (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.RemoveItem, decimal.Parse(sAmount), decimal.Parse(sAmount), clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                    oAud_EmpPayItems.Insert();
                }
                dgr_PayItems.RefreshGrid();
                ClearFields();
            }

        }
        #endregion

        #region Grid Events
        private void dgr_PayItems_CellEditBegining(object sender, DataGridBeginningEditEventArgs e)
        {
            if (!bInitState)
            {
                int irowID = dgr_PayItems.SelectedIndex;
                string payItemID = (dgr_PayItems.dt.Rows[irowID][0].ToString());

                tbl_payMas_PaySlipItems oPayItm = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, payItemID);
                if (oPayItm.InputMode == (int)(Digiteq_Logic.InputMode.Auto_NoEdit))
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
        }

        private void dgr_PayItems_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumnIndex = e.Column.DisplayIndex;
            int irowID = dgr_PayItems.SelectedIndex;

            #region Validate Rate
            if (iColumnIndex == 5)
            {
                TextBox t = e.EditingElement as TextBox;
                string sPayItemID = dgr_PayItems.dt.Rows[irowID][0].ToString();
                decimal rate = clsValidation.Validate_DecimalNumber(dgr_PayItems.dt.Rows[irowID][iColumnIndex].ToString());
                decimal dPreviousRate = rate;
                try
                {
                    rate = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(rate, 2);

                tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, sPayItemID, (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.ChangeAmount, dPreviousRate, rate, clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                oAud_EmpPayItems.Insert();

                if (oPayrollGroup != null)
                {
                    tbl_payMas_PaySlipItems oItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sPayItemID);
                    if (oItem != null && oItem.IsNoPayable)
                    {
                        decimal dNopayabllTotal = 0;
                        int iRawIdNoPay = 0;
                        foreach (DataRow row in dgr_PayItems.dt.Rows)
                        {
                            string sItemID = row["ItemID"].ToString();
                            if (sItemID == clsConfig.sNopay)
                                iRawIdNoPay = dgr_PayItems.dt.Rows.IndexOf(row);

                            tbl_payMas_PaySlipItems oItems = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sItemID);
                            if (oItems != null && oItems.IsNoPayable)
                            {
                                if (oItems.PayItem_ID == oItem.PayItem_ID)
                                    dNopayabllTotal += rate;
                                else
                                {
                                    decimal dAmount = decimal.Parse(row["Rate"].ToString());
                                    dNopayabllTotal += dAmount;
                                }
                            }
                        }
                        decimal diDivRate_Att_PerPeriod = oPayrollGroup.DivRate_Nopay / 60;
                        decimal[] dAttenData = clsHelpMethods.GetAttendanceDetails(sEmployeeID, dtmPeriStart, dtmPeriEnd);

                        decimal dNopay = (dNopayabllTotal / diDivRate_Att_PerPeriod) * (dAttenData[3] / 60);
                        dgr_PayItems.dt.Rows[iRawIdNoPay][5] = dNopay;
                    }
                }
            }
            #endregion
        }

        private void dgr_PayItems_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_PayItems.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_PayItems.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fill_StatutaryItems(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgrStatutary_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)dgrStatutary.SelectedItems[0];
                string sPayItemID = row[1].ToString();
                string sStatItemId = row[4].ToString();
                DataRow[] rows = dt_EmpStatutaryItems.Select("payItem_ID ='" + sPayItemID + "'  AND statutaryPayItem_ID = '" + sStatItemId + "'");
                if (rows.Length > 0)
                {
                    rows[0]["apply"] = rows[0]["apply"].ToString() == "True" ? false : true;
                }
            }
            catch { }
        }
        #endregion

        #region Window Event
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, "default", (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.Open, 0, 0, clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            oAud_EmpPayItems.Insert();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, "default", (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.Close, 0, 0, clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            oAud_EmpPayItems.Insert();
        }
        #endregion

        #region Help Method
        private void PayItemsAddtoGrid(tbl_payMas_PaySlipItems oPayslipItem, List<string> oList)
        {

            DataRow[] items = dgr_PayItems.dt.Select("ItemID ='" + oPayslipItem.PayItem_ID + "'");
            if (items.Length == 0)
            {
                dgr_PayItems.dt.Rows.Add(oPayslipItem.PayItem_ID, oPayslipItem.PayItem_Code, oPayslipItem.PayItem_Title, clsRef_Name.get_PaySlipItem_Class_Code(oPayslipItem.PayItem_Class_ID), clsRef_Name.get_PaySlipItem_Type_Code(oPayslipItem.PayItem_Type_ID), 0.00m, oPayslipItem.IsEarning, 0.00m);
                dgr_PayItems.RefreshGrid();
                ClearFields();

                tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, oPayslipItem.PayItem_ID, (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.AddNewItem, 0, 0, clsSecurity.getServerDateTime(), false, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                oAud_EmpPayItems.Insert();
            }
            else
                oList.Add(items[0][1].ToString() + " - " + items[0][2].ToString());
        } 
        #endregion

        #region Btn All Item Add
        private void btnGridItemAddAll_Click(object sender, RoutedEventArgs e)
        {
            List<string> oList = new List<string>();
            this.Cursor = Cursors.Wait;
            foreach (tbl_payMas_PaySlipItems oPayItems in tbl_payMas_PaySlipItems.SelectAll_DefinetionItems())
                PayItemsAddtoGrid(oPayItems, oList);

            if (oList.Count > 0)
            {
                string sMessageBody_ShiftErrorEmployees = "";
                foreach (string sEmp in oList)
                    sMessageBody_ShiftErrorEmployees += sEmp + " \n";

                SEACCMessageBox.Show("Pay Slip Items Already Exist!!!", sMessageBody_ShiftErrorEmployees, MessageBoxButton.OK);

            }
            this.Cursor = Cursors.Arrow;
        }
        #endregion
    }
}