using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genDepartment_Stock {
		#region Fields
		private string department_ID;
		private string item_ID;
		private string job_ID;
		private decimal qty;
		private decimal weight;
		private decimal meter;
		private decimal wasteageWeight;
		private decimal damageWeight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genDepartment_Stock class.
		/// </summary>
		public tbl_genDepartment_Stock() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genDepartment_Stock class.
		/// </summary>
		public tbl_genDepartment_Stock(string department_ID, string item_ID, string job_ID, decimal qty, decimal weight, decimal meter, decimal wasteageWeight, decimal damageWeight) {
			this.department_ID = department_ID;
			this.item_ID = item_ID;
			this.job_ID = job_ID;
			this.qty = qty;
			this.weight = weight;
			this.meter = meter;
			this.wasteageWeight = wasteageWeight;
			this.damageWeight = damageWeight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Meter value.
		/// </summary>
		public decimal Meter {
			get { return meter; }
			set { meter = value; }
		}
		
		/// <summary>
		/// Gets or sets the WasteageWeight value.
		/// </summary>
		public decimal WasteageWeight {
			get { return wasteageWeight; }
			set { wasteageWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the DamageWeight value.
		/// </summary>
		public decimal DamageWeight {
			get { return damageWeight; }
			set { damageWeight = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genDepartment_Stock table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wasteageWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damageWeight", SqlDbType.Decimal,9);
 
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@meter"].Value = meter;
			scom.Parameters["@wasteageWeight"].Value = wasteageWeight;
			scom.Parameters["@damageWeight"].Value = damageWeight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genDepartment_Stock table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wasteageWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damageWeight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@meter"].Value = meter;
			scom.Parameters["@wasteageWeight"].Value = wasteageWeight;
			scom.Parameters["@damageWeight"].Value = damageWeight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genDepartment_Stock table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@job_ID"].Value = job_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartment_Stock table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartment_Stock table by a foreign key.
		/// </summary>
		public static void DeleteAllByDepartment_ID(string department_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockDeleteAllByDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartment_Stock table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genDepartment_Stock table.
		/// </summary>
		public static tbl_genDepartment_Stock Select(string department_ID_Incoming, string item_ID_Incoming, string job_ID_Incoming){

			tbl_genDepartment_Stock tbl_genDepartment_Stockins = new tbl_genDepartment_Stock();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@job_ID"].Value = job_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genDepartment_Stockins = Maketbl_genDepartment_Stock(dataReader);
				} else {
					tbl_genDepartment_Stockins = null;
				}
			}
			scon.Close();
			return tbl_genDepartment_Stockins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartment_Stock table.
		/// </summary>
		public static List<tbl_genDepartment_Stock> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genDepartment_Stock> tbl_genDepartment_StockList = new List<tbl_genDepartment_Stock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDepartment_Stock tbl_genDepartment_Stock = Maketbl_genDepartment_Stock(dataReader);
					tbl_genDepartment_StockList.Add(tbl_genDepartment_Stock);
				}
			}
			scon.Close();
			return tbl_genDepartment_StockList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartment_Stock table by a foreign key.
		/// </summary>
		public static List<tbl_genDepartment_Stock> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_genDepartment_Stock> tbl_genDepartment_StockList = new List<tbl_genDepartment_Stock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDepartment_Stock tbl_genDepartment_Stock = Maketbl_genDepartment_Stock(dataReader);
					tbl_genDepartment_StockList.Add(tbl_genDepartment_Stock);
				}
			}
			scon.Close();
			return tbl_genDepartment_StockList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartment_Stock table by a foreign key.
		/// </summary>
		public static List<tbl_genDepartment_Stock> SelectAllByDepartment_ID(string department_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockSelectAllByDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
				List<tbl_genDepartment_Stock> tbl_genDepartment_StockList = new List<tbl_genDepartment_Stock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDepartment_Stock tbl_genDepartment_Stock = Maketbl_genDepartment_Stock(dataReader);
					tbl_genDepartment_StockList.Add(tbl_genDepartment_Stock);
				}
			}
			scon.Close();
			return tbl_genDepartment_StockList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartment_Stock table by a foreign key.
		/// </summary>
		public static List<tbl_genDepartment_Stock> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartment_StockSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genDepartment_Stock> tbl_genDepartment_StockList = new List<tbl_genDepartment_Stock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDepartment_Stock tbl_genDepartment_Stock = Maketbl_genDepartment_Stock(dataReader);
					tbl_genDepartment_StockList.Add(tbl_genDepartment_Stock);
				}
			}
			scon.Close();
			return tbl_genDepartment_StockList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genDepartment_Stock class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genDepartment_Stock Maketbl_genDepartment_Stock(SqlDataReader dataReader) {
			tbl_genDepartment_Stock tbl_genDepartment_Stock = new tbl_genDepartment_Stock();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genDepartment_Stock.Department_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genDepartment_Stock.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genDepartment_Stock.Job_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genDepartment_Stock.Qty = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genDepartment_Stock.Weight = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genDepartment_Stock.Meter = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genDepartment_Stock.WasteageWeight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genDepartment_Stock.DamageWeight = dataReader.GetDecimal(7);
			}

			return tbl_genDepartment_Stock;
		}
		/// <summary>
		/// This makes tbl_genDepartment_Stock datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genDepartment_Stock object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genDepartment_Stock  tbl_genDepartment_Stock   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_meter = new DataColumn("meter" , typeof(decimal));
			DataColumn col_wasteageWeight = new DataColumn("wasteageWeight" , typeof(decimal));
			DataColumn col_damageWeight = new DataColumn("damageWeight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_department_ID,col_item_ID,col_job_ID,col_qty,col_weight,col_meter,col_wasteageWeight,col_damageWeight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genDepartment_Stock datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genDepartment_Stock object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genDepartment_Stock user) {
		DataRow drow = dt.NewRow();
		
			drow["department_ID"] = user.department_ID;
			drow["item_ID"] = user.item_ID;
			drow["job_ID"] = user.job_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["meter"] = user.meter;
			drow["wasteageWeight"] = user.wasteageWeight;
			drow["damageWeight"] = user.damageWeight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
