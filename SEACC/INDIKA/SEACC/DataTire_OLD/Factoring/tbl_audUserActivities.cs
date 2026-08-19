using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audUserActivities {
		#region Fields
		private int form_ID;
		private int activityTypeID;
		private DateTime activityDate;
		private string user_ID;
		private string terminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audUserActivities class.
		/// </summary>
		public tbl_audUserActivities() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audUserActivities class.
		/// </summary>
		public tbl_audUserActivities(int form_ID, int activityTypeID, DateTime activityDate, string user_ID, string terminal_ID) {
			this.form_ID = form_ID;
			this.activityTypeID = activityTypeID;
			this.activityDate = activityDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
		}
		

		
		#endregion
		
		#region Properties

		
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ActivityTypeID value.
		/// </summary>
		public int ActivityTypeID {
			get { return activityTypeID; }
			set { activityTypeID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ActivityDate value.
		/// </summary>
		public DateTime ActivityDate {
			get { return activityDate; }
			set { activityDate = value; }
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
		/// Saves a record to the tbl_audUserActivities table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audUserActivitiesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@activityTypeID", SqlDbType.Int,4);
			scom.Parameters.Add("@activityDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@activityTypeID"].Value = activityTypeID;
			scom.Parameters["@activityDate"].Value = activityDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audUserActivities table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audUserActivitiesUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@activityTypeID", SqlDbType.Int,4);
			scom.Parameters.Add("@activityDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@activityTypeID"].Value = activityTypeID;
			scom.Parameters["@activityDate"].Value = activityDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audUserActivities table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audUserActivitiesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
	//		scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audUserActivities table.
		/// </summary>
		public static tbl_audUserActivities Select(Int64 transaction_ID_Incoming){

			tbl_audUserActivities tbl_audUserActivitiesins = new tbl_audUserActivities();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audUserActivitiesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audUserActivitiesins = Maketbl_audUserActivities(dataReader);
				} else {
					tbl_audUserActivitiesins = null;
				}
			}
			scon.Close();
			return tbl_audUserActivitiesins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audUserActivities table.
		/// </summary>
		public static List<tbl_audUserActivities> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audUserActivitiesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audUserActivities> tbl_audUserActivitiesList = new List<tbl_audUserActivities>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audUserActivities tbl_audUserActivities = Maketbl_audUserActivities(dataReader);
					tbl_audUserActivitiesList.Add(tbl_audUserActivities);
				}
			}
			scon.Close();
			return tbl_audUserActivitiesList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audUserActivities class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audUserActivities Maketbl_audUserActivities(SqlDataReader dataReader) {
			tbl_audUserActivities tbl_audUserActivities = new tbl_audUserActivities();
			
			
			if (dataReader.IsDBNull(1) == false) {
				tbl_audUserActivities.Form_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audUserActivities.ActivityTypeID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audUserActivities.ActivityDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audUserActivities.User_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_audUserActivities.Terminal_ID = dataReader.GetString(4);
			}

			return tbl_audUserActivities;
		}
		/// <summary>
		/// This makes tbl_audUserActivities datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audUserActivities object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audUserActivities  tbl_audUserActivities   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_activityTypeID = new DataColumn("activityTypeID" , typeof(int));
			DataColumn col_activityDate = new DataColumn("activityDate" , typeof(DateTime));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_form_ID,col_activityTypeID,col_activityDate,col_user_ID,col_terminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audUserActivities datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audUserActivities object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audUserActivities user) {
		DataRow drow = dt.NewRow();
		
			drow["form_ID"] = user.form_ID;
			drow["activityTypeID"] = user.activityTypeID;
			drow["activityDate"] = user.activityDate;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
