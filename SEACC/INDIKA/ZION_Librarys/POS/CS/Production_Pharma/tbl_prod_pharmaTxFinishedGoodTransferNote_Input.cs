using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxFinishedGoodTransferNote_Input {
		#region Fields
		private int line_No;
		private int output_itemLine_No;
		private string fgtn_ID;
		private string item_ID;
		private string uom_ID;
		private decimal floorQty;
		private decimal inputQty;
		private decimal inputWeight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxFinishedGoodTransferNote_Input class.
		/// </summary>
		public tbl_prod_pharmaTxFinishedGoodTransferNote_Input() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxFinishedGoodTransferNote_Input class.
		/// </summary>
		public tbl_prod_pharmaTxFinishedGoodTransferNote_Input(int line_No, int output_itemLine_No, string fgtn_ID, string item_ID, string uom_ID, decimal floorQty, decimal inputQty, decimal inputWeight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string remark) {
			this.line_No = line_No;
			this.output_itemLine_No = output_itemLine_No;
			this.fgtn_ID = fgtn_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.floorQty = floorQty;
			this.inputQty = inputQty;
			this.inputWeight = inputWeight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
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
		/// Gets or sets the Output_itemLine_No value.
		/// </summary>
		public int Output_itemLine_No {
			get { return output_itemLine_No; }
			set { output_itemLine_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fgtn_ID value.
		/// </summary>
		public string Fgtn_ID {
			get { return fgtn_ID; }
			set { fgtn_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@output_itemLine_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@floorQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@output_itemLine_No"].Value = output_itemLine_No;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@floorQty"].Value = floorQty;
			scom.Parameters["@inputQty"].Value = inputQty;
			scom.Parameters["@inputWeight"].Value = inputWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@output_itemLine_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@floorQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@output_itemLine_No"].Value = output_itemLine_No;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@floorQty"].Value = floorQty;
			scom.Parameters["@inputQty"].Value = inputQty;
			scom.Parameters["@inputWeight"].Value = inputWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@output_itemLine_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@output_itemLine_No"].Value = output_itemLine_No;
 
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by a foreign key.
		/// </summary>
		public static void DeleteAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputDeleteAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by a foreign key.
		/// </summary>
		public static void DeleteAllByOutput_itemLine_No_Fgtn_ID(int output_itemLine_No, string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputDeleteAllByOutput_itemLine_No_Fgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@output_itemLine_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@output_itemLine_No"].Value = output_itemLine_No;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table.
		/// </summary>
		public static tbl_prod_pharmaTxFinishedGoodTransferNote_Input Select(int line_No_Incoming, int output_itemLine_No_Incoming, string fgtn_ID_Incoming){

			tbl_prod_pharmaTxFinishedGoodTransferNote_Input tbl_prod_pharmaTxFinishedGoodTransferNote_Inputins = new tbl_prod_pharmaTxFinishedGoodTransferNote_Input();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@output_itemLine_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@output_itemLine_No"].Value = output_itemLine_No_Incoming;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Inputins = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Input(dataReader);
				} else {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Inputins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_Inputins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> tbl_prod_pharmaTxFinishedGoodTransferNote_InputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Input tbl_prod_pharmaTxFinishedGoodTransferNote_Input = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Input(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_InputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Input);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_InputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> SelectAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputSelectAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> tbl_prod_pharmaTxFinishedGoodTransferNote_InputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Input tbl_prod_pharmaTxFinishedGoodTransferNote_Input = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Input(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_InputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Input);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_InputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> SelectAllByOutput_itemLine_No_Fgtn_ID(int output_itemLine_No, string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputSelectAllByOutput_itemLine_No_Fgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@output_itemLine_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@output_itemLine_No"].Value = output_itemLine_No;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> tbl_prod_pharmaTxFinishedGoodTransferNote_InputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Input tbl_prod_pharmaTxFinishedGoodTransferNote_Input = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Input(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_InputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Input);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_InputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> tbl_prod_pharmaTxFinishedGoodTransferNote_InputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Input tbl_prod_pharmaTxFinishedGoodTransferNote_Input = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Input(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_InputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Input);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_InputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Input table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_InputSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input> tbl_prod_pharmaTxFinishedGoodTransferNote_InputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Input>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Input tbl_prod_pharmaTxFinishedGoodTransferNote_Input = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Input(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_InputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Input);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_InputList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxFinishedGoodTransferNote_Input class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxFinishedGoodTransferNote_Input Maketbl_prod_pharmaTxFinishedGoodTransferNote_Input(SqlDataReader dataReader) {
			tbl_prod_pharmaTxFinishedGoodTransferNote_Input tbl_prod_pharmaTxFinishedGoodTransferNote_Input = new tbl_prod_pharmaTxFinishedGoodTransferNote_Input();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.Output_itemLine_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.Fgtn_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.Uom_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.FloorQty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.InputQty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.InputWeight = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.UnitPrice = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.WeightPrice = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.TotalAmount = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Input.Remark = dataReader.GetString(11);
			}

			return tbl_prod_pharmaTxFinishedGoodTransferNote_Input;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxFinishedGoodTransferNote_Input datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxFinishedGoodTransferNote_Input object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxFinishedGoodTransferNote_Input  tbl_prod_pharmaTxFinishedGoodTransferNote_Input   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_output_itemLine_No = new DataColumn("output_itemLine_No" , typeof(int));
			DataColumn col_fgtn_ID = new DataColumn("fgtn_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_floorQty = new DataColumn("floorQty" , typeof(decimal));
			DataColumn col_inputQty = new DataColumn("inputQty" , typeof(decimal));
			DataColumn col_inputWeight = new DataColumn("inputWeight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_output_itemLine_No,col_fgtn_ID,col_item_ID,col_uom_ID,col_floorQty,col_inputQty,col_inputWeight,col_unitPrice,col_weightPrice,col_totalAmount,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxFinishedGoodTransferNote_Input datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxFinishedGoodTransferNote_Input object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxFinishedGoodTransferNote_Input user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["output_itemLine_No"] = user.output_itemLine_No;
			drow["fgtn_ID"] = user.fgtn_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["floorQty"] = user.floorQty;
			drow["inputQty"] = user.inputQty;
			drow["inputWeight"] = user.inputWeight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
