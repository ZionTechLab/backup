using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission {
		#region Fields
		private string commission_ID;
		private DateTime commissionDate;
		private string remark;
		private string employee_ID;
		private string monthName;
		private string yearName;
		private decimal txtInvoices_Valied;
		private decimal txtInvoices_OverDue;
		private decimal txtInvoices_Deduction;
		private decimal txtInvoices_Total;
		private decimal txtCom_SalesTarget;
		private decimal txtCom_ValidInvoicesAmt;
		private decimal txtCom_CreditNoteAmt;
		private decimal txtCom_ValidAmt;
		private decimal txtCom_Commission;
		private decimal txtTot_ValidCommission;
		private decimal txtTot_ExceededSales;
		private decimal txtTot_Deductions;
		private decimal txtTot_Reimbursed;
		private decimal txtTot_Commission;
		private decimal txtInvoices_Rejection;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission class.
		/// </summary>
		public tbl_sasSalesCommission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission class.
		/// </summary>
		public tbl_sasSalesCommission(string commission_ID, DateTime commissionDate, string remark, string employee_ID, string monthName, string yearName, decimal txtInvoices_Valied, decimal txtInvoices_OverDue, decimal txtInvoices_Deduction, decimal txtInvoices_Total, decimal txtCom_SalesTarget, decimal txtCom_ValidInvoicesAmt, decimal txtCom_CreditNoteAmt, decimal txtCom_ValidAmt, decimal txtCom_Commission, decimal txtTot_ValidCommission, decimal txtTot_ExceededSales, decimal txtTot_Deductions, decimal txtTot_Reimbursed, decimal txtTot_Commission, decimal txtInvoices_Rejection) {
			this.commission_ID = commission_ID;
			this.commissionDate = commissionDate;
			this.remark = remark;
			this.employee_ID = employee_ID;
			this.monthName = monthName;
			this.yearName = yearName;
			this.txtInvoices_Valied = txtInvoices_Valied;
			this.txtInvoices_OverDue = txtInvoices_OverDue;
			this.txtInvoices_Deduction = txtInvoices_Deduction;
			this.txtInvoices_Total = txtInvoices_Total;
			this.txtCom_SalesTarget = txtCom_SalesTarget;
			this.txtCom_ValidInvoicesAmt = txtCom_ValidInvoicesAmt;
			this.txtCom_CreditNoteAmt = txtCom_CreditNoteAmt;
			this.txtCom_ValidAmt = txtCom_ValidAmt;
			this.txtCom_Commission = txtCom_Commission;
			this.txtTot_ValidCommission = txtTot_ValidCommission;
			this.txtTot_ExceededSales = txtTot_ExceededSales;
			this.txtTot_Deductions = txtTot_Deductions;
			this.txtTot_Reimbursed = txtTot_Reimbursed;
			this.txtTot_Commission = txtTot_Commission;
			this.txtInvoices_Rejection = txtInvoices_Rejection;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Commission_ID value.
		/// </summary>
		public string Commission_ID {
			get { return commission_ID; }
			set { commission_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommissionDate value.
		/// </summary>
		public DateTime CommissionDate {
			get { return commissionDate; }
			set { commissionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MonthName value.
		/// </summary>
		public string MonthName {
			get { return monthName; }
			set { monthName = value; }
		}
		
		/// <summary>
		/// Gets or sets the YearName value.
		/// </summary>
		public string YearName {
			get { return yearName; }
			set { yearName = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtInvoices_Valied value.
		/// </summary>
		public decimal TxtInvoices_Valied {
			get { return txtInvoices_Valied; }
			set { txtInvoices_Valied = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtInvoices_OverDue value.
		/// </summary>
		public decimal TxtInvoices_OverDue {
			get { return txtInvoices_OverDue; }
			set { txtInvoices_OverDue = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtInvoices_Deduction value.
		/// </summary>
		public decimal TxtInvoices_Deduction {
			get { return txtInvoices_Deduction; }
			set { txtInvoices_Deduction = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtInvoices_Total value.
		/// </summary>
		public decimal TxtInvoices_Total {
			get { return txtInvoices_Total; }
			set { txtInvoices_Total = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtCom_SalesTarget value.
		/// </summary>
		public decimal TxtCom_SalesTarget {
			get { return txtCom_SalesTarget; }
			set { txtCom_SalesTarget = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtCom_ValidInvoicesAmt value.
		/// </summary>
		public decimal TxtCom_ValidInvoicesAmt {
			get { return txtCom_ValidInvoicesAmt; }
			set { txtCom_ValidInvoicesAmt = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtCom_CreditNoteAmt value.
		/// </summary>
		public decimal TxtCom_CreditNoteAmt {
			get { return txtCom_CreditNoteAmt; }
			set { txtCom_CreditNoteAmt = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtCom_ValidAmt value.
		/// </summary>
		public decimal TxtCom_ValidAmt {
			get { return txtCom_ValidAmt; }
			set { txtCom_ValidAmt = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtCom_Commission value.
		/// </summary>
		public decimal TxtCom_Commission {
			get { return txtCom_Commission; }
			set { txtCom_Commission = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtTot_ValidCommission value.
		/// </summary>
		public decimal TxtTot_ValidCommission {
			get { return txtTot_ValidCommission; }
			set { txtTot_ValidCommission = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtTot_ExceededSales value.
		/// </summary>
		public decimal TxtTot_ExceededSales {
			get { return txtTot_ExceededSales; }
			set { txtTot_ExceededSales = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtTot_Deductions value.
		/// </summary>
		public decimal TxtTot_Deductions {
			get { return txtTot_Deductions; }
			set { txtTot_Deductions = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtTot_Reimbursed value.
		/// </summary>
		public decimal TxtTot_Reimbursed {
			get { return txtTot_Reimbursed; }
			set { txtTot_Reimbursed = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtTot_Commission value.
		/// </summary>
		public decimal TxtTot_Commission {
			get { return txtTot_Commission; }
			set { txtTot_Commission = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtInvoices_Rejection value.
		/// </summary>
		public decimal TxtInvoices_Rejection {
			get { return txtInvoices_Rejection; }
			set { txtInvoices_Rejection = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@commissionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@monthName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@yearName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@txtInvoices_Valied", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtInvoices_OverDue", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtInvoices_Deduction", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtInvoices_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_SalesTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_ValidInvoicesAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_CreditNoteAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_ValidAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_Commission", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_ValidCommission", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_ExceededSales", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_Deductions", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_Reimbursed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_Commission", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtInvoices_Rejection", SqlDbType.Decimal,9);
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@commissionDate"].Value = commissionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@monthName"].Value = monthName;
			scom.Parameters["@yearName"].Value = yearName;
			scom.Parameters["@txtInvoices_Valied"].Value = txtInvoices_Valied;
			scom.Parameters["@txtInvoices_OverDue"].Value = txtInvoices_OverDue;
			scom.Parameters["@txtInvoices_Deduction"].Value = txtInvoices_Deduction;
			scom.Parameters["@txtInvoices_Total"].Value = txtInvoices_Total;
			scom.Parameters["@txtCom_SalesTarget"].Value = txtCom_SalesTarget;
			scom.Parameters["@txtCom_ValidInvoicesAmt"].Value = txtCom_ValidInvoicesAmt;
			scom.Parameters["@txtCom_CreditNoteAmt"].Value = txtCom_CreditNoteAmt;
			scom.Parameters["@txtCom_ValidAmt"].Value = txtCom_ValidAmt;
			scom.Parameters["@txtCom_Commission"].Value = txtCom_Commission;
			scom.Parameters["@txtTot_ValidCommission"].Value = txtTot_ValidCommission;
			scom.Parameters["@txtTot_ExceededSales"].Value = txtTot_ExceededSales;
			scom.Parameters["@txtTot_Deductions"].Value = txtTot_Deductions;
			scom.Parameters["@txtTot_Reimbursed"].Value = txtTot_Reimbursed;
			scom.Parameters["@txtTot_Commission"].Value = txtTot_Commission;
			scom.Parameters["@txtInvoices_Rejection"].Value = txtInvoices_Rejection;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@commissionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@monthName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@yearName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@txtInvoices_Valied", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtInvoices_OverDue", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtInvoices_Deduction", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtInvoices_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_SalesTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_ValidInvoicesAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_CreditNoteAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_ValidAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtCom_Commission", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_ValidCommission", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_ExceededSales", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_Deductions", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_Reimbursed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtTot_Commission", SqlDbType.Decimal,9);
			scom.Parameters.Add("@txtInvoices_Rejection", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@commissionDate"].Value = commissionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@monthName"].Value = monthName;
			scom.Parameters["@yearName"].Value = yearName;
			scom.Parameters["@txtInvoices_Valied"].Value = txtInvoices_Valied;
			scom.Parameters["@txtInvoices_OverDue"].Value = txtInvoices_OverDue;
			scom.Parameters["@txtInvoices_Deduction"].Value = txtInvoices_Deduction;
			scom.Parameters["@txtInvoices_Total"].Value = txtInvoices_Total;
			scom.Parameters["@txtCom_SalesTarget"].Value = txtCom_SalesTarget;
			scom.Parameters["@txtCom_ValidInvoicesAmt"].Value = txtCom_ValidInvoicesAmt;
			scom.Parameters["@txtCom_CreditNoteAmt"].Value = txtCom_CreditNoteAmt;
			scom.Parameters["@txtCom_ValidAmt"].Value = txtCom_ValidAmt;
			scom.Parameters["@txtCom_Commission"].Value = txtCom_Commission;
			scom.Parameters["@txtTot_ValidCommission"].Value = txtTot_ValidCommission;
			scom.Parameters["@txtTot_ExceededSales"].Value = txtTot_ExceededSales;
			scom.Parameters["@txtTot_Deductions"].Value = txtTot_Deductions;
			scom.Parameters["@txtTot_Reimbursed"].Value = txtTot_Reimbursed;
			scom.Parameters["@txtTot_Commission"].Value = txtTot_Commission;
			scom.Parameters["@txtInvoices_Rejection"].Value = txtInvoices_Rejection;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommissionDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission table.
		/// </summary>
		public static tbl_sasSalesCommission Select(string commission_ID_Incoming){

			tbl_sasSalesCommission tbl_sasSalesCommissionins = new tbl_sasSalesCommission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommissionins = Maketbl_sasSalesCommission(dataReader);
				} else {
					tbl_sasSalesCommissionins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission table.
		/// </summary>
		public static List<tbl_sasSalesCommission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission> tbl_sasSalesCommissionList = new List<tbl_sasSalesCommission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission tbl_sasSalesCommission = Maketbl_sasSalesCommission(dataReader);
					tbl_sasSalesCommissionList.Add(tbl_sasSalesCommission);
				}
			}
			scon.Close();
			return tbl_sasSalesCommissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommissionSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_sasSalesCommission> tbl_sasSalesCommissionList = new List<tbl_sasSalesCommission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission tbl_sasSalesCommission = Maketbl_sasSalesCommission(dataReader);
					tbl_sasSalesCommissionList.Add(tbl_sasSalesCommission);
				}
			}
			scon.Close();
			return tbl_sasSalesCommissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission Maketbl_sasSalesCommission(SqlDataReader dataReader) {
			tbl_sasSalesCommission tbl_sasSalesCommission = new tbl_sasSalesCommission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission.Commission_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission.CommissionDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission.Employee_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesCommission.MonthName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesCommission.YearName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasSalesCommission.TxtInvoices_Valied = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasSalesCommission.TxtInvoices_OverDue = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasSalesCommission.TxtInvoices_Deduction = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasSalesCommission.TxtInvoices_Total = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasSalesCommission.TxtCom_SalesTarget = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasSalesCommission.TxtCom_ValidInvoicesAmt = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasSalesCommission.TxtCom_CreditNoteAmt = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasSalesCommission.TxtCom_ValidAmt = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasSalesCommission.TxtCom_Commission = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasSalesCommission.TxtTot_ValidCommission = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasSalesCommission.TxtTot_ExceededSales = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasSalesCommission.TxtTot_Deductions = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasSalesCommission.TxtTot_Reimbursed = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasSalesCommission.TxtTot_Commission = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasSalesCommission.TxtInvoices_Rejection = dataReader.GetDecimal(20);
			}

			return tbl_sasSalesCommission;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission  tbl_sasSalesCommission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_commissionDate = new DataColumn("commissionDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_monthName = new DataColumn("monthName" , typeof(string));
			DataColumn col_yearName = new DataColumn("yearName" , typeof(string));
			DataColumn col_txtInvoices_Valied = new DataColumn("txtInvoices_Valied" , typeof(decimal));
			DataColumn col_txtInvoices_OverDue = new DataColumn("txtInvoices_OverDue" , typeof(decimal));
			DataColumn col_txtInvoices_Deduction = new DataColumn("txtInvoices_Deduction" , typeof(decimal));
			DataColumn col_txtInvoices_Total = new DataColumn("txtInvoices_Total" , typeof(decimal));
			DataColumn col_txtCom_SalesTarget = new DataColumn("txtCom_SalesTarget" , typeof(decimal));
			DataColumn col_txtCom_ValidInvoicesAmt = new DataColumn("txtCom_ValidInvoicesAmt" , typeof(decimal));
			DataColumn col_txtCom_CreditNoteAmt = new DataColumn("txtCom_CreditNoteAmt" , typeof(decimal));
			DataColumn col_txtCom_ValidAmt = new DataColumn("txtCom_ValidAmt" , typeof(decimal));
			DataColumn col_txtCom_Commission = new DataColumn("txtCom_Commission" , typeof(decimal));
			DataColumn col_txtTot_ValidCommission = new DataColumn("txtTot_ValidCommission" , typeof(decimal));
			DataColumn col_txtTot_ExceededSales = new DataColumn("txtTot_ExceededSales" , typeof(decimal));
			DataColumn col_txtTot_Deductions = new DataColumn("txtTot_Deductions" , typeof(decimal));
			DataColumn col_txtTot_Reimbursed = new DataColumn("txtTot_Reimbursed" , typeof(decimal));
			DataColumn col_txtTot_Commission = new DataColumn("txtTot_Commission" , typeof(decimal));
			DataColumn col_txtInvoices_Rejection = new DataColumn("txtInvoices_Rejection" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_commission_ID,col_commissionDate,col_remark,col_employee_ID,col_monthName,col_yearName,col_txtInvoices_Valied,col_txtInvoices_OverDue,col_txtInvoices_Deduction,col_txtInvoices_Total,col_txtCom_SalesTarget,col_txtCom_ValidInvoicesAmt,col_txtCom_CreditNoteAmt,col_txtCom_ValidAmt,col_txtCom_Commission,col_txtTot_ValidCommission,col_txtTot_ExceededSales,col_txtTot_Deductions,col_txtTot_Reimbursed,col_txtTot_Commission,col_txtInvoices_Rejection,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission user) {
		DataRow drow = dt.NewRow();
		
			drow["commission_ID"] = user.commission_ID;
			drow["commissionDate"] = user.commissionDate;
			drow["remark"] = user.remark;
			drow["employee_ID"] = user.employee_ID;
			drow["monthName"] = user.monthName;
			drow["yearName"] = user.yearName;
			drow["txtInvoices_Valied"] = user.txtInvoices_Valied;
			drow["txtInvoices_OverDue"] = user.txtInvoices_OverDue;
			drow["txtInvoices_Deduction"] = user.txtInvoices_Deduction;
			drow["txtInvoices_Total"] = user.txtInvoices_Total;
			drow["txtCom_SalesTarget"] = user.txtCom_SalesTarget;
			drow["txtCom_ValidInvoicesAmt"] = user.txtCom_ValidInvoicesAmt;
			drow["txtCom_CreditNoteAmt"] = user.txtCom_CreditNoteAmt;
			drow["txtCom_ValidAmt"] = user.txtCom_ValidAmt;
			drow["txtCom_Commission"] = user.txtCom_Commission;
			drow["txtTot_ValidCommission"] = user.txtTot_ValidCommission;
			drow["txtTot_ExceededSales"] = user.txtTot_ExceededSales;
			drow["txtTot_Deductions"] = user.txtTot_Deductions;
			drow["txtTot_Reimbursed"] = user.txtTot_Reimbursed;
			drow["txtTot_Commission"] = user.txtTot_Commission;
			drow["txtInvoices_Rejection"] = user.txtInvoices_Rejection;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
