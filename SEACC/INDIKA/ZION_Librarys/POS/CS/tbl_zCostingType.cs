using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCostingType {
		#region Fields
		private string costingType_ID;
		private string costingTypeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCostingType class.
		/// </summary>
		public tbl_zCostingType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCostingType class.
		/// </summary>
		public tbl_zCostingType(string costingType_ID, string costingTypeName) {
			this.costingType_ID = costingType_ID;
			this.costingTypeName = costingTypeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CostingType_ID value.
		/// </summary>
		public string CostingType_ID {
			get { return costingType_ID; }
			set { costingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostingTypeName value.
		/// </summary>
		public string CostingTypeName {
			get { return costingTypeName; }
			set { costingTypeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zCostingType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCostingTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costingTypeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
			scom.Parameters["@costingTypeName"].Value = costingTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCostingType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCostingTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costingTypeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
			scom.Parameters["@costingTypeName"].Value = costingTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCostingType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCostingTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCostingType table.
		/// </summary>
		public static tbl_zCostingType Select(string costingType_ID_Incoming){

			tbl_zCostingType tbl_zCostingTypeins = new tbl_zCostingType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCostingTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costingType_ID"].Value = costingType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCostingTypeins = Maketbl_zCostingType(dataReader);
				} else {
					tbl_zCostingTypeins = null;
				}
			}
			scon.Close();
			return tbl_zCostingTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCostingType table.
		/// </summary>
		public static List<tbl_zCostingType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCostingTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCostingType> tbl_zCostingTypeList = new List<tbl_zCostingType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCostingType tbl_zCostingType = Maketbl_zCostingType(dataReader);
					tbl_zCostingTypeList.Add(tbl_zCostingType);
				}
			}
			scon.Close();
			return tbl_zCostingTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCostingType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCostingType Maketbl_zCostingType(SqlDataReader dataReader) {
			tbl_zCostingType tbl_zCostingType = new tbl_zCostingType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCostingType.CostingType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCostingType.CostingTypeName = dataReader.GetString(1);
			}

			return tbl_zCostingType;
		}
		/// <summary>
		/// This makes tbl_zCostingType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zCostingType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zCostingType  tbl_zCostingType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_costingType_ID = new DataColumn("costingType_ID" , typeof(string));
			DataColumn col_costingTypeName = new DataColumn("costingTypeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_costingType_ID,col_costingTypeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zCostingType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCostingType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCostingType user) {
		DataRow drow = dt.NewRow();
		
			drow["costingType_ID"] = user.costingType_ID;
			drow["costingTypeName"] = user.costingTypeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
