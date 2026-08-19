using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_genCustomerFinance {
		#region Fields
		private string customer_ID;
		private decimal depositAmount;
		private decimal creditPeriod;
		private decimal creditLimit;
		private decimal salesDues;
		private decimal creditBalance;
		private decimal totalSales;
		private decimal deposittedChequeCount;
		private decimal realizedChequeCount;
		private decimal returnedChequeCount;
		private decimal deposittedChequeAmount;
		private decimal realizedChequeAmount;
		private decimal returnedChequeAmount;
		private decimal openingBalance;
		private DateTime openingBalanceDate;
		private decimal chequesInHand;
		private decimal loyaltyAmount;
		private DateTime loyalityStartDate;
		private string loyalityCardNo;
		private decimal outstandingAmount;
		private decimal chequeInHandAmount;
		private decimal commissionCreditPeriod;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerFinance class.
		/// </summary>
		public tbl_genCustomerFinance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerFinance class.
		/// </summary>
		public tbl_genCustomerFinance(string customer_ID, decimal depositAmount, decimal creditPeriod, decimal creditLimit, decimal salesDues, decimal creditBalance, decimal totalSales, decimal deposittedChequeCount, decimal realizedChequeCount, decimal returnedChequeCount, decimal deposittedChequeAmount, decimal realizedChequeAmount, decimal returnedChequeAmount, decimal openingBalance, DateTime openingBalanceDate, decimal chequesInHand, decimal loyaltyAmount, DateTime loyalityStartDate, string loyalityCardNo, decimal outstandingAmount, decimal chequeInHandAmount, decimal commissionCreditPeriod) {
			this.customer_ID = customer_ID;
			this.depositAmount = depositAmount;
			this.creditPeriod = creditPeriod;
			this.creditLimit = creditLimit;
			this.salesDues = salesDues;
			this.creditBalance = creditBalance;
			this.totalSales = totalSales;
			this.deposittedChequeCount = deposittedChequeCount;
			this.realizedChequeCount = realizedChequeCount;
			this.returnedChequeCount = returnedChequeCount;
			this.deposittedChequeAmount = deposittedChequeAmount;
			this.realizedChequeAmount = realizedChequeAmount;
			this.returnedChequeAmount = returnedChequeAmount;
			this.openingBalance = openingBalance;
			this.openingBalanceDate = openingBalanceDate;
			this.chequesInHand = chequesInHand;
			this.loyaltyAmount = loyaltyAmount;
			this.loyalityStartDate = loyalityStartDate;
			this.loyalityCardNo = loyalityCardNo;
			this.outstandingAmount = outstandingAmount;
			this.chequeInHandAmount = chequeInHandAmount;
			this.commissionCreditPeriod = commissionCreditPeriod;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepositAmount value.
		/// </summary>
		public decimal DepositAmount {
			get { return depositAmount; }
			set { depositAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditPeriod value.
		/// </summary>
		public decimal CreditPeriod {
			get { return creditPeriod; }
			set { creditPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditLimit value.
		/// </summary>
		public decimal CreditLimit {
			get { return creditLimit; }
			set { creditLimit = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesDues value.
		/// </summary>
		public decimal SalesDues {
			get { return salesDues; }
			set { salesDues = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditBalance value.
		/// </summary>
		public decimal CreditBalance {
			get { return creditBalance; }
			set { creditBalance = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalSales value.
		/// </summary>
		public decimal TotalSales {
			get { return totalSales; }
			set { totalSales = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeposittedChequeCount value.
		/// </summary>
		public decimal DeposittedChequeCount {
			get { return deposittedChequeCount; }
			set { deposittedChequeCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the RealizedChequeCount value.
		/// </summary>
		public decimal RealizedChequeCount {
			get { return realizedChequeCount; }
			set { realizedChequeCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReturnedChequeCount value.
		/// </summary>
		public decimal ReturnedChequeCount {
			get { return returnedChequeCount; }
			set { returnedChequeCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeposittedChequeAmount value.
		/// </summary>
		public decimal DeposittedChequeAmount {
			get { return deposittedChequeAmount; }
			set { deposittedChequeAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the RealizedChequeAmount value.
		/// </summary>
		public decimal RealizedChequeAmount {
			get { return realizedChequeAmount; }
			set { realizedChequeAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReturnedChequeAmount value.
		/// </summary>
		public decimal ReturnedChequeAmount {
			get { return returnedChequeAmount; }
			set { returnedChequeAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the OpeningBalance value.
		/// </summary>
		public decimal OpeningBalance {
			get { return openingBalance; }
			set { openingBalance = value; }
		}
		
		/// <summary>
		/// Gets or sets the OpeningBalanceDate value.
		/// </summary>
		public DateTime OpeningBalanceDate {
			get { return openingBalanceDate; }
			set { openingBalanceDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequesInHand value.
		/// </summary>
		public decimal ChequesInHand {
			get { return chequesInHand; }
			set { chequesInHand = value; }
		}
		
		/// <summary>
		/// Gets or sets the LoyaltyAmount value.
		/// </summary>
		public decimal LoyaltyAmount {
			get { return loyaltyAmount; }
			set { loyaltyAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the LoyalityStartDate value.
		/// </summary>
		public DateTime LoyalityStartDate {
			get { return loyalityStartDate; }
			set { loyalityStartDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the LoyalityCardNo value.
		/// </summary>
		public string LoyalityCardNo {
			get { return loyalityCardNo; }
			set { loyalityCardNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the OutstandingAmount value.
		/// </summary>
		public decimal OutstandingAmount {
			get { return outstandingAmount; }
			set { outstandingAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeInHandAmount value.
		/// </summary>
		public decimal ChequeInHandAmount {
			get { return chequeInHandAmount; }
			set { chequeInHandAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommissionCreditPeriod value.
		/// </summary>
		public decimal CommissionCreditPeriod {
			get { return commissionCreditPeriod; }
			set { commissionCreditPeriod = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCustomerFinance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerFinanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@depositAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditPeriod", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditLimit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salesDues", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalSales", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DeposittedChequeCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@RealizedChequeCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ReturnedChequeCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DeposittedChequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@RealizedChequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ReturnedChequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@openingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@openingBalanceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@chequesInHand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@loyaltyAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@loyalityStartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@loyalityCardNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@outstandingAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeInHandAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionCreditPeriod", SqlDbType.Decimal,9);
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@depositAmount"].Value = depositAmount;
			scom.Parameters["@creditPeriod"].Value = creditPeriod;
			scom.Parameters["@creditLimit"].Value = creditLimit;
			scom.Parameters["@salesDues"].Value = salesDues;
			scom.Parameters["@creditBalance"].Value = creditBalance;
			scom.Parameters["@totalSales"].Value = totalSales;
			scom.Parameters["@DeposittedChequeCount"].Value = deposittedChequeCount;
			scom.Parameters["@RealizedChequeCount"].Value = realizedChequeCount;
			scom.Parameters["@ReturnedChequeCount"].Value = returnedChequeCount;
			scom.Parameters["@DeposittedChequeAmount"].Value = deposittedChequeAmount;
			scom.Parameters["@RealizedChequeAmount"].Value = realizedChequeAmount;
			scom.Parameters["@ReturnedChequeAmount"].Value = returnedChequeAmount;
			scom.Parameters["@openingBalance"].Value = openingBalance;
			scom.Parameters["@openingBalanceDate"].Value = openingBalanceDate;
			scom.Parameters["@chequesInHand"].Value = chequesInHand;
			scom.Parameters["@loyaltyAmount"].Value = loyaltyAmount;
			scom.Parameters["@loyalityStartDate"].Value = loyalityStartDate;
			scom.Parameters["@loyalityCardNo"].Value = loyalityCardNo;
			scom.Parameters["@outstandingAmount"].Value = outstandingAmount;
			scom.Parameters["@chequeInHandAmount"].Value = chequeInHandAmount;
			scom.Parameters["@commissionCreditPeriod"].Value = commissionCreditPeriod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCustomerFinance table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerFinanceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@depositAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditPeriod", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditLimit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salesDues", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalSales", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DeposittedChequeCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@RealizedChequeCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ReturnedChequeCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DeposittedChequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@RealizedChequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ReturnedChequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@openingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@openingBalanceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@chequesInHand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@loyaltyAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@loyalityStartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@loyalityCardNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@outstandingAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeInHandAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionCreditPeriod", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@depositAmount"].Value = depositAmount;
			scom.Parameters["@creditPeriod"].Value = creditPeriod;
			scom.Parameters["@creditLimit"].Value = creditLimit;
			scom.Parameters["@salesDues"].Value = salesDues;
			scom.Parameters["@creditBalance"].Value = creditBalance;
			scom.Parameters["@totalSales"].Value = totalSales;
			scom.Parameters["@DeposittedChequeCount"].Value = deposittedChequeCount;
			scom.Parameters["@RealizedChequeCount"].Value = realizedChequeCount;
			scom.Parameters["@ReturnedChequeCount"].Value = returnedChequeCount;
			scom.Parameters["@DeposittedChequeAmount"].Value = deposittedChequeAmount;
			scom.Parameters["@RealizedChequeAmount"].Value = realizedChequeAmount;
			scom.Parameters["@ReturnedChequeAmount"].Value = returnedChequeAmount;
			scom.Parameters["@openingBalance"].Value = openingBalance;
			scom.Parameters["@openingBalanceDate"].Value = openingBalanceDate;
			scom.Parameters["@chequesInHand"].Value = chequesInHand;
			scom.Parameters["@loyaltyAmount"].Value = loyaltyAmount;
			scom.Parameters["@loyalityStartDate"].Value = loyalityStartDate;
			scom.Parameters["@loyalityCardNo"].Value = loyalityCardNo;
			scom.Parameters["@outstandingAmount"].Value = outstandingAmount;
			scom.Parameters["@chequeInHandAmount"].Value = chequeInHandAmount;
			scom.Parameters["@commissionCreditPeriod"].Value = commissionCreditPeriod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCustomerFinance table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerFinanceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerFinance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerFinanceDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCustomerFinance table.
		/// </summary>
		public static tbl_genCustomerFinance Select(string customer_ID_Incoming){

			tbl_genCustomerFinance tbl_genCustomerFinanceins = new tbl_genCustomerFinance();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerFinanceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCustomerFinanceins = Maketbl_genCustomerFinance(dataReader);
				} else {
					tbl_genCustomerFinanceins = null;
				}
			}
			scon.Close();
			return tbl_genCustomerFinanceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerFinance table.
		/// </summary>
		public static List<tbl_genCustomerFinance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerFinanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCustomerFinance> tbl_genCustomerFinanceList = new List<tbl_genCustomerFinance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerFinance tbl_genCustomerFinance = Maketbl_genCustomerFinance(dataReader);
					tbl_genCustomerFinanceList.Add(tbl_genCustomerFinance);
				}
			}
			scon.Close();
			return tbl_genCustomerFinanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerFinance table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerFinance> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerFinanceSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genCustomerFinance> tbl_genCustomerFinanceList = new List<tbl_genCustomerFinance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerFinance tbl_genCustomerFinance = Maketbl_genCustomerFinance(dataReader);
					tbl_genCustomerFinanceList.Add(tbl_genCustomerFinance);
				}
			}
			scon.Close();
			return tbl_genCustomerFinanceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCustomerFinance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCustomerFinance Maketbl_genCustomerFinance(SqlDataReader dataReader) {
			tbl_genCustomerFinance tbl_genCustomerFinance = new tbl_genCustomerFinance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCustomerFinance.Customer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCustomerFinance.DepositAmount = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCustomerFinance.CreditPeriod = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCustomerFinance.CreditLimit = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCustomerFinance.SalesDues = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genCustomerFinance.CreditBalance = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genCustomerFinance.TotalSales = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genCustomerFinance.DeposittedChequeCount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genCustomerFinance.RealizedChequeCount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genCustomerFinance.ReturnedChequeCount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genCustomerFinance.DeposittedChequeAmount = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genCustomerFinance.RealizedChequeAmount = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genCustomerFinance.ReturnedChequeAmount = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genCustomerFinance.OpeningBalance = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genCustomerFinance.OpeningBalanceDate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genCustomerFinance.ChequesInHand = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genCustomerFinance.LoyaltyAmount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genCustomerFinance.LoyalityStartDate = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genCustomerFinance.LoyalityCardNo = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genCustomerFinance.OutstandingAmount = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genCustomerFinance.ChequeInHandAmount = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genCustomerFinance.CommissionCreditPeriod = dataReader.GetDecimal(21);
			}

			return tbl_genCustomerFinance;
		}
		/// <summary>
		/// This makes tbl_genCustomerFinance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCustomerFinance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCustomerFinance  tbl_genCustomerFinance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_depositAmount = new DataColumn("depositAmount" , typeof(decimal));
			DataColumn col_creditPeriod = new DataColumn("creditPeriod" , typeof(decimal));
			DataColumn col_creditLimit = new DataColumn("creditLimit" , typeof(decimal));
			DataColumn col_salesDues = new DataColumn("salesDues" , typeof(decimal));
			DataColumn col_creditBalance = new DataColumn("creditBalance" , typeof(decimal));
			DataColumn col_totalSales = new DataColumn("totalSales" , typeof(decimal));
			DataColumn col_DeposittedChequeCount = new DataColumn("DeposittedChequeCount" , typeof(decimal));
			DataColumn col_RealizedChequeCount = new DataColumn("RealizedChequeCount" , typeof(decimal));
			DataColumn col_ReturnedChequeCount = new DataColumn("ReturnedChequeCount" , typeof(decimal));
			DataColumn col_DeposittedChequeAmount = new DataColumn("DeposittedChequeAmount" , typeof(decimal));
			DataColumn col_RealizedChequeAmount = new DataColumn("RealizedChequeAmount" , typeof(decimal));
			DataColumn col_ReturnedChequeAmount = new DataColumn("ReturnedChequeAmount" , typeof(decimal));
			DataColumn col_openingBalance = new DataColumn("openingBalance" , typeof(decimal));
			DataColumn col_openingBalanceDate = new DataColumn("openingBalanceDate" , typeof(DateTime));
			DataColumn col_chequesInHand = new DataColumn("chequesInHand" , typeof(decimal));
			DataColumn col_loyaltyAmount = new DataColumn("loyaltyAmount" , typeof(decimal));
			DataColumn col_loyalityStartDate = new DataColumn("loyalityStartDate" , typeof(DateTime));
			DataColumn col_loyalityCardNo = new DataColumn("loyalityCardNo" , typeof(string));
			DataColumn col_outstandingAmount = new DataColumn("outstandingAmount" , typeof(decimal));
			DataColumn col_chequeInHandAmount = new DataColumn("chequeInHandAmount" , typeof(decimal));
			DataColumn col_commissionCreditPeriod = new DataColumn("commissionCreditPeriod" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_customer_ID,col_depositAmount,col_creditPeriod,col_creditLimit,col_salesDues,col_creditBalance,col_totalSales,col_DeposittedChequeCount,col_RealizedChequeCount,col_ReturnedChequeCount,col_DeposittedChequeAmount,col_RealizedChequeAmount,col_ReturnedChequeAmount,col_openingBalance,col_openingBalanceDate,col_chequesInHand,col_loyaltyAmount,col_loyalityStartDate,col_loyalityCardNo,col_outstandingAmount,col_chequeInHandAmount,col_commissionCreditPeriod,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCustomerFinance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCustomerFinance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCustomerFinance user) {
		DataRow drow = dt.NewRow();
		
			drow["customer_ID"] = user.customer_ID;
			drow["depositAmount"] = user.depositAmount;
			drow["creditPeriod"] = user.creditPeriod;
			drow["creditLimit"] = user.creditLimit;
			drow["salesDues"] = user.salesDues;
			drow["creditBalance"] = user.creditBalance;
			drow["totalSales"] = user.totalSales;
			drow["DeposittedChequeCount"] = user.DeposittedChequeCount;
			drow["RealizedChequeCount"] = user.RealizedChequeCount;
			drow["ReturnedChequeCount"] = user.ReturnedChequeCount;
			drow["DeposittedChequeAmount"] = user.DeposittedChequeAmount;
			drow["RealizedChequeAmount"] = user.RealizedChequeAmount;
			drow["ReturnedChequeAmount"] = user.ReturnedChequeAmount;
			drow["openingBalance"] = user.openingBalance;
			drow["openingBalanceDate"] = user.openingBalanceDate;
			drow["chequesInHand"] = user.chequesInHand;
			drow["loyaltyAmount"] = user.loyaltyAmount;
			drow["loyalityStartDate"] = user.loyalityStartDate;
			drow["loyalityCardNo"] = user.loyalityCardNo;
			drow["outstandingAmount"] = user.outstandingAmount;
			drow["chequeInHandAmount"] = user.chequeInHandAmount;
			drow["commissionCreditPeriod"] = user.commissionCreditPeriod;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
