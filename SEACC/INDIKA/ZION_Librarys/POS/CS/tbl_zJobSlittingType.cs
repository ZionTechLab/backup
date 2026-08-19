using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobSlittingType {
		#region Fields
		private string slittingType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobSlittingType class.
		/// </summary>
		public tbl_zJobSlittingType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobSlittingType class.
		/// </summary>
		public tbl_zJobSlittingType(string slittingType_ID, string typeName) {
			this.slittingType_ID = slittingType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SlittingType_ID value.
		/// </summary>
		public string SlittingType_ID {
			get { return slittingType_ID; }
			set { slittingType_ID = value; }
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
		/// Saves a record to the tbl_zJobSlittingType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSlittingTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@slittingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@slittingType_ID"].Value = slittingType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobSlittingType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSlittingTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@slittingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@slittingType_ID"].Value = slittingType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobSlittingType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSlittingTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@slittingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@slittingType_ID"].Value = slittingType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobSlittingType table.
		/// </summary>
		public static tbl_zJobSlittingType Select(string slittingType_ID_Incoming){

			tbl_zJobSlittingType tbl_zJobSlittingTypeins = new tbl_zJobSlittingType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSlittingTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slittingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@slittingType_ID"].Value = slittingType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobSlittingTypeins = Maketbl_zJobSlittingType(dataReader);
				} else {
					tbl_zJobSlittingTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobSlittingTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobSlittingType table.
		/// </summary>
		public static List<tbl_zJobSlittingType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSlittingTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobSlittingType> tbl_zJobSlittingTypeList = new List<tbl_zJobSlittingType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobSlittingType tbl_zJobSlittingType = Maketbl_zJobSlittingType(dataReader);
					tbl_zJobSlittingTypeList.Add(tbl_zJobSlittingType);
				}
			}
			scon.Close();
			return tbl_zJobSlittingTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobSlittingType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobSlittingType Maketbl_zJobSlittingType(SqlDataReader dataReader) {
			tbl_zJobSlittingType tbl_zJobSlittingType = new tbl_zJobSlittingType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobSlittingType.SlittingType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobSlittingType.TypeName = dataReader.GetString(1);
			}

			return tbl_zJobSlittingType;
		}
		/// <summary>
		/// This makes tbl_zJobSlittingType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobSlittingType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobSlittingType  tbl_zJobSlittingType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_slittingType_ID = new DataColumn("slittingType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_slittingType_ID,col_typeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobSlittingType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobSlittingType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobSlittingType user) {
		DataRow drow = dt.NewRow();
		
			drow["slittingType_ID"] = user.slittingType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
