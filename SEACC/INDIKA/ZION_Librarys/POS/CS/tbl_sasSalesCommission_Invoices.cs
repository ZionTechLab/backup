using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission_Invoices {
		#region Fields
		private int line_No;
		private string commission_ID;
		private string invoice_ID;
		private DateTime invoiceDate;
		private decimal invoiceAmount;
		private decimal allocationAmount;
		private int days;
		private string customerName;
		private bool isRejected;
		private bool isValied;
		private bool isOverDue;
		private bool isDeduction;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Invoices class.
		/// </summary>
		public tbl_sasSalesCommission_Invoices() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Invoices class.
		/// </summary>
		public tbl_sasSalesCommission_Invoices(int line_No, string commission_ID, string invoice_ID, DateTime invoiceDate, decimal invoiceAmount, decimal allocationAmount, int days, string customerName, bool isRejected, bool isValied, bool isOverDue, bool isDeduction) {
			this.line_No = line_No;
			this.commission_ID = commission_ID;
			this.invoice_ID = invoice_ID;
			this.invoiceDate = invoiceDate;
			this.invoiceAmount = invoiceAmount;
			this.allocationAmount = allocationAmount;
			this.days = days;
			this.customerName = customerName;
			this.isRejected = isRejected;
			this.isValied = isValied;
			this.isOverDue = isOverDue;
			this.isDeduction = isDeduction;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Commission_ID value.
		/// </summary>
		public string Commission_ID {
			get { return commission_ID; }
			set { commission_ID = value; }
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
		/// Gets or sets the AllocationAmount value.
		/// </summary>
		public decimal AllocationAmount {
			get { return allocationAmount; }
			set { allocationAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Days value.
		/// </summary>
		public int Days {
			get { return days; }
			set { days = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRejected value.
		/// </summary>
		public bool IsRejected {
			get { return isRejected; }
			set { isRejected = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsValied value.
		/// </summary>
		public bool IsValied {
			get { return isValied; }
			set { isValied = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOverDue value.
		/// </summary>
		public bool IsOverDue {
			get { return isOverDue; }
			set { isOverDue = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeduction value.
		/// </summary>
		public bool IsDeduction {
			get { return isDeduction; }
			set { isDeduction = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission_Invoices table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_InvoicesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure; 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoiceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocationAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@days", SqlDbType.Int,4);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isRejected", SqlDbType.Bit,1);
			scom.Parameters.Add("@isValied", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverDue", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeduction", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@invoiceAmount"].Value = invoiceAmount;
			scom.Parameters["@allocationAmount"].Value = allocationAmount;
			scom.Parameters["@days"].Value = days;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@isRejected"].Value = isRejected;
			scom.Parameters["@isValied"].Value = isValied;
			scom.Parameters["@isOverDue"].Value = isOverDue;
			scom.Parameters["@isDeduction"].Value = isDeduction;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission_Invoices table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_InvoicesUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoiceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocationAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@days", SqlDbType.Int,4);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isRejected", SqlDbType.Bit,1);
			scom.Parameters.Add("@isValied", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverDue", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeduction", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@invoiceAmount"].Value = invoiceAmount;
			scom.Parameters["@allocationAmount"].Value = allocationAmount;
			scom.Parameters["@days"].Value = days;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@isRejected"].Value = isRejected;
			scom.Parameters["@isValied"].Value = isValied;
			scom.Parameters["@isOverDue"].Value = isOverDue;
			scom.Parameters["@isDeduction"].Value = isDeduction;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission_Invoices table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_InvoicesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Invoices table by a foreign key.
		/// </summary>
		public static void DeleteAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_InvoicesDeleteAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission_Invoices table.
		/// </summary>
		public static tbl_sasSalesCommission_Invoices Select(int line_No_Incoming, string commission_ID_Incoming, string invoice_ID_Incoming){

			tbl_sasSalesCommission_Invoices tbl_sasSalesCommission_Invoicesins = new tbl_sasSalesCommission_Invoices();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_InvoicesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommission_Invoicesins = Maketbl_sasSalesCommission_Invoices(dataReader);
				} else {
					tbl_sasSalesCommission_Invoicesins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_Invoicesins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Invoices table.
		/// </summary>
		public static List<tbl_sasSalesCommission_Invoices> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_InvoicesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission_Invoices> tbl_sasSalesCommission_InvoicesList = new List<tbl_sasSalesCommission_Invoices>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Invoices tbl_sasSalesCommission_Invoices = Maketbl_sasSalesCommission_Invoices(dataReader);
					tbl_sasSalesCommission_InvoicesList.Add(tbl_sasSalesCommission_Invoices);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_InvoicesList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Invoices table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_Invoices> SelectAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_InvoicesSelectAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
				List<tbl_sasSalesCommission_Invoices> tbl_sasSalesCommission_InvoicesList = new List<tbl_sasSalesCommission_Invoices>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Invoices tbl_sasSalesCommission_Invoices = Maketbl_sasSalesCommission_Invoices(dataReader);
					tbl_sasSalesCommission_InvoicesList.Add(tbl_sasSalesCommission_Invoices);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_InvoicesList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission_Invoices class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission_Invoices Maketbl_sasSalesCommission_Invoices(SqlDataReader dataReader) {
			tbl_sasSalesCommission_Invoices tbl_sasSalesCommission_Invoices = new tbl_sasSalesCommission_Invoices();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission_Invoices.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission_Invoices.Commission_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission_Invoices.Invoice_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission_Invoices.InvoiceDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesCommission_Invoices.InvoiceAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesCommission_Invoices.AllocationAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasSalesCommission_Invoices.Days = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasSalesCommission_Invoices.CustomerName = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasSalesCommission_Invoices.IsRejected = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasSalesCommission_Invoices.IsValied = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasSalesCommission_Invoices.IsOverDue = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasSalesCommission_Invoices.IsDeduction = dataReader.GetBoolean(11);
			}

			return tbl_sasSalesCommission_Invoices;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission_Invoices datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Invoices object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission_Invoices  tbl_sasSalesCommission_Invoices   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_invoiceDate = new DataColumn("invoiceDate" , typeof(DateTime));
			DataColumn col_invoiceAmount = new DataColumn("invoiceAmount" , typeof(decimal));
			DataColumn col_allocationAmount = new DataColumn("allocationAmount" , typeof(decimal));
			DataColumn col_days = new DataColumn("days" , typeof(int));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_isRejected = new DataColumn("isRejected" , typeof(bool));
			DataColumn col_isValied = new DataColumn("isValied" , typeof(bool));
			DataColumn col_isOverDue = new DataColumn("isOverDue" , typeof(bool));
			DataColumn col_isDeduction = new DataColumn("isDeduction" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_commission_ID,col_invoice_ID,col_invoiceDate,col_invoiceAmount,col_allocationAmount,col_days,col_customerName,col_isRejected,col_isValied,col_isOverDue,col_isDeduction,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission_Invoices datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Invoices object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission_Invoices user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["commission_ID"] = user.commission_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["invoiceDate"] = user.invoiceDate;
			drow["invoiceAmount"] = user.invoiceAmount;
			drow["allocationAmount"] = user.allocationAmount;
			drow["days"] = user.days;
			drow["customerName"] = user.customerName;
			drow["isRejected"] = user.isRejected;
			drow["isValied"] = user.isValied;
			drow["isOverDue"] = user.isOverDue;
			drow["isDeduction"] = user.isDeduction;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
