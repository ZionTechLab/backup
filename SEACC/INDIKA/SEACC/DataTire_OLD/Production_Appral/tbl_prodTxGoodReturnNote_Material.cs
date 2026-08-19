using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxGoodReturnNote_Material {
		#region Fields
		private int line_No;
		private string pGRN_No;
		private string item_ID;
		private string uom_ID;
		private decimal pGRN_Qty;
		private decimal pGRN_Weight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private bool isDamage;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxGoodReturnNote_Material class.
		/// </summary>
		public tbl_prodTxGoodReturnNote_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxGoodReturnNote_Material class.
		/// </summary>
		public tbl_prodTxGoodReturnNote_Material(int line_No, string pGRN_No, string item_ID, string uom_ID, decimal pGRN_Qty, decimal pGRN_Weight, decimal unitPrice, decimal weightPrice, decimal totalAmount, bool isDamage, string remark) {
			this.line_No = line_No;
			this.pGRN_No = pGRN_No;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.pGRN_Qty = pGRN_Qty;
			this.pGRN_Weight = pGRN_Weight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.isDamage = isDamage;
			this.remark = remark;
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
		/// Gets or sets the PGRN_No value.
		/// </summary>
		public string PGRN_No {
			get { return pGRN_No; }
			set { pGRN_No = value; }
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
		/// Gets or sets the PGRN_Qty value.
		/// </summary>
		public decimal PGRN_Qty {
			get { return pGRN_Qty; }
			set { pGRN_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the PGRN_Weight value.
		/// </summary>
		public decimal PGRN_Weight {
			get { return pGRN_Weight; }
			set { pGRN_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightPrice value.
		/// </summary>
		public decimal WeightPrice {
			get { return weightPrice; }
			set { weightPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDamage value.
		/// </summary>
		public bool IsDamage {
			get { return isDamage; }
			set { isDamage = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxGoodReturnNote_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pGRN_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pGRN_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDamage", SqlDbType.Bit,1);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@pGRN_Qty"].Value = pGRN_Qty;
			scom.Parameters["@pGRN_Weight"].Value = pGRN_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@isDamage"].Value = isDamage;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxGoodReturnNote_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pGRN_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pGRN_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDamage", SqlDbType.Bit,1);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@pGRN_Qty"].Value = pGRN_Qty;
			scom.Parameters["@pGRN_Weight"].Value = pGRN_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@isDamage"].Value = isDamage;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxGoodReturnNote_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByPGRN_No(string pGRN_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialDeleteAllByPGRN_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_PGRN_No(int line_No, string pGRN_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialDeleteAllByLine_No_PGRN_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxGoodReturnNote_Material table.
		/// </summary>
		public static tbl_prodTxGoodReturnNote_Material Select(int line_No_Incoming, string pGRN_No_Incoming){

			tbl_prodTxGoodReturnNote_Material tbl_prodTxGoodReturnNote_Materialins = new tbl_prodTxGoodReturnNote_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@pGRN_No"].Value = pGRN_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxGoodReturnNote_Materialins = Maketbl_prodTxGoodReturnNote_Material(dataReader);
				} else {
					tbl_prodTxGoodReturnNote_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNote_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxGoodReturnNote_Material> tbl_prodTxGoodReturnNote_MaterialList = new List<tbl_prodTxGoodReturnNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote_Material tbl_prodTxGoodReturnNote_Material = Maketbl_prodTxGoodReturnNote_Material(dataReader);
					tbl_prodTxGoodReturnNote_MaterialList.Add(tbl_prodTxGoodReturnNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote_Material> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxGoodReturnNote_Material> tbl_prodTxGoodReturnNote_MaterialList = new List<tbl_prodTxGoodReturnNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote_Material tbl_prodTxGoodReturnNote_Material = Maketbl_prodTxGoodReturnNote_Material(dataReader);
					tbl_prodTxGoodReturnNote_MaterialList.Add(tbl_prodTxGoodReturnNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote_Material> SelectAllByPGRN_No(string pGRN_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialSelectAllByPGRN_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
				List<tbl_prodTxGoodReturnNote_Material> tbl_prodTxGoodReturnNote_MaterialList = new List<tbl_prodTxGoodReturnNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote_Material tbl_prodTxGoodReturnNote_Material = Maketbl_prodTxGoodReturnNote_Material(dataReader);
					tbl_prodTxGoodReturnNote_MaterialList.Add(tbl_prodTxGoodReturnNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxGoodReturnNote_Material> tbl_prodTxGoodReturnNote_MaterialList = new List<tbl_prodTxGoodReturnNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote_Material tbl_prodTxGoodReturnNote_Material = Maketbl_prodTxGoodReturnNote_Material(dataReader);
					tbl_prodTxGoodReturnNote_MaterialList.Add(tbl_prodTxGoodReturnNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote_Material> SelectAllByLine_No_PGRN_No(int line_No, string pGRN_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNote_MaterialSelectAllByLine_No_PGRN_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
				List<tbl_prodTxGoodReturnNote_Material> tbl_prodTxGoodReturnNote_MaterialList = new List<tbl_prodTxGoodReturnNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote_Material tbl_prodTxGoodReturnNote_Material = Maketbl_prodTxGoodReturnNote_Material(dataReader);
					tbl_prodTxGoodReturnNote_MaterialList.Add(tbl_prodTxGoodReturnNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNote_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxGoodReturnNote_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxGoodReturnNote_Material Maketbl_prodTxGoodReturnNote_Material(SqlDataReader dataReader) {
			tbl_prodTxGoodReturnNote_Material tbl_prodTxGoodReturnNote_Material = new tbl_prodTxGoodReturnNote_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxGoodReturnNote_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxGoodReturnNote_Material.PGRN_No = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxGoodReturnNote_Material.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxGoodReturnNote_Material.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxGoodReturnNote_Material.PGRN_Qty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxGoodReturnNote_Material.PGRN_Weight = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxGoodReturnNote_Material.UnitPrice = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxGoodReturnNote_Material.WeightPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxGoodReturnNote_Material.TotalAmount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxGoodReturnNote_Material.IsDamage = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxGoodReturnNote_Material.Remark = dataReader.GetString(10);
			}

			return tbl_prodTxGoodReturnNote_Material;
		}
		/// <summary>
		/// This makes tbl_prodTxGoodReturnNote_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxGoodReturnNote_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxGoodReturnNote_Material  tbl_prodTxGoodReturnNote_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_pGRN_No = new DataColumn("pGRN_No" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_pGRN_Qty = new DataColumn("pGRN_Qty" , typeof(decimal));
			DataColumn col_pGRN_Weight = new DataColumn("pGRN_Weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_isDamage = new DataColumn("isDamage" , typeof(bool));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_pGRN_No,col_item_ID,col_uom_ID,col_pGRN_Qty,col_pGRN_Weight,col_unitPrice,col_weightPrice,col_totalAmount,col_isDamage,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxGoodReturnNote_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxGoodReturnNote_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxGoodReturnNote_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["pGRN_No"] = user.pGRN_No;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["pGRN_Qty"] = user.pGRN_Qty;
			drow["pGRN_Weight"] = user.pGRN_Weight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["isDamage"] = user.isDamage;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
