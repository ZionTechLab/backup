using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobGussestType {
		#region Fields
		private string gussestType_ID;
		private string gussestTypeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobGussestType class.
		/// </summary>
		public tbl_zJobGussestType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobGussestType class.
		/// </summary>
		public tbl_zJobGussestType(string gussestType_ID, string gussestTypeName) {
			this.gussestType_ID = gussestType_ID;
			this.gussestTypeName = gussestTypeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GussestType_ID value.
		/// </summary>
		public string GussestType_ID {
			get { return gussestType_ID; }
			set { gussestType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GussestTypeName value.
		/// </summary>
		public string GussestTypeName {
			get { return gussestTypeName; }
			set { gussestTypeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobGussestType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobGussestTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gussestType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gussestTypeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@gussestType_ID"].Value = gussestType_ID;
			scom.Parameters["@gussestTypeName"].Value = gussestTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobGussestType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobGussestTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gussestType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gussestTypeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@gussestType_ID"].Value = gussestType_ID;
			scom.Parameters["@gussestTypeName"].Value = gussestTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobGussestType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobGussestTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gussestType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@gussestType_ID"].Value = gussestType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobGussestType table.
		/// </summary>
		public static tbl_zJobGussestType Select(string gussestType_ID_Incoming){

			tbl_zJobGussestType tbl_zJobGussestTypeins = new tbl_zJobGussestType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobGussestTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gussestType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@gussestType_ID"].Value = gussestType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobGussestTypeins = Maketbl_zJobGussestType(dataReader);
				} else {
					tbl_zJobGussestTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobGussestTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobGussestType table.
		/// </summary>
		public static List<tbl_zJobGussestType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobGussestTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobGussestType> tbl_zJobGussestTypeList = new List<tbl_zJobGussestType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobGussestType tbl_zJobGussestType = Maketbl_zJobGussestType(dataReader);
					tbl_zJobGussestTypeList.Add(tbl_zJobGussestType);
				}
			}
			scon.Close();
			return tbl_zJobGussestTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobGussestType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobGussestType Maketbl_zJobGussestType(SqlDataReader dataReader) {
			tbl_zJobGussestType tbl_zJobGussestType = new tbl_zJobGussestType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobGussestType.GussestType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobGussestType.GussestTypeName = dataReader.GetString(1);
			}

			return tbl_zJobGussestType;
		}
		/// <summary>
		/// This makes tbl_zJobGussestType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobGussestType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobGussestType  tbl_zJobGussestType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gussestType_ID = new DataColumn("gussestType_ID" , typeof(string));
			DataColumn col_gussestTypeName = new DataColumn("gussestTypeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_gussestType_ID,col_gussestTypeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobGussestType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobGussestType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobGussestType user) {
		DataRow drow = dt.NewRow();
		
			drow["gussestType_ID"] = user.gussestType_ID;
			drow["gussestTypeName"] = user.gussestTypeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
