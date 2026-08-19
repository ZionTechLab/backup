using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxJobCard_SubIn_SFG_Material {
		#region Fields
		private string prodJob_ID;
		private int line_no;
		private int line_no_detail;
		private bool isSubOutRawMaterial;
		private string item_ID;
		private bool isSelect;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_SubIn_SFG_Material class.
		/// </summary>
		public tbl_prodTxJobCard_SubIn_SFG_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_SubIn_SFG_Material class.
		/// </summary>
		public tbl_prodTxJobCard_SubIn_SFG_Material(string prodJob_ID, int line_no, int line_no_detail, bool isSubOutRawMaterial, string item_ID, bool isSelect) {
			this.prodJob_ID = prodJob_ID;
			this.line_no = line_no;
			this.line_no_detail = line_no_detail;
			this.isSubOutRawMaterial = isSubOutRawMaterial;
			this.item_ID = item_ID;
			this.isSelect = isSelect;
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
		/// Gets or sets the Line_no_detail value.
		/// </summary>
		public int Line_no_detail {
			get { return line_no_detail; }
			set { line_no_detail = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSubOutRawMaterial value.
		/// </summary>
		public bool IsSubOutRawMaterial {
			get { return isSubOutRawMaterial; }
			set { isSubOutRawMaterial = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSelect value.
		/// </summary>
		public bool IsSelect {
			get { return isSelect; }
			set { isSelect = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxJobCard_SubIn_SFG_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@line_no_detail", SqlDbType.Int,4);
			scom.Parameters.Add("@isSubOutRawMaterial", SqlDbType.Bit,1);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSelect", SqlDbType.Bit,1);
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_no"].Value = line_no;
			scom.Parameters["@line_no_detail"].Value = line_no_detail;
			scom.Parameters["@isSubOutRawMaterial"].Value = isSubOutRawMaterial;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@isSelect"].Value = isSelect;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxJobCard_SubIn_SFG_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@line_no_detail", SqlDbType.Int,4);
			scom.Parameters.Add("@isSubOutRawMaterial", SqlDbType.Bit,1);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSelect", SqlDbType.Bit,1);
 
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_no"].Value = line_no;
			scom.Parameters["@line_no_detail"].Value = line_no_detail;
			scom.Parameters["@isSubOutRawMaterial"].Value = isSubOutRawMaterial;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@isSelect"].Value = isSelect;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxJobCard_SubIn_SFG_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@line_no_detail", SqlDbType.Int,4);
			scom.Parameters.Add("@isSubOutRawMaterial", SqlDbType.Bit,1);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scom.Parameters["@line_no"].Value = line_no;
 
			scom.Parameters["@line_no_detail"].Value = line_no_detail;
 
			scom.Parameters["@isSubOutRawMaterial"].Value = isSubOutRawMaterial;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID_Line_no(string prodJob_ID, int line_no) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialDeleteAllByProdJob_ID_Line_no", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_no"].Value = line_no;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxJobCard_SubIn_SFG_Material table.
		/// </summary>
		public static tbl_prodTxJobCard_SubIn_SFG_Material Select(string prodJob_ID_Incoming, int line_no_Incoming, int line_no_detail_Incoming, bool isSubOutRawMaterial_Incoming){

			tbl_prodTxJobCard_SubIn_SFG_Material tbl_prodTxJobCard_SubIn_SFG_Materialins = new tbl_prodTxJobCard_SubIn_SFG_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@line_no_detail", SqlDbType.Int,4);
			scom.Parameters.Add("@isSubOutRawMaterial", SqlDbType.Bit,1);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			scom.Parameters["@line_no"].Value = line_no_Incoming;
			scom.Parameters["@line_no_detail"].Value = line_no_detail_Incoming;
			scom.Parameters["@isSubOutRawMaterial"].Value = isSubOutRawMaterial_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG_Materialins = Maketbl_prodTxJobCard_SubIn_SFG_Material(dataReader);
				} else {
					tbl_prodTxJobCard_SubIn_SFG_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFG_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG_Material table.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxJobCard_SubIn_SFG_Material> tbl_prodTxJobCard_SubIn_SFG_MaterialList = new List<tbl_prodTxJobCard_SubIn_SFG_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG_Material tbl_prodTxJobCard_SubIn_SFG_Material = Maketbl_prodTxJobCard_SubIn_SFG_Material(dataReader);
					tbl_prodTxJobCard_SubIn_SFG_MaterialList.Add(tbl_prodTxJobCard_SubIn_SFG_Material);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFG_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG_Material> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxJobCard_SubIn_SFG_Material> tbl_prodTxJobCard_SubIn_SFG_MaterialList = new List<tbl_prodTxJobCard_SubIn_SFG_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG_Material tbl_prodTxJobCard_SubIn_SFG_Material = Maketbl_prodTxJobCard_SubIn_SFG_Material(dataReader);
					tbl_prodTxJobCard_SubIn_SFG_MaterialList.Add(tbl_prodTxJobCard_SubIn_SFG_Material);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFG_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxJobCard_SubIn_SFG_Material> tbl_prodTxJobCard_SubIn_SFG_MaterialList = new List<tbl_prodTxJobCard_SubIn_SFG_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG_Material tbl_prodTxJobCard_SubIn_SFG_Material = Maketbl_prodTxJobCard_SubIn_SFG_Material(dataReader);
					tbl_prodTxJobCard_SubIn_SFG_MaterialList.Add(tbl_prodTxJobCard_SubIn_SFG_Material);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFG_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_SubIn_SFG_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_SubIn_SFG_Material> SelectAllByProdJob_ID_Line_no(string prodJob_ID, int line_no) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_SubIn_SFG_MaterialSelectAllByProdJob_ID_Line_no", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@line_no"].Value = line_no;
				List<tbl_prodTxJobCard_SubIn_SFG_Material> tbl_prodTxJobCard_SubIn_SFG_MaterialList = new List<tbl_prodTxJobCard_SubIn_SFG_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_SubIn_SFG_Material tbl_prodTxJobCard_SubIn_SFG_Material = Maketbl_prodTxJobCard_SubIn_SFG_Material(dataReader);
					tbl_prodTxJobCard_SubIn_SFG_MaterialList.Add(tbl_prodTxJobCard_SubIn_SFG_Material);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_SubIn_SFG_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxJobCard_SubIn_SFG_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxJobCard_SubIn_SFG_Material Maketbl_prodTxJobCard_SubIn_SFG_Material(SqlDataReader dataReader) {
			tbl_prodTxJobCard_SubIn_SFG_Material tbl_prodTxJobCard_SubIn_SFG_Material = new tbl_prodTxJobCard_SubIn_SFG_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxJobCard_SubIn_SFG_Material.ProdJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxJobCard_SubIn_SFG_Material.Line_no = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxJobCard_SubIn_SFG_Material.Line_no_detail = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxJobCard_SubIn_SFG_Material.IsSubOutRawMaterial = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxJobCard_SubIn_SFG_Material.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxJobCard_SubIn_SFG_Material.IsSelect = dataReader.GetBoolean(5);
			}

			return tbl_prodTxJobCard_SubIn_SFG_Material;
		}
		/// <summary>
		/// This makes tbl_prodTxJobCard_SubIn_SFG_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_SubIn_SFG_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxJobCard_SubIn_SFG_Material  tbl_prodTxJobCard_SubIn_SFG_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_line_no = new DataColumn("line_no" , typeof(int));
			DataColumn col_line_no_detail = new DataColumn("line_no_detail" , typeof(int));
			DataColumn col_isSubOutRawMaterial = new DataColumn("isSubOutRawMaterial" , typeof(bool));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_isSelect = new DataColumn("isSelect" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_prodJob_ID,col_line_no,col_line_no_detail,col_isSubOutRawMaterial,col_item_ID,col_isSelect,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxJobCard_SubIn_SFG_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_SubIn_SFG_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxJobCard_SubIn_SFG_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["line_no"] = user.line_no;
			drow["line_no_detail"] = user.line_no_detail;
			drow["isSubOutRawMaterial"] = user.isSubOutRawMaterial;
			drow["item_ID"] = user.item_ID;
			drow["isSelect"] = user.isSelect;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
