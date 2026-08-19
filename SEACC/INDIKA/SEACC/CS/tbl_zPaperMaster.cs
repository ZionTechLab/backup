using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPaperMaster {
		#region Fields
		private string paper_ID;
		private string paperName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPaperMaster class.
		/// </summary>
		public tbl_zPaperMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPaperMaster class.
		/// </summary>
		public tbl_zPaperMaster(string paper_ID, string paperName) {
			this.paper_ID = paper_ID;
			this.paperName = paperName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Paper_ID value.
		/// </summary>
		public string Paper_ID {
			get { return paper_ID; }
			set { paper_ID = value; }
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
		/// Saves a record to the tbl_zPaperMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaperMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paperName", SqlDbType.VarChar,50);
 
			scom.Parameters["@paper_ID"].Value = paper_ID;
			scom.Parameters["@paperName"].Value = paperName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPaperMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaperMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paperName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@paper_ID"].Value = paper_ID;
			scom.Parameters["@paperName"].Value = paperName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPaperMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaperMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paper_ID"].Value = paper_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPaperMaster table.
		/// </summary>
		public static tbl_zPaperMaster Select(string paper_ID_Incoming){

			tbl_zPaperMaster tbl_zPaperMasterins = new tbl_zPaperMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaperMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paper_ID"].Value = paper_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPaperMasterins = Maketbl_zPaperMaster(dataReader);
				} else {
					tbl_zPaperMasterins = null;
				}
			}
			scon.Close();
			return tbl_zPaperMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPaperMaster table.
		/// </summary>
		public static List<tbl_zPaperMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaperMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPaperMaster> tbl_zPaperMasterList = new List<tbl_zPaperMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPaperMaster tbl_zPaperMaster = Maketbl_zPaperMaster(dataReader);
					tbl_zPaperMasterList.Add(tbl_zPaperMaster);
				}
			}
			scon.Close();
			return tbl_zPaperMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPaperMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPaperMaster Maketbl_zPaperMaster(SqlDataReader dataReader) {
			tbl_zPaperMaster tbl_zPaperMaster = new tbl_zPaperMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPaperMaster.Paper_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPaperMaster.PaperName = dataReader.GetString(1);
			}

			return tbl_zPaperMaster;
		}
		/// <summary>
		/// This makes tbl_zPaperMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPaperMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPaperMaster  tbl_zPaperMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_paper_ID = new DataColumn("paper_ID" , typeof(string));
			DataColumn col_paperName = new DataColumn("paperName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_paper_ID,col_paperName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPaperMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPaperMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPaperMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["paper_ID"] = user.paper_ID;
			drow["paperName"] = user.paperName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
