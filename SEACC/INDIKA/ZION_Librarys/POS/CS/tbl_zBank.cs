using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zBank {
		#region Fields
		private string bank_ID;
		private string bankName;
		private string sortName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zBank class.
		/// </summary>
		public tbl_zBank() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zBank class.
		/// </summary>
		public tbl_zBank(string bank_ID, string bankName, string sortName) {
			this.bank_ID = bank_ID;
			this.bankName = bankName;
			this.sortName = sortName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankName value.
		/// </summary>
		public string BankName {
			get { return bankName; }
			set { bankName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SortName value.
		/// </summary>
		public string SortName {
			get { return sortName; }
			set { sortName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zBank table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@sortName", SqlDbType.VarChar,10);
 
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@bankName"].Value = bankName;
			scom.Parameters["@sortName"].Value = sortName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zBank table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@sortName", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@bankName"].Value = bankName;
			scom.Parameters["@sortName"].Value = sortName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zBank table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zBank table.
		/// </summary>
		public static tbl_zBank Select(string bank_ID_Incoming){

			tbl_zBank tbl_zBankins = new tbl_zBank();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zBankins = Maketbl_zBank(dataReader);
				} else {
					tbl_zBankins = null;
				}
			}
			scon.Close();
			return tbl_zBankins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zBank table.
		/// </summary>
		public static List<tbl_zBank> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBankSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zBank> tbl_zBankList = new List<tbl_zBank>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zBank tbl_zBank = Maketbl_zBank(dataReader);
					tbl_zBankList.Add(tbl_zBank);
				}
			}
			scon.Close();
			return tbl_zBankList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zBank class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zBank Maketbl_zBank(SqlDataReader dataReader) {
			tbl_zBank tbl_zBank = new tbl_zBank();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zBank.Bank_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zBank.BankName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zBank.SortName = dataReader.GetString(2);
			}

			return tbl_zBank;
		}
		/// <summary>
		/// This makes tbl_zBank datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zBank object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zBank  tbl_zBank   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_bankName = new DataColumn("bankName" , typeof(string));
			DataColumn col_sortName = new DataColumn("sortName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_bank_ID,col_bankName,col_sortName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zBank datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zBank object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zBank user) {
		DataRow drow = dt.NewRow();
		
			drow["bank_ID"] = user.bank_ID;
			drow["bankName"] = user.bankName;
			drow["sortName"] = user.sortName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
