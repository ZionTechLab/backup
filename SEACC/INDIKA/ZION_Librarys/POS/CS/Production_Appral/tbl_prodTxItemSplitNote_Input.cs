using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxItemSplitNote_Input {
		#region Fields
		private int line_No;
		private string split_ID;
		private string item_ID;
		private string uom_ID;
		private decimal floorQty;
		private decimal inputQtyRate;
		private decimal inputQty;
		private decimal inputWeight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string remark;
		private string linkedOutputItem_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxItemSplitNote_Input class.
		/// </summary>
		public tbl_prodTxItemSplitNote_Input() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxItemSplitNote_Input class.
		/// </summary>
		public tbl_prodTxItemSplitNote_Input(int line_No, string split_ID, string item_ID, string uom_ID, decimal floorQty, decimal inputQtyRate, decimal inputQty, decimal inputWeight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string remark, string linkedOutputItem_ID) {
			this.line_No = line_No;
			this.split_ID = split_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.floorQty = floorQty;
			this.inputQtyRate = inputQtyRate;
			this.inputQty = inputQty;
			this.inputWeight = inputWeight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.remark = remark;
			this.linkedOutputItem_ID = linkedOutputItem_ID;
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
		/// Gets or sets the Split_ID value.
		/// </summary>
		public string Split_ID {
			get { return split_ID; }
			set { split_ID = value; }
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
		/// Gets or sets the FloorQty value.
		/// </summary>
		public decimal FloorQty {
			get { return floorQty; }
			set { floorQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputQtyRate value.
		/// </summary>
		public decimal InputQtyRate {
			get { return inputQtyRate; }
			set { inputQtyRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputQty value.
		/// </summary>
		public decimal InputQty {
			get { return inputQty; }
			set { inputQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputWeight value.
		/// </summary>
		public decimal InputWeight {
			get { return inputWeight; }
			set { inputWeight = value; }
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
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the LinkedOutputItem_ID value.
		/// </summary>
		public string LinkedOutputItem_ID {
			get { return linkedOutputItem_ID; }
			set { linkedOutputItem_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxItemSplitNote_Input table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@split_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@floorQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputQtyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@linkedOutputItem_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@split_ID"].Value = split_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@floorQty"].Value = floorQty;
			scom.Parameters["@inputQtyRate"].Value = inputQtyRate;
			scom.Parameters["@inputQty"].Value = inputQty;
			scom.Parameters["@inputWeight"].Value = inputWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@linkedOutputItem_ID"].Value = linkedOutputItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxItemSplitNote_Input table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@split_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@floorQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputQtyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@linkedOutputItem_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@split_ID"].Value = split_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@floorQty"].Value = floorQty;
			scom.Parameters["@inputQtyRate"].Value = inputQtyRate;
			scom.Parameters["@inputQty"].Value = inputQty;
			scom.Parameters["@inputWeight"].Value = inputWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@linkedOutputItem_ID"].Value = linkedOutputItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxItemSplitNote_Input table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@split_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@split_ID"].Value = split_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table by a foreign key.
		/// </summary>
		public static void DeleteAllBySplit_ID(string split_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputDeleteAllBySplit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@split_ID", SqlDbType.VarChar,20);
			scom.Parameters["@split_ID"].Value = split_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table by a foreign key.
		/// </summary>
		public static void DeleteAllByLinkedOutputItem_ID(string linkedOutputItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputDeleteAllByLinkedOutputItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@linkedOutputItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@linkedOutputItem_ID"].Value = linkedOutputItem_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxItemSplitNote_Input table.
		/// </summary>
		public static tbl_prodTxItemSplitNote_Input Select(int line_No_Incoming, string split_ID_Incoming){

			tbl_prodTxItemSplitNote_Input tbl_prodTxItemSplitNote_Inputins = new tbl_prodTxItemSplitNote_Input();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@split_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@split_ID"].Value = split_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxItemSplitNote_Inputins = Maketbl_prodTxItemSplitNote_Input(dataReader);
				} else {
					tbl_prodTxItemSplitNote_Inputins = null;
				}
			}
			scon.Close();
			return tbl_prodTxItemSplitNote_Inputins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table.
		/// </summary>
		public static List<tbl_prodTxItemSplitNote_Input> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxItemSplitNote_Input> tbl_prodTxItemSplitNote_InputList = new List<tbl_prodTxItemSplitNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxItemSplitNote_Input tbl_prodTxItemSplitNote_Input = Maketbl_prodTxItemSplitNote_Input(dataReader);
					tbl_prodTxItemSplitNote_InputList.Add(tbl_prodTxItemSplitNote_Input);
				}
			}
			scon.Close();
			return tbl_prodTxItemSplitNote_InputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxItemSplitNote_Input> SelectAllBySplit_ID(string split_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputSelectAllBySplit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@split_ID", SqlDbType.VarChar,20);
			scom.Parameters["@split_ID"].Value = split_ID;
				List<tbl_prodTxItemSplitNote_Input> tbl_prodTxItemSplitNote_InputList = new List<tbl_prodTxItemSplitNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxItemSplitNote_Input tbl_prodTxItemSplitNote_Input = Maketbl_prodTxItemSplitNote_Input(dataReader);
					tbl_prodTxItemSplitNote_InputList.Add(tbl_prodTxItemSplitNote_Input);
				}
			}
			scon.Close();
			return tbl_prodTxItemSplitNote_InputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxItemSplitNote_Input> SelectAllByLinkedOutputItem_ID(string linkedOutputItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputSelectAllByLinkedOutputItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@linkedOutputItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@linkedOutputItem_ID"].Value = linkedOutputItem_ID;
				List<tbl_prodTxItemSplitNote_Input> tbl_prodTxItemSplitNote_InputList = new List<tbl_prodTxItemSplitNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxItemSplitNote_Input tbl_prodTxItemSplitNote_Input = Maketbl_prodTxItemSplitNote_Input(dataReader);
					tbl_prodTxItemSplitNote_InputList.Add(tbl_prodTxItemSplitNote_Input);
				}
			}
			scon.Close();
			return tbl_prodTxItemSplitNote_InputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxItemSplitNote_Input> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxItemSplitNote_Input> tbl_prodTxItemSplitNote_InputList = new List<tbl_prodTxItemSplitNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxItemSplitNote_Input tbl_prodTxItemSplitNote_Input = Maketbl_prodTxItemSplitNote_Input(dataReader);
					tbl_prodTxItemSplitNote_InputList.Add(tbl_prodTxItemSplitNote_Input);
				}
			}
			scon.Close();
			return tbl_prodTxItemSplitNote_InputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxItemSplitNote_Input table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxItemSplitNote_Input> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxItemSplitNote_InputSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxItemSplitNote_Input> tbl_prodTxItemSplitNote_InputList = new List<tbl_prodTxItemSplitNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxItemSplitNote_Input tbl_prodTxItemSplitNote_Input = Maketbl_prodTxItemSplitNote_Input(dataReader);
					tbl_prodTxItemSplitNote_InputList.Add(tbl_prodTxItemSplitNote_Input);
				}
			}
			scon.Close();
			return tbl_prodTxItemSplitNote_InputList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxItemSplitNote_Input class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxItemSplitNote_Input Maketbl_prodTxItemSplitNote_Input(SqlDataReader dataReader) {
			tbl_prodTxItemSplitNote_Input tbl_prodTxItemSplitNote_Input = new tbl_prodTxItemSplitNote_Input();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxItemSplitNote_Input.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxItemSplitNote_Input.Split_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxItemSplitNote_Input.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxItemSplitNote_Input.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxItemSplitNote_Input.FloorQty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxItemSplitNote_Input.InputQtyRate = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxItemSplitNote_Input.InputQty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxItemSplitNote_Input.InputWeight = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxItemSplitNote_Input.UnitPrice = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxItemSplitNote_Input.WeightPrice = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxItemSplitNote_Input.TotalAmount = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxItemSplitNote_Input.Remark = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxItemSplitNote_Input.LinkedOutputItem_ID = dataReader.GetString(12);
			}

			return tbl_prodTxItemSplitNote_Input;
		}
		/// <summary>
		/// This makes tbl_prodTxItemSplitNote_Input datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxItemSplitNote_Input object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxItemSplitNote_Input  tbl_prodTxItemSplitNote_Input   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_split_ID = new DataColumn("split_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_floorQty = new DataColumn("floorQty" , typeof(decimal));
			DataColumn col_inputQtyRate = new DataColumn("inputQtyRate" , typeof(decimal));
			DataColumn col_inputQty = new DataColumn("inputQty" , typeof(decimal));
			DataColumn col_inputWeight = new DataColumn("inputWeight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_linkedOutputItem_ID = new DataColumn("linkedOutputItem_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_split_ID,col_item_ID,col_uom_ID,col_floorQty,col_inputQtyRate,col_inputQty,col_inputWeight,col_unitPrice,col_weightPrice,col_totalAmount,col_remark,col_linkedOutputItem_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxItemSplitNote_Input datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxItemSplitNote_Input object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxItemSplitNote_Input user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["split_ID"] = user.split_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["floorQty"] = user.floorQty;
			drow["inputQtyRate"] = user.inputQtyRate;
			drow["inputQty"] = user.inputQty;
			drow["inputWeight"] = user.inputWeight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["remark"] = user.remark;
			drow["linkedOutputItem_ID"] = user.linkedOutputItem_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
