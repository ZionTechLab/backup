using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaMasSectionActivity {
		#region Fields
		private string activity_ID;
		private string description;
		private string section_ID;
		private decimal shiftMinutes_Day;
		private decimal shiftMinutes_Night;
		private string remarks;
		private decimal labourRatePerHour_Day;
		private decimal labourRatePerHour_Night;
		private decimal oHRatePerHour;
		private decimal otherCostRatePerHour;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaMasSectionActivity class.
		/// </summary>
		public tbl_prod_pharmaMasSectionActivity() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaMasSectionActivity class.
		/// </summary>
		public tbl_prod_pharmaMasSectionActivity(string activity_ID, string description, string section_ID, decimal shiftMinutes_Day, decimal shiftMinutes_Night, string remarks, decimal labourRatePerHour_Day, decimal labourRatePerHour_Night, decimal oHRatePerHour, decimal otherCostRatePerHour) {
			this.activity_ID = activity_ID;
			this.description = description;
			this.section_ID = section_ID;
			this.shiftMinutes_Day = shiftMinutes_Day;
			this.shiftMinutes_Night = shiftMinutes_Night;
			this.remarks = remarks;
			this.labourRatePerHour_Day = labourRatePerHour_Day;
			this.labourRatePerHour_Night = labourRatePerHour_Night;
			this.oHRatePerHour = oHRatePerHour;
			this.otherCostRatePerHour = otherCostRatePerHour;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Activity_ID value.
		/// </summary>
		public string Activity_ID {
			get { return activity_ID; }
			set { activity_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Day value.
		/// </summary>
		public decimal ShiftMinutes_Day {
			get { return shiftMinutes_Day; }
			set { shiftMinutes_Day = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Night value.
		/// </summary>
		public decimal ShiftMinutes_Night {
			get { return shiftMinutes_Night; }
			set { shiftMinutes_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the LabourRatePerHour_Day value.
		/// </summary>
		public decimal LabourRatePerHour_Day {
			get { return labourRatePerHour_Day; }
			set { labourRatePerHour_Day = value; }
		}
		
		/// <summary>
		/// Gets or sets the LabourRatePerHour_Night value.
		/// </summary>
		public decimal LabourRatePerHour_Night {
			get { return labourRatePerHour_Night; }
			set { labourRatePerHour_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the OHRatePerHour value.
		/// </summary>
		public decimal OHRatePerHour {
			get { return oHRatePerHour; }
			set { oHRatePerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherCostRatePerHour value.
		/// </summary>
		public decimal OtherCostRatePerHour {
			get { return otherCostRatePerHour; }
			set { otherCostRatePerHour = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaMasSectionActivity table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasSectionActivityInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,50);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shiftMinutes_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftMinutes_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@labourRatePerHour_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourRatePerHour_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@OHRatePerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@OtherCostRatePerHour", SqlDbType.Decimal,9);
 
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@shiftMinutes_Day"].Value = shiftMinutes_Day;
			scom.Parameters["@shiftMinutes_Night"].Value = shiftMinutes_Night;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@labourRatePerHour_Day"].Value = labourRatePerHour_Day;
			scom.Parameters["@labourRatePerHour_Night"].Value = labourRatePerHour_Night;
			scom.Parameters["@OHRatePerHour"].Value = oHRatePerHour;
			scom.Parameters["@OtherCostRatePerHour"].Value = otherCostRatePerHour;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaMasSectionActivity table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasSectionActivityUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,50);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shiftMinutes_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftMinutes_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@labourRatePerHour_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourRatePerHour_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@OHRatePerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@OtherCostRatePerHour", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@shiftMinutes_Day"].Value = shiftMinutes_Day;
			scom.Parameters["@shiftMinutes_Night"].Value = shiftMinutes_Night;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@labourRatePerHour_Day"].Value = labourRatePerHour_Day;
			scom.Parameters["@labourRatePerHour_Night"].Value = labourRatePerHour_Night;
			scom.Parameters["@OHRatePerHour"].Value = oHRatePerHour;
			scom.Parameters["@OtherCostRatePerHour"].Value = otherCostRatePerHour;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaMasSectionActivity table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasSectionActivityDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters["@activity_ID"].Value = activity_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaMasSectionActivity table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasSectionActivityDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaMasSectionActivity table.
		/// </summary>
		public static tbl_prod_pharmaMasSectionActivity Select(string activity_ID_Incoming){

			tbl_prod_pharmaMasSectionActivity tbl_prod_pharmaMasSectionActivityins = new tbl_prod_pharmaMasSectionActivity();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasSectionActivitySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters["@activity_ID"].Value = activity_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaMasSectionActivityins = Maketbl_prod_pharmaMasSectionActivity(dataReader);
				} else {
					tbl_prod_pharmaMasSectionActivityins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaMasSectionActivityins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaMasSectionActivity table.
		/// </summary>
		public static List<tbl_prod_pharmaMasSectionActivity> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasSectionActivitySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaMasSectionActivity> tbl_prod_pharmaMasSectionActivityList = new List<tbl_prod_pharmaMasSectionActivity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaMasSectionActivity tbl_prod_pharmaMasSectionActivity = Maketbl_prod_pharmaMasSectionActivity(dataReader);
					tbl_prod_pharmaMasSectionActivityList.Add(tbl_prod_pharmaMasSectionActivity);
				}
			}
			scon.Close();
			return tbl_prod_pharmaMasSectionActivityList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaMasSectionActivity table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaMasSectionActivity> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasSectionActivitySelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_prod_pharmaMasSectionActivity> tbl_prod_pharmaMasSectionActivityList = new List<tbl_prod_pharmaMasSectionActivity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaMasSectionActivity tbl_prod_pharmaMasSectionActivity = Maketbl_prod_pharmaMasSectionActivity(dataReader);
					tbl_prod_pharmaMasSectionActivityList.Add(tbl_prod_pharmaMasSectionActivity);
				}
			}
			scon.Close();
			return tbl_prod_pharmaMasSectionActivityList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaMasSectionActivity class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaMasSectionActivity Maketbl_prod_pharmaMasSectionActivity(SqlDataReader dataReader) {
			tbl_prod_pharmaMasSectionActivity tbl_prod_pharmaMasSectionActivity = new tbl_prod_pharmaMasSectionActivity();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaMasSectionActivity.Activity_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaMasSectionActivity.Description = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaMasSectionActivity.Section_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaMasSectionActivity.ShiftMinutes_Day = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaMasSectionActivity.ShiftMinutes_Night = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaMasSectionActivity.Remarks = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaMasSectionActivity.LabourRatePerHour_Day = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaMasSectionActivity.LabourRatePerHour_Night = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaMasSectionActivity.OHRatePerHour = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaMasSectionActivity.OtherCostRatePerHour = dataReader.GetDecimal(9);
			}

			return tbl_prod_pharmaMasSectionActivity;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaMasSectionActivity datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaMasSectionActivity object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaMasSectionActivity  tbl_prod_pharmaMasSectionActivity   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_activity_ID = new DataColumn("activity_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_shiftMinutes_Day = new DataColumn("shiftMinutes_Day" , typeof(decimal));
			DataColumn col_shiftMinutes_Night = new DataColumn("shiftMinutes_Night" , typeof(decimal));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_labourRatePerHour_Day = new DataColumn("labourRatePerHour_Day" , typeof(decimal));
			DataColumn col_labourRatePerHour_Night = new DataColumn("labourRatePerHour_Night" , typeof(decimal));
			DataColumn col_OHRatePerHour = new DataColumn("OHRatePerHour" , typeof(decimal));
			DataColumn col_OtherCostRatePerHour = new DataColumn("OtherCostRatePerHour" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_activity_ID,col_description,col_section_ID,col_shiftMinutes_Day,col_shiftMinutes_Night,col_remarks,col_labourRatePerHour_Day,col_labourRatePerHour_Night,col_OHRatePerHour,col_OtherCostRatePerHour,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaMasSectionActivity datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaMasSectionActivity object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaMasSectionActivity user) {
		DataRow drow = dt.NewRow();
		
			drow["activity_ID"] = user.activity_ID;
			drow["description"] = user.description;
			drow["section_ID"] = user.section_ID;
			drow["shiftMinutes_Day"] = user.shiftMinutes_Day;
			drow["shiftMinutes_Night"] = user.shiftMinutes_Night;
			drow["remarks"] = user.remarks;
			drow["labourRatePerHour_Day"] = user.labourRatePerHour_Day;
			drow["labourRatePerHour_Night"] = user.labourRatePerHour_Night;
			drow["OHRatePerHour"] = user.OHRatePerHour;
			drow["OtherCostRatePerHour"] = user.OtherCostRatePerHour;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
