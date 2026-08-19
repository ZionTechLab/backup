using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pcbTxIOU {
		#region Fields
		private string iou_ID;
		private DateTime iouDate;
		private string pcbAccount_ID;
		private string iouRequest_ID;
		private string iouUser_ID;
		private string remarks;
		private decimal iouAmount;
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
		/// Initializes a new instance of the tbl_pcbTxIOU class.
		/// </summary>
		public tbl_pcbTxIOU() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxIOU class.
		/// </summary>
		public tbl_pcbTxIOU(string iou_ID, DateTime iouDate, string pcbAccount_ID, string iouRequest_ID, string iouUser_ID, string remarks, decimal iouAmount, decimal settledAmount, bool isSettled, bool isCanceled, string createUser_ID, string modifiedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string canceledUserTerminal_ID) {
			this.iou_ID = iou_ID;
			this.iouDate = iouDate;
			this.pcbAccount_ID = pcbAccount_ID;
			this.iouRequest_ID = iouRequest_ID;
			this.iouUser_ID = iouUser_ID;
			this.remarks = remarks;
			this.iouAmount = iouAmount;
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
		/// Gets or sets the Iou_ID value.
		/// </summary>
		public string Iou_ID {
			get { return iou_ID; }
			set { iou_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouDate value.
		/// </summary>
		public DateTime IouDate {
			get { return iouDate; }
			set { iouDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PcbAccount_ID value.
		/// </summary>
		public string PcbAccount_ID {
			get { return pcbAccount_ID; }
			set { pcbAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouRequest_ID value.
		/// </summary>
		public string IouRequest_ID {
			get { return iouRequest_ID; }
			set { iouRequest_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouUser_ID value.
		/// </summary>
		public string IouUser_ID {
			get { return iouUser_ID; }
			set { iouUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouAmount value.
		/// </summary>
		public decimal IouAmount {
			get { return iouAmount; }
			set { iouAmount = value; }
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
		/// Saves a record to the tbl_pcbTxIOU table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iou_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iouDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iouRequest_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iouUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@iouAmount", SqlDbType.Decimal,9);
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
 
			scom.Parameters["@iou_ID"].Value = iou_ID;
			scom.Parameters["@iouDate"].Value = iouDate;
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@iouRequest_ID"].Value = iouRequest_ID;
			scom.Parameters["@iouUser_ID"].Value = iouUser_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@iouAmount"].Value = iouAmount;
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
		/// Updates a record in the tbl_pcbTxIOU table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iou_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iouDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iouRequest_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iouUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@iouAmount", SqlDbType.Decimal,9);
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
 
 
			scom.Parameters["@iou_ID"].Value = iou_ID;
			scom.Parameters["@iouDate"].Value = iouDate;
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@iouRequest_ID"].Value = iouRequest_ID;
			scom.Parameters["@iouUser_ID"].Value = iouUser_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@iouAmount"].Value = iouAmount;
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
		/// Deletes a record from the tbl_pcbTxIOU table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@iou_ID", SqlDbType.VarChar,10);
			scom.Parameters["@iou_ID"].Value = iou_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOU table by a foreign key.
		/// </summary>
		public static void DeleteAllByPcbAccount_ID(string pcbAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUDeleteAllByPcbAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOU table by a foreign key.
		/// </summary>
		public static void DeleteAllByIouUser_ID(string iouUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUDeleteAllByIouUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouUser_ID"].Value = iouUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOU table by a foreign key.
		/// </summary>
		public static void DeleteAllByIouRequest_ID(string iouRequest_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUDeleteAllByIouRequest_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouRequest_ID", SqlDbType.VarChar,10);
			scom.Parameters["@iouRequest_ID"].Value = iouRequest_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbTxIOU table.
		/// </summary>
		public static tbl_pcbTxIOU Select(string iou_ID_Incoming){

			tbl_pcbTxIOU tbl_pcbTxIOUins = new tbl_pcbTxIOU();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iou_ID", SqlDbType.VarChar,10);
			scom.Parameters["@iou_ID"].Value = iou_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbTxIOUins = Maketbl_pcbTxIOU(dataReader);
				} else {
					tbl_pcbTxIOUins = null;
				}
			}
			scon.Close();
			return tbl_pcbTxIOUins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOU table.
		/// </summary>
		public static List<tbl_pcbTxIOU> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbTxIOU> tbl_pcbTxIOUList = new List<tbl_pcbTxIOU>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOU tbl_pcbTxIOU = Maketbl_pcbTxIOU(dataReader);
					tbl_pcbTxIOUList.Add(tbl_pcbTxIOU);
				}
			}
			scon.Close();
			return tbl_pcbTxIOUList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOU table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOU> SelectAllByPcbAccount_ID(string pcbAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSelectAllByPcbAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
				List<tbl_pcbTxIOU> tbl_pcbTxIOUList = new List<tbl_pcbTxIOU>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOU tbl_pcbTxIOU = Maketbl_pcbTxIOU(dataReader);
					tbl_pcbTxIOUList.Add(tbl_pcbTxIOU);
				}
			}
			scon.Close();
			return tbl_pcbTxIOUList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOU table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOU> SelectAllByIouUser_ID(string iouUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSelectAllByIouUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouUser_ID"].Value = iouUser_ID;
				List<tbl_pcbTxIOU> tbl_pcbTxIOUList = new List<tbl_pcbTxIOU>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOU tbl_pcbTxIOU = Maketbl_pcbTxIOU(dataReader);
					tbl_pcbTxIOUList.Add(tbl_pcbTxIOU);
				}
			}
			scon.Close();
			return tbl_pcbTxIOUList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOU table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOU> SelectAllByIouRequest_ID(string iouRequest_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSelectAllByIouRequest_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouRequest_ID", SqlDbType.VarChar,10);
			scom.Parameters["@iouRequest_ID"].Value = iouRequest_ID;
				List<tbl_pcbTxIOU> tbl_pcbTxIOUList = new List<tbl_pcbTxIOU>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOU tbl_pcbTxIOU = Maketbl_pcbTxIOU(dataReader);
					tbl_pcbTxIOUList.Add(tbl_pcbTxIOU);
				}
			}
			scon.Close();
			return tbl_pcbTxIOUList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbTxIOU class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbTxIOU Maketbl_pcbTxIOU(SqlDataReader dataReader) {
			tbl_pcbTxIOU tbl_pcbTxIOU = new tbl_pcbTxIOU();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbTxIOU.Iou_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbTxIOU.IouDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbTxIOU.PcbAccount_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbTxIOU.IouRequest_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbTxIOU.IouUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pcbTxIOU.Remarks = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pcbTxIOU.IouAmount = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pcbTxIOU.SettledAmount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pcbTxIOU.IsSettled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pcbTxIOU.IsCanceled = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pcbTxIOU.CreateUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pcbTxIOU.ModifiedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pcbTxIOU.CanceldUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pcbTxIOU.DateCreate = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pcbTxIOU.DateModified = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pcbTxIOU.DateCanceled = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pcbTxIOU.CreateUserTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pcbTxIOU.ModifiedUserTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pcbTxIOU.CanceledUserTerminal_ID = dataReader.GetString(18);
			}

			return tbl_pcbTxIOU;
		}
		/// <summary>
		/// This makes tbl_pcbTxIOU datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbTxIOU object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbTxIOU  tbl_pcbTxIOU   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_iou_ID = new DataColumn("iou_ID" , typeof(string));
			DataColumn col_iouDate = new DataColumn("iouDate" , typeof(DateTime));
			DataColumn col_pcbAccount_ID = new DataColumn("pcbAccount_ID" , typeof(string));
			DataColumn col_iouRequest_ID = new DataColumn("iouRequest_ID" , typeof(string));
			DataColumn col_iouUser_ID = new DataColumn("iouUser_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_iouAmount = new DataColumn("iouAmount" , typeof(decimal));
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
		dt.Columns.AddRange(new DataColumn[] { col_iou_ID,col_iouDate,col_pcbAccount_ID,col_iouRequest_ID,col_iouUser_ID,col_remarks,col_iouAmount,col_settledAmount,col_isSettled,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_canceledUserTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbTxIOU datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbTxIOU object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbTxIOU user) {
		DataRow drow = dt.NewRow();
		
			drow["iou_ID"] = user.iou_ID;
			drow["iouDate"] = user.iouDate;
			drow["pcbAccount_ID"] = user.pcbAccount_ID;
			drow["iouRequest_ID"] = user.iouRequest_ID;
			drow["iouUser_ID"] = user.iouUser_ID;
			drow["remarks"] = user.remarks;
			drow["iouAmount"] = user.iouAmount;
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
