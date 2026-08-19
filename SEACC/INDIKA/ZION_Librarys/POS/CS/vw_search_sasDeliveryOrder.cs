using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class vw_search_sasDeliveryOrder {
		#region Fields
		private string deliveryOrder_ID;
		private string customerName;
		private string orderRefNo;
		private DateTime deliveryOrderDate;
		private decimal grandTotal;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isSeattled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the vw_search_sasDeliveryOrder class.
		/// </summary>
		public vw_search_sasDeliveryOrder() {
		}
		
		/// <summary>
		/// Initializes a new instance of the vw_search_sasDeliveryOrder class.
		/// </summary>
		public vw_search_sasDeliveryOrder(string deliveryOrder_ID, string customerName, string orderRefNo, DateTime deliveryOrderDate, decimal grandTotal, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled) {
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.customerName = customerName;
			this.orderRefNo = orderRefNo;
			this.deliveryOrderDate = deliveryOrderDate;
			this.grandTotal = grandTotal;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isSeattled = isSeattled;
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
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo value.
		/// </summary>
		public string OrderRefNo {
			get { return orderRefNo; }
			set { orderRefNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrderDate value.
		/// </summary>
		public DateTime DeliveryOrderDate {
			get { return deliveryOrderDate; }
			set { deliveryOrderDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public decimal GrandTotal {
			get { return grandTotal; }
			set { grandTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFinished value.
		/// </summary>
		public bool IsFinished {
			get { return isFinished; }
			set { isFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSeattled value.
		/// </summary>
		public bool IsSeattled {
			get { return isSeattled; }
			set { isSeattled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the vw_search_sasDeliveryOrder table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasDeliveryOrderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deliveryOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
 
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@deliveryOrderDate"].Value = deliveryOrderDate;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the vw_search_sasDeliveryOrder table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasDeliveryOrderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deliveryOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@deliveryOrderDate"].Value = deliveryOrderDate;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the vw_search_sasDeliveryOrder table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasDeliveryOrderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the vw_search_sasDeliveryOrder table.
		/// </summary>
		public static vw_search_sasDeliveryOrder Select(string deliveryOrder_ID_Incoming){

			vw_search_sasDeliveryOrder vw_search_sasDeliveryOrderins = new vw_search_sasDeliveryOrder();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasDeliveryOrderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					vw_search_sasDeliveryOrderins = Makevw_search_sasDeliveryOrder(dataReader);
				} else {
					vw_search_sasDeliveryOrderins = null;
				}
			}
			scon.Close();
			return vw_search_sasDeliveryOrderins;
		}
		
		/// <summary>
		/// Selects all records from the vw_search_sasDeliveryOrder table.
		/// </summary>
		public static List<vw_search_sasDeliveryOrder> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasDeliveryOrderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<vw_search_sasDeliveryOrder> vw_search_sasDeliveryOrderList = new List<vw_search_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					vw_search_sasDeliveryOrder vw_search_sasDeliveryOrder = Makevw_search_sasDeliveryOrder(dataReader);
					vw_search_sasDeliveryOrderList.Add(vw_search_sasDeliveryOrder);
				}
			}
			scon.Close();
			return vw_search_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Creates a new instance of the vw_search_sasDeliveryOrder class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static vw_search_sasDeliveryOrder Makevw_search_sasDeliveryOrder(SqlDataReader dataReader) {
			vw_search_sasDeliveryOrder vw_search_sasDeliveryOrder = new vw_search_sasDeliveryOrder();
			
			if (dataReader.IsDBNull(0) == false) {
				vw_search_sasDeliveryOrder.DeliveryOrder_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				vw_search_sasDeliveryOrder.CustomerName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				vw_search_sasDeliveryOrder.OrderRefNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				vw_search_sasDeliveryOrder.DeliveryOrderDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				vw_search_sasDeliveryOrder.GrandTotal = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				vw_search_sasDeliveryOrder.IsApproved = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				vw_search_sasDeliveryOrder.IsFinished = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				vw_search_sasDeliveryOrder.IsDeleted = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				vw_search_sasDeliveryOrder.IsLocked = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				vw_search_sasDeliveryOrder.IsSeattled = dataReader.GetBoolean(9);
			}

			return vw_search_sasDeliveryOrder;
		}
		/// <summary>
		/// This makes vw_search_sasDeliveryOrder datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new vw_search_sasDeliveryOrder object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( vw_search_sasDeliveryOrder  vw_search_sasDeliveryOrder   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_orderRefNo = new DataColumn("orderRefNo" , typeof(string));
			DataColumn col_deliveryOrderDate = new DataColumn("deliveryOrderDate" , typeof(DateTime));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_deliveryOrder_ID,col_customerName,col_orderRefNo,col_deliveryOrderDate,col_grandTotal,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,});		return dt;
		}
		/// <summary>
		/// This fills vw_search_sasDeliveryOrder datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new vw_search_sasDeliveryOrder object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, vw_search_sasDeliveryOrder user) {
		DataRow drow = dt.NewRow();
		
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["customerName"] = user.customerName;
			drow["orderRefNo"] = user.orderRefNo;
			drow["deliveryOrderDate"] = user.deliveryOrderDate;
			drow["grandTotal"] = user.grandTotal;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isSeattled"] = user.isSeattled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
