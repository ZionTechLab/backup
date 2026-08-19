using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF {
		#region Fields
		private int line_No;
		private string subIn_ID;
		private string item_ID_SF;
		private string item_ID;
		private string uom_ID;
		private decimal existing_Qty;
		private decimal existing_Weight;
		private decimal consumed_Qty;
		private decimal consumed_Weight;
		private decimal unitCost;
		private decimal totalCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF class.
		/// </summary>
		public tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF class.
		/// </summary>
		public tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(int line_No, string subIn_ID, string item_ID_SF, string item_ID, string uom_ID, decimal existing_Qty, decimal existing_Weight, decimal consumed_Qty, decimal consumed_Weight, decimal unitCost, decimal totalCost) {
			this.line_No = line_No;
			this.subIn_ID = subIn_ID;
			this.item_ID_SF = item_ID_SF;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.existing_Qty = existing_Qty;
			this.existing_Weight = existing_Weight;
			this.consumed_Qty = consumed_Qty;
			this.consumed_Weight = consumed_Weight;
			this.unitCost = unitCost;
			this.totalCost = totalCost;
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
		/// Gets or sets the Item_ID_SF value.
		/// </summary>
		public string Item_ID_SF {
			get { return item_ID_SF; }
			set { item_ID_SF = value; }
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
		/// Gets or sets the Existing_Qty value.
		/// </summary>
		public decimal Existing_Qty {
			get { return existing_Qty; }
			set { existing_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Existing_Weight value.
		/// </summary>
		public decimal Existing_Weight {
			get { return existing_Weight; }
			set { existing_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Consumed_Qty value.
		/// </summary>
		public decimal Consumed_Qty {
			get { return consumed_Qty; }
			set { consumed_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Consumed_Weight value.
		/// </summary>
		public decimal Consumed_Weight {
			get { return consumed_Weight; }
			set { consumed_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitCost value.
		/// </summary>
		public decimal UnitCost {
			get { return unitCost; }
			set { unitCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalCost value.
		/// </summary>
		public decimal TotalCost {
			get { return totalCost; }
			set { totalCost = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_SF", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@existing_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@existing_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@consumed_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@consumed_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
			scom.Parameters["@item_ID_SF"].Value = item_ID_SF;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@existing_Qty"].Value = existing_Qty;
			scom.Parameters["@existing_Weight"].Value = existing_Weight;
			scom.Parameters["@consumed_Qty"].Value = consumed_Qty;
			scom.Parameters["@consumed_Weight"].Value = consumed_Weight;
			scom.Parameters["@unitCost"].Value = unitCost;
			scom.Parameters["@totalCost"].Value = totalCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_SF", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@existing_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@existing_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@consumed_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@consumed_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
			scom.Parameters["@item_ID_SF"].Value = item_ID_SF;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@existing_Qty"].Value = existing_Qty;
			scom.Parameters["@existing_Weight"].Value = existing_Weight;
			scom.Parameters["@consumed_Qty"].Value = consumed_Qty;
			scom.Parameters["@consumed_Weight"].Value = consumed_Weight;
			scom.Parameters["@unitCost"].Value = unitCost;
			scom.Parameters["@totalCost"].Value = totalCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFDelete", scon);
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
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by a foreign key.
		/// </summary>
		public static void DeleteAllBySubIn_ID(string subIn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFDeleteAllBySubIn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_SF(string item_ID_SF) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFDeleteAllByItem_ID_SF", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID_SF", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_SF"].Value = item_ID_SF;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table.
		/// </summary>
		public static tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF Select(int line_No_Incoming, string subIn_ID_Incoming){

			tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFins = new tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@subIn_ID"].Value = subIn_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFins = Maketbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(dataReader);
				} else {
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFins = null;
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList = new List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF = Maketbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(dataReader);
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList.Add(tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList = new List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF = Maketbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(dataReader);
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList.Add(tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> SelectAllBySubIn_ID(string subIn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFSelectAllBySubIn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
				List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList = new List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF = Maketbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(dataReader);
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList.Add(tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList = new List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF = Maketbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(dataReader);
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList.Add(tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> SelectAllByItem_ID_SF(string item_ID_SF) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFSelectAllByItem_ID_SF", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_SF", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_SF"].Value = item_ID_SF;
				List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF> tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList = new List<tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF = Maketbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(dataReader);
					tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList.Add(tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNote_ConsumedMaterial_ForSFList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF Maketbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(SqlDataReader dataReader) {
			tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF = new tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.SubIn_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.Item_ID_SF = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.Uom_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.Existing_Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.Existing_Weight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.Consumed_Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.Consumed_Weight = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.UnitCost = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.TotalCost = dataReader.GetDecimal(10);
			}

			return tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF;
		}
		/// <summary>
		/// This makes tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF  tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_subIn_ID = new DataColumn("subIn_ID" , typeof(string));
			DataColumn col_item_ID_SF = new DataColumn("item_ID_SF" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_existing_Qty = new DataColumn("existing_Qty" , typeof(decimal));
			DataColumn col_existing_Weight = new DataColumn("existing_Weight" , typeof(decimal));
			DataColumn col_consumed_Qty = new DataColumn("consumed_Qty" , typeof(decimal));
			DataColumn col_consumed_Weight = new DataColumn("consumed_Weight" , typeof(decimal));
			DataColumn col_unitCost = new DataColumn("unitCost" , typeof(decimal));
			DataColumn col_totalCost = new DataColumn("totalCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_subIn_ID,col_item_ID_SF,col_item_ID,col_uom_ID,col_existing_Qty,col_existing_Weight,col_consumed_Qty,col_consumed_Weight,col_unitCost,col_totalCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["subIn_ID"] = user.subIn_ID;
			drow["item_ID_SF"] = user.item_ID_SF;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["existing_Qty"] = user.existing_Qty;
			drow["existing_Weight"] = user.existing_Weight;
			drow["consumed_Qty"] = user.consumed_Qty;
			drow["consumed_Weight"] = user.consumed_Weight;
			drow["unitCost"] = user.unitCost;
			drow["totalCost"] = user.totalCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
