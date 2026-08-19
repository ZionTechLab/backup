using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsTempStockTrackingReport {
		#region Fields
		private int lineNo;
		private string item_ID;
		private string itemSubCategory_ID;
		private decimal qty;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal weight;
		private string transactionType;
		private bool isAdd;
		private bool isOPB;
		private string transactionID;
		private DateTime transactionDate;
		private string remark;
		private string createUser_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsTempStockTrackingReport class.
		/// </summary>
		public tbl_scsTempStockTrackingReport() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsTempStockTrackingReport class.
		/// </summary>
		public tbl_scsTempStockTrackingReport(string item_ID, string itemSubCategory_ID, decimal qty, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal weight, string transactionType, bool isAdd, bool isOPB, string transactionID, DateTime transactionDate, string remark, string createUser_ID) {
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.qty = qty;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.weight = weight;
			this.transactionType = transactionType;
			this.isAdd = isAdd;
			this.isOPB = isOPB;
			this.transactionID = transactionID;
			this.transactionDate = transactionDate;
			this.remark = remark;
			this.createUser_ID = createUser_ID;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsTempStockTrackingReport class.
		/// </summary>
		public tbl_scsTempStockTrackingReport(int lineNo, string item_ID, string itemSubCategory_ID, decimal qty, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal weight, string transactionType, bool isAdd, bool isOPB, string transactionID, DateTime transactionDate, string remark, string createUser_ID) {
			this.lineNo = lineNo;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.qty = qty;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.weight = weight;
			this.transactionType = transactionType;
			this.isAdd = isAdd;
			this.isOPB = isOPB;
			this.transactionID = transactionID;
			this.transactionDate = transactionDate;
			this.remark = remark;
			this.createUser_ID = createUser_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the LineNo value.
		/// </summary>
		public int LineNo {
			get { return lineNo; }
			set { lineNo = value; }
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
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
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
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionType value.
		/// </summary>
		public string TransactionType {
			get { return transactionType; }
			set { transactionType = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAdd value.
		/// </summary>
		public bool IsAdd {
			get { return isAdd; }
			set { isAdd = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOPB value.
		/// </summary>
		public bool IsOPB {
			get { return isOPB; }
			set { isOPB = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionID value.
		/// </summary>
		public string TransactionID {
			get { return transactionID; }
			set { transactionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsTempStockTrackingReport table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsTempStockTrackingReportInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TransactionType", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IsAdd", SqlDbType.Bit,1);
			scom.Parameters.Add("@IsOPB", SqlDbType.Bit,1);
			scom.Parameters.Add("@TransactionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@TransactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@TransactionType"].Value = transactionType;
			scom.Parameters["@IsAdd"].Value = isAdd;
			scom.Parameters["@IsOPB"].Value = isOPB;
			scom.Parameters["@TransactionID"].Value = transactionID;
			scom.Parameters["@TransactionDate"].Value = transactionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsTempStockTrackingReport table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsTempStockTrackingReportUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TransactionType", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IsAdd", SqlDbType.Bit,1);
			scom.Parameters.Add("@IsOPB", SqlDbType.Bit,1);
			scom.Parameters.Add("@TransactionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@TransactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@TransactionType"].Value = transactionType;
			scom.Parameters["@IsAdd"].Value = isAdd;
			scom.Parameters["@IsOPB"].Value = isOPB;
			scom.Parameters["@TransactionID"].Value = transactionID;
			scom.Parameters["@TransactionDate"].Value = transactionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsTempStockTrackingReport table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsTempStockTrackingReportDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@lineNo", SqlDbType.Int,4);
			scom.Parameters["@lineNo"].Value = lineNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsTempStockTrackingReport table.
		/// </summary>
		public static tbl_scsTempStockTrackingReport Select(int lineNo_Incoming){

			tbl_scsTempStockTrackingReport tbl_scsTempStockTrackingReportins = new tbl_scsTempStockTrackingReport();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsTempStockTrackingReportSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@lineNo", SqlDbType.Int,4);
			scom.Parameters["@lineNo"].Value = lineNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsTempStockTrackingReportins = Maketbl_scsTempStockTrackingReport(dataReader);
				} else {
					tbl_scsTempStockTrackingReportins = null;
				}
			}
			scon.Close();
			return tbl_scsTempStockTrackingReportins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsTempStockTrackingReport table.
		/// </summary>
		public static List<tbl_scsTempStockTrackingReport> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsTempStockTrackingReportSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsTempStockTrackingReport> tbl_scsTempStockTrackingReportList = new List<tbl_scsTempStockTrackingReport>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsTempStockTrackingReport tbl_scsTempStockTrackingReport = Maketbl_scsTempStockTrackingReport(dataReader);
					tbl_scsTempStockTrackingReportList.Add(tbl_scsTempStockTrackingReport);
				}
			}
			scon.Close();
			return tbl_scsTempStockTrackingReportList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsTempStockTrackingReport class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsTempStockTrackingReport Maketbl_scsTempStockTrackingReport(SqlDataReader dataReader) {
			tbl_scsTempStockTrackingReport tbl_scsTempStockTrackingReport = new tbl_scsTempStockTrackingReport();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsTempStockTrackingReport.LineNo = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsTempStockTrackingReport.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsTempStockTrackingReport.ItemSubCategory_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsTempStockTrackingReport.Qty = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsTempStockTrackingReport.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsTempStockTrackingReport.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsTempStockTrackingReport.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsTempStockTrackingReport.Weight = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsTempStockTrackingReport.TransactionType = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsTempStockTrackingReport.IsAdd = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsTempStockTrackingReport.IsOPB = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsTempStockTrackingReport.TransactionID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsTempStockTrackingReport.TransactionDate = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsTempStockTrackingReport.Remark = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsTempStockTrackingReport.CreateUser_ID = dataReader.GetString(14);
			}

			return tbl_scsTempStockTrackingReport;
		}
		/// <summary>
		/// This makes tbl_scsTempStockTrackingReport datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsTempStockTrackingReport object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsTempStockTrackingReport  tbl_scsTempStockTrackingReport   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_lineNo = new DataColumn("lineNo" , typeof(int));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_TransactionType = new DataColumn("TransactionType" , typeof(string));
			DataColumn col_IsAdd = new DataColumn("IsAdd" , typeof(bool));
			DataColumn col_IsOPB = new DataColumn("IsOPB" , typeof(bool));
			DataColumn col_TransactionID = new DataColumn("TransactionID" , typeof(string));
			DataColumn col_TransactionDate = new DataColumn("TransactionDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_lineNo,col_item_ID,col_itemSubCategory_ID,col_qty,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_weight,col_TransactionType,col_IsAdd,col_IsOPB,col_TransactionID,col_TransactionDate,col_remark,col_createUser_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsTempStockTrackingReport datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsTempStockTrackingReport object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsTempStockTrackingReport user) {
		DataRow drow = dt.NewRow();
		
			drow["lineNo"] = user.lineNo;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["qty"] = user.qty;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["weight"] = user.weight;
			drow["TransactionType"] = user.TransactionType;
			drow["IsAdd"] = user.IsAdd;
			drow["IsOPB"] = user.IsOPB;
			drow["TransactionID"] = user.TransactionID;
			drow["TransactionDate"] = user.TransactionDate;
			drow["remark"] = user.remark;
			drow["createUser_ID"] = user.createUser_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
