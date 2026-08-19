using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasPickingNote_Detail {
		#region Fields
		private int line_No;
		private string pickingNote_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string customerOrder_ID;
		private decimal qty;
		private decimal qtySettle;
		private decimal qtyPicked;
		private decimal qtyReturned;
		private decimal weight;
		private decimal weightSettle;
		private decimal weightPicked;
		private decimal weightReturned;
		private string remark;
		private bool isWeightCalculation;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasPickingNote_Detail class.
		/// </summary>
		public tbl_sasPickingNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasPickingNote_Detail class.
		/// </summary>
		public tbl_sasPickingNote_Detail(int line_No, string pickingNote_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string customerOrder_ID, decimal qty, decimal qtySettle, decimal qtyPicked, decimal qtyReturned, decimal weight, decimal weightSettle, decimal weightPicked, decimal weightReturned, string remark, bool isWeightCalculation) {
			this.line_No = line_No;
			this.pickingNote_ID = pickingNote_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.customerOrder_ID = customerOrder_ID;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.qtyPicked = qtyPicked;
			this.qtyReturned = qtyReturned;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.weightPicked = weightPicked;
			this.weightReturned = weightReturned;
			this.remark = remark;
			this.isWeightCalculation = isWeightCalculation;
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
		/// Gets or sets the PickingNote_ID value.
		/// </summary>
		public string PickingNote_ID {
			get { return pickingNote_ID; }
			set { pickingNote_ID = value; }
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
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle value.
		/// </summary>
		public decimal QtySettle {
			get { return qtySettle; }
			set { qtySettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyPicked value.
		/// </summary>
		public decimal QtyPicked {
			get { return qtyPicked; }
			set { qtyPicked = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyReturned value.
		/// </summary>
		public decimal QtyReturned {
			get { return qtyReturned; }
			set { qtyReturned = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightSettle value.
		/// </summary>
		public decimal WeightSettle {
			get { return weightSettle; }
			set { weightSettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightPicked value.
		/// </summary>
		public decimal WeightPicked {
			get { return weightPicked; }
			set { weightPicked = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightReturned value.
		/// </summary>
		public decimal WeightReturned {
			get { return weightReturned; }
			set { weightReturned = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public bool IsWeightCalculation {
			get { return isWeightCalculation; }
			set { isWeightCalculation = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasPickingNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pickingNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtyPicked", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtyReturned", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPicked", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightReturned", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pickingNote_ID"].Value = pickingNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@qtyPicked"].Value = qtyPicked;
			scom.Parameters["@qtyReturned"].Value = qtyReturned;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@weightPicked"].Value = weightPicked;
			scom.Parameters["@weightReturned"].Value = weightReturned;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasPickingNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pickingNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtyPicked", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtyReturned", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPicked", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightReturned", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pickingNote_ID"].Value = pickingNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@qtyPicked"].Value = qtyPicked;
			scom.Parameters["@qtyReturned"].Value = qtyReturned;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@weightPicked"].Value = weightPicked;
			scom.Parameters["@weightReturned"].Value = weightReturned;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasPickingNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pickingNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@pickingNote_ID"].Value = pickingNote_ID;
 
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
		/// Selects all records from the tbl_sasPickingNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPickingNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPickingNote_ID(string pickingNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailDeleteAllByPickingNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pickingNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pickingNote_ID"].Value = pickingNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPickingNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPickingNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasPickingNote_Detail table.
		/// </summary>
		public static tbl_sasPickingNote_Detail Select(string pickingNote_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_sasPickingNote_Detail tbl_sasPickingNote_Detailins = new tbl_sasPickingNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pickingNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@pickingNote_ID"].Value = pickingNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasPickingNote_Detailins = Maketbl_sasPickingNote_Detail(dataReader);
				} else {
					tbl_sasPickingNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasPickingNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPickingNote_Detail table.
		/// </summary>
		public static List<tbl_sasPickingNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasPickingNote_Detail> tbl_sasPickingNote_DetailList = new List<tbl_sasPickingNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPickingNote_Detail tbl_sasPickingNote_Detail = Maketbl_sasPickingNote_Detail(dataReader);
					tbl_sasPickingNote_DetailList.Add(tbl_sasPickingNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasPickingNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPickingNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasPickingNote_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_sasPickingNote_Detail> tbl_sasPickingNote_DetailList = new List<tbl_sasPickingNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPickingNote_Detail tbl_sasPickingNote_Detail = Maketbl_sasPickingNote_Detail(dataReader);
					tbl_sasPickingNote_DetailList.Add(tbl_sasPickingNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasPickingNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPickingNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasPickingNote_Detail> SelectAllByPickingNote_ID(string pickingNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailSelectAllByPickingNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pickingNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pickingNote_ID"].Value = pickingNote_ID;
				List<tbl_sasPickingNote_Detail> tbl_sasPickingNote_DetailList = new List<tbl_sasPickingNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPickingNote_Detail tbl_sasPickingNote_Detail = Maketbl_sasPickingNote_Detail(dataReader);
					tbl_sasPickingNote_DetailList.Add(tbl_sasPickingNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasPickingNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPickingNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasPickingNote_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_sasPickingNote_Detail> tbl_sasPickingNote_DetailList = new List<tbl_sasPickingNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPickingNote_Detail tbl_sasPickingNote_Detail = Maketbl_sasPickingNote_Detail(dataReader);
					tbl_sasPickingNote_DetailList.Add(tbl_sasPickingNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasPickingNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPickingNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasPickingNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPickingNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasPickingNote_Detail> tbl_sasPickingNote_DetailList = new List<tbl_sasPickingNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPickingNote_Detail tbl_sasPickingNote_Detail = Maketbl_sasPickingNote_Detail(dataReader);
					tbl_sasPickingNote_DetailList.Add(tbl_sasPickingNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasPickingNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasPickingNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasPickingNote_Detail Maketbl_sasPickingNote_Detail(SqlDataReader dataReader) {
			tbl_sasPickingNote_Detail tbl_sasPickingNote_Detail = new tbl_sasPickingNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasPickingNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasPickingNote_Detail.PickingNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasPickingNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasPickingNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasPickingNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasPickingNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasPickingNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasPickingNote_Detail.CustomerOrder_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasPickingNote_Detail.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasPickingNote_Detail.QtySettle = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasPickingNote_Detail.QtyPicked = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasPickingNote_Detail.QtyReturned = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasPickingNote_Detail.Weight = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasPickingNote_Detail.WeightSettle = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasPickingNote_Detail.WeightPicked = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasPickingNote_Detail.WeightReturned = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasPickingNote_Detail.Remark = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasPickingNote_Detail.IsWeightCalculation = dataReader.GetBoolean(17);
			}

			return tbl_sasPickingNote_Detail;
		}
		/// <summary>
		/// This makes tbl_sasPickingNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasPickingNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasPickingNote_Detail  tbl_sasPickingNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_pickingNote_ID = new DataColumn("pickingNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_qtyPicked = new DataColumn("qtyPicked" , typeof(decimal));
			DataColumn col_qtyReturned = new DataColumn("qtyReturned" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_weightPicked = new DataColumn("weightPicked" , typeof(decimal));
			DataColumn col_weightReturned = new DataColumn("weightReturned" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_pickingNote_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_customerOrder_ID,col_qty,col_qtySettle,col_qtyPicked,col_qtyReturned,col_weight,col_weightSettle,col_weightPicked,col_weightReturned,col_remark,col_isWeightCalculation,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasPickingNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasPickingNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasPickingNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["pickingNote_ID"] = user.pickingNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["qtyPicked"] = user.qtyPicked;
			drow["qtyReturned"] = user.qtyReturned;
			drow["weight"] = user.weight;
			drow["weightSettle"] = user.weightSettle;
			drow["weightPicked"] = user.weightPicked;
			drow["weightReturned"] = user.weightReturned;
			drow["remark"] = user.remark;
			drow["isWeightCalculation"] = user.isWeightCalculation;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
