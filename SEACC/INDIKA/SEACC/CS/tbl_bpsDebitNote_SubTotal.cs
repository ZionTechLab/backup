using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsDebitNote_SubTotal {
		#region Fields
		private int line_No;
		private string debitNote_ID;
		private string tc_ID;
		private string gl_ID;
		private string customer_ID;
		private string bankAcc_No;
		private string costCenter1_ID;
		private string costCenter2_ID;
		private decimal amount;
		private bool isCredit;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsDebitNote_SubTotal class.
		/// </summary>
		public tbl_bpsDebitNote_SubTotal() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsDebitNote_SubTotal class.
		/// </summary>
		public tbl_bpsDebitNote_SubTotal(int line_No, string debitNote_ID, string tc_ID, string gl_ID, string customer_ID, string bankAcc_No, string costCenter1_ID, string costCenter2_ID, decimal amount, bool isCredit, string remarks) {
			this.line_No = line_No;
			this.debitNote_ID = debitNote_ID;
			this.tc_ID = tc_ID;
			this.gl_ID = gl_ID;
			this.customer_ID = customer_ID;
			this.bankAcc_No = bankAcc_No;
			this.costCenter1_ID = costCenter1_ID;
			this.costCenter2_ID = costCenter2_ID;
			this.amount = amount;
			this.isCredit = isCredit;
			this.remarks = remarks;
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
		/// Gets or sets the DebitNote_ID value.
		/// </summary>
		public string DebitNote_ID {
			get { return debitNote_ID; }
			set { debitNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tc_ID value.
		/// </summary>
		public string Tc_ID {
			get { return tc_ID; }
			set { tc_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankAcc_No value.
		/// </summary>
		public string BankAcc_No {
			get { return bankAcc_No; }
			set { bankAcc_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter1_ID value.
		/// </summary>
		public string CostCenter1_ID {
			get { return costCenter1_ID; }
			set { costCenter1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter2_ID value.
		/// </summary>
		public string CostCenter2_ID {
			get { return costCenter2_ID; }
			set { costCenter2_ID = value; }
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
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsDebitNote_SubTotal table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@IsCredit", SqlDbType.Bit,1);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@tc_ID"].Value = tc_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@IsCredit"].Value = isCredit;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsDebitNote_SubTotal table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@IsCredit", SqlDbType.Bit,1);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@tc_ID"].Value = tc_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@IsCredit"].Value = isCredit;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsDebitNote_SubTotal table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
			scom.Parameters["@tc_ID"].Value = tc_ID;
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostCenter1_ID(string costCenter1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalDeleteAllByCostCenter1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table by a foreign key.
		/// </summary>
		public static void DeleteAllByDebitNote_ID(string debitNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalDeleteAllByDebitNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostCenter2_ID(string costCenter2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalDeleteAllByCostCenter2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsDebitNote_SubTotal table.
		/// </summary>
		public static tbl_bpsDebitNote_SubTotal Select(int line_No_Incoming, string debitNote_ID_Incoming, string tc_ID_Incoming, string gl_ID_Incoming){

			tbl_bpsDebitNote_SubTotal tbl_bpsDebitNote_SubTotalins = new tbl_bpsDebitNote_SubTotal();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID_Incoming;
			scom.Parameters["@tc_ID"].Value = tc_ID_Incoming;
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsDebitNote_SubTotalins = Maketbl_bpsDebitNote_SubTotal(dataReader);
				} else {
					tbl_bpsDebitNote_SubTotalins = null;
				}
			}
			scon.Close();
			return tbl_bpsDebitNote_SubTotalins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table.
		/// </summary>
		public static List<tbl_bpsDebitNote_SubTotal> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsDebitNote_SubTotal> tbl_bpsDebitNote_SubTotalList = new List<tbl_bpsDebitNote_SubTotal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote_SubTotal tbl_bpsDebitNote_SubTotal = Maketbl_bpsDebitNote_SubTotal(dataReader);
					tbl_bpsDebitNote_SubTotalList.Add(tbl_bpsDebitNote_SubTotal);
				}
			}
			scon.Close();
			return tbl_bpsDebitNote_SubTotalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote_SubTotal> SelectAllByCostCenter1_ID(string costCenter1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalSelectAllByCostCenter1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
				List<tbl_bpsDebitNote_SubTotal> tbl_bpsDebitNote_SubTotalList = new List<tbl_bpsDebitNote_SubTotal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote_SubTotal tbl_bpsDebitNote_SubTotal = Maketbl_bpsDebitNote_SubTotal(dataReader);
					tbl_bpsDebitNote_SubTotalList.Add(tbl_bpsDebitNote_SubTotal);
				}
			}
			scon.Close();
			return tbl_bpsDebitNote_SubTotalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote_SubTotal> SelectAllByDebitNote_ID(string debitNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalSelectAllByDebitNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
				List<tbl_bpsDebitNote_SubTotal> tbl_bpsDebitNote_SubTotalList = new List<tbl_bpsDebitNote_SubTotal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote_SubTotal tbl_bpsDebitNote_SubTotal = Maketbl_bpsDebitNote_SubTotal(dataReader);
					tbl_bpsDebitNote_SubTotalList.Add(tbl_bpsDebitNote_SubTotal);
				}
			}
			scon.Close();
			return tbl_bpsDebitNote_SubTotalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote_SubTotal> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_bpsDebitNote_SubTotal> tbl_bpsDebitNote_SubTotalList = new List<tbl_bpsDebitNote_SubTotal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote_SubTotal tbl_bpsDebitNote_SubTotal = Maketbl_bpsDebitNote_SubTotal(dataReader);
					tbl_bpsDebitNote_SubTotalList.Add(tbl_bpsDebitNote_SubTotal);
				}
			}
			scon.Close();
			return tbl_bpsDebitNote_SubTotalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote_SubTotal table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote_SubTotal> SelectAllByCostCenter2_ID(string costCenter2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNote_SubTotalSelectAllByCostCenter2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
				List<tbl_bpsDebitNote_SubTotal> tbl_bpsDebitNote_SubTotalList = new List<tbl_bpsDebitNote_SubTotal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote_SubTotal tbl_bpsDebitNote_SubTotal = Maketbl_bpsDebitNote_SubTotal(dataReader);
					tbl_bpsDebitNote_SubTotalList.Add(tbl_bpsDebitNote_SubTotal);
				}
			}
			scon.Close();
			return tbl_bpsDebitNote_SubTotalList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsDebitNote_SubTotal class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsDebitNote_SubTotal Maketbl_bpsDebitNote_SubTotal(SqlDataReader dataReader) {
			tbl_bpsDebitNote_SubTotal tbl_bpsDebitNote_SubTotal = new tbl_bpsDebitNote_SubTotal();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsDebitNote_SubTotal.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsDebitNote_SubTotal.DebitNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsDebitNote_SubTotal.Tc_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsDebitNote_SubTotal.Gl_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsDebitNote_SubTotal.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsDebitNote_SubTotal.BankAcc_No = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsDebitNote_SubTotal.CostCenter1_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsDebitNote_SubTotal.CostCenter2_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsDebitNote_SubTotal.Amount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsDebitNote_SubTotal.IsCredit = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsDebitNote_SubTotal.Remarks = dataReader.GetString(10);
			}

			return tbl_bpsDebitNote_SubTotal;
		}
		/// <summary>
		/// This makes tbl_bpsDebitNote_SubTotal datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsDebitNote_SubTotal object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsDebitNote_SubTotal  tbl_bpsDebitNote_SubTotal   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_debitNote_ID = new DataColumn("debitNote_ID" , typeof(string));
			DataColumn col_tc_ID = new DataColumn("tc_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_bankAcc_No = new DataColumn("bankAcc_No" , typeof(string));
			DataColumn col_costCenter1_ID = new DataColumn("costCenter1_ID" , typeof(string));
			DataColumn col_costCenter2_ID = new DataColumn("costCenter2_ID" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_IsCredit = new DataColumn("IsCredit" , typeof(bool));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_debitNote_ID,col_tc_ID,col_gl_ID,col_customer_ID,col_bankAcc_No,col_costCenter1_ID,col_costCenter2_ID,col_amount,col_IsCredit,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsDebitNote_SubTotal datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsDebitNote_SubTotal object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsDebitNote_SubTotal user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["debitNote_ID"] = user.debitNote_ID;
			drow["tc_ID"] = user.tc_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["bankAcc_No"] = user.bankAcc_No;
			drow["costCenter1_ID"] = user.costCenter1_ID;
			drow["costCenter2_ID"] = user.costCenter2_ID;
			drow["amount"] = user.amount;
			drow["IsCredit"] = user.IsCredit;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
