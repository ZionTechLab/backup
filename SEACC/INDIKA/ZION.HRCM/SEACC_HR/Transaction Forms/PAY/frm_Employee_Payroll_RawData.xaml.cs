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

namespace Digiteq.Transaction_Forms.PAY
{
    /// <summary>
    /// Interaction logic for frm_Employee_Payroll_RawData.xaml
    /// </summary>
    public partial class frm_Employee_Payroll_RawData : Window
    {
        #region Class Variables
        string sProcessGroupID;
        int iProcessPeriodID, iSubProcessPeriodID;
        DateTime dtmPeriodStartDate, dtmPeriodEndDate;
        tbl_payMas_ProcessPeriod_Sub oSubPeriod;
        tbl_payMas_ProcessGroup oPayrollGroup;
        bool bSave_Enable = false;
        #endregion

        #region Form Load
        public frm_Employee_Payroll_RawData(string sGroupID, int iMainPeriodID, int iSubPeriodID, bool bSaveEnable)
        {
            #region Initialize Usercontrol
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            sProcessGroupID = sGroupID;
            iProcessPeriodID = iMainPeriodID;
            iSubProcessPeriodID = iSubPeriodID;
            bSave_Enable = bSaveEnable;
            lblProcessGroup.Content = clsRef_Name.get_PayrollProcessGroup_Title(sGroupID);
            oPayrollGroup = tbl_payMas_ProcessGroup.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sGroupID);
            oSubPeriod = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sGroupID, iMainPeriodID, iSubProcessPeriodID);
            lblProcessPeriod.Content = clsRef_Name.get_processPeriodMain_Name(oSubPeriod.ProcessPeriod_ID.ToString()) + " - " + oSubPeriod.ProcessPeriod_Sub_Title;

            dtmPeriodStartDate = oSubPeriod.StartDate.Date;
            dtmPeriodEndDate = oSubPeriod.EndDate.Date;
            lblProcessStartDate.Content = oSubPeriod.StartDate.ToString(clsValidation.Format_Date);
            lblProcessEndDate.Content = oSubPeriod.EndDate.ToString(clsValidation.Format_Date);

            SEACC_Form.enmFormName = FormName.Employee_PayrollRowData;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("empID");
            dgr_Main.dt.Columns.Add("empName");
            dgr_Main.dt.Columns.Add("empDivision");
            dgr_Main.dt.Columns.Add("empDepatment");
            dgr_Main.dt.Columns.Add("empSection");
            dgr_Main.dt.Columns.Add("empSubSection");


            dgr_Main.dt.Columns.Add("workDays_Mand");
            dgr_Main.dt.Columns.Add("workDays_Act");

            dgr_Main.dt.Columns.Add("workHrs_Mand");
            dgr_Main.dt.Columns.Add("workHrsMins_Mand");//new
            dgr_Main.dt.Columns.Add("workHrs_Act");
            dgr_Main.dt.Columns.Add("workHrsMins_Act");//new
            dgr_Main.dt.Columns.Add("lateHrs");
            dgr_Main.dt.Columns.Add("lateHrsMins");//new
            dgr_Main.dt.Columns.Add("noPayHrs");
            dgr_Main.dt.Columns.Add("noPayHrsMins");//new
            dgr_Main.dt.Columns.Add("workHrs_OT_Normal");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Normal");//new
            dgr_Main.dt.Columns.Add("workHrs_OT_Double");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Double");//new
            dgr_Main.dt.Columns.Add("workHrs_OT_Triple");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Triple");//new
            dgr_Main.dt.Columns.Add("leaveHrs");
            dgr_Main.dt.Columns.Add("leaveHrsMins");//new
            dgr_Main.dt.Columns.Add("gatePassHrs");
            dgr_Main.dt.Columns.Add("gatePassHrsMins");//new

            dgr_Main.dt.Columns.Add("baseRate_OT_Normal");
            dgr_Main.dt.Columns.Add("baseRate_OT_Double");
            dgr_Main.dt.Columns.Add("baseRate_OT_Triple");
            dgr_Main.dt.Columns.Add("divRate_OT_Normal");
            dgr_Main.dt.Columns.Add("divRate_OT_Double");
            dgr_Main.dt.Columns.Add("divRate_OT_Triple");
            dgr_Main.dt.Columns.Add("empRate_OT_Normal");
            dgr_Main.dt.Columns.Add("empRate_OT_Double");
            dgr_Main.dt.Columns.Add("empRate_OT_Triple");
            dgr_Main.dt.Columns.Add("divRate_Nopay");
            dgr_Main.dt.Columns.Add("divRate_Late");
            dgr_Main.dt.Columns.Add("empRate_Nopay");
            dgr_Main.dt.Columns.Add("empRate_Late");
            #endregion

            #region Acction Button
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Emp. No.", "empID", 80);
            dgr_Main.Add_DatagridColoumn("Emp. Name", "empName", 150);
            dgr_Main.Add_DatagridColoumn("Division", "empDivision", 100, false);
            dgr_Main.Add_DatagridColoumn("Department", "empDepatment", 100, false);
            dgr_Main.Add_DatagridColoumn("Section", "empSection", 180, false);
            dgr_Main.Add_DatagridColoumn("Sub Section", "empSubSection", 100, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Mandatory Days", "workDays_Mand", 100, false, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Actual Days", "workDays_Act", 100, false, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Mand. Hrs.", "workHrs_Mand", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Mand. Hrs:Mins", "workHrsMins_Mand", 100, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Actual Hrs.", "workHrs_Act", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Actual Hrs:Mins", "workHrsMins_Act", 100, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Late Hrs.", "lateHrs", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Late Hrs:Mins", "lateHrsMins", 100, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "No Pay Hrs", "noPayHrs", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "No Pay Hrs:Mins", "noPayHrsMins", 100, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Hrs. Normal", "workHrs_OT_Normal", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Hrs:Mins Normal", "workHrsMins_OT_Normal", 125, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Hrs. Double", "workHrs_OT_Double", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Hrs:Mins Double", "workHrsMins_OT_Double", 125, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Hrs. Triple", "workHrs_OT_Triple", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Hrs:Mins Triple", "workHrsMins_OT_Triple", 125, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Leave Hrs", "leaveHrs", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Leave Hrs:Mins", "leaveHrsMins", 125, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Gatepass Hrs.", "gatePassHrs", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Gatepass Hrs:Mins", "gatePassHrsMins", 125, !clsConfig.bPayrollRawDataShow_HoursOnly, true);
            #endregion

