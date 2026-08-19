using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_atlActions {
		#region Fields
		private string auditAction_ID;
		private DateTime actionDate;
		private int form_ID;
		private string user_ID;
		private string terminal_ID;
		private string remarks1;
		private string descrription;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_atlActions class.
		/// </summary>
		public tbl_atlActions() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlActions class.
		/// </summary>
		public tbl_atlActions(string auditAction_ID, DateTime actionDate, int form_ID, string user_ID, string terminal_ID, string remarks1, string descrription) {
			this.auditAction_ID = auditAction_ID;
			this.actionDate = actionDate;
			this.form_ID = form_ID;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.remarks1 = remarks1;
			this.descrription = descrription;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AuditAction_ID value.
		/// </summary>
		public string AuditAction_ID {
			get { return auditAction_ID; }
			set { auditAction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ActionDate value.
		/// </summary>
		public DateTime ActionDate {
			get { return actionDate; }
			set { actionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
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
		/// Gets or sets the Remarks1 value.
		/// </summary>
		public string Remarks1 {
			get { return remarks1; }
			set { remarks1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Descrription value.
		/// </summary>
		public string Descrription {
			get { return descrription; }
			set { descrription = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_atlActions table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlActionsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@auditAction_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@actionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@Remarks1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@Descrription", SqlDbType.VarChar,100);
 
			scom.Parameters["@auditAction_ID"].Value = auditAction_ID;
			scom.Parameters["@actionDate"].Value = actionDate;
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@Remarks1"].Value = remarks1;
			scom.Parameters["@Descrription"].Value = descrription;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_atlActions table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlActionsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@auditAction_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@actionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@Remarks1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@Descrription", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@auditAction_ID"].Value = auditAction_ID;
			scom.Parameters["@actionDate"].Value = actionDate;
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@Remarks1"].Value = remarks1;
			scom.Parameters["@Descrription"].Value = descrription;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_atlActions table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlActionsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@auditAction_ID", SqlDbType.VarChar,10);
			scom.Parameters["@auditAction_ID"].Value = auditAction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlActions table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlActionsDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_atlActions table.
		/// </summary>
		public static tbl_atlActions Select(string auditAction_ID_Incoming){

			tbl_atlActions tbl_atlActionsins = new tbl_atlActions();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlActionsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@auditAction_ID", SqlDbType.VarChar,10);
			scom.Parameters["@auditAction_ID"].Value = auditAction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_atlActionsins = Maketbl_atlActions(dataReader);
				} else {
					tbl_atlActionsins = null;
				}
			}
			scon.Close();
			return tbl_atlActionsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlActions table.
		/// </summary>
		public static List<tbl_atlActions> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlActionsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_atlActions> tbl_atlActionsList = new List<tbl_atlActions>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlActions tbl_atlActions = Maketbl_atlActions(dataReader);
					tbl_atlActionsList.Add(tbl_atlActions);
				}
			}
			scon.Close();
			return tbl_atlActionsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlActions table by a foreign key.
		/// </summary>
		public static List<tbl_atlActions> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlActionsSelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_atlActions> tbl_atlActionsList = new List<tbl_atlActions>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlActions tbl_atlActions = Maketbl_atlActions(dataReader);
					tbl_atlActionsList.Add(tbl_atlActions);
				}
			}
			scon.Close();
			return tbl_atlActionsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_atlActions class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_atlActions Maketbl_atlActions(SqlDataReader dataReader) {
			tbl_atlActions tbl_atlActions = new tbl_atlActions();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_atlActions.AuditAction_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_atlActions.ActionDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_atlActions.Form_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_atlActions.User_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_atlActions.Terminal_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_atlActions.Remarks1 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_atlActions.Descrription = dataReader.GetString(6);
			}

			return tbl_atlActions;
		}
		/// <summary>
		/// This makes tbl_atlActions datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_atlActions object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_atlActions  tbl_atlActions   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_auditAction_ID = new DataColumn("auditAction_ID" , typeof(string));
			DataColumn col_actionDate = new DataColumn("actionDate" , typeof(DateTime));
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_Remarks1 = new DataColumn("Remarks1" , typeof(string));
			DataColumn col_Descrription = new DataColumn("Descrription" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_auditAction_ID,col_actionDate,col_form_ID,col_user_ID,col_terminal_ID,col_Remarks1,col_Descrription,});		return dt;
		}
		/// <summary>
		/// This fills tbl_atlActions datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_atlActions object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_atlActions user) {
		DataRow drow = dt.NewRow();
		
			drow["auditAction_ID"] = user.auditAction_ID;
			drow["actionDate"] = user.actionDate;
			drow["form_ID"] = user.form_ID;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["Remarks1"] = user.Remarks1;
			drow["Descrription"] = user.Descrription;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
