using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsDocument_Barcode {
		#region Fields
		private string transaction_Code;
		private string transaction_ID;
		private string item_ID;
		private int barcode_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsDocument_Barcode class.
		/// </summary>
		public tbl_scsDocument_Barcode() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsDocument_Barcode class.
		/// </summary>
		public tbl_scsDocument_Barcode(string transaction_Code, string transaction_ID, string item_ID, int barcode_ID) {
			this.transaction_Code = transaction_Code;
			this.transaction_ID = transaction_ID;
			this.item_ID = item_ID;
			this.barcode_ID = barcode_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Transaction_Code value.
		/// </summary>
		public string Transaction_Code {
			get { return transaction_Code; }
			set { transaction_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Barcode_ID value.
		/// </summary>
		public int Barcode_ID {
			get { return barcode_ID; }
			set { barcode_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsDocument_Barcode table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDocument_BarcodeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@transaction_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
 
			scom.Parameters["@transaction_Code"].Value = transaction_Code;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsDocument_Barcode table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDocument_BarcodeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@transaction_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@transaction_Code"].Value = transaction_Code;
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDocument_Barcode table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDocument_BarcodeDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDocument_Barcode table by a foreign key.
		/// </summary>
		public static void DeleteAllByBarcode_ID(int barcode_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDocument_BarcodeDeleteAllByBarcode_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsDocument_Barcode table.
		/// </summary>
		public static tbl_scsDocument_Barcode Select(string transaction_Code_Incoming, string transaction_ID_Incoming, string item_ID_Incoming, int barcode_ID_Incoming){

			tbl_scsDocument_Barcode tbl_scsDocument_Barcodeins = new tbl_scsDocument_Barcode();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDocument_BarcodeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@transaction_Code"].Value = transaction_Code_Incoming;
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@barcode_ID"].Value = barcode_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsDocument_Barcodeins = Maketbl_scsDocument_Barcode(dataReader);
				} else {
					tbl_scsDocument_Barcodeins = null;
				}
			}
			scon.Close();
			return tbl_scsDocument_Barcodeins;
		}

        public static List<tbl_scsDocument_Barcode> SelectAll()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_scsDocument_BarcodeSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<tbl_scsDocument_Barcode> tbl_scsDocument_BarcodeList = new List<tbl_scsDocument_Barcode>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_scsDocument_Barcode tbl_scsDocument_Barcode = Maketbl_scsDocument_Barcode(dataReader);
                    tbl_scsDocument_BarcodeList.Add(tbl_scsDocument_Barcode);
                }
            }
            scon.Close();
            return tbl_scsDocument_BarcodeList;
        }

		/// <summary>
		/// Selects all records from the tbl_scsDocument_Barcode table by a foreign key.
		/// </summary>
		public static List<tbl_scsDocument_Barcode> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDocument_BarcodeSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsDocument_Barcode> tbl_scsDocument_BarcodeList = new List<tbl_scsDocument_Barcode>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDocument_Barcode tbl_scsDocument_Barcode = Maketbl_scsDocument_Barcode(dataReader);
					tbl_scsDocument_BarcodeList.Add(tbl_scsDocument_Barcode);
				}
			}
			scon.Close();
			return tbl_scsDocument_BarcodeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDocument_Barcode table by a foreign key.
		/// </summary>
		public static List<tbl_scsDocument_Barcode> SelectAllByBarcode_ID(int barcode_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDocument_BarcodeSelectAllByBarcode_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
				List<tbl_scsDocument_Barcode> tbl_scsDocument_BarcodeList = new List<tbl_scsDocument_Barcode>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDocument_Barcode tbl_scsDocument_Barcode = Maketbl_scsDocument_Barcode(dataReader);
					tbl_scsDocument_BarcodeList.Add(tbl_scsDocument_Barcode);
				}
			}
			scon.Close();
			return tbl_scsDocument_BarcodeList;
		}

        
		
		/// <summary>
		/// Creates a new instance of the tbl_scsDocument_Barcode class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsDocument_Barcode Maketbl_scsDocument_Barcode(SqlDataReader dataReader) {
			tbl_scsDocument_Barcode tbl_scsDocument_Barcode = new tbl_scsDocument_Barcode();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsDocument_Barcode.Transaction_Code = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsDocument_Barcode.Transaction_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsDocument_Barcode.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsDocument_Barcode.Barcode_ID = dataReader.GetInt32(3);
			}

			return tbl_scsDocument_Barcode;
		}
		/// <summary>
		/// This makes tbl_scsDocument_Barcode datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsDocument_Barcode object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsDocument_Barcode  tbl_scsDocument_Barcode   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_transaction_Code = new DataColumn("transaction_Code" , typeof(string));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_barcode_ID = new DataColumn("barcode_ID" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_transaction_Code,col_transaction_ID,col_item_ID,col_barcode_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsDocument_Barcode datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsDocument_Barcode object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsDocument_Barcode user) {
		DataRow drow = dt.NewRow();
		
			drow["transaction_Code"] = user.transaction_Code;
			drow["transaction_ID"] = user.transaction_ID;
			drow["item_ID"] = user.item_ID;
			drow["barcode_ID"] = user.barcode_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
