using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_pmsProductionAnalysis_FinishedGoodWeightWise {
		#region Fields
		private string productionJob_ID;
		private string customer_ID;
		private string customerName;
		private string item_ID;
		private string itemName;
		private DateTime shaduleDate;
		private decimal weighOut;
		private decimal jobWeight;
		private decimal jobQty;
		private string customerOrder_ID;
		private DateTime productionOrderDate;
		private decimal length;
		private string item_ID_Output;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_PMSProductionAnalysis_FinishedGoodWeightWise class.
		/// </summary>
		public srh_pmsProductionAnalysis_FinishedGoodWeightWise() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_PMSProductionAnalysis_FinishedGoodWeightWise class.
		/// </summary>
		public srh_pmsProductionAnalysis_FinishedGoodWeightWise(string productionJob_ID, string customer_ID, string customerName, string item_ID, string itemName, DateTime shaduleDate, decimal weighOut, decimal jobWeight, decimal jobQty, string customerOrder_ID, DateTime productionOrderDate, decimal length, string item_ID_Output) {
			this.productionJob_ID = productionJob_ID;
			this.customer_ID = customer_ID;
			this.customerName = customerName;
			this.item_ID = item_ID;
			this.itemName = itemName;
			this.shaduleDate = shaduleDate;
			this.weighOut = weighOut;
			this.jobWeight = jobWeight;
			this.jobQty = jobQty;
			this.customerOrder_ID = customerOrder_ID;
			this.productionOrderDate = productionOrderDate;
			this.length = length;
			this.item_ID_Output = item_ID_Output;
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
		/// Gets or sets the ShaduleDate value.
		/// </summary>
		public DateTime ShaduleDate {
			get { return shaduleDate; }
			set { shaduleDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeighOut value.
		/// </summary>
		public decimal WeighOut {
			get { return weighOut; }
			set { weighOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobWeight value.
		/// </summary>
		public decimal JobWeight {
			get { return jobWeight; }
			set { jobWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobQty value.
		/// </summary>
		public decimal JobQty {
			get { return jobQty; }
			set { jobQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionOrderDate value.
		/// </summary>
		public DateTime ProductionOrderDate {
			get { return productionOrderDate; }
			set { productionOrderDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public decimal Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID_Output value.
		/// </summary>
		public string Item_ID_Output {
			get { return item_ID_Output; }
			set { item_ID_Output = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the srh_PMSProductionAnalysis_FinishedGoodWeightWise table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_PMSProductionAnalysis_FinishedGoodWeightWiseInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@shaduleDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@weighOut", SqlDbType.Decimal,9);
			scom.Parameters.Add("@jobWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@JobQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Item_ID_Output", SqlDbType.VarChar,20);
 
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@shaduleDate"].Value = shaduleDate;
			scom.Parameters["@weighOut"].Value = weighOut;
			scom.Parameters["@jobWeight"].Value = jobWeight;
			scom.Parameters["@JobQty"].Value = jobQty;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@productionOrderDate"].Value = productionOrderDate;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@Item_ID_Output"].Value = item_ID_Output;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the srh_PMSProductionAnalysis_FinishedGoodWeightWise table.
		/// </summary>
        public static List<srh_pmsProductionAnalysis_FinishedGoodWeightWise> SelectAll(DateTime dtmdateFrom, DateTime dtmEndDate)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_PMSProductionAnalysis_FinishedGoodWeightWiseSelectAll", scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<srh_pmsProductionAnalysis_FinishedGoodWeightWise> srh_PMSProductionAnalysis_FinishedGoodWeightWiseList = new List<srh_pmsProductionAnalysis_FinishedGoodWeightWise>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_pmsProductionAnalysis_FinishedGoodWeightWise srh_PMSProductionAnalysis_FinishedGoodWeightWise = Makesrh_PMSProductionAnalysis_FinishedGoodWeightWise(dataReader);
					srh_PMSProductionAnalysis_FinishedGoodWeightWiseList.Add(srh_PMSProductionAnalysis_FinishedGoodWeightWise);
				}
			}
			scon.Close();
			return srh_PMSProductionAnalysis_FinishedGoodWeightWiseList;
		}
		
		/// <summary>
		/// Creates a new instance of the srh_PMSProductionAnalysis_FinishedGoodWeightWise class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_pmsProductionAnalysis_FinishedGoodWeightWise Makesrh_PMSProductionAnalysis_FinishedGoodWeightWise(SqlDataReader dataReader) {
			srh_pmsProductionAnalysis_FinishedGoodWeightWise srh_PMSProductionAnalysis_FinishedGoodWeightWise = new srh_pmsProductionAnalysis_FinishedGoodWeightWise();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.Customer_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.CustomerName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.ItemName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.ShaduleDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.WeighOut = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.JobWeight = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.JobQty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.CustomerOrder_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.ProductionOrderDate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.Length = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_PMSProductionAnalysis_FinishedGoodWeightWise.Item_ID_Output = dataReader.GetString(12);
			}

			return srh_PMSProductionAnalysis_FinishedGoodWeightWise;
		}
		/// <summary>
		/// This makes srh_PMSProductionAnalysis_FinishedGoodWeightWise datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new srh_PMSProductionAnalysis_FinishedGoodWeightWise object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( srh_pmsProductionAnalysis_FinishedGoodWeightWise  srh_PMSProductionAnalysis_FinishedGoodWeightWise   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_shaduleDate = new DataColumn("shaduleDate" , typeof(DateTime));
			DataColumn col_weighOut = new DataColumn("weighOut" , typeof(decimal));
			DataColumn col_jobWeight = new DataColumn("jobWeight" , typeof(decimal));
			DataColumn col_JobQty = new DataColumn("JobQty" , typeof(decimal));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_productionOrderDate = new DataColumn("productionOrderDate" , typeof(DateTime));
			DataColumn col_length = new DataColumn("length" , typeof(decimal));
			DataColumn col_Item_ID_Output = new DataColumn("Item_ID_Output" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_productionJob_ID,col_customer_ID,col_customerName,col_item_ID,col_itemName,col_shaduleDate,col_weighOut,col_jobWeight,col_JobQty,col_customerOrder_ID,col_productionOrderDate,col_length,col_Item_ID_Output,});		return dt;
		}
		/// <summary>
		/// This fills srh_PMSProductionAnalysis_FinishedGoodWeightWise datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new srh_PMSProductionAnalysis_FinishedGoodWeightWise object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, srh_pmsProductionAnalysis_FinishedGoodWeightWise user) {
		DataRow drow = dt.NewRow();
		
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["customerName"] = user.customerName;
			drow["item_ID"] = user.item_ID;
			drow["itemName"] = user.itemName;
			drow["shaduleDate"] = user.shaduleDate;
			drow["weighOut"] = user.weighOut;
			drow["jobWeight"] = user.jobWeight;
			drow["JobQty"] = user.JobQty;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["productionOrderDate"] = user.productionOrderDate;
			drow["length"] = user.length;
			drow["Item_ID_Output"] = user.Item_ID_Output;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
