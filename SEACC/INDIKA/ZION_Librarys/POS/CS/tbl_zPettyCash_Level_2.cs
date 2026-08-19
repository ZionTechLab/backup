using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPettyCash_Level_2 {
		#region Fields
		private string pettyCash_Level_2_ID;
		private string pettyCash_Level_2Name;
		private string pettyCash_Level_1_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCash_Level_2 class.
		/// </summary>
		public tbl_zPettyCash_Level_2() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCash_Level_2 class.
		/// </summary>
		public tbl_zPettyCash_Level_2(string pettyCash_Level_2_ID, string pettyCash_Level_2Name, string pettyCash_Level_1_ID) {
			this.pettyCash_Level_2_ID = pettyCash_Level_2_ID;
			this.pettyCash_Level_2Name = pettyCash_Level_2Name;
			this.pettyCash_Level_1_ID = pettyCash_Level_1_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PettyCash_Level_2_ID value.
		/// </summary>
		public string PettyCash_Level_2_ID {
			get { return pettyCash_Level_2_ID; }
			set { pettyCash_Level_2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCash_Level_2Name value.
		/// </summary>
		public string PettyCash_Level_2Name {
			get { return pettyCash_Level_2Name; }
			set { pettyCash_Level_2Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCash_Level_1_ID value.
		/// </summary>
		public string PettyCash_Level_1_ID {
			get { return pettyCash_Level_1_ID; }
			set { pettyCash_Level_1_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zPettyCash_Level_2 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_2Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCash_Level_2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCash_Level_2Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@pettyCash_Level_1_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@pettyCash_Level_2_ID"].Value = pettyCash_Level_2_ID;
			scom.Parameters["@pettyCash_Level_2Name"].Value = pettyCash_Level_2Name;
			scom.Parameters["@pettyCash_Level_1_ID"].Value = pettyCash_Level_1_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPettyCash_Level_2 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_2Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCash_Level_2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCash_Level_2Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@pettyCash_Level_1_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@pettyCash_Level_2_ID"].Value = pettyCash_Level_2_ID;
			scom.Parameters["@pettyCash_Level_2Name"].Value = pettyCash_Level_2Name;
			scom.Parameters["@pettyCash_Level_1_ID"].Value = pettyCash_Level_1_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPettyCash_Level_2 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_2Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pettyCash_Level_2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_2_ID"].Value = pettyCash_Level_2_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCash_Level_2 table by a foreign key.
		/// </summary>
		public static void DeleteAllByPettyCash_Level_1_ID(string pettyCash_Level_1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_2DeleteAllByPettyCash_Level_1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_1_ID"].Value = pettyCash_Level_1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPettyCash_Level_2 table.
		/// </summary>
		public static tbl_zPettyCash_Level_2 Select(string pettyCash_Level_2_ID_Incoming){

			tbl_zPettyCash_Level_2 tbl_zPettyCash_Level_2ins = new tbl_zPettyCash_Level_2();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_2Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_2_ID"].Value = pettyCash_Level_2_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPettyCash_Level_2ins = Maketbl_zPettyCash_Level_2(dataReader);
				} else {
					tbl_zPettyCash_Level_2ins = null;
				}
			}
			scon.Close();
			return tbl_zPettyCash_Level_2ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCash_Level_2 table.
		/// </summary>
		public static List<tbl_zPettyCash_Level_2> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_2SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPettyCash_Level_2> tbl_zPettyCash_Level_2List = new List<tbl_zPettyCash_Level_2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPettyCash_Level_2 tbl_zPettyCash_Level_2 = Maketbl_zPettyCash_Level_2(dataReader);
					tbl_zPettyCash_Level_2List.Add(tbl_zPettyCash_Level_2);
				}
			}
			scon.Close();
			return tbl_zPettyCash_Level_2List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCash_Level_2 table by a foreign key.
		/// </summary>
		public static List<tbl_zPettyCash_Level_2> SelectAllByPettyCash_Level_1_ID(string pettyCash_Level_1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_2SelectAllByPettyCash_Level_1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_1_ID"].Value = pettyCash_Level_1_ID;
				List<tbl_zPettyCash_Level_2> tbl_zPettyCash_Level_2List = new List<tbl_zPettyCash_Level_2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPettyCash_Level_2 tbl_zPettyCash_Level_2 = Maketbl_zPettyCash_Level_2(dataReader);
					tbl_zPettyCash_Level_2List.Add(tbl_zPettyCash_Level_2);
				}
			}
			scon.Close();
			return tbl_zPettyCash_Level_2List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPettyCash_Level_2 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPettyCash_Level_2 Maketbl_zPettyCash_Level_2(SqlDataReader dataReader) {
			tbl_zPettyCash_Level_2 tbl_zPettyCash_Level_2 = new tbl_zPettyCash_Level_2();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPettyCash_Level_2.PettyCash_Level_2_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPettyCash_Level_2.PettyCash_Level_2Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zPettyCash_Level_2.PettyCash_Level_1_ID = dataReader.GetString(2);
			}

			return tbl_zPettyCash_Level_2;
		}
		/// <summary>
		/// This makes tbl_zPettyCash_Level_2 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPettyCash_Level_2 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPettyCash_Level_2  tbl_zPettyCash_Level_2   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pettyCash_Level_2_ID = new DataColumn("pettyCash_Level_2_ID" , typeof(string));
			DataColumn col_pettyCash_Level_2Name = new DataColumn("pettyCash_Level_2Name" , typeof(string));
			DataColumn col_pettyCash_Level_1_ID = new DataColumn("pettyCash_Level_1_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_pettyCash_Level_2_ID,col_pettyCash_Level_2Name,col_pettyCash_Level_1_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPettyCash_Level_2 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPettyCash_Level_2 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPettyCash_Level_2 user) {
		DataRow drow = dt.NewRow();
		
			drow["pettyCash_Level_2_ID"] = user.pettyCash_Level_2_ID;
			drow["pettyCash_Level_2Name"] = user.pettyCash_Level_2Name;
			drow["pettyCash_Level_1_ID"] = user.pettyCash_Level_1_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
