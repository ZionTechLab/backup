using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rbInsReportFormula {
		#region Fields
		private int line_No;
		private string reportItem_level1_ID;
		private string level1Calulation_ID;
		private string arithmeticOperators;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportFormula class.
		/// </summary>
		public tbl_rbInsReportFormula() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportFormula class.
		/// </summary>
		public tbl_rbInsReportFormula(string reportItem_level1_ID, string level1Calulation_ID, string arithmeticOperators) {
			this.reportItem_level1_ID = reportItem_level1_ID;
			this.level1Calulation_ID = level1Calulation_ID;
			this.arithmeticOperators = arithmeticOperators;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportFormula class.
		/// </summary>
		public tbl_rbInsReportFormula(int line_No, string reportItem_level1_ID, string level1Calulation_ID, string arithmeticOperators) {
			this.line_No = line_No;
			this.reportItem_level1_ID = reportItem_level1_ID;
			this.level1Calulation_ID = level1Calulation_ID;
			this.arithmeticOperators = arithmeticOperators;
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
		/// Gets or sets the ReportItem_level1_ID value.
		/// </summary>
		public string ReportItem_level1_ID {
			get { return reportItem_level1_ID; }
			set { reportItem_level1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Level1Calulation_ID value.
		/// </summary>
		public string Level1Calulation_ID {
			get { return level1Calulation_ID; }
			set { level1Calulation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ArithmeticOperators value.
		/// </summary>
		public string ArithmeticOperators {
			get { return arithmeticOperators; }
			set { arithmeticOperators = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rbInsReportFormula table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportFormulaInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@level1Calulation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@arithmeticOperators", SqlDbType.VarChar,5);
 
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
			scom.Parameters["@level1Calulation_ID"].Value = level1Calulation_ID;
			scom.Parameters["@arithmeticOperators"].Value = arithmeticOperators;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rbInsReportFormula table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportFormulaUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@level1Calulation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@arithmeticOperators", SqlDbType.VarChar,5);
 
 
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
			scom.Parameters["@level1Calulation_ID"].Value = level1Calulation_ID;
			scom.Parameters["@arithmeticOperators"].Value = arithmeticOperators;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_rbInsReportFormula table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportFormulaDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_rbInsReportFormula table.
		/// </summary>
		public static tbl_rbInsReportFormula Select(int line_No_Incoming){

			tbl_rbInsReportFormula tbl_rbInsReportFormulains = new tbl_rbInsReportFormula();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportFormulaSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rbInsReportFormulains = Maketbl_rbInsReportFormula(dataReader);
				} else {
					tbl_rbInsReportFormulains = null;
				}
			}
			scon.Close();
			return tbl_rbInsReportFormulains;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsReportFormula table.
		/// </summary>
		public static List<tbl_rbInsReportFormula> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportFormulaSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rbInsReportFormula> tbl_rbInsReportFormulaList = new List<tbl_rbInsReportFormula>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbInsReportFormula tbl_rbInsReportFormula = Maketbl_rbInsReportFormula(dataReader);
					tbl_rbInsReportFormulaList.Add(tbl_rbInsReportFormula);
				}
			}
			scon.Close();
			return tbl_rbInsReportFormulaList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rbInsReportFormula class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rbInsReportFormula Maketbl_rbInsReportFormula(SqlDataReader dataReader) {
			tbl_rbInsReportFormula tbl_rbInsReportFormula = new tbl_rbInsReportFormula();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rbInsReportFormula.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rbInsReportFormula.ReportItem_level1_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rbInsReportFormula.Level1Calulation_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_rbInsReportFormula.ArithmeticOperators = dataReader.GetString(3);
			}

			return tbl_rbInsReportFormula;
		}
		/// <summary>
		/// This makes tbl_rbInsReportFormula datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rbInsReportFormula object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rbInsReportFormula  tbl_rbInsReportFormula   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_reportItem_level1_ID = new DataColumn("reportItem_level1_ID" , typeof(string));
			DataColumn col_level1Calulation_ID = new DataColumn("level1Calulation_ID" , typeof(string));
			DataColumn col_arithmeticOperators = new DataColumn("arithmeticOperators" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_reportItem_level1_ID,col_level1Calulation_ID,col_arithmeticOperators,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rbInsReportFormula datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rbInsReportFormula object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rbInsReportFormula user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["reportItem_level1_ID"] = user.reportItem_level1_ID;
			drow["level1Calulation_ID"] = user.level1Calulation_ID;
			drow["arithmeticOperators"] = user.arithmeticOperators;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
