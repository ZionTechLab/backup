using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audAudit_Users {
		#region Fields
		private string audit_ID;
		private string user_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audAudit_Users class.
		/// </summary>
		public tbl_audAudit_Users() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audAudit_Users class.
		/// </summary>
		public tbl_audAudit_Users(string audit_ID, string user_ID, bool isActive) {
			this.audit_ID = audit_ID;
			this.user_ID = user_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Audit_ID value.
		/// </summary>
		public string Audit_ID {
			get { return audit_ID; }
			set { audit_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audAudit_Users table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@audit_ID"].Value = audit_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audAudit_Users table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@audit_ID"].Value = audit_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audAudit_Users table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@audit_ID"].Value = audit_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Users table by a foreign key.
		/// </summary>
		public static void DeleteAllByAudit_ID(string audit_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersDeleteAllByAudit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@audit_ID"].Value = audit_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Users table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audAudit_Users table.
		/// </summary>
		public static tbl_audAudit_Users Select(string audit_ID_Incoming, string user_ID_Incoming){

			tbl_audAudit_Users tbl_audAudit_Usersins = new tbl_audAudit_Users();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@audit_ID"].Value = audit_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audAudit_Usersins = Maketbl_audAudit_Users(dataReader);
				} else {
					tbl_audAudit_Usersins = null;
				}
			}
			scon.Close();
			return tbl_audAudit_Usersins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Users table.
		/// </summary>
		public static List<tbl_audAudit_Users> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audAudit_Users> tbl_audAudit_UsersList = new List<tbl_audAudit_Users>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAudit_Users tbl_audAudit_Users = Maketbl_audAudit_Users(dataReader);
					tbl_audAudit_UsersList.Add(tbl_audAudit_Users);
				}
			}
			scon.Close();
			return tbl_audAudit_UsersList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Users table by a foreign key.
		/// </summary>
		public static List<tbl_audAudit_Users> SelectAllByAudit_ID(string audit_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersSelectAllByAudit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@audit_ID"].Value = audit_ID;
				List<tbl_audAudit_Users> tbl_audAudit_UsersList = new List<tbl_audAudit_Users>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAudit_Users tbl_audAudit_Users = Maketbl_audAudit_Users(dataReader);
					tbl_audAudit_UsersList.Add(tbl_audAudit_Users);
				}
			}
			scon.Close();
			return tbl_audAudit_UsersList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Users table by a foreign key.
		/// </summary>
		public static List<tbl_audAudit_Users> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_UsersSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_audAudit_Users> tbl_audAudit_UsersList = new List<tbl_audAudit_Users>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAudit_Users tbl_audAudit_Users = Maketbl_audAudit_Users(dataReader);
					tbl_audAudit_UsersList.Add(tbl_audAudit_Users);
				}
			}
			scon.Close();
			return tbl_audAudit_UsersList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audAudit_Users class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audAudit_Users Maketbl_audAudit_Users(SqlDataReader dataReader) {
			tbl_audAudit_Users tbl_audAudit_Users = new tbl_audAudit_Users();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audAudit_Users.Audit_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audAudit_Users.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audAudit_Users.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_audAudit_Users;
		}
		/// <summary>
		/// This makes tbl_audAudit_Users datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audAudit_Users object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audAudit_Users  tbl_audAudit_Users   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_audit_ID = new DataColumn("audit_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_audit_ID,col_user_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audAudit_Users datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audAudit_Users object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audAudit_Users user) {
		DataRow drow = dt.NewRow();
		
			drow["audit_ID"] = user.audit_ID;
			drow["user_ID"] = user.user_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
