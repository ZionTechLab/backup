using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxFinishedGoodTransferNote_Output {
		#region Fields
		private int line_No;
		private string fgtn_ID;
		private string item_ID;
		private string uom_ID;
		private decimal outputQty;
		private decimal outputWeight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxFinishedGoodTransferNote_Output class.
		/// </summary>
		public tbl_prod_pharmaTxFinishedGoodTransferNote_Output() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxFinishedGoodTransferNote_Output class.
		/// </summary>
		public tbl_prod_pharmaTxFinishedGoodTransferNote_Output(int line_No, string fgtn_ID, string item_ID, string uom_ID, decimal outputQty, decimal outputWeight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string remark) {
			this.line_No = line_No;
			this.fgtn_ID = fgtn_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.outputQty = outputQty;
			this.outputWeight = outputWeight;
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
		/// Gets or sets the OutputQty value.
		/// </summary>
		public decimal OutputQty {
			get { return outputQty; }
			set { outputQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the OutputWeight value.
		/// </summary>
		public decimal OutputWeight {
			get { return outputWeight; }
			set { outputWeight = value; }
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
		/// Saves a record to the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@outputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@outputWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@outputQty"].Value = outputQty;
			scom.Parameters["@outputWeight"].Value = outputWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@outputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@outputWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@outputQty"].Value = outputQty;
			scom.Parameters["@outputWeight"].Value = outputWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table by a foreign key.
		/// </summary>
		public static void DeleteAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputDeleteAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table.
		/// </summary>
		public static tbl_prod_pharmaTxFinishedGoodTransferNote_Output Select(int line_No_Incoming, string fgtn_ID_Incoming){

			tbl_prod_pharmaTxFinishedGoodTransferNote_Output tbl_prod_pharmaTxFinishedGoodTransferNote_Outputins = new tbl_prod_pharmaTxFinishedGoodTransferNote_Output();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Outputins = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Output(dataReader);
				} else {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Outputins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_Outputins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output> tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Output tbl_prod_pharmaTxFinishedGoodTransferNote_Output = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Output(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Output);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output> tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Output tbl_prod_pharmaTxFinishedGoodTransferNote_Output = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Output(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Output);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output> tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Output tbl_prod_pharmaTxFinishedGoodTransferNote_Output = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Output(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Output);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferNote_Output table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output> SelectAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferNote_OutputSelectAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output> tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList = new List<tbl_prod_pharmaTxFinishedGoodTransferNote_Output>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferNote_Output tbl_prod_pharmaTxFinishedGoodTransferNote_Output = Maketbl_prod_pharmaTxFinishedGoodTransferNote_Output(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList.Add(tbl_prod_pharmaTxFinishedGoodTransferNote_Output);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferNote_OutputList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxFinishedGoodTransferNote_Output class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxFinishedGoodTransferNote_Output Maketbl_prod_pharmaTxFinishedGoodTransferNote_Output(SqlDataReader dataReader) {
			tbl_prod_pharmaTxFinishedGoodTransferNote_Output tbl_prod_pharmaTxFinishedGoodTransferNote_Output = new tbl_prod_pharmaTxFinishedGoodTransferNote_Output();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.Fgtn_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.OutputQty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.OutputWeight = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.UnitPrice = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.WeightPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.TotalAmount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferNote_Output.Remark = dataReader.GetString(9);
			}

			return tbl_prod_pharmaTxFinishedGoodTransferNote_Output;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxFinishedGoodTransferNote_Output datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxFinishedGoodTransferNote_Output object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxFinishedGoodTransferNote_Output  tbl_prod_pharmaTxFinishedGoodTransferNote_Output   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_fgtn_ID = new DataColumn("fgtn_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_outputQty = new DataColumn("outputQty" , typeof(decimal));
			DataColumn col_outputWeight = new DataColumn("outputWeight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_fgtn_ID,col_item_ID,col_uom_ID,col_outputQty,col_outputWeight,col_unitPrice,col_weightPrice,col_totalAmount,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxFinishedGoodTransferNote_Output datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxFinishedGoodTransferNote_Output object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxFinishedGoodTransferNote_Output user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["fgtn_ID"] = user.fgtn_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["outputQty"] = user.outputQty;
			drow["outputWeight"] = user.outputWeight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
