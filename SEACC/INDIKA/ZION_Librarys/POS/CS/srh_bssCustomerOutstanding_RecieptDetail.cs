using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class srh_bssCustomerOutstanding_RecieptDetail
    {
		#region Fields
		private string invoice_ID;
		private DateTime invoiceDate;
		private string deliveryOrder_ID;
		private string purchaseOrder_ID;
		private string currencyCode;
		private decimal currencyRate;
		private decimal grandTotal;
		private int age;
		private string receipt_ID;
		private decimal sattledAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_bssCustomerOutstanding_RecieptDetail class.
		/// </summary>
		public srh_bssCustomerOutstanding_RecieptDetail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_bssCustomerOutstanding_RecieptDetail class.
		/// </summary>
		public srh_bssCustomerOutstanding_RecieptDetail(string invoice_ID, DateTime invoiceDate, string deliveryOrder_ID, string purchaseOrder_ID, string currencyCode, decimal currencyRate, decimal grandTotal, int age, string receipt_ID, decimal sattledAmount) {
			this.invoice_ID = invoice_ID;
			this.invoiceDate = invoiceDate;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.currencyCode = currencyCode;
			this.currencyRate = currencyRate;
			this.grandTotal = grandTotal;
			this.age = age;
			this.receipt_ID = receipt_ID;
			this.sattledAmount = sattledAmount;
		}
		#endregion
		
		#region Properties
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
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseOrder_ID value.
		/// </summary>
		public string PurchaseOrder_ID {
			get { return purchaseOrder_ID; }
			set { purchaseOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyCode value.
		/// </summary>
		public string CurrencyCode {
			get { return currencyCode; }
			set { currencyCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyRate value.
		/// </summary>
		public decimal CurrencyRate {
			get { return currencyRate; }
			set { currencyRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public decimal GrandTotal {
			get { return grandTotal; }
			set { grandTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the Age value.
		/// </summary>
		public int Age {
			get { return age; }
			set { age = value; }
		}
		
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SattledAmount value.
		/// </summary>
		public decimal SattledAmount {
			get { return sattledAmount; }
			set { sattledAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Selects all records from the srh_bssCustomerOutstanding_RecieptDetail table.
		/// </summary>
        public static List<srh_bssCustomerOutstanding_RecieptDetail> SelectAll(string chequeRegister_ID, DateTime toDate)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_bssCustomerOutstanding_RecieptDetailSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@toDate", SqlDbType.DateTime);

            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@toDate"].Value = toDate;

            List<srh_bssCustomerOutstanding_RecieptDetail> srh_bssCustomerOutstanding_RecieptDetailList = new List<srh_bssCustomerOutstanding_RecieptDetail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_bssCustomerOutstanding_RecieptDetail srh_bssCustomerOutstanding_RecieptDetail = Makesrh_bssCustomerOutstanding_RecieptDetail(dataReader);
                    srh_bssCustomerOutstanding_RecieptDetailList.Add(srh_bssCustomerOutstanding_RecieptDetail);
                }
            }
            scon.Close();
            return srh_bssCustomerOutstanding_RecieptDetailList;
        }
		
		/// <summary>
		/// Creates a new instance of the srh_bssCustomerOutstanding_RecieptDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_bssCustomerOutstanding_RecieptDetail Makesrh_bssCustomerOutstanding_RecieptDetail(SqlDataReader dataReader) {
			srh_bssCustomerOutstanding_RecieptDetail srh_bssCustomerOutstanding_RecieptDetail = new srh_bssCustomerOutstanding_RecieptDetail();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.Invoice_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.InvoiceDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.DeliveryOrder_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.PurchaseOrder_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.CurrencyCode = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.CurrencyRate = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.GrandTotal = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.Age = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.Receipt_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_bssCustomerOutstanding_RecieptDetail.SattledAmount = dataReader.GetDecimal(9);
			}

			return srh_bssCustomerOutstanding_RecieptDetail;
		}
		/// <summary>
		/// This makes srh_bssCustomerOutstanding_RecieptDetail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new srh_bssCustomerOutstanding_RecieptDetail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( srh_bssCustomerOutstanding_RecieptDetail  srh_bssCustomerOutstanding_RecieptDetail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_invoiceDate = new DataColumn("invoiceDate" , typeof(DateTime));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_PurchaseOrder_ID = new DataColumn("PurchaseOrder_ID" , typeof(string));
			DataColumn col_currencyCode = new DataColumn("currencyCode" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_age = new DataColumn("age" , typeof(int));
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_sattledAmount = new DataColumn("sattledAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_invoice_ID,col_invoiceDate,col_deliveryOrder_ID,col_PurchaseOrder_ID,col_currencyCode,col_currencyRate,col_grandTotal,col_age,col_receipt_ID,col_sattledAmount,});		return dt;
		}
		/// <summary>
		/// This fills srh_bssCustomerOutstanding_RecieptDetail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new srh_bssCustomerOutstanding_RecieptDetail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, srh_bssCustomerOutstanding_RecieptDetail user) {
		DataRow drow = dt.NewRow();
		
			drow["invoice_ID"] = user.invoice_ID;
			drow["invoiceDate"] = user.invoiceDate;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["PurchaseOrder_ID"] = user.PurchaseOrder_ID;
			drow["currencyCode"] = user.currencyCode;
			drow["currencyRate"] = user.currencyRate;
			drow["grandTotal"] = user.grandTotal;
			drow["age"] = user.age;
			drow["receipt_ID"] = user.receipt_ID;
			drow["sattledAmount"] = user.sattledAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