            RefreshGrid();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
            try
            {
                dgr_Main.dt.Clear();
                List<string> lsEmployees_ShiftIssues = new List<string>();

                #region Payroll Processings - New Infomation
                if (!oSubPeriod.IsClosedPeriod)
                {
                    #region Flush old Data to relevant group Before Load
                    //List<tbl_payTxSIPRawData> oRawData = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmPeriodStartDate, dtmPeriodEndDate).Where(p => p.ProcessGroup_ID == sProcessGroupID).ToList();
                    //if (oRawData.Count > 0)
                    //{
                    //    clsHelpMethods.RollBack_Payroll(sProcessGroupID, dtmPeriodStartDate, dtmPeriodEndDate);
                    //}
                    #endregion

                    #region Fill Payroll details
                    decimal diDivRate_OT_PerPeriod = oPayrollGroup.DivRate_OT / 60;
                    decimal diDivRate_Att_PerPeriod = oPayrollGroup.DivRate_Nopay ;
                    decimal diLateGracePeriodMins_PerDay = oPayrollGroup.GraceMins_Late;
                    decimal dMaxLateMins_PerDay = oPayrollGroup.MaxMins_Late;
                    decimal dMaxLateDays_PerPeriod = oPayrollGroup.MaxDays_Late;

                    foreach (tbl_genMasEmployee detail in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != null && p.SurName != null && p.Department_ID != null && p.Payroll_ProcessGroupID == sProcessGroupID && p.IsCanceled == false).OrderBy(o => o.EpfNo.PadLeft(4, '0')).ThenBy(o => o.Employee_ID.PadLeft(4, '0')))
                    {//
                     //  if (detail.EpfNo != "0035")
                     //    continue;

                        if (clsConfig.bLateCalculate_EndOfPayrollPeriod)
                            UpdateLatesToNopay(detail.Employee_ID, dMaxLateMins_PerDay, dMaxLateDays_PerPeriod, diLateGracePeriodMins_PerDay);

                        #region Check lastworking date for remove resign employee
                        if (detail.LastWorkingDate.Date != clsConfig.defaultDateTime.Date && dtmPeriodStartDate.Date > detail.LastWorkingDate.Date)
                            continue;
                        #endregion

                        #region Get shift details
                        string[] oShiftDetails = clsHelpMethods.getEmpShiftDetails(detail.Employee_ID, dtmPeriodEndDate, detail.IsRosterBasedEmployee);
                        if (decimal.Parse(oShiftDetails[4]) == 0)
                        {
                            lsEmployees_ShiftIssues.Add(detail.Employee_ID + " - " + clsRef_Name.get_EmployeeShortName(detail.Employee_ID));
                            continue;
                        }
                        #endregion

                        #region Get attendance details
                        decimal[] dAttenData = clsHelpMethods.GetAttendanceDetails(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);
                        if (clsConfig.bDisable_ZeroAttendance_Employees && dAttenData[1] <= 0)//Drop employee have not working minutes to entry Month
                            continue;
                        #endregion

                        #region Days Calculation
                        //string sMandatoryDays = "0", sActualDays = "0";
                        //if (clsConfig.bEnable_DaysCalculation)
                        //{
                        //    sMandatoryDays = DBHandling.ExecQuery_ReturnDecimal("SELECT [dbo].[GetMandatoryDays]('" + dtmPeriodStartDate.Date + "', '" + dtmPeriodEndDate.Date + "', '" + detail.Employee_ID + "')").ToString();
                        //    sActualDays = DBHandling.ExecQuery_ReturnDecimal("SELECT [dbo].[GetWorkingDays]('" + dtmPeriodStartDate.Date + "', '" + dtmPeriodEndDate.Date + "', '" + detail.Employee_ID + "')").ToString();
                        //}
                        #endregion

                        #region Fill Data Grid
                        #region Late Time Validation
                        //decimal dLateMinutes = 0;
                        //if (clsConfig.bLateCalculation_DeductGivenLateMaxTime)
                        //    dLateMinutes = dAttenData[2] - (oPayrollGroup.MaxMins_Late);
                        //else
                        //    dLateMinutes = dAttenData[2];
                        //dLateMinutes = dLateMinutes < 0 ? 0 : dLateMinutes;
                        #endregion

                        var Quary = "exec [dbo].[sp_getAttendanceData_DateRange2]  '" + dtmPeriodStartDate.Date + "', '" + dtmPeriodEndDate.Date + "', '" + detail.Employee_ID + "'";
                        var tmpDt = DBHandling.ExecQuery(Quary).Tables[0];

                        dgr_Main.dt.Merge(tmpDt);

                     
                        //dgr_Main.dt.Rows.Add(detail.Employee_ID,
                        //    detail.SurName + " ," + detail.Initails,
                        //    clsRef_Name.get_Division_Name(detail.Division_ID),
                        //    clsRef_Name.get_Department_Name(detail.Department_ID),
                        //    clsRef_Name.get_Section_Name(detail.SectionID),
                        //    clsRef_Name.get_SubSection_Name(detail.SubSectionID),

                        //    sMandatoryDays,//MandatoryDays
                        //    sActualDays,//ActualDays

                        //    cls_Formater.FormatDecimal(dAttenData[0] / 60, 2), //workHrs_Mand
                        //    ConvertMinsToHrsMins(dAttenData[0]), //workHrs_Mand

                        //    cls_Formater.FormatDecimal(dAttenData[1] / 60, 2), //workHrs_Act
                        //    ConvertMinsToHrsMins(dAttenData[1]), //workHrs_Act

                        //    cls_Formater.FormatDecimal(dLateMinutes / 60, 2), //Late
                        //    ConvertMinsToHrsMins(dLateMinutes), //Late

                        //    cls_Formater.FormatDecimal(dAttenData[3] / 60, 2), //Nopay
                        //    ConvertMinsToHrsMins(dAttenData[3]), //Nopay

                        //    cls_Formater.FormatDecimal(dAttenData[4] / 60, 2), //workHrs_OT_Normal
                        //    ConvertMinsToHrsMins(dAttenData[4]), //workHrs_OT_Normal

                        //    cls_Formater.FormatDecimal(dAttenData[5] / 60, 2), //workHrs_OT_Double
                        //    ConvertMinsToHrsMins(dAttenData[5]),  // workHrs_OT_Double

                        //    cls_Formater.FormatDecimal(dAttenData[8] / 60, 2), //workHrs_OT_Triple
                        //    ConvertMinsToHrsMins(dAttenData[8]),  // workHrs_OT_Triple

                        //    cls_Formater.FormatDecimal(dAttenData[6] / 60, 2), //Leave
                        //    ConvertMinsToHrsMins(dAttenData[6]),  // Leave

                        //    cls_Formater.FormatDecimal(dAttenData[7] / 60, 2), //Gatepass
                        //    ConvertMinsToHrsMins(dAttenData[7]),  // Gatepass

                        //    "1.5", //Base OT Rate
                        //    "2.0", //Base Double IT Rate
                        //    "3.0", //Base Triple IT Rate
                        //    diDivRate_OT_PerPeriod, // Divide OT Rate
                        //    diDivRate_OT_PerPeriod, // Divide Double OT Rate
                        //    diDivRate_OT_PerPeriod, // Divide Triple OT Rate
                        //    "0", // Employee OT Rate - Not developed
                        //    "0", // Employee Double OT Rate - Not developed
                        //    "0", // Employee Triple OT Rate - Not developed

                        //    diDivRate_Att_PerPeriod, // Divide Nopay Rate
                        //    diDivRate_Att_PerPeriod, // Divide Late Rate
                        //    "0", // Employee Nopay Rate - Not developed
                        //    "0"  // Employee Late Rate - Not developed
                        //    );
                        #endregion

                        #region Common Payslip Items

                        decimal BasicSalary = DBHandling.ExecQuery_ReturnDecimal("[dbo].[sp_GetBasicSalary] '"+clsSecurity.CompanyID+"','"+ clsSecurity.BranchID + "','" + detail.Employee_ID+"'");

                        decimal dOT_Normal_Amt = decimal.Parse(tmpDt.Rows[0]["Amt_OT"].ToString());
                        decimal dOT_Double_Amt = decimal.Parse(tmpDt.Rows[0]["Amt_DOT"].ToString());
                        decimal dOT_Triple_Amt = decimal.Parse(tmpDt.Rows[0]["Amt_DOT"].ToString());
                        decimal dNoPay_Amt = decimal.Parse(tmpDt.Rows[0]["Amt_NP"].ToString());
                        decimal dLateAmt = decimal.Parse(tmpDt.Rows[0]["Amt_Late"].ToString());
                        #region OT
                        //   decimal dOT_WorkingMin = dAttenData[4];
                        //   decimal OTRate = clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, "PITM/128");
                        //     decimal dOT_Normal_Amt = (BasicSalary / diDivRate_Att_PerPeriod) * 1.5m * (dAttenData[4] );
                        //   decimal dOT_Normal_Amt = OTRate/60 * (dAttenData[4]);
                        UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sOT_Normal, dOT_Normal_Amt);
                        #endregion

                        #region Double OT
                       // decimal dOT_Double_Amt = (BasicSalary / diDivRate_Att_PerPeriod) * 2.0m * (dAttenData[5] );
                        UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sOT_Double, dOT_Double_Amt);
                        #endregion

