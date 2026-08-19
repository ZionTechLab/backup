using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ZEmpAreaManager {
		#region Fields
		private string areaManager_ID;
		private string areaManagerName;
		private string salesManager_ID;
		private bool isDelete;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ZEmpAreaManager class.
		/// </summary>
		public tbl_ZEmpAreaManager() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ZEmpAreaManager class.
		/// </summary>
		public tbl_ZEmpAreaManager(string areaManager_ID, string areaManagerName, string salesManager_ID, bool isDelete) {
			this.areaManager_ID = areaManager_ID;
			this.areaManagerName = areaManagerName;
			this.salesManager_ID = salesManager_ID;
			this.isDelete = isDelete;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AreaManager_ID value.
		/// </summary>
		public string AreaManager_ID {
			get { return areaManager_ID; }
			set { areaManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AreaManagerName value.
		/// </summary>
		public string AreaManagerName {
			get { return areaManagerName; }
			set { areaManagerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesManager_ID value.
		/// </summary>
		public string SalesManager_ID {
			get { return salesManager_ID; }
			set { salesManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelete value.
		/// </summary>
		public bool IsDelete {
			get { return isDelete; }
			set { isDelete = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ZEmpAreaManager table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@areaManagerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
 
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@areaManagerName"].Value = areaManagerName;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@isDelete"].Value = isDelete;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ZEmpAreaManager table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@areaManagerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
 
 
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@areaManagerName"].Value = areaManagerName;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@isDelete"].Value = isDelete;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ZEmpAreaManager table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpAreaManager table by a foreign key.
		/// </summary>
		public static void DeleteAllByAreaManager_ID(string areaManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerDeleteAllByAreaManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpAreaManager table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesManager_ID(string salesManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerDeleteAllBySalesManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ZEmpAreaManager table.
		/// </summary>
		public static tbl_ZEmpAreaManager Select(string areaManager_ID_Incoming){

			tbl_ZEmpAreaManager tbl_ZEmpAreaManagerins = new tbl_ZEmpAreaManager();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ZEmpAreaManagerins = Maketbl_ZEmpAreaManager(dataReader);
				} else {
					tbl_ZEmpAreaManagerins = null;
				}
			}
			scon.Close();
			return tbl_ZEmpAreaManagerins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpAreaManager table.
		/// </summary>
		public static List<tbl_ZEmpAreaManager> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ZEmpAreaManager> tbl_ZEmpAreaManagerList = new List<tbl_ZEmpAreaManager>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpAreaManager tbl_ZEmpAreaManager = Maketbl_ZEmpAreaManager(dataReader);
					tbl_ZEmpAreaManagerList.Add(tbl_ZEmpAreaManager);
				}
			}
			scon.Close();
			return tbl_ZEmpAreaManagerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpAreaManager table by a foreign key.
		/// </summary>
		public static List<tbl_ZEmpAreaManager> SelectAllByAreaManager_ID(string areaManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerSelectAllByAreaManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
				List<tbl_ZEmpAreaManager> tbl_ZEmpAreaManagerList = new List<tbl_ZEmpAreaManager>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpAreaManager tbl_ZEmpAreaManager = Maketbl_ZEmpAreaManager(dataReader);
					tbl_ZEmpAreaManagerList.Add(tbl_ZEmpAreaManager);
				}
			}
			scon.Close();
			return tbl_ZEmpAreaManagerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpAreaManager table by a foreign key.
		/// </summary>
		public static List<tbl_ZEmpAreaManager> SelectAllBySalesManager_ID(string salesManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpAreaManagerSelectAllBySalesManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
				List<tbl_ZEmpAreaManager> tbl_ZEmpAreaManagerList = new List<tbl_ZEmpAreaManager>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpAreaManager tbl_ZEmpAreaManager = Maketbl_ZEmpAreaManager(dataReader);
					tbl_ZEmpAreaManagerList.Add(tbl_ZEmpAreaManager);
				}
			}
			scon.Close();
			return tbl_ZEmpAreaManagerList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ZEmpAreaManager class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ZEmpAreaManager Maketbl_ZEmpAreaManager(SqlDataReader dataReader) {
			tbl_ZEmpAreaManager tbl_ZEmpAreaManager = new tbl_ZEmpAreaManager();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ZEmpAreaManager.AreaManager_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ZEmpAreaManager.AreaManagerName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ZEmpAreaManager.SalesManager_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ZEmpAreaManager.IsDelete = dataReader.GetBoolean(3);
			}

			return tbl_ZEmpAreaManager;
		}
		/// <summary>
		/// This makes tbl_ZEmpAreaManager datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ZEmpAreaManager object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ZEmpAreaManager  tbl_ZEmpAreaManager   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_areaManager_ID = new DataColumn("areaManager_ID" , typeof(string));
			DataColumn col_areaManagerName = new DataColumn("areaManagerName" , typeof(string));
			DataColumn col_salesManager_ID = new DataColumn("salesManager_ID" , typeof(string));
			DataColumn col_isDelete = new DataColumn("isDelete" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_areaManager_ID,col_areaManagerName,col_salesManager_ID,col_isDelete,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ZEmpAreaManager datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ZEmpAreaManager object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ZEmpAreaManager user) {
		DataRow drow = dt.NewRow();
		
			drow["areaManager_ID"] = user.areaManager_ID;
			drow["areaManagerName"] = user.areaManagerName;
			drow["salesManager_ID"] = user.salesManager_ID;
			drow["isDelete"] = user.isDelete;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
