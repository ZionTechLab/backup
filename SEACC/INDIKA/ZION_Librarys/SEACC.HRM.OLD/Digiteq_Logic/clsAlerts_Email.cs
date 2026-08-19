using SEACC_Alert_Engine;
using System.Data;
using SEACC_WPFControls;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using DataTire;

namespace Digiteq_Logic
{
    public class clsAlerts_Email
    {
        #region  Activity Alerts / Instant Alerts
        /****************** 
        * ACTIVITY ALERTS
        ******************/
        #region Email Generate for Leave
        public static void CreateEmail_LeaveApplication(enum_Alerts AlertID, string LeaveID, string sPersontype)
        {
            Colors enmColor = Colors.Updated;
            if (AlertID == enum_Alerts.LeaveApplied)
                enmColor = Colors.New;
            if (AlertID == enum_Alerts.LeaveUpdated)
                enmColor = Colors.Updated;
            if (AlertID == enum_Alerts.LeaveCancel)
                enmColor = Colors.Updated;
            if (AlertID == enum_Alerts.LeaveApproved)
                enmColor = Colors.Approvd;
            if (AlertID == enum_Alerts.LeaveReject)
                enmColor = Colors.rejected;

            int iAlert_ID = (int)enum_Alerts.LeaveApplied;
            tbl_utlAlert oAlert = tbl_utlAlert.Select(iAlert_ID);
            if (oAlert != null && oAlert.IsActive)
            {
                tbl_tasEmployeeLeaveCard oLeave = tbl_tasEmployeeLeaveCard.Select(clsSecurity.CompanyID, clsSecurity.BranchID, LeaveID);
                if (oLeave != null && oLeave.Leave_ID != "default")
                {
                    DataTable tblDetails = new DataTable();
                    tblDetails.Columns.Add("0");
                    tblDetails.Columns.Add("1");
                    tblDetails.Columns.Add("2");

                    string sName_Applied = "", sName_Checked = "", sName_Approved = "", sName_Covering_1 = "", sName_Covering_2 = "";
                    string sEmpIDAppied = "", sEmpIDChecked = "", sEmpIDApproved = "", sEmpIDCovering1 = "", sEmpIDCovering2 = "";
                    string sEmail_Applied = "", sEmail_Checked = "", sEmail_Approved = "", sEmail_Covering_1 = "", sEmail_Covering_2 = "";
                    string sEmailSubject = "";
                    string sEmailHeder_Appliecent = "", sEmailHeder_CheckedUser = "", sEmailHeder_ApprovedUser = "", SEmailHeader_CoveringPerson1 = "", SEmailHeader_CoveringPerson2 = "";

                    #region Collect User Data
                    #region Applied
                    tbl_genMasEmployee oEmployee_Applied = tbl_genMasEmployee.Select(oLeave.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Applied != null)
                    {
                        sName_Applied = oEmployee_Applied.Initails + " " + oEmployee_Applied.SurName;
                        sEmail_Applied = oEmployee_Applied.Email;
                        sEmpIDAppied = oEmployee_Applied.Employee_ID;
                    }
                    #endregion

                    #region Checked
                    tbl_genMasEmployee oEmployee_Checked = tbl_genMasEmployee.Select(oLeave.UserID_Supevisor, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Checked != null)
                    {
                        sName_Checked = oEmployee_Checked.Initails + " " + oEmployee_Checked.SurName;
                        sEmail_Checked = oEmployee_Checked.Email;
                        sEmpIDChecked = oEmployee_Checked.Employee_ID;
                    }
                    else
                    {
                        sName_Checked = "N/A";
                    }
                    #endregion

                    #region Approved
                    tbl_genMasEmployee oEmployee_Approver = tbl_genMasEmployee.Select(oLeave.UserID_Manager, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Approver != null)
                    {
                        sName_Approved = oEmployee_Approver.Initails + " " + oEmployee_Approver.SurName;
                        sEmail_Approved = oEmployee_Approver.Email;
                        sEmpIDApproved = oEmployee_Approver.Employee_ID;
                    }
                    else
                    {
                        sName_Approved = "N/A";
                    }
                    #endregion

                    #region Covering_1
                    tbl_genMasEmployee oEmployee_Covering_1 = tbl_genMasEmployee.Select(oLeave.UserID_CP1, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Covering_1 != null)
                    {
                        sName_Covering_1 = oEmployee_Covering_1.Initails + " " + oEmployee_Covering_1.SurName;
                        sEmail_Covering_1 = oEmployee_Covering_1.Email;
                        sEmpIDCovering1 = oEmployee_Covering_1.Employee_ID;
                    }
                    else
                    {
                        sName_Covering_1 = "N/A";
                    }
                    #endregion

                    #region Covering_2
                    tbl_genMasEmployee oEmployee_Covering_2 = tbl_genMasEmployee.Select(oLeave.UserID_CP2, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Covering_2 != null)
                    {
                        sName_Covering_2 = oEmployee_Covering_2.Initails + " " + oEmployee_Covering_2.SurName;
                        sEmail_Covering_2 = oEmployee_Covering_2.Email;
                        sEmpIDCovering2 = oEmployee_Covering_2.Employee_ID;
                    }
                    else
                    {
                        sName_Covering_2 = "N/A";
                    }
                    #endregion
                    #endregion

                    sEmailSubject = "Leave - " + sName_Applied + " " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);

                    #region New Leave
                    if ((AlertID == enum_Alerts.LeaveApplied))
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\nYour Leave Applied " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + " is Pending Approval";
                        SEmailHeader_CoveringPerson1 = "Dear " + sName_Covering_1 + ",\n" + sName_Applied + " has Nominate you as a Covering Person for Leave Applied " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        SEmailHeader_CoveringPerson2 = "Dear " + sName_Covering_2 + ",\n" + sName_Applied + " has Nominate you as a Covering Person for Leave Applied " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n" + sName_Applied + " has Applied for a Leave " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + "\nPlease check it as a Supervisor... !!";
                        sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n" + sName_Applied + " has Applied for a Leave " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + "\nPlease Approve it as a Manager... !!";
                    }
                    #endregion
                    #region Updated Leave
                    else if (AlertID == enum_Alerts.LeaveUpdated)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\nYour Updated Leave Applied (Leave ID - " + oLeave.Leave_ID + ")" + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + " is Pending Approval";
                        SEmailHeader_CoveringPerson1 = "Dear " + sName_Covering_1 + ",\n" + sName_Applied + " has Nominate you as a Covering Person for Updated Leave Applied (Leave ID - " + oLeave.Leave_ID + ") " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        SEmailHeader_CoveringPerson2 = "Dear " + sName_Covering_2 + ",\n" + sName_Applied + " has Nominate you as a Covering Person for Updated Leave Applied (Leave ID - " + oLeave.Leave_ID + ") " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n" + sName_Applied + " has Updated Applied for a Leave (Leave ID - " + oLeave.Leave_ID + ") " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + "\nPlease Check it as a Supervisor... !!";
                        sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n" + sName_Applied + " has Updated Applied for a Leave " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + "\nPlease Approve it as a Manager... !!";
                    }
                    #endregion
                    #region Canceled Leave
                    else if (AlertID == enum_Alerts.LeaveCancel)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\nYour Leave Applied " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + " is Successfully Cancled";
                        SEmailHeader_CoveringPerson1 = "Dear " + sName_Covering_1 + ",\n" + sName_Applied + " has Cancled  Leave " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        SEmailHeader_CoveringPerson2 = "Dear " + sName_Covering_2 + ",\n" + sName_Applied + " has Cancled  Leave " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n" + sName_Applied + " has Cancled  Leave " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n" + sName_Applied + " has Cancled  Leave " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                    }
                    #endregion
                    #region Rejected Leave
                    else if (AlertID == enum_Alerts.LeaveReject)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\nYour Leave Applied " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + " is Rejected " + sPersontype;
                        if (clsSecurity.EmployeeIDLoged == sEmpIDCovering1)
                            SEmailHeader_CoveringPerson1 = "Dear " + sName_Covering_1 + ",\n" + sName_Applied + "'s Leave Applied for " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + "\n is successfully rejected... !";
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDCovering2)
                            SEmailHeader_CoveringPerson2 = "Dear " + sName_Covering_2 + ",\n" + sName_Applied + "'s has Leave Applied for " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + "\n is successfully rejected... !";
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDChecked && clsSecurity.EmployeeIDLoged == sEmpIDApproved)
                            sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n" + sName_Applied + "'s  Leave Applied for " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + "\n is successfully rejected... !!";
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDApproved)
                            sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n" + sName_Applied + "'s Applied for a Leave " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + "\n is successfully rejected... !!";

                    }
                    #endregion
                    #region Approved Leave
                    else if (AlertID == enum_Alerts.LeaveApproved)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\nYour Leave Applied " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime) + " is Approved " + sPersontype;
                        if (clsSecurity.EmployeeIDLoged == sEmpIDCovering1)
                            SEmailHeader_CoveringPerson1 = "Dear " + sName_Covering_1 + ",\n You have confirmed as a Covering Person of " + sName_Applied + "'s Leave, Applied " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        if (clsSecurity.EmployeeIDLoged == sEmpIDCovering2)
                            SEmailHeader_CoveringPerson2 = "Dear " + sName_Covering_2 + ",\n You have confirmed as a Covering Person of " + sName_Applied + "'s Leave Applied " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        if (clsSecurity.EmployeeIDLoged == sEmpIDChecked)
                            sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n You have approved " + sName_Applied + "'s Leave Applied  for " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                        if (clsSecurity.EmployeeIDLoged == sEmpIDApproved)
                            sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n You have approved " + sName_Applied + "'s  Leave Applied for " + oLeave.Leave_Start.ToString(clsConfig.Format_DateTime) + " to " + oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                    }
                    #endregion

                    string sLeaveID = oLeave.Leave_ID;
                    string sEmployee = oLeave.Employee_ID + " - " + sName_Applied;
                    string sDate_LeaveStart = oLeave.Leave_Start.ToString(clsConfig.Format_DateTime);
                    string sDate_LeaveEnd = oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                    string sReason = oLeave.Reason;

                    #region Create details table
                    tblDetails.Rows.Add("", "", "");
                    tblDetails.Rows.Add("Leave ID", ":", sLeaveID);
                    tblDetails.Rows.Add("Employee", ":", sEmployee);
                    tblDetails.Rows.Add("Leave Start", ":", sDate_LeaveStart);
                    tblDetails.Rows.Add("Leave End", ":", sDate_LeaveEnd);

                    tblDetails.Rows.Add("Reason", ":", sReason);
                    tblDetails.Rows.Add("", "", "");
                    tblDetails.Rows.Add("Covering Person1", ":", sName_Covering_1);
                    tblDetails.Rows.Add("Covering Person2", ":", sName_Covering_2);
                    tblDetails.Rows.Add("Supervisor", ":", sName_Checked);
                    tblDetails.Rows.Add("Manager", ":", sName_Approved);
                    #endregion

                    #region Email - Aplicant

                    //int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                    //tbl_utlAlertMailBox_Pending Email1 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_Appliecent, enmColor, tblDetails), 0);
                    //Email1.Insert();
                    //tbl_utlAlertMailBox_Receiver EmailR1 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Applied, sEmail_Applied);
                    //EmailR1.Insert();

                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_Appliecent, enmColor, tblDetails), sName_Applied, sEmail_Applied);
                    #endregion

                    if (AlertID == enum_Alerts.LeaveApproved)
                    {
                        #region Covering Person 1
                        if (clsSecurity.UserIDLoged == sEmpIDCovering1)
                        {
                            if (oEmployee_Covering_1 != null)
                            {
                                //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                //tbl_utlAlertMailBox_Pending Email2 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson1, enmColor, tblDetails), 0);
                                //Email2.Insert();
                                //tbl_utlAlertMailBox_Receiver EmailR2 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Covering_1, sEmail_Covering_1);
                                //EmailR2.Insert();

                                SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson1, enmColor, tblDetails), sName_Covering_1, sEmail_Covering_1);
                            }
                        }
                        #endregion

                        #region Covering Person2
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDCovering2)
                        {
                            if (oEmployee_Covering_2 != null)
                            {
                                //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                //tbl_utlAlertMailBox_Pending Email3 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson2, enmColor, tblDetails), 0);
                                //Email3.Insert();
                                //tbl_utlAlertMailBox_Receiver EmailR3 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Covering_2, sEmail_Covering_2);
                                //EmailR3.Insert();

                                SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson2, enmColor, tblDetails), sName_Covering_2, sEmail_Covering_2);
                            }
                        }
                        #endregion

                        #region Supevisor
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDChecked)
                        {
                            if ((oEmployee_Applied.SupevisorID == oEmployee_Applied.ManagerID))
                            {
                                if (oEmployee_Approver != null)
                                {
                                    //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), 0);
                                    //Email5.Insert();
                                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Approved, sEmail_Approved);
                                    //EmailR5.Insert();

                                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                                }
                            }
                            else
                            {
                                if (oEmployee_Approver != null && oEmployee_Checked != null)
                                {
                                    //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                    //tbl_utlAlertMailBox_Pending Email4 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), 0);
                                    //Email4.Insert();
                                    //tbl_utlAlertMailBox_Receiver EmailR4 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Checked, sEmail_Checked);
                                    //EmailR4.Insert();

                                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), sName_Checked, sEmail_Checked);
                                }
                            }
                        }
                        #endregion

                        #region Manager
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDApproved)
                        {
                            if ((oEmployee_Applied.SupevisorID == oEmployee_Applied.ManagerID))
                            {
                                if (oEmployee_Approver != null)
                                {
                                    //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), 0);
                                    //Email5.Insert();
                                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Approved, sEmail_Approved);
                                    //EmailR5.Insert();

                                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                                }
                            }
                            else
                            {
                                if (oEmployee_Approver != null && oEmployee_Checked != null)
                                {
                                    //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), 0);
                                    //Email5.Insert();
                                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Approved, sEmail_Approved);
                                    //EmailR5.Insert();

                                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                                }
                            }
                        }
                        #endregion
                    }
                    else if (AlertID == enum_Alerts.LeaveReject)
                    {

                        #region Covering Person 1
                        if (clsSecurity.UserIDLoged == sEmpIDCovering1)
                        {
                            if (oEmployee_Covering_1 != null)
                            {
                                //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                //tbl_utlAlertMailBox_Pending Email2 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson1, enmColor, tblDetails), 0);
                                //Email2.Insert();
                                //tbl_utlAlertMailBox_Receiver EmailR2 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Covering_1, sEmail_Covering_1);
                                //EmailR2.Insert();

                                SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson1, enmColor, tblDetails), sName_Covering_1, sEmail_Covering_1);
                            }
                        }
                        #endregion

                        #region Covering Person2
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDCovering2)
                        {
                            if (oEmployee_Covering_2 != null)
                            {
                                //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                //tbl_utlAlertMailBox_Pending Email3 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson2, enmColor, tblDetails), 0);
                                //Email3.Insert();
                                //tbl_utlAlertMailBox_Receiver EmailR3 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Covering_2, sEmail_Covering_2);
                                //EmailR3.Insert();

                                SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson2, enmColor, tblDetails), sName_Covering_2, sEmail_Covering_2);
                            }
                        }
                        #endregion

                        #region Supevisor
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDChecked)
                        {
                            if ((oEmployee_Applied.SupevisorID == oEmployee_Applied.ManagerID))
                            {
                                if (oEmployee_Approver != null)
                                {
                                    //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), 0);
                                    //Email5.Insert();
                                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Approved, sEmail_Approved);
                                    //EmailR5.Insert();

                                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                                }
                            }
                            else
                            {
                                if (oEmployee_Approver != null && oEmployee_Checked != null)
                                {
                                    //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                    //tbl_utlAlertMailBox_Pending Email4 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), 0);
                                    //Email4.Insert();
                                    //tbl_utlAlertMailBox_Receiver EmailR4 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Checked, sEmail_Checked);
                                    //EmailR4.Insert();

                                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), sName_Checked, sEmail_Checked);
                                }
                            }
                        }
                        #endregion

                        #region Manager
                        else if (clsSecurity.EmployeeIDLoged == sEmpIDApproved)
                        {
                            if ((oEmployee_Applied.SupevisorID == oEmployee_Applied.ManagerID))
                            {
                                if (oEmployee_Approver != null)
                                {
                                    //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), 0);
                                    //Email5.Insert();
                                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Approved, sEmail_Approved);
                                    //EmailR5.Insert();

                                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                                }
                            }
                            else
                            {
                                if (oEmployee_Approver != null && oEmployee_Checked != null)
                                {
                                    //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), 0);
                                    //Email5.Insert();
                                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Approved, sEmail_Approved);
                                    //EmailR5.Insert();

                                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {

                        #region Covering Person 1
                        if (oEmployee_Covering_1 != null)
                        {
                            //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                            //tbl_utlAlertMailBox_Pending Email2 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson1, enmColor, tblDetails), 0);
                            //Email2.Insert();
                            //tbl_utlAlertMailBox_Receiver EmailR2 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Covering_1, sEmail_Covering_1);
                            //EmailR2.Insert();

                            SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson1, enmColor, tblDetails), sName_Covering_1, sEmail_Covering_1);
                        }
                        #endregion

                        #region Covering Person2
                        if (oEmployee_Covering_2 != null)
                        {
                            //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                            //tbl_utlAlertMailBox_Pending Email3 = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson2, enmColor, tblDetails), 0);
                            //Email3.Insert();
                            //tbl_utlAlertMailBox_Receiver EmailR3 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Covering_2, sEmail_Covering_2);
                            //EmailR3.Insert();

                            SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(SEmailHeader_CoveringPerson2, enmColor, tblDetails), sName_Covering_2, sEmail_Covering_2);
                        }
                        #endregion

                        if (oEmployee_Applied.SupevisorID == oEmployee_Applied.ManagerID)
                        {
                            if (oEmployee_Checked != null && oEmployee_Approver != null)
                            {
                                SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                            }
                        }
                        else
                        {
                            if (oEmployee_Checked != null)
                            {
                                SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), sName_Checked, sEmail_Checked);
                            }

                            if (oEmployee_Approver != null)
                            {
                                SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Email Generate for GatePass
        public static void CreateEmail_GatePass(enum_Alerts AlertID, string GPID, string sPersontype)
        {
            Colors enmColor = Colors.Updated;
            if (AlertID == enum_Alerts.GatePass_Applied)
                enmColor = Colors.New;
            if (AlertID == enum_Alerts.GatePass_updated)
                enmColor = Colors.Updated;
            if (AlertID == enum_Alerts.GatePass_Canceled)
                enmColor = Colors.Updated;
            if (AlertID == enum_Alerts.GatePass_Approved)
                enmColor = Colors.Approvd;
            if (AlertID == enum_Alerts.GatePass_Rejected)
                enmColor = Colors.rejected;


            tbl_utlAlert oAlert = tbl_utlAlert.Select((int)AlertID);
            if (oAlert != null && oAlert.IsActive)
            {
                tbl_tasTxGatePass oGatePass = tbl_tasTxGatePass.Select(clsSecurity.CompanyID, clsSecurity.BranchID, GPID.Trim());
                if (oGatePass != null && oGatePass.GatePass_ID != "default")
                {
                    DataTable tblDetails = new DataTable();
                    tblDetails.Columns.Add("0");
                    tblDetails.Columns.Add("1");
                    tblDetails.Columns.Add("2");

                    string sName_Applied = "", sName_Checked = "", sName_Approved = "";
                    string sEmail_Applied = "", sEmail_Checked = "", sEmail_Approved = "";
                    string sEmployeeID_Applied = "", sEmployeeID_Checked = "", sEmployeeID_Approved = "";

                    string sEmailHeder_Appliecent = "", sEmailHeder_CheckedUser = "", sEmailHeder_ApprovedUser = "";

                    #region Applied
                    tbl_genMasEmployee oEmployee_Applied = tbl_genMasEmployee.Select(oGatePass.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Applied != null)
                    {
                        sName_Applied = oEmployee_Applied.Initails + " " + oEmployee_Applied.SurName;
                        sEmail_Applied = oEmployee_Applied.Email_office;
                        sEmployeeID_Applied = oEmployee_Applied.Employee_ID;
                    }
                    #endregion

                    #region Checked
                    tbl_genMasEmployee oEmployee_Checked = tbl_genMasEmployee.Select(oGatePass.UserID_Supevisor, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Checked != null)
                    {
                        sName_Checked = oEmployee_Checked.Initails + " " + oEmployee_Checked.SurName;
                        sEmail_Checked = oEmployee_Checked.Email;
                        sEmployeeID_Checked = oEmployee_Checked.Employee_ID;
                    }
                    #endregion

                    #region Approved
                    tbl_genMasEmployee oEmployee_Approved = tbl_genMasEmployee.Select(oGatePass.UserID_Manager, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Approved != null)
                    {
                        sName_Approved = oEmployee_Approved.Initails + " " + oEmployee_Approved.SurName;
                        sEmail_Approved = oEmployee_Approved.Email_office;
                        sEmployeeID_Approved = oEmployee_Approved.Employee_ID;
                    }
                    #endregion

                    string sEmailSubject = "Gate Pass Requested - " + sName_Applied + " on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + cls_Formater.FormatDecimal(((oGatePass.Leave_Hours) / 60), 2) + " Hours";

                    if (AlertID == enum_Alerts.GatePass_Applied)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\n Your Gate Pass Applied on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + cls_Formater.FormatDecimal(((oGatePass.Leave_Hours) / 60), 2) + " Hours is pending Approval";
                        sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n" + sName_Applied + " has Applied for a Gate Pass on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + ((oGatePass.Leave_Hours) / 60) + " Hours" + "\nPlease check it as a Supervisor... !!";
                        sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n" + sName_Applied + " has Applied for a Gate Pass on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + ((oGatePass.Leave_Hours) / 60) + " Hours" + "\nPlease Approve it as a Manager... !!";
                    }
                    else if (AlertID == enum_Alerts.GatePass_updated)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\n Your Updated Gate Pass Applied (Gatepass ID - '" + oGatePass.GatePass_ID + "') on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + cls_Formater.FormatDecimal(((oGatePass.Leave_Hours) / 60), 2) + " Hours is pending Approval";
                        sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n" + sName_Applied + " has Updated Applied Gate Pass (Gatepass ID - '" + oGatePass.GatePass_ID + "') on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + ((oGatePass.Leave_Hours) / 60) + " Hours" + "\nPlease Check it as a Supervisor... !!";
                        sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n" + sName_Applied + " has Updated Applied Gate Pass (Gatepass ID - '" + oGatePass.GatePass_ID + "') on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + ((oGatePass.Leave_Hours) / 60) + " Hours" + "\nPlease Approve it as a Manager... !!";
                    }
                    else if (AlertID == enum_Alerts.GatePass_Approved)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\n Your Gate Pass Applied on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_DateTime) + " for " + cls_Formater.FormatDecimal(((oGatePass.Leave_Hours) / 60), 2) + " Hours is Approved " + sPersontype;
                        sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n You have approved " + sName_Applied + "'s Gate Pass on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_DateTime) + " for " + ((oGatePass.Leave_Hours) / 60) + " Hours";
                        sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n You have approved " + sName_Applied + "'s Gate Pass on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_DateTime) + " for " + ((oGatePass.Leave_Hours) / 60) + " Hours";
                    }
                    else if (AlertID == enum_Alerts.GatePass_Rejected)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\n Your Gate Pass Applied on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_DateTime) + " for " + cls_Formater.FormatDecimal(((oGatePass.Leave_Hours) / 60), 2) + " Hours is Rejected" + sPersontype;
                        sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n" + sName_Applied + "'s Gate Pass Applied for " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_DateTime) + " for " + ((oGatePass.Leave_Hours) / 60) + " Successfully Rejected !";
                        sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n" + sName_Applied + "'s Gate Pass Applied for " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_DateTime) + " for " + ((oGatePass.Leave_Hours) / 60) + " Successfully Rejected !";
                    }
                    else if (AlertID == enum_Alerts.GatePass_Canceled)
                    {
                        sEmailHeder_Appliecent = "Dear " + sName_Applied + ",\n Your Gate Pass Applied on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + cls_Formater.FormatDecimal(((oGatePass.Leave_Hours) / 60), 2) + " Hours is Successfully Cancled";
                        sEmailHeder_CheckedUser = "Dear " + sName_Checked + ",\n" + sName_Applied + " has Cancled Gate Pass on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + ((oGatePass.Leave_Hours) / 60) + " Hours";
                        sEmailHeder_ApprovedUser = "Dear " + sName_Approved + ",\n" + sName_Applied + " has Cancled  Gate Pass on " + oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date) + " for " + ((oGatePass.Leave_Hours) / 60) + " Hours";
                    }
                    string sGpID = oGatePass.GatePass_ID;
                    string sEmployee = oGatePass.Employee_ID + " - " + sName_Applied;
                    string sDate_GPSDate = oGatePass.GatePass_DateTime.ToString(clsConfig.Format_DateTime);
                    decimal iHrs = ((oGatePass.Leave_Hours) / 60);
                    string sHrs_GP = cls_Formater.FormatDecimal(iHrs, 2); //iHrs.ToString();
                    string sReason = oGatePass.Reason;

                    #region Fill details table
                    tblDetails.Rows.Add("", "", "");
                    tblDetails.Rows.Add("Gate Pass ID", ":", sGpID);
                    tblDetails.Rows.Add("Employee", ":", sEmployee);
                    tblDetails.Rows.Add("Date", ":", sDate_GPSDate);
                    tblDetails.Rows.Add("Leave Hours", ":", sHrs_GP);

                    tblDetails.Rows.Add("Reason", ":", sReason);
                    tblDetails.Rows.Add("", "", "");
                    tblDetails.Rows.Add("Supervisor", ":", sName_Checked);
                    tblDetails.Rows.Add("Manager", ":", sName_Approved);
                    #endregion

                    #region Email - Aplicant
                    //int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                    //tbl_utlAlertMailBox_Pending Email1 = new tbl_utlAlertMailBox_Pending(Emailid, (int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_Appliecent, enmColor, tblDetails), 0);
                    //Email1.Insert();
                    //tbl_utlAlertMailBox_Receiver EmailR1 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Applied, sEmail_Applied);
                    //EmailR1.Insert();

                    SaveMailHTML((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_Appliecent, enmColor, tblDetails), sName_Applied, sEmail_Applied);
                    #endregion

                    #region Email - Checked
                    if (oEmployee_Checked != null && (oEmployee_Applied.SupevisorID == oEmployee_Applied.ManagerID))
                    {
                        //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                        //tbl_utlAlertMailBox_Pending Email4 = new tbl_utlAlertMailBox_Pending(Emailid, (int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), 0);
                        //Email4.Insert();
                        //tbl_utlAlertMailBox_Receiver EmailR4 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Approved, sEmail_Approved);
                        //EmailR4.Insert();

                        SaveMailHTML((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);

                    }
                    else
                    {
                        //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                        //tbl_utlAlertMailBox_Pending Email4 = new tbl_utlAlertMailBox_Pending(Emailid, (int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), 0);
                        //Email4.Insert();
                        //tbl_utlAlertMailBox_Receiver EmailR4 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Checked, sEmail_Checked);
                        //EmailR4.Insert();

                        SaveMailHTML((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_CheckedUser, enmColor, tblDetails), sName_Checked, sEmail_Checked);
                    }
                    #endregion

                    #region Email - Approved
                    if (oEmployee_Approved != null && (oEmployee_Applied.SupevisorID != oEmployee_Applied.ManagerID))
                    {
                        //Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                        //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, (int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), 0);
                        //Email5.Insert();
                        //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, sName_Approved, sEmail_Approved);
                        //EmailR5.Insert();

                        SaveMailHTML((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_ApprovedUser, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Old method - Gatepass updated
        //public static void CreateEmail_Test(string Mes, string email)
        //{
        //    Colors enmColor = Colors.New;

        //    int iAlert_ID = (int)enum_Alerts.GatePass_updated;
        //    tbl_utlAlert oAlert = tbl_utlAlert.Select(iAlert_ID);
        //    if (oAlert != null && oAlert.IsActive)
        //    {
        //        tbl_tasTxGatePass oGatePass = tbl_tasTxGatePass.Select("GP/0016", clsSecurity.CompanyID, clsSecurity.BranchID);
        //        if (oGatePass != null && oGatePass.GatePass_ID != "default")
        //        {
        //            string sEmailHheder = "HI..!\nThis is a test mail generated by the SEACC System\nYour Messege : " + Mes;
        //            string sGatePass_ID = oGatePass.GatePass_ID;
        //            string sEmployee = oGatePass.Employee_ID + " - " + clsRef_Name.get_EmployeeName(oGatePass.Employee_ID);
        //            string sDate_Time = oGatePass.GatePass_DateTime.ToShortDateString();
        //            string sLeaveHours = oGatePass.Leave_Hours.ToString();
        //            string sReason = oGatePass.Reason;

        //            DataTable tblDetails = new DataTable();
        //            tblDetails.Columns.Add("0");
        //            tblDetails.Columns.Add("1");
        //            tblDetails.Columns.Add("2");

        //            tblDetails.Rows.Add("Created By", ":", clsSecurity.UserIDLoged);
        //            tblDetails.Rows.Add("Created Time", ":", clsSecurity.getServerDateTime());

        //            string sBodyHTML = clsEmailEngine.CreateEmailBody(sEmailHheder, enmColor, tblDetails);

        //            //int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
        //            //tbl_utlAlertMailBox_Pending Email = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, "", sBodyHTML, 0);
        //            //Email.Insert();
        //            //tbl_utlAlertMailBox_Receiver emailR = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, "", email);
        //            //emailR.Insert();

        //            SaveMailHTML(iAlert_ID, "", sBodyHTML, "", email);
        //        }
        //    }
        //} 
        #endregion

        public static void CreateEmail_AttendanceRecord_Update(string LeaveID)
        {
            Colors enmColor = Colors.Updated;

            int iAlert_ID = (int)enum_Alerts.AttendanceRecordUpdate;
            tbl_utlAlert oAlert = tbl_utlAlert.Select(iAlert_ID);
            if (oAlert != null && oAlert.IsActive)
            {
                tbl_tasEmployeeLeaveCard oLeave = tbl_tasEmployeeLeaveCard.Select(LeaveID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oLeave != null && oLeave.Leave_ID != "default")
                {
                    #region Applied
                    string sName_Applied = "";
                    string sEmail_Applied = "";
                    tbl_genMasEmployee oEmployee_Applied = tbl_genMasEmployee.Select(oLeave.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Applied != null)
                    {
                        sName_Applied = oEmployee_Applied.Initails + " " + oEmployee_Applied.SurName;
                        sEmail_Applied = oEmployee_Applied.Email;
                    }
                    #endregion

                    #region Approved
                    string sName_Approved = "";
                    string sEmail_Approved = "";
                    tbl_genMasEmployee oEmployee_Approver = tbl_genMasEmployee.Select(oLeave.UserID_Manager, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Approver != null)
                    {
                        sName_Approved = oEmployee_Approver.Initails + " " + oEmployee_Approver.SurName;
                        sEmail_Approved = oEmployee_Approver.Email;
                    }
                    #endregion

                    #region Checked
                    string sName_Checked = "";
                    string sEmail_Checked = "";
                    tbl_genMasEmployee oEmployee_Checked = tbl_genMasEmployee.Select(oLeave.UserID_Manager, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Checked != null)
                    {
                        sName_Checked = oEmployee_Checked.Initails + " " + oEmployee_Checked.SurName;
                        sEmail_Checked = oEmployee_Checked.Email;
                    }
                    #endregion

                    #region Covering_1
                    string sName_Covering_1 = "";
                    string sEmail_Covering_1 = "";
                    tbl_genMasEmployee oEmployee_Covering_1 = tbl_genMasEmployee.Select(oLeave.UserID_CP1, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Checked != null)
                    {
                        sName_Covering_1 = oEmployee_Covering_1.Initails + " " + oEmployee_Covering_1.SurName;
                        sEmail_Covering_1 = oEmployee_Covering_1.Email;
                    }
                    #endregion

                    #region Covering_2
                    string sName_Covering_2 = "";
                    string sEmail_Covering_2 = "";
                    tbl_genMasEmployee oEmployee_Covering_2 = tbl_genMasEmployee.Select(oLeave.UserID_CP2, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployee_Checked != null)
                    {
                        sName_Covering_2 = oEmployee_Covering_2.FullName;
                        sEmail_Covering_2 = oEmployee_Covering_2.Email;
                    }
                    #endregion

                    string sEmailSubject = "Update of Leave Requested - " + sName_Applied + " " + oLeave.Leave_Start + " to " + oLeave.Leave_End + "(Leave ID - " + oLeave.Leave_ID + ")";

                    string sEmailHeder_AppliedUser = "Dear " + sName_Applied + ",\nYour Updated Leave Applied (Leave ID - " + oLeave.Leave_ID + ")" + oLeave.Leave_Start + " to " + oLeave.Leave_End + " is Pending Approval";
                    string sEmailHeder_Covering1 = "Dear " + sName_Covering_1 + ",\n" + sName_Applied + " has Nominate you as a Covering Person for Updated Leave Applied (Leave ID - " + oLeave.Leave_ID + ") " + oLeave.Leave_Start + " to " + oLeave.Leave_End;
                    string sEmailHeder_Covering2 = "Dear " + sName_Covering_2 + ",\n" + sName_Applied + " has Nominate you as a Covering Person for Updated Leave Applied (Leave ID - " + oLeave.Leave_ID + ") " + oLeave.Leave_Start + " to " + oLeave.Leave_End;
                    string sEmailHeder_Checked = "Dear " + sName_Checked + ",\n" + sName_Applied + " has Updated Applied for a Leave (Leave ID - " + oLeave.Leave_ID + ") " + oLeave.Leave_Start + " to " + oLeave.Leave_End + "\nPlease Check it as a Supervisor... !!";
                    string sEmailHeder_Approved = "Dear " + sName_Approved + ",\n" + sName_Applied + " has Updated Applied for a Leave " + oLeave.Leave_Start + " to " + oLeave.Leave_End + "\nPlease Approve it as a Manager... !!";

                    string sLeaveID = oLeave.Leave_ID;
                    string sEmployee = oLeave.Employee_ID + " - " + sName_Applied;
                    string sDate_LeaveStart = oLeave.Leave_Start.ToString(clsConfig.Format_DateTime);
                    string sDate_LeaveEnd = oLeave.Leave_End.ToString(clsConfig.Format_DateTime);
                    string sReason = oLeave.Reason;

                    #region Create details table
                    DataTable tblDetails = new DataTable();
                    tblDetails.Columns.Add("0");
                    tblDetails.Columns.Add("1");
                    tblDetails.Columns.Add("2");

                    tblDetails.Rows.Add("", "", "");
                    tblDetails.Rows.Add("Leave ID", ":", sLeaveID);
                    tblDetails.Rows.Add("Employee", ":", sEmployee);
                    tblDetails.Rows.Add("Leave Start", ":", sDate_LeaveStart);
                    tblDetails.Rows.Add("Leave End", ":", sDate_LeaveEnd);
                    //  tblDetails.Rows.Add("No of days", ":", sDate_LeaveEnd);
                    tblDetails.Rows.Add("Reason", ":", sReason);
                    tblDetails.Rows.Add("", "", "");
                    tblDetails.Rows.Add("Covering Person1", ":", sName_Covering_1);
                    tblDetails.Rows.Add("Covering Person2", ":", sName_Covering_2);
                    tblDetails.Rows.Add("Supervisor", ":", sName_Checked);
                    tblDetails.Rows.Add("Manager", ":", sName_Approved);
                    #endregion

                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_AppliedUser, enmColor, tblDetails), sName_Applied, sEmail_Applied);
                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_Covering1, enmColor, tblDetails), sName_Covering_1, sEmail_Covering_1);
                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_Covering2, enmColor, tblDetails), sName_Covering_2, sEmail_Covering_2);
                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_Checked, enmColor, tblDetails), sName_Checked, sEmail_Checked);
                    SaveMailHTML(iAlert_ID, sEmailSubject, clsEmailEngine.CreateEmailBody(sEmailHeder_Approved, enmColor, tblDetails), sName_Approved, sEmail_Approved);
                }
            }
        }

        public static void CreateEmail_ChangedPassword(string changeAccountUserID, string newPassword)
        {
            Colors enmColor = Colors.New;
            string pw = "";

            int iAlert_ID = (int)enum_Alerts.PasswordChanged;
            tbl_utlAlert oAlert = tbl_utlAlert.Select(iAlert_ID);

            if (oAlert != null && oAlert.IsActive)
            {
                tbl_securityUserMaster recordlogedUser = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);
                tbl_securityUserMaster recordAccountOwner = tbl_securityUserMaster.Select(changeAccountUserID);
                tbl_securityUserMaster recordAdmin = tbl_securityUserMaster.Select("admin"); ;

                if (recordlogedUser != null && recordlogedUser != null)
                {
                    #region Content Of Email
                    string sEmailHheder = "PASSWORD CHANGED";

                    DataTable tblDetails = new DataTable();
                    tblDetails.Columns.Add("0");
                    tblDetails.Columns.Add("1");
                    tblDetails.Columns.Add("2");
                    tblDetails.Rows.Add("Changed By   ", ":", clsSecurity.UserIDLoged);
                    tblDetails.Rows.Add("Account Owner", ":", changeAccountUserID);
                    tblDetails.Rows.Add("Changed Time ", ":", clsSecurity.getServerDateTime());
                    tblDetails.Rows.Add("New Password ", ":", pw);
                    #endregion

                    #region Save Email in DataBase
                    string sBodyHTML = clsEmailEngine.CreateEmailBody(sEmailHheder, enmColor, tblDetails);

                    SaveMailHTML(iAlert_ID, sEmailHheder, sBodyHTML, recordAccountOwner.UserName, recordAccountOwner.Email);
                    #endregion
                }
            }
        }

        public static void CreateEmail_ForgotPassword(string name, string empID, string depatment, string designation, string emailAddress, string mobileNo)
        {
            Colors enmColor = Colors.Updated;
            int iAlert_ID = (int)enum_Alerts.ForgotPassword;
            tbl_utlAlert oAlert = tbl_utlAlert.Select(iAlert_ID);

            if (oAlert != null && oAlert.IsActive)
            {
                #region Content Of Email
                string sEmailHheder = "Forgot Password Change Request";

                DataTable tblDetails = new DataTable();
                tblDetails.Columns.Add("0");
                tblDetails.Columns.Add("1");
                tblDetails.Columns.Add("2");
                tblDetails.Columns.Add("3");
                tblDetails.Columns.Add("4");
                tblDetails.Columns.Add("5");
                tblDetails.Rows.Add("Name   ", ":", name);
                tblDetails.Rows.Add("Employee ID", ":", empID);
                tblDetails.Rows.Add("Department", ":", depatment);
                tblDetails.Rows.Add("Designation", ":", depatment);
                tblDetails.Rows.Add("Email Address ", ":", emailAddress);
                tblDetails.Rows.Add("Mobile Address ", ":", emailAddress);
                #endregion

                #region Save Email in DataBase
                string sBodyHTML = clsEmailEngine.CreateEmailBody(sEmailHheder, enmColor, tblDetails);

                //int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                //tbl_utlAlertMailBox_Pending emailP = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, "", sBodyHTML, 0);
                //emailP.Insert();
                //tbl_utlAlertMailBox_Receiver emailR = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, name, clsSecurity.DigiteqEmail);
                //emailR.Insert();

                SaveMailHTML(iAlert_ID, sEmailHheder, sBodyHTML, name, clsSecurity.DigiteqEmail);
                #endregion
            }
        }

        public static void CreateEmail_RequestAccount(string name, string empID, string depatment, string designation, string emailAddress, string mobileNo)
        {
            Colors enmColor = Colors.Updated;
            int iAlert_ID = (int)enum_Alerts.RequestNewAccount;
            tbl_utlAlert oAlert = tbl_utlAlert.Select(iAlert_ID);

            if (oAlert != null && oAlert.IsActive)
            {
                #region Content Of Email
                string sEmailHheder = "Requseting a New Account";

                DataTable tblDetails = new DataTable();
                tblDetails.Columns.Add("0");
                tblDetails.Columns.Add("1");
                tblDetails.Columns.Add("2");
                tblDetails.Columns.Add("3");
                tblDetails.Columns.Add("4");
                tblDetails.Columns.Add("5");
                tblDetails.Rows.Add("Name   ", ":", name);
                tblDetails.Rows.Add("Employee ID", ":", empID);
                tblDetails.Rows.Add("Department", ":", depatment);
                tblDetails.Rows.Add("Designation", ":", depatment);
                tblDetails.Rows.Add("Email Address ", ":", emailAddress);
                tblDetails.Rows.Add("Mobile Address ", ":", emailAddress);
                #endregion

                #region Save Email in DataBase
                string sBodyHTML = clsEmailEngine.CreateEmailBody(sEmailHheder, enmColor, tblDetails);

                //int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                //tbl_utlAlertMailBox_Pending emailP = new tbl_utlAlertMailBox_Pending(Emailid, iAlert_ID, "", sBodyHTML, 0);
                //emailP.Insert();
                //tbl_utlAlertMailBox_Receiver emailR = new tbl_utlAlertMailBox_Receiver(Emailid, 1, 1, name, clsSecurity.DigiteqEmail);
                //emailR.Insert();

                SaveMailHTML(iAlert_ID, sEmailHheder, sBodyHTML, name, clsSecurity.DigiteqEmail);
                #endregion
            }
        }

        public static int CreateEmail_BirthdayListOfEmploees(enum_Alerts AlertID, DateTime dtm, DataTable dtEmployees, string sEmailSubject, string sEmail_To)
        {
            int iEmailID = -1;
            tbl_utlAlert oAlert = tbl_utlAlert.Select((int)AlertID);
            if (oAlert != null && oAlert.IsActive)
            {
                string sEmpCount = dtEmployees.Rows.Count.ToString();
                string sFooter = "";
                Colors enmColor = Colors.New;

                string sBody = clsEmailEngine.CreateEmailBody_Common(sEmailSubject, "", "", enmColor, dtEmployees);
                sBody = sBody.Replace("No. of payslips:", "");
                sBody = sBody.Replace("<b>Important</b> !!", "");

                iEmailID = SaveMailHTML((int)AlertID, sEmailSubject, sBody, "Sir", sEmail_To);
            }
            return iEmailID;
        }

        #endregion

        #region Schedule Alerts
        /****************** 
         * SCHEDULE ALERTS
         ******************/
        public static void CreateEmail_DailyHeadCount(DateTime date)
        {
            //public static void CreateEmail_DailyHeadCount(DateTime date, string sReceievr_Name, string sReceiver_Email, SendMailTypes eType){
            bool bEmailStatus = false;

            enum_Alerts AlertID = enum_Alerts.DailyHeadCount;
            tbl_utlAlert oAlert = tbl_utlAlert.Select((int)AlertID);
            if (oAlert != null && oAlert.IsActive)
                try
                {
                    string qry = "sp_getEmployeeHeadCount_fromRawData '" + clsSecurity.CompanyID + "', '" + clsSecurity.BranchID + "', '" + date.Date + "' , '" + date.Date + "', '%', '%', '%', '%', '%', '%', '%' , '%'";
                    DataTable dt_DbResults = DBHandling.ExecQuery(qry).Tables[0];

                    DataTable tblDetails = new DataTable();
                    tblDetails.Columns.Add("Department");
                    tblDetails.Columns.Add("Total", typeof(int));
                    tblDetails.Columns.Add("Present", typeof(int));
                    tblDetails.Columns.Add("Absent", typeof(int));
                    tblDetails.Columns.Add("Leave", typeof(int));
                    foreach (tbl_genMasDepartment oDept in tbl_genMasDepartment.SelectAllByCompany_ID_CompanyBranch_ID(clsSecurity.CompanyID, clsSecurity.BranchID))
                    {
                        DataRow[] records = dt_DbResults.Select("department_ID = '" + oDept.Department_ID + "'");
                        int iPresentRecords = records.Length;
                        int iTotRecords = tbl_genMasEmployee.SelectAll().Where(r => r.Department_ID == oDept.Department_ID && r.Emp_statusID.Trim() != ((int)EmployeeStatus.Resigned).ToString().Trim() && r.Employee_ID != "default").Count();
                        int iApprovedLeaves = 0;
                        foreach (tbl_genMasEmployee record in tbl_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString() && p.Department_ID == oDept.Department_ID))
                        {
                            iApprovedLeaves += tbl_tasEmployeeLeaveCard.SelectAll().Where(r => r.Leave_Start.Date == date.Date && r.Employee_ID == record.Employee_ID).Count();
                        }
                        int iAbsRecords = iTotRecords - iPresentRecords - iApprovedLeaves;

                        tblDetails.Rows.Add(oDept.DepartmentName, iTotRecords, iPresentRecords, iAbsRecords, iApprovedLeaves);

                    }

                    int empTot_All = tblDetails.AsEnumerable().Sum(row => row.Field<int>("Total"));
                    int empTot_Present = tblDetails.AsEnumerable().Sum(row => row.Field<int>("Present"));
                    int empTot_Abs = tblDetails.AsEnumerable().Sum(row => row.Field<int>("Absent"));
                    int empTot_Leaves = tblDetails.AsEnumerable().Sum(row => row.Field<int>("Leave"));
                    tblDetails.Rows.Add("Total", empTot_All, empTot_Present, empTot_Abs, empTot_Leaves);

                    Colors enmColor = Colors.New;
                    string sEmailSubject = "Daily Head Count on " + date.ToString(clsConfig.Format_Date);

                    //int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, (int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody_DailyStatus(sEmailSubject, enmColor, tblDetails), 0);
                    //Email5.Insert();
                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, (int)eType, sReceievr_Name, sReceiver_Email);
                    //EmailR5.Insert();

                    bEmailStatus = SaveMailHTML_ScheduledAlerts((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody_DailyStatus(sEmailSubject, enmColor, tblDetails));

                    if (bEmailStatus)
                        UpdateAlertSentTime(AlertID, true);
                }
                catch (Exception ex)
                {
                    UpdateAlertSentTime(AlertID, false);
                }

            //DataTable a = tblDetails;
        }

        public static void CreateEmail_DailyPresentEmployees_DeptWise(DateTime date)
        {
            //public static void CreateEmail_DailyPresentEmployees_DeptWise(DateTime date, string sReceievr_Name, string sReceiver_Email, SendMailTypes eType) { 

            bool bEmailStatus = false;
            enum_Alerts AlertID = enum_Alerts.DailyPrecences;
            tbl_utlAlert oAlert = tbl_utlAlert.Select((int)AlertID);
            if (oAlert != null && oAlert.IsActive)
                try
                {
                    DataTable tblDetails = new DataTable();
                    //tblDetails.Columns.Add("Employee Id");
                    tblDetails.Columns.Add("EPF No");
                    tblDetails.Columns.Add("Employee Name");
                    tblDetails.Columns.Add("Alias Name");
                    tblDetails.Columns.Add("Designation");
                    //tblDetails.Columns.Add("In Time");
                    //tblDetails.Columns.Add("Manager");

                    List<tbl_genMasEmployee> oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default" && p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                    foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.IsTime_Attendance == true && p.Department_ID == "DEP/031"))
                    {
                        DataTable dtAttenResult = DBHandling.ExecQuery("select * from [tbl_tasTxDeviceRawData] where [device_empID] = '" + oEmployee.Employee_ID2 + "' AND cast( [device_DateTime] as date) = '" + date.Date + "' ").Tables[0];
                        dtAttenResult.AsEnumerable().OrderBy(r => r.Field<DateTime>("device_DateTime")).Distinct().ToList().FirstOrDefault();
                        if (dtAttenResult.Rows.Count >= 1)
                        {
                            tblDetails.Rows.Add(
                                oEmployee.EpfNo == "" ? " - " : oEmployee.EpfNo,
                                oEmployee.SurName + " " + oEmployee.Initails + ". ",
                                oEmployee.AliasName == "" ? "-" : oEmployee.AliasName + " ",
                                clsRef_Name.get_Designation_Name(oEmployee.Designation_ID) + " "
                                //DateTime.Parse(dtAttenResult.AsEnumerable().OrderBy(r => r.Field<DateTime>("device_DateTime")).Distinct().ToList().FirstOrDefault()["device_DateTime"].ToString()).ToString("hh: mm tt")
                                );
                        }
                    }

                    Colors enmColor = Colors.New;
                    string sEmailSubject = "Digiteq Solutions (Pvt) Ltd - Attendance on " + date.ToString("dddd, dd MMMM yyyy hh:mm tt");

                    //int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, (int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody_DailyStatus(sEmailSubject, enmColor, tblDetails), 0);
                    //Email5.Insert();
                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, (int)eType, sReceievr_Name, sReceiver_Email);
                    //EmailR5.Insert();

                    bEmailStatus = SaveMailHTML_ScheduledAlerts((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody_DailyStatus(sEmailSubject, enmColor, tblDetails));
                    if (bEmailStatus)
                        UpdateAlertSentTime(AlertID, true);
                }
                catch
                {
                    UpdateAlertSentTime(AlertID, false);
                }
        }

        public static void CreateEmail_PayrollProcessed(DateTime date)
        {
            //public static void CReateEmail_PayrollProcessed(DateTime date, string sReceievr_Name, string sReceiver_Email, SendMailTypes eType){

            bool bEmailStatus = false;

            enum_Alerts AlertID = enum_Alerts.Payroll_Processed;
            tbl_utlAlert oAlert = tbl_utlAlert.Select((int)AlertID);
            if (oAlert != null && oAlert.IsActive)
            {
                try
                {
                    DataTable tblDetails = new DataTable();
                    tblDetails.Columns.Add("Payroll Period");
                    tblDetails.Columns.Add("No. of Employees", typeof(int));

                    string sPayrollPeriod = date.AddMonths(-1).ToString("Y");
                    string sEmpCount = DBHandling.ExecQuery_ReturnStringValue(" SELECT count([employee_ID]) " +
                                 "FROM[tbl_payTxSIPRawData] " +
                                 "where DATEPART(yyyy,[processPeriod_Sub_startDate]) = DATEPART(yyyy, '" + date.Date.AddMonths(-1) + "') " +
                                 "AND DATEPART(MM,[processPeriod_Sub_startDate]) = DATEPART(MM, '" + date.Date.AddMonths(-1) + "')  ");
                    tblDetails.Rows.Add(sPayrollPeriod, int.Parse(sEmpCount));

                    Colors enmColor = Colors.Approvd;
                    string sEmailSubject = clsSecurity.CompanyName + " - Payroll Processed";

                    //int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                    //tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, (int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody_DailyStatus(sEmailSubject, enmColor, tblDetails), 0);
                    //Email5.Insert();
                    //tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, 1, (int)eType, sReceievr_Name, sReceiver_Email);
                    //EmailR5.Insert();

                    bEmailStatus = SaveMailHTML_ScheduledAlerts((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody_DailyStatus(sEmailSubject, enmColor, tblDetails));

                    if (bEmailStatus)
                        UpdateAlertSentTime(AlertID, true);
                }
                catch
                {
                    UpdateAlertSentTime(AlertID, false);
                }
            }
        }

        public static void CreateEmail_MonthlySoftwarePayment(DateTime date)
        {
            //public static void CReateEmail_MonthlySoftwarePayment(DateTime date, int iReceiverIndex, string sReceievr_Name, string sReceiver_Email, SendMailTypes eType){
            bool bEmailStatus = false;

            enum_Alerts AlertID = enum_Alerts.Monthly_Software_Payment;
            tbl_utlAlert oAlert = tbl_utlAlert.Select((int)AlertID);
            if (oAlert != null && oAlert.IsActive)
            {
                try
                {
                    DataTable dtTblDetails = new DataTable();

                    string sPayrollPeriod = date.AddMonths(-1).ToString("Y");                    
                    string sCompanyName = clsSecurity.CompanyName;
                    string sQuary = "exec [sp_Monthly_Software_Payment] '" + date.Date.Year + "','" + date.Date.AddMonths(-1).Month + "'";

                    dtTblDetails = DBHandling.ExecQuery(sQuary).Tables[0];

                    string sEmpCount = DBHandling.ExecQuery_ReturnStringValue(" SELECT count([employee_ID]) " +
                                 "FROM[tbl_payTxSIPRawData] " +
                                 "where DATEPART(yyyy,[processPeriod_Sub_startDate]) = DATEPART(yyyy, '" + date.Date.AddMonths(-1) + "') " +
                                 "AND DATEPART(MM,[processPeriod_Sub_startDate]) = DATEPART(MM, '" + date.Date.AddMonths(-1) + "')  ");
                    string sNoofPayslip = "No. of payslips: " + sEmpCount;

                    Colors enmColor = Colors.Warning;
                    string sEmailSubject = "Monthly Software Payments for " + sPayrollPeriod + " | " + sCompanyName;
                    string sFooter = "<b>Important !!</b>\n Please release the monthly software Subscription Payment above " + sEmpCount + " payslip within 7 days of this system generated notice.. For non payment of this reminder your payroll payslip printing will be blocked on 8th day of this reminder date. For reactivation of the payslip printing and additional charge of rupees 500 per employee will be charged. Also there will be a payment delay of 1 % per week for non payment of monthly payment subscription. ";

                    bEmailStatus = SaveMailHTML_ScheduledAlerts((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody_Common(sEmailSubject, sNoofPayslip, sFooter, enmColor, dtTblDetails));

                    if (bEmailStatus)
                        UpdateAlertSentTime(AlertID, true);
                }
                catch
                {
                    UpdateAlertSentTime(AlertID, false);
                }
            }
        }

        public static void CreateEmail_ProbationPeriod_End(DateTime date)
        {
            bool bEmailStatus = false;

            enum_Alerts AlertID = enum_Alerts.ProbationPeriod_End;
            tbl_utlAlert oAlert = tbl_utlAlert.Select((int)AlertID);
            if (oAlert != null && oAlert.IsActive)
            {
                try
                {
                    DataTable dtTblDetails = new DataTable();

                    string sProbationPeriod = date.ToString("Y");
                    DateTime dStartDate = new DateTime(date.Year, date.Month, 1);
                    DateTime dEndDate = dStartDate.AddMonths(1).AddDays(-1);

                    string sQuary = "exec [sp_ProbationPeriod_End] '" + dStartDate.Date + "','" + dEndDate.Date + "'";
                    dtTblDetails = DBHandling.ExecQuery(sQuary).Tables[0];

                    Colors enmColor = Colors.Approvd;
                    string sEmailSubject = "Probation Period Ending Employees in " + sProbationPeriod;

                    bEmailStatus = SaveMailHTML_ScheduledAlerts((int)AlertID, sEmailSubject, clsEmailEngine.CreateEmailBody_Common(sEmailSubject, "", "", enmColor, dtTblDetails));

                    if (bEmailStatus)
                        UpdateAlertSentTime(AlertID, true);
                }
                catch
                {
                    UpdateAlertSentTime(AlertID, false);
                }
            }
        } 
        #endregion

        #region Save Schedule Mails
        public static bool SaveMailHTML_ScheduledAlerts(int iAlertID, string sEmailSubject, string sBodyHTML)
        {
            bool status = false;
            try
            {
                int Emailid = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                tbl_utlAlertMailBox_Pending Email5 = new tbl_utlAlertMailBox_Pending(Emailid, iAlertID, sEmailSubject, sBodyHTML, 0);
                Email5.Insert();

                foreach (tbl_utlAlert_detail sett in tbl_utlAlert_detail.SelectAllByAlert_ID(iAlertID))
                {
                    tbl_utlAlertMailBox_Receiver EmailR5 = new tbl_utlAlertMailBox_Receiver(Emailid, sett.Setting_ID, (int)sett.ReceiverType, sett.PersonName, sett.UserEmail1);
                    EmailR5.Insert();
                }

                status = true;
                clsValidation.WriteErrorLog(Emailid.ToString());
            }
            catch (Exception ex)
            {
                clsValidation.WriteErrorLog(iAlertID + " - Alert Save failed - " + ex.Message);
            }
            return status;
        }
        #endregion

        #region Shedule Alerts - Help Methods
        public static void Checking_SheduledAlerts()
        {
            foreach (tbl_utlAlert_Shedule oShedule in tbl_utlAlert_Shedule.SelectAll().Where(p => p.IsActive))
            {
                int iAlert = (oShedule.Alert_ID);

                bool value = false;
                tbl_utlAlert oAlert = tbl_utlAlert.Select(oShedule.Alert_ID);
                int iAlertID = oAlert.Alert_ID;

                DateTime dtmTodayAlert_Time = clsValidation.Merge_DateAndTime(DateTime.Now, oShedule.SheduledTime);

                if (oAlert != null && oAlert.Alert_ID != 0)
                {
                    DateTime dtNow = clsSecurity.getServerDateTime();

                    #region monthly
                    if (oShedule.IsMonthly)
                    {
                        if (dtNow > dtmTodayAlert_Time && oShedule.LastAlert_SentTime.Month != dtNow.Month)
                        {
                            value = true;
                        }
                    }
                    #endregion

                    #region daily
                    else if (oShedule.IsDaily)
                    {
                        if (dtNow > dtmTodayAlert_Time && dtNow.Date != oShedule.LastAlert_SentTime.Date)
                            value = true;
                    }
                    #endregion
                }

                if (value)
                {

                    if (iAlertID == (int)enum_Alerts.Monthly_Software_Payment)
                        CreateEmail_MonthlySoftwarePayment(dtmTodayAlert_Time);
                    else if (iAlertID == (int)enum_Alerts.Payroll_Processed)
                        CreateEmail_PayrollProcessed(dtmTodayAlert_Time);
                    else if (iAlertID == (int)enum_Alerts.DailyHeadCount)
                        CreateEmail_DailyHeadCount(dtmTodayAlert_Time);
                    else if (iAlertID == (int)enum_Alerts.DailyPrecences)
                        CreateEmail_DailyPresentEmployees_DeptWise(dtmTodayAlert_Time);
                    else if (iAlertID == (int)enum_Alerts.ProbationPeriod_End)
                        CreateEmail_ProbationPeriod_End(dtmTodayAlert_Time);                    

                }
            }
        }


        public static void UpdateAlertSentTime(enum_Alerts enAlert, bool bStatus)
        {
            tbl_utlAlert_Shedule detail = tbl_utlAlert_Shedule.Select((int)enAlert);
            if (bStatus)
            {
                if (detail != null && detail.IsActive)
                {
                    detail.LastAlert_SentTime = clsSecurity.getServerDateTime();
                    detail.Update();
                    clsValidation.WriteErrorLog("\n" + (int)enAlert + " - " + enAlert.ToString() + " Generated Succesfully ");
                }
            }
            else
                clsValidation.WriteErrorLog("\n" + (int)enAlert + " - " + enAlert.ToString() + " Generated Failed");
        }
        #endregion

        #region Save Mails
        public static int SaveMailHTML(int iAlertID, string sEmailSubject, string sBodyHTML, string sReceiver, string sReceiverEmail)
        {
            int iReturn = -1;
            try
            {
                int iEmailId = int.Parse((clsCommon.getAutoGeneratedCode(FormName.Alert)));
                iReturn = iEmailId;
                tbl_utlAlertMailBox_Pending emailP = new tbl_utlAlertMailBox_Pending(iEmailId, iAlertID, sEmailSubject, sBodyHTML, 0);
                emailP.Insert();

                tbl_utlAlertMailBox_Receiver emailR = new tbl_utlAlertMailBox_Receiver(iEmailId, 1, (int)SendMailTypes.To, sReceiver, sReceiverEmail);
                emailR.Insert();
            }
            catch (Exception ex)
            {
                clsValidation.WriteErrorLog(iAlertID + " - Alert Save failed - " + ex.Message);
            }

            return iReturn;

        }


        #endregion
    }
}
