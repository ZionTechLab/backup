using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_pmsSectionPlan_Master {
		#region Fields
		private string section_ID;
		private DateTime sectionPlanDate;
		private string job_ID;
		private string remark;
		private decimal qty;
		private int lineNo;
		private string uom;
		private string item_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsSectionPlan_Master class.
		/// </summary>
		public tbl_pmsSectionPlan_Master() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsSectionPlan_Master class.
		/// </summary>
		public tbl_pmsSectionPlan_Master(string section_ID, DateTime sectionPlanDate, string job_ID, string remark, decimal qty, int lineNo, string uom, string item_ID) {
			this.section_ID = section_ID;
			this.sectionPlanDate = sectionPlanDate;
			this.job_ID = job_ID;
			this.remark = remark;
			this.qty = qty;
			this.lineNo = lineNo;
			this.uom = uom;
			this.item_ID = item_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionPlanDate value.
		/// </summary>
		public DateTime SectionPlanDate {
			get { return sectionPlanDate; }
			set { sectionPlanDate = value; }
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
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the LineNo value.
		/// </summary>
		public int LineNo {
			get { return lineNo; }
			set { lineNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom value.
		/// </summary>
		public string Uom {
			get { return uom; }
			set { uom = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsSectionPlan_Master table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_MasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionPlanDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@LineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@Uom", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Item_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionPlanDate"].Value = sectionPlanDate;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@Qty"].Value = qty;
			scom.Parameters["@LineNo"].Value = lineNo;
			scom.Parameters["@Uom"].Value = uom;
			scom.Parameters["@Item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsSectionPlan_Master table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_MasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionPlanDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@LineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@Uom", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Item_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionPlanDate"].Value = sectionPlanDate;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@Qty"].Value = qty;
			scom.Parameters["@LineNo"].Value = lineNo;
			scom.Parameters["@Uom"].Value = uom;
			scom.Parameters["@Item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsSectionPlan_Master table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_MasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionPlanDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@sectionPlanDate"].Value = sectionPlanDate;
 
			scom.Parameters["@job_ID"].Value = job_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsSectionPlan_Master table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_MasterDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsSectionPlan_Master table.
		/// </summary>
		public static tbl_pmsSectionPlan_Master Select(string section_ID_Incoming, DateTime sectionPlanDate_Incoming, string job_ID_Incoming){

			tbl_pmsSectionPlan_Master tbl_pmsSectionPlan_Masterins = new tbl_pmsSectionPlan_Master();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_MasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionPlanDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@sectionPlanDate"].Value = sectionPlanDate_Incoming;
			scom.Parameters["@job_ID"].Value = job_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsSectionPlan_Masterins = Maketbl_pmsSectionPlan_Master(dataReader);
				} else {
					tbl_pmsSectionPlan_Masterins = null;
				}
			}
			scon.Close();
			return tbl_pmsSectionPlan_Masterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsSectionPlan_Master table.
		/// </summary>
		public static List<tbl_pmsSectionPlan_Master> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_MasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsSectionPlan_Master> tbl_pmsSectionPlan_MasterList = new List<tbl_pmsSectionPlan_Master>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsSectionPlan_Master tbl_pmsSectionPlan_Master = Maketbl_pmsSectionPlan_Master(dataReader);
					tbl_pmsSectionPlan_MasterList.Add(tbl_pmsSectionPlan_Master);
				}
			}
			scon.Close();
			return tbl_pmsSectionPlan_MasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsSectionPlan_Master table by a foreign key.
		/// </summary>
		public static List<tbl_pmsSectionPlan_Master> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_MasterSelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_pmsSectionPlan_Master> tbl_pmsSectionPlan_MasterList = new List<tbl_pmsSectionPlan_Master>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsSectionPlan_Master tbl_pmsSectionPlan_Master = Maketbl_pmsSectionPlan_Master(dataReader);
					tbl_pmsSectionPlan_MasterList.Add(tbl_pmsSectionPlan_Master);
				}
			}
			scon.Close();
			return tbl_pmsSectionPlan_MasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsSectionPlan_Master class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsSectionPlan_Master Maketbl_pmsSectionPlan_Master(SqlDataReader dataReader) {
			tbl_pmsSectionPlan_Master tbl_pmsSectionPlan_Master = new tbl_pmsSectionPlan_Master();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsSectionPlan_Master.Section_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsSectionPlan_Master.SectionPlanDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsSectionPlan_Master.Job_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsSectionPlan_Master.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsSectionPlan_Master.Qty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsSectionPlan_Master.LineNo = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsSectionPlan_Master.Uom = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsSectionPlan_Master.Item_ID = dataReader.GetString(7);
			}

			return tbl_pmsSectionPlan_Master;
		}
		/// <summary>
		/// This makes tbl_pmsSectionPlan_Master datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsSectionPlan_Master object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsSectionPlan_Master  tbl_pmsSectionPlan_Master   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_sectionPlanDate = new DataColumn("sectionPlanDate" , typeof(DateTime));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_Qty = new DataColumn("Qty" , typeof(decimal));
			DataColumn col_LineNo = new DataColumn("LineNo" , typeof(int));
			DataColumn col_Uom = new DataColumn("Uom" , typeof(string));
			DataColumn col_Item_ID = new DataColumn("Item_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_section_ID,col_sectionPlanDate,col_job_ID,col_remark,col_Qty,col_LineNo,col_Uom,col_Item_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsSectionPlan_Master datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsSectionPlan_Master object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsSectionPlan_Master user) {
		DataRow drow = dt.NewRow();
		
			drow["section_ID"] = user.section_ID;
			drow["sectionPlanDate"] = user.sectionPlanDate;
			drow["job_ID"] = user.job_ID;
			drow["remark"] = user.remark;
			drow["Qty"] = user.Qty;
			drow["LineNo"] = user.LineNo;
			drow["Uom"] = user.Uom;
			drow["Item_ID"] = user.Item_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
