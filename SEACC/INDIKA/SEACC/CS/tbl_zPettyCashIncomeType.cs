using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPettyCashIncomeType {
		#region Fields
		private string pettyCashIncomeType_ID;
		private string pettyCashIncomeTypeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCashIncomeType class.
		/// </summary>
		public tbl_zPettyCashIncomeType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCashIncomeType class.
		/// </summary>
		public tbl_zPettyCashIncomeType(string pettyCashIncomeType_ID, string pettyCashIncomeTypeName) {
			this.pettyCashIncomeType_ID = pettyCashIncomeType_ID;
			this.pettyCashIncomeTypeName = pettyCashIncomeTypeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PettyCashIncomeType_ID value.
		/// </summary>
		public string PettyCashIncomeType_ID {
			get { return pettyCashIncomeType_ID; }
			set { pettyCashIncomeType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCashIncomeTypeName value.
		/// </summary>
		public string PettyCashIncomeTypeName {
			get { return pettyCashIncomeTypeName; }
			set { pettyCashIncomeTypeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zPettyCashIncomeType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashIncomeTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCashIncomeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCashIncomeTypeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@pettyCashIncomeType_ID"].Value = pettyCashIncomeType_ID;
			scom.Parameters["@pettyCashIncomeTypeName"].Value = pettyCashIncomeTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPettyCashIncomeType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashIncomeTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCashIncomeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCashIncomeTypeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@pettyCashIncomeType_ID"].Value = pettyCashIncomeType_ID;
			scom.Parameters["@pettyCashIncomeTypeName"].Value = pettyCashIncomeTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPettyCashIncomeType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashIncomeTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pettyCashIncomeType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCashIncomeType_ID"].Value = pettyCashIncomeType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPettyCashIncomeType table.
		/// </summary>
		public static tbl_zPettyCashIncomeType Select(string pettyCashIncomeType_ID_Incoming){

			tbl_zPettyCashIncomeType tbl_zPettyCashIncomeTypeins = new tbl_zPettyCashIncomeType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashIncomeTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashIncomeType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCashIncomeType_ID"].Value = pettyCashIncomeType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPettyCashIncomeTypeins = Maketbl_zPettyCashIncomeType(dataReader);
				} else {
					tbl_zPettyCashIncomeTypeins = null;
				}
			}
			scon.Close();
			return tbl_zPettyCashIncomeTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCashIncomeType table.
		/// </summary>
		public static List<tbl_zPettyCashIncomeType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCashIncomeTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPettyCashIncomeType> tbl_zPettyCashIncomeTypeList = new List<tbl_zPettyCashIncomeType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPettyCashIncomeType tbl_zPettyCashIncomeType = Maketbl_zPettyCashIncomeType(dataReader);
					tbl_zPettyCashIncomeTypeList.Add(tbl_zPettyCashIncomeType);
				}
			}
			scon.Close();
			return tbl_zPettyCashIncomeTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPettyCashIncomeType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPettyCashIncomeType Maketbl_zPettyCashIncomeType(SqlDataReader dataReader) {
			tbl_zPettyCashIncomeType tbl_zPettyCashIncomeType = new tbl_zPettyCashIncomeType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPettyCashIncomeType.PettyCashIncomeType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPettyCashIncomeType.PettyCashIncomeTypeName = dataReader.GetString(1);
			}

			return tbl_zPettyCashIncomeType;
		}
		/// <summary>
		/// This makes tbl_zPettyCashIncomeType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPettyCashIncomeType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPettyCashIncomeType  tbl_zPettyCashIncomeType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pettyCashIncomeType_ID = new DataColumn("pettyCashIncomeType_ID" , typeof(string));
			DataColumn col_pettyCashIncomeTypeName = new DataColumn("pettyCashIncomeTypeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_pettyCashIncomeType_ID,col_pettyCashIncomeTypeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPettyCashIncomeType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPettyCashIncomeType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPettyCashIncomeType user) {
		DataRow drow = dt.NewRow();
		
			drow["pettyCashIncomeType_ID"] = user.pettyCashIncomeType_ID;
			drow["pettyCashIncomeTypeName"] = user.pettyCashIncomeTypeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
