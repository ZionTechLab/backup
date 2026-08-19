using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_proWorkInProgress_Batch_OutputItem {
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
		private decimal weightFinished;
		private decimal weightWastage;
		private decimal weightOutput;
		private string length_uomID;
		private decimal length;
		private decimal cylinderSize;
		private decimal counter;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_proWorkInProgress_Batch_OutputItem class.
		/// </summary>
		public tbl_proWorkInProgress_Batch_OutputItem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_proWorkInProgress_Batch_OutputItem class.
		/// </summary>
		public tbl_proWorkInProgress_Batch_OutputItem(int line_No, string productionJob_ID, string workInProgress_ID, string batch_ID, string section_ID, string machine_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal qtyWastage, decimal weightFinished, decimal weightWastage, decimal weightOutput, string length_uomID, decimal length, decimal cylinderSize, decimal counter) {
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
			this.weightFinished = weightFinished;
			this.weightWastage = weightWastage;
			this.weightOutput = weightOutput;
			this.length_uomID = length_uomID;
			this.length = length;
			this.cylinderSize = cylinderSize;
			this.counter = counter;
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
		/// Gets or sets the WeightFinished value.
		/// </summary>
		public decimal WeightFinished {
			get { return weightFinished; }
			set { weightFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightWastage value.
		/// </summary>
		public decimal WeightWastage {
			get { return weightWastage; }
			set { weightWastage = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightOutput value.
		/// </summary>
		public decimal WeightOutput {
			get { return weightOutput; }
			set { weightOutput = value; }
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
		
		/// <summary>
		/// Gets or sets the CylinderSize value.
		/// </summary>
		public decimal CylinderSize {
			get { return cylinderSize; }
			set { cylinderSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public decimal Counter {
			get { return counter; }
			set { counter = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_proWorkInProgress_Batch_OutputItem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemInsert", scon);
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
			scom.Parameters.Add("@weightFinished", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightWastage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightOutput", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Length_uomID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cylinderSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@counter", SqlDbType.Decimal,9);
 
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
			scom.Parameters["@weightFinished"].Value = weightFinished;
			scom.Parameters["@weightWastage"].Value = weightWastage;
			scom.Parameters["@weightOutput"].Value = weightOutput;
			scom.Parameters["@Length_uomID"].Value = length_uomID;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@cylinderSize"].Value = cylinderSize;
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_proWorkInProgress_Batch_OutputItem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemUpdate", scon);
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
			scom.Parameters.Add("@weightFinished", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightWastage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightOutput", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Length_uomID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cylinderSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@counter", SqlDbType.Decimal,9);
 
 
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
			scom.Parameters["@weightFinished"].Value = weightFinished;
			scom.Parameters["@weightWastage"].Value = weightWastage;
			scom.Parameters["@weightOutput"].Value = weightOutput;
			scom.Parameters["@Length_uomID"].Value = length_uomID;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@cylinderSize"].Value = cylinderSize;
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_proWorkInProgress_Batch_OutputItem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemDelete", scon);
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
		/// Selects all records from the tbl_proWorkInProgress_Batch_OutputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemDeleteAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_OutputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByWorkInProgress_ID_Batch_ID_Section_ID_Machine_ID(string workInProgress_ID, string batch_ID, string section_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemDeleteAllByWorkInProgress_ID_Batch_ID_Section_ID_Machine_ID", scon);
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
		/// Selects a single record from the tbl_proWorkInProgress_Batch_OutputItem table.
		/// </summary>
		public static tbl_proWorkInProgress_Batch_OutputItem Select(string workInProgress_ID_Incoming, string batch_ID_Incoming, string section_ID_Incoming, string machine_ID_Incoming, string item_ID_Incoming){

			tbl_proWorkInProgress_Batch_OutputItem tbl_proWorkInProgress_Batch_OutputItemins = new tbl_proWorkInProgress_Batch_OutputItem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemSelect", scon);
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
					tbl_proWorkInProgress_Batch_OutputItemins = Maketbl_proWorkInProgress_Batch_OutputItem(dataReader);
				} else {
					tbl_proWorkInProgress_Batch_OutputItemins = null;
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batch_OutputItemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_OutputItem table.
		/// </summary>
		public static List<tbl_proWorkInProgress_Batch_OutputItem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_proWorkInProgress_Batch_OutputItem> tbl_proWorkInProgress_Batch_OutputItemList = new List<tbl_proWorkInProgress_Batch_OutputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proWorkInProgress_Batch_OutputItem tbl_proWorkInProgress_Batch_OutputItem = Maketbl_proWorkInProgress_Batch_OutputItem(dataReader);
					tbl_proWorkInProgress_Batch_OutputItemList.Add(tbl_proWorkInProgress_Batch_OutputItem);
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batch_OutputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_OutputItem table by a foreign key.
		/// </summary>
		public static List<tbl_proWorkInProgress_Batch_OutputItem> SelectAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemSelectAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
				List<tbl_proWorkInProgress_Batch_OutputItem> tbl_proWorkInProgress_Batch_OutputItemList = new List<tbl_proWorkInProgress_Batch_OutputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proWorkInProgress_Batch_OutputItem tbl_proWorkInProgress_Batch_OutputItem = Maketbl_proWorkInProgress_Batch_OutputItem(dataReader);
					tbl_proWorkInProgress_Batch_OutputItemList.Add(tbl_proWorkInProgress_Batch_OutputItem);
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batch_OutputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch_OutputItem table by a foreign key.
		/// </summary>
		public static List<tbl_proWorkInProgress_Batch_OutputItem> SelectAllByWorkInProgress_ID_Batch_ID_Section_ID_Machine_ID(string workInProgress_ID, string batch_ID, string section_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_Batch_OutputItemSelectAllByWorkInProgress_ID_Batch_ID_Section_ID_Machine_ID", scon);
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
				List<tbl_proWorkInProgress_Batch_OutputItem> tbl_proWorkInProgress_Batch_OutputItemList = new List<tbl_proWorkInProgress_Batch_OutputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proWorkInProgress_Batch_OutputItem tbl_proWorkInProgress_Batch_OutputItem = Maketbl_proWorkInProgress_Batch_OutputItem(dataReader);
					tbl_proWorkInProgress_Batch_OutputItemList.Add(tbl_proWorkInProgress_Batch_OutputItem);
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batch_OutputItemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_proWorkInProgress_Batch_OutputItem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_proWorkInProgress_Batch_OutputItem Maketbl_proWorkInProgress_Batch_OutputItem(SqlDataReader dataReader) {
			tbl_proWorkInProgress_Batch_OutputItem tbl_proWorkInProgress_Batch_OutputItem = new tbl_proWorkInProgress_Batch_OutputItem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.ProductionJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.WorkInProgress_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Batch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Section_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Machine_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Item_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.ItemSubCategory_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.ItemSubCategory2_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.ItemSerialNo = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.ItemSerialNo2 = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Qty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.QtyWastage = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.WeightFinished = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.WeightWastage = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.WeightOutput = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Length_uomID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Length = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.CylinderSize = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_proWorkInProgress_Batch_OutputItem.Counter = dataReader.GetDecimal(19);
			}

			return tbl_proWorkInProgress_Batch_OutputItem;
		}
		/// <summary>
		/// This makes tbl_proWorkInProgress_Batch_OutputItem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_proWorkInProgress_Batch_OutputItem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_proWorkInProgress_Batch_OutputItem  tbl_proWorkInProgress_Batch_OutputItem   )
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
			DataColumn col_weightFinished = new DataColumn("weightFinished" , typeof(decimal));
			DataColumn col_weightWastage = new DataColumn("weightWastage" , typeof(decimal));
			DataColumn col_weightOutput = new DataColumn("weightOutput" , typeof(decimal));
			DataColumn col_Length_uomID = new DataColumn("Length_uomID" , typeof(string));
			DataColumn col_length = new DataColumn("length" , typeof(decimal));
			DataColumn col_cylinderSize = new DataColumn("cylinderSize" , typeof(decimal));
			DataColumn col_counter = new DataColumn("counter" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_productionJob_ID,col_workInProgress_ID,col_batch_ID,col_section_ID,col_machine_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_qtyWastage,col_weightFinished,col_weightWastage,col_weightOutput,col_Length_uomID,col_length,col_cylinderSize,col_counter,});		return dt;
		}
		/// <summary>
		/// This fills tbl_proWorkInProgress_Batch_OutputItem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_proWorkInProgress_Batch_OutputItem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_proWorkInProgress_Batch_OutputItem user) {
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
			drow["weightFinished"] = user.weightFinished;
			drow["weightWastage"] = user.weightWastage;
			drow["weightOutput"] = user.weightOutput;
			drow["Length_uomID"] = user.Length_uomID;
			drow["length"] = user.length;
			drow["cylinderSize"] = user.cylinderSize;
			drow["counter"] = user.counter;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
