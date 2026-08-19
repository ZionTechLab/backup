using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pcbTxIOURefund {
		#region Fields
		private string refund_ID;
		private DateTime refundDate;
		private string pcbAccount_ID;
		private string user_ID;
		private string remarks;
		private decimal amount;
		private decimal settledAmount;
		private bool isSettled;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string canceldUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateCanceled;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string canceledUserTerminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxIOURefund class.
		/// </summary>
		public tbl_pcbTxIOURefund() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxIOURefund class.
		/// </summary>
		public tbl_pcbTxIOURefund(string refund_ID, DateTime refundDate, string pcbAccount_ID, string user_ID, string remarks, decimal amount, decimal settledAmount, bool isSettled, bool isCanceled, string createUser_ID, string modifiedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string canceledUserTerminal_ID) {
			this.refund_ID = refund_ID;
			this.refundDate = refundDate;
			this.pcbAccount_ID = pcbAccount_ID;
			this.user_ID = user_ID;
			this.remarks = remarks;
			this.amount = amount;
			this.settledAmount = settledAmount;
			this.isSettled = isSettled;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateCanceled = dateCanceled;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Refund_ID value.
		/// </summary>
		public string Refund_ID {
			get { return refund_ID; }
			set { refund_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RefundDate value.
		/// </summary>
		public DateTime RefundDate {
			get { return refundDate; }
			set { refundDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PcbAccount_ID value.
		/// </summary>
		public string PcbAccount_ID {
			get { return pcbAccount_ID; }
			set { pcbAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettledAmount value.
		/// </summary>
		public decimal SettledAmount {
			get { return settledAmount; }
			set { settledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSettled value.
		/// </summary>
		public bool IsSettled {
			get { return isSettled; }
			set { isSettled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceldUser_ID value.
		/// </summary>
		public string CanceldUser_ID {
			get { return canceldUser_ID; }
			set { canceldUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCanceled value.
		/// </summary>
		public DateTime DateCanceled {
			get { return dateCanceled; }
			set { dateCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUserTerminal_ID value.
		/// </summary>
		public string CreateUserTerminal_ID {
			get { return createUserTerminal_ID; }
			set { createUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUserTerminal_ID value.
		/// </summary>
		public string ModifiedUserTerminal_ID {
			get { return modifiedUserTerminal_ID; }
			set { modifiedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceledUserTerminal_ID value.
		/// </summary>
		public string CanceledUserTerminal_ID {
			get { return canceledUserTerminal_ID; }
			set { canceledUserTerminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pcbTxIOURefund table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@refund_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@refundDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@refund_ID"].Value = refund_ID;
			scom.Parameters["@refundDate"].Value = refundDate;
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@isSettled"].Value = isSettled;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pcbTxIOURefund table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@refund_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@refundDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@refund_ID"].Value = refund_ID;
			scom.Parameters["@refundDate"].Value = refundDate;
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@isSettled"].Value = isSettled;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pcbTxIOURefund table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@refund_ID", SqlDbType.VarChar,10);
			scom.Parameters["@refund_ID"].Value = refund_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOURefund table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOURefund table by a foreign key.
		/// </summary>
		public static void DeleteAllByPcbAccount_ID(string pcbAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundDeleteAllByPcbAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbTxIOURefund table.
		/// </summary>
		public static tbl_pcbTxIOURefund Select(string refund_ID_Incoming){

			tbl_pcbTxIOURefund tbl_pcbTxIOURefundins = new tbl_pcbTxIOURefund();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@refund_ID", SqlDbType.VarChar,10);
			scom.Parameters["@refund_ID"].Value = refund_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbTxIOURefundins = Maketbl_pcbTxIOURefund(dataReader);
				} else {
					tbl_pcbTxIOURefundins = null;
				}
			}
			scon.Close();
			return tbl_pcbTxIOURefundins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOURefund table.
		/// </summary>
		public static List<tbl_pcbTxIOURefund> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbTxIOURefund> tbl_pcbTxIOURefundList = new List<tbl_pcbTxIOURefund>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOURefund tbl_pcbTxIOURefund = Maketbl_pcbTxIOURefund(dataReader);
					tbl_pcbTxIOURefundList.Add(tbl_pcbTxIOURefund);
				}
			}
			scon.Close();
			return tbl_pcbTxIOURefundList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOURefund table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOURefund> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_pcbTxIOURefund> tbl_pcbTxIOURefundList = new List<tbl_pcbTxIOURefund>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOURefund tbl_pcbTxIOURefund = Maketbl_pcbTxIOURefund(dataReader);
					tbl_pcbTxIOURefundList.Add(tbl_pcbTxIOURefund);
				}
			}
			scon.Close();
			return tbl_pcbTxIOURefundList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOURefund table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOURefund> SelectAllByPcbAccount_ID(string pcbAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURefundSelectAllByPcbAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
				List<tbl_pcbTxIOURefund> tbl_pcbTxIOURefundList = new List<tbl_pcbTxIOURefund>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOURefund tbl_pcbTxIOURefund = Maketbl_pcbTxIOURefund(dataReader);
					tbl_pcbTxIOURefundList.Add(tbl_pcbTxIOURefund);
				}
			}
			scon.Close();
			return tbl_pcbTxIOURefundList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbTxIOURefund class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbTxIOURefund Maketbl_pcbTxIOURefund(SqlDataReader dataReader) {
			tbl_pcbTxIOURefund tbl_pcbTxIOURefund = new tbl_pcbTxIOURefund();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbTxIOURefund.Refund_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbTxIOURefund.RefundDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbTxIOURefund.PcbAccount_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbTxIOURefund.User_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbTxIOURefund.Remarks = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pcbTxIOURefund.Amount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pcbTxIOURefund.SettledAmount = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pcbTxIOURefund.IsSettled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pcbTxIOURefund.IsCanceled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pcbTxIOURefund.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pcbTxIOURefund.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pcbTxIOURefund.CanceldUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pcbTxIOURefund.DateCreate = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pcbTxIOURefund.DateModified = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pcbTxIOURefund.DateCanceled = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pcbTxIOURefund.CreateUserTerminal_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pcbTxIOURefund.ModifiedUserTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pcbTxIOURefund.CanceledUserTerminal_ID = dataReader.GetString(17);
			}

			return tbl_pcbTxIOURefund;
		}
		/// <summary>
		/// This makes tbl_pcbTxIOURefund datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbTxIOURefund object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbTxIOURefund  tbl_pcbTxIOURefund   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_refund_ID = new DataColumn("refund_ID" , typeof(string));
			DataColumn col_refundDate = new DataColumn("refundDate" , typeof(DateTime));
			DataColumn col_pcbAccount_ID = new DataColumn("pcbAccount_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_settledAmount = new DataColumn("settledAmount" , typeof(decimal));
			DataColumn col_isSettled = new DataColumn("isSettled" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_refund_ID,col_refundDate,col_pcbAccount_ID,col_user_ID,col_remarks,col_amount,col_settledAmount,col_isSettled,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_canceledUserTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbTxIOURefund datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbTxIOURefund object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbTxIOURefund user) {
		DataRow drow = dt.NewRow();
		
			drow["refund_ID"] = user.refund_ID;
			drow["refundDate"] = user.refundDate;
			drow["pcbAccount_ID"] = user.pcbAccount_ID;
			drow["user_ID"] = user.user_ID;
			drow["remarks"] = user.remarks;
			drow["amount"] = user.amount;
			drow["settledAmount"] = user.settledAmount;
			drow["isSettled"] = user.isSettled;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateCanceled"] = user.dateCanceled;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
