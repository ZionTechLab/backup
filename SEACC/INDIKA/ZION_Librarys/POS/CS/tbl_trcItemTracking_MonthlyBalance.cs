using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_trcItemTracking_MonthlyBalance {
		#region Fields
		private int month_ID;
		private string createUser_ID;
		private string createTerminal_ID;
		private DateTime dateCreate;
		private bool isfinished;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_trcItemTracking_MonthlyBalance class.
		/// </summary>
		public tbl_trcItemTracking_MonthlyBalance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_trcItemTracking_MonthlyBalance class.
		/// </summary>
		public tbl_trcItemTracking_MonthlyBalance(int month_ID, string createUser_ID, string createTerminal_ID, DateTime dateCreate, bool isfinished) {
			this.month_ID = month_ID;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.dateCreate = dateCreate;
			this.isfinished = isfinished;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Month_ID value.
		/// </summary>
		public int Month_ID {
			get { return month_ID; }
			set { month_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Isfinished value.
		/// </summary>
		public bool Isfinished {
			get { return isfinished; }
			set { isfinished = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_trcItemTracking_MonthlyBalance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isfinished", SqlDbType.Bit,1);
 
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@isfinished"].Value = isfinished;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_trcItemTracking_MonthlyBalance table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalanceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isfinished", SqlDbType.Bit,1);
 
 
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@isfinished"].Value = isfinished;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_trcItemTracking_MonthlyBalance table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalanceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters["@month_ID"].Value = month_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_trcItemTracking_MonthlyBalance table.
		/// </summary>
		public static tbl_trcItemTracking_MonthlyBalance Select(int month_ID_Incoming){

			tbl_trcItemTracking_MonthlyBalance tbl_trcItemTracking_MonthlyBalanceins = new tbl_trcItemTracking_MonthlyBalance();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalanceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters["@month_ID"].Value = month_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_trcItemTracking_MonthlyBalanceins = Maketbl_trcItemTracking_MonthlyBalance(dataReader);
				} else {
					tbl_trcItemTracking_MonthlyBalanceins = null;
				}
			}
			scon.Close();
			return tbl_trcItemTracking_MonthlyBalanceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking_MonthlyBalance table.
		/// </summary>
		public static List<tbl_trcItemTracking_MonthlyBalance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_trcItemTracking_MonthlyBalance> tbl_trcItemTracking_MonthlyBalanceList = new List<tbl_trcItemTracking_MonthlyBalance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcItemTracking_MonthlyBalance tbl_trcItemTracking_MonthlyBalance = Maketbl_trcItemTracking_MonthlyBalance(dataReader);
					tbl_trcItemTracking_MonthlyBalanceList.Add(tbl_trcItemTracking_MonthlyBalance);
				}
			}
			scon.Close();
			return tbl_trcItemTracking_MonthlyBalanceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_trcItemTracking_MonthlyBalance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_trcItemTracking_MonthlyBalance Maketbl_trcItemTracking_MonthlyBalance(SqlDataReader dataReader) {
			tbl_trcItemTracking_MonthlyBalance tbl_trcItemTracking_MonthlyBalance = new tbl_trcItemTracking_MonthlyBalance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_trcItemTracking_MonthlyBalance.Month_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_trcItemTracking_MonthlyBalance.CreateUser_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_trcItemTracking_MonthlyBalance.CreateTerminal_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_trcItemTracking_MonthlyBalance.DateCreate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_trcItemTracking_MonthlyBalance.Isfinished = dataReader.GetBoolean(4);
			}

			return tbl_trcItemTracking_MonthlyBalance;
		}
		/// <summary>
		/// This makes tbl_trcItemTracking_MonthlyBalance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_trcItemTracking_MonthlyBalance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_trcItemTracking_MonthlyBalance  tbl_trcItemTracking_MonthlyBalance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(int));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_isfinished = new DataColumn("isfinished" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_month_ID,col_createUser_ID,col_createTerminal_ID,col_dateCreate,col_isfinished,});		return dt;
		}
		/// <summary>
		/// This fills tbl_trcItemTracking_MonthlyBalance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_trcItemTracking_MonthlyBalance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_trcItemTracking_MonthlyBalance user) {
		DataRow drow = dt.NewRow();
		
			drow["month_ID"] = user.month_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["isfinished"] = user.isfinished;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
