using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLPosting_Detail_UnpostedTXN {
		#region Fields
		private int line_No;
		private string glPosting_ID;
		private string batch_ID;
		private int slot_ID;
		private string transaction_ID;
		private string gl_ID;
		private bool isCanceled;
		private DateTime transactionDate;
		private string remark;
		private string mainTransaction_ID;
		private string costCenter1_ID;
		private string costCenter2_ID;
		private string customer_ID;
		private string supplier_ID;
		private string employee_ID;
		private string bankAcc_No;
		private string cusSupEmpName;
		private string financialYear_ID;
		private string companyID;
		private string cheq_No;
		private string narration;
		private decimal amount;
		private bool isCredit;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLPosting_Detail_UnpostedTXN class.
		/// </summary>
		public tbl_accGLPosting_Detail_UnpostedTXN() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLPosting_Detail_UnpostedTXN class.
		/// </summary>
		public tbl_accGLPosting_Detail_UnpostedTXN(int line_No, string glPosting_ID, string batch_ID, int slot_ID, string transaction_ID, string gl_ID, bool isCanceled, DateTime transactionDate, string remark, string mainTransaction_ID, string costCenter1_ID, string costCenter2_ID, string customer_ID, string supplier_ID, string employee_ID, string bankAcc_No, string cusSupEmpName, string financialYear_ID, string companyID, string cheq_No, string narration, decimal amount, bool isCredit) {
			this.line_No = line_No;
			this.glPosting_ID = glPosting_ID;
			this.batch_ID = batch_ID;
			this.slot_ID = slot_ID;
			this.transaction_ID = transaction_ID;
			this.gl_ID = gl_ID;
			this.isCanceled = isCanceled;
			this.transactionDate = transactionDate;
			this.remark = remark;
			this.mainTransaction_ID = mainTransaction_ID;
			this.costCenter1_ID = costCenter1_ID;
			this.costCenter2_ID = costCenter2_ID;
			this.customer_ID = customer_ID;
			this.supplier_ID = supplier_ID;
			this.employee_ID = employee_ID;
			this.bankAcc_No = bankAcc_No;
			this.cusSupEmpName = cusSupEmpName;
			this.financialYear_ID = financialYear_ID;
			this.companyID = companyID;
			this.cheq_No = cheq_No;
			this.narration = narration;
			this.amount = amount;
			this.isCredit = isCredit;
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
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Batch_ID value.
		/// </summary>
		public string Batch_ID {
			get { return batch_ID; }
			set { batch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Slot_ID value.
		/// </summary>
		public int Slot_ID {
			get { return slot_ID; }
			set { slot_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the MainTransaction_ID value.
		/// </summary>
		public string MainTransaction_ID {
			get { return mainTransaction_ID; }
			set { mainTransaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter1_ID value.
		/// </summary>
		public string CostCenter1_ID {
			get { return costCenter1_ID; }
			set { costCenter1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter2_ID value.
		/// </summary>
		public string CostCenter2_ID {
			get { return costCenter2_ID; }
			set { costCenter2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankAcc_No value.
		/// </summary>
		public string BankAcc_No {
			get { return bankAcc_No; }
			set { bankAcc_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the CusSupEmpName value.
		/// </summary>
		public string CusSupEmpName {
			get { return cusSupEmpName; }
			set { cusSupEmpName = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cheq_No value.
		/// </summary>
		public string Cheq_No {
			get { return cheq_No; }
			set { cheq_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Narration value.
		/// </summary>
		public string Narration {
			get { return narration; }
			set { narration = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCredit value.
		/// </summary>
		public bool IsCredit {
			get { return isCredit; }
			set { isCredit = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLPosting_Detail_UnpostedTXN table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_Detail_UnpostedTXNInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@mainTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cusSupEmpName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cheq_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,500);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@IsCredit", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@slot_ID"].Value = slot_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@mainTransaction_ID"].Value = mainTransaction_ID;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@cusSupEmpName"].Value = cusSupEmpName;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@cheq_No"].Value = cheq_No;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@IsCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLPosting_Detail_UnpostedTXN table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_Detail_UnpostedTXNUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@mainTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cusSupEmpName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cheq_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,500);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@IsCredit", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@slot_ID"].Value = slot_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@mainTransaction_ID"].Value = mainTransaction_ID;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@cusSupEmpName"].Value = cusSupEmpName;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@cheq_No"].Value = cheq_No;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@IsCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLPosting_Detail_UnpostedTXN table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_Detail_UnpostedTXNDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
 
			scom.Parameters["@batch_ID"].Value = batch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLPosting_Detail_UnpostedTXN table.
		/// </summary>
		public static tbl_accGLPosting_Detail_UnpostedTXN Select(int line_No_Incoming, string glPosting_ID_Incoming, string batch_ID_Incoming){

			tbl_accGLPosting_Detail_UnpostedTXN tbl_accGLPosting_Detail_UnpostedTXNins = new tbl_accGLPosting_Detail_UnpostedTXN();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_Detail_UnpostedTXNSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID_Incoming;
			scom.Parameters["@batch_ID"].Value = batch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLPosting_Detail_UnpostedTXNins = Maketbl_accGLPosting_Detail_UnpostedTXN(dataReader);
				} else {
					tbl_accGLPosting_Detail_UnpostedTXNins = null;
				}
			}
			scon.Close();
			return tbl_accGLPosting_Detail_UnpostedTXNins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLPosting_Detail_UnpostedTXN table.
		/// </summary>
		public static List<tbl_accGLPosting_Detail_UnpostedTXN> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_Detail_UnpostedTXNSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLPosting_Detail_UnpostedTXN> tbl_accGLPosting_Detail_UnpostedTXNList = new List<tbl_accGLPosting_Detail_UnpostedTXN>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLPosting_Detail_UnpostedTXN tbl_accGLPosting_Detail_UnpostedTXN = Maketbl_accGLPosting_Detail_UnpostedTXN(dataReader);
					tbl_accGLPosting_Detail_UnpostedTXNList.Add(tbl_accGLPosting_Detail_UnpostedTXN);
				}
			}
			scon.Close();
			return tbl_accGLPosting_Detail_UnpostedTXNList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLPosting_Detail_UnpostedTXN class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLPosting_Detail_UnpostedTXN Maketbl_accGLPosting_Detail_UnpostedTXN(SqlDataReader dataReader) {
			tbl_accGLPosting_Detail_UnpostedTXN tbl_accGLPosting_Detail_UnpostedTXN = new tbl_accGLPosting_Detail_UnpostedTXN();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.GlPosting_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Batch_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Slot_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Transaction_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Gl_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.IsCanceled = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.TransactionDate = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Remark = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.MainTransaction_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.CostCenter1_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.CostCenter2_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Customer_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Supplier_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Employee_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.BankAcc_No = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.CusSupEmpName = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.FinancialYear_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.CompanyID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Cheq_No = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Narration = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.Amount = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accGLPosting_Detail_UnpostedTXN.IsCredit = dataReader.GetBoolean(22);
			}

			return tbl_accGLPosting_Detail_UnpostedTXN;
		}
		/// <summary>
		/// This makes tbl_accGLPosting_Detail_UnpostedTXN datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLPosting_Detail_UnpostedTXN object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLPosting_Detail_UnpostedTXN  tbl_accGLPosting_Detail_UnpostedTXN   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_batch_ID = new DataColumn("batch_ID" , typeof(string));
			DataColumn col_slot_ID = new DataColumn("slot_ID" , typeof(int));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_transactionDate = new DataColumn("transactionDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_mainTransaction_ID = new DataColumn("mainTransaction_ID" , typeof(string));
			DataColumn col_costCenter1_ID = new DataColumn("costCenter1_ID" , typeof(string));
			DataColumn col_costCenter2_ID = new DataColumn("costCenter2_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_bankAcc_No = new DataColumn("bankAcc_No" , typeof(string));
			DataColumn col_cusSupEmpName = new DataColumn("cusSupEmpName" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_cheq_No = new DataColumn("cheq_No" , typeof(string));
			DataColumn col_narration = new DataColumn("narration" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_IsCredit = new DataColumn("IsCredit" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_glPosting_ID,col_batch_ID,col_slot_ID,col_transaction_ID,col_gl_ID,col_isCanceled,col_transactionDate,col_remark,col_mainTransaction_ID,col_costCenter1_ID,col_costCenter2_ID,col_customer_ID,col_supplier_ID,col_employee_ID,col_bankAcc_No,col_cusSupEmpName,col_financialYear_ID,col_companyID,col_cheq_No,col_narration,col_amount,col_IsCredit,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLPosting_Detail_UnpostedTXN datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLPosting_Detail_UnpostedTXN object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLPosting_Detail_UnpostedTXN user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["batch_ID"] = user.batch_ID;
			drow["slot_ID"] = user.slot_ID;
			drow["transaction_ID"] = user.transaction_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["isCanceled"] = user.isCanceled;
			drow["transactionDate"] = user.transactionDate;
			drow["remark"] = user.remark;
			drow["mainTransaction_ID"] = user.mainTransaction_ID;
			drow["costCenter1_ID"] = user.costCenter1_ID;
			drow["costCenter2_ID"] = user.costCenter2_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["bankAcc_No"] = user.bankAcc_No;
			drow["cusSupEmpName"] = user.cusSupEmpName;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["companyID"] = user.companyID;
			drow["cheq_No"] = user.cheq_No;
			drow["narration"] = user.narration;
			drow["amount"] = user.amount;
			drow["IsCredit"] = user.IsCredit;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
