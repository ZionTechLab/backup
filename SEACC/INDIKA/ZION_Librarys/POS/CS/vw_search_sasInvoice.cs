using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class vw_search_sasInvoice {
		#region Fields
		private string invoice_ID;
		private string customerName;
		private string orderRefNo;
		private DateTime invoiceDate;
		private decimal grandTotal;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isSeattled;
		private bool isVatInvoice;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the vw_search_sasInvoice class.
		/// </summary>
		public vw_search_sasInvoice() {
		}
		
		/// <summary>
		/// Initializes a new instance of the vw_search_sasInvoice class.
		/// </summary>
		public vw_search_sasInvoice(string invoice_ID, string customerName, string orderRefNo, DateTime invoiceDate, decimal grandTotal, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled, bool isVatInvoice) {
			this.invoice_ID = invoice_ID;
			this.customerName = customerName;
			this.orderRefNo = orderRefNo;
			this.invoiceDate = invoiceDate;
			this.grandTotal = grandTotal;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isSeattled = isSeattled;
			this.isVatInvoice = isVatInvoice;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo value.
		/// </summary>
		public string OrderRefNo {
			get { return orderRefNo; }
			set { orderRefNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceDate value.
		/// </summary>
		public DateTime InvoiceDate {
			get { return invoiceDate; }
			set { invoiceDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public decimal GrandTotal {
			get { return grandTotal; }
			set { grandTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFinished value.
		/// </summary>
		public bool IsFinished {
			get { return isFinished; }
			set { isFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSeattled value.
		/// </summary>
		public bool IsSeattled {
			get { return isSeattled; }
			set { isSeattled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVatInvoice value.
		/// </summary>
		public bool IsVatInvoice {
			get { return isVatInvoice; }
			set { isVatInvoice = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the vw_search_sasInvoice table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInvoiceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVatInvoice", SqlDbType.Bit,1);
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@isVatInvoice"].Value = isVatInvoice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the vw_search_sasInvoice table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInvoiceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVatInvoice", SqlDbType.Bit,1);
 
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@isVatInvoice"].Value = isVatInvoice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the vw_search_sasInvoice table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInvoiceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the vw_search_sasInvoice table.
		/// </summary>
		public static vw_search_sasInvoice Select(string invoice_ID_Incoming){

			vw_search_sasInvoice vw_search_sasInvoiceins = new vw_search_sasInvoice();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInvoiceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					vw_search_sasInvoiceins = Makevw_search_sasInvoice(dataReader);
				} else {
					vw_search_sasInvoiceins = null;
				}
			}
			scon.Close();
			return vw_search_sasInvoiceins;
		}
		
		/// <summary>
		/// Selects all records from the vw_search_sasInvoice table.
		/// </summary>
		public static List<vw_search_sasInvoice> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInvoiceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<vw_search_sasInvoice> vw_search_sasInvoiceList = new List<vw_search_sasInvoice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					vw_search_sasInvoice vw_search_sasInvoice = Makevw_search_sasInvoice(dataReader);
					vw_search_sasInvoiceList.Add(vw_search_sasInvoice);
				}
			}
			scon.Close();
			return vw_search_sasInvoiceList;
		}
		
		/// <summary>
		/// Creates a new instance of the vw_search_sasInvoice class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static vw_search_sasInvoice Makevw_search_sasInvoice(SqlDataReader dataReader) {
			vw_search_sasInvoice vw_search_sasInvoice = new vw_search_sasInvoice();
			
			if (dataReader.IsDBNull(0) == false) {
				vw_search_sasInvoice.Invoice_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				vw_search_sasInvoice.CustomerName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				vw_search_sasInvoice.OrderRefNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				vw_search_sasInvoice.InvoiceDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				vw_search_sasInvoice.GrandTotal = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				vw_search_sasInvoice.IsApproved = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				vw_search_sasInvoice.IsFinished = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				vw_search_sasInvoice.IsDeleted = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				vw_search_sasInvoice.IsLocked = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				vw_search_sasInvoice.IsSeattled = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				vw_search_sasInvoice.IsVatInvoice = dataReader.GetBoolean(10);
			}

			return vw_search_sasInvoice;
		}
		/// <summary>
		/// This makes vw_search_sasInvoice datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new vw_search_sasInvoice object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( vw_search_sasInvoice  vw_search_sasInvoice   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_orderRefNo = new DataColumn("orderRefNo" , typeof(string));
			DataColumn col_invoiceDate = new DataColumn("invoiceDate" , typeof(DateTime));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_isVatInvoice = new DataColumn("isVatInvoice" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_invoice_ID,col_customerName,col_orderRefNo,col_invoiceDate,col_grandTotal,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,col_isVatInvoice,});		return dt;
		}
		/// <summary>
		/// This fills vw_search_sasInvoice datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new vw_search_sasInvoice object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, vw_search_sasInvoice user) {
		DataRow drow = dt.NewRow();
		
			drow["invoice_ID"] = user.invoice_ID;
			drow["customerName"] = user.customerName;
			drow["orderRefNo"] = user.orderRefNo;
			drow["invoiceDate"] = user.invoiceDate;
			drow["grandTotal"] = user.grandTotal;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isSeattled"] = user.isSeattled;
			drow["isVatInvoice"] = user.isVatInvoice;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
