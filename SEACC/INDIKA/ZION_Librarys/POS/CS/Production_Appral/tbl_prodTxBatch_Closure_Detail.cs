using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxBatch_Closure_Detail {
		#region Fields
		private int line_No;
		private string closure_ID;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string item_ID_FG;
		private string uom_ID_FG;
		private int batchStatus;
		private decimal unitCost_Actual_FG;
		private decimal qty_Actual_FG;
		private decimal totalCost_Actual_FG;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxBatch_Closure_Detail class.
		/// </summary>
		public tbl_prodTxBatch_Closure_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxBatch_Closure_Detail class.
		/// </summary>
		public tbl_prodTxBatch_Closure_Detail(int line_No, string closure_ID, string prodJob_ID, string prodBatch_ID, string item_ID_FG, string uom_ID_FG, int batchStatus, decimal unitCost_Actual_FG, decimal qty_Actual_FG, decimal totalCost_Actual_FG) {
			this.line_No = line_No;
			this.closure_ID = closure_ID;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.item_ID_FG = item_ID_FG;
			this.uom_ID_FG = uom_ID_FG;
			this.batchStatus = batchStatus;
			this.unitCost_Actual_FG = unitCost_Actual_FG;
			this.qty_Actual_FG = qty_Actual_FG;
			this.totalCost_Actual_FG = totalCost_Actual_FG;
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
		/// Gets or sets the Closure_ID value.
		/// </summary>
		public string Closure_ID {
			get { return closure_ID; }
			set { closure_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdBatch_ID value.
		/// </summary>
		public string ProdBatch_ID {
			get { return prodBatch_ID; }
			set { prodBatch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_FG value.
		/// </summary>
		public string Uom_ID_FG {
			get { return uom_ID_FG; }
			set { uom_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the BatchStatus value.
		/// </summary>
		public int BatchStatus {
			get { return batchStatus; }
			set { batchStatus = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitCost_Actual_FG value.
		/// </summary>
		public decimal UnitCost_Actual_FG {
			get { return unitCost_Actual_FG; }
			set { unitCost_Actual_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Actual_FG value.
		/// </summary>
		public decimal Qty_Actual_FG {
			get { return qty_Actual_FG; }
			set { qty_Actual_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalCost_Actual_FG value.
		/// </summary>
		public decimal TotalCost_Actual_FG {
			get { return totalCost_Actual_FG; }
			set { totalCost_Actual_FG = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxBatch_Closure_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID_FG", SqlDbType.VarChar,10);
			scom.Parameters.Add("@batchStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@unitCost_Actual_FG", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Actual_FG", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalCost_Actual_FG", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@closure_ID"].Value = closure_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID_FG"].Value = uom_ID_FG;
			scom.Parameters["@batchStatus"].Value = batchStatus;
			scom.Parameters["@unitCost_Actual_FG"].Value = unitCost_Actual_FG;
			scom.Parameters["@qty_Actual_FG"].Value = qty_Actual_FG;
			scom.Parameters["@totalCost_Actual_FG"].Value = totalCost_Actual_FG;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxBatch_Closure_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID_FG", SqlDbType.VarChar,10);
			scom.Parameters.Add("@batchStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@unitCost_Actual_FG", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Actual_FG", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalCost_Actual_FG", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@closure_ID"].Value = closure_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID_FG"].Value = uom_ID_FG;
			scom.Parameters["@batchStatus"].Value = batchStatus;
			scom.Parameters["@unitCost_Actual_FG"].Value = unitCost_Actual_FG;
			scom.Parameters["@qty_Actual_FG"].Value = qty_Actual_FG;
			scom.Parameters["@totalCost_Actual_FG"].Value = totalCost_Actual_FG;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxBatch_Closure_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@closure_ID"].Value = closure_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID_FG(string uom_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailDeleteAllByUom_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_FG", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_FG"].Value = uom_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailDeleteAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByClosure_ID(string closure_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailDeleteAllByClosure_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters["@closure_ID"].Value = closure_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxBatch_Closure_Detail table.
		/// </summary>
		public static tbl_prodTxBatch_Closure_Detail Select(int line_No_Incoming, string closure_ID_Incoming){

			tbl_prodTxBatch_Closure_Detail tbl_prodTxBatch_Closure_Detailins = new tbl_prodTxBatch_Closure_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@closure_ID"].Value = closure_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxBatch_Closure_Detailins = Maketbl_prodTxBatch_Closure_Detail(dataReader);
				} else {
					tbl_prodTxBatch_Closure_Detailins = null;
				}
			}
			scon.Close();
			return tbl_prodTxBatch_Closure_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table.
		/// </summary>
		public static List<tbl_prodTxBatch_Closure_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxBatch_Closure_Detail> tbl_prodTxBatch_Closure_DetailList = new List<tbl_prodTxBatch_Closure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Closure_Detail tbl_prodTxBatch_Closure_Detail = Maketbl_prodTxBatch_Closure_Detail(dataReader);
					tbl_prodTxBatch_Closure_DetailList.Add(tbl_prodTxBatch_Closure_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_Closure_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Closure_Detail> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prodTxBatch_Closure_Detail> tbl_prodTxBatch_Closure_DetailList = new List<tbl_prodTxBatch_Closure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Closure_Detail tbl_prodTxBatch_Closure_Detail = Maketbl_prodTxBatch_Closure_Detail(dataReader);
					tbl_prodTxBatch_Closure_DetailList.Add(tbl_prodTxBatch_Closure_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_Closure_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Closure_Detail> SelectAllByUom_ID_FG(string uom_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailSelectAllByUom_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_FG", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_FG"].Value = uom_ID_FG;
				List<tbl_prodTxBatch_Closure_Detail> tbl_prodTxBatch_Closure_DetailList = new List<tbl_prodTxBatch_Closure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Closure_Detail tbl_prodTxBatch_Closure_Detail = Maketbl_prodTxBatch_Closure_Detail(dataReader);
					tbl_prodTxBatch_Closure_DetailList.Add(tbl_prodTxBatch_Closure_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_Closure_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Closure_Detail> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxBatch_Closure_Detail> tbl_prodTxBatch_Closure_DetailList = new List<tbl_prodTxBatch_Closure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Closure_Detail tbl_prodTxBatch_Closure_Detail = Maketbl_prodTxBatch_Closure_Detail(dataReader);
					tbl_prodTxBatch_Closure_DetailList.Add(tbl_prodTxBatch_Closure_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_Closure_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Closure_Detail> SelectAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailSelectAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
				List<tbl_prodTxBatch_Closure_Detail> tbl_prodTxBatch_Closure_DetailList = new List<tbl_prodTxBatch_Closure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Closure_Detail tbl_prodTxBatch_Closure_Detail = Maketbl_prodTxBatch_Closure_Detail(dataReader);
					tbl_prodTxBatch_Closure_DetailList.Add(tbl_prodTxBatch_Closure_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_Closure_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Closure_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Closure_Detail> SelectAllByClosure_ID(string closure_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_Closure_DetailSelectAllByClosure_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters["@closure_ID"].Value = closure_ID;
				List<tbl_prodTxBatch_Closure_Detail> tbl_prodTxBatch_Closure_DetailList = new List<tbl_prodTxBatch_Closure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Closure_Detail tbl_prodTxBatch_Closure_Detail = Maketbl_prodTxBatch_Closure_Detail(dataReader);
					tbl_prodTxBatch_Closure_DetailList.Add(tbl_prodTxBatch_Closure_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_Closure_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxBatch_Closure_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxBatch_Closure_Detail Maketbl_prodTxBatch_Closure_Detail(SqlDataReader dataReader) {
			tbl_prodTxBatch_Closure_Detail tbl_prodTxBatch_Closure_Detail = new tbl_prodTxBatch_Closure_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxBatch_Closure_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxBatch_Closure_Detail.Closure_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxBatch_Closure_Detail.ProdJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxBatch_Closure_Detail.ProdBatch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxBatch_Closure_Detail.Item_ID_FG = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxBatch_Closure_Detail.Uom_ID_FG = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxBatch_Closure_Detail.BatchStatus = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxBatch_Closure_Detail.UnitCost_Actual_FG = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxBatch_Closure_Detail.Qty_Actual_FG = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxBatch_Closure_Detail.TotalCost_Actual_FG = dataReader.GetDecimal(9);
			}

			return tbl_prodTxBatch_Closure_Detail;
		}
		/// <summary>
		/// This makes tbl_prodTxBatch_Closure_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxBatch_Closure_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxBatch_Closure_Detail  tbl_prodTxBatch_Closure_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_closure_ID = new DataColumn("closure_ID" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_uom_ID_FG = new DataColumn("uom_ID_FG" , typeof(string));
			DataColumn col_batchStatus = new DataColumn("batchStatus" , typeof(int));
			DataColumn col_unitCost_Actual_FG = new DataColumn("unitCost_Actual_FG" , typeof(decimal));
			DataColumn col_qty_Actual_FG = new DataColumn("qty_Actual_FG" , typeof(decimal));
			DataColumn col_totalCost_Actual_FG = new DataColumn("totalCost_Actual_FG" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_closure_ID,col_prodJob_ID,col_prodBatch_ID,col_item_ID_FG,col_uom_ID_FG,col_batchStatus,col_unitCost_Actual_FG,col_qty_Actual_FG,col_totalCost_Actual_FG,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxBatch_Closure_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxBatch_Closure_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxBatch_Closure_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["closure_ID"] = user.closure_ID;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["uom_ID_FG"] = user.uom_ID_FG;
			drow["batchStatus"] = user.batchStatus;
			drow["unitCost_Actual_FG"] = user.unitCost_Actual_FG;
			drow["qty_Actual_FG"] = user.qty_Actual_FG;
			drow["totalCost_Actual_FG"] = user.totalCost_Actual_FG;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
