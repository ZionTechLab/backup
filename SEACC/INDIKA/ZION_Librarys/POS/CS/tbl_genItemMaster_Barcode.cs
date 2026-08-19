using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_Barcode {
		#region Fields
		private int barcode_ID;
		private string item_ID;
		private string serialNo1;
		private string serialNo2;
		private string batchNo;
		private DateTime expiry_OEM;
		private DateTime expiry_Local;
		private bool isDelivered;
		private bool isDamaged;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Barcode class.
		/// </summary>
		public tbl_genItemMaster_Barcode() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Barcode class.
		/// </summary>
		public tbl_genItemMaster_Barcode(int barcode_ID, string item_ID, string serialNo1, string serialNo2, string batchNo, DateTime expiry_OEM, DateTime expiry_Local, bool isDelivered, bool isDamaged, string remarks) {
			this.barcode_ID = barcode_ID;
			this.item_ID = item_ID;
			this.serialNo1 = serialNo1;
			this.serialNo2 = serialNo2;
			this.batchNo = batchNo;
			this.expiry_OEM = expiry_OEM;
			this.expiry_Local = expiry_Local;
			this.isDelivered = isDelivered;
			this.isDamaged = isDamaged;
			this.remarks = remarks;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Barcode_ID value.
		/// </summary>
		public int Barcode_ID {
			get { return barcode_ID; }
			set { barcode_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo1 value.
		/// </summary>
		public string SerialNo1 {
			get { return serialNo1; }
			set { serialNo1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo2 value.
		/// </summary>
		public string SerialNo2 {
			get { return serialNo2; }
			set { serialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the BatchNo value.
		/// </summary>
		public string BatchNo {
			get { return batchNo; }
			set { batchNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Expiry_OEM value.
		/// </summary>
		public DateTime Expiry_OEM {
			get { return expiry_OEM; }
			set { expiry_OEM = value; }
		}
		
		/// <summary>
		/// Gets or sets the Expiry_Local value.
		/// </summary>
		public DateTime Expiry_Local {
			get { return expiry_Local; }
			set { expiry_Local = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelivered value.
		/// </summary>
		public bool IsDelivered {
			get { return isDelivered; }
			set { isDelivered = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDamaged value.
		/// </summary>
		public bool IsDamaged {
			get { return isDamaged; }
			set { isDamaged = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_Barcode table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_BarcodeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@serialNo1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@expiry_OEM", SqlDbType.DateTime,8);
			scom.Parameters.Add("@expiry_Local", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDamaged", SqlDbType.Bit,1);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
 
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@serialNo1"].Value = serialNo1;
			scom.Parameters["@serialNo2"].Value = serialNo2;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@expiry_OEM"].Value = expiry_OEM;
			scom.Parameters["@expiry_Local"].Value = expiry_Local;
			scom.Parameters["@isDelivered"].Value = isDelivered;
			scom.Parameters["@isDamaged"].Value = isDamaged;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_Barcode table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_BarcodeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@serialNo1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@expiry_OEM", SqlDbType.DateTime,8);
			scom.Parameters.Add("@expiry_Local", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDamaged", SqlDbType.Bit,1);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@serialNo1"].Value = serialNo1;
			scom.Parameters["@serialNo2"].Value = serialNo2;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@expiry_OEM"].Value = expiry_OEM;
			scom.Parameters["@expiry_Local"].Value = expiry_Local;
			scom.Parameters["@isDelivered"].Value = isDelivered;
			scom.Parameters["@isDamaged"].Value = isDamaged;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_Barcode table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_BarcodeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Barcode table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_BarcodeDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_Barcode table.
		/// </summary>
		public static tbl_genItemMaster_Barcode Select(int barcode_ID_Incoming){

			tbl_genItemMaster_Barcode tbl_genItemMaster_Barcodeins = new tbl_genItemMaster_Barcode();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_BarcodeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_Barcodeins = Maketbl_genItemMaster_Barcode(dataReader);
				} else {
					tbl_genItemMaster_Barcodeins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_Barcodeins;
		}
        public static tbl_genItemMaster_Barcode Select(string item_ID,string serialNo1)
        {

            tbl_genItemMaster_Barcode tbl_genItemMaster_Barcodeins = new tbl_genItemMaster_Barcode();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_genItemMaster_BarcodeSelectByserialNo1", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@item_ID"].Value = item_ID;
            scom.Parameters.Add("@serialNo1", SqlDbType.VarChar, 20);
            scom.Parameters["@serialNo1"].Value = serialNo1;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_genItemMaster_Barcodeins = Maketbl_genItemMaster_Barcode(dataReader);
                }
                else
                {
                    tbl_genItemMaster_Barcodeins = null;
                }
            }
            scon.Close();
            return tbl_genItemMaster_Barcodeins;
        }
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Barcode table.
		/// </summary>
		public static List<tbl_genItemMaster_Barcode> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_BarcodeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_Barcode> tbl_genItemMaster_BarcodeList = new List<tbl_genItemMaster_Barcode>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Barcode tbl_genItemMaster_Barcode = Maketbl_genItemMaster_Barcode(dataReader);
					tbl_genItemMaster_BarcodeList.Add(tbl_genItemMaster_Barcode);
				}
			}
			scon.Close();
			return tbl_genItemMaster_BarcodeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Barcode table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Barcode> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_BarcodeSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_Barcode> tbl_genItemMaster_BarcodeList = new List<tbl_genItemMaster_Barcode>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Barcode tbl_genItemMaster_Barcode = Maketbl_genItemMaster_Barcode(dataReader);
					tbl_genItemMaster_BarcodeList.Add(tbl_genItemMaster_Barcode);
				}
			}
			scon.Close();
			return tbl_genItemMaster_BarcodeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_Barcode class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_Barcode Maketbl_genItemMaster_Barcode(SqlDataReader dataReader) {
			tbl_genItemMaster_Barcode tbl_genItemMaster_Barcode = new tbl_genItemMaster_Barcode();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_Barcode.Barcode_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_Barcode.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_Barcode.SerialNo1 = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_Barcode.SerialNo2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_Barcode.BatchNo = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_Barcode.Expiry_OEM = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_Barcode.Expiry_Local = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_Barcode.IsDelivered = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_Barcode.IsDamaged = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster_Barcode.Remarks = dataReader.GetString(9);
			}

			return tbl_genItemMaster_Barcode;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_Barcode datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Barcode object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_Barcode  tbl_genItemMaster_Barcode   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_barcode_ID = new DataColumn("barcode_ID" , typeof(int));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_serialNo1 = new DataColumn("serialNo1" , typeof(string));
			DataColumn col_serialNo2 = new DataColumn("serialNo2" , typeof(string));
			DataColumn col_batchNo = new DataColumn("batchNo" , typeof(string));
			DataColumn col_expiry_OEM = new DataColumn("expiry_OEM" , typeof(DateTime));
			DataColumn col_expiry_Local = new DataColumn("expiry_Local" , typeof(DateTime));
			DataColumn col_isDelivered = new DataColumn("isDelivered" , typeof(bool));
			DataColumn col_isDamaged = new DataColumn("isDamaged" , typeof(bool));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_barcode_ID,col_item_ID,col_serialNo1,col_serialNo2,col_batchNo,col_expiry_OEM,col_expiry_Local,col_isDelivered,col_isDamaged,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_Barcode datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Barcode object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_Barcode user) {
		DataRow drow = dt.NewRow();
		
			drow["barcode_ID"] = user.barcode_ID;
			drow["item_ID"] = user.item_ID;
			drow["serialNo1"] = user.serialNo1;
			drow["serialNo2"] = user.serialNo2;
			drow["batchNo"] = user.batchNo;
			drow["expiry_OEM"] = user.expiry_OEM;
			drow["expiry_Local"] = user.expiry_Local;
			drow["isDelivered"] = user.isDelivered;
			drow["isDamaged"] = user.isDamaged;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
