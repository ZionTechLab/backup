using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ZEmpSalesRep {
		#region Fields
		private string selesRep_ID;
		private string selesRepName;
		private string areaManager_ID;
		private string store_ID;
		private bool isCollector;
		private bool isSalesRep;
		private bool isDelete;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ZEmpSalesRep class.
		/// </summary>
		public tbl_ZEmpSalesRep() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ZEmpSalesRep class.
		/// </summary>
		public tbl_ZEmpSalesRep(string selesRep_ID, string selesRepName, string areaManager_ID, string store_ID, bool isCollector, bool isSalesRep, bool isDelete) {
			this.selesRep_ID = selesRep_ID;
			this.selesRepName = selesRepName;
			this.areaManager_ID = areaManager_ID;
			this.store_ID = store_ID;
			this.isCollector = isCollector;
			this.isSalesRep = isSalesRep;
			this.isDelete = isDelete;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SelesRep_ID value.
		/// </summary>
		public string SelesRep_ID {
			get { return selesRep_ID; }
			set { selesRep_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SelesRepName value.
		/// </summary>
		public string SelesRepName {
			get { return selesRepName; }
			set { selesRepName = value; }
		}
		
		/// <summary>
		/// Gets or sets the AreaManager_ID value.
		/// </summary>
		public string AreaManager_ID {
			get { return areaManager_ID; }
			set { areaManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCollector value.
		/// </summary>
		public bool IsCollector {
			get { return isCollector; }
			set { isCollector = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalesRep value.
		/// </summary>
		public bool IsSalesRep {
			get { return isSalesRep; }
			set { isSalesRep = value; }
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
		/// Saves a record to the tbl_ZEmpSalesRep table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@selesRepName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCollector", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesRep", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
 
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
			scom.Parameters["@selesRepName"].Value = selesRepName;
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@isCollector"].Value = isCollector;
			scom.Parameters["@isSalesRep"].Value = isSalesRep;
			scom.Parameters["@isDelete"].Value = isDelete;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ZEmpSalesRep table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@selesRepName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCollector", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesRep", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
 
 
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
			scom.Parameters["@selesRepName"].Value = selesRepName;
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@isCollector"].Value = isCollector;
			scom.Parameters["@isSalesRep"].Value = isSalesRep;
			scom.Parameters["@isDelete"].Value = isDelete;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ZEmpSalesRep table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesRep table by a foreign key.
		/// </summary>
		public static void DeleteAllBySelesRep_ID(string selesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepDeleteAllBySelesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesRep table by a foreign key.
		/// </summary>
		public static void DeleteAllByAreaManager_ID(string areaManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepDeleteAllByAreaManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ZEmpSalesRep table.
		/// </summary>
		public static tbl_ZEmpSalesRep Select(string selesRep_ID_Incoming){

			tbl_ZEmpSalesRep tbl_ZEmpSalesRepins = new tbl_ZEmpSalesRep();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ZEmpSalesRepins = Maketbl_ZEmpSalesRep(dataReader);
				} else {
					tbl_ZEmpSalesRepins = null;
				}
			}
			scon.Close();
			return tbl_ZEmpSalesRepins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesRep table.
		/// </summary>
		public static List<tbl_ZEmpSalesRep> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ZEmpSalesRep> tbl_ZEmpSalesRepList = new List<tbl_ZEmpSalesRep>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpSalesRep tbl_ZEmpSalesRep = Maketbl_ZEmpSalesRep(dataReader);
					tbl_ZEmpSalesRepList.Add(tbl_ZEmpSalesRep);
				}
			}
			scon.Close();
			return tbl_ZEmpSalesRepList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesRep table by a foreign key.
		/// </summary>
		public static List<tbl_ZEmpSalesRep> SelectAllBySelesRep_ID(string selesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepSelectAllBySelesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
				List<tbl_ZEmpSalesRep> tbl_ZEmpSalesRepList = new List<tbl_ZEmpSalesRep>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpSalesRep tbl_ZEmpSalesRep = Maketbl_ZEmpSalesRep(dataReader);
					tbl_ZEmpSalesRepList.Add(tbl_ZEmpSalesRep);
				}
			}
			scon.Close();
			return tbl_ZEmpSalesRepList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesRep table by a foreign key.
		/// </summary>
		public static List<tbl_ZEmpSalesRep> SelectAllByAreaManager_ID(string areaManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesRepSelectAllByAreaManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
				List<tbl_ZEmpSalesRep> tbl_ZEmpSalesRepList = new List<tbl_ZEmpSalesRep>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpSalesRep tbl_ZEmpSalesRep = Maketbl_ZEmpSalesRep(dataReader);
					tbl_ZEmpSalesRepList.Add(tbl_ZEmpSalesRep);
				}
			}
			scon.Close();
			return tbl_ZEmpSalesRepList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ZEmpSalesRep class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ZEmpSalesRep Maketbl_ZEmpSalesRep(SqlDataReader dataReader) {
			tbl_ZEmpSalesRep tbl_ZEmpSalesRep = new tbl_ZEmpSalesRep();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ZEmpSalesRep.SelesRep_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ZEmpSalesRep.SelesRepName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ZEmpSalesRep.AreaManager_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ZEmpSalesRep.Store_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ZEmpSalesRep.IsCollector = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ZEmpSalesRep.IsSalesRep = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ZEmpSalesRep.IsDelete = dataReader.GetBoolean(6);
			}

			return tbl_ZEmpSalesRep;
		}
		/// <summary>
		/// This makes tbl_ZEmpSalesRep datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ZEmpSalesRep object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ZEmpSalesRep  tbl_ZEmpSalesRep   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_selesRep_ID = new DataColumn("selesRep_ID" , typeof(string));
			DataColumn col_selesRepName = new DataColumn("selesRepName" , typeof(string));
			DataColumn col_areaManager_ID = new DataColumn("areaManager_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_isCollector = new DataColumn("isCollector" , typeof(bool));
			DataColumn col_isSalesRep = new DataColumn("isSalesRep" , typeof(bool));
			DataColumn col_isDelete = new DataColumn("isDelete" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_selesRep_ID,col_selesRepName,col_areaManager_ID,col_store_ID,col_isCollector,col_isSalesRep,col_isDelete,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ZEmpSalesRep datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ZEmpSalesRep object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ZEmpSalesRep user) {
		DataRow drow = dt.NewRow();
		
			drow["selesRep_ID"] = user.selesRep_ID;
			drow["selesRepName"] = user.selesRepName;
			drow["areaManager_ID"] = user.areaManager_ID;
			drow["store_ID"] = user.store_ID;
			drow["isCollector"] = user.isCollector;
			drow["isSalesRep"] = user.isSalesRep;
			drow["isDelete"] = user.isDelete;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
