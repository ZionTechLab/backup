using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audTransaction_DebitNote {
		#region Fields
		private string debitNote_ID;
		private string user_ID;
		private bool bIsCanceled;
		private string terminal_ID;
		private DateTime auditDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audTransaction_DebitNote class.
		/// </summary>
		public tbl_audTransaction_DebitNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audTransaction_DebitNote class.
		/// </summary>
		public tbl_audTransaction_DebitNote(string debitNote_ID, string user_ID, bool bIsCanceled, string terminal_ID, DateTime auditDate) {
			this.debitNote_ID = debitNote_ID;
			this.user_ID = user_ID;
			this.bIsCanceled = bIsCanceled;
			this.terminal_ID = terminal_ID;
			this.auditDate = auditDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DebitNote_ID value.
		/// </summary>
		public string DebitNote_ID {
			get { return debitNote_ID; }
			set { debitNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BIsCanceled value.
		/// </summary>
		public bool BIsCanceled {
			get { return bIsCanceled; }
			set { bIsCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AuditDate value.
		/// </summary>
		public DateTime AuditDate {
			get { return auditDate; }
			set { auditDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audTransaction_DebitNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audTransaction_DebitNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audTransaction_DebitNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_DebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteDeleteAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_DebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByDebitNote_ID(string debitNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteDeleteAllByDebitNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_DebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audTransaction_DebitNote table.
		/// </summary>
		public static tbl_audTransaction_DebitNote Select(string debitNote_ID_Incoming, string user_ID_Incoming, bool bIsCanceled_Incoming){

			tbl_audTransaction_DebitNote tbl_audTransaction_DebitNoteins = new tbl_audTransaction_DebitNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audTransaction_DebitNoteins = Maketbl_audTransaction_DebitNote(dataReader);
				} else {
					tbl_audTransaction_DebitNoteins = null;
				}
			}
			scon.Close();
			return tbl_audTransaction_DebitNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_DebitNote table.
		/// </summary>
		public static List<tbl_audTransaction_DebitNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audTransaction_DebitNote> tbl_audTransaction_DebitNoteList = new List<tbl_audTransaction_DebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransaction_DebitNote tbl_audTransaction_DebitNote = Maketbl_audTransaction_DebitNote(dataReader);
					tbl_audTransaction_DebitNoteList.Add(tbl_audTransaction_DebitNote);
				}
			}
			scon.Close();
			return tbl_audTransaction_DebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_DebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_audTransaction_DebitNote> SelectAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteSelectAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
				List<tbl_audTransaction_DebitNote> tbl_audTransaction_DebitNoteList = new List<tbl_audTransaction_DebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransaction_DebitNote tbl_audTransaction_DebitNote = Maketbl_audTransaction_DebitNote(dataReader);
					tbl_audTransaction_DebitNoteList.Add(tbl_audTransaction_DebitNote);
				}
			}
			scon.Close();
			return tbl_audTransaction_DebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_DebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_audTransaction_DebitNote> SelectAllByDebitNote_ID(string debitNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteSelectAllByDebitNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
				List<tbl_audTransaction_DebitNote> tbl_audTransaction_DebitNoteList = new List<tbl_audTransaction_DebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransaction_DebitNote tbl_audTransaction_DebitNote = Maketbl_audTransaction_DebitNote(dataReader);
					tbl_audTransaction_DebitNoteList.Add(tbl_audTransaction_DebitNote);
				}
			}
			scon.Close();
			return tbl_audTransaction_DebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_DebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_audTransaction_DebitNote> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_DebitNoteSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_audTransaction_DebitNote> tbl_audTransaction_DebitNoteList = new List<tbl_audTransaction_DebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransaction_DebitNote tbl_audTransaction_DebitNote = Maketbl_audTransaction_DebitNote(dataReader);
					tbl_audTransaction_DebitNoteList.Add(tbl_audTransaction_DebitNote);
				}
			}
			scon.Close();
			return tbl_audTransaction_DebitNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audTransaction_DebitNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audTransaction_DebitNote Maketbl_audTransaction_DebitNote(SqlDataReader dataReader) {
			tbl_audTransaction_DebitNote tbl_audTransaction_DebitNote = new tbl_audTransaction_DebitNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audTransaction_DebitNote.DebitNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audTransaction_DebitNote.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audTransaction_DebitNote.BIsCanceled = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audTransaction_DebitNote.Terminal_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audTransaction_DebitNote.AuditDate = dataReader.GetDateTime(4);
			}

			return tbl_audTransaction_DebitNote;
		}
		/// <summary>
		/// This makes tbl_audTransaction_DebitNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audTransaction_DebitNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audTransaction_DebitNote  tbl_audTransaction_DebitNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_debitNote_ID = new DataColumn("debitNote_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_bIsCanceled = new DataColumn("bIsCanceled" , typeof(bool));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_auditDate = new DataColumn("auditDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_debitNote_ID,col_user_ID,col_bIsCanceled,col_terminal_ID,col_auditDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audTransaction_DebitNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audTransaction_DebitNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audTransaction_DebitNote user) {
		DataRow drow = dt.NewRow();
		
			drow["debitNote_ID"] = user.debitNote_ID;
			drow["user_ID"] = user.user_ID;
			drow["bIsCanceled"] = user.bIsCanceled;
			drow["terminal_ID"] = user.terminal_ID;
			drow["auditDate"] = user.auditDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
