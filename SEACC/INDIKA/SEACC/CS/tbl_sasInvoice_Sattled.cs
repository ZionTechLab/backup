using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasInvoice_Sattled {
		#region Fields
		private string settled_ID;
		private string invoice_ID;
		private string journalEntry_ID_DR;
		private int lineNo_JEDR;
		private string posTransaction_ID;
		private string receipt_ID;
		private string posReceipt_ID;
		private string chequeRegister_ID;
		private string creditNote_ID;
		private string debitNote_ID;
		private string journalEntry_ID_CR;
		private int lineNo_JECR;
		private string paymentMethod_ID;
		private string paymentMethodTransection_ID;
		private DateTime sattledDate;
		private decimal sattledAmount;
		private bool isDebit;
		private DateTime allocationDate;
		private string allocationID;
		private bool isAdvancePayment;
		private bool isOverPayment;
		private string postingStaus_ID_Allocaation;
		private string glPosting_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasInvoice_Sattled class.
		/// </summary>
		public tbl_sasInvoice_Sattled() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasInvoice_Sattled class.
		/// </summary>
		public tbl_sasInvoice_Sattled(string settled_ID, string invoice_ID, string journalEntry_ID_DR, int lineNo_JEDR, string posTransaction_ID, string receipt_ID, string posReceipt_ID, string chequeRegister_ID, string creditNote_ID, string debitNote_ID, string journalEntry_ID_CR, int lineNo_JECR, string paymentMethod_ID, string paymentMethodTransection_ID, DateTime sattledDate, decimal sattledAmount, bool isDebit, DateTime allocationDate, string allocationID, bool isAdvancePayment, bool isOverPayment, string postingStaus_ID_Allocaation, string glPosting_ID) {
			this.settled_ID = settled_ID;
			this.invoice_ID = invoice_ID;
			this.journalEntry_ID_DR = journalEntry_ID_DR;
			this.lineNo_JEDR = lineNo_JEDR;
			this.posTransaction_ID = posTransaction_ID;
			this.receipt_ID = receipt_ID;
			this.posReceipt_ID = posReceipt_ID;
			this.chequeRegister_ID = chequeRegister_ID;
			this.creditNote_ID = creditNote_ID;
			this.debitNote_ID = debitNote_ID;
			this.journalEntry_ID_CR = journalEntry_ID_CR;
			this.lineNo_JECR = lineNo_JECR;
			this.paymentMethod_ID = paymentMethod_ID;
			this.paymentMethodTransection_ID = paymentMethodTransection_ID;
			this.sattledDate = sattledDate;
			this.sattledAmount = sattledAmount;
			this.isDebit = isDebit;
			this.allocationDate = allocationDate;
			this.allocationID = allocationID;
			this.isAdvancePayment = isAdvancePayment;
			this.isOverPayment = isOverPayment;
			this.postingStaus_ID_Allocaation = postingStaus_ID_Allocaation;
			this.glPosting_ID = glPosting_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Settled_ID value.
		/// </summary>
		public string Settled_ID {
			get { return settled_ID; }
			set { settled_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
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
		/// Gets or sets the PosTransaction_ID value.
		/// </summary>
		public string PosTransaction_ID {
			get { return posTransaction_ID; }
			set { posTransaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosReceipt_ID value.
		/// </summary>
		public string PosReceipt_ID {
			get { return posReceipt_ID; }
			set { posReceipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditNote_ID value.
		/// </summary>
		public string CreditNote_ID {
			get { return creditNote_ID; }
			set { creditNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DebitNote_ID value.
		/// </summary>
		public string DebitNote_ID {
			get { return debitNote_ID; }
			set { debitNote_ID = value; }
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
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethodTransection_ID value.
		/// </summary>
		public string PaymentMethodTransection_ID {
			get { return paymentMethodTransection_ID; }
			set { paymentMethodTransection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SattledDate value.
		/// </summary>
		public DateTime SattledDate {
			get { return sattledDate; }
			set { sattledDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the SattledAmount value.
		/// </summary>
		public decimal SattledAmount {
			get { return sattledAmount; }
			set { sattledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDebit value.
		/// </summary>
		public bool IsDebit {
			get { return isDebit; }
			set { isDebit = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllocationDate value.
		/// </summary>
		public DateTime AllocationDate {
			get { return allocationDate; }
			set { allocationDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllocationID value.
		/// </summary>
		public string AllocationID {
			get { return allocationID; }
			set { allocationID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAdvancePayment value.
		/// </summary>
		public bool IsAdvancePayment {
			get { return isAdvancePayment; }
			set { isAdvancePayment = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOverPayment value.
		/// </summary>
		public bool IsOverPayment {
			get { return isOverPayment; }
			set { isOverPayment = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStaus_ID_Allocaation value.
		/// </summary>
		public string PostingStaus_ID_Allocaation {
			get { return postingStaus_ID_Allocaation; }
			set { postingStaus_ID_Allocaation = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasInvoice_Sattled table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@settled_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@journalEntry_ID_DR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lineNo_JEDR", SqlDbType.Int,4);
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@journalEntry_ID_CR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lineNo_JECR", SqlDbType.Int,4);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMethodTransection_ID", SqlDbType.VarChar,30);
			scom.Parameters.Add("@sattledDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@sattledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDebit", SqlDbType.Bit,1);
			scom.Parameters.Add("@allocationDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@allocationID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isAdvancePayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@postingStaus_ID_Allocaation", SqlDbType.VarChar,20);
			scom.Parameters.Add("@GlPosting_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@settled_ID"].Value = settled_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@journalEntry_ID_DR"].Value = journalEntry_ID_DR;
			scom.Parameters["@lineNo_JEDR"].Value = lineNo_JEDR;
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@journalEntry_ID_CR"].Value = journalEntry_ID_CR;
			scom.Parameters["@lineNo_JECR"].Value = lineNo_JECR;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@paymentMethodTransection_ID"].Value = paymentMethodTransection_ID;
			scom.Parameters["@sattledDate"].Value = sattledDate;
			scom.Parameters["@sattledAmount"].Value = sattledAmount;
			scom.Parameters["@isDebit"].Value = isDebit;
			scom.Parameters["@allocationDate"].Value = allocationDate;
			scom.Parameters["@allocationID"].Value = allocationID;
			scom.Parameters["@isAdvancePayment"].Value = isAdvancePayment;
			scom.Parameters["@isOverPayment"].Value = isOverPayment;
			scom.Parameters["@postingStaus_ID_Allocaation"].Value = postingStaus_ID_Allocaation;
			scom.Parameters["@GlPosting_ID"].Value = glPosting_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasInvoice_Sattled table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@settled_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@journalEntry_ID_DR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lineNo_JEDR", SqlDbType.Int,4);
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@journalEntry_ID_CR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lineNo_JECR", SqlDbType.Int,4);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMethodTransection_ID", SqlDbType.VarChar,30);
			scom.Parameters.Add("@sattledDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@sattledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDebit", SqlDbType.Bit,1);
			scom.Parameters.Add("@allocationDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@allocationID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isAdvancePayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@postingStaus_ID_Allocaation", SqlDbType.VarChar,20);
			scom.Parameters.Add("@GlPosting_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@settled_ID"].Value = settled_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@journalEntry_ID_DR"].Value = journalEntry_ID_DR;
			scom.Parameters["@lineNo_JEDR"].Value = lineNo_JEDR;
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@journalEntry_ID_CR"].Value = journalEntry_ID_CR;
			scom.Parameters["@lineNo_JECR"].Value = lineNo_JECR;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@paymentMethodTransection_ID"].Value = paymentMethodTransection_ID;
			scom.Parameters["@sattledDate"].Value = sattledDate;
			scom.Parameters["@sattledAmount"].Value = sattledAmount;
			scom.Parameters["@isDebit"].Value = isDebit;
			scom.Parameters["@allocationDate"].Value = allocationDate;
			scom.Parameters["@allocationID"].Value = allocationID;
			scom.Parameters["@isAdvancePayment"].Value = isAdvancePayment;
			scom.Parameters["@isOverPayment"].Value = isOverPayment;
			scom.Parameters["@postingStaus_ID_Allocaation"].Value = postingStaus_ID_Allocaation;
			scom.Parameters["@GlPosting_ID"].Value = glPosting_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasInvoice_Sattled table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@settled_ID", SqlDbType.VarChar,20);
			scom.Parameters["@settled_ID"].Value = settled_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static void DeleteAllByReceipt_ID(string receipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledDeleteAllByReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreditNote_ID(string creditNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledDeleteAllByCreditNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static void DeleteAllByPosReceipt_ID(string posReceipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledDeleteAllByPosReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static void DeleteAllByPosTransaction_ID(string posTransaction_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledDeleteAllByPosTransaction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        public static tbl_sasInvoice_Sattled Select(string invoice_ID_Incoming, string receipt_ID_Incoming, string chequeRegister_ID_Incoming, string creditNote_ID_Incoming, string debitNote_ID_Incoming, string paymentMethod_ID_Incoming, string paymentMethodTransection_ID_Incoming)
        {
            tbl_sasInvoice_Sattled tbl_sasInvoice_Sattledins = new tbl_sasInvoice_Sattled();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelect2", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@paymentMethodTransection_ID", SqlDbType.VarChar, 30);
            scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
            scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
            scom.Parameters["@creditNote_ID"].Value = creditNote_ID_Incoming;
            scom.Parameters["@debitNote_ID"].Value = debitNote_ID_Incoming;
            scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID_Incoming;
            scom.Parameters["@paymentMethodTransection_ID"].Value = paymentMethodTransection_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_sasInvoice_Sattledins = Maketbl_sasInvoice_Sattled(dataReader);
                }
                else
                {
                    tbl_sasInvoice_Sattledins = null;
                }
            }
            scon.Close();
            return tbl_sasInvoice_Sattledins;
        }
        /// <summary>
		/// Selects a single record from the tbl_sasInvoice_Sattled table.
		/// </summary>
		public static tbl_sasInvoice_Sattled Select(string settled_ID_Incoming){

			tbl_sasInvoice_Sattled tbl_sasInvoice_Sattledins = new tbl_sasInvoice_Sattled();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@settled_ID", SqlDbType.VarChar,20);
			scom.Parameters["@settled_ID"].Value = settled_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasInvoice_Sattledins = Maketbl_sasInvoice_Sattled(dataReader);
				} else {
					tbl_sasInvoice_Sattledins = null;
				}
			}
			scon.Close();
			return tbl_sasInvoice_Sattledins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table.
		/// </summary>
		public static List<tbl_sasInvoice_Sattled> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasInvoice_Sattled> tbl_sasInvoice_SattledList = new List<tbl_sasInvoice_Sattled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvoice_Sattled tbl_sasInvoice_Sattled = Maketbl_sasInvoice_Sattled(dataReader);
					tbl_sasInvoice_SattledList.Add(tbl_sasInvoice_Sattled);
				}
			}
			scon.Close();
			return tbl_sasInvoice_SattledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Sattled> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_sasInvoice_Sattled> tbl_sasInvoice_SattledList = new List<tbl_sasInvoice_Sattled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvoice_Sattled tbl_sasInvoice_Sattled = Maketbl_sasInvoice_Sattled(dataReader);
					tbl_sasInvoice_SattledList.Add(tbl_sasInvoice_Sattled);
				}
			}
			scon.Close();
			return tbl_sasInvoice_SattledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Sattled> SelectAllByReceipt_ID(string receipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelectAllByReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
				List<tbl_sasInvoice_Sattled> tbl_sasInvoice_SattledList = new List<tbl_sasInvoice_Sattled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvoice_Sattled tbl_sasInvoice_Sattled = Maketbl_sasInvoice_Sattled(dataReader);
					tbl_sasInvoice_SattledList.Add(tbl_sasInvoice_Sattled);
				}
			}
			scon.Close();
			return tbl_sasInvoice_SattledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Sattled> SelectAllByCreditNote_ID(string creditNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelectAllByCreditNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
				List<tbl_sasInvoice_Sattled> tbl_sasInvoice_SattledList = new List<tbl_sasInvoice_Sattled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvoice_Sattled tbl_sasInvoice_Sattled = Maketbl_sasInvoice_Sattled(dataReader);
					tbl_sasInvoice_SattledList.Add(tbl_sasInvoice_Sattled);
				}
			}
			scon.Close();
			return tbl_sasInvoice_SattledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Sattled> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_sasInvoice_Sattled> tbl_sasInvoice_SattledList = new List<tbl_sasInvoice_Sattled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvoice_Sattled tbl_sasInvoice_Sattled = Maketbl_sasInvoice_Sattled(dataReader);
					tbl_sasInvoice_SattledList.Add(tbl_sasInvoice_Sattled);
				}
			}
			scon.Close();
			return tbl_sasInvoice_SattledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Sattled> SelectAllByPosReceipt_ID(string posReceipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelectAllByPosReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
				List<tbl_sasInvoice_Sattled> tbl_sasInvoice_SattledList = new List<tbl_sasInvoice_Sattled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvoice_Sattled tbl_sasInvoice_Sattled = Maketbl_sasInvoice_Sattled(dataReader);
					tbl_sasInvoice_SattledList.Add(tbl_sasInvoice_Sattled);
				}
			}
			scon.Close();
			return tbl_sasInvoice_SattledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Sattled table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Sattled> SelectAllByPosTransaction_ID(string posTransaction_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_SattledSelectAllByPosTransaction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
				List<tbl_sasInvoice_Sattled> tbl_sasInvoice_SattledList = new List<tbl_sasInvoice_Sattled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvoice_Sattled tbl_sasInvoice_Sattled = Maketbl_sasInvoice_Sattled(dataReader);
					tbl_sasInvoice_SattledList.Add(tbl_sasInvoice_Sattled);
				}
			}
			scon.Close();
			return tbl_sasInvoice_SattledList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasInvoice_Sattled class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasInvoice_Sattled Maketbl_sasInvoice_Sattled(SqlDataReader dataReader) {
			tbl_sasInvoice_Sattled tbl_sasInvoice_Sattled = new tbl_sasInvoice_Sattled();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasInvoice_Sattled.Settled_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasInvoice_Sattled.Invoice_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasInvoice_Sattled.JournalEntry_ID_DR = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasInvoice_Sattled.LineNo_JEDR = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasInvoice_Sattled.PosTransaction_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasInvoice_Sattled.Receipt_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasInvoice_Sattled.PosReceipt_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasInvoice_Sattled.ChequeRegister_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasInvoice_Sattled.CreditNote_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasInvoice_Sattled.DebitNote_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasInvoice_Sattled.JournalEntry_ID_CR = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasInvoice_Sattled.LineNo_JECR = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasInvoice_Sattled.PaymentMethod_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasInvoice_Sattled.PaymentMethodTransection_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasInvoice_Sattled.SattledDate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasInvoice_Sattled.SattledAmount = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasInvoice_Sattled.IsDebit = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasInvoice_Sattled.AllocationDate = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasInvoice_Sattled.AllocationID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasInvoice_Sattled.IsAdvancePayment = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasInvoice_Sattled.IsOverPayment = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasInvoice_Sattled.PostingStaus_ID_Allocaation = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasInvoice_Sattled.GlPosting_ID = dataReader.GetString(22);
			}

			return tbl_sasInvoice_Sattled;
		}
		/// <summary>
		/// This makes tbl_sasInvoice_Sattled datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasInvoice_Sattled object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasInvoice_Sattled  tbl_sasInvoice_Sattled   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_settled_ID = new DataColumn("settled_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_journalEntry_ID_DR = new DataColumn("journalEntry_ID_DR" , typeof(string));
			DataColumn col_lineNo_JEDR = new DataColumn("lineNo_JEDR" , typeof(int));
			DataColumn col_posTransaction_ID = new DataColumn("posTransaction_ID" , typeof(string));
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_posReceipt_ID = new DataColumn("posReceipt_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_creditNote_ID = new DataColumn("creditNote_ID" , typeof(string));
			DataColumn col_debitNote_ID = new DataColumn("debitNote_ID" , typeof(string));
			DataColumn col_journalEntry_ID_CR = new DataColumn("journalEntry_ID_CR" , typeof(string));
			DataColumn col_lineNo_JECR = new DataColumn("lineNo_JECR" , typeof(int));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_paymentMethodTransection_ID = new DataColumn("paymentMethodTransection_ID" , typeof(string));
			DataColumn col_sattledDate = new DataColumn("sattledDate" , typeof(DateTime));
			DataColumn col_sattledAmount = new DataColumn("sattledAmount" , typeof(decimal));
			DataColumn col_isDebit = new DataColumn("isDebit" , typeof(bool));
			DataColumn col_allocationDate = new DataColumn("allocationDate" , typeof(DateTime));
			DataColumn col_allocationID = new DataColumn("allocationID" , typeof(string));
			DataColumn col_isAdvancePayment = new DataColumn("isAdvancePayment" , typeof(bool));
			DataColumn col_isOverPayment = new DataColumn("isOverPayment" , typeof(bool));
			DataColumn col_postingStaus_ID_Allocaation = new DataColumn("postingStaus_ID_Allocaation" , typeof(string));
			DataColumn col_GlPosting_ID = new DataColumn("GlPosting_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_settled_ID,col_invoice_ID,col_journalEntry_ID_DR,col_lineNo_JEDR,col_posTransaction_ID,col_receipt_ID,col_posReceipt_ID,col_chequeRegister_ID,col_creditNote_ID,col_debitNote_ID,col_journalEntry_ID_CR,col_lineNo_JECR,col_paymentMethod_ID,col_paymentMethodTransection_ID,col_sattledDate,col_sattledAmount,col_isDebit,col_allocationDate,col_allocationID,col_isAdvancePayment,col_isOverPayment,col_postingStaus_ID_Allocaation,col_GlPosting_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasInvoice_Sattled datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasInvoice_Sattled object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasInvoice_Sattled user) {
		DataRow drow = dt.NewRow();
		
			drow["settled_ID"] = user.settled_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["journalEntry_ID_DR"] = user.journalEntry_ID_DR;
			drow["lineNo_JEDR"] = user.lineNo_JEDR;
			drow["posTransaction_ID"] = user.posTransaction_ID;
			drow["receipt_ID"] = user.receipt_ID;
			drow["posReceipt_ID"] = user.posReceipt_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["creditNote_ID"] = user.creditNote_ID;
			drow["debitNote_ID"] = user.debitNote_ID;
			drow["journalEntry_ID_CR"] = user.journalEntry_ID_CR;
			drow["lineNo_JECR"] = user.lineNo_JECR;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["paymentMethodTransection_ID"] = user.paymentMethodTransection_ID;
			drow["sattledDate"] = user.sattledDate;
			drow["sattledAmount"] = user.sattledAmount;
			drow["isDebit"] = user.isDebit;
			drow["allocationDate"] = user.allocationDate;
			drow["allocationID"] = user.allocationID;
			drow["isAdvancePayment"] = user.isAdvancePayment;
			drow["isOverPayment"] = user.isOverPayment;
			drow["postingStaus_ID_Allocaation"] = user.postingStaus_ID_Allocaation;
			drow["GlPosting_ID"] = user.GlPosting_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
