using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission_Invoices_Payments {
		#region Fields
		private int line_No;
		private string commission_ID;
		private string invoice_ID;
		private DateTime invoiceDate;
		private string payment_ID;
		private DateTime paymentDate;
		private string paymentRemark;
		private decimal allocationAmount;
		private int days;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Invoices_Payments class.
		/// </summary>
		public tbl_sasSalesCommission_Invoices_Payments() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Invoices_Payments class.
		/// </summary>
		public tbl_sasSalesCommission_Invoices_Payments(int line_No, string commission_ID, string invoice_ID, DateTime invoiceDate, string payment_ID, DateTime paymentDate, string paymentRemark, decimal allocationAmount, int days) {
			this.line_No = line_No;
			this.commission_ID = commission_ID;
			this.invoice_ID = invoice_ID;
			this.invoiceDate = invoiceDate;
			this.payment_ID = payment_ID;
			this.paymentDate = paymentDate;
			this.paymentRemark = paymentRemark;
			this.allocationAmount = allocationAmount;
			this.days = days;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Commission_ID value.
		/// </summary>
		public string Commission_ID {
			get { return commission_ID; }
			set { commission_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceDate value.
		/// </summary>
		public DateTime InvoiceDate {
			get { return invoiceDate; }
			set { invoiceDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Payment_ID value.
		/// </summary>
		public string Payment_ID {
			get { return payment_ID; }
			set { payment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentDate value.
		/// </summary>
		public DateTime PaymentDate {
			get { return paymentDate; }
			set { paymentDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentRemark value.
		/// </summary>
		public string PaymentRemark {
			get { return paymentRemark; }
			set { paymentRemark = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllocationAmount value.
		/// </summary>
		public decimal AllocationAmount {
			get { return allocationAmount; }
			set { allocationAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Days value.
		/// </summary>
		public int Days {
			get { return days; }
			set { days = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission_Invoices_Payments table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_Invoices_PaymentsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@payment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@paymentRemark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@allocationAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@days", SqlDbType.Int,4);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@payment_ID"].Value = payment_ID;
			scom.Parameters["@paymentDate"].Value = paymentDate;
			scom.Parameters["@paymentRemark"].Value = paymentRemark;
			scom.Parameters["@allocationAmount"].Value = allocationAmount;
			scom.Parameters["@days"].Value = days;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission_Invoices_Payments table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_Invoices_PaymentsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@payment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@paymentRemark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@allocationAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@days", SqlDbType.Int,4);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@invoiceDate"].Value = invoiceDate;
			scom.Parameters["@payment_ID"].Value = payment_ID;
			scom.Parameters["@paymentDate"].Value = paymentDate;
			scom.Parameters["@paymentRemark"].Value = paymentRemark;
			scom.Parameters["@allocationAmount"].Value = allocationAmount;
			scom.Parameters["@days"].Value = days;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission_Invoices_Payments table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_Invoices_PaymentsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Invoices_Payments table by a foreign key.
		/// </summary>
		public static void DeleteAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_Invoices_PaymentsDeleteAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission_Invoices_Payments table.
		/// </summary>
		public static tbl_sasSalesCommission_Invoices_Payments Select(int line_No_Incoming, string commission_ID_Incoming, string invoice_ID_Incoming){

			tbl_sasSalesCommission_Invoices_Payments tbl_sasSalesCommission_Invoices_Paymentsins = new tbl_sasSalesCommission_Invoices_Payments();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_Invoices_PaymentsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommission_Invoices_Paymentsins = Maketbl_sasSalesCommission_Invoices_Payments(dataReader);
				} else {
					tbl_sasSalesCommission_Invoices_Paymentsins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_Invoices_Paymentsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Invoices_Payments table.
		/// </summary>
		public static List<tbl_sasSalesCommission_Invoices_Payments> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_Invoices_PaymentsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission_Invoices_Payments> tbl_sasSalesCommission_Invoices_PaymentsList = new List<tbl_sasSalesCommission_Invoices_Payments>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Invoices_Payments tbl_sasSalesCommission_Invoices_Payments = Maketbl_sasSalesCommission_Invoices_Payments(dataReader);
					tbl_sasSalesCommission_Invoices_PaymentsList.Add(tbl_sasSalesCommission_Invoices_Payments);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_Invoices_PaymentsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Invoices_Payments table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_Invoices_Payments> SelectAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_Invoices_PaymentsSelectAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
				List<tbl_sasSalesCommission_Invoices_Payments> tbl_sasSalesCommission_Invoices_PaymentsList = new List<tbl_sasSalesCommission_Invoices_Payments>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Invoices_Payments tbl_sasSalesCommission_Invoices_Payments = Maketbl_sasSalesCommission_Invoices_Payments(dataReader);
					tbl_sasSalesCommission_Invoices_PaymentsList.Add(tbl_sasSalesCommission_Invoices_Payments);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_Invoices_PaymentsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission_Invoices_Payments class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission_Invoices_Payments Maketbl_sasSalesCommission_Invoices_Payments(SqlDataReader dataReader) {
			tbl_sasSalesCommission_Invoices_Payments tbl_sasSalesCommission_Invoices_Payments = new tbl_sasSalesCommission_Invoices_Payments();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission_Invoices_Payments.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission_Invoices_Payments.Commission_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission_Invoices_Payments.Invoice_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission_Invoices_Payments.InvoiceDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesCommission_Invoices_Payments.Payment_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesCommission_Invoices_Payments.PaymentDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasSalesCommission_Invoices_Payments.PaymentRemark = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasSalesCommission_Invoices_Payments.AllocationAmount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasSalesCommission_Invoices_Payments.Days = dataReader.GetInt32(8);
			}

			return tbl_sasSalesCommission_Invoices_Payments;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission_Invoices_Payments datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Invoices_Payments object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission_Invoices_Payments  tbl_sasSalesCommission_Invoices_Payments   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_invoiceDate = new DataColumn("invoiceDate" , typeof(DateTime));
			DataColumn col_payment_ID = new DataColumn("payment_ID" , typeof(string));
			DataColumn col_paymentDate = new DataColumn("paymentDate" , typeof(DateTime));
			DataColumn col_paymentRemark = new DataColumn("paymentRemark" , typeof(string));
			DataColumn col_allocationAmount = new DataColumn("allocationAmount" , typeof(decimal));
			DataColumn col_days = new DataColumn("days" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_commission_ID,col_invoice_ID,col_invoiceDate,col_payment_ID,col_paymentDate,col_paymentRemark,col_allocationAmount,col_days,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission_Invoices_Payments datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Invoices_Payments object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission_Invoices_Payments user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["commission_ID"] = user.commission_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["invoiceDate"] = user.invoiceDate;
			drow["payment_ID"] = user.payment_ID;
			drow["paymentDate"] = user.paymentDate;
			drow["paymentRemark"] = user.paymentRemark;
			drow["allocationAmount"] = user.allocationAmount;
			drow["days"] = user.days;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
