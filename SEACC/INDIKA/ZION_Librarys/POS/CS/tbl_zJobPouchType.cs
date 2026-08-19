using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobPouchType {
		#region Fields
		private string pouchType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPouchType class.
		/// </summary>
		public tbl_zJobPouchType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPouchType class.
		/// </summary>
		public tbl_zJobPouchType(string pouchType_ID, string typeName) {
			this.pouchType_ID = pouchType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PouchType_ID value.
		/// </summary>
		public string PouchType_ID {
			get { return pouchType_ID; }
			set { pouchType_ID = value; }
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
		/// Saves a record to the tbl_zJobPouchType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPouchTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pouchType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@pouchType_ID"].Value = pouchType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobPouchType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPouchTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pouchType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@pouchType_ID"].Value = pouchType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobPouchType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPouchTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pouchType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pouchType_ID"].Value = pouchType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobPouchType table.
		/// </summary>
		public static tbl_zJobPouchType Select(string pouchType_ID_Incoming){

			tbl_zJobPouchType tbl_zJobPouchTypeins = new tbl_zJobPouchType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPouchTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pouchType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pouchType_ID"].Value = pouchType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobPouchTypeins = Maketbl_zJobPouchType(dataReader);
				} else {
					tbl_zJobPouchTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobPouchTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobPouchType table.
		/// </summary>
		public static List<tbl_zJobPouchType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPouchTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobPouchType> tbl_zJobPouchTypeList = new List<tbl_zJobPouchType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobPouchType tbl_zJobPouchType = Maketbl_zJobPouchType(dataReader);
					tbl_zJobPouchTypeList.Add(tbl_zJobPouchType);
				}
			}
			scon.Close();
			return tbl_zJobPouchTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobPouchType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobPouchType Maketbl_zJobPouchType(SqlDataReader dataReader) {
			tbl_zJobPouchType tbl_zJobPouchType = new tbl_zJobPouchType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobPouchType.PouchType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobPouchType.TypeName = dataReader.GetString(1);
			}

			return tbl_zJobPouchType;
		}
		/// <summary>
		/// This makes tbl_zJobPouchType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobPouchType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobPouchType  tbl_zJobPouchType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pouchType_ID = new DataColumn("pouchType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_pouchType_ID,col_typeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobPouchType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobPouchType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobPouchType user) {
		DataRow drow = dt.NewRow();
		
			drow["pouchType_ID"] = user.pouchType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
