using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsPrePlan_SectionPath_OutputItem {
		#region Fields
		private int line_NoOutput;
		private int line_No;
		private string prePlan_ID;
		private string section_ID;
		private string item_ID;
		private decimal qty;
		private decimal weight;
		private decimal length;
		private string uom_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsPrePlan_SectionPath_OutputItem class.
		/// </summary>
		public tbl_pmsPrePlan_SectionPath_OutputItem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsPrePlan_SectionPath_OutputItem class.
		/// </summary>
		public tbl_pmsPrePlan_SectionPath_OutputItem(int line_NoOutput, int line_No, string prePlan_ID, string section_ID, string item_ID, decimal qty, decimal weight, decimal length, string uom_ID) {
			this.line_NoOutput = line_NoOutput;
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.item_ID = item_ID;
			this.qty = qty;
			this.weight = weight;
			this.length = length;
			this.uom_ID = uom_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_NoOutput value.
		/// </summary>
		public int Line_NoOutput {
			get { return line_NoOutput; }
			set { line_NoOutput = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
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
		/// Gets or sets the Length value.
		/// </summary>
		public decimal Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsPrePlan_SectionPath_OutputItem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoOutput", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_NoOutput"].Value = line_NoOutput;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsPrePlan_SectionPath_OutputItem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoOutput", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_NoOutput"].Value = line_NoOutput;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsPrePlan_SectionPath_OutputItem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_NoOutput", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoOutput"].Value = line_NoOutput;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_OutputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_OutputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrePlan_ID(string prePlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemDeleteAllByPrePlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_OutputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_PrePlan_ID_Section_ID(int line_No, string prePlan_ID, string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemDeleteAllByLine_No_PrePlan_ID_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsPrePlan_SectionPath_OutputItem table.
		/// </summary>
		public static tbl_pmsPrePlan_SectionPath_OutputItem Select(int line_NoOutput_Incoming, int line_No_Incoming, string prePlan_ID_Incoming, string section_ID_Incoming, string item_ID_Incoming){

			tbl_pmsPrePlan_SectionPath_OutputItem tbl_pmsPrePlan_SectionPath_OutputItemins = new tbl_pmsPrePlan_SectionPath_OutputItem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoOutput", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoOutput"].Value = line_NoOutput_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_OutputItemins = Maketbl_pmsPrePlan_SectionPath_OutputItem(dataReader);
				} else {
					tbl_pmsPrePlan_SectionPath_OutputItemins = null;
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_OutputItemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_OutputItem table.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath_OutputItem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsPrePlan_SectionPath_OutputItem> tbl_pmsPrePlan_SectionPath_OutputItemList = new List<tbl_pmsPrePlan_SectionPath_OutputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_OutputItem tbl_pmsPrePlan_SectionPath_OutputItem = Maketbl_pmsPrePlan_SectionPath_OutputItem(dataReader);
					tbl_pmsPrePlan_SectionPath_OutputItemList.Add(tbl_pmsPrePlan_SectionPath_OutputItem);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_OutputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_OutputItem table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath_OutputItem> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_pmsPrePlan_SectionPath_OutputItem> tbl_pmsPrePlan_SectionPath_OutputItemList = new List<tbl_pmsPrePlan_SectionPath_OutputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_OutputItem tbl_pmsPrePlan_SectionPath_OutputItem = Maketbl_pmsPrePlan_SectionPath_OutputItem(dataReader);
					tbl_pmsPrePlan_SectionPath_OutputItemList.Add(tbl_pmsPrePlan_SectionPath_OutputItem);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_OutputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_OutputItem table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath_OutputItem> SelectAllByPrePlan_ID(string prePlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemSelectAllByPrePlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
				List<tbl_pmsPrePlan_SectionPath_OutputItem> tbl_pmsPrePlan_SectionPath_OutputItemList = new List<tbl_pmsPrePlan_SectionPath_OutputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_OutputItem tbl_pmsPrePlan_SectionPath_OutputItem = Maketbl_pmsPrePlan_SectionPath_OutputItem(dataReader);
					tbl_pmsPrePlan_SectionPath_OutputItemList.Add(tbl_pmsPrePlan_SectionPath_OutputItem);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_OutputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_OutputItem table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath_OutputItem> SelectAllByLine_No_PrePlan_ID_Section_ID(int line_No, string prePlan_ID, string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_OutputItemSelectAllByLine_No_PrePlan_ID_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_pmsPrePlan_SectionPath_OutputItem> tbl_pmsPrePlan_SectionPath_OutputItemList = new List<tbl_pmsPrePlan_SectionPath_OutputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_OutputItem tbl_pmsPrePlan_SectionPath_OutputItem = Maketbl_pmsPrePlan_SectionPath_OutputItem(dataReader);
					tbl_pmsPrePlan_SectionPath_OutputItemList.Add(tbl_pmsPrePlan_SectionPath_OutputItem);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_OutputItemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsPrePlan_SectionPath_OutputItem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsPrePlan_SectionPath_OutputItem Maketbl_pmsPrePlan_SectionPath_OutputItem(SqlDataReader dataReader) {
			tbl_pmsPrePlan_SectionPath_OutputItem tbl_pmsPrePlan_SectionPath_OutputItem = new tbl_pmsPrePlan_SectionPath_OutputItem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.Line_NoOutput = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.PrePlan_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.Section_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.Weight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.Length = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsPrePlan_SectionPath_OutputItem.Uom_ID = dataReader.GetString(8);
			}

			return tbl_pmsPrePlan_SectionPath_OutputItem;
		}
		/// <summary>
		/// This makes tbl_pmsPrePlan_SectionPath_OutputItem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsPrePlan_SectionPath_OutputItem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsPrePlan_SectionPath_OutputItem  tbl_pmsPrePlan_SectionPath_OutputItem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_NoOutput = new DataColumn("line_NoOutput" , typeof(int));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_length = new DataColumn("length" , typeof(decimal));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_NoOutput,col_line_No,col_prePlan_ID,col_section_ID,col_item_ID,col_qty,col_weight,col_length,col_uom_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsPrePlan_SectionPath_OutputItem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsPrePlan_SectionPath_OutputItem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsPrePlan_SectionPath_OutputItem user) {
		DataRow drow = dt.NewRow();
		
			drow["line_NoOutput"] = user.line_NoOutput;
			drow["line_No"] = user.line_No;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["item_ID"] = user.item_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["length"] = user.length;
			drow["uom_ID"] = user.uom_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
