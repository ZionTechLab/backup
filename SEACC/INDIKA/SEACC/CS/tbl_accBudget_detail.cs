using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accBudget_detail {
		#region Fields
		private string financialYear_ID;
		private string gl_ID;
		private int revisionCount;
		private decimal value_Jan;
		private decimal value_Feb;
		private decimal value_Mar;
		private decimal value_Apr;
		private decimal value_May;
		private decimal value_Jun;
		private decimal value_Jul;
		private decimal value_Aug;
		private decimal value_Sep;
		private decimal value_Oct;
		private decimal value_Nov;
		private decimal value_Dec;
		private decimal value_Year;
		private decimal value_Quarter_1;
		private decimal value_Quarter_2;
		private decimal value_Quarter_3;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accBudget_detail class.
		/// </summary>
		public tbl_accBudget_detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accBudget_detail class.
		/// </summary>
		public tbl_accBudget_detail(string financialYear_ID, string gl_ID, int revisionCount, decimal value_Jan, decimal value_Feb, decimal value_Mar, decimal value_Apr, decimal value_May, decimal value_Jun, decimal value_Jul, decimal value_Aug, decimal value_Sep, decimal value_Oct, decimal value_Nov, decimal value_Dec, decimal value_Year, decimal value_Quarter_1, decimal value_Quarter_2, decimal value_Quarter_3) {
			this.financialYear_ID = financialYear_ID;
			this.gl_ID = gl_ID;
			this.revisionCount = revisionCount;
			this.value_Jan = value_Jan;
			this.value_Feb = value_Feb;
			this.value_Mar = value_Mar;
			this.value_Apr = value_Apr;
			this.value_May = value_May;
			this.value_Jun = value_Jun;
			this.value_Jul = value_Jul;
			this.value_Aug = value_Aug;
			this.value_Sep = value_Sep;
			this.value_Oct = value_Oct;
			this.value_Nov = value_Nov;
			this.value_Dec = value_Dec;
			this.value_Year = value_Year;
			this.value_Quarter_1 = value_Quarter_1;
			this.value_Quarter_2 = value_Quarter_2;
			this.value_Quarter_3 = value_Quarter_3;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RevisionCount value.
		/// </summary>
		public int RevisionCount {
			get { return revisionCount; }
			set { revisionCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Jan value.
		/// </summary>
		public decimal Value_Jan {
			get { return value_Jan; }
			set { value_Jan = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Feb value.
		/// </summary>
		public decimal Value_Feb {
			get { return value_Feb; }
			set { value_Feb = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Mar value.
		/// </summary>
		public decimal Value_Mar {
			get { return value_Mar; }
			set { value_Mar = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Apr value.
		/// </summary>
		public decimal Value_Apr {
			get { return value_Apr; }
			set { value_Apr = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_May value.
		/// </summary>
		public decimal Value_May {
			get { return value_May; }
			set { value_May = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Jun value.
		/// </summary>
		public decimal Value_Jun {
			get { return value_Jun; }
			set { value_Jun = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Jul value.
		/// </summary>
		public decimal Value_Jul {
			get { return value_Jul; }
			set { value_Jul = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Aug value.
		/// </summary>
		public decimal Value_Aug {
			get { return value_Aug; }
			set { value_Aug = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Sep value.
		/// </summary>
		public decimal Value_Sep {
			get { return value_Sep; }
			set { value_Sep = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Oct value.
		/// </summary>
		public decimal Value_Oct {
			get { return value_Oct; }
			set { value_Oct = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Nov value.
		/// </summary>
		public decimal Value_Nov {
			get { return value_Nov; }
			set { value_Nov = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Dec value.
		/// </summary>
		public decimal Value_Dec {
			get { return value_Dec; }
			set { value_Dec = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Year value.
		/// </summary>
		public decimal Value_Year {
			get { return value_Year; }
			set { value_Year = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Quarter_1 value.
		/// </summary>
		public decimal Value_Quarter_1 {
			get { return value_Quarter_1; }
			set { value_Quarter_1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Quarter_2 value.
		/// </summary>
		public decimal Value_Quarter_2 {
			get { return value_Quarter_2; }
			set { value_Quarter_2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Value_Quarter_3 value.
		/// </summary>
		public decimal Value_Quarter_3 {
			get { return value_Quarter_3; }
			set { value_Quarter_3 = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accBudget_detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@revisionCount", SqlDbType.Int,4);
			scom.Parameters.Add("@value_Jan", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Feb", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Mar", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Apr", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_May", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Jun", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Jul", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Aug", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Sep", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Oct", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Nov", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Dec", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Year", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Quarter_1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Quarter_2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Quarter_3", SqlDbType.Decimal,9);
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@revisionCount"].Value = revisionCount;
			scom.Parameters["@value_Jan"].Value = value_Jan;
			scom.Parameters["@value_Feb"].Value = value_Feb;
			scom.Parameters["@value_Mar"].Value = value_Mar;
			scom.Parameters["@value_Apr"].Value = value_Apr;
			scom.Parameters["@value_May"].Value = value_May;
			scom.Parameters["@value_Jun"].Value = value_Jun;
			scom.Parameters["@value_Jul"].Value = value_Jul;
			scom.Parameters["@value_Aug"].Value = value_Aug;
			scom.Parameters["@value_Sep"].Value = value_Sep;
			scom.Parameters["@value_Oct"].Value = value_Oct;
			scom.Parameters["@value_Nov"].Value = value_Nov;
			scom.Parameters["@value_Dec"].Value = value_Dec;
			scom.Parameters["@value_Year"].Value = value_Year;
			scom.Parameters["@value_Quarter_1"].Value = value_Quarter_1;
			scom.Parameters["@value_Quarter_2"].Value = value_Quarter_2;
			scom.Parameters["@value_Quarter_3"].Value = value_Quarter_3;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accBudget_detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@revisionCount", SqlDbType.Int,4);
			scom.Parameters.Add("@value_Jan", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Feb", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Mar", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Apr", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_May", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Jun", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Jul", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Aug", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Sep", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Oct", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Nov", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Dec", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Year", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Quarter_1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Quarter_2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@value_Quarter_3", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@revisionCount"].Value = revisionCount;
			scom.Parameters["@value_Jan"].Value = value_Jan;
			scom.Parameters["@value_Feb"].Value = value_Feb;
			scom.Parameters["@value_Mar"].Value = value_Mar;
			scom.Parameters["@value_Apr"].Value = value_Apr;
			scom.Parameters["@value_May"].Value = value_May;
			scom.Parameters["@value_Jun"].Value = value_Jun;
			scom.Parameters["@value_Jul"].Value = value_Jul;
			scom.Parameters["@value_Aug"].Value = value_Aug;
			scom.Parameters["@value_Sep"].Value = value_Sep;
			scom.Parameters["@value_Oct"].Value = value_Oct;
			scom.Parameters["@value_Nov"].Value = value_Nov;
			scom.Parameters["@value_Dec"].Value = value_Dec;
			scom.Parameters["@value_Year"].Value = value_Year;
			scom.Parameters["@value_Quarter_1"].Value = value_Quarter_1;
			scom.Parameters["@value_Quarter_2"].Value = value_Quarter_2;
			scom.Parameters["@value_Quarter_3"].Value = value_Quarter_3;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accBudget_detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accBudget_detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accBudget_detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailDeleteAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accBudget_detail table.
		/// </summary>
		public static tbl_accBudget_detail Select(string financialYear_ID_Incoming, string gl_ID_Incoming){

			tbl_accBudget_detail tbl_accBudget_detailins = new tbl_accBudget_detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID_Incoming;
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accBudget_detailins = Maketbl_accBudget_detail(dataReader);
				} else {
					tbl_accBudget_detailins = null;
				}
			}
			scon.Close();
			return tbl_accBudget_detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accBudget_detail table.
		/// </summary>
		public static List<tbl_accBudget_detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accBudget_detail> tbl_accBudget_detailList = new List<tbl_accBudget_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accBudget_detail tbl_accBudget_detail = Maketbl_accBudget_detail(dataReader);
					tbl_accBudget_detailList.Add(tbl_accBudget_detail);
				}
			}
			scon.Close();
			return tbl_accBudget_detailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accBudget_detail table by a foreign key.
		/// </summary>
		public static List<tbl_accBudget_detail> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accBudget_detail> tbl_accBudget_detailList = new List<tbl_accBudget_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accBudget_detail tbl_accBudget_detail = Maketbl_accBudget_detail(dataReader);
					tbl_accBudget_detailList.Add(tbl_accBudget_detail);
				}
			}
			scon.Close();
			return tbl_accBudget_detailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accBudget_detail table by a foreign key.
		/// </summary>
		public static List<tbl_accBudget_detail> SelectAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accBudget_detailSelectAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
				List<tbl_accBudget_detail> tbl_accBudget_detailList = new List<tbl_accBudget_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accBudget_detail tbl_accBudget_detail = Maketbl_accBudget_detail(dataReader);
					tbl_accBudget_detailList.Add(tbl_accBudget_detail);
				}
			}
			scon.Close();
			return tbl_accBudget_detailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accBudget_detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accBudget_detail Maketbl_accBudget_detail(SqlDataReader dataReader) {
			tbl_accBudget_detail tbl_accBudget_detail = new tbl_accBudget_detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accBudget_detail.FinancialYear_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accBudget_detail.Gl_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accBudget_detail.RevisionCount = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accBudget_detail.Value_Jan = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accBudget_detail.Value_Feb = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accBudget_detail.Value_Mar = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accBudget_detail.Value_Apr = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accBudget_detail.Value_May = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accBudget_detail.Value_Jun = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accBudget_detail.Value_Jul = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accBudget_detail.Value_Aug = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accBudget_detail.Value_Sep = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accBudget_detail.Value_Oct = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accBudget_detail.Value_Nov = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accBudget_detail.Value_Dec = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accBudget_detail.Value_Year = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accBudget_detail.Value_Quarter_1 = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accBudget_detail.Value_Quarter_2 = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accBudget_detail.Value_Quarter_3 = dataReader.GetDecimal(18);
			}

			return tbl_accBudget_detail;
		}
		/// <summary>
		/// This makes tbl_accBudget_detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accBudget_detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accBudget_detail  tbl_accBudget_detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_revisionCount = new DataColumn("revisionCount" , typeof(int));
			DataColumn col_value_Jan = new DataColumn("value_Jan" , typeof(decimal));
			DataColumn col_value_Feb = new DataColumn("value_Feb" , typeof(decimal));
			DataColumn col_value_Mar = new DataColumn("value_Mar" , typeof(decimal));
			DataColumn col_value_Apr = new DataColumn("value_Apr" , typeof(decimal));
			DataColumn col_value_May = new DataColumn("value_May" , typeof(decimal));
			DataColumn col_value_Jun = new DataColumn("value_Jun" , typeof(decimal));
			DataColumn col_value_Jul = new DataColumn("value_Jul" , typeof(decimal));
			DataColumn col_value_Aug = new DataColumn("value_Aug" , typeof(decimal));
			DataColumn col_value_Sep = new DataColumn("value_Sep" , typeof(decimal));
			DataColumn col_value_Oct = new DataColumn("value_Oct" , typeof(decimal));
			DataColumn col_value_Nov = new DataColumn("value_Nov" , typeof(decimal));
			DataColumn col_value_Dec = new DataColumn("value_Dec" , typeof(decimal));
			DataColumn col_value_Year = new DataColumn("value_Year" , typeof(decimal));
			DataColumn col_value_Quarter_1 = new DataColumn("value_Quarter_1" , typeof(decimal));
			DataColumn col_value_Quarter_2 = new DataColumn("value_Quarter_2" , typeof(decimal));
			DataColumn col_value_Quarter_3 = new DataColumn("value_Quarter_3" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_financialYear_ID,col_gl_ID,col_revisionCount,col_value_Jan,col_value_Feb,col_value_Mar,col_value_Apr,col_value_May,col_value_Jun,col_value_Jul,col_value_Aug,col_value_Sep,col_value_Oct,col_value_Nov,col_value_Dec,col_value_Year,col_value_Quarter_1,col_value_Quarter_2,col_value_Quarter_3,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accBudget_detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accBudget_detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accBudget_detail user) {
		DataRow drow = dt.NewRow();
		
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["revisionCount"] = user.revisionCount;
			drow["value_Jan"] = user.value_Jan;
			drow["value_Feb"] = user.value_Feb;
			drow["value_Mar"] = user.value_Mar;
			drow["value_Apr"] = user.value_Apr;
			drow["value_May"] = user.value_May;
			drow["value_Jun"] = user.value_Jun;
			drow["value_Jul"] = user.value_Jul;
			drow["value_Aug"] = user.value_Aug;
			drow["value_Sep"] = user.value_Sep;
			drow["value_Oct"] = user.value_Oct;
			drow["value_Nov"] = user.value_Nov;
			drow["value_Dec"] = user.value_Dec;
			drow["value_Year"] = user.value_Year;
			drow["value_Quarter_1"] = user.value_Quarter_1;
			drow["value_Quarter_2"] = user.value_Quarter_2;
			drow["value_Quarter_3"] = user.value_Quarter_3;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
