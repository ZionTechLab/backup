using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsChequeDeposit_Detail {
		#region Fields
		private string chequeDeposit_ID;
		private string chequeRegister_ID;
		private DateTime dateDeposit;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string financialYear_ID;
		private string companyID;
		private bool isRedeposit;
		private string glPosting_ID_Deposit;
		private string postingStatus_ID_Deposit;
		private string chequeStatus_ID;
		private string glPosting_ID_Rec;
		private string postingStatus_ID_Rec;
		private DateTime dateReconciliation;
		private int companyAccount_ID;
		private int recSerialNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeDeposit_Detail class.
		/// </summary>
		public tbl_bpsChequeDeposit_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeDeposit_Detail class.
		/// </summary>
		public tbl_bpsChequeDeposit_Detail(string chequeDeposit_ID, string chequeRegister_ID, DateTime dateDeposit, string glPosting_ID, string postingStatus_ID, string financialYear_ID, string companyID, bool isRedeposit, string glPosting_ID_Deposit, string postingStatus_ID_Deposit, string chequeStatus_ID, string glPosting_ID_Rec, string postingStatus_ID_Rec, DateTime dateReconciliation, int companyAccount_ID, int recSerialNo) {
			this.chequeDeposit_ID = chequeDeposit_ID;
			this.chequeRegister_ID = chequeRegister_ID;
			this.dateDeposit = dateDeposit;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
			this.companyID = companyID;
			this.isRedeposit = isRedeposit;
			this.glPosting_ID_Deposit = glPosting_ID_Deposit;
			this.postingStatus_ID_Deposit = postingStatus_ID_Deposit;
			this.chequeStatus_ID = chequeStatus_ID;
			this.glPosting_ID_Rec = glPosting_ID_Rec;
			this.postingStatus_ID_Rec = postingStatus_ID_Rec;
			this.dateReconciliation = dateReconciliation;
			this.companyAccount_ID = companyAccount_ID;
			this.recSerialNo = recSerialNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeDeposit_ID value.
		/// </summary>
		public string ChequeDeposit_ID {
			get { return chequeDeposit_ID; }
			set { chequeDeposit_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDeposit value.
		/// </summary>
		public DateTime DateDeposit {
			get { return dateDeposit; }
			set { dateDeposit = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStatus_ID value.
		/// </summary>
		public string PostingStatus_ID {
			get { return postingStatus_ID; }
			set { postingStatus_ID = value; }
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
		/// Gets or sets the IsRedeposit value.
		/// </summary>
		public bool IsRedeposit {
			get { return isRedeposit; }
			set { isRedeposit = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID_Deposit value.
		/// </summary>
		public string GlPosting_ID_Deposit {
			get { return glPosting_ID_Deposit; }
			set { glPosting_ID_Deposit = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStatus_ID_Deposit value.
		/// </summary>
		public string PostingStatus_ID_Deposit {
			get { return postingStatus_ID_Deposit; }
			set { postingStatus_ID_Deposit = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeStatus_ID value.
		/// </summary>
		public string ChequeStatus_ID {
			get { return chequeStatus_ID; }
			set { chequeStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID_Rec value.
		/// </summary>
		public string GlPosting_ID_Rec {
			get { return glPosting_ID_Rec; }
			set { glPosting_ID_Rec = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStatus_ID_Rec value.
		/// </summary>
		public string PostingStatus_ID_Rec {
			get { return postingStatus_ID_Rec; }
			set { postingStatus_ID_Rec = value; }
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
		/// Saves a record to the tbl_bpsChequeDeposit_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateDeposit", SqlDbType.DateTime,8);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isRedeposit", SqlDbType.Bit,1);
			scom.Parameters.Add("@glPosting_ID_Deposit", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID_Deposit", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID_Rec", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID_Rec", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateReconciliation", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
 
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@dateDeposit"].Value = dateDeposit;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@isRedeposit"].Value = isRedeposit;
			scom.Parameters["@glPosting_ID_Deposit"].Value = glPosting_ID_Deposit;
			scom.Parameters["@postingStatus_ID_Deposit"].Value = postingStatus_ID_Deposit;
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@glPosting_ID_Rec"].Value = glPosting_ID_Rec;
			scom.Parameters["@postingStatus_ID_Rec"].Value = postingStatus_ID_Rec;
			scom.Parameters["@dateReconciliation"].Value = dateReconciliation;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsChequeDeposit_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateDeposit", SqlDbType.DateTime,8);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isRedeposit", SqlDbType.Bit,1);
			scom.Parameters.Add("@glPosting_ID_Deposit", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID_Deposit", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID_Rec", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID_Rec", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateReconciliation", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
 
 
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@dateDeposit"].Value = dateDeposit;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@isRedeposit"].Value = isRedeposit;
			scom.Parameters["@glPosting_ID_Deposit"].Value = glPosting_ID_Deposit;
			scom.Parameters["@postingStatus_ID_Deposit"].Value = postingStatus_ID_Deposit;
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@glPosting_ID_Rec"].Value = glPosting_ID_Rec;
			scom.Parameters["@postingStatus_ID_Rec"].Value = postingStatus_ID_Rec;
			scom.Parameters["@dateReconciliation"].Value = dateReconciliation;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsChequeDeposit_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeDeposit_ID(string chequeDeposit_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailDeleteAllByChequeDeposit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsChequeDeposit_Detail table.
		/// </summary>
		public static tbl_bpsChequeDeposit_Detail Select(string chequeDeposit_ID_Incoming, string chequeRegister_ID_Incoming){

			tbl_bpsChequeDeposit_Detail tbl_bpsChequeDeposit_Detailins = new tbl_bpsChequeDeposit_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID_Incoming;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsChequeDeposit_Detailins = Maketbl_bpsChequeDeposit_Detail(dataReader);
				} else {
					tbl_bpsChequeDeposit_Detailins = null;
				}
			}
			scon.Close();
			return tbl_bpsChequeDeposit_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit_Detail table.
		/// </summary>
		public static List<tbl_bpsChequeDeposit_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsChequeDeposit_Detail> tbl_bpsChequeDeposit_DetailList = new List<tbl_bpsChequeDeposit_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeDeposit_Detail tbl_bpsChequeDeposit_Detail = Maketbl_bpsChequeDeposit_Detail(dataReader);
					tbl_bpsChequeDeposit_DetailList.Add(tbl_bpsChequeDeposit_Detail);
				}
			}
			scon.Close();
			return tbl_bpsChequeDeposit_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeDeposit_Detail> SelectAllByChequeDeposit_ID(string chequeDeposit_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailSelectAllByChequeDeposit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;
				List<tbl_bpsChequeDeposit_Detail> tbl_bpsChequeDeposit_DetailList = new List<tbl_bpsChequeDeposit_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeDeposit_Detail tbl_bpsChequeDeposit_Detail = Maketbl_bpsChequeDeposit_Detail(dataReader);
					tbl_bpsChequeDeposit_DetailList.Add(tbl_bpsChequeDeposit_Detail);
				}
			}
			scon.Close();
			return tbl_bpsChequeDeposit_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeDeposit_Detail> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDeposit_DetailSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_bpsChequeDeposit_Detail> tbl_bpsChequeDeposit_DetailList = new List<tbl_bpsChequeDeposit_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeDeposit_Detail tbl_bpsChequeDeposit_Detail = Maketbl_bpsChequeDeposit_Detail(dataReader);
					tbl_bpsChequeDeposit_DetailList.Add(tbl_bpsChequeDeposit_Detail);
				}
			}
			scon.Close();
			return tbl_bpsChequeDeposit_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsChequeDeposit_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsChequeDeposit_Detail Maketbl_bpsChequeDeposit_Detail(SqlDataReader dataReader) {
			tbl_bpsChequeDeposit_Detail tbl_bpsChequeDeposit_Detail = new tbl_bpsChequeDeposit_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsChequeDeposit_Detail.ChequeDeposit_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsChequeDeposit_Detail.ChequeRegister_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsChequeDeposit_Detail.DateDeposit = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsChequeDeposit_Detail.GlPosting_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsChequeDeposit_Detail.PostingStatus_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsChequeDeposit_Detail.FinancialYear_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsChequeDeposit_Detail.CompanyID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsChequeDeposit_Detail.IsRedeposit = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsChequeDeposit_Detail.GlPosting_ID_Deposit = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsChequeDeposit_Detail.PostingStatus_ID_Deposit = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsChequeDeposit_Detail.ChequeStatus_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsChequeDeposit_Detail.GlPosting_ID_Rec = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsChequeDeposit_Detail.PostingStatus_ID_Rec = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsChequeDeposit_Detail.DateReconciliation = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsChequeDeposit_Detail.CompanyAccount_ID = dataReader.GetInt32(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsChequeDeposit_Detail.RecSerialNo = dataReader.GetInt32(15);
			}

			return tbl_bpsChequeDeposit_Detail;
		}
		/// <summary>
		/// This makes tbl_bpsChequeDeposit_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsChequeDeposit_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsChequeDeposit_Detail  tbl_bpsChequeDeposit_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeDeposit_ID = new DataColumn("chequeDeposit_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_dateDeposit = new DataColumn("dateDeposit" , typeof(DateTime));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_isRedeposit = new DataColumn("isRedeposit" , typeof(bool));
			DataColumn col_glPosting_ID_Deposit = new DataColumn("glPosting_ID_Deposit" , typeof(string));
			DataColumn col_postingStatus_ID_Deposit = new DataColumn("postingStatus_ID_Deposit" , typeof(string));
			DataColumn col_chequeStatus_ID = new DataColumn("chequeStatus_ID" , typeof(string));
			DataColumn col_glPosting_ID_Rec = new DataColumn("glPosting_ID_Rec" , typeof(string));
			DataColumn col_postingStatus_ID_Rec = new DataColumn("postingStatus_ID_Rec" , typeof(string));
			DataColumn col_dateReconciliation = new DataColumn("dateReconciliation" , typeof(DateTime));
			DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID" , typeof(int));
			DataColumn col_recSerialNo = new DataColumn("recSerialNo" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_chequeDeposit_ID,col_chequeRegister_ID,col_dateDeposit,col_glPosting_ID,col_postingStatus_ID,col_financialYear_ID,col_companyID,col_isRedeposit,col_glPosting_ID_Deposit,col_postingStatus_ID_Deposit,col_chequeStatus_ID,col_glPosting_ID_Rec,col_postingStatus_ID_Rec,col_dateReconciliation,col_companyAccount_ID,col_recSerialNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsChequeDeposit_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsChequeDeposit_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsChequeDeposit_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeDeposit_ID"] = user.chequeDeposit_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["dateDeposit"] = user.dateDeposit;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["companyID"] = user.companyID;
			drow["isRedeposit"] = user.isRedeposit;
			drow["glPosting_ID_Deposit"] = user.glPosting_ID_Deposit;
			drow["postingStatus_ID_Deposit"] = user.postingStatus_ID_Deposit;
			drow["chequeStatus_ID"] = user.chequeStatus_ID;
			drow["glPosting_ID_Rec"] = user.glPosting_ID_Rec;
			drow["postingStatus_ID_Rec"] = user.postingStatus_ID_Rec;
			drow["dateReconciliation"] = user.dateReconciliation;
			drow["companyAccount_ID"] = user.companyAccount_ID;
			drow["recSerialNo"] = user.recSerialNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
