using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxJobCard_Labour {
		#region Fields
		private int line_No;
		private string prodJob_ID;
		private string prodSection_ID;
		private string prodActivity_ID;
		private decimal shifts_Day;
		private decimal shiftMinutes_Day;
		private decimal labours_Day;
		private decimal labourRatePerHour_Day;
		private decimal shifts_Night;
		private decimal shiftMinutes_Night;
		private decimal labours_Night;
		private decimal labourRatePerHour_Night;
		private decimal ohRatePerHour;
		private decimal otherCostRatePerHour;
		private decimal prodMinutes;
		private decimal costTotal;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_Labour class.
		/// </summary>
		public tbl_prodTxJobCard_Labour() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_Labour class.
		/// </summary>
		public tbl_prodTxJobCard_Labour(int line_No, string prodJob_ID, string prodSection_ID, string prodActivity_ID, decimal shifts_Day, decimal shiftMinutes_Day, decimal labours_Day, decimal labourRatePerHour_Day, decimal shifts_Night, decimal shiftMinutes_Night, decimal labours_Night, decimal labourRatePerHour_Night, decimal ohRatePerHour, decimal otherCostRatePerHour, decimal prodMinutes, decimal costTotal) {
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.prodSection_ID = prodSection_ID;
			this.prodActivity_ID = prodActivity_ID;
			this.shifts_Day = shifts_Day;
			this.shiftMinutes_Day = shiftMinutes_Day;
			this.labours_Day = labours_Day;
			this.labourRatePerHour_Day = labourRatePerHour_Day;
			this.shifts_Night = shifts_Night;
			this.shiftMinutes_Night = shiftMinutes_Night;
			this.labours_Night = labours_Night;
			this.labourRatePerHour_Night = labourRatePerHour_Night;
			this.ohRatePerHour = ohRatePerHour;
			this.otherCostRatePerHour = otherCostRatePerHour;
			this.prodMinutes = prodMinutes;
			this.costTotal = costTotal;
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
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdSection_ID value.
		/// </summary>
		public string ProdSection_ID {
			get { return prodSection_ID; }
			set { prodSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdActivity_ID value.
		/// </summary>
		public string ProdActivity_ID {
			get { return prodActivity_ID; }
			set { prodActivity_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shifts_Day value.
		/// </summary>
		public decimal Shifts_Day {
			get { return shifts_Day; }
			set { shifts_Day = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Day value.
		/// </summary>
		public decimal ShiftMinutes_Day {
			get { return shiftMinutes_Day; }
			set { shiftMinutes_Day = value; }
		}
		
		/// <summary>
		/// Gets or sets the Labours_Day value.
		/// </summary>
		public decimal Labours_Day {
			get { return labours_Day; }
			set { labours_Day = value; }
		}
		
		/// <summary>
		/// Gets or sets the LabourRatePerHour_Day value.
		/// </summary>
		public decimal LabourRatePerHour_Day {
			get { return labourRatePerHour_Day; }
			set { labourRatePerHour_Day = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shifts_Night value.
		/// </summary>
		public decimal Shifts_Night {
			get { return shifts_Night; }
			set { shifts_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Night value.
		/// </summary>
		public decimal ShiftMinutes_Night {
			get { return shiftMinutes_Night; }
			set { shiftMinutes_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the Labours_Night value.
		/// </summary>
		public decimal Labours_Night {
			get { return labours_Night; }
			set { labours_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the LabourRatePerHour_Night value.
		/// </summary>
		public decimal LabourRatePerHour_Night {
			get { return labourRatePerHour_Night; }
			set { labourRatePerHour_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the OhRatePerHour value.
		/// </summary>
		public decimal OhRatePerHour {
			get { return ohRatePerHour; }
			set { ohRatePerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherCostRatePerHour value.
		/// </summary>
		public decimal OtherCostRatePerHour {
			get { return otherCostRatePerHour; }
			set { otherCostRatePerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdMinutes value.
		/// </summary>
		public decimal ProdMinutes {
			get { return prodMinutes; }
			set { prodMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostTotal value.
		/// </summary>
		public decimal CostTotal {
			get { return costTotal; }
			set { costTotal = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxJobCard_Labour table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodActivity_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shifts_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftMinutes_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labours_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourRatePerHour_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shifts_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftMinutes_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labours_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourRatePerHour_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ohRatePerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherCostRatePerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@prodMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costTotal", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodSection_ID"].Value = prodSection_ID;
			scom.Parameters["@prodActivity_ID"].Value = prodActivity_ID;
			scom.Parameters["@shifts_Day"].Value = shifts_Day;
			scom.Parameters["@shiftMinutes_Day"].Value = shiftMinutes_Day;
			scom.Parameters["@labours_Day"].Value = labours_Day;
			scom.Parameters["@labourRatePerHour_Day"].Value = labourRatePerHour_Day;
			scom.Parameters["@shifts_Night"].Value = shifts_Night;
			scom.Parameters["@shiftMinutes_Night"].Value = shiftMinutes_Night;
			scom.Parameters["@labours_Night"].Value = labours_Night;
			scom.Parameters["@labourRatePerHour_Night"].Value = labourRatePerHour_Night;
			scom.Parameters["@ohRatePerHour"].Value = ohRatePerHour;
			scom.Parameters["@otherCostRatePerHour"].Value = otherCostRatePerHour;
			scom.Parameters["@prodMinutes"].Value = prodMinutes;
			scom.Parameters["@costTotal"].Value = costTotal;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxJobCard_Labour table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodActivity_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shifts_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftMinutes_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labours_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourRatePerHour_Day", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shifts_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftMinutes_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labours_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourRatePerHour_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ohRatePerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherCostRatePerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@prodMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costTotal", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodSection_ID"].Value = prodSection_ID;
			scom.Parameters["@prodActivity_ID"].Value = prodActivity_ID;
			scom.Parameters["@shifts_Day"].Value = shifts_Day;
			scom.Parameters["@shiftMinutes_Day"].Value = shiftMinutes_Day;
			scom.Parameters["@labours_Day"].Value = labours_Day;
			scom.Parameters["@labourRatePerHour_Day"].Value = labourRatePerHour_Day;
			scom.Parameters["@shifts_Night"].Value = shifts_Night;
			scom.Parameters["@shiftMinutes_Night"].Value = shiftMinutes_Night;
			scom.Parameters["@labours_Night"].Value = labours_Night;
			scom.Parameters["@labourRatePerHour_Night"].Value = labourRatePerHour_Night;
			scom.Parameters["@ohRatePerHour"].Value = ohRatePerHour;
			scom.Parameters["@otherCostRatePerHour"].Value = otherCostRatePerHour;
			scom.Parameters["@prodMinutes"].Value = prodMinutes;
			scom.Parameters["@costTotal"].Value = costTotal;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxJobCard_Labour table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Labour table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Labour table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdSection_ID(string prodSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourDeleteAllByProdSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodSection_ID"].Value = prodSection_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Labour table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdActivity_ID(string prodActivity_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourDeleteAllByProdActivity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodActivity_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodActivity_ID"].Value = prodActivity_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxJobCard_Labour table.
		/// </summary>
		public static tbl_prodTxJobCard_Labour Select(int line_No_Incoming, string prodJob_ID_Incoming){

			tbl_prodTxJobCard_Labour tbl_prodTxJobCard_Labourins = new tbl_prodTxJobCard_Labour();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxJobCard_Labourins = Maketbl_prodTxJobCard_Labour(dataReader);
				} else {
					tbl_prodTxJobCard_Labourins = null;
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_Labourins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Labour table.
		/// </summary>
		public static List<tbl_prodTxJobCard_Labour> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxJobCard_Labour> tbl_prodTxJobCard_LabourList = new List<tbl_prodTxJobCard_Labour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_Labour tbl_prodTxJobCard_Labour = Maketbl_prodTxJobCard_Labour(dataReader);
					tbl_prodTxJobCard_LabourList.Add(tbl_prodTxJobCard_Labour);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_LabourList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Labour table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_Labour> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxJobCard_Labour> tbl_prodTxJobCard_LabourList = new List<tbl_prodTxJobCard_Labour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_Labour tbl_prodTxJobCard_Labour = Maketbl_prodTxJobCard_Labour(dataReader);
					tbl_prodTxJobCard_LabourList.Add(tbl_prodTxJobCard_Labour);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_LabourList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Labour table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_Labour> SelectAllByProdSection_ID(string prodSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourSelectAllByProdSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodSection_ID"].Value = prodSection_ID;
				List<tbl_prodTxJobCard_Labour> tbl_prodTxJobCard_LabourList = new List<tbl_prodTxJobCard_Labour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_Labour tbl_prodTxJobCard_Labour = Maketbl_prodTxJobCard_Labour(dataReader);
					tbl_prodTxJobCard_LabourList.Add(tbl_prodTxJobCard_Labour);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_LabourList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_Labour table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_Labour> SelectAllByProdActivity_ID(string prodActivity_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_LabourSelectAllByProdActivity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodActivity_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodActivity_ID"].Value = prodActivity_ID;
				List<tbl_prodTxJobCard_Labour> tbl_prodTxJobCard_LabourList = new List<tbl_prodTxJobCard_Labour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_Labour tbl_prodTxJobCard_Labour = Maketbl_prodTxJobCard_Labour(dataReader);
					tbl_prodTxJobCard_LabourList.Add(tbl_prodTxJobCard_Labour);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_LabourList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxJobCard_Labour class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxJobCard_Labour Maketbl_prodTxJobCard_Labour(SqlDataReader dataReader) {
			tbl_prodTxJobCard_Labour tbl_prodTxJobCard_Labour = new tbl_prodTxJobCard_Labour();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxJobCard_Labour.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxJobCard_Labour.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxJobCard_Labour.ProdSection_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxJobCard_Labour.ProdActivity_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxJobCard_Labour.Shifts_Day = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxJobCard_Labour.ShiftMinutes_Day = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxJobCard_Labour.Labours_Day = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxJobCard_Labour.LabourRatePerHour_Day = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxJobCard_Labour.Shifts_Night = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxJobCard_Labour.ShiftMinutes_Night = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxJobCard_Labour.Labours_Night = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxJobCard_Labour.LabourRatePerHour_Night = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxJobCard_Labour.OhRatePerHour = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxJobCard_Labour.OtherCostRatePerHour = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxJobCard_Labour.ProdMinutes = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxJobCard_Labour.CostTotal = dataReader.GetDecimal(15);
			}

			return tbl_prodTxJobCard_Labour;
		}
		/// <summary>
		/// This makes tbl_prodTxJobCard_Labour datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_Labour object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxJobCard_Labour  tbl_prodTxJobCard_Labour   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodSection_ID = new DataColumn("prodSection_ID" , typeof(string));
			DataColumn col_prodActivity_ID = new DataColumn("prodActivity_ID" , typeof(string));
			DataColumn col_shifts_Day = new DataColumn("shifts_Day" , typeof(decimal));
			DataColumn col_shiftMinutes_Day = new DataColumn("shiftMinutes_Day" , typeof(decimal));
			DataColumn col_labours_Day = new DataColumn("labours_Day" , typeof(decimal));
			DataColumn col_labourRatePerHour_Day = new DataColumn("labourRatePerHour_Day" , typeof(decimal));
			DataColumn col_shifts_Night = new DataColumn("shifts_Night" , typeof(decimal));
			DataColumn col_shiftMinutes_Night = new DataColumn("shiftMinutes_Night" , typeof(decimal));
			DataColumn col_labours_Night = new DataColumn("labours_Night" , typeof(decimal));
			DataColumn col_labourRatePerHour_Night = new DataColumn("labourRatePerHour_Night" , typeof(decimal));
			DataColumn col_ohRatePerHour = new DataColumn("ohRatePerHour" , typeof(decimal));
			DataColumn col_otherCostRatePerHour = new DataColumn("otherCostRatePerHour" , typeof(decimal));
			DataColumn col_prodMinutes = new DataColumn("prodMinutes" , typeof(decimal));
			DataColumn col_costTotal = new DataColumn("costTotal" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_prodJob_ID,col_prodSection_ID,col_prodActivity_ID,col_shifts_Day,col_shiftMinutes_Day,col_labours_Day,col_labourRatePerHour_Day,col_shifts_Night,col_shiftMinutes_Night,col_labours_Night,col_labourRatePerHour_Night,col_ohRatePerHour,col_otherCostRatePerHour,col_prodMinutes,col_costTotal,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxJobCard_Labour datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_Labour object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxJobCard_Labour user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodSection_ID"] = user.prodSection_ID;
			drow["prodActivity_ID"] = user.prodActivity_ID;
			drow["shifts_Day"] = user.shifts_Day;
			drow["shiftMinutes_Day"] = user.shiftMinutes_Day;
			drow["labours_Day"] = user.labours_Day;
			drow["labourRatePerHour_Day"] = user.labourRatePerHour_Day;
			drow["shifts_Night"] = user.shifts_Night;
			drow["shiftMinutes_Night"] = user.shiftMinutes_Night;
			drow["labours_Night"] = user.labours_Night;
			drow["labourRatePerHour_Night"] = user.labourRatePerHour_Night;
			drow["ohRatePerHour"] = user.ohRatePerHour;
			drow["otherCostRatePerHour"] = user.otherCostRatePerHour;
			drow["prodMinutes"] = user.prodMinutes;
			drow["costTotal"] = user.costTotal;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
