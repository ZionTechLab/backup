using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zQuotationType {
		#region Fields
		private string quotationType_ID;
		private string quotationTypeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zQuotationType class.
		/// </summary>
		public tbl_zQuotationType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zQuotationType class.
		/// </summary>
		public tbl_zQuotationType(string quotationType_ID, string quotationTypeName) {
			this.quotationType_ID = quotationType_ID;
			this.quotationTypeName = quotationTypeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the QuotationType_ID value.
		/// </summary>
		public string QuotationType_ID {
			get { return quotationType_ID; }
			set { quotationType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the QuotationTypeName value.
		/// </summary>
		public string QuotationTypeName {
			get { return quotationTypeName; }
			set { quotationTypeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zQuotationType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@quotationType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@quotationTypeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@quotationType_ID"].Value = quotationType_ID;
			scom.Parameters["@quotationTypeName"].Value = quotationTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zQuotationType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@quotationType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@quotationTypeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@quotationType_ID"].Value = quotationType_ID;
			scom.Parameters["@quotationTypeName"].Value = quotationTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zQuotationType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@quotationType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@quotationType_ID"].Value = quotationType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zQuotationType table.
		/// </summary>
		public static tbl_zQuotationType Select(string quotationType_ID_Incoming){

			tbl_zQuotationType tbl_zQuotationTypeins = new tbl_zQuotationType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotationType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@quotationType_ID"].Value = quotationType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zQuotationTypeins = Maketbl_zQuotationType(dataReader);
				} else {
					tbl_zQuotationTypeins = null;
				}
			}
			scon.Close();
			return tbl_zQuotationTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zQuotationType table.
		/// </summary>
		public static List<tbl_zQuotationType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zQuotationType> tbl_zQuotationTypeList = new List<tbl_zQuotationType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zQuotationType tbl_zQuotationType = Maketbl_zQuotationType(dataReader);
					tbl_zQuotationTypeList.Add(tbl_zQuotationType);
				}
			}
			scon.Close();
			return tbl_zQuotationTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zQuotationType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zQuotationType Maketbl_zQuotationType(SqlDataReader dataReader) {
			tbl_zQuotationType tbl_zQuotationType = new tbl_zQuotationType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zQuotationType.QuotationType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zQuotationType.QuotationTypeName = dataReader.GetString(1);
			}

			return tbl_zQuotationType;
		}
		/// <summary>
		/// This makes tbl_zQuotationType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zQuotationType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zQuotationType  tbl_zQuotationType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_quotationType_ID = new DataColumn("quotationType_ID" , typeof(string));
			DataColumn col_quotationTypeName = new DataColumn("quotationTypeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_quotationType_ID,col_quotationTypeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zQuotationType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zQuotationType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zQuotationType user) {
		DataRow drow = dt.NewRow();
		
			drow["quotationType_ID"] = user.quotationType_ID;
			drow["quotationTypeName"] = user.quotationTypeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
