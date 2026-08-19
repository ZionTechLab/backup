using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsSectionPlan_LogDetail {
		#region Fields
		private Int64 sectionPlan_ID;
		private string job_ID;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsSectionPlan_LogDetail class.
		/// </summary>
		public tbl_pmsSectionPlan_LogDetail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsSectionPlan_LogDetail class.
		/// </summary>
		public tbl_pmsSectionPlan_LogDetail(Int64 sectionPlan_ID, string job_ID, string remark) {
			this.sectionPlan_ID = sectionPlan_ID;
			this.job_ID = job_ID;
			this.remark = remark;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SectionPlan_ID value.
		/// </summary>
		public Int64 SectionPlan_ID {
			get { return sectionPlan_ID; }
			set { sectionPlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsSectionPlan_LogDetail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogDetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sectionPlan_ID", SqlDbType.BigInt,8);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
 
			scom.Parameters["@sectionPlan_ID"].Value = sectionPlan_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsSectionPlan_LogDetail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogDetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@sectionPlan_ID", SqlDbType.BigInt, 8);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@sectionPlan_ID"].Value = sectionPlan_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsSectionPlan_LogDetail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogDetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@sectionPlan_ID", SqlDbType.BigInt, 8);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sectionPlan_ID"].Value = sectionPlan_ID;
 
			scom.Parameters["@job_ID"].Value = job_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsSectionPlan_LogDetail table.
		/// </summary>
		public static tbl_pmsSectionPlan_LogDetail Select(Int64 sectionPlan_ID_Incoming, string job_ID_Incoming){

			tbl_pmsSectionPlan_LogDetail tbl_pmsSectionPlan_LogDetailins = new tbl_pmsSectionPlan_LogDetail();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogDetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@sectionPlan_ID", SqlDbType.BigInt, 8);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sectionPlan_ID"].Value = sectionPlan_ID_Incoming;
			scom.Parameters["@job_ID"].Value = job_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsSectionPlan_LogDetailins = Maketbl_pmsSectionPlan_LogDetail(dataReader);
				} else {
					tbl_pmsSectionPlan_LogDetailins = null;
				}
			}
			scon.Close();
			return tbl_pmsSectionPlan_LogDetailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsSectionPlan_LogDetail table.
		/// </summary>
		public static List<tbl_pmsSectionPlan_LogDetail> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogDetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsSectionPlan_LogDetail> tbl_pmsSectionPlan_LogDetailList = new List<tbl_pmsSectionPlan_LogDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsSectionPlan_LogDetail tbl_pmsSectionPlan_LogDetail = Maketbl_pmsSectionPlan_LogDetail(dataReader);
					tbl_pmsSectionPlan_LogDetailList.Add(tbl_pmsSectionPlan_LogDetail);
				}
			}
			scon.Close();
			return tbl_pmsSectionPlan_LogDetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsSectionPlan_LogDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsSectionPlan_LogDetail Maketbl_pmsSectionPlan_LogDetail(SqlDataReader dataReader) {
			tbl_pmsSectionPlan_LogDetail tbl_pmsSectionPlan_LogDetail = new tbl_pmsSectionPlan_LogDetail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsSectionPlan_LogDetail.SectionPlan_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsSectionPlan_LogDetail.Job_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsSectionPlan_LogDetail.Remark = dataReader.GetString(2);
			}

			return tbl_pmsSectionPlan_LogDetail;
		}
		/// <summary>
		/// This makes tbl_pmsSectionPlan_LogDetail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsSectionPlan_LogDetail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsSectionPlan_LogDetail  tbl_pmsSectionPlan_LogDetail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_sectionPlan_ID = new DataColumn("sectionPlan_ID" , typeof(Int64));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_sectionPlan_ID,col_job_ID,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsSectionPlan_LogDetail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsSectionPlan_LogDetail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsSectionPlan_LogDetail user) {
		DataRow drow = dt.NewRow();
		
			drow["sectionPlan_ID"] = user.sectionPlan_ID;
			drow["job_ID"] = user.job_ID;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
