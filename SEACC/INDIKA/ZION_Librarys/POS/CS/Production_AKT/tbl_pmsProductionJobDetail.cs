using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsProductionJobDetail {
		#region Fields
		private string productionJob_ID;
		private decimal jobFinishedQty;
		private decimal deliveryQty;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsProductionJobDetail class.
		/// </summary>
		public tbl_pmsProductionJobDetail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsProductionJobDetail class.
		/// </summary>
		public tbl_pmsProductionJobDetail(string productionJob_ID, decimal jobFinishedQty, decimal deliveryQty) {
			this.productionJob_ID = productionJob_ID;
			this.jobFinishedQty = jobFinishedQty;
			this.deliveryQty = deliveryQty;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobFinishedQty value.
		/// </summary>
		public decimal JobFinishedQty {
			get { return jobFinishedQty; }
			set { jobFinishedQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryQty value.
		/// </summary>
		public decimal DeliveryQty {
			get { return deliveryQty; }
			set { deliveryQty = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsProductionJobDetail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobDetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@jobFinishedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliveryQty", SqlDbType.Decimal,9);
 
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@jobFinishedQty"].Value = jobFinishedQty;
			scom.Parameters["@deliveryQty"].Value = deliveryQty;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsProductionJobDetail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobDetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@jobFinishedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliveryQty", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@jobFinishedQty"].Value = jobFinishedQty;
			scom.Parameters["@deliveryQty"].Value = deliveryQty;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsProductionJobDetail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobDetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsProductionJobDetail table.
		/// </summary>
		public static tbl_pmsProductionJobDetail Select(string productionJob_ID_Incoming){

			tbl_pmsProductionJobDetail tbl_pmsProductionJobDetailins = new tbl_pmsProductionJobDetail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobDetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsProductionJobDetailins = Maketbl_pmsProductionJobDetail(dataReader);
				} else {
					tbl_pmsProductionJobDetailins = null;
				}
			}
			scon.Close();
			return tbl_pmsProductionJobDetailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobDetail table.
		/// </summary>
		public static List<tbl_pmsProductionJobDetail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobDetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsProductionJobDetail> tbl_pmsProductionJobDetailList = new List<tbl_pmsProductionJobDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobDetail tbl_pmsProductionJobDetail = Maketbl_pmsProductionJobDetail(dataReader);
					tbl_pmsProductionJobDetailList.Add(tbl_pmsProductionJobDetail);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobDetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsProductionJobDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsProductionJobDetail Maketbl_pmsProductionJobDetail(SqlDataReader dataReader) {
			tbl_pmsProductionJobDetail tbl_pmsProductionJobDetail = new tbl_pmsProductionJobDetail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsProductionJobDetail.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsProductionJobDetail.JobFinishedQty = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsProductionJobDetail.DeliveryQty = dataReader.GetDecimal(2);
			}

			return tbl_pmsProductionJobDetail;
		}
		/// <summary>
		/// This makes tbl_pmsProductionJobDetail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsProductionJobDetail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsProductionJobDetail  tbl_pmsProductionJobDetail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_jobFinishedQty = new DataColumn("jobFinishedQty" , typeof(decimal));
			DataColumn col_deliveryQty = new DataColumn("deliveryQty" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_productionJob_ID,col_jobFinishedQty,col_deliveryQty,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsProductionJobDetail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsProductionJobDetail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsProductionJobDetail user) {
		DataRow drow = dt.NewRow();
		
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["jobFinishedQty"] = user.jobFinishedQty;
			drow["deliveryQty"] = user.deliveryQty;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
