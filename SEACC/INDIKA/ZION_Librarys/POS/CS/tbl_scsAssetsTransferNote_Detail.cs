using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsAssetsTransferNote_Detail {
		#region Fields
		private int line_No;
		private string assetsTransferNote_ID;
		private string item_ID;
		private string fixedAsset_Code;
		private string remarks;
		private decimal cost_FIFO;
		private decimal weightedAvgCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsAssetsTransferNote_Detail class.
		/// </summary>
		public tbl_scsAssetsTransferNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsAssetsTransferNote_Detail class.
		/// </summary>
		public tbl_scsAssetsTransferNote_Detail(int line_No, string assetsTransferNote_ID, string item_ID, string fixedAsset_Code, string remarks, decimal cost_FIFO, decimal weightedAvgCost) {
			this.line_No = line_No;
			this.assetsTransferNote_ID = assetsTransferNote_ID;
			this.item_ID = item_ID;
			this.fixedAsset_Code = fixedAsset_Code;
			this.remarks = remarks;
			this.cost_FIFO = cost_FIFO;
			this.weightedAvgCost = weightedAvgCost;
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
		/// Gets or sets the AssetsTransferNote_ID value.
		/// </summary>
		public string AssetsTransferNote_ID {
			get { return assetsTransferNote_ID; }
			set { assetsTransferNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FixedAsset_Code value.
		/// </summary>
		public string FixedAsset_Code {
			get { return fixedAsset_Code; }
			set { fixedAsset_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_FIFO value.
		/// </summary>
		public decimal Cost_FIFO {
			get { return cost_FIFO; }
			set { cost_FIFO = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightedAvgCost value.
		/// </summary>
		public decimal WeightedAvgCost {
			get { return weightedAvgCost; }
			set { weightedAvgCost = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsAssetsTransferNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@assetsTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fixedAsset_Code", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@assetsTransferNote_ID"].Value = assetsTransferNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@fixedAsset_Code"].Value = fixedAsset_Code;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@cost_FIFO"].Value = cost_FIFO;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsAssetsTransferNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@assetsTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fixedAsset_Code", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@assetsTransferNote_ID"].Value = assetsTransferNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@fixedAsset_Code"].Value = fixedAsset_Code;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@cost_FIFO"].Value = cost_FIFO;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsAssetsTransferNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@assetsTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@assetsTransferNote_ID"].Value = assetsTransferNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsAssetsTransferNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsAssetsTransferNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByAssetsTransferNote_ID(string assetsTransferNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailDeleteAllByAssetsTransferNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assetsTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@assetsTransferNote_ID"].Value = assetsTransferNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsAssetsTransferNote_Detail table.
		/// </summary>
		public static tbl_scsAssetsTransferNote_Detail Select(int line_No_Incoming, string assetsTransferNote_ID_Incoming){

			tbl_scsAssetsTransferNote_Detail tbl_scsAssetsTransferNote_Detailins = new tbl_scsAssetsTransferNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@assetsTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@assetsTransferNote_ID"].Value = assetsTransferNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsAssetsTransferNote_Detailins = Maketbl_scsAssetsTransferNote_Detail(dataReader);
				} else {
					tbl_scsAssetsTransferNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsAssetsTransferNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsAssetsTransferNote_Detail table.
		/// </summary>
		public static List<tbl_scsAssetsTransferNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsAssetsTransferNote_Detail> tbl_scsAssetsTransferNote_DetailList = new List<tbl_scsAssetsTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsAssetsTransferNote_Detail tbl_scsAssetsTransferNote_Detail = Maketbl_scsAssetsTransferNote_Detail(dataReader);
					tbl_scsAssetsTransferNote_DetailList.Add(tbl_scsAssetsTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsAssetsTransferNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsAssetsTransferNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsAssetsTransferNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsAssetsTransferNote_Detail> tbl_scsAssetsTransferNote_DetailList = new List<tbl_scsAssetsTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsAssetsTransferNote_Detail tbl_scsAssetsTransferNote_Detail = Maketbl_scsAssetsTransferNote_Detail(dataReader);
					tbl_scsAssetsTransferNote_DetailList.Add(tbl_scsAssetsTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsAssetsTransferNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsAssetsTransferNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsAssetsTransferNote_Detail> SelectAllByAssetsTransferNote_ID(string assetsTransferNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsAssetsTransferNote_DetailSelectAllByAssetsTransferNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assetsTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@assetsTransferNote_ID"].Value = assetsTransferNote_ID;
				List<tbl_scsAssetsTransferNote_Detail> tbl_scsAssetsTransferNote_DetailList = new List<tbl_scsAssetsTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsAssetsTransferNote_Detail tbl_scsAssetsTransferNote_Detail = Maketbl_scsAssetsTransferNote_Detail(dataReader);
					tbl_scsAssetsTransferNote_DetailList.Add(tbl_scsAssetsTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsAssetsTransferNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsAssetsTransferNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsAssetsTransferNote_Detail Maketbl_scsAssetsTransferNote_Detail(SqlDataReader dataReader) {
			tbl_scsAssetsTransferNote_Detail tbl_scsAssetsTransferNote_Detail = new tbl_scsAssetsTransferNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsAssetsTransferNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsAssetsTransferNote_Detail.AssetsTransferNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsAssetsTransferNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsAssetsTransferNote_Detail.FixedAsset_Code = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsAssetsTransferNote_Detail.Remarks = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsAssetsTransferNote_Detail.Cost_FIFO = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsAssetsTransferNote_Detail.WeightedAvgCost = dataReader.GetDecimal(6);
			}

			return tbl_scsAssetsTransferNote_Detail;
		}
		/// <summary>
		/// This makes tbl_scsAssetsTransferNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsAssetsTransferNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsAssetsTransferNote_Detail  tbl_scsAssetsTransferNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_assetsTransferNote_ID = new DataColumn("assetsTransferNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_fixedAsset_Code = new DataColumn("fixedAsset_Code" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_cost_FIFO = new DataColumn("cost_FIFO" , typeof(decimal));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_assetsTransferNote_ID,col_item_ID,col_fixedAsset_Code,col_remarks,col_cost_FIFO,col_weightedAvgCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsAssetsTransferNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsAssetsTransferNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsAssetsTransferNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["assetsTransferNote_ID"] = user.assetsTransferNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["fixedAsset_Code"] = user.fixedAsset_Code;
			drow["remarks"] = user.remarks;
			drow["cost_FIFO"] = user.cost_FIFO;
			drow["weightedAvgCost"] = user.weightedAvgCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
