using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxWorkInProgress_Material {
		#region Fields
		private int line_No;
		private string wip_ID;
		private string item_ID;
		private string uom_ID;
		private decimal planned_Qty;
		private decimal floor_Qty;
		private decimal waste_Qty;
		private decimal qc_Qty;
		private decimal inputOutput_QtyRate;
		private decimal inputOutput_Qty;
		private decimal inputOutput_Weight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string remark;
		private bool is_Output;
		private string output_Section_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxWorkInProgress_Material class.
		/// </summary>
		public tbl_prodTxWorkInProgress_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxWorkInProgress_Material class.
		/// </summary>
		public tbl_prodTxWorkInProgress_Material(int line_No, string wip_ID, string item_ID, string uom_ID, decimal planned_Qty, decimal floor_Qty, decimal waste_Qty, decimal qc_Qty, decimal inputOutput_QtyRate, decimal inputOutput_Qty, decimal inputOutput_Weight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string remark, bool is_Output, string output_Section_ID) {
			this.line_No = line_No;
			this.wip_ID = wip_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.planned_Qty = planned_Qty;
			this.floor_Qty = floor_Qty;
			this.waste_Qty = waste_Qty;
			this.qc_Qty = qc_Qty;
			this.inputOutput_QtyRate = inputOutput_QtyRate;
			this.inputOutput_Qty = inputOutput_Qty;
			this.inputOutput_Weight = inputOutput_Weight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.remark = remark;
			this.is_Output = is_Output;
			this.output_Section_ID = output_Section_ID;
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
		/// Gets or sets the Wip_ID value.
		/// </summary>
		public string Wip_ID {
			get { return wip_ID; }
			set { wip_ID = value; }
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
		/// Gets or sets the Planned_Qty value.
		/// </summary>
		public decimal Planned_Qty {
			get { return planned_Qty; }
			set { planned_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Floor_Qty value.
		/// </summary>
		public decimal Floor_Qty {
			get { return floor_Qty; }
			set { floor_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Waste_Qty value.
		/// </summary>
		public decimal Waste_Qty {
			get { return waste_Qty; }
			set { waste_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qc_Qty value.
		/// </summary>
		public decimal Qc_Qty {
			get { return qc_Qty; }
			set { qc_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputOutput_QtyRate value.
		/// </summary>
		public decimal InputOutput_QtyRate {
			get { return inputOutput_QtyRate; }
			set { inputOutput_QtyRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputOutput_Qty value.
		/// </summary>
		public decimal InputOutput_Qty {
			get { return inputOutput_Qty; }
			set { inputOutput_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputOutput_Weight value.
		/// </summary>
		public decimal InputOutput_Weight {
			get { return inputOutput_Weight; }
			set { inputOutput_Weight = value; }
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
		
		/// <summary>
		/// Gets or sets the Is_Output value.
		/// </summary>
		public bool Is_Output {
			get { return is_Output; }
			set { is_Output = value; }
		}
		
		/// <summary>
		/// Gets or sets the Output_Section_ID value.
		/// </summary>
		public string Output_Section_ID {
			get { return output_Section_ID; }
			set { output_Section_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxWorkInProgress_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@planned_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@floor_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@waste_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qc_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputOutput_QtyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputOutput_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputOutput_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,20);
			scom.Parameters.Add("@is_Output", SqlDbType.Bit,1);
			scom.Parameters.Add("@output_Section_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@wip_ID"].Value = wip_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@planned_Qty"].Value = planned_Qty;
			scom.Parameters["@floor_Qty"].Value = floor_Qty;
			scom.Parameters["@waste_Qty"].Value = waste_Qty;
			scom.Parameters["@qc_Qty"].Value = qc_Qty;
			scom.Parameters["@inputOutput_QtyRate"].Value = inputOutput_QtyRate;
			scom.Parameters["@inputOutput_Qty"].Value = inputOutput_Qty;
			scom.Parameters["@inputOutput_Weight"].Value = inputOutput_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@is_Output"].Value = is_Output;
			scom.Parameters["@output_Section_ID"].Value = output_Section_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxWorkInProgress_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@planned_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@floor_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@waste_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qc_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputOutput_QtyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputOutput_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inputOutput_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,20);
			scom.Parameters.Add("@is_Output", SqlDbType.Bit,1);
			scom.Parameters.Add("@output_Section_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@wip_ID"].Value = wip_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@planned_Qty"].Value = planned_Qty;
			scom.Parameters["@floor_Qty"].Value = floor_Qty;
			scom.Parameters["@waste_Qty"].Value = waste_Qty;
			scom.Parameters["@qc_Qty"].Value = qc_Qty;
			scom.Parameters["@inputOutput_QtyRate"].Value = inputOutput_QtyRate;
			scom.Parameters["@inputOutput_Qty"].Value = inputOutput_Qty;
			scom.Parameters["@inputOutput_Weight"].Value = inputOutput_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@is_Output"].Value = is_Output;
			scom.Parameters["@output_Section_ID"].Value = output_Section_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxWorkInProgress_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@wip_ID"].Value = wip_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByOutput_Section_ID(string output_Section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialDeleteAllByOutput_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@output_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@output_Section_ID"].Value = output_Section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByWip_ID(string wip_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialDeleteAllByWip_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters["@wip_ID"].Value = wip_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxWorkInProgress_Material table.
		/// </summary>
		public static tbl_prodTxWorkInProgress_Material Select(int line_No_Incoming, string wip_ID_Incoming){

			tbl_prodTxWorkInProgress_Material tbl_prodTxWorkInProgress_Materialins = new tbl_prodTxWorkInProgress_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@wip_ID"].Value = wip_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxWorkInProgress_Materialins = Maketbl_prodTxWorkInProgress_Material(dataReader);
				} else {
					tbl_prodTxWorkInProgress_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prodTxWorkInProgress_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table.
		/// </summary>
		public static List<tbl_prodTxWorkInProgress_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxWorkInProgress_Material> tbl_prodTxWorkInProgress_MaterialList = new List<tbl_prodTxWorkInProgress_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxWorkInProgress_Material tbl_prodTxWorkInProgress_Material = Maketbl_prodTxWorkInProgress_Material(dataReader);
					tbl_prodTxWorkInProgress_MaterialList.Add(tbl_prodTxWorkInProgress_Material);
				}
			}
			scon.Close();
			return tbl_prodTxWorkInProgress_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxWorkInProgress_Material> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxWorkInProgress_Material> tbl_prodTxWorkInProgress_MaterialList = new List<tbl_prodTxWorkInProgress_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxWorkInProgress_Material tbl_prodTxWorkInProgress_Material = Maketbl_prodTxWorkInProgress_Material(dataReader);
					tbl_prodTxWorkInProgress_MaterialList.Add(tbl_prodTxWorkInProgress_Material);
				}
			}
			scon.Close();
			return tbl_prodTxWorkInProgress_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxWorkInProgress_Material> SelectAllByOutput_Section_ID(string output_Section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialSelectAllByOutput_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@output_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@output_Section_ID"].Value = output_Section_ID;
				List<tbl_prodTxWorkInProgress_Material> tbl_prodTxWorkInProgress_MaterialList = new List<tbl_prodTxWorkInProgress_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxWorkInProgress_Material tbl_prodTxWorkInProgress_Material = Maketbl_prodTxWorkInProgress_Material(dataReader);
					tbl_prodTxWorkInProgress_MaterialList.Add(tbl_prodTxWorkInProgress_Material);
				}
			}
			scon.Close();
			return tbl_prodTxWorkInProgress_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxWorkInProgress_Material> SelectAllByWip_ID(string wip_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialSelectAllByWip_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters["@wip_ID"].Value = wip_ID;
				List<tbl_prodTxWorkInProgress_Material> tbl_prodTxWorkInProgress_MaterialList = new List<tbl_prodTxWorkInProgress_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxWorkInProgress_Material tbl_prodTxWorkInProgress_Material = Maketbl_prodTxWorkInProgress_Material(dataReader);
					tbl_prodTxWorkInProgress_MaterialList.Add(tbl_prodTxWorkInProgress_Material);
				}
			}
			scon.Close();
			return tbl_prodTxWorkInProgress_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxWorkInProgress_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxWorkInProgress_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxWorkInProgress_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxWorkInProgress_Material> tbl_prodTxWorkInProgress_MaterialList = new List<tbl_prodTxWorkInProgress_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxWorkInProgress_Material tbl_prodTxWorkInProgress_Material = Maketbl_prodTxWorkInProgress_Material(dataReader);
					tbl_prodTxWorkInProgress_MaterialList.Add(tbl_prodTxWorkInProgress_Material);
				}
			}
			scon.Close();
			return tbl_prodTxWorkInProgress_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxWorkInProgress_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxWorkInProgress_Material Maketbl_prodTxWorkInProgress_Material(SqlDataReader dataReader) {
			tbl_prodTxWorkInProgress_Material tbl_prodTxWorkInProgress_Material = new tbl_prodTxWorkInProgress_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxWorkInProgress_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxWorkInProgress_Material.Wip_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxWorkInProgress_Material.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxWorkInProgress_Material.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxWorkInProgress_Material.Planned_Qty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxWorkInProgress_Material.Floor_Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxWorkInProgress_Material.Waste_Qty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxWorkInProgress_Material.Qc_Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxWorkInProgress_Material.InputOutput_QtyRate = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxWorkInProgress_Material.InputOutput_Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxWorkInProgress_Material.InputOutput_Weight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxWorkInProgress_Material.UnitPrice = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxWorkInProgress_Material.WeightPrice = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxWorkInProgress_Material.TotalAmount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxWorkInProgress_Material.Remark = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxWorkInProgress_Material.Is_Output = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prodTxWorkInProgress_Material.Output_Section_ID = dataReader.GetString(16);
			}

			return tbl_prodTxWorkInProgress_Material;
		}
		/// <summary>
		/// This makes tbl_prodTxWorkInProgress_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxWorkInProgress_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxWorkInProgress_Material  tbl_prodTxWorkInProgress_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_wip_ID = new DataColumn("wip_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_planned_Qty = new DataColumn("planned_Qty" , typeof(decimal));
			DataColumn col_floor_Qty = new DataColumn("floor_Qty" , typeof(decimal));
			DataColumn col_waste_Qty = new DataColumn("waste_Qty" , typeof(decimal));
			DataColumn col_qc_Qty = new DataColumn("qc_Qty" , typeof(decimal));
			DataColumn col_inputOutput_QtyRate = new DataColumn("inputOutput_QtyRate" , typeof(decimal));
			DataColumn col_inputOutput_Qty = new DataColumn("inputOutput_Qty" , typeof(decimal));
			DataColumn col_inputOutput_Weight = new DataColumn("inputOutput_Weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_is_Output = new DataColumn("is_Output" , typeof(bool));
			DataColumn col_output_Section_ID = new DataColumn("output_Section_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_wip_ID,col_item_ID,col_uom_ID,col_planned_Qty,col_floor_Qty,col_waste_Qty,col_qc_Qty,col_inputOutput_QtyRate,col_inputOutput_Qty,col_inputOutput_Weight,col_unitPrice,col_weightPrice,col_totalAmount,col_remark,col_is_Output,col_output_Section_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxWorkInProgress_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxWorkInProgress_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxWorkInProgress_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["wip_ID"] = user.wip_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["planned_Qty"] = user.planned_Qty;
			drow["floor_Qty"] = user.floor_Qty;
			drow["waste_Qty"] = user.waste_Qty;
			drow["qc_Qty"] = user.qc_Qty;
			drow["inputOutput_QtyRate"] = user.inputOutput_QtyRate;
			drow["inputOutput_Qty"] = user.inputOutput_Qty;
			drow["inputOutput_Weight"] = user.inputOutput_Weight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["remark"] = user.remark;
			drow["is_Output"] = user.is_Output;
			drow["output_Section_ID"] = user.output_Section_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
