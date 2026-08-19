using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxMaterialRequision_Material {
		#region Fields
		private int line_No;
		private string mr_No;
		private string prodJob_ID;
		private int line_No_JobWise;
		private string prodBatch_ID;
		private string item_ID;
		private string uom_ID;
		private decimal bom_Qty;
		private decimal issued_Qty;
		private decimal balance_Qty;
		private decimal mr_Qty;
		private DateTime required_Date;
		private string instructions;
		private string store_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxMaterialRequision_Material class.
		/// </summary>
		public tbl_prodTxMaterialRequision_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxMaterialRequision_Material class.
		/// </summary>
		public tbl_prodTxMaterialRequision_Material(int line_No, string mr_No, string prodJob_ID, int line_No_JobWise, string prodBatch_ID, string item_ID, string uom_ID, decimal bom_Qty, decimal issued_Qty, decimal balance_Qty, decimal mr_Qty, DateTime required_Date, string instructions, string store_ID) {
			this.line_No = line_No;
			this.mr_No = mr_No;
			this.prodJob_ID = prodJob_ID;
			this.line_No_JobWise = line_No_JobWise;
			this.prodBatch_ID = prodBatch_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.bom_Qty = bom_Qty;
			this.issued_Qty = issued_Qty;
			this.balance_Qty = balance_Qty;
			this.mr_Qty = mr_Qty;
			this.required_Date = required_Date;
			this.instructions = instructions;
			this.store_ID = store_ID;
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
		/// Gets or sets the Mr_No value.
		/// </summary>
		public string Mr_No {
			get { return mr_No; }
			set { mr_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No_JobWise value.
		/// </summary>
		public int Line_No_JobWise {
			get { return line_No_JobWise; }
			set { line_No_JobWise = value; }
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
		/// Gets or sets the Bom_Qty value.
		/// </summary>
		public decimal Bom_Qty {
			get { return bom_Qty; }
			set { bom_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Issued_Qty value.
		/// </summary>
		public decimal Issued_Qty {
			get { return issued_Qty; }
			set { issued_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Balance_Qty value.
		/// </summary>
		public decimal Balance_Qty {
			get { return balance_Qty; }
			set { balance_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mr_Qty value.
		/// </summary>
		public decimal Mr_Qty {
			get { return mr_Qty; }
			set { mr_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Required_Date value.
		/// </summary>
		public DateTime Required_Date {
			get { return required_Date; }
			set { required_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Instructions value.
		/// </summary>
		public string Instructions {
			get { return instructions; }
			set { instructions = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxMaterialRequision_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No_JobWise", SqlDbType.Int,4);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bom_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@balance_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@mr_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@required_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@instructions", SqlDbType.VarChar,200);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_No_JobWise"].Value = line_No_JobWise;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@bom_Qty"].Value = bom_Qty;
			scom.Parameters["@issued_Qty"].Value = issued_Qty;
			scom.Parameters["@balance_Qty"].Value = balance_Qty;
			scom.Parameters["@mr_Qty"].Value = mr_Qty;
			scom.Parameters["@required_Date"].Value = required_Date;
			scom.Parameters["@instructions"].Value = instructions;
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxMaterialRequision_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No_JobWise", SqlDbType.Int,4);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bom_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@balance_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@mr_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@required_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@instructions", SqlDbType.VarChar,200);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_No_JobWise"].Value = line_No_JobWise;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@bom_Qty"].Value = bom_Qty;
			scom.Parameters["@issued_Qty"].Value = issued_Qty;
			scom.Parameters["@balance_Qty"].Value = balance_Qty;
			scom.Parameters["@mr_Qty"].Value = mr_Qty;
			scom.Parameters["@required_Date"].Value = required_Date;
			scom.Parameters["@instructions"].Value = instructions;
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxMaterialRequision_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@mr_No"].Value = mr_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByMr_No(string mr_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialDeleteAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxMaterialRequision_Material table.
		/// </summary>
		public static tbl_prodTxMaterialRequision_Material Select(int line_No_Incoming, string mr_No_Incoming){

			tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Materialins = new tbl_prodTxMaterialRequision_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@mr_No"].Value = mr_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxMaterialRequision_Materialins = Maketbl_prodTxMaterialRequision_Material(dataReader);
				} else {
					tbl_prodTxMaterialRequision_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxMaterialRequision_Material> tbl_prodTxMaterialRequision_MaterialList = new List<tbl_prodTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Material = Maketbl_prodTxMaterialRequision_Material(dataReader);
					tbl_prodTxMaterialRequision_MaterialList.Add(tbl_prodTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_Material> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prodTxMaterialRequision_Material> tbl_prodTxMaterialRequision_MaterialList = new List<tbl_prodTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Material = Maketbl_prodTxMaterialRequision_Material(dataReader);
					tbl_prodTxMaterialRequision_MaterialList.Add(tbl_prodTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_Material> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_prodTxMaterialRequision_Material> tbl_prodTxMaterialRequision_MaterialList = new List<tbl_prodTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Material = Maketbl_prodTxMaterialRequision_Material(dataReader);
					tbl_prodTxMaterialRequision_MaterialList.Add(tbl_prodTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_Material> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxMaterialRequision_Material> tbl_prodTxMaterialRequision_MaterialList = new List<tbl_prodTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Material = Maketbl_prodTxMaterialRequision_Material(dataReader);
					tbl_prodTxMaterialRequision_MaterialList.Add(tbl_prodTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_Material> SelectAllByMr_No(string mr_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialSelectAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
				List<tbl_prodTxMaterialRequision_Material> tbl_prodTxMaterialRequision_MaterialList = new List<tbl_prodTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Material = Maketbl_prodTxMaterialRequision_Material(dataReader);
					tbl_prodTxMaterialRequision_MaterialList.Add(tbl_prodTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxMaterialRequision_Material> tbl_prodTxMaterialRequision_MaterialList = new List<tbl_prodTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Material = Maketbl_prodTxMaterialRequision_Material(dataReader);
					tbl_prodTxMaterialRequision_MaterialList.Add(tbl_prodTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_Material> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_MaterialSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxMaterialRequision_Material> tbl_prodTxMaterialRequision_MaterialList = new List<tbl_prodTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Material = Maketbl_prodTxMaterialRequision_Material(dataReader);
					tbl_prodTxMaterialRequision_MaterialList.Add(tbl_prodTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxMaterialRequision_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxMaterialRequision_Material Maketbl_prodTxMaterialRequision_Material(SqlDataReader dataReader) {
			tbl_prodTxMaterialRequision_Material tbl_prodTxMaterialRequision_Material = new tbl_prodTxMaterialRequision_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxMaterialRequision_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxMaterialRequision_Material.Mr_No = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxMaterialRequision_Material.ProdJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxMaterialRequision_Material.Line_No_JobWise = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxMaterialRequision_Material.ProdBatch_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxMaterialRequision_Material.Item_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxMaterialRequision_Material.Uom_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxMaterialRequision_Material.Bom_Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxMaterialRequision_Material.Issued_Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxMaterialRequision_Material.Balance_Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxMaterialRequision_Material.Mr_Qty = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxMaterialRequision_Material.Required_Date = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxMaterialRequision_Material.Instructions = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxMaterialRequision_Material.Store_ID = dataReader.GetString(13);
			}

			return tbl_prodTxMaterialRequision_Material;
		}
		/// <summary>
		/// This makes tbl_prodTxMaterialRequision_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxMaterialRequision_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxMaterialRequision_Material  tbl_prodTxMaterialRequision_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_mr_No = new DataColumn("mr_No" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_line_No_JobWise = new DataColumn("line_No_JobWise" , typeof(int));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_bom_Qty = new DataColumn("bom_Qty" , typeof(decimal));
			DataColumn col_issued_Qty = new DataColumn("issued_Qty" , typeof(decimal));
			DataColumn col_balance_Qty = new DataColumn("balance_Qty" , typeof(decimal));
			DataColumn col_mr_Qty = new DataColumn("mr_Qty" , typeof(decimal));
			DataColumn col_required_Date = new DataColumn("required_Date" , typeof(DateTime));
			DataColumn col_instructions = new DataColumn("instructions" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_mr_No,col_prodJob_ID,col_line_No_JobWise,col_prodBatch_ID,col_item_ID,col_uom_ID,col_bom_Qty,col_issued_Qty,col_balance_Qty,col_mr_Qty,col_required_Date,col_instructions,col_store_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxMaterialRequision_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxMaterialRequision_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxMaterialRequision_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["mr_No"] = user.mr_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["line_No_JobWise"] = user.line_No_JobWise;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["bom_Qty"] = user.bom_Qty;
			drow["issued_Qty"] = user.issued_Qty;
			drow["balance_Qty"] = user.balance_Qty;
			drow["mr_Qty"] = user.mr_Qty;
			drow["required_Date"] = user.required_Date;
			drow["instructions"] = user.instructions;
			drow["store_ID"] = user.store_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
