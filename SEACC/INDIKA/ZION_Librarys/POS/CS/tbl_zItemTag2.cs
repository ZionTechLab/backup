using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemTag2 {
		#region Fields
		private string tag2_ID;
		private string description;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemTag2 class.
		/// </summary>
		public tbl_zItemTag2() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemTag2 class.
		/// </summary>
		public tbl_zItemTag2(string tag2_ID, string description) {
			this.tag2_ID = tag2_ID;
			this.description = description;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tag2_ID value.
		/// </summary>
		public string Tag2_ID {
			get { return tag2_ID; }
			set { tag2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemTag2 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag2Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tag2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
 
			scom.Parameters["@tag2_ID"].Value = tag2_ID;
			scom.Parameters["@description"].Value = description;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemTag2 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag2Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tag2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@tag2_ID"].Value = tag2_ID;
			scom.Parameters["@description"].Value = description;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemTag2 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag2Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tag2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag2_ID"].Value = tag2_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemTag2 table.
		/// </summary>
		public static tbl_zItemTag2 Select(string tag2_ID_Incoming){

			tbl_zItemTag2 tbl_zItemTag2ins = new tbl_zItemTag2();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag2Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tag2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag2_ID"].Value = tag2_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemTag2ins = Maketbl_zItemTag2(dataReader);
				} else {
					tbl_zItemTag2ins = null;
				}
			}
			scon.Close();
			return tbl_zItemTag2ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag2 table.
		/// </summary>
		public static List<tbl_zItemTag2> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag2SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemTag2> tbl_zItemTag2List = new List<tbl_zItemTag2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag2 tbl_zItemTag2 = Maketbl_zItemTag2(dataReader);
					tbl_zItemTag2List.Add(tbl_zItemTag2);
				}
			}
			scon.Close();
			return tbl_zItemTag2List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemTag2 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemTag2 Maketbl_zItemTag2(SqlDataReader dataReader) {
			tbl_zItemTag2 tbl_zItemTag2 = new tbl_zItemTag2();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemTag2.Tag2_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemTag2.Description = dataReader.GetString(1);
			}

			return tbl_zItemTag2;
		}
		/// <summary>
		/// This makes tbl_zItemTag2 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemTag2 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemTag2  tbl_zItemTag2   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tag2_ID = new DataColumn("tag2_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_tag2_ID,col_description,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemTag2 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemTag2 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemTag2 user) {
		DataRow drow = dt.NewRow();
		
			drow["tag2_ID"] = user.tag2_ID;
			drow["description"] = user.description;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
