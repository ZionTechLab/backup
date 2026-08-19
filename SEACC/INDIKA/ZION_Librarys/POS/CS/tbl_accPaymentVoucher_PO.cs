using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accPaymentVoucher_PO {
		#region Fields
		private string purchaseOrder_ID;
		private string paymentVoucher_ID;
		private decimal amount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accPaymentVoucher_PO class.
		/// </summary>
		public tbl_accPaymentVoucher_PO() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accPaymentVoucher_PO class.
		/// </summary>
		public tbl_accPaymentVoucher_PO(string purchaseOrder_ID, string paymentVoucher_ID, decimal amount) {
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.paymentVoucher_ID = paymentVoucher_ID;
			this.amount = amount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PurchaseOrder_ID value.
		/// </summary>
		public string PurchaseOrder_ID {
			get { return purchaseOrder_ID; }
			set { purchaseOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentVoucher_ID value.
		/// </summary>
		public string PaymentVoucher_ID {
			get { return paymentVoucher_ID; }
			set { paymentVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accPaymentVoucher_PO table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_POInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accPaymentVoucher_PO table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_POUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accPaymentVoucher_PO table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_PODelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
 
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accPaymentVoucher_PO table.
		/// </summary>
		public static tbl_accPaymentVoucher_PO Select(string purchaseOrder_ID_Incoming, string paymentVoucher_ID_Incoming){

			tbl_accPaymentVoucher_PO tbl_accPaymentVoucher_POins = new tbl_accPaymentVoucher_PO();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_POSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID_Incoming;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accPaymentVoucher_POins = Maketbl_accPaymentVoucher_PO(dataReader);
				} else {
					tbl_accPaymentVoucher_POins = null;
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_POins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_PO table.
		/// </summary>
		public static List<tbl_accPaymentVoucher_PO> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_POSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accPaymentVoucher_PO> tbl_accPaymentVoucher_POList = new List<tbl_accPaymentVoucher_PO>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_PO tbl_accPaymentVoucher_PO = Maketbl_accPaymentVoucher_PO(dataReader);
					tbl_accPaymentVoucher_POList.Add(tbl_accPaymentVoucher_PO);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_POList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accPaymentVoucher_PO class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accPaymentVoucher_PO Maketbl_accPaymentVoucher_PO(SqlDataReader dataReader) {
			tbl_accPaymentVoucher_PO tbl_accPaymentVoucher_PO = new tbl_accPaymentVoucher_PO();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accPaymentVoucher_PO.PurchaseOrder_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accPaymentVoucher_PO.PaymentVoucher_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accPaymentVoucher_PO.Amount = dataReader.GetDecimal(2);
			}

			return tbl_accPaymentVoucher_PO;
		}
		/// <summary>
		/// This makes tbl_accPaymentVoucher_PO datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accPaymentVoucher_PO object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accPaymentVoucher_PO  tbl_accPaymentVoucher_PO   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_purchaseOrder_ID = new DataColumn("purchaseOrder_ID" , typeof(string));
			DataColumn col_paymentVoucher_ID = new DataColumn("paymentVoucher_ID" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_purchaseOrder_ID,col_paymentVoucher_ID,col_amount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accPaymentVoucher_PO datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accPaymentVoucher_PO object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accPaymentVoucher_PO user) {
		DataRow drow = dt.NewRow();
		
			drow["purchaseOrder_ID"] = user.purchaseOrder_ID;
			drow["paymentVoucher_ID"] = user.paymentVoucher_ID;
			drow["amount"] = user.amount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