                        #region Triple OT
                       // decimal dOT_Triple_Amt = (BasicSalary / diDivRate_Att_PerPeriod) * 3.0m * (dAttenData[8] );
                        UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sOT_Triple, dOT_Triple_Amt);
                        #endregion

                        #region PAYE
                        decimal dPAYE_Amt = clsHelpMethods.GetPAYE_Amout_FromMas(detail.Employee_ID);
                        UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sPAYE, dPAYE_Amt);
                        #endregion

                        #region No Pay
                       // decimal dNoPay_Amt = (BasicSalary / diDivRate_Att_PerPeriod) * (dAttenData[3] );
                        UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sNopay, dNoPay_Amt);
                        #endregion

                        UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sLate, dAttenData[9]);

                        #endregion

                        #region Hero Group - Payslip Items
                        //if (clsConfig.bEnableAllowance_Hero)
                        //{
                        //    #region Attendance Allowance
                        //    decimal dAttenBonus_Amt = 0;
                        //    decimal condAtt = ((dLateMis_forSalary + dAttenData[3] + dAttenData[6]) / (decimal.Parse(oShiftDetails[4])));
                        //    if (condAtt < 0.5m)
                        //    {
                        //        dAttenBonus_Amt = decimal.Parse(clsConfig.sAttendance_LessThan_HalfDay);
                        //    }
                        //    else if (condAtt >= 0.5m && condAtt < 1m)
                        //    {
                        //        dAttenBonus_Amt = decimal.Parse(clsConfig.sAttendance_LessThan_OneDay);
                        //    }
                        //    else if (condAtt >= 1 && condAtt < 1.5m)
                        //    {
                        //        dAttenBonus_Amt = decimal.Parse(clsConfig.sAttendance_LessThan_OneAndHalfDay);
                        //    }
                        //    else
                        //    {
                        //        dAttenBonus_Amt = 0;
                        //    }
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sAttendance, dAttenBonus_Amt);

                        //    #endregion

                        //    #region Other Allowance and Deduction
                        //    decimal condAll = ((dAttenData[3] + dAttenData[6]) / 60); // hrs for Allowance deductions
                        //    decimal dAllowance1_ded = 0;
                        //    if (condAll >= 36)
                        //        dAllowance1_ded = ((clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.sAllowance1) / diDivRate_Att_PerPeriod) * condAll);
                        //    //UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sAllowance1_Deduction, -dAllowance1_ded);
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sAllowance1_Deduction, dAllowance1_ded);

                        //    decimal dIncrementAllowance_ded = 0;
                        //    if (condAll >= 36)
                        //        dIncrementAllowance_ded = ((clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.sIncrementAllowance) / diDivRate_Att_PerPeriod) * condAll);
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sIncrementAllowance_Deduction, dIncrementAllowance_ded);

                        //    decimal dAllowanceTea_ded = 0;
                        //    if (condAll >= 36)
                        //        dAllowanceTea_ded = ((clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.sTeaMakingAllowance) / diDivRate_Att_PerPeriod) * condAll);
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sTeaMakingAllowance_Deduction, dAllowanceTea_ded);

                        //    decimal dAllowanceBording_ded = 0;
                        //    if (condAll >= 36)
                        //        dAllowanceBording_ded = ((clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.sBordingAllowance) / diDivRate_Att_PerPeriod) * condAll);
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sBordingAllowance_Deduction, dAllowanceBording_ded);

                        //    /*----------Hero-Nature----------------------*/
                        //    decimal dAllowanceCoconut_ded = 0;
                        //    if (condAll >= 36)
                        //        dAllowanceCoconut_ded = ((clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.sCocuntAllowance) / diDivRate_Att_PerPeriod) * condAll);
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sCocuntAllowance_Deduction, dAllowanceCoconut_ded);

                        //    decimal dAllowanceStores_ded = 0;
                        //    if (condAll >= 36)
                        //        dAllowanceStores_ded = ((clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.sStoresAllowance) / diDivRate_Att_PerPeriod) * condAll);
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sStoresAllowance_Deduction, dAllowanceStores_ded);

                        //    decimal dAllowanceDryer_ded = 0;
                        //    if (condAll >= 36)
                        //        dAllowanceDryer_ded = ((clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.sDryerAllowance) / diDivRate_Att_PerPeriod) * condAll);
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sDryerAllowance_Deduction, dAllowanceDryer_ded);

                        //    decimal dShellRemovingAllowance = 0;
                        //    try
                        //    {
                        //        string sQuary = "SELECT sum(amount_Total) As Amount" +
                        //                            " FROM tbl_ccTxDailyWorkingProgress" +
                        //                            " WHERE(attendenceDate >= '" + dtmPeriodStartDate.Date + "')" +
                        //                            " AND(attendenceDate <= '" + dtmPeriodEndDate.Date + "')" +
                        //                            " AND employee_ID = '10'" +
                        //                            " AND paymentPeriod = 2 " +
                        //                            " Group by company_ID, companyBranch_ID, employee_ID";
                        //        string sShellRemovingAllowance = DBHandling.ExecQuery_ReturnStringValue(sQuary);
                        //        if (sShellRemovingAllowance != "-")
                        //            dShellRemovingAllowance = decimal.Parse(sShellRemovingAllowance);
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        dShellRemovingAllowance = 0;
                        //    }
                        //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sShellremovingAllowance, dShellRemovingAllowance);
                        //    #endregion
                        //}
                        //-------------------------------------------- 
                        #endregion

                        #region AKT - Payslip Items
                        if (clsConfig.bEnableAllowance_AKT)
                        {
                            //#region Stamp Duty
                            //decimal dStampDuty_Amt = (clsHelpMethods.GetGrossSalary_FromMas(detail.Employee_ID)) >= 25000m ? 25m : 0.00m;
                            //UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sStampDuty_Deduction, dStampDuty_Amt);
                            //#endregion

                            //#region Coinage Updates
                            //decimal dLastMonthCoinage_Amt = 0;
                            //tbl_genMasEmployee_PaySlipItems oPayItem_LastCoinage = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, detail.Employee_ID, clsConfig.sCurrentMonthCoinage);
                            //if (oPayItem_LastCoinage != null)
                            //    dLastMonthCoinage_Amt = oPayItem_LastCoinage.Rate * -1;
                            //UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sLastMonthCoinage, dLastMonthCoinage_Amt);
                            //UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sCurrentMonthCoinage, 0);
                            //#endregion

                            //#region Store Allowance
                            //if (detail.Department_ID == clsConfig.sDepartmentID_One)//Store Department (360)
                            //{
                            //    decimal dWorkingDays = decimal.Parse(sActualDays); //clsHelpMethods.RoundDecimalPlaces(dAttenData[1] / (8m * 60m)); //decimal.Parse(oShiftDetails[3])
                            //    decimal dStoreAllowance = 0;

                            //    //Store Allowance
                            //    decimal dStoreEntitlements = clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.EntitlementOne);//Store Entitilement (76)
                            //    if (dStoreEntitlements > 0)
                            //    {
                            //        if (dWorkingDays > 22m)
                            //            dStoreAllowance = dStoreEntitlements;// 5000
                            //        else if (dWorkingDays <= 22m && dWorkingDays >= 15m)
                            //            dStoreAllowance = dStoreEntitlements / 2m;// 5000/1
                            //        else
                            //            dStoreAllowance = 0m;
                            //    }
                            //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sStoresAllowance, dStoreAllowance); //Store Allowance (61)
                            //}
                            //#endregion

                            //#region Ladies Night Allowance
                            //tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(detail.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                            //if (oEmp.Gender == (int)Gender.Female)
                            //{
                            //    decimal sBaseSalary_ForDay = 0;
                            //    decimal dAttendanceMinutes = clsHelpMethods.GetLadiesNightShiftsDays(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);
                            //    decimal dBaseSalaryHour = decimal.Round((clsHelpMethods.GetBaseSalaryForNopay_FromMas(detail.Employee_ID) / diDivRate_Att_PerPeriod) / 2m, 2);

                            //    if (dAttendanceMinutes > 0)
                            //        sBaseSalary_ForDay = (dBaseSalaryHour * (dAttendanceMinutes / 60)); //base salary for day * employee working days

                            //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sLadiesNightShift_Allowance, sBaseSalary_ForDay);
                            //}
                            //#endregion

                            //#region Shift Allowance
                            ////decimal dShiftDays = clsHelpMethods.RoundDecimalPlaces(dAttenData[1] / (8m * 60m)); //decimal.Parse(oShiftDetails[3])
                            //decimal dShiftAllowance = 0;

                            ////Shift Allowance
                            //decimal dShiftEntitlements = clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.EntitlementTwo);//Shift Entitilement (77)
                            //if (dShiftEntitlements > 0)
                            //    dShiftAllowance = dShiftEntitlements * decimal.Parse(sActualDays);// 500 * 210 * 60

                            //UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sShiftAllowance, dShiftAllowance); //Store Allowance (61)
                            //#endregion

                            //#region Night Allowance
                            //if (detail.EmpCatagory3_ID == clsConfig.sCategoryItem1 || detail.EmpCatagory3_ID == clsConfig.sCategoryItem2 || detail.EmpCatagory3_ID == clsConfig.sCategoryItem3)
                            //{
                            //    decimal d24NightShiftDays = 0, dNightShiftDays = 0;
                            //    clsHelpMethods.GetNightShiftsDays(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date, ref d24NightShiftDays, ref dNightShiftDays);

                            //    decimal dNightRate = 0, d24NightRate = 0;
                            //    if (detail.EmpCatagory3_ID == clsConfig.sCategoryItem1)//supervisors
                            //    {
                            //        d24NightRate = 300m;
                            //        dNightRate = 200m;
                            //    }
                            //    else if (detail.EmpCatagory3_ID == clsConfig.sCategoryItem2)//operators and helpers akt
                            //    {
                            //        d24NightRate = 250m;
                            //        dNightRate = 150m;
                            //    }
                            //    else if(detail.EmpCatagory3_ID == clsConfig.sCategoryItem3)//polymer employees
                            //    {
                            //        d24NightRate = 100m;
                            //        dNightRate = 0;
                            //    }

                            //    decimal dAmount = 0;
                            //    if (d24NightShiftDays > 0)
                            //        dAmount += d24NightRate * d24NightShiftDays;
                            //    if (dNightShiftDays > 0)
                            //        dAmount += dNightRate * dNightShiftDays;



                            //    UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sNightAllowance, dAmount);
                            //}
                            //#endregion
                        }
                        #endregion

                        #region CELCIUS - Payslip Items
                        #region Attendance Allowance
                        if (clsConfig.bEnableAllowance_Celcius)
                        {
                            decimal dAttenBonus_Amt_Cel = decimal.Parse(clsConfig.sCel_AttendanceBonus_Rate);
                            decimal condAtt_Cel = ((dAttenData[3] + dAttenData[6]) / decimal.Parse(oShiftDetails[4]));

                            if (condAtt_Cel >= 1m && condAtt_Cel <= 1.5m)
                                dAttenBonus_Amt_Cel -= decimal.Parse(clsConfig.sAttendanceAllowanceApplyRate_One);
                            else if (condAtt_Cel >= 1.5m && condAtt_Cel <= 2.5m)
                                dAttenBonus_Amt_Cel -= decimal.Parse(clsConfig.sAttendanceAllowanceApplyRate_Two);
                            else if (condAtt_Cel >= 2.5m && condAtt_Cel <= 3.5m)
                                dAttenBonus_Amt_Cel -= decimal.Parse(clsConfig.sAttendanceAllowanceApplyRate_Three);
                            else if (condAtt_Cel > 3.5m)
                                dAttenBonus_Amt_Cel = 0;

                            UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sAttendance, dAttenBonus_Amt_Cel);
                        }
                        #endregion

                        #region ShiftAllowance
                        //2017-12-22 remove shift allowance for celcius due to the requirement changed
                        //decimal sShiftAllowance = UpdateShiftAllowance(detail.Employee_ID);
                        //UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sShiftAllowance, sShiftAllowance); 
                        #endregion
                        #endregion

                        #region Indika Enterprises
                        if (clsConfig.bEnableAllowance_Indika)
                        {
                            #region Attendance Allowance
                            decimal dAttenBonus_Amt_indk = decimal.Parse("0");
                            decimal condAtt_indk = ((dAttenData[3] + dAttenData[6]) / decimal.Parse(oShiftDetails[4]));

                            if (detail.Department_ID == clsConfig.sDepartmentID_One)//admin / accounts
                            {
                                if (condAtt_indk < 1m)
                                    dAttenBonus_Amt_indk = decimal.Parse(clsConfig.sAttendanceAllowanceApplyRate_One);
                            }
                            else if (detail.Department_ID == clsConfig.sDepartmentID_Two)//factory
                            {
                                if (condAtt_indk < 1m)
                                    dAttenBonus_Amt_indk = decimal.Parse(clsConfig.sAttendanceAllowanceApplyRate_One);
                            }
                            else if (detail.Department_ID == clsConfig.sDepartmentID_Three || detail.Department_ID == clsConfig.sDepartmentID_Four)//store and drivers
                            {
                                if (condAtt_indk < 1m)
                                    dAttenBonus_Amt_indk = decimal.Parse(clsConfig.sAttendanceAllowanceApplyRate_Three);
                                if (condAtt_indk >= 1m && condAtt_indk < 2m)
                                    dAttenBonus_Amt_indk = decimal.Parse(clsConfig.sAttendanceAllowanceApplyRate_Two);
                            }
                            UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sAttendance, dAttenBonus_Amt_indk);
                            #endregion

                            #region Late Deduction
                            //decimal dLateDays = clsHelpMethods.UpdateLates(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);
                            //decimal dLateDeduction_Amt = 0;
                            //if (dLateDays > 0)
                            //{
                            //    dLateDays -= clsConfig.dMaximumLateDays_Office;//3

                            //    if (dLateDays > 0)
                            //        dLateDeduction_Amt = dLateDays * clsConfig.sLate_DeductionRate;//50
                            //}
                            //UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sLate, dLateDeduction_Amt);
                            #endregion

                            #region Fixed Allowances
                            decimal dWorkingDaysForMonth = 30;
                            if (detail.Department_ID != "DEP/001" )
                                dWorkingDaysForMonth = 200 / 9;

                            decimal dNoPayDays = clsHelpMethods.RoundDecimalPlaces(dAttenData[3] / decimal.Parse(oShiftDetails[4]));
                            decimal dRiskAllowance = 0, dStockAllowance = 0, dReimbursementAllowance = 0, dTransportAllowance = 0;
                            decimal dRiskEntitlements = clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.EntitlementOne);
                        
                            if (dRiskEntitlements > 0)
                            {  
                                    dRiskAllowance = dRiskEntitlements - (dRiskEntitlements / diDivRate_Att_PerPeriod * dAttenData[3]);//5000 - (5000/26 *3)
                                if (dRiskAllowance > dRiskEntitlements)
                                    dRiskAllowance = dRiskEntitlements;
                            }
                            UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sRiskAllowance, dRiskAllowance);

                            //Stock Allowance
                            decimal dStockEntitlements = clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.EntitlementTwo);
                            if (dStockEntitlements > 0)
                            {
                                dStockAllowance = dStockEntitlements - (dStockEntitlements / diDivRate_Att_PerPeriod * dAttenData[3]); //5000 - (5000/26 *3)
                                if (dStockAllowance > dStockEntitlements)
                                    dStockAllowance = dStockEntitlements;
                            }
                            UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sStockAllowance, dStockAllowance);

                            //Reimbursement Allowance
                            decimal dReimbursementEntitlements = clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.EntitlementThree);
                            if (dReimbursementEntitlements > 0)
                            {
                                dReimbursementAllowance = dReimbursementEntitlements - (dReimbursementEntitlements / diDivRate_Att_PerPeriod * dAttenData[3]);//5000 - (5000/26 *3)
                                if (dReimbursementAllowance > dReimbursementEntitlements)
                                    dReimbursementAllowance = dReimbursementEntitlements;
                            }
                            UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sReimbursementAllowance, dReimbursementAllowance);

                            //Transport Allowance
                            decimal dTransportEntitlements = clsHelpMethods.GetPaySlipItemAmount_FromMas(detail.Employee_ID, clsConfig.EntitlementFour);
                            if (dTransportEntitlements > 0)
                            {
                                dTransportAllowance = dTransportEntitlements - (dTransportEntitlements / diDivRate_Att_PerPeriod * dAttenData[3]);
                              //  dTransportAllowance = (dTransportEntitlements / decimal.Parse(sMandatoryDays)) * decimal.Parse(sActualDays); //(5000/26) * 22
                                if (dTransportAllowance > dTransportEntitlements)
                                    dTransportAllowance = dTransportEntitlements;
                            }
                            UpdatePaySlipItemAmount(detail.Employee_ID, clsConfig.sTransportAllowance, dTransportAllowance);
                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                    if (lsEmployees_ShiftIssues.Count > 0)
                    {
                        string sMessageBody_ShiftErrorEmployees = "";
                        foreach (string sEmp in lsEmployees_ShiftIssues)
                            sMessageBody_ShiftErrorEmployees += sEmp + " \n";

                        SEACCMessageBox.Show("Something went wrong in Employee's Shift", sMessageBody_ShiftErrorEmployees, MessageBoxButton.OK);
                    }
                }
                #endregion

                #region Payroll Processings - Saved Data
                else
                {
                    foreach (tbl_payTxSIPRawData detail in tbl_payTxSIPRawData.SelectAll().Where(p => p.ProcessGroup_ID == oSubPeriod.ProcessGroup_ID && p.ProcessPeriod_ID == oSubPeriod.ProcessPeriod_ID && p.ProcessPeriod_Sub_ID == oSubPeriod.ProcessPeriod_Sub_ID).OrderBy(o => o.Employee_ID.PadLeft(4, '0')))
                    {
                        dgr_Main.dt.Rows.Add(detail.Employee_ID,
                            clsRef_Name.get_EmployeeShortName(detail.Employee_ID),
                            clsRef_Name.get_Division_Name(detail.Division_ID),
                            clsRef_Name.get_Department_Name(detail.Department_ID),
                            clsRef_Name.get_Section_Name(detail.SectionID),
                            clsRef_Name.get_SubSection_Name(detail.SubSectionID),

                            cls_Formater.FormatDecimal(detail.WorkingDays_Mand, 2), //WorkingDays_Mand
                            cls_Formater.FormatDecimal(detail.WorkingDays_Act, 2), //WorkingDays_Act

                            cls_Formater.FormatDecimal((detail.WorkingMinutes_Mand / 60), 2),    //workHrs_Mand
                            ConvertMinsToHrsMins(detail.WorkingMinutes_Mand),

                            cls_Formater.FormatDecimal((detail.WorkingMinutesAct_Nomal / 60), 2), //workHrs_Act
                            ConvertMinsToHrsMins(detail.WorkingMinutesAct_Nomal),

                            cls_Formater.FormatDecimal((detail.LateMinutes / 60), 2), //lateHrs
                            ConvertMinsToHrsMins(detail.LateMinutes),

                            cls_Formater.FormatDecimal((detail.NoPayMinutes / 60), 2), //noPayHrs
                            ConvertMinsToHrsMins(detail.NoPayMinutes),

                            cls_Formater.FormatDecimal((detail.WorkingMinutesAct_OT / 60), 2), //workHrs_OT_Normal
                            ConvertMinsToHrsMins(detail.WorkingMinutesAct_OT),

                            cls_Formater.FormatDecimal((detail.WorkingMinutesAct_OT_Dub / 60), 2), //workHrs_OT_Double
                            ConvertMinsToHrsMins(detail.WorkingMinutesAct_OT_Dub),

                            cls_Formater.FormatDecimal((detail.WorkingMinutesAct_OT_Trpl / 60), 2), //workHrs_OT_Triple
                            ConvertMinsToHrsMins(detail.WorkingMinutesAct_OT_Trpl),

                            cls_Formater.FormatDecimal((detail.LeaveMinutes / 60), 2), //Leave
                            ConvertMinsToHrsMins(detail.LeaveMinutes),

                            cls_Formater.FormatDecimal((detail.GatePassMinutes / 60), 2), //Gatepass
                            ConvertMinsToHrsMins(detail.GatePassMinutes),

                            cls_Formater.FormatDecimal(detail.BaseRate_OT, 2),
                            cls_Formater.FormatDecimal(detail.BaseRate_DOT, 2),
                            cls_Formater.FormatDecimal(detail.BaseRate_TOT, 2),

                            cls_Formater.FormatDecimal(detail.DivRate_OT, 2),
                            cls_Formater.FormatDecimal(detail.DivRate_DOT, 2),
                            cls_Formater.FormatDecimal(detail.DivRate_TOT, 2),

                            cls_Formater.FormatDecimal(detail.EmpRate_OT, 2),
                            cls_Formater.FormatDecimal(detail.EmpRate_DOT, 2),
                            cls_Formater.FormatDecimal(detail.EmpRate_TOT, 2),

                            cls_Formater.FormatDecimal(detail.DivRate_Nopay, 2),
                            cls_Formater.FormatDecimal(detail.DivRate_Late, 2),
                            cls_Formater.FormatDecimal(detail.EmpRate_Nopay, 2),
                            cls_Formater.FormatDecimal(detail.EmpRate_Late, 2)
                            );
                    }
                }
                #endregion

                dgr_Main.RefreshGrid();
                FrmWaiting.Close();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Something went wrong...", ex.Message, MessageBoxButton.OK);
            }
            finally
            {
                dgr_Main.RefreshGrid();
                FrmWaiting.Close();
            }
        }
        #endregion

        #region Action Buttons
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            return;

            if (!oSubPeriod.IsClosedPeriod)
            {
                if (SEACCMessageBox.Show("Are you sure to start the process? '", ""))
                {
                    frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
                    try
                    {
                        #region Flush data already added
                        List<tbl_payTxSIPRawData> oRawData = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmPeriodStartDate, dtmPeriodEndDate)
                            .Where(p => p.ProcessGroup_ID == sProcessGroupID).ToList();
                        if (oRawData.Count > 0)
                        {
                            //clsHelpMethods.RollBack_Payroll(sProcessGroupID, dtmPeriodStartDate, dtmPeriodEndDate);
                            DBHandling.ExecQuery("exec payrollFlushGroup '" + dtmPeriodStartDate + "', '" + dtmPeriodEndDate + "', '" + sProcessGroupID + "'");
                        }
                        #endregion

                        #region Save Payroll Data
                        foreach (DataRow row in dgr_Main.dt.Rows)
                        {
                            #region Method Variables Initialize
                            string sEmployee_ID = row["empID"].ToString();

                            decimal dWorkDays_Mand = decimal.Parse(row["workDays_Mand"].ToString());
                            decimal dWorkDays_Act = decimal.Parse(row["workDays_Act"].ToString());

                            decimal dWorkMins_Mand = clsValidation.GetMinutes(row["workHrsMins_Mand"].ToString());  // decimal.Parse(row["workHrs_Mand"].ToString());
                            decimal dWorkMins_Act = clsValidation.GetMinutes(row["workHrsMins_Act"].ToString());
                            decimal dNoPayMins = clsValidation.GetMinutes(row["noPayHrsMins"].ToString());
                            decimal dLatesMins = clsValidation.GetMinutes(row["lateHrsMins"].ToString());
                            decimal dWorkMins_OT_Normal = clsValidation.GetMinutes(row["workHrsMins_OT_Normal"].ToString());
                            decimal dWorkMins_OT_Double = clsValidation.GetMinutes(row["workHrsMins_OT_Double"].ToString());
                            decimal dWorkMins_OT_Triple = clsValidation.GetMinutes(row["workHrsMins_OT_Triple"].ToString());
                            decimal dLeaveMins = clsValidation.GetMinutes(row["leaveHrsMins"].ToString());
                            decimal dGatePassMins = clsValidation.GetMinutes(row["gatePassHrsMins"].ToString());

                            decimal dBaseRate_OT = decimal.Parse(row["baseRate_OT_Normal"].ToString());
                            decimal dBaseRate_DOT = decimal.Parse(row["baseRate_OT_Double"].ToString());
                            decimal dBaseRate_TOT = decimal.Parse(row["baseRate_OT_Triple"].ToString());

                            decimal dDivRate_OT = 0;// decimal.Parse(row["divRate_OT_Normal"].ToString());
                            decimal dDivRate_DOT = 0;// decimal.Parse(row["divRate_OT_Double"].ToString());
                            decimal dDivRate_TOT = 0;// decimal.Parse(row["divRate_OT_Triple"].ToString());

                            decimal dEmpRate_OT = 0; //decimal.Parse(row["empRate_OT_Normal"].ToString());//Not used 
                            decimal dEmpRate_DOT = 0; //decimal.Parse(row["empRate_OT_Double"].ToString());//Not used 
                            decimal dEmpRate_TOT = 0; //decimal.Parse(row["empRate_OT_Triple"].ToString());//Not used 

                            decimal dDivRate_Nopay = 0;// decimal.Parse(row["divRate_Nopay"].ToString());
                            decimal dDivRate_Late = 0;// decimal.Parse(row["divRate_Late"].ToString());
                            decimal dEmpRate_Nopay = 0;// decimal.Parse(row["empRate_Nopay"].ToString());//Not used 
                            decimal dEmpRate_Late = 0;// decimal.Parse(row["empRate_Late"].ToString());//Not used 

                            tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(sEmployee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);

                            int iSIP_ID = 0;
                            tbl_payTxSIPRawData oTxRawData = tbl_payTxSIPRawData.SelectAll().Where(r => r.Company_ID == clsSecurity.CompanyID && r.CompanyBranch_ID == clsSecurity.BranchID).OrderByDescending(o => o.SIP_ID).FirstOrDefault();
                            if (oTxRawData != null)
                                iSIP_ID = oTxRawData.SIP_ID + 1;
                            #endregion

                            UpdatePaySlipItemAmount(sEmployee_ID, clsConfig.sCurrentMonthCoinage, 0);//update current month coinage as zero for before process

                            #region Insert tbl_payTxSIPRawData
                            tbl_payTxSIPRawData nTxpayrollRaw = new tbl_payTxSIPRawData(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP_ID, sProcessGroupID, iProcessPeriodID, iSubProcessPeriodID, oEmployee.Employee_ID, oEmployee.Division_ID, oEmployee.Department_ID, oEmployee.SectionID, oEmployee.SubSectionID, oSubPeriod.StartDate.Date, oSubPeriod.EndDate.Date,
                                dWorkDays_Mand, dWorkDays_Act, dWorkMins_Mand, dWorkMins_Act, dNoPayMins, dLatesMins, dWorkMins_OT_Normal, dWorkMins_OT_Double, dWorkMins_OT_Triple,
                                dLeaveMins, dGatePassMins, dBaseRate_OT, dBaseRate_DOT, dBaseRate_TOT, dDivRate_OT, dDivRate_DOT, dDivRate_TOT, dEmpRate_OT, dEmpRate_DOT, dEmpRate_TOT, dDivRate_Nopay, dDivRate_Late, dEmpRate_Nopay, dEmpRate_Late, oEmployee.Designation_ID, oEmployee.EmpCatagory1_ID, oEmployee.EmpCatagory2_ID, oEmployee.EmpCatagory3_ID, oEmployee.DateConfirm, oEmployee.IsTime_Attendance, oEmployee.IsPayslip_Print, oEmployee.NicNo, oEmployee.IsEPF_ETF_Process, oEmployee.EpfNo, oEmployee.Is_PayeeProcess,
                                "default", oEmployee.PaymentMethod_ID, oEmployee.Bank_ID, oEmployee.BankBranch_ID, oEmployee.Employee_AccountNo, false, false, clsSecurity.UserIDLoged, "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                            nTxpayrollRaw.Insert();
                            #endregion

                            foreach (tbl_genMasEmployee_PaySlipItems oEmpPayItem in tbl_genMasEmployee_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID))
                            {
                                tbl_payMas_PaySlipItems oMasPayItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmpPayItem.PayItem_ID);
                                if (!oMasPayItem.IsPayslipApplicable)
                                    continue;

                                #region Insert tbl_payTxSIPRawData_PaySlipItems
                                tbl_payTxSIPRawData_PaySlipItems nTxPaySlipItem = new tbl_payTxSIPRawData_PaySlipItems(
                                    clsSecurity.CompanyID, clsSecurity.BranchID, nTxpayrollRaw.SIP_ID, oMasPayItem.PayItem_ID, 0, oMasPayItem.PayItem_Code, 
                                    oMasPayItem.PayItem_ID, oMasPayItem.PayItem_Class_ID, oMasPayItem.PayItem_Type_ID, oMasPayItem.InputMode, 
                                    oMasPayItem.IsEarning, oMasPayItem.Pay_Period, "default", oEmpPayItem.Rate, 0, 0, clsSecurity.UserIDLoged, 
                                    "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default", 
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime);
                                nTxPaySlipItem.Insert();
                                #endregion

                                foreach (tbl_genMasEmployee_PaySlipItems_Statutary oEmpStatItem in tbl_genMasEmployee_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID_PayItem_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, oEmpPayItem.PayItem_ID))
                                {
                                    decimal amount;
                                    if (oEmpStatItem.IsFlatRate)
                                        amount = oEmpStatItem.FlatRate;
                                    else
                                        amount = oEmpPayItem.Rate * oEmpStatItem.Percentage / 100;

                                    #region Insert tbl_payTxSIPRawData_PaySlipItems_Statutary
                                    tbl_payTxSIPRawData_PaySlipItems_Statutary oNewTxstat = new tbl_payTxSIPRawData_PaySlipItems_Statutary(clsSecurity.CompanyID, clsSecurity.BranchID, nTxpayrollRaw.SIP_ID, nTxPaySlipItem.PayItem_ID, oEmpStatItem.StatutaryPayItem_ID, oEmpStatItem.IsFlatRate, oEmpStatItem.Percentage, amount, 0, 0, clsSecurity.UserIDLoged, "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                                    oNewTxstat.Insert();
                                    #endregion
                                }
                            }

                            #region Update Coinage
                            decimal dNetSalary = clsHelpMethods.GetNetSalary_FromTX(sEmployee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);
                            decimal dCurrentMonthCoinage = (Math.Floor(dNetSalary / 10.0m) * 10m) - dNetSalary; //Round down to 10
                            UpdatePaySlipItemAmount(sEmployee_ID, clsConfig.sCurrentMonthCoinage, dCurrentMonthCoinage);
                            tbl_payTxSIPRawData_PaySlipItems oPayTx_Payslip = tbl_payTxSIPRawData_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, nTxpayrollRaw.SIP_ID, clsConfig.sCurrentMonthCoinage);
                            if (oPayTx_Payslip != null)
                            {
                                oPayTx_Payslip.Amount = dCurrentMonthCoinage;
                                oPayTx_Payslip.Update();
                            }
                            #endregion
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                    finally
                    {
                        FrmWaiting.Close();
                        this.Cursor = Cursors.Arrow;
                    }
                }
            }
            else
            {
                SEACCMessageBox.Show("Oops....", " Process Period has already been processed.", MessageBoxButton.OK);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();
            try
            {
                string sEmployeeid = dgr_Main.dt.Rows[irowID]["empID"].ToString();

                if (vDG_Cell.Column.SortMemberPath == "empName" || vDG_Cell.Column.SortMemberPath == "empDivision" || vDG_Cell.Column.SortMemberPath == "empDepatment" || vDG_Cell.Column.SortMemberPath == "empSection" || vDG_Cell.Column.SortMemberPath == "empSubSection")
                {
                    Master_Forms.frm_Employee_PaySlipItems frmPayItems;
                    if (!oSubPeriod.IsClosedPeriod)
                    {
                        frmPayItems = new Master_Forms.frm_Employee_PaySlipItems(sEmployeeid, false, bSave_Enable, dtmPeriodStartDate, dtmPeriodEndDate,false);
                        frmPayItems.oPayrollGroup = this.oPayrollGroup;
                    }
                    else
                        frmPayItems = new Master_Forms.frm_Employee_PaySlipItems(sEmployeeid, false, false, dtmPeriodStartDate, dtmPeriodEndDate,false);
                    frmPayItems.ShowDialog();
                }

                //This is Under construction ) (This is for View Salary Window )
                else if (vDG_Cell.Column.SortMemberPath == "empID")
                {
                    // frm_Employee_Salary frmEmpSal = new frm_Employee_Salary();
                    // frmEmpSal.RefreshGrid(sEmployeeid);
                    // frmEmpSal.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                //SEACCExeption.Show(ex);
            }
        }
        private void dgr_Main_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vDG_Cell = dgr_Main.GetCurrentCell();
            int irowID = dgr_Main.SelectedIndex;

            try
            {
                string sEmployeeid = dgr_Main.dt.Rows[irowID]["empID"].ToString();

                if (vDG_Cell.Column.SortMemberPath == "workHrs_Mand" || vDG_Cell.Column.SortMemberPath == "workHrsMins_Mand" || vDG_Cell.Column.SortMemberPath == "workHrs_Act" || vDG_Cell.Column.SortMemberPath == "workHrsMins_Act")
                {
                    UC_DailyAttendanceControlPanel UC = new UC_DailyAttendanceControlPanel();
                    if (UC.SEACC_Form.PermissionTO_Read)
                    {
                        UC.EmployeeWithDurationSelect(sEmployeeid, dtmPeriodStartDate, dtmPeriodEndDate);
                        frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);

                        SW.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                //SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Help Methods
        #region Common
        private void UpdatePaySlipItemAmount(string empID, string payItem_ID, decimal dAmount)
        {
            foreach (tbl_genMasEmployee_PaySlipItems oMasEmpPayItem in tbl_genMasEmployee_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, empID).Where(p => p.PayItem_ID == payItem_ID))
            {
                tbl_payMas_PaySlipItems oPayItem = tbl_payMas_PaySlipItems.Select(oMasEmpPayItem.Company_ID, oMasEmpPayItem.CompanyBranch_ID, oMasEmpPayItem.PayItem_ID);
                if (!oPayItem.IsEarning && oPayItem.PayItem_ID != clsConfig.sCurrentMonthCoinage)
                    dAmount = -dAmount;

                //tbl_payMas_PaySlipItems oPayItem = tbl_payMas_PaySlipItems.Select(oMasEmpPayItem.Company_ID, oMasEmpPayItem.CompanyBranch_ID, oMasEmpPayItem.PayItem_ID);
                //if (!oPayItem.IsEarning && oPayItem.PayItem_ID != clsConfig.sCurrentMonthCoinage)
                //    dAmount = dAmount;

                tbl_audTxEmployee_PaySlipItems oAud_EmpPayItems = new tbl_audTxEmployee_PaySlipItems(clsSecurity.CompanyID, clsSecurity.BranchID, empID, payItem_ID, (int)SEACC_Form.enmFormName, (int)enum_Activities_PayslipItems.ChangeAmount, oMasEmpPayItem.Rate, clsHelpMethods.RoundDecimalPlaces(dAmount), clsSecurity.getServerDateTime(), true, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                oAud_EmpPayItems.Insert();

                oMasEmpPayItem.Rate = dAmount;
                oMasEmpPayItem.Update();
            }
        }

        private string ConvertMinsToHrsMins(decimal dTotMins)
        {
            decimal dMins = dTotMins % 60;
            decimal dHrs = (dTotMins - dMins) / 60;
            return dHrs.ToString("00") + ":" + dMins.ToString("00");
        }

        private decimal Get_PayslipAmount(string sEmpID, string sPayslipID)
        {
            decimal dPayslipAmount = 0;
            tbl_genMasEmployee_PaySlipItems oMasEmpPayItem = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sEmpID, sPayslipID);
            if (oMasEmpPayItem != null)
                dPayslipAmount = oMasEmpPayItem.Rate;

            return dPayslipAmount;
        }
        #endregion

        #region AKT Only
        private void UpdateLatesToNopay(string sEmpId, decimal dLateMaxMins, decimal dMaxLateDays, decimal dLateGracePeriod)
        {
            decimal dPayrollPeriod_LateMins = 0;
            decimal dPayrollPeriod_LateDays = 0;
            foreach (tbl_tasTxDailyAttendance attens in tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(sEmpId, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date).OrderBy(o => o.AttendenceDate))//Where(r => r.AttendenceDate.Date >= periodStartDate.Date && r.AttendenceDate <= periodEndDate.Date && r.Employee_ID == sEmpId)
            {
                if (attens.ShiftStartTime < attens.TimeIn_DateTime && attens.ShiftStartTime.Date != clsValidation.defaultDateTime.Date && attens.TimeIn_DateTime.Date != clsValidation.defaultDateTime.Date)
                {
                    dPayrollPeriod_LateMins += attens.NoPayMinutesApproved;
                }

                if (attens.LateMinutes > dLateGracePeriod)
                {
                    dPayrollPeriod_LateMins += (attens.LateMinutes - dLateGracePeriod);
                    dPayrollPeriod_LateDays++;
                }

                if (dPayrollPeriod_LateDays > dMaxLateDays && attens.LateMinutes > dLateGracePeriod)
                    attens.LateMinutesApproved = 60;
                else if (dPayrollPeriod_LateDays <= dMaxLateDays && dPayrollPeriod_LateMins > dLateMaxMins && attens.LateMinutes > dLateGracePeriod)
                    attens.LateMinutesApproved = 60;
                else
                    attens.LateMinutesApproved = 0;
                attens.Update();

                tbl_tasTxDailyAttendance_revision oRevAtten = tbl_tasTxDailyAttendance_revision.SelectAll_Advanced(attens.AttendenceDate.Date, sEmpId).Where(p => (!p.IsCanceled && !p.IsOverride)).OrderByDescending(c => c.Date_Created).FirstOrDefault();
                if (oRevAtten != null)
                {
                    oRevAtten.LateMinutesApproved = attens.LateMinutesApproved;
                    oRevAtten.Update();
                }
                else if (attens.LateMinutesApproved > 0 || attens.LateMinutes > 0)
                {
                    tbl_tasTxDailyAttendance_revision nRevAttens = new tbl_tasTxDailyAttendance_revision(attens.Company_ID, attens.CompanyBranch_ID, attens.AttendenceDate, attens.Employee_ID, attens.Department_ID, attens.DayType, attens.Shift_ID, attens.ShiftDay, attens.ShiftStartTime, attens.ShiftEndTime, attens.ShiftMinutes, attens.ShiftMinutesMin, attens.NextShiftMinutes, attens.ShiftGracePeriod, attens.TimeIn_ID, attens.TimeIn_DateTime, attens.TimeOut_ID, attens.TimeOut_DateTime, attens.TotalMinutes, attens.WorkedMinutes, attens.OTRate, attens.DOTRate, attens.TOTRate, attens.OTMinutes, attens.DOTMinutes, attens.TOTMinutes, attens.IsOT_Applicable, attens.OTMinutesApproved, attens.DOTMinutesApproved, attens.TOTMinutesApproved, attens.LateMinutes, attens.LateMinutesApproved, attens.NoPayMinutes, attens.NoPayMinutesApproved, attens.LeaveMinutes, attens.GpMinutes, false, false, 1, "Default", "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                    nRevAttens.Insert();
                }
            }
        }
        #endregion

        #endregion

    }
}