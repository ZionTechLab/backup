using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_detail {
		#region Fields
		private int setting_ID;
		private int alert_ID;
		private string personName;
		private string userEmail1;
		private int receiverType;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_detail class.
		/// </summary>
		public tbl_utlAlert_detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_detail class.
		/// </summary>
		public tbl_utlAlert_detail(int setting_ID, int alert_ID, string personName, string userEmail1, int receiverType) {
			this.setting_ID = setting_ID;
			this.alert_ID = alert_ID;
			this.personName = personName;
			this.userEmail1 = userEmail1;
			this.receiverType = receiverType;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Setting_ID value.
		/// </summary>
		public int Setting_ID {
			get { return setting_ID; }
			set { setting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Alert_ID value.
		/// </summary>
		public int Alert_ID {
			get { return alert_ID; }
			set { alert_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PersonName value.
		/// </summary>
		public string PersonName {
			get { return personName; }
			set { personName = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserEmail1 value.
		/// </summary>
		public string UserEmail1 {
			get { return userEmail1; }
			set { userEmail1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiverType value.
		/// </summary>
		public int ReceiverType {
			get { return receiverType; }
			set { receiverType = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlert_detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_detailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@setting_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@personName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@userEmail1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@receiverType", SqlDbType.Int,4);
 
			scom.Parameters["@setting_ID"].Value = setting_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@personName"].Value = personName;
			scom.Parameters["@userEmail1"].Value = userEmail1;
			scom.Parameters["@receiverType"].Value = receiverType;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_detailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@setting_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@personName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@userEmail1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@receiverType", SqlDbType.Int,4);
 
 
			scom.Parameters["@setting_ID"].Value = setting_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@personName"].Value = personName;
			scom.Parameters["@userEmail1"].Value = userEmail1;
			scom.Parameters["@receiverType"].Value = receiverType;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_detailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@setting_ID", SqlDbType.Int,4);
			scom.Parameters["@setting_ID"].Value = setting_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlert_ID(int alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_detailDeleteAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_detail table.
		/// </summary>
		public static tbl_utlAlert_detail Select(int setting_ID_Incoming){

			tbl_utlAlert_detail tbl_utlAlert_detailins = new tbl_utlAlert_detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_detailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@setting_ID", SqlDbType.Int,4);
			scom.Parameters["@setting_ID"].Value = setting_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_detailins = Maketbl_utlAlert_detail(dataReader);
				} else {
					tbl_utlAlert_detailins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_detail table.
		/// </summary>
		public static List<tbl_utlAlert_detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_detailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_detail> tbl_utlAlert_detailList = new List<tbl_utlAlert_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_detail tbl_utlAlert_detail = Maketbl_utlAlert_detail(dataReader);
					tbl_utlAlert_detailList.Add(tbl_utlAlert_detail);
				}
			}
			scon.Close();
			return tbl_utlAlert_detailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_detail table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_detail> SelectAllByAlert_ID(int alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_detailSelectAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID;
				List<tbl_utlAlert_detail> tbl_utlAlert_detailList = new List<tbl_utlAlert_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_detail tbl_utlAlert_detail = Maketbl_utlAlert_detail(dataReader);
					tbl_utlAlert_detailList.Add(tbl_utlAlert_detail);
				}
			}
			scon.Close();
			return tbl_utlAlert_detailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_detail Maketbl_utlAlert_detail(SqlDataReader dataReader) {
			tbl_utlAlert_detail tbl_utlAlert_detail = new tbl_utlAlert_detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_detail.Setting_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_detail.Alert_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_detail.PersonName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlert_detail.UserEmail1 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlert_detail.ReceiverType = dataReader.GetInt32(4);
			}

			return tbl_utlAlert_detail;
		}
		/// <summary>
		/// This makes tbl_utlAlert_detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_detail  tbl_utlAlert_detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_setting_ID = new DataColumn("setting_ID" , typeof(int));
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(int));
			DataColumn col_personName = new DataColumn("personName" , typeof(string));
			DataColumn col_userEmail1 = new DataColumn("userEmail1" , typeof(string));
			DataColumn col_receiverType = new DataColumn("receiverType" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_setting_ID,col_alert_ID,col_personName,col_userEmail1,col_receiverType,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_detail user) {
		DataRow drow = dt.NewRow();
		
			drow["setting_ID"] = user.setting_ID;
			drow["alert_ID"] = user.alert_ID;
			drow["personName"] = user.personName;
			drow["userEmail1"] = user.userEmail1;
			drow["receiverType"] = user.receiverType;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
