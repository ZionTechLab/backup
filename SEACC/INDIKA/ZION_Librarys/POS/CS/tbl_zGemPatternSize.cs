using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zGemPatternSize {
		#region Fields
		private string patternSize_ID;
		private string patternSizeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zGemPatternSize class.
		/// </summary>
		public tbl_zGemPatternSize() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zGemPatternSize class.
		/// </summary>
		public tbl_zGemPatternSize(string patternSize_ID, string patternSizeName) {
			this.patternSize_ID = patternSize_ID;
			this.patternSizeName = patternSizeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PatternSize_ID value.
		/// </summary>
		public string PatternSize_ID {
			get { return patternSize_ID; }
			set { patternSize_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PatternSizeName value.
		/// </summary>
		public string PatternSizeName {
			get { return patternSizeName; }
			set { patternSizeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zGemPatternSize table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternSizeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@patternSize_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@patternSizeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@patternSize_ID"].Value = patternSize_ID;
			scom.Parameters["@patternSizeName"].Value = patternSizeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zGemPatternSize table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternSizeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@patternSize_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@patternSizeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@patternSize_ID"].Value = patternSize_ID;
			scom.Parameters["@patternSizeName"].Value = patternSizeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zGemPatternSize table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternSizeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@patternSize_ID", SqlDbType.VarChar,10);
			scom.Parameters["@patternSize_ID"].Value = patternSize_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zGemPatternSize table.
		/// </summary>
		public static tbl_zGemPatternSize Select(string patternSize_ID_Incoming){

			tbl_zGemPatternSize tbl_zGemPatternSizeins = new tbl_zGemPatternSize();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternSizeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@patternSize_ID", SqlDbType.VarChar,10);
			scom.Parameters["@patternSize_ID"].Value = patternSize_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zGemPatternSizeins = Maketbl_zGemPatternSize(dataReader);
				} else {
					tbl_zGemPatternSizeins = null;
				}
			}
			scon.Close();
			return tbl_zGemPatternSizeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zGemPatternSize table.
		/// </summary>
		public static List<tbl_zGemPatternSize> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternSizeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zGemPatternSize> tbl_zGemPatternSizeList = new List<tbl_zGemPatternSize>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zGemPatternSize tbl_zGemPatternSize = Maketbl_zGemPatternSize(dataReader);
					tbl_zGemPatternSizeList.Add(tbl_zGemPatternSize);
				}
			}
			scon.Close();
			return tbl_zGemPatternSizeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zGemPatternSize class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zGemPatternSize Maketbl_zGemPatternSize(SqlDataReader dataReader) {
			tbl_zGemPatternSize tbl_zGemPatternSize = new tbl_zGemPatternSize();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zGemPatternSize.PatternSize_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zGemPatternSize.PatternSizeName = dataReader.GetString(1);
			}

			return tbl_zGemPatternSize;
		}
		/// <summary>
		/// This makes tbl_zGemPatternSize datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zGemPatternSize object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zGemPatternSize  tbl_zGemPatternSize   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_patternSize_ID = new DataColumn("patternSize_ID" , typeof(string));
			DataColumn col_patternSizeName = new DataColumn("patternSizeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_patternSize_ID,col_patternSizeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zGemPatternSize datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zGemPatternSize object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zGemPatternSize user) {
		DataRow drow = dt.NewRow();
		
			drow["patternSize_ID"] = user.patternSize_ID;
			drow["patternSizeName"] = user.patternSizeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
