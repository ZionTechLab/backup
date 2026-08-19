using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class srh_pmsJobRegister {
		#region Fields
		private string productionJob_ID;
		private string productionJobType_ID;
		private string job_ID;
		private string customerOrder_ID;
		private string item_ID;
		private string itemName;
		private string uom_ID;
		private string uomCode;
		private string customer_ID;
		private string customerName;
		private DateTime productionOrderDate;
		private DateTime endDate;
		private bool isApproved;
		private bool isDeleted;
		private bool isJobClosed;
		private string productionJobTypeName;
		private string salesRep_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_pmsJobRegister class.
		/// </summary>
		public srh_pmsJobRegister() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_pmsJobRegister class.
		/// </summary>
		public srh_pmsJobRegister(string productionJob_ID, string productionJobType_ID, string job_ID, string customerOrder_ID, string item_ID, string itemName, string uom_ID, string uomCode, string customer_ID, string customerName, DateTime productionOrderDate, DateTime endDate, bool isApproved, bool isDeleted, bool isJobClosed, string productionJobTypeName, string salesRep_ID) {
			this.productionJob_ID = productionJob_ID;
			this.productionJobType_ID = productionJobType_ID;
			this.job_ID = job_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.item_ID = item_ID;
			this.itemName = itemName;
			this.uom_ID = uom_ID;
			this.uomCode = uomCode;
			this.customer_ID = customer_ID;
			this.customerName = customerName;
			this.productionOrderDate = productionOrderDate;
			this.endDate = endDate;
			this.isApproved = isApproved;
			this.isDeleted = isDeleted;
			this.isJobClosed = isJobClosed;
			this.productionJobTypeName = productionJobTypeName;
			this.salesRep_ID = salesRep_ID;
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
		/// Gets or sets the ProductionJobType_ID value.
		/// </summary>
		public string ProductionJobType_ID {
			get { return productionJobType_ID; }
			set { productionJobType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomCode value.
		/// </summary>
		public string UomCode {
			get { return uomCode; }
			set { uomCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionOrderDate value.
		/// </summary>
		public DateTime ProductionOrderDate {
			get { return productionOrderDate; }
			set { productionOrderDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndDate value.
		/// </summary>
		public DateTime EndDate {
			get { return endDate; }
			set { endDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobClosed value.
		/// </summary>
		public bool IsJobClosed {
			get { return isJobClosed; }
			set { isJobClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJobTypeName value.
		/// </summary>
		public string ProductionJobTypeName {
			get { return productionJobTypeName; }
			set { productionJobTypeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesRep_ID value.
		/// </summary>
		public string SalesRep_ID {
			get { return salesRep_ID; }
			set { salesRep_ID = value; }
		}
		#endregion
		
		#region Methods
	
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_pmsJobRegisterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uomCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@productionOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@productionJobTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uomCode"].Value = uomCode;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@productionOrderDate"].Value = productionOrderDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@productionJobTypeName"].Value = productionJobTypeName;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        #region ***********Select Metherds********
        public static List<srh_pmsJobRegister> SelectAll_ByJobDate(DateTime dtmdateFrom, DateTime dtmEndDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_PMS_ProductionJobRegisterSellectAll_byJobDate", scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<srh_pmsJobRegister> srh_pmsJobRegisterList = new List<srh_pmsJobRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_pmsJobRegister srh_pmsJobRegister = Makesrh_pmsJobRegister(dataReader);
                    srh_pmsJobRegisterList.Add(srh_pmsJobRegister);
                }
            }
            scon.Close();
            return srh_pmsJobRegisterList;
        }
        public static List<srh_pmsJobRegister> SelectAll_ByDeliveryDate(DateTime dtmdateFrom, DateTime dtmEndDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_PMS_ProductionJobRegisterSellectAll_byDeliveryDate", scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<srh_pmsJobRegister> srh_pmsJobRegisterList = new List<srh_pmsJobRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_pmsJobRegister srh_pmsJobRegister = Makesrh_pmsJobRegister(dataReader);
                    srh_pmsJobRegisterList.Add(srh_pmsJobRegister);
                }
            }
            scon.Close();
            return srh_pmsJobRegisterList;
        }
        public static List<srh_pmsJobRegister> SelectAll_ByApprovedDate(DateTime dtmdateFrom, DateTime dtmEndDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_PMS_ProductionJobRegisterSellectAll_byApprovedDate", scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<srh_pmsJobRegister> srh_pmsJobRegisterList = new List<srh_pmsJobRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_pmsJobRegister srh_pmsJobRegister = Makesrh_pmsJobRegister(dataReader);
                    srh_pmsJobRegisterList.Add(srh_pmsJobRegister);
                }
            }
            scon.Close();
            return srh_pmsJobRegisterList;
        }
        #endregion
        

        private static srh_pmsJobRegister Makesrh_pmsJobRegister(SqlDataReader dataReader) {
			srh_pmsJobRegister srh_pmsJobRegister = new srh_pmsJobRegister();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_pmsJobRegister.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_pmsJobRegister.ProductionJobType_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_pmsJobRegister.Job_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_pmsJobRegister.CustomerOrder_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_pmsJobRegister.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_pmsJobRegister.ItemName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_pmsJobRegister.Uom_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_pmsJobRegister.UomCode = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_pmsJobRegister.Customer_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_pmsJobRegister.CustomerName = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_pmsJobRegister.ProductionOrderDate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_pmsJobRegister.EndDate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_pmsJobRegister.IsApproved = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				srh_pmsJobRegister.IsDeleted = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				srh_pmsJobRegister.IsJobClosed = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				srh_pmsJobRegister.ProductionJobTypeName = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				srh_pmsJobRegister.SalesRep_ID = dataReader.GetString(16);
			}

			return srh_pmsJobRegister;
		}		
		public static DataTable CreateDataTable( srh_pmsJobRegister  srh_pmsJobRegister   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_productionJobType_ID = new DataColumn("productionJobType_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_uomCode = new DataColumn("uomCode" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_productionOrderDate = new DataColumn("productionOrderDate" , typeof(DateTime));
			DataColumn col_endDate = new DataColumn("endDate" , typeof(DateTime));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isJobClosed = new DataColumn("isJobClosed" , typeof(bool));
			DataColumn col_productionJobTypeName = new DataColumn("productionJobTypeName" , typeof(string));
			DataColumn col_salesRep_ID = new DataColumn("salesRep_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_productionJob_ID,col_productionJobType_ID,col_job_ID,col_customerOrder_ID,col_item_ID,col_itemName,col_uom_ID,col_uomCode,col_customer_ID,col_customerName,col_productionOrderDate,col_endDate,col_isApproved,col_isDeleted,col_isJobClosed,col_productionJobTypeName,col_salesRep_ID,});		return dt;
		}
	
		public static void FillData(DataTable dt, srh_pmsJobRegister user) {
		DataRow drow = dt.NewRow();
		
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["productionJobType_ID"] = user.productionJobType_ID;
			drow["job_ID"] = user.job_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemName"] = user.itemName;
			drow["uom_ID"] = user.uom_ID;
			drow["uomCode"] = user.uomCode;
			drow["customer_ID"] = user.customer_ID;
			drow["customerName"] = user.customerName;
			drow["productionOrderDate"] = user.productionOrderDate;
			drow["endDate"] = user.endDate;
			drow["isApproved"] = user.isApproved;
			drow["isDeleted"] = user.isDeleted;
			drow["isJobClosed"] = user.isJobClosed;
			drow["productionJobTypeName"] = user.productionJobTypeName;
			drow["salesRep_ID"] = user.salesRep_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
