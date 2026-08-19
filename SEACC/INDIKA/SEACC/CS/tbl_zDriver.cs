using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zDriver {
		#region Fields
		private string driver_ID;
		private string driverName;
		private string nicNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zDriver class.
		/// </summary>
		public tbl_zDriver() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zDriver class.
		/// </summary>
		public tbl_zDriver(string driver_ID, string driverName, string nicNo) {
			this.driver_ID = driver_ID;
			this.driverName = driverName;
			this.nicNo = nicNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Driver_ID value.
		/// </summary>
		public string Driver_ID {
			get { return driver_ID; }
			set { driver_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DriverName value.
		/// </summary>
		public string DriverName {
			get { return driverName; }
			set { driverName = value; }
		}
		
		/// <summary>
		/// Gets or sets the NicNo value.
		/// </summary>
		public string NicNo {
			get { return nicNo; }
			set { nicNo = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zDriver table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDriverInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@driverName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,50);
 
			scom.Parameters["@driver_ID"].Value = driver_ID;
			scom.Parameters["@driverName"].Value = driverName;
			scom.Parameters["@nicNo"].Value = nicNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zDriver table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDriverUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@driverName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@driver_ID"].Value = driver_ID;
			scom.Parameters["@driverName"].Value = driverName;
			scom.Parameters["@nicNo"].Value = nicNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zDriver table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDriverDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters["@driver_ID"].Value = driver_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zDriver table.
		/// </summary>
		public static tbl_zDriver Select(string driver_ID_Incoming){

			tbl_zDriver tbl_zDriverins = new tbl_zDriver();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDriverSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters["@driver_ID"].Value = driver_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zDriverins = Maketbl_zDriver(dataReader);
				} else {
					tbl_zDriverins = null;
				}
			}
			scon.Close();
			return tbl_zDriverins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDriver table.
		/// </summary>
		public static List<tbl_zDriver> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDriverSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zDriver> tbl_zDriverList = new List<tbl_zDriver>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zDriver tbl_zDriver = Maketbl_zDriver(dataReader);
					tbl_zDriverList.Add(tbl_zDriver);
				}
			}
			scon.Close();
			return tbl_zDriverList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zDriver class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zDriver Maketbl_zDriver(SqlDataReader dataReader) {
			tbl_zDriver tbl_zDriver = new tbl_zDriver();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zDriver.Driver_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zDriver.DriverName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zDriver.NicNo = dataReader.GetString(2);
			}

			return tbl_zDriver;
		}
		/// <summary>
		/// This makes tbl_zDriver datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zDriver object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zDriver  tbl_zDriver   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_driver_ID = new DataColumn("driver_ID" , typeof(string));
			DataColumn col_driverName = new DataColumn("driverName" , typeof(string));
			DataColumn col_nicNo = new DataColumn("nicNo" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_driver_ID,col_driverName,col_nicNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zDriver datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zDriver object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zDriver user) {
		DataRow drow = dt.NewRow();
		
			drow["driver_ID"] = user.driver_ID;
			drow["driverName"] = user.driverName;
			drow["nicNo"] = user.nicNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
