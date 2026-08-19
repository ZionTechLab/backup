using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_posDayStartAndEnd_Detail_CashWithdrawal {
		#region Fields
		private int line_No;
		private int dayDetail_Index;
		private DateTime withdrawal_Time;
		private decimal amount;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_posDayStartAndEnd_Detail_CashWithdrawal class.
		/// </summary>
		public tbl_posDayStartAndEnd_Detail_CashWithdrawal() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_posDayStartAndEnd_Detail_CashWithdrawal class.
		/// </summary>
		public tbl_posDayStartAndEnd_Detail_CashWithdrawal(int line_No, int dayDetail_Index, DateTime withdrawal_Time, decimal amount, string remark) {
			this.line_No = line_No;
			this.dayDetail_Index = dayDetail_Index;
			this.withdrawal_Time = withdrawal_Time;
			this.amount = amount;
			this.remark = remark;
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
		/// Gets or sets the DayDetail_Index value.
		/// </summary>
		public int DayDetail_Index {
			get { return dayDetail_Index; }
			set { dayDetail_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Withdrawal_Time value.
		/// </summary>
		public DateTime Withdrawal_Time {
			get { return withdrawal_Time; }
			set { withdrawal_Time = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_posDayStartAndEnd_Detail_CashWithdrawal table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_Detail_CashWithdrawalInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@withdrawal_Time", SqlDbType.DateTime,8);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
			scom.Parameters["@withdrawal_Time"].Value = withdrawal_Time;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_posDayStartAndEnd_Detail_CashWithdrawal table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_Detail_CashWithdrawalUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@withdrawal_Time", SqlDbType.DateTime,8);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
			scom.Parameters["@withdrawal_Time"].Value = withdrawal_Time;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_posDayStartAndEnd_Detail_CashWithdrawal table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_Detail_CashWithdrawalDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail_CashWithdrawal table by a foreign key.
		/// </summary>
		public static void DeleteAllByDayDetail_Index(int dayDetail_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_Detail_CashWithdrawalDeleteAllByDayDetail_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_posDayStartAndEnd_Detail_CashWithdrawal table.
		/// </summary>
		public static tbl_posDayStartAndEnd_Detail_CashWithdrawal Select(int line_No_Incoming, int dayDetail_Index_Incoming){

			tbl_posDayStartAndEnd_Detail_CashWithdrawal tbl_posDayStartAndEnd_Detail_CashWithdrawalins = new tbl_posDayStartAndEnd_Detail_CashWithdrawal();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_Detail_CashWithdrawalSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail_CashWithdrawalins = Maketbl_posDayStartAndEnd_Detail_CashWithdrawal(dataReader);
				} else {
					tbl_posDayStartAndEnd_Detail_CashWithdrawalins = null;
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_Detail_CashWithdrawalins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail_CashWithdrawal table.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail_CashWithdrawal> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_Detail_CashWithdrawalSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_posDayStartAndEnd_Detail_CashWithdrawal> tbl_posDayStartAndEnd_Detail_CashWithdrawalList = new List<tbl_posDayStartAndEnd_Detail_CashWithdrawal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail_CashWithdrawal tbl_posDayStartAndEnd_Detail_CashWithdrawal = Maketbl_posDayStartAndEnd_Detail_CashWithdrawal(dataReader);
					tbl_posDayStartAndEnd_Detail_CashWithdrawalList.Add(tbl_posDayStartAndEnd_Detail_CashWithdrawal);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_Detail_CashWithdrawalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail_CashWithdrawal table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail_CashWithdrawal> SelectAllByDayDetail_Index(int dayDetail_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_Detail_CashWithdrawalSelectAllByDayDetail_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
				List<tbl_posDayStartAndEnd_Detail_CashWithdrawal> tbl_posDayStartAndEnd_Detail_CashWithdrawalList = new List<tbl_posDayStartAndEnd_Detail_CashWithdrawal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail_CashWithdrawal tbl_posDayStartAndEnd_Detail_CashWithdrawal = Maketbl_posDayStartAndEnd_Detail_CashWithdrawal(dataReader);
					tbl_posDayStartAndEnd_Detail_CashWithdrawalList.Add(tbl_posDayStartAndEnd_Detail_CashWithdrawal);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_Detail_CashWithdrawalList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_posDayStartAndEnd_Detail_CashWithdrawal class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_posDayStartAndEnd_Detail_CashWithdrawal Maketbl_posDayStartAndEnd_Detail_CashWithdrawal(SqlDataReader dataReader) {
			tbl_posDayStartAndEnd_Detail_CashWithdrawal tbl_posDayStartAndEnd_Detail_CashWithdrawal = new tbl_posDayStartAndEnd_Detail_CashWithdrawal();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_posDayStartAndEnd_Detail_CashWithdrawal.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_posDayStartAndEnd_Detail_CashWithdrawal.DayDetail_Index = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_posDayStartAndEnd_Detail_CashWithdrawal.Withdrawal_Time = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_posDayStartAndEnd_Detail_CashWithdrawal.Amount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_posDayStartAndEnd_Detail_CashWithdrawal.Remark = dataReader.GetString(4);
			}

			return tbl_posDayStartAndEnd_Detail_CashWithdrawal;
		}
		/// <summary>
		/// This makes tbl_posDayStartAndEnd_Detail_CashWithdrawal datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_posDayStartAndEnd_Detail_CashWithdrawal object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_posDayStartAndEnd_Detail_CashWithdrawal  tbl_posDayStartAndEnd_Detail_CashWithdrawal   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_dayDetail_Index = new DataColumn("dayDetail_Index" , typeof(int));
			DataColumn col_withdrawal_Time = new DataColumn("withdrawal_Time" , typeof(DateTime));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_dayDetail_Index,col_withdrawal_Time,col_amount,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_posDayStartAndEnd_Detail_CashWithdrawal datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_posDayStartAndEnd_Detail_CashWithdrawal object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_posDayStartAndEnd_Detail_CashWithdrawal user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["dayDetail_Index"] = user.dayDetail_Index;
			drow["withdrawal_Time"] = user.withdrawal_Time;
			drow["amount"] = user.amount;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
