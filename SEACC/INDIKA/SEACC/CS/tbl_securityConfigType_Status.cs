using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityConfigType_Status {
		#region Fields
		private string configTypeStatus_ID;
		private string configTypeStatus;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigType_Status class.
		/// </summary>
		public tbl_securityConfigType_Status() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigType_Status class.
		/// </summary>
		public tbl_securityConfigType_Status(string configTypeStatus_ID, string configTypeStatus, string remark) {
			this.configTypeStatus_ID = configTypeStatus_ID;
			this.configTypeStatus = configTypeStatus;
			this.remark = remark;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ConfigTypeStatus_ID value.
		/// </summary>
		public string ConfigTypeStatus_ID {
			get { return configTypeStatus_ID; }
			set { configTypeStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ConfigTypeStatus value.
		/// </summary>
		public string ConfigTypeStatus {
			get { return configTypeStatus; }
			set { configTypeStatus = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityConfigType_Status table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_StatusInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@configTypeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@configTypeStatus", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
 
			scom.Parameters["@configTypeStatus_ID"].Value = configTypeStatus_ID;
			scom.Parameters["@configTypeStatus"].Value = configTypeStatus;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityConfigType_Status table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_StatusUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@configTypeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@configTypeStatus", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@configTypeStatus_ID"].Value = configTypeStatus_ID;
			scom.Parameters["@configTypeStatus"].Value = configTypeStatus;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityConfigType_Status table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_StatusDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@configTypeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@configTypeStatus_ID"].Value = configTypeStatus_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityConfigType_Status table.
		/// </summary>
		public static tbl_securityConfigType_Status Select(string configTypeStatus_ID_Incoming){

			tbl_securityConfigType_Status tbl_securityConfigType_Statusins = new tbl_securityConfigType_Status();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_StatusSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@configTypeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@configTypeStatus_ID"].Value = configTypeStatus_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityConfigType_Statusins = Maketbl_securityConfigType_Status(dataReader);
				} else {
					tbl_securityConfigType_Statusins = null;
				}
			}
			scon.Close();
			return tbl_securityConfigType_Statusins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityConfigType_Status table.
		/// </summary>
		public static List<tbl_securityConfigType_Status> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_StatusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityConfigType_Status> tbl_securityConfigType_StatusList = new List<tbl_securityConfigType_Status>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityConfigType_Status tbl_securityConfigType_Status = Maketbl_securityConfigType_Status(dataReader);
					tbl_securityConfigType_StatusList.Add(tbl_securityConfigType_Status);
				}
			}
			scon.Close();
			return tbl_securityConfigType_StatusList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityConfigType_Status class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityConfigType_Status Maketbl_securityConfigType_Status(SqlDataReader dataReader) {
			tbl_securityConfigType_Status tbl_securityConfigType_Status = new tbl_securityConfigType_Status();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityConfigType_Status.ConfigTypeStatus_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityConfigType_Status.ConfigTypeStatus = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityConfigType_Status.Remark = dataReader.GetString(2);
			}

			return tbl_securityConfigType_Status;
		}
		/// <summary>
		/// This makes tbl_securityConfigType_Status datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityConfigType_Status object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityConfigType_Status  tbl_securityConfigType_Status   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_configTypeStatus_ID = new DataColumn("configTypeStatus_ID" , typeof(string));
			DataColumn col_configTypeStatus = new DataColumn("configTypeStatus" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_configTypeStatus_ID,col_configTypeStatus,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityConfigType_Status datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityConfigType_Status object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityConfigType_Status user) {
		DataRow drow = dt.NewRow();
		
			drow["configTypeStatus_ID"] = user.configTypeStatus_ID;
			drow["configTypeStatus"] = user.configTypeStatus;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
