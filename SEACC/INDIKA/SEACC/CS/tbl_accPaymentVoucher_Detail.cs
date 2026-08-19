using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accPaymentVoucher_Detail {
		#region Fields
		private int line_No;
		private string paymentVoucher_ID;
		private string accountPayableNote_ID;
		private string chequeRegister_ID;
		private string debitNote_ID;
		private string customerRefundableNote_ID;
		private string journalEntry_ID_DR;
		private int lineNo_JEDR;
		private string journalEntry_ID_CR;
		private int lineNo_JECR;
		private string narration;
		private decimal settleAmount;
		private bool isSettled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accPaymentVoucher_Detail class.
		/// </summary>
		public tbl_accPaymentVoucher_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accPaymentVoucher_Detail class.
		/// </summary>
		public tbl_accPaymentVoucher_Detail(int line_No, string paymentVoucher_ID, string accountPayableNote_ID, string chequeRegister_ID, string debitNote_ID, string customerRefundableNote_ID, string journalEntry_ID_DR, int lineNo_JEDR, string journalEntry_ID_CR, int lineNo_JECR, string narration, decimal settleAmount, bool isSettled) {
			this.line_No = line_No;
			this.paymentVoucher_ID = paymentVoucher_ID;
			this.accountPayableNote_ID = accountPayableNote_ID;
			this.chequeRegister_ID = chequeRegister_ID;
			this.debitNote_ID = debitNote_ID;
			this.customerRefundableNote_ID = customerRefundableNote_ID;
			this.journalEntry_ID_DR = journalEntry_ID_DR;
			this.lineNo_JEDR = lineNo_JEDR;
			this.journalEntry_ID_CR = journalEntry_ID_CR;
			this.lineNo_JECR = lineNo_JECR;
			this.narration = narration;
			this.settleAmount = settleAmount;
			this.isSettled = isSettled;
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
		/// Gets or sets the PaymentVoucher_ID value.
		/// </summary>
		public string PaymentVoucher_ID {
			get { return paymentVoucher_ID; }
			set { paymentVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountPayableNote_ID value.
		/// </summary>
		public string AccountPayableNote_ID {
			get { return accountPayableNote_ID; }
			set { accountPayableNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DebitNote_ID value.
		/// </summary>
		public string DebitNote_ID {
			get { return debitNote_ID; }
			set { debitNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerRefundableNote_ID value.
		/// </summary>
		public string CustomerRefundableNote_ID {
			get { return customerRefundableNote_ID; }
			set { customerRefundableNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the JournalEntry_ID_DR value.
		/// </summary>
		public string JournalEntry_ID_DR {
			get { return journalEntry_ID_DR; }
			set { journalEntry_ID_DR = value; }
		}
		
		/// <summary>
		/// Gets or sets the LineNo_JEDR value.
		/// </summary>
		public int LineNo_JEDR {
			get { return lineNo_JEDR; }
			set { lineNo_JEDR = value; }
		}
		
		/// <summary>
		/// Gets or sets the JournalEntry_ID_CR value.
		/// </summary>
		public string JournalEntry_ID_CR {
			get { return journalEntry_ID_CR; }
			set { journalEntry_ID_CR = value; }
		}
		
		/// <summary>
		/// Gets or sets the LineNo_JECR value.
		/// </summary>
		public int LineNo_JECR {
			get { return lineNo_JECR; }
			set { lineNo_JECR = value; }
		}
		
		/// <summary>
		/// Gets or sets the Narration value.
		/// </summary>
		public string Narration {
			get { return narration; }
			set { narration = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettleAmount value.
		/// </summary>
		public decimal SettleAmount {
			get { return settleAmount; }
			set { settleAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSettled value.
		/// </summary>
		public bool IsSettled {
			get { return isSettled; }
			set { isSettled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accPaymentVoucher_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerRefundableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@journalEntry_ID_DR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lineNo_JEDR", SqlDbType.Int,4);
			scom.Parameters.Add("@journalEntry_ID_CR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lineNo_JECR", SqlDbType.Int,4);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,20);
			scom.Parameters.Add("@settleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@customerRefundableNote_ID"].Value = customerRefundableNote_ID;
			scom.Parameters["@journalEntry_ID_DR"].Value = journalEntry_ID_DR;
			scom.Parameters["@lineNo_JEDR"].Value = lineNo_JEDR;
			scom.Parameters["@journalEntry_ID_CR"].Value = journalEntry_ID_CR;
			scom.Parameters["@lineNo_JECR"].Value = lineNo_JECR;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@settleAmount"].Value = settleAmount;
			scom.Parameters["@isSettled"].Value = isSettled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
        /// <summary>
        /// Updates a record in the tbl_accPaymentVoucher_Detail table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
            scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerRefundableNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@journalEntry_ID_DR", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@lineNo_JEDR", SqlDbType.Int, 4);
            scom.Parameters.Add("@journalEntry_ID_CR", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@lineNo_JECR", SqlDbType.Int, 4);
            scom.Parameters.Add("@narration", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@settleAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@isSettled", SqlDbType.Bit, 1);


            scom.Parameters["@line_No"].Value = line_No;
            scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
            scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
            scom.Parameters["@customerRefundableNote_ID"].Value = customerRefundableNote_ID;
            scom.Parameters["@journalEntry_ID_DR"].Value = journalEntry_ID_DR;
            scom.Parameters["@lineNo_JEDR"].Value = lineNo_JEDR;
            scom.Parameters["@journalEntry_ID_CR"].Value = journalEntry_ID_CR;
            scom.Parameters["@lineNo_JECR"].Value = lineNo_JECR;
            scom.Parameters["@narration"].Value = narration;
            scom.Parameters["@settleAmount"].Value = settleAmount;
            scom.Parameters["@isSettled"].Value = isSettled;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
        /// <summary>
		/// Deletes a record from the tbl_accPaymentVoucher_Detail table by its primary key.
		/// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerRefundableNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@journalEntry_ID_DR", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@lineNo_JEDR", SqlDbType.Int, 4);
            scom.Parameters.Add("@journalEntry_ID_CR", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@lineNo_JECR", SqlDbType.Int, 4);

            scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
            scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
            scom.Parameters["@customerRefundableNote_ID"].Value = customerRefundableNote_ID;
            scom.Parameters["@journalEntry_ID_DR"].Value = journalEntry_ID_DR;
            scom.Parameters["@lineNo_JEDR"].Value = lineNo_JEDR;
            scom.Parameters["@journalEntry_ID_CR"].Value = journalEntry_ID_CR;
            scom.Parameters["@lineNo_JECR"].Value = lineNo_JECR;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
        /// <summary>
        /// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
        /// </summary>
        public static void DeleteAllByAccountPayableNote_ID(string accountPayableNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailDeleteAllByAccountPayableNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByDebitNote_ID(string debitNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailDeleteAllByDebitNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByLineNo_JECR_JournalEntry_ID_CR(int lineNo_JECR, string journalEntry_ID_CR) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailDeleteAllByLineNo_JECR_JournalEntry_ID_CR", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@lineNo_JECR", SqlDbType.Int,4);
			scom.Parameters.Add("@journalEntry_ID_CR", SqlDbType.VarChar,20);
			scom.Parameters["@lineNo_JECR"].Value = lineNo_JECR;
			scom.Parameters["@journalEntry_ID_CR"].Value = journalEntry_ID_CR;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaymentVoucher_ID(string paymentVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailDeleteAllByPaymentVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByLineNo_JEDR_JournalEntry_ID_DR(int lineNo_JEDR, string journalEntry_ID_DR) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailDeleteAllByLineNo_JEDR_JournalEntry_ID_DR", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@lineNo_JEDR", SqlDbType.Int,4);
			scom.Parameters.Add("@journalEntry_ID_DR", SqlDbType.VarChar,20);
			scom.Parameters["@lineNo_JEDR"].Value = lineNo_JEDR;
			scom.Parameters["@journalEntry_ID_DR"].Value = journalEntry_ID_DR;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table.
		/// </summary>
		public static List<tbl_accPaymentVoucher_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accPaymentVoucher_Detail> tbl_accPaymentVoucher_DetailList = new List<tbl_accPaymentVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_Detail tbl_accPaymentVoucher_Detail = Maketbl_accPaymentVoucher_Detail(dataReader);
					tbl_accPaymentVoucher_DetailList.Add(tbl_accPaymentVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accPaymentVoucher_Detail> SelectAllByAccountPayableNote_ID(string accountPayableNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailSelectAllByAccountPayableNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
				List<tbl_accPaymentVoucher_Detail> tbl_accPaymentVoucher_DetailList = new List<tbl_accPaymentVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_Detail tbl_accPaymentVoucher_Detail = Maketbl_accPaymentVoucher_Detail(dataReader);
					tbl_accPaymentVoucher_DetailList.Add(tbl_accPaymentVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accPaymentVoucher_Detail> SelectAllByDebitNote_ID(string debitNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailSelectAllByDebitNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
				List<tbl_accPaymentVoucher_Detail> tbl_accPaymentVoucher_DetailList = new List<tbl_accPaymentVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_Detail tbl_accPaymentVoucher_Detail = Maketbl_accPaymentVoucher_Detail(dataReader);
					tbl_accPaymentVoucher_DetailList.Add(tbl_accPaymentVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accPaymentVoucher_Detail> SelectAllByLineNo_JECR_JournalEntry_ID_CR(int lineNo_JECR, string journalEntry_ID_CR) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailSelectAllByLineNo_JECR_JournalEntry_ID_CR", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@lineNo_JECR", SqlDbType.Int,4);
			scom.Parameters.Add("@journalEntry_ID_CR", SqlDbType.VarChar,20);
			scom.Parameters["@lineNo_JECR"].Value = lineNo_JECR;
			scom.Parameters["@journalEntry_ID_CR"].Value = journalEntry_ID_CR;
				List<tbl_accPaymentVoucher_Detail> tbl_accPaymentVoucher_DetailList = new List<tbl_accPaymentVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_Detail tbl_accPaymentVoucher_Detail = Maketbl_accPaymentVoucher_Detail(dataReader);
					tbl_accPaymentVoucher_DetailList.Add(tbl_accPaymentVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accPaymentVoucher_Detail> SelectAllByPaymentVoucher_ID(string paymentVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailSelectAllByPaymentVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
				List<tbl_accPaymentVoucher_Detail> tbl_accPaymentVoucher_DetailList = new List<tbl_accPaymentVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_Detail tbl_accPaymentVoucher_Detail = Maketbl_accPaymentVoucher_Detail(dataReader);
					tbl_accPaymentVoucher_DetailList.Add(tbl_accPaymentVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accPaymentVoucher_Detail> SelectAllByLineNo_JEDR_JournalEntry_ID_DR(int lineNo_JEDR, string journalEntry_ID_DR) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_DetailSelectAllByLineNo_JEDR_JournalEntry_ID_DR", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@lineNo_JEDR", SqlDbType.Int,4);
			scom.Parameters.Add("@journalEntry_ID_DR", SqlDbType.VarChar,20);
			scom.Parameters["@lineNo_JEDR"].Value = lineNo_JEDR;
			scom.Parameters["@journalEntry_ID_DR"].Value = journalEntry_ID_DR;
				List<tbl_accPaymentVoucher_Detail> tbl_accPaymentVoucher_DetailList = new List<tbl_accPaymentVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_Detail tbl_accPaymentVoucher_Detail = Maketbl_accPaymentVoucher_Detail(dataReader);
					tbl_accPaymentVoucher_DetailList.Add(tbl_accPaymentVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accPaymentVoucher_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accPaymentVoucher_Detail Maketbl_accPaymentVoucher_Detail(SqlDataReader dataReader) {
			tbl_accPaymentVoucher_Detail tbl_accPaymentVoucher_Detail = new tbl_accPaymentVoucher_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accPaymentVoucher_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accPaymentVoucher_Detail.PaymentVoucher_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accPaymentVoucher_Detail.AccountPayableNote_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accPaymentVoucher_Detail.ChequeRegister_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accPaymentVoucher_Detail.DebitNote_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accPaymentVoucher_Detail.CustomerRefundableNote_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accPaymentVoucher_Detail.JournalEntry_ID_DR = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accPaymentVoucher_Detail.LineNo_JEDR = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accPaymentVoucher_Detail.JournalEntry_ID_CR = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accPaymentVoucher_Detail.LineNo_JECR = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accPaymentVoucher_Detail.Narration = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accPaymentVoucher_Detail.SettleAmount = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accPaymentVoucher_Detail.IsSettled = dataReader.GetBoolean(12);
			}

			return tbl_accPaymentVoucher_Detail;
		}
		/// <summary>
		/// This makes tbl_accPaymentVoucher_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accPaymentVoucher_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accPaymentVoucher_Detail  tbl_accPaymentVoucher_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_paymentVoucher_ID = new DataColumn("paymentVoucher_ID" , typeof(string));
			DataColumn col_accountPayableNote_ID = new DataColumn("accountPayableNote_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_debitNote_ID = new DataColumn("debitNote_ID" , typeof(string));
			DataColumn col_customerRefundableNote_ID = new DataColumn("customerRefundableNote_ID" , typeof(string));
			DataColumn col_journalEntry_ID_DR = new DataColumn("journalEntry_ID_DR" , typeof(string));
			DataColumn col_lineNo_JEDR = new DataColumn("lineNo_JEDR" , typeof(int));
			DataColumn col_journalEntry_ID_CR = new DataColumn("journalEntry_ID_CR" , typeof(string));
			DataColumn col_lineNo_JECR = new DataColumn("lineNo_JECR" , typeof(int));
			DataColumn col_narration = new DataColumn("narration" , typeof(string));
			DataColumn col_settleAmount = new DataColumn("settleAmount" , typeof(decimal));
			DataColumn col_isSettled = new DataColumn("isSettled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_paymentVoucher_ID,col_accountPayableNote_ID,col_chequeRegister_ID,col_debitNote_ID,col_customerRefundableNote_ID,col_journalEntry_ID_DR,col_lineNo_JEDR,col_journalEntry_ID_CR,col_lineNo_JECR,col_narration,col_settleAmount,col_isSettled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accPaymentVoucher_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accPaymentVoucher_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accPaymentVoucher_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["paymentVoucher_ID"] = user.paymentVoucher_ID;
			drow["accountPayableNote_ID"] = user.accountPayableNote_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["debitNote_ID"] = user.debitNote_ID;
			drow["customerRefundableNote_ID"] = user.customerRefundableNote_ID;
			drow["journalEntry_ID_DR"] = user.journalEntry_ID_DR;
			drow["lineNo_JEDR"] = user.lineNo_JEDR;
			drow["journalEntry_ID_CR"] = user.journalEntry_ID_CR;
			drow["lineNo_JECR"] = user.lineNo_JECR;
			drow["narration"] = user.narration;
			drow["settleAmount"] = user.settleAmount;
			drow["isSettled"] = user.isSettled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
