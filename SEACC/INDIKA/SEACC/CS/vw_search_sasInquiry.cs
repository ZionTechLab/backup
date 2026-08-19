using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class vw_search_sasInquiry {
		#region Fields
		private string inquiry_ID;
		private string customerName;
		private string orderRefNo;
		private DateTime inquiryDate;
		private decimal grandTotal;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isSeattled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the vw_search_sasInquiry class.
		/// </summary>
		public vw_search_sasInquiry() {
		}
		
		/// <summary>
		/// Initializes a new instance of the vw_search_sasInquiry class.
		/// </summary>
		public vw_search_sasInquiry(string inquiry_ID, string customerName, string orderRefNo, DateTime inquiryDate, decimal grandTotal, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled) {
			this.inquiry_ID = inquiry_ID;
			this.customerName = customerName;
			this.orderRefNo = orderRefNo;
			this.inquiryDate = inquiryDate;
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
		/// Gets or sets the Inquiry_ID value.
		/// </summary>
		public string Inquiry_ID {
			get { return inquiry_ID; }
			set { inquiry_ID = value; }
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
		/// Gets or sets the InquiryDate value.
		/// </summary>
		public DateTime InquiryDate {
			get { return inquiryDate; }
			set { inquiryDate = value; }
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
		/// Saves a record to the vw_search_sasInquiry table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInquiryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@inquiryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
 
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@inquiryDate"].Value = inquiryDate;
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
		/// Updates a record in the vw_search_sasInquiry table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInquiryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@inquiryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@inquiryDate"].Value = inquiryDate;
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
		/// Deletes a record from the vw_search_sasInquiry table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInquiryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the vw_search_sasInquiry table.
		/// </summary>
		public static vw_search_sasInquiry Select(string inquiry_ID_Incoming){

			vw_search_sasInquiry vw_search_sasInquiryins = new vw_search_sasInquiry();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInquirySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					vw_search_sasInquiryins = Makevw_search_sasInquiry(dataReader);
				} else {
					vw_search_sasInquiryins = null;
				}
			}
			scon.Close();
			return vw_search_sasInquiryins;
		}
		
		/// <summary>
		/// Selects all records from the vw_search_sasInquiry table.
		/// </summary>
		public static List<vw_search_sasInquiry> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_sasInquirySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<vw_search_sasInquiry> vw_search_sasInquiryList = new List<vw_search_sasInquiry>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					vw_search_sasInquiry vw_search_sasInquiry = Makevw_search_sasInquiry(dataReader);
					vw_search_sasInquiryList.Add(vw_search_sasInquiry);
				}
			}
			scon.Close();
			return vw_search_sasInquiryList;
		}
		
		/// <summary>
		/// Creates a new instance of the vw_search_sasInquiry class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static vw_search_sasInquiry Makevw_search_sasInquiry(SqlDataReader dataReader) {
			vw_search_sasInquiry vw_search_sasInquiry = new vw_search_sasInquiry();
			
			if (dataReader.IsDBNull(0) == false) {
				vw_search_sasInquiry.Inquiry_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				vw_search_sasInquiry.CustomerName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				vw_search_sasInquiry.OrderRefNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				vw_search_sasInquiry.InquiryDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				vw_search_sasInquiry.GrandTotal = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				vw_search_sasInquiry.IsApproved = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				vw_search_sasInquiry.IsFinished = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				vw_search_sasInquiry.IsDeleted = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				vw_search_sasInquiry.IsLocked = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				vw_search_sasInquiry.IsSeattled = dataReader.GetBoolean(9);
			}

			return vw_search_sasInquiry;
		}
		/// <summary>
		/// This makes vw_search_sasInquiry datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new vw_search_sasInquiry object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( vw_search_sasInquiry  vw_search_sasInquiry   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_inquiry_ID = new DataColumn("inquiry_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_orderRefNo = new DataColumn("orderRefNo" , typeof(string));
			DataColumn col_inquiryDate = new DataColumn("inquiryDate" , typeof(DateTime));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_inquiry_ID,col_customerName,col_orderRefNo,col_inquiryDate,col_grandTotal,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,});		return dt;
		}
		/// <summary>
		/// This fills vw_search_sasInquiry datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new vw_search_sasInquiry object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, vw_search_sasInquiry user) {
		DataRow drow = dt.NewRow();
		
			drow["inquiry_ID"] = user.inquiry_ID;
			drow["customerName"] = user.customerName;
			drow["orderRefNo"] = user.orderRefNo;
			drow["inquiryDate"] = user.inquiryDate;
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
