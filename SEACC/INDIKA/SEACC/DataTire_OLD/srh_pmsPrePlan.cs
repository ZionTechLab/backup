using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_pmsPrePlan {
		#region Fields
		private string productionJob_ID;
		private DateTime productionOrderDate;
		private string prePlan_ID;
		private DateTime prePlanDate;
		private string customerName;
		private string sectionName;
		private string machineName;
		private int line_NoOutput;
		private int line_No;
		private string section_ID;
		private string item_ID;
		private decimal qty;
		private decimal weight;
		private string uom_ID;
        private string machine_ID;
        private decimal sectioncapacity;
        private decimal labourBudgetedCost;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the srh_pmsPrePlan class.
        /// </summary>
        public srh_pmsPrePlan() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_pmsPrePlan class.
		/// </summary>
		public srh_pmsPrePlan(string productionJob_ID, DateTime productionOrderDate, string prePlan_ID, DateTime prePlanDate, string customerName, string sectionName, string machineName, int line_NoOutput, int line_No, string section_ID, string item_ID, decimal qty, decimal weight, string uom_ID) {
			this.productionJob_ID = productionJob_ID;
			this.productionOrderDate = productionOrderDate;
			this.prePlan_ID = prePlan_ID;
			this.prePlanDate = prePlanDate;
			this.customerName = customerName;
			this.sectionName = sectionName;
			this.machineName = machineName;
			this.line_NoOutput = line_NoOutput;
			this.line_No = line_No;
			this.section_ID = section_ID;
			this.item_ID = item_ID;
			this.qty = qty;
			this.weight = weight;
			this.uom_ID = uom_ID;
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
		/// Gets or sets the ProductionOrderDate value.
		/// </summary>
		public DateTime ProductionOrderDate {
			get { return productionOrderDate; }
			set { productionOrderDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlanDate value.
		/// </summary>
		public DateTime PrePlanDate {
			get { return prePlanDate; }
			set { prePlanDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionName value.
		/// </summary>
		public string SectionName {
			get { return sectionName; }
			set { sectionName = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineName value.
		/// </summary>
		public string MachineName {
			get { return machineName; }
			set { machineName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_NoOutput value.
		/// </summary>
		public int Line_NoOutput {
			get { return line_NoOutput; }
			set { line_NoOutput = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
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
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
        /// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID
        {
            get { return machine_ID; }
            set { machine_ID = value; }
        }
        /// <summary>
		/// Gets or sets the Sectioncapacity value.
		/// </summary>
		public decimal Sectioncapacity
        {
            get { return sectioncapacity; }
            set { sectioncapacity = value; }
        }
        /// <summary>
		/// Gets or sets the LabourBudgetedCost value.
		/// </summary>
		public decimal LabourBudgetedCost
        {
            get { return labourBudgetedCost; }
            set { labourBudgetedCost = value; }
        }
        #endregion

        #region Methods		

		
		/// <summary>
		/// Selects all records from the srh_pmsPrePlan table.
		/// </summary>
		public static List<srh_pmsPrePlan> SelectAllByJobDate(DateTime dtmdateFrom, DateTime dtmEndDate) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_pmsPrePlanSelectAll_byJobDate", scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
            scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<srh_pmsPrePlan> srh_pmsPrePlanList = new List<srh_pmsPrePlan>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_pmsPrePlan srh_pmsPrePlan = Makesrh_pmsPrePlan(dataReader);
					srh_pmsPrePlanList.Add(srh_pmsPrePlan);
				}
			}
			scon.Close();
			return srh_pmsPrePlanList;
		}
        /// <summary>
        /// Selects all records from the srh_pmsPrePlan table.
        /// </summary>
        public static List<srh_pmsPrePlan> SelectAll_Inputs_ByPrePlanDate(DateTime dtmdateFrom, DateTime dtmEndDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_pmsPrePlanSelectAll_Inputs_byPrePlanDate", scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<srh_pmsPrePlan> srh_pmsPrePlanList = new List<srh_pmsPrePlan>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_pmsPrePlan srh_pmsPrePlan = Makesrh_pmsPrePlan(dataReader);
                    srh_pmsPrePlanList.Add(srh_pmsPrePlan);
                }
            }
            scon.Close();
            return srh_pmsPrePlanList;
        }

        /// <summary>
        /// Selects all records from the srh_pmsPrePlan table.
        /// </summary>
        public static List<srh_pmsPrePlan> SelectAll_Inputs_ByProductionPrePlanDate(DateTime dtmdateFrom, DateTime dtmEndDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_pmsPrePlanSelectAll_Inputs_byProductionPrePlanDate", scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<srh_pmsPrePlan> srh_pmsPrePlanList = new List<srh_pmsPrePlan>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_pmsPrePlan srh_pmsPrePlan = Makesrh_pmsPrePlan(dataReader);
                    srh_pmsPrePlanList.Add(srh_pmsPrePlan);
                }
            }
            scon.Close();
            return srh_pmsPrePlanList;
        }

        /// <summary>
        /// Creates a new instance of the srh_pmsPrePlan class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static srh_pmsPrePlan Makesrh_pmsPrePlan(SqlDataReader dataReader) {
			srh_pmsPrePlan srh_pmsPrePlan = new srh_pmsPrePlan();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_pmsPrePlan.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_pmsPrePlan.ProductionOrderDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_pmsPrePlan.PrePlan_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_pmsPrePlan.PrePlanDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_pmsPrePlan.CustomerName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_pmsPrePlan.SectionName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_pmsPrePlan.MachineName = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_pmsPrePlan.Line_NoOutput = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_pmsPrePlan.Line_No = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_pmsPrePlan.Section_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_pmsPrePlan.Item_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_pmsPrePlan.Qty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_pmsPrePlan.Weight = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				srh_pmsPrePlan.Uom_ID = dataReader.GetString(13);
			}
            if (dataReader.IsDBNull(14) == false)
            {
                srh_pmsPrePlan.Machine_ID = dataReader.GetString(14);
            }
            if (dataReader.IsDBNull(15) == false)
            {
                srh_pmsPrePlan.sectioncapacity = dataReader.GetDecimal(15);
            }
            if (dataReader.IsDBNull(16) == false)
            {
                srh_pmsPrePlan.LabourBudgetedCost = dataReader.GetDecimal(16);
            }
            return srh_pmsPrePlan;
		}
		
		#endregion
	}
}
