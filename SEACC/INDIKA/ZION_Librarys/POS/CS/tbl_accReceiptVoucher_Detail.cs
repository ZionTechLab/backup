using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accReceiptVoucher_Detail {
		#region Fields
		private string receiptVoucher_ID;
		private string gl_ID;
		private string cost_Center_ID;
		private string cost_Center_ID2;
		private decimal amount;
		private bool isCredit;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accReceiptVoucher_Detail class.
		/// </summary>
		public tbl_accReceiptVoucher_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accReceiptVoucher_Detail class.
		/// </summary>
		public tbl_accReceiptVoucher_Detail(string receiptVoucher_ID, string gl_ID, string cost_Center_ID, string cost_Center_ID2, decimal amount, bool isCredit) {
			this.receiptVoucher_ID = receiptVoucher_ID;
			this.gl_ID = gl_ID;
			this.cost_Center_ID = cost_Center_ID;
			this.cost_Center_ID2 = cost_Center_ID2;
			this.amount = amount;
			this.isCredit = isCredit;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ReceiptVoucher_ID value.
		/// </summary>
		public string ReceiptVoucher_ID {
			get { return receiptVoucher_ID; }
			set { receiptVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center_ID value.
		/// </summary>
		public string Cost_Center_ID {
			get { return cost_Center_ID; }
			set { cost_Center_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center_ID2 value.
		/// </summary>
		public string Cost_Center_ID2 {
			get { return cost_Center_ID2; }
			set { cost_Center_ID2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCredit value.
		/// </summary>
		public bool IsCredit {
			get { return isCredit; }
			set { isCredit = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accReceiptVoucher_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center_ID2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
 
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@cost_Center_ID2"].Value = cost_Center_ID2;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accReceiptVoucher_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center_ID2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
 
 
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@cost_Center_ID2"].Value = cost_Center_ID2;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accReceiptVoucher_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID;
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByReceiptVoucher_ID(string receiptVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailDeleteAllByReceiptVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accReceiptVoucher_Detail table.
		/// </summary>
		public static tbl_accReceiptVoucher_Detail Select(string receiptVoucher_ID_Incoming, string gl_ID_Incoming){

			tbl_accReceiptVoucher_Detail tbl_accReceiptVoucher_Detailins = new tbl_accReceiptVoucher_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID_Incoming;
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accReceiptVoucher_Detailins = Maketbl_accReceiptVoucher_Detail(dataReader);
				} else {
					tbl_accReceiptVoucher_Detailins = null;
				}
			}
			scon.Close();
			return tbl_accReceiptVoucher_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher_Detail table.
		/// </summary>
		public static List<tbl_accReceiptVoucher_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accReceiptVoucher_Detail> tbl_accReceiptVoucher_DetailList = new List<tbl_accReceiptVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher_Detail tbl_accReceiptVoucher_Detail = Maketbl_accReceiptVoucher_Detail(dataReader);
					tbl_accReceiptVoucher_DetailList.Add(tbl_accReceiptVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptVoucher_Detail> SelectAllByReceiptVoucher_ID(string receiptVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailSelectAllByReceiptVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID;
				List<tbl_accReceiptVoucher_Detail> tbl_accReceiptVoucher_DetailList = new List<tbl_accReceiptVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher_Detail tbl_accReceiptVoucher_Detail = Maketbl_accReceiptVoucher_Detail(dataReader);
					tbl_accReceiptVoucher_DetailList.Add(tbl_accReceiptVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptVoucher_Detail> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucher_DetailSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accReceiptVoucher_Detail> tbl_accReceiptVoucher_DetailList = new List<tbl_accReceiptVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher_Detail tbl_accReceiptVoucher_Detail = Maketbl_accReceiptVoucher_Detail(dataReader);
					tbl_accReceiptVoucher_DetailList.Add(tbl_accReceiptVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucher_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accReceiptVoucher_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accReceiptVoucher_Detail Maketbl_accReceiptVoucher_Detail(SqlDataReader dataReader) {
			tbl_accReceiptVoucher_Detail tbl_accReceiptVoucher_Detail = new tbl_accReceiptVoucher_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accReceiptVoucher_Detail.ReceiptVoucher_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accReceiptVoucher_Detail.Gl_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accReceiptVoucher_Detail.Cost_Center_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accReceiptVoucher_Detail.Cost_Center_ID2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accReceiptVoucher_Detail.Amount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accReceiptVoucher_Detail.IsCredit = dataReader.GetBoolean(5);
			}

			return tbl_accReceiptVoucher_Detail;
		}
		/// <summary>
		/// This makes tbl_accReceiptVoucher_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accReceiptVoucher_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accReceiptVoucher_Detail  tbl_accReceiptVoucher_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_receiptVoucher_ID = new DataColumn("receiptVoucher_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_cost_Center_ID = new DataColumn("cost_Center_ID" , typeof(string));
			DataColumn col_cost_Center_ID2 = new DataColumn("cost_Center_ID2" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_isCredit = new DataColumn("isCredit" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_receiptVoucher_ID,col_gl_ID,col_cost_Center_ID,col_cost_Center_ID2,col_amount,col_isCredit,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accReceiptVoucher_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accReceiptVoucher_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accReceiptVoucher_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["receiptVoucher_ID"] = user.receiptVoucher_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["cost_Center_ID"] = user.cost_Center_ID;
			drow["cost_Center_ID2"] = user.cost_Center_ID2;
			drow["amount"] = user.amount;
			drow["isCredit"] = user.isCredit;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
