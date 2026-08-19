using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxBatch_Material {
		#region Fields
		private int line_No;
		private int line_No_Sub1;
		private int line_No_Sub2;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string item_ID;
		private string uom_ID;
		private bool isSemiFinishItem;
		private decimal inputQty;
		private bool isWastagePercent;
		private decimal wastagePercent;
		private decimal wastageQty;
		private decimal totalInputQty;
		private string section_ID;
		private decimal smv_TimeMinutes;
		private decimal totalLabour;
		private decimal lowestCost;
		private decimal highestCost;
		private decimal weightedAvgCost;
		private decimal bomCost;
		private int costTypeSelection;
		private decimal cost;
		private bool allowCostEdit;
		private decimal editedCost;
		private bool isSelected;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxBatch_Material class.
		/// </summary>
		public tbl_prodTxBatch_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxBatch_Material class.
		/// </summary>
		public tbl_prodTxBatch_Material(int line_No, int line_No_Sub1, int line_No_Sub2, string prodJob_ID, string prodBatch_ID, string item_ID, string uom_ID, bool isSemiFinishItem, decimal inputQty, bool isWastagePercent, decimal wastagePercent, decimal wastageQty, decimal totalInputQty, string section_ID, decimal smv_TimeMinutes, decimal totalLabour, decimal lowestCost, decimal highestCost, decimal weightedAvgCost, decimal bomCost, int costTypeSelection, decimal cost, bool allowCostEdit, decimal editedCost, bool isSelected) {
			this.line_No = line_No;
			this.line_No_Sub1 = line_No_Sub1;
			this.line_No_Sub2 = line_No_Sub2;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.isSemiFinishItem = isSemiFinishItem;
			this.inputQty = inputQty;
			this.isWastagePercent = isWastagePercent;
			this.wastagePercent = wastagePercent;
			this.wastageQty = wastageQty;
			this.totalInputQty = totalInputQty;
			this.section_ID = section_ID;
			this.smv_TimeMinutes = smv_TimeMinutes;
			this.totalLabour = totalLabour;
			this.lowestCost = lowestCost;
			this.highestCost = highestCost;
			this.weightedAvgCost = weightedAvgCost;
			this.bomCost = bomCost;
			this.costTypeSelection = costTypeSelection;
			this.cost = cost;
			this.allowCostEdit = allowCostEdit;
			this.editedCost = editedCost;
			this.isSelected = isSelected;
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
		/// Gets or sets the Line_No_Sub1 value.
		/// </summary>
		public int Line_No_Sub1 {
			get { return line_No_Sub1; }
			set { line_No_Sub1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No_Sub2 value.
		/// </summary>
		public int Line_No_Sub2 {
			get { return line_No_Sub2; }
			set { line_No_Sub2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdBatch_ID value.
		/// </summary>
		public string ProdBatch_ID {
			get { return prodBatch_ID; }
			set { prodBatch_ID = value; }
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
		/// Gets or sets the IsSemiFinishItem value.
		/// </summary>
		public bool IsSemiFinishItem {
			get { return isSemiFinishItem; }
			set { isSemiFinishItem = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputQty value.
		/// </summary>
		public decimal InputQty {
			get { return inputQty; }
			set { inputQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWastagePercent value.
		/// </summary>
		public bool IsWastagePercent {
			get { return isWastagePercent; }
			set { isWastagePercent = value; }
		}
		
		/// <summary>
		/// Gets or sets the WastagePercent value.
		/// </summary>
		public decimal WastagePercent {
			get { return wastagePercent; }
			set { wastagePercent = value; }
		}
		
		/// <summary>
		/// Gets or sets the WastageQty value.
		/// </summary>
		public decimal WastageQty {
			get { return wastageQty; }
			set { wastageQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalInputQty value.
		/// </summary>
		public decimal TotalInputQty {
			get { return totalInputQty; }
			set { totalInputQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Smv_TimeMinutes value.
		/// </summary>
		public decimal Smv_TimeMinutes {
			get { return smv_TimeMinutes; }
			set { smv_TimeMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalLabour value.
		/// </summary>
		public decimal TotalLabour {
			get { return totalLabour; }
			set { totalLabour = value; }
		}
		
		/// <summary>
		/// Gets or sets the LowestCost value.
		/// </summary>
		public decimal LowestCost {
			get { return lowestCost; }
			set { lowestCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the HighestCost value.
		/// </summary>
		public decimal HighestCost {
			get { return highestCost; }
			set { highestCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightedAvgCost value.
		/// </summary>
		public decimal WeightedAvgCost {
			get { return weightedAvgCost; }
			set { weightedAvgCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the BomCost value.
		/// </summary>
		public decimal BomCost {
			get { return bomCost; }
			set { bomCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostTypeSelection value.
		/// </summary>
		public int CostTypeSelection {
			get { return costTypeSelection; }
			set { costTypeSelection = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost value.
		/// </summary>
		public decimal Cost {
			get { return cost; }
			set { cost = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowCostEdit value.
		/// </summary>
		public bool AllowCostEdit {
			get { return allowCostEdit; }
			set { allowCostEdit = value; }
		}
		
		/// <summary>
		/// Gets or sets the EditedCost value.
		/// </summary>
		public decimal EditedCost {
			get { return editedCost; }
			set { editedCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSelected value.
		/// </summary>
		public bool IsSelected {
			get { return isSelected; }
			set { isSelected = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxBatch_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isSemiFinishItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@inputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isWastagePercent", SqlDbType.Bit,1);
			scom.Parameters.Add("@wastagePercent", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wastageQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalInputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@smv_TimeMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalLabour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lowestCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@highestCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bomCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costTypeSelection", SqlDbType.Int,4);
			scom.Parameters.Add("@cost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowCostEdit", SqlDbType.Bit,1);
			scom.Parameters.Add("@editedCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSelected", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1;
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@isSemiFinishItem"].Value = isSemiFinishItem;
			scom.Parameters["@inputQty"].Value = inputQty;
			scom.Parameters["@isWastagePercent"].Value = isWastagePercent;
			scom.Parameters["@wastagePercent"].Value = wastagePercent;
			scom.Parameters["@wastageQty"].Value = wastageQty;
			scom.Parameters["@totalInputQty"].Value = totalInputQty;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@smv_TimeMinutes"].Value = smv_TimeMinutes;
			scom.Parameters["@totalLabour"].Value = totalLabour;
			scom.Parameters["@lowestCost"].Value = lowestCost;
			scom.Parameters["@highestCost"].Value = highestCost;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
			scom.Parameters["@bomCost"].Value = bomCost;
			scom.Parameters["@costTypeSelection"].Value = costTypeSelection;
			scom.Parameters["@cost"].Value = cost;
			scom.Parameters["@allowCostEdit"].Value = allowCostEdit;
			scom.Parameters["@editedCost"].Value = editedCost;
			scom.Parameters["@isSelected"].Value = isSelected;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxBatch_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isSemiFinishItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@inputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isWastagePercent", SqlDbType.Bit,1);
			scom.Parameters.Add("@wastagePercent", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wastageQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalInputQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@smv_TimeMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalLabour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lowestCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@highestCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bomCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costTypeSelection", SqlDbType.Int,4);
			scom.Parameters.Add("@cost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowCostEdit", SqlDbType.Bit,1);
			scom.Parameters.Add("@editedCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSelected", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1;
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@isSemiFinishItem"].Value = isSemiFinishItem;
			scom.Parameters["@inputQty"].Value = inputQty;
			scom.Parameters["@isWastagePercent"].Value = isWastagePercent;
			scom.Parameters["@wastagePercent"].Value = wastagePercent;
			scom.Parameters["@wastageQty"].Value = wastageQty;
			scom.Parameters["@totalInputQty"].Value = totalInputQty;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@smv_TimeMinutes"].Value = smv_TimeMinutes;
			scom.Parameters["@totalLabour"].Value = totalLabour;
			scom.Parameters["@lowestCost"].Value = lowestCost;
			scom.Parameters["@highestCost"].Value = highestCost;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
			scom.Parameters["@bomCost"].Value = bomCost;
			scom.Parameters["@costTypeSelection"].Value = costTypeSelection;
			scom.Parameters["@cost"].Value = cost;
			scom.Parameters["@allowCostEdit"].Value = allowCostEdit;
			scom.Parameters["@editedCost"].Value = editedCost;
			scom.Parameters["@isSelected"].Value = isSelected;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxBatch_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1;
 
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2;
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_Line_No_Sub1_Line_No_Sub2_ProdJob_ID(int line_No, int line_No_Sub1, int line_No_Sub2, string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialDeleteAllByLine_No_Line_No_Sub1_Line_No_Sub2_ProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1;
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxBatch_Material table.
		/// </summary>
		public static tbl_prodTxBatch_Material Select(int line_No_Incoming, int line_No_Sub1_Incoming, int line_No_Sub2_Incoming, string prodJob_ID_Incoming, string prodBatch_ID_Incoming){

			tbl_prodTxBatch_Material tbl_prodTxBatch_Materialins = new tbl_prodTxBatch_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1_Incoming;
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxBatch_Materialins = Maketbl_prodTxBatch_Material(dataReader);
				} else {
					tbl_prodTxBatch_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prodTxBatch_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table.
		/// </summary>
		public static List<tbl_prodTxBatch_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxBatch_Material> tbl_prodTxBatch_MaterialList = new List<tbl_prodTxBatch_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Material tbl_prodTxBatch_Material = Maketbl_prodTxBatch_Material(dataReader);
					tbl_prodTxBatch_MaterialList.Add(tbl_prodTxBatch_Material);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Material> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxBatch_Material> tbl_prodTxBatch_MaterialList = new List<tbl_prodTxBatch_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Material tbl_prodTxBatch_Material = Maketbl_prodTxBatch_Material(dataReader);
					tbl_prodTxBatch_MaterialList.Add(tbl_prodTxBatch_Material);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxBatch_Material> tbl_prodTxBatch_MaterialList = new List<tbl_prodTxBatch_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Material tbl_prodTxBatch_Material = Maketbl_prodTxBatch_Material(dataReader);
					tbl_prodTxBatch_MaterialList.Add(tbl_prodTxBatch_Material);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Material> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialSelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_prodTxBatch_Material> tbl_prodTxBatch_MaterialList = new List<tbl_prodTxBatch_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Material tbl_prodTxBatch_Material = Maketbl_prodTxBatch_Material(dataReader);
					tbl_prodTxBatch_MaterialList.Add(tbl_prodTxBatch_Material);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Material> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxBatch_Material> tbl_prodTxBatch_MaterialList = new List<tbl_prodTxBatch_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Material tbl_prodTxBatch_Material = Maketbl_prodTxBatch_Material(dataReader);
					tbl_prodTxBatch_MaterialList.Add(tbl_prodTxBatch_Material);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Material> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prodTxBatch_Material> tbl_prodTxBatch_MaterialList = new List<tbl_prodTxBatch_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Material tbl_prodTxBatch_Material = Maketbl_prodTxBatch_Material(dataReader);
					tbl_prodTxBatch_MaterialList.Add(tbl_prodTxBatch_Material);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxBatch_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxBatch_Material> SelectAllByLine_No_Line_No_Sub1_Line_No_Sub2_ProdJob_ID(int line_No, int line_No_Sub1, int line_No_Sub2, string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxBatch_MaterialSelectAllByLine_No_Line_No_Sub1_Line_No_Sub2_ProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1;
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxBatch_Material> tbl_prodTxBatch_MaterialList = new List<tbl_prodTxBatch_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxBatch_Material tbl_prodTxBatch_Material = Maketbl_prodTxBatch_Material(dataReader);
					tbl_prodTxBatch_MaterialList.Add(tbl_prodTxBatch_Material);
				}
			}
			scon.Close();
			return tbl_prodTxBatch_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxBatch_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxBatch_Material Maketbl_prodTxBatch_Material(SqlDataReader dataReader) {
			tbl_prodTxBatch_Material tbl_prodTxBatch_Material = new tbl_prodTxBatch_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxBatch_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxBatch_Material.Line_No_Sub1 = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxBatch_Material.Line_No_Sub2 = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxBatch_Material.ProdJob_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxBatch_Material.ProdBatch_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxBatch_Material.Item_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxBatch_Material.Uom_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxBatch_Material.IsSemiFinishItem = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxBatch_Material.InputQty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxBatch_Material.IsWastagePercent = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxBatch_Material.WastagePercent = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxBatch_Material.WastageQty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxBatch_Material.TotalInputQty = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxBatch_Material.Section_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxBatch_Material.Smv_TimeMinutes = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxBatch_Material.TotalLabour = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prodTxBatch_Material.LowestCost = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prodTxBatch_Material.HighestCost = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prodTxBatch_Material.WeightedAvgCost = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prodTxBatch_Material.BomCost = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prodTxBatch_Material.CostTypeSelection = dataReader.GetInt32(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prodTxBatch_Material.Cost = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prodTxBatch_Material.AllowCostEdit = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prodTxBatch_Material.EditedCost = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prodTxBatch_Material.IsSelected = dataReader.GetBoolean(24);
			}

			return tbl_prodTxBatch_Material;
		}
		/// <summary>
		/// This makes tbl_prodTxBatch_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxBatch_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxBatch_Material  tbl_prodTxBatch_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_line_No_Sub1 = new DataColumn("line_No_Sub1" , typeof(int));
			DataColumn col_line_No_Sub2 = new DataColumn("line_No_Sub2" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_isSemiFinishItem = new DataColumn("isSemiFinishItem" , typeof(bool));
			DataColumn col_inputQty = new DataColumn("inputQty" , typeof(decimal));
			DataColumn col_isWastagePercent = new DataColumn("isWastagePercent" , typeof(bool));
			DataColumn col_wastagePercent = new DataColumn("wastagePercent" , typeof(decimal));
			DataColumn col_wastageQty = new DataColumn("wastageQty" , typeof(decimal));
			DataColumn col_totalInputQty = new DataColumn("totalInputQty" , typeof(decimal));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_smv_TimeMinutes = new DataColumn("smv_TimeMinutes" , typeof(decimal));
			DataColumn col_totalLabour = new DataColumn("totalLabour" , typeof(decimal));
			DataColumn col_lowestCost = new DataColumn("lowestCost" , typeof(decimal));
			DataColumn col_highestCost = new DataColumn("highestCost" , typeof(decimal));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
			DataColumn col_bomCost = new DataColumn("bomCost" , typeof(decimal));
			DataColumn col_costTypeSelection = new DataColumn("costTypeSelection" , typeof(int));
			DataColumn col_cost = new DataColumn("cost" , typeof(decimal));
			DataColumn col_allowCostEdit = new DataColumn("allowCostEdit" , typeof(bool));
			DataColumn col_editedCost = new DataColumn("editedCost" , typeof(decimal));
			DataColumn col_isSelected = new DataColumn("isSelected" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_line_No_Sub1,col_line_No_Sub2,col_prodJob_ID,col_prodBatch_ID,col_item_ID,col_uom_ID,col_isSemiFinishItem,col_inputQty,col_isWastagePercent,col_wastagePercent,col_wastageQty,col_totalInputQty,col_section_ID,col_smv_TimeMinutes,col_totalLabour,col_lowestCost,col_highestCost,col_weightedAvgCost,col_bomCost,col_costTypeSelection,col_cost,col_allowCostEdit,col_editedCost,col_isSelected,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxBatch_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxBatch_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxBatch_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["line_No_Sub1"] = user.line_No_Sub1;
			drow["line_No_Sub2"] = user.line_No_Sub2;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["isSemiFinishItem"] = user.isSemiFinishItem;
			drow["inputQty"] = user.inputQty;
			drow["isWastagePercent"] = user.isWastagePercent;
			drow["wastagePercent"] = user.wastagePercent;
			drow["wastageQty"] = user.wastageQty;
			drow["totalInputQty"] = user.totalInputQty;
			drow["section_ID"] = user.section_ID;
			drow["smv_TimeMinutes"] = user.smv_TimeMinutes;
			drow["totalLabour"] = user.totalLabour;
			drow["lowestCost"] = user.lowestCost;
			drow["highestCost"] = user.highestCost;
			drow["weightedAvgCost"] = user.weightedAvgCost;
			drow["bomCost"] = user.bomCost;
			drow["costTypeSelection"] = user.costTypeSelection;
			drow["cost"] = user.cost;
			drow["allowCostEdit"] = user.allowCostEdit;
			drow["editedCost"] = user.editedCost;
			drow["isSelected"] = user.isSelected;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
