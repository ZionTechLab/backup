using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_atlWIPEntry {
		#region Fields
		private Int64 transaction_ID;
		private string productionJob_ID;
		private string workInProgress_ID;
		private string prePlan_ID;
		private string section_ID;
		private string sectionName;
		private string remarks;
		private DateTime transactionDate;
		private DateTime modifyDate;
		private string user_ID;
		private string userName;
		private string terminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_atlWIPEntry class.
		/// </summary>
		public tbl_atlWIPEntry() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlWIPEntry class.
		/// </summary>
		public tbl_atlWIPEntry(string productionJob_ID, string workInProgress_ID, string prePlan_ID, string section_ID, string sectionName, string remarks, DateTime transactionDate, DateTime modifyDate, string user_ID, string userName, string terminal_ID) {
			this.productionJob_ID = productionJob_ID;
			this.workInProgress_ID = workInProgress_ID;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.sectionName = sectionName;
			this.remarks = remarks;
			this.transactionDate = transactionDate;
			this.modifyDate = modifyDate;
			this.user_ID = user_ID;
			this.userName = userName;
			this.terminal_ID = terminal_ID;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlWIPEntry class.
		/// </summary>
		public tbl_atlWIPEntry(Int64 transaction_ID, string productionJob_ID, string workInProgress_ID, string prePlan_ID, string section_ID, string sectionName, string remarks, DateTime transactionDate, DateTime modifyDate, string user_ID, string userName, string terminal_ID) {
			this.transaction_ID = transaction_ID;
			this.productionJob_ID = productionJob_ID;
			this.workInProgress_ID = workInProgress_ID;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.sectionName = sectionName;
			this.remarks = remarks;
			this.transactionDate = transactionDate;
			this.modifyDate = modifyDate;
			this.user_ID = user_ID;
			this.userName = userName;
			this.terminal_ID = terminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public Int64 Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionName value.
		/// </summary>
		public string SectionName {
			get { return sectionName; }
			set { sectionName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifyDate value.
		/// </summary>
		public DateTime ModifyDate {
			get { return modifyDate; }
			set { modifyDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserName value.
		/// </summary>
		public string UserName {
			get { return userName; }
			set { userName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_atlWIPEntry table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlWIPEntryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@modifyDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionName"].Value = sectionName;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@modifyDate"].Value = modifyDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_atlWIPEntry table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlWIPEntryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@modifyDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionName"].Value = sectionName;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@modifyDate"].Value = modifyDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_atlWIPEntry table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlWIPEntryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_atlWIPEntry table.
		/// </summary>
		public static tbl_atlWIPEntry Select(Int64 transaction_ID_Incoming){

			tbl_atlWIPEntry tbl_atlWIPEntryins = new tbl_atlWIPEntry();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlWIPEntrySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt);
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_atlWIPEntryins = Maketbl_atlWIPEntry(dataReader);
				} else {
					tbl_atlWIPEntryins = null;
				}
			}
			scon.Close();
			return tbl_atlWIPEntryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlWIPEntry table.
		/// </summary>
		public static List<tbl_atlWIPEntry> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlWIPEntrySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_atlWIPEntry> tbl_atlWIPEntryList = new List<tbl_atlWIPEntry>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlWIPEntry tbl_atlWIPEntry = Maketbl_atlWIPEntry(dataReader);
					tbl_atlWIPEntryList.Add(tbl_atlWIPEntry);
				}
			}
			scon.Close();
			return tbl_atlWIPEntryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_atlWIPEntry class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_atlWIPEntry Maketbl_atlWIPEntry(SqlDataReader dataReader) {
			tbl_atlWIPEntry tbl_atlWIPEntry = new tbl_atlWIPEntry();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_atlWIPEntry.Transaction_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_atlWIPEntry.ProductionJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_atlWIPEntry.WorkInProgress_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_atlWIPEntry.PrePlan_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_atlWIPEntry.Section_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_atlWIPEntry.SectionName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_atlWIPEntry.Remarks = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_atlWIPEntry.TransactionDate = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_atlWIPEntry.ModifyDate = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_atlWIPEntry.User_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_atlWIPEntry.UserName = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_atlWIPEntry.Terminal_ID = dataReader.GetString(11);
			}

			return tbl_atlWIPEntry;
		}
		/// <summary>
		/// This makes tbl_atlWIPEntry datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_atlWIPEntry object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_atlWIPEntry  tbl_atlWIPEntry   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(long));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_sectionName = new DataColumn("sectionName" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_transactionDate = new DataColumn("transactionDate" , typeof(DateTime));
			DataColumn col_modifyDate = new DataColumn("modifyDate" , typeof(DateTime));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_userName = new DataColumn("userName" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_transaction_ID,col_productionJob_ID,col_workInProgress_ID,col_prePlan_ID,col_section_ID,col_sectionName,col_remarks,col_transactionDate,col_modifyDate,col_user_ID,col_userName,col_terminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_atlWIPEntry datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_atlWIPEntry object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_atlWIPEntry user) {
		DataRow drow = dt.NewRow();
		
			drow["transaction_ID"] = user.transaction_ID;
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["sectionName"] = user.sectionName;
			drow["remarks"] = user.remarks;
			drow["transactionDate"] = user.transactionDate;
			drow["modifyDate"] = user.modifyDate;
			drow["user_ID"] = user.user_ID;
			drow["userName"] = user.userName;
			drow["terminal_ID"] = user.terminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
