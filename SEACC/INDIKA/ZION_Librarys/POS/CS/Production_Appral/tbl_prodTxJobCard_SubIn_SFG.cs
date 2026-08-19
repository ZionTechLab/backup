using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxJobCard_SubIn_SFG {
		#region Fields
		private string prodJob_ID;
		private int line_no;
		private string subIn_item_ID;
		private string uom_ID;
		private decimal qty;
		private string subIn_Section;
		private int materialGrid_line_no;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_SubIn_SFG class.
		/// </summary>
		public tbl_prodTxJobCard_SubIn_SFG() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_SubIn_SFG class.
		/// </summary>
		public tbl_prodTxJobCard_SubIn_SFG(string prodJob_ID, int line_no, string subIn_item_ID, string uom_ID, decimal qty, string subIn_Section, int materialGrid_line_no) {
			this.prodJob_ID = prodJob_ID;
			this.line_no = line_no;
			this.subIn_item_ID = subIn_item_ID;
			this.uom_ID = uom_ID;
			this.qty = qty;
			this.subIn_Section = subIn_Section;
			this.materialGrid_line_no = materialGrid_line_no;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_no value.
		/// </summary>
		public int Line_no {
			get { return line_no; }
			set { line_no = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubIn_item_ID value.
		/// </summary>
		public string SubIn_item_ID {
			get { return subIn_item_ID; }
			set { subIn_item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubIn_Section value.
		/// </summary>
		public string SubIn_Section {
			get { return subIn_Section; }
			set { subIn_Section = value; }
		}
		
		/// <summary>
		/// Gets or sets the MaterialGrid_line_no value.
		/// </summary>
		public int MaterialGrid_line_no {
			get { return materialGrid_line_no; }
			set { materialGrid_line_no = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxJobCard_SubIn_SFG table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subIn_Section", SqlDbType.VarChar,20);
			scom.Parameters.Add("@materialGrid_line_no", SqlDbType.Int,4);
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_no"].Value = line_no;
			scom.Parameters["@subIn_item_ID"].Value = subIn_item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@subIn_Section"].Value = subIn_Section;
			scom.Parameters["@materialGrid_line_no"].Value = materialGrid_line_no;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxJobCard_SubIn_SFG table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@subIn_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subIn_Section", SqlDbType.VarChar,20);
			scom.Parameters.Add("@materialGrid_line_no", SqlDbType.Int,4);
 
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_no"].Value = line_no;
			scom.Parameters["@subIn_item_ID"].Value = subIn_item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@subIn_Section"].Value = subIn_Section;
			scom.Parameters["@materialGrid_line_no"].Value = materialGrid_line_no;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxJobCard_SubIn_SFG table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scom.Parameters["@line_no"].Value = line_no;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table by a foreign key.
		/// </summary>
		public static void DeleteAllBySubIn_Section(string subIn_Section) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGDeleteAllBySubIn_Section", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@subIn_Section", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_Section"].Value = subIn_Section;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table by a foreign key.
		/// </summary>
		public static void DeleteAllBySubIn_item_ID(string subIn_item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGDeleteAllBySubIn_item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@subIn_item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_item_ID"].Value = subIn_item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxJobCard_SubIn_SFG table.
		/// </summary>
		public static tbl_prodTxJobCard_SubIn_SFG Select(string prodJob_ID_Incoming, int line_no_Incoming){

			tbl_prodTxJobCard_SubIn_SFG tbl_prodTxJobCard_SubIn_SFGins = new tbl_prodTxJobCard_SubIn_SFG();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			scom.Parameters["@line_no"].Value = line_no_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFGins = Maketbl_prodTxJobCard_SubIn_SFG(dataReader);
				} else {
					tbl_prodTxJobCard_SubIn_SFGins = null;
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFGins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxJobCard_SubIn_SFG> tbl_prodTxJobCard_SubIn_SFGList = new List<tbl_prodTxJobCard_SubIn_SFG>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG tbl_prodTxJobCard_SubIn_SFG = Maketbl_prodTxJobCard_SubIn_SFG(dataReader);
					tbl_prodTxJobCard_SubIn_SFGList.Add(tbl_prodTxJobCard_SubIn_SFG);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFGList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG> SelectAllBySubIn_Section(string subIn_Section) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGSelectAllBySubIn_Section", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subIn_Section", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_Section"].Value = subIn_Section;
				List<tbl_prodTxJobCard_SubIn_SFG> tbl_prodTxJobCard_SubIn_SFGList = new List<tbl_prodTxJobCard_SubIn_SFG>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG tbl_prodTxJobCard_SubIn_SFG = Maketbl_prodTxJobCard_SubIn_SFG(dataReader);
					tbl_prodTxJobCard_SubIn_SFGList.Add(tbl_prodTxJobCard_SubIn_SFG);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFGList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG> SelectAllBySubIn_item_ID(string subIn_item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGSelectAllBySubIn_item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subIn_item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_item_ID"].Value = subIn_item_ID;
				List<tbl_prodTxJobCard_SubIn_SFG> tbl_prodTxJobCard_SubIn_SFGList = new List<tbl_prodTxJobCard_SubIn_SFG>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG tbl_prodTxJobCard_SubIn_SFG = Maketbl_prodTxJobCard_SubIn_SFG(dataReader);
					tbl_prodTxJobCard_SubIn_SFGList.Add(tbl_prodTxJobCard_SubIn_SFG);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFGList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxJobCard_SubIn_SFG> tbl_prodTxJobCard_SubIn_SFGList = new List<tbl_prodTxJobCard_SubIn_SFG>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG tbl_prodTxJobCard_SubIn_SFG = Maketbl_prodTxJobCard_SubIn_SFG(dataReader);
					tbl_prodTxJobCard_SubIn_SFGList.Add(tbl_prodTxJobCard_SubIn_SFG);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFGList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFGSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxJobCard_SubIn_SFG> tbl_prodTxJobCard_SubIn_SFGList = new List<tbl_prodTxJobCard_SubIn_SFG>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG tbl_prodTxJobCard_SubIn_SFG = Maketbl_prodTxJobCard_SubIn_SFG(dataReader);
					tbl_prodTxJobCard_SubIn_SFGList.Add(tbl_prodTxJobCard_SubIn_SFG);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFGList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxJobCard_SubIn_SFG class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxJobCard_SubIn_SFG Maketbl_prodTxJobCard_SubIn_SFG(SqlDataReader dataReader) {
			tbl_prodTxJobCard_SubIn_SFG tbl_prodTxJobCard_SubIn_SFG = new tbl_prodTxJobCard_SubIn_SFG();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxJobCard_SubIn_SFG.ProdJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxJobCard_SubIn_SFG.Line_no = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxJobCard_SubIn_SFG.SubIn_item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxJobCard_SubIn_SFG.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxJobCard_SubIn_SFG.Qty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxJobCard_SubIn_SFG.SubIn_Section = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxJobCard_SubIn_SFG.MaterialGrid_line_no = dataReader.GetInt32(6);
			}

			return tbl_prodTxJobCard_SubIn_SFG;
		}
		/// <summary>
		/// This makes tbl_prodTxJobCard_SubIn_SFG datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_SubIn_SFG object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxJobCard_SubIn_SFG  tbl_prodTxJobCard_SubIn_SFG   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_line_no = new DataColumn("line_no" , typeof(int));
			DataColumn col_subIn_item_ID = new DataColumn("subIn_item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_subIn_Section = new DataColumn("subIn_Section" , typeof(string));
			DataColumn col_materialGrid_line_no = new DataColumn("materialGrid_line_no" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_prodJob_ID,col_line_no,col_subIn_item_ID,col_uom_ID,col_qty,col_subIn_Section,col_materialGrid_line_no,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxJobCard_SubIn_SFG datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_SubIn_SFG object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxJobCard_SubIn_SFG user) {
		DataRow drow = dt.NewRow();
		
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["line_no"] = user.line_no;
			drow["subIn_item_ID"] = user.subIn_item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["qty"] = user.qty;
			drow["subIn_Section"] = user.subIn_Section;
			drow["materialGrid_line_no"] = user.materialGrid_line_no;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
