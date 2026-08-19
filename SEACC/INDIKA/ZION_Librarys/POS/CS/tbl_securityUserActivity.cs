using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityUserActivity {
		#region Fields
		private int functionForm_ID;
		private int functionReport_ID;
		private string transaction_ID;
		private int printCount;
		private string printedUser_ID;
		private string printedTerminal_ID;
		private DateTime datePrinted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserActivity class.
		/// </summary>
		public tbl_securityUserActivity() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserActivity class.
		/// </summary>
		public tbl_securityUserActivity(int functionForm_ID, int functionReport_ID, string transaction_ID, int printCount, string printedUser_ID, string printedTerminal_ID, DateTime datePrinted) {
			this.functionForm_ID = functionForm_ID;
			this.functionReport_ID = functionReport_ID;
			this.transaction_ID = transaction_ID;
			this.printCount = printCount;
			this.printedUser_ID = printedUser_ID;
			this.printedTerminal_ID = printedTerminal_ID;
			this.datePrinted = datePrinted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FunctionForm_ID value.
		/// </summary>
		public int FunctionForm_ID {
			get { return functionForm_ID; }
			set { functionForm_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FunctionReport_ID value.
		/// </summary>
		public int FunctionReport_ID {
			get { return functionReport_ID; }
			set { functionReport_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintedUser_ID value.
		/// </summary>
		public string PrintedUser_ID {
			get { return printedUser_ID; }
			set { printedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintedTerminal_ID value.
		/// </summary>
		public string PrintedTerminal_ID {
			get { return printedTerminal_ID; }
			set { printedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DatePrinted value.
		/// </summary>
		public DateTime DatePrinted {
			get { return datePrinted; }
			set { datePrinted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityUserActivity table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivityInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@functionForm_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@functionReport_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
 
			scom.Parameters["@functionForm_ID"].Value = functionForm_ID;
			scom.Parameters["@functionReport_ID"].Value = functionReport_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@datePrinted"].Value = datePrinted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityUserActivity table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivityUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@functionForm_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@functionReport_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@functionForm_ID"].Value = functionForm_ID;
			scom.Parameters["@functionReport_ID"].Value = functionReport_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@datePrinted"].Value = datePrinted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityUserActivity table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivityDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@functionForm_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@functionReport_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,50);
			scom.Parameters["@functionForm_ID"].Value = functionForm_ID;
 
			scom.Parameters["@functionReport_ID"].Value = functionReport_ID;
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserActivity table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunctionReport_ID(int functionReport_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivityDeleteAllByFunctionReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@functionReport_ID", SqlDbType.Int,4);
			scom.Parameters["@functionReport_ID"].Value = functionReport_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserActivity table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunctionForm_ID(int functionForm_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivityDeleteAllByFunctionForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@functionForm_ID", SqlDbType.Int,4);
			scom.Parameters["@functionForm_ID"].Value = functionForm_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityUserActivity table.
		/// </summary>
		public static tbl_securityUserActivity Select(int functionForm_ID_Incoming, int functionReport_ID_Incoming, string transaction_ID_Incoming){

			tbl_securityUserActivity tbl_securityUserActivityins = new tbl_securityUserActivity();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivitySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@functionForm_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@functionReport_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,50);
			scom.Parameters["@functionForm_ID"].Value = functionForm_ID_Incoming;
			scom.Parameters["@functionReport_ID"].Value = functionReport_ID_Incoming;
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityUserActivityins = Maketbl_securityUserActivity(dataReader);
				} else {
					tbl_securityUserActivityins = null;
				}
			}
			scon.Close();
			return tbl_securityUserActivityins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserActivity table.
		/// </summary>
		public static List<tbl_securityUserActivity> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivitySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityUserActivity> tbl_securityUserActivityList = new List<tbl_securityUserActivity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserActivity tbl_securityUserActivity = Maketbl_securityUserActivity(dataReader);
					tbl_securityUserActivityList.Add(tbl_securityUserActivity);
				}
			}
			scon.Close();
			return tbl_securityUserActivityList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserActivity table by a foreign key.
		/// </summary>
		public static List<tbl_securityUserActivity> SelectAllByFunctionReport_ID(int functionReport_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivitySelectAllByFunctionReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@functionReport_ID", SqlDbType.Int,4);
			scom.Parameters["@functionReport_ID"].Value = functionReport_ID;
				List<tbl_securityUserActivity> tbl_securityUserActivityList = new List<tbl_securityUserActivity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserActivity tbl_securityUserActivity = Maketbl_securityUserActivity(dataReader);
					tbl_securityUserActivityList.Add(tbl_securityUserActivity);
				}
			}
			scon.Close();
			return tbl_securityUserActivityList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserActivity table by a foreign key.
		/// </summary>
		public static List<tbl_securityUserActivity> SelectAllByFunctionForm_ID(int functionForm_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserActivitySelectAllByFunctionForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@functionForm_ID", SqlDbType.Int,4);
			scom.Parameters["@functionForm_ID"].Value = functionForm_ID;
				List<tbl_securityUserActivity> tbl_securityUserActivityList = new List<tbl_securityUserActivity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserActivity tbl_securityUserActivity = Maketbl_securityUserActivity(dataReader);
					tbl_securityUserActivityList.Add(tbl_securityUserActivity);
				}
			}
			scon.Close();
			return tbl_securityUserActivityList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityUserActivity class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityUserActivity Maketbl_securityUserActivity(SqlDataReader dataReader) {
			tbl_securityUserActivity tbl_securityUserActivity = new tbl_securityUserActivity();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityUserActivity.FunctionForm_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityUserActivity.FunctionReport_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityUserActivity.Transaction_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityUserActivity.PrintCount = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityUserActivity.PrintedUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityUserActivity.PrintedTerminal_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityUserActivity.DatePrinted = dataReader.GetDateTime(6);
			}

			return tbl_securityUserActivity;
		}
		/// <summary>
		/// This makes tbl_securityUserActivity datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityUserActivity object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityUserActivity  tbl_securityUserActivity   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_functionForm_ID = new DataColumn("functionForm_ID" , typeof(int));
			DataColumn col_functionReport_ID = new DataColumn("functionReport_ID" , typeof(int));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_printedUser_ID = new DataColumn("printedUser_ID" , typeof(string));
			DataColumn col_printedTerminal_ID = new DataColumn("printedTerminal_ID" , typeof(string));
			DataColumn col_datePrinted = new DataColumn("datePrinted" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_functionForm_ID,col_functionReport_ID,col_transaction_ID,col_printCount,col_printedUser_ID,col_printedTerminal_ID,col_datePrinted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityUserActivity datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityUserActivity object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityUserActivity user) {
		DataRow drow = dt.NewRow();
		
			drow["functionForm_ID"] = user.functionForm_ID;
			drow["functionReport_ID"] = user.functionReport_ID;
			drow["transaction_ID"] = user.transaction_ID;
			drow["printCount"] = user.printCount;
			drow["printedUser_ID"] = user.printedUser_ID;
			drow["printedTerminal_ID"] = user.printedTerminal_ID;
			drow["datePrinted"] = user.datePrinted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
