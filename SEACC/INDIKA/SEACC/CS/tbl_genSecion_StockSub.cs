using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genSecion_StockSub {
		#region Fields
		private string section_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSerialNo;
		private string job_ID;
		private decimal qty;
		private decimal weight;
		private decimal meter;
		private decimal wasteageWeight;
		private decimal damageWeight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genSecion_StockSub class.
		/// </summary>
		public tbl_genSecion_StockSub() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genSecion_StockSub class.
		/// </summary>
		public tbl_genSecion_StockSub(string section_ID, string item_ID, string itemSubCategory_ID, string itemSerialNo, string job_ID, decimal qty, decimal weight, decimal meter, decimal wasteageWeight, decimal damageWeight) {
			this.section_ID = section_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSerialNo = itemSerialNo;
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
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
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
		/// Saves a record to the tbl_genSecion_StockSub table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wasteageWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damageWeight", SqlDbType.Decimal,9);
 
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
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
		/// Updates a record in the tbl_genSecion_StockSub table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wasteageWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damageWeight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
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
		/// Deletes a record from the tbl_genSecion_StockSub table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@job_ID"].Value = job_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_ItemSubCategory_ID_ItemSerialNo(string item_ID, string itemSubCategory_ID, string itemSerialNo) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubDeleteAllByItem_ID_ItemSubCategory_ID_ItemSerialNo", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genSecion_StockSub table.
		/// </summary>
		public static tbl_genSecion_StockSub Select(string section_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSerialNo_Incoming, string job_ID_Incoming){

			tbl_genSecion_StockSub tbl_genSecion_StockSubins = new tbl_genSecion_StockSub();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@job_ID"].Value = job_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genSecion_StockSubins = Maketbl_genSecion_StockSub(dataReader);
				} else {
					tbl_genSecion_StockSubins = null;
				}
			}
			scon.Close();
			return tbl_genSecion_StockSubins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table.
		/// </summary>
		public static List<tbl_genSecion_StockSub> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genSecion_StockSub> tbl_genSecion_StockSubList = new List<tbl_genSecion_StockSub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSecion_StockSub tbl_genSecion_StockSub = Maketbl_genSecion_StockSub(dataReader);
					tbl_genSecion_StockSubList.Add(tbl_genSecion_StockSub);
				}
			}
			scon.Close();
			return tbl_genSecion_StockSubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static List<tbl_genSecion_StockSub> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genSecion_StockSub> tbl_genSecion_StockSubList = new List<tbl_genSecion_StockSub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSecion_StockSub tbl_genSecion_StockSub = Maketbl_genSecion_StockSub(dataReader);
					tbl_genSecion_StockSubList.Add(tbl_genSecion_StockSub);
				}
			}
			scon.Close();
			return tbl_genSecion_StockSubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static List<tbl_genSecion_StockSub> SelectAllByItem_ID_ItemSubCategory_ID_ItemSerialNo(string item_ID, string itemSubCategory_ID, string itemSerialNo) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubSelectAllByItem_ID_ItemSubCategory_ID_ItemSerialNo", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
				List<tbl_genSecion_StockSub> tbl_genSecion_StockSubList = new List<tbl_genSecion_StockSub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSecion_StockSub tbl_genSecion_StockSub = Maketbl_genSecion_StockSub(dataReader);
					tbl_genSecion_StockSubList.Add(tbl_genSecion_StockSub);
				}
			}
			scon.Close();
			return tbl_genSecion_StockSubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static List<tbl_genSecion_StockSub> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_genSecion_StockSub> tbl_genSecion_StockSubList = new List<tbl_genSecion_StockSub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSecion_StockSub tbl_genSecion_StockSub = Maketbl_genSecion_StockSub(dataReader);
					tbl_genSecion_StockSubList.Add(tbl_genSecion_StockSub);
				}
			}
			scon.Close();
			return tbl_genSecion_StockSubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static List<tbl_genSecion_StockSub> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubSelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_genSecion_StockSub> tbl_genSecion_StockSubList = new List<tbl_genSecion_StockSub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSecion_StockSub tbl_genSecion_StockSub = Maketbl_genSecion_StockSub(dataReader);
					tbl_genSecion_StockSubList.Add(tbl_genSecion_StockSub);
				}
			}
			scon.Close();
			return tbl_genSecion_StockSubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSecion_StockSub table by a foreign key.
		/// </summary>
		public static List<tbl_genSecion_StockSub> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSecion_StockSubSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_genSecion_StockSub> tbl_genSecion_StockSubList = new List<tbl_genSecion_StockSub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSecion_StockSub tbl_genSecion_StockSub = Maketbl_genSecion_StockSub(dataReader);
					tbl_genSecion_StockSubList.Add(tbl_genSecion_StockSub);
				}
			}
			scon.Close();
			return tbl_genSecion_StockSubList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genSecion_StockSub class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genSecion_StockSub Maketbl_genSecion_StockSub(SqlDataReader dataReader) {
			tbl_genSecion_StockSub tbl_genSecion_StockSub = new tbl_genSecion_StockSub();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genSecion_StockSub.Section_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genSecion_StockSub.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genSecion_StockSub.ItemSubCategory_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genSecion_StockSub.ItemSerialNo = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genSecion_StockSub.Job_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genSecion_StockSub.Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genSecion_StockSub.Weight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genSecion_StockSub.Meter = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genSecion_StockSub.WasteageWeight = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genSecion_StockSub.DamageWeight = dataReader.GetDecimal(9);
			}

			return tbl_genSecion_StockSub;
		}
		/// <summary>
		/// This makes tbl_genSecion_StockSub datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genSecion_StockSub object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genSecion_StockSub  tbl_genSecion_StockSub   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_meter = new DataColumn("meter" , typeof(decimal));
			DataColumn col_wasteageWeight = new DataColumn("wasteageWeight" , typeof(decimal));
			DataColumn col_damageWeight = new DataColumn("damageWeight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_section_ID,col_item_ID,col_itemSubCategory_ID,col_itemSerialNo,col_job_ID,col_qty,col_weight,col_meter,col_wasteageWeight,col_damageWeight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genSecion_StockSub datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genSecion_StockSub object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genSecion_StockSub user) {
		DataRow drow = dt.NewRow();
		
			drow["section_ID"] = user.section_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
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
