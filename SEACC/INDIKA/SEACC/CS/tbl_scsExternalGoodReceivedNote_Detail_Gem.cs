using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsExternalGoodReceivedNote_Detail_Gem {
		#region Fields
		private int line_No;
		private string externalGoodReceivedNote_ID;
		private string companyBranch_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string gemDetail;
		private string metalDetail;
		private decimal metalWeight;
		private decimal gemWeight;
		private decimal gemQty;
		private decimal sellingPrice;
		private bool isTransferred;
		private bool isLocked;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodReceivedNote_Detail_Gem class.
		/// </summary>
		public tbl_scsExternalGoodReceivedNote_Detail_Gem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodReceivedNote_Detail_Gem class.
		/// </summary>
		public tbl_scsExternalGoodReceivedNote_Detail_Gem(int line_No, string externalGoodReceivedNote_ID, string companyBranch_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string gemDetail, string metalDetail, decimal metalWeight, decimal gemWeight, decimal gemQty, decimal sellingPrice, bool isTransferred, bool isLocked) {
			this.line_No = line_No;
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.gemDetail = gemDetail;
			this.metalDetail = metalDetail;
			this.metalWeight = metalWeight;
			this.gemWeight = gemWeight;
			this.gemQty = gemQty;
			this.sellingPrice = sellingPrice;
			this.isTransferred = isTransferred;
			this.isLocked = isLocked;
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
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
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
		/// Gets or sets the GemDetail value.
		/// </summary>
		public string GemDetail {
			get { return gemDetail; }
			set { gemDetail = value; }
		}
		
		/// <summary>
		/// Gets or sets the MetalDetail value.
		/// </summary>
		public string MetalDetail {
			get { return metalDetail; }
			set { metalDetail = value; }
		}
		
		/// <summary>
		/// Gets or sets the MetalWeight value.
		/// </summary>
		public decimal MetalWeight {
			get { return metalWeight; }
			set { metalWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the GemWeight value.
		/// </summary>
		public decimal GemWeight {
			get { return gemWeight; }
			set { gemWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the GemQty value.
		/// </summary>
		public decimal GemQty {
			get { return gemQty; }
			set { gemQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice value.
		/// </summary>
		public decimal SellingPrice {
			get { return sellingPrice; }
			set { sellingPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTransferred value.
		/// </summary>
		public bool IsTransferred {
			get { return isTransferred; }
			set { isTransferred = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsExternalGoodReceivedNote_Detail_Gem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_Detail_GemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@gemDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gemWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gemQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isTransferred", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@gemDetail"].Value = gemDetail;
			scom.Parameters["@metalDetail"].Value = metalDetail;
			scom.Parameters["@metalWeight"].Value = metalWeight;
			scom.Parameters["@gemWeight"].Value = gemWeight;
			scom.Parameters["@gemQty"].Value = gemQty;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@isTransferred"].Value = isTransferred;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsExternalGoodReceivedNote_Detail_Gem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_Detail_GemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@gemDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gemWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gemQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isTransferred", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@gemDetail"].Value = gemDetail;
			scom.Parameters["@metalDetail"].Value = metalDetail;
			scom.Parameters["@metalWeight"].Value = metalWeight;
			scom.Parameters["@gemWeight"].Value = gemWeight;
			scom.Parameters["@gemQty"].Value = gemQty;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@isTransferred"].Value = isTransferred;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsExternalGoodReceivedNote_Detail_Gem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_Detail_GemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsExternalGoodReceivedNote_Detail_Gem table.
		/// </summary>
		public static tbl_scsExternalGoodReceivedNote_Detail_Gem Select(string externalGoodReceivedNote_ID_Incoming, string companyBranch_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsExternalGoodReceivedNote_Detail_Gem tbl_scsExternalGoodReceivedNote_Detail_Gemins = new tbl_scsExternalGoodReceivedNote_Detail_Gem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_Detail_GemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote_Detail_Gemins = Maketbl_scsExternalGoodReceivedNote_Detail_Gem(dataReader);
				} else {
					tbl_scsExternalGoodReceivedNote_Detail_Gemins = null;
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNote_Detail_Gemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote_Detail_Gem table.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote_Detail_Gem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_Detail_GemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsExternalGoodReceivedNote_Detail_Gem> tbl_scsExternalGoodReceivedNote_Detail_GemList = new List<tbl_scsExternalGoodReceivedNote_Detail_Gem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote_Detail_Gem tbl_scsExternalGoodReceivedNote_Detail_Gem = Maketbl_scsExternalGoodReceivedNote_Detail_Gem(dataReader);
					tbl_scsExternalGoodReceivedNote_Detail_GemList.Add(tbl_scsExternalGoodReceivedNote_Detail_Gem);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNote_Detail_GemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsExternalGoodReceivedNote_Detail_Gem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsExternalGoodReceivedNote_Detail_Gem Maketbl_scsExternalGoodReceivedNote_Detail_Gem(SqlDataReader dataReader) {
			tbl_scsExternalGoodReceivedNote_Detail_Gem tbl_scsExternalGoodReceivedNote_Detail_Gem = new tbl_scsExternalGoodReceivedNote_Detail_Gem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.ExternalGoodReceivedNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.CompanyBranch_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.ItemSubCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.ItemSubCategory2_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.ItemSerialNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.GemDetail = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.MetalDetail = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.MetalWeight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.GemWeight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.GemQty = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.SellingPrice = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.IsTransferred = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsExternalGoodReceivedNote_Detail_Gem.IsLocked = dataReader.GetBoolean(15);
			}

			return tbl_scsExternalGoodReceivedNote_Detail_Gem;
		}
		/// <summary>
		/// This makes tbl_scsExternalGoodReceivedNote_Detail_Gem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodReceivedNote_Detail_Gem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsExternalGoodReceivedNote_Detail_Gem  tbl_scsExternalGoodReceivedNote_Detail_Gem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_gemDetail = new DataColumn("gemDetail" , typeof(string));
			DataColumn col_metalDetail = new DataColumn("metalDetail" , typeof(string));
			DataColumn col_metalWeight = new DataColumn("metalWeight" , typeof(decimal));
			DataColumn col_gemWeight = new DataColumn("gemWeight" , typeof(decimal));
			DataColumn col_gemQty = new DataColumn("gemQty" , typeof(decimal));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
			DataColumn col_isTransferred = new DataColumn("isTransferred" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_externalGoodReceivedNote_ID,col_companyBranch_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_gemDetail,col_metalDetail,col_metalWeight,col_gemWeight,col_gemQty,col_sellingPrice,col_isTransferred,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsExternalGoodReceivedNote_Detail_Gem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodReceivedNote_Detail_Gem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsExternalGoodReceivedNote_Detail_Gem user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["gemDetail"] = user.gemDetail;
			drow["metalDetail"] = user.metalDetail;
			drow["metalWeight"] = user.metalWeight;
			drow["gemWeight"] = user.gemWeight;
			drow["gemQty"] = user.gemQty;
			drow["sellingPrice"] = user.sellingPrice;
			drow["isTransferred"] = user.isTransferred;
			drow["isLocked"] = user.isLocked;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
