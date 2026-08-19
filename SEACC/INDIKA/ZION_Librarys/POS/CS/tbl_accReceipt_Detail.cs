using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accReceipt_Detail {
		#region Fields
		private int line_No;
		private string receipt_ID;
		private string gl_ID;
		private decimal crAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accReceipt_Detail class.
		/// </summary>
		public tbl_accReceipt_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accReceipt_Detail class.
		/// </summary>
		public tbl_accReceipt_Detail(int line_No, string receipt_ID, string gl_ID, decimal crAmount) {
			this.line_No = line_No;
			this.receipt_ID = receipt_ID;
			this.gl_ID = gl_ID;
			this.crAmount = crAmount;
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
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CrAmount value.
		/// </summary>
		public decimal CrAmount {
			get { return crAmount; }
			set { crAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accReceipt_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceipt_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@crAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@crAmount"].Value = crAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accReceipt_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceipt_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@crAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@crAmount"].Value = crAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accReceipt_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceipt_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceipt_DetailDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accReceipt_Detail table.
		/// </summary>
		public static tbl_accReceipt_Detail Select(string receipt_ID_Incoming, string gl_ID_Incoming){

			tbl_accReceipt_Detail tbl_accReceipt_Detailins = new tbl_accReceipt_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceipt_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accReceipt_Detailins = Maketbl_accReceipt_Detail(dataReader);
				} else {
					tbl_accReceipt_Detailins = null;
				}
			}
			scon.Close();
			return tbl_accReceipt_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt_Detail table.
		/// </summary>
		public static List<tbl_accReceipt_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceipt_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accReceipt_Detail> tbl_accReceipt_DetailList = new List<tbl_accReceipt_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceipt_Detail tbl_accReceipt_Detail = Maketbl_accReceipt_Detail(dataReader);
					tbl_accReceipt_DetailList.Add(tbl_accReceipt_Detail);
				}
			}
			scon.Close();
			return tbl_accReceipt_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accReceipt_Detail> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceipt_DetailSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accReceipt_Detail> tbl_accReceipt_DetailList = new List<tbl_accReceipt_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceipt_Detail tbl_accReceipt_Detail = Maketbl_accReceipt_Detail(dataReader);
					tbl_accReceipt_DetailList.Add(tbl_accReceipt_Detail);
				}
			}
			scon.Close();
			return tbl_accReceipt_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accReceipt_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accReceipt_Detail Maketbl_accReceipt_Detail(SqlDataReader dataReader) {
			tbl_accReceipt_Detail tbl_accReceipt_Detail = new tbl_accReceipt_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accReceipt_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accReceipt_Detail.Receipt_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accReceipt_Detail.Gl_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accReceipt_Detail.CrAmount = dataReader.GetDecimal(3);
			}

			return tbl_accReceipt_Detail;
		}
		/// <summary>
		/// This makes tbl_accReceipt_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accReceipt_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accReceipt_Detail  tbl_accReceipt_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_crAmount = new DataColumn("crAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_receipt_ID,col_gl_ID,col_crAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accReceipt_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accReceipt_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accReceipt_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["receipt_ID"] = user.receipt_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["crAmount"] = user.crAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
