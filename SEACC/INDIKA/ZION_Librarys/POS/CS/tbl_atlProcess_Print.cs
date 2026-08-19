using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_atlProcess_Print {
		#region Fields
		private Int64 transaction_ID;
		private int form_ID;
		private int processNote_ID;
		private string note_ID;
		private string activity_Type;
		private DateTime printDate;
		private string user_ID;
		private string terminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Print class.
		/// </summary>
		public tbl_atlProcess_Print() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Print class.
		/// </summary>
		public tbl_atlProcess_Print(int form_ID, int processNote_ID, string note_ID, string activity_Type, DateTime printDate, string user_ID, string terminal_ID) {
			this.form_ID = form_ID;
			this.processNote_ID = processNote_ID;
			this.note_ID = note_ID;
			this.activity_Type = activity_Type;
			this.printDate = printDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Print class.
		/// </summary>
		public tbl_atlProcess_Print(Int64 transaction_ID, int form_ID, int processNote_ID, string note_ID, string activity_Type, DateTime printDate, string user_ID, string terminal_ID) {
			this.transaction_ID = transaction_ID;
			this.form_ID = form_ID;
			this.processNote_ID = processNote_ID;
			this.note_ID = note_ID;
			this.activity_Type = activity_Type;
			this.printDate = printDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public Int64 Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessNote_ID value.
		/// </summary>
		public int ProcessNote_ID {
			get { return processNote_ID; }
			set { processNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Note_ID value.
		/// </summary>
		public string Note_ID {
			get { return note_ID; }
			set { note_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Activity_Type value.
		/// </summary>
		public string Activity_Type {
			get { return activity_Type; }
			set { activity_Type = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintDate value.
		/// </summary>
		public DateTime PrintDate {
			get { return printDate; }
			set { printDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_atlProcess_Print table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@note_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Activity_Type", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@note_ID"].Value = note_ID;
			scom.Parameters["@Activity_Type"].Value = activity_Type;
			scom.Parameters["@printDate"].Value = printDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_atlProcess_Print table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@note_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Activity_Type", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@note_ID"].Value = note_ID;
			scom.Parameters["@Activity_Type"].Value = activity_Type;
			scom.Parameters["@printDate"].Value = printDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_atlProcess_Print table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@transaction_ID", SqlDbType.Int, 8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Print table by a foreign key.
		/// </summary>
		public static void DeleteAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintDeleteAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Print table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_atlProcess_Print table.
		/// </summary>
		public static tbl_atlProcess_Print Select(Int64 transaction_ID_Incoming){

			tbl_atlProcess_Print tbl_atlProcess_Printins = new tbl_atlProcess_Print();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@transaction_ID", SqlDbType.Int, 8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_atlProcess_Printins = Maketbl_atlProcess_Print(dataReader);
				} else {
					tbl_atlProcess_Printins = null;
				}
			}
			scon.Close();
			return tbl_atlProcess_Printins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Print table.
		/// </summary>
		public static List<tbl_atlProcess_Print> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_atlProcess_Print> tbl_atlProcess_PrintList = new List<tbl_atlProcess_Print>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlProcess_Print tbl_atlProcess_Print = Maketbl_atlProcess_Print(dataReader);
					tbl_atlProcess_PrintList.Add(tbl_atlProcess_Print);
				}
			}
			scon.Close();
			return tbl_atlProcess_PrintList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Print table by a foreign key.
		/// </summary>
		public static List<tbl_atlProcess_Print> SelectAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintSelectAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
				List<tbl_atlProcess_Print> tbl_atlProcess_PrintList = new List<tbl_atlProcess_Print>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlProcess_Print tbl_atlProcess_Print = Maketbl_atlProcess_Print(dataReader);
					tbl_atlProcess_PrintList.Add(tbl_atlProcess_Print);
				}
			}
			scon.Close();
			return tbl_atlProcess_PrintList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Print table by a foreign key.
		/// </summary>
		public static List<tbl_atlProcess_Print> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_PrintSelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_atlProcess_Print> tbl_atlProcess_PrintList = new List<tbl_atlProcess_Print>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlProcess_Print tbl_atlProcess_Print = Maketbl_atlProcess_Print(dataReader);
					tbl_atlProcess_PrintList.Add(tbl_atlProcess_Print);
				}
			}
			scon.Close();
			return tbl_atlProcess_PrintList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_atlProcess_Print class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_atlProcess_Print Maketbl_atlProcess_Print(SqlDataReader dataReader) {
			tbl_atlProcess_Print tbl_atlProcess_Print = new tbl_atlProcess_Print();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_atlProcess_Print.Transaction_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_atlProcess_Print.Form_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_atlProcess_Print.ProcessNote_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_atlProcess_Print.Note_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_atlProcess_Print.Activity_Type = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_atlProcess_Print.PrintDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_atlProcess_Print.User_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_atlProcess_Print.Terminal_ID = dataReader.GetString(7);
			}

			return tbl_atlProcess_Print;
		}
		/// <summary>
		/// This makes tbl_atlProcess_Print datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_atlProcess_Print object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_atlProcess_Print  tbl_atlProcess_Print   )
		{
		DataTable dt = new DataTable();

        DataColumn col_transaction_ID = new DataColumn("transaction_ID", typeof(int));
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_processNote_ID = new DataColumn("processNote_ID" , typeof(int));
			DataColumn col_note_ID = new DataColumn("note_ID" , typeof(string));
			DataColumn col_Activity_Type = new DataColumn("Activity_Type" , typeof(string));
			DataColumn col_printDate = new DataColumn("printDate" , typeof(DateTime));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_transaction_ID,col_form_ID,col_processNote_ID,col_note_ID,col_Activity_Type,col_printDate,col_user_ID,col_terminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_atlProcess_Print datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_atlProcess_Print object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_atlProcess_Print user) {
		DataRow drow = dt.NewRow();
		
			drow["transaction_ID"] = user.transaction_ID;
			drow["form_ID"] = user.form_ID;
			drow["processNote_ID"] = user.processNote_ID;
			drow["note_ID"] = user.note_ID;
			drow["Activity_Type"] = user.Activity_Type;
			drow["printDate"] = user.printDate;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
