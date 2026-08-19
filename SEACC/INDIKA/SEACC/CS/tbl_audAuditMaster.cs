using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audAuditMaster {
		#region Fields
		private string audit_ID;
		private string auditName;
		private string auditCategory_ID;
		private bool isOnlyCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audAuditMaster class.
		/// </summary>
		public tbl_audAuditMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audAuditMaster class.
		/// </summary>
		public tbl_audAuditMaster(string audit_ID, string auditName, string auditCategory_ID, bool isOnlyCanceled) {
			this.audit_ID = audit_ID;
			this.auditName = auditName;
			this.auditCategory_ID = auditCategory_ID;
			this.isOnlyCanceled = isOnlyCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Audit_ID value.
		/// </summary>
		public string Audit_ID {
			get { return audit_ID; }
			set { audit_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AuditName value.
		/// </summary>
		public string AuditName {
			get { return auditName; }
			set { auditName = value; }
		}
		
		/// <summary>
		/// Gets or sets the AuditCategory_ID value.
		/// </summary>
		public string AuditCategory_ID {
			get { return auditCategory_ID; }
			set { auditCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOnlyCanceled value.
		/// </summary>
		public bool IsOnlyCanceled {
			get { return isOnlyCanceled; }
			set { isOnlyCanceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audAuditMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAuditMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@auditName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isOnlyCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@audit_ID"].Value = audit_ID;
			scom.Parameters["@auditName"].Value = auditName;
			scom.Parameters["@auditCategory_ID"].Value = auditCategory_ID;
			scom.Parameters["@isOnlyCanceled"].Value = isOnlyCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audAuditMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAuditMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@auditName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isOnlyCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@audit_ID"].Value = audit_ID;
			scom.Parameters["@auditName"].Value = auditName;
			scom.Parameters["@auditCategory_ID"].Value = auditCategory_ID;
			scom.Parameters["@isOnlyCanceled"].Value = isOnlyCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audAuditMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAuditMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@audit_ID"].Value = audit_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAuditMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByAuditCategory_ID(string auditCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAuditMasterDeleteAllByAuditCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@auditCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@auditCategory_ID"].Value = auditCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audAuditMaster table.
		/// </summary>
		public static tbl_audAuditMaster Select(string audit_ID_Incoming){

			tbl_audAuditMaster tbl_audAuditMasterins = new tbl_audAuditMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAuditMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@audit_ID"].Value = audit_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audAuditMasterins = Maketbl_audAuditMaster(dataReader);
				} else {
					tbl_audAuditMasterins = null;
				}
			}
			scon.Close();
			return tbl_audAuditMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAuditMaster table.
		/// </summary>
		public static List<tbl_audAuditMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAuditMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audAuditMaster> tbl_audAuditMasterList = new List<tbl_audAuditMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAuditMaster tbl_audAuditMaster = Maketbl_audAuditMaster(dataReader);
					tbl_audAuditMasterList.Add(tbl_audAuditMaster);
				}
			}
			scon.Close();
			return tbl_audAuditMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAuditMaster table by a foreign key.
		/// </summary>
		public static List<tbl_audAuditMaster> SelectAllByAuditCategory_ID(string auditCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAuditMasterSelectAllByAuditCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@auditCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@auditCategory_ID"].Value = auditCategory_ID;
				List<tbl_audAuditMaster> tbl_audAuditMasterList = new List<tbl_audAuditMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAuditMaster tbl_audAuditMaster = Maketbl_audAuditMaster(dataReader);
					tbl_audAuditMasterList.Add(tbl_audAuditMaster);
				}
			}
			scon.Close();
			return tbl_audAuditMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audAuditMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audAuditMaster Maketbl_audAuditMaster(SqlDataReader dataReader) {
			tbl_audAuditMaster tbl_audAuditMaster = new tbl_audAuditMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audAuditMaster.Audit_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audAuditMaster.AuditName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audAuditMaster.AuditCategory_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audAuditMaster.IsOnlyCanceled = dataReader.GetBoolean(3);
			}

			return tbl_audAuditMaster;
		}
		/// <summary>
		/// This makes tbl_audAuditMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audAuditMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audAuditMaster  tbl_audAuditMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_audit_ID = new DataColumn("audit_ID" , typeof(string));
			DataColumn col_auditName = new DataColumn("auditName" , typeof(string));
			DataColumn col_auditCategory_ID = new DataColumn("auditCategory_ID" , typeof(string));
			DataColumn col_isOnlyCanceled = new DataColumn("isOnlyCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_audit_ID,col_auditName,col_auditCategory_ID,col_isOnlyCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audAuditMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audAuditMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audAuditMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["audit_ID"] = user.audit_ID;
			drow["auditName"] = user.auditName;
			drow["auditCategory_ID"] = user.auditCategory_ID;
			drow["isOnlyCanceled"] = user.isOnlyCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
