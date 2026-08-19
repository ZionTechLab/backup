using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_atlProcess_Modify {
		#region Fields
		private Int64 transaction_ID;
		private int form_ID;
		private int processNote_ID;
		private DateTime modifyDate;
		private string user_ID;
		private string terminal_ID;
		private string note_ID;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Modify class.
		/// </summary>
		public tbl_atlProcess_Modify() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Modify class.
		/// </summary>
		public tbl_atlProcess_Modify(int form_ID, int processNote_ID, DateTime modifyDate, string user_ID, string terminal_ID, string note_ID, string remarks) {
			this.form_ID = form_ID;
			this.processNote_ID = processNote_ID;
			this.modifyDate = modifyDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.note_ID = note_ID;
			this.remarks = remarks;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Modify class.
		/// </summary>
		public tbl_atlProcess_Modify(Int64 transaction_ID, int form_ID, int processNote_ID, DateTime modifyDate, string user_ID, string terminal_ID, string note_ID, string remarks) {
			this.transaction_ID = transaction_ID;
			this.form_ID = form_ID;
			this.processNote_ID = processNote_ID;
			this.modifyDate = modifyDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.note_ID = note_ID;
			this.remarks = remarks;
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
		/// Gets or sets the ModifyDate value.
		/// </summary>
		public DateTime ModifyDate {
			get { return modifyDate; }
			set { modifyDate = value; }
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
		
		/// <summary>
		/// Gets or sets the Note_ID value.
		/// </summary>
		public string Note_ID {
			get { return note_ID; }
			set { note_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_atlProcess_Modify table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifyInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@modifyDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@note_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@modifyDate"].Value = modifyDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@note_ID"].Value = note_ID;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_atlProcess_Modify table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifyUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@modifyDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@note_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@modifyDate"].Value = modifyDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@note_ID"].Value = note_ID;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_atlProcess_Modify table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifyDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Modify table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifyDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Modify table by a foreign key.
		/// </summary>
		public static void DeleteAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifyDeleteAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_atlProcess_Modify table.
		/// </summary>
		public static tbl_atlProcess_Modify Select(Int64 transaction_ID_Incoming){

			tbl_atlProcess_Modify tbl_atlProcess_Modifyins = new tbl_atlProcess_Modify();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_atlProcess_Modifyins = Maketbl_atlProcess_Modify(dataReader);
				} else {
					tbl_atlProcess_Modifyins = null;
				}
			}
			scon.Close();
			return tbl_atlProcess_Modifyins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Modify table.
		/// </summary>
		public static List<tbl_atlProcess_Modify> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_atlProcess_Modify> tbl_atlProcess_ModifyList = new List<tbl_atlProcess_Modify>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlProcess_Modify tbl_atlProcess_Modify = Maketbl_atlProcess_Modify(dataReader);
					tbl_atlProcess_ModifyList.Add(tbl_atlProcess_Modify);
				}
			}
			scon.Close();
			return tbl_atlProcess_ModifyList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Modify table by a foreign key.
		/// </summary>
		public static List<tbl_atlProcess_Modify> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifySelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_atlProcess_Modify> tbl_atlProcess_ModifyList = new List<tbl_atlProcess_Modify>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlProcess_Modify tbl_atlProcess_Modify = Maketbl_atlProcess_Modify(dataReader);
					tbl_atlProcess_ModifyList.Add(tbl_atlProcess_Modify);
				}
			}
			scon.Close();
			return tbl_atlProcess_ModifyList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Modify table by a foreign key.
		/// </summary>
		public static List<tbl_atlProcess_Modify> SelectAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_ModifySelectAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
				List<tbl_atlProcess_Modify> tbl_atlProcess_ModifyList = new List<tbl_atlProcess_Modify>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlProcess_Modify tbl_atlProcess_Modify = Maketbl_atlProcess_Modify(dataReader);
					tbl_atlProcess_ModifyList.Add(tbl_atlProcess_Modify);
				}
			}
			scon.Close();
			return tbl_atlProcess_ModifyList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_atlProcess_Modify class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_atlProcess_Modify Maketbl_atlProcess_Modify(SqlDataReader dataReader) {
			tbl_atlProcess_Modify tbl_atlProcess_Modify = new tbl_atlProcess_Modify();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_atlProcess_Modify.Transaction_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_atlProcess_Modify.Form_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_atlProcess_Modify.ProcessNote_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_atlProcess_Modify.ModifyDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_atlProcess_Modify.User_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_atlProcess_Modify.Terminal_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_atlProcess_Modify.Note_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_atlProcess_Modify.Remarks = dataReader.GetString(7);
			}

			return tbl_atlProcess_Modify;
		}
		/// <summary>
		/// This makes tbl_atlProcess_Modify datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_atlProcess_Modify object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_atlProcess_Modify  tbl_atlProcess_Modify   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(long));
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_processNote_ID = new DataColumn("processNote_ID" , typeof(int));
			DataColumn col_modifyDate = new DataColumn("modifyDate" , typeof(DateTime));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_note_ID = new DataColumn("note_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_transaction_ID,col_form_ID,col_processNote_ID,col_modifyDate,col_user_ID,col_terminal_ID,col_note_ID,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_atlProcess_Modify datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_atlProcess_Modify object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_atlProcess_Modify user) {
		DataRow drow = dt.NewRow();
		
			drow["transaction_ID"] = user.transaction_ID;
			drow["form_ID"] = user.form_ID;
			drow["processNote_ID"] = user.processNote_ID;
			drow["modifyDate"] = user.modifyDate;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["note_ID"] = user.note_ID;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
