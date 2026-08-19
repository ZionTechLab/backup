using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityPurge_Detail {
		#region Fields
		private int line_No;
		private string purge_ID;
		private string transaction_ID;
		private DateTime transactionDate;
		private string customer_ID;
		private int processNote_ID;
		private bool isPurgeEnd;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityPurge_Detail class.
		/// </summary>
		public tbl_securityPurge_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityPurge_Detail class.
		/// </summary>
		public tbl_securityPurge_Detail(string purge_ID, string transaction_ID, DateTime transactionDate, string customer_ID, int processNote_ID, bool isPurgeEnd) {
			this.purge_ID = purge_ID;
			this.transaction_ID = transaction_ID;
			this.transactionDate = transactionDate;
			this.customer_ID = customer_ID;
			this.processNote_ID = processNote_ID;
			this.isPurgeEnd = isPurgeEnd;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityPurge_Detail class.
		/// </summary>
		public tbl_securityPurge_Detail(int line_No, string purge_ID, string transaction_ID, DateTime transactionDate, string customer_ID, int processNote_ID, bool isPurgeEnd) {
			this.line_No = line_No;
			this.purge_ID = purge_ID;
			this.transaction_ID = transaction_ID;
			this.transactionDate = transactionDate;
			this.customer_ID = customer_ID;
			this.processNote_ID = processNote_ID;
			this.isPurgeEnd = isPurgeEnd;
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
		/// Gets or sets the Purge_ID value.
		/// </summary>
		public string Purge_ID {
			get { return purge_ID; }
			set { purge_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessNote_ID value.
		/// </summary>
		public int ProcessNote_ID {
			get { return processNote_ID; }
			set { processNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPurgeEnd value.
		/// </summary>
		public bool IsPurgeEnd {
			get { return isPurgeEnd; }
			set { isPurgeEnd = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityPurge_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@purge_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isPurgeEnd", SqlDbType.Bit,1);
 
			scom.Parameters["@purge_ID"].Value = purge_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@isPurgeEnd"].Value = isPurgeEnd;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityPurge_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
			scom.Parameters.Add("@purge_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isPurgeEnd", SqlDbType.Bit,1);

            scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@purge_ID"].Value = purge_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@isPurgeEnd"].Value = isPurgeEnd;
            
            
 
			scon.Open();
            scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityPurge_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPurge_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailDeleteAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPurge_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPurge_ID(string purge_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailDeleteAllByPurge_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purge_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purge_ID"].Value = purge_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPurge_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityPurge_Detail table.
		/// </summary>
		public static tbl_securityPurge_Detail Select(int line_No_Incoming){

			tbl_securityPurge_Detail tbl_securityPurge_Detailins = new tbl_securityPurge_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityPurge_Detailins = Maketbl_securityPurge_Detail(dataReader);
				} else {
					tbl_securityPurge_Detailins = null;
				}
			}
			scon.Close();
			return tbl_securityPurge_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPurge_Detail table.
		/// </summary>
		public static List<tbl_securityPurge_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityPurge_Detail> tbl_securityPurge_DetailList = new List<tbl_securityPurge_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityPurge_Detail tbl_securityPurge_Detail = Maketbl_securityPurge_Detail(dataReader);
					tbl_securityPurge_DetailList.Add(tbl_securityPurge_Detail);
				}
			}
			scon.Close();
			return tbl_securityPurge_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPurge_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_securityPurge_Detail> SelectAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailSelectAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
				List<tbl_securityPurge_Detail> tbl_securityPurge_DetailList = new List<tbl_securityPurge_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityPurge_Detail tbl_securityPurge_Detail = Maketbl_securityPurge_Detail(dataReader);
					tbl_securityPurge_DetailList.Add(tbl_securityPurge_Detail);
				}
			}
			scon.Close();
			return tbl_securityPurge_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPurge_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_securityPurge_Detail> SelectAllByPurge_ID(string purge_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailSelectAllByPurge_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purge_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purge_ID"].Value = purge_ID;
				List<tbl_securityPurge_Detail> tbl_securityPurge_DetailList = new List<tbl_securityPurge_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityPurge_Detail tbl_securityPurge_Detail = Maketbl_securityPurge_Detail(dataReader);
					tbl_securityPurge_DetailList.Add(tbl_securityPurge_Detail);
				}
			}
			scon.Close();
			return tbl_securityPurge_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPurge_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_securityPurge_Detail> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPurge_DetailSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_securityPurge_Detail> tbl_securityPurge_DetailList = new List<tbl_securityPurge_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityPurge_Detail tbl_securityPurge_Detail = Maketbl_securityPurge_Detail(dataReader);
					tbl_securityPurge_DetailList.Add(tbl_securityPurge_Detail);
				}
			}
			scon.Close();
			return tbl_securityPurge_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityPurge_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityPurge_Detail Maketbl_securityPurge_Detail(SqlDataReader dataReader) {
			tbl_securityPurge_Detail tbl_securityPurge_Detail = new tbl_securityPurge_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityPurge_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityPurge_Detail.Purge_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityPurge_Detail.Transaction_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityPurge_Detail.TransactionDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityPurge_Detail.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityPurge_Detail.ProcessNote_ID = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityPurge_Detail.IsPurgeEnd = dataReader.GetBoolean(6);
			}

			return tbl_securityPurge_Detail;
		}
		/// <summary>
		/// This makes tbl_securityPurge_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityPurge_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityPurge_Detail  tbl_securityPurge_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_purge_ID = new DataColumn("purge_ID" , typeof(string));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_transactionDate = new DataColumn("transactionDate" , typeof(DateTime));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_processNote_ID = new DataColumn("processNote_ID" , typeof(int));
			DataColumn col_isPurgeEnd = new DataColumn("isPurgeEnd" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_purge_ID,col_transaction_ID,col_transactionDate,col_customer_ID,col_processNote_ID,col_isPurgeEnd,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityPurge_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityPurge_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityPurge_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["purge_ID"] = user.purge_ID;
			drow["transaction_ID"] = user.transaction_ID;
			drow["transactionDate"] = user.transactionDate;
			drow["customer_ID"] = user.customer_ID;
			drow["processNote_ID"] = user.processNote_ID;
			drow["isPurgeEnd"] = user.isPurgeEnd;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
