using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_whTxn_VehicleTracker {
		#region Fields
		private string vehicleTracking_ID;
		private string vehicle_No;
		private int purpose;
		private string customer_ID;
		private string container_No;
		private string driverName;
		private string driverNic;
		private DateTime checkinTime;
		private DateTime checkoutTime;
		private bool isCancelled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Cancelled;
		private string terminalID_Created;
		private string terminaiID_Modified;
		private string terminalID_Cancelled;
		private DateTime date_Created;
		private DateTime dateModified;
		private DateTime date_Cancelled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_VehicleTracker class.
		/// </summary>
		public tbl_whTxn_VehicleTracker() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_VehicleTracker class.
		/// </summary>
		public tbl_whTxn_VehicleTracker(string vehicleTracking_ID, string vehicle_No, int purpose, string customer_ID, string container_No, string driverName, string driverNic, DateTime checkinTime, DateTime checkoutTime, bool isCancelled, string userID_Created, string userID_Modified, string userID_Cancelled, string terminalID_Created, string terminaiID_Modified, string terminalID_Cancelled, DateTime date_Created, DateTime dateModified, DateTime date_Cancelled) {
			this.vehicleTracking_ID = vehicleTracking_ID;
			this.vehicle_No = vehicle_No;
			this.purpose = purpose;
			this.customer_ID = customer_ID;
			this.container_No = container_No;
			this.driverName = driverName;
			this.driverNic = driverNic;
			this.checkinTime = checkinTime;
			this.checkoutTime = checkoutTime;
			this.isCancelled = isCancelled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Cancelled = userID_Cancelled;
			this.terminalID_Created = terminalID_Created;
			this.terminaiID_Modified = terminaiID_Modified;
			this.terminalID_Cancelled = terminalID_Cancelled;
			this.date_Created = date_Created;
			this.dateModified = dateModified;
			this.date_Cancelled = date_Cancelled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the VehicleTracking_ID value.
		/// </summary>
		public string VehicleTracking_ID {
			get { return vehicleTracking_ID; }
			set { vehicleTracking_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Vehicle_No value.
		/// </summary>
		public string Vehicle_No {
			get { return vehicle_No; }
			set { vehicle_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Purpose value.
		/// </summary>
		public int Purpose {
			get { return purpose; }
			set { purpose = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Container_No value.
		/// </summary>
		public string Container_No {
			get { return container_No; }
			set { container_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the DriverName value.
		/// </summary>
		public string DriverName {
			get { return driverName; }
			set { driverName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DriverNic value.
		/// </summary>
		public string DriverNic {
			get { return driverNic; }
			set { driverNic = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckinTime value.
		/// </summary>
		public DateTime CheckinTime {
			get { return checkinTime; }
			set { checkinTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckoutTime value.
		/// </summary>
		public DateTime CheckoutTime {
			get { return checkoutTime; }
			set { checkoutTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCancelled value.
		/// </summary>
		public bool IsCancelled {
			get { return isCancelled; }
			set { isCancelled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Cancelled value.
		/// </summary>
		public string UserID_Cancelled {
			get { return userID_Cancelled; }
			set { userID_Cancelled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminaiID_Modified value.
		/// </summary>
		public string TerminaiID_Modified {
			get { return terminaiID_Modified; }
			set { terminaiID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Cancelled value.
		/// </summary>
		public string TerminalID_Cancelled {
			get { return terminalID_Cancelled; }
			set { terminalID_Cancelled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Cancelled value.
		/// </summary>
		public DateTime Date_Cancelled {
			get { return date_Cancelled; }
			set { date_Cancelled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_whTxn_VehicleTracker table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_VehicleTrackerInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@vehicleTracking_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@vehicle_No", SqlDbType.VarChar,10);
			scom.Parameters.Add("@purpose", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@container_No", SqlDbType.VarChar,10);
			scom.Parameters.Add("@driverName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@driverNic", SqlDbType.VarChar,10);
			scom.Parameters.Add("@checkinTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@checkoutTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isCancelled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Cancelled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminaiID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Cancelled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Cancelled", SqlDbType.DateTime,8);
 
			scom.Parameters["@vehicleTracking_ID"].Value = vehicleTracking_ID;
			scom.Parameters["@vehicle_No"].Value = vehicle_No;
			scom.Parameters["@purpose"].Value = purpose;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@container_No"].Value = container_No;
			scom.Parameters["@driverName"].Value = driverName;
			scom.Parameters["@driverNic"].Value = driverNic;
			scom.Parameters["@checkinTime"].Value = checkinTime;
			scom.Parameters["@checkoutTime"].Value = checkoutTime;
			scom.Parameters["@isCancelled"].Value = isCancelled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Cancelled"].Value = userID_Cancelled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminaiID_Modified"].Value = terminaiID_Modified;
			scom.Parameters["@terminalID_Cancelled"].Value = terminalID_Cancelled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@date_Cancelled"].Value = date_Cancelled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_whTxn_VehicleTracker table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_VehicleTrackerUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@vehicleTracking_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@vehicle_No", SqlDbType.VarChar,10);
			scom.Parameters.Add("@purpose", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@container_No", SqlDbType.VarChar,10);
			scom.Parameters.Add("@driverName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@driverNic", SqlDbType.VarChar,10);
			scom.Parameters.Add("@checkinTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@checkoutTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isCancelled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Cancelled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminaiID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Cancelled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Cancelled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@vehicleTracking_ID"].Value = vehicleTracking_ID;
			scom.Parameters["@vehicle_No"].Value = vehicle_No;
			scom.Parameters["@purpose"].Value = purpose;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@container_No"].Value = container_No;
			scom.Parameters["@driverName"].Value = driverName;
			scom.Parameters["@driverNic"].Value = driverNic;
			scom.Parameters["@checkinTime"].Value = checkinTime;
			scom.Parameters["@checkoutTime"].Value = checkoutTime;
			scom.Parameters["@isCancelled"].Value = isCancelled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Cancelled"].Value = userID_Cancelled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminaiID_Modified"].Value = terminaiID_Modified;
			scom.Parameters["@terminalID_Cancelled"].Value = terminalID_Cancelled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@date_Cancelled"].Value = date_Cancelled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_whTxn_VehicleTracker table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_VehicleTrackerDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@vehicleTracking_ID", SqlDbType.VarChar,8);
			scom.Parameters["@vehicleTracking_ID"].Value = vehicleTracking_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_VehicleTracker table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_VehicleTrackerDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_whTxn_VehicleTracker table.
		/// </summary>
		public static tbl_whTxn_VehicleTracker Select(string vehicleTracking_ID_Incoming){

			tbl_whTxn_VehicleTracker tbl_whTxn_VehicleTrackerins = new tbl_whTxn_VehicleTracker();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_VehicleTrackerSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@vehicleTracking_ID", SqlDbType.VarChar,8);
			scom.Parameters["@vehicleTracking_ID"].Value = vehicleTracking_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_whTxn_VehicleTrackerins = Maketbl_whTxn_VehicleTracker(dataReader);
				} else {
					tbl_whTxn_VehicleTrackerins = null;
				}
			}
			scon.Close();
			return tbl_whTxn_VehicleTrackerins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_VehicleTracker table.
		/// </summary>
		public static List<tbl_whTxn_VehicleTracker> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_VehicleTrackerSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_whTxn_VehicleTracker> tbl_whTxn_VehicleTrackerList = new List<tbl_whTxn_VehicleTracker>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_VehicleTracker tbl_whTxn_VehicleTracker = Maketbl_whTxn_VehicleTracker(dataReader);
					tbl_whTxn_VehicleTrackerList.Add(tbl_whTxn_VehicleTracker);
				}
			}
			scon.Close();
			return tbl_whTxn_VehicleTrackerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_VehicleTracker table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_VehicleTracker> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_VehicleTrackerSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_whTxn_VehicleTracker> tbl_whTxn_VehicleTrackerList = new List<tbl_whTxn_VehicleTracker>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_VehicleTracker tbl_whTxn_VehicleTracker = Maketbl_whTxn_VehicleTracker(dataReader);
					tbl_whTxn_VehicleTrackerList.Add(tbl_whTxn_VehicleTracker);
				}
			}
			scon.Close();
			return tbl_whTxn_VehicleTrackerList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_whTxn_VehicleTracker class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_whTxn_VehicleTracker Maketbl_whTxn_VehicleTracker(SqlDataReader dataReader) {
			tbl_whTxn_VehicleTracker tbl_whTxn_VehicleTracker = new tbl_whTxn_VehicleTracker();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_whTxn_VehicleTracker.VehicleTracking_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_whTxn_VehicleTracker.Vehicle_No = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_whTxn_VehicleTracker.Purpose = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_whTxn_VehicleTracker.Customer_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_whTxn_VehicleTracker.Container_No = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_whTxn_VehicleTracker.DriverName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_whTxn_VehicleTracker.DriverNic = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_whTxn_VehicleTracker.CheckinTime = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_whTxn_VehicleTracker.CheckoutTime = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_whTxn_VehicleTracker.IsCancelled = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_whTxn_VehicleTracker.UserID_Created = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_whTxn_VehicleTracker.UserID_Modified = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_whTxn_VehicleTracker.UserID_Cancelled = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_whTxn_VehicleTracker.TerminalID_Created = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_whTxn_VehicleTracker.TerminaiID_Modified = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_whTxn_VehicleTracker.TerminalID_Cancelled = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_whTxn_VehicleTracker.Date_Created = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_whTxn_VehicleTracker.DateModified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_whTxn_VehicleTracker.Date_Cancelled = dataReader.GetDateTime(18);
			}

			return tbl_whTxn_VehicleTracker;
		}
		/// <summary>
		/// This makes tbl_whTxn_VehicleTracker datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_whTxn_VehicleTracker object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_whTxn_VehicleTracker  tbl_whTxn_VehicleTracker   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_vehicleTracking_ID = new DataColumn("vehicleTracking_ID" , typeof(string));
			DataColumn col_vehicle_No = new DataColumn("vehicle_No" , typeof(string));
			DataColumn col_purpose = new DataColumn("purpose" , typeof(int));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_container_No = new DataColumn("container_No" , typeof(string));
			DataColumn col_driverName = new DataColumn("driverName" , typeof(string));
			DataColumn col_driverNic = new DataColumn("driverNic" , typeof(string));
			DataColumn col_checkinTime = new DataColumn("checkinTime" , typeof(DateTime));
			DataColumn col_checkoutTime = new DataColumn("checkoutTime" , typeof(DateTime));
			DataColumn col_isCancelled = new DataColumn("isCancelled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Cancelled = new DataColumn("userID_Cancelled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminaiID_Modified = new DataColumn("terminaiID_Modified" , typeof(string));
			DataColumn col_terminalID_Cancelled = new DataColumn("terminalID_Cancelled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_date_Cancelled = new DataColumn("date_Cancelled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_vehicleTracking_ID,col_vehicle_No,col_purpose,col_customer_ID,col_container_No,col_driverName,col_driverNic,col_checkinTime,col_checkoutTime,col_isCancelled,col_userID_Created,col_userID_Modified,col_userID_Cancelled,col_terminalID_Created,col_terminaiID_Modified,col_terminalID_Cancelled,col_date_Created,col_dateModified,col_date_Cancelled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_whTxn_VehicleTracker datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_whTxn_VehicleTracker object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_whTxn_VehicleTracker user) {
		DataRow drow = dt.NewRow();
		
			drow["vehicleTracking_ID"] = user.vehicleTracking_ID;
			drow["vehicle_No"] = user.vehicle_No;
			drow["purpose"] = user.purpose;
			drow["customer_ID"] = user.customer_ID;
			drow["container_No"] = user.container_No;
			drow["driverName"] = user.driverName;
			drow["driverNic"] = user.driverNic;
			drow["checkinTime"] = user.checkinTime;
			drow["checkoutTime"] = user.checkoutTime;
			drow["isCancelled"] = user.isCancelled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Cancelled"] = user.userID_Cancelled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminaiID_Modified"] = user.terminaiID_Modified;
			drow["terminalID_Cancelled"] = user.terminalID_Cancelled;
			drow["date_Created"] = user.date_Created;
			drow["dateModified"] = user.dateModified;
			drow["date_Cancelled"] = user.date_Cancelled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
