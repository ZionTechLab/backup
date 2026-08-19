using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_proWorkInProgress_Batch_InputItem {
		#region Fields
		private int line_No;
		private string productionJob_ID;
		private string workInProgress_ID;
		private string batch_ID;
		private string section_ID;
		private string machine_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal qtyWastage;
		private decimal weightInput;
		private decimal weightWastage;
		private decimal weightExcess;
		private decimal weightUsed;
		private string length_uomID;
		private decimal length;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_proWorkInProgress_Batch_InputItem class.
		/// </summary>
		public tbl_proWorkInProgress_Batch_InputItem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_proWorkInProgress_Batch_InputItem class.
		/// </summary>
		public tbl_proWorkInProgress_Batch_InputItem(int line_No, string productionJob_ID, string workInProgress_ID, string batch_ID, string section_ID, string machine_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal qtyWastage, decimal weightInput, decimal weightWastage, decimal weightExcess, decimal weightUsed, string length_uomID, decimal length) {
			this.line_No = line_No;
			this.productionJob_ID = productionJob_ID;
			this.workInProgress_ID = workInProgress_ID;
			this.batch_ID = batch_ID;
			this.section_ID = section_ID;
			this.machine_ID = machine_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.qtyWastage = qtyWastage;
			this.weightInput = weightInput;
			this.weightWastage = weightWastage;
			this.weightExcess = weightExcess;
			this.weightUsed = weightUsed;
			this.length_uomID = length_uomID;
			this.length = length;
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
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Batch_ID value.
		/// </summary>
		public string Batch_ID {
			get { return batch_ID; }
			set { batch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
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
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyWastage value.
		/// </summary>
		public decimal QtyWastage {
			get { return qtyWastage; }
			set { qtyWastage = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightInput value.
		/// </summary>
		public decimal WeightInput {
			get { return weightInput; }
			set { weightInput = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightWastage value.
		/// </summary>
		public decimal WeightWastage {
			get { return weightWastage; }
			set { weightWastage = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightExcess value.
		/// </summary>
		public decimal WeightExcess {
			get { return weightExcess; }
			set { weightExcess = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightUsed value.
		/// </summary>
		public decimal WeightUsed {
			get { return weightUsed; }
			set { weightUsed = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length_uomID value.
		/// </summary>
		public string Length_uomID {
			get { return length_uomID; }
			set { length_uomID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public decimal Length {
			get { return length; }
			set { length = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_proWorkInProgress_Batch_InputItem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtyWastage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightInput", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightWastage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightExcess", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightUsed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Length_uomID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtyWastage"].Value = qtyWastage;
			scom.Parameters["@weightInput"].Value = weightInput;
			scom.Parameters["@weightWastage"].Value = weightWastage;
			scom.Parameters["@weightExcess"].Value = weightExcess;
			scom.Parameters["@weightUsed"].Value = weightUsed;
			scom.Parameters["@Length_uomID"].Value = length_uomID;
			scom.Parameters["@length"].Value = length;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_proWorkInProgress_Batch_InputItem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtyWastage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightInput", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightWastage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightExcess", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightUsed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Length_uomID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtyWastage"].Value = qtyWastage;
			scom.Parameters["@weightInput"].Value = weightInput;
			scom.Parameters["@weightWastage"].Value = weightWastage;
			scom.Parameters["@weightExcess"].Value = weightExcess;
			scom.Parameters["@weightUsed"].Value = weightUsed;
			scom.Parameters["@Length_uomID"].Value = length_uomID;
			scom.Parameters["@length"].Value = length;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_proWorkInProgress_Batch_InputItem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scom.Parameters["@batch_ID"].Value = batch_ID;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_InputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByWorkInProgress_ID_Batch_ID_Section_ID_Machine_ID(string workInProgress_ID, string batch_ID, string section_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemDeleteAllByWorkInProgress_ID_Batch_ID_Section_ID_Machine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_InputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemDeleteAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_proWorkInProgress_Batch_InputItem table.
		/// </summary>
		public static tbl_proWorkInProgress_Batch_InputItem Select(string workInProgress_ID_Incoming, string batch_ID_Incoming, string section_ID_Incoming, string machine_ID_Incoming, string item_ID_Incoming){

			tbl_proWorkInProgress_Batch_InputItem tbl_proWorkInProgress_Batch_InputItemins = new tbl_proWorkInProgress_Batch_InputItem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID_Incoming;
			scom.Parameters["@batch_ID"].Value = batch_ID_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_proWorkInProgress_Batch_InputItemins = Maketbl_proWorkInProgress_Batch_InputItem(dataReader);
				} else {
					tbl_proWorkInProgress_Batch_InputItemins = null;
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batch_InputItemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_InputItem table.
		/// </summary>
		public static List<tbl_proWorkInProgress_Batch_InputItem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_proWorkInProgress_Batch_InputItem> tbl_proWorkInProgress_Batch_InputItemList = new List<tbl_proWorkInProgress_Batch_InputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proWorkInProgress_Batch_InputItem tbl_proWorkInProgress_Batch_InputItem = Maketbl_proWorkInProgress_Batch_InputItem(dataReader);
					tbl_proWorkInProgress_Batch_InputItemList.Add(tbl_proWorkInProgress_Batch_InputItem);
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batch_InputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_InputItem table by a foreign key.
		/// </summary>
		public static List<tbl_proWorkInProgress_Batch_InputItem> SelectAllByWorkInProgress_ID_Batch_ID_Section_ID_Machine_ID(string workInProgress_ID, string batch_ID, string section_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemSelectAllByWorkInProgress_ID_Batch_ID_Section_ID_Machine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
				List<tbl_proWorkInProgress_Batch_InputItem> tbl_proWorkInProgress_Batch_InputItemList = new List<tbl_proWorkInProgress_Batch_InputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proWorkInProgress_Batch_InputItem tbl_proWorkInProgress_Batch_InputItem = Maketbl_proWorkInProgress_Batch_InputItem(dataReader);
					tbl_proWorkInProgress_Batch_InputItemList.Add(tbl_proWorkInProgress_Batch_InputItem);
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batch_InputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_InputItem table by a foreign key.
		/// </summary>
		public static List<tbl_proWorkInProgress_Batch_InputItem> SelectAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_InputItemSelectAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
				List<tbl_proWorkInProgress_Batch_InputItem> tbl_proWorkInProgress_Batch_InputItemList = new List<tbl_proWorkInProgress_Batch_InputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proWorkInProgress_Batch_InputItem tbl_proWorkInProgress_Batch_InputItem = Maketbl_proWorkInProgress_Batch_InputItem(dataReader);
					tbl_proWorkInProgress_Batch_InputItemList.Add(tbl_proWorkInProgress_Batch_InputItem);
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batch_InputItemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_proWorkInProgress_Batch_InputItem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_proWorkInProgress_Batch_InputItem Maketbl_proWorkInProgress_Batch_InputItem(SqlDataReader dataReader) {
			tbl_proWorkInProgress_Batch_InputItem tbl_proWorkInProgress_Batch_InputItem = new tbl_proWorkInProgress_Batch_InputItem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_proWorkInProgress_Batch_InputItem.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_proWorkInProgress_Batch_InputItem.ProductionJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_proWorkInProgress_Batch_InputItem.WorkInProgress_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_proWorkInProgress_Batch_InputItem.Batch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_proWorkInProgress_Batch_InputItem.Section_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_proWorkInProgress_Batch_InputItem.Machine_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_proWorkInProgress_Batch_InputItem.Item_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_proWorkInProgress_Batch_InputItem.ItemSubCategory_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_proWorkInProgress_Batch_InputItem.ItemSubCategory2_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_proWorkInProgress_Batch_InputItem.ItemSerialNo = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_proWorkInProgress_Batch_InputItem.ItemSerialNo2 = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_proWorkInProgress_Batch_InputItem.Qty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_proWorkInProgress_Batch_InputItem.QtyWastage = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_proWorkInProgress_Batch_InputItem.WeightInput = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_proWorkInProgress_Batch_InputItem.WeightWastage = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_proWorkInProgress_Batch_InputItem.WeightExcess = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_proWorkInProgress_Batch_InputItem.WeightUsed = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_proWorkInProgress_Batch_InputItem.Length_uomID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_proWorkInProgress_Batch_InputItem.Length = dataReader.GetDecimal(18);
			}

			return tbl_proWorkInProgress_Batch_InputItem;
		}
		/// <summary>
		/// This makes tbl_proWorkInProgress_Batch_InputItem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_proWorkInProgress_Batch_InputItem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_proWorkInProgress_Batch_InputItem  tbl_proWorkInProgress_Batch_InputItem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_batch_ID = new DataColumn("batch_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtyWastage = new DataColumn("qtyWastage" , typeof(decimal));
			DataColumn col_weightInput = new DataColumn("weightInput" , typeof(decimal));
			DataColumn col_weightWastage = new DataColumn("weightWastage" , typeof(decimal));
			DataColumn col_weightExcess = new DataColumn("weightExcess" , typeof(decimal));
			DataColumn col_weightUsed = new DataColumn("weightUsed" , typeof(decimal));
			DataColumn col_Length_uomID = new DataColumn("Length_uomID" , typeof(string));
			DataColumn col_length = new DataColumn("length" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_productionJob_ID,col_workInProgress_ID,col_batch_ID,col_section_ID,col_machine_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_qtyWastage,col_weightInput,col_weightWastage,col_weightExcess,col_weightUsed,col_Length_uomID,col_length,});		return dt;
		}
		/// <summary>
		/// This fills tbl_proWorkInProgress_Batch_InputItem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_proWorkInProgress_Batch_InputItem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_proWorkInProgress_Batch_InputItem user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["batch_ID"] = user.batch_ID;
			drow["section_ID"] = user.section_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["qtyWastage"] = user.qtyWastage;
			drow["weightInput"] = user.weightInput;
			drow["weightWastage"] = user.weightWastage;
			drow["weightExcess"] = user.weightExcess;
			drow["weightUsed"] = user.weightUsed;
			drow["Length_uomID"] = user.Length_uomID;
			drow["length"] = user.length;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
