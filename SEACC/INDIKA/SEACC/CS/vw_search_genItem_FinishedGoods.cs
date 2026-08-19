using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class vw_search_genItem_FinishedGoods {
		#region Fields
		private string item_ID;
		private string customerName;
		private string itemName;
		private decimal width;
		private decimal height;
		private decimal thickness;
		private decimal gusset;
		private string polythyneType;
		private string sealingType;
		private string brandName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the vw_search_genItem_FinishedGoods class.
		/// </summary>
		public vw_search_genItem_FinishedGoods() {
		}
		
		/// <summary>
		/// Initializes a new instance of the vw_search_genItem_FinishedGoods class.
		/// </summary>
		public vw_search_genItem_FinishedGoods(string item_ID, string customerName, string itemName, decimal width, decimal height, decimal thickness, decimal gusset, string polythyneType, string sealingType, string brandName) {
			this.item_ID = item_ID;
			this.customerName = customerName;
			this.itemName = itemName;
			this.width = width;
			this.height = height;
			this.thickness = thickness;
			this.gusset = gusset;
			this.polythyneType = polythyneType;
			this.sealingType = sealingType;
			this.brandName = brandName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Width value.
		/// </summary>
		public decimal Width {
			get { return width; }
			set { width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Height value.
		/// </summary>
		public decimal Height {
			get { return height; }
			set { height = value; }
		}
		
		/// <summary>
		/// Gets or sets the Thickness value.
		/// </summary>
		public decimal Thickness {
			get { return thickness; }
			set { thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gusset value.
		/// </summary>
		public decimal Gusset {
			get { return gusset; }
			set { gusset = value; }
		}
		
		/// <summary>
		/// Gets or sets the PolythyneType value.
		/// </summary>
		public string PolythyneType {
			get { return polythyneType; }
			set { polythyneType = value; }
		}
		
		/// <summary>
		/// Gets or sets the SealingType value.
		/// </summary>
		public string SealingType {
			get { return sealingType; }
			set { sealingType = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrandName value.
		/// </summary>
		public string BrandName {
			get { return brandName; }
			set { brandName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the vw_search_genItem_FinishedGoods table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_genItem_FinishedGoodsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PolythyneType", SqlDbType.VarChar,50);
			scom.Parameters.Add("@SealingType", SqlDbType.VarChar,50);
			scom.Parameters.Add("@brandName", SqlDbType.VarChar,50);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@PolythyneType"].Value = polythyneType;
			scom.Parameters["@SealingType"].Value = sealingType;
			scom.Parameters["@brandName"].Value = brandName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the vw_search_genItem_FinishedGoods table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_genItem_FinishedGoodsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PolythyneType", SqlDbType.VarChar,50);
			scom.Parameters.Add("@SealingType", SqlDbType.VarChar,50);
			scom.Parameters.Add("@brandName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@PolythyneType"].Value = polythyneType;
			scom.Parameters["@SealingType"].Value = sealingType;
			scom.Parameters["@brandName"].Value = brandName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the vw_search_genItem_FinishedGoods table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_genItem_FinishedGoodsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the vw_search_genItem_FinishedGoods table.
		/// </summary>
		public static vw_search_genItem_FinishedGoods Select(string item_ID_Incoming){

			vw_search_genItem_FinishedGoods vw_search_genItem_FinishedGoodsins = new vw_search_genItem_FinishedGoods();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_genItem_FinishedGoodsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					vw_search_genItem_FinishedGoodsins = Makevw_search_genItem_FinishedGoods(dataReader);
				} else {
					vw_search_genItem_FinishedGoodsins = null;
				}
			}
			scon.Close();
			return vw_search_genItem_FinishedGoodsins;
		}
		
		/// <summary>
		/// Selects all records from the vw_search_genItem_FinishedGoods table.
		/// </summary>
		public static List<vw_search_genItem_FinishedGoods> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_search_genItem_FinishedGoodsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<vw_search_genItem_FinishedGoods> vw_search_genItem_FinishedGoodsList = new List<vw_search_genItem_FinishedGoods>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					vw_search_genItem_FinishedGoods vw_search_genItem_FinishedGoods = Makevw_search_genItem_FinishedGoods(dataReader);
					vw_search_genItem_FinishedGoodsList.Add(vw_search_genItem_FinishedGoods);
				}
			}
			scon.Close();
			return vw_search_genItem_FinishedGoodsList;
		}
		
		/// <summary>
		/// Creates a new instance of the vw_search_genItem_FinishedGoods class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static vw_search_genItem_FinishedGoods Makevw_search_genItem_FinishedGoods(SqlDataReader dataReader) {
			vw_search_genItem_FinishedGoods vw_search_genItem_FinishedGoods = new vw_search_genItem_FinishedGoods();
			
			if (dataReader.IsDBNull(0) == false) {
				vw_search_genItem_FinishedGoods.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				vw_search_genItem_FinishedGoods.CustomerName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				vw_search_genItem_FinishedGoods.ItemName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				vw_search_genItem_FinishedGoods.Width = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				vw_search_genItem_FinishedGoods.Height = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				vw_search_genItem_FinishedGoods.Thickness = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				vw_search_genItem_FinishedGoods.Gusset = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				vw_search_genItem_FinishedGoods.PolythyneType = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				vw_search_genItem_FinishedGoods.SealingType = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				vw_search_genItem_FinishedGoods.BrandName = dataReader.GetString(9);
			}

			return vw_search_genItem_FinishedGoods;
		}
		/// <summary>
		/// This makes vw_search_genItem_FinishedGoods datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new vw_search_genItem_FinishedGoods object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( vw_search_genItem_FinishedGoods  vw_search_genItem_FinishedGoods   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_height = new DataColumn("height" , typeof(decimal));
			DataColumn col_thickness = new DataColumn("thickness" , typeof(decimal));
			DataColumn col_gusset = new DataColumn("gusset" , typeof(decimal));
			DataColumn col_PolythyneType = new DataColumn("PolythyneType" , typeof(string));
			DataColumn col_SealingType = new DataColumn("SealingType" , typeof(string));
			DataColumn col_brandName = new DataColumn("brandName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_customerName,col_itemName,col_width,col_height,col_thickness,col_gusset,col_PolythyneType,col_SealingType,col_brandName,});		return dt;
		}
		/// <summary>
		/// This fills vw_search_genItem_FinishedGoods datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new vw_search_genItem_FinishedGoods object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, vw_search_genItem_FinishedGoods user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["customerName"] = user.customerName;
			drow["itemName"] = user.itemName;
			drow["width"] = user.width;
			drow["height"] = user.height;
			drow["thickness"] = user.thickness;
			drow["gusset"] = user.gusset;
			drow["PolythyneType"] = user.PolythyneType;
			drow["SealingType"] = user.SealingType;
			drow["brandName"] = user.brandName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
