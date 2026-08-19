using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsChequeReIssue_Detail {
		#region Fields
		private int line_No;
		private string reIssue_ID;
		private string chequeRegister_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeReIssue_Detail class.
		/// </summary>
		public tbl_bpsChequeReIssue_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeReIssue_Detail class.
		/// </summary>
		public tbl_bpsChequeReIssue_Detail(int line_No, string reIssue_ID, string chequeRegister_ID) {
			this.line_No = line_No;
			this.reIssue_ID = reIssue_ID;
			this.chequeRegister_ID = chequeRegister_ID;
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
		/// Gets or sets the ReIssue_ID value.
		/// </summary>
		public string ReIssue_ID {
			get { return reIssue_ID; }
			set { reIssue_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsChequeReIssue_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReIssue_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@reIssue_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@reIssue_ID"].Value = reIssue_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsChequeReIssue_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReIssue_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@reIssue_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@reIssue_ID"].Value = reIssue_ID;
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReIssue_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByReIssue_ID(string reIssue_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReIssue_DetailDeleteAllByReIssue_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;

 
			scom.Parameters.Add("@reIssue_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reIssue_ID"].Value = reIssue_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReIssue_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReIssue_DetailDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsChequeReIssue_Detail table.
		/// </summary>
		public static tbl_bpsChequeReIssue_Detail Select(int line_No_Incoming, string reIssue_ID_Incoming, string chequeRegister_ID_Incoming){

			tbl_bpsChequeReIssue_Detail tbl_bpsChequeReIssue_Detailins = new tbl_bpsChequeReIssue_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReIssue_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@reIssue_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@reIssue_ID"].Value = reIssue_ID_Incoming;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsChequeReIssue_Detailins = Maketbl_bpsChequeReIssue_Detail(dataReader);
				} else {
					tbl_bpsChequeReIssue_Detailins = null;
				}
			}
			scon.Close();
			return tbl_bpsChequeReIssue_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReIssue_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeReIssue_Detail> SelectAllByReIssue_ID(string reIssue_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReIssue_DetailSelectAllByReIssue_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reIssue_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reIssue_ID"].Value = reIssue_ID;
				List<tbl_bpsChequeReIssue_Detail> tbl_bpsChequeReIssue_DetailList = new List<tbl_bpsChequeReIssue_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReIssue_Detail tbl_bpsChequeReIssue_Detail = Maketbl_bpsChequeReIssue_Detail(dataReader);
					tbl_bpsChequeReIssue_DetailList.Add(tbl_bpsChequeReIssue_Detail);
				}
			}
			scon.Close();
			return tbl_bpsChequeReIssue_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReIssue_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeReIssue_Detail> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReIssue_DetailSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_bpsChequeReIssue_Detail> tbl_bpsChequeReIssue_DetailList = new List<tbl_bpsChequeReIssue_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReIssue_Detail tbl_bpsChequeReIssue_Detail = Maketbl_bpsChequeReIssue_Detail(dataReader);
					tbl_bpsChequeReIssue_DetailList.Add(tbl_bpsChequeReIssue_Detail);
				}
			}
			scon.Close();
			return tbl_bpsChequeReIssue_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsChequeReIssue_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsChequeReIssue_Detail Maketbl_bpsChequeReIssue_Detail(SqlDataReader dataReader) {
			tbl_bpsChequeReIssue_Detail tbl_bpsChequeReIssue_Detail = new tbl_bpsChequeReIssue_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsChequeReIssue_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsChequeReIssue_Detail.ReIssue_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsChequeReIssue_Detail.ChequeRegister_ID = dataReader.GetString(2);
			}

			return tbl_bpsChequeReIssue_Detail;
		}
		/// <summary>
		/// This fills tbl_bpsChequeReIssue_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsChequeReIssue_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsChequeReIssue_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["reIssue_ID"] = user.reIssue_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
