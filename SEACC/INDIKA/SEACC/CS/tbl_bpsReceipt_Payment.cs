using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsReceipt_Payment {
		#region Fields
		private string receipt_ID;
		private string paymentMethod_ID;
		private string paymentMethodTransection_ID;
		private string customerName;
		private DateTime expiryDate;
		private decimal paymentAmount;
		private decimal settleAmount;
		private bool isSettled;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsReceipt_Payment class.
		/// </summary>
		public tbl_bpsReceipt_Payment() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsReceipt_Payment class.
		/// </summary>
		public tbl_bpsReceipt_Payment(string receipt_ID, string paymentMethod_ID, string paymentMethodTransection_ID, string customerName, DateTime expiryDate, decimal paymentAmount, decimal settleAmount, bool isSettled, bool isDeleted) {
			this.receipt_ID = receipt_ID;
			this.paymentMethod_ID = paymentMethod_ID;
			this.paymentMethodTransection_ID = paymentMethodTransection_ID;
			this.customerName = customerName;
			this.expiryDate = expiryDate;
			this.paymentAmount = paymentAmount;
			this.settleAmount = settleAmount;
			this.isSettled = isSettled;
			this.isDeleted = isDeleted;
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
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethodTransection_ID value.
		/// </summary>
		public string PaymentMethodTransection_ID {
			get { return paymentMethodTransection_ID; }
			set { paymentMethodTransection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExpiryDate value.
		/// </summary>
		public DateTime ExpiryDate {
			get { return expiryDate; }
			set { expiryDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentAmount value.
		/// </summary>
		public decimal PaymentAmount {
			get { return paymentAmount; }
			set { paymentAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettleAmount value.
		/// </summary>
		public decimal SettleAmount {
			get { return settleAmount; }
			set { settleAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSettled value.
		/// </summary>
		public bool IsSettled {
			get { return isSettled; }
			set { isSettled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsReceipt_Payment table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_PaymentInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethodTransection_ID", SqlDbType.VarChar,30);
            scom.Parameters.Add("@customerName", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@expiryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@PaymentAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@SettleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@IsSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@paymentMethodTransection_ID"].Value = paymentMethodTransection_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@expiryDate"].Value = expiryDate;
			scom.Parameters["@PaymentAmount"].Value = paymentAmount;
			scom.Parameters["@SettleAmount"].Value = settleAmount;
			scom.Parameters["@IsSettled"].Value = isSettled;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsReceipt_Payment table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_PaymentUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethodTransection_ID", SqlDbType.VarChar,30);
            scom.Parameters.Add("@customerName", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@expiryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@PaymentAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@SettleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@IsSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@paymentMethodTransection_ID"].Value = paymentMethodTransection_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@expiryDate"].Value = expiryDate;
			scom.Parameters["@PaymentAmount"].Value = paymentAmount;
			scom.Parameters["@SettleAmount"].Value = settleAmount;
			scom.Parameters["@IsSettled"].Value = isSettled;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsReceipt_Payment table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_PaymentDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethodTransection_ID", SqlDbType.VarChar,30);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
 
			scom.Parameters["@paymentMethodTransection_ID"].Value = paymentMethodTransection_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsReceipt_Payment table.
		/// </summary>
		public static tbl_bpsReceipt_Payment Select(string receipt_ID_Incoming, string paymentMethod_ID_Incoming, string paymentMethodTransection_ID_Incoming){

			tbl_bpsReceipt_Payment tbl_bpsReceipt_Paymentins = new tbl_bpsReceipt_Payment();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_PaymentSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentMethodTransection_ID", SqlDbType.VarChar,30);
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID_Incoming;
			scom.Parameters["@paymentMethodTransection_ID"].Value = paymentMethodTransection_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsReceipt_Paymentins = Maketbl_bpsReceipt_Payment(dataReader);
				} else {
					tbl_bpsReceipt_Paymentins = null;
				}
			}
			scon.Close();
			return tbl_bpsReceipt_Paymentins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt_Payment table.
		/// </summary>
		public static List<tbl_bpsReceipt_Payment> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceipt_PaymentSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsReceipt_Payment> tbl_bpsReceipt_PaymentList = new List<tbl_bpsReceipt_Payment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsReceipt_Payment tbl_bpsReceipt_Payment = Maketbl_bpsReceipt_Payment(dataReader);
					tbl_bpsReceipt_PaymentList.Add(tbl_bpsReceipt_Payment);
				}
			}
			scon.Close();
			return tbl_bpsReceipt_PaymentList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsReceipt_Payment class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsReceipt_Payment Maketbl_bpsReceipt_Payment(SqlDataReader dataReader) {
			tbl_bpsReceipt_Payment tbl_bpsReceipt_Payment = new tbl_bpsReceipt_Payment();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsReceipt_Payment.Receipt_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsReceipt_Payment.PaymentMethod_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsReceipt_Payment.PaymentMethodTransection_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsReceipt_Payment.CustomerName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsReceipt_Payment.ExpiryDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsReceipt_Payment.PaymentAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsReceipt_Payment.SettleAmount = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsReceipt_Payment.IsSettled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsReceipt_Payment.IsDeleted = dataReader.GetBoolean(8);
			}

			return tbl_bpsReceipt_Payment;
		}
		/// <summary>
		/// This makes tbl_bpsReceipt_Payment datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsReceipt_Payment object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsReceipt_Payment  tbl_bpsReceipt_Payment   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_paymentMethodTransection_ID = new DataColumn("paymentMethodTransection_ID" , typeof(string));
            DataColumn col_customerName = new DataColumn("customerName", typeof(string));
			DataColumn col_expiryDate = new DataColumn("expiryDate" , typeof(DateTime));
			DataColumn col_PaymentAmount = new DataColumn("PaymentAmount" , typeof(decimal));
			DataColumn col_SettleAmount = new DataColumn("SettleAmount" , typeof(decimal));
			DataColumn col_IsSettled = new DataColumn("IsSettled" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_receipt_ID,col_paymentMethod_ID,col_paymentMethodTransection_ID,col_customerName,col_expiryDate,col_PaymentAmount,col_SettleAmount,col_IsSettled,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsReceipt_Payment datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsReceipt_Payment object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsReceipt_Payment user) {
		DataRow drow = dt.NewRow();
		
			drow["receipt_ID"] = user.receipt_ID;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["paymentMethodTransection_ID"] = user.paymentMethodTransection_ID;
			drow["customerName"] = user.customerName;
			drow["expiryDate"] = user.expiryDate;
			drow["PaymentAmount"] = user.PaymentAmount;
			drow["SettleAmount"] = user.SettleAmount;
			drow["IsSettled"] = user.IsSettled;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
