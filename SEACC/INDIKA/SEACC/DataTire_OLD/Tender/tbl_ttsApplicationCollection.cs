using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsApplicationCollection {
		#region Fields
		private string application_ID;
		private string tender_ID;
		private string receipt_No;
		private decimal receipt_Amount;
		private string paymentMethod;
		private string cheque_No;
		private string accountNumber;
		private DateTime cheque_Date;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsApplicationCollection class.
		/// </summary>
		public tbl_ttsApplicationCollection() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsApplicationCollection class.
		/// </summary>
		public tbl_ttsApplicationCollection(string application_ID, string tender_ID, string receipt_No, decimal receipt_Amount, string paymentMethod, string cheque_No, string accountNumber, DateTime cheque_Date, bool isCanceled) {
			this.application_ID = application_ID;
			this.tender_ID = tender_ID;
			this.receipt_No = receipt_No;
			this.receipt_Amount = receipt_Amount;
			this.paymentMethod = paymentMethod;
			this.cheque_No = cheque_No;
			this.accountNumber = accountNumber;
			this.cheque_Date = cheque_Date;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Application_ID value.
		/// </summary>
		public string Application_ID {
			get { return application_ID; }
			set { application_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Receipt_No value.
		/// </summary>
		public string Receipt_No {
			get { return receipt_No; }
			set { receipt_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Receipt_Amount value.
		/// </summary>
		public decimal Receipt_Amount {
			get { return receipt_Amount; }
			set { receipt_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethod value.
		/// </summary>
		public string PaymentMethod {
			get { return paymentMethod; }
			set { paymentMethod = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cheque_No value.
		/// </summary>
		public string Cheque_No {
			get { return cheque_No; }
			set { cheque_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber value.
		/// </summary>
		public string AccountNumber {
			get { return accountNumber; }
			set { accountNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cheque_Date value.
		/// </summary>
		public DateTime Cheque_Date {
			get { return cheque_Date; }
			set { cheque_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsApplicationCollection table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsApplicationCollectionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@application_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@receipt_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@paymentMethod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@cheque_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cheque_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@application_ID"].Value = application_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@receipt_No"].Value = receipt_No;
			scom.Parameters["@receipt_Amount"].Value = receipt_Amount;
			scom.Parameters["@paymentMethod"].Value = paymentMethod;
			scom.Parameters["@cheque_No"].Value = cheque_No;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@cheque_Date"].Value = cheque_Date;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsApplicationCollection table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsApplicationCollectionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@application_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@receipt_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@paymentMethod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@cheque_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cheque_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@application_ID"].Value = application_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@receipt_No"].Value = receipt_No;
			scom.Parameters["@receipt_Amount"].Value = receipt_Amount;
			scom.Parameters["@paymentMethod"].Value = paymentMethod;
			scom.Parameters["@cheque_No"].Value = cheque_No;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@cheque_Date"].Value = cheque_Date;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsApplicationCollection table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsApplicationCollectionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@application_ID", SqlDbType.VarChar,10);
			scom.Parameters["@application_ID"].Value = application_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsApplicationCollection table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsApplicationCollectionDeleteAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsApplicationCollection table.
		/// </summary>
		public static tbl_ttsApplicationCollection Select(string application_ID_Incoming){

			tbl_ttsApplicationCollection tbl_ttsApplicationCollectionins = new tbl_ttsApplicationCollection();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsApplicationCollectionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@application_ID", SqlDbType.VarChar,10);
			scom.Parameters["@application_ID"].Value = application_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsApplicationCollectionins = Maketbl_ttsApplicationCollection(dataReader);
				} else {
					tbl_ttsApplicationCollectionins = null;
				}
			}
			scon.Close();
			return tbl_ttsApplicationCollectionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsApplicationCollection table.
		/// </summary>
		public static List<tbl_ttsApplicationCollection> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsApplicationCollectionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsApplicationCollection> tbl_ttsApplicationCollectionList = new List<tbl_ttsApplicationCollection>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsApplicationCollection tbl_ttsApplicationCollection = Maketbl_ttsApplicationCollection(dataReader);
					tbl_ttsApplicationCollectionList.Add(tbl_ttsApplicationCollection);
				}
			}
			scon.Close();
			return tbl_ttsApplicationCollectionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsApplicationCollection table by a foreign key.
		/// </summary>
		public static List<tbl_ttsApplicationCollection> SelectAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsApplicationCollectionSelectAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
				List<tbl_ttsApplicationCollection> tbl_ttsApplicationCollectionList = new List<tbl_ttsApplicationCollection>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsApplicationCollection tbl_ttsApplicationCollection = Maketbl_ttsApplicationCollection(dataReader);
					tbl_ttsApplicationCollectionList.Add(tbl_ttsApplicationCollection);
				}
			}
			scon.Close();
			return tbl_ttsApplicationCollectionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsApplicationCollection class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsApplicationCollection Maketbl_ttsApplicationCollection(SqlDataReader dataReader) {
			tbl_ttsApplicationCollection tbl_ttsApplicationCollection = new tbl_ttsApplicationCollection();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsApplicationCollection.Application_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsApplicationCollection.Tender_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsApplicationCollection.Receipt_No = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsApplicationCollection.Receipt_Amount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsApplicationCollection.PaymentMethod = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsApplicationCollection.Cheque_No = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsApplicationCollection.AccountNumber = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ttsApplicationCollection.Cheque_Date = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ttsApplicationCollection.IsCanceled = dataReader.GetBoolean(8);
			}

			return tbl_ttsApplicationCollection;
		}
		/// <summary>
		/// This makes tbl_ttsApplicationCollection datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsApplicationCollection object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsApplicationCollection  tbl_ttsApplicationCollection   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_application_ID = new DataColumn("application_ID" , typeof(string));
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_receipt_No = new DataColumn("receipt_No" , typeof(string));
			DataColumn col_receipt_Amount = new DataColumn("receipt_Amount" , typeof(decimal));
			DataColumn col_paymentMethod = new DataColumn("paymentMethod" , typeof(string));
			DataColumn col_cheque_No = new DataColumn("cheque_No" , typeof(string));
			DataColumn col_accountNumber = new DataColumn("accountNumber" , typeof(string));
			DataColumn col_cheque_Date = new DataColumn("cheque_Date" , typeof(DateTime));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_application_ID,col_tender_ID,col_receipt_No,col_receipt_Amount,col_paymentMethod,col_cheque_No,col_accountNumber,col_cheque_Date,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsApplicationCollection datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsApplicationCollection object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsApplicationCollection user) {
		DataRow drow = dt.NewRow();
		
			drow["application_ID"] = user.application_ID;
			drow["tender_ID"] = user.tender_ID;
			drow["receipt_No"] = user.receipt_No;
			drow["receipt_Amount"] = user.receipt_Amount;
			drow["paymentMethod"] = user.paymentMethod;
			drow["cheque_No"] = user.cheque_No;
			drow["accountNumber"] = user.accountNumber;
			drow["cheque_Date"] = user.cheque_Date;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
