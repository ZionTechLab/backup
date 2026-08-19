using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPettyCash_Level_1 {
		#region Fields
		private string pettyCash_Level_1_ID;
		private string pettyCash_Level_1Name;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCash_Level_1 class.
		/// </summary>
		public tbl_zPettyCash_Level_1() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCash_Level_1 class.
		/// </summary>
		public tbl_zPettyCash_Level_1(string pettyCash_Level_1_ID, string pettyCash_Level_1Name) {
			this.pettyCash_Level_1_ID = pettyCash_Level_1_ID;
			this.pettyCash_Level_1Name = pettyCash_Level_1Name;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PettyCash_Level_1_ID value.
		/// </summary>
		public string PettyCash_Level_1_ID {
			get { return pettyCash_Level_1_ID; }
			set { pettyCash_Level_1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCash_Level_1Name value.
		/// </summary>
		public string PettyCash_Level_1Name {
			get { return pettyCash_Level_1Name; }
			set { pettyCash_Level_1Name = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zPettyCash_Level_1 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_1Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCash_Level_1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCash_Level_1Name", SqlDbType.VarChar,200);
 
			scom.Parameters["@pettyCash_Level_1_ID"].Value = pettyCash_Level_1_ID;
			scom.Parameters["@pettyCash_Level_1Name"].Value = pettyCash_Level_1Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPettyCash_Level_1 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_1Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCash_Level_1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCash_Level_1Name", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@pettyCash_Level_1_ID"].Value = pettyCash_Level_1_ID;
			scom.Parameters["@pettyCash_Level_1Name"].Value = pettyCash_Level_1Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPettyCash_Level_1 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_1Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pettyCash_Level_1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_1_ID"].Value = pettyCash_Level_1_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPettyCash_Level_1 table.
		/// </summary>
		public static tbl_zPettyCash_Level_1 Select(string pettyCash_Level_1_ID_Incoming){

			tbl_zPettyCash_Level_1 tbl_zPettyCash_Level_1ins = new tbl_zPettyCash_Level_1();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_1Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_1_ID"].Value = pettyCash_Level_1_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPettyCash_Level_1ins = Maketbl_zPettyCash_Level_1(dataReader);
				} else {
					tbl_zPettyCash_Level_1ins = null;
				}
			}
			scon.Close();
			return tbl_zPettyCash_Level_1ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCash_Level_1 table.
		/// </summary>
		public static List<tbl_zPettyCash_Level_1> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_1SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPettyCash_Level_1> tbl_zPettyCash_Level_1List = new List<tbl_zPettyCash_Level_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPettyCash_Level_1 tbl_zPettyCash_Level_1 = Maketbl_zPettyCash_Level_1(dataReader);
					tbl_zPettyCash_Level_1List.Add(tbl_zPettyCash_Level_1);
				}
			}
			scon.Close();
			return tbl_zPettyCash_Level_1List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPettyCash_Level_1 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPettyCash_Level_1 Maketbl_zPettyCash_Level_1(SqlDataReader dataReader) {
			tbl_zPettyCash_Level_1 tbl_zPettyCash_Level_1 = new tbl_zPettyCash_Level_1();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPettyCash_Level_1.PettyCash_Level_1_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPettyCash_Level_1.PettyCash_Level_1Name = dataReader.GetString(1);
			}

			return tbl_zPettyCash_Level_1;
		}
		/// <summary>
		/// This makes tbl_zPettyCash_Level_1 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPettyCash_Level_1 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPettyCash_Level_1  tbl_zPettyCash_Level_1   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pettyCash_Level_1_ID = new DataColumn("pettyCash_Level_1_ID" , typeof(string));
			DataColumn col_pettyCash_Level_1Name = new DataColumn("pettyCash_Level_1Name" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_pettyCash_Level_1_ID,col_pettyCash_Level_1Name,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPettyCash_Level_1 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPettyCash_Level_1 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPettyCash_Level_1 user) {
		DataRow drow = dt.NewRow();
		
			drow["pettyCash_Level_1_ID"] = user.pettyCash_Level_1_ID;
			drow["pettyCash_Level_1Name"] = user.pettyCash_Level_1Name;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
