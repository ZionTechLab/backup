using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobPolytheneType {
		#region Fields
		private string polytheneType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPolytheneType class.
		/// </summary>
		public tbl_zJobPolytheneType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPolytheneType class.
		/// </summary>
		public tbl_zJobPolytheneType(string polytheneType_ID, string typeName) {
			this.polytheneType_ID = polytheneType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PolytheneType_ID value.
		/// </summary>
		public string PolytheneType_ID {
			get { return polytheneType_ID; }
			set { polytheneType_ID = value; }
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
		/// Saves a record to the tbl_zJobPolytheneType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobPolytheneType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobPolytheneType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobPolytheneType table.
		/// </summary>
		public static tbl_zJobPolytheneType Select(string polytheneType_ID_Incoming){

			tbl_zJobPolytheneType tbl_zJobPolytheneTypeins = new tbl_zJobPolytheneType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobPolytheneTypeins = Maketbl_zJobPolytheneType(dataReader);
				} else {
					tbl_zJobPolytheneTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobPolytheneTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobPolytheneType table.
		/// </summary>
		public static List<tbl_zJobPolytheneType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobPolytheneType> tbl_zJobPolytheneTypeList = new List<tbl_zJobPolytheneType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobPolytheneType tbl_zJobPolytheneType = Maketbl_zJobPolytheneType(dataReader);
					tbl_zJobPolytheneTypeList.Add(tbl_zJobPolytheneType);
				}
			}
			scon.Close();
			return tbl_zJobPolytheneTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobPolytheneType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobPolytheneType Maketbl_zJobPolytheneType(SqlDataReader dataReader) {
			tbl_zJobPolytheneType tbl_zJobPolytheneType = new tbl_zJobPolytheneType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobPolytheneType.PolytheneType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobPolytheneType.TypeName = dataReader.GetString(1);
			}

			return tbl_zJobPolytheneType;
		}
		/// <summary>
		/// This makes tbl_zJobPolytheneType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobPolytheneType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobPolytheneType  tbl_zJobPolytheneType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_polytheneType_ID = new DataColumn("polytheneType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_polytheneType_ID,col_typeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobPolytheneType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobPolytheneType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobPolytheneType user) {
		DataRow drow = dt.NewRow();
		
			drow["polytheneType_ID"] = user.polytheneType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
