using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPettyCashExpenditureType {
		#region Fields
		private string pettyCashExpenditureType_ID;
		private string pettyCashExpenditureTypeName;
		private string pettyCash_Level_3_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCashExpenditureType class.
		/// </summary>
		public tbl_zPettyCashExpenditureType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCashExpenditureType class.
		/// </summary>
		public tbl_zPettyCashExpenditureType(string pettyCashExpenditureType_ID, string pettyCashExpenditureTypeName, string pettyCash_Level_3_ID) {
			this.pettyCashExpenditureType_ID = pettyCashExpenditureType_ID;
			this.pettyCashExpenditureTypeName = pettyCashExpenditureTypeName;
			this.pettyCash_Level_3_ID = pettyCash_Level_3_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PettyCashExpenditureType_ID value.
		/// </summary>
		public string PettyCashExpenditureType_ID {
			get { return pettyCashExpenditureType_ID; }
			set { pettyCashExpenditureType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCashExpenditureTypeName value.
		/// </summary>
		public string PettyCashExpenditureTypeName {
			get { return pettyCashExpenditureTypeName; }
			set { pettyCashExpenditureTypeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCash_Level_3_ID value.
		/// </summary>
		public string PettyCash_Level_3_ID {
			get { return pettyCash_Level_3_ID; }
			set { pettyCash_Level_3_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zPettyCashExpenditureType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashExpenditureTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCashExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCashExpenditureTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@pettyCash_Level_3_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@pettyCashExpenditureType_ID"].Value = pettyCashExpenditureType_ID;
			scom.Parameters["@pettyCashExpenditureTypeName"].Value = pettyCashExpenditureTypeName;
			scom.Parameters["@pettyCash_Level_3_ID"].Value = pettyCash_Level_3_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPettyCashExpenditureType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashExpenditureTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCashExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCashExpenditureTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@pettyCash_Level_3_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@pettyCashExpenditureType_ID"].Value = pettyCashExpenditureType_ID;
			scom.Parameters["@pettyCashExpenditureTypeName"].Value = pettyCashExpenditureTypeName;
			scom.Parameters["@pettyCash_Level_3_ID"].Value = pettyCash_Level_3_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPettyCashExpenditureType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashExpenditureTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pettyCashExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCashExpenditureType_ID"].Value = pettyCashExpenditureType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCashExpenditureType table by a foreign key.
		/// </summary>
		public static void DeleteAllByPettyCash_Level_3_ID(string pettyCash_Level_3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashExpenditureTypeDeleteAllByPettyCash_Level_3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_3_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_3_ID"].Value = pettyCash_Level_3_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPettyCashExpenditureType table.
		/// </summary>
		public static tbl_zPettyCashExpenditureType Select(string pettyCashExpenditureType_ID_Incoming){

			tbl_zPettyCashExpenditureType tbl_zPettyCashExpenditureTypeins = new tbl_zPettyCashExpenditureType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashExpenditureTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCashExpenditureType_ID"].Value = pettyCashExpenditureType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPettyCashExpenditureTypeins = Maketbl_zPettyCashExpenditureType(dataReader);
				} else {
					tbl_zPettyCashExpenditureTypeins = null;
				}
			}
			scon.Close();
			return tbl_zPettyCashExpenditureTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCashExpenditureType table.
		/// </summary>
		public static List<tbl_zPettyCashExpenditureType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashExpenditureTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPettyCashExpenditureType> tbl_zPettyCashExpenditureTypeList = new List<tbl_zPettyCashExpenditureType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPettyCashExpenditureType tbl_zPettyCashExpenditureType = Maketbl_zPettyCashExpenditureType(dataReader);
					tbl_zPettyCashExpenditureTypeList.Add(tbl_zPettyCashExpenditureType);
				}
			}
			scon.Close();
			return tbl_zPettyCashExpenditureTypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCashExpenditureType table by a foreign key.
		/// </summary>
		public static List<tbl_zPettyCashExpenditureType> SelectAllByPettyCash_Level_3_ID(string pettyCash_Level_3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashExpenditureTypeSelectAllByPettyCash_Level_3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_3_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_3_ID"].Value = pettyCash_Level_3_ID;
				List<tbl_zPettyCashExpenditureType> tbl_zPettyCashExpenditureTypeList = new List<tbl_zPettyCashExpenditureType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPettyCashExpenditureType tbl_zPettyCashExpenditureType = Maketbl_zPettyCashExpenditureType(dataReader);
					tbl_zPettyCashExpenditureTypeList.Add(tbl_zPettyCashExpenditureType);
				}
			}
			scon.Close();
			return tbl_zPettyCashExpenditureTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPettyCashExpenditureType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPettyCashExpenditureType Maketbl_zPettyCashExpenditureType(SqlDataReader dataReader) {
			tbl_zPettyCashExpenditureType tbl_zPettyCashExpenditureType = new tbl_zPettyCashExpenditureType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPettyCashExpenditureType.PettyCashExpenditureType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPettyCashExpenditureType.PettyCashExpenditureTypeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zPettyCashExpenditureType.PettyCash_Level_3_ID = dataReader.GetString(2);
			}

			return tbl_zPettyCashExpenditureType;
		}
		/// <summary>
		/// This makes tbl_zPettyCashExpenditureType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPettyCashExpenditureType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPettyCashExpenditureType  tbl_zPettyCashExpenditureType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pettyCashExpenditureType_ID = new DataColumn("pettyCashExpenditureType_ID" , typeof(string));
			DataColumn col_pettyCashExpenditureTypeName = new DataColumn("pettyCashExpenditureTypeName" , typeof(string));
			DataColumn col_pettyCash_Level_3_ID = new DataColumn("pettyCash_Level_3_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_pettyCashExpenditureType_ID,col_pettyCashExpenditureTypeName,col_pettyCash_Level_3_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPettyCashExpenditureType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPettyCashExpenditureType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPettyCashExpenditureType user) {
		DataRow drow = dt.NewRow();
		
			drow["pettyCashExpenditureType_ID"] = user.pettyCashExpenditureType_ID;
			drow["pettyCashExpenditureTypeName"] = user.pettyCashExpenditureTypeName;
			drow["pettyCash_Level_3_ID"] = user.pettyCash_Level_3_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
