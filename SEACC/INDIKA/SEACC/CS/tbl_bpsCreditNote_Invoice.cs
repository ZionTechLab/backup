using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsCreditNote_Invoice {
		#region Fields
		private string creditNote_ID;
		private int line_No;
		private string invoice_ID;
		private string orderRef_ID;
		private decimal alocatedAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsCreditNote_Invoice class.
		/// </summary>
		public tbl_bpsCreditNote_Invoice() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsCreditNote_Invoice class.
		/// </summary>
		public tbl_bpsCreditNote_Invoice(string creditNote_ID, int line_No, string invoice_ID, string orderRef_ID, decimal alocatedAmount) {
			this.creditNote_ID = creditNote_ID;
			this.line_No = line_No;
			this.invoice_ID = invoice_ID;
			this.orderRef_ID = orderRef_ID;
			this.alocatedAmount = alocatedAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CreditNote_ID value.
		/// </summary>
		public string CreditNote_ID {
			get { return creditNote_ID; }
			set { creditNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRef_ID value.
		/// </summary>
		public string OrderRef_ID {
			get { return orderRef_ID; }
			set { orderRef_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AlocatedAmount value.
		/// </summary>
		public decimal AlocatedAmount {
			get { return alocatedAmount; }
			set { alocatedAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsCreditNote_Invoice table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCreditNote_InvoiceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@OrderRef_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alocatedAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@OrderRef_ID"].Value = OrderRef_ID;
			scom.Parameters["@alocatedAmount"].Value = alocatedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsCreditNote_Invoice table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCreditNote_InvoiceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@OrderRef_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alocatedAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@OrderRef_ID"].Value = orderRef_ID;
			scom.Parameters["@alocatedAmount"].Value = alocatedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsCreditNote_Invoice table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCreditNote_InvoiceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
 
			scom.Parameters["@line_No"].Value = line_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCreditNote_Invoice table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreditNote_ID(string creditNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCreditNote_InvoiceDeleteAllByCreditNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsCreditNote_Invoice table.
		/// </summary>
		public static tbl_bpsCreditNote_Invoice Select(string creditNote_ID_Incoming, int line_No_Incoming){

			tbl_bpsCreditNote_Invoice tbl_bpsCreditNote_Invoiceins = new tbl_bpsCreditNote_Invoice();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCreditNote_InvoiceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsCreditNote_Invoiceins = Maketbl_bpsCreditNote_Invoice(dataReader);
				} else {
					tbl_bpsCreditNote_Invoiceins = null;
				}
			}
			scon.Close();
			return tbl_bpsCreditNote_Invoiceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCreditNote_Invoice table.
		/// </summary>
		public static List<tbl_bpsCreditNote_Invoice> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCreditNote_InvoiceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsCreditNote_Invoice> tbl_bpsCreditNote_InvoiceList = new List<tbl_bpsCreditNote_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsCreditNote_Invoice tbl_bpsCreditNote_Invoice = Maketbl_bpsCreditNote_Invoice(dataReader);
					tbl_bpsCreditNote_InvoiceList.Add(tbl_bpsCreditNote_Invoice);
				}
			}
			scon.Close();
			return tbl_bpsCreditNote_InvoiceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCreditNote_Invoice table by a foreign key.
		/// </summary>
		public static List<tbl_bpsCreditNote_Invoice> SelectAllByCreditNote_ID(string creditNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCreditNote_InvoiceSelectAllByCreditNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
				List<tbl_bpsCreditNote_Invoice> tbl_bpsCreditNote_InvoiceList = new List<tbl_bpsCreditNote_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsCreditNote_Invoice tbl_bpsCreditNote_Invoice = Maketbl_bpsCreditNote_Invoice(dataReader);
					tbl_bpsCreditNote_InvoiceList.Add(tbl_bpsCreditNote_Invoice);
				}
			}
			scon.Close();
			return tbl_bpsCreditNote_InvoiceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsCreditNote_Invoice class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsCreditNote_Invoice Maketbl_bpsCreditNote_Invoice(SqlDataReader dataReader) {
			tbl_bpsCreditNote_Invoice tbl_bpsCreditNote_Invoice = new tbl_bpsCreditNote_Invoice();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsCreditNote_Invoice.CreditNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsCreditNote_Invoice.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsCreditNote_Invoice.Invoice_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsCreditNote_Invoice.OrderRef_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsCreditNote_Invoice.AlocatedAmount = dataReader.GetDecimal(4);
			}

			return tbl_bpsCreditNote_Invoice;
		}
		/// <summary>
		/// This makes tbl_bpsCreditNote_Invoice datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsCreditNote_Invoice object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsCreditNote_Invoice  tbl_bpsCreditNote_Invoice   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_creditNote_ID = new DataColumn("creditNote_ID" , typeof(string));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_OrderRef_ID = new DataColumn("OrderRef_ID" , typeof(string));
			DataColumn col_alocatedAmount = new DataColumn("alocatedAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_creditNote_ID,col_line_No,col_invoice_ID,col_OrderRef_ID,col_alocatedAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsCreditNote_Invoice datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsCreditNote_Invoice object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsCreditNote_Invoice user) {
		DataRow drow = dt.NewRow();
		
			drow["creditNote_ID"] = user.creditNote_ID;
			drow["line_No"] = user.line_No;
			drow["invoice_ID"] = user.invoice_ID;
			drow["OrderRef_ID"] = user.OrderRef_ID;
			drow["alocatedAmount"] = user.alocatedAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
