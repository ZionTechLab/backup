using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audTransactioin_CreditNote {
		#region Fields
		private string creditNote_ID;
		private string user_ID;
		private bool bIsCanceled;
		private string terminal_ID;
		private DateTime auditDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audTransactioin_CreditNote class.
		/// </summary>
		public tbl_audTransactioin_CreditNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audTransactioin_CreditNote class.
		/// </summary>
		public tbl_audTransactioin_CreditNote(string creditNote_ID, string user_ID, bool bIsCanceled, string terminal_ID, DateTime auditDate) {
			this.creditNote_ID = creditNote_ID;
			this.user_ID = user_ID;
			this.bIsCanceled = bIsCanceled;
			this.terminal_ID = terminal_ID;
			this.auditDate = auditDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CreditNote_ID value.
		/// </summary>
		public string CreditNote_ID {
			get { return creditNote_ID; }
			set { creditNote_ID = value; }
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
		/// Saves a record to the tbl_audTransactioin_CreditNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audTransactioin_CreditNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audTransactioin_CreditNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_CreditNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_CreditNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteDeleteAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_CreditNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreditNote_ID(string creditNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteDeleteAllByCreditNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audTransactioin_CreditNote table.
		/// </summary>
		public static tbl_audTransactioin_CreditNote Select(string creditNote_ID_Incoming, string user_ID_Incoming, bool bIsCanceled_Incoming){

			tbl_audTransactioin_CreditNote tbl_audTransactioin_CreditNoteins = new tbl_audTransactioin_CreditNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audTransactioin_CreditNoteins = Maketbl_audTransactioin_CreditNote(dataReader);
				} else {
					tbl_audTransactioin_CreditNoteins = null;
				}
			}
			scon.Close();
			return tbl_audTransactioin_CreditNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_CreditNote table.
		/// </summary>
		public static List<tbl_audTransactioin_CreditNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audTransactioin_CreditNote> tbl_audTransactioin_CreditNoteList = new List<tbl_audTransactioin_CreditNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_CreditNote tbl_audTransactioin_CreditNote = Maketbl_audTransactioin_CreditNote(dataReader);
					tbl_audTransactioin_CreditNoteList.Add(tbl_audTransactioin_CreditNote);
				}
			}
			scon.Close();
			return tbl_audTransactioin_CreditNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_CreditNote table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_CreditNote> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_audTransactioin_CreditNote> tbl_audTransactioin_CreditNoteList = new List<tbl_audTransactioin_CreditNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_CreditNote tbl_audTransactioin_CreditNote = Maketbl_audTransactioin_CreditNote(dataReader);
					tbl_audTransactioin_CreditNoteList.Add(tbl_audTransactioin_CreditNote);
				}
			}
			scon.Close();
			return tbl_audTransactioin_CreditNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_CreditNote table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_CreditNote> SelectAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteSelectAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
				List<tbl_audTransactioin_CreditNote> tbl_audTransactioin_CreditNoteList = new List<tbl_audTransactioin_CreditNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_CreditNote tbl_audTransactioin_CreditNote = Maketbl_audTransactioin_CreditNote(dataReader);
					tbl_audTransactioin_CreditNoteList.Add(tbl_audTransactioin_CreditNote);
				}
			}
			scon.Close();
			return tbl_audTransactioin_CreditNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_CreditNote table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_CreditNote> SelectAllByCreditNote_ID(string creditNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_CreditNoteSelectAllByCreditNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
				List<tbl_audTransactioin_CreditNote> tbl_audTransactioin_CreditNoteList = new List<tbl_audTransactioin_CreditNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_CreditNote tbl_audTransactioin_CreditNote = Maketbl_audTransactioin_CreditNote(dataReader);
					tbl_audTransactioin_CreditNoteList.Add(tbl_audTransactioin_CreditNote);
				}
			}
			scon.Close();
			return tbl_audTransactioin_CreditNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audTransactioin_CreditNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audTransactioin_CreditNote Maketbl_audTransactioin_CreditNote(SqlDataReader dataReader) {
			tbl_audTransactioin_CreditNote tbl_audTransactioin_CreditNote = new tbl_audTransactioin_CreditNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audTransactioin_CreditNote.CreditNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audTransactioin_CreditNote.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audTransactioin_CreditNote.BIsCanceled = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audTransactioin_CreditNote.Terminal_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audTransactioin_CreditNote.AuditDate = dataReader.GetDateTime(4);
			}

			return tbl_audTransactioin_CreditNote;
		}
		/// <summary>
		/// This makes tbl_audTransactioin_CreditNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audTransactioin_CreditNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audTransactioin_CreditNote  tbl_audTransactioin_CreditNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_creditNote_ID = new DataColumn("creditNote_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_bIsCanceled = new DataColumn("bIsCanceled" , typeof(bool));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_auditDate = new DataColumn("auditDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_creditNote_ID,col_user_ID,col_bIsCanceled,col_terminal_ID,col_auditDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audTransactioin_CreditNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audTransactioin_CreditNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audTransactioin_CreditNote user) {
		DataRow drow = dt.NewRow();
		
			drow["creditNote_ID"] = user.creditNote_ID;
			drow["user_ID"] = user.user_ID;
			drow["bIsCanceled"] = user.bIsCanceled;
			drow["terminal_ID"] = user.terminal_ID;
			drow["auditDate"] = user.auditDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
