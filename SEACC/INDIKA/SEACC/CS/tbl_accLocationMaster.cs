using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accLocationMaster {
		#region Fields
		private string user_ID;
		private string userName;
		private string locationCode;
		private string locationName;
		private string baseCurrency;
		private bool isActive;
		private string createUser_ID;
		private string createTerminal_ID;
		private string modifiedUser_ID;
		private string modifiedTerminal_ID;
		private string checkedUser_ID;
		private string checkedTerminal_ID;
		private string approvedUser_ID;
		private string approvedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accLocationMaster class.
		/// </summary>
		public tbl_accLocationMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accLocationMaster class.
		/// </summary>
		public tbl_accLocationMaster(string user_ID, string userName, string locationCode, string locationName, string baseCurrency, bool isActive, string createUser_ID, string createTerminal_ID, string modifiedUser_ID, string modifiedTerminal_ID, string checkedUser_ID, string checkedTerminal_ID, string approvedUser_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked) {
			this.user_ID = user_ID;
			this.userName = userName;
			this.locationCode = locationCode;
			this.locationName = locationName;
			this.baseCurrency = baseCurrency;
			this.isActive = isActive;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.checkedTerminal_ID = checkedTerminal_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.approvedTerminal_ID = approvedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserName value.
		/// </summary>
		public string UserName {
			get { return userName; }
			set { userName = value; }
		}
		
		/// <summary>
		/// Gets or sets the LocationCode value.
		/// </summary>
		public string LocationCode {
			get { return locationCode; }
			set { locationCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the LocationName value.
		/// </summary>
		public string LocationName {
			get { return locationName; }
			set { locationName = value; }
		}
		
		/// <summary>
		/// Gets or sets the BaseCurrency value.
		/// </summary>
		public string BaseCurrency {
			get { return baseCurrency; }
			set { baseCurrency = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedTerminal_ID value.
		/// </summary>
		public string CheckedTerminal_ID {
			get { return checkedTerminal_ID; }
			set { checkedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedTerminal_ID value.
		/// </summary>
		public string ApprovedTerminal_ID {
			get { return approvedTerminal_ID; }
			set { approvedTerminal_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accLocationMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accLocationMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@locationCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@locationName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@baseCurrency", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@locationCode"].Value = locationCode;
			scom.Parameters["@locationName"].Value = locationName;
			scom.Parameters["@baseCurrency"].Value = baseCurrency;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accLocationMaster table.
		/// </summary>
		public static List<tbl_accLocationMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accLocationMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accLocationMaster> tbl_accLocationMasterList = new List<tbl_accLocationMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accLocationMaster tbl_accLocationMaster = Maketbl_accLocationMaster(dataReader);
					tbl_accLocationMasterList.Add(tbl_accLocationMaster);
				}
			}
			scon.Close();
			return tbl_accLocationMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accLocationMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accLocationMaster Maketbl_accLocationMaster(SqlDataReader dataReader) {
			tbl_accLocationMaster tbl_accLocationMaster = new tbl_accLocationMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accLocationMaster.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accLocationMaster.UserName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accLocationMaster.LocationCode = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accLocationMaster.LocationName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accLocationMaster.BaseCurrency = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accLocationMaster.IsActive = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accLocationMaster.CreateUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accLocationMaster.CreateTerminal_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accLocationMaster.ModifiedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accLocationMaster.ModifiedTerminal_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accLocationMaster.CheckedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accLocationMaster.CheckedTerminal_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accLocationMaster.ApprovedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accLocationMaster.ApprovedTerminal_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accLocationMaster.DateCreate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accLocationMaster.DateModified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accLocationMaster.DateChecked = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accLocationMaster.DateApproved = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accLocationMaster.IsChecked = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accLocationMaster.IsApproved = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accLocationMaster.IsFinished = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accLocationMaster.IsDeleted = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accLocationMaster.IsLocked = dataReader.GetBoolean(22);
			}

			return tbl_accLocationMaster;
		}
		/// <summary>
		/// This makes tbl_accLocationMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accLocationMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accLocationMaster  tbl_accLocationMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_userName = new DataColumn("userName" , typeof(string));
			DataColumn col_locationCode = new DataColumn("locationCode" , typeof(string));
			DataColumn col_locationName = new DataColumn("locationName" , typeof(string));
			DataColumn col_baseCurrency = new DataColumn("baseCurrency" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_checkedTerminal_ID = new DataColumn("checkedTerminal_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_approvedTerminal_ID = new DataColumn("approvedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_userName,col_locationCode,col_locationName,col_baseCurrency,col_isActive,col_createUser_ID,col_createTerminal_ID,col_modifiedUser_ID,col_modifiedTerminal_ID,col_checkedUser_ID,col_checkedTerminal_ID,col_approvedUser_ID,col_approvedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accLocationMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accLocationMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accLocationMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["userName"] = user.userName;
			drow["locationCode"] = user.locationCode;
			drow["locationName"] = user.locationName;
			drow["baseCurrency"] = user.baseCurrency;
			drow["isActive"] = user.isActive;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["checkedTerminal_ID"] = user.checkedTerminal_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["approvedTerminal_ID"] = user.approvedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
