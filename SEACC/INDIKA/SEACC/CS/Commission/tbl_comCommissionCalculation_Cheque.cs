using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_comCommissionCalculation_Cheque {
		#region Fields
		private Int64 comCalcChqIndex;
		private Int64 comCalcIndex;
		private Int64 periodIndex;
		private string salesRep_ID;
		private string areaManager_ID;
		private string salesManager_ID;
		private string collector_ID;
		private int roleOfEmplyee;
		private string chequeRegister_ID;
		private string invoice_ID;
		private bool isChequeDateDed;
		private bool isRchequeDed_thisPeriod;
		private bool isRchequeDed_prvPeriod;
		private bool isSelect_forDed;
		private int dateSlab;
		private decimal ded_Rate;
		private decimal ded_Amount;
		private string remarks;
		public decimal allocatedAmount;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_comCommissionCalculation_Cheque class.
		/// </summary>
		public tbl_comCommissionCalculation_Cheque() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_comCommissionCalculation_Cheque class.
		/// </summary>
		public tbl_comCommissionCalculation_Cheque(Int64 comCalcChqIndex, Int64 comCalcIndex, Int64 periodIndex, string salesRep_ID, string areaManager_ID, string salesManager_ID, string collector_ID, int roleOfEmplyee, string chequeRegister_ID, string invoice_ID, bool isChequeDateDed, bool isRchequeDed_thisPeriod, bool isRchequeDed_prvPeriod, bool isSelect_forDed, int dateSlab, decimal ded_Rate, decimal ded_Amount, string remarks,decimal allocatedAmount) {
			this.comCalcChqIndex = comCalcChqIndex;
			this.comCalcIndex = comCalcIndex;
			this.periodIndex = periodIndex;
			this.salesRep_ID = salesRep_ID;
			this.areaManager_ID = areaManager_ID;
			this.salesManager_ID = salesManager_ID;
			this.collector_ID = collector_ID;
			this.roleOfEmplyee = roleOfEmplyee;
			this.chequeRegister_ID = chequeRegister_ID;
			this.invoice_ID = invoice_ID;
			this.isChequeDateDed = isChequeDateDed;
			this.isRchequeDed_thisPeriod = isRchequeDed_thisPeriod;
			this.isRchequeDed_prvPeriod = isRchequeDed_prvPeriod;
			this.isSelect_forDed = isSelect_forDed;
			this.dateSlab = dateSlab;
			this.ded_Rate = ded_Rate;
			this.ded_Amount = ded_Amount;
			this.remarks = remarks;
			this.allocatedAmount = allocatedAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ComCalcChqIndex value.
		/// </summary>
		public Int64 ComCalcChqIndex {
			get { return comCalcChqIndex; }
			set { comCalcChqIndex = value; }
		}
		
		/// <summary>
		/// Gets or sets the ComCalcIndex value.
		/// </summary>
		public Int64 ComCalcIndex {
			get { return comCalcIndex; }
			set { comCalcIndex = value; }
		}
		
		/// <summary>
		/// Gets or sets the PeriodIndex value.
		/// </summary>
		public Int64 PeriodIndex {
			get { return periodIndex; }
			set { periodIndex = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesRep_ID value.
		/// </summary>
		public string SalesRep_ID {
			get { return salesRep_ID; }
			set { salesRep_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AreaManager_ID value.
		/// </summary>
		public string AreaManager_ID {
			get { return areaManager_ID; }
			set { areaManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesManager_ID value.
		/// </summary>
		public string SalesManager_ID {
			get { return salesManager_ID; }
			set { salesManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Collector_ID value.
		/// </summary>
		public string Collector_ID {
			get { return collector_ID; }
			set { collector_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RoleOfEmplyee value.
		/// </summary>
		public int RoleOfEmplyee {
			get { return roleOfEmplyee; }
			set { roleOfEmplyee = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChequeDateDed value.
		/// </summary>
		public bool IsChequeDateDed {
			get { return isChequeDateDed; }
			set { isChequeDateDed = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRchequeDed_thisPeriod value.
		/// </summary>
		public bool IsRchequeDed_thisPeriod {
			get { return isRchequeDed_thisPeriod; }
			set { isRchequeDed_thisPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRchequeDed_prvPeriod value.
		/// </summary>
		public bool IsRchequeDed_prvPeriod {
			get { return isRchequeDed_prvPeriod; }
			set { isRchequeDed_prvPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSelect_forDed value.
		/// </summary>
		public bool IsSelect_forDed {
			get { return isSelect_forDed; }
			set { isSelect_forDed = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateSlab value.
		/// </summary>
		public int DateSlab {
			get { return dateSlab; }
			set { dateSlab = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_Rate value.
		/// </summary>
		public decimal Ded_Rate {
			get { return ded_Rate; }
			set { ded_Rate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_Amount value.
		/// </summary>
		public decimal Ded_Amount {
			get { return ded_Amount; }
			set { ded_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_comCommissionCalculation_Cheque table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@comCalcChqIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@comCalcIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@periodIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@collector_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@roleOfEmplyee", SqlDbType.Int,4);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isChequeDateDed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRchequeDed_thisPeriod", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRchequeDed_prvPeriod", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSelect_forDed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateSlab", SqlDbType.Int,4);
			scom.Parameters.Add("@ded_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 	scom.Parameters.Add("@allocatedAmount", SqlDbType.Decimal,9);

			scom.Parameters["@comCalcChqIndex"].Value = comCalcChqIndex;
			scom.Parameters["@comCalcIndex"].Value = comCalcIndex;
			scom.Parameters["@periodIndex"].Value = periodIndex;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@collector_ID"].Value = collector_ID;
			scom.Parameters["@roleOfEmplyee"].Value = roleOfEmplyee;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@isChequeDateDed"].Value = isChequeDateDed;
			scom.Parameters["@isRchequeDed_thisPeriod"].Value = isRchequeDed_thisPeriod;
			scom.Parameters["@isRchequeDed_prvPeriod"].Value = isRchequeDed_prvPeriod;
			scom.Parameters["@isSelect_forDed"].Value = isSelect_forDed;
			scom.Parameters["@dateSlab"].Value = dateSlab;
			scom.Parameters["@ded_Rate"].Value = ded_Rate;
			scom.Parameters["@ded_Amount"].Value = ded_Amount;
			scom.Parameters["@remarks"].Value = remarks;
 	scom.Parameters["@allocatedAmount"].Value = allocatedAmount;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_comCommissionCalculation_Cheque table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@comCalcChqIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@comCalcIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@periodIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@collector_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@roleOfEmplyee", SqlDbType.Int,4);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isChequeDateDed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRchequeDed_thisPeriod", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRchequeDed_prvPeriod", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSelect_forDed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateSlab", SqlDbType.Int,4);
			scom.Parameters.Add("@ded_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 		scom.Parameters.Add("@allocatedAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@comCalcChqIndex"].Value = comCalcChqIndex;
			scom.Parameters["@comCalcIndex"].Value = comCalcIndex;
			scom.Parameters["@periodIndex"].Value = periodIndex;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@collector_ID"].Value = collector_ID;
			scom.Parameters["@roleOfEmplyee"].Value = roleOfEmplyee;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@isChequeDateDed"].Value = isChequeDateDed;
			scom.Parameters["@isRchequeDed_thisPeriod"].Value = isRchequeDed_thisPeriod;
			scom.Parameters["@isRchequeDed_prvPeriod"].Value = isRchequeDed_prvPeriod;
			scom.Parameters["@isSelect_forDed"].Value = isSelect_forDed;
			scom.Parameters["@dateSlab"].Value = dateSlab;
			scom.Parameters["@ded_Rate"].Value = ded_Rate;
			scom.Parameters["@ded_Amount"].Value = ded_Amount;
			scom.Parameters["@remarks"].Value = remarks;
 	scom.Parameters["@allocatedAmount"].Value = allocatedAmount;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_comCommissionCalculation_Cheque table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@comCalcChqIndex", SqlDbType.BigInt,8);
			scom.Parameters["@comCalcChqIndex"].Value = comCalcChqIndex;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesRep_ID(string salesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDeleteAllBySalesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllByCollector_ID(string collector_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDeleteAllByCollector_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@collector_ID", SqlDbType.VarChar,20);
			scom.Parameters["@collector_ID"].Value = collector_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllByPeriodIndex(Int64 periodIndex) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDeleteAllByPeriodIndex", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@periodIndex", SqlDbType.BigInt,8);
			scom.Parameters["@periodIndex"].Value = periodIndex;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesManager_ID(string salesManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDeleteAllBySalesManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllByComCalcIndex(Int64 comCalcIndex) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDeleteAllByComCalcIndex", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@comCalcIndex", SqlDbType.BigInt,8);
			scom.Parameters["@comCalcIndex"].Value = comCalcIndex;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllByAreaManager_ID(string areaManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDeleteAllByAreaManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_comCommissionCalculation_Cheque table.
		/// </summary>
		public static tbl_comCommissionCalculation_Cheque Select(Int64 comCalcChqIndex_Incoming){

			tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Chequeins = new tbl_comCommissionCalculation_Cheque();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@comCalcChqIndex", SqlDbType.BigInt,8);
			scom.Parameters["@comCalcChqIndex"].Value = comCalcChqIndex_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_comCommissionCalculation_Chequeins = Maketbl_comCommissionCalculation_Cheque(dataReader);
				} else {
					tbl_comCommissionCalculation_Chequeins = null;
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_Chequeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAllBySalesRep_ID(string salesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAllBySalesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAllByCollector_ID(string collector_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAllByCollector_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@collector_ID", SqlDbType.VarChar,20);
			scom.Parameters["@collector_ID"].Value = collector_ID;
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAllByPeriodIndex(Int64 periodIndex) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAllByPeriodIndex", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@periodIndex", SqlDbType.BigInt,8);
			scom.Parameters["@periodIndex"].Value = periodIndex;
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAllBySalesManager_ID(string salesManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAllBySalesManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAllByComCalcIndex(Int64 comCalcIndex) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAllByComCalcIndex", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@comCalcIndex", SqlDbType.BigInt,8);
			scom.Parameters["@comCalcIndex"].Value = comCalcIndex;
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAllByAreaManager_ID(string areaManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAllByAreaManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation_Cheque> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculation_ChequeSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_comCommissionCalculation_Cheque> tbl_comCommissionCalculation_ChequeList = new List<tbl_comCommissionCalculation_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = Maketbl_comCommissionCalculation_Cheque(dataReader);
					tbl_comCommissionCalculation_ChequeList.Add(tbl_comCommissionCalculation_Cheque);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculation_ChequeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_comCommissionCalculation_Cheque class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_comCommissionCalculation_Cheque Maketbl_comCommissionCalculation_Cheque(SqlDataReader dataReader) {
			tbl_comCommissionCalculation_Cheque tbl_comCommissionCalculation_Cheque = new tbl_comCommissionCalculation_Cheque();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_comCommissionCalculation_Cheque.ComCalcChqIndex = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_comCommissionCalculation_Cheque.ComCalcIndex = dataReader.GetInt64(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_comCommissionCalculation_Cheque.PeriodIndex = dataReader.GetInt64(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_comCommissionCalculation_Cheque.SalesRep_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_comCommissionCalculation_Cheque.AreaManager_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_comCommissionCalculation_Cheque.SalesManager_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_comCommissionCalculation_Cheque.Collector_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_comCommissionCalculation_Cheque.RoleOfEmplyee = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_comCommissionCalculation_Cheque.ChequeRegister_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_comCommissionCalculation_Cheque.Invoice_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_comCommissionCalculation_Cheque.IsChequeDateDed = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_comCommissionCalculation_Cheque.IsRchequeDed_thisPeriod = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_comCommissionCalculation_Cheque.IsRchequeDed_prvPeriod = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_comCommissionCalculation_Cheque.IsSelect_forDed = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_comCommissionCalculation_Cheque.DateSlab = dataReader.GetInt32(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_comCommissionCalculation_Cheque.Ded_Rate = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_comCommissionCalculation_Cheque.Ded_Amount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_comCommissionCalculation_Cheque.Remarks = dataReader.GetString(17);
			}
if (dataReader.IsDBNull(18) == false) {
				tbl_comCommissionCalculation_Cheque.allocatedAmount = dataReader.GetDecimal(18);
			}
			return tbl_comCommissionCalculation_Cheque;
		}
		/// <summary>
		/// This makes tbl_comCommissionCalculation_Cheque datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_comCommissionCalculation_Cheque object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_comCommissionCalculation_Cheque  tbl_comCommissionCalculation_Cheque   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_comCalcChqIndex = new DataColumn("comCalcChqIndex" , typeof(long));
			DataColumn col_comCalcIndex = new DataColumn("comCalcIndex" , typeof(long));
			DataColumn col_periodIndex = new DataColumn("periodIndex" , typeof(long));
			DataColumn col_salesRep_ID = new DataColumn("salesRep_ID" , typeof(string));
			DataColumn col_areaManager_ID = new DataColumn("areaManager_ID" , typeof(string));
			DataColumn col_salesManager_ID = new DataColumn("salesManager_ID" , typeof(string));
			DataColumn col_collector_ID = new DataColumn("collector_ID" , typeof(string));
			DataColumn col_roleOfEmplyee = new DataColumn("roleOfEmplyee" , typeof(int));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_isChequeDateDed = new DataColumn("isChequeDateDed" , typeof(bool));
			DataColumn col_isRchequeDed_thisPeriod = new DataColumn("isRchequeDed_thisPeriod" , typeof(bool));
			DataColumn col_isRchequeDed_prvPeriod = new DataColumn("isRchequeDed_prvPeriod" , typeof(bool));
			DataColumn col_isSelect_forDed = new DataColumn("isSelect_forDed" , typeof(bool));
			DataColumn col_dateSlab = new DataColumn("dateSlab" , typeof(int));
			DataColumn col_ded_Rate = new DataColumn("ded_Rate" , typeof(decimal));
			DataColumn col_ded_Amount = new DataColumn("ded_Amount" , typeof(decimal));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_comCalcChqIndex,col_comCalcIndex,col_periodIndex,col_salesRep_ID,col_areaManager_ID,col_salesManager_ID,col_collector_ID,col_roleOfEmplyee,col_chequeRegister_ID,col_invoice_ID,col_isChequeDateDed,col_isRchequeDed_thisPeriod,col_isRchequeDed_prvPeriod,col_isSelect_forDed,col_dateSlab,col_ded_Rate,col_ded_Amount,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_comCommissionCalculation_Cheque datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_comCommissionCalculation_Cheque object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_comCommissionCalculation_Cheque user) {
		DataRow drow = dt.NewRow();
		
			drow["comCalcChqIndex"] = user.comCalcChqIndex;
			drow["comCalcIndex"] = user.comCalcIndex;
			drow["periodIndex"] = user.periodIndex;
			drow["salesRep_ID"] = user.salesRep_ID;
			drow["areaManager_ID"] = user.areaManager_ID;
			drow["salesManager_ID"] = user.salesManager_ID;
			drow["collector_ID"] = user.collector_ID;
			drow["roleOfEmplyee"] = user.roleOfEmplyee;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["isChequeDateDed"] = user.isChequeDateDed;
			drow["isRchequeDed_thisPeriod"] = user.isRchequeDed_thisPeriod;
			drow["isRchequeDed_prvPeriod"] = user.isRchequeDed_prvPeriod;
			drow["isSelect_forDed"] = user.isSelect_forDed;
			drow["dateSlab"] = user.dateSlab;
			drow["ded_Rate"] = user.ded_Rate;
			drow["ded_Amount"] = user.ded_Amount;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
