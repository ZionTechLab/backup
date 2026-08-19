using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityUserRole {
		#region Fields
		private string userRole_ID;
		private string userRoleName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserRole class.
		/// </summary>
		public tbl_securityUserRole() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserRole class.
		/// </summary>
		public tbl_securityUserRole(string userRole_ID, string userRoleName) {
			this.userRole_ID = userRole_ID;
			this.userRoleName = userRoleName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the UserRole_ID value.
		/// </summary>
		public string UserRole_ID {
			get { return userRole_ID; }
			set { userRole_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserRoleName value.
		/// </summary>
		public string UserRoleName {
			get { return userRoleName; }
			set { userRoleName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityUserRole table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRoleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userRoleName", SqlDbType.VarChar,50);
 
			scom.Parameters["@userRole_ID"].Value = userRole_ID;
			scom.Parameters["@userRoleName"].Value = userRoleName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityUserRole table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRoleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userRoleName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@userRole_ID"].Value = userRole_ID;
			scom.Parameters["@userRoleName"].Value = userRoleName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityUserRole table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRoleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters["@userRole_ID"].Value = userRole_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityUserRole table.
		/// </summary>
		public static tbl_securityUserRole Select(string userRole_ID_Incoming){

			tbl_securityUserRole tbl_securityUserRoleins = new tbl_securityUserRole();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRoleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters["@userRole_ID"].Value = userRole_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityUserRoleins = Maketbl_securityUserRole(dataReader);
				} else {
					tbl_securityUserRoleins = null;
				}
			}
			scon.Close();
			return tbl_securityUserRoleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserRole table.
		/// </summary>
		public static List<tbl_securityUserRole> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRoleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityUserRole> tbl_securityUserRoleList = new List<tbl_securityUserRole>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserRole tbl_securityUserRole = Maketbl_securityUserRole(dataReader);
					tbl_securityUserRoleList.Add(tbl_securityUserRole);
				}
			}
			scon.Close();
			return tbl_securityUserRoleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityUserRole class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityUserRole Maketbl_securityUserRole(SqlDataReader dataReader) {
			tbl_securityUserRole tbl_securityUserRole = new tbl_securityUserRole();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityUserRole.UserRole_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityUserRole.UserRoleName = dataReader.GetString(1);
			}

			return tbl_securityUserRole;
		}
		/// <summary>
		/// This makes tbl_securityUserRole datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityUserRole object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityUserRole  tbl_securityUserRole   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_userRole_ID = new DataColumn("userRole_ID" , typeof(string));
			DataColumn col_userRoleName = new DataColumn("userRoleName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_userRole_ID,col_userRoleName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityUserRole datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityUserRole object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityUserRole user) {
		DataRow drow = dt.NewRow();
		
			drow["userRole_ID"] = user.userRole_ID;
			drow["userRoleName"] = user.userRoleName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
