using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_WIP_ProductionAndWasteage {
		#region Fields
		private int line_No;
		private string machine_ID;
		private string machineName;
		private DateTime dateStart;
        private DateTime dateEnd;
		private decimal weightFinished;
		private decimal weightWasteage;
		private decimal weighOut;
		private decimal cylinderSize;
		private decimal counter;
		private int section_line_No;
		private string section_ID;
		private string sectionName;
		private string productionJob_ID;
		private string workInProgress_ID;
		private decimal length;
		private decimal qty;
        private string outItemID;
        private string outItemName;
        private string finishedGoodItemID;
        private int line_NoShedule;
        private int wIP_LineNo;
        private string prePlan_ID;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the srh_WIP_ProductionAndWasteage class.
        /// </summary>
        public srh_WIP_ProductionAndWasteage() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_WIP_ProductionAndWasteage class.
		/// </summary>
        public srh_WIP_ProductionAndWasteage(int line_No, string machine_ID, string machineName, DateTime dateStart, DateTime dateEnd, decimal weightFinished, decimal weightWasteage, decimal weighOut, decimal cylinderSize, decimal counter, int section_line_No, string section_ID, string sectionName, string productionJob_ID,
            string workInProgress_ID, decimal length, decimal qty, string outItemID, string outItemName, string finishedGoodItemID)
        {
			this.line_No = line_No;
			this.machine_ID = machine_ID;
			this.machineName = machineName;
			this.dateStart = dateStart;
            this.dateEnd = dateEnd;
			this.weightFinished = weightFinished;
			this.weightWasteage = weightWasteage;
			this.weighOut = weighOut;
			this.cylinderSize = cylinderSize;
			this.counter = counter;
			this.section_line_No = section_line_No;
			this.section_ID = section_ID;
			this.sectionName = sectionName;
			this.productionJob_ID = productionJob_ID;
			this.workInProgress_ID = workInProgress_ID;
			this.length = length;
			this.qty = qty;
            this.outItemID = outItemID;
            this.outItemName = outItemName;
            this.finishedGoodItemID = finishedGoodItemID;
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
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineName value.
		/// </summary>
		public string MachineName {
			get { return machineName; }
			set { machineName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateStart value.
		/// </summary>
		public DateTime DateStart {
			get { return dateStart; }
			set { dateStart = value; }
		}

        /// <summary>
        /// Gets or sets the DateStart value.
        /// </summary>
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

		/// <summary>
		/// Gets or sets the WeightFinished value.
		/// </summary>
		public decimal WeightFinished {
			get { return weightFinished; }
			set { weightFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightWasteage value.
		/// </summary>
		public decimal WeightWasteage {
			get { return weightWasteage; }
			set { weightWasteage = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeighOut value.
		/// </summary>
		public decimal WeighOut {
			get { return weighOut; }
			set { weighOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the CylinderSize value.
		/// </summary>
		public decimal CylinderSize {
			get { return cylinderSize; }
			set { cylinderSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public decimal Counter {
			get { return counter; }
			set { counter = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_line_No value.
		/// </summary>
		public int Section_line_No {
			get { return section_line_No; }
			set { section_line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionName value.
		/// </summary>
		public string SectionName {
			get { return sectionName; }
			set { sectionName = value; }
		}
		
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
		/// Gets or sets the Length value.
		/// </summary>
		public decimal Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}

        /// <summary>
        /// Gets or sets the OutItemID value.
        /// </summary>
        public string OutItemID
        {
            get { return outItemID; }
            set { outItemID = value; }
        }
        /// <summary>
        /// Gets or sets the OutItemName value.
        /// </summary>
        public string OutItemName
        {
            get { return outItemName; }
            set { outItemName = value; }
        }
        /// <summary>
        /// Gets or sets the FinishedGoodItemID value.
        /// </summary>
        public string FinishedGoodItemID
        {
            get { return finishedGoodItemID; }
            set { finishedGoodItemID = value; }
        }

        /// <summary>
		/// Gets or sets the Line_NoShedule value.
		/// </summary>
		public int Line_NoShedule
        {
            get { return line_NoShedule; }
            set { line_NoShedule = value; }
        }
        /// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int WIP_LineNo
        {
            get { return wIP_LineNo; }
            set { wIP_LineNo = value; }
        }
        /// <summary>
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID
        {
            get { return prePlan_ID; }
            set { prePlan_ID = value; }
        }
        #endregion

        #region Methods
        public static List<srh_WIP_ProductionAndWasteage> SelectAll(DateTime dateFrom, DateTime dateTo)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_WIP_ProductionAndWasteageSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
            List<srh_WIP_ProductionAndWasteage> srh_WIP_ProductionAndWasteageList = new List<srh_WIP_ProductionAndWasteage>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_WIP_ProductionAndWasteage srh_WIP_ProductionAndWasteage = Makesrh_WIP_ProductionAndWasteage(dataReader);
                    srh_WIP_ProductionAndWasteageList.Add(srh_WIP_ProductionAndWasteage);
                }
            }
            scon.Close();
            return srh_WIP_ProductionAndWasteageList;
        }

        /// <summary>
        /// Selects all records from the srh_WIP_ProductionAndWasteage table by a foreign key.
        /// </summary>
        public static List<srh_WIP_ProductionAndWasteage> SelectAllByMachine_ID(string machine_ID, DateTime dateFrom, DateTime dateTo)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_WIP_ProductionAndWasteageSelectAllByMachine_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@machine_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@machine_ID"].Value = machine_ID;
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
            List<srh_WIP_ProductionAndWasteage> srh_WIP_ProductionAndWasteageList = new List<srh_WIP_ProductionAndWasteage>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_WIP_ProductionAndWasteage srh_WIP_ProductionAndWasteage = Makesrh_WIP_ProductionAndWasteage(dataReader);
                    srh_WIP_ProductionAndWasteageList.Add(srh_WIP_ProductionAndWasteage);
                }
            }
            scon.Close();
            return srh_WIP_ProductionAndWasteageList;
        }

        /// <summary>
        /// Selects all records from the srh_WIP_ProductionAndWasteage table by a foreign key.
        /// </summary>
        public static List<srh_WIP_ProductionAndWasteage> SelectAllBySection_ID(string section_ID, DateTime dateFrom, DateTime dateTo)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_WIP_ProductionAndWasteageSelectAllBySection_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@section_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@section_ID"].Value = section_ID;
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
            List<srh_WIP_ProductionAndWasteage> srh_WIP_ProductionAndWasteageList = new List<srh_WIP_ProductionAndWasteage>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_WIP_ProductionAndWasteage srh_WIP_ProductionAndWasteage = Makesrh_WIP_ProductionAndWasteage(dataReader);
                    srh_WIP_ProductionAndWasteageList.Add(srh_WIP_ProductionAndWasteage);
                }
            }
            scon.Close();
            return srh_WIP_ProductionAndWasteageList;
        }
        public static List<srh_WIP_ProductionAndWasteage> SelectAllBySection_ID(string section_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_WIP_ProductionAndWasteageSelectAllBySection_ID_WithoutDates", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@section_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@section_ID"].Value = section_ID;            
            List<srh_WIP_ProductionAndWasteage> srh_WIP_ProductionAndWasteageList = new List<srh_WIP_ProductionAndWasteage>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_WIP_ProductionAndWasteage srh_WIP_ProductionAndWasteage = Makesrh_WIP_ProductionAndWasteage(dataReader);
                    srh_WIP_ProductionAndWasteageList.Add(srh_WIP_ProductionAndWasteage);
                }
            }
            scon.Close();
            return srh_WIP_ProductionAndWasteageList;
        }		
		
		
		/// <summary>
		/// Creates a new instance of the srh_WIP_ProductionAndWasteage class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_WIP_ProductionAndWasteage Makesrh_WIP_ProductionAndWasteage(SqlDataReader dataReader) {
			srh_WIP_ProductionAndWasteage srh_WIP_ProductionAndWasteage = new srh_WIP_ProductionAndWasteage();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_WIP_ProductionAndWasteage.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_WIP_ProductionAndWasteage.Machine_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_WIP_ProductionAndWasteage.MachineName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_WIP_ProductionAndWasteage.DateStart = dataReader.GetDateTime(3);
			}
            if (dataReader.IsDBNull(4) == false){
                srh_WIP_ProductionAndWasteage.DateEnd = dataReader.GetDateTime(4);
            }
			if (dataReader.IsDBNull(5) == false) {
				srh_WIP_ProductionAndWasteage.WeightFinished = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_WIP_ProductionAndWasteage.WeightWasteage = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_WIP_ProductionAndWasteage.WeighOut = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_WIP_ProductionAndWasteage.CylinderSize = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_WIP_ProductionAndWasteage.Counter = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_WIP_ProductionAndWasteage.Section_line_No = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_WIP_ProductionAndWasteage.Section_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_WIP_ProductionAndWasteage.SectionName = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				srh_WIP_ProductionAndWasteage.ProductionJob_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				srh_WIP_ProductionAndWasteage.WorkInProgress_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				srh_WIP_ProductionAndWasteage.Length = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				srh_WIP_ProductionAndWasteage.Qty = dataReader.GetDecimal(16);
			}
            if (dataReader.IsDBNull(17) == false) {
                srh_WIP_ProductionAndWasteage.OutItemID = dataReader.GetString(17);
            } 
            if (dataReader.IsDBNull(18) == false) {
                srh_WIP_ProductionAndWasteage.OutItemName = dataReader.GetString(18);
            } 
            if (dataReader.IsDBNull(19) == false) {
                srh_WIP_ProductionAndWasteage.FinishedGoodItemID = dataReader.GetString(19);
            }
            if (dataReader.IsDBNull(20) == false)
            {
                srh_WIP_ProductionAndWasteage.Line_NoShedule = dataReader.GetInt32(20);
            }
            if (dataReader.IsDBNull(21) == false)
            {
                srh_WIP_ProductionAndWasteage.WIP_LineNo = dataReader.GetInt32(21);
            }
            if (dataReader.IsDBNull(22) == false)
            {
                srh_WIP_ProductionAndWasteage.PrePlan_ID = dataReader.GetString(22);
            }
            return srh_WIP_ProductionAndWasteage;
		}
		
		#endregion
	}
}
