using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCost_Center1 {
		#region Fields
		private string cost_Center1_ID;
		private string cost_Center1_Name;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCost_Center1 class.
		/// </summary>
		public tbl_zCost_Center1() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCost_Center1 class.
		/// </summary>
		public tbl_zCost_Center1(string cost_Center1_ID, string cost_Center1_Name, bool isCanceled) {
			this.cost_Center1_ID = cost_Center1_ID;
			this.cost_Center1_Name = cost_Center1_Name;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Cost_Center1_ID value.
		/// </summary>
		public string Cost_Center1_ID {
			get { return cost_Center1_ID; }
			set { cost_Center1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center1_Name value.
		/// </summary>
		public string Cost_Center1_Name {
			get { return cost_Center1_Name; }
			set { cost_Center1_Name = value; }
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
		/// Saves a record to the tbl_zCost_Center1 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCost_Center1Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@cost_Center1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center1_Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@cost_Center1_ID"].Value = cost_Center1_ID;
			scom.Parameters["@cost_Center1_Name"].Value = cost_Center1_Name;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCost_Center1 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCost_Center1Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@cost_Center1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center1_Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@cost_Center1_ID"].Value = cost_Center1_ID;
			scom.Parameters["@cost_Center1_Name"].Value = cost_Center1_Name;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCost_Center1 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCost_Center1Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@cost_Center1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center1_ID"].Value = cost_Center1_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCost_Center1 table.
		/// </summary>
		public static tbl_zCost_Center1 Select(string cost_Center1_ID_Incoming){

			tbl_zCost_Center1 tbl_zCost_Center1ins = new tbl_zCost_Center1();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCost_Center1Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center1_ID"].Value = cost_Center1_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCost_Center1ins = Maketbl_zCost_Center1(dataReader);
				} else {
					tbl_zCost_Center1ins = null;
				}
			}
			scon.Close();
			return tbl_zCost_Center1ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCost_Center1 table.
		/// </summary>
		public static List<tbl_zCost_Center1> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCost_Center1SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCost_Center1> tbl_zCost_Center1List = new List<tbl_zCost_Center1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCost_Center1 tbl_zCost_Center1 = Maketbl_zCost_Center1(dataReader);
					tbl_zCost_Center1List.Add(tbl_zCost_Center1);
				}
			}
			scon.Close();
			return tbl_zCost_Center1List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCost_Center1 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCost_Center1 Maketbl_zCost_Center1(SqlDataReader dataReader) {
			tbl_zCost_Center1 tbl_zCost_Center1 = new tbl_zCost_Center1();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCost_Center1.Cost_Center1_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCost_Center1.Cost_Center1_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zCost_Center1.IsCanceled = dataReader.GetBoolean(2);
			}

			return tbl_zCost_Center1;
		}
		/// <summary>
		/// This makes tbl_zCost_Center1 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zCost_Center1 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zCost_Center1  tbl_zCost_Center1   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_cost_Center1_ID = new DataColumn("cost_Center1_ID" , typeof(string));
			DataColumn col_cost_Center1_Name = new DataColumn("cost_Center1_Name" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_cost_Center1_ID,col_cost_Center1_Name,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zCost_Center1 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCost_Center1 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCost_Center1 user) {
		DataRow drow = dt.NewRow();
		
			drow["cost_Center1_ID"] = user.cost_Center1_ID;
			drow["cost_Center1_Name"] = user.cost_Center1_Name;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
