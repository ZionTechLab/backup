using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAuditCategory {
		#region Fields
		private string auditCategory_ID;
		private string auditCategoryName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAuditCategory class.
		/// </summary>
		public tbl_zAuditCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAuditCategory class.
		/// </summary>
		public tbl_zAuditCategory(string auditCategory_ID, string auditCategoryName) {
			this.auditCategory_ID = auditCategory_ID;
			this.auditCategoryName = auditCategoryName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AuditCategory_ID value.
		/// </summary>
		public string AuditCategory_ID {
			get { return auditCategory_ID; }
			set { auditCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AuditCategoryName value.
		/// </summary>
		public string AuditCategoryName {
			get { return auditCategoryName; }
			set { auditCategoryName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAuditCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAuditCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@auditCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@auditCategoryName", SqlDbType.VarChar,50);
 
			scom.Parameters["@auditCategory_ID"].Value = auditCategory_ID;
			scom.Parameters["@auditCategoryName"].Value = auditCategoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAuditCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAuditCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@auditCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@auditCategoryName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@auditCategory_ID"].Value = auditCategory_ID;
			scom.Parameters["@auditCategoryName"].Value = auditCategoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAuditCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAuditCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@auditCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@auditCategory_ID"].Value = auditCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAuditCategory table.
		/// </summary>
		public static tbl_zAuditCategory Select(string auditCategory_ID_Incoming){

			tbl_zAuditCategory tbl_zAuditCategoryins = new tbl_zAuditCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAuditCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@auditCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@auditCategory_ID"].Value = auditCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAuditCategoryins = Maketbl_zAuditCategory(dataReader);
				} else {
					tbl_zAuditCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zAuditCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAuditCategory table.
		/// </summary>
		public static List<tbl_zAuditCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAuditCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAuditCategory> tbl_zAuditCategoryList = new List<tbl_zAuditCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAuditCategory tbl_zAuditCategory = Maketbl_zAuditCategory(dataReader);
					tbl_zAuditCategoryList.Add(tbl_zAuditCategory);
				}
			}
			scon.Close();
			return tbl_zAuditCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAuditCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAuditCategory Maketbl_zAuditCategory(SqlDataReader dataReader) {
			tbl_zAuditCategory tbl_zAuditCategory = new tbl_zAuditCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAuditCategory.AuditCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAuditCategory.AuditCategoryName = dataReader.GetString(1);
			}

			return tbl_zAuditCategory;
		}
		/// <summary>
		/// This makes tbl_zAuditCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAuditCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAuditCategory  tbl_zAuditCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_auditCategory_ID = new DataColumn("auditCategory_ID" , typeof(string));
			DataColumn col_auditCategoryName = new DataColumn("auditCategoryName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_auditCategory_ID,col_auditCategoryName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAuditCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAuditCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAuditCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["auditCategory_ID"] = user.auditCategory_ID;
			drow["auditCategoryName"] = user.auditCategoryName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
