using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accReceiptMultiple_Cheque {
		#region Fields
		private int line_No;
		private string receipt_ID;
		private string chequeRegister_ID;
		private decimal chequeAmount;
		private DateTime dateCheque;
		private decimal seattleAmount;
		private string bank_ID;
		private string branch_ID;
		private string chequeNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accReceiptMultiple_Cheque class.
		/// </summary>
		public tbl_accReceiptMultiple_Cheque() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accReceiptMultiple_Cheque class.
		/// </summary>
		public tbl_accReceiptMultiple_Cheque(int line_No, string receipt_ID, string chequeRegister_ID, decimal chequeAmount, DateTime dateCheque, decimal seattleAmount, string bank_ID, string branch_ID, string chequeNo) {
			this.line_No = line_No;
			this.receipt_ID = receipt_ID;
			this.chequeRegister_ID = chequeRegister_ID;
			this.chequeAmount = chequeAmount;
			this.dateCheque = dateCheque;
			this.seattleAmount = seattleAmount;
			this.bank_ID = bank_ID;
			this.branch_ID = branch_ID;
			this.chequeNo = chequeNo;
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
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount value.
		/// </summary>
		public decimal ChequeAmount {
			get { return chequeAmount; }
			set { chequeAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCheque value.
		/// </summary>
		public DateTime DateCheque {
			get { return dateCheque; }
			set { dateCheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the SeattleAmount value.
		/// </summary>
		public decimal SeattleAmount {
			get { return seattleAmount; }
			set { seattleAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeNo value.
		/// </summary>
		public string ChequeNo {
			get { return chequeNo; }
			set { chequeNo = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accReceiptMultiple_Cheque table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dateCheque", SqlDbType.DateTime,8);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeNo", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@dateCheque"].Value = dateCheque;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@chequeNo"].Value = chequeNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accReceiptMultiple_Cheque table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dateCheque", SqlDbType.DateTime,8);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeNo", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@dateCheque"].Value = dateCheque;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@chequeNo"].Value = chequeNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accReceiptMultiple_Cheque table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptMultiple_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptMultiple_Cheque table by a foreign key.
		/// </summary>
		public static void DeleteAllByReceipt_ID(string receipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeDeleteAllByReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accReceiptMultiple_Cheque table.
		/// </summary>
		public static tbl_accReceiptMultiple_Cheque Select(string receipt_ID_Incoming, string chequeRegister_ID_Incoming){

			tbl_accReceiptMultiple_Cheque tbl_accReceiptMultiple_Chequeins = new tbl_accReceiptMultiple_Cheque();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accReceiptMultiple_Chequeins = Maketbl_accReceiptMultiple_Cheque(dataReader);
				} else {
					tbl_accReceiptMultiple_Chequeins = null;
				}
			}
			scon.Close();
			return tbl_accReceiptMultiple_Chequeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptMultiple_Cheque table.
		/// </summary>
		public static List<tbl_accReceiptMultiple_Cheque> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accReceiptMultiple_Cheque> tbl_accReceiptMultiple_ChequeList = new List<tbl_accReceiptMultiple_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptMultiple_Cheque tbl_accReceiptMultiple_Cheque = Maketbl_accReceiptMultiple_Cheque(dataReader);
					tbl_accReceiptMultiple_ChequeList.Add(tbl_accReceiptMultiple_Cheque);
				}
			}
			scon.Close();
			return tbl_accReceiptMultiple_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptMultiple_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptMultiple_Cheque> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_accReceiptMultiple_Cheque> tbl_accReceiptMultiple_ChequeList = new List<tbl_accReceiptMultiple_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptMultiple_Cheque tbl_accReceiptMultiple_Cheque = Maketbl_accReceiptMultiple_Cheque(dataReader);
					tbl_accReceiptMultiple_ChequeList.Add(tbl_accReceiptMultiple_Cheque);
				}
			}
			scon.Close();
			return tbl_accReceiptMultiple_ChequeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptMultiple_Cheque table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptMultiple_Cheque> SelectAllByReceipt_ID(string receipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptMultiple_ChequeSelectAllByReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
				List<tbl_accReceiptMultiple_Cheque> tbl_accReceiptMultiple_ChequeList = new List<tbl_accReceiptMultiple_Cheque>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptMultiple_Cheque tbl_accReceiptMultiple_Cheque = Maketbl_accReceiptMultiple_Cheque(dataReader);
					tbl_accReceiptMultiple_ChequeList.Add(tbl_accReceiptMultiple_Cheque);
				}
			}
			scon.Close();
			return tbl_accReceiptMultiple_ChequeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accReceiptMultiple_Cheque class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accReceiptMultiple_Cheque Maketbl_accReceiptMultiple_Cheque(SqlDataReader dataReader) {
			tbl_accReceiptMultiple_Cheque tbl_accReceiptMultiple_Cheque = new tbl_accReceiptMultiple_Cheque();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accReceiptMultiple_Cheque.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accReceiptMultiple_Cheque.Receipt_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accReceiptMultiple_Cheque.ChequeRegister_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accReceiptMultiple_Cheque.ChequeAmount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accReceiptMultiple_Cheque.DateCheque = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accReceiptMultiple_Cheque.SeattleAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accReceiptMultiple_Cheque.Bank_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accReceiptMultiple_Cheque.Branch_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accReceiptMultiple_Cheque.ChequeNo = dataReader.GetString(8);
			}

			return tbl_accReceiptMultiple_Cheque;
		}
		/// <summary>
		/// This makes tbl_accReceiptMultiple_Cheque datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accReceiptMultiple_Cheque object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accReceiptMultiple_Cheque  tbl_accReceiptMultiple_Cheque   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_dateCheque = new DataColumn("dateCheque" , typeof(DateTime));
			DataColumn col_seattleAmount = new DataColumn("seattleAmount" , typeof(decimal));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_chequeNo = new DataColumn("chequeNo" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_receipt_ID,col_chequeRegister_ID,col_chequeAmount,col_dateCheque,col_seattleAmount,col_bank_ID,col_branch_ID,col_chequeNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accReceiptMultiple_Cheque datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accReceiptMultiple_Cheque object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accReceiptMultiple_Cheque user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["receipt_ID"] = user.receipt_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["chequeAmount"] = user.chequeAmount;
			drow["dateCheque"] = user.dateCheque;
			drow["seattleAmount"] = user.seattleAmount;
			drow["bank_ID"] = user.bank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["chequeNo"] = user.chequeNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
