using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pay_EarningAndDicuctions {
		#region Fields
		private string end_ID;
		private string end_Name;
		private string end_Type;
		private string end_Description;
		private int end_Rate;
		private decimal end_FlatRate;
		private decimal end_PercentageRate;
		private bool end_Epf;
		private decimal end_DiductFromEmp;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pay_EarningAndDicuctions class.
		/// </summary>
		public tbl_pay_EarningAndDicuctions() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pay_EarningAndDicuctions class.
		/// </summary>
		public tbl_pay_EarningAndDicuctions(string end_ID, string end_Name, string end_Type, string end_Description, int end_Rate, decimal end_FlatRate, decimal end_PercentageRate, bool end_Epf, decimal end_DiductFromEmp, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.end_ID = end_ID;
			this.end_Name = end_Name;
			this.end_Type = end_Type;
			this.end_Description = end_Description;
			this.end_Rate = end_Rate;
			this.end_FlatRate = end_FlatRate;
			this.end_PercentageRate = end_PercentageRate;
			this.end_Epf = end_Epf;
			this.end_DiductFromEmp = end_DiductFromEmp;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the End_ID value.
		/// </summary>
		public string End_ID {
			get { return end_ID; }
			set { end_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_Name value.
		/// </summary>
		public string End_Name {
			get { return end_Name; }
			set { end_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_Type value.
		/// </summary>
		public string End_Type {
			get { return end_Type; }
			set { end_Type = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_Description value.
		/// </summary>
		public string End_Description {
			get { return end_Description; }
			set { end_Description = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_Rate value.
		/// </summary>
		public int End_Rate {
			get { return end_Rate; }
			set { end_Rate = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_FlatRate value.
		/// </summary>
		public decimal End_FlatRate {
			get { return end_FlatRate; }
			set { end_FlatRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_PercentageRate value.
		/// </summary>
		public decimal End_PercentageRate {
			get { return end_PercentageRate; }
			set { end_PercentageRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_Epf value.
		/// </summary>
		public bool End_Epf {
			get { return end_Epf; }
			set { end_Epf = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_DiductFromEmp value.
		/// </summary>
		public decimal End_DiductFromEmp {
			get { return end_DiductFromEmp; }
			set { end_DiductFromEmp = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pay_EarningAndDicuctions table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pay_EarningAndDicuctionsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@end_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@end_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@end_Type", SqlDbType.VarChar,20);
			scom.Parameters.Add("@end_Description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@end_Rate", SqlDbType.Int,4);
			scom.Parameters.Add("@end_FlatRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@end_PercentageRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@end_Epf", SqlDbType.Bit,1);
			scom.Parameters.Add("@end_DiductFromEmp", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@end_ID"].Value = end_ID;
			scom.Parameters["@end_Name"].Value = end_Name;
			scom.Parameters["@end_Type"].Value = end_Type;
			scom.Parameters["@end_Description"].Value = end_Description;
			scom.Parameters["@end_Rate"].Value = end_Rate;
			scom.Parameters["@end_FlatRate"].Value = end_FlatRate;
			scom.Parameters["@end_PercentageRate"].Value = end_PercentageRate;
			scom.Parameters["@end_Epf"].Value = end_Epf;
			scom.Parameters["@end_DiductFromEmp"].Value = end_DiductFromEmp;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pay_EarningAndDicuctions table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pay_EarningAndDicuctionsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@end_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@end_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@end_Type", SqlDbType.VarChar,20);
			scom.Parameters.Add("@end_Description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@end_Rate", SqlDbType.Int,4);
			scom.Parameters.Add("@end_FlatRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@end_PercentageRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@end_Epf", SqlDbType.Bit,1);
			scom.Parameters.Add("@end_DiductFromEmp", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@end_ID"].Value = end_ID;
			scom.Parameters["@end_Name"].Value = end_Name;
			scom.Parameters["@end_Type"].Value = end_Type;
			scom.Parameters["@end_Description"].Value = end_Description;
			scom.Parameters["@end_Rate"].Value = end_Rate;
			scom.Parameters["@end_FlatRate"].Value = end_FlatRate;
			scom.Parameters["@end_PercentageRate"].Value = end_PercentageRate;
			scom.Parameters["@end_Epf"].Value = end_Epf;
			scom.Parameters["@end_DiductFromEmp"].Value = end_DiductFromEmp;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pay_EarningAndDicuctions table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pay_EarningAndDicuctionsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@end_ID", SqlDbType.VarChar,8);
			scom.Parameters["@end_ID"].Value = end_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pay_EarningAndDicuctions table.
		/// </summary>
		public static tbl_pay_EarningAndDicuctions Select(string end_ID_Incoming){

			tbl_pay_EarningAndDicuctions tbl_pay_EarningAndDicuctionsins = new tbl_pay_EarningAndDicuctions();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pay_EarningAndDicuctionsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@end_ID", SqlDbType.VarChar,8);
			scom.Parameters["@end_ID"].Value = end_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pay_EarningAndDicuctionsins = Maketbl_pay_EarningAndDicuctions(dataReader);
				} else {
					tbl_pay_EarningAndDicuctionsins = null;
				}
			}
			scon.Close();
			return tbl_pay_EarningAndDicuctionsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pay_EarningAndDicuctions table.
		/// </summary>
		public static List<tbl_pay_EarningAndDicuctions> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pay_EarningAndDicuctionsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pay_EarningAndDicuctions> tbl_pay_EarningAndDicuctionsList = new List<tbl_pay_EarningAndDicuctions>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pay_EarningAndDicuctions tbl_pay_EarningAndDicuctions = Maketbl_pay_EarningAndDicuctions(dataReader);
					tbl_pay_EarningAndDicuctionsList.Add(tbl_pay_EarningAndDicuctions);
				}
			}
			scon.Close();
			return tbl_pay_EarningAndDicuctionsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pay_EarningAndDicuctions class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pay_EarningAndDicuctions Maketbl_pay_EarningAndDicuctions(SqlDataReader dataReader) {
			tbl_pay_EarningAndDicuctions tbl_pay_EarningAndDicuctions = new tbl_pay_EarningAndDicuctions();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pay_EarningAndDicuctions.End_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pay_EarningAndDicuctions.End_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pay_EarningAndDicuctions.End_Type = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pay_EarningAndDicuctions.End_Description = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pay_EarningAndDicuctions.End_Rate = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pay_EarningAndDicuctions.End_FlatRate = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pay_EarningAndDicuctions.End_PercentageRate = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pay_EarningAndDicuctions.End_Epf = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pay_EarningAndDicuctions.End_DiductFromEmp = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pay_EarningAndDicuctions.IsCanceled = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pay_EarningAndDicuctions.UserID_Created = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pay_EarningAndDicuctions.UserID_Modified = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pay_EarningAndDicuctions.UserID_Canceled = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pay_EarningAndDicuctions.TerminalID_Created = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pay_EarningAndDicuctions.TerminalID_Modified = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pay_EarningAndDicuctions.TerminalID_Canceled = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pay_EarningAndDicuctions.Date_Created = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pay_EarningAndDicuctions.Date_Modified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pay_EarningAndDicuctions.Date_Canceled = dataReader.GetDateTime(18);
			}

			return tbl_pay_EarningAndDicuctions;
		}
		/// <summary>
		/// This makes tbl_pay_EarningAndDicuctions datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pay_EarningAndDicuctions object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pay_EarningAndDicuctions  tbl_pay_EarningAndDicuctions   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_end_ID = new DataColumn("end_ID" , typeof(string));
			DataColumn col_end_Name = new DataColumn("end_Name" , typeof(string));
			DataColumn col_end_Type = new DataColumn("end_Type" , typeof(string));
			DataColumn col_end_Description = new DataColumn("end_Description" , typeof(string));
			DataColumn col_end_Rate = new DataColumn("end_Rate" , typeof(int));
			DataColumn col_end_FlatRate = new DataColumn("end_FlatRate" , typeof(decimal));
			DataColumn col_end_PercentageRate = new DataColumn("end_PercentageRate" , typeof(decimal));
			DataColumn col_end_Epf = new DataColumn("end_Epf" , typeof(bool));
			DataColumn col_end_DiductFromEmp = new DataColumn("end_DiductFromEmp" , typeof(decimal));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_end_ID,col_end_Name,col_end_Type,col_end_Description,col_end_Rate,col_end_FlatRate,col_end_PercentageRate,col_end_Epf,col_end_DiductFromEmp,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pay_EarningAndDicuctions datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pay_EarningAndDicuctions object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pay_EarningAndDicuctions user) {
		DataRow drow = dt.NewRow();
		
			drow["end_ID"] = user.end_ID;
			drow["end_Name"] = user.end_Name;
			drow["end_Type"] = user.end_Type;
			drow["end_Description"] = user.end_Description;
			drow["end_Rate"] = user.end_Rate;
			drow["end_FlatRate"] = user.end_FlatRate;
			drow["end_PercentageRate"] = user.end_PercentageRate;
			drow["end_Epf"] = user.end_Epf;
			drow["end_DiductFromEmp"] = user.end_DiductFromEmp;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
