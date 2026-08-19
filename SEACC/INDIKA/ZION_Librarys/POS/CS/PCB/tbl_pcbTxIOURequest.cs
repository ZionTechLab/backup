using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pcbTxIOURequest {
		#region Fields
		private string iouRequest_ID;
		private DateTime iouRequestDate;
		private string iouRequestedUser_ID;
		private string remarks;
		private decimal requestAmount;
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
		/// Initializes a new instance of the tbl_pcbTxIOURequest class.
		/// </summary>
		public tbl_pcbTxIOURequest() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxIOURequest class.
		/// </summary>
		public tbl_pcbTxIOURequest(string iouRequest_ID, DateTime iouRequestDate, string iouRequestedUser_ID, string remarks, decimal requestAmount, bool isSettled, bool isCanceled, string createUser_ID, string modifiedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string canceledUserTerminal_ID) {
			this.iouRequest_ID = iouRequest_ID;
			this.iouRequestDate = iouRequestDate;
			this.iouRequestedUser_ID = iouRequestedUser_ID;
			this.remarks = remarks;
			this.requestAmount = requestAmount;
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
		/// Gets or sets the IouRequest_ID value.
		/// </summary>
		public string IouRequest_ID {
			get { return iouRequest_ID; }
			set { iouRequest_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouRequestDate value.
		/// </summary>
		public DateTime IouRequestDate {
			get { return iouRequestDate; }
			set { iouRequestDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouRequestedUser_ID value.
		/// </summary>
		public string IouRequestedUser_ID {
			get { return iouRequestedUser_ID; }
			set { iouRequestedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the RequestAmount value.
		/// </summary>
		public decimal RequestAmount {
			get { return requestAmount; }
			set { requestAmount = value; }
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
		/// Saves a record to the tbl_pcbTxIOURequest table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURequestInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iouRequest_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iouRequestDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@iouRequestedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
			scom.Parameters.Add("@requestAmount", SqlDbType.Decimal,9);
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
 
			scom.Parameters["@iouRequest_ID"].Value = iouRequest_ID;
			scom.Parameters["@iouRequestDate"].Value = iouRequestDate;
			scom.Parameters["@iouRequestedUser_ID"].Value = iouRequestedUser_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@requestAmount"].Value = requestAmount;
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
		/// Updates a record in the tbl_pcbTxIOURequest table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURequestUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iouRequest_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iouRequestDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@iouRequestedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
			scom.Parameters.Add("@requestAmount", SqlDbType.Decimal,9);
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
 
 
			scom.Parameters["@iouRequest_ID"].Value = iouRequest_ID;
			scom.Parameters["@iouRequestDate"].Value = iouRequestDate;
			scom.Parameters["@iouRequestedUser_ID"].Value = iouRequestedUser_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@requestAmount"].Value = requestAmount;
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
		/// Deletes a record from the tbl_pcbTxIOURequest table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURequestDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@iouRequest_ID", SqlDbType.VarChar,10);
			scom.Parameters["@iouRequest_ID"].Value = iouRequest_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOURequest table by a foreign key.
		/// </summary>
		public static void DeleteAllByIouRequestedUser_ID(string iouRequestedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURequestDeleteAllByIouRequestedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouRequestedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouRequestedUser_ID"].Value = iouRequestedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbTxIOURequest table.
		/// </summary>
		public static tbl_pcbTxIOURequest Select(string iouRequest_ID_Incoming){

			tbl_pcbTxIOURequest tbl_pcbTxIOURequestins = new tbl_pcbTxIOURequest();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURequestSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouRequest_ID", SqlDbType.VarChar,10);
			scom.Parameters["@iouRequest_ID"].Value = iouRequest_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbTxIOURequestins = Maketbl_pcbTxIOURequest(dataReader);
				} else {
					tbl_pcbTxIOURequestins = null;
				}
			}
			scon.Close();
			return tbl_pcbTxIOURequestins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOURequest table.
		/// </summary>
		public static List<tbl_pcbTxIOURequest> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURequestSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbTxIOURequest> tbl_pcbTxIOURequestList = new List<tbl_pcbTxIOURequest>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOURequest tbl_pcbTxIOURequest = Maketbl_pcbTxIOURequest(dataReader);
					tbl_pcbTxIOURequestList.Add(tbl_pcbTxIOURequest);
				}
			}
			scon.Close();
			return tbl_pcbTxIOURequestList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOURequest table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOURequest> SelectAllByIouRequestedUser_ID(string iouRequestedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOURequestSelectAllByIouRequestedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouRequestedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouRequestedUser_ID"].Value = iouRequestedUser_ID;
				List<tbl_pcbTxIOURequest> tbl_pcbTxIOURequestList = new List<tbl_pcbTxIOURequest>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOURequest tbl_pcbTxIOURequest = Maketbl_pcbTxIOURequest(dataReader);
					tbl_pcbTxIOURequestList.Add(tbl_pcbTxIOURequest);
				}
			}
			scon.Close();
			return tbl_pcbTxIOURequestList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbTxIOURequest class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbTxIOURequest Maketbl_pcbTxIOURequest(SqlDataReader dataReader) {
			tbl_pcbTxIOURequest tbl_pcbTxIOURequest = new tbl_pcbTxIOURequest();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbTxIOURequest.IouRequest_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbTxIOURequest.IouRequestDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbTxIOURequest.IouRequestedUser_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbTxIOURequest.Remarks = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbTxIOURequest.RequestAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pcbTxIOURequest.IsSettled = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pcbTxIOURequest.IsCanceled = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pcbTxIOURequest.CreateUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pcbTxIOURequest.ModifiedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pcbTxIOURequest.CanceldUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pcbTxIOURequest.DateCreate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pcbTxIOURequest.DateModified = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pcbTxIOURequest.DateCanceled = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pcbTxIOURequest.CreateUserTerminal_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pcbTxIOURequest.ModifiedUserTerminal_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pcbTxIOURequest.CanceledUserTerminal_ID = dataReader.GetString(15);
			}

			return tbl_pcbTxIOURequest;
		}
		/// <summary>
		/// This makes tbl_pcbTxIOURequest datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbTxIOURequest object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbTxIOURequest  tbl_pcbTxIOURequest   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_iouRequest_ID = new DataColumn("iouRequest_ID" , typeof(string));
			DataColumn col_iouRequestDate = new DataColumn("iouRequestDate" , typeof(DateTime));
			DataColumn col_iouRequestedUser_ID = new DataColumn("iouRequestedUser_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_requestAmount = new DataColumn("requestAmount" , typeof(decimal));
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
		dt.Columns.AddRange(new DataColumn[] { col_iouRequest_ID,col_iouRequestDate,col_iouRequestedUser_ID,col_remarks,col_requestAmount,col_isSettled,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_canceledUserTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbTxIOURequest datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbTxIOURequest object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbTxIOURequest user) {
		DataRow drow = dt.NewRow();
		
			drow["iouRequest_ID"] = user.iouRequest_ID;
			drow["iouRequestDate"] = user.iouRequestDate;
			drow["iouRequestedUser_ID"] = user.iouRequestedUser_ID;
			drow["remarks"] = user.remarks;
			drow["requestAmount"] = user.requestAmount;
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
