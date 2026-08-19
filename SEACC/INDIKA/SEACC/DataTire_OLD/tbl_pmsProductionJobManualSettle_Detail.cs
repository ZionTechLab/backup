using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsProductionJobManualSettle_Detail {
		#region Fields
		private int settle_ID;
		private string customerOrder_ID;
		private bool isSettle;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsProductionJobManualSettle_Detail class.
		/// </summary>
		public tbl_pmsProductionJobManualSettle_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsProductionJobManualSettle_Detail class.
		/// </summary>
		public tbl_pmsProductionJobManualSettle_Detail(int settle_ID, string customerOrder_ID, bool isSettle) {
			this.settle_ID = settle_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.isSettle = isSettle;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Settle_ID value.
		/// </summary>
		public int Settle_ID {
			get { return settle_ID; }
			set { settle_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSettle value.
		/// </summary>
		public bool IsSettle {
			get { return isSettle; }
			set { isSettle = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsProductionJobManualSettle_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@settle_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSettle", SqlDbType.Bit,1);
 
			scom.Parameters["@settle_ID"].Value = settle_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@isSettle"].Value = isSettle;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsProductionJobManualSettle_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@settle_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSettle", SqlDbType.Bit,1);
 
 
			scom.Parameters["@settle_ID"].Value = settle_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@isSettle"].Value = isSettle;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsProductionJobManualSettle_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@settle_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@settle_ID"].Value = settle_ID;
 
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobManualSettle_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobManualSettle_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySettle_ID(int settle_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailDeleteAllBySettle_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@settle_ID", SqlDbType.Int,4);
			scom.Parameters["@settle_ID"].Value = settle_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsProductionJobManualSettle_Detail table.
		/// </summary>
		public static tbl_pmsProductionJobManualSettle_Detail Select(int settle_ID_Incoming, string customerOrder_ID_Incoming){

			tbl_pmsProductionJobManualSettle_Detail tbl_pmsProductionJobManualSettle_Detailins = new tbl_pmsProductionJobManualSettle_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@settle_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@settle_ID"].Value = settle_ID_Incoming;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsProductionJobManualSettle_Detailins = Maketbl_pmsProductionJobManualSettle_Detail(dataReader);
				} else {
					tbl_pmsProductionJobManualSettle_Detailins = null;
				}
			}
			scon.Close();
			return tbl_pmsProductionJobManualSettle_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobManualSettle_Detail table.
		/// </summary>
		public static List<tbl_pmsProductionJobManualSettle_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsProductionJobManualSettle_Detail> tbl_pmsProductionJobManualSettle_DetailList = new List<tbl_pmsProductionJobManualSettle_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobManualSettle_Detail tbl_pmsProductionJobManualSettle_Detail = Maketbl_pmsProductionJobManualSettle_Detail(dataReader);
					tbl_pmsProductionJobManualSettle_DetailList.Add(tbl_pmsProductionJobManualSettle_Detail);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobManualSettle_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobManualSettle_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobManualSettle_Detail> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_pmsProductionJobManualSettle_Detail> tbl_pmsProductionJobManualSettle_DetailList = new List<tbl_pmsProductionJobManualSettle_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobManualSettle_Detail tbl_pmsProductionJobManualSettle_Detail = Maketbl_pmsProductionJobManualSettle_Detail(dataReader);
					tbl_pmsProductionJobManualSettle_DetailList.Add(tbl_pmsProductionJobManualSettle_Detail);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobManualSettle_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobManualSettle_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobManualSettle_Detail> SelectAllBySettle_ID(int settle_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobManualSettle_DetailSelectAllBySettle_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@settle_ID", SqlDbType.Int,4);
			scom.Parameters["@settle_ID"].Value = settle_ID;
				List<tbl_pmsProductionJobManualSettle_Detail> tbl_pmsProductionJobManualSettle_DetailList = new List<tbl_pmsProductionJobManualSettle_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobManualSettle_Detail tbl_pmsProductionJobManualSettle_Detail = Maketbl_pmsProductionJobManualSettle_Detail(dataReader);
					tbl_pmsProductionJobManualSettle_DetailList.Add(tbl_pmsProductionJobManualSettle_Detail);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobManualSettle_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsProductionJobManualSettle_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsProductionJobManualSettle_Detail Maketbl_pmsProductionJobManualSettle_Detail(SqlDataReader dataReader) {
			tbl_pmsProductionJobManualSettle_Detail tbl_pmsProductionJobManualSettle_Detail = new tbl_pmsProductionJobManualSettle_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsProductionJobManualSettle_Detail.Settle_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsProductionJobManualSettle_Detail.CustomerOrder_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsProductionJobManualSettle_Detail.IsSettle = dataReader.GetBoolean(2);
			}

			return tbl_pmsProductionJobManualSettle_Detail;
		}
		/// <summary>
		/// This makes tbl_pmsProductionJobManualSettle_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsProductionJobManualSettle_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsProductionJobManualSettle_Detail  tbl_pmsProductionJobManualSettle_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_settle_ID = new DataColumn("settle_ID" , typeof(int));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_isSettle = new DataColumn("isSettle" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_settle_ID,col_customerOrder_ID,col_isSettle,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsProductionJobManualSettle_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsProductionJobManualSettle_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsProductionJobManualSettle_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["settle_ID"] = user.settle_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["isSettle"] = user.isSettle;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
