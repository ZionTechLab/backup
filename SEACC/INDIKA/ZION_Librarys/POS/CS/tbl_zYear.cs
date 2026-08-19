using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zYear {
		#region Fields
		private string yearName;
		private int yearNumber;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zYear class.
		/// </summary>
		public tbl_zYear() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zYear class.
		/// </summary>
		public tbl_zYear(string yearName, int yearNumber) {
			this.yearName = yearName;
			this.yearNumber = yearNumber;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the YearName value.
		/// </summary>
		public string YearName {
			get { return yearName; }
			set { yearName = value; }
		}
		
		/// <summary>
		/// Gets or sets the YearNumber value.
		/// </summary>
		public int YearNumber {
			get { return yearNumber; }
			set { yearNumber = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zYear table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zYearInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@yearName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@yearNumber", SqlDbType.Int,4);
 
			scom.Parameters["@yearName"].Value = yearName;
			scom.Parameters["@yearNumber"].Value = yearNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zYear table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zYearUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@yearName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@yearNumber", SqlDbType.Int,4);
 
 
			scom.Parameters["@yearName"].Value = yearName;
			scom.Parameters["@yearNumber"].Value = yearNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zYear table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zYearDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@yearName", SqlDbType.VarChar,20);
			scom.Parameters["@yearName"].Value = yearName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zYear table.
		/// </summary>
		public static tbl_zYear Select(string yearName_Incoming){

			tbl_zYear tbl_zYearins = new tbl_zYear();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zYearSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@yearName", SqlDbType.VarChar,20);
			scom.Parameters["@yearName"].Value = yearName_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zYearins = Maketbl_zYear(dataReader);
				} else {
					tbl_zYearins = null;
				}
			}
			scon.Close();
			return tbl_zYearins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zYear table.
		/// </summary>
		public static List<tbl_zYear> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zYearSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zYear> tbl_zYearList = new List<tbl_zYear>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zYear tbl_zYear = Maketbl_zYear(dataReader);
					tbl_zYearList.Add(tbl_zYear);
				}
			}
			scon.Close();
			return tbl_zYearList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zYear class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zYear Maketbl_zYear(SqlDataReader dataReader) {
			tbl_zYear tbl_zYear = new tbl_zYear();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zYear.YearName = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zYear.YearNumber = dataReader.GetInt32(1);
			}

			return tbl_zYear;
		}
		/// <summary>
		/// This makes tbl_zYear datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zYear object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zYear  tbl_zYear   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_yearName = new DataColumn("yearName" , typeof(string));
			DataColumn col_yearNumber = new DataColumn("yearNumber" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_yearName,col_yearNumber,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zYear datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zYear object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zYear user) {
		DataRow drow = dt.NewRow();
		
			drow["yearName"] = user.yearName;
			drow["yearNumber"] = user.yearNumber;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
