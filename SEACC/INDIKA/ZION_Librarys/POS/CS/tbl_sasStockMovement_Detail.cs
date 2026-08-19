using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasStockMovement_Detail {
		#region Fields
		private string note_ID;
		private string stockNoteType_ID;
		private string item_ID;
		private decimal qty;
		private decimal weight;
		private decimal unitPrice;
		private decimal tatalAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasStockMovement_Detail class.
		/// </summary>
		public tbl_sasStockMovement_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasStockMovement_Detail class.
		/// </summary>
		public tbl_sasStockMovement_Detail(string note_ID, string stockNoteType_ID, string item_ID, decimal qty, decimal weight, decimal unitPrice, decimal tatalAmount) {
			this.note_ID = note_ID;
			this.stockNoteType_ID = stockNoteType_ID;
			this.item_ID = item_ID;
			this.qty = qty;
			this.weight = weight;
			this.unitPrice = unitPrice;
			this.tatalAmount = tatalAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Note_ID value.
		/// </summary>
		public string Note_ID {
			get { return note_ID; }
			set { note_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StockNoteType_ID value.
		/// </summary>
		public string StockNoteType_ID {
			get { return stockNoteType_ID; }
			set { stockNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalAmount value.
		/// </summary>
		public decimal TatalAmount {
			get { return tatalAmount; }
			set { tatalAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasStockMovement_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasStockMovement_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@note_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@note_ID"].Value = note_ID;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasStockMovement_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasStockMovement_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@note_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@note_ID"].Value = note_ID;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasStockMovement_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasStockMovement_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@note_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@note_ID"].Value = note_ID;
 
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasStockMovement_Detail table.
		/// </summary>
		public static tbl_sasStockMovement_Detail Select(string note_ID_Incoming, string stockNoteType_ID_Incoming, string item_ID_Incoming){

			tbl_sasStockMovement_Detail tbl_sasStockMovement_Detailins = new tbl_sasStockMovement_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasStockMovement_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@note_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@note_ID"].Value = note_ID_Incoming;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasStockMovement_Detailins = Maketbl_sasStockMovement_Detail(dataReader);
				} else {
					tbl_sasStockMovement_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasStockMovement_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasStockMovement_Detail table.
		/// </summary>
		public static List<tbl_sasStockMovement_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasStockMovement_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasStockMovement_Detail> tbl_sasStockMovement_DetailList = new List<tbl_sasStockMovement_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasStockMovement_Detail tbl_sasStockMovement_Detail = Maketbl_sasStockMovement_Detail(dataReader);
					tbl_sasStockMovement_DetailList.Add(tbl_sasStockMovement_Detail);
				}
			}
			scon.Close();
			return tbl_sasStockMovement_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasStockMovement_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasStockMovement_Detail Maketbl_sasStockMovement_Detail(SqlDataReader dataReader) {
			tbl_sasStockMovement_Detail tbl_sasStockMovement_Detail = new tbl_sasStockMovement_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasStockMovement_Detail.Note_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasStockMovement_Detail.StockNoteType_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasStockMovement_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasStockMovement_Detail.Qty = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasStockMovement_Detail.Weight = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasStockMovement_Detail.UnitPrice = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasStockMovement_Detail.TatalAmount = dataReader.GetDecimal(6);
			}

			return tbl_sasStockMovement_Detail;
		}
		/// <summary>
		/// This makes tbl_sasStockMovement_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasStockMovement_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasStockMovement_Detail  tbl_sasStockMovement_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_note_ID = new DataColumn("note_ID" , typeof(string));
			DataColumn col_stockNoteType_ID = new DataColumn("stockNoteType_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_note_ID,col_stockNoteType_ID,col_item_ID,col_qty,col_weight,col_unitPrice,col_tatalAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasStockMovement_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasStockMovement_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasStockMovement_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["note_ID"] = user.note_ID;
			drow["stockNoteType_ID"] = user.stockNoteType_ID;
			drow["item_ID"] = user.item_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["unitPrice"] = user.unitPrice;
			drow["tatalAmount"] = user.tatalAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
