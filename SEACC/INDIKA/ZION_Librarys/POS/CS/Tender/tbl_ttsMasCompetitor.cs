using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsMasCompetitor {
		#region Fields
		private string competitor_Id;
		private string competitor_name;
		private string competitor_Desc;
		private string com_Country;
		private string com_City;
		private string remarks;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsMasCompetitor class.
		/// </summary>
		public tbl_ttsMasCompetitor() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsMasCompetitor class.
		/// </summary>
		public tbl_ttsMasCompetitor(string competitor_Id, string competitor_name, string competitor_Desc, string com_Country, string com_City, string remarks, bool isCanceled) {
			this.competitor_Id = competitor_Id;
			this.competitor_name = competitor_name;
			this.competitor_Desc = competitor_Desc;
			this.com_Country = com_Country;
			this.com_City = com_City;
			this.remarks = remarks;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Competitor_Id value.
		/// </summary>
		public string Competitor_Id {
			get { return competitor_Id; }
			set { competitor_Id = value; }
		}
		
		/// <summary>
		/// Gets or sets the Competitor_name value.
		/// </summary>
		public string Competitor_name {
			get { return competitor_name; }
			set { competitor_name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Competitor_Desc value.
		/// </summary>
		public string Competitor_Desc {
			get { return competitor_Desc; }
			set { competitor_Desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the Com_Country value.
		/// </summary>
		public string Com_Country {
			get { return com_Country; }
			set { com_Country = value; }
		}
		
		/// <summary>
		/// Gets or sets the Com_City value.
		/// </summary>
		public string Com_City {
			get { return com_City; }
			set { com_City = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
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
		/// Saves a record to the tbl_ttsMasCompetitor table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@competitor_Id", SqlDbType.VarChar,20);
			scom.Parameters.Add("@competitor_name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@competitor_Desc", SqlDbType.VarChar,50);
			scom.Parameters.Add("@com_Country", SqlDbType.VarChar,10);
			scom.Parameters.Add("@com_City", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@competitor_Id"].Value = competitor_Id;
			scom.Parameters["@competitor_name"].Value = competitor_name;
			scom.Parameters["@competitor_Desc"].Value = competitor_Desc;
			scom.Parameters["@com_Country"].Value = com_Country;
			scom.Parameters["@com_City"].Value = com_City;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsMasCompetitor table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@competitor_Id", SqlDbType.VarChar,20);
			scom.Parameters.Add("@competitor_name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@competitor_Desc", SqlDbType.VarChar,50);
			scom.Parameters.Add("@com_Country", SqlDbType.VarChar,10);
			scom.Parameters.Add("@com_City", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@competitor_Id"].Value = competitor_Id;
			scom.Parameters["@competitor_name"].Value = competitor_name;
			scom.Parameters["@competitor_Desc"].Value = competitor_Desc;
			scom.Parameters["@com_Country"].Value = com_Country;
			scom.Parameters["@com_City"].Value = com_City;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsMasCompetitor table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@competitor_Id", SqlDbType.VarChar,20);
			scom.Parameters["@competitor_Id"].Value = competitor_Id;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsMasCompetitor table by a foreign key.
		/// </summary>
		public static void DeleteAllByCom_City(string com_City) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorDeleteAllByCom_City", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@com_City", SqlDbType.VarChar,10);
			scom.Parameters["@com_City"].Value = com_City;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsMasCompetitor table by a foreign key.
		/// </summary>
		public static void DeleteAllByCom_Country(string com_Country) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorDeleteAllByCom_Country", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@com_Country", SqlDbType.VarChar,10);
			scom.Parameters["@com_Country"].Value = com_Country;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsMasCompetitor table.
		/// </summary>
		public static tbl_ttsMasCompetitor Select(string competitor_Id_Incoming){

			tbl_ttsMasCompetitor tbl_ttsMasCompetitorins = new tbl_ttsMasCompetitor();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@competitor_Id", SqlDbType.VarChar,20);
			scom.Parameters["@competitor_Id"].Value = competitor_Id_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsMasCompetitorins = Maketbl_ttsMasCompetitor(dataReader);
				} else {
					tbl_ttsMasCompetitorins = null;
				}
			}
			scon.Close();
			return tbl_ttsMasCompetitorins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsMasCompetitor table.
		/// </summary>
		public static List<tbl_ttsMasCompetitor> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsMasCompetitor> tbl_ttsMasCompetitorList = new List<tbl_ttsMasCompetitor>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsMasCompetitor tbl_ttsMasCompetitor = Maketbl_ttsMasCompetitor(dataReader);
					tbl_ttsMasCompetitorList.Add(tbl_ttsMasCompetitor);
				}
			}
			scon.Close();
			return tbl_ttsMasCompetitorList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsMasCompetitor table by a foreign key.
		/// </summary>
		public static List<tbl_ttsMasCompetitor> SelectAllByCom_City(string com_City) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorSelectAllByCom_City", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@com_City", SqlDbType.VarChar,10);
			scom.Parameters["@com_City"].Value = com_City;
				List<tbl_ttsMasCompetitor> tbl_ttsMasCompetitorList = new List<tbl_ttsMasCompetitor>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsMasCompetitor tbl_ttsMasCompetitor = Maketbl_ttsMasCompetitor(dataReader);
					tbl_ttsMasCompetitorList.Add(tbl_ttsMasCompetitor);
				}
			}
			scon.Close();
			return tbl_ttsMasCompetitorList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsMasCompetitor table by a foreign key.
		/// </summary>
		public static List<tbl_ttsMasCompetitor> SelectAllByCom_Country(string com_Country) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsMasCompetitorSelectAllByCom_Country", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@com_Country", SqlDbType.VarChar,10);
			scom.Parameters["@com_Country"].Value = com_Country;
				List<tbl_ttsMasCompetitor> tbl_ttsMasCompetitorList = new List<tbl_ttsMasCompetitor>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsMasCompetitor tbl_ttsMasCompetitor = Maketbl_ttsMasCompetitor(dataReader);
					tbl_ttsMasCompetitorList.Add(tbl_ttsMasCompetitor);
				}
			}
			scon.Close();
			return tbl_ttsMasCompetitorList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsMasCompetitor class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsMasCompetitor Maketbl_ttsMasCompetitor(SqlDataReader dataReader) {
			tbl_ttsMasCompetitor tbl_ttsMasCompetitor = new tbl_ttsMasCompetitor();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsMasCompetitor.Competitor_Id = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsMasCompetitor.Competitor_name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsMasCompetitor.Competitor_Desc = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsMasCompetitor.Com_Country = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsMasCompetitor.Com_City = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsMasCompetitor.Remarks = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsMasCompetitor.IsCanceled = dataReader.GetBoolean(6);
			}

			return tbl_ttsMasCompetitor;
		}
		/// <summary>
		/// This makes tbl_ttsMasCompetitor datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsMasCompetitor object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsMasCompetitor  tbl_ttsMasCompetitor   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_competitor_Id = new DataColumn("competitor_Id" , typeof(string));
			DataColumn col_competitor_name = new DataColumn("competitor_name" , typeof(string));
			DataColumn col_competitor_Desc = new DataColumn("competitor_Desc" , typeof(string));
			DataColumn col_com_Country = new DataColumn("com_Country" , typeof(string));
			DataColumn col_com_City = new DataColumn("com_City" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_competitor_Id,col_competitor_name,col_competitor_Desc,col_com_Country,col_com_City,col_remarks,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsMasCompetitor datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsMasCompetitor object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsMasCompetitor user) {
		DataRow drow = dt.NewRow();
		
			drow["competitor_Id"] = user.competitor_Id;
			drow["competitor_name"] = user.competitor_name;
			drow["competitor_Desc"] = user.competitor_Desc;
			drow["com_Country"] = user.com_Country;
			drow["com_City"] = user.com_City;
			drow["remarks"] = user.remarks;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
