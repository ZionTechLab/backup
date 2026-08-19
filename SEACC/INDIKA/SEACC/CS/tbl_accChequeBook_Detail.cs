using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accChequeBook_Detail {
		#region Fields
		private string chequeBook_ID;
		private string chequeNumber;
		private string voucherNo;
		private string narration;
		private bool isCancel;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accChequeBook_Detail class.
		/// </summary>
		public tbl_accChequeBook_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accChequeBook_Detail class.
		/// </summary>
		public tbl_accChequeBook_Detail(string chequeBook_ID, string chequeNumber, string voucherNo, string narration, bool isCancel) {
			this.chequeBook_ID = chequeBook_ID;
			this.chequeNumber = chequeNumber;
			this.voucherNo = voucherNo;
			this.narration = narration;
			this.isCancel = isCancel;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeBook_ID value.
		/// </summary>
		public string ChequeBook_ID {
			get { return chequeBook_ID; }
			set { chequeBook_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeNumber value.
		/// </summary>
		public string ChequeNumber {
			get { return chequeNumber; }
			set { chequeNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the VoucherNo value.
		/// </summary>
		public string VoucherNo {
			get { return voucherNo; }
			set { voucherNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Narration value.
		/// </summary>
		public string Narration {
			get { return narration; }
			set { narration = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCancel value.
		/// </summary>
		public bool IsCancel {
			get { return isCancel; }
			set { isCancel = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accChequeBook_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeBook_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@voucherNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Narration", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isCancel", SqlDbType.Bit,1);
 
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@voucherNo"].Value = voucherNo;
			scom.Parameters["@Narration"].Value = narration;
			scom.Parameters["@isCancel"].Value = isCancel;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accChequeBook_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeBook_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@voucherNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Narration", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isCancel", SqlDbType.Bit,1);
 
 
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@voucherNo"].Value = voucherNo;
			scom.Parameters["@Narration"].Value = narration;
			scom.Parameters["@isCancel"].Value = isCancel;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accChequeBook_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeBook_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
 
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeBook_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeBook_ID(string chequeBook_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeBook_DetailDeleteAllByChequeBook_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accChequeBook_Detail table.
		/// </summary>
		public static tbl_accChequeBook_Detail Select(string chequeNumber_Incoming, string chequeBook_ID_Incoming){

			tbl_accChequeBook_Detail tbl_accChequeBook_Detailins = new tbl_accChequeBook_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeBook_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeNumber"].Value = chequeNumber_Incoming;
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accChequeBook_Detailins = Maketbl_accChequeBook_Detail(dataReader);
				} else {
					tbl_accChequeBook_Detailins = null;
				}
			}
			scon.Close();
			return tbl_accChequeBook_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeBook_Detail table.
		/// </summary>
		public static List<tbl_accChequeBook_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeBook_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accChequeBook_Detail> tbl_accChequeBook_DetailList = new List<tbl_accChequeBook_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accChequeBook_Detail tbl_accChequeBook_Detail = Maketbl_accChequeBook_Detail(dataReader);
					tbl_accChequeBook_DetailList.Add(tbl_accChequeBook_Detail);
				}
			}
			scon.Close();
			return tbl_accChequeBook_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeBook_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accChequeBook_Detail> SelectAllByChequeBook_ID(string chequeBook_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeBook_DetailSelectAllByChequeBook_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
				List<tbl_accChequeBook_Detail> tbl_accChequeBook_DetailList = new List<tbl_accChequeBook_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accChequeBook_Detail tbl_accChequeBook_Detail = Maketbl_accChequeBook_Detail(dataReader);
					tbl_accChequeBook_DetailList.Add(tbl_accChequeBook_Detail);
				}
			}
			scon.Close();
			return tbl_accChequeBook_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accChequeBook_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accChequeBook_Detail Maketbl_accChequeBook_Detail(SqlDataReader dataReader) {
			tbl_accChequeBook_Detail tbl_accChequeBook_Detail = new tbl_accChequeBook_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accChequeBook_Detail.ChequeBook_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accChequeBook_Detail.ChequeNumber = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accChequeBook_Detail.VoucherNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accChequeBook_Detail.Narration = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accChequeBook_Detail.IsCancel = dataReader.GetBoolean(4);
			}

			return tbl_accChequeBook_Detail;
		}
		/// <summary>
		/// This makes tbl_accChequeBook_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accChequeBook_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accChequeBook_Detail  tbl_accChequeBook_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeBook_ID = new DataColumn("chequeBook_ID" , typeof(string));
			DataColumn col_chequeNumber = new DataColumn("chequeNumber" , typeof(string));
			DataColumn col_voucherNo = new DataColumn("voucherNo" , typeof(string));
			DataColumn col_Narration = new DataColumn("Narration" , typeof(string));
			DataColumn col_isCancel = new DataColumn("isCancel" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_chequeBook_ID,col_chequeNumber,col_voucherNo,col_Narration,col_isCancel,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accChequeBook_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accChequeBook_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accChequeBook_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeBook_ID"] = user.chequeBook_ID;
			drow["chequeNumber"] = user.chequeNumber;
			drow["voucherNo"] = user.voucherNo;
			drow["Narration"] = user.Narration;
			drow["isCancel"] = user.isCancel;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
