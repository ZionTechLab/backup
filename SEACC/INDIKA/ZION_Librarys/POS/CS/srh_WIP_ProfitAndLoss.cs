using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_WIP_ProfitAndLoss {
		#region Fields
		private string productionJob_ID;
		private string workInProgress_ID;
		private DateTime productionOrderDate;
		private string item_ID;
		private string itemName;
		private bool isQty;
		private bool isWeight;
		private bool isLength;
		private string customer_ID;
		private string customerName;
		private decimal qty;
		private decimal weight;
        private string salesRep_ID;
        private decimal unitPrice;       
        private decimal weightPrice;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_WIP_ProfitAndLoss class.
		/// </summary>
		public srh_WIP_ProfitAndLoss() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_WIP_ProfitAndLoss class.
		/// </summary>
        public srh_WIP_ProfitAndLoss(string productionJob_ID, string workInProgress_ID, DateTime productionOrderDate, string item_ID, string itemName, bool isQty, bool isWeight, bool isLength, string customer_ID, string customerName, decimal qty, decimal weight, string salesRep_ID, decimal unitPrice, decimal weightPrice)
        {
			this.productionJob_ID = productionJob_ID;
			this.workInProgress_ID = workInProgress_ID;
			this.productionOrderDate = productionOrderDate;
			this.item_ID = item_ID;
			this.itemName = itemName;
			this.isQty = isQty;
			this.isWeight = isWeight;
			this.isLength = isLength;
			this.customer_ID = customer_ID;
			this.customerName = customerName;
			this.qty = qty;
			this.weight = weight;
            this.salesRep_ID = salesRep_ID;
            this.unitPrice = unitPrice;
            this.weightPrice = weightPrice;
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
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionOrderDate value.
		/// </summary>
		public DateTime ProductionOrderDate {
			get { return productionOrderDate; }
			set { productionOrderDate = value; }
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
		/// Gets or sets the IsQty value.
		/// </summary>
		public bool IsQty {
			get { return isQty; }
			set { isQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeight value.
		/// </summary>
		public bool IsWeight {
			get { return isWeight; }
			set { isWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLength value.
		/// </summary>
		public bool IsLength {
			get { return isLength; }
			set { isLength = value; }
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
        /// Gets or sets the SalesRep_ID value.
        /// </summary>
        public string SalesRep_ID
        {
            get { return salesRep_ID; }
            set { salesRep_ID = value; }
        }
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public decimal WeightPrice
        {
            get { return weightPrice; }
            set { weightPrice = value; }
        }
		#endregion

		#region Methods
        /// <summary>
        /// Selects a single record from the srh_WIP_ProfitAndLoss table.
        /// </summary>
        public static srh_WIP_ProfitAndLoss Select(string productionJob_ID_Incoming)
        {

            srh_WIP_ProfitAndLoss srh_WIP_ProfitAndLossins = new srh_WIP_ProfitAndLoss();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_WIP_ProfitAndLossSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@productionJob_ID"].Value = productionJob_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    srh_WIP_ProfitAndLossins = Makesrh_WIP_ProfitAndLoss(dataReader);
                }
                else
                {
                    srh_WIP_ProfitAndLossins = null;
                }
            }
            scon.Close();
            return srh_WIP_ProfitAndLossins;
        }
		
		/// <summary>
		/// Selects all records from the srh_WIP_ProfitAndLoss table.
		/// </summary>
        public static List<srh_WIP_ProfitAndLoss> SelectAll(DateTime dateFrom, DateTime dateTo)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_WIP_ProfitAndLossSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
            List<srh_WIP_ProfitAndLoss> srh_WIP_ProfitAndLossList = new List<srh_WIP_ProfitAndLoss>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_WIP_ProfitAndLoss srh_WIP_ProfitAndLoss = Makesrh_WIP_ProfitAndLoss(dataReader);
                    srh_WIP_ProfitAndLossList.Add(srh_WIP_ProfitAndLoss);
                }
            }
            scon.Close();
            return srh_WIP_ProfitAndLossList;
        }
		
		/// <summary>
		/// Creates a new instance of the srh_WIP_ProfitAndLoss class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_WIP_ProfitAndLoss Makesrh_WIP_ProfitAndLoss(SqlDataReader dataReader) {
			srh_WIP_ProfitAndLoss srh_WIP_ProfitAndLoss = new srh_WIP_ProfitAndLoss();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_WIP_ProfitAndLoss.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_WIP_ProfitAndLoss.WorkInProgress_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_WIP_ProfitAndLoss.ProductionOrderDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_WIP_ProfitAndLoss.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_WIP_ProfitAndLoss.ItemName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_WIP_ProfitAndLoss.IsQty = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_WIP_ProfitAndLoss.IsWeight = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_WIP_ProfitAndLoss.IsLength = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_WIP_ProfitAndLoss.Customer_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_WIP_ProfitAndLoss.CustomerName = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_WIP_ProfitAndLoss.Qty = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_WIP_ProfitAndLoss.Weight = dataReader.GetDecimal(11);
			}
            if (dataReader.IsDBNull(12) == false)
            {
                srh_WIP_ProfitAndLoss.SalesRep_ID = dataReader.GetString(12);
            }
            if (dataReader.IsDBNull(13) == false)
            {
                srh_WIP_ProfitAndLoss.UnitPrice = dataReader.GetDecimal(13);
            }
            if (dataReader.IsDBNull(14) == false)
            {
                srh_WIP_ProfitAndLoss.weightPrice = dataReader.GetDecimal(14);
            }
			return srh_WIP_ProfitAndLoss;
		}		
		#endregion
	}
}
