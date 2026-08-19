using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zGemPatternLength {
		#region Fields
		private string patternLength_ID;
		private string patternLengthName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zGemPatternLength class.
		/// </summary>
		public tbl_zGemPatternLength() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zGemPatternLength class.
		/// </summary>
		public tbl_zGemPatternLength(string patternLength_ID, string patternLengthName) {
			this.patternLength_ID = patternLength_ID;
			this.patternLengthName = patternLengthName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PatternLength_ID value.
		/// </summary>
		public string PatternLength_ID {
			get { return patternLength_ID; }
			set { patternLength_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PatternLengthName value.
		/// </summary>
		public string PatternLengthName {
			get { return patternLengthName; }
			set { patternLengthName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zGemPatternLength table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternLengthInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@patternLength_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@patternLengthName", SqlDbType.VarChar,50);
 
			scom.Parameters["@patternLength_ID"].Value = patternLength_ID;
			scom.Parameters["@patternLengthName"].Value = patternLengthName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zGemPatternLength table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternLengthUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@patternLength_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@patternLengthName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@patternLength_ID"].Value = patternLength_ID;
			scom.Parameters["@patternLengthName"].Value = patternLengthName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zGemPatternLength table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternLengthDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@patternLength_ID", SqlDbType.VarChar,10);
			scom.Parameters["@patternLength_ID"].Value = patternLength_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zGemPatternLength table.
		/// </summary>
		public static tbl_zGemPatternLength Select(string patternLength_ID_Incoming){

			tbl_zGemPatternLength tbl_zGemPatternLengthins = new tbl_zGemPatternLength();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternLengthSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@patternLength_ID", SqlDbType.VarChar,10);
			scom.Parameters["@patternLength_ID"].Value = patternLength_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zGemPatternLengthins = Maketbl_zGemPatternLength(dataReader);
				} else {
					tbl_zGemPatternLengthins = null;
				}
			}
			scon.Close();
			return tbl_zGemPatternLengthins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zGemPatternLength table.
		/// </summary>
		public static List<tbl_zGemPatternLength> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemPatternLengthSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zGemPatternLength> tbl_zGemPatternLengthList = new List<tbl_zGemPatternLength>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zGemPatternLength tbl_zGemPatternLength = Maketbl_zGemPatternLength(dataReader);
					tbl_zGemPatternLengthList.Add(tbl_zGemPatternLength);
				}
			}
			scon.Close();
			return tbl_zGemPatternLengthList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zGemPatternLength class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zGemPatternLength Maketbl_zGemPatternLength(SqlDataReader dataReader) {
			tbl_zGemPatternLength tbl_zGemPatternLength = new tbl_zGemPatternLength();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zGemPatternLength.PatternLength_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zGemPatternLength.PatternLengthName = dataReader.GetString(1);
			}

			return tbl_zGemPatternLength;
		}
		/// <summary>
		/// This makes tbl_zGemPatternLength datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zGemPatternLength object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zGemPatternLength  tbl_zGemPatternLength   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_patternLength_ID = new DataColumn("patternLength_ID" , typeof(string));
			DataColumn col_patternLengthName = new DataColumn("patternLengthName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_patternLength_ID,col_patternLengthName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zGemPatternLength datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zGemPatternLength object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zGemPatternLength user) {
		DataRow drow = dt.NewRow();
		
			drow["patternLength_ID"] = user.patternLength_ID;
			drow["patternLengthName"] = user.patternLengthName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
