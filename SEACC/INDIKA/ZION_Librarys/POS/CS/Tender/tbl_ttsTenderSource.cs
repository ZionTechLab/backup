using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderSource {
		#region Fields
		private string tenderSource_ID;
		private string tenderSourceName;
		private string description;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderSource class.
		/// </summary>
		public tbl_ttsTenderSource() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderSource class.
		/// </summary>
		public tbl_ttsTenderSource(string tenderSource_ID, string tenderSourceName, string description) {
			this.tenderSource_ID = tenderSource_ID;
			this.tenderSourceName = tenderSourceName;
			this.description = description;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the TenderSource_ID value.
		/// </summary>
		public string TenderSource_ID {
			get { return tenderSource_ID; }
			set { tenderSource_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TenderSourceName value.
		/// </summary>
		public string TenderSourceName {
			get { return tenderSourceName; }
			set { tenderSourceName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderSource table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSourceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tenderSource_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@tenderSourceName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
 
			scom.Parameters["@tenderSource_ID"].Value = tenderSource_ID;
			scom.Parameters["@tenderSourceName"].Value = tenderSourceName;
			scom.Parameters["@description"].Value = description;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderSource table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSourceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tenderSource_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@tenderSourceName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@tenderSource_ID"].Value = tenderSource_ID;
			scom.Parameters["@tenderSourceName"].Value = tenderSourceName;
			scom.Parameters["@description"].Value = description;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderSource table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSourceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tenderSource_ID", SqlDbType.VarChar,8);
			scom.Parameters["@tenderSource_ID"].Value = tenderSource_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderSource table.
		/// </summary>
		public static tbl_ttsTenderSource Select(string tenderSource_ID_Incoming){

			tbl_ttsTenderSource tbl_ttsTenderSourceins = new tbl_ttsTenderSource();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSourceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tenderSource_ID", SqlDbType.VarChar,8);
			scom.Parameters["@tenderSource_ID"].Value = tenderSource_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderSourceins = Maketbl_ttsTenderSource(dataReader);
				} else {
					tbl_ttsTenderSourceins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderSourceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderSource table.
		/// </summary>
		public static List<tbl_ttsTenderSource> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSourceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderSource> tbl_ttsTenderSourceList = new List<tbl_ttsTenderSource>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderSource tbl_ttsTenderSource = Maketbl_ttsTenderSource(dataReader);
					tbl_ttsTenderSourceList.Add(tbl_ttsTenderSource);
				}
			}
			scon.Close();
			return tbl_ttsTenderSourceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderSource class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderSource Maketbl_ttsTenderSource(SqlDataReader dataReader) {
			tbl_ttsTenderSource tbl_ttsTenderSource = new tbl_ttsTenderSource();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderSource.TenderSource_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderSource.TenderSourceName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderSource.Description = dataReader.GetString(2);
			}

			return tbl_ttsTenderSource;
		}
		/// <summary>
		/// This makes tbl_ttsTenderSource datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderSource object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderSource  tbl_ttsTenderSource   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tenderSource_ID = new DataColumn("tenderSource_ID" , typeof(string));
			DataColumn col_tenderSourceName = new DataColumn("tenderSourceName" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_tenderSource_ID,col_tenderSourceName,col_description,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderSource datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderSource object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderSource user) {
		DataRow drow = dt.NewRow();
		
			drow["tenderSource_ID"] = user.tenderSource_ID;
			drow["tenderSourceName"] = user.tenderSourceName;
			drow["description"] = user.description;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
