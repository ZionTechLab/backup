using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaMasCostFooter {
		#region Fields
		private int line_No;
		private string footer_ID;
		private string description;
		private bool isEnable;
		private bool isTax;
		private string tax_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaMasCostFooter class.
		/// </summary>
		public tbl_prod_pharmaMasCostFooter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaMasCostFooter class.
		/// </summary>
		public tbl_prod_pharmaMasCostFooter(int line_No, string footer_ID, string description, bool isEnable, bool isTax, string tax_ID) {
			this.line_No = line_No;
			this.footer_ID = footer_ID;
			this.description = description;
			this.isEnable = isEnable;
			this.isTax = isTax;
			this.tax_ID = tax_ID;
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
		/// Gets or sets the Footer_ID value.
		/// </summary>
		public string Footer_ID {
			get { return footer_ID; }
			set { footer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEnable value.
		/// </summary>
		public bool IsEnable {
			get { return isEnable; }
			set { isEnable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTax value.
		/// </summary>
		public bool IsTax {
			get { return isTax; }
			set { isTax = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tax_ID value.
		/// </summary>
		public string Tax_ID {
			get { return tax_ID; }
			set { tax_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaMasCostFooter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostFooterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTax", SqlDbType.Bit,1);
			scom.Parameters.Add("@tax_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@footer_ID"].Value = footer_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isTax"].Value = isTax;
			scom.Parameters["@tax_ID"].Value = tax_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaMasCostFooter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostFooterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTax", SqlDbType.Bit,1);
			scom.Parameters.Add("@tax_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@footer_ID"].Value = footer_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isTax"].Value = isTax;
			scom.Parameters["@tax_ID"].Value = tax_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaMasCostFooter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostFooterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@footer_ID"].Value = footer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaMasCostFooter table by a foreign key.
		/// </summary>
		public static void DeleteAllByFooter_ID(string footer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostFooterDeleteAllByFooter_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@footer_ID"].Value = footer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaMasCostFooter table.
		/// </summary>
		public static tbl_prod_pharmaMasCostFooter Select(string footer_ID_Incoming){

			tbl_prod_pharmaMasCostFooter tbl_prod_pharmaMasCostFooterins = new tbl_prod_pharmaMasCostFooter();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostFooterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@footer_ID"].Value = footer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaMasCostFooterins = Maketbl_prod_pharmaMasCostFooter(dataReader);
				} else {
					tbl_prod_pharmaMasCostFooterins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaMasCostFooterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaMasCostFooter table.
		/// </summary>
		public static List<tbl_prod_pharmaMasCostFooter> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostFooterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaMasCostFooter> tbl_prod_pharmaMasCostFooterList = new List<tbl_prod_pharmaMasCostFooter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaMasCostFooter tbl_prod_pharmaMasCostFooter = Maketbl_prod_pharmaMasCostFooter(dataReader);
					tbl_prod_pharmaMasCostFooterList.Add(tbl_prod_pharmaMasCostFooter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaMasCostFooterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaMasCostFooter table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaMasCostFooter> SelectAllByFooter_ID(string footer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostFooterSelectAllByFooter_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@footer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@footer_ID"].Value = footer_ID;
				List<tbl_prod_pharmaMasCostFooter> tbl_prod_pharmaMasCostFooterList = new List<tbl_prod_pharmaMasCostFooter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaMasCostFooter tbl_prod_pharmaMasCostFooter = Maketbl_prod_pharmaMasCostFooter(dataReader);
					tbl_prod_pharmaMasCostFooterList.Add(tbl_prod_pharmaMasCostFooter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaMasCostFooterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaMasCostFooter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaMasCostFooter Maketbl_prod_pharmaMasCostFooter(SqlDataReader dataReader) {
			tbl_prod_pharmaMasCostFooter tbl_prod_pharmaMasCostFooter = new tbl_prod_pharmaMasCostFooter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaMasCostFooter.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaMasCostFooter.Footer_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaMasCostFooter.Description = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaMasCostFooter.IsEnable = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaMasCostFooter.IsTax = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaMasCostFooter.Tax_ID = dataReader.GetString(5);
			}

			return tbl_prod_pharmaMasCostFooter;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaMasCostFooter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaMasCostFooter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaMasCostFooter  tbl_prod_pharmaMasCostFooter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_footer_ID = new DataColumn("footer_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
			DataColumn col_isTax = new DataColumn("isTax" , typeof(bool));
			DataColumn col_tax_ID = new DataColumn("tax_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_footer_ID,col_description,col_isEnable,col_isTax,col_tax_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaMasCostFooter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaMasCostFooter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaMasCostFooter user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["footer_ID"] = user.footer_ID;
			drow["description"] = user.description;
			drow["isEnable"] = user.isEnable;
			drow["isTax"] = user.isTax;
			drow["tax_ID"] = user.tax_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
