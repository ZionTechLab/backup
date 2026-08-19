using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_tasDevice_RawData {
		#region Fields
		private int iD;
		private string device_ID;
		private DateTime device_DateTime;
		private string device_empID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasDevice_RawData class.
		/// </summary>
		public tbl_tasDevice_RawData() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasDevice_RawData class.
		/// </summary>
		public tbl_tasDevice_RawData(string device_ID, DateTime device_DateTime, string device_empID) {
			this.device_ID = device_ID;
			this.device_DateTime = device_DateTime;
			this.device_empID = device_empID;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasDevice_RawData class.
		/// </summary>
		public tbl_tasDevice_RawData(int iD, string device_ID, DateTime device_DateTime, string device_empID) {
			this.iD = iD;
			this.device_ID = device_ID;
			this.device_DateTime = device_DateTime;
			this.device_empID = device_empID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ID value.
		/// </summary>
		public int ID {
			get { return iD; }
			set { iD = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_ID value.
		/// </summary>
		public string Device_ID {
			get { return device_ID; }
			set { device_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_DateTime value.
		/// </summary>
		public DateTime Device_DateTime {
			get { return device_DateTime; }
			set { device_DateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_empID value.
		/// </summary>
		public string Device_empID {
			get { return device_empID; }
			set { device_empID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasDevice_RawData table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasDevice_RawDataInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@device_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@device_empID", SqlDbType.VarChar,10);
 
			scom.Parameters["@device_ID"].Value = device_ID;
			scom.Parameters["@device_DateTime"].Value = device_DateTime;
			scom.Parameters["@device_empID"].Value = device_empID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}


        public void Insert_Advance()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasDevice_RawDataInsert_Advance", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@device_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@device_DateTime", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@device_empID", SqlDbType.VarChar, 10);

            scom.Parameters["@device_ID"].Value = device_ID;
            scom.Parameters["@device_DateTime"].Value = device_DateTime;
            scom.Parameters["@device_empID"].Value = device_empID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
		/// <summary>
		/// Updates a record in the tbl_tasDevice_RawData table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasDevice_RawDataUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@device_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@device_empID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@device_ID"].Value = device_ID;
			scom.Parameters["@device_DateTime"].Value = device_DateTime;
			scom.Parameters["@device_empID"].Value = device_empID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasDevice_RawData table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasDevice_RawDataDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@ID", SqlDbType.Int,4);
			scom.Parameters["@ID"].Value = iD;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasDevice_RawData table.
		/// </summary>
		public static tbl_tasDevice_RawData Select(string iD_Incoming){

			tbl_tasDevice_RawData tbl_tasDevice_RawDatains = new tbl_tasDevice_RawData();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasDevice_RawDataSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@DeviceID", SqlDbType.VarChar, 20);
            scom.Parameters["@DeviceID"].Value = iD_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasDevice_RawDatains = Maketbl_tasDevice_RawData(dataReader);
				} else {
					tbl_tasDevice_RawDatains = null;
				}
			}
			scon.Close();
			return tbl_tasDevice_RawDatains;
		}

        public static tbl_tasDevice_RawData Select_By_EmpID_and_Date(string EMPID,DateTime Date)
        {

            tbl_tasDevice_RawData tbl_tasDevice_RawDatains = new tbl_tasDevice_RawData();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasDevice_RawDataSelect_EMPDI_and_Date", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@DeviceEMPID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@DeviceDatetime", SqlDbType.DateTime, 20);
            scom.Parameters["@DeviceEMPID"].Value = EMPID;
            scom.Parameters["@DeviceDatetime"].Value = Date;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_tasDevice_RawDatains = Maketbl_tasDevice_RawData(dataReader);
                }
                else
                {
                    tbl_tasDevice_RawDatains = null;
                }
            }
            scon.Close();
            return tbl_tasDevice_RawDatains;
        }
		/// <summary>
		/// Selects all records from the tbl_tasDevice_RawData table.
		/// </summary>
		public static List<tbl_tasDevice_RawData> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasDevice_RawDataSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasDevice_RawData> tbl_tasDevice_RawDataList = new List<tbl_tasDevice_RawData>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasDevice_RawData tbl_tasDevice_RawData = Maketbl_tasDevice_RawData(dataReader);
					tbl_tasDevice_RawDataList.Add(tbl_tasDevice_RawData);
				}
			}
			scon.Close();
			return tbl_tasDevice_RawDataList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasDevice_RawData class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasDevice_RawData Maketbl_tasDevice_RawData(SqlDataReader dataReader) {
			tbl_tasDevice_RawData tbl_tasDevice_RawData = new tbl_tasDevice_RawData();
			
			
            if (dataReader.IsDBNull(0) == false) {
               tbl_tasDevice_RawData.Device_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasDevice_RawData.Device_DateTime = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasDevice_RawData.Device_empID = dataReader.GetString(2);
			}

			return tbl_tasDevice_RawData;
		}
		/// <summary>
		/// This makes tbl_tasDevice_RawData datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasDevice_RawData object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasDevice_RawData  tbl_tasDevice_RawData   )
		{
		DataTable dt = new DataTable();
		
			//DataColumn col_ID = new DataColumn("ID" , typeof(int));
			DataColumn col_device_ID = new DataColumn("device_ID" , typeof(string));
			DataColumn col_device_DateTime = new DataColumn("device_DateTime" , typeof(DateTime));
			DataColumn col_device_empID = new DataColumn("device_empID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] {col_device_ID,col_device_DateTime,col_device_empID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasDevice_RawData datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasDevice_RawData object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasDevice_RawData user) {
		DataRow drow = dt.NewRow();
		
			//drow["ID"] = user.ID;
			drow["device_ID"] = user.device_ID;
			drow["device_DateTime"] = user.device_DateTime;
			drow["device_empID"] = user.device_empID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
