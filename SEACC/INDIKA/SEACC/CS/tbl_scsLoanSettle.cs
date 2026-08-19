using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsLoanSettle {
		#region Fields
		private string allocationID;
		private string loanIn_ID;
		private string loanOut_ID;
		private decimal qtySettle;
		private decimal weightSettle;
		private decimal unitPriceSettle;
		private decimal weightPriceSettle;
		private DateTime allocationDate;
		private bool isQtyAllocation;
		private bool isLoanInBase;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsLoanSettle class.
		/// </summary>
		public tbl_scsLoanSettle() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsLoanSettle class.
		/// </summary>
		public tbl_scsLoanSettle(string allocationID, string loanIn_ID, string loanOut_ID, decimal qtySettle, decimal weightSettle, decimal unitPriceSettle, decimal weightPriceSettle, DateTime allocationDate, bool isQtyAllocation, bool isLoanInBase) {
			this.allocationID = allocationID;
			this.loanIn_ID = loanIn_ID;
			this.loanOut_ID = loanOut_ID;
			this.qtySettle = qtySettle;
			this.weightSettle = weightSettle;
			this.unitPriceSettle = unitPriceSettle;
			this.weightPriceSettle = weightPriceSettle;
			this.allocationDate = allocationDate;
			this.isQtyAllocation = isQtyAllocation;
			this.isLoanInBase = isLoanInBase;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AllocationID value.
		/// </summary>
		public string AllocationID {
			get { return allocationID; }
			set { allocationID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LoanIn_ID value.
		/// </summary>
		public string LoanIn_ID {
			get { return loanIn_ID; }
			set { loanIn_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LoanOut_ID value.
		/// </summary>
		public string LoanOut_ID {
			get { return loanOut_ID; }
			set { loanOut_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle value.
		/// </summary>
		public decimal QtySettle {
			get { return qtySettle; }
			set { qtySettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightSettle value.
		/// </summary>
		public decimal WeightSettle {
			get { return weightSettle; }
			set { weightSettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPriceSettle value.
		/// </summary>
		public decimal UnitPriceSettle {
			get { return unitPriceSettle; }
			set { unitPriceSettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightPriceSettle value.
		/// </summary>
		public decimal WeightPriceSettle {
			get { return weightPriceSettle; }
			set { weightPriceSettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllocationDate value.
		/// </summary>
		public DateTime AllocationDate {
			get { return allocationDate; }
			set { allocationDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsQtyAllocation value.
		/// </summary>
		public bool IsQtyAllocation {
			get { return isQtyAllocation; }
			set { isQtyAllocation = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLoanInBase value.
		/// </summary>
		public bool IsLoanInBase {
			get { return isLoanInBase; }
			set { isLoanInBase = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsLoanSettle table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@allocationID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@loanIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@loanOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPriceSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPriceSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocationDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isQtyAllocation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLoanInBase", SqlDbType.Bit,1);
 
			scom.Parameters["@allocationID"].Value = allocationID;
			scom.Parameters["@loanIn_ID"].Value = loanIn_ID;
			scom.Parameters["@loanOut_ID"].Value = loanOut_ID;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPriceSettle"].Value = unitPriceSettle;
			scom.Parameters["@weightPriceSettle"].Value = weightPriceSettle;
			scom.Parameters["@allocationDate"].Value = allocationDate;
			scom.Parameters["@isQtyAllocation"].Value = isQtyAllocation;
			scom.Parameters["@isLoanInBase"].Value = isLoanInBase;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsLoanSettle table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@allocationID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@loanIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@loanOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPriceSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPriceSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocationDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isQtyAllocation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLoanInBase", SqlDbType.Bit,1);
 
 
			scom.Parameters["@allocationID"].Value = allocationID;
			scom.Parameters["@loanIn_ID"].Value = loanIn_ID;
			scom.Parameters["@loanOut_ID"].Value = loanOut_ID;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPriceSettle"].Value = unitPriceSettle;
			scom.Parameters["@weightPriceSettle"].Value = weightPriceSettle;
			scom.Parameters["@allocationDate"].Value = allocationDate;
			scom.Parameters["@isQtyAllocation"].Value = isQtyAllocation;
			scom.Parameters["@isLoanInBase"].Value = isLoanInBase;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsLoanSettle table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@allocationID", SqlDbType.VarChar,20);
			scom.Parameters["@allocationID"].Value = allocationID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanSettle table by a foreign key.
		/// </summary>
		public static void DeleteAllByLoanIn_ID(string loanIn_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleDeleteAllByLoanIn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@loanIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@loanIn_ID"].Value = loanIn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanSettle table by a foreign key.
		/// </summary>
		public static void DeleteAllByLoanOut_ID(string loanOut_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleDeleteAllByLoanOut_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@loanOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@loanOut_ID"].Value = loanOut_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsLoanSettle table.
		/// </summary>
		public static tbl_scsLoanSettle Select(string allocationID_Incoming){

			tbl_scsLoanSettle tbl_scsLoanSettleins = new tbl_scsLoanSettle();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@allocationID", SqlDbType.VarChar,20);
			scom.Parameters["@allocationID"].Value = allocationID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsLoanSettleins = Maketbl_scsLoanSettle(dataReader);
				} else {
					tbl_scsLoanSettleins = null;
				}
			}
			scon.Close();
			return tbl_scsLoanSettleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanSettle table.
		/// </summary>
		public static List<tbl_scsLoanSettle> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsLoanSettle> tbl_scsLoanSettleList = new List<tbl_scsLoanSettle>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsLoanSettle tbl_scsLoanSettle = Maketbl_scsLoanSettle(dataReader);
					tbl_scsLoanSettleList.Add(tbl_scsLoanSettle);
				}
			}
			scon.Close();
			return tbl_scsLoanSettleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanSettle table by a foreign key.
		/// </summary>
		public static List<tbl_scsLoanSettle> SelectAllByLoanIn_ID(string loanIn_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleSelectAllByLoanIn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@loanIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@loanIn_ID"].Value = loanIn_ID;
				List<tbl_scsLoanSettle> tbl_scsLoanSettleList = new List<tbl_scsLoanSettle>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsLoanSettle tbl_scsLoanSettle = Maketbl_scsLoanSettle(dataReader);
					tbl_scsLoanSettleList.Add(tbl_scsLoanSettle);
				}
			}
			scon.Close();
			return tbl_scsLoanSettleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanSettle table by a foreign key.
		/// </summary>
		public static List<tbl_scsLoanSettle> SelectAllByLoanOut_ID(string loanOut_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanSettleSelectAllByLoanOut_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@loanOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@loanOut_ID"].Value = loanOut_ID;
				List<tbl_scsLoanSettle> tbl_scsLoanSettleList = new List<tbl_scsLoanSettle>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsLoanSettle tbl_scsLoanSettle = Maketbl_scsLoanSettle(dataReader);
					tbl_scsLoanSettleList.Add(tbl_scsLoanSettle);
				}
			}
			scon.Close();
			return tbl_scsLoanSettleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsLoanSettle class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsLoanSettle Maketbl_scsLoanSettle(SqlDataReader dataReader) {
			tbl_scsLoanSettle tbl_scsLoanSettle = new tbl_scsLoanSettle();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsLoanSettle.AllocationID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsLoanSettle.LoanIn_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsLoanSettle.LoanOut_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsLoanSettle.QtySettle = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsLoanSettle.WeightSettle = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsLoanSettle.UnitPriceSettle = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsLoanSettle.WeightPriceSettle = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsLoanSettle.AllocationDate = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsLoanSettle.IsQtyAllocation = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsLoanSettle.IsLoanInBase = dataReader.GetBoolean(9);
			}

			return tbl_scsLoanSettle;
		}
		/// <summary>
		/// This makes tbl_scsLoanSettle datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsLoanSettle object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsLoanSettle  tbl_scsLoanSettle   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_allocationID = new DataColumn("allocationID" , typeof(string));
			DataColumn col_loanIn_ID = new DataColumn("loanIn_ID" , typeof(string));
			DataColumn col_loanOut_ID = new DataColumn("loanOut_ID" , typeof(string));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_unitPriceSettle = new DataColumn("unitPriceSettle" , typeof(decimal));
			DataColumn col_weightPriceSettle = new DataColumn("weightPriceSettle" , typeof(decimal));
			DataColumn col_allocationDate = new DataColumn("allocationDate" , typeof(DateTime));
			DataColumn col_isQtyAllocation = new DataColumn("isQtyAllocation" , typeof(bool));
			DataColumn col_isLoanInBase = new DataColumn("isLoanInBase" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_allocationID,col_loanIn_ID,col_loanOut_ID,col_qtySettle,col_weightSettle,col_unitPriceSettle,col_weightPriceSettle,col_allocationDate,col_isQtyAllocation,col_isLoanInBase,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsLoanSettle datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsLoanSettle object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsLoanSettle user) {
		DataRow drow = dt.NewRow();
		
			drow["allocationID"] = user.allocationID;
			drow["loanIn_ID"] = user.loanIn_ID;
			drow["loanOut_ID"] = user.loanOut_ID;
			drow["qtySettle"] = user.qtySettle;
			drow["weightSettle"] = user.weightSettle;
			drow["unitPriceSettle"] = user.unitPriceSettle;
			drow["weightPriceSettle"] = user.weightPriceSettle;
			drow["allocationDate"] = user.allocationDate;
			drow["isQtyAllocation"] = user.isQtyAllocation;
			drow["isLoanInBase"] = user.isLoanInBase;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
