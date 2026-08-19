using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPettyCash_Level_4 {
		#region Fields
		private string pettyCash_Level_4_ID;
		private string pettyCash_Level_4Name;
		private string pettyCash_Level_3_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCash_Level_4 class.
		/// </summary>
		public tbl_zPettyCash_Level_4() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPettyCash_Level_4 class.
		/// </summary>
		public tbl_zPettyCash_Level_4(string pettyCash_Level_4_ID, string pettyCash_Level_4Name, string pettyCash_Level_3_ID) {
			this.pettyCash_Level_4_ID = pettyCash_Level_4_ID;
			this.pettyCash_Level_4Name = pettyCash_Level_4Name;
			this.pettyCash_Level_3_ID = pettyCash_Level_3_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PettyCash_Level_4_ID value.
		/// </summary>
		public string PettyCash_Level_4_ID {
			get { return pettyCash_Level_4_ID; }
			set { pettyCash_Level_4_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCash_Level_4Name value.
		/// </summary>
		public string PettyCash_Level_4Name {
			get { return pettyCash_Level_4Name; }
			set { pettyCash_Level_4Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCash_Level_3_ID value.
		/// </summary>
		public string PettyCash_Level_3_ID {
			get { return pettyCash_Level_3_ID; }
			set { pettyCash_Level_3_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zPettyCash_Level_4 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_4Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCash_Level_4_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCash_Level_4Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@pettyCash_Level_3_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@pettyCash_Level_4_ID"].Value = pettyCash_Level_4_ID;
			scom.Parameters["@pettyCash_Level_4Name"].Value = pettyCash_Level_4Name;
			scom.Parameters["@pettyCash_Level_3_ID"].Value = pettyCash_Level_3_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPettyCash_Level_4 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_4Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCash_Level_4_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCash_Level_4Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@pettyCash_Level_3_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@pettyCash_Level_4_ID"].Value = pettyCash_Level_4_ID;
			scom.Parameters["@pettyCash_Level_4Name"].Value = pettyCash_Level_4Name;
			scom.Parameters["@pettyCash_Level_3_ID"].Value = pettyCash_Level_3_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPettyCash_Level_4 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_4Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pettyCash_Level_4_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_4_ID"].Value = pettyCash_Level_4_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCash_Level_4 table by a foreign key.
		/// </summary>
		public static void DeleteAllByPettyCash_Level_3_ID(string pettyCash_Level_3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_4DeleteAllByPettyCash_Level_3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_3_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_3_ID"].Value = pettyCash_Level_3_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPettyCash_Level_4 table.
		/// </summary>
		public static tbl_zPettyCash_Level_4 Select(string pettyCash_Level_4_ID_Incoming){

			tbl_zPettyCash_Level_4 tbl_zPettyCash_Level_4ins = new tbl_zPettyCash_Level_4();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_4Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_4_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_4_ID"].Value = pettyCash_Level_4_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPettyCash_Level_4ins = Maketbl_zPettyCash_Level_4(dataReader);
				} else {
					tbl_zPettyCash_Level_4ins = null;
				}
			}
			scon.Close();
			return tbl_zPettyCash_Level_4ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCash_Level_4 table.
		/// </summary>
		public static List<tbl_zPettyCash_Level_4> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_4SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPettyCash_Level_4> tbl_zPettyCash_Level_4List = new List<tbl_zPettyCash_Level_4>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPettyCash_Level_4 tbl_zPettyCash_Level_4 = Maketbl_zPettyCash_Level_4(dataReader);
					tbl_zPettyCash_Level_4List.Add(tbl_zPettyCash_Level_4);
				}
			}
			scon.Close();
			return tbl_zPettyCash_Level_4List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPettyCash_Level_4 table by a foreign key.
		/// </summary>
		public static List<tbl_zPettyCash_Level_4> SelectAllByPettyCash_Level_3_ID(string pettyCash_Level_3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPettyCash_Level_4SelectAllByPettyCash_Level_3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCash_Level_3_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCash_Level_3_ID"].Value = pettyCash_Level_3_ID;
				List<tbl_zPettyCash_Level_4> tbl_zPettyCash_Level_4List = new List<tbl_zPettyCash_Level_4>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPettyCash_Level_4 tbl_zPettyCash_Level_4 = Maketbl_zPettyCash_Level_4(dataReader);
					tbl_zPettyCash_Level_4List.Add(tbl_zPettyCash_Level_4);
				}
			}
			scon.Close();
			return tbl_zPettyCash_Level_4List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPettyCash_Level_4 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPettyCash_Level_4 Maketbl_zPettyCash_Level_4(SqlDataReader dataReader) {
			tbl_zPettyCash_Level_4 tbl_zPettyCash_Level_4 = new tbl_zPettyCash_Level_4();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPettyCash_Level_4.PettyCash_Level_4_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPettyCash_Level_4.PettyCash_Level_4Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zPettyCash_Level_4.PettyCash_Level_3_ID = dataReader.GetString(2);
			}

			return tbl_zPettyCash_Level_4;
		}
		/// <summary>
		/// This makes tbl_zPettyCash_Level_4 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPettyCash_Level_4 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPettyCash_Level_4  tbl_zPettyCash_Level_4   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pettyCash_Level_4_ID = new DataColumn("pettyCash_Level_4_ID" , typeof(string));
			DataColumn col_pettyCash_Level_4Name = new DataColumn("pettyCash_Level_4Name" , typeof(string));
			DataColumn col_pettyCash_Level_3_ID = new DataColumn("pettyCash_Level_3_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_pettyCash_Level_4_ID,col_pettyCash_Level_4Name,col_pettyCash_Level_3_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPettyCash_Level_4 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPettyCash_Level_4 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPettyCash_Level_4 user) {
		DataRow drow = dt.NewRow();
		
			drow["pettyCash_Level_4_ID"] = user.pettyCash_Level_4_ID;
			drow["pettyCash_Level_4Name"] = user.pettyCash_Level_4Name;
			drow["pettyCash_Level_3_ID"] = user.pettyCash_Level_3_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
