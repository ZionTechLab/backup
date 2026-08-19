using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accChequeReconciliation_Detail {
		#region Fields
		private int line_No;
		private string reconciliation_ID;
		private string chequeRegister_ID;
		private decimal penaltyAmount;
		private string chequeStatus_ID;
		private DateTime dateReconciliation;
		private int companyAccount_ID;
		private int recSerialNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accChequeReconciliation_Detail class.
		/// </summary>
		public tbl_accChequeReconciliation_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accChequeReconciliation_Detail class.
		/// </summary>
		public tbl_accChequeReconciliation_Detail(int line_No, string reconciliation_ID, string chequeRegister_ID, decimal penaltyAmount, string chequeStatus_ID, DateTime dateReconciliation, int companyAccount_ID, int recSerialNo) {
			this.line_No = line_No;
			this.reconciliation_ID = reconciliation_ID;
			this.chequeRegister_ID = chequeRegister_ID;
			this.penaltyAmount = penaltyAmount;
			this.chequeStatus_ID = chequeStatus_ID;
			this.dateReconciliation = dateReconciliation;
			this.companyAccount_ID = companyAccount_ID;
			this.recSerialNo = recSerialNo;
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
		/// Gets or sets the Reconciliation_ID value.
		/// </summary>
		public string Reconciliation_ID {
			get { return reconciliation_ID; }
			set { reconciliation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PenaltyAmount value.
		/// </summary>
		public decimal PenaltyAmount {
			get { return penaltyAmount; }
			set { penaltyAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeStatus_ID value.
		/// </summary>
		public string ChequeStatus_ID {
			get { return chequeStatus_ID; }
			set { chequeStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReconciliation value.
		/// </summary>
		public DateTime DateReconciliation {
			get { return dateReconciliation; }
			set { dateReconciliation = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyAccount_ID value.
		/// </summary>
		public int CompanyAccount_ID {
			get { return companyAccount_ID; }
			set { companyAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecSerialNo value.
		/// </summary>
		public int RecSerialNo {
			get { return recSerialNo; }
			set { recSerialNo = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accChequeReconciliation_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeReconciliation_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@penaltyAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateReconciliation", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@penaltyAmount"].Value = penaltyAmount;
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@dateReconciliation"].Value = dateReconciliation;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accChequeReconciliation_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeReconciliation_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@penaltyAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateReconciliation", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@penaltyAmount"].Value = penaltyAmount;
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@dateReconciliation"].Value = dateReconciliation;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accChequeReconciliation_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeReconciliation_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeReconciliation_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByReconciliation_ID(string reconciliation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeReconciliation_DetailDeleteAllByReconciliation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accChequeReconciliation_Detail table.
		/// </summary>
		public static tbl_accChequeReconciliation_Detail Select(int line_No_Incoming, string reconciliation_ID_Incoming, string chequeRegister_ID_Incoming){

			tbl_accChequeReconciliation_Detail tbl_accChequeReconciliation_Detailins = new tbl_accChequeReconciliation_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeReconciliation_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID_Incoming;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accChequeReconciliation_Detailins = Maketbl_accChequeReconciliation_Detail(dataReader);
				} else {
					tbl_accChequeReconciliation_Detailins = null;
				}
			}
			scon.Close();
			return tbl_accChequeReconciliation_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeReconciliation_Detail table.
		/// </summary>
		public static List<tbl_accChequeReconciliation_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeReconciliation_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accChequeReconciliation_Detail> tbl_accChequeReconciliation_DetailList = new List<tbl_accChequeReconciliation_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accChequeReconciliation_Detail tbl_accChequeReconciliation_Detail = Maketbl_accChequeReconciliation_Detail(dataReader);
					tbl_accChequeReconciliation_DetailList.Add(tbl_accChequeReconciliation_Detail);
				}
			}
			scon.Close();
			return tbl_accChequeReconciliation_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeReconciliation_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accChequeReconciliation_Detail> SelectAllByReconciliation_ID(string reconciliation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeReconciliation_DetailSelectAllByReconciliation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
				List<tbl_accChequeReconciliation_Detail> tbl_accChequeReconciliation_DetailList = new List<tbl_accChequeReconciliation_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accChequeReconciliation_Detail tbl_accChequeReconciliation_Detail = Maketbl_accChequeReconciliation_Detail(dataReader);
					tbl_accChequeReconciliation_DetailList.Add(tbl_accChequeReconciliation_Detail);
				}
			}
			scon.Close();
			return tbl_accChequeReconciliation_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accChequeReconciliation_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accChequeReconciliation_Detail Maketbl_accChequeReconciliation_Detail(SqlDataReader dataReader) {
			tbl_accChequeReconciliation_Detail tbl_accChequeReconciliation_Detail = new tbl_accChequeReconciliation_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accChequeReconciliation_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accChequeReconciliation_Detail.Reconciliation_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accChequeReconciliation_Detail.ChequeRegister_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accChequeReconciliation_Detail.PenaltyAmount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accChequeReconciliation_Detail.ChequeStatus_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accChequeReconciliation_Detail.DateReconciliation = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accChequeReconciliation_Detail.CompanyAccount_ID = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accChequeReconciliation_Detail.RecSerialNo = dataReader.GetInt32(7);
			}

			return tbl_accChequeReconciliation_Detail;
		}
		/// <summary>
		/// This makes tbl_accChequeReconciliation_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accChequeReconciliation_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accChequeReconciliation_Detail  tbl_accChequeReconciliation_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_reconciliation_ID = new DataColumn("reconciliation_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_penaltyAmount = new DataColumn("penaltyAmount" , typeof(decimal));
			DataColumn col_chequeStatus_ID = new DataColumn("chequeStatus_ID" , typeof(string));
			DataColumn col_dateReconciliation = new DataColumn("dateReconciliation" , typeof(DateTime));
			DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID" , typeof(int));
			DataColumn col_recSerialNo = new DataColumn("recSerialNo" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_reconciliation_ID,col_chequeRegister_ID,col_penaltyAmount,col_chequeStatus_ID,col_dateReconciliation,col_companyAccount_ID,col_recSerialNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accChequeReconciliation_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accChequeReconciliation_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accChequeReconciliation_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["reconciliation_ID"] = user.reconciliation_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["penaltyAmount"] = user.penaltyAmount;
			drow["chequeStatus_ID"] = user.chequeStatus_ID;
			drow["dateReconciliation"] = user.dateReconciliation;
			drow["companyAccount_ID"] = user.companyAccount_ID;
			drow["recSerialNo"] = user.recSerialNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
