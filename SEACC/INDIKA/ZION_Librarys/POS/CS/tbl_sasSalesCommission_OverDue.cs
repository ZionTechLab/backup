using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission_OverDue {
		#region Fields
		private string commission_ID;
		private string invoice_ID;
		private DateTime invoiceDate;
		private decimal invoiceAmount;
		private decimal allocationAmount;
		private int days;
		private string customerName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_OverDue class.
		/// </summary>
		public tbl_sasSalesCommission_OverDue() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_OverDue class.
		/// </summary>
		public tbl_sasSalesCommission_OverDue(string commission_ID, string invoice_ID, DateTime invoiceDate, decimal invoiceAmount, decimal allocationAmount, int days, string customerName) {
			this.commission_ID = commission_ID;
			this.invoice_ID = invoice_ID;
			this.invoiceDate = invoiceDate;
			this.invoiceAmount = invoiceAmount;
			this.allocationAmount = allocationAmount;
			this.days = days;
			this.customerName = customerName;
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission_OverDue table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_OverDueInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoiceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocationAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@days", SqlDbType.Int,4);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@invoiceAmount"].Value = invoiceAmount;
			scom.Parameters["@allocationAmount"].Value = allocationAmount;
			scom.Parameters["@days"].Value = days;
			scom.Parameters["@customerName"].Value = customerName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission_OverDue table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_OverDueUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoiceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocationAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@days", SqlDbType.Int,4);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@invoiceAmount"].Value = invoiceAmount;
			scom.Parameters["@allocationAmount"].Value = allocationAmount;
			scom.Parameters["@days"].Value = days;
			scom.Parameters["@customerName"].Value = customerName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission_OverDue table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_OverDueDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_OverDue table by a foreign key.
		/// </summary>
		public static void DeleteAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_OverDueDeleteAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission_OverDue table.
		/// </summary>
		public static tbl_sasSalesCommission_OverDue Select(string commission_ID_Incoming, string invoice_ID_Incoming){

			tbl_sasSalesCommission_OverDue tbl_sasSalesCommission_OverDueins = new tbl_sasSalesCommission_OverDue();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_OverDueSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommission_OverDueins = Maketbl_sasSalesCommission_OverDue(dataReader);
				} else {
					tbl_sasSalesCommission_OverDueins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_OverDueins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_OverDue table.
		/// </summary>
		public static List<tbl_sasSalesCommission_OverDue> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_OverDueSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission_OverDue> tbl_sasSalesCommission_OverDueList = new List<tbl_sasSalesCommission_OverDue>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_OverDue tbl_sasSalesCommission_OverDue = Maketbl_sasSalesCommission_OverDue(dataReader);
					tbl_sasSalesCommission_OverDueList.Add(tbl_sasSalesCommission_OverDue);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_OverDueList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_OverDue table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_OverDue> SelectAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_OverDueSelectAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
				List<tbl_sasSalesCommission_OverDue> tbl_sasSalesCommission_OverDueList = new List<tbl_sasSalesCommission_OverDue>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_OverDue tbl_sasSalesCommission_OverDue = Maketbl_sasSalesCommission_OverDue(dataReader);
					tbl_sasSalesCommission_OverDueList.Add(tbl_sasSalesCommission_OverDue);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_OverDueList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission_OverDue class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission_OverDue Maketbl_sasSalesCommission_OverDue(SqlDataReader dataReader) {
			tbl_sasSalesCommission_OverDue tbl_sasSalesCommission_OverDue = new tbl_sasSalesCommission_OverDue();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission_OverDue.Commission_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission_OverDue.Invoice_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission_OverDue.InvoiceDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission_OverDue.InvoiceAmount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesCommission_OverDue.AllocationAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesCommission_OverDue.Days = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasSalesCommission_OverDue.CustomerName = dataReader.GetString(6);
			}

			return tbl_sasSalesCommission_OverDue;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission_OverDue datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_OverDue object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission_OverDue  tbl_sasSalesCommission_OverDue   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_invoiceDate = new DataColumn("invoiceDate" , typeof(DateTime));
			DataColumn col_invoiceAmount = new DataColumn("invoiceAmount" , typeof(decimal));
			DataColumn col_allocationAmount = new DataColumn("allocationAmount" , typeof(decimal));
			DataColumn col_days = new DataColumn("days" , typeof(int));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_commission_ID,col_invoice_ID,col_invoiceDate,col_invoiceAmount,col_allocationAmount,col_days,col_customerName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission_OverDue datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_OverDue object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission_OverDue user) {
		DataRow drow = dt.NewRow();
		
			drow["commission_ID"] = user.commission_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["invoiceDate"] = user.invoiceDate;
			drow["invoiceAmount"] = user.invoiceAmount;
			drow["allocationAmount"] = user.allocationAmount;
			drow["days"] = user.days;
			drow["customerName"] = user.customerName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
