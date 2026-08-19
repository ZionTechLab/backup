using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accContraVoucher_Detail {
		#region Fields
		private int line_No;
		private string contraVoucher_ID;
		private string tc_ID;
		private string gl_ID;
		private string customer_ID;
		private string supplier_ID;
		private string employee_ID;
		private string bankAcc_No;
		private string costCenter1_ID;
		private string costCenter2_ID;
		private string remarks;
		private decimal amount;
		private bool isCredit;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accContraVoucher_Detail class.
		/// </summary>
		public tbl_accContraVoucher_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accContraVoucher_Detail class.
		/// </summary>
		public tbl_accContraVoucher_Detail(int line_No, string contraVoucher_ID, string tc_ID, string gl_ID, string customer_ID, string supplier_ID, string employee_ID, string bankAcc_No, string costCenter1_ID, string costCenter2_ID, string remarks, decimal amount, bool isCredit) {
			this.line_No = line_No;
			this.contraVoucher_ID = contraVoucher_ID;
			this.tc_ID = tc_ID;
			this.gl_ID = gl_ID;
			this.customer_ID = customer_ID;
			this.supplier_ID = supplier_ID;
			this.employee_ID = employee_ID;
			this.bankAcc_No = bankAcc_No;
			this.costCenter1_ID = costCenter1_ID;
			this.costCenter2_ID = costCenter2_ID;
			this.remarks = remarks;
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
		/// Gets or sets the ContraVoucher_ID value.
		/// </summary>
		public string ContraVoucher_ID {
			get { return contraVoucher_ID; }
			set { contraVoucher_ID = value; }
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
		/// Saves a record to the tbl_accContraVoucher_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@ContraVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@ContraVoucher_ID"].Value = contraVoucher_ID;
			scom.Parameters["@tc_ID"].Value = tc_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accContraVoucher_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@ContraVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@ContraVoucher_ID"].Value = contraVoucher_ID;
			scom.Parameters["@tc_ID"].Value = tc_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accContraVoucher_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@ContraVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@ContraVoucher_ID"].Value = contraVoucher_ID;
 
			scom.Parameters["@tc_ID"].Value = tc_ID;
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByContraVoucher_ID(string contraVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailDeleteAllByContraVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@ContraVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@ContraVoucher_ID"].Value = contraVoucher_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostCenter1_ID(string costCenter1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailDeleteAllByCostCenter1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostCenter2_ID(string costCenter2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailDeleteAllByCostCenter2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accContraVoucher_Detail table.
		/// </summary>
		public static tbl_accContraVoucher_Detail Select(int line_No_Incoming, string contraVoucher_ID_Incoming, string tc_ID_Incoming, string gl_ID_Incoming){

			tbl_accContraVoucher_Detail tbl_accContraVoucher_Detailins = new tbl_accContraVoucher_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@ContraVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tc_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@ContraVoucher_ID"].Value = contraVoucher_ID_Incoming;
			scom.Parameters["@tc_ID"].Value = tc_ID_Incoming;
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accContraVoucher_Detailins = Maketbl_accContraVoucher_Detail(dataReader);
				} else {
					tbl_accContraVoucher_Detailins = null;
				}
			}
			scon.Close();
			return tbl_accContraVoucher_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table.
		/// </summary>
		public static List<tbl_accContraVoucher_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accContraVoucher_Detail> tbl_accContraVoucher_DetailList = new List<tbl_accContraVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = Maketbl_accContraVoucher_Detail(dataReader);
					tbl_accContraVoucher_DetailList.Add(tbl_accContraVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accContraVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accContraVoucher_Detail> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_accContraVoucher_Detail> tbl_accContraVoucher_DetailList = new List<tbl_accContraVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = Maketbl_accContraVoucher_Detail(dataReader);
					tbl_accContraVoucher_DetailList.Add(tbl_accContraVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accContraVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accContraVoucher_Detail> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_accContraVoucher_Detail> tbl_accContraVoucher_DetailList = new List<tbl_accContraVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = Maketbl_accContraVoucher_Detail(dataReader);
					tbl_accContraVoucher_DetailList.Add(tbl_accContraVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accContraVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accContraVoucher_Detail> SelectAllByContraVoucher_ID(string contraVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelectAllByContraVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@ContraVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@ContraVoucher_ID"].Value = contraVoucher_ID;
				List<tbl_accContraVoucher_Detail> tbl_accContraVoucher_DetailList = new List<tbl_accContraVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = Maketbl_accContraVoucher_Detail(dataReader);
					tbl_accContraVoucher_DetailList.Add(tbl_accContraVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accContraVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accContraVoucher_Detail> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accContraVoucher_Detail> tbl_accContraVoucher_DetailList = new List<tbl_accContraVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = Maketbl_accContraVoucher_Detail(dataReader);
					tbl_accContraVoucher_DetailList.Add(tbl_accContraVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accContraVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accContraVoucher_Detail> SelectAllByCostCenter1_ID(string costCenter1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelectAllByCostCenter1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
				List<tbl_accContraVoucher_Detail> tbl_accContraVoucher_DetailList = new List<tbl_accContraVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = Maketbl_accContraVoucher_Detail(dataReader);
					tbl_accContraVoucher_DetailList.Add(tbl_accContraVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accContraVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accContraVoucher_Detail> SelectAllByCostCenter2_ID(string costCenter2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelectAllByCostCenter2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
				List<tbl_accContraVoucher_Detail> tbl_accContraVoucher_DetailList = new List<tbl_accContraVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = Maketbl_accContraVoucher_Detail(dataReader);
					tbl_accContraVoucher_DetailList.Add(tbl_accContraVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accContraVoucher_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accContraVoucher_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accContraVoucher_Detail> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accContraVoucher_DetailSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_accContraVoucher_Detail> tbl_accContraVoucher_DetailList = new List<tbl_accContraVoucher_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = Maketbl_accContraVoucher_Detail(dataReader);
					tbl_accContraVoucher_DetailList.Add(tbl_accContraVoucher_Detail);
				}
			}
			scon.Close();
			return tbl_accContraVoucher_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accContraVoucher_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accContraVoucher_Detail Maketbl_accContraVoucher_Detail(SqlDataReader dataReader) {
			tbl_accContraVoucher_Detail tbl_accContraVoucher_Detail = new tbl_accContraVoucher_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accContraVoucher_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accContraVoucher_Detail.ContraVoucher_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accContraVoucher_Detail.Tc_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accContraVoucher_Detail.Gl_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accContraVoucher_Detail.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accContraVoucher_Detail.Supplier_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accContraVoucher_Detail.Employee_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accContraVoucher_Detail.BankAcc_No = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accContraVoucher_Detail.CostCenter1_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accContraVoucher_Detail.CostCenter2_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accContraVoucher_Detail.Remarks = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accContraVoucher_Detail.Amount = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accContraVoucher_Detail.IsCredit = dataReader.GetBoolean(12);
			}

			return tbl_accContraVoucher_Detail;
		}
		/// <summary>
		/// This makes tbl_accContraVoucher_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accContraVoucher_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accContraVoucher_Detail  tbl_accContraVoucher_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_ContraVoucher_ID = new DataColumn("ContraVoucher_ID" , typeof(string));
			DataColumn col_tc_ID = new DataColumn("tc_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_bankAcc_No = new DataColumn("bankAcc_No" , typeof(string));
			DataColumn col_costCenter1_ID = new DataColumn("costCenter1_ID" , typeof(string));
			DataColumn col_costCenter2_ID = new DataColumn("costCenter2_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_isCredit = new DataColumn("isCredit" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_ContraVoucher_ID,col_tc_ID,col_gl_ID,col_customer_ID,col_supplier_ID,col_employee_ID,col_bankAcc_No,col_costCenter1_ID,col_costCenter2_ID,col_remarks,col_amount,col_isCredit,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accContraVoucher_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accContraVoucher_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accContraVoucher_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["ContraVoucher_ID"] = user.ContraVoucher_ID;
			drow["tc_ID"] = user.tc_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["bankAcc_No"] = user.bankAcc_No;
			drow["costCenter1_ID"] = user.costCenter1_ID;
			drow["costCenter2_ID"] = user.costCenter2_ID;
			drow["remarks"] = user.remarks;
			drow["amount"] = user.amount;
			drow["isCredit"] = user.isCredit;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
