using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityStockValidate {
		#region Fields
		private int form_ID;
		private string companyID;
		private string companyBranch_ID;
		private string remarks;
		private bool stockValidate_Qty;
		private bool stockValidate_Weight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityStockValidate class.
		/// </summary>
		public tbl_securityStockValidate() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityStockValidate class.
		/// </summary>
		public tbl_securityStockValidate(int form_ID, string companyID, string companyBranch_ID, string remarks, bool stockValidate_Qty, bool stockValidate_Weight) {
			this.form_ID = form_ID;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.remarks = remarks;
			this.stockValidate_Qty = stockValidate_Qty;
			this.stockValidate_Weight = stockValidate_Weight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the StockValidate_Qty value.
		/// </summary>
		public bool StockValidate_Qty {
			get { return stockValidate_Qty; }
			set { stockValidate_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the StockValidate_Weight value.
		/// </summary>
		public bool StockValidate_Weight {
			get { return stockValidate_Weight; }
			set { stockValidate_Weight = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityStockValidate table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@StockValidate_Qty", SqlDbType.Bit,1);
			scom.Parameters.Add("@StockValidate_Weight", SqlDbType.Bit,1);
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@StockValidate_Qty"].Value = stockValidate_Qty;
			scom.Parameters["@StockValidate_Weight"].Value = stockValidate_Weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityStockValidate table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@StockValidate_Qty", SqlDbType.Bit,1);
			scom.Parameters.Add("@StockValidate_Weight", SqlDbType.Bit,1);
 
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@StockValidate_Qty"].Value = stockValidate_Qty;
			scom.Parameters["@StockValidate_Weight"].Value = stockValidate_Weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityStockValidate table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scom.Parameters["@companyID"].Value = companyID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStockValidate table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStockValidate table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStockValidate table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityStockValidate table.
		/// </summary>
		public static tbl_securityStockValidate Select(int form_ID_Incoming, string companyID_Incoming, string companyBranch_ID_Incoming){

			tbl_securityStockValidate tbl_securityStockValidateins = new tbl_securityStockValidate();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@form_ID"].Value = form_ID_Incoming;
			scom.Parameters["@companyID"].Value = companyID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityStockValidateins = Maketbl_securityStockValidate(dataReader);
				} else {
					tbl_securityStockValidateins = null;
				}
			}
			scon.Close();
			return tbl_securityStockValidateins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStockValidate table.
		/// </summary>
		public static List<tbl_securityStockValidate> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityStockValidate> tbl_securityStockValidateList = new List<tbl_securityStockValidate>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityStockValidate tbl_securityStockValidate = Maketbl_securityStockValidate(dataReader);
					tbl_securityStockValidateList.Add(tbl_securityStockValidate);
				}
			}
			scon.Close();
			return tbl_securityStockValidateList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStockValidate table by a foreign key.
		/// </summary>
		public static List<tbl_securityStockValidate> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_securityStockValidate> tbl_securityStockValidateList = new List<tbl_securityStockValidate>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityStockValidate tbl_securityStockValidate = Maketbl_securityStockValidate(dataReader);
					tbl_securityStockValidateList.Add(tbl_securityStockValidate);
				}
			}
			scon.Close();
			return tbl_securityStockValidateList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStockValidate table by a foreign key.
		/// </summary>
		public static List<tbl_securityStockValidate> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateSelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_securityStockValidate> tbl_securityStockValidateList = new List<tbl_securityStockValidate>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityStockValidate tbl_securityStockValidate = Maketbl_securityStockValidate(dataReader);
					tbl_securityStockValidateList.Add(tbl_securityStockValidate);
				}
			}
			scon.Close();
			return tbl_securityStockValidateList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStockValidate table by a foreign key.
		/// </summary>
		public static List<tbl_securityStockValidate> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStockValidateSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_securityStockValidate> tbl_securityStockValidateList = new List<tbl_securityStockValidate>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityStockValidate tbl_securityStockValidate = Maketbl_securityStockValidate(dataReader);
					tbl_securityStockValidateList.Add(tbl_securityStockValidate);
				}
			}
			scon.Close();
			return tbl_securityStockValidateList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityStockValidate class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityStockValidate Maketbl_securityStockValidate(SqlDataReader dataReader) {
			tbl_securityStockValidate tbl_securityStockValidate = new tbl_securityStockValidate();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityStockValidate.Form_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityStockValidate.CompanyID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityStockValidate.CompanyBranch_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityStockValidate.Remarks = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityStockValidate.StockValidate_Qty = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityStockValidate.StockValidate_Weight = dataReader.GetBoolean(5);
			}

			return tbl_securityStockValidate;
		}
		/// <summary>
		/// This makes tbl_securityStockValidate datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityStockValidate object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityStockValidate  tbl_securityStockValidate   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_StockValidate_Qty = new DataColumn("StockValidate_Qty" , typeof(bool));
			DataColumn col_StockValidate_Weight = new DataColumn("StockValidate_Weight" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_form_ID,col_companyID,col_companyBranch_ID,col_remarks,col_StockValidate_Qty,col_StockValidate_Weight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityStockValidate datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityStockValidate object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityStockValidate user) {
		DataRow drow = dt.NewRow();
		
			drow["form_ID"] = user.form_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["remarks"] = user.remarks;
			drow["StockValidate_Qty"] = user.StockValidate_Qty;
			drow["StockValidate_Weight"] = user.StockValidate_Weight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
