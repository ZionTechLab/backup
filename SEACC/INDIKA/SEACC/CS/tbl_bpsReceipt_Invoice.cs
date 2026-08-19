using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsReceipt_Invoice {
		#region Fields
		private int line_No;
		private string receipt_ID;
		private string invoice_ID;
		private bool isLocked;
		private string orderRefNo_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsReceipt_Invoice class.
		/// </summary>
		public tbl_bpsReceipt_Invoice() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsReceipt_Invoice class.
		/// </summary>
		public tbl_bpsReceipt_Invoice(int line_No, string receipt_ID, string invoice_ID, bool isLocked, string orderRefNo_ID) {
			this.line_No = line_No;
			this.receipt_ID = receipt_ID;
			this.invoice_ID = invoice_ID;
			this.isLocked = isLocked;
			this.orderRefNo_ID = orderRefNo_ID;
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
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsReceipt_Invoice table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsReceipt_Invoice table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsReceipt_Invoice table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt_Invoice table by a foreign key.
		/// </summary>
		public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceDeleteAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt_Invoice table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			//scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt_Invoice table by a foreign key.
		/// </summary>
		public static void DeleteAllByReceipt_ID(string receipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceDeleteAllByReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsReceipt_Invoice table.
		/// </summary>
		public static tbl_bpsReceipt_Invoice Select(string receipt_ID_Incoming, string invoice_ID_Incoming){

			tbl_bpsReceipt_Invoice tbl_bpsReceipt_Invoiceins = new tbl_bpsReceipt_Invoice();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsReceipt_Invoiceins = Maketbl_bpsReceipt_Invoice(dataReader);
				} else {
					tbl_bpsReceipt_Invoiceins = null;
				}
			}
			scon.Close();
			return tbl_bpsReceipt_Invoiceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt_Invoice table.
		/// </summary>
		public static List<tbl_bpsReceipt_Invoice> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsReceipt_Invoice> tbl_bpsReceipt_InvoiceList = new List<tbl_bpsReceipt_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsReceipt_Invoice tbl_bpsReceipt_Invoice = Maketbl_bpsReceipt_Invoice(dataReader);
					tbl_bpsReceipt_InvoiceList.Add(tbl_bpsReceipt_Invoice);
				}
			}
			scon.Close();
			return tbl_bpsReceipt_InvoiceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt_Invoice table by a foreign key.
		/// </summary>
		public static List<tbl_bpsReceipt_Invoice> SelectAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceSelectAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
				List<tbl_bpsReceipt_Invoice> tbl_bpsReceipt_InvoiceList = new List<tbl_bpsReceipt_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsReceipt_Invoice tbl_bpsReceipt_Invoice = Maketbl_bpsReceipt_Invoice(dataReader);
					tbl_bpsReceipt_InvoiceList.Add(tbl_bpsReceipt_Invoice);
				}
			}
			scon.Close();
			return tbl_bpsReceipt_InvoiceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt_Invoice table by a foreign key.
		/// </summary>
		public static List<tbl_bpsReceipt_Invoice> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_bpsReceipt_Invoice> tbl_bpsReceipt_InvoiceList = new List<tbl_bpsReceipt_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsReceipt_Invoice tbl_bpsReceipt_Invoice = Maketbl_bpsReceipt_Invoice(dataReader);
					tbl_bpsReceipt_InvoiceList.Add(tbl_bpsReceipt_Invoice);
				}
			}
			scon.Close();
			return tbl_bpsReceipt_InvoiceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt_Invoice table by a foreign key.
		/// </summary>
		public static List<tbl_bpsReceipt_Invoice> SelectAllByReceipt_ID(string receipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_InvoiceSelectAllByReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
				List<tbl_bpsReceipt_Invoice> tbl_bpsReceipt_InvoiceList = new List<tbl_bpsReceipt_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsReceipt_Invoice tbl_bpsReceipt_Invoice = Maketbl_bpsReceipt_Invoice(dataReader);
					tbl_bpsReceipt_InvoiceList.Add(tbl_bpsReceipt_Invoice);
				}
			}
			scon.Close();
			return tbl_bpsReceipt_InvoiceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsReceipt_Invoice class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsReceipt_Invoice Maketbl_bpsReceipt_Invoice(SqlDataReader dataReader) {
			tbl_bpsReceipt_Invoice tbl_bpsReceipt_Invoice = new tbl_bpsReceipt_Invoice();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsReceipt_Invoice.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsReceipt_Invoice.Receipt_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsReceipt_Invoice.Invoice_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsReceipt_Invoice.IsLocked = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsReceipt_Invoice.OrderRefNo_ID = dataReader.GetString(4);
			}

			return tbl_bpsReceipt_Invoice;
		}
		/// <summary>
		/// This makes tbl_bpsReceipt_Invoice datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsReceipt_Invoice object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsReceipt_Invoice  tbl_bpsReceipt_Invoice   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_receipt_ID,col_invoice_ID,col_isLocked,col_orderRefNo_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsReceipt_Invoice datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsReceipt_Invoice object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsReceipt_Invoice user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["receipt_ID"] = user.receipt_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["isLocked"] = user.isLocked;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
