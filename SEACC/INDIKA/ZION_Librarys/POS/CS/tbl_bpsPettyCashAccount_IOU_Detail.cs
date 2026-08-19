using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsPettyCashAccount_IOU_Detail {
		#region Fields
		private int line_NoIOU;
		private string iouAccount_ID;
		private DateTime iouDate;
		private string remark;
		private string spentUserName;
		private decimal amount;
		private bool isIncome;
		private bool isExpenditure;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount_IOU_Detail class.
		/// </summary>
		public tbl_bpsPettyCashAccount_IOU_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount_IOU_Detail class.
		/// </summary>
		public tbl_bpsPettyCashAccount_IOU_Detail(int line_NoIOU, string iouAccount_ID, DateTime iouDate, string remark, string spentUserName, decimal amount, bool isIncome, bool isExpenditure) {
			this.line_NoIOU = line_NoIOU;
			this.iouAccount_ID = iouAccount_ID;
			this.iouDate = iouDate;
			this.remark = remark;
			this.spentUserName = spentUserName;
			this.amount = amount;
			this.isIncome = isIncome;
			this.isExpenditure = isExpenditure;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_NoIOU value.
		/// </summary>
		public int Line_NoIOU {
			get { return line_NoIOU; }
			set { line_NoIOU = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouAccount_ID value.
		/// </summary>
		public string IouAccount_ID {
			get { return iouAccount_ID; }
			set { iouAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouDate value.
		/// </summary>
		public DateTime IouDate {
			get { return iouDate; }
			set { iouDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the SpentUserName value.
		/// </summary>
		public string SpentUserName {
			get { return spentUserName; }
			set { spentUserName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsIncome value.
		/// </summary>
		public bool IsIncome {
			get { return isIncome; }
			set { isIncome = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsExpenditure value.
		/// </summary>
		public bool IsExpenditure {
			get { return isExpenditure; }
			set { isExpenditure = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsPettyCashAccount_IOU_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOU_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoIOU", SqlDbType.Int,4);
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IouDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@spentUserName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isIncome", SqlDbType.Bit,1);
			scom.Parameters.Add("@isExpenditure", SqlDbType.Bit,1);
 
			scom.Parameters["@line_NoIOU"].Value = line_NoIOU;
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
			scom.Parameters["@IouDate"].Value = iouDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@spentUserName"].Value = spentUserName;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isIncome"].Value = isIncome;
			scom.Parameters["@isExpenditure"].Value = isExpenditure;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsPettyCashAccount_IOU_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOU_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoIOU", SqlDbType.Int,4);
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IouDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@spentUserName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isIncome", SqlDbType.Bit,1);
			scom.Parameters.Add("@isExpenditure", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_NoIOU"].Value = line_NoIOU;
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
			scom.Parameters["@IouDate"].Value = iouDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@spentUserName"].Value = spentUserName;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isIncome"].Value = isIncome;
			scom.Parameters["@isExpenditure"].Value = isExpenditure;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsPettyCashAccount_IOU_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOU_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_NoIOU", SqlDbType.Int,4);
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoIOU"].Value = line_NoIOU;
 
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_IOU_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByIouAccount_ID(string iouAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOU_DetailDeleteAllByIouAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsPettyCashAccount_IOU_Detail table.
		/// </summary>
		public static tbl_bpsPettyCashAccount_IOU_Detail Select(int line_NoIOU_Incoming, string iouAccount_ID_Incoming){

			tbl_bpsPettyCashAccount_IOU_Detail tbl_bpsPettyCashAccount_IOU_Detailins = new tbl_bpsPettyCashAccount_IOU_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOU_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoIOU", SqlDbType.Int,4);
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoIOU"].Value = line_NoIOU_Incoming;
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsPettyCashAccount_IOU_Detailins = Maketbl_bpsPettyCashAccount_IOU_Detail(dataReader);
				} else {
					tbl_bpsPettyCashAccount_IOU_Detailins = null;
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_IOU_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_IOU_Detail table.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_IOU_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOU_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsPettyCashAccount_IOU_Detail> tbl_bpsPettyCashAccount_IOU_DetailList = new List<tbl_bpsPettyCashAccount_IOU_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_IOU_Detail tbl_bpsPettyCashAccount_IOU_Detail = Maketbl_bpsPettyCashAccount_IOU_Detail(dataReader);
					tbl_bpsPettyCashAccount_IOU_DetailList.Add(tbl_bpsPettyCashAccount_IOU_Detail);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_IOU_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_IOU_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_IOU_Detail> SelectAllByIouAccount_ID(string iouAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_IOU_DetailSelectAllByIouAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
				List<tbl_bpsPettyCashAccount_IOU_Detail> tbl_bpsPettyCashAccount_IOU_DetailList = new List<tbl_bpsPettyCashAccount_IOU_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_IOU_Detail tbl_bpsPettyCashAccount_IOU_Detail = Maketbl_bpsPettyCashAccount_IOU_Detail(dataReader);
					tbl_bpsPettyCashAccount_IOU_DetailList.Add(tbl_bpsPettyCashAccount_IOU_Detail);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_IOU_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsPettyCashAccount_IOU_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsPettyCashAccount_IOU_Detail Maketbl_bpsPettyCashAccount_IOU_Detail(SqlDataReader dataReader) {
			tbl_bpsPettyCashAccount_IOU_Detail tbl_bpsPettyCashAccount_IOU_Detail = new tbl_bpsPettyCashAccount_IOU_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsPettyCashAccount_IOU_Detail.Line_NoIOU = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsPettyCashAccount_IOU_Detail.IouAccount_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsPettyCashAccount_IOU_Detail.IouDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsPettyCashAccount_IOU_Detail.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsPettyCashAccount_IOU_Detail.SpentUserName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsPettyCashAccount_IOU_Detail.Amount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsPettyCashAccount_IOU_Detail.IsIncome = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsPettyCashAccount_IOU_Detail.IsExpenditure = dataReader.GetBoolean(7);
			}

			return tbl_bpsPettyCashAccount_IOU_Detail;
		}
		/// <summary>
		/// This makes tbl_bpsPettyCashAccount_IOU_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount_IOU_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsPettyCashAccount_IOU_Detail  tbl_bpsPettyCashAccount_IOU_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_NoIOU = new DataColumn("line_NoIOU" , typeof(int));
			DataColumn col_iouAccount_ID = new DataColumn("iouAccount_ID" , typeof(string));
			DataColumn col_IouDate = new DataColumn("IouDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_spentUserName = new DataColumn("spentUserName" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_isIncome = new DataColumn("isIncome" , typeof(bool));
			DataColumn col_isExpenditure = new DataColumn("isExpenditure" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_NoIOU,col_iouAccount_ID,col_IouDate,col_remark,col_spentUserName,col_amount,col_isIncome,col_isExpenditure,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsPettyCashAccount_IOU_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount_IOU_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsPettyCashAccount_IOU_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_NoIOU"] = user.line_NoIOU;
			drow["iouAccount_ID"] = user.iouAccount_ID;
			drow["IouDate"] = user.IouDate;
			drow["remark"] = user.remark;
			drow["spentUserName"] = user.spentUserName;
			drow["amount"] = user.amount;
			drow["isIncome"] = user.isIncome;
			drow["isExpenditure"] = user.isExpenditure;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
