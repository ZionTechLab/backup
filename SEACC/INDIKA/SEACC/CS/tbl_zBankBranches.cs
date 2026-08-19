using DataTire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_zBankBranches {
		#region Fields
		private string branch_ID;
		private string bank_ID;
		private string branchName;
		private string originalBranchCode;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zBankBranches class.
		/// </summary>
		public tbl_zBankBranches() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zBankBranches class.
		/// </summary>
		public tbl_zBankBranches(string branch_ID, string bank_ID, string branchName, string originalBranchCode) {
			this.branch_ID = branch_ID;
			this.bank_ID = bank_ID;
			this.branchName = branchName;
			this.originalBranchCode = originalBranchCode;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BranchName value.
		/// </summary>
		public string BranchName {
			get { return branchName; }
			set { branchName = value; }
		}
		
		/// <summary>
		/// Gets or sets the OriginalBranchCode value.
		/// </summary>
		public string OriginalBranchCode {
			get { return originalBranchCode; }
			set { originalBranchCode = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zBankBranches table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankBranchesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@originalBranchCode", SqlDbType.VarChar,20);
 
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@originalBranchCode"].Value = originalBranchCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zBankBranches table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankBranchesUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@originalBranchCode", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@originalBranchCode"].Value = originalBranchCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zBankBranches table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankBranchesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zBankBranches table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankBranchesDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zBankBranches table.
		/// </summary>
		public static tbl_zBankBranches Select(string branch_ID_Incoming){

			tbl_zBankBranches tbl_zBankBranchesins = new tbl_zBankBranches();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankBranchesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zBankBranchesins = Maketbl_zBankBranches(dataReader);
				} else {
					tbl_zBankBranchesins = null;
				}
			}
			scon.Close();
			return tbl_zBankBranchesins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zBankBranches table.
		/// </summary>
		public static List<tbl_zBankBranches> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankBranchesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zBankBranches> tbl_zBankBranchesList = new List<tbl_zBankBranches>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zBankBranches tbl_zBankBranches = Maketbl_zBankBranches(dataReader);
					tbl_zBankBranchesList.Add(tbl_zBankBranches);
				}
			}
			scon.Close();
			return tbl_zBankBranchesList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zBankBranches table by a foreign key.
		/// </summary>
		public static List<tbl_zBankBranches> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankBranchesSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_zBankBranches> tbl_zBankBranchesList = new List<tbl_zBankBranches>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zBankBranches tbl_zBankBranches = Maketbl_zBankBranches(dataReader);
					tbl_zBankBranchesList.Add(tbl_zBankBranches);
				}
			}
			scon.Close();
			return tbl_zBankBranchesList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zBankBranches class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zBankBranches Maketbl_zBankBranches(SqlDataReader dataReader) {
			tbl_zBankBranches tbl_zBankBranches = new tbl_zBankBranches();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zBankBranches.Branch_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zBankBranches.Bank_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zBankBranches.BranchName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zBankBranches.OriginalBranchCode = dataReader.GetString(3);
			}

			return tbl_zBankBranches;
		}
		/// <summary>
		/// This makes tbl_zBankBranches datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zBankBranches object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zBankBranches  tbl_zBankBranches   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branchName = new DataColumn("branchName" , typeof(string));
			DataColumn col_originalBranchCode = new DataColumn("originalBranchCode" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_branch_ID,col_bank_ID,col_branchName,col_originalBranchCode,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zBankBranches datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zBankBranches object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zBankBranches user) {
		DataRow drow = dt.NewRow();
		
			drow["branch_ID"] = user.branch_ID;
			drow["bank_ID"] = user.bank_ID;
			drow["branchName"] = user.branchName;
			drow["originalBranchCode"] = user.originalBranchCode;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
