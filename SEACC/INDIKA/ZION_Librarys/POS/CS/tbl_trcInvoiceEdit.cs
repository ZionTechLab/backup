using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_trcInvoiceEdit {
		#region Fields
		private int tracking_ID;
		private string transaction_ID;
		private string existingOrderRefNo;
		private string orderRefNo_ID;
		private DateTime modifyDate;
		private string user_ID;
		private string terminal_ID;
		private string productionJob_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_trcInvoiceEdit class.
		/// </summary>
		public tbl_trcInvoiceEdit() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_trcInvoiceEdit class.
		/// </summary>
		public tbl_trcInvoiceEdit(string transaction_ID, string existingOrderRefNo, string orderRefNo_ID, DateTime modifyDate, string user_ID, string terminal_ID, string productionJob_ID) {
			this.transaction_ID = transaction_ID;
			this.existingOrderRefNo = existingOrderRefNo;
			this.orderRefNo_ID = orderRefNo_ID;
			this.modifyDate = modifyDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.productionJob_ID = productionJob_ID;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_trcInvoiceEdit class.
		/// </summary>
		public tbl_trcInvoiceEdit(int tracking_ID, string transaction_ID, string existingOrderRefNo, string orderRefNo_ID, DateTime modifyDate, string user_ID, string terminal_ID, string productionJob_ID) {
			this.tracking_ID = tracking_ID;
			this.transaction_ID = transaction_ID;
			this.existingOrderRefNo = existingOrderRefNo;
			this.orderRefNo_ID = orderRefNo_ID;
			this.modifyDate = modifyDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.productionJob_ID = productionJob_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tracking_ID value.
		/// </summary>
		public int Tracking_ID {
			get { return tracking_ID; }
			set { tracking_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExistingOrderRefNo value.
		/// </summary>
		public string ExistingOrderRefNo {
			get { return existingOrderRefNo; }
			set { existingOrderRefNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifyDate value.
		/// </summary>
		public DateTime ModifyDate {
			get { return modifyDate; }
			set { modifyDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_trcInvoiceEdit table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcInvoiceEditInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@existingOrderRefNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@modifyDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@existingOrderRefNo"].Value = existingOrderRefNo;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@modifyDate"].Value = modifyDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_trcInvoiceEdit table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcInvoiceEditUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@existingOrderRefNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@modifyDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@existingOrderRefNo"].Value = existingOrderRefNo;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@modifyDate"].Value = modifyDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_trcInvoiceEdit table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcInvoiceEditDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tracking_ID", SqlDbType.Int,4);
			scom.Parameters["@tracking_ID"].Value = tracking_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcInvoiceEdit table by a foreign key.
		/// </summary>
		public static void DeleteAllByTransaction_ID(string transaction_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcInvoiceEditDeleteAllByTransaction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_trcInvoiceEdit table.
		/// </summary>
		public static tbl_trcInvoiceEdit Select(int tracking_ID_Incoming){

			tbl_trcInvoiceEdit tbl_trcInvoiceEditins = new tbl_trcInvoiceEdit();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcInvoiceEditSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tracking_ID", SqlDbType.Int,4);
			scom.Parameters["@tracking_ID"].Value = tracking_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_trcInvoiceEditins = Maketbl_trcInvoiceEdit(dataReader);
				} else {
					tbl_trcInvoiceEditins = null;
				}
			}
			scon.Close();
			return tbl_trcInvoiceEditins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcInvoiceEdit table.
		/// </summary>
		public static List<tbl_trcInvoiceEdit> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcInvoiceEditSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_trcInvoiceEdit> tbl_trcInvoiceEditList = new List<tbl_trcInvoiceEdit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcInvoiceEdit tbl_trcInvoiceEdit = Maketbl_trcInvoiceEdit(dataReader);
					tbl_trcInvoiceEditList.Add(tbl_trcInvoiceEdit);
				}
			}
			scon.Close();
			return tbl_trcInvoiceEditList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcInvoiceEdit table by a foreign key.
		/// </summary>
		public static List<tbl_trcInvoiceEdit> SelectAllByTransaction_ID(string transaction_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcInvoiceEditSelectAllByTransaction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
				List<tbl_trcInvoiceEdit> tbl_trcInvoiceEditList = new List<tbl_trcInvoiceEdit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcInvoiceEdit tbl_trcInvoiceEdit = Maketbl_trcInvoiceEdit(dataReader);
					tbl_trcInvoiceEditList.Add(tbl_trcInvoiceEdit);
				}
			}
			scon.Close();
			return tbl_trcInvoiceEditList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_trcInvoiceEdit class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_trcInvoiceEdit Maketbl_trcInvoiceEdit(SqlDataReader dataReader) {
			tbl_trcInvoiceEdit tbl_trcInvoiceEdit = new tbl_trcInvoiceEdit();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_trcInvoiceEdit.Tracking_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_trcInvoiceEdit.Transaction_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_trcInvoiceEdit.ExistingOrderRefNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_trcInvoiceEdit.OrderRefNo_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_trcInvoiceEdit.ModifyDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_trcInvoiceEdit.User_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_trcInvoiceEdit.Terminal_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_trcInvoiceEdit.ProductionJob_ID = dataReader.GetString(7);
			}

			return tbl_trcInvoiceEdit;
		}
		/// <summary>
		/// This makes tbl_trcInvoiceEdit datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_trcInvoiceEdit object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_trcInvoiceEdit  tbl_trcInvoiceEdit   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tracking_ID = new DataColumn("tracking_ID" , typeof(int));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_existingOrderRefNo = new DataColumn("existingOrderRefNo" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_modifyDate = new DataColumn("modifyDate" , typeof(DateTime));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_tracking_ID,col_transaction_ID,col_existingOrderRefNo,col_orderRefNo_ID,col_modifyDate,col_user_ID,col_terminal_ID,col_productionJob_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_trcInvoiceEdit datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_trcInvoiceEdit object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_trcInvoiceEdit user) {
		DataRow drow = dt.NewRow();
		
			drow["tracking_ID"] = user.tracking_ID;
			drow["transaction_ID"] = user.transaction_ID;
			drow["existingOrderRefNo"] = user.existingOrderRefNo;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["modifyDate"] = user.modifyDate;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["productionJob_ID"] = user.productionJob_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
