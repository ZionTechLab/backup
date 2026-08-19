using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsPettyCashAccount_IOU {
		#region Fields
		private string iouAccount_ID;
		private string pettyCashAccount_ID;
		private DateTime iouDate;
		private string remark;
		private decimal balanceAmount;
		private string iouMangerName;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isClose;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount_IOU class.
		/// </summary>
		public tbl_bpsPettyCashAccount_IOU() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount_IOU class.
		/// </summary>
		public tbl_bpsPettyCashAccount_IOU(string iouAccount_ID, string pettyCashAccount_ID, DateTime iouDate, string remark, decimal balanceAmount, string iouMangerName, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isClose) {
			this.iouAccount_ID = iouAccount_ID;
			this.pettyCashAccount_ID = pettyCashAccount_ID;
			this.iouDate = iouDate;
			this.remark = remark;
			this.balanceAmount = balanceAmount;
			this.iouMangerName = iouMangerName;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isClose = isClose;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the IouAccount_ID value.
		/// </summary>
		public string IouAccount_ID {
			get { return iouAccount_ID; }
			set { iouAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCashAccount_ID value.
		/// </summary>
		public string PettyCashAccount_ID {
			get { return pettyCashAccount_ID; }
			set { pettyCashAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouDate value.
		/// </summary>
		public DateTime IouDate {
			get { return iouDate; }
			set { iouDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the BalanceAmount value.
		/// </summary>
		public decimal BalanceAmount {
			get { return balanceAmount; }
			set { balanceAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouMangerName value.
		/// </summary>
		public string IouMangerName {
			get { return iouMangerName; }
			set { iouMangerName = value; }
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
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
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
		/// Gets or sets the DateChecked value.
		/// </summary>
		public DateTime DateChecked {
			get { return dateChecked; }
			set { dateChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime DateApproved {
			get { return dateApproved; }
			set { dateApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked value.
		/// </summary>
		public bool IsChecked {
			get { return isChecked; }
			set { isChecked = value; }
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
		/// Gets or sets the IsClose value.
		/// </summary>
		public bool IsClose {
			get { return isClose; }
			set { isClose = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsPettyCashAccount_IOU table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOUInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@iouDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@balanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@iouMangerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isClose", SqlDbType.Bit,1);
 
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@iouDate"].Value = iouDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@balanceAmount"].Value = balanceAmount;
			scom.Parameters["@iouMangerName"].Value = iouMangerName;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isClose"].Value = isClose;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsPettyCashAccount_IOU table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOUUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@iouDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@balanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@iouMangerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isClose", SqlDbType.Bit,1);
 
 
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@iouDate"].Value = iouDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@balanceAmount"].Value = balanceAmount;
			scom.Parameters["@iouMangerName"].Value = iouMangerName;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isClose"].Value = isClose;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsPettyCashAccount_IOU table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOUDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_IOU table by a foreign key.
		/// </summary>
		public static void DeleteAllByPettyCashAccount_ID(string pettyCashAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOUDeleteAllByPettyCashAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsPettyCashAccount_IOU table.
		/// </summary>
		public static tbl_bpsPettyCashAccount_IOU Select(string iouAccount_ID_Incoming){

			tbl_bpsPettyCashAccount_IOU tbl_bpsPettyCashAccount_IOUins = new tbl_bpsPettyCashAccount_IOU();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOUSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsPettyCashAccount_IOUins = Maketbl_bpsPettyCashAccount_IOU(dataReader);
				} else {
					tbl_bpsPettyCashAccount_IOUins = null;
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_IOUins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_IOU table.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_IOU> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOUSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsPettyCashAccount_IOU> tbl_bpsPettyCashAccount_IOUList = new List<tbl_bpsPettyCashAccount_IOU>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_IOU tbl_bpsPettyCashAccount_IOU = Maketbl_bpsPettyCashAccount_IOU(dataReader);
					tbl_bpsPettyCashAccount_IOUList.Add(tbl_bpsPettyCashAccount_IOU);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_IOUList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_IOU table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_IOU> SelectAllByPettyCashAccount_ID(string pettyCashAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOUSelectAllByPettyCashAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
				List<tbl_bpsPettyCashAccount_IOU> tbl_bpsPettyCashAccount_IOUList = new List<tbl_bpsPettyCashAccount_IOU>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_IOU tbl_bpsPettyCashAccount_IOU = Maketbl_bpsPettyCashAccount_IOU(dataReader);
					tbl_bpsPettyCashAccount_IOUList.Add(tbl_bpsPettyCashAccount_IOU);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_IOUList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsPettyCashAccount_IOU class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsPettyCashAccount_IOU Maketbl_bpsPettyCashAccount_IOU(SqlDataReader dataReader) {
			tbl_bpsPettyCashAccount_IOU tbl_bpsPettyCashAccount_IOU = new tbl_bpsPettyCashAccount_IOU();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsPettyCashAccount_IOU.IouAccount_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsPettyCashAccount_IOU.PettyCashAccount_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsPettyCashAccount_IOU.IouDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsPettyCashAccount_IOU.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsPettyCashAccount_IOU.BalanceAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsPettyCashAccount_IOU.IouMangerName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsPettyCashAccount_IOU.CreateUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsPettyCashAccount_IOU.ModifiedUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsPettyCashAccount_IOU.CheckedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsPettyCashAccount_IOU.ApprovedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsPettyCashAccount_IOU.DateCreate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsPettyCashAccount_IOU.DateModified = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsPettyCashAccount_IOU.DateChecked = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsPettyCashAccount_IOU.DateApproved = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsPettyCashAccount_IOU.IsChecked = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsPettyCashAccount_IOU.IsApproved = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsPettyCashAccount_IOU.IsFinished = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsPettyCashAccount_IOU.IsDeleted = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsPettyCashAccount_IOU.IsLocked = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsPettyCashAccount_IOU.IsClose = dataReader.GetBoolean(19);
			}

			return tbl_bpsPettyCashAccount_IOU;
		}
		/// <summary>
		/// This makes tbl_bpsPettyCashAccount_IOU datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount_IOU object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsPettyCashAccount_IOU  tbl_bpsPettyCashAccount_IOU   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_iouAccount_ID = new DataColumn("iouAccount_ID" , typeof(string));
			DataColumn col_pettyCashAccount_ID = new DataColumn("pettyCashAccount_ID" , typeof(string));
			DataColumn col_iouDate = new DataColumn("iouDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_balanceAmount = new DataColumn("balanceAmount" , typeof(decimal));
			DataColumn col_iouMangerName = new DataColumn("iouMangerName" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isClose = new DataColumn("isClose" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_iouAccount_ID,col_pettyCashAccount_ID,col_iouDate,col_remark,col_balanceAmount,col_iouMangerName,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isClose,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsPettyCashAccount_IOU datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount_IOU object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsPettyCashAccount_IOU user) {
		DataRow drow = dt.NewRow();
		
			drow["iouAccount_ID"] = user.iouAccount_ID;
			drow["pettyCashAccount_ID"] = user.pettyCashAccount_ID;
			drow["iouDate"] = user.iouDate;
			drow["remark"] = user.remark;
			drow["balanceAmount"] = user.balanceAmount;
			drow["iouMangerName"] = user.iouMangerName;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isClose"] = user.isClose;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
