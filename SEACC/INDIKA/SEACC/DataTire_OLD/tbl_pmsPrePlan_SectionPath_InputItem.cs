using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsPrePlan_SectionPath_InputItem {
		#region Fields
		private int line_NoInput;
		private int line_No;
		private string prePlan_ID;
		private string section_ID;
		private string item_ID;
		private decimal qty;
		private decimal weight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsPrePlan_SectionPath_InputItem class.
		/// </summary>
		public tbl_pmsPrePlan_SectionPath_InputItem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsPrePlan_SectionPath_InputItem class.
		/// </summary>
		public tbl_pmsPrePlan_SectionPath_InputItem(int line_NoInput, int line_No, string prePlan_ID, string section_ID, string item_ID, decimal qty, decimal weight) {
			this.line_NoInput = line_NoInput;
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.item_ID = item_ID;
			this.qty = qty;
			this.weight = weight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_NoInput value.
		/// </summary>
		public int Line_NoInput {
			get { return line_NoInput; }
			set { line_NoInput = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsPrePlan_SectionPath_InputItem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoInput", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_NoInput"].Value = line_NoInput;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsPrePlan_SectionPath_InputItem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoInput", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_NoInput"].Value = line_NoInput;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsPrePlan_SectionPath_InputItem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_NoInput", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoInput"].Value = line_NoInput;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_InputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrePlan_ID(string prePlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemDeleteAllByPrePlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_InputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_InputItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_PrePlan_ID_Section_ID(int line_No, string prePlan_ID, string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemDeleteAllByLine_No_PrePlan_ID_Section_ID", scon);
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
		/// Selects a single record from the tbl_pmsPrePlan_SectionPath_InputItem table.
		/// </summary>
		public static tbl_pmsPrePlan_SectionPath_InputItem Select(int line_NoInput_Incoming, int line_No_Incoming, string prePlan_ID_Incoming, string section_ID_Incoming, string item_ID_Incoming){

			tbl_pmsPrePlan_SectionPath_InputItem tbl_pmsPrePlan_SectionPath_InputItemins = new tbl_pmsPrePlan_SectionPath_InputItem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoInput", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoInput"].Value = line_NoInput_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_InputItemins = Maketbl_pmsPrePlan_SectionPath_InputItem(dataReader);
				} else {
					tbl_pmsPrePlan_SectionPath_InputItemins = null;
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_InputItemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_InputItem table.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath_InputItem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsPrePlan_SectionPath_InputItem> tbl_pmsPrePlan_SectionPath_InputItemList = new List<tbl_pmsPrePlan_SectionPath_InputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_InputItem tbl_pmsPrePlan_SectionPath_InputItem = Maketbl_pmsPrePlan_SectionPath_InputItem(dataReader);
					tbl_pmsPrePlan_SectionPath_InputItemList.Add(tbl_pmsPrePlan_SectionPath_InputItem);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_InputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_InputItem table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath_InputItem> SelectAllByPrePlan_ID(string prePlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemSelectAllByPrePlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
				List<tbl_pmsPrePlan_SectionPath_InputItem> tbl_pmsPrePlan_SectionPath_InputItemList = new List<tbl_pmsPrePlan_SectionPath_InputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_InputItem tbl_pmsPrePlan_SectionPath_InputItem = Maketbl_pmsPrePlan_SectionPath_InputItem(dataReader);
					tbl_pmsPrePlan_SectionPath_InputItemList.Add(tbl_pmsPrePlan_SectionPath_InputItem);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_InputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_InputItem table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath_InputItem> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_pmsPrePlan_SectionPath_InputItem> tbl_pmsPrePlan_SectionPath_InputItemList = new List<tbl_pmsPrePlan_SectionPath_InputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_InputItem tbl_pmsPrePlan_SectionPath_InputItem = Maketbl_pmsPrePlan_SectionPath_InputItem(dataReader);
					tbl_pmsPrePlan_SectionPath_InputItemList.Add(tbl_pmsPrePlan_SectionPath_InputItem);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_InputItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath_InputItem table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath_InputItem> SelectAllByLine_No_PrePlan_ID_Section_ID(int line_No, string prePlan_ID, string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPath_InputItemSelectAllByLine_No_PrePlan_ID_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_pmsPrePlan_SectionPath_InputItem> tbl_pmsPrePlan_SectionPath_InputItemList = new List<tbl_pmsPrePlan_SectionPath_InputItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath_InputItem tbl_pmsPrePlan_SectionPath_InputItem = Maketbl_pmsPrePlan_SectionPath_InputItem(dataReader);
					tbl_pmsPrePlan_SectionPath_InputItemList.Add(tbl_pmsPrePlan_SectionPath_InputItem);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPath_InputItemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsPrePlan_SectionPath_InputItem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsPrePlan_SectionPath_InputItem Maketbl_pmsPrePlan_SectionPath_InputItem(SqlDataReader dataReader) {
			tbl_pmsPrePlan_SectionPath_InputItem tbl_pmsPrePlan_SectionPath_InputItem = new tbl_pmsPrePlan_SectionPath_InputItem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsPrePlan_SectionPath_InputItem.Line_NoInput = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsPrePlan_SectionPath_InputItem.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsPrePlan_SectionPath_InputItem.PrePlan_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsPrePlan_SectionPath_InputItem.Section_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsPrePlan_SectionPath_InputItem.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsPrePlan_SectionPath_InputItem.Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsPrePlan_SectionPath_InputItem.Weight = dataReader.GetDecimal(6);
			}

			return tbl_pmsPrePlan_SectionPath_InputItem;
		}
		/// <summary>
		/// This makes tbl_pmsPrePlan_SectionPath_InputItem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsPrePlan_SectionPath_InputItem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsPrePlan_SectionPath_InputItem  tbl_pmsPrePlan_SectionPath_InputItem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_NoInput = new DataColumn("line_NoInput" , typeof(int));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_NoInput,col_line_No,col_prePlan_ID,col_section_ID,col_item_ID,col_qty,col_weight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsPrePlan_SectionPath_InputItem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsPrePlan_SectionPath_InputItem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsPrePlan_SectionPath_InputItem user) {
		DataRow drow = dt.NewRow();
		
			drow["line_NoInput"] = user.line_NoInput;
			drow["line_No"] = user.line_No;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["item_ID"] = user.item_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
