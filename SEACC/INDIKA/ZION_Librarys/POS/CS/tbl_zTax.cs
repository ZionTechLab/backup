using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zTax {
		#region Fields
		private string tax_ID;
		private string taxName;
		private decimal taxPesentage;
		private string payableGl_ID;
		private string receivableGl_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zTax class.
		/// </summary>
		public tbl_zTax() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zTax class.
		/// </summary>
		public tbl_zTax(string tax_ID, string taxName, decimal taxPesentage, string payableGl_ID, string receivableGl_ID) {
			this.tax_ID = tax_ID;
			this.taxName = taxName;
			this.taxPesentage = taxPesentage;
			this.payableGl_ID = payableGl_ID;
			this.receivableGl_ID = receivableGl_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tax_ID value.
		/// </summary>
		public string Tax_ID {
			get { return tax_ID; }
			set { tax_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaxName value.
		/// </summary>
		public string TaxName {
			get { return taxName; }
			set { taxName = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaxPesentage value.
		/// </summary>
		public decimal TaxPesentage {
			get { return taxPesentage; }
			set { taxPesentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayableGl_ID value.
		/// </summary>
		public string PayableGl_ID {
			get { return payableGl_ID; }
			set { payableGl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceivableGl_ID value.
		/// </summary>
		public string ReceivableGl_ID {
			get { return receivableGl_ID; }
			set { receivableGl_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zTax table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTaxInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tax_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@taxName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@taxPesentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@payableGl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receivableGl_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@tax_ID"].Value = tax_ID;
			scom.Parameters["@taxName"].Value = taxName;
			scom.Parameters["@taxPesentage"].Value = taxPesentage;
			scom.Parameters["@payableGl_ID"].Value = payableGl_ID;
			scom.Parameters["@receivableGl_ID"].Value = receivableGl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zTax table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTaxUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tax_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@taxName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@taxPesentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@payableGl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receivableGl_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@tax_ID"].Value = tax_ID;
			scom.Parameters["@taxName"].Value = taxName;
			scom.Parameters["@taxPesentage"].Value = taxPesentage;
			scom.Parameters["@payableGl_ID"].Value = payableGl_ID;
			scom.Parameters["@receivableGl_ID"].Value = receivableGl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zTax table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTaxDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tax_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tax_ID"].Value = tax_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zTax table.
		/// </summary>
		public static tbl_zTax Select(string tax_ID_Incoming){

			tbl_zTax tbl_zTaxins = new tbl_zTax();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTaxSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tax_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tax_ID"].Value = tax_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zTaxins = Maketbl_zTax(dataReader);
				} else {
					tbl_zTaxins = null;
				}
			}
			scon.Close();
			return tbl_zTaxins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zTax table.
		/// </summary>
		public static List<tbl_zTax> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTaxSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zTax> tbl_zTaxList = new List<tbl_zTax>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zTax tbl_zTax = Maketbl_zTax(dataReader);
					tbl_zTaxList.Add(tbl_zTax);
				}
			}
			scon.Close();
			return tbl_zTaxList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zTax class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zTax Maketbl_zTax(SqlDataReader dataReader) {
			tbl_zTax tbl_zTax = new tbl_zTax();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zTax.Tax_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zTax.TaxName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zTax.TaxPesentage = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zTax.PayableGl_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zTax.ReceivableGl_ID = dataReader.GetString(4);
			}

			return tbl_zTax;
		}
		/// <summary>
		/// This makes tbl_zTax datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zTax object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zTax  tbl_zTax   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tax_ID = new DataColumn("tax_ID" , typeof(string));
			DataColumn col_taxName = new DataColumn("taxName" , typeof(string));
			DataColumn col_taxPesentage = new DataColumn("taxPesentage" , typeof(decimal));
			DataColumn col_payableGl_ID = new DataColumn("payableGl_ID" , typeof(string));
			DataColumn col_receivableGl_ID = new DataColumn("receivableGl_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_tax_ID,col_taxName,col_taxPesentage,col_payableGl_ID,col_receivableGl_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zTax datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zTax object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zTax user) {
		DataRow drow = dt.NewRow();
		
			drow["tax_ID"] = user.tax_ID;
			drow["taxName"] = user.taxName;
			drow["taxPesentage"] = user.taxPesentage;
			drow["payableGl_ID"] = user.payableGl_ID;
			drow["receivableGl_ID"] = user.receivableGl_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
