using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accAccountPayableNote_SubTotal {
		#region Fields
		private int line_No;
		private string accountPayableNote_ID;
		private string tc_ID;
		private string gl_ID;
		private string customer_ID;
		private string supplier_ID;
		private string employee_ID;
		private string bankAcc_No;
		private string costCenter1_ID;
		private string costCenter2_ID;
		private decimal amount;
		private bool isCredit;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accAccountPayableNote_SubTotal class.
		/// </summary>
		public tbl_accAccountPayableNote_SubTotal() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accAccountPayableNote_SubTotal class.
		/// </summary>
		public tbl_accAccountPayableNote_SubTotal(int line_No, string accountPayableNote_ID, string tc_ID, string gl_ID, string customer_ID, string supplier_ID, string employee_ID, string bankAcc_No, string costCenter1_ID, string costCenter2_ID, decimal amount, bool isCredit) {
			this.line_No = line_No;
			this.accountPayableNote_ID = accountPayableNote_ID;
			this.tc_ID = tc_ID;
			this.gl_ID = gl_ID;
			this.customer_ID = customer_ID;
			this.supplier_ID = supplier_ID;
			this.employee_ID = employee_ID;
			this.bankAcc_No = bankAcc_No;
			this.costCenter1_ID = costCenter1_ID;
			this.costCenter2_ID = costCenter2_ID;
			this.amount = amount;
			this.isCredit = isCredit;
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
		/// Gets or sets the AccountPayableNote_ID value.
		/// </summary>
		public string AccountPayableNote_ID {
			get { return accountPayableNote_ID; }
			set { accountPayableNote_ID = value; }
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
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accAccountPayableNote_SubTotal table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_SubTotalInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@IsCredit", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@tc_ID"].Value = tc_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@IsCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accAccountPayableNote_SubTotal table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_SubTotalUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@IsCredit", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@tc_ID"].Value = tc_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@IsCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accAccountPayableNote_SubTotal table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_SubTotalDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
 
			scom.Parameters["@tc_ID"].Value = tc_ID;
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote_SubTotal table by a foreign key.
		/// </summary>
		public static void DeleteAllByAccountPayableNote_ID(string accountPayableNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_SubTotalDeleteAllByAccountPayableNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accAccountPayableNote_SubTotal table.
		/// </summary>
		public static tbl_accAccountPayableNote_SubTotal Select(int line_No_Incoming, string accountPayableNote_ID_Incoming, string tc_ID_Incoming, string gl_ID_Incoming){

			tbl_accAccountPayableNote_SubTotal tbl_accAccountPayableNote_SubTotalins = new tbl_accAccountPayableNote_SubTotal();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_SubTotalSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID_Incoming;
			scom.Parameters["@tc_ID"].Value = tc_ID_Incoming;
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accAccountPayableNote_SubTotalins = Maketbl_accAccountPayableNote_SubTotal(dataReader);
				} else {
					tbl_accAccountPayableNote_SubTotalins = null;
				}
			}
			scon.Close();
			return tbl_accAccountPayableNote_SubTotalins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote_SubTotal table.
		/// </summary>
		public static List<tbl_accAccountPayableNote_SubTotal> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_SubTotalSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accAccountPayableNote_SubTotal> tbl_accAccountPayableNote_SubTotalList = new List<tbl_accAccountPayableNote_SubTotal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote_SubTotal tbl_accAccountPayableNote_SubTotal = Maketbl_accAccountPayableNote_SubTotal(dataReader);
					tbl_accAccountPayableNote_SubTotalList.Add(tbl_accAccountPayableNote_SubTotal);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNote_SubTotalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote_SubTotal table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountPayableNote_SubTotal> SelectAllByAccountPayableNote_ID(string accountPayableNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_SubTotalSelectAllByAccountPayableNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
				List<tbl_accAccountPayableNote_SubTotal> tbl_accAccountPayableNote_SubTotalList = new List<tbl_accAccountPayableNote_SubTotal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote_SubTotal tbl_accAccountPayableNote_SubTotal = Maketbl_accAccountPayableNote_SubTotal(dataReader);
					tbl_accAccountPayableNote_SubTotalList.Add(tbl_accAccountPayableNote_SubTotal);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNote_SubTotalList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accAccountPayableNote_SubTotal class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accAccountPayableNote_SubTotal Maketbl_accAccountPayableNote_SubTotal(SqlDataReader dataReader) {
			tbl_accAccountPayableNote_SubTotal tbl_accAccountPayableNote_SubTotal = new tbl_accAccountPayableNote_SubTotal();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accAccountPayableNote_SubTotal.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accAccountPayableNote_SubTotal.AccountPayableNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accAccountPayableNote_SubTotal.Tc_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accAccountPayableNote_SubTotal.Gl_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accAccountPayableNote_SubTotal.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accAccountPayableNote_SubTotal.Supplier_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accAccountPayableNote_SubTotal.Employee_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accAccountPayableNote_SubTotal.BankAcc_No = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accAccountPayableNote_SubTotal.CostCenter1_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accAccountPayableNote_SubTotal.CostCenter2_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accAccountPayableNote_SubTotal.Amount = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accAccountPayableNote_SubTotal.IsCredit = dataReader.GetBoolean(11);
			}

			return tbl_accAccountPayableNote_SubTotal;
		}
		/// <summary>
		/// This makes tbl_accAccountPayableNote_SubTotal datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accAccountPayableNote_SubTotal object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accAccountPayableNote_SubTotal  tbl_accAccountPayableNote_SubTotal   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_accountPayableNote_ID = new DataColumn("accountPayableNote_ID" , typeof(string));
			DataColumn col_tc_ID = new DataColumn("tc_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_bankAcc_No = new DataColumn("bankAcc_No" , typeof(string));
			DataColumn col_costCenter1_ID = new DataColumn("costCenter1_ID" , typeof(string));
			DataColumn col_costCenter2_ID = new DataColumn("costCenter2_ID" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_IsCredit = new DataColumn("IsCredit" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_accountPayableNote_ID,col_tc_ID,col_gl_ID,col_customer_ID,col_supplier_ID,col_employee_ID,col_bankAcc_No,col_costCenter1_ID,col_costCenter2_ID,col_amount,col_IsCredit,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accAccountPayableNote_SubTotal datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accAccountPayableNote_SubTotal object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accAccountPayableNote_SubTotal user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["accountPayableNote_ID"] = user.accountPayableNote_ID;
			drow["tc_ID"] = user.tc_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["bankAcc_No"] = user.bankAcc_No;
			drow["costCenter1_ID"] = user.costCenter1_ID;
			drow["costCenter2_ID"] = user.costCenter2_ID;
			drow["amount"] = user.amount;
			drow["IsCredit"] = user.IsCredit;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
