using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccAccountPaybleNoteType {
		#region Fields
		private string apnType_ID;
		private string apnTypeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccAccountPaybleNoteType class.
		/// </summary>
		public tbl_zAccAccountPaybleNoteType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccAccountPaybleNoteType class.
		/// </summary>
		public tbl_zAccAccountPaybleNoteType(string apnType_ID, string apnTypeName) {
			this.apnType_ID = apnType_ID;
			this.apnTypeName = apnTypeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ApnType_ID value.
		/// </summary>
		public string ApnType_ID {
			get { return apnType_ID; }
			set { apnType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApnTypeName value.
		/// </summary>
		public string ApnTypeName {
			get { return apnTypeName; }
			set { apnTypeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccAccountPaybleNoteType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccAccountPaybleNoteTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@apnType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@apnTypeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@apnType_ID"].Value = apnType_ID;
			scom.Parameters["@apnTypeName"].Value = apnTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccAccountPaybleNoteType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccAccountPaybleNoteTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@apnType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@apnTypeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@apnType_ID"].Value = apnType_ID;
			scom.Parameters["@apnTypeName"].Value = apnTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccAccountPaybleNoteType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccAccountPaybleNoteTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@apnType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@apnType_ID"].Value = apnType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccAccountPaybleNoteType table.
		/// </summary>
		public static tbl_zAccAccountPaybleNoteType Select(string apnType_ID_Incoming){

			tbl_zAccAccountPaybleNoteType tbl_zAccAccountPaybleNoteTypeins = new tbl_zAccAccountPaybleNoteType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccAccountPaybleNoteTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@apnType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@apnType_ID"].Value = apnType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccAccountPaybleNoteTypeins = Maketbl_zAccAccountPaybleNoteType(dataReader);
				} else {
					tbl_zAccAccountPaybleNoteTypeins = null;
				}
			}
			scon.Close();
			return tbl_zAccAccountPaybleNoteTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccAccountPaybleNoteType table.
		/// </summary>
		public static List<tbl_zAccAccountPaybleNoteType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccAccountPaybleNoteTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccAccountPaybleNoteType> tbl_zAccAccountPaybleNoteTypeList = new List<tbl_zAccAccountPaybleNoteType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccAccountPaybleNoteType tbl_zAccAccountPaybleNoteType = Maketbl_zAccAccountPaybleNoteType(dataReader);
					tbl_zAccAccountPaybleNoteTypeList.Add(tbl_zAccAccountPaybleNoteType);
				}
			}
			scon.Close();
			return tbl_zAccAccountPaybleNoteTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccAccountPaybleNoteType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccAccountPaybleNoteType Maketbl_zAccAccountPaybleNoteType(SqlDataReader dataReader) {
			tbl_zAccAccountPaybleNoteType tbl_zAccAccountPaybleNoteType = new tbl_zAccAccountPaybleNoteType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccAccountPaybleNoteType.ApnType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccAccountPaybleNoteType.ApnTypeName = dataReader.GetString(1);
			}

			return tbl_zAccAccountPaybleNoteType;
		}
		/// <summary>
		/// This makes tbl_zAccAccountPaybleNoteType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccAccountPaybleNoteType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccAccountPaybleNoteType  tbl_zAccAccountPaybleNoteType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_apnType_ID = new DataColumn("apnType_ID" , typeof(string));
			DataColumn col_apnTypeName = new DataColumn("apnTypeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_apnType_ID,col_apnTypeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccAccountPaybleNoteType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccAccountPaybleNoteType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccAccountPaybleNoteType user) {
		DataRow drow = dt.NewRow();
		
			drow["apnType_ID"] = user.apnType_ID;
			drow["apnTypeName"] = user.apnTypeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
