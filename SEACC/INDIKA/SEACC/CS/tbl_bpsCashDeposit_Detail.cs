using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsCashDeposit_Detail {
		#region Fields
		private int line_No;
		private string cashDeposit_ID;
		private string receipt_ID;
		private string glPosting_ID;
		private string postingStatus_ID;
		private decimal depositedAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsCashDeposit_Detail class.
		/// </summary>
		public tbl_bpsCashDeposit_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsCashDeposit_Detail class.
		/// </summary>
		public tbl_bpsCashDeposit_Detail(int line_No, string cashDeposit_ID, string receipt_ID, string glPosting_ID, string postingStatus_ID, decimal depositedAmount) {
			this.line_No = line_No;
			this.cashDeposit_ID = cashDeposit_ID;
			this.receipt_ID = receipt_ID;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.depositedAmount = depositedAmount;
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
		/// Gets or sets the CashDeposit_ID value.
		/// </summary>
		public string CashDeposit_ID {
			get { return cashDeposit_ID; }
			set { cashDeposit_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStatus_ID value.
		/// </summary>
		public string PostingStatus_ID {
			get { return postingStatus_ID; }
			set { postingStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepositedAmount value.
		/// </summary>
		public decimal DepositedAmount {
			get { return depositedAmount; }
			set { depositedAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsCashDeposit_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDeposit_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@depositedAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@depositedAmount"].Value = depositedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsCashDeposit_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDeposit_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@depositedAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@depositedAmount"].Value = depositedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsCashDeposit_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDeposit_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID;
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCashDeposit_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCashDeposit_ID(string cashDeposit_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDeposit_DetailDeleteAllByCashDeposit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsCashDeposit_Detail table.
		/// </summary>
		public static tbl_bpsCashDeposit_Detail Select(string cashDeposit_ID_Incoming, string receipt_ID_Incoming){

			tbl_bpsCashDeposit_Detail tbl_bpsCashDeposit_Detailins = new tbl_bpsCashDeposit_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDeposit_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID_Incoming;
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsCashDeposit_Detailins = Maketbl_bpsCashDeposit_Detail(dataReader);
				} else {
					tbl_bpsCashDeposit_Detailins = null;
				}
			}
			scon.Close();
			return tbl_bpsCashDeposit_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCashDeposit_Detail table.
		/// </summary>
		public static List<tbl_bpsCashDeposit_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDeposit_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsCashDeposit_Detail> tbl_bpsCashDeposit_DetailList = new List<tbl_bpsCashDeposit_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsCashDeposit_Detail tbl_bpsCashDeposit_Detail = Maketbl_bpsCashDeposit_Detail(dataReader);
					tbl_bpsCashDeposit_DetailList.Add(tbl_bpsCashDeposit_Detail);
				}
			}
			scon.Close();
			return tbl_bpsCashDeposit_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCashDeposit_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsCashDeposit_Detail> SelectAllByCashDeposit_ID(string cashDeposit_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDeposit_DetailSelectAllByCashDeposit_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID;
				List<tbl_bpsCashDeposit_Detail> tbl_bpsCashDeposit_DetailList = new List<tbl_bpsCashDeposit_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsCashDeposit_Detail tbl_bpsCashDeposit_Detail = Maketbl_bpsCashDeposit_Detail(dataReader);
					tbl_bpsCashDeposit_DetailList.Add(tbl_bpsCashDeposit_Detail);
				}
			}
			scon.Close();
			return tbl_bpsCashDeposit_DetailList;
		}

        /// <summary>
        /// Selects all records from the tbl_bpsCashDeposit_Detail table by a foreign key.
        /// </summary>
        public static List<tbl_bpsCashDeposit_Detail> SelectAllByReceipt_ID(string receipt_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsCashDeposit_DetailSelectAllByReceipt_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@receipt_ID"].Value = receipt_ID;
            List<tbl_bpsCashDeposit_Detail> tbl_bpsCashDeposit_DetailList = new List<tbl_bpsCashDeposit_Detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsCashDeposit_Detail tbl_bpsCashDeposit_Detail = Maketbl_bpsCashDeposit_Detail(dataReader);
                    tbl_bpsCashDeposit_DetailList.Add(tbl_bpsCashDeposit_Detail);
                }
            }
            scon.Close();
            return tbl_bpsCashDeposit_DetailList;
        }
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsCashDeposit_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsCashDeposit_Detail Maketbl_bpsCashDeposit_Detail(SqlDataReader dataReader) {
			tbl_bpsCashDeposit_Detail tbl_bpsCashDeposit_Detail = new tbl_bpsCashDeposit_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsCashDeposit_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsCashDeposit_Detail.CashDeposit_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsCashDeposit_Detail.Receipt_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsCashDeposit_Detail.GlPosting_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsCashDeposit_Detail.PostingStatus_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsCashDeposit_Detail.DepositedAmount = dataReader.GetDecimal(5);
			}

			return tbl_bpsCashDeposit_Detail;
		}
		/// <summary>
		/// This makes tbl_bpsCashDeposit_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsCashDeposit_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsCashDeposit_Detail  tbl_bpsCashDeposit_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_cashDeposit_ID = new DataColumn("cashDeposit_ID" , typeof(string));
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_depositedAmount = new DataColumn("depositedAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_cashDeposit_ID,col_receipt_ID,col_glPosting_ID,col_postingStatus_ID,col_depositedAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsCashDeposit_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsCashDeposit_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsCashDeposit_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["cashDeposit_ID"] = user.cashDeposit_ID;
			drow["receipt_ID"] = user.receipt_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["depositedAmount"] = user.depositedAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
