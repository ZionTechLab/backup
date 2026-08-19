using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rptTempProductionMachineWiser_Detail {
		#region Fields
		private int line_No;
		private DateTime reportDate;
		private string section_ID;
		private string sectionName;
		private string machine_ID;
		private string machineName;
		private decimal jobChange;
		private decimal rejection;
		private decimal qty;
		private decimal weight;
		private decimal lenght;
		private string uomLength_ID;
		private decimal cylinderSize;
		private decimal counter;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rptTempProductionMachineWiser_Detail class.
		/// </summary>
		public tbl_rptTempProductionMachineWiser_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rptTempProductionMachineWiser_Detail class.
		/// </summary>
		public tbl_rptTempProductionMachineWiser_Detail(DateTime reportDate, string section_ID, string sectionName, string machine_ID, string machineName, decimal jobChange, decimal rejection, decimal qty, decimal weight, decimal lenght, string uomLength_ID, decimal cylinderSize, decimal counter) {
			this.reportDate = reportDate;
			this.section_ID = section_ID;
			this.sectionName = sectionName;
			this.machine_ID = machine_ID;
			this.machineName = machineName;
			this.jobChange = jobChange;
			this.rejection = rejection;
			this.qty = qty;
			this.weight = weight;
			this.lenght = lenght;
			this.uomLength_ID = uomLength_ID;
			this.cylinderSize = cylinderSize;
			this.counter = counter;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rptTempProductionMachineWiser_Detail class.
		/// </summary>
		public tbl_rptTempProductionMachineWiser_Detail(int line_No, DateTime reportDate, string section_ID, string sectionName, string machine_ID, string machineName, decimal jobChange, decimal rejection, decimal qty, decimal weight, decimal lenght, string uomLength_ID, decimal cylinderSize, decimal counter) {
			this.line_No = line_No;
			this.reportDate = reportDate;
			this.section_ID = section_ID;
			this.sectionName = sectionName;
			this.machine_ID = machine_ID;
			this.machineName = machineName;
			this.jobChange = jobChange;
			this.rejection = rejection;
			this.qty = qty;
			this.weight = weight;
			this.lenght = lenght;
			this.uomLength_ID = uomLength_ID;
			this.cylinderSize = cylinderSize;
			this.counter = counter;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportDate value.
		/// </summary>
		public DateTime ReportDate {
			get { return reportDate; }
			set { reportDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionName value.
		/// </summary>
		public string SectionName {
			get { return sectionName; }
			set { sectionName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineName value.
		/// </summary>
		public string MachineName {
			get { return machineName; }
			set { machineName = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobChange value.
		/// </summary>
		public decimal JobChange {
			get { return jobChange; }
			set { jobChange = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rejection value.
		/// </summary>
		public decimal Rejection {
			get { return rejection; }
			set { rejection = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Lenght value.
		/// </summary>
		public decimal Lenght {
			get { return lenght; }
			set { lenght = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomLength_ID value.
		/// </summary>
		public string UomLength_ID {
			get { return uomLength_ID; }
			set { uomLength_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CylinderSize value.
		/// </summary>
		public decimal CylinderSize {
			get { return cylinderSize; }
			set { cylinderSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public decimal Counter {
			get { return counter; }
			set { counter = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rptTempProductionMachineWiser_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rptTempProductionMachineWiser_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@jobChange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rejection", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lenght", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uomLength_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cylinderSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@counter", SqlDbType.Decimal,9);
 
			scom.Parameters["@reportDate"].Value = reportDate;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionName"].Value = sectionName;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@machineName"].Value = machineName;
			scom.Parameters["@jobChange"].Value = jobChange;
			scom.Parameters["@rejection"].Value = rejection;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@lenght"].Value = lenght;
			scom.Parameters["@uomLength_ID"].Value = uomLength_ID;
			scom.Parameters["@cylinderSize"].Value = cylinderSize;
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rptTempProductionMachineWiser_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rptTempProductionMachineWiser_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@jobChange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rejection", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lenght", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uomLength_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cylinderSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@counter", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@reportDate"].Value = reportDate;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionName"].Value = sectionName;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@machineName"].Value = machineName;
			scom.Parameters["@jobChange"].Value = jobChange;
			scom.Parameters["@rejection"].Value = rejection;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@lenght"].Value = lenght;
			scom.Parameters["@uomLength_ID"].Value = uomLength_ID;
			scom.Parameters["@cylinderSize"].Value = cylinderSize;
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_rptTempProductionMachineWiser_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rptTempProductionMachineWiser_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_rptTempProductionMachineWiser_Detail table.
		/// </summary>
		public static tbl_rptTempProductionMachineWiser_Detail Select(int line_No_Incoming){

			tbl_rptTempProductionMachineWiser_Detail tbl_rptTempProductionMachineWiser_Detailins = new tbl_rptTempProductionMachineWiser_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rptTempProductionMachineWiser_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rptTempProductionMachineWiser_Detailins = Maketbl_rptTempProductionMachineWiser_Detail(dataReader);
				} else {
					tbl_rptTempProductionMachineWiser_Detailins = null;
				}
			}
			scon.Close();
			return tbl_rptTempProductionMachineWiser_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rptTempProductionMachineWiser_Detail table.
		/// </summary>
		public static List<tbl_rptTempProductionMachineWiser_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rptTempProductionMachineWiser_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rptTempProductionMachineWiser_Detail> tbl_rptTempProductionMachineWiser_DetailList = new List<tbl_rptTempProductionMachineWiser_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rptTempProductionMachineWiser_Detail tbl_rptTempProductionMachineWiser_Detail = Maketbl_rptTempProductionMachineWiser_Detail(dataReader);
					tbl_rptTempProductionMachineWiser_DetailList.Add(tbl_rptTempProductionMachineWiser_Detail);
				}
			}
			scon.Close();
			return tbl_rptTempProductionMachineWiser_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rptTempProductionMachineWiser_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rptTempProductionMachineWiser_Detail Maketbl_rptTempProductionMachineWiser_Detail(SqlDataReader dataReader) {
			tbl_rptTempProductionMachineWiser_Detail tbl_rptTempProductionMachineWiser_Detail = new tbl_rptTempProductionMachineWiser_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rptTempProductionMachineWiser_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rptTempProductionMachineWiser_Detail.ReportDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rptTempProductionMachineWiser_Detail.Section_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_rptTempProductionMachineWiser_Detail.SectionName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_rptTempProductionMachineWiser_Detail.Machine_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_rptTempProductionMachineWiser_Detail.MachineName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_rptTempProductionMachineWiser_Detail.JobChange = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_rptTempProductionMachineWiser_Detail.Rejection = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_rptTempProductionMachineWiser_Detail.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_rptTempProductionMachineWiser_Detail.Weight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_rptTempProductionMachineWiser_Detail.Lenght = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_rptTempProductionMachineWiser_Detail.UomLength_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_rptTempProductionMachineWiser_Detail.CylinderSize = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_rptTempProductionMachineWiser_Detail.Counter = dataReader.GetDecimal(13);
			}

			return tbl_rptTempProductionMachineWiser_Detail;
		}
		/// <summary>
		/// This makes tbl_rptTempProductionMachineWiser_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rptTempProductionMachineWiser_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rptTempProductionMachineWiser_Detail  tbl_rptTempProductionMachineWiser_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_reportDate = new DataColumn("reportDate" , typeof(DateTime));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_sectionName = new DataColumn("sectionName" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_machineName = new DataColumn("machineName" , typeof(string));
			DataColumn col_jobChange = new DataColumn("jobChange" , typeof(decimal));
			DataColumn col_rejection = new DataColumn("rejection" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_lenght = new DataColumn("lenght" , typeof(decimal));
			DataColumn col_uomLength_ID = new DataColumn("uomLength_ID" , typeof(string));
			DataColumn col_cylinderSize = new DataColumn("cylinderSize" , typeof(decimal));
			DataColumn col_counter = new DataColumn("counter" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_reportDate,col_section_ID,col_sectionName,col_machine_ID,col_machineName,col_jobChange,col_rejection,col_qty,col_weight,col_lenght,col_uomLength_ID,col_cylinderSize,col_counter,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rptTempProductionMachineWiser_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rptTempProductionMachineWiser_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rptTempProductionMachineWiser_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["reportDate"] = user.reportDate;
			drow["section_ID"] = user.section_ID;
			drow["sectionName"] = user.sectionName;
			drow["machine_ID"] = user.machine_ID;
			drow["machineName"] = user.machineName;
			drow["jobChange"] = user.jobChange;
			drow["rejection"] = user.rejection;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["lenght"] = user.lenght;
			drow["uomLength_ID"] = user.uomLength_ID;
			drow["cylinderSize"] = user.cylinderSize;
			drow["counter"] = user.counter;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
