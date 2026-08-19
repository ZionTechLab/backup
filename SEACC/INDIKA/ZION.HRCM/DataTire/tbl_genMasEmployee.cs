using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasEmployee {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string employee_ID;
		private string employee_ID2;
		private string titleID;
		private string fullName;
		private string initails;
		private string surName;
		private string aliasName;
		private string nicNo;
		private string drivingLic_No;
		private string passportNo;
		private string nationality_ID;
		private string religion_ID;
		private DateTime dateOfBirth;
		private DateTime dateOfMerrage;
		private int gender;
		private int civilState;
		private string addressLine1;
		private string addressLine2;
		private string addressLine3;
		private string town_ID;
		private string city_ID;
		private string district_ID;
		private string country_ID;
		private string postalCode_ID;
		private string gs_DivisionCode;
		private string province_ID;
		private string telephone_Home;
		private string telephone_Office;
		private string telephone_Ext;
		private string mobile1;
		private string mobile2;
		private string mobile_Office;
		private string emrg_Contact1;
		private string emrg_ContactPerson1;
		private string emrg_Contact2;
		private string emrg_ContactPerson2;
		private string email;
		private string email_office;
		private string epfNo;
		private string designation_ID;
		private string empCatagory1_ID;
		private string empCatagory2_ID;
		private string empCatagory3_ID;
		private string department_ID;
		private string division_ID;
		private string sectionID;
		private string subSectionID;
		private string employee_RecuirtmentType;
		private DateTime dateJoin;
		private DateTime dateConfirm;
		private DateTime dateTerminate;
		private DateTime lastWorkingDate;
		private DateTime payrollEndDate;
		private DateTime visaEndDate;
		private string managerID;
		private string supevisorID;
		private string shift_ID;
		private bool isTime_Attendance;
		private string attendanceGroup1_ID;
		private string attendanceGroup2_ID;
		private bool isPayrall_Process;
		private bool isPayslip_Print;
		private bool isEPF_ETF_Process;
		private bool is_PayeeProcess;
		private string paymentMethod_ID;
		private string employee_AccountName;
		private string employee_AccountNo;
		private string bank_ID;
		private string bankBranch_ID;
		private string payroll_Level;
		private string payroll_ProcessGroupID;
		private string emp_statusID;
		private byte[] employee_Image;
		private bool isSportman;
		private bool isSalesManager;
		private bool isAreaManager;
		private bool isSelesRep;
		private bool isSalesExecutive;
		private bool isDriver;
		private bool isAssistant;
		private bool isOperator;
		private bool isRosterBasedEmployee;
		private decimal salesTarget;
		private decimal minimumSalesTarget;
		private decimal commisionPersentage_Normal;
		private decimal commisionPersentage_Bones;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMasEmployee class.
		/// </summary>
		public tbl_genMasEmployee() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasEmployee class.
		/// </summary>
		public tbl_genMasEmployee(string company_ID, string companyBranch_ID, string employee_ID, string employee_ID2, string titleID, string fullName, string initails, string surName, string aliasName, string nicNo, string drivingLic_No, string passportNo, string nationality_ID, string religion_ID, DateTime dateOfBirth, DateTime dateOfMerrage, int gender, int civilState, string addressLine1, string addressLine2, string addressLine3, string town_ID, string city_ID, string district_ID, string country_ID, string postalCode_ID, string gs_DivisionCode, string province_ID, string telephone_Home, string telephone_Office, string telephone_Ext, string mobile1, string mobile2, string mobile_Office, string emrg_Contact1, string emrg_ContactPerson1, string emrg_Contact2, string emrg_ContactPerson2, string email, string email_office, string epfNo, string designation_ID, string empCatagory1_ID, string empCatagory2_ID, string empCatagory3_ID, string department_ID, string division_ID, string sectionID, string subSectionID, string employee_RecuirtmentType, DateTime dateJoin, DateTime dateConfirm, DateTime dateTerminate, DateTime lastWorkingDate, DateTime payrollEndDate, DateTime visaEndDate, string managerID, string supevisorID, string shift_ID, bool isTime_Attendance, string attendanceGroup1_ID, string attendanceGroup2_ID, bool isPayrall_Process, bool isPayslip_Print, bool isEPF_ETF_Process, bool is_PayeeProcess, string paymentMethod_ID, string employee_AccountName, string employee_AccountNo, string bank_ID, string bankBranch_ID, string payroll_Level, string payroll_ProcessGroupID, string emp_statusID, byte[] employee_Image, bool isSportman, bool isSalesManager, bool isAreaManager, bool isSelesRep, bool isSalesExecutive, bool isDriver, bool isAssistant, bool isOperator, bool isRosterBasedEmployee, decimal salesTarget, decimal minimumSalesTarget, decimal commisionPersentage_Normal, decimal commisionPersentage_Bones, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.employee_ID = employee_ID;
			this.employee_ID2 = employee_ID2;
			this.titleID = titleID;
			this.fullName = fullName;
			this.initails = initails;
			this.surName = surName;
			this.aliasName = aliasName;
			this.nicNo = nicNo;
			this.drivingLic_No = drivingLic_No;
			this.passportNo = passportNo;
			this.nationality_ID = nationality_ID;
			this.religion_ID = religion_ID;
			this.dateOfBirth = dateOfBirth;
			this.dateOfMerrage = dateOfMerrage;
			this.gender = gender;
			this.civilState = civilState;
			this.addressLine1 = addressLine1;
			this.addressLine2 = addressLine2;
			this.addressLine3 = addressLine3;
			this.town_ID = town_ID;
			this.city_ID = city_ID;
			this.district_ID = district_ID;
			this.country_ID = country_ID;
			this.postalCode_ID = postalCode_ID;
			this.gs_DivisionCode = gs_DivisionCode;
			this.province_ID = province_ID;
			this.telephone_Home = telephone_Home;
			this.telephone_Office = telephone_Office;
			this.telephone_Ext = telephone_Ext;
			this.mobile1 = mobile1;
			this.mobile2 = mobile2;
			this.mobile_Office = mobile_Office;
			this.emrg_Contact1 = emrg_Contact1;
			this.emrg_ContactPerson1 = emrg_ContactPerson1;
			this.emrg_Contact2 = emrg_Contact2;
			this.emrg_ContactPerson2 = emrg_ContactPerson2;
			this.email = email;
			this.email_office = email_office;
			this.epfNo = epfNo;
			this.designation_ID = designation_ID;
			this.empCatagory1_ID = empCatagory1_ID;
			this.empCatagory2_ID = empCatagory2_ID;
			this.empCatagory3_ID = empCatagory3_ID;
			this.department_ID = department_ID;
			this.division_ID = division_ID;
			this.sectionID = sectionID;
			this.subSectionID = subSectionID;
			this.employee_RecuirtmentType = employee_RecuirtmentType;
			this.dateJoin = dateJoin;
			this.dateConfirm = dateConfirm;
			this.dateTerminate = dateTerminate;
			this.lastWorkingDate = lastWorkingDate;
			this.payrollEndDate = payrollEndDate;
			this.visaEndDate = visaEndDate;
			this.managerID = managerID;
			this.supevisorID = supevisorID;
			this.shift_ID = shift_ID;
			this.isTime_Attendance = isTime_Attendance;
			this.attendanceGroup1_ID = attendanceGroup1_ID;
			this.attendanceGroup2_ID = attendanceGroup2_ID;
			this.isPayrall_Process = isPayrall_Process;
			this.isPayslip_Print = isPayslip_Print;
			this.isEPF_ETF_Process = isEPF_ETF_Process;
			this.is_PayeeProcess = is_PayeeProcess;
			this.paymentMethod_ID = paymentMethod_ID;
			this.employee_AccountName = employee_AccountName;
			this.employee_AccountNo = employee_AccountNo;
			this.bank_ID = bank_ID;
			this.bankBranch_ID = bankBranch_ID;
			this.payroll_Level = payroll_Level;
			this.payroll_ProcessGroupID = payroll_ProcessGroupID;
			this.emp_statusID = emp_statusID;
			this.employee_Image = employee_Image;
			this.isSportman = isSportman;
			this.isSalesManager = isSalesManager;
			this.isAreaManager = isAreaManager;
			this.isSelesRep = isSelesRep;
			this.isSalesExecutive = isSalesExecutive;
			this.isDriver = isDriver;
			this.isAssistant = isAssistant;
			this.isOperator = isOperator;
			this.isRosterBasedEmployee = isRosterBasedEmployee;
			this.salesTarget = salesTarget;
			this.minimumSalesTarget = minimumSalesTarget;
			this.commisionPersentage_Normal = commisionPersentage_Normal;
			this.commisionPersentage_Bones = commisionPersentage_Bones;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID2 value.
		/// </summary>
		public string Employee_ID2 {
			get { return employee_ID2; }
			set { employee_ID2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the TitleID value.
		/// </summary>
		public string TitleID {
			get { return titleID; }
			set { titleID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FullName value.
		/// </summary>
		public string FullName {
			get { return fullName; }
			set { fullName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Initails value.
		/// </summary>
		public string Initails {
			get { return initails; }
			set { initails = value; }
		}
		
		/// <summary>
		/// Gets or sets the SurName value.
		/// </summary>
		public string SurName {
			get { return surName; }
			set { surName = value; }
		}
		
		/// <summary>
		/// Gets or sets the AliasName value.
		/// </summary>
		public string AliasName {
			get { return aliasName; }
			set { aliasName = value; }
		}
		
		/// <summary>
		/// Gets or sets the NicNo value.
		/// </summary>
		public string NicNo {
			get { return nicNo; }
			set { nicNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the DrivingLic_No value.
		/// </summary>
		public string DrivingLic_No {
			get { return drivingLic_No; }
			set { drivingLic_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PassportNo value.
		/// </summary>
		public string PassportNo {
			get { return passportNo; }
			set { passportNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Nationality_ID value.
		/// </summary>
		public string Nationality_ID {
			get { return nationality_ID; }
			set { nationality_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Religion_ID value.
		/// </summary>
		public string Religion_ID {
			get { return religion_ID; }
			set { religion_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateOfBirth value.
		/// </summary>
		public DateTime DateOfBirth {
			get { return dateOfBirth; }
			set { dateOfBirth = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateOfMerrage value.
		/// </summary>
		public DateTime DateOfMerrage {
			get { return dateOfMerrage; }
			set { dateOfMerrage = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gender value.
		/// </summary>
		public int Gender {
			get { return gender; }
			set { gender = value; }
		}
		
		/// <summary>
		/// Gets or sets the CivilState value.
		/// </summary>
		public int CivilState {
			get { return civilState; }
			set { civilState = value; }
		}
		
		/// <summary>
		/// Gets or sets the AddressLine1 value.
		/// </summary>
		public string AddressLine1 {
			get { return addressLine1; }
			set { addressLine1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the AddressLine2 value.
		/// </summary>
		public string AddressLine2 {
			get { return addressLine2; }
			set { addressLine2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the AddressLine3 value.
		/// </summary>
		public string AddressLine3 {
			get { return addressLine3; }
			set { addressLine3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Town_ID value.
		/// </summary>
		public string Town_ID {
			get { return town_ID; }
			set { town_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the City_ID value.
		/// </summary>
		public string City_ID {
			get { return city_ID; }
			set { city_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the District_ID value.
		/// </summary>
		public string District_ID {
			get { return district_ID; }
			set { district_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Country_ID value.
		/// </summary>
		public string Country_ID {
			get { return country_ID; }
			set { country_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostalCode_ID value.
		/// </summary>
		public string PostalCode_ID {
			get { return postalCode_ID; }
			set { postalCode_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gs_DivisionCode value.
		/// </summary>
		public string Gs_DivisionCode {
			get { return gs_DivisionCode; }
			set { gs_DivisionCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the Province_ID value.
		/// </summary>
		public string Province_ID {
			get { return province_ID; }
			set { province_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone_Home value.
		/// </summary>
		public string Telephone_Home {
			get { return telephone_Home; }
			set { telephone_Home = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone_Office value.
		/// </summary>
		public string Telephone_Office {
			get { return telephone_Office; }
			set { telephone_Office = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone_Ext value.
		/// </summary>
		public string Telephone_Ext {
			get { return telephone_Ext; }
			set { telephone_Ext = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mobile1 value.
		/// </summary>
		public string Mobile1 {
			get { return mobile1; }
			set { mobile1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mobile2 value.
		/// </summary>
		public string Mobile2 {
			get { return mobile2; }
			set { mobile2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mobile_Office value.
		/// </summary>
		public string Mobile_Office {
			get { return mobile_Office; }
			set { mobile_Office = value; }
		}
		
		/// <summary>
		/// Gets or sets the Emrg_Contact1 value.
		/// </summary>
		public string Emrg_Contact1 {
			get { return emrg_Contact1; }
			set { emrg_Contact1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Emrg_ContactPerson1 value.
		/// </summary>
		public string Emrg_ContactPerson1 {
			get { return emrg_ContactPerson1; }
			set { emrg_ContactPerson1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Emrg_Contact2 value.
		/// </summary>
		public string Emrg_Contact2 {
			get { return emrg_Contact2; }
			set { emrg_Contact2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Emrg_ContactPerson2 value.
		/// </summary>
		public string Emrg_ContactPerson2 {
			get { return emrg_ContactPerson2; }
			set { emrg_ContactPerson2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email {
			get { return email; }
			set { email = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email_office value.
		/// </summary>
		public string Email_office {
			get { return email_office; }
			set { email_office = value; }
		}
		
		/// <summary>
		/// Gets or sets the EpfNo value.
		/// </summary>
		public string EpfNo {
			get { return epfNo; }
			set { epfNo = value; }
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
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Division_ID value.
		/// </summary>
		public string Division_ID {
			get { return division_ID; }
			set { division_ID = value; }
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
		/// Gets or sets the Employee_RecuirtmentType value.
		/// </summary>
		public string Employee_RecuirtmentType {
			get { return employee_RecuirtmentType; }
			set { employee_RecuirtmentType = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateJoin value.
		/// </summary>
		public DateTime DateJoin {
			get { return dateJoin; }
			set { dateJoin = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateConfirm value.
		/// </summary>
		public DateTime DateConfirm {
			get { return dateConfirm; }
			set { dateConfirm = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateTerminate value.
		/// </summary>
		public DateTime DateTerminate {
			get { return dateTerminate; }
			set { dateTerminate = value; }
		}
		
		/// <summary>
		/// Gets or sets the LastWorkingDate value.
		/// </summary>
		public DateTime LastWorkingDate {
			get { return lastWorkingDate; }
			set { lastWorkingDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayrollEndDate value.
		/// </summary>
		public DateTime PayrollEndDate {
			get { return payrollEndDate; }
			set { payrollEndDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the VisaEndDate value.
		/// </summary>
		public DateTime VisaEndDate {
			get { return visaEndDate; }
			set { visaEndDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ManagerID value.
		/// </summary>
		public string ManagerID {
			get { return managerID; }
			set { managerID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SupevisorID value.
		/// </summary>
		public string SupevisorID {
			get { return supevisorID; }
			set { supevisorID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_ID value.
		/// </summary>
		public string Shift_ID {
			get { return shift_ID; }
			set { shift_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTime_Attendance value.
		/// </summary>
		public bool IsTime_Attendance {
			get { return isTime_Attendance; }
			set { isTime_Attendance = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttendanceGroup1_ID value.
		/// </summary>
		public string AttendanceGroup1_ID {
			get { return attendanceGroup1_ID; }
			set { attendanceGroup1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttendanceGroup2_ID value.
		/// </summary>
		public string AttendanceGroup2_ID {
			get { return attendanceGroup2_ID; }
			set { attendanceGroup2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPayrall_Process value.
		/// </summary>
		public bool IsPayrall_Process {
			get { return isPayrall_Process; }
			set { isPayrall_Process = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPayslip_Print value.
		/// </summary>
		public bool IsPayslip_Print {
			get { return isPayslip_Print; }
			set { isPayslip_Print = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEPF_ETF_Process value.
		/// </summary>
		public bool IsEPF_ETF_Process {
			get { return isEPF_ETF_Process; }
			set { isEPF_ETF_Process = value; }
		}
		
		/// <summary>
		/// Gets or sets the Is_PayeeProcess value.
		/// </summary>
		public bool Is_PayeeProcess {
			get { return is_PayeeProcess; }
			set { is_PayeeProcess = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_AccountName value.
		/// </summary>
		public string Employee_AccountName {
			get { return employee_AccountName; }
			set { employee_AccountName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_AccountNo value.
		/// </summary>
		public string Employee_AccountNo {
			get { return employee_AccountNo; }
			set { employee_AccountNo = value; }
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
		/// Gets or sets the Payroll_Level value.
		/// </summary>
		public string Payroll_Level {
			get { return payroll_Level; }
			set { payroll_Level = value; }
		}
		
		/// <summary>
		/// Gets or sets the Payroll_ProcessGroupID value.
		/// </summary>
		public string Payroll_ProcessGroupID {
			get { return payroll_ProcessGroupID; }
			set { payroll_ProcessGroupID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Emp_statusID value.
		/// </summary>
		public string Emp_statusID {
			get { return emp_statusID; }
			set { emp_statusID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_Image value.
		/// </summary>
		public byte[] Employee_Image {
			get { return employee_Image; }
			set { employee_Image = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSportman value.
		/// </summary>
		public bool IsSportman {
			get { return isSportman; }
			set { isSportman = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalesManager value.
		/// </summary>
		public bool IsSalesManager {
			get { return isSalesManager; }
			set { isSalesManager = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAreaManager value.
		/// </summary>
		public bool IsAreaManager {
			get { return isAreaManager; }
			set { isAreaManager = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSelesRep value.
		/// </summary>
		public bool IsSelesRep {
			get { return isSelesRep; }
			set { isSelesRep = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalesExecutive value.
		/// </summary>
		public bool IsSalesExecutive {
			get { return isSalesExecutive; }
			set { isSalesExecutive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDriver value.
		/// </summary>
		public bool IsDriver {
			get { return isDriver; }
			set { isDriver = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAssistant value.
		/// </summary>
		public bool IsAssistant {
			get { return isAssistant; }
			set { isAssistant = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOperator value.
		/// </summary>
		public bool IsOperator {
			get { return isOperator; }
			set { isOperator = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRosterBasedEmployee value.
		/// </summary>
		public bool IsRosterBasedEmployee {
			get { return isRosterBasedEmployee; }
			set { isRosterBasedEmployee = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesTarget value.
		/// </summary>
		public decimal SalesTarget {
			get { return salesTarget; }
			set { salesTarget = value; }
		}
		
		/// <summary>
		/// Gets or sets the MinimumSalesTarget value.
		/// </summary>
		public decimal MinimumSalesTarget {
			get { return minimumSalesTarget; }
			set { minimumSalesTarget = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommisionPersentage_Normal value.
		/// </summary>
		public decimal CommisionPersentage_Normal {
			get { return commisionPersentage_Normal; }
			set { commisionPersentage_Normal = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommisionPersentage_Bones value.
		/// </summary>
		public decimal CommisionPersentage_Bones {
			get { return commisionPersentage_Bones; }
			set { commisionPersentage_Bones = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMasEmployee table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@titleID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@fullName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@initails", SqlDbType.VarChar,10);
			scom.Parameters.Add("@surName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@aliasName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@drivingLic_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@passportNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nationality_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@religion_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@dateOfBirth", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateOfMerrage", SqlDbType.DateTime,8);
			scom.Parameters.Add("@gender", SqlDbType.Int,4);
			scom.Parameters.Add("@civilState", SqlDbType.Int,4);
			scom.Parameters.Add("@addressLine1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@addressLine2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@addressLine3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@postalCode_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@gs_DivisionCode", SqlDbType.VarChar,8);
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@telephone_Home", SqlDbType.VarChar,20);
			scom.Parameters.Add("@telephone_Office", SqlDbType.VarChar,20);
			scom.Parameters.Add("@telephone_Ext", SqlDbType.VarChar,5);
			scom.Parameters.Add("@mobile1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mobile2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mobile_Office", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emrg_Contact1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emrg_ContactPerson1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emrg_Contact2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emrg_ContactPerson2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email_office", SqlDbType.VarChar,50);
			scom.Parameters.Add("@epfNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@designation_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory2_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory3_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_RecuirtmentType", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateJoin", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateConfirm", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateTerminate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lastWorkingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@payrollEndDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@visaEndDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@managerID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supevisorID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isTime_Attendance", SqlDbType.Bit,1);
			scom.Parameters.Add("@attendanceGroup1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPayrall_Process", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPayslip_Print", SqlDbType.Bit,1);
			scom.Parameters.Add("@isEPF_ETF_Process", SqlDbType.Bit,1);
			scom.Parameters.Add("@is_PayeeProcess", SqlDbType.Bit,1);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_AccountName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@employee_AccountNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payroll_Level", SqlDbType.VarChar,20);
			scom.Parameters.Add("@payroll_ProcessGroupID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@emp_statusID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_Image", SqlDbType.Image, 2147483647);
			scom.Parameters.Add("@isSportman", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesManager", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAreaManager", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSelesRep", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesExecutive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDriver", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAssistant", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOperator", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRosterBasedEmployee", SqlDbType.Bit,1);
			scom.Parameters.Add("@salesTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@minimumSalesTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commisionPersentage_Normal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commisionPersentage_Bones", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@employee_ID2"].Value = employee_ID2;
			scom.Parameters["@titleID"].Value = titleID;
			scom.Parameters["@fullName"].Value = fullName;
			scom.Parameters["@initails"].Value = initails;
			scom.Parameters["@surName"].Value = surName;
			scom.Parameters["@aliasName"].Value = aliasName;
			scom.Parameters["@nicNo"].Value = nicNo;
			scom.Parameters["@drivingLic_No"].Value = drivingLic_No;
			scom.Parameters["@passportNo"].Value = passportNo;
			scom.Parameters["@nationality_ID"].Value = nationality_ID;
			scom.Parameters["@religion_ID"].Value = religion_ID;
			scom.Parameters["@dateOfBirth"].Value = dateOfBirth;
			scom.Parameters["@dateOfMerrage"].Value = dateOfMerrage;
			scom.Parameters["@gender"].Value = gender;
			scom.Parameters["@civilState"].Value = civilState;
			scom.Parameters["@addressLine1"].Value = addressLine1;
			scom.Parameters["@addressLine2"].Value = addressLine2;
			scom.Parameters["@addressLine3"].Value = addressLine3;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@district_ID"].Value = district_ID;
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@postalCode_ID"].Value = postalCode_ID;
			scom.Parameters["@gs_DivisionCode"].Value = gs_DivisionCode;
			scom.Parameters["@province_ID"].Value = province_ID;
			scom.Parameters["@telephone_Home"].Value = telephone_Home;
			scom.Parameters["@telephone_Office"].Value = telephone_Office;
			scom.Parameters["@telephone_Ext"].Value = telephone_Ext;
			scom.Parameters["@mobile1"].Value = mobile1;
			scom.Parameters["@mobile2"].Value = mobile2;
			scom.Parameters["@mobile_Office"].Value = mobile_Office;
			scom.Parameters["@emrg_Contact1"].Value = emrg_Contact1;
			scom.Parameters["@emrg_ContactPerson1"].Value = emrg_ContactPerson1;
			scom.Parameters["@emrg_Contact2"].Value = emrg_Contact2;
			scom.Parameters["@emrg_ContactPerson2"].Value = emrg_ContactPerson2;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@email_office"].Value = email_office;
			scom.Parameters["@epfNo"].Value = epfNo;
			scom.Parameters["@designation_ID"].Value = designation_ID;
			scom.Parameters["@empCatagory1_ID"].Value = empCatagory1_ID;
			scom.Parameters["@empCatagory2_ID"].Value = empCatagory2_ID;
			scom.Parameters["@empCatagory3_ID"].Value = empCatagory3_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@subSectionID"].Value = subSectionID;
			scom.Parameters["@employee_RecuirtmentType"].Value = employee_RecuirtmentType;
			scom.Parameters["@dateJoin"].Value = dateJoin;
			scom.Parameters["@dateConfirm"].Value = dateConfirm;
			scom.Parameters["@dateTerminate"].Value = dateTerminate;
			scom.Parameters["@lastWorkingDate"].Value = lastWorkingDate;
			scom.Parameters["@payrollEndDate"].Value = payrollEndDate;
			scom.Parameters["@visaEndDate"].Value = visaEndDate;
			scom.Parameters["@managerID"].Value = managerID;
			scom.Parameters["@supevisorID"].Value = supevisorID;
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@isTime_Attendance"].Value = isTime_Attendance;
			scom.Parameters["@attendanceGroup1_ID"].Value = attendanceGroup1_ID;
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
			scom.Parameters["@isPayrall_Process"].Value = isPayrall_Process;
			scom.Parameters["@isPayslip_Print"].Value = isPayslip_Print;
			scom.Parameters["@isEPF_ETF_Process"].Value = isEPF_ETF_Process;
			scom.Parameters["@is_PayeeProcess"].Value = is_PayeeProcess;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@employee_AccountName"].Value = employee_AccountName;
			scom.Parameters["@employee_AccountNo"].Value = employee_AccountNo;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
			scom.Parameters["@payroll_Level"].Value = payroll_Level;
			scom.Parameters["@payroll_ProcessGroupID"].Value = payroll_ProcessGroupID;
			scom.Parameters["@emp_statusID"].Value = emp_statusID;
			scom.Parameters["@employee_Image"].Value = employee_Image;
			scom.Parameters["@isSportman"].Value = isSportman;
			scom.Parameters["@isSalesManager"].Value = isSalesManager;
			scom.Parameters["@isAreaManager"].Value = isAreaManager;
			scom.Parameters["@isSelesRep"].Value = isSelesRep;
			scom.Parameters["@isSalesExecutive"].Value = isSalesExecutive;
			scom.Parameters["@isDriver"].Value = isDriver;
			scom.Parameters["@isAssistant"].Value = isAssistant;
			scom.Parameters["@isOperator"].Value = isOperator;
			scom.Parameters["@isRosterBasedEmployee"].Value = isRosterBasedEmployee;
			scom.Parameters["@salesTarget"].Value = salesTarget;
			scom.Parameters["@minimumSalesTarget"].Value = minimumSalesTarget;
			scom.Parameters["@commisionPersentage_Normal"].Value = commisionPersentage_Normal;
			scom.Parameters["@commisionPersentage_Bones"].Value = commisionPersentage_Bones;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genMasEmployee table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@titleID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@fullName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@initails", SqlDbType.VarChar,10);
			scom.Parameters.Add("@surName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@aliasName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@drivingLic_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@passportNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nationality_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@religion_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@dateOfBirth", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateOfMerrage", SqlDbType.DateTime,8);
			scom.Parameters.Add("@gender", SqlDbType.Int,4);
			scom.Parameters.Add("@civilState", SqlDbType.Int,4);
			scom.Parameters.Add("@addressLine1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@addressLine2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@addressLine3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@postalCode_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@gs_DivisionCode", SqlDbType.VarChar,8);
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@telephone_Home", SqlDbType.VarChar,20);
			scom.Parameters.Add("@telephone_Office", SqlDbType.VarChar,20);
			scom.Parameters.Add("@telephone_Ext", SqlDbType.VarChar,5);
			scom.Parameters.Add("@mobile1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mobile2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mobile_Office", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emrg_Contact1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emrg_ContactPerson1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emrg_Contact2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emrg_ContactPerson2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email_office", SqlDbType.VarChar,50);
			scom.Parameters.Add("@epfNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@designation_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory2_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory3_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_RecuirtmentType", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateJoin", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateConfirm", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateTerminate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lastWorkingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@payrollEndDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@visaEndDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@managerID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supevisorID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isTime_Attendance", SqlDbType.Bit,1);
			scom.Parameters.Add("@attendanceGroup1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPayrall_Process", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPayslip_Print", SqlDbType.Bit,1);
			scom.Parameters.Add("@isEPF_ETF_Process", SqlDbType.Bit,1);
			scom.Parameters.Add("@is_PayeeProcess", SqlDbType.Bit,1);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_AccountName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@employee_AccountNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payroll_Level", SqlDbType.VarChar,20);
			scom.Parameters.Add("@payroll_ProcessGroupID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@emp_statusID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_Image", SqlDbType.Image, 2147483647);
			scom.Parameters.Add("@isSportman", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesManager", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAreaManager", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSelesRep", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesExecutive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDriver", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAssistant", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOperator", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRosterBasedEmployee", SqlDbType.Bit,1);
			scom.Parameters.Add("@salesTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@minimumSalesTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commisionPersentage_Normal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commisionPersentage_Bones", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@employee_ID2"].Value = employee_ID2;
			scom.Parameters["@titleID"].Value = titleID;
			scom.Parameters["@fullName"].Value = fullName;
			scom.Parameters["@initails"].Value = initails;
			scom.Parameters["@surName"].Value = surName;
			scom.Parameters["@aliasName"].Value = aliasName;
			scom.Parameters["@nicNo"].Value = nicNo;
			scom.Parameters["@drivingLic_No"].Value = drivingLic_No;
			scom.Parameters["@passportNo"].Value = passportNo;
			scom.Parameters["@nationality_ID"].Value = nationality_ID;
			scom.Parameters["@religion_ID"].Value = religion_ID;
			scom.Parameters["@dateOfBirth"].Value = dateOfBirth;
			scom.Parameters["@dateOfMerrage"].Value = dateOfMerrage;
			scom.Parameters["@gender"].Value = gender;
			scom.Parameters["@civilState"].Value = civilState;
			scom.Parameters["@addressLine1"].Value = addressLine1;
			scom.Parameters["@addressLine2"].Value = addressLine2;
			scom.Parameters["@addressLine3"].Value = addressLine3;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@district_ID"].Value = district_ID;
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@postalCode_ID"].Value = postalCode_ID;
			scom.Parameters["@gs_DivisionCode"].Value = gs_DivisionCode;
			scom.Parameters["@province_ID"].Value = province_ID;
			scom.Parameters["@telephone_Home"].Value = telephone_Home;
			scom.Parameters["@telephone_Office"].Value = telephone_Office;
			scom.Parameters["@telephone_Ext"].Value = telephone_Ext;
			scom.Parameters["@mobile1"].Value = mobile1;
			scom.Parameters["@mobile2"].Value = mobile2;
			scom.Parameters["@mobile_Office"].Value = mobile_Office;
			scom.Parameters["@emrg_Contact1"].Value = emrg_Contact1;
			scom.Parameters["@emrg_ContactPerson1"].Value = emrg_ContactPerson1;
			scom.Parameters["@emrg_Contact2"].Value = emrg_Contact2;
			scom.Parameters["@emrg_ContactPerson2"].Value = emrg_ContactPerson2;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@email_office"].Value = email_office;
			scom.Parameters["@epfNo"].Value = epfNo;
			scom.Parameters["@designation_ID"].Value = designation_ID;
			scom.Parameters["@empCatagory1_ID"].Value = empCatagory1_ID;
			scom.Parameters["@empCatagory2_ID"].Value = empCatagory2_ID;
			scom.Parameters["@empCatagory3_ID"].Value = empCatagory3_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@subSectionID"].Value = subSectionID;
			scom.Parameters["@employee_RecuirtmentType"].Value = employee_RecuirtmentType;
			scom.Parameters["@dateJoin"].Value = dateJoin;
			scom.Parameters["@dateConfirm"].Value = dateConfirm;
			scom.Parameters["@dateTerminate"].Value = dateTerminate;
			scom.Parameters["@lastWorkingDate"].Value = lastWorkingDate;
			scom.Parameters["@payrollEndDate"].Value = payrollEndDate;
			scom.Parameters["@visaEndDate"].Value = visaEndDate;
			scom.Parameters["@managerID"].Value = managerID;
			scom.Parameters["@supevisorID"].Value = supevisorID;
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@isTime_Attendance"].Value = isTime_Attendance;
			scom.Parameters["@attendanceGroup1_ID"].Value = attendanceGroup1_ID;
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
			scom.Parameters["@isPayrall_Process"].Value = isPayrall_Process;
			scom.Parameters["@isPayslip_Print"].Value = isPayslip_Print;
			scom.Parameters["@isEPF_ETF_Process"].Value = isEPF_ETF_Process;
			scom.Parameters["@is_PayeeProcess"].Value = is_PayeeProcess;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@employee_AccountName"].Value = employee_AccountName;
			scom.Parameters["@employee_AccountNo"].Value = employee_AccountNo;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
			scom.Parameters["@payroll_Level"].Value = payroll_Level;
			scom.Parameters["@payroll_ProcessGroupID"].Value = payroll_ProcessGroupID;
			scom.Parameters["@emp_statusID"].Value = emp_statusID;
			scom.Parameters["@employee_Image"].Value = employee_Image;
			scom.Parameters["@isSportman"].Value = isSportman;
			scom.Parameters["@isSalesManager"].Value = isSalesManager;
			scom.Parameters["@isAreaManager"].Value = isAreaManager;
			scom.Parameters["@isSelesRep"].Value = isSelesRep;
			scom.Parameters["@isSalesExecutive"].Value = isSalesExecutive;
			scom.Parameters["@isDriver"].Value = isDriver;
			scom.Parameters["@isAssistant"].Value = isAssistant;
			scom.Parameters["@isOperator"].Value = isOperator;
			scom.Parameters["@isRosterBasedEmployee"].Value = isRosterBasedEmployee;
			scom.Parameters["@salesTarget"].Value = salesTarget;
			scom.Parameters["@minimumSalesTarget"].Value = minimumSalesTarget;
			scom.Parameters["@commisionPersentage_Normal"].Value = commisionPersentage_Normal;
			scom.Parameters["@commisionPersentage_Bones"].Value = commisionPersentage_Bones;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMasEmployee table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmpCatagory2_ID(string empCatagory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByEmpCatagory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@empCatagory2_ID", SqlDbType.VarChar,8);
			scom.Parameters["@empCatagory2_ID"].Value = empCatagory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByTitleID(string titleID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByTitleID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@titleID", SqlDbType.VarChar,8);
			scom.Parameters["@titleID"].Value = titleID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaymentMethod_ID(string paymentMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByPaymentMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByBankBranch_ID(string bankBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByBankBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByDesignation_ID(string designation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByDesignation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@designation_ID", SqlDbType.VarChar,8);
			scom.Parameters["@designation_ID"].Value = designation_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByNationality_ID(string nationality_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByNationality_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@nationality_ID", SqlDbType.VarChar,8);
			scom.Parameters["@nationality_ID"].Value = nationality_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByPostalCode_ID(string postalCode_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByPostalCode_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@postalCode_ID", SqlDbType.VarChar,8);
			scom.Parameters["@postalCode_ID"].Value = postalCode_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,8);
			scom.Parameters["@town_ID"].Value = town_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,8);
			scom.Parameters["@country_ID"].Value = country_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByReligion_ID(string religion_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByReligion_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@religion_ID", SqlDbType.VarChar,8);
			scom.Parameters["@religion_ID"].Value = religion_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmpCatagory1_ID(string empCatagory1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByEmpCatagory1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@empCatagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters["@empCatagory1_ID"].Value = empCatagory1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByDistrict_ID(string district_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByDistrict_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,8);
			scom.Parameters["@district_ID"].Value = district_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmpCatagory3_ID(string empCatagory3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByEmpCatagory3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@empCatagory3_ID", SqlDbType.VarChar,8);
			scom.Parameters["@empCatagory3_ID"].Value = empCatagory3_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByCity_ID(string city_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,8);
			scom.Parameters["@city_ID"].Value = city_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasEmployee table.
		/// </summary>
		public static tbl_genMasEmployee Select(string employee_ID_Incoming, string company_ID_Incoming, string companyBranch_ID_Incoming){

			tbl_genMasEmployee tbl_genMasEmployeeins = new tbl_genMasEmployee();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasEmployeeins = Maketbl_genMasEmployee(dataReader);
				} else {
					tbl_genMasEmployeeins = null;
				}
			}
			scon.Close();
			return tbl_genMasEmployeeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByEmpCatagory2_ID(string empCatagory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByEmpCatagory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@empCatagory2_ID", SqlDbType.VarChar,8);
			scom.Parameters["@empCatagory2_ID"].Value = empCatagory2_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByTitleID(string titleID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByTitleID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@titleID", SqlDbType.VarChar,8);
			scom.Parameters["@titleID"].Value = titleID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByPaymentMethod_ID(string paymentMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByPaymentMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByBankBranch_ID(string bankBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByBankBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByDesignation_ID(string designation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByDesignation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@designation_ID", SqlDbType.VarChar,8);
			scom.Parameters["@designation_ID"].Value = designation_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByNationality_ID(string nationality_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByNationality_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@nationality_ID", SqlDbType.VarChar,8);
			scom.Parameters["@nationality_ID"].Value = nationality_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByPostalCode_ID(string postalCode_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByPostalCode_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@postalCode_ID", SqlDbType.VarChar,8);
			scom.Parameters["@postalCode_ID"].Value = postalCode_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,8);
			scom.Parameters["@town_ID"].Value = town_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,8);
			scom.Parameters["@country_ID"].Value = country_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
        /// <summary>
        /// Selects all records from the tbl_genMasEmployee table by a foreign key.
        /// </summary>
        public static List<tbl_genMasEmployee> SelectAllByCompany_ID_CompanyBranch_ID_Payroll_ProcessGroupID(string company_ID, string companyBranch_ID, string payroll_ProcessGroupID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByCompany_ID_CompanyBranch_ID_Payroll_ProcessGroupID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@company_ID", SqlDbType.VarChar, 8);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 8);
            scom.Parameters.Add("@payroll_ProcessGroupID", SqlDbType.VarChar, 10);
            scom.Parameters["@company_ID"].Value = company_ID;
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@payroll_ProcessGroupID"].Value = payroll_ProcessGroupID;
            List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
                    tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
                }
            }
            scon.Close();
            return tbl_genMasEmployeeList;
        }
        /// <summary>
        /// Selects all records from the tbl_genMasEmployee table by a foreign key.
        /// </summary>
        public static List<tbl_genMasEmployee> SelectAllByReligion_ID(string religion_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByReligion_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@religion_ID", SqlDbType.VarChar,8);
			scom.Parameters["@religion_ID"].Value = religion_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByEmpCatagory1_ID(string empCatagory1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByEmpCatagory1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@empCatagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters["@empCatagory1_ID"].Value = empCatagory1_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByDistrict_ID(string district_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByDistrict_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,8);
			scom.Parameters["@district_ID"].Value = district_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByEmpCatagory3_ID(string empCatagory3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByEmpCatagory3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@empCatagory3_ID", SqlDbType.VarChar,8);
			scom.Parameters["@empCatagory3_ID"].Value = empCatagory3_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByCity_ID(string city_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,8);
			scom.Parameters["@city_ID"].Value = city_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployeeSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_genMasEmployee> tbl_genMasEmployeeList = new List<tbl_genMasEmployee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee tbl_genMasEmployee = Maketbl_genMasEmployee(dataReader);
					tbl_genMasEmployeeList.Add(tbl_genMasEmployee);
				}
			}
			scon.Close();
			return tbl_genMasEmployeeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMasEmployee class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasEmployee Maketbl_genMasEmployee(SqlDataReader dataReader) {
			tbl_genMasEmployee tbl_genMasEmployee = new tbl_genMasEmployee();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasEmployee.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasEmployee.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasEmployee.Employee_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasEmployee.Employee_ID2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasEmployee.TitleID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasEmployee.FullName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMasEmployee.Initails = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMasEmployee.SurName = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMasEmployee.AliasName = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMasEmployee.NicNo = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMasEmployee.DrivingLic_No = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMasEmployee.PassportNo = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMasEmployee.Nationality_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genMasEmployee.Religion_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genMasEmployee.DateOfBirth = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genMasEmployee.DateOfMerrage = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genMasEmployee.Gender = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genMasEmployee.CivilState = dataReader.GetInt32(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genMasEmployee.AddressLine1 = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genMasEmployee.AddressLine2 = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genMasEmployee.AddressLine3 = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genMasEmployee.Town_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genMasEmployee.City_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genMasEmployee.District_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genMasEmployee.Country_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genMasEmployee.PostalCode_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genMasEmployee.Gs_DivisionCode = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_genMasEmployee.Province_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_genMasEmployee.Telephone_Home = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_genMasEmployee.Telephone_Office = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_genMasEmployee.Telephone_Ext = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_genMasEmployee.Mobile1 = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_genMasEmployee.Mobile2 = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_genMasEmployee.Mobile_Office = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_genMasEmployee.Emrg_Contact1 = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_genMasEmployee.Emrg_ContactPerson1 = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_genMasEmployee.Emrg_Contact2 = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_genMasEmployee.Emrg_ContactPerson2 = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_genMasEmployee.Email = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_genMasEmployee.Email_office = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_genMasEmployee.EpfNo = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_genMasEmployee.Designation_ID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_genMasEmployee.EmpCatagory1_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_genMasEmployee.EmpCatagory2_ID = dataReader.GetString(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_genMasEmployee.EmpCatagory3_ID = dataReader.GetString(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_genMasEmployee.Department_ID = dataReader.GetString(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_genMasEmployee.Division_ID = dataReader.GetString(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_genMasEmployee.SectionID = dataReader.GetString(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_genMasEmployee.SubSectionID = dataReader.GetString(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_genMasEmployee.Employee_RecuirtmentType = dataReader.GetString(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_genMasEmployee.DateJoin = dataReader.GetDateTime(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_genMasEmployee.DateConfirm = dataReader.GetDateTime(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_genMasEmployee.DateTerminate = dataReader.GetDateTime(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_genMasEmployee.LastWorkingDate = dataReader.GetDateTime(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_genMasEmployee.PayrollEndDate = dataReader.GetDateTime(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_genMasEmployee.VisaEndDate = dataReader.GetDateTime(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_genMasEmployee.ManagerID = dataReader.GetString(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_genMasEmployee.SupevisorID = dataReader.GetString(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_genMasEmployee.Shift_ID = dataReader.GetString(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_genMasEmployee.IsTime_Attendance = dataReader.GetBoolean(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_genMasEmployee.AttendanceGroup1_ID = dataReader.GetString(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_genMasEmployee.AttendanceGroup2_ID = dataReader.GetString(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_genMasEmployee.IsPayrall_Process = dataReader.GetBoolean(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_genMasEmployee.IsPayslip_Print = dataReader.GetBoolean(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_genMasEmployee.IsEPF_ETF_Process = dataReader.GetBoolean(64);
			}
			if (dataReader.IsDBNull(65) == false) {
				tbl_genMasEmployee.Is_PayeeProcess = dataReader.GetBoolean(65);
			}
			if (dataReader.IsDBNull(66) == false) {
				tbl_genMasEmployee.PaymentMethod_ID = dataReader.GetString(66);
			}
			if (dataReader.IsDBNull(67) == false) {
				tbl_genMasEmployee.Employee_AccountName = dataReader.GetString(67);
			}
			if (dataReader.IsDBNull(68) == false) {
				tbl_genMasEmployee.Employee_AccountNo = dataReader.GetString(68);
			}
			if (dataReader.IsDBNull(69) == false) {
				tbl_genMasEmployee.Bank_ID = dataReader.GetString(69);
			}
			if (dataReader.IsDBNull(70) == false) {
				tbl_genMasEmployee.BankBranch_ID = dataReader.GetString(70);
			}
			if (dataReader.IsDBNull(71) == false) {
				tbl_genMasEmployee.Payroll_Level = dataReader.GetString(71);
			}
			if (dataReader.IsDBNull(72) == false) {
				tbl_genMasEmployee.Payroll_ProcessGroupID = dataReader.GetString(72);
			}
			if (dataReader.IsDBNull(73) == false) {
				tbl_genMasEmployee.Emp_statusID = dataReader.GetString(73);
			}
			if (dataReader.IsDBNull(74) == false) {
				tbl_genMasEmployee.Employee_Image = (byte[])dataReader[74];
            }
			if (dataReader.IsDBNull(75) == false) {
				tbl_genMasEmployee.IsSportman = dataReader.GetBoolean(75);
			}
			if (dataReader.IsDBNull(76) == false) {
				tbl_genMasEmployee.IsSalesManager = dataReader.GetBoolean(76);
			}
			if (dataReader.IsDBNull(77) == false) {
				tbl_genMasEmployee.IsAreaManager = dataReader.GetBoolean(77);
			}
			if (dataReader.IsDBNull(78) == false) {
				tbl_genMasEmployee.IsSelesRep = dataReader.GetBoolean(78);
			}
			if (dataReader.IsDBNull(79) == false) {
				tbl_genMasEmployee.IsSalesExecutive = dataReader.GetBoolean(79);
			}
			if (dataReader.IsDBNull(80) == false) {
				tbl_genMasEmployee.IsDriver = dataReader.GetBoolean(80);
			}
			if (dataReader.IsDBNull(81) == false) {
				tbl_genMasEmployee.IsAssistant = dataReader.GetBoolean(81);
			}
			if (dataReader.IsDBNull(82) == false) {
				tbl_genMasEmployee.IsOperator = dataReader.GetBoolean(82);
			}
			if (dataReader.IsDBNull(83) == false) {
				tbl_genMasEmployee.IsRosterBasedEmployee = dataReader.GetBoolean(83);
			}
			if (dataReader.IsDBNull(84) == false) {
				tbl_genMasEmployee.SalesTarget = dataReader.GetDecimal(84);
			}
			if (dataReader.IsDBNull(85) == false) {
				tbl_genMasEmployee.MinimumSalesTarget = dataReader.GetDecimal(85);
			}
			if (dataReader.IsDBNull(86) == false) {
				tbl_genMasEmployee.CommisionPersentage_Normal = dataReader.GetDecimal(86);
			}
			if (dataReader.IsDBNull(87) == false) {
				tbl_genMasEmployee.CommisionPersentage_Bones = dataReader.GetDecimal(87);
			}
			if (dataReader.IsDBNull(88) == false) {
				tbl_genMasEmployee.IsCanceled = dataReader.GetBoolean(88);
			}
			if (dataReader.IsDBNull(89) == false) {
				tbl_genMasEmployee.UserID_Created = dataReader.GetString(89);
			}
			if (dataReader.IsDBNull(90) == false) {
				tbl_genMasEmployee.UserID_Modified = dataReader.GetString(90);
			}
			if (dataReader.IsDBNull(91) == false) {
				tbl_genMasEmployee.UserID_Canceled = dataReader.GetString(91);
			}
			if (dataReader.IsDBNull(92) == false) {
				tbl_genMasEmployee.TerminalID_Created = dataReader.GetString(92);
			}
			if (dataReader.IsDBNull(93) == false) {
				tbl_genMasEmployee.TerminalID_Modified = dataReader.GetString(93);
			}
			if (dataReader.IsDBNull(94) == false) {
				tbl_genMasEmployee.TerminalID_Canceled = dataReader.GetString(94);
			}
			if (dataReader.IsDBNull(95) == false) {
				tbl_genMasEmployee.Date_Created = dataReader.GetDateTime(95);
			}
			if (dataReader.IsDBNull(96) == false) {
				tbl_genMasEmployee.Date_Modified = dataReader.GetDateTime(96);
			}
			if (dataReader.IsDBNull(97) == false) {
				tbl_genMasEmployee.Date_Canceled = dataReader.GetDateTime(97);
			}

			return tbl_genMasEmployee;
		}
		/// <summary>
		/// This makes tbl_genMasEmployee datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasEmployee object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasEmployee  tbl_genMasEmployee   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_employee_ID2 = new DataColumn("employee_ID2" , typeof(string));
			DataColumn col_titleID = new DataColumn("titleID" , typeof(string));
			DataColumn col_fullName = new DataColumn("fullName" , typeof(string));
			DataColumn col_initails = new DataColumn("initails" , typeof(string));
			DataColumn col_surName = new DataColumn("surName" , typeof(string));
			DataColumn col_aliasName = new DataColumn("aliasName" , typeof(string));
			DataColumn col_nicNo = new DataColumn("nicNo" , typeof(string));
			DataColumn col_drivingLic_No = new DataColumn("drivingLic_No" , typeof(string));
			DataColumn col_passportNo = new DataColumn("passportNo" , typeof(string));
			DataColumn col_nationality_ID = new DataColumn("nationality_ID" , typeof(string));
			DataColumn col_religion_ID = new DataColumn("religion_ID" , typeof(string));
			DataColumn col_dateOfBirth = new DataColumn("dateOfBirth" , typeof(DateTime));
			DataColumn col_dateOfMerrage = new DataColumn("dateOfMerrage" , typeof(DateTime));
			DataColumn col_gender = new DataColumn("gender" , typeof(int));
			DataColumn col_civilState = new DataColumn("civilState" , typeof(int));
			DataColumn col_addressLine1 = new DataColumn("addressLine1" , typeof(string));
			DataColumn col_addressLine2 = new DataColumn("addressLine2" , typeof(string));
			DataColumn col_addressLine3 = new DataColumn("addressLine3" , typeof(string));
			DataColumn col_town_ID = new DataColumn("town_ID" , typeof(string));
			DataColumn col_city_ID = new DataColumn("city_ID" , typeof(string));
			DataColumn col_district_ID = new DataColumn("district_ID" , typeof(string));
			DataColumn col_country_ID = new DataColumn("country_ID" , typeof(string));
			DataColumn col_postalCode_ID = new DataColumn("postalCode_ID" , typeof(string));
			DataColumn col_gs_DivisionCode = new DataColumn("gs_DivisionCode" , typeof(string));
			DataColumn col_province_ID = new DataColumn("province_ID" , typeof(string));
			DataColumn col_telephone_Home = new DataColumn("telephone_Home" , typeof(string));
			DataColumn col_telephone_Office = new DataColumn("telephone_Office" , typeof(string));
			DataColumn col_telephone_Ext = new DataColumn("telephone_Ext" , typeof(string));
			DataColumn col_mobile1 = new DataColumn("mobile1" , typeof(string));
			DataColumn col_mobile2 = new DataColumn("mobile2" , typeof(string));
			DataColumn col_mobile_Office = new DataColumn("mobile_Office" , typeof(string));
			DataColumn col_emrg_Contact1 = new DataColumn("emrg_Contact1" , typeof(string));
			DataColumn col_emrg_ContactPerson1 = new DataColumn("emrg_ContactPerson1" , typeof(string));
			DataColumn col_emrg_Contact2 = new DataColumn("emrg_Contact2" , typeof(string));
			DataColumn col_emrg_ContactPerson2 = new DataColumn("emrg_ContactPerson2" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
			DataColumn col_email_office = new DataColumn("email_office" , typeof(string));
			DataColumn col_epfNo = new DataColumn("epfNo" , typeof(string));
			DataColumn col_designation_ID = new DataColumn("designation_ID" , typeof(string));
			DataColumn col_empCatagory1_ID = new DataColumn("empCatagory1_ID" , typeof(string));
			DataColumn col_empCatagory2_ID = new DataColumn("empCatagory2_ID" , typeof(string));
			DataColumn col_empCatagory3_ID = new DataColumn("empCatagory3_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_sectionID = new DataColumn("sectionID" , typeof(string));
			DataColumn col_subSectionID = new DataColumn("subSectionID" , typeof(string));
			DataColumn col_employee_RecuirtmentType = new DataColumn("employee_RecuirtmentType" , typeof(string));
			DataColumn col_dateJoin = new DataColumn("dateJoin" , typeof(DateTime));
			DataColumn col_dateConfirm = new DataColumn("dateConfirm" , typeof(DateTime));
			DataColumn col_dateTerminate = new DataColumn("dateTerminate" , typeof(DateTime));
			DataColumn col_lastWorkingDate = new DataColumn("lastWorkingDate" , typeof(DateTime));
			DataColumn col_payrollEndDate = new DataColumn("payrollEndDate" , typeof(DateTime));
			DataColumn col_visaEndDate = new DataColumn("visaEndDate" , typeof(DateTime));
			DataColumn col_managerID = new DataColumn("managerID" , typeof(string));
			DataColumn col_supevisorID = new DataColumn("supevisorID" , typeof(string));
			DataColumn col_shift_ID = new DataColumn("shift_ID" , typeof(string));
			DataColumn col_isTime_Attendance = new DataColumn("isTime_Attendance" , typeof(bool));
			DataColumn col_attendanceGroup1_ID = new DataColumn("attendanceGroup1_ID" , typeof(string));
			DataColumn col_attendanceGroup2_ID = new DataColumn("attendanceGroup2_ID" , typeof(string));
			DataColumn col_isPayrall_Process = new DataColumn("isPayrall_Process" , typeof(bool));
			DataColumn col_isPayslip_Print = new DataColumn("isPayslip_Print" , typeof(bool));
			DataColumn col_isEPF_ETF_Process = new DataColumn("isEPF_ETF_Process" , typeof(bool));
			DataColumn col_is_PayeeProcess = new DataColumn("is_PayeeProcess" , typeof(bool));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_employee_AccountName = new DataColumn("employee_AccountName" , typeof(string));
			DataColumn col_employee_AccountNo = new DataColumn("employee_AccountNo" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_bankBranch_ID = new DataColumn("bankBranch_ID" , typeof(string));
			DataColumn col_payroll_Level = new DataColumn("payroll_Level" , typeof(string));
			DataColumn col_payroll_ProcessGroupID = new DataColumn("payroll_ProcessGroupID" , typeof(string));
			DataColumn col_emp_statusID = new DataColumn("emp_statusID" , typeof(string));
			DataColumn col_employee_Image = new DataColumn("employee_Image" , typeof(byte));
			DataColumn col_isSportman = new DataColumn("isSportman" , typeof(bool));
			DataColumn col_isSalesManager = new DataColumn("isSalesManager" , typeof(bool));
			DataColumn col_isAreaManager = new DataColumn("isAreaManager" , typeof(bool));
			DataColumn col_isSelesRep = new DataColumn("isSelesRep" , typeof(bool));
			DataColumn col_isSalesExecutive = new DataColumn("isSalesExecutive" , typeof(bool));
			DataColumn col_isDriver = new DataColumn("isDriver" , typeof(bool));
			DataColumn col_isAssistant = new DataColumn("isAssistant" , typeof(bool));
			DataColumn col_isOperator = new DataColumn("isOperator" , typeof(bool));
			DataColumn col_isRosterBasedEmployee = new DataColumn("isRosterBasedEmployee" , typeof(bool));
			DataColumn col_salesTarget = new DataColumn("salesTarget" , typeof(decimal));
			DataColumn col_minimumSalesTarget = new DataColumn("minimumSalesTarget" , typeof(decimal));
			DataColumn col_commisionPersentage_Normal = new DataColumn("commisionPersentage_Normal" , typeof(decimal));
			DataColumn col_commisionPersentage_Bones = new DataColumn("commisionPersentage_Bones" , typeof(decimal));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_employee_ID,col_employee_ID2,col_titleID,col_fullName,col_initails,col_surName,col_aliasName,col_nicNo,col_drivingLic_No,col_passportNo,col_nationality_ID,col_religion_ID,col_dateOfBirth,col_dateOfMerrage,col_gender,col_civilState,col_addressLine1,col_addressLine2,col_addressLine3,col_town_ID,col_city_ID,col_district_ID,col_country_ID,col_postalCode_ID,col_gs_DivisionCode,col_province_ID,col_telephone_Home,col_telephone_Office,col_telephone_Ext,col_mobile1,col_mobile2,col_mobile_Office,col_emrg_Contact1,col_emrg_ContactPerson1,col_emrg_Contact2,col_emrg_ContactPerson2,col_email,col_email_office,col_epfNo,col_designation_ID,col_empCatagory1_ID,col_empCatagory2_ID,col_empCatagory3_ID,col_department_ID,col_division_ID,col_sectionID,col_subSectionID,col_employee_RecuirtmentType,col_dateJoin,col_dateConfirm,col_dateTerminate,col_lastWorkingDate,col_payrollEndDate,col_visaEndDate,col_managerID,col_supevisorID,col_shift_ID,col_isTime_Attendance,col_attendanceGroup1_ID,col_attendanceGroup2_ID,col_isPayrall_Process,col_isPayslip_Print,col_isEPF_ETF_Process,col_is_PayeeProcess,col_paymentMethod_ID,col_employee_AccountName,col_employee_AccountNo,col_bank_ID,col_bankBranch_ID,col_payroll_Level,col_payroll_ProcessGroupID,col_emp_statusID,col_employee_Image,col_isSportman,col_isSalesManager,col_isAreaManager,col_isSelesRep,col_isSalesExecutive,col_isDriver,col_isAssistant,col_isOperator,col_isRosterBasedEmployee,col_salesTarget,col_minimumSalesTarget,col_commisionPersentage_Normal,col_commisionPersentage_Bones,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasEmployee datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasEmployee object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasEmployee user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["employee_ID2"] = user.employee_ID2;
			drow["titleID"] = user.titleID;
			drow["fullName"] = user.fullName;
			drow["initails"] = user.initails;
			drow["surName"] = user.surName;
			drow["aliasName"] = user.aliasName;
			drow["nicNo"] = user.nicNo;
			drow["drivingLic_No"] = user.drivingLic_No;
			drow["passportNo"] = user.passportNo;
			drow["nationality_ID"] = user.nationality_ID;
			drow["religion_ID"] = user.religion_ID;
			drow["dateOfBirth"] = user.dateOfBirth;
			drow["dateOfMerrage"] = user.dateOfMerrage;
			drow["gender"] = user.gender;
			drow["civilState"] = user.civilState;
			drow["addressLine1"] = user.addressLine1;
			drow["addressLine2"] = user.addressLine2;
			drow["addressLine3"] = user.addressLine3;
			drow["town_ID"] = user.town_ID;
			drow["city_ID"] = user.city_ID;
			drow["district_ID"] = user.district_ID;
			drow["country_ID"] = user.country_ID;
			drow["postalCode_ID"] = user.postalCode_ID;
			drow["gs_DivisionCode"] = user.gs_DivisionCode;
			drow["province_ID"] = user.province_ID;
			drow["telephone_Home"] = user.telephone_Home;
			drow["telephone_Office"] = user.telephone_Office;
			drow["telephone_Ext"] = user.telephone_Ext;
			drow["mobile1"] = user.mobile1;
			drow["mobile2"] = user.mobile2;
			drow["mobile_Office"] = user.mobile_Office;
			drow["emrg_Contact1"] = user.emrg_Contact1;
			drow["emrg_ContactPerson1"] = user.emrg_ContactPerson1;
			drow["emrg_Contact2"] = user.emrg_Contact2;
			drow["emrg_ContactPerson2"] = user.emrg_ContactPerson2;
			drow["email"] = user.email;
			drow["email_office"] = user.email_office;
			drow["epfNo"] = user.epfNo;
			drow["designation_ID"] = user.designation_ID;
			drow["empCatagory1_ID"] = user.empCatagory1_ID;
			drow["empCatagory2_ID"] = user.empCatagory2_ID;
			drow["empCatagory3_ID"] = user.empCatagory3_ID;
			drow["department_ID"] = user.department_ID;
			drow["division_ID"] = user.division_ID;
			drow["sectionID"] = user.sectionID;
			drow["subSectionID"] = user.subSectionID;
			drow["employee_RecuirtmentType"] = user.employee_RecuirtmentType;
			drow["dateJoin"] = user.dateJoin;
			drow["dateConfirm"] = user.dateConfirm;
			drow["dateTerminate"] = user.dateTerminate;
			drow["lastWorkingDate"] = user.lastWorkingDate;
			drow["payrollEndDate"] = user.payrollEndDate;
			drow["visaEndDate"] = user.visaEndDate;
			drow["managerID"] = user.managerID;
			drow["supevisorID"] = user.supevisorID;
			drow["shift_ID"] = user.shift_ID;
			drow["isTime_Attendance"] = user.isTime_Attendance;
			drow["attendanceGroup1_ID"] = user.attendanceGroup1_ID;
			drow["attendanceGroup2_ID"] = user.attendanceGroup2_ID;
			drow["isPayrall_Process"] = user.isPayrall_Process;
			drow["isPayslip_Print"] = user.isPayslip_Print;
			drow["isEPF_ETF_Process"] = user.isEPF_ETF_Process;
			drow["is_PayeeProcess"] = user.is_PayeeProcess;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["employee_AccountName"] = user.employee_AccountName;
			drow["employee_AccountNo"] = user.employee_AccountNo;
			drow["bank_ID"] = user.bank_ID;
			drow["bankBranch_ID"] = user.bankBranch_ID;
			drow["payroll_Level"] = user.payroll_Level;
			drow["payroll_ProcessGroupID"] = user.payroll_ProcessGroupID;
			drow["emp_statusID"] = user.emp_statusID;
			drow["employee_Image"] = user.employee_Image;
			drow["isSportman"] = user.isSportman;
			drow["isSalesManager"] = user.isSalesManager;
			drow["isAreaManager"] = user.isAreaManager;
			drow["isSelesRep"] = user.isSelesRep;
			drow["isSalesExecutive"] = user.isSalesExecutive;
			drow["isDriver"] = user.isDriver;
			drow["isAssistant"] = user.isAssistant;
			drow["isOperator"] = user.isOperator;
			drow["isRosterBasedEmployee"] = user.isRosterBasedEmployee;
			drow["salesTarget"] = user.salesTarget;
			drow["minimumSalesTarget"] = user.minimumSalesTarget;
			drow["commisionPersentage_Normal"] = user.commisionPersentage_Normal;
			drow["commisionPersentage_Bones"] = user.commisionPersentage_Bones;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
