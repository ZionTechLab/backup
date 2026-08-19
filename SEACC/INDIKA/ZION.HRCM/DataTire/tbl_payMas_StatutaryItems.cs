using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payMas_StatutaryItems {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string statutaryPayItem_ID;
		private string statutaryPayItem_Code;
		private string statutaryPayItem_Title;
		private decimal percentage;
		private decimal flatRate;
		private bool isFlatRate;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_StatutaryItems class.
		/// </summary>
		public tbl_payMas_StatutaryItems() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_StatutaryItems class.
		/// </summary>
		public tbl_payMas_StatutaryItems(string company_ID, string companyBranch_ID, string statutaryPayItem_ID, string statutaryPayItem_Code, string statutaryPayItem_Title, decimal percentage, decimal flatRate, bool isFlatRate, bool isCanceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.statutaryPayItem_ID = statutaryPayItem_ID;
			this.statutaryPayItem_Code = statutaryPayItem_Code;
			this.statutaryPayItem_Title = statutaryPayItem_Title;
			this.percentage = percentage;
			this.flatRate = flatRate;
			this.isFlatRate = isFlatRate;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Company_ID value.
		/// </summary>
		public string Company_ID {
			get { return company_ID; }
			set { company_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatutaryPayItem_ID value.
		/// </summary>
		public string StatutaryPayItem_ID {
			get { return statutaryPayItem_ID; }
			set { statutaryPayItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatutaryPayItem_Code value.
		/// </summary>
		public string StatutaryPayItem_Code {
			get { return statutaryPayItem_Code; }
			set { statutaryPayItem_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatutaryPayItem_Title value.
		/// </summary>
		public string StatutaryPayItem_Title {
			get { return statutaryPayItem_Title; }
			set { statutaryPayItem_Title = value; }
		}
		
		/// <summary>
		/// Gets or sets the Percentage value.
		/// </summary>
		public decimal Percentage {
			get { return percentage; }
			set { percentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the FlatRate value.
		/// </summary>
		public decimal FlatRate {
			get { return flatRate; }
			set { flatRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFlatRate value.
		/// </summary>
		public bool IsFlatRate {
			get { return isFlatRate; }
			set { isFlatRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payMas_StatutaryItems table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_StatutaryItemsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statutaryPayItem_Code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statutaryPayItem_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@percentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@flatRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isFlatRate", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID;
			scom.Parameters["@statutaryPayItem_Code"].Value = statutaryPayItem_Code;
			scom.Parameters["@statutaryPayItem_Title"].Value = statutaryPayItem_Title;
			scom.Parameters["@percentage"].Value = percentage;
			scom.Parameters["@flatRate"].Value = flatRate;
			scom.Parameters["@isFlatRate"].Value = isFlatRate;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payMas_StatutaryItems table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_StatutaryItemsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statutaryPayItem_Code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statutaryPayItem_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@percentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@flatRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isFlatRate", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID;
			scom.Parameters["@statutaryPayItem_Code"].Value = statutaryPayItem_Code;
			scom.Parameters["@statutaryPayItem_Title"].Value = statutaryPayItem_Title;
			scom.Parameters["@percentage"].Value = percentage;
			scom.Parameters["@flatRate"].Value = flatRate;
			scom.Parameters["@isFlatRate"].Value = isFlatRate;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payMas_StatutaryItems table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_StatutaryItemsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payMas_StatutaryItems table.
		/// </summary>
		public static tbl_payMas_StatutaryItems Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string statutaryPayItem_ID_Incoming){

			tbl_payMas_StatutaryItems tbl_payMas_StatutaryItemsins = new tbl_payMas_StatutaryItems();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_StatutaryItemsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payMas_StatutaryItemsins = Maketbl_payMas_StatutaryItems(dataReader);
				} else {
					tbl_payMas_StatutaryItemsins = null;
				}
			}
			scon.Close();
			return tbl_payMas_StatutaryItemsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_StatutaryItems table.
		/// </summary>
		public static List<tbl_payMas_StatutaryItems> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_StatutaryItemsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payMas_StatutaryItems> tbl_payMas_StatutaryItemsList = new List<tbl_payMas_StatutaryItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_StatutaryItems tbl_payMas_StatutaryItems = Maketbl_payMas_StatutaryItems(dataReader);
					tbl_payMas_StatutaryItemsList.Add(tbl_payMas_StatutaryItems);
				}
			}
			scon.Close();
			return tbl_payMas_StatutaryItemsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payMas_StatutaryItems class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payMas_StatutaryItems Maketbl_payMas_StatutaryItems(SqlDataReader dataReader) {
			tbl_payMas_StatutaryItems tbl_payMas_StatutaryItems = new tbl_payMas_StatutaryItems();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payMas_StatutaryItems.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payMas_StatutaryItems.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payMas_StatutaryItems.StatutaryPayItem_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payMas_StatutaryItems.StatutaryPayItem_Code = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payMas_StatutaryItems.StatutaryPayItem_Title = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payMas_StatutaryItems.Percentage = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payMas_StatutaryItems.FlatRate = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_payMas_StatutaryItems.IsFlatRate = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_payMas_StatutaryItems.IsCanceled = dataReader.GetBoolean(8);
			}

			return tbl_payMas_StatutaryItems;
		}
		/// <summary>
		/// This makes tbl_payMas_StatutaryItems datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payMas_StatutaryItems object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payMas_StatutaryItems  tbl_payMas_StatutaryItems   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_statutaryPayItem_ID = new DataColumn("statutaryPayItem_ID" , typeof(string));
			DataColumn col_statutaryPayItem_Code = new DataColumn("statutaryPayItem_Code" , typeof(string));
			DataColumn col_statutaryPayItem_Title = new DataColumn("statutaryPayItem_Title" , typeof(string));
			DataColumn col_percentage = new DataColumn("percentage" , typeof(decimal));
			DataColumn col_flatRate = new DataColumn("flatRate" , typeof(decimal));
			DataColumn col_isFlatRate = new DataColumn("isFlatRate" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_statutaryPayItem_ID,col_statutaryPayItem_Code,col_statutaryPayItem_Title,col_percentage,col_flatRate,col_isFlatRate,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payMas_StatutaryItems datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payMas_StatutaryItems object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payMas_StatutaryItems user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["statutaryPayItem_ID"] = user.statutaryPayItem_ID;
			drow["statutaryPayItem_Code"] = user.statutaryPayItem_Code;
			drow["statutaryPayItem_Title"] = user.statutaryPayItem_Title;
			drow["percentage"] = user.percentage;
			drow["flatRate"] = user.flatRate;
			drow["isFlatRate"] = user.isFlatRate;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
