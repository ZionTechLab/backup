using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audTransactioin_DeliveryOrder {
		#region Fields
		private string deliveryOrder_ID;
		private string user_ID;
		private bool bIsCanceled;
		private string terminal_ID;
		private DateTime auditDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audTransactioin_DeliveryOrder class.
		/// </summary>
		public tbl_audTransactioin_DeliveryOrder() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audTransactioin_DeliveryOrder class.
		/// </summary>
		public tbl_audTransactioin_DeliveryOrder(string deliveryOrder_ID, string user_ID, bool bIsCanceled, string terminal_ID, DateTime auditDate) {
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.user_ID = user_ID;
			this.bIsCanceled = bIsCanceled;
			this.terminal_ID = terminal_ID;
			this.auditDate = auditDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BIsCanceled value.
		/// </summary>
		public bool BIsCanceled {
			get { return bIsCanceled; }
			set { bIsCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AuditDate value.
		/// </summary>
		public DateTime AuditDate {
			get { return auditDate; }
			set { auditDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audTransactioin_DeliveryOrder table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audTransactioin_DeliveryOrder table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audTransactioin_DeliveryOrder table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_DeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderDeleteAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_DeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_DeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderDeleteAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audTransactioin_DeliveryOrder table.
		/// </summary>
		public static tbl_audTransactioin_DeliveryOrder Select(string deliveryOrder_ID_Incoming, string user_ID_Incoming, bool bIsCanceled_Incoming){

			tbl_audTransactioin_DeliveryOrder tbl_audTransactioin_DeliveryOrderins = new tbl_audTransactioin_DeliveryOrder();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audTransactioin_DeliveryOrderins = Maketbl_audTransactioin_DeliveryOrder(dataReader);
				} else {
					tbl_audTransactioin_DeliveryOrderins = null;
				}
			}
			scon.Close();
			return tbl_audTransactioin_DeliveryOrderins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_DeliveryOrder table.
		/// </summary>
		public static List<tbl_audTransactioin_DeliveryOrder> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audTransactioin_DeliveryOrder> tbl_audTransactioin_DeliveryOrderList = new List<tbl_audTransactioin_DeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_DeliveryOrder tbl_audTransactioin_DeliveryOrder = Maketbl_audTransactioin_DeliveryOrder(dataReader);
					tbl_audTransactioin_DeliveryOrderList.Add(tbl_audTransactioin_DeliveryOrder);
				}
			}
			scon.Close();
			return tbl_audTransactioin_DeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_DeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_DeliveryOrder> SelectAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderSelectAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
				List<tbl_audTransactioin_DeliveryOrder> tbl_audTransactioin_DeliveryOrderList = new List<tbl_audTransactioin_DeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_DeliveryOrder tbl_audTransactioin_DeliveryOrder = Maketbl_audTransactioin_DeliveryOrder(dataReader);
					tbl_audTransactioin_DeliveryOrderList.Add(tbl_audTransactioin_DeliveryOrder);
				}
			}
			scon.Close();
			return tbl_audTransactioin_DeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_DeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_DeliveryOrder> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_audTransactioin_DeliveryOrder> tbl_audTransactioin_DeliveryOrderList = new List<tbl_audTransactioin_DeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_DeliveryOrder tbl_audTransactioin_DeliveryOrder = Maketbl_audTransactioin_DeliveryOrder(dataReader);
					tbl_audTransactioin_DeliveryOrderList.Add(tbl_audTransactioin_DeliveryOrder);
				}
			}
			scon.Close();
			return tbl_audTransactioin_DeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_DeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_DeliveryOrder> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_DeliveryOrderSelectAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
				List<tbl_audTransactioin_DeliveryOrder> tbl_audTransactioin_DeliveryOrderList = new List<tbl_audTransactioin_DeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_DeliveryOrder tbl_audTransactioin_DeliveryOrder = Maketbl_audTransactioin_DeliveryOrder(dataReader);
					tbl_audTransactioin_DeliveryOrderList.Add(tbl_audTransactioin_DeliveryOrder);
				}
			}
			scon.Close();
			return tbl_audTransactioin_DeliveryOrderList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audTransactioin_DeliveryOrder class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audTransactioin_DeliveryOrder Maketbl_audTransactioin_DeliveryOrder(SqlDataReader dataReader) {
			tbl_audTransactioin_DeliveryOrder tbl_audTransactioin_DeliveryOrder = new tbl_audTransactioin_DeliveryOrder();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audTransactioin_DeliveryOrder.DeliveryOrder_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audTransactioin_DeliveryOrder.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audTransactioin_DeliveryOrder.BIsCanceled = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audTransactioin_DeliveryOrder.Terminal_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audTransactioin_DeliveryOrder.AuditDate = dataReader.GetDateTime(4);
			}

			return tbl_audTransactioin_DeliveryOrder;
		}
		/// <summary>
		/// This makes tbl_audTransactioin_DeliveryOrder datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audTransactioin_DeliveryOrder object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audTransactioin_DeliveryOrder  tbl_audTransactioin_DeliveryOrder   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_bIsCanceled = new DataColumn("bIsCanceled" , typeof(bool));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_auditDate = new DataColumn("auditDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_deliveryOrder_ID,col_user_ID,col_bIsCanceled,col_terminal_ID,col_auditDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audTransactioin_DeliveryOrder datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audTransactioin_DeliveryOrder object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audTransactioin_DeliveryOrder user) {
		DataRow drow = dt.NewRow();
		
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["user_ID"] = user.user_ID;
			drow["bIsCanceled"] = user.bIsCanceled;
			drow["terminal_ID"] = user.terminal_ID;
			drow["auditDate"] = user.auditDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
