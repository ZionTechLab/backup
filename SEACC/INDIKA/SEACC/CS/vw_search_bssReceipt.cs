using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class vw_search_bssReceipt {
		#region Fields
		private string receipt_ID;
		private string customerName;
		private DateTime receiptDate;
		private decimal cashAmount;
		private decimal chequeAmount;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isSeattled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the vw_search_bssReceipt class.
		/// </summary>
		public vw_search_bssReceipt() {
		}
		
		/// <summary>
		/// Initializes a new instance of the vw_search_bssReceipt class.
		/// </summary>
		public vw_search_bssReceipt(string receipt_ID, string customerName, DateTime receiptDate, decimal cashAmount, decimal chequeAmount, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled) {
			this.receipt_ID = receipt_ID;
			this.customerName = customerName;
			this.receiptDate = receiptDate;
			this.cashAmount = cashAmount;
			this.chequeAmount = chequeAmount;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isSeattled = isSeattled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptDate value.
		/// </summary>
		public DateTime ReceiptDate {
			get { return receiptDate; }
			set { receiptDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the CashAmount value.
		/// </summary>
		public decimal CashAmount {
			get { return cashAmount; }
			set { cashAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount value.
		/// </summary>
		public decimal ChequeAmount {
			get { return chequeAmount; }
			set { chequeAmount = value; }
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
		/// Saves a record to the vw_search_bssReceipt table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_bssReceiptInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@receiptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@cashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@receiptDate"].Value = receiptDate;
			scom.Parameters["@cashAmount"].Value = cashAmount;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
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
		/// Updates a record in the vw_search_bssReceipt table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_bssReceiptUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@receiptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@cashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@receiptDate"].Value = receiptDate;
			scom.Parameters["@cashAmount"].Value = cashAmount;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
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
		/// Deletes a record from the vw_search_bssReceipt table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_bssReceiptDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the vw_search_bssReceipt table.
		/// </summary>
		public static vw_search_bssReceipt Select(string receipt_ID_Incoming){

			vw_search_bssReceipt vw_search_bssReceiptins = new vw_search_bssReceipt();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_bssReceiptSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					vw_search_bssReceiptins = Makevw_search_bssReceipt(dataReader);
				} else {
					vw_search_bssReceiptins = null;
				}
			}
			scon.Close();
			return vw_search_bssReceiptins;
		}
		
		/// <summary>
		/// Selects all records from the vw_search_bssReceipt table.
		/// </summary>
		public static List<vw_search_bssReceipt> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_bssReceiptSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<vw_search_bssReceipt> vw_search_bssReceiptList = new List<vw_search_bssReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					vw_search_bssReceipt vw_search_bssReceipt = Makevw_search_bssReceipt(dataReader);
					vw_search_bssReceiptList.Add(vw_search_bssReceipt);
				}
			}
			scon.Close();
			return vw_search_bssReceiptList;
		}
		
		/// <summary>
		/// Creates a new instance of the vw_search_bssReceipt class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static vw_search_bssReceipt Makevw_search_bssReceipt(SqlDataReader dataReader) {
			vw_search_bssReceipt vw_search_bssReceipt = new vw_search_bssReceipt();
			
			if (dataReader.IsDBNull(0) == false) {
				vw_search_bssReceipt.Receipt_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				vw_search_bssReceipt.CustomerName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				vw_search_bssReceipt.ReceiptDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				vw_search_bssReceipt.CashAmount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				vw_search_bssReceipt.ChequeAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				vw_search_bssReceipt.IsApproved = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				vw_search_bssReceipt.IsFinished = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				vw_search_bssReceipt.IsDeleted = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				vw_search_bssReceipt.IsLocked = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				vw_search_bssReceipt.IsSeattled = dataReader.GetBoolean(9);
			}

			return vw_search_bssReceipt;
		}
		/// <summary>
		/// This makes vw_search_bssReceipt datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new vw_search_bssReceipt object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( vw_search_bssReceipt  vw_search_bssReceipt   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_receiptDate = new DataColumn("receiptDate" , typeof(DateTime));
			DataColumn col_cashAmount = new DataColumn("cashAmount" , typeof(decimal));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_receipt_ID,col_customerName,col_receiptDate,col_cashAmount,col_chequeAmount,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,});		return dt;
		}
		/// <summary>
		/// This fills vw_search_bssReceipt datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new vw_search_bssReceipt object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, vw_search_bssReceipt user) {
		DataRow drow = dt.NewRow();
		
			drow["receipt_ID"] = user.receipt_ID;
			drow["customerName"] = user.customerName;
			drow["receiptDate"] = user.receiptDate;
			drow["cashAmount"] = user.cashAmount;
			drow["chequeAmount"] = user.chequeAmount;
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
