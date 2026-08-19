using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxSubContractInNote_Material {
		#region Fields
		private int line_No;
		private string subIn_ID;
		private string item_ID;
		private string uom_ID;
		private decimal total_Issued_Qty;
		private decimal returned_Qty;
		private decimal returned_Weight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxSubContractInNote_Material class.
		/// </summary>
		public tbl_prod_pharmaTxSubContractInNote_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxSubContractInNote_Material class.
		/// </summary>
		public tbl_prod_pharmaTxSubContractInNote_Material(int line_No, string subIn_ID, string item_ID, string uom_ID, decimal total_Issued_Qty, decimal returned_Qty, decimal returned_Weight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string remark) {
			this.line_No = line_No;
			this.subIn_ID = subIn_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.total_Issued_Qty = total_Issued_Qty;
			this.returned_Qty = returned_Qty;
			this.returned_Weight = returned_Weight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
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
		/// Gets or sets the SubIn_ID value.
		/// </summary>
		public string SubIn_ID {
			get { return subIn_ID; }
			set { subIn_ID = value; }
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
		/// Gets or sets the Total_Issued_Qty value.
		/// </summary>
		public decimal Total_Issued_Qty {
			get { return total_Issued_Qty; }
			set { total_Issued_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Returned_Qty value.
		/// </summary>
		public decimal Returned_Qty {
			get { return returned_Qty; }
			set { returned_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Returned_Weight value.
		/// </summary>
		public decimal Returned_Weight {
			get { return returned_Weight; }
			set { returned_Weight = value; }
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
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxSubContractInNote_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@total_Issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@returned_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@returned_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@total_Issued_Qty"].Value = total_Issued_Qty;
			scom.Parameters["@returned_Qty"].Value = returned_Qty;
			scom.Parameters["@returned_Weight"].Value = returned_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxSubContractInNote_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@total_Issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@returned_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@returned_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@total_Issued_Qty"].Value = total_Issued_Qty;
			scom.Parameters["@returned_Qty"].Value = returned_Qty;
			scom.Parameters["@returned_Weight"].Value = returned_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxSubContractInNote_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractInNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllBySubIn_ID(string subIn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialDeleteAllBySubIn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractInNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractInNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxSubContractInNote_Material table.
		/// </summary>
		public static tbl_prod_pharmaTxSubContractInNote_Material Select(int line_No_Incoming, string subIn_ID_Incoming){

			tbl_prod_pharmaTxSubContractInNote_Material tbl_prod_pharmaTxSubContractInNote_Materialins = new tbl_prod_pharmaTxSubContractInNote_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@subIn_ID"].Value = subIn_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractInNote_Materialins = Maketbl_prod_pharmaTxSubContractInNote_Material(dataReader);
				} else {
					tbl_prod_pharmaTxSubContractInNote_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractInNote_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractInNote_Material table.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractInNote_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxSubContractInNote_Material> tbl_prod_pharmaTxSubContractInNote_MaterialList = new List<tbl_prod_pharmaTxSubContractInNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractInNote_Material tbl_prod_pharmaTxSubContractInNote_Material = Maketbl_prod_pharmaTxSubContractInNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractInNote_MaterialList.Add(tbl_prod_pharmaTxSubContractInNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractInNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractInNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractInNote_Material> SelectAllBySubIn_ID(string subIn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialSelectAllBySubIn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
				List<tbl_prod_pharmaTxSubContractInNote_Material> tbl_prod_pharmaTxSubContractInNote_MaterialList = new List<tbl_prod_pharmaTxSubContractInNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractInNote_Material tbl_prod_pharmaTxSubContractInNote_Material = Maketbl_prod_pharmaTxSubContractInNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractInNote_MaterialList.Add(tbl_prod_pharmaTxSubContractInNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractInNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractInNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractInNote_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prod_pharmaTxSubContractInNote_Material> tbl_prod_pharmaTxSubContractInNote_MaterialList = new List<tbl_prod_pharmaTxSubContractInNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractInNote_Material tbl_prod_pharmaTxSubContractInNote_Material = Maketbl_prod_pharmaTxSubContractInNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractInNote_MaterialList.Add(tbl_prod_pharmaTxSubContractInNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractInNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractInNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractInNote_Material> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractInNote_MaterialSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_pharmaTxSubContractInNote_Material> tbl_prod_pharmaTxSubContractInNote_MaterialList = new List<tbl_prod_pharmaTxSubContractInNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractInNote_Material tbl_prod_pharmaTxSubContractInNote_Material = Maketbl_prod_pharmaTxSubContractInNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractInNote_MaterialList.Add(tbl_prod_pharmaTxSubContractInNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractInNote_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxSubContractInNote_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxSubContractInNote_Material Maketbl_prod_pharmaTxSubContractInNote_Material(SqlDataReader dataReader) {
			tbl_prod_pharmaTxSubContractInNote_Material tbl_prod_pharmaTxSubContractInNote_Material = new tbl_prod_pharmaTxSubContractInNote_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.SubIn_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.Total_Issued_Qty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.Returned_Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.Returned_Weight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.UnitPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.WeightPrice = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.TotalAmount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_pharmaTxSubContractInNote_Material.Remark = dataReader.GetString(10);
			}

			return tbl_prod_pharmaTxSubContractInNote_Material;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxSubContractInNote_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxSubContractInNote_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxSubContractInNote_Material  tbl_prod_pharmaTxSubContractInNote_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_subIn_ID = new DataColumn("subIn_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_total_Issued_Qty = new DataColumn("total_Issued_Qty" , typeof(decimal));
			DataColumn col_returned_Qty = new DataColumn("returned_Qty" , typeof(decimal));
			DataColumn col_returned_Weight = new DataColumn("returned_Weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_subIn_ID,col_item_ID,col_uom_ID,col_total_Issued_Qty,col_returned_Qty,col_returned_Weight,col_unitPrice,col_weightPrice,col_totalAmount,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxSubContractInNote_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxSubContractInNote_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxSubContractInNote_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["subIn_ID"] = user.subIn_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["total_Issued_Qty"] = user.total_Issued_Qty;
			drow["returned_Qty"] = user.returned_Qty;
			drow["returned_Weight"] = user.returned_Weight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
