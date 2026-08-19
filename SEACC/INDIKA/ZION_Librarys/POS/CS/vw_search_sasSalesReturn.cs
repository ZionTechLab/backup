using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class vw_search_sasSalesReturn {
		#region Fields
		private string salesReturnedNote_ID;
		private string customerName;
		private string orderRefNo;
		private DateTime salesReturnedNoteDate;
		private string invoice_ID;
		private decimal financeCharges;
		private decimal grandTotal;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isSeattled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the vw_search_sasSalesReturn class.
		/// </summary>
		public vw_search_sasSalesReturn() {
		}
		
		/// <summary>
		/// Initializes a new instance of the vw_search_sasSalesReturn class.
		/// </summary>
		public vw_search_sasSalesReturn(string salesReturnedNote_ID, string customerName, string orderRefNo, DateTime salesReturnedNoteDate, string invoice_ID, decimal financeCharges, decimal grandTotal, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled) {
			this.salesReturnedNote_ID = salesReturnedNote_ID;
			this.customerName = customerName;
			this.orderRefNo = orderRefNo;
			this.salesReturnedNoteDate = salesReturnedNoteDate;
			this.invoice_ID = invoice_ID;
			this.financeCharges = financeCharges;
			this.grandTotal = grandTotal;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isSeattled = isSeattled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SalesReturnedNote_ID value.
		/// </summary>
		public string SalesReturnedNote_ID {
			get { return salesReturnedNote_ID; }
			set { salesReturnedNote_ID = value; }
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
		/// Gets or sets the SalesReturnedNoteDate value.
		/// </summary>
		public DateTime SalesReturnedNoteDate {
			get { return salesReturnedNoteDate; }
			set { salesReturnedNoteDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinanceCharges value.
		/// </summary>
		public decimal FinanceCharges {
			get { return financeCharges; }
			set { financeCharges = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the vw_search_sasSalesReturn table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasSalesReturnInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@salesReturnedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@FinanceCharges", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
 
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@salesReturnedNoteDate"].Value = salesReturnedNoteDate;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@FinanceCharges"].Value = financeCharges;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the vw_search_sasSalesReturn table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasSalesReturnUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@salesReturnedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@FinanceCharges", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@salesReturnedNoteDate"].Value = salesReturnedNoteDate;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@FinanceCharges"].Value = financeCharges;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the vw_search_sasSalesReturn table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasSalesReturnDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the vw_search_sasSalesReturn table.
		/// </summary>
		public static vw_search_sasSalesReturn Select(string salesReturnedNote_ID_Incoming){

			vw_search_sasSalesReturn vw_search_sasSalesReturnins = new vw_search_sasSalesReturn();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasSalesReturnSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					vw_search_sasSalesReturnins = Makevw_search_sasSalesReturn(dataReader);
				} else {
					vw_search_sasSalesReturnins = null;
				}
			}
			scon.Close();
			return vw_search_sasSalesReturnins;
		}
		
		/// <summary>
		/// Selects all records from the vw_search_sasSalesReturn table.
		/// </summary>
		public static List<vw_search_sasSalesReturn> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasSalesReturnSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<vw_search_sasSalesReturn> vw_search_sasSalesReturnList = new List<vw_search_sasSalesReturn>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					vw_search_sasSalesReturn vw_search_sasSalesReturn = Makevw_search_sasSalesReturn(dataReader);
					vw_search_sasSalesReturnList.Add(vw_search_sasSalesReturn);
				}
			}
			scon.Close();
			return vw_search_sasSalesReturnList;
		}
		
		/// <summary>
		/// Creates a new instance of the vw_search_sasSalesReturn class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static vw_search_sasSalesReturn Makevw_search_sasSalesReturn(SqlDataReader dataReader) {
			vw_search_sasSalesReturn vw_search_sasSalesReturn = new vw_search_sasSalesReturn();
			
			if (dataReader.IsDBNull(0) == false) {
				vw_search_sasSalesReturn.SalesReturnedNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				vw_search_sasSalesReturn.CustomerName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				vw_search_sasSalesReturn.OrderRefNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				vw_search_sasSalesReturn.SalesReturnedNoteDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				vw_search_sasSalesReturn.Invoice_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				vw_search_sasSalesReturn.FinanceCharges = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				vw_search_sasSalesReturn.GrandTotal = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				vw_search_sasSalesReturn.IsApproved = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				vw_search_sasSalesReturn.IsFinished = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				vw_search_sasSalesReturn.IsDeleted = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				vw_search_sasSalesReturn.IsLocked = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				vw_search_sasSalesReturn.IsSeattled = dataReader.GetBoolean(11);
			}

			return vw_search_sasSalesReturn;
		}
		/// <summary>
		/// This makes vw_search_sasSalesReturn datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new vw_search_sasSalesReturn object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( vw_search_sasSalesReturn  vw_search_sasSalesReturn   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_salesReturnedNote_ID = new DataColumn("salesReturnedNote_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_orderRefNo = new DataColumn("orderRefNo" , typeof(string));
			DataColumn col_salesReturnedNoteDate = new DataColumn("salesReturnedNoteDate" , typeof(DateTime));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_FinanceCharges = new DataColumn("FinanceCharges" , typeof(decimal));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_salesReturnedNote_ID,col_customerName,col_orderRefNo,col_salesReturnedNoteDate,col_invoice_ID,col_FinanceCharges,col_grandTotal,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,});		return dt;
		}
		/// <summary>
		/// This fills vw_search_sasSalesReturn datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new vw_search_sasSalesReturn object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, vw_search_sasSalesReturn user) {
		DataRow drow = dt.NewRow();
		
			drow["salesReturnedNote_ID"] = user.salesReturnedNote_ID;
			drow["customerName"] = user.customerName;
			drow["orderRefNo"] = user.orderRefNo;
			drow["salesReturnedNoteDate"] = user.salesReturnedNoteDate;
			drow["invoice_ID"] = user.invoice_ID;
			drow["FinanceCharges"] = user.FinanceCharges;
			drow["grandTotal"] = user.grandTotal;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isSeattled"] = user.isSeattled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
