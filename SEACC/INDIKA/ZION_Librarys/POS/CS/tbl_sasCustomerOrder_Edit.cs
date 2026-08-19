using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasCustomerOrder_Edit {
		#region Fields
		private string customerOrderEdit_ID;
		private string remark;
		private DateTime customerOrderEditDate;
		private string customerOrder_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal qty_Modified;
		private decimal weight;
		private decimal weight_Modified;
		private string createUser_ID;
		private DateTime dateCreate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasCustomerOrder_Edit class.
		/// </summary>
		public tbl_sasCustomerOrder_Edit() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasCustomerOrder_Edit class.
		/// </summary>
		public tbl_sasCustomerOrder_Edit(string customerOrderEdit_ID, string remark, DateTime customerOrderEditDate, string customerOrder_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal qty_Modified, decimal weight, decimal weight_Modified, string createUser_ID, DateTime dateCreate) {
			this.customerOrderEdit_ID = customerOrderEdit_ID;
			this.remark = remark;
			this.customerOrderEditDate = customerOrderEditDate;
			this.customerOrder_ID = customerOrder_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.qty_Modified = qty_Modified;
			this.weight = weight;
			this.weight_Modified = weight_Modified;
			this.createUser_ID = createUser_ID;
			this.dateCreate = dateCreate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CustomerOrderEdit_ID value.
		/// </summary>
		public string CustomerOrderEdit_ID {
			get { return customerOrderEdit_ID; }
			set { customerOrderEdit_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrderEditDate value.
		/// </summary>
		public DateTime CustomerOrderEditDate {
			get { return customerOrderEditDate; }
			set { customerOrderEditDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
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
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Modified value.
		/// </summary>
		public decimal Qty_Modified {
			get { return qty_Modified; }
			set { qty_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight_Modified value.
		/// </summary>
		public decimal Weight_Modified {
			get { return weight_Modified; }
			set { weight_Modified = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasCustomerOrder_Edit table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_EditInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerOrderEdit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@customerOrderEditDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Modified", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Modified", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
 
			scom.Parameters["@customerOrderEdit_ID"].Value = customerOrderEdit_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customerOrderEditDate"].Value = customerOrderEditDate;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qty_Modified"].Value = qty_Modified;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weight_Modified"].Value = weight_Modified;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasCustomerOrder_Edit table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_EditUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerOrderEdit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@customerOrderEditDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Modified", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Modified", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@customerOrderEdit_ID"].Value = customerOrderEdit_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customerOrderEditDate"].Value = customerOrderEditDate;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qty_Modified"].Value = qty_Modified;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weight_Modified"].Value = weight_Modified;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasCustomerOrder_Edit table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_EditDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customerOrderEdit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrderEdit_ID"].Value = customerOrderEdit_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasCustomerOrder_Edit table.
		/// </summary>
		public static tbl_sasCustomerOrder_Edit Select(string customerOrderEdit_ID_Incoming){

			tbl_sasCustomerOrder_Edit tbl_sasCustomerOrder_Editins = new tbl_sasCustomerOrder_Edit();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_EditSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrderEdit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrderEdit_ID"].Value = customerOrderEdit_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasCustomerOrder_Editins = Maketbl_sasCustomerOrder_Edit(dataReader);
				} else {
					tbl_sasCustomerOrder_Editins = null;
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_Editins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Edit table.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Edit> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_EditSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasCustomerOrder_Edit> tbl_sasCustomerOrder_EditList = new List<tbl_sasCustomerOrder_Edit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Edit tbl_sasCustomerOrder_Edit = Maketbl_sasCustomerOrder_Edit(dataReader);
					tbl_sasCustomerOrder_EditList.Add(tbl_sasCustomerOrder_Edit);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_EditList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasCustomerOrder_Edit class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasCustomerOrder_Edit Maketbl_sasCustomerOrder_Edit(SqlDataReader dataReader) {
			tbl_sasCustomerOrder_Edit tbl_sasCustomerOrder_Edit = new tbl_sasCustomerOrder_Edit();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasCustomerOrder_Edit.CustomerOrderEdit_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasCustomerOrder_Edit.Remark = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasCustomerOrder_Edit.CustomerOrderEditDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasCustomerOrder_Edit.CustomerOrder_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasCustomerOrder_Edit.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasCustomerOrder_Edit.ItemSubCategory_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasCustomerOrder_Edit.ItemSubCategory2_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasCustomerOrder_Edit.ItemSerialNo = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasCustomerOrder_Edit.ItemSerialNo2 = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasCustomerOrder_Edit.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasCustomerOrder_Edit.Qty_Modified = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasCustomerOrder_Edit.Weight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasCustomerOrder_Edit.Weight_Modified = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasCustomerOrder_Edit.CreateUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasCustomerOrder_Edit.DateCreate = dataReader.GetDateTime(14);
			}

			return tbl_sasCustomerOrder_Edit;
		}
		/// <summary>
		/// This makes tbl_sasCustomerOrder_Edit datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasCustomerOrder_Edit object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasCustomerOrder_Edit  tbl_sasCustomerOrder_Edit   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customerOrderEdit_ID = new DataColumn("customerOrderEdit_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_customerOrderEditDate = new DataColumn("customerOrderEditDate" , typeof(DateTime));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qty_Modified = new DataColumn("qty_Modified" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weight_Modified = new DataColumn("weight_Modified" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_customerOrderEdit_ID,col_remark,col_customerOrderEditDate,col_customerOrder_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_qty_Modified,col_weight,col_weight_Modified,col_createUser_ID,col_dateCreate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasCustomerOrder_Edit datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasCustomerOrder_Edit object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasCustomerOrder_Edit user) {
		DataRow drow = dt.NewRow();
		
			drow["customerOrderEdit_ID"] = user.customerOrderEdit_ID;
			drow["remark"] = user.remark;
			drow["customerOrderEditDate"] = user.customerOrderEditDate;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["qty_Modified"] = user.qty_Modified;
			drow["weight"] = user.weight;
			drow["weight_Modified"] = user.weight_Modified;
			drow["createUser_ID"] = user.createUser_ID;
			drow["dateCreate"] = user.dateCreate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
