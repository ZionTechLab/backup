using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxJobCard_CostFooter {
		#region Fields
		private int line_No;
		private string prodJob_ID;
		private string footer_ID;
		private decimal percentage;
		private decimal amount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_CostFooter class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_CostFooter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_CostFooter class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_CostFooter(int line_No, string prodJob_ID, string footer_ID, decimal percentage, decimal amount) {
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.footer_ID = footer_ID;
			this.percentage = percentage;
			this.amount = amount;
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
		/// Gets or sets the Footer_ID value.
		/// </summary>
		public string Footer_ID {
			get { return footer_ID; }
			set { footer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Percentage value.
		/// </summary>
		public decimal Percentage {
			get { return percentage; }
			set { percentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxJobCard_CostFooter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@percentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@footer_ID"].Value = footer_ID;
			scom.Parameters["@percentage"].Value = percentage;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxJobCard_CostFooter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@percentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@footer_ID"].Value = footer_ID;
			scom.Parameters["@percentage"].Value = percentage;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxJobCard_CostFooter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scom.Parameters["@footer_ID"].Value = footer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostFooter table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostFooter table by a foreign key.
		/// </summary>
		public static void DeleteAllByFooter_ID(string footer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterDeleteAllByFooter_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@footer_ID"].Value = footer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxJobCard_CostFooter table.
		/// </summary>
		public static tbl_prod_pharmaTxJobCard_CostFooter Select(string prodJob_ID_Incoming, string footer_ID_Incoming){

			tbl_prod_pharmaTxJobCard_CostFooter tbl_prod_pharmaTxJobCard_CostFooterins = new tbl_prod_pharmaTxJobCard_CostFooter();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			scom.Parameters["@footer_ID"].Value = footer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_CostFooterins = Maketbl_prod_pharmaTxJobCard_CostFooter(dataReader);
				} else {
					tbl_prod_pharmaTxJobCard_CostFooterins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_CostFooterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostFooter table.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_CostFooter> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxJobCard_CostFooter> tbl_prod_pharmaTxJobCard_CostFooterList = new List<tbl_prod_pharmaTxJobCard_CostFooter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_CostFooter tbl_prod_pharmaTxJobCard_CostFooter = Maketbl_prod_pharmaTxJobCard_CostFooter(dataReader);
					tbl_prod_pharmaTxJobCard_CostFooterList.Add(tbl_prod_pharmaTxJobCard_CostFooter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_CostFooterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostFooter table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_CostFooter> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxJobCard_CostFooter> tbl_prod_pharmaTxJobCard_CostFooterList = new List<tbl_prod_pharmaTxJobCard_CostFooter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_CostFooter tbl_prod_pharmaTxJobCard_CostFooter = Maketbl_prod_pharmaTxJobCard_CostFooter(dataReader);
					tbl_prod_pharmaTxJobCard_CostFooterList.Add(tbl_prod_pharmaTxJobCard_CostFooter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_CostFooterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_CostFooter table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_CostFooter> SelectAllByFooter_ID(string footer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_CostFooterSelectAllByFooter_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@footer_ID"].Value = footer_ID;
				List<tbl_prod_pharmaTxJobCard_CostFooter> tbl_prod_pharmaTxJobCard_CostFooterList = new List<tbl_prod_pharmaTxJobCard_CostFooter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_CostFooter tbl_prod_pharmaTxJobCard_CostFooter = Maketbl_prod_pharmaTxJobCard_CostFooter(dataReader);
					tbl_prod_pharmaTxJobCard_CostFooterList.Add(tbl_prod_pharmaTxJobCard_CostFooter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_CostFooterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxJobCard_CostFooter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxJobCard_CostFooter Maketbl_prod_pharmaTxJobCard_CostFooter(SqlDataReader dataReader) {
			tbl_prod_pharmaTxJobCard_CostFooter tbl_prod_pharmaTxJobCard_CostFooter = new tbl_prod_pharmaTxJobCard_CostFooter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxJobCard_CostFooter.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxJobCard_CostFooter.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxJobCard_CostFooter.Footer_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxJobCard_CostFooter.Percentage = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxJobCard_CostFooter.Amount = dataReader.GetDecimal(4);
			}

			return tbl_prod_pharmaTxJobCard_CostFooter;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxJobCard_CostFooter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_CostFooter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxJobCard_CostFooter  tbl_prod_pharmaTxJobCard_CostFooter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_footer_ID = new DataColumn("footer_ID" , typeof(string));
			DataColumn col_percentage = new DataColumn("percentage" , typeof(decimal));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_prodJob_ID,col_footer_ID,col_percentage,col_amount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxJobCard_CostFooter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_CostFooter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxJobCard_CostFooter user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["footer_ID"] = user.footer_ID;
			drow["percentage"] = user.percentage;
			drow["amount"] = user.amount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
