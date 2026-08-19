using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsMatfor_Entry_Detail {
		#region Fields
		private int line_No;
		private string employee_ID;
		private string mrp_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string customer_ID;
		private decimal qty;
		private decimal weight;
		private string brandName;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsMatfor_Entry_Detail class.
		/// </summary>
		public tbl_scsMatfor_Entry_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsMatfor_Entry_Detail class.
		/// </summary>
		public tbl_scsMatfor_Entry_Detail(int line_No, string employee_ID, string mrp_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string customer_ID, decimal qty, decimal weight, string brandName, string remark) {
			this.line_No = line_No;
			this.employee_ID = employee_ID;
			this.mrp_ID = mrp_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.customer_ID = customer_ID;
			this.qty = qty;
			this.weight = weight;
			this.brandName = brandName;
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mrp_ID value.
		/// </summary>
		public string Mrp_ID {
			get { return mrp_ID; }
			set { mrp_ID = value; }
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
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID {
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo2 value.
		/// </summary>
		public string ItemSerialNo2 {
			get { return itemSerialNo2; }
			set { itemSerialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
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
		/// Gets or sets the BrandName value.
		/// </summary>
		public string BrandName {
			get { return brandName; }
			set { brandName = value; }
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
		/// Saves a record to the tbl_scsMatfor_Entry_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@brandName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@brandName"].Value = brandName;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsMatfor_Entry_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@brandName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@brandName"].Value = brandName;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsMatfor_Entry_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMrp_ID_Employee_ID(string mrp_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailDeleteAllByMrp_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMrp_ID(string mrp_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailDeleteAllByMrp_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsMatfor_Entry_Detail table.
		/// </summary>
		public static tbl_scsMatfor_Entry_Detail Select(int line_No_Incoming, string employee_ID_Incoming, string mrp_ID_Incoming){

			tbl_scsMatfor_Entry_Detail tbl_scsMatfor_Entry_Detailins = new tbl_scsMatfor_Entry_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			scom.Parameters["@mrp_ID"].Value = mrp_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detailins = Maketbl_scsMatfor_Entry_Detail(dataReader);
				} else {
					tbl_scsMatfor_Entry_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail table.
		/// </summary>
		public static List<tbl_scsMatfor_Entry_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsMatfor_Entry_Detail> tbl_scsMatfor_Entry_DetailList = new List<tbl_scsMatfor_Entry_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail tbl_scsMatfor_Entry_Detail = Maketbl_scsMatfor_Entry_Detail(dataReader);
					tbl_scsMatfor_Entry_DetailList.Add(tbl_scsMatfor_Entry_Detail);
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsMatfor_Entry_Detail> SelectAllByMrp_ID_Employee_ID(string mrp_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailSelectAllByMrp_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_scsMatfor_Entry_Detail> tbl_scsMatfor_Entry_DetailList = new List<tbl_scsMatfor_Entry_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail tbl_scsMatfor_Entry_Detail = Maketbl_scsMatfor_Entry_Detail(dataReader);
					tbl_scsMatfor_Entry_DetailList.Add(tbl_scsMatfor_Entry_Detail);
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsMatfor_Entry_Detail> SelectAllByMrp_ID(string mrp_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_DetailSelectAllByMrp_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
				List<tbl_scsMatfor_Entry_Detail> tbl_scsMatfor_Entry_DetailList = new List<tbl_scsMatfor_Entry_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail tbl_scsMatfor_Entry_Detail = Maketbl_scsMatfor_Entry_Detail(dataReader);
					tbl_scsMatfor_Entry_DetailList.Add(tbl_scsMatfor_Entry_Detail);
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsMatfor_Entry_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsMatfor_Entry_Detail Maketbl_scsMatfor_Entry_Detail(SqlDataReader dataReader) {
			tbl_scsMatfor_Entry_Detail tbl_scsMatfor_Entry_Detail = new tbl_scsMatfor_Entry_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsMatfor_Entry_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsMatfor_Entry_Detail.Employee_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsMatfor_Entry_Detail.Mrp_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsMatfor_Entry_Detail.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsMatfor_Entry_Detail.ItemSubCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsMatfor_Entry_Detail.ItemSubCategory2_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsMatfor_Entry_Detail.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsMatfor_Entry_Detail.ItemSerialNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsMatfor_Entry_Detail.Customer_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsMatfor_Entry_Detail.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsMatfor_Entry_Detail.Weight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsMatfor_Entry_Detail.BrandName = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsMatfor_Entry_Detail.Remark = dataReader.GetString(12);
			}

			return tbl_scsMatfor_Entry_Detail;
		}
		/// <summary>
		/// This makes tbl_scsMatfor_Entry_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsMatfor_Entry_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsMatfor_Entry_Detail  tbl_scsMatfor_Entry_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_mrp_ID = new DataColumn("mrp_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_brandName = new DataColumn("brandName" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_employee_ID,col_mrp_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_customer_ID,col_qty,col_weight,col_brandName,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsMatfor_Entry_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsMatfor_Entry_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsMatfor_Entry_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["employee_ID"] = user.employee_ID;
			drow["mrp_ID"] = user.mrp_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["customer_ID"] = user.customer_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["brandName"] = user.brandName;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
