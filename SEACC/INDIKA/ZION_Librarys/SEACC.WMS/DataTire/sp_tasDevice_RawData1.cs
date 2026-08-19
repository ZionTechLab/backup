using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class sp_tasDevice_RawData {
		#region Fields
		private int rawData_Index;
		private DateTime device_DateTime;
		private string device_ID;
		private string device_Name;
		private string device_empID;
		private string employeeName;
		private int entry_Type;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the sp_tasDevice_RawData class.
		/// </summary>
		public sp_tasDevice_RawData() {
		}
		
		/// <summary>
		/// Initializes a new instance of the sp_tasDevice_RawData class.
		/// </summary>
		public sp_tasDevice_RawData(int rawData_Index, DateTime device_DateTime, string device_ID, string device_Name, string device_empID, string employeeName, int entry_Type) {
			this.rawData_Index = rawData_Index;
			this.device_DateTime = device_DateTime;
			this.device_ID = device_ID;
			this.device_Name = device_Name;
			this.device_empID = device_empID;
			this.employeeName = employeeName;
			this.entry_Type = entry_Type;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the RawData_Index value.
		/// </summary>
		public int RawData_Index {
			get { return rawData_Index; }
			set { rawData_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_DateTime value.
		/// </summary>
		public DateTime Device_DateTime {
			get { return device_DateTime; }
			set { device_DateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_ID value.
		/// </summary>
		public string Device_ID {
			get { return device_ID; }
			set { device_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_Name value.
		/// </summary>
		public string Device_Name {
			get { return device_Name; }
			set { device_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_empID value.
		/// </summary>
		public string Device_empID {
			get { return device_empID; }
			set { device_empID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeName value.
		/// </summary>
		public string EmployeeName {
			get { return employeeName; }
			set { employeeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Entry_Type value.
		/// </summary>
		public int Entry_Type {
			get { return entry_Type; }
			set { entry_Type = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the sp_tasDevice_RawData table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_tasDevice_RawDataInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@rawData_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@device_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@device_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@device_empID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employeeName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@entry_Type", SqlDbType.Int,4);
 
			scom.Parameters["@rawData_Index"].Value = rawData_Index;
			scom.Parameters["@device_DateTime"].Value = device_DateTime;
			scom.Parameters["@device_ID"].Value = device_ID;
			scom.Parameters["@device_Name"].Value = device_Name;
			scom.Parameters["@device_empID"].Value = device_empID;
			scom.Parameters["@employeeName"].Value = employeeName;
			scom.Parameters["@entry_Type"].Value = entry_Type;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the sp_tasDevice_RawData table.
		/// </summary>
		public static List<sp_tasDevice_RawData> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_tasDevice_RawDataSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<sp_tasDevice_RawData> sp_tasDevice_RawDataList = new List<sp_tasDevice_RawData>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					sp_tasDevice_RawData sp_tasDevice_RawData = Makesp_tasDevice_RawData(dataReader);
					sp_tasDevice_RawDataList.Add(sp_tasDevice_RawData);
				}
			}
			scon.Close();
			return sp_tasDevice_RawDataList;
		}

        public static List<sp_tasDevice_RawData> SelectAll(String device_ID, string device_empID, DateTime FromDate, DateTime ToDate)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("sp_tasDevice_RawDataSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@device_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@device_ID"].Value = device_ID;
            scom.Parameters.Add("@device_empID", SqlDbType.VarChar, 20);
            scom.Parameters["@device_empID"].Value = device_empID;
            scom.Parameters.Add("@FromDate", SqlDbType.DateTime);
            scom.Parameters["@FromDate"].Value = FromDate;
            scom.Parameters.Add("@ToDate", SqlDbType.DateTime);
            scom.Parameters["@ToDate"].Value = ToDate;

            List<sp_tasDevice_RawData> sp_tasDevice_RawDataList = new List<sp_tasDevice_RawData>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    sp_tasDevice_RawData sp_tasDevice_RawData = Makesp_tasDevice_RawData(dataReader);
                    sp_tasDevice_RawDataList.Add(sp_tasDevice_RawData);
                }
            }
            scon.Close();
            return sp_tasDevice_RawDataList;
        }
		

		/// <summary>
		/// Creates a new instance of the sp_tasDevice_RawData class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static sp_tasDevice_RawData Makesp_tasDevice_RawData(SqlDataReader dataReader) {
			sp_tasDevice_RawData sp_tasDevice_RawData = new sp_tasDevice_RawData();
			
			if (dataReader.IsDBNull(0) == false) {
				sp_tasDevice_RawData.RawData_Index = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				sp_tasDevice_RawData.Device_DateTime = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				sp_tasDevice_RawData.Device_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				sp_tasDevice_RawData.Device_Name = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				sp_tasDevice_RawData.Device_empID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				sp_tasDevice_RawData.EmployeeName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				sp_tasDevice_RawData.Entry_Type = dataReader.GetInt32(6);
			}

			return sp_tasDevice_RawData;
		}
		/// <summary>
		/// This makes sp_tasDevice_RawData datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new sp_tasDevice_RawData object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( sp_tasDevice_RawData  sp_tasDevice_RawData   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_rawData_Index = new DataColumn("rawData_Index" , typeof(int));
			DataColumn col_device_DateTime = new DataColumn("device_DateTime" , typeof(DateTime));
			DataColumn col_device_ID = new DataColumn("device_ID" , typeof(string));
			DataColumn col_device_Name = new DataColumn("device_Name" , typeof(string));
			DataColumn col_device_empID = new DataColumn("device_empID" , typeof(string));
			DataColumn col_employeeName = new DataColumn("employeeName" , typeof(string));
			DataColumn col_entry_Type = new DataColumn("entry_Type" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_rawData_Index,col_device_DateTime,col_device_ID,col_device_Name,col_device_empID,col_employeeName,col_entry_Type,});		return dt;
		}
		/// <summary>
		/// This fills sp_tasDevice_RawData datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new sp_tasDevice_RawData object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, sp_tasDevice_RawData user) {
		DataRow drow = dt.NewRow();
		
			drow["rawData_Index"] = user.rawData_Index;
			drow["device_DateTime"] = user.device_DateTime;
			drow["device_ID"] = user.device_ID;
			drow["device_Name"] = user.device_Name;
			drow["device_empID"] = user.device_empID;
			drow["employeeName"] = user.employeeName;
			drow["entry_Type"] = user.entry_Type;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
