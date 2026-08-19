using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class sp_genMasBankBranch {
		#region Fields
		private string bankBranch_ID;
		private string bankBranch_code;
		private string bank_ID;
		private string bankShortName;
		private string branchName;
		private string originalBranchCode;
		private bool isDelete;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string deleteUserID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the sp_genMasBankBranch class.
		/// </summary>
		public sp_genMasBankBranch() {
		}
		
		/// <summary>
		/// Initializes a new instance of the sp_genMasBankBranch class.
		/// </summary>
		public sp_genMasBankBranch(string bankBranch_ID, string bankBranch_code, string bank_ID, string bankShortName, string branchName, string originalBranchCode, bool isDelete, string createUser_ID, string modifiedUser_ID, string deleteUserID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDeleted) {
			this.bankBranch_ID = bankBranch_ID;
			this.bankBranch_code = bankBranch_code;
			this.bank_ID = bank_ID;
			this.bankShortName = bankShortName;
			this.branchName = branchName;
			this.originalBranchCode = originalBranchCode;
			this.isDelete = isDelete;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.deleteUserID = deleteUserID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateDeleted = dateDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the BankBranch_ID value.
		/// </summary>
		public string BankBranch_ID {
			get { return bankBranch_ID; }
			set { bankBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankBranch_code value.
		/// </summary>
		public string BankBranch_code {
			get { return bankBranch_code; }
			set { bankBranch_code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankShortName value.
		/// </summary>
		public string BankShortName {
			get { return bankShortName; }
			set { bankShortName = value; }
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
		
		/// <summary>
		/// Gets or sets the IsDelete value.
		/// </summary>
		public bool IsDelete {
			get { return isDelete; }
			set { isDelete = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeleteUserID value.
		/// </summary>
		public string DeleteUserID {
			get { return deleteUserID; }
			set { deleteUserID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedTerminal_ID value.
		/// </summary>
		public string DeletedTerminal_ID {
			get { return deletedTerminal_ID; }
			set { deletedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the sp_genMasBankBranch table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasBankBranchInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankBranch_code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankShortName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@originalBranchCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deleteUserID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
 
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
			scom.Parameters["@bankBranch_code"].Value = bankBranch_code;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@bankShortName"].Value = bankShortName;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@originalBranchCode"].Value = originalBranchCode;
			scom.Parameters["@isDelete"].Value = isDelete;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deleteUserID"].Value = deleteUserID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the sp_genMasBankBranch table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasBankBranchUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankBranch_code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankShortName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@originalBranchCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deleteUserID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
			scom.Parameters["@bankBranch_code"].Value = bankBranch_code;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@bankShortName"].Value = bankShortName;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@originalBranchCode"].Value = originalBranchCode;
			scom.Parameters["@isDelete"].Value = isDelete;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deleteUserID"].Value = deleteUserID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the sp_genMasBankBranch table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasBankBranchDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the sp_genMasBankBranch table.
		/// </summary>
		public static sp_genMasBankBranch Select(string bankBranch_ID_Incoming){

			sp_genMasBankBranch sp_genMasBankBranchins = new sp_genMasBankBranch();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasBankBranchSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					sp_genMasBankBranchins = Makesp_genMasBankBranch(dataReader);
				} else {
					sp_genMasBankBranchins = null;
				}
			}
			scon.Close();
			return sp_genMasBankBranchins;
		}
		
		/// <summary>
		/// Selects all records from the sp_genMasBankBranch table.
		/// </summary>
		public static List<sp_genMasBankBranch> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasBankBranchSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<sp_genMasBankBranch> sp_genMasBankBranchList = new List<sp_genMasBankBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					sp_genMasBankBranch sp_genMasBankBranch = Makesp_genMasBankBranch(dataReader);
					sp_genMasBankBranchList.Add(sp_genMasBankBranch);
				}
			}
			scon.Close();
			return sp_genMasBankBranchList;
		}
		
		/// <summary>
		/// Creates a new instance of the sp_genMasBankBranch class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static sp_genMasBankBranch Makesp_genMasBankBranch(SqlDataReader dataReader) {
			sp_genMasBankBranch sp_genMasBankBranch = new sp_genMasBankBranch();
			
			if (dataReader.IsDBNull(0) == false) {
				sp_genMasBankBranch.BankBranch_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				sp_genMasBankBranch.BankBranch_code = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				sp_genMasBankBranch.Bank_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				sp_genMasBankBranch.BankShortName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				sp_genMasBankBranch.BranchName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				sp_genMasBankBranch.OriginalBranchCode = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				sp_genMasBankBranch.IsDelete = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				sp_genMasBankBranch.CreateUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				sp_genMasBankBranch.ModifiedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				sp_genMasBankBranch.DeleteUserID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				sp_genMasBankBranch.CreateTerminal_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				sp_genMasBankBranch.ModifiedTerminal_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				sp_genMasBankBranch.DeletedTerminal_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				sp_genMasBankBranch.DateCreate = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				sp_genMasBankBranch.DateModified = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				sp_genMasBankBranch.DateDeleted = dataReader.GetDateTime(15);
			}

			return sp_genMasBankBranch;
		}
		/// <summary>
		/// This makes sp_genMasBankBranch datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new sp_genMasBankBranch object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( sp_genMasBankBranch  sp_genMasBankBranch   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_bankBranch_ID = new DataColumn("bankBranch_ID" , typeof(string));
			DataColumn col_bankBranch_code = new DataColumn("bankBranch_code" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_bankShortName = new DataColumn("bankShortName" , typeof(string));
			DataColumn col_branchName = new DataColumn("branchName" , typeof(string));
			DataColumn col_originalBranchCode = new DataColumn("originalBranchCode" , typeof(string));
			DataColumn col_isDelete = new DataColumn("isDelete" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_deleteUserID = new DataColumn("deleteUserID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_bankBranch_ID,col_bankBranch_code,col_bank_ID,col_bankShortName,col_branchName,col_originalBranchCode,col_isDelete,col_createUser_ID,col_modifiedUser_ID,col_deleteUserID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_dateCreate,col_dateModified,col_dateDeleted,});		return dt;
		}
		/// <summary>
		/// This fills sp_genMasBankBranch datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new sp_genMasBankBranch object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, sp_genMasBankBranch user) {
		DataRow drow = dt.NewRow();
		
			drow["bankBranch_ID"] = user.bankBranch_ID;
			drow["bankBranch_code"] = user.bankBranch_code;
			drow["bank_ID"] = user.bank_ID;
			drow["bankShortName"] = user.bankShortName;
			drow["branchName"] = user.branchName;
			drow["originalBranchCode"] = user.originalBranchCode;
			drow["isDelete"] = user.isDelete;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["deleteUserID"] = user.deleteUserID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateDeleted"] = user.dateDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
