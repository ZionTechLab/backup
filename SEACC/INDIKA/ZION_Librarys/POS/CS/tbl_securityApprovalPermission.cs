using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityApprovalPermission {
		#region Fields
		private string user_ID;
		private int processNote_ID;
		private bool isAllow;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityApprovalPermission class.
		/// </summary>
		public tbl_securityApprovalPermission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityApprovalPermission class.
		/// </summary>
		public tbl_securityApprovalPermission(string user_ID, int processNote_ID, bool isAllow) {
			this.user_ID = user_ID;
			this.processNote_ID = processNote_ID;
			this.isAllow = isAllow;
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
		/// Gets or sets the ProcessNote_ID value.
		/// </summary>
		public int ProcessNote_ID {
			get { return processNote_ID; }
			set { processNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAllow value.
		/// </summary>
		public bool IsAllow {
			get { return isAllow; }
			set { isAllow = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityApprovalPermission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isAllow", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@isAllow"].Value = isAllow;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityApprovalPermission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isAllow", SqlDbType.Bit,1);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@isAllow"].Value = isAllow;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityApprovalPermission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityApprovalPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionDeleteAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityApprovalPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityApprovalPermission table.
		/// </summary>
		public static tbl_securityApprovalPermission Select(string user_ID_Incoming, int processNote_ID_Incoming){

			tbl_securityApprovalPermission tbl_securityApprovalPermissionins = new tbl_securityApprovalPermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@processNote_ID"].Value = processNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityApprovalPermissionins = Maketbl_securityApprovalPermission(dataReader);
				} else {
					tbl_securityApprovalPermissionins = null;
				}
			}
			scon.Close();
			return tbl_securityApprovalPermissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityApprovalPermission table.
		/// </summary>
		public static List<tbl_securityApprovalPermission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityApprovalPermission> tbl_securityApprovalPermissionList = new List<tbl_securityApprovalPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityApprovalPermission tbl_securityApprovalPermission = Maketbl_securityApprovalPermission(dataReader);
					tbl_securityApprovalPermissionList.Add(tbl_securityApprovalPermission);
				}
			}
			scon.Close();
			return tbl_securityApprovalPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityApprovalPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityApprovalPermission> SelectAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionSelectAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
				List<tbl_securityApprovalPermission> tbl_securityApprovalPermissionList = new List<tbl_securityApprovalPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityApprovalPermission tbl_securityApprovalPermission = Maketbl_securityApprovalPermission(dataReader);
					tbl_securityApprovalPermissionList.Add(tbl_securityApprovalPermission);
				}
			}
			scon.Close();
			return tbl_securityApprovalPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityApprovalPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityApprovalPermission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityApprovalPermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_securityApprovalPermission> tbl_securityApprovalPermissionList = new List<tbl_securityApprovalPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityApprovalPermission tbl_securityApprovalPermission = Maketbl_securityApprovalPermission(dataReader);
					tbl_securityApprovalPermissionList.Add(tbl_securityApprovalPermission);
				}
			}
			scon.Close();
			return tbl_securityApprovalPermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityApprovalPermission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityApprovalPermission Maketbl_securityApprovalPermission(SqlDataReader dataReader) {
			tbl_securityApprovalPermission tbl_securityApprovalPermission = new tbl_securityApprovalPermission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityApprovalPermission.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityApprovalPermission.ProcessNote_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityApprovalPermission.IsAllow = dataReader.GetBoolean(2);
			}

			return tbl_securityApprovalPermission;
		}
		/// <summary>
		/// This makes tbl_securityApprovalPermission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityApprovalPermission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityApprovalPermission  tbl_securityApprovalPermission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_processNote_ID = new DataColumn("processNote_ID" , typeof(int));
			DataColumn col_isAllow = new DataColumn("isAllow" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_processNote_ID,col_isAllow,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityApprovalPermission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityApprovalPermission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityApprovalPermission user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["processNote_ID"] = user.processNote_ID;
			drow["isAllow"] = user.isAllow;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
