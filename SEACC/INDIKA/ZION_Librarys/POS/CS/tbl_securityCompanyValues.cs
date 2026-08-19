using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityCompanyValues {
		#region Fields
		private int companyValues_ID;
		private string companyValuesName;
		private string companyValuesDetail;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityCompanyValues class.
		/// </summary>
		public tbl_securityCompanyValues() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityCompanyValues class.
		/// </summary>
		public tbl_securityCompanyValues(int companyValues_ID, string companyValuesName, string companyValuesDetail) {
			this.companyValues_ID = companyValues_ID;
			this.companyValuesName = companyValuesName;
			this.companyValuesDetail = companyValuesDetail;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyValues_ID value.
		/// </summary>
		public int CompanyValues_ID {
			get { return companyValues_ID; }
			set { companyValues_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyValuesName value.
		/// </summary>
		public string CompanyValuesName {
			get { return companyValuesName; }
			set { companyValuesName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyValuesDetail value.
		/// </summary>
		public string CompanyValuesDetail {
			get { return companyValuesDetail; }
			set { companyValuesDetail = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityCompanyValues table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityCompanyValuesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyValues_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyValuesName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyValuesDetail", SqlDbType.VarChar,500);
 
			scom.Parameters["@companyValues_ID"].Value = companyValues_ID;
			scom.Parameters["@companyValuesName"].Value = companyValuesName;
			scom.Parameters["@companyValuesDetail"].Value = companyValuesDetail;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityCompanyValues table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityCompanyValuesUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyValues_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyValuesName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyValuesDetail", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@companyValues_ID"].Value = companyValues_ID;
			scom.Parameters["@companyValuesName"].Value = companyValuesName;
			scom.Parameters["@companyValuesDetail"].Value = companyValuesDetail;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityCompanyValues table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityCompanyValuesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyValues_ID", SqlDbType.Int,4);
			scom.Parameters["@companyValues_ID"].Value = companyValues_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityCompanyValues table.
		/// </summary>
		public static tbl_securityCompanyValues Select(int companyValues_ID_Incoming){

			tbl_securityCompanyValues tbl_securityCompanyValuesins = new tbl_securityCompanyValues();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityCompanyValuesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyValues_ID", SqlDbType.Int,4);
			scom.Parameters["@companyValues_ID"].Value = companyValues_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityCompanyValuesins = Maketbl_securityCompanyValues(dataReader);
				} else {
					tbl_securityCompanyValuesins = null;
				}
			}
			scon.Close();
			return tbl_securityCompanyValuesins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityCompanyValues table.
		/// </summary>
		public static List<tbl_securityCompanyValues> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityCompanyValuesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityCompanyValues> tbl_securityCompanyValuesList = new List<tbl_securityCompanyValues>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityCompanyValues tbl_securityCompanyValues = Maketbl_securityCompanyValues(dataReader);
					tbl_securityCompanyValuesList.Add(tbl_securityCompanyValues);
				}
			}
			scon.Close();
			return tbl_securityCompanyValuesList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityCompanyValues class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityCompanyValues Maketbl_securityCompanyValues(SqlDataReader dataReader) {
			tbl_securityCompanyValues tbl_securityCompanyValues = new tbl_securityCompanyValues();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityCompanyValues.CompanyValues_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityCompanyValues.CompanyValuesName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityCompanyValues.CompanyValuesDetail = dataReader.GetString(2);
			}

			return tbl_securityCompanyValues;
		}
		/// <summary>
		/// This makes tbl_securityCompanyValues datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityCompanyValues object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityCompanyValues  tbl_securityCompanyValues   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyValues_ID = new DataColumn("companyValues_ID" , typeof(int));
			DataColumn col_companyValuesName = new DataColumn("companyValuesName" , typeof(string));
			DataColumn col_companyValuesDetail = new DataColumn("companyValuesDetail" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_companyValues_ID,col_companyValuesName,col_companyValuesDetail,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityCompanyValues datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityCompanyValues object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityCompanyValues user) {
		DataRow drow = dt.NewRow();
		
			drow["companyValues_ID"] = user.companyValues_ID;
			drow["companyValuesName"] = user.companyValuesName;
			drow["companyValuesDetail"] = user.companyValuesDetail;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
