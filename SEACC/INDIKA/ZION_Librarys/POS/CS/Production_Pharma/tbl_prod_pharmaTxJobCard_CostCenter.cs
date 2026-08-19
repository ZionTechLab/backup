using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxJobCard_CostCenter {
		#region Fields
		private int line_No;
		private string prodJob_ID;
		private string cost_Center_ID;
		private decimal smv;
		private decimal smv_rate;
		private decimal cost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_CostCenter class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_CostCenter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_CostCenter class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_CostCenter(int line_No, string prodJob_ID, string cost_Center_ID, decimal smv, decimal smv_rate, decimal cost) {
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.cost_Center_ID = cost_Center_ID;
			this.smv = smv;
			this.smv_rate = smv_rate;
			this.cost = cost;
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
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center_ID value.
		/// </summary>
		public string Cost_Center_ID {
			get { return cost_Center_ID; }
			set { cost_Center_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Smv value.
		/// </summary>
		public decimal Smv {
			get { return smv; }
			set { smv = value; }
		}
		
		/// <summary>
		/// Gets or sets the Smv_rate value.
		/// </summary>
		public decimal Smv_rate {
			get { return smv_rate; }
			set { smv_rate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost value.
		/// </summary>
		public decimal Cost {
			get { return cost; }
			set { cost = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxJobCard_CostCenter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@smv", SqlDbType.Decimal,9);
			scom.Parameters.Add("@smv_rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@smv"].Value = smv;
			scom.Parameters["@smv_rate"].Value = smv_rate;
			scom.Parameters["@cost"].Value = cost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxJobCard_CostCenter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@smv", SqlDbType.Decimal,9);
			scom.Parameters.Add("@smv_rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@smv"].Value = smv;
			scom.Parameters["@smv_rate"].Value = smv_rate;
			scom.Parameters["@cost"].Value = cost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxJobCard_CostCenter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostCenter table by a foreign key.
		/// </summary>
		public static void DeleteAllByCost_Center_ID(string cost_Center_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterDeleteAllByCost_Center_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostCenter table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxJobCard_CostCenter table.
		/// </summary>
		public static tbl_prod_pharmaTxJobCard_CostCenter Select(int line_No_Incoming, string prodJob_ID_Incoming){

			tbl_prod_pharmaTxJobCard_CostCenter tbl_prod_pharmaTxJobCard_CostCenterins = new tbl_prod_pharmaTxJobCard_CostCenter();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_CostCenterins = Maketbl_prod_pharmaTxJobCard_CostCenter(dataReader);
				} else {
					tbl_prod_pharmaTxJobCard_CostCenterins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_CostCenterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostCenter table.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_CostCenter> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxJobCard_CostCenter> tbl_prod_pharmaTxJobCard_CostCenterList = new List<tbl_prod_pharmaTxJobCard_CostCenter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_CostCenter tbl_prod_pharmaTxJobCard_CostCenter = Maketbl_prod_pharmaTxJobCard_CostCenter(dataReader);
					tbl_prod_pharmaTxJobCard_CostCenterList.Add(tbl_prod_pharmaTxJobCard_CostCenter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_CostCenterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostCenter table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_CostCenter> SelectAllByCost_Center_ID(string cost_Center_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterSelectAllByCost_Center_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
				List<tbl_prod_pharmaTxJobCard_CostCenter> tbl_prod_pharmaTxJobCard_CostCenterList = new List<tbl_prod_pharmaTxJobCard_CostCenter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_CostCenter tbl_prod_pharmaTxJobCard_CostCenter = Maketbl_prod_pharmaTxJobCard_CostCenter(dataReader);
					tbl_prod_pharmaTxJobCard_CostCenterList.Add(tbl_prod_pharmaTxJobCard_CostCenter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_CostCenterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostCenter table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_CostCenter> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostCenterSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxJobCard_CostCenter> tbl_prod_pharmaTxJobCard_CostCenterList = new List<tbl_prod_pharmaTxJobCard_CostCenter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_CostCenter tbl_prod_pharmaTxJobCard_CostCenter = Maketbl_prod_pharmaTxJobCard_CostCenter(dataReader);
					tbl_prod_pharmaTxJobCard_CostCenterList.Add(tbl_prod_pharmaTxJobCard_CostCenter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_CostCenterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxJobCard_CostCenter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxJobCard_CostCenter Maketbl_prod_pharmaTxJobCard_CostCenter(SqlDataReader dataReader) {
			tbl_prod_pharmaTxJobCard_CostCenter tbl_prod_pharmaTxJobCard_CostCenter = new tbl_prod_pharmaTxJobCard_CostCenter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxJobCard_CostCenter.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxJobCard_CostCenter.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxJobCard_CostCenter.Cost_Center_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxJobCard_CostCenter.Smv = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxJobCard_CostCenter.Smv_rate = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxJobCard_CostCenter.Cost = dataReader.GetDecimal(5);
			}

			return tbl_prod_pharmaTxJobCard_CostCenter;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxJobCard_CostCenter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_CostCenter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxJobCard_CostCenter  tbl_prod_pharmaTxJobCard_CostCenter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_cost_Center_ID = new DataColumn("cost_Center_ID" , typeof(string));
			DataColumn col_smv = new DataColumn("smv" , typeof(decimal));
			DataColumn col_smv_rate = new DataColumn("smv_rate" , typeof(decimal));
			DataColumn col_cost = new DataColumn("cost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_prodJob_ID,col_cost_Center_ID,col_smv,col_smv_rate,col_cost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxJobCard_CostCenter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_CostCenter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxJobCard_CostCenter user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["cost_Center_ID"] = user.cost_Center_ID;
			drow["smv"] = user.smv;
			drow["smv_rate"] = user.smv_rate;
			drow["cost"] = user.cost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
