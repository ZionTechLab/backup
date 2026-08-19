using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genStore_Stock_reconciliation {
		#region Fields
		private int rec_ID;
		private string store_ID;
		private string item_ID;
		private string job_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty_Old;
		private decimal qty;
		private decimal weight_Old;
		private decimal weight;
		private string createUser_ID;
		private DateTime dateCreate;
		private string createTerminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genStore_Stock_reconciliation class.
		/// </summary>
		public tbl_genStore_Stock_reconciliation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genStore_Stock_reconciliation class.
		/// </summary>
		public tbl_genStore_Stock_reconciliation(string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty_Old, decimal qty, decimal weight_Old, decimal weight, string createUser_ID, DateTime dateCreate, string createTerminal_ID) {
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.job_ID = job_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty_Old = qty_Old;
			this.qty = qty;
			this.weight_Old = weight_Old;
			this.weight = weight;
			this.createUser_ID = createUser_ID;
			this.dateCreate = dateCreate;
			this.createTerminal_ID = createTerminal_ID;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genStore_Stock_reconciliation class.
		/// </summary>
		public tbl_genStore_Stock_reconciliation(int rec_ID, string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty_Old, decimal qty, decimal weight_Old, decimal weight, string createUser_ID, DateTime dateCreate, string createTerminal_ID) {
			this.rec_ID = rec_ID;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.job_ID = job_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty_Old = qty_Old;
			this.qty = qty;
			this.weight_Old = weight_Old;
			this.weight = weight;
			this.createUser_ID = createUser_ID;
			this.dateCreate = dateCreate;
			this.createTerminal_ID = createTerminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Rec_ID value.
		/// </summary>
		public int Rec_ID {
			get { return rec_ID; }
			set { rec_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
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
		/// Gets or sets the Qty_Old value.
		/// </summary>
		public decimal Qty_Old {
			get { return qty_Old; }
			set { qty_Old = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight_Old value.
		/// </summary>
		public decimal Weight_Old {
			get { return weight_Old; }
			set { weight_Old = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genStore_Stock_reconciliation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_Stock_reconciliationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty_Old", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Old", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty_Old"].Value = qty_Old;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight_Old"].Value = weight_Old;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genStore_Stock_reconciliation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_Stock_reconciliationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty_Old", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Old", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty_Old"].Value = qty_Old;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight_Old"].Value = weight_Old;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genStore_Stock_reconciliation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_Stock_reconciliationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@Rec_ID", SqlDbType.Int,4);
			scom.Parameters["@Rec_ID"].Value = rec_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genStore_Stock_reconciliation table.
		/// </summary>
		public static tbl_genStore_Stock_reconciliation Select(int rec_ID_Incoming){

			tbl_genStore_Stock_reconciliation tbl_genStore_Stock_reconciliationins = new tbl_genStore_Stock_reconciliation();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_Stock_reconciliationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@Rec_ID", SqlDbType.Int,4);
			scom.Parameters["@Rec_ID"].Value = rec_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genStore_Stock_reconciliationins = Maketbl_genStore_Stock_reconciliation(dataReader);
				} else {
					tbl_genStore_Stock_reconciliationins = null;
				}
			}
			scon.Close();
			return tbl_genStore_Stock_reconciliationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock_reconciliation table.
		/// </summary>
		public static List<tbl_genStore_Stock_reconciliation> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_Stock_reconciliationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genStore_Stock_reconciliation> tbl_genStore_Stock_reconciliationList = new List<tbl_genStore_Stock_reconciliation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genStore_Stock_reconciliation tbl_genStore_Stock_reconciliation = Maketbl_genStore_Stock_reconciliation(dataReader);
					tbl_genStore_Stock_reconciliationList.Add(tbl_genStore_Stock_reconciliation);
				}
			}
			scon.Close();
			return tbl_genStore_Stock_reconciliationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genStore_Stock_reconciliation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genStore_Stock_reconciliation Maketbl_genStore_Stock_reconciliation(SqlDataReader dataReader) {
			tbl_genStore_Stock_reconciliation tbl_genStore_Stock_reconciliation = new tbl_genStore_Stock_reconciliation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genStore_Stock_reconciliation.Rec_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genStore_Stock_reconciliation.Store_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genStore_Stock_reconciliation.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genStore_Stock_reconciliation.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genStore_Stock_reconciliation.ItemSubCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genStore_Stock_reconciliation.ItemSubCategory2_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genStore_Stock_reconciliation.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genStore_Stock_reconciliation.ItemSerialNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genStore_Stock_reconciliation.Qty_Old = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genStore_Stock_reconciliation.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genStore_Stock_reconciliation.Weight_Old = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genStore_Stock_reconciliation.Weight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genStore_Stock_reconciliation.CreateUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genStore_Stock_reconciliation.DateCreate = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genStore_Stock_reconciliation.CreateTerminal_ID = dataReader.GetString(14);
			}

			return tbl_genStore_Stock_reconciliation;
		}
		/// <summary>
		/// This makes tbl_genStore_Stock_reconciliation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genStore_Stock_reconciliation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genStore_Stock_reconciliation  tbl_genStore_Stock_reconciliation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_Rec_ID = new DataColumn("Rec_ID" , typeof(int));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty_Old = new DataColumn("qty_Old" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight_Old = new DataColumn("weight_Old" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_Rec_ID,col_store_ID,col_item_ID,col_job_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty_Old,col_qty,col_weight_Old,col_weight,col_createUser_ID,col_dateCreate,col_createTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genStore_Stock_reconciliation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genStore_Stock_reconciliation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genStore_Stock_reconciliation user) {
		DataRow drow = dt.NewRow();
		
			drow["Rec_ID"] = user.Rec_ID;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["job_ID"] = user.job_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty_Old"] = user.qty_Old;
			drow["qty"] = user.qty;
			drow["weight_Old"] = user.weight_Old;
			drow["weight"] = user.weight;
			drow["createUser_ID"] = user.createUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["createTerminal_ID"] = user.createTerminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
