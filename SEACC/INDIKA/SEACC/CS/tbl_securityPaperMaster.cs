using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityPaperMaster {
		#region Fields
		private string companyID;
		private string companyBranch;
		private string paperName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityPaperMaster class.
		/// </summary>
		public tbl_securityPaperMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityPaperMaster class.
		/// </summary>
		public tbl_securityPaperMaster(string companyID, string companyBranch, string paperName) {
			this.companyID = companyID;
			this.companyBranch = companyBranch;
			this.paperName = paperName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch value.
		/// </summary>
		public string CompanyBranch {
			get { return companyBranch; }
			set { companyBranch = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaperName value.
		/// </summary>
		public string PaperName {
			get { return paperName; }
			set { paperName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityPaperMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaperMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paperName", SqlDbType.VarChar,50);
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch"].Value = companyBranch;
			scom.Parameters["@paperName"].Value = paperName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityPaperMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaperMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paperName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch"].Value = companyBranch;
			scom.Parameters["@paperName"].Value = paperName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityPaperMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaperMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters["@companyID"].Value = companyID;
 
			scom.Parameters["@companyBranch"].Value = companyBranch;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityPaperMaster table.
		/// </summary>
		public static tbl_securityPaperMaster Select(string companyID_Incoming, string companyBranch_Incoming){

			tbl_securityPaperMaster tbl_securityPaperMasterins = new tbl_securityPaperMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaperMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters["@companyID"].Value = companyID_Incoming;
			scom.Parameters["@companyBranch"].Value = companyBranch_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityPaperMasterins = Maketbl_securityPaperMaster(dataReader);
				} else {
					tbl_securityPaperMasterins = null;
				}
			}
			scon.Close();
			return tbl_securityPaperMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPaperMaster table.
		/// </summary>
		public static List<tbl_securityPaperMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaperMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityPaperMaster> tbl_securityPaperMasterList = new List<tbl_securityPaperMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityPaperMaster tbl_securityPaperMaster = Maketbl_securityPaperMaster(dataReader);
					tbl_securityPaperMasterList.Add(tbl_securityPaperMaster);
				}
			}
			scon.Close();
			return tbl_securityPaperMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityPaperMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityPaperMaster Maketbl_securityPaperMaster(SqlDataReader dataReader) {
			tbl_securityPaperMaster tbl_securityPaperMaster = new tbl_securityPaperMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityPaperMaster.CompanyID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityPaperMaster.CompanyBranch = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityPaperMaster.PaperName = dataReader.GetString(2);
			}

			return tbl_securityPaperMaster;
		}
		/// <summary>
		/// This makes tbl_securityPaperMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityPaperMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityPaperMaster  tbl_securityPaperMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch = new DataColumn("companyBranch" , typeof(string));
			DataColumn col_paperName = new DataColumn("paperName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_companyID,col_companyBranch,col_paperName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityPaperMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityPaperMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityPaperMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["companyID"] = user.companyID;
			drow["companyBranch"] = user.companyBranch;
			drow["paperName"] = user.paperName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
