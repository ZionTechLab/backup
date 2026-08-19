using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasTxDeviceRawData {
		#region Fields
		private int rawData_Index;
		private string device_ID;
		private DateTime device_DateTime;
		private string device_empID;
		private bool isAttendanceCompleted;
		private bool isSelected;
		private int entry_Type;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxDeviceRawData class.
		/// </summary>
		public tbl_tasTxDeviceRawData() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxDeviceRawData class.
		/// </summary>
		public tbl_tasTxDeviceRawData(int rawData_Index, string device_ID, DateTime device_DateTime, string device_empID, bool isAttendanceCompleted, bool isSelected, int entry_Type) {
			this.rawData_Index = rawData_Index;
			this.device_ID = device_ID;
			this.device_DateTime = device_DateTime;
			this.device_empID = device_empID;
			this.isAttendanceCompleted = isAttendanceCompleted;
			this.isSelected = isSelected;
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
		
		/// <summary>
		/// Gets or sets the IsAttendanceCompleted value.
		/// </summary>
		public bool IsAttendanceCompleted {
			get { return isAttendanceCompleted; }
			set { isAttendanceCompleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSelected value.
		/// </summary>
		public bool IsSelected {
			get { return isSelected; }
			set { isSelected = value; }
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
		/// Saves a record to the tbl_tasTxDeviceRawData table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDeviceRawDataInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@rawData_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@device_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@device_empID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isAttendanceCompleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSelected", SqlDbType.Bit,1);
			scom.Parameters.Add("@entry_Type", SqlDbType.Int,4);
 
			scom.Parameters["@rawData_Index"].Value = rawData_Index;
			scom.Parameters["@device_ID"].Value = device_ID;
			scom.Parameters["@device_DateTime"].Value = device_DateTime;
			scom.Parameters["@device_empID"].Value = device_empID;
			scom.Parameters["@isAttendanceCompleted"].Value = isAttendanceCompleted;
			scom.Parameters["@isSelected"].Value = isSelected;
			scom.Parameters["@entry_Type"].Value = entry_Type;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasTxDeviceRawData table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDeviceRawDataUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@rawData_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@device_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@device_empID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isAttendanceCompleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSelected", SqlDbType.Bit,1);
			scom.Parameters.Add("@entry_Type", SqlDbType.Int,4);
 
 
			scom.Parameters["@rawData_Index"].Value = rawData_Index;
			scom.Parameters["@device_ID"].Value = device_ID;
			scom.Parameters["@device_DateTime"].Value = device_DateTime;
			scom.Parameters["@device_empID"].Value = device_empID;
			scom.Parameters["@isAttendanceCompleted"].Value = isAttendanceCompleted;
			scom.Parameters["@isSelected"].Value = isSelected;
			scom.Parameters["@entry_Type"].Value = entry_Type;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasTxDeviceRawData table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDeviceRawDataDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@rawData_Index", SqlDbType.Int,4);
			scom.Parameters["@rawData_Index"].Value = rawData_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasTxDeviceRawData table.
		/// </summary>
		public static tbl_tasTxDeviceRawData Select(int rawData_Index_Incoming){

			tbl_tasTxDeviceRawData tbl_tasTxDeviceRawDatains = new tbl_tasTxDeviceRawData();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDeviceRawDataSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@rawData_Index", SqlDbType.Int,4);
			scom.Parameters["@rawData_Index"].Value = rawData_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasTxDeviceRawDatains = Maketbl_tasTxDeviceRawData(dataReader);
				} else {
					tbl_tasTxDeviceRawDatains = null;
				}
			}
			scon.Close();
			return tbl_tasTxDeviceRawDatains;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxDeviceRawData table.
		/// </summary>
		public static List<tbl_tasTxDeviceRawData> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDeviceRawDataSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasTxDeviceRawData> tbl_tasTxDeviceRawDataList = new List<tbl_tasTxDeviceRawData>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxDeviceRawData tbl_tasTxDeviceRawData = Maketbl_tasTxDeviceRawData(dataReader);
					tbl_tasTxDeviceRawDataList.Add(tbl_tasTxDeviceRawData);
				}
			}
			scon.Close();
			return tbl_tasTxDeviceRawDataList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasTxDeviceRawData class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasTxDeviceRawData Maketbl_tasTxDeviceRawData(SqlDataReader dataReader) {
			tbl_tasTxDeviceRawData tbl_tasTxDeviceRawData = new tbl_tasTxDeviceRawData();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasTxDeviceRawData.RawData_Index = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasTxDeviceRawData.Device_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasTxDeviceRawData.Device_DateTime = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasTxDeviceRawData.Device_empID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasTxDeviceRawData.IsAttendanceCompleted = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasTxDeviceRawData.IsSelected = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasTxDeviceRawData.Entry_Type = dataReader.GetInt32(6);
			}

			return tbl_tasTxDeviceRawData;
		}
		/// <summary>
		/// This makes tbl_tasTxDeviceRawData datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasTxDeviceRawData object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasTxDeviceRawData  tbl_tasTxDeviceRawData   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_rawData_Index = new DataColumn("rawData_Index" , typeof(int));
			DataColumn col_device_ID = new DataColumn("device_ID" , typeof(string));
			DataColumn col_device_DateTime = new DataColumn("device_DateTime" , typeof(DateTime));
			DataColumn col_device_empID = new DataColumn("device_empID" , typeof(string));
			DataColumn col_isAttendanceCompleted = new DataColumn("isAttendanceCompleted" , typeof(bool));
			DataColumn col_isSelected = new DataColumn("isSelected" , typeof(bool));
			DataColumn col_entry_Type = new DataColumn("entry_Type" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_rawData_Index,col_device_ID,col_device_DateTime,col_device_empID,col_isAttendanceCompleted,col_isSelected,col_entry_Type,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasTxDeviceRawData datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasTxDeviceRawData object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasTxDeviceRawData user) {
		DataRow drow = dt.NewRow();
		
			drow["rawData_Index"] = user.rawData_Index;
			drow["device_ID"] = user.device_ID;
			drow["device_DateTime"] = user.device_DateTime;
			drow["device_empID"] = user.device_empID;
			drow["isAttendanceCompleted"] = user.isAttendanceCompleted;
			drow["isSelected"] = user.isSelected;
			drow["entry_Type"] = user.entry_Type;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
