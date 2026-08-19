using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audFifoTransaction {
		#region Fields
		private int fifo_Index;
		private int form_ID;
		private string transaction_ID;
		private DateTime transaction_date;
		private string store_ID;
		private string item_ID;
		private string itemSerialNo;
		private decimal qty;
		private decimal unitCost;
		private bool isStockIn;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audFifoTransaction class.
		/// </summary>
		public tbl_audFifoTransaction() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audFifoTransaction class.
		/// </summary>
		public tbl_audFifoTransaction(int form_ID, string transaction_ID, DateTime transaction_date, string store_ID, string item_ID, string itemSerialNo, decimal qty, decimal unitCost, bool isStockIn) {
			this.form_ID = form_ID;
			this.transaction_ID = transaction_ID;
			this.transaction_date = transaction_date;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.itemSerialNo = itemSerialNo;
			this.qty = qty;
			this.unitCost = unitCost;
			this.isStockIn = isStockIn;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audFifoTransaction class.
		/// </summary>
		public tbl_audFifoTransaction(int fifo_Index, int form_ID, string transaction_ID, DateTime transaction_date, string store_ID, string item_ID, string itemSerialNo, decimal qty, decimal unitCost, bool isStockIn) {
			this.fifo_Index = fifo_Index;
			this.form_ID = form_ID;
			this.transaction_ID = transaction_ID;
			this.transaction_date = transaction_date;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.itemSerialNo = itemSerialNo;
			this.qty = qty;
			this.unitCost = unitCost;
			this.isStockIn = isStockIn;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Fifo_Index value.
		/// </summary>
		public int Fifo_Index {
			get { return fifo_Index; }
			set { fifo_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_date value.
		/// </summary>
		public DateTime Transaction_date {
			get { return transaction_date; }
			set { transaction_date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitCost value.
		/// </summary>
		public decimal UnitCost {
			get { return unitCost; }
			set { unitCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsStockIn value.
		/// </summary>
		public bool IsStockIn {
			get { return isStockIn; }
			set { isStockIn = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audFifoTransaction table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audFifoTransactionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isStockIn", SqlDbType.Bit,1);
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@transaction_date"].Value = transaction_date;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@unitCost"].Value = unitCost;
			scom.Parameters["@isStockIn"].Value = isStockIn;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audFifoTransaction table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audFifoTransactionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isStockIn", SqlDbType.Bit,1);
 
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@transaction_date"].Value = transaction_date;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@unitCost"].Value = unitCost;
			scom.Parameters["@isStockIn"].Value = isStockIn;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audFifoTransaction table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audFifoTransactionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@fifo_Index", SqlDbType.Int,4);
			scom.Parameters["@fifo_Index"].Value = fifo_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        public static void DeleteAllByForm_ID_Transaction_ID(int form_ID, string transaction_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_audFifoTransactionDeleteAllByForm_ID_Transaction_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@form_ID", SqlDbType.Int, 16);
            scom.Parameters["@form_ID"].Value = form_ID;
            scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@transaction_ID"].Value = transaction_ID;

          //  scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the tbl_audFifoTransaction table.
        /// </summary>
        public static tbl_audFifoTransaction Select(int fifo_Index_Incoming){

			tbl_audFifoTransaction tbl_audFifoTransactionins = new tbl_audFifoTransaction();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audFifoTransactionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fifo_Index", SqlDbType.Int,4);
			scom.Parameters["@fifo_Index"].Value = fifo_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audFifoTransactionins = Maketbl_audFifoTransaction(dataReader);
				} else {
					tbl_audFifoTransactionins = null;
				}
			}
			scon.Close();
			return tbl_audFifoTransactionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audFifoTransaction table.
		/// </summary>
		public static List<tbl_audFifoTransaction> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audFifoTransactionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audFifoTransaction> tbl_audFifoTransactionList = new List<tbl_audFifoTransaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audFifoTransaction tbl_audFifoTransaction = Maketbl_audFifoTransaction(dataReader);
					tbl_audFifoTransactionList.Add(tbl_audFifoTransaction);
				}
			}
			scon.Close();
			return tbl_audFifoTransactionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audFifoTransaction class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audFifoTransaction Maketbl_audFifoTransaction(SqlDataReader dataReader) {
			tbl_audFifoTransaction tbl_audFifoTransaction = new tbl_audFifoTransaction();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audFifoTransaction.Fifo_Index = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audFifoTransaction.Form_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audFifoTransaction.Transaction_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audFifoTransaction.Transaction_date = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audFifoTransaction.Store_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_audFifoTransaction.Item_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_audFifoTransaction.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_audFifoTransaction.Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_audFifoTransaction.UnitCost = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_audFifoTransaction.IsStockIn = dataReader.GetBoolean(9);
			}

			return tbl_audFifoTransaction;
		}
		/// <summary>
		/// This makes tbl_audFifoTransaction datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audFifoTransaction object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audFifoTransaction  tbl_audFifoTransaction   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_fifo_Index = new DataColumn("fifo_Index" , typeof(int));
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_transaction_date = new DataColumn("transaction_date" , typeof(DateTime));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_unitCost = new DataColumn("unitCost" , typeof(decimal));
			DataColumn col_isStockIn = new DataColumn("isStockIn" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_fifo_Index,col_form_ID,col_transaction_ID,col_transaction_date,col_store_ID,col_item_ID,col_itemSerialNo,col_qty,col_unitCost,col_isStockIn,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audFifoTransaction datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audFifoTransaction object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audFifoTransaction user) {
		DataRow drow = dt.NewRow();
		
			drow["fifo_Index"] = user.fifo_Index;
			drow["form_ID"] = user.form_ID;
			drow["transaction_ID"] = user.transaction_ID;
			drow["transaction_date"] = user.transaction_date;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["qty"] = user.qty;
			drow["unitCost"] = user.unitCost;
			drow["isStockIn"] = user.isStockIn;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
