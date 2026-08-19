using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DataTire {
	public sealed class tbl_pcbTxExpenditure_Detail {
		#region Fields
		private string expenditure_ID;
		private string pcbExpenditureCategory_ID;
		private string remarks;
		private decimal amount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxExpenditure_Detail class.
		/// </summary>
		public tbl_pcbTxExpenditure_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxExpenditure_Detail class.
		/// </summary>
		public tbl_pcbTxExpenditure_Detail(string expenditure_ID, string pcbExpenditureCategory_ID, string remarks, decimal amount) {
			this.expenditure_ID = expenditure_ID;
			this.pcbExpenditureCategory_ID = pcbExpenditureCategory_ID;
			this.remarks = remarks;
			this.amount = amount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Expenditure_ID value.
		/// </summary>
		public string Expenditure_ID {
			get { return expenditure_ID; }
			set { expenditure_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PcbExpenditureCategory_ID value.
		/// </summary>
		public string PcbExpenditureCategory_ID {
			get { return pcbExpenditureCategory_ID; }
			set { pcbExpenditureCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pcbTxExpenditure_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pcbTxExpenditure_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pcbTxExpenditure_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
 
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxExpenditure_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByExpenditure_ID(string expenditure_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailDeleteAllByExpenditure_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxExpenditure_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPcbExpenditureCategory_ID(string pcbExpenditureCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailDeleteAllByPcbExpenditureCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbTxExpenditure_Detail table.
		/// </summary>
		public static tbl_pcbTxExpenditure_Detail Select(string expenditure_ID_Incoming, string pcbExpenditureCategory_ID_Incoming){

			tbl_pcbTxExpenditure_Detail tbl_pcbTxExpenditure_Detailins = new tbl_pcbTxExpenditure_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID_Incoming;
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbTxExpenditure_Detailins = Maketbl_pcbTxExpenditure_Detail(dataReader);
				} else {
					tbl_pcbTxExpenditure_Detailins = null;
				}
			}
			scon.Close();
			return tbl_pcbTxExpenditure_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxExpenditure_Detail table.
		/// </summary>
		public static List<tbl_pcbTxExpenditure_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbTxExpenditure_Detail> tbl_pcbTxExpenditure_DetailList = new List<tbl_pcbTxExpenditure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxExpenditure_Detail tbl_pcbTxExpenditure_Detail = Maketbl_pcbTxExpenditure_Detail(dataReader);
					tbl_pcbTxExpenditure_DetailList.Add(tbl_pcbTxExpenditure_Detail);
				}
			}
			scon.Close();
			return tbl_pcbTxExpenditure_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxExpenditure_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxExpenditure_Detail> SelectAllByExpenditure_ID(string expenditure_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailSelectAllByExpenditure_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
				List<tbl_pcbTxExpenditure_Detail> tbl_pcbTxExpenditure_DetailList = new List<tbl_pcbTxExpenditure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxExpenditure_Detail tbl_pcbTxExpenditure_Detail = Maketbl_pcbTxExpenditure_Detail(dataReader);
					tbl_pcbTxExpenditure_DetailList.Add(tbl_pcbTxExpenditure_Detail);
				}
			}
			scon.Close();
			return tbl_pcbTxExpenditure_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxExpenditure_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxExpenditure_Detail> SelectAllByPcbExpenditureCategory_ID(string pcbExpenditureCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditure_DetailSelectAllByPcbExpenditureCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID;
				List<tbl_pcbTxExpenditure_Detail> tbl_pcbTxExpenditure_DetailList = new List<tbl_pcbTxExpenditure_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxExpenditure_Detail tbl_pcbTxExpenditure_Detail = Maketbl_pcbTxExpenditure_Detail(dataReader);
					tbl_pcbTxExpenditure_DetailList.Add(tbl_pcbTxExpenditure_Detail);
				}
			}
			scon.Close();
			return tbl_pcbTxExpenditure_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbTxExpenditure_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbTxExpenditure_Detail Maketbl_pcbTxExpenditure_Detail(SqlDataReader dataReader) {
			tbl_pcbTxExpenditure_Detail tbl_pcbTxExpenditure_Detail = new tbl_pcbTxExpenditure_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbTxExpenditure_Detail.Expenditure_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbTxExpenditure_Detail.PcbExpenditureCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbTxExpenditure_Detail.Remarks = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbTxExpenditure_Detail.Amount = dataReader.GetDecimal(3);
			}

			return tbl_pcbTxExpenditure_Detail;
		}
		/// <summary>
		/// This makes tbl_pcbTxExpenditure_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbTxExpenditure_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbTxExpenditure_Detail  tbl_pcbTxExpenditure_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_Expenditure_ID = new DataColumn("Expenditure_ID" , typeof(string));
			DataColumn col_pcbExpenditureCategory_ID = new DataColumn("pcbExpenditureCategory_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_Expenditure_ID,col_pcbExpenditureCategory_ID,col_remarks,col_amount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbTxExpenditure_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbTxExpenditure_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbTxExpenditure_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["Expenditure_ID"] = user.Expenditure_ID;
			drow["pcbExpenditureCategory_ID"] = user.pcbExpenditureCategory_ID;
			drow["remarks"] = user.remarks;
			drow["amount"] = user.amount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
