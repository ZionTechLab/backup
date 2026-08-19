using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_pmsAdhesiveInputAndOutput {
		#region Fields
		private string productionJob_ID;
		private string customer_ID;
		private string customerName;
		private string itemName;
		private string machineName;
		private decimal weightInput;
		private string item_ID;
		private string inputItemName;
		private string inputItemCatergoryID;
		private decimal cutbackSize;
		private decimal lengthOut;
		private decimal weighOut;
		private DateTime dateStart;
        private string sectionID;
        private string jobID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_pmsAdhesiveInputAndOutput class.
		/// </summary>
		public srh_pmsAdhesiveInputAndOutput() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_pmsAdhesiveInputAndOutput class.
		/// </summary>
		public srh_pmsAdhesiveInputAndOutput(string productionJob_ID, string customer_ID, string customerName, string itemName, string machineName, decimal weightInput, string item_ID, string inputItemName, string inputItemCatergoryID, decimal cutbackSize, decimal lengthOut, decimal weighOut, DateTime dateStart) {
			this.productionJob_ID = productionJob_ID;
			this.customer_ID = customer_ID;
			this.customerName = customerName;
			this.itemName = itemName;
			this.machineName = machineName;
			this.weightInput = weightInput;
			this.item_ID = item_ID;
			this.inputItemName = inputItemName;
			this.inputItemCatergoryID = inputItemCatergoryID;
			this.cutbackSize = cutbackSize;
			this.lengthOut = lengthOut;
			this.weighOut = weighOut;
			this.dateStart = dateStart;
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
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineName value.
		/// </summary>
		public string MachineName {
			get { return machineName; }
			set { machineName = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightInput value.
		/// </summary>
		public decimal WeightInput {
			get { return weightInput; }
			set { weightInput = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputItemName value.
		/// </summary>
		public string InputItemName {
			get { return inputItemName; }
			set { inputItemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputItemCatergoryID value.
		/// </summary>
		public string InputItemCatergoryID {
			get { return inputItemCatergoryID; }
			set { inputItemCatergoryID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CutbackSize value.
		/// </summary>
		public decimal CutbackSize {
			get { return cutbackSize; }
			set { cutbackSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the LengthOut value.
		/// </summary>
		public decimal LengthOut {
			get { return lengthOut; }
			set { lengthOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeighOut value.
		/// </summary>
		public decimal WeighOut {
			get { return weighOut; }
			set { weighOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateStart value.
		/// </summary>
		public DateTime DateStart {
			get { return dateStart; }
			set { dateStart = value; }
		}
		#endregion

        public string SectionID
        {
            get { return sectionID;}
            set { sectionID = value;}
        }

        public string JobID
        {
            get { return jobID; }
            set { jobID = value; }
        }

		#region Methods	
		
		/// <summary>
		/// Selects all records from the srh_pmsAdhesiveInputAndOutput table.
		/// </summary>
        public static List<srh_pmsAdhesiveInputAndOutput> SelectAllByDateRange(DateTime dtmdateFrom, DateTime dtmEndDate)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_PMS_AdhesiveInputOutputDetailSelectAll", scon);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dtmdateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dtmEndDate.AddDays(1).AddMinutes(-1);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<srh_pmsAdhesiveInputAndOutput> srh_pmsAdhesiveInputAndOutputList = new List<srh_pmsAdhesiveInputAndOutput>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_pmsAdhesiveInputAndOutput srh_pmsAdhesiveInputAndOutput = Makesrh_pmsAdhesiveInputAndOutput(dataReader);
					srh_pmsAdhesiveInputAndOutputList.Add(srh_pmsAdhesiveInputAndOutput);
				}
			}
			scon.Close();
			return srh_pmsAdhesiveInputAndOutputList;
		}
		
		/// <summary>
		/// Creates a new instance of the srh_pmsAdhesiveInputAndOutput class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_pmsAdhesiveInputAndOutput Makesrh_pmsAdhesiveInputAndOutput(SqlDataReader dataReader) {
			srh_pmsAdhesiveInputAndOutput srh_pmsAdhesiveInputAndOutput = new srh_pmsAdhesiveInputAndOutput();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_pmsAdhesiveInputAndOutput.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_pmsAdhesiveInputAndOutput.Customer_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_pmsAdhesiveInputAndOutput.CustomerName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_pmsAdhesiveInputAndOutput.ItemName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_pmsAdhesiveInputAndOutput.MachineName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_pmsAdhesiveInputAndOutput.WeightInput = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_pmsAdhesiveInputAndOutput.Item_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_pmsAdhesiveInputAndOutput.InputItemName = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_pmsAdhesiveInputAndOutput.InputItemCatergoryID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_pmsAdhesiveInputAndOutput.CutbackSize = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_pmsAdhesiveInputAndOutput.LengthOut = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_pmsAdhesiveInputAndOutput.WeighOut = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_pmsAdhesiveInputAndOutput.DateStart = dataReader.GetDateTime(12);
			}
            if (dataReader.IsDBNull(13) == false)
            {
                srh_pmsAdhesiveInputAndOutput.SectionID = dataReader.GetString(13);
            }

			return srh_pmsAdhesiveInputAndOutput;
		}
		/// <summary>
		/// This makes srh_pmsAdhesiveInputAndOutput datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new srh_pmsAdhesiveInputAndOutput object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( srh_pmsAdhesiveInputAndOutput  srh_pmsAdhesiveInputAndOutput   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_machineName = new DataColumn("machineName" , typeof(string));
			DataColumn col_weightInput = new DataColumn("weightInput" , typeof(decimal));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_InputItemName = new DataColumn("InputItemName" , typeof(string));
			DataColumn col_InputItemCatergoryID = new DataColumn("InputItemCatergoryID" , typeof(string));
			DataColumn col_cutbackSize = new DataColumn("cutbackSize" , typeof(decimal));
			DataColumn col_LengthOut = new DataColumn("LengthOut" , typeof(decimal));
			DataColumn col_weighOut = new DataColumn("weighOut" , typeof(decimal));
			DataColumn col_dateStart = new DataColumn("dateStart" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_productionJob_ID,col_customer_ID,col_customerName,col_itemName,col_machineName,col_weightInput,col_item_ID,col_InputItemName,col_InputItemCatergoryID,col_cutbackSize,col_LengthOut,col_weighOut,col_dateStart,});		return dt;
		}
		/// <summary>
		/// This fills srh_pmsAdhesiveInputAndOutput datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new srh_pmsAdhesiveInputAndOutput object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, srh_pmsAdhesiveInputAndOutput user) {
		DataRow drow = dt.NewRow();
		
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["customerName"] = user.customerName;
			drow["itemName"] = user.itemName;
			drow["machineName"] = user.machineName;
			drow["weightInput"] = user.weightInput;
			drow["item_ID"] = user.item_ID;
			drow["InputItemName"] = user.InputItemName;
			drow["InputItemCatergoryID"] = user.InputItemCatergoryID;
			drow["cutbackSize"] = user.cutbackSize;
			drow["LengthOut"] = user.LengthOut;
			drow["weighOut"] = user.weighOut;
			drow["dateStart"] = user.dateStart;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
