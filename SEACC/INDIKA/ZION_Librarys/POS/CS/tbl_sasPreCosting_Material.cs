using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasPreCosting_Material {
		#region Fields
		private int line_No;
		private string preCosting_ID;
		private string item_ID;
		private string uom_ID;
		private decimal width;
		private decimal height;
		private decimal gauge;
		private decimal gusset;
		private decimal qty;
		private decimal weight;
		private decimal weightCalculated;
		private decimal costPrice;
		private decimal amount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting_Material class.
		/// </summary>
		public tbl_sasPreCosting_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting_Material class.
		/// </summary>
		public tbl_sasPreCosting_Material(int line_No, string preCosting_ID, string item_ID, string uom_ID, decimal width, decimal height, decimal gauge, decimal gusset, decimal qty, decimal weight, decimal weightCalculated, decimal costPrice, decimal amount) {
			this.line_No = line_No;
			this.preCosting_ID = preCosting_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.width = width;
			this.height = height;
			this.gauge = gauge;
			this.gusset = gusset;
			this.qty = qty;
			this.weight = weight;
			this.weightCalculated = weightCalculated;
			this.costPrice = costPrice;
			this.amount = amount;
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
		/// Gets or sets the PreCosting_ID value.
		/// </summary>
		public string PreCosting_ID {
			get { return preCosting_ID; }
			set { preCosting_ID = value; }
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
		/// Gets or sets the Width value.
		/// </summary>
		public decimal Width {
			get { return width; }
			set { width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Height value.
		/// </summary>
		public decimal Height {
			get { return height; }
			set { height = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gauge value.
		/// </summary>
		public decimal Gauge {
			get { return gauge; }
			set { gauge = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gusset value.
		/// </summary>
		public decimal Gusset {
			get { return gusset; }
			set { gusset = value; }
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
		/// Gets or sets the WeightCalculated value.
		/// </summary>
		public decimal WeightCalculated {
			get { return weightCalculated; }
			set { weightCalculated = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostPrice value.
		/// </summary>
		public decimal CostPrice {
			get { return costPrice; }
			set { costPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasPreCosting_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gauge", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightCalculated", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@gauge"].Value = gauge;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightCalculated"].Value = weightCalculated;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasPreCosting_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gauge", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightCalculated", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@gauge"].Value = gauge;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightCalculated"].Value = weightCalculated;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasPreCosting_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByPreCosting_ID(string preCosting_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialDeleteAllByPreCosting_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
             
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasPreCosting_Material table.
		/// </summary>
		public static tbl_sasPreCosting_Material Select(int line_No_Incoming, string preCosting_ID_Incoming, string item_ID_Incoming){

			tbl_sasPreCosting_Material tbl_sasPreCosting_Materialins = new tbl_sasPreCosting_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasPreCosting_Materialins = Maketbl_sasPreCosting_Material(dataReader);
				} else {
					tbl_sasPreCosting_Materialins = null;
				}
			}
			scon.Close();
			return tbl_sasPreCosting_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Material table.
		/// </summary>
		public static List<tbl_sasPreCosting_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasPreCosting_Material> tbl_sasPreCosting_MaterialList = new List<tbl_sasPreCosting_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Material tbl_sasPreCosting_Material = Maketbl_sasPreCosting_Material(dataReader);
					tbl_sasPreCosting_MaterialList.Add(tbl_sasPreCosting_Material);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Material table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Material> SelectAllByPreCosting_ID(string preCosting_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialSelectAllByPreCosting_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
				List<tbl_sasPreCosting_Material> tbl_sasPreCosting_MaterialList = new List<tbl_sasPreCosting_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Material tbl_sasPreCosting_Material = Maketbl_sasPreCosting_Material(dataReader);
					tbl_sasPreCosting_MaterialList.Add(tbl_sasPreCosting_Material);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Material table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasPreCosting_Material> tbl_sasPreCosting_MaterialList = new List<tbl_sasPreCosting_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Material tbl_sasPreCosting_Material = Maketbl_sasPreCosting_Material(dataReader);
					tbl_sasPreCosting_MaterialList.Add(tbl_sasPreCosting_Material);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasPreCosting_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasPreCosting_Material Maketbl_sasPreCosting_Material(SqlDataReader dataReader) {
			tbl_sasPreCosting_Material tbl_sasPreCosting_Material = new tbl_sasPreCosting_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasPreCosting_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasPreCosting_Material.PreCosting_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasPreCosting_Material.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasPreCosting_Material.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasPreCosting_Material.Width = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasPreCosting_Material.Height = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasPreCosting_Material.Gauge = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasPreCosting_Material.Gusset = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasPreCosting_Material.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasPreCosting_Material.Weight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasPreCosting_Material.WeightCalculated = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasPreCosting_Material.CostPrice = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasPreCosting_Material.Amount = dataReader.GetDecimal(12);
			}

			return tbl_sasPreCosting_Material;
		}
		/// <summary>
		/// This makes tbl_sasPreCosting_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasPreCosting_Material  tbl_sasPreCosting_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_preCosting_ID = new DataColumn("preCosting_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_height = new DataColumn("height" , typeof(decimal));
			DataColumn col_gauge = new DataColumn("gauge" , typeof(decimal));
			DataColumn col_gusset = new DataColumn("gusset" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightCalculated = new DataColumn("weightCalculated" , typeof(decimal));
			DataColumn col_costPrice = new DataColumn("costPrice" , typeof(decimal));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_preCosting_ID,col_item_ID,col_uom_ID,col_width,col_height,col_gauge,col_gusset,col_qty,col_weight,col_weightCalculated,col_costPrice,col_amount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasPreCosting_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasPreCosting_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["preCosting_ID"] = user.preCosting_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["width"] = user.width;
			drow["height"] = user.height;
			drow["gauge"] = user.gauge;
			drow["gusset"] = user.gusset;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["weightCalculated"] = user.weightCalculated;
			drow["costPrice"] = user.costPrice;
			drow["amount"] = user.amount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
