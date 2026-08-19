using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zFixedAssetType {
		#region Fields
		private int fixedAssetType_ID;
		private string gl_ID;
		private decimal lifeTime;
		private decimal depreciationRate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zFixedAssetType class.
		/// </summary>
		public tbl_zFixedAssetType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zFixedAssetType class.
		/// </summary>
		public tbl_zFixedAssetType(int fixedAssetType_ID, string gl_ID, decimal lifeTime, decimal depreciationRate) {
			this.fixedAssetType_ID = fixedAssetType_ID;
			this.gl_ID = gl_ID;
			this.lifeTime = lifeTime;
			this.depreciationRate = depreciationRate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FixedAssetType_ID value.
		/// </summary>
		public int FixedAssetType_ID {
			get { return fixedAssetType_ID; }
			set { fixedAssetType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LifeTime value.
		/// </summary>
		public decimal LifeTime {
			get { return lifeTime; }
			set { lifeTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepreciationRate value.
		/// </summary>
		public decimal DepreciationRate {
			get { return depreciationRate; }
			set { depreciationRate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zFixedAssetType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFixedAssetTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@fixedAssetType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lifeTime", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depreciationRate", SqlDbType.Decimal,9);
 
			scom.Parameters["@fixedAssetType_ID"].Value = fixedAssetType_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@lifeTime"].Value = lifeTime;
			scom.Parameters["@depreciationRate"].Value = depreciationRate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zFixedAssetType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFixedAssetTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@fixedAssetType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lifeTime", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depreciationRate", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@fixedAssetType_ID"].Value = fixedAssetType_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@lifeTime"].Value = lifeTime;
			scom.Parameters["@depreciationRate"].Value = depreciationRate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zFixedAssetType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFixedAssetTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@fixedAssetType_ID", SqlDbType.Int,4);
			scom.Parameters["@fixedAssetType_ID"].Value = fixedAssetType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zFixedAssetType table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFixedAssetTypeDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zFixedAssetType table.
		/// </summary>
		public static tbl_zFixedAssetType Select(int fixedAssetType_ID_Incoming){

			tbl_zFixedAssetType tbl_zFixedAssetTypeins = new tbl_zFixedAssetType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFixedAssetTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fixedAssetType_ID", SqlDbType.Int,4);
			scom.Parameters["@fixedAssetType_ID"].Value = fixedAssetType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zFixedAssetTypeins = Maketbl_zFixedAssetType(dataReader);
				} else {
					tbl_zFixedAssetTypeins = null;
				}
			}
			scon.Close();
			return tbl_zFixedAssetTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zFixedAssetType table.
		/// </summary>
		public static List<tbl_zFixedAssetType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFixedAssetTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zFixedAssetType> tbl_zFixedAssetTypeList = new List<tbl_zFixedAssetType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zFixedAssetType tbl_zFixedAssetType = Maketbl_zFixedAssetType(dataReader);
					tbl_zFixedAssetTypeList.Add(tbl_zFixedAssetType);
				}
			}
			scon.Close();
			return tbl_zFixedAssetTypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zFixedAssetType table by a foreign key.
		/// </summary>
		public static List<tbl_zFixedAssetType> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFixedAssetTypeSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_zFixedAssetType> tbl_zFixedAssetTypeList = new List<tbl_zFixedAssetType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zFixedAssetType tbl_zFixedAssetType = Maketbl_zFixedAssetType(dataReader);
					tbl_zFixedAssetTypeList.Add(tbl_zFixedAssetType);
				}
			}
			scon.Close();
			return tbl_zFixedAssetTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zFixedAssetType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zFixedAssetType Maketbl_zFixedAssetType(SqlDataReader dataReader) {
			tbl_zFixedAssetType tbl_zFixedAssetType = new tbl_zFixedAssetType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zFixedAssetType.FixedAssetType_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zFixedAssetType.Gl_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zFixedAssetType.LifeTime = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zFixedAssetType.DepreciationRate = dataReader.GetDecimal(3);
			}

			return tbl_zFixedAssetType;
		}
		/// <summary>
		/// This makes tbl_zFixedAssetType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zFixedAssetType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zFixedAssetType  tbl_zFixedAssetType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_fixedAssetType_ID = new DataColumn("fixedAssetType_ID" , typeof(int));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_lifeTime = new DataColumn("lifeTime" , typeof(decimal));
			DataColumn col_depreciationRate = new DataColumn("depreciationRate" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_fixedAssetType_ID,col_gl_ID,col_lifeTime,col_depreciationRate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zFixedAssetType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zFixedAssetType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zFixedAssetType user) {
		DataRow drow = dt.NewRow();
		
			drow["fixedAssetType_ID"] = user.fixedAssetType_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["lifeTime"] = user.lifeTime;
			drow["depreciationRate"] = user.depreciationRate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
