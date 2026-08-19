using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_Note {
		#region Fields
		private int note_ID;
		private string noteName;
		private string glSubCatagory_ID1;
		private string glSubCatagory_ID2;
		private bool isAddition;
		private bool isTotal;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Note class.
		/// </summary>
		public tbl_accGLMaster_Note() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Note class.
		/// </summary>
		public tbl_accGLMaster_Note(int note_ID, string noteName, string glSubCatagory_ID1, string glSubCatagory_ID2, bool isAddition, bool isTotal) {
			this.note_ID = note_ID;
			this.noteName = noteName;
			this.glSubCatagory_ID1 = glSubCatagory_ID1;
			this.glSubCatagory_ID2 = glSubCatagory_ID2;
			this.isAddition = isAddition;
			this.isTotal = isTotal;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Note_ID value.
		/// </summary>
		public int Note_ID {
			get { return note_ID; }
			set { note_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoteName value.
		/// </summary>
		public string NoteName {
			get { return noteName; }
			set { noteName = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlSubCatagory_ID1 value.
		/// </summary>
		public string GlSubCatagory_ID1 {
			get { return glSubCatagory_ID1; }
			set { glSubCatagory_ID1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlSubCatagory_ID2 value.
		/// </summary>
		public string GlSubCatagory_ID2 {
			get { return glSubCatagory_ID2; }
			set { glSubCatagory_ID2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAddition value.
		/// </summary>
		public bool IsAddition {
			get { return isAddition; }
			set { isAddition = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTotal value.
		/// </summary>
		public bool IsTotal {
			get { return isTotal; }
			set { isTotal = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLMaster_Note table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_NoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@note_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@noteName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glSubCatagory_ID1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glSubCatagory_ID2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isAddition", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTotal", SqlDbType.Bit,1);
 
			scom.Parameters["@note_ID"].Value = note_ID;
			scom.Parameters["@noteName"].Value = noteName;
			scom.Parameters["@glSubCatagory_ID1"].Value = glSubCatagory_ID1;
			scom.Parameters["@glSubCatagory_ID2"].Value = glSubCatagory_ID2;
			scom.Parameters["@isAddition"].Value = isAddition;
			scom.Parameters["@isTotal"].Value = isTotal;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_Note table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_NoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@note_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@noteName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glSubCatagory_ID1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glSubCatagory_ID2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isAddition", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTotal", SqlDbType.Bit,1);
 
 
			scom.Parameters["@note_ID"].Value = note_ID;
			scom.Parameters["@noteName"].Value = noteName;
			scom.Parameters["@glSubCatagory_ID1"].Value = glSubCatagory_ID1;
			scom.Parameters["@glSubCatagory_ID2"].Value = glSubCatagory_ID2;
			scom.Parameters["@isAddition"].Value = isAddition;
			scom.Parameters["@isTotal"].Value = isTotal;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_Note table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_NoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@note_ID", SqlDbType.Int,4);
			scom.Parameters["@note_ID"].Value = note_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_Note table.
		/// </summary>
		public static tbl_accGLMaster_Note Select(int note_ID_Incoming){

			tbl_accGLMaster_Note tbl_accGLMaster_Noteins = new tbl_accGLMaster_Note();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_NoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@note_ID", SqlDbType.Int,4);
			scom.Parameters["@note_ID"].Value = note_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_Noteins = Maketbl_accGLMaster_Note(dataReader);
				} else {
					tbl_accGLMaster_Noteins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_Noteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Note table.
		/// </summary>
		public static List<tbl_accGLMaster_Note> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_NoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_Note> tbl_accGLMaster_NoteList = new List<tbl_accGLMaster_Note>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Note tbl_accGLMaster_Note = Maketbl_accGLMaster_Note(dataReader);
					tbl_accGLMaster_NoteList.Add(tbl_accGLMaster_Note);
				}
			}
			scon.Close();
			return tbl_accGLMaster_NoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_Note class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_Note Maketbl_accGLMaster_Note(SqlDataReader dataReader) {
			tbl_accGLMaster_Note tbl_accGLMaster_Note = new tbl_accGLMaster_Note();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_Note.Note_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_Note.NoteName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_Note.GlSubCatagory_ID1 = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLMaster_Note.GlSubCatagory_ID2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLMaster_Note.IsAddition = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accGLMaster_Note.IsTotal = dataReader.GetBoolean(5);
			}

			return tbl_accGLMaster_Note;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_Note datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Note object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_Note  tbl_accGLMaster_Note   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_note_ID = new DataColumn("note_ID" , typeof(int));
			DataColumn col_noteName = new DataColumn("noteName" , typeof(string));
			DataColumn col_glSubCatagory_ID1 = new DataColumn("glSubCatagory_ID1" , typeof(string));
			DataColumn col_glSubCatagory_ID2 = new DataColumn("glSubCatagory_ID2" , typeof(string));
			DataColumn col_isAddition = new DataColumn("isAddition" , typeof(bool));
			DataColumn col_isTotal = new DataColumn("isTotal" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_note_ID,col_noteName,col_glSubCatagory_ID1,col_glSubCatagory_ID2,col_isAddition,col_isTotal,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_Note datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Note object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_Note user) {
		DataRow drow = dt.NewRow();
		
			drow["note_ID"] = user.note_ID;
			drow["noteName"] = user.noteName;
			drow["glSubCatagory_ID1"] = user.glSubCatagory_ID1;
			drow["glSubCatagory_ID2"] = user.glSubCatagory_ID2;
			drow["isAddition"] = user.isAddition;
			drow["isTotal"] = user.isTotal;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
