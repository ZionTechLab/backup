using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccCostCenter1 {

		#region Fields
		private string costCenter1_ID;
		private string costCenter1Name;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccCostCenter1 class.
		/// </summary>
		public tbl_zAccCostCenter1() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccCostCenter1 class.
		/// </summary>
		public tbl_zAccCostCenter1(string costCenter1_ID, string costCenter1Name) {
			this.costCenter1_ID = costCenter1_ID;
			this.costCenter1Name = costCenter1Name;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CostCenter1_ID value.
		/// </summary>
		public string CostCenter1_ID {
			get { return costCenter1_ID; }
			set { costCenter1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter1Name value.
		/// </summary>
		public string CostCenter1Name {
			get { return costCenter1Name; }
			set { costCenter1Name = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccCostCenter1 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter1Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter1Name", SqlDbType.VarChar,50);
 
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter1Name"].Value = costCenter1Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccCostCenter1 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter1Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter1Name", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter1Name"].Value = costCenter1Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccCostCenter1 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter1Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccCostCenter1 table.
		/// </summary>
		public static tbl_zAccCostCenter1 Select(string costCenter1_ID_Incoming){

			tbl_zAccCostCenter1 tbl_zAccCostCenter1ins = new tbl_zAccCostCenter1();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter1Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccCostCenter1ins = Maketbl_zAccCostCenter1(dataReader);
				} else {
					tbl_zAccCostCenter1ins = null;
				}
			}
			scon.Close();
			return tbl_zAccCostCenter1ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccCostCenter1 table.
		/// </summary>
		public static List<tbl_zAccCostCenter1> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenter1SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccCostCenter1> tbl_zAccCostCenter1List = new List<tbl_zAccCostCenter1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccCostCenter1 tbl_zAccCostCenter1 = Maketbl_zAccCostCenter1(dataReader);
					tbl_zAccCostCenter1List.Add(tbl_zAccCostCenter1);
				}
			}
			scon.Close();
			return tbl_zAccCostCenter1List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccCostCenter1 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccCostCenter1 Maketbl_zAccCostCenter1(SqlDataReader dataReader) {
			tbl_zAccCostCenter1 tbl_zAccCostCenter1 = new tbl_zAccCostCenter1();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccCostCenter1.CostCenter1_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccCostCenter1.CostCenter1Name = dataReader.GetString(1);
			}

			return tbl_zAccCostCenter1;
		}
		/// <summary>
		/// This makes tbl_zAccCostCenter1 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccCostCenter1 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccCostCenter1  tbl_zAccCostCenter1   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_costCenter1_ID = new DataColumn("costCenter1_ID" , typeof(string));
			DataColumn col_costCenter1Name = new DataColumn("costCenter1Name" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_costCenter1_ID,col_costCenter1Name,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccCostCenter1 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccCostCenter1 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccCostCenter1 user) {
		DataRow drow = dt.NewRow();
		
			drow["costCenter1_ID"] = user.costCenter1_ID;
			drow["costCenter1Name"] = user.costCenter1Name;
		dt.Rows.Add(drow);
		}
		#endregion

	}
}
