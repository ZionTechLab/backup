using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemTag1 {
		#region Fields
		private string tag1_ID;
		private string description;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemTag1 class.
		/// </summary>
		public tbl_zItemTag1() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemTag1 class.
		/// </summary>
		public tbl_zItemTag1(string tag1_ID, string description) {
			this.tag1_ID = tag1_ID;
			this.description = description;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tag1_ID value.
		/// </summary>
		public string Tag1_ID {
			get { return tag1_ID; }
			set { tag1_ID = value; }
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
		/// Saves a record to the tbl_zItemTag1 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag1Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tag1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
 
			scom.Parameters["@tag1_ID"].Value = tag1_ID;
			scom.Parameters["@description"].Value = description;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemTag1 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag1Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tag1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@tag1_ID"].Value = tag1_ID;
			scom.Parameters["@description"].Value = description;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemTag1 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag1Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tag1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag1_ID"].Value = tag1_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemTag1 table.
		/// </summary>
		public static tbl_zItemTag1 Select(string tag1_ID_Incoming){

			tbl_zItemTag1 tbl_zItemTag1ins = new tbl_zItemTag1();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag1Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tag1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag1_ID"].Value = tag1_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemTag1ins = Maketbl_zItemTag1(dataReader);
				} else {
					tbl_zItemTag1ins = null;
				}
			}
			scon.Close();
			return tbl_zItemTag1ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag1 table.
		/// </summary>
		public static List<tbl_zItemTag1> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag1SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemTag1> tbl_zItemTag1List = new List<tbl_zItemTag1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag1 tbl_zItemTag1 = Maketbl_zItemTag1(dataReader);
					tbl_zItemTag1List.Add(tbl_zItemTag1);
				}
			}
			scon.Close();
			return tbl_zItemTag1List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemTag1 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemTag1 Maketbl_zItemTag1(SqlDataReader dataReader) {
			tbl_zItemTag1 tbl_zItemTag1 = new tbl_zItemTag1();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemTag1.Tag1_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemTag1.Description = dataReader.GetString(1);
			}

			return tbl_zItemTag1;
		}
		/// <summary>
		/// This makes tbl_zItemTag1 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemTag1 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemTag1  tbl_zItemTag1   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tag1_ID = new DataColumn("tag1_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_tag1_ID,col_description,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemTag1 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemTag1 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemTag1 user) {
		DataRow drow = dt.NewRow();
		
			drow["tag1_ID"] = user.tag1_ID;
			drow["description"] = user.description;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
