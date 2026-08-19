using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodMasSectionActivity {
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
		/// Initializes a new instance of the tbl_prodMasSectionActivity class.
		/// </summary>
		public tbl_prodMasSectionActivity() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodMasSectionActivity class.
		/// </summary>
		public tbl_prodMasSectionActivity(string activity_ID, string description, string section_ID, decimal shiftMinutes_Day, decimal shiftMinutes_Night, string remarks, decimal labourRatePerHour_Day, decimal labourRatePerHour_Night, decimal oHRatePerHour, decimal otherCostRatePerHour) {
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
		/// Saves a record to the tbl_prodMasSectionActivity table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasSectionActivityInsert", scon);
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
		/// Updates a record in the tbl_prodMasSectionActivity table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasSectionActivityUpdate", scon);
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
		/// Deletes a record from the tbl_prodMasSectionActivity table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasSectionActivityDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters["@activity_ID"].Value = activity_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodMasSectionActivity table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasSectionActivityDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodMasSectionActivity table.
		/// </summary>
		public static tbl_prodMasSectionActivity Select(string activity_ID_Incoming){

			tbl_prodMasSectionActivity tbl_prodMasSectionActivityins = new tbl_prodMasSectionActivity();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasSectionActivitySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters["@activity_ID"].Value = activity_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodMasSectionActivityins = Maketbl_prodMasSectionActivity(dataReader);
				} else {
					tbl_prodMasSectionActivityins = null;
				}
			}
			scon.Close();
			return tbl_prodMasSectionActivityins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodMasSectionActivity table.
		/// </summary>
		public static List<tbl_prodMasSectionActivity> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasSectionActivitySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodMasSectionActivity> tbl_prodMasSectionActivityList = new List<tbl_prodMasSectionActivity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodMasSectionActivity tbl_prodMasSectionActivity = Maketbl_prodMasSectionActivity(dataReader);
					tbl_prodMasSectionActivityList.Add(tbl_prodMasSectionActivity);
				}
			}
			scon.Close();
			return tbl_prodMasSectionActivityList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodMasSectionActivity table by a foreign key.
		/// </summary>
		public static List<tbl_prodMasSectionActivity> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasSectionActivitySelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_prodMasSectionActivity> tbl_prodMasSectionActivityList = new List<tbl_prodMasSectionActivity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodMasSectionActivity tbl_prodMasSectionActivity = Maketbl_prodMasSectionActivity(dataReader);
					tbl_prodMasSectionActivityList.Add(tbl_prodMasSectionActivity);
				}
			}
			scon.Close();
			return tbl_prodMasSectionActivityList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodMasSectionActivity class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodMasSectionActivity Maketbl_prodMasSectionActivity(SqlDataReader dataReader) {
			tbl_prodMasSectionActivity tbl_prodMasSectionActivity = new tbl_prodMasSectionActivity();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodMasSectionActivity.Activity_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodMasSectionActivity.Description = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodMasSectionActivity.Section_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodMasSectionActivity.ShiftMinutes_Day = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodMasSectionActivity.ShiftMinutes_Night = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodMasSectionActivity.Remarks = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodMasSectionActivity.LabourRatePerHour_Day = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodMasSectionActivity.LabourRatePerHour_Night = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodMasSectionActivity.OHRatePerHour = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodMasSectionActivity.OtherCostRatePerHour = dataReader.GetDecimal(9);
			}

			return tbl_prodMasSectionActivity;
		}
		/// <summary>
		/// This makes tbl_prodMasSectionActivity datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodMasSectionActivity object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodMasSectionActivity  tbl_prodMasSectionActivity   )
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
		/// This fills tbl_prodMasSectionActivity datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodMasSectionActivity object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodMasSectionActivity user) {
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
