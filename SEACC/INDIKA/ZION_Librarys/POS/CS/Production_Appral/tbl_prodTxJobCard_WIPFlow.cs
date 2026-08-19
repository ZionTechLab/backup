using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxJobCard_WIPFlow {
		#region Fields
		private Int64 sf_Index;
		private int line_No;
		private string prodJob_ID;
		private string item_ID;
		private string uom_ID;
		private decimal outQty;
		private decimal outWeight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string inSectionID;
		private string outSectionID;
		private bool isSubOut;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_WIPFlow class.
		/// </summary>
		public tbl_prodTxJobCard_WIPFlow() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_WIPFlow class.
		/// </summary>
		public tbl_prodTxJobCard_WIPFlow(int line_No, string prodJob_ID, string item_ID, string uom_ID, decimal outQty, decimal outWeight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string inSectionID, string outSectionID, bool isSubOut) {
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.outQty = outQty;
			this.outWeight = outWeight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.inSectionID = inSectionID;
			this.outSectionID = outSectionID;
			this.isSubOut = isSubOut;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_WIPFlow class.
		/// </summary>
		public tbl_prodTxJobCard_WIPFlow(Int64 sf_Index, int line_No, string prodJob_ID, string item_ID, string uom_ID, decimal outQty, decimal outWeight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string inSectionID, string outSectionID, bool isSubOut) {
			this.sf_Index = sf_Index;
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.outQty = outQty;
			this.outWeight = outWeight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.inSectionID = inSectionID;
			this.outSectionID = outSectionID;
			this.isSubOut = isSubOut;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Sf_Index value.
		/// </summary>
		public Int64 Sf_Index {
			get { return sf_Index; }
			set { sf_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OutQty value.
		/// </summary>
		public decimal OutQty {
			get { return outQty; }
			set { outQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the OutWeight value.
		/// </summary>
		public decimal OutWeight {
			get { return outWeight; }
			set { outWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightPrice value.
		/// </summary>
		public decimal WeightPrice {
			get { return weightPrice; }
			set { weightPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the InSectionID value.
		/// </summary>
		public string InSectionID {
			get { return inSectionID; }
			set { inSectionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OutSectionID value.
		/// </summary>
		public string OutSectionID {
			get { return outSectionID; }
			set { outSectionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSubOut value.
		/// </summary>
		public bool IsSubOut {
			get { return isSubOut; }
			set { isSubOut = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxJobCard_WIPFlow table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@outQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@outWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@outSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSubOut", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@outQty"].Value = outQty;
			scom.Parameters["@outWeight"].Value = outWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@inSectionID"].Value = inSectionID;
			scom.Parameters["@outSectionID"].Value = outSectionID;
			scom.Parameters["@isSubOut"].Value = isSubOut;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxJobCard_WIPFlow table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@sf_Index", SqlDbType.BigInt);
            scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@outQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@outWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@outSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSubOut", SqlDbType.Bit,1);

            scom.Parameters["@sf_Index"].Value = sf_Index;
            scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@outQty"].Value = outQty;
			scom.Parameters["@outWeight"].Value = outWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@inSectionID"].Value = inSectionID;
			scom.Parameters["@outSectionID"].Value = outSectionID;
			scom.Parameters["@isSubOut"].Value = isSubOut;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxJobCard_WIPFlow table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sf_Index", SqlDbType.BigInt);
			scom.Parameters["@sf_Index"].Value = sf_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static void DeleteAllByInSectionID(string inSectionID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowDeleteAllByInSectionID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@inSectionID", SqlDbType.VarChar,20);
			scom.Parameters["@inSectionID"].Value = inSectionID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static void DeleteAllByOutSectionID(string outSectionID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowDeleteAllByOutSectionID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@outSectionID", SqlDbType.VarChar,20);
			scom.Parameters["@outSectionID"].Value = outSectionID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxJobCard_WIPFlow table.
		/// </summary>
		public static tbl_prodTxJobCard_WIPFlow Select(Int64 sf_Index_Incoming){

			tbl_prodTxJobCard_WIPFlow tbl_prodTxJobCard_WIPFlowins = new tbl_prodTxJobCard_WIPFlow();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sf_Index", SqlDbType.BigInt);
			scom.Parameters["@sf_Index"].Value = sf_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxJobCard_WIPFlowins = Maketbl_prodTxJobCard_WIPFlow(dataReader);
				} else {
					tbl_prodTxJobCard_WIPFlowins = null;
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_WIPFlowins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table.
		/// </summary>
		public static List<tbl_prodTxJobCard_WIPFlow> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxJobCard_WIPFlow> tbl_prodTxJobCard_WIPFlowList = new List<tbl_prodTxJobCard_WIPFlow>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_WIPFlow tbl_prodTxJobCard_WIPFlow = Maketbl_prodTxJobCard_WIPFlow(dataReader);
					tbl_prodTxJobCard_WIPFlowList.Add(tbl_prodTxJobCard_WIPFlow);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_WIPFlowList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_WIPFlow> SelectAllByInSectionID(string inSectionID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowSelectAllByInSectionID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@inSectionID", SqlDbType.VarChar,20);
			scom.Parameters["@inSectionID"].Value = inSectionID;
				List<tbl_prodTxJobCard_WIPFlow> tbl_prodTxJobCard_WIPFlowList = new List<tbl_prodTxJobCard_WIPFlow>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_WIPFlow tbl_prodTxJobCard_WIPFlow = Maketbl_prodTxJobCard_WIPFlow(dataReader);
					tbl_prodTxJobCard_WIPFlowList.Add(tbl_prodTxJobCard_WIPFlow);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_WIPFlowList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_WIPFlow> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxJobCard_WIPFlow> tbl_prodTxJobCard_WIPFlowList = new List<tbl_prodTxJobCard_WIPFlow>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_WIPFlow tbl_prodTxJobCard_WIPFlow = Maketbl_prodTxJobCard_WIPFlow(dataReader);
					tbl_prodTxJobCard_WIPFlowList.Add(tbl_prodTxJobCard_WIPFlow);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_WIPFlowList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_WIPFlow> SelectAllByOutSectionID(string outSectionID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowSelectAllByOutSectionID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@outSectionID", SqlDbType.VarChar,20);
			scom.Parameters["@outSectionID"].Value = outSectionID;
				List<tbl_prodTxJobCard_WIPFlow> tbl_prodTxJobCard_WIPFlowList = new List<tbl_prodTxJobCard_WIPFlow>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_WIPFlow tbl_prodTxJobCard_WIPFlow = Maketbl_prodTxJobCard_WIPFlow(dataReader);
					tbl_prodTxJobCard_WIPFlowList.Add(tbl_prodTxJobCard_WIPFlow);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_WIPFlowList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_WIPFlow> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxJobCard_WIPFlow> tbl_prodTxJobCard_WIPFlowList = new List<tbl_prodTxJobCard_WIPFlow>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_WIPFlow tbl_prodTxJobCard_WIPFlow = Maketbl_prodTxJobCard_WIPFlow(dataReader);
					tbl_prodTxJobCard_WIPFlowList.Add(tbl_prodTxJobCard_WIPFlow);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_WIPFlowList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_WIPFlow table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_WIPFlow> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_WIPFlowSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxJobCard_WIPFlow> tbl_prodTxJobCard_WIPFlowList = new List<tbl_prodTxJobCard_WIPFlow>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_WIPFlow tbl_prodTxJobCard_WIPFlow = Maketbl_prodTxJobCard_WIPFlow(dataReader);
					tbl_prodTxJobCard_WIPFlowList.Add(tbl_prodTxJobCard_WIPFlow);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_WIPFlowList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxJobCard_WIPFlow class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxJobCard_WIPFlow Maketbl_prodTxJobCard_WIPFlow(SqlDataReader dataReader) {
			tbl_prodTxJobCard_WIPFlow tbl_prodTxJobCard_WIPFlow = new tbl_prodTxJobCard_WIPFlow();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxJobCard_WIPFlow.Sf_Index = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxJobCard_WIPFlow.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxJobCard_WIPFlow.ProdJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxJobCard_WIPFlow.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxJobCard_WIPFlow.Uom_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxJobCard_WIPFlow.OutQty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxJobCard_WIPFlow.OutWeight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxJobCard_WIPFlow.UnitPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxJobCard_WIPFlow.WeightPrice = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxJobCard_WIPFlow.TotalAmount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxJobCard_WIPFlow.InSectionID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxJobCard_WIPFlow.OutSectionID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxJobCard_WIPFlow.IsSubOut = dataReader.GetBoolean(12);
			}

			return tbl_prodTxJobCard_WIPFlow;
		}
		/// <summary>
		/// This makes tbl_prodTxJobCard_WIPFlow datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_WIPFlow object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxJobCard_WIPFlow  tbl_prodTxJobCard_WIPFlow   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_sf_Index = new DataColumn("sf_Index" , typeof(Int64));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_outQty = new DataColumn("outQty" , typeof(decimal));
			DataColumn col_outWeight = new DataColumn("outWeight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_inSectionID = new DataColumn("inSectionID" , typeof(string));
			DataColumn col_outSectionID = new DataColumn("outSectionID" , typeof(string));
			DataColumn col_isSubOut = new DataColumn("isSubOut" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_sf_Index,col_line_No,col_prodJob_ID,col_item_ID,col_uom_ID,col_outQty,col_outWeight,col_unitPrice,col_weightPrice,col_totalAmount,col_inSectionID,col_outSectionID,col_isSubOut,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxJobCard_WIPFlow datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_WIPFlow object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxJobCard_WIPFlow user) {
		DataRow drow = dt.NewRow();
		
			drow["sf_Index"] = user.sf_Index;
			drow["line_No"] = user.line_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["outQty"] = user.outQty;
			drow["outWeight"] = user.outWeight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["inSectionID"] = user.inSectionID;
			drow["outSectionID"] = user.outSectionID;
			drow["isSubOut"] = user.isSubOut;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
