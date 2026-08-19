using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_polyTxMaterialRequision_Material {
		#region Fields
		private int line_No;
		private string mr_No;
		private string prodJob_ID;
		private int line_No_JobWise;
		private string item_ID;
		private string uom_ID;
		private string uom_ID_Weight;
		private decimal bom_Qty;
		private decimal issued_Qty;
		private decimal balance_Qty;
		private decimal mr_Qty;
		private decimal bom_Weight;
		private decimal issued_Weight;
		private decimal balance_Weight;
		private decimal mr_Weight;
		private DateTime required_Date;
		private string instructions;
		private string store_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxMaterialRequision_Material class.
		/// </summary>
		public tbl_prod_polyTxMaterialRequision_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxMaterialRequision_Material class.
		/// </summary>
		public tbl_prod_polyTxMaterialRequision_Material(int line_No, string mr_No, string prodJob_ID, int line_No_JobWise, string item_ID, string uom_ID, string uom_ID_Weight, decimal bom_Qty, decimal issued_Qty, decimal balance_Qty, decimal mr_Qty, decimal bom_Weight, decimal issued_Weight, decimal balance_Weight, decimal mr_Weight, DateTime required_Date, string instructions, string store_ID) {
			this.line_No = line_No;
			this.mr_No = mr_No;
			this.prodJob_ID = prodJob_ID;
			this.line_No_JobWise = line_No_JobWise;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.uom_ID_Weight = uom_ID_Weight;
			this.bom_Qty = bom_Qty;
			this.issued_Qty = issued_Qty;
			this.balance_Qty = balance_Qty;
			this.mr_Qty = mr_Qty;
			this.bom_Weight = bom_Weight;
			this.issued_Weight = issued_Weight;
			this.balance_Weight = balance_Weight;
			this.mr_Weight = mr_Weight;
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
		/// Gets or sets the Uom_ID_Weight value.
		/// </summary>
		public string Uom_ID_Weight {
			get { return uom_ID_Weight; }
			set { uom_ID_Weight = value; }
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
		/// Gets or sets the Bom_Weight value.
		/// </summary>
		public decimal Bom_Weight {
			get { return bom_Weight; }
			set { bom_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Issued_Weight value.
		/// </summary>
		public decimal Issued_Weight {
			get { return issued_Weight; }
			set { issued_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Balance_Weight value.
		/// </summary>
		public decimal Balance_Weight {
			get { return balance_Weight; }
			set { balance_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mr_Weight value.
		/// </summary>
		public decimal Mr_Weight {
			get { return mr_Weight; }
			set { mr_Weight = value; }
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
		/// Saves a record to the tbl_prod_polyTxMaterialRequision_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No_JobWise", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_ID_Weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bom_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@balance_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@mr_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bom_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issued_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@balance_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@mr_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@required_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@instructions", SqlDbType.VarChar,200);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_No_JobWise"].Value = line_No_JobWise;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uom_ID_Weight"].Value = uom_ID_Weight;
			scom.Parameters["@bom_Qty"].Value = bom_Qty;
			scom.Parameters["@issued_Qty"].Value = issued_Qty;
			scom.Parameters["@balance_Qty"].Value = balance_Qty;
			scom.Parameters["@mr_Qty"].Value = mr_Qty;
			scom.Parameters["@bom_Weight"].Value = bom_Weight;
			scom.Parameters["@issued_Weight"].Value = issued_Weight;
			scom.Parameters["@balance_Weight"].Value = balance_Weight;
			scom.Parameters["@mr_Weight"].Value = mr_Weight;
			scom.Parameters["@required_Date"].Value = required_Date;
			scom.Parameters["@instructions"].Value = instructions;
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_polyTxMaterialRequision_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No_JobWise", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_ID_Weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bom_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@balance_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@mr_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bom_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issued_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@balance_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@mr_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@required_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@instructions", SqlDbType.VarChar,200);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_No_JobWise"].Value = line_No_JobWise;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uom_ID_Weight"].Value = uom_ID_Weight;
			scom.Parameters["@bom_Qty"].Value = bom_Qty;
			scom.Parameters["@issued_Qty"].Value = issued_Qty;
			scom.Parameters["@balance_Qty"].Value = balance_Qty;
			scom.Parameters["@mr_Qty"].Value = mr_Qty;
			scom.Parameters["@bom_Weight"].Value = bom_Weight;
			scom.Parameters["@issued_Weight"].Value = issued_Weight;
			scom.Parameters["@balance_Weight"].Value = balance_Weight;
			scom.Parameters["@mr_Weight"].Value = mr_Weight;
			scom.Parameters["@required_Date"].Value = required_Date;
			scom.Parameters["@instructions"].Value = instructions;
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_polyTxMaterialRequision_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialDelete", scon);
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
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByMr_No(string mr_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialDeleteAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_polyTxMaterialRequision_Material table.
		/// </summary>
		public static tbl_prod_polyTxMaterialRequision_Material Select(int line_No_Incoming, string mr_No_Incoming){

			tbl_prod_polyTxMaterialRequision_Material tbl_prod_polyTxMaterialRequision_Materialins = new tbl_prod_polyTxMaterialRequision_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@mr_No"].Value = mr_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_Materialins = Maketbl_prod_polyTxMaterialRequision_Material(dataReader);
				} else {
					tbl_prod_polyTxMaterialRequision_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_polyTxMaterialRequision_Material> tbl_prod_polyTxMaterialRequision_MaterialList = new List<tbl_prod_polyTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_Material tbl_prod_polyTxMaterialRequision_Material = Maketbl_prod_polyTxMaterialRequision_Material(dataReader);
					tbl_prod_polyTxMaterialRequision_MaterialList.Add(tbl_prod_polyTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_Material> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_polyTxMaterialRequision_Material> tbl_prod_polyTxMaterialRequision_MaterialList = new List<tbl_prod_polyTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_Material tbl_prod_polyTxMaterialRequision_Material = Maketbl_prod_polyTxMaterialRequision_Material(dataReader);
					tbl_prod_polyTxMaterialRequision_MaterialList.Add(tbl_prod_polyTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_Material> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_prod_polyTxMaterialRequision_Material> tbl_prod_polyTxMaterialRequision_MaterialList = new List<tbl_prod_polyTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_Material tbl_prod_polyTxMaterialRequision_Material = Maketbl_prod_polyTxMaterialRequision_Material(dataReader);
					tbl_prod_polyTxMaterialRequision_MaterialList.Add(tbl_prod_polyTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_Material> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_polyTxMaterialRequision_Material> tbl_prod_polyTxMaterialRequision_MaterialList = new List<tbl_prod_polyTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_Material tbl_prod_polyTxMaterialRequision_Material = Maketbl_prod_polyTxMaterialRequision_Material(dataReader);
					tbl_prod_polyTxMaterialRequision_MaterialList.Add(tbl_prod_polyTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_Material> SelectAllByMr_No(string mr_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialSelectAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
				List<tbl_prod_polyTxMaterialRequision_Material> tbl_prod_polyTxMaterialRequision_MaterialList = new List<tbl_prod_polyTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_Material tbl_prod_polyTxMaterialRequision_Material = Maketbl_prod_polyTxMaterialRequision_Material(dataReader);
					tbl_prod_polyTxMaterialRequision_MaterialList.Add(tbl_prod_polyTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prod_polyTxMaterialRequision_Material> tbl_prod_polyTxMaterialRequision_MaterialList = new List<tbl_prod_polyTxMaterialRequision_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_Material tbl_prod_polyTxMaterialRequision_Material = Maketbl_prod_polyTxMaterialRequision_Material(dataReader);
					tbl_prod_polyTxMaterialRequision_MaterialList.Add(tbl_prod_polyTxMaterialRequision_Material);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_polyTxMaterialRequision_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_polyTxMaterialRequision_Material Maketbl_prod_polyTxMaterialRequision_Material(SqlDataReader dataReader) {
			tbl_prod_polyTxMaterialRequision_Material tbl_prod_polyTxMaterialRequision_Material = new tbl_prod_polyTxMaterialRequision_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Mr_No = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_polyTxMaterialRequision_Material.ProdJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Line_No_JobWise = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Uom_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Uom_ID_Weight = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Bom_Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Issued_Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Balance_Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Mr_Qty = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Bom_Weight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Issued_Weight = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Balance_Weight = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Mr_Weight = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Required_Date = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Instructions = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_polyTxMaterialRequision_Material.Store_ID = dataReader.GetString(17);
			}

			return tbl_prod_polyTxMaterialRequision_Material;
		}
		/// <summary>
		/// This makes tbl_prod_polyTxMaterialRequision_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxMaterialRequision_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_polyTxMaterialRequision_Material  tbl_prod_polyTxMaterialRequision_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_mr_No = new DataColumn("mr_No" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_line_No_JobWise = new DataColumn("line_No_JobWise" , typeof(int));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_uom_ID_Weight = new DataColumn("uom_ID_Weight" , typeof(string));
			DataColumn col_bom_Qty = new DataColumn("bom_Qty" , typeof(decimal));
			DataColumn col_issued_Qty = new DataColumn("issued_Qty" , typeof(decimal));
			DataColumn col_balance_Qty = new DataColumn("balance_Qty" , typeof(decimal));
			DataColumn col_mr_Qty = new DataColumn("mr_Qty" , typeof(decimal));
			DataColumn col_bom_Weight = new DataColumn("bom_Weight" , typeof(decimal));
			DataColumn col_issued_Weight = new DataColumn("issued_Weight" , typeof(decimal));
			DataColumn col_balance_Weight = new DataColumn("balance_Weight" , typeof(decimal));
			DataColumn col_mr_Weight = new DataColumn("mr_Weight" , typeof(decimal));
			DataColumn col_required_Date = new DataColumn("required_Date" , typeof(DateTime));
			DataColumn col_instructions = new DataColumn("instructions" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_mr_No,col_prodJob_ID,col_line_No_JobWise,col_item_ID,col_uom_ID,col_uom_ID_Weight,col_bom_Qty,col_issued_Qty,col_balance_Qty,col_mr_Qty,col_bom_Weight,col_issued_Weight,col_balance_Weight,col_mr_Weight,col_required_Date,col_instructions,col_store_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_polyTxMaterialRequision_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxMaterialRequision_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_polyTxMaterialRequision_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["mr_No"] = user.mr_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["line_No_JobWise"] = user.line_No_JobWise;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["uom_ID_Weight"] = user.uom_ID_Weight;
			drow["bom_Qty"] = user.bom_Qty;
			drow["issued_Qty"] = user.issued_Qty;
			drow["balance_Qty"] = user.balance_Qty;
			drow["mr_Qty"] = user.mr_Qty;
			drow["bom_Weight"] = user.bom_Weight;
			drow["issued_Weight"] = user.issued_Weight;
			drow["balance_Weight"] = user.balance_Weight;
			drow["mr_Weight"] = user.mr_Weight;
			drow["required_Date"] = user.required_Date;
			drow["instructions"] = user.instructions;
			drow["store_ID"] = user.store_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
