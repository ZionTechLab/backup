using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_pmsDailyProductuinJobApproved {
		#region Fields
		private string productionJob_ID;
		private DateTime date;
		private string purchaseOrder_ID;
		private string customerName;
		private string itemName;
		private decimal qty;
		private decimal weight;
		private decimal unitPrice;
		private decimal grandTotal;
		private DateTime deliveryDate;
		private string uomCode;
		private string productionJobTypeName;
		private string customer_ID;
		private string job_ID;
        private string itemID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_pmsDailyProductuinJobApproved class.
		/// </summary>
		public srh_pmsDailyProductuinJobApproved() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_pmsDailyProductuinJobApproved class.
		/// </summary>
		public srh_pmsDailyProductuinJobApproved(string productionJob_ID, DateTime date, string purchaseOrder_ID, string customerName, string itemName, decimal qty, decimal weight, decimal unitPrice, decimal grandTotal, DateTime deliveryDate, string uomCode, string productionJobTypeName, string customer_ID, string job_ID) {
			this.productionJob_ID = productionJob_ID;
			this.date = date;
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.customerName = customerName;
			this.itemName = itemName;
			this.qty = qty;
			this.weight = weight;
			this.unitPrice = unitPrice;
			this.grandTotal = grandTotal;
			this.deliveryDate = deliveryDate;
			this.uomCode = uomCode;
			this.productionJobTypeName = productionJobTypeName;
			this.customer_ID = customer_ID;
			this.job_ID = job_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime Date {
			get { return date; }
			set { date = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseOrder_ID value.
		/// </summary>
		public string PurchaseOrder_ID {
			get { return purchaseOrder_ID; }
			set { purchaseOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public decimal GrandTotal {
			get { return grandTotal; }
			set { grandTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryDate value.
		/// </summary>
		public DateTime DeliveryDate {
			get { return deliveryDate; }
			set { deliveryDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomCode value.
		/// </summary>
		public string UomCode {
			get { return uomCode; }
			set { uomCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJobTypeName value.
		/// </summary>
		public string ProductionJobTypeName {
			get { return productionJobTypeName; }
			set { productionJobTypeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
		#endregion		

		#region Methods

		/// <summary>
		/// Selects all records from the srh_pmsDailyProductuinJobApproved table.
		/// </summary>
        public static List<srh_pmsDailyProductuinJobApproved> SelectAll(DateTime dtmdateFrom, DateTime dtmEndDate, bool isApprovedJobsOnly)
        {
            string sSpName = isApprovedJobsOnly ? "srh_PMS_DailyProductuinJobApproved" : "srh_PMS_DailyProductuinJobAll";

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand(sSpName, scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<srh_pmsDailyProductuinJobApproved> srh_pmsDailyProductuinJobApprovedList = new List<srh_pmsDailyProductuinJobApproved>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_pmsDailyProductuinJobApproved srh_pmsDailyProductuinJobApproved = Makesrh_pmsDailyProductuinJobApproved(dataReader);
                    srh_pmsDailyProductuinJobApprovedList.Add(srh_pmsDailyProductuinJobApproved);
                }
            }
            scon.Close();
            return srh_pmsDailyProductuinJobApprovedList;
        }
		
		/// <summary>
		/// Creates a new instance of the srh_pmsDailyProductuinJobApproved class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_pmsDailyProductuinJobApproved Makesrh_pmsDailyProductuinJobApproved(SqlDataReader dataReader) {
			srh_pmsDailyProductuinJobApproved srh_pmsDailyProductuinJobApproved = new srh_pmsDailyProductuinJobApproved();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_pmsDailyProductuinJobApproved.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_pmsDailyProductuinJobApproved.Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_pmsDailyProductuinJobApproved.PurchaseOrder_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_pmsDailyProductuinJobApproved.CustomerName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_pmsDailyProductuinJobApproved.ItemName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_pmsDailyProductuinJobApproved.Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_pmsDailyProductuinJobApproved.Weight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_pmsDailyProductuinJobApproved.UnitPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_pmsDailyProductuinJobApproved.GrandTotal = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_pmsDailyProductuinJobApproved.DeliveryDate = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_pmsDailyProductuinJobApproved.UomCode = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_pmsDailyProductuinJobApproved.ProductionJobTypeName = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_pmsDailyProductuinJobApproved.Customer_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				srh_pmsDailyProductuinJobApproved.Job_ID = dataReader.GetString(13);
			}
            if (dataReader.IsDBNull(14) == false)
            {
                srh_pmsDailyProductuinJobApproved.ItemID = dataReader.GetString(14);
            }

			return srh_pmsDailyProductuinJobApproved;
		}
		/// <summary>
		/// This makes srh_pmsDailyProductuinJobApproved datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new srh_pmsDailyProductuinJobApproved object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( srh_pmsDailyProductuinJobApproved  srh_pmsDailyProductuinJobApproved   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_purchaseOrder_ID = new DataColumn("purchaseOrder_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_deliveryDate = new DataColumn("deliveryDate" , typeof(DateTime));
			DataColumn col_uomCode = new DataColumn("uomCode" , typeof(string));
			DataColumn col_productionJobTypeName = new DataColumn("productionJobTypeName" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_productionJob_ID,col_dateApproved,col_purchaseOrder_ID,col_customerName,col_itemName,col_qty,col_weight,col_unitPrice,col_grandTotal,col_deliveryDate,col_uomCode,col_productionJobTypeName,col_customer_ID,col_job_ID,});		return dt;
		}
		/// <summary>
		/// This fills srh_pmsDailyProductuinJobApproved datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new srh_pmsDailyProductuinJobApproved object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, srh_pmsDailyProductuinJobApproved user) {
		DataRow drow = dt.NewRow();
		
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["dateApproved"] = user.date;
			drow["purchaseOrder_ID"] = user.purchaseOrder_ID;
			drow["customerName"] = user.customerName;
			drow["itemName"] = user.itemName;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["unitPrice"] = user.unitPrice;
			drow["grandTotal"] = user.grandTotal;
			drow["deliveryDate"] = user.deliveryDate;
			drow["uomCode"] = user.uomCode;
			drow["productionJobTypeName"] = user.productionJobTypeName;
			drow["customer_ID"] = user.customer_ID;
			drow["job_ID"] = user.job_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
