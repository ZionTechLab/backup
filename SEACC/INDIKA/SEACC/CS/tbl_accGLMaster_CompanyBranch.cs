using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_CompanyBranch {
		#region Fields
		private string companyBranch_ID;
		private string creditCard_ControlAcc;
		private string cashInHand_Acc;
		private string chequeInHand_Acc;
		private string advance_ControlAcc;
		private string sales_Acc;
		private string creditNote_ControlAcc;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_CompanyBranch class.
		/// </summary>
		public tbl_accGLMaster_CompanyBranch() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_CompanyBranch class.
		/// </summary>
		public tbl_accGLMaster_CompanyBranch(string companyBranch_ID, string creditCard_ControlAcc, string cashInHand_Acc, string chequeInHand_Acc, string advance_ControlAcc, string sales_Acc, string creditNote_ControlAcc) {
			this.companyBranch_ID = companyBranch_ID;
			this.creditCard_ControlAcc = creditCard_ControlAcc;
			this.cashInHand_Acc = cashInHand_Acc;
			this.chequeInHand_Acc = chequeInHand_Acc;
			this.advance_ControlAcc = advance_ControlAcc;
			this.sales_Acc = sales_Acc;
			this.creditNote_ControlAcc = creditNote_ControlAcc;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditCard_ControlAcc value.
		/// </summary>
		public string CreditCard_ControlAcc {
			get { return creditCard_ControlAcc; }
			set { creditCard_ControlAcc = value; }
		}
		
		/// <summary>
		/// Gets or sets the CashInHand_Acc value.
		/// </summary>
		public string CashInHand_Acc {
			get { return cashInHand_Acc; }
			set { cashInHand_Acc = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeInHand_Acc value.
		/// </summary>
		public string ChequeInHand_Acc {
			get { return chequeInHand_Acc; }
			set { chequeInHand_Acc = value; }
		}
		
		/// <summary>
		/// Gets or sets the Advance_ControlAcc value.
		/// </summary>
		public string Advance_ControlAcc {
			get { return advance_ControlAcc; }
			set { advance_ControlAcc = value; }
		}
		
		/// <summary>
		/// Gets or sets the Sales_Acc value.
		/// </summary>
		public string Sales_Acc {
			get { return sales_Acc; }
			set { sales_Acc = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditNote_ControlAcc value.
		/// </summary>
		public string CreditNote_ControlAcc {
			get { return creditNote_ControlAcc; }
			set { creditNote_ControlAcc = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLMaster_CompanyBranch table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CompanyBranchInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditCard_ControlAcc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cashInHand_Acc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeInHand_Acc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@advance_ControlAcc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sales_Acc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ControlAcc", SqlDbType.VarChar,20);
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@creditCard_ControlAcc"].Value = creditCard_ControlAcc;
			scom.Parameters["@cashInHand_Acc"].Value = cashInHand_Acc;
			scom.Parameters["@chequeInHand_Acc"].Value = chequeInHand_Acc;
			scom.Parameters["@advance_ControlAcc"].Value = advance_ControlAcc;
			scom.Parameters["@sales_Acc"].Value = sales_Acc;
			scom.Parameters["@creditNote_ControlAcc"].Value = creditNote_ControlAcc;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_CompanyBranch table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CompanyBranchUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditCard_ControlAcc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cashInHand_Acc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeInHand_Acc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@advance_ControlAcc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sales_Acc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ControlAcc", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@creditCard_ControlAcc"].Value = creditCard_ControlAcc;
			scom.Parameters["@cashInHand_Acc"].Value = cashInHand_Acc;
			scom.Parameters["@chequeInHand_Acc"].Value = chequeInHand_Acc;
			scom.Parameters["@advance_ControlAcc"].Value = advance_ControlAcc;
			scom.Parameters["@sales_Acc"].Value = sales_Acc;
			scom.Parameters["@creditNote_ControlAcc"].Value = creditNote_ControlAcc;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_CompanyBranch table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CompanyBranchDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CompanyBranch table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CompanyBranchDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_CompanyBranch table.
		/// </summary>
		public static tbl_accGLMaster_CompanyBranch Select(string companyBranch_ID_Incoming){

			tbl_accGLMaster_CompanyBranch tbl_accGLMaster_CompanyBranchins = new tbl_accGLMaster_CompanyBranch();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CompanyBranchSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_CompanyBranchins = Maketbl_accGLMaster_CompanyBranch(dataReader);
				} else {
					tbl_accGLMaster_CompanyBranchins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_CompanyBranchins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CompanyBranch table.
		/// </summary>
		public static List<tbl_accGLMaster_CompanyBranch> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CompanyBranchSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_CompanyBranch> tbl_accGLMaster_CompanyBranchList = new List<tbl_accGLMaster_CompanyBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_CompanyBranch tbl_accGLMaster_CompanyBranch = Maketbl_accGLMaster_CompanyBranch(dataReader);
					tbl_accGLMaster_CompanyBranchList.Add(tbl_accGLMaster_CompanyBranch);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CompanyBranchList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CompanyBranch table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_CompanyBranch> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CompanyBranchSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_accGLMaster_CompanyBranch> tbl_accGLMaster_CompanyBranchList = new List<tbl_accGLMaster_CompanyBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_CompanyBranch tbl_accGLMaster_CompanyBranch = Maketbl_accGLMaster_CompanyBranch(dataReader);
					tbl_accGLMaster_CompanyBranchList.Add(tbl_accGLMaster_CompanyBranch);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CompanyBranchList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_CompanyBranch class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_CompanyBranch Maketbl_accGLMaster_CompanyBranch(SqlDataReader dataReader) {
			tbl_accGLMaster_CompanyBranch tbl_accGLMaster_CompanyBranch = new tbl_accGLMaster_CompanyBranch();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_CompanyBranch.CompanyBranch_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_CompanyBranch.CreditCard_ControlAcc = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_CompanyBranch.CashInHand_Acc = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLMaster_CompanyBranch.ChequeInHand_Acc = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLMaster_CompanyBranch.Advance_ControlAcc = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accGLMaster_CompanyBranch.Sales_Acc = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accGLMaster_CompanyBranch.CreditNote_ControlAcc = dataReader.GetString(6);
			}

			return tbl_accGLMaster_CompanyBranch;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_CompanyBranch datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_CompanyBranch object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_CompanyBranch  tbl_accGLMaster_CompanyBranch   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_creditCard_ControlAcc = new DataColumn("creditCard_ControlAcc" , typeof(string));
			DataColumn col_cashInHand_Acc = new DataColumn("cashInHand_Acc" , typeof(string));
			DataColumn col_chequeInHand_Acc = new DataColumn("chequeInHand_Acc" , typeof(string));
			DataColumn col_advance_ControlAcc = new DataColumn("advance_ControlAcc" , typeof(string));
			DataColumn col_sales_Acc = new DataColumn("sales_Acc" , typeof(string));
			DataColumn col_creditNote_ControlAcc = new DataColumn("creditNote_ControlAcc" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_companyBranch_ID,col_creditCard_ControlAcc,col_cashInHand_Acc,col_chequeInHand_Acc,col_advance_ControlAcc,col_sales_Acc,col_creditNote_ControlAcc,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_CompanyBranch datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_CompanyBranch object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_CompanyBranch user) {
		DataRow drow = dt.NewRow();
		
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["creditCard_ControlAcc"] = user.creditCard_ControlAcc;
			drow["cashInHand_Acc"] = user.cashInHand_Acc;
			drow["chequeInHand_Acc"] = user.chequeInHand_Acc;
			drow["advance_ControlAcc"] = user.advance_ControlAcc;
			drow["sales_Acc"] = user.sales_Acc;
			drow["creditNote_ControlAcc"] = user.creditNote_ControlAcc;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
