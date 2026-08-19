using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert {
		#region Fields
		private string alert_ID;
		private string alertName;
		private string formCategory_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert class.
		/// </summary>
		public tbl_utlAlert() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert class.
		/// </summary>
		public tbl_utlAlert(string alert_ID, string alertName, string formCategory_ID, bool isActive) {
			this.alert_ID = alert_ID;
			this.alertName = alertName;
			this.formCategory_ID = formCategory_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Alert_ID value.
		/// </summary>
		public string Alert_ID {
			get { return alert_ID; }
			set { alert_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AlertName value.
		/// </summary>
		public string AlertName {
			get { return alertName; }
			set { alertName = value; }
		}
		
		/// <summary>
		/// Gets or sets the FormCategory_ID value.
		/// </summary>
		public string FormCategory_ID {
			get { return formCategory_ID; }
			set { formCategory_ID = value; }
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
		/// Saves a record to the tbl_utlAlert table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alertName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@alertName"].Value = alertName;
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alertName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@alertName"].Value = alertName;
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert table.
		/// </summary>
		public static tbl_utlAlert Select(string alert_ID_Incoming){

			tbl_utlAlert tbl_utlAlertins = new tbl_utlAlert();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlertins = Maketbl_utlAlert(dataReader);
				} else {
					tbl_utlAlertins = null;
				}
			}
			scon.Close();
			return tbl_utlAlertins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert table.
		/// </summary>
		public static List<tbl_utlAlert> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert> tbl_utlAlertList = new List<tbl_utlAlert>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert tbl_utlAlert = Maketbl_utlAlert(dataReader);
					tbl_utlAlertList.Add(tbl_utlAlert);
				}
			}
			scon.Close();
			return tbl_utlAlertList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert Maketbl_utlAlert(SqlDataReader dataReader) {
			tbl_utlAlert tbl_utlAlert = new tbl_utlAlert();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert.Alert_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert.AlertName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert.FormCategory_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlert.IsActive = dataReader.GetBoolean(3);
			}

			return tbl_utlAlert;
		}
		/// <summary>
		/// This makes tbl_utlAlert datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert  tbl_utlAlert   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(string));
			DataColumn col_alertName = new DataColumn("alertName" , typeof(string));
			DataColumn col_formCategory_ID = new DataColumn("formCategory_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_alert_ID,col_alertName,col_formCategory_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert user) {
		DataRow drow = dt.NewRow();
		
			drow["alert_ID"] = user.alert_ID;
			drow["alertName"] = user.alertName;
			drow["formCategory_ID"] = user.formCategory_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
