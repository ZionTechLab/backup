using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccCostCenter2 {
		#region Fields
		private string costCenter2_ID;
		private string costCenter2Name;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccCostCenter2 class.
		/// </summary>
		public tbl_zAccCostCenter2() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccCostCenter2 class.
		/// </summary>
		public tbl_zAccCostCenter2(string costCenter2_ID, string costCenter2Name) {
			this.costCenter2_ID = costCenter2_ID;
			this.costCenter2Name = costCenter2Name;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CostCenter2_ID value.
		/// </summary>
		public string CostCenter2_ID {
			get { return costCenter2_ID; }
			set { costCenter2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter2Name value.
		/// </summary>
		public string CostCenter2Name {
			get { return costCenter2Name; }
			set { costCenter2Name = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccCostCenter2 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter2Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2Name", SqlDbType.VarChar,50);
 
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@costCenter2Name"].Value = costCenter2Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccCostCenter2 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter2Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2Name", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@costCenter2Name"].Value = costCenter2Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccCostCenter2 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter2Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccCostCenter2 table.
		/// </summary>
		public static tbl_zAccCostCenter2 Select(string costCenter2_ID_Incoming){

			tbl_zAccCostCenter2 tbl_zAccCostCenter2ins = new tbl_zAccCostCenter2();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter2Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccCostCenter2ins = Maketbl_zAccCostCenter2(dataReader);
				} else {
					tbl_zAccCostCenter2ins = null;
				}
			}
			scon.Close();
			return tbl_zAccCostCenter2ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccCostCenter2 table.
		/// </summary>
		public static List<tbl_zAccCostCenter2> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter2SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccCostCenter2> tbl_zAccCostCenter2List = new List<tbl_zAccCostCenter2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccCostCenter2 tbl_zAccCostCenter2 = Maketbl_zAccCostCenter2(dataReader);
					tbl_zAccCostCenter2List.Add(tbl_zAccCostCenter2);
				}
			}
			scon.Close();
			return tbl_zAccCostCenter2List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccCostCenter2 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccCostCenter2 Maketbl_zAccCostCenter2(SqlDataReader dataReader) {
			tbl_zAccCostCenter2 tbl_zAccCostCenter2 = new tbl_zAccCostCenter2();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccCostCenter2.CostCenter2_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccCostCenter2.CostCenter2Name = dataReader.GetString(1);
			}

			return tbl_zAccCostCenter2;
		}
		/// <summary>
		/// This makes tbl_zAccCostCenter2 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccCostCenter2 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccCostCenter2  tbl_zAccCostCenter2   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_costCenter2_ID = new DataColumn("costCenter2_ID" , typeof(string));
			DataColumn col_costCenter2Name = new DataColumn("costCenter2Name" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_costCenter2_ID,col_costCenter2Name,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccCostCenter2 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccCostCenter2 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccCostCenter2 user) {
		DataRow drow = dt.NewRow();
		
			drow["costCenter2_ID"] = user.costCenter2_ID;
			drow["costCenter2Name"] = user.costCenter2Name;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
