using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audAudit_Note {
		#region Fields
		private string audit_ID;
		private int processNote_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audAudit_Note class.
		/// </summary>
		public tbl_audAudit_Note() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audAudit_Note class.
		/// </summary>
		public tbl_audAudit_Note(string audit_ID, int processNote_ID, bool isActive) {
			this.audit_ID = audit_ID;
			this.processNote_ID = processNote_ID;
			this.isActive = isActive;
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
		/// Gets or sets the ProcessNote_ID value.
		/// </summary>
		public int ProcessNote_ID {
			get { return processNote_ID; }
			set { processNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audAudit_Note table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@audit_ID"].Value = audit_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audAudit_Note table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@audit_ID"].Value = audit_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audAudit_Note table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@audit_ID"].Value = audit_ID;
 
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Note table by a foreign key.
		/// </summary>
		public static void DeleteAllByAudit_ID(string audit_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteDeleteAllByAudit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@audit_ID"].Value = audit_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Note table by a foreign key.
		/// </summary>
		public static void DeleteAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteDeleteAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audAudit_Note table.
		/// </summary>
		public static tbl_audAudit_Note Select(string audit_ID_Incoming, int processNote_ID_Incoming){

			tbl_audAudit_Note tbl_audAudit_Noteins = new tbl_audAudit_Note();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@audit_ID"].Value = audit_ID_Incoming;
			scom.Parameters["@processNote_ID"].Value = processNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audAudit_Noteins = Maketbl_audAudit_Note(dataReader);
				} else {
					tbl_audAudit_Noteins = null;
				}
			}
			scon.Close();
			return tbl_audAudit_Noteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Note table.
		/// </summary>
		public static List<tbl_audAudit_Note> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audAudit_Note> tbl_audAudit_NoteList = new List<tbl_audAudit_Note>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAudit_Note tbl_audAudit_Note = Maketbl_audAudit_Note(dataReader);
					tbl_audAudit_NoteList.Add(tbl_audAudit_Note);
				}
			}
			scon.Close();
			return tbl_audAudit_NoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Note table by a foreign key.
		/// </summary>
		public static List<tbl_audAudit_Note> SelectAllByAudit_ID(string audit_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteSelectAllByAudit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@audit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@audit_ID"].Value = audit_ID;
				List<tbl_audAudit_Note> tbl_audAudit_NoteList = new List<tbl_audAudit_Note>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAudit_Note tbl_audAudit_Note = Maketbl_audAudit_Note(dataReader);
					tbl_audAudit_NoteList.Add(tbl_audAudit_Note);
				}
			}
			scon.Close();
			return tbl_audAudit_NoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAudit_Note table by a foreign key.
		/// </summary>
		public static List<tbl_audAudit_Note> SelectAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAudit_NoteSelectAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
				List<tbl_audAudit_Note> tbl_audAudit_NoteList = new List<tbl_audAudit_Note>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAudit_Note tbl_audAudit_Note = Maketbl_audAudit_Note(dataReader);
					tbl_audAudit_NoteList.Add(tbl_audAudit_Note);
				}
			}
			scon.Close();
			return tbl_audAudit_NoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audAudit_Note class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audAudit_Note Maketbl_audAudit_Note(SqlDataReader dataReader) {
			tbl_audAudit_Note tbl_audAudit_Note = new tbl_audAudit_Note();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audAudit_Note.Audit_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audAudit_Note.ProcessNote_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audAudit_Note.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_audAudit_Note;
		}
		/// <summary>
		/// This makes tbl_audAudit_Note datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audAudit_Note object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audAudit_Note  tbl_audAudit_Note   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_audit_ID = new DataColumn("audit_ID" , typeof(string));
			DataColumn col_processNote_ID = new DataColumn("processNote_ID" , typeof(int));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_audit_ID,col_processNote_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audAudit_Note datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audAudit_Note object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audAudit_Note user) {
		DataRow drow = dt.NewRow();
		
			drow["audit_ID"] = user.audit_ID;
			drow["processNote_ID"] = user.processNote_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
