using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsFixedAssetDepreciation {
		#region Fields
		private string fixedAssetDepreciation_ID;
		private int barcode_ID;
		private string financialYear_ID;
		private string month_ID;
		private string department_ID;
		private DateTime date_from;
		private DateTime date_to;
		private decimal openingWDN;
		private decimal monthDeprecation;
		private decimal closingWDN;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsFixedAssetDepreciation class.
		/// </summary>
		public tbl_scsFixedAssetDepreciation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsFixedAssetDepreciation class.
		/// </summary>
		public tbl_scsFixedAssetDepreciation(string fixedAssetDepreciation_ID, int barcode_ID, string financialYear_ID, string month_ID, string department_ID, DateTime date_from, DateTime date_to, decimal openingWDN, decimal monthDeprecation, decimal closingWDN) {
			this.fixedAssetDepreciation_ID = fixedAssetDepreciation_ID;
			this.barcode_ID = barcode_ID;
			this.financialYear_ID = financialYear_ID;
			this.month_ID = month_ID;
			this.department_ID = department_ID;
			this.date_from = date_from;
			this.date_to = date_to;
			this.openingWDN = openingWDN;
			this.monthDeprecation = monthDeprecation;
			this.closingWDN = closingWDN;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FixedAssetDepreciation_ID value.
		/// </summary>
		public string FixedAssetDepreciation_ID {
			get { return fixedAssetDepreciation_ID; }
			set { fixedAssetDepreciation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Barcode_ID value.
		/// </summary>
		public int Barcode_ID {
			get { return barcode_ID; }
			set { barcode_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_ID value.
		/// </summary>
		public string Month_ID {
			get { return month_ID; }
			set { month_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_from value.
		/// </summary>
		public DateTime Date_from {
			get { return date_from; }
			set { date_from = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_to value.
		/// </summary>
		public DateTime Date_to {
			get { return date_to; }
			set { date_to = value; }
		}
		
		/// <summary>
		/// Gets or sets the OpeningWDN value.
		/// </summary>
		public decimal OpeningWDN {
			get { return openingWDN; }
			set { openingWDN = value; }
		}
		
		/// <summary>
		/// Gets or sets the MonthDeprecation value.
		/// </summary>
		public decimal MonthDeprecation {
			get { return monthDeprecation; }
			set { monthDeprecation = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClosingWDN value.
		/// </summary>
		public decimal ClosingWDN {
			get { return closingWDN; }
			set { closingWDN = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsFixedAssetDepreciation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@fixedAssetDepreciation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Date_from", SqlDbType.DateTime,8);
			scom.Parameters.Add("@Date_to", SqlDbType.DateTime,8);
			scom.Parameters.Add("@openingWDN", SqlDbType.Decimal,9);
			scom.Parameters.Add("@monthDeprecation", SqlDbType.Decimal,9);
			scom.Parameters.Add("@closingWDN", SqlDbType.Decimal,9);
 
			scom.Parameters["@fixedAssetDepreciation_ID"].Value = fixedAssetDepreciation_ID;
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@Date_from"].Value = date_from;
			scom.Parameters["@Date_to"].Value = date_to;
			scom.Parameters["@openingWDN"].Value = openingWDN;
			scom.Parameters["@monthDeprecation"].Value = monthDeprecation;
			scom.Parameters["@closingWDN"].Value = closingWDN;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsFixedAssetDepreciation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@fixedAssetDepreciation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Date_from", SqlDbType.DateTime,8);
			scom.Parameters.Add("@Date_to", SqlDbType.DateTime,8);
			scom.Parameters.Add("@openingWDN", SqlDbType.Decimal,9);
			scom.Parameters.Add("@monthDeprecation", SqlDbType.Decimal,9);
			scom.Parameters.Add("@closingWDN", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@fixedAssetDepreciation_ID"].Value = fixedAssetDepreciation_ID;
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@Date_from"].Value = date_from;
			scom.Parameters["@Date_to"].Value = date_to;
			scom.Parameters["@openingWDN"].Value = openingWDN;
			scom.Parameters["@monthDeprecation"].Value = monthDeprecation;
			scom.Parameters["@closingWDN"].Value = closingWDN;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsFixedAssetDepreciation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@fixedAssetDepreciation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fixedAssetDepreciation_ID"].Value = fixedAssetDepreciation_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAssetDepreciation table by a foreign key.
		/// </summary>
		public static void DeleteAllByFinancialYear_ID_Month_ID(string financialYear_ID, string month_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationDeleteAllByFinancialYear_ID_Month_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAssetDepreciation table by a foreign key.
		/// </summary>
		public static void DeleteAllByDepartment_ID(string department_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationDeleteAllByDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAssetDepreciation table by a foreign key.
		/// </summary>
		public static void DeleteAllByBarcode_ID(int barcode_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationDeleteAllByBarcode_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsFixedAssetDepreciation table.
		/// </summary>
		public static tbl_scsFixedAssetDepreciation Select(string fixedAssetDepreciation_ID_Incoming){

			tbl_scsFixedAssetDepreciation tbl_scsFixedAssetDepreciationins = new tbl_scsFixedAssetDepreciation();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fixedAssetDepreciation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fixedAssetDepreciation_ID"].Value = fixedAssetDepreciation_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsFixedAssetDepreciationins = Maketbl_scsFixedAssetDepreciation(dataReader);
				} else {
					tbl_scsFixedAssetDepreciationins = null;
				}
			}
			scon.Close();
			return tbl_scsFixedAssetDepreciationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAssetDepreciation table.
		/// </summary>
		public static List<tbl_scsFixedAssetDepreciation> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsFixedAssetDepreciation> tbl_scsFixedAssetDepreciationList = new List<tbl_scsFixedAssetDepreciation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsFixedAssetDepreciation tbl_scsFixedAssetDepreciation = Maketbl_scsFixedAssetDepreciation(dataReader);
					tbl_scsFixedAssetDepreciationList.Add(tbl_scsFixedAssetDepreciation);
				}
			}
			scon.Close();
			return tbl_scsFixedAssetDepreciationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAssetDepreciation table by a foreign key.
		/// </summary>
		public static List<tbl_scsFixedAssetDepreciation> SelectAllByFinancialYear_ID_Month_ID(string financialYear_ID, string month_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationSelectAllByFinancialYear_ID_Month_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
				List<tbl_scsFixedAssetDepreciation> tbl_scsFixedAssetDepreciationList = new List<tbl_scsFixedAssetDepreciation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsFixedAssetDepreciation tbl_scsFixedAssetDepreciation = Maketbl_scsFixedAssetDepreciation(dataReader);
					tbl_scsFixedAssetDepreciationList.Add(tbl_scsFixedAssetDepreciation);
				}
			}
			scon.Close();
			return tbl_scsFixedAssetDepreciationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAssetDepreciation table by a foreign key.
		/// </summary>
		public static List<tbl_scsFixedAssetDepreciation> SelectAllByDepartment_ID(string department_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationSelectAllByDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
				List<tbl_scsFixedAssetDepreciation> tbl_scsFixedAssetDepreciationList = new List<tbl_scsFixedAssetDepreciation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsFixedAssetDepreciation tbl_scsFixedAssetDepreciation = Maketbl_scsFixedAssetDepreciation(dataReader);
					tbl_scsFixedAssetDepreciationList.Add(tbl_scsFixedAssetDepreciation);
				}
			}
			scon.Close();
			return tbl_scsFixedAssetDepreciationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAssetDepreciation table by a foreign key.
		/// </summary>
		public static List<tbl_scsFixedAssetDepreciation> SelectAllByBarcode_ID(int barcode_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDepreciationSelectAllByBarcode_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
				List<tbl_scsFixedAssetDepreciation> tbl_scsFixedAssetDepreciationList = new List<tbl_scsFixedAssetDepreciation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsFixedAssetDepreciation tbl_scsFixedAssetDepreciation = Maketbl_scsFixedAssetDepreciation(dataReader);
					tbl_scsFixedAssetDepreciationList.Add(tbl_scsFixedAssetDepreciation);
				}
			}
			scon.Close();
			return tbl_scsFixedAssetDepreciationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsFixedAssetDepreciation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsFixedAssetDepreciation Maketbl_scsFixedAssetDepreciation(SqlDataReader dataReader) {
			tbl_scsFixedAssetDepreciation tbl_scsFixedAssetDepreciation = new tbl_scsFixedAssetDepreciation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsFixedAssetDepreciation.FixedAssetDepreciation_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsFixedAssetDepreciation.Barcode_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsFixedAssetDepreciation.FinancialYear_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsFixedAssetDepreciation.Month_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsFixedAssetDepreciation.Department_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsFixedAssetDepreciation.Date_from = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsFixedAssetDepreciation.Date_to = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsFixedAssetDepreciation.OpeningWDN = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsFixedAssetDepreciation.MonthDeprecation = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsFixedAssetDepreciation.ClosingWDN = dataReader.GetDecimal(9);
			}

			return tbl_scsFixedAssetDepreciation;
		}
		/// <summary>
		/// This makes tbl_scsFixedAssetDepreciation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsFixedAssetDepreciation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsFixedAssetDepreciation  tbl_scsFixedAssetDepreciation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_fixedAssetDepreciation_ID = new DataColumn("fixedAssetDepreciation_ID" , typeof(string));
			DataColumn col_barcode_ID = new DataColumn("barcode_ID" , typeof(int));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_Date_from = new DataColumn("Date_from" , typeof(DateTime));
			DataColumn col_Date_to = new DataColumn("Date_to" , typeof(DateTime));
			DataColumn col_openingWDN = new DataColumn("openingWDN" , typeof(decimal));
			DataColumn col_monthDeprecation = new DataColumn("monthDeprecation" , typeof(decimal));
			DataColumn col_closingWDN = new DataColumn("closingWDN" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_fixedAssetDepreciation_ID,col_barcode_ID,col_financialYear_ID,col_month_ID,col_department_ID,col_Date_from,col_Date_to,col_openingWDN,col_monthDeprecation,col_closingWDN,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsFixedAssetDepreciation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsFixedAssetDepreciation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsFixedAssetDepreciation user) {
		DataRow drow = dt.NewRow();
		
			drow["fixedAssetDepreciation_ID"] = user.fixedAssetDepreciation_ID;
			drow["barcode_ID"] = user.barcode_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["month_ID"] = user.month_ID;
			drow["department_ID"] = user.department_ID;
			drow["Date_from"] = user.Date_from;
			drow["Date_to"] = user.Date_to;
			drow["openingWDN"] = user.openingWDN;
			drow["monthDeprecation"] = user.monthDeprecation;
			drow["closingWDN"] = user.closingWDN;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
