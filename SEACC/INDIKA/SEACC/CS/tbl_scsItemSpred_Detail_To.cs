using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsItemSpred_Detail_To {
		#region Fields
		private int line_No;
		private string itemSpred_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string store_ID;
		private decimal qty;
		private decimal weight;
		private decimal weightDamaged;
		private decimal weightRejection;
		private decimal meter;
		private string remark;
		private decimal weightedAvgCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsItemSpred_Detail_To class.
		/// </summary>
		public tbl_scsItemSpred_Detail_To() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsItemSpred_Detail_To class.
		/// </summary>
		public tbl_scsItemSpred_Detail_To(int line_No, string itemSpred_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string store_ID, decimal qty, decimal weight, decimal weightDamaged, decimal weightRejection, decimal meter, string remark, decimal weightedAvgCost) {
			this.line_No = line_No;
			this.itemSpred_ID = itemSpred_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.store_ID = store_ID;
			this.qty = qty;
			this.weight = weight;
			this.weightDamaged = weightDamaged;
			this.weightRejection = weightRejection;
			this.meter = meter;
			this.remark = remark;
			this.weightedAvgCost = weightedAvgCost;
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
		/// Gets or sets the ItemSpred_ID value.
		/// </summary>
		public string ItemSpred_ID {
			get { return itemSpred_ID; }
			set { itemSpred_ID = value; }
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
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
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
		/// Gets or sets the WeightDamaged value.
		/// </summary>
		public decimal WeightDamaged {
			get { return weightDamaged; }
			set { weightDamaged = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightRejection value.
		/// </summary>
		public decimal WeightRejection {
			get { return weightRejection; }
			set { weightRejection = value; }
		}
		
		/// <summary>
		/// Gets or sets the Meter value.
		/// </summary>
		public decimal Meter {
			get { return meter; }
			set { meter = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightedAvgCost value.
		/// </summary>
		public decimal WeightedAvgCost {
			get { return weightedAvgCost; }
			set { weightedAvgCost = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsItemSpred_Detail_To table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@itemSpred_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightDamaged", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightRejection", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@itemSpred_ID"].Value = itemSpred_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightDamaged"].Value = weightDamaged;
			scom.Parameters["@weightRejection"].Value = weightRejection;
			scom.Parameters["@meter"].Value = meter;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsItemSpred_Detail_To table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@itemSpred_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightDamaged", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightRejection", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@itemSpred_ID"].Value = itemSpred_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightDamaged"].Value = weightDamaged;
			scom.Parameters["@weightRejection"].Value = weightRejection;
			scom.Parameters["@meter"].Value = meter;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsItemSpred_Detail_To table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@itemSpred_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@itemSpred_ID"].Value = itemSpred_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSpred_ID(string itemSpred_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToDeleteAllByItemSpred_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@itemSpred_ID", SqlDbType.VarChar,20);
			scom.Parameters["@itemSpred_ID"].Value = itemSpred_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        /// <summary>
        /// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
        /// </summary>
        public static void DeleteAllByStore_ID(string store_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToDeleteAllByStore_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@store_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@store_ID"].Value = store_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the tbl_scsItemSpred_Detail_To table.
        /// </summary>
        public static tbl_scsItemSpred_Detail_To Select(int line_No_Incoming, string itemSpred_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsItemSpred_Detail_To tbl_scsItemSpred_Detail_Toins = new tbl_scsItemSpred_Detail_To();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@itemSpred_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@itemSpred_ID"].Value = itemSpred_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsItemSpred_Detail_Toins = Maketbl_scsItemSpred_Detail_To(dataReader);
				} else {
					tbl_scsItemSpred_Detail_Toins = null;
				}
			}
			scon.Close();
			return tbl_scsItemSpred_Detail_Toins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table.
		/// </summary>
		public static List<tbl_scsItemSpred_Detail_To> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsItemSpred_Detail_To> tbl_scsItemSpred_Detail_ToList = new List<tbl_scsItemSpred_Detail_To>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsItemSpred_Detail_To tbl_scsItemSpred_Detail_To = Maketbl_scsItemSpred_Detail_To(dataReader);
					tbl_scsItemSpred_Detail_ToList.Add(tbl_scsItemSpred_Detail_To);
				}
			}
			scon.Close();
			return tbl_scsItemSpred_Detail_ToList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
		/// </summary>
		public static List<tbl_scsItemSpred_Detail_To> SelectAllByItemSpred_ID(string itemSpred_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToSelectAllByItemSpred_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSpred_ID", SqlDbType.VarChar,20);
			scom.Parameters["@itemSpred_ID"].Value = itemSpred_ID;
				List<tbl_scsItemSpred_Detail_To> tbl_scsItemSpred_Detail_ToList = new List<tbl_scsItemSpred_Detail_To>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsItemSpred_Detail_To tbl_scsItemSpred_Detail_To = Maketbl_scsItemSpred_Detail_To(dataReader);
					tbl_scsItemSpred_Detail_ToList.Add(tbl_scsItemSpred_Detail_To);
				}
			}
			scon.Close();
			return tbl_scsItemSpred_Detail_ToList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
		/// </summary>
		public static List<tbl_scsItemSpred_Detail_To> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsItemSpred_Detail_To> tbl_scsItemSpred_Detail_ToList = new List<tbl_scsItemSpred_Detail_To>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsItemSpred_Detail_To tbl_scsItemSpred_Detail_To = Maketbl_scsItemSpred_Detail_To(dataReader);
					tbl_scsItemSpred_Detail_ToList.Add(tbl_scsItemSpred_Detail_To);
				}
			}
			scon.Close();
			return tbl_scsItemSpred_Detail_ToList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
		/// </summary>
		public static List<tbl_scsItemSpred_Detail_To> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_scsItemSpred_Detail_To> tbl_scsItemSpred_Detail_ToList = new List<tbl_scsItemSpred_Detail_To>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsItemSpred_Detail_To tbl_scsItemSpred_Detail_To = Maketbl_scsItemSpred_Detail_To(dataReader);
					tbl_scsItemSpred_Detail_ToList.Add(tbl_scsItemSpred_Detail_To);
				}
			}
			scon.Close();
			return tbl_scsItemSpred_Detail_ToList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
		/// </summary>
		public static List<tbl_scsItemSpred_Detail_To> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_scsItemSpred_Detail_To> tbl_scsItemSpred_Detail_ToList = new List<tbl_scsItemSpred_Detail_To>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsItemSpred_Detail_To tbl_scsItemSpred_Detail_To = Maketbl_scsItemSpred_Detail_To(dataReader);
					tbl_scsItemSpred_Detail_ToList.Add(tbl_scsItemSpred_Detail_To);
				}
			}
			scon.Close();
			return tbl_scsItemSpred_Detail_ToList;
		}

        /// <summary>
        /// Selects all records from the tbl_scsItemSpred_Detail_To table by a foreign key.
        /// </summary>
        public static List<tbl_scsItemSpred_Detail_To> SelectAllByStore_ID(string store_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_scsItemSpred_Detail_ToSelectAllByStore_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@store_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@store_ID"].Value = store_ID;
            List<tbl_scsItemSpred_Detail_To> tbl_scsItemSpred_Detail_ToList = new List<tbl_scsItemSpred_Detail_To>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_scsItemSpred_Detail_To tbl_scsItemSpred_Detail_To = Maketbl_scsItemSpred_Detail_To(dataReader);
                    tbl_scsItemSpred_Detail_ToList.Add(tbl_scsItemSpred_Detail_To);
                }
            }
            scon.Close();
            return tbl_scsItemSpred_Detail_ToList;
        }

        /// <summary>
        /// Creates a new instance of the tbl_scsItemSpred_Detail_To class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_scsItemSpred_Detail_To Maketbl_scsItemSpred_Detail_To(SqlDataReader dataReader) {
			tbl_scsItemSpred_Detail_To tbl_scsItemSpred_Detail_To = new tbl_scsItemSpred_Detail_To();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsItemSpred_Detail_To.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsItemSpred_Detail_To.ItemSpred_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsItemSpred_Detail_To.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsItemSpred_Detail_To.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsItemSpred_Detail_To.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsItemSpred_Detail_To.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsItemSpred_Detail_To.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsItemSpred_Detail_To.Store_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsItemSpred_Detail_To.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsItemSpred_Detail_To.Weight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsItemSpred_Detail_To.WeightDamaged = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsItemSpred_Detail_To.WeightRejection = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsItemSpred_Detail_To.Meter = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsItemSpred_Detail_To.Remark = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsItemSpred_Detail_To.WeightedAvgCost = dataReader.GetDecimal(14);
			}

			return tbl_scsItemSpred_Detail_To;
		}
		/// <summary>
		/// This makes tbl_scsItemSpred_Detail_To datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsItemSpred_Detail_To object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsItemSpred_Detail_To  tbl_scsItemSpred_Detail_To   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_itemSpred_ID = new DataColumn("itemSpred_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightDamaged = new DataColumn("weightDamaged" , typeof(decimal));
			DataColumn col_weightRejection = new DataColumn("weightRejection" , typeof(decimal));
			DataColumn col_meter = new DataColumn("meter" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_itemSpred_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_store_ID,col_qty,col_weight,col_weightDamaged,col_weightRejection,col_meter,col_remark,col_weightedAvgCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsItemSpred_Detail_To datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsItemSpred_Detail_To object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsItemSpred_Detail_To user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["itemSpred_ID"] = user.itemSpred_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["store_ID"] = user.store_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["weightDamaged"] = user.weightDamaged;
			drow["weightRejection"] = user.weightRejection;
			drow["meter"] = user.meter;
			drow["remark"] = user.remark;
			drow["weightedAvgCost"] = user.weightedAvgCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
