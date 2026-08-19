using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobSealingType {
		#region Fields
		private string sealingType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobSealingType class.
		/// </summary>
		public tbl_zJobSealingType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobSealingType class.
		/// </summary>
		public tbl_zJobSealingType(string sealingType_ID, string typeName) {
			this.sealingType_ID = sealingType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SealingType_ID value.
		/// </summary>
		public string SealingType_ID {
			get { return sealingType_ID; }
			set { sealingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobSealingType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobSealingType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobSealingType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobSealingType table.
		/// </summary>
		public static tbl_zJobSealingType Select(string sealingType_ID_Incoming){

			tbl_zJobSealingType tbl_zJobSealingTypeins = new tbl_zJobSealingType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobSealingTypeins = Maketbl_zJobSealingType(dataReader);
				} else {
					tbl_zJobSealingTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobSealingTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobSealingType table.
		/// </summary>
		public static List<tbl_zJobSealingType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobSealingType> tbl_zJobSealingTypeList = new List<tbl_zJobSealingType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobSealingType tbl_zJobSealingType = Maketbl_zJobSealingType(dataReader);
					tbl_zJobSealingTypeList.Add(tbl_zJobSealingType);
				}
			}
			scon.Close();
			return tbl_zJobSealingTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobSealingType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobSealingType Maketbl_zJobSealingType(SqlDataReader dataReader) {
			tbl_zJobSealingType tbl_zJobSealingType = new tbl_zJobSealingType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobSealingType.SealingType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobSealingType.TypeName = dataReader.GetString(1);
			}

			return tbl_zJobSealingType;
		}
		/// <summary>
		/// This makes tbl_zJobSealingType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobSealingType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobSealingType  tbl_zJobSealingType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_sealingType_ID = new DataColumn("sealingType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_sealingType_ID,col_typeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobSealingType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobSealingType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobSealingType user) {
		DataRow drow = dt.NewRow();
		
			drow["sealingType_ID"] = user.sealingType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
