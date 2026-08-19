using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission_PaymentSettlement {
		#region Fields
		private string commission_ID;
		private string paymentVoucher_ID;
		private DateTime settlementDate;
		private decimal settledAmount;
		private DateTime allocationDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_PaymentSettlement class.
		/// </summary>
		public tbl_sasSalesCommission_PaymentSettlement() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_PaymentSettlement class.
		/// </summary>
		public tbl_sasSalesCommission_PaymentSettlement(string commission_ID, string paymentVoucher_ID, DateTime settlementDate, decimal settledAmount, DateTime allocationDate) {
			this.commission_ID = commission_ID;
			this.paymentVoucher_ID = paymentVoucher_ID;
			this.settlementDate = settlementDate;
			this.settledAmount = settledAmount;
			this.allocationDate = allocationDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Commission_ID value.
		/// </summary>
		public string Commission_ID {
			get { return commission_ID; }
			set { commission_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentVoucher_ID value.
		/// </summary>
		public string PaymentVoucher_ID {
			get { return paymentVoucher_ID; }
			set { paymentVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettlementDate value.
		/// </summary>
		public DateTime SettlementDate {
			get { return settlementDate; }
			set { settlementDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettledAmount value.
		/// </summary>
		public decimal SettledAmount {
			get { return settledAmount; }
			set { settledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllocationDate value.
		/// </summary>
		public DateTime AllocationDate {
			get { return allocationDate; }
			set { allocationDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission_PaymentSettlement table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_PaymentSettlementInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@settlementDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocationDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@settlementDate"].Value = settlementDate;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@allocationDate"].Value = allocationDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission_PaymentSettlement table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_PaymentSettlementUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@settlementDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocationDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@settlementDate"].Value = settlementDate;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@allocationDate"].Value = allocationDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission_PaymentSettlement table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_PaymentSettlementDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_PaymentSettlement table by a foreign key.
		/// </summary>
		public static void DeleteAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_PaymentSettlementDeleteAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission_PaymentSettlement table.
		/// </summary>
		public static tbl_sasSalesCommission_PaymentSettlement Select(string commission_ID_Incoming){

			tbl_sasSalesCommission_PaymentSettlement tbl_sasSalesCommission_PaymentSettlementins = new tbl_sasSalesCommission_PaymentSettlement();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_PaymentSettlementSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommission_PaymentSettlementins = Maketbl_sasSalesCommission_PaymentSettlement(dataReader);
				} else {
					tbl_sasSalesCommission_PaymentSettlementins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_PaymentSettlementins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_PaymentSettlement table.
		/// </summary>
		public static List<tbl_sasSalesCommission_PaymentSettlement> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_PaymentSettlementSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission_PaymentSettlement> tbl_sasSalesCommission_PaymentSettlementList = new List<tbl_sasSalesCommission_PaymentSettlement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_PaymentSettlement tbl_sasSalesCommission_PaymentSettlement = Maketbl_sasSalesCommission_PaymentSettlement(dataReader);
					tbl_sasSalesCommission_PaymentSettlementList.Add(tbl_sasSalesCommission_PaymentSettlement);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_PaymentSettlementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_PaymentSettlement table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_PaymentSettlement> SelectAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_PaymentSettlementSelectAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
				List<tbl_sasSalesCommission_PaymentSettlement> tbl_sasSalesCommission_PaymentSettlementList = new List<tbl_sasSalesCommission_PaymentSettlement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_PaymentSettlement tbl_sasSalesCommission_PaymentSettlement = Maketbl_sasSalesCommission_PaymentSettlement(dataReader);
					tbl_sasSalesCommission_PaymentSettlementList.Add(tbl_sasSalesCommission_PaymentSettlement);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_PaymentSettlementList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission_PaymentSettlement class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission_PaymentSettlement Maketbl_sasSalesCommission_PaymentSettlement(SqlDataReader dataReader) {
			tbl_sasSalesCommission_PaymentSettlement tbl_sasSalesCommission_PaymentSettlement = new tbl_sasSalesCommission_PaymentSettlement();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission_PaymentSettlement.Commission_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission_PaymentSettlement.PaymentVoucher_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission_PaymentSettlement.SettlementDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission_PaymentSettlement.SettledAmount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesCommission_PaymentSettlement.AllocationDate = dataReader.GetDateTime(4);
			}

			return tbl_sasSalesCommission_PaymentSettlement;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission_PaymentSettlement datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_PaymentSettlement object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission_PaymentSettlement  tbl_sasSalesCommission_PaymentSettlement   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_paymentVoucher_ID = new DataColumn("paymentVoucher_ID" , typeof(string));
			DataColumn col_settlementDate = new DataColumn("settlementDate" , typeof(DateTime));
			DataColumn col_settledAmount = new DataColumn("settledAmount" , typeof(decimal));
			DataColumn col_allocationDate = new DataColumn("allocationDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_commission_ID,col_paymentVoucher_ID,col_settlementDate,col_settledAmount,col_allocationDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission_PaymentSettlement datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_PaymentSettlement object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission_PaymentSettlement user) {
		DataRow drow = dt.NewRow();
		
			drow["commission_ID"] = user.commission_ID;
			drow["paymentVoucher_ID"] = user.paymentVoucher_ID;
			drow["settlementDate"] = user.settlementDate;
			drow["settledAmount"] = user.settledAmount;
			drow["allocationDate"] = user.allocationDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
