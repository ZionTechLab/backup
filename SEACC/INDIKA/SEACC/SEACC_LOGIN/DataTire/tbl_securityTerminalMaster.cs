using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SEACC_LOGIN.DataTire
{
	public sealed class tbl_securityTerminalMaster {
		#region Fields
		private string terminal_ID;
		private string terminal_Name;
		private string ipAddress;
		private string macAddress;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityTerminalMaster class.
		/// </summary>
		public tbl_securityTerminalMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityTerminalMaster class.
		/// </summary>
		public tbl_securityTerminalMaster(string terminal_ID, string terminal_Name, string ipAddress, string macAddress) {
			this.terminal_ID = terminal_ID;
			this.terminal_Name = terminal_Name;
			this.ipAddress = ipAddress;
			this.macAddress = macAddress;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_Name value.
		/// </summary>
		public string Terminal_Name {
			get { return terminal_Name; }
			set { terminal_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the IpAddress value.
		/// </summary>
		public string IpAddress {
			get { return ipAddress; }
			set { ipAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the MacAddress value.
		/// </summary>
		public string MacAddress {
			get { return macAddress; }
			set { macAddress = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityTerminalMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityTerminalMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@terminal_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ipAddress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@macAddress", SqlDbType.VarChar,50);
 
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@terminal_Name"].Value = terminal_Name;
			scom.Parameters["@ipAddress"].Value = ipAddress;
			scom.Parameters["@macAddress"].Value = macAddress;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityTerminalMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityTerminalMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@terminal_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ipAddress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@macAddress", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@terminal_Name"].Value = terminal_Name;
			scom.Parameters["@ipAddress"].Value = ipAddress;
			scom.Parameters["@macAddress"].Value = macAddress;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityTerminalMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityTerminalMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityTerminalMaster table.
		/// </summary>
		public static tbl_securityTerminalMaster Select(string terminal_ID_Incoming){

			tbl_securityTerminalMaster tbl_securityTerminalMasterins = new tbl_securityTerminalMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityTerminalMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityTerminalMasterins = Maketbl_securityTerminalMaster(dataReader);
				} else {
					tbl_securityTerminalMasterins = null;
				}
			}
			scon.Close();
			return tbl_securityTerminalMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityTerminalMaster table.
		/// </summary>
		public static List<tbl_securityTerminalMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityTerminalMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityTerminalMaster> tbl_securityTerminalMasterList = new List<tbl_securityTerminalMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityTerminalMaster tbl_securityTerminalMaster = Maketbl_securityTerminalMaster(dataReader);
					tbl_securityTerminalMasterList.Add(tbl_securityTerminalMaster);
				}
			}
			scon.Close();
			return tbl_securityTerminalMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityTerminalMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityTerminalMaster Maketbl_securityTerminalMaster(SqlDataReader dataReader) {
			tbl_securityTerminalMaster tbl_securityTerminalMaster = new tbl_securityTerminalMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityTerminalMaster.Terminal_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityTerminalMaster.Terminal_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityTerminalMaster.IpAddress = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityTerminalMaster.MacAddress = dataReader.GetString(3);
			}

			return tbl_securityTerminalMaster;
		}
		/// <summary>
		/// This makes tbl_securityTerminalMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityTerminalMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityTerminalMaster  tbl_securityTerminalMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_terminal_Name = new DataColumn("terminal_Name" , typeof(string));
			DataColumn col_ipAddress = new DataColumn("ipAddress" , typeof(string));
			DataColumn col_macAddress = new DataColumn("macAddress" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_terminal_ID,col_terminal_Name,col_ipAddress,col_macAddress,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityTerminalMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityTerminalMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityTerminalMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["terminal_ID"] = user.terminal_ID;
			drow["terminal_Name"] = user.terminal_Name;
			drow["ipAddress"] = user.ipAddress;
			drow["macAddress"] = user.macAddress;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
