using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasDeliveryPlan_Invoice {
		#region Fields
		private string deliveryPlan_ID;
		private string invoice_ID;
		private int printCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryPlan_Invoice class.
		/// </summary>
		public tbl_sasDeliveryPlan_Invoice() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryPlan_Invoice class.
		/// </summary>
		public tbl_sasDeliveryPlan_Invoice(string deliveryPlan_ID, string invoice_ID, int printCount) {
			this.deliveryPlan_ID = deliveryPlan_ID;
			this.invoice_ID = invoice_ID;
			this.printCount = printCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DeliveryPlan_ID value.
		/// </summary>
		public string DeliveryPlan_ID {
			get { return deliveryPlan_ID; }
			set { deliveryPlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasDeliveryPlan_Invoice table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasDeliveryPlan_Invoice table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
 
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasDeliveryPlan_Invoice table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_Invoice table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryPlan_ID(string deliveryPlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceDeleteAllByDeliveryPlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_Invoice table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasDeliveryPlan_Invoice table.
		/// </summary>
		public static tbl_sasDeliveryPlan_Invoice Select(string deliveryPlan_ID_Incoming, string invoice_ID_Incoming){

			tbl_sasDeliveryPlan_Invoice tbl_sasDeliveryPlan_Invoiceins = new tbl_sasDeliveryPlan_Invoice();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID_Incoming;
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasDeliveryPlan_Invoiceins = Maketbl_sasDeliveryPlan_Invoice(dataReader);
				} else {
					tbl_sasDeliveryPlan_Invoiceins = null;
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_Invoiceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_Invoice table.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_Invoice> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasDeliveryPlan_Invoice> tbl_sasDeliveryPlan_InvoiceList = new List<tbl_sasDeliveryPlan_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_Invoice tbl_sasDeliveryPlan_Invoice = Maketbl_sasDeliveryPlan_Invoice(dataReader);
					tbl_sasDeliveryPlan_InvoiceList.Add(tbl_sasDeliveryPlan_Invoice);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_InvoiceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_Invoice table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_Invoice> SelectAllByDeliveryPlan_ID(string deliveryPlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceSelectAllByDeliveryPlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
				List<tbl_sasDeliveryPlan_Invoice> tbl_sasDeliveryPlan_InvoiceList = new List<tbl_sasDeliveryPlan_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_Invoice tbl_sasDeliveryPlan_Invoice = Maketbl_sasDeliveryPlan_Invoice(dataReader);
					tbl_sasDeliveryPlan_InvoiceList.Add(tbl_sasDeliveryPlan_Invoice);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_InvoiceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_Invoice table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_Invoice> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_InvoiceSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_sasDeliveryPlan_Invoice> tbl_sasDeliveryPlan_InvoiceList = new List<tbl_sasDeliveryPlan_Invoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_Invoice tbl_sasDeliveryPlan_Invoice = Maketbl_sasDeliveryPlan_Invoice(dataReader);
					tbl_sasDeliveryPlan_InvoiceList.Add(tbl_sasDeliveryPlan_Invoice);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_InvoiceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasDeliveryPlan_Invoice class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasDeliveryPlan_Invoice Maketbl_sasDeliveryPlan_Invoice(SqlDataReader dataReader) {
			tbl_sasDeliveryPlan_Invoice tbl_sasDeliveryPlan_Invoice = new tbl_sasDeliveryPlan_Invoice();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasDeliveryPlan_Invoice.DeliveryPlan_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasDeliveryPlan_Invoice.Invoice_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasDeliveryPlan_Invoice.PrintCount = dataReader.GetInt32(2);
			}

			return tbl_sasDeliveryPlan_Invoice;
		}
		/// <summary>
		/// This makes tbl_sasDeliveryPlan_Invoice datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryPlan_Invoice object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasDeliveryPlan_Invoice  tbl_sasDeliveryPlan_Invoice   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_deliveryPlan_ID = new DataColumn("deliveryPlan_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_deliveryPlan_ID,col_invoice_ID,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasDeliveryPlan_Invoice datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryPlan_Invoice object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasDeliveryPlan_Invoice user) {
		DataRow drow = dt.NewRow();
		
			drow["deliveryPlan_ID"] = user.deliveryPlan_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["printCount"] = user.printCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
