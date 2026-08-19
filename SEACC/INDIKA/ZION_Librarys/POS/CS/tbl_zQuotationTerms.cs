using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zQuotationTerms {
		#region Fields
		private string qTerm_ID;
		private string qTerm_DESC;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zQuotationTerms class.
		/// </summary>
		public tbl_zQuotationTerms() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zQuotationTerms class.
		/// </summary>
		public tbl_zQuotationTerms(string qTerm_ID, string qTerm_DESC) {
			this.qTerm_ID = qTerm_ID;
			this.qTerm_DESC = qTerm_DESC;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the QTerm_ID value.
		/// </summary>
		public string QTerm_ID {
			get { return qTerm_ID; }
			set { qTerm_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the QTerm_DESC value.
		/// </summary>
		public string QTerm_DESC {
			get { return qTerm_DESC; }
			set { qTerm_DESC = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zQuotationTerms table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTermsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@qTerm_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qTerm_DESC", SqlDbType.VarChar,100);
 
			scom.Parameters["@qTerm_ID"].Value = qTerm_ID;
			scom.Parameters["@qTerm_DESC"].Value = qTerm_DESC;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zQuotationTerms table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTermsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@qTerm_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qTerm_DESC", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@qTerm_ID"].Value = qTerm_ID;
			scom.Parameters["@qTerm_DESC"].Value = qTerm_DESC;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zQuotationTerms table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTermsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@qTerm_ID", SqlDbType.VarChar,10);
			scom.Parameters["@qTerm_ID"].Value = qTerm_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zQuotationTerms table.
		/// </summary>
		public static tbl_zQuotationTerms Select(string qTerm_ID_Incoming){

			tbl_zQuotationTerms tbl_zQuotationTermsins = new tbl_zQuotationTerms();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTermsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@qTerm_ID", SqlDbType.VarChar,10);
			scom.Parameters["@qTerm_ID"].Value = qTerm_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zQuotationTermsins = Maketbl_zQuotationTerms(dataReader);
				} else {
					tbl_zQuotationTermsins = null;
				}
			}
			scon.Close();
			return tbl_zQuotationTermsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zQuotationTerms table.
		/// </summary>
		public static List<tbl_zQuotationTerms> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zQuotationTermsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zQuotationTerms> tbl_zQuotationTermsList = new List<tbl_zQuotationTerms>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zQuotationTerms tbl_zQuotationTerms = Maketbl_zQuotationTerms(dataReader);
					tbl_zQuotationTermsList.Add(tbl_zQuotationTerms);
				}
			}
			scon.Close();
			return tbl_zQuotationTermsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zQuotationTerms class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zQuotationTerms Maketbl_zQuotationTerms(SqlDataReader dataReader) {
			tbl_zQuotationTerms tbl_zQuotationTerms = new tbl_zQuotationTerms();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zQuotationTerms.QTerm_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zQuotationTerms.QTerm_DESC = dataReader.GetString(1);
			}

			return tbl_zQuotationTerms;
		}
		/// <summary>
		/// This makes tbl_zQuotationTerms datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zQuotationTerms object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zQuotationTerms  tbl_zQuotationTerms   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_qTerm_ID = new DataColumn("qTerm_ID" , typeof(string));
			DataColumn col_qTerm_DESC = new DataColumn("qTerm_DESC" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_qTerm_ID,col_qTerm_DESC,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zQuotationTerms datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zQuotationTerms object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zQuotationTerms user) {
		DataRow drow = dt.NewRow();
		
			drow["qTerm_ID"] = user.qTerm_ID;
			drow["qTerm_DESC"] = user.qTerm_DESC;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
