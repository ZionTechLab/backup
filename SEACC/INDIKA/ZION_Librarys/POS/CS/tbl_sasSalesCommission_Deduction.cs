using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission_Deduction {
		#region Fields
		private string commission_ID;
		private Int64 deduction_ID;
		private string invoice_ID;
		private DateTime invoiceDate;
		private decimal invoiceAmount;
		private decimal pendingAmount;
		private decimal deductionAmount;
		private bool isDeductionApproved;
		private bool isSettled;
		private bool isInvoiceDeduction;
		private string employee_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Deduction class.
		/// </summary>
		public tbl_sasSalesCommission_Deduction() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Deduction class.
		/// </summary>
		public tbl_sasSalesCommission_Deduction(string commission_ID, Int64 deduction_ID, string invoice_ID, DateTime invoiceDate, decimal invoiceAmount, decimal pendingAmount, decimal deductionAmount, bool isDeductionApproved, bool isSettled, bool isInvoiceDeduction, string employee_ID) {
			this.commission_ID = commission_ID;
			this.deduction_ID = deduction_ID;
			this.invoice_ID = invoice_ID;
			this.invoiceDate = invoiceDate;
			this.invoiceAmount = invoiceAmount;
			this.pendingAmount = pendingAmount;
			this.deductionAmount = deductionAmount;
			this.isDeductionApproved = isDeductionApproved;
			this.isSettled = isSettled;
			this.isInvoiceDeduction = isInvoiceDeduction;
			this.employee_ID = employee_ID;
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
		/// Gets or sets the Deduction_ID value.
		/// </summary>
		public Int64 Deduction_ID {
			get { return deduction_ID; }
			set { deduction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceDate value.
		/// </summary>
		public DateTime InvoiceDate {
			get { return invoiceDate; }
			set { invoiceDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceAmount value.
		/// </summary>
		public decimal InvoiceAmount {
			get { return invoiceAmount; }
			set { invoiceAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PendingAmount value.
		/// </summary>
		public decimal PendingAmount {
			get { return pendingAmount; }
			set { pendingAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeductionAmount value.
		/// </summary>
		public decimal DeductionAmount {
			get { return deductionAmount; }
			set { deductionAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeductionApproved value.
		/// </summary>
		public bool IsDeductionApproved {
			get { return isDeductionApproved; }
			set { isDeductionApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSettled value.
		/// </summary>
		public bool IsSettled {
			get { return isSettled; }
			set { isSettled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsInvoiceDeduction value.
		/// </summary>
		public bool IsInvoiceDeduction {
			get { return isInvoiceDeduction; }
			set { isInvoiceDeduction = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission_Deduction table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deduction_ID", SqlDbType.BigInt);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoiceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pendingAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deductionAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDeductionApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isInvoiceDeduction", SqlDbType.Bit,1);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@deduction_ID"].Value = deduction_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@invoiceAmount"].Value = invoiceAmount;
			scom.Parameters["@pendingAmount"].Value = pendingAmount;
			scom.Parameters["@deductionAmount"].Value = deductionAmount;
			scom.Parameters["@isDeductionApproved"].Value = isDeductionApproved;
			scom.Parameters["@isSettled"].Value = isSettled;
			scom.Parameters["@isInvoiceDeduction"].Value = isInvoiceDeduction;
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission_Deduction table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
            scom.Parameters.Add("@deduction_ID", SqlDbType.BigInt);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoiceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pendingAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deductionAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDeductionApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isInvoiceDeduction", SqlDbType.Bit,1);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@deduction_ID"].Value = deduction_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@invoiceAmount"].Value = invoiceAmount;
			scom.Parameters["@pendingAmount"].Value = pendingAmount;
			scom.Parameters["@deductionAmount"].Value = deductionAmount;
			scom.Parameters["@isDeductionApproved"].Value = isDeductionApproved;
			scom.Parameters["@isSettled"].Value = isSettled;
			scom.Parameters["@isInvoiceDeduction"].Value = isInvoiceDeduction;
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission_Deduction table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deduction_ID", SqlDbType.BigInt);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scom.Parameters["@deduction_ID"].Value = deduction_ID;
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Deduction table by a foreign key.
		/// </summary>
		public static void DeleteAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionDeleteAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Deduction table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeduction_ID(Int64 deduction_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionDeleteAllByDeduction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deduction_ID", SqlDbType.BigInt);
			scom.Parameters["@deduction_ID"].Value = deduction_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission_Deduction table.
		/// </summary>
		public static tbl_sasSalesCommission_Deduction Select(string commission_ID_Incoming, Int64 deduction_ID_Incoming, string invoice_ID_Incoming){

			tbl_sasSalesCommission_Deduction tbl_sasSalesCommission_Deductionins = new tbl_sasSalesCommission_Deduction();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deduction_ID", SqlDbType.BigInt);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			scom.Parameters["@deduction_ID"].Value = deduction_ID_Incoming;
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommission_Deductionins = Maketbl_sasSalesCommission_Deduction(dataReader);
				} else {
					tbl_sasSalesCommission_Deductionins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_Deductionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Deduction table.
		/// </summary>
		public static List<tbl_sasSalesCommission_Deduction> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission_Deduction> tbl_sasSalesCommission_DeductionList = new List<tbl_sasSalesCommission_Deduction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Deduction tbl_sasSalesCommission_Deduction = Maketbl_sasSalesCommission_Deduction(dataReader);
					tbl_sasSalesCommission_DeductionList.Add(tbl_sasSalesCommission_Deduction);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_DeductionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Deduction table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_Deduction> SelectAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionSelectAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
				List<tbl_sasSalesCommission_Deduction> tbl_sasSalesCommission_DeductionList = new List<tbl_sasSalesCommission_Deduction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Deduction tbl_sasSalesCommission_Deduction = Maketbl_sasSalesCommission_Deduction(dataReader);
					tbl_sasSalesCommission_DeductionList.Add(tbl_sasSalesCommission_Deduction);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_DeductionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Deduction table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_Deduction> SelectAllByDeduction_ID(Int64 deduction_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_DeductionSelectAllByDeduction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deduction_ID", SqlDbType.BigInt);
			scom.Parameters["@deduction_ID"].Value = deduction_ID;
				List<tbl_sasSalesCommission_Deduction> tbl_sasSalesCommission_DeductionList = new List<tbl_sasSalesCommission_Deduction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Deduction tbl_sasSalesCommission_Deduction = Maketbl_sasSalesCommission_Deduction(dataReader);
					tbl_sasSalesCommission_DeductionList.Add(tbl_sasSalesCommission_Deduction);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_DeductionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission_Deduction class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission_Deduction Maketbl_sasSalesCommission_Deduction(SqlDataReader dataReader) {
			tbl_sasSalesCommission_Deduction tbl_sasSalesCommission_Deduction = new tbl_sasSalesCommission_Deduction();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission_Deduction.Commission_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission_Deduction.Deduction_ID = dataReader.GetInt64(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission_Deduction.Invoice_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission_Deduction.InvoiceDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesCommission_Deduction.InvoiceAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesCommission_Deduction.PendingAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasSalesCommission_Deduction.DeductionAmount = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasSalesCommission_Deduction.IsDeductionApproved = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasSalesCommission_Deduction.IsSettled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasSalesCommission_Deduction.IsInvoiceDeduction = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasSalesCommission_Deduction.Employee_ID = dataReader.GetString(10);
			}

			return tbl_sasSalesCommission_Deduction;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission_Deduction datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Deduction object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission_Deduction  tbl_sasSalesCommission_Deduction   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_deduction_ID = new DataColumn("deduction_ID" , typeof(Int64));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_invoiceDate = new DataColumn("invoiceDate" , typeof(DateTime));
			DataColumn col_invoiceAmount = new DataColumn("invoiceAmount" , typeof(decimal));
			DataColumn col_pendingAmount = new DataColumn("pendingAmount" , typeof(decimal));
			DataColumn col_deductionAmount = new DataColumn("deductionAmount" , typeof(decimal));
			DataColumn col_isDeductionApproved = new DataColumn("isDeductionApproved" , typeof(bool));
			DataColumn col_isSettled = new DataColumn("isSettled" , typeof(bool));
			DataColumn col_isInvoiceDeduction = new DataColumn("isInvoiceDeduction" , typeof(bool));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_commission_ID,col_deduction_ID,col_invoice_ID,col_invoiceDate,col_invoiceAmount,col_pendingAmount,col_deductionAmount,col_isDeductionApproved,col_isSettled,col_isInvoiceDeduction,col_employee_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission_Deduction datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Deduction object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission_Deduction user) {
		DataRow drow = dt.NewRow();
		
			drow["commission_ID"] = user.commission_ID;
			drow["deduction_ID"] = user.deduction_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["invoiceDate"] = user.invoiceDate;
			drow["invoiceAmount"] = user.invoiceAmount;
			drow["pendingAmount"] = user.pendingAmount;
			drow["deductionAmount"] = user.deductionAmount;
			drow["isDeductionApproved"] = user.isDeductionApproved;
			drow["isSettled"] = user.isSettled;
			drow["isInvoiceDeduction"] = user.isInvoiceDeduction;
			drow["employee_ID"] = user.employee_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
