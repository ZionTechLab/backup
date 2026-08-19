using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxJobCard_SectionSMV {
		#region Fields
		private int line_No;
		private string prodJob_ID;
		private string prodSection_ID;
		private decimal smv_TimeMinutes;
		private decimal smv_RatePerMinute;
		private decimal cost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_SectionSMV class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_SectionSMV() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_SectionSMV class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_SectionSMV(int line_No, string prodJob_ID, string prodSection_ID, decimal smv_TimeMinutes, decimal smv_RatePerMinute, decimal cost) {
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.prodSection_ID = prodSection_ID;
			this.smv_TimeMinutes = smv_TimeMinutes;
			this.smv_RatePerMinute = smv_RatePerMinute;
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
		/// Gets or sets the ProdSection_ID value.
		/// </summary>
		public string ProdSection_ID {
			get { return prodSection_ID; }
			set { prodSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Smv_TimeMinutes value.
		/// </summary>
		public decimal Smv_TimeMinutes {
			get { return smv_TimeMinutes; }
			set { smv_TimeMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the Smv_RatePerMinute value.
		/// </summary>
		public decimal Smv_RatePerMinute {
			get { return smv_RatePerMinute; }
			set { smv_RatePerMinute = value; }
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
		/// Saves a record to the tbl_prod_pharmaTxJobCard_SectionSMV table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@smv_TimeMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@smv_RatePerMinute", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodSection_ID"].Value = prodSection_ID;
			scom.Parameters["@smv_TimeMinutes"].Value = smv_TimeMinutes;
			scom.Parameters["@smv_RatePerMinute"].Value = smv_RatePerMinute;
			scom.Parameters["@cost"].Value = cost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxJobCard_SectionSMV table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@smv_TimeMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@smv_RatePerMinute", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodSection_ID"].Value = prodSection_ID;
			scom.Parameters["@smv_TimeMinutes"].Value = smv_TimeMinutes;
			scom.Parameters["@smv_RatePerMinute"].Value = smv_RatePerMinute;
			scom.Parameters["@cost"].Value = cost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxJobCard_SectionSMV table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVDelete", scon);
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
		/// Selects all records from the tbl_prod_pharmaTxJobCard_SectionSMV table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdSection_ID(string prodSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVDeleteAllByProdSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodSection_ID"].Value = prodSection_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_SectionSMV table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxJobCard_SectionSMV table.
		/// </summary>
		public static tbl_prod_pharmaTxJobCard_SectionSMV Select(int line_No_Incoming, string prodJob_ID_Incoming){

			tbl_prod_pharmaTxJobCard_SectionSMV tbl_prod_pharmaTxJobCard_SectionSMVins = new tbl_prod_pharmaTxJobCard_SectionSMV();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_SectionSMVins = Maketbl_prod_pharmaTxJobCard_SectionSMV(dataReader);
				} else {
					tbl_prod_pharmaTxJobCard_SectionSMVins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_SectionSMVins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_SectionSMV table.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_SectionSMV> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxJobCard_SectionSMV> tbl_prod_pharmaTxJobCard_SectionSMVList = new List<tbl_prod_pharmaTxJobCard_SectionSMV>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_SectionSMV tbl_prod_pharmaTxJobCard_SectionSMV = Maketbl_prod_pharmaTxJobCard_SectionSMV(dataReader);
					tbl_prod_pharmaTxJobCard_SectionSMVList.Add(tbl_prod_pharmaTxJobCard_SectionSMV);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_SectionSMVList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_SectionSMV table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_SectionSMV> SelectAllByProdSection_ID(string prodSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVSelectAllByProdSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodSection_ID"].Value = prodSection_ID;
				List<tbl_prod_pharmaTxJobCard_SectionSMV> tbl_prod_pharmaTxJobCard_SectionSMVList = new List<tbl_prod_pharmaTxJobCard_SectionSMV>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_SectionSMV tbl_prod_pharmaTxJobCard_SectionSMV = Maketbl_prod_pharmaTxJobCard_SectionSMV(dataReader);
					tbl_prod_pharmaTxJobCard_SectionSMVList.Add(tbl_prod_pharmaTxJobCard_SectionSMV);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_SectionSMVList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_SectionSMV table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_SectionSMV> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_SectionSMVSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxJobCard_SectionSMV> tbl_prod_pharmaTxJobCard_SectionSMVList = new List<tbl_prod_pharmaTxJobCard_SectionSMV>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_SectionSMV tbl_prod_pharmaTxJobCard_SectionSMV = Maketbl_prod_pharmaTxJobCard_SectionSMV(dataReader);
					tbl_prod_pharmaTxJobCard_SectionSMVList.Add(tbl_prod_pharmaTxJobCard_SectionSMV);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_SectionSMVList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxJobCard_SectionSMV class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxJobCard_SectionSMV Maketbl_prod_pharmaTxJobCard_SectionSMV(SqlDataReader dataReader) {
			tbl_prod_pharmaTxJobCard_SectionSMV tbl_prod_pharmaTxJobCard_SectionSMV = new tbl_prod_pharmaTxJobCard_SectionSMV();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxJobCard_SectionSMV.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxJobCard_SectionSMV.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxJobCard_SectionSMV.ProdSection_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxJobCard_SectionSMV.Smv_TimeMinutes = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxJobCard_SectionSMV.Smv_RatePerMinute = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxJobCard_SectionSMV.Cost = dataReader.GetDecimal(5);
			}

			return tbl_prod_pharmaTxJobCard_SectionSMV;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxJobCard_SectionSMV datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_SectionSMV object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxJobCard_SectionSMV  tbl_prod_pharmaTxJobCard_SectionSMV   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodSection_ID = new DataColumn("prodSection_ID" , typeof(string));
			DataColumn col_smv_TimeMinutes = new DataColumn("smv_TimeMinutes" , typeof(decimal));
			DataColumn col_smv_RatePerMinute = new DataColumn("smv_RatePerMinute" , typeof(decimal));
			DataColumn col_cost = new DataColumn("cost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_prodJob_ID,col_prodSection_ID,col_smv_TimeMinutes,col_smv_RatePerMinute,col_cost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxJobCard_SectionSMV datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_SectionSMV object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxJobCard_SectionSMV user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodSection_ID"] = user.prodSection_ID;
			drow["smv_TimeMinutes"] = user.smv_TimeMinutes;
			drow["smv_RatePerMinute"] = user.smv_RatePerMinute;
			drow["cost"] = user.cost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
