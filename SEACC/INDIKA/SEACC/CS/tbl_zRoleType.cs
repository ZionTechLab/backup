using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zRoleType {
		#region Fields
		private string roleType_ID;
		private string roleTypeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zRoleType class.
		/// </summary>
		public tbl_zRoleType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zRoleType class.
		/// </summary>
		public tbl_zRoleType(string roleType_ID, string roleTypeName) {
			this.roleType_ID = roleType_ID;
			this.roleTypeName = roleTypeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the RoleType_ID value.
		/// </summary>
		public string RoleType_ID {
			get { return roleType_ID; }
			set { roleType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RoleTypeName value.
		/// </summary>
		public string RoleTypeName {
			get { return roleTypeName; }
			set { roleTypeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zRoleType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRoleTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@roleType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@roleTypeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@roleType_ID"].Value = roleType_ID;
			scom.Parameters["@roleTypeName"].Value = roleTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zRoleType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRoleTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@roleType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@roleTypeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@roleType_ID"].Value = roleType_ID;
			scom.Parameters["@roleTypeName"].Value = roleTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zRoleType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRoleTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@roleType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@roleType_ID"].Value = roleType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zRoleType table.
		/// </summary>
		public static tbl_zRoleType Select(string roleType_ID_Incoming){

			tbl_zRoleType tbl_zRoleTypeins = new tbl_zRoleType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRoleTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@roleType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@roleType_ID"].Value = roleType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zRoleTypeins = Maketbl_zRoleType(dataReader);
				} else {
					tbl_zRoleTypeins = null;
				}
			}
			scon.Close();
			return tbl_zRoleTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zRoleType table.
		/// </summary>
		public static List<tbl_zRoleType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRoleTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zRoleType> tbl_zRoleTypeList = new List<tbl_zRoleType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zRoleType tbl_zRoleType = Maketbl_zRoleType(dataReader);
					tbl_zRoleTypeList.Add(tbl_zRoleType);
				}
			}
			scon.Close();
			return tbl_zRoleTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zRoleType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zRoleType Maketbl_zRoleType(SqlDataReader dataReader) {
			tbl_zRoleType tbl_zRoleType = new tbl_zRoleType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zRoleType.RoleType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zRoleType.RoleTypeName = dataReader.GetString(1);
			}

			return tbl_zRoleType;
		}
		/// <summary>
		/// This makes tbl_zRoleType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zRoleType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zRoleType  tbl_zRoleType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_roleType_ID = new DataColumn("roleType_ID" , typeof(string));
			DataColumn col_roleTypeName = new DataColumn("roleTypeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_roleType_ID,col_roleTypeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zRoleType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zRoleType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zRoleType user) {
		DataRow drow = dt.NewRow();
		
			drow["roleType_ID"] = user.roleType_ID;
			drow["roleTypeName"] = user.roleTypeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
