using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsMatfor_Entry_Detail_RwMaterial {
		#region Fields
		private Int64 rwLine_No;
		private int line_No;
		private string employee_ID;
		private string mrp_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string rw_item_ID;
		private string rw_itemSubCategory_ID;
		private string rw_itemSubCategory2_ID;
		private string rw_itemSerialNo;
		private string rw_itemSerialNo2;
		private string customer_ID;
		private decimal qty;
		private decimal weight;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsMatfor_Entry_Detail_RwMaterial class.
		/// </summary>
		public tbl_scsMatfor_Entry_Detail_RwMaterial() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsMatfor_Entry_Detail_RwMaterial class.
		/// </summary>
		public tbl_scsMatfor_Entry_Detail_RwMaterial(int line_No, string employee_ID, string mrp_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string rw_item_ID, string rw_itemSubCategory_ID, string rw_itemSubCategory2_ID, string rw_itemSerialNo, string rw_itemSerialNo2, string customer_ID, decimal qty, decimal weight, string remark) {
			this.line_No = line_No;
			this.employee_ID = employee_ID;
			this.mrp_ID = mrp_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.rw_item_ID = rw_item_ID;
			this.rw_itemSubCategory_ID = rw_itemSubCategory_ID;
			this.rw_itemSubCategory2_ID = rw_itemSubCategory2_ID;
			this.rw_itemSerialNo = rw_itemSerialNo;
			this.rw_itemSerialNo2 = rw_itemSerialNo2;
			this.customer_ID = customer_ID;
			this.qty = qty;
			this.weight = weight;
			this.remark = remark;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsMatfor_Entry_Detail_RwMaterial class.
		/// </summary>
		public tbl_scsMatfor_Entry_Detail_RwMaterial(Int64 rwLine_No, int line_No, string employee_ID, string mrp_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string rw_item_ID, string rw_itemSubCategory_ID, string rw_itemSubCategory2_ID, string rw_itemSerialNo, string rw_itemSerialNo2, string customer_ID, decimal qty, decimal weight, string remark) {
			this.rwLine_No = rwLine_No;
			this.line_No = line_No;
			this.employee_ID = employee_ID;
			this.mrp_ID = mrp_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.rw_item_ID = rw_item_ID;
			this.rw_itemSubCategory_ID = rw_itemSubCategory_ID;
			this.rw_itemSubCategory2_ID = rw_itemSubCategory2_ID;
			this.rw_itemSerialNo = rw_itemSerialNo;
			this.rw_itemSerialNo2 = rw_itemSerialNo2;
			this.customer_ID = customer_ID;
			this.qty = qty;
			this.weight = weight;
			this.remark = remark;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the RwLine_No value.
		/// </summary>
		public Int64 RwLine_No {
			get { return rwLine_No; }
			set { rwLine_No = value; }
		}
		
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
		/// Gets or sets the Rw_item_ID value.
		/// </summary>
		public string Rw_item_ID {
			get { return rw_item_ID; }
			set { rw_item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rw_itemSubCategory_ID value.
		/// </summary>
		public string Rw_itemSubCategory_ID {
			get { return rw_itemSubCategory_ID; }
			set { rw_itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rw_itemSubCategory2_ID value.
		/// </summary>
		public string Rw_itemSubCategory2_ID {
			get { return rw_itemSubCategory2_ID; }
			set { rw_itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rw_itemSerialNo value.
		/// </summary>
		public string Rw_itemSerialNo {
			get { return rw_itemSerialNo; }
			set { rw_itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rw_itemSerialNo2 value.
		/// </summary>
		public string Rw_itemSerialNo2 {
			get { return rw_itemSerialNo2; }
			set { rw_itemSerialNo2 = value; }
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
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsMatfor_Entry_Detail_RwMaterial table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@rw_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rw_itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@rw_itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@rw_itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@rw_itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@rw_item_ID"].Value = rw_item_ID;
			scom.Parameters["@rw_itemSubCategory_ID"].Value = rw_itemSubCategory_ID;
			scom.Parameters["@rw_itemSubCategory2_ID"].Value = rw_itemSubCategory2_ID;
			scom.Parameters["@rw_itemSerialNo"].Value = rw_itemSerialNo;
			scom.Parameters["@rw_itemSerialNo2"].Value = rw_itemSerialNo2;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsMatfor_Entry_Detail_RwMaterial table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@rw_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rw_itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@rw_itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@rw_itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@rw_itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@rw_item_ID"].Value = rw_item_ID;
			scom.Parameters["@rw_itemSubCategory_ID"].Value = rw_itemSubCategory_ID;
			scom.Parameters["@rw_itemSubCategory2_ID"].Value = rw_itemSubCategory2_ID;
			scom.Parameters["@rw_itemSerialNo"].Value = rw_itemSerialNo;
			scom.Parameters["@rw_itemSerialNo2"].Value = rw_itemSerialNo2;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsMatfor_Entry_Detail_RwMaterial table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@rwLine_No", SqlDbType.BigInt,8);
			scom.Parameters["@rwLine_No"].Value = rwLine_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table by a foreign key.
		/// </summary>
		public static void DeleteAllByMrp_ID(string mrp_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialDeleteAllByMrp_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table by a foreign key.
		/// </summary>
		public static void DeleteAllByMrp_ID_Rw_item_ID_Rw_itemSubCategory_ID_Rw_itemSubCategory2_ID_Rw_itemSerialNo_ItemSerialNo2(string mrp_ID, string rw_item_ID, string rw_itemSubCategory_ID, string rw_itemSubCategory2_ID, string rw_itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialDeleteAllByMrp_ID_Rw_item_ID_Rw_itemSubCategory_ID_Rw_itemSubCategory2_ID_Rw_itemSerialNo_ItemSerialNo2", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rw_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rw_itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@rw_itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@rw_itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@rw_item_ID"].Value = rw_item_ID;
			scom.Parameters["@rw_itemSubCategory_ID"].Value = rw_itemSubCategory_ID;
			scom.Parameters["@rw_itemSubCategory2_ID"].Value = rw_itemSubCategory2_ID;
			scom.Parameters["@rw_itemSerialNo"].Value = rw_itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_Employee_ID_Mrp_ID(int line_No, string employee_ID, string mrp_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialDeleteAllByLine_No_Employee_ID_Mrp_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
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
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table by a foreign key.
		/// </summary>
		public static void DeleteAllByMrp_ID_Employee_ID(string mrp_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialDeleteAllByMrp_ID_Employee_ID", scon);
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
		/// Selects a single record from the tbl_scsMatfor_Entry_Detail_RwMaterial table.
		/// </summary>
		public static tbl_scsMatfor_Entry_Detail_RwMaterial Select(Int64 rwLine_No_Incoming){

			tbl_scsMatfor_Entry_Detail_RwMaterial tbl_scsMatfor_Entry_Detail_RwMaterialins = new tbl_scsMatfor_Entry_Detail_RwMaterial();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@rwLine_No", SqlDbType.BigInt,8);
			scom.Parameters["@rwLine_No"].Value = rwLine_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail_RwMaterialins = Maketbl_scsMatfor_Entry_Detail_RwMaterial(dataReader);
				} else {
					tbl_scsMatfor_Entry_Detail_RwMaterialins = null;
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_Detail_RwMaterialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table.
		/// </summary>
		public static List<tbl_scsMatfor_Entry_Detail_RwMaterial> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsMatfor_Entry_Detail_RwMaterial> tbl_scsMatfor_Entry_Detail_RwMaterialList = new List<tbl_scsMatfor_Entry_Detail_RwMaterial>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail_RwMaterial tbl_scsMatfor_Entry_Detail_RwMaterial = Maketbl_scsMatfor_Entry_Detail_RwMaterial(dataReader);
					tbl_scsMatfor_Entry_Detail_RwMaterialList.Add(tbl_scsMatfor_Entry_Detail_RwMaterial);
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_Detail_RwMaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table by a foreign key.
		/// </summary>
		public static List<tbl_scsMatfor_Entry_Detail_RwMaterial> SelectAllByMrp_ID(string mrp_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialSelectAllByMrp_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
				List<tbl_scsMatfor_Entry_Detail_RwMaterial> tbl_scsMatfor_Entry_Detail_RwMaterialList = new List<tbl_scsMatfor_Entry_Detail_RwMaterial>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail_RwMaterial tbl_scsMatfor_Entry_Detail_RwMaterial = Maketbl_scsMatfor_Entry_Detail_RwMaterial(dataReader);
					tbl_scsMatfor_Entry_Detail_RwMaterialList.Add(tbl_scsMatfor_Entry_Detail_RwMaterial);
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_Detail_RwMaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table by a foreign key.
		/// </summary>
		public static List<tbl_scsMatfor_Entry_Detail_RwMaterial> SelectAllByMrp_ID_itemID_itemSubCategoryID_itemSubCategory2ID_itemSerialNo_ItemSerialNo2(string mrp_ID, string rw_item_ID, string rw_itemSubCategory_ID, string rw_itemSubCategory2_ID, string rw_itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("sp_MRP_RM_SelectAllByMrp_ID_Rw_item_ID_Rw_itemSubCategory_ID_Rw_itemSubCategory2_ID_Rw_itemSerialNo_ItemSerialNo2", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rw_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rw_itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@rw_itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@rw_itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@rw_item_ID"].Value = rw_item_ID;
			scom.Parameters["@rw_itemSubCategory_ID"].Value = rw_itemSubCategory_ID;
			scom.Parameters["@rw_itemSubCategory2_ID"].Value = rw_itemSubCategory2_ID;
			scom.Parameters["@rw_itemSerialNo"].Value = rw_itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
				List<tbl_scsMatfor_Entry_Detail_RwMaterial> tbl_scsMatfor_Entry_Detail_RwMaterialList = new List<tbl_scsMatfor_Entry_Detail_RwMaterial>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail_RwMaterial tbl_scsMatfor_Entry_Detail_RwMaterial = Maketbl_scsMatfor_Entry_Detail_RwMaterial(dataReader);
					tbl_scsMatfor_Entry_Detail_RwMaterialList.Add(tbl_scsMatfor_Entry_Detail_RwMaterial);
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_Detail_RwMaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table by a foreign key.
		/// </summary>
		public static List<tbl_scsMatfor_Entry_Detail_RwMaterial> SelectAllByLine_No_Employee_ID_Mrp_ID(int line_No, string employee_ID, string mrp_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialSelectAllByLine_No_Employee_ID_Mrp_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
				List<tbl_scsMatfor_Entry_Detail_RwMaterial> tbl_scsMatfor_Entry_Detail_RwMaterialList = new List<tbl_scsMatfor_Entry_Detail_RwMaterial>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail_RwMaterial tbl_scsMatfor_Entry_Detail_RwMaterial = Maketbl_scsMatfor_Entry_Detail_RwMaterial(dataReader);
					tbl_scsMatfor_Entry_Detail_RwMaterialList.Add(tbl_scsMatfor_Entry_Detail_RwMaterial);
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_Detail_RwMaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsMatfor_Entry_Detail_RwMaterial table by a foreign key.
		/// </summary>
		public static List<tbl_scsMatfor_Entry_Detail_RwMaterial> SelectAllByMrp_ID_Employee_ID(string mrp_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsMatfor_Entry_Detail_RwMaterialSelectAllByMrp_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mrp_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mrp_ID"].Value = mrp_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_scsMatfor_Entry_Detail_RwMaterial> tbl_scsMatfor_Entry_Detail_RwMaterialList = new List<tbl_scsMatfor_Entry_Detail_RwMaterial>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsMatfor_Entry_Detail_RwMaterial tbl_scsMatfor_Entry_Detail_RwMaterial = Maketbl_scsMatfor_Entry_Detail_RwMaterial(dataReader);
					tbl_scsMatfor_Entry_Detail_RwMaterialList.Add(tbl_scsMatfor_Entry_Detail_RwMaterial);
				}
			}
			scon.Close();
			return tbl_scsMatfor_Entry_Detail_RwMaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsMatfor_Entry_Detail_RwMaterial class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsMatfor_Entry_Detail_RwMaterial Maketbl_scsMatfor_Entry_Detail_RwMaterial(SqlDataReader dataReader) {
			tbl_scsMatfor_Entry_Detail_RwMaterial tbl_scsMatfor_Entry_Detail_RwMaterial = new tbl_scsMatfor_Entry_Detail_RwMaterial();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.RwLine_No = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Employee_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Mrp_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.ItemSubCategory_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.ItemSubCategory2_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.ItemSerialNo = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.ItemSerialNo2 = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Rw_item_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Rw_itemSubCategory_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Rw_itemSubCategory2_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Rw_itemSerialNo = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Rw_itemSerialNo2 = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Customer_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Qty = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Weight = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsMatfor_Entry_Detail_RwMaterial.Remark = dataReader.GetString(17);
			}

			return tbl_scsMatfor_Entry_Detail_RwMaterial;
		}
		/// <summary>
		/// This makes tbl_scsMatfor_Entry_Detail_RwMaterial datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsMatfor_Entry_Detail_RwMaterial object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsMatfor_Entry_Detail_RwMaterial  tbl_scsMatfor_Entry_Detail_RwMaterial   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_rwLine_No = new DataColumn("rwLine_No" , typeof(Int64));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_mrp_ID = new DataColumn("mrp_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_rw_item_ID = new DataColumn("rw_item_ID" , typeof(string));
			DataColumn col_rw_itemSubCategory_ID = new DataColumn("rw_itemSubCategory_ID" , typeof(string));
			DataColumn col_rw_itemSubCategory2_ID = new DataColumn("rw_itemSubCategory2_ID" , typeof(string));
			DataColumn col_rw_itemSerialNo = new DataColumn("rw_itemSerialNo" , typeof(string));
			DataColumn col_rw_itemSerialNo2 = new DataColumn("rw_itemSerialNo2" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_rwLine_No,col_line_No,col_employee_ID,col_mrp_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_rw_item_ID,col_rw_itemSubCategory_ID,col_rw_itemSubCategory2_ID,col_rw_itemSerialNo,col_rw_itemSerialNo2,col_customer_ID,col_qty,col_weight,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsMatfor_Entry_Detail_RwMaterial datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsMatfor_Entry_Detail_RwMaterial object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsMatfor_Entry_Detail_RwMaterial user) {
		DataRow drow = dt.NewRow();
		
			drow["rwLine_No"] = user.rwLine_No;
			drow["line_No"] = user.line_No;
			drow["employee_ID"] = user.employee_ID;
			drow["mrp_ID"] = user.mrp_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["rw_item_ID"] = user.rw_item_ID;
			drow["rw_itemSubCategory_ID"] = user.rw_itemSubCategory_ID;
			drow["rw_itemSubCategory2_ID"] = user.rw_itemSubCategory2_ID;
			drow["rw_itemSerialNo"] = user.rw_itemSerialNo;
			drow["rw_itemSerialNo2"] = user.rw_itemSerialNo2;
			drow["customer_ID"] = user.customer_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
