using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxJobCard_Material_Outsource {
		#region Fields
		private int line_No;
		private int line_No_Sub1;
		private int line_No_Sub2;
		private string prodJob_ID;
		private string item_ID;
		private string uom_ID;
		private decimal qty_Outsource;
		private decimal max_OutsourceRate;
		private decimal max_OutsourceCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_Material_Outsource class.
		/// </summary>
		public tbl_prodTxJobCard_Material_Outsource() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_Material_Outsource class.
		/// </summary>
		public tbl_prodTxJobCard_Material_Outsource(int line_No, int line_No_Sub1, int line_No_Sub2, string prodJob_ID, string item_ID, string uom_ID, decimal qty_Outsource, decimal max_OutsourceRate, decimal max_OutsourceCost) {
			this.line_No = line_No;
			this.line_No_Sub1 = line_No_Sub1;
			this.line_No_Sub2 = line_No_Sub2;
			this.prodJob_ID = prodJob_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.qty_Outsource = qty_Outsource;
			this.max_OutsourceRate = max_OutsourceRate;
			this.max_OutsourceCost = max_OutsourceCost;
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
		/// Gets or sets the Qty_Outsource value.
		/// </summary>
		public decimal Qty_Outsource {
			get { return qty_Outsource; }
			set { qty_Outsource = value; }
		}
		
		/// <summary>
		/// Gets or sets the Max_OutsourceRate value.
		/// </summary>
		public decimal Max_OutsourceRate {
			get { return max_OutsourceRate; }
			set { max_OutsourceRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Max_OutsourceCost value.
		/// </summary>
		public decimal Max_OutsourceCost {
			get { return max_OutsourceCost; }
			set { max_OutsourceCost = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxJobCard_Material_Outsource table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qty_Outsource", SqlDbType.Decimal,9);
			scom.Parameters.Add("@max_OutsourceRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@max_OutsourceCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1;
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@qty_Outsource"].Value = qty_Outsource;
			scom.Parameters["@max_OutsourceRate"].Value = max_OutsourceRate;
			scom.Parameters["@max_OutsourceCost"].Value = max_OutsourceCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxJobCard_Material_Outsource table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qty_Outsource", SqlDbType.Decimal,9);
			scom.Parameters.Add("@max_OutsourceRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@max_OutsourceCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1;
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@qty_Outsource"].Value = qty_Outsource;
			scom.Parameters["@max_OutsourceRate"].Value = max_OutsourceRate;
			scom.Parameters["@max_OutsourceCost"].Value = max_OutsourceCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxJobCard_Material_Outsource table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
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
		/// Selects all records from the tbl_prodTxJobCard_Material_Outsource table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Material_Outsource table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Material_Outsource table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_Line_No_Sub1_Line_No_Sub2_ProdJob_ID(int line_No, int line_No_Sub1, int line_No_Sub2, string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceDeleteAllByLine_No_Line_No_Sub1_Line_No_Sub2_ProdJob_ID", scon);
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
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxJobCard_Material_Outsource table.
		/// </summary>
		public static tbl_prodTxJobCard_Material_Outsource Select(int line_No_Incoming, int line_No_Sub1_Incoming, int line_No_Sub2_Incoming, string prodJob_ID_Incoming){

			tbl_prodTxJobCard_Material_Outsource tbl_prodTxJobCard_Material_Outsourceins = new tbl_prodTxJobCard_Material_Outsource();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub1", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No_Sub2", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@line_No_Sub1"].Value = line_No_Sub1_Incoming;
			scom.Parameters["@line_No_Sub2"].Value = line_No_Sub2_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxJobCard_Material_Outsourceins = Maketbl_prodTxJobCard_Material_Outsource(dataReader);
				} else {
					tbl_prodTxJobCard_Material_Outsourceins = null;
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_Material_Outsourceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Material_Outsource table.
		/// </summary>
		public static List<tbl_prodTxJobCard_Material_Outsource> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxJobCard_Material_Outsource> tbl_prodTxJobCard_Material_OutsourceList = new List<tbl_prodTxJobCard_Material_Outsource>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_Material_Outsource tbl_prodTxJobCard_Material_Outsource = Maketbl_prodTxJobCard_Material_Outsource(dataReader);
					tbl_prodTxJobCard_Material_OutsourceList.Add(tbl_prodTxJobCard_Material_Outsource);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_Material_OutsourceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Material_Outsource table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_Material_Outsource> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxJobCard_Material_Outsource> tbl_prodTxJobCard_Material_OutsourceList = new List<tbl_prodTxJobCard_Material_Outsource>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_Material_Outsource tbl_prodTxJobCard_Material_Outsource = Maketbl_prodTxJobCard_Material_Outsource(dataReader);
					tbl_prodTxJobCard_Material_OutsourceList.Add(tbl_prodTxJobCard_Material_Outsource);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_Material_OutsourceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Material_Outsource table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_Material_Outsource> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxJobCard_Material_Outsource> tbl_prodTxJobCard_Material_OutsourceList = new List<tbl_prodTxJobCard_Material_Outsource>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_Material_Outsource tbl_prodTxJobCard_Material_Outsource = Maketbl_prodTxJobCard_Material_Outsource(dataReader);
					tbl_prodTxJobCard_Material_OutsourceList.Add(tbl_prodTxJobCard_Material_Outsource);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_Material_OutsourceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Material_Outsource table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_Material_Outsource> SelectAllByLine_No_Line_No_Sub1_Line_No_Sub2_ProdJob_ID(int line_No, int line_No_Sub1, int line_No_Sub2, string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_Material_OutsourceSelectAllByLine_No_Line_No_Sub1_Line_No_Sub2_ProdJob_ID", scon);
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
				List<tbl_prodTxJobCard_Material_Outsource> tbl_prodTxJobCard_Material_OutsourceList = new List<tbl_prodTxJobCard_Material_Outsource>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_Material_Outsource tbl_prodTxJobCard_Material_Outsource = Maketbl_prodTxJobCard_Material_Outsource(dataReader);
					tbl_prodTxJobCard_Material_OutsourceList.Add(tbl_prodTxJobCard_Material_Outsource);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_Material_OutsourceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxJobCard_Material_Outsource class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxJobCard_Material_Outsource Maketbl_prodTxJobCard_Material_Outsource(SqlDataReader dataReader) {
			tbl_prodTxJobCard_Material_Outsource tbl_prodTxJobCard_Material_Outsource = new tbl_prodTxJobCard_Material_Outsource();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxJobCard_Material_Outsource.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxJobCard_Material_Outsource.Line_No_Sub1 = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxJobCard_Material_Outsource.Line_No_Sub2 = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxJobCard_Material_Outsource.ProdJob_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxJobCard_Material_Outsource.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxJobCard_Material_Outsource.Uom_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxJobCard_Material_Outsource.Qty_Outsource = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxJobCard_Material_Outsource.Max_OutsourceRate = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxJobCard_Material_Outsource.Max_OutsourceCost = dataReader.GetDecimal(8);
			}

			return tbl_prodTxJobCard_Material_Outsource;
		}
		/// <summary>
		/// This makes tbl_prodTxJobCard_Material_Outsource datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_Material_Outsource object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxJobCard_Material_Outsource  tbl_prodTxJobCard_Material_Outsource   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_line_No_Sub1 = new DataColumn("line_No_Sub1" , typeof(int));
			DataColumn col_line_No_Sub2 = new DataColumn("line_No_Sub2" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_qty_Outsource = new DataColumn("qty_Outsource" , typeof(decimal));
			DataColumn col_max_OutsourceRate = new DataColumn("max_OutsourceRate" , typeof(decimal));
			DataColumn col_max_OutsourceCost = new DataColumn("max_OutsourceCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_line_No_Sub1,col_line_No_Sub2,col_prodJob_ID,col_item_ID,col_uom_ID,col_qty_Outsource,col_max_OutsourceRate,col_max_OutsourceCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxJobCard_Material_Outsource datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_Material_Outsource object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxJobCard_Material_Outsource user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["line_No_Sub1"] = user.line_No_Sub1;
			drow["line_No_Sub2"] = user.line_No_Sub2;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["qty_Outsource"] = user.qty_Outsource;
			drow["max_OutsourceRate"] = user.max_OutsourceRate;
			drow["max_OutsourceCost"] = user.max_OutsourceCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
