using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsChequeReturnToSender_Detail {
		#region Fields
		private int line_No;
		private string returnedToSender_ID;
		private string chequeRegister_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeReturnToSender_Detail class.
		/// </summary>
		public tbl_bpsChequeReturnToSender_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeReturnToSender_Detail class.
		/// </summary>
		public tbl_bpsChequeReturnToSender_Detail(int line_No, string returnedToSender_ID, string chequeRegister_ID) {
			this.line_No = line_No;
			this.returnedToSender_ID = returnedToSender_ID;
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
		/// Gets or sets the ReturnedToSender_ID value.
		/// </summary>
		public string ReturnedToSender_ID {
			get { return returnedToSender_ID; }
			set { returnedToSender_ID = value; }
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
		/// Saves a record to the tbl_bpsChequeReturnToSender_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsChequeReturnToSender_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsChequeReturnToSender_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID;
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReturnToSender_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByReturnedToSender_ID(string returnedToSender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailDeleteAllByReturnedToSender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReturnToSender_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsChequeReturnToSender_Detail table.
		/// </summary>
		public static tbl_bpsChequeReturnToSender_Detail Select(string returnedToSender_ID_Incoming, string chequeRegister_ID_Incoming){

			tbl_bpsChequeReturnToSender_Detail tbl_bpsChequeReturnToSender_Detailins = new tbl_bpsChequeReturnToSender_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID_Incoming;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsChequeReturnToSender_Detailins = Maketbl_bpsChequeReturnToSender_Detail(dataReader);
				} else {
					tbl_bpsChequeReturnToSender_Detailins = null;
				}
			}
			scon.Close();
			return tbl_bpsChequeReturnToSender_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReturnToSender_Detail table.
		/// </summary>
		public static List<tbl_bpsChequeReturnToSender_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsChequeReturnToSender_Detail> tbl_bpsChequeReturnToSender_DetailList = new List<tbl_bpsChequeReturnToSender_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReturnToSender_Detail tbl_bpsChequeReturnToSender_Detail = Maketbl_bpsChequeReturnToSender_Detail(dataReader);
					tbl_bpsChequeReturnToSender_DetailList.Add(tbl_bpsChequeReturnToSender_Detail);
				}
			}
			scon.Close();
			return tbl_bpsChequeReturnToSender_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReturnToSender_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeReturnToSender_Detail> SelectAllByReturnedToSender_ID(string returnedToSender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailSelectAllByReturnedToSender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID;
				List<tbl_bpsChequeReturnToSender_Detail> tbl_bpsChequeReturnToSender_DetailList = new List<tbl_bpsChequeReturnToSender_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReturnToSender_Detail tbl_bpsChequeReturnToSender_Detail = Maketbl_bpsChequeReturnToSender_Detail(dataReader);
					tbl_bpsChequeReturnToSender_DetailList.Add(tbl_bpsChequeReturnToSender_Detail);
				}
			}
			scon.Close();
			return tbl_bpsChequeReturnToSender_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReturnToSender_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeReturnToSender_Detail> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSender_DetailSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_bpsChequeReturnToSender_Detail> tbl_bpsChequeReturnToSender_DetailList = new List<tbl_bpsChequeReturnToSender_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReturnToSender_Detail tbl_bpsChequeReturnToSender_Detail = Maketbl_bpsChequeReturnToSender_Detail(dataReader);
					tbl_bpsChequeReturnToSender_DetailList.Add(tbl_bpsChequeReturnToSender_Detail);
				}
			}
			scon.Close();
			return tbl_bpsChequeReturnToSender_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsChequeReturnToSender_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsChequeReturnToSender_Detail Maketbl_bpsChequeReturnToSender_Detail(SqlDataReader dataReader) {
			tbl_bpsChequeReturnToSender_Detail tbl_bpsChequeReturnToSender_Detail = new tbl_bpsChequeReturnToSender_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsChequeReturnToSender_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsChequeReturnToSender_Detail.ReturnedToSender_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsChequeReturnToSender_Detail.ChequeRegister_ID = dataReader.GetString(2);
			}

			return tbl_bpsChequeReturnToSender_Detail;
		}
		/// <summary>
		/// This makes tbl_bpsChequeReturnToSender_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsChequeReturnToSender_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsChequeReturnToSender_Detail  tbl_bpsChequeReturnToSender_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_returnedToSender_ID = new DataColumn("returnedToSender_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_returnedToSender_ID,col_chequeRegister_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsChequeReturnToSender_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsChequeReturnToSender_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsChequeReturnToSender_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["returnedToSender_ID"] = user.returnedToSender_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
