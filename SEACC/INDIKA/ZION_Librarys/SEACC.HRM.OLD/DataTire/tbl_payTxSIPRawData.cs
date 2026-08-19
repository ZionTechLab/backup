using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payTxSIPRawData {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int sIP_ID;
		private string processGroup_ID;
		private int processPeriod_ID;
		private int processPeriod_Sub_ID;
		private string employee_ID;
		private string division_ID;
		private string department_ID;
		private string sectionID;
		private string subSectionID;
		private DateTime processPeriod_Sub_startDate;
		private DateTime processPeriod_Sub_endDate;
		private decimal workingDays_Mand;
		private decimal workingDays_Act;
		private decimal workingMinutes_Mand;
		private decimal workingMinutesAct_Nomal;
		private decimal noPayMinutes;
		private decimal lateMinutes;
		private decimal workingMinutesAct_OT;
		private decimal workingMinutesAct_OT_Dub;
		private decimal workingMinutesAct_OT_Trpl;
		private decimal leaveMinutes;
		private decimal gatePassMinutes;
		private decimal baseRate_OT;
		private decimal baseRate_DOT;
		private decimal baseRate_TOT;
		private decimal divRate_OT;
		private decimal divRate_DOT;
		private decimal divRate_TOT;
		private decimal empRate_OT;
		private decimal empRate_DOT;
		private decimal empRate_TOT;
		private decimal divRate_Nopay;
		private decimal divRate_Late;
		private decimal empRate_Nopay;
		private decimal empRate_Late;
		private string designation_ID;
		private string empCatagory1_ID;
		private string empCatagory2_ID;
		private string empCatagory3_ID;
		private DateTime empDateConfirmed;
		private bool isTime_Attendance;
		private bool isPayslip_Print;
		private string nicNo;
		private bool isEPF_ETF_Process;
		private string epfNo;
		private bool is_PayeeProcess;
		private string payeeNo;
		private string paymentMethod_ID;
		private string bank_ID;
		private string bankBranch_ID;
		private string bank_AccNo;
		private bool isChecked;
		private bool isApproved;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string checkedTerminal_ID;
		private string approvedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payTxSIPRawData class.
		/// </summary>
		public tbl_payTxSIPRawData() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payTxSIPRawData class.
		/// </summary>
		public tbl_payTxSIPRawData(string company_ID, string companyBranch_ID, int sIP_ID, string processGroup_ID, int processPeriod_ID, int processPeriod_Sub_ID, string employee_ID, string division_ID, string department_ID, string sectionID, string subSectionID, DateTime processPeriod_Sub_startDate, DateTime processPeriod_Sub_endDate, decimal workingDays_Mand, decimal workingDays_Act, decimal workingMinutes_Mand, decimal workingMinutesAct_Nomal, decimal noPayMinutes, decimal lateMinutes, decimal workingMinutesAct_OT, decimal workingMinutesAct_OT_Dub, decimal workingMinutesAct_OT_Trpl, decimal leaveMinutes, decimal gatePassMinutes, decimal baseRate_OT, decimal baseRate_DOT, decimal baseRate_TOT, decimal divRate_OT, decimal divRate_DOT, decimal divRate_TOT, decimal empRate_OT, decimal empRate_DOT, decimal empRate_TOT, decimal divRate_Nopay, decimal divRate_Late, decimal empRate_Nopay, decimal empRate_Late, string designation_ID, string empCatagory1_ID, string empCatagory2_ID, string empCatagory3_ID, DateTime empDateConfirmed, bool isTime_Attendance, bool isPayslip_Print, string nicNo, bool isEPF_ETF_Process, string epfNo, bool is_PayeeProcess, string payeeNo, string paymentMethod_ID, string bank_ID, string bankBranch_ID, string bank_AccNo, bool isChecked, bool isApproved, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string checkedTerminal_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.sIP_ID = sIP_ID;
			this.processGroup_ID = processGroup_ID;
			this.processPeriod_ID = processPeriod_ID;
			this.processPeriod_Sub_ID = processPeriod_Sub_ID;
			this.employee_ID = employee_ID;
			this.division_ID = division_ID;
			this.department_ID = department_ID;
			this.sectionID = sectionID;
			this.subSectionID = subSectionID;
			this.processPeriod_Sub_startDate = processPeriod_Sub_startDate;
			this.processPeriod_Sub_endDate = processPeriod_Sub_endDate;
			this.workingDays_Mand = workingDays_Mand;
			this.workingDays_Act = workingDays_Act;
			this.workingMinutes_Mand = workingMinutes_Mand;
			this.workingMinutesAct_Nomal = workingMinutesAct_Nomal;
			this.noPayMinutes = noPayMinutes;
			this.lateMinutes = lateMinutes;
			this.workingMinutesAct_OT = workingMinutesAct_OT;
			this.workingMinutesAct_OT_Dub = workingMinutesAct_OT_Dub;
			this.workingMinutesAct_OT_Trpl = workingMinutesAct_OT_Trpl;
			this.leaveMinutes = leaveMinutes;
			this.gatePassMinutes = gatePassMinutes;
			this.baseRate_OT = baseRate_OT;
			this.baseRate_DOT = baseRate_DOT;
			this.baseRate_TOT = baseRate_TOT;
			this.divRate_OT = divRate_OT;
			this.divRate_DOT = divRate_DOT;
			this.divRate_TOT = divRate_TOT;
			this.empRate_OT = empRate_OT;
			this.empRate_DOT = empRate_DOT;
			this.empRate_TOT = empRate_TOT;
			this.divRate_Nopay = divRate_Nopay;
			this.divRate_Late = divRate_Late;
			this.empRate_Nopay = empRate_Nopay;
			this.empRate_Late = empRate_Late;
			this.designation_ID = designation_ID;
			this.empCatagory1_ID = empCatagory1_ID;
			this.empCatagory2_ID = empCatagory2_ID;
			this.empCatagory3_ID = empCatagory3_ID;
			this.empDateConfirmed = empDateConfirmed;
			this.isTime_Attendance = isTime_Attendance;
			this.isPayslip_Print = isPayslip_Print;
			this.nicNo = nicNo;
			this.isEPF_ETF_Process = isEPF_ETF_Process;
			this.epfNo = epfNo;
			this.is_PayeeProcess = is_PayeeProcess;
			this.payeeNo = payeeNo;
			this.paymentMethod_ID = paymentMethod_ID;
			this.bank_ID = bank_ID;
			this.bankBranch_ID = bankBranch_ID;
			this.bank_AccNo = bank_AccNo;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.checkedTerminal_ID = checkedTerminal_ID;
			this.approvedTerminal_ID = approvedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Company_ID value.
		/// </summary>
		public string Company_ID {
			get { return company_ID; }
			set { company_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SIP_ID value.
		/// </summary>
		public int SIP_ID {
			get { return sIP_ID; }
			set { sIP_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessGroup_ID value.
		/// </summary>
		public string ProcessGroup_ID {
			get { return processGroup_ID; }
			set { processGroup_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessPeriod_ID value.
		/// </summary>
		public int ProcessPeriod_ID {
			get { return processPeriod_ID; }
			set { processPeriod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessPeriod_Sub_ID value.
		/// </summary>
		public int ProcessPeriod_Sub_ID {
			get { return processPeriod_Sub_ID; }
			set { processPeriod_Sub_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Division_ID value.
		/// </summary>
		public string Division_ID {
			get { return division_ID; }
			set { division_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionID value.
		/// </summary>
		public string SectionID {
			get { return sectionID; }
			set { sectionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubSectionID value.
		/// </summary>
		public string SubSectionID {
			get { return subSectionID; }
			set { subSectionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessPeriod_Sub_startDate value.
		/// </summary>
		public DateTime ProcessPeriod_Sub_startDate {
			get { return processPeriod_Sub_startDate; }
			set { processPeriod_Sub_startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessPeriod_Sub_endDate value.
		/// </summary>
		public DateTime ProcessPeriod_Sub_endDate {
			get { return processPeriod_Sub_endDate; }
			set { processPeriod_Sub_endDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingDays_Mand value.
		/// </summary>
		public decimal WorkingDays_Mand {
			get { return workingDays_Mand; }
			set { workingDays_Mand = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingDays_Act value.
		/// </summary>
		public decimal WorkingDays_Act {
			get { return workingDays_Act; }
			set { workingDays_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_Mand value.
		/// </summary>
		public decimal WorkingMinutes_Mand {
			get { return workingMinutes_Mand; }
			set { workingMinutes_Mand = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_Nomal value.
		/// </summary>
		public decimal WorkingMinutesAct_Nomal {
			get { return workingMinutesAct_Nomal; }
			set { workingMinutesAct_Nomal = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoPayMinutes value.
		/// </summary>
		public decimal NoPayMinutes {
			get { return noPayMinutes; }
			set { noPayMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the LateMinutes value.
		/// </summary>
		public decimal LateMinutes {
			get { return lateMinutes; }
			set { lateMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT value.
		/// </summary>
		public decimal WorkingMinutesAct_OT {
			get { return workingMinutesAct_OT; }
			set { workingMinutesAct_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT_Dub value.
		/// </summary>
		public decimal WorkingMinutesAct_OT_Dub {
			get { return workingMinutesAct_OT_Dub; }
			set { workingMinutesAct_OT_Dub = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT_Trpl value.
		/// </summary>
		public decimal WorkingMinutesAct_OT_Trpl {
			get { return workingMinutesAct_OT_Trpl; }
			set { workingMinutesAct_OT_Trpl = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveMinutes value.
		/// </summary>
		public decimal LeaveMinutes {
			get { return leaveMinutes; }
			set { leaveMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the GatePassMinutes value.
		/// </summary>
		public decimal GatePassMinutes {
			get { return gatePassMinutes; }
			set { gatePassMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the BaseRate_OT value.
		/// </summary>
		public decimal BaseRate_OT {
			get { return baseRate_OT; }
			set { baseRate_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the BaseRate_DOT value.
		/// </summary>
		public decimal BaseRate_DOT {
			get { return baseRate_DOT; }
			set { baseRate_DOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the BaseRate_TOT value.
		/// </summary>
		public decimal BaseRate_TOT {
			get { return baseRate_TOT; }
			set { baseRate_TOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_OT value.
		/// </summary>
		public decimal DivRate_OT {
			get { return divRate_OT; }
			set { divRate_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_DOT value.
		/// </summary>
		public decimal DivRate_DOT {
			get { return divRate_DOT; }
			set { divRate_DOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_TOT value.
		/// </summary>
		public decimal DivRate_TOT {
			get { return divRate_TOT; }
			set { divRate_TOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpRate_OT value.
		/// </summary>
		public decimal EmpRate_OT {
			get { return empRate_OT; }
			set { empRate_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpRate_DOT value.
		/// </summary>
		public decimal EmpRate_DOT {
			get { return empRate_DOT; }
			set { empRate_DOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpRate_TOT value.
		/// </summary>
		public decimal EmpRate_TOT {
			get { return empRate_TOT; }
			set { empRate_TOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_Nopay value.
		/// </summary>
		public decimal DivRate_Nopay {
			get { return divRate_Nopay; }
			set { divRate_Nopay = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_Late value.
		/// </summary>
		public decimal DivRate_Late {
			get { return divRate_Late; }
			set { divRate_Late = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpRate_Nopay value.
		/// </summary>
		public decimal EmpRate_Nopay {
			get { return empRate_Nopay; }
			set { empRate_Nopay = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpRate_Late value.
		/// </summary>
		public decimal EmpRate_Late {
			get { return empRate_Late; }
			set { empRate_Late = value; }
		}
		
		/// <summary>
		/// Gets or sets the Designation_ID value.
		/// </summary>
		public string Designation_ID {
			get { return designation_ID; }
			set { designation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpCatagory1_ID value.
		/// </summary>
		public string EmpCatagory1_ID {
			get { return empCatagory1_ID; }
			set { empCatagory1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpCatagory2_ID value.
		/// </summary>
		public string EmpCatagory2_ID {
			get { return empCatagory2_ID; }
			set { empCatagory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpCatagory3_ID value.
		/// </summary>
		public string EmpCatagory3_ID {
			get { return empCatagory3_ID; }
			set { empCatagory3_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpDateConfirmed value.
		/// </summary>
		public DateTime EmpDateConfirmed {
			get { return empDateConfirmed; }
			set { empDateConfirmed = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTime_Attendance value.
		/// </summary>
		public bool IsTime_Attendance {
			get { return isTime_Attendance; }
			set { isTime_Attendance = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPayslip_Print value.
		/// </summary>
		public bool IsPayslip_Print {
			get { return isPayslip_Print; }
			set { isPayslip_Print = value; }
		}
		
		/// <summary>
		/// Gets or sets the NicNo value.
		/// </summary>
		public string NicNo {
			get { return nicNo; }
			set { nicNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEPF_ETF_Process value.
		/// </summary>
		public bool IsEPF_ETF_Process {
			get { return isEPF_ETF_Process; }
			set { isEPF_ETF_Process = value; }
		}
		
		/// <summary>
		/// Gets or sets the EpfNo value.
		/// </summary>
		public string EpfNo {
			get { return epfNo; }
			set { epfNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Is_PayeeProcess value.
		/// </summary>
		public bool Is_PayeeProcess {
			get { return is_PayeeProcess; }
			set { is_PayeeProcess = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayeeNo value.
		/// </summary>
		public string PayeeNo {
			get { return payeeNo; }
			set { payeeNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankBranch_ID value.
		/// </summary>
		public string BankBranch_ID {
			get { return bankBranch_ID; }
			set { bankBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_AccNo value.
		/// </summary>
		public string Bank_AccNo {
			get { return bank_AccNo; }
			set { bank_AccNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked value.
		/// </summary>
		public bool IsChecked {
			get { return isChecked; }
			set { isChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedTerminal_ID value.
		/// </summary>
		public string CheckedTerminal_ID {
			get { return checkedTerminal_ID; }
			set { checkedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedTerminal_ID value.
		/// </summary>
		public string ApprovedTerminal_ID {
			get { return approvedTerminal_ID; }
			set { approvedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateChecked value.
		/// </summary>
		public DateTime DateChecked {
			get { return dateChecked; }
			set { dateChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime DateApproved {
			get { return dateApproved; }
			set { dateApproved = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payTxSIPRawData table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processPeriod_Sub_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@processPeriod_Sub_endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@workingDays_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingDays_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_Nomal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Dub", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Trpl", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@baseRate_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@baseRate_DOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@baseRate_TOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_DOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_TOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_DOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_TOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_Nopay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_Nopay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@designation_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory2_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory3_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empDateConfirmed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isTime_Attendance", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPayslip_Print", SqlDbType.Bit,1);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isEPF_ETF_Process", SqlDbType.Bit,1);
			scom.Parameters.Add("@epfNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@is_PayeeProcess", SqlDbType.Bit,1);
			scom.Parameters.Add("@payeeNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_AccNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
			scom.Parameters["@processPeriod_Sub_ID"].Value = processPeriod_Sub_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@subSectionID"].Value = subSectionID;
			scom.Parameters["@processPeriod_Sub_startDate"].Value = processPeriod_Sub_startDate;
			scom.Parameters["@processPeriod_Sub_endDate"].Value = processPeriod_Sub_endDate;
			scom.Parameters["@workingDays_Mand"].Value = workingDays_Mand;
			scom.Parameters["@workingDays_Act"].Value = workingDays_Act;
			scom.Parameters["@workingMinutes_Mand"].Value = workingMinutes_Mand;
			scom.Parameters["@workingMinutesAct_Nomal"].Value = workingMinutesAct_Nomal;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@workingMinutesAct_OT"].Value = workingMinutesAct_OT;
			scom.Parameters["@workingMinutesAct_OT_Dub"].Value = workingMinutesAct_OT_Dub;
			scom.Parameters["@workingMinutesAct_OT_Trpl"].Value = workingMinutesAct_OT_Trpl;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@gatePassMinutes"].Value = gatePassMinutes;
			scom.Parameters["@baseRate_OT"].Value = baseRate_OT;
			scom.Parameters["@baseRate_DOT"].Value = baseRate_DOT;
			scom.Parameters["@baseRate_TOT"].Value = baseRate_TOT;
			scom.Parameters["@divRate_OT"].Value = divRate_OT;
			scom.Parameters["@divRate_DOT"].Value = divRate_DOT;
			scom.Parameters["@divRate_TOT"].Value = divRate_TOT;
			scom.Parameters["@empRate_OT"].Value = empRate_OT;
			scom.Parameters["@empRate_DOT"].Value = empRate_DOT;
			scom.Parameters["@empRate_TOT"].Value = empRate_TOT;
			scom.Parameters["@divRate_Nopay"].Value = divRate_Nopay;
			scom.Parameters["@divRate_Late"].Value = divRate_Late;
			scom.Parameters["@empRate_Nopay"].Value = empRate_Nopay;
			scom.Parameters["@empRate_Late"].Value = empRate_Late;
			scom.Parameters["@designation_ID"].Value = designation_ID;
			scom.Parameters["@empCatagory1_ID"].Value = empCatagory1_ID;
			scom.Parameters["@empCatagory2_ID"].Value = empCatagory2_ID;
			scom.Parameters["@empCatagory3_ID"].Value = empCatagory3_ID;
			scom.Parameters["@empDateConfirmed"].Value = empDateConfirmed;
			scom.Parameters["@isTime_Attendance"].Value = isTime_Attendance;
			scom.Parameters["@isPayslip_Print"].Value = isPayslip_Print;
			scom.Parameters["@nicNo"].Value = nicNo;
			scom.Parameters["@isEPF_ETF_Process"].Value = isEPF_ETF_Process;
			scom.Parameters["@epfNo"].Value = epfNo;
			scom.Parameters["@is_PayeeProcess"].Value = is_PayeeProcess;
			scom.Parameters["@payeeNo"].Value = payeeNo;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
			scom.Parameters["@bank_AccNo"].Value = bank_AccNo;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payTxSIPRawData table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processPeriod_Sub_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@processPeriod_Sub_endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@workingDays_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingDays_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_Nomal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Dub", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Trpl", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@baseRate_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@baseRate_DOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@baseRate_TOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_DOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_TOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_DOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_TOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_Nopay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_Nopay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@empRate_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@designation_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory2_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory3_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empDateConfirmed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isTime_Attendance", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPayslip_Print", SqlDbType.Bit,1);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isEPF_ETF_Process", SqlDbType.Bit,1);
			scom.Parameters.Add("@epfNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@is_PayeeProcess", SqlDbType.Bit,1);
			scom.Parameters.Add("@payeeNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_AccNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
			scom.Parameters["@processPeriod_Sub_ID"].Value = processPeriod_Sub_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@subSectionID"].Value = subSectionID;
			scom.Parameters["@processPeriod_Sub_startDate"].Value = processPeriod_Sub_startDate;
			scom.Parameters["@processPeriod_Sub_endDate"].Value = processPeriod_Sub_endDate;
			scom.Parameters["@workingDays_Mand"].Value = workingDays_Mand;
			scom.Parameters["@workingDays_Act"].Value = workingDays_Act;
			scom.Parameters["@workingMinutes_Mand"].Value = workingMinutes_Mand;
			scom.Parameters["@workingMinutesAct_Nomal"].Value = workingMinutesAct_Nomal;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@workingMinutesAct_OT"].Value = workingMinutesAct_OT;
			scom.Parameters["@workingMinutesAct_OT_Dub"].Value = workingMinutesAct_OT_Dub;
			scom.Parameters["@workingMinutesAct_OT_Trpl"].Value = workingMinutesAct_OT_Trpl;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@gatePassMinutes"].Value = gatePassMinutes;
			scom.Parameters["@baseRate_OT"].Value = baseRate_OT;
			scom.Parameters["@baseRate_DOT"].Value = baseRate_DOT;
			scom.Parameters["@baseRate_TOT"].Value = baseRate_TOT;
			scom.Parameters["@divRate_OT"].Value = divRate_OT;
			scom.Parameters["@divRate_DOT"].Value = divRate_DOT;
			scom.Parameters["@divRate_TOT"].Value = divRate_TOT;
			scom.Parameters["@empRate_OT"].Value = empRate_OT;
			scom.Parameters["@empRate_DOT"].Value = empRate_DOT;
			scom.Parameters["@empRate_TOT"].Value = empRate_TOT;
			scom.Parameters["@divRate_Nopay"].Value = divRate_Nopay;
			scom.Parameters["@divRate_Late"].Value = divRate_Late;
			scom.Parameters["@empRate_Nopay"].Value = empRate_Nopay;
			scom.Parameters["@empRate_Late"].Value = empRate_Late;
			scom.Parameters["@designation_ID"].Value = designation_ID;
			scom.Parameters["@empCatagory1_ID"].Value = empCatagory1_ID;
			scom.Parameters["@empCatagory2_ID"].Value = empCatagory2_ID;
			scom.Parameters["@empCatagory3_ID"].Value = empCatagory3_ID;
			scom.Parameters["@empDateConfirmed"].Value = empDateConfirmed;
			scom.Parameters["@isTime_Attendance"].Value = isTime_Attendance;
			scom.Parameters["@isPayslip_Print"].Value = isPayslip_Print;
			scom.Parameters["@nicNo"].Value = nicNo;
			scom.Parameters["@isEPF_ETF_Process"].Value = isEPF_ETF_Process;
			scom.Parameters["@epfNo"].Value = epfNo;
			scom.Parameters["@is_PayeeProcess"].Value = is_PayeeProcess;
			scom.Parameters["@payeeNo"].Value = payeeNo;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
			scom.Parameters["@bank_AccNo"].Value = bank_AccNo;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payTxSIPRawData table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID(string company_ID, string companyBranch_ID, string processGroup_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataDeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID_ProcessPeriod_Sub_ID(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID, int processPeriod_Sub_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataDeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID_ProcessPeriod_Sub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
			scom.Parameters["@processPeriod_Sub_ID"].Value = processPeriod_Sub_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataDeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payTxSIPRawData table.
		/// </summary>
		public static tbl_payTxSIPRawData Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int sIP_ID_Incoming){

			tbl_payTxSIPRawData tbl_payTxSIPRawDatains = new tbl_payTxSIPRawData();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@SIP_ID"].Value = sIP_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payTxSIPRawDatains = Maketbl_payTxSIPRawData(dataReader);
				} else {
					tbl_payTxSIPRawDatains = null;
				}
			}
			scon.Close();
			return tbl_payTxSIPRawDatains;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData table.
		/// </summary>
		public static List<tbl_payTxSIPRawData> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payTxSIPRawData> tbl_payTxSIPRawDataList = new List<tbl_payTxSIPRawData>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payTxSIPRawData tbl_payTxSIPRawData = Maketbl_payTxSIPRawData(dataReader);
					tbl_payTxSIPRawDataList.Add(tbl_payTxSIPRawData);
				}
			}
			scon.Close();
			return tbl_payTxSIPRawDataList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData table by a foreign key.
		/// </summary>
		public static List<tbl_payTxSIPRawData> SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID(string company_ID, string companyBranch_ID, string processGroup_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataSelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
				List<tbl_payTxSIPRawData> tbl_payTxSIPRawDataList = new List<tbl_payTxSIPRawData>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payTxSIPRawData tbl_payTxSIPRawData = Maketbl_payTxSIPRawData(dataReader);
					tbl_payTxSIPRawDataList.Add(tbl_payTxSIPRawData);
				}
			}
			scon.Close();
			return tbl_payTxSIPRawDataList;
		}

        public static List<tbl_payTxSIPRawData> SelectAllPeriods_ByDateRange(DateTime dtmStartDate, DateTime dtmEndDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataSelectAllByDateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@startDate", SqlDbType.DateTime);
            scom.Parameters.Add("@endDate", SqlDbType.DateTime);

            scom.Parameters["@startDate"].Value = dtmStartDate.Date;
            scom.Parameters["@endDate"].Value = dtmEndDate.Date;

            List<tbl_payTxSIPRawData> tbl_payTxSIPRawDataList = new List<tbl_payTxSIPRawData>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_payTxSIPRawData tbl_payTxSIPRawData = Maketbl_payTxSIPRawData(dataReader);
                    tbl_payTxSIPRawDataList.Add(tbl_payTxSIPRawData);
                }
            }
            scon.Close();
            return tbl_payTxSIPRawDataList;
        }

        public static List<tbl_payTxSIPRawData> SelectPeriod_ByDateRange(DateTime dtmStartDate, DateTime dtmEndDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataSelectPeriod_ByDateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@startDate", SqlDbType.DateTime);
            scom.Parameters.Add("@endDate", SqlDbType.DateTime);

            scom.Parameters["@startDate"].Value = dtmStartDate.Date;
            scom.Parameters["@endDate"].Value = dtmEndDate.Date;

            List<tbl_payTxSIPRawData> tbl_payTxSIPRawDataList = new List<tbl_payTxSIPRawData>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_payTxSIPRawData tbl_payTxSIPRawData = Maketbl_payTxSIPRawData(dataReader);
                    tbl_payTxSIPRawDataList.Add(tbl_payTxSIPRawData);
                }
            }
            scon.Close();
            return tbl_payTxSIPRawDataList;
        }
        /// <summary>
        /// Selects all records from the tbl_payTxSIPRawData table by a foreign key.
        /// </summary>
        public static List<tbl_payTxSIPRawData> SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID_ProcessPeriod_Sub_ID(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID, int processPeriod_Sub_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataSelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID_ProcessPeriod_Sub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
			scom.Parameters["@processPeriod_Sub_ID"].Value = processPeriod_Sub_ID;
				List<tbl_payTxSIPRawData> tbl_payTxSIPRawDataList = new List<tbl_payTxSIPRawData>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payTxSIPRawData tbl_payTxSIPRawData = Maketbl_payTxSIPRawData(dataReader);
					tbl_payTxSIPRawDataList.Add(tbl_payTxSIPRawData);
				}
			}
			scon.Close();
			return tbl_payTxSIPRawDataList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData table by a foreign key.
		/// </summary>
		public static List<tbl_payTxSIPRawData> SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawDataSelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
				List<tbl_payTxSIPRawData> tbl_payTxSIPRawDataList = new List<tbl_payTxSIPRawData>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payTxSIPRawData tbl_payTxSIPRawData = Maketbl_payTxSIPRawData(dataReader);
					tbl_payTxSIPRawDataList.Add(tbl_payTxSIPRawData);
				}
			}
			scon.Close();
			return tbl_payTxSIPRawDataList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payTxSIPRawData class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payTxSIPRawData Maketbl_payTxSIPRawData(SqlDataReader dataReader) {
			tbl_payTxSIPRawData tbl_payTxSIPRawData = new tbl_payTxSIPRawData();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payTxSIPRawData.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payTxSIPRawData.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payTxSIPRawData.SIP_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payTxSIPRawData.ProcessGroup_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payTxSIPRawData.ProcessPeriod_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payTxSIPRawData.ProcessPeriod_Sub_ID = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payTxSIPRawData.Employee_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_payTxSIPRawData.Division_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_payTxSIPRawData.Department_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_payTxSIPRawData.SectionID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_payTxSIPRawData.SubSectionID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_payTxSIPRawData.ProcessPeriod_Sub_startDate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_payTxSIPRawData.ProcessPeriod_Sub_endDate = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_payTxSIPRawData.WorkingDays_Mand = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_payTxSIPRawData.WorkingDays_Act = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_payTxSIPRawData.WorkingMinutes_Mand = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_payTxSIPRawData.WorkingMinutesAct_Nomal = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_payTxSIPRawData.NoPayMinutes = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_payTxSIPRawData.LateMinutes = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_payTxSIPRawData.WorkingMinutesAct_OT = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_payTxSIPRawData.WorkingMinutesAct_OT_Dub = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_payTxSIPRawData.WorkingMinutesAct_OT_Trpl = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_payTxSIPRawData.LeaveMinutes = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_payTxSIPRawData.GatePassMinutes = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_payTxSIPRawData.BaseRate_OT = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_payTxSIPRawData.BaseRate_DOT = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_payTxSIPRawData.BaseRate_TOT = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_payTxSIPRawData.DivRate_OT = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_payTxSIPRawData.DivRate_DOT = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_payTxSIPRawData.DivRate_TOT = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_payTxSIPRawData.EmpRate_OT = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_payTxSIPRawData.EmpRate_DOT = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_payTxSIPRawData.EmpRate_TOT = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_payTxSIPRawData.DivRate_Nopay = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_payTxSIPRawData.DivRate_Late = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_payTxSIPRawData.EmpRate_Nopay = dataReader.GetDecimal(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_payTxSIPRawData.EmpRate_Late = dataReader.GetDecimal(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_payTxSIPRawData.Designation_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_payTxSIPRawData.EmpCatagory1_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_payTxSIPRawData.EmpCatagory2_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_payTxSIPRawData.EmpCatagory3_ID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_payTxSIPRawData.EmpDateConfirmed = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_payTxSIPRawData.IsTime_Attendance = dataReader.GetBoolean(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_payTxSIPRawData.IsPayslip_Print = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_payTxSIPRawData.NicNo = dataReader.GetString(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_payTxSIPRawData.IsEPF_ETF_Process = dataReader.GetBoolean(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_payTxSIPRawData.EpfNo = dataReader.GetString(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_payTxSIPRawData.Is_PayeeProcess = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_payTxSIPRawData.PayeeNo = dataReader.GetString(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_payTxSIPRawData.PaymentMethod_ID = dataReader.GetString(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_payTxSIPRawData.Bank_ID = dataReader.GetString(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_payTxSIPRawData.BankBranch_ID = dataReader.GetString(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_payTxSIPRawData.Bank_AccNo = dataReader.GetString(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_payTxSIPRawData.IsChecked = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_payTxSIPRawData.IsApproved = dataReader.GetBoolean(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_payTxSIPRawData.CreateUser_ID = dataReader.GetString(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_payTxSIPRawData.ModifiedUser_ID = dataReader.GetString(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_payTxSIPRawData.CheckedUser_ID = dataReader.GetString(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_payTxSIPRawData.ApprovedUser_ID = dataReader.GetString(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_payTxSIPRawData.CreateTerminal_ID = dataReader.GetString(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_payTxSIPRawData.ModifiedTerminal_ID = dataReader.GetString(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_payTxSIPRawData.CheckedTerminal_ID = dataReader.GetString(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_payTxSIPRawData.ApprovedTerminal_ID = dataReader.GetString(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_payTxSIPRawData.DateCreate = dataReader.GetDateTime(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_payTxSIPRawData.DateModified = dataReader.GetDateTime(64);
			}
			if (dataReader.IsDBNull(65) == false) {
				tbl_payTxSIPRawData.DateChecked = dataReader.GetDateTime(65);
			}
			if (dataReader.IsDBNull(66) == false) {
				tbl_payTxSIPRawData.DateApproved = dataReader.GetDateTime(66);
			}

			return tbl_payTxSIPRawData;
		}
		/// <summary>
		/// This makes tbl_payTxSIPRawData datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payTxSIPRawData object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payTxSIPRawData  tbl_payTxSIPRawData   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_SIP_ID = new DataColumn("SIP_ID" , typeof(int));
			DataColumn col_processGroup_ID = new DataColumn("processGroup_ID" , typeof(string));
			DataColumn col_processPeriod_ID = new DataColumn("processPeriod_ID" , typeof(int));
			DataColumn col_processPeriod_Sub_ID = new DataColumn("processPeriod_Sub_ID" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_sectionID = new DataColumn("sectionID" , typeof(string));
			DataColumn col_subSectionID = new DataColumn("subSectionID" , typeof(string));
			DataColumn col_processPeriod_Sub_startDate = new DataColumn("processPeriod_Sub_startDate" , typeof(DateTime));
			DataColumn col_processPeriod_Sub_endDate = new DataColumn("processPeriod_Sub_endDate" , typeof(DateTime));
			DataColumn col_workingDays_Mand = new DataColumn("workingDays_Mand" , typeof(decimal));
			DataColumn col_workingDays_Act = new DataColumn("workingDays_Act" , typeof(decimal));
			DataColumn col_workingMinutes_Mand = new DataColumn("workingMinutes_Mand" , typeof(decimal));
			DataColumn col_workingMinutesAct_Nomal = new DataColumn("workingMinutesAct_Nomal" , typeof(decimal));
			DataColumn col_noPayMinutes = new DataColumn("noPayMinutes" , typeof(decimal));
			DataColumn col_lateMinutes = new DataColumn("lateMinutes" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT = new DataColumn("workingMinutesAct_OT" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT_Dub = new DataColumn("workingMinutesAct_OT_Dub" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT_Trpl = new DataColumn("workingMinutesAct_OT_Trpl" , typeof(decimal));
			DataColumn col_leaveMinutes = new DataColumn("leaveMinutes" , typeof(decimal));
			DataColumn col_gatePassMinutes = new DataColumn("gatePassMinutes" , typeof(decimal));
			DataColumn col_baseRate_OT = new DataColumn("baseRate_OT" , typeof(decimal));
			DataColumn col_baseRate_DOT = new DataColumn("baseRate_DOT" , typeof(decimal));
			DataColumn col_baseRate_TOT = new DataColumn("baseRate_TOT" , typeof(decimal));
			DataColumn col_divRate_OT = new DataColumn("divRate_OT" , typeof(decimal));
			DataColumn col_divRate_DOT = new DataColumn("divRate_DOT" , typeof(decimal));
			DataColumn col_divRate_TOT = new DataColumn("divRate_TOT" , typeof(decimal));
			DataColumn col_empRate_OT = new DataColumn("empRate_OT" , typeof(decimal));
			DataColumn col_empRate_DOT = new DataColumn("empRate_DOT" , typeof(decimal));
			DataColumn col_empRate_TOT = new DataColumn("empRate_TOT" , typeof(decimal));
			DataColumn col_divRate_Nopay = new DataColumn("divRate_Nopay" , typeof(decimal));
			DataColumn col_divRate_Late = new DataColumn("divRate_Late" , typeof(decimal));
			DataColumn col_empRate_Nopay = new DataColumn("empRate_Nopay" , typeof(decimal));
			DataColumn col_empRate_Late = new DataColumn("empRate_Late" , typeof(decimal));
			DataColumn col_designation_ID = new DataColumn("designation_ID" , typeof(string));
			DataColumn col_empCatagory1_ID = new DataColumn("empCatagory1_ID" , typeof(string));
			DataColumn col_empCatagory2_ID = new DataColumn("empCatagory2_ID" , typeof(string));
			DataColumn col_empCatagory3_ID = new DataColumn("empCatagory3_ID" , typeof(string));
			DataColumn col_empDateConfirmed = new DataColumn("empDateConfirmed" , typeof(DateTime));
			DataColumn col_isTime_Attendance = new DataColumn("isTime_Attendance" , typeof(bool));
			DataColumn col_isPayslip_Print = new DataColumn("isPayslip_Print" , typeof(bool));
			DataColumn col_nicNo = new DataColumn("nicNo" , typeof(string));
			DataColumn col_isEPF_ETF_Process = new DataColumn("isEPF_ETF_Process" , typeof(bool));
			DataColumn col_epfNo = new DataColumn("epfNo" , typeof(string));
			DataColumn col_is_PayeeProcess = new DataColumn("is_PayeeProcess" , typeof(bool));
			DataColumn col_payeeNo = new DataColumn("payeeNo" , typeof(string));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_bankBranch_ID = new DataColumn("bankBranch_ID" , typeof(string));
			DataColumn col_bank_AccNo = new DataColumn("bank_AccNo" , typeof(string));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_checkedTerminal_ID = new DataColumn("checkedTerminal_ID" , typeof(string));
			DataColumn col_approvedTerminal_ID = new DataColumn("approvedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_SIP_ID,col_processGroup_ID,col_processPeriod_ID,col_processPeriod_Sub_ID,col_employee_ID,col_division_ID,col_department_ID,col_sectionID,col_subSectionID,col_processPeriod_Sub_startDate,col_processPeriod_Sub_endDate,col_workingDays_Mand,col_workingDays_Act,col_workingMinutes_Mand,col_workingMinutesAct_Nomal,col_noPayMinutes,col_lateMinutes,col_workingMinutesAct_OT,col_workingMinutesAct_OT_Dub,col_workingMinutesAct_OT_Trpl,col_leaveMinutes,col_gatePassMinutes,col_baseRate_OT,col_baseRate_DOT,col_baseRate_TOT,col_divRate_OT,col_divRate_DOT,col_divRate_TOT,col_empRate_OT,col_empRate_DOT,col_empRate_TOT,col_divRate_Nopay,col_divRate_Late,col_empRate_Nopay,col_empRate_Late,col_designation_ID,col_empCatagory1_ID,col_empCatagory2_ID,col_empCatagory3_ID,col_empDateConfirmed,col_isTime_Attendance,col_isPayslip_Print,col_nicNo,col_isEPF_ETF_Process,col_epfNo,col_is_PayeeProcess,col_payeeNo,col_paymentMethod_ID,col_bank_ID,col_bankBranch_ID,col_bank_AccNo,col_isChecked,col_isApproved,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_checkedTerminal_ID,col_approvedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payTxSIPRawData datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payTxSIPRawData object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payTxSIPRawData user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["SIP_ID"] = user.SIP_ID;
			drow["processGroup_ID"] = user.processGroup_ID;
			drow["processPeriod_ID"] = user.processPeriod_ID;
			drow["processPeriod_Sub_ID"] = user.processPeriod_Sub_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["division_ID"] = user.division_ID;
			drow["department_ID"] = user.department_ID;
			drow["sectionID"] = user.sectionID;
			drow["subSectionID"] = user.subSectionID;
			drow["processPeriod_Sub_startDate"] = user.processPeriod_Sub_startDate;
			drow["processPeriod_Sub_endDate"] = user.processPeriod_Sub_endDate;
			drow["workingDays_Mand"] = user.workingDays_Mand;
			drow["workingDays_Act"] = user.workingDays_Act;
			drow["workingMinutes_Mand"] = user.workingMinutes_Mand;
			drow["workingMinutesAct_Nomal"] = user.workingMinutesAct_Nomal;
			drow["noPayMinutes"] = user.noPayMinutes;
			drow["lateMinutes"] = user.lateMinutes;
			drow["workingMinutesAct_OT"] = user.workingMinutesAct_OT;
			drow["workingMinutesAct_OT_Dub"] = user.workingMinutesAct_OT_Dub;
			drow["workingMinutesAct_OT_Trpl"] = user.workingMinutesAct_OT_Trpl;
			drow["leaveMinutes"] = user.leaveMinutes;
			drow["gatePassMinutes"] = user.gatePassMinutes;
			drow["baseRate_OT"] = user.baseRate_OT;
			drow["baseRate_DOT"] = user.baseRate_DOT;
			drow["baseRate_TOT"] = user.baseRate_TOT;
			drow["divRate_OT"] = user.divRate_OT;
			drow["divRate_DOT"] = user.divRate_DOT;
			drow["divRate_TOT"] = user.divRate_TOT;
			drow["empRate_OT"] = user.empRate_OT;
			drow["empRate_DOT"] = user.empRate_DOT;
			drow["empRate_TOT"] = user.empRate_TOT;
			drow["divRate_Nopay"] = user.divRate_Nopay;
			drow["divRate_Late"] = user.divRate_Late;
			drow["empRate_Nopay"] = user.empRate_Nopay;
			drow["empRate_Late"] = user.empRate_Late;
			drow["designation_ID"] = user.designation_ID;
			drow["empCatagory1_ID"] = user.empCatagory1_ID;
			drow["empCatagory2_ID"] = user.empCatagory2_ID;
			drow["empCatagory3_ID"] = user.empCatagory3_ID;
			drow["empDateConfirmed"] = user.empDateConfirmed;
			drow["isTime_Attendance"] = user.isTime_Attendance;
			drow["isPayslip_Print"] = user.isPayslip_Print;
			drow["nicNo"] = user.nicNo;
			drow["isEPF_ETF_Process"] = user.isEPF_ETF_Process;
			drow["epfNo"] = user.epfNo;
			drow["is_PayeeProcess"] = user.is_PayeeProcess;
			drow["payeeNo"] = user.payeeNo;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["bank_ID"] = user.bank_ID;
			drow["bankBranch_ID"] = user.bankBranch_ID;
			drow["bank_AccNo"] = user.bank_AccNo;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["checkedTerminal_ID"] = user.checkedTerminal_ID;
			drow["approvedTerminal_ID"] = user.approvedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
