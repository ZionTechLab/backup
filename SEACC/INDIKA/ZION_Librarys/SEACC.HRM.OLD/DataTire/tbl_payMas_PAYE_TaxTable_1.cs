using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payMas_PAYE_TaxTable_1 {
		#region Fields
		private string tax_table_ID;
		private string tax_tableCode;
		private string tax_tableName;
		private decimal tax_StartRange;
		private decimal tax_EndRange;
		private decimal tax_Rate;
		private decimal cola_Amt;
		private DateTime startDate;
		private DateTime endDate;
		private string glcode_CR;
		private string glcode_DR;
		private int status;
		private bool isChecked;
		private bool isApproved;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Checked;
		private string userID_Approved;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Checked;
		private string terminalID_Approved;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Checked;
		private DateTime date_Approved;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_PAYE_TaxTable_1 class.
		/// </summary>
		public tbl_payMas_PAYE_TaxTable_1() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_PAYE_TaxTable_1 class.
		/// </summary>
		public tbl_payMas_PAYE_TaxTable_1(string tax_table_ID, string tax_tableCode, string tax_tableName, decimal tax_StartRange, decimal tax_EndRange, decimal tax_Rate, decimal cola_Amt, DateTime startDate, DateTime endDate, string glcode_CR, string glcode_DR, int status, bool isChecked, bool isApproved, bool isCanceled, string userID_Created, string userID_Modified, string userID_Checked, string userID_Approved, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Checked, string terminalID_Approved, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Checked, DateTime date_Approved, DateTime date_Canceled) {
			this.tax_table_ID = tax_table_ID;
			this.tax_tableCode = tax_tableCode;
			this.tax_tableName = tax_tableName;
			this.tax_StartRange = tax_StartRange;
			this.tax_EndRange = tax_EndRange;
			this.tax_Rate = tax_Rate;
			this.cola_Amt = cola_Amt;
			this.startDate = startDate;
			this.endDate = endDate;
			this.glcode_CR = glcode_CR;
			this.glcode_DR = glcode_DR;
			this.status = status;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Checked = userID_Checked;
			this.userID_Approved = userID_Approved;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Checked = terminalID_Checked;
			this.terminalID_Approved = terminalID_Approved;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Checked = date_Checked;
			this.date_Approved = date_Approved;
			this.date_Canceled = date_Canceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tax_table_ID value.
		/// </summary>
		public string Tax_table_ID {
			get { return tax_table_ID; }
			set { tax_table_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tax_tableCode value.
		/// </summary>
		public string Tax_tableCode {
			get { return tax_tableCode; }
			set { tax_tableCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tax_tableName value.
		/// </summary>
		public string Tax_tableName {
			get { return tax_tableName; }
			set { tax_tableName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tax_StartRange value.
		/// </summary>
		public decimal Tax_StartRange {
			get { return tax_StartRange; }
			set { tax_StartRange = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tax_EndRange value.
		/// </summary>
		public decimal Tax_EndRange {
			get { return tax_EndRange; }
			set { tax_EndRange = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tax_Rate value.
		/// </summary>
		public decimal Tax_Rate {
			get { return tax_Rate; }
			set { tax_Rate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cola_Amt value.
		/// </summary>
		public decimal Cola_Amt {
			get { return cola_Amt; }
			set { cola_Amt = value; }
		}
		
		/// <summary>
		/// Gets or sets the StartDate value.
		/// </summary>
		public DateTime StartDate {
			get { return startDate; }
			set { startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndDate value.
		/// </summary>
		public DateTime EndDate {
			get { return endDate; }
			set { endDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Glcode_CR value.
		/// </summary>
		public string Glcode_CR {
			get { return glcode_CR; }
			set { glcode_CR = value; }
		}
		
		/// <summary>
		/// Gets or sets the Glcode_DR value.
		/// </summary>
		public string Glcode_DR {
			get { return glcode_DR; }
			set { glcode_DR = value; }
		}
		
		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public int Status {
			get { return status; }
			set { status = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked value.
		/// </summary>
		public bool IsChecked {
			get { return isChecked; }
			set { isChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Checked value.
		/// </summary>
		public string UserID_Checked {
			get { return userID_Checked; }
			set { userID_Checked = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Approved value.
		/// </summary>
		public string UserID_Approved {
			get { return userID_Approved; }
			set { userID_Approved = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Checked value.
		/// </summary>
		public string TerminalID_Checked {
			get { return terminalID_Checked; }
			set { terminalID_Checked = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Approved value.
		/// </summary>
		public string TerminalID_Approved {
			get { return terminalID_Approved; }
			set { terminalID_Approved = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Checked value.
		/// </summary>
		public DateTime Date_Checked {
			get { return date_Checked; }
			set { date_Checked = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Approved value.
		/// </summary>
		public DateTime Date_Approved {
			get { return date_Approved; }
			set { date_Approved = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payMas_PAYE_TaxTable_1 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tax_table_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tax_tableCode", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tax_tableName", SqlDbType.VarChar,150);
			scom.Parameters.Add("@tax_StartRange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tax_EndRange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tax_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cola_Amt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@glcode_CR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glcode_DR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@status", SqlDbType.Int,4);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Checked", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Approved", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Checked", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Approved", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,100);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Approved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@tax_table_ID"].Value = tax_table_ID;
			scom.Parameters["@tax_tableCode"].Value = tax_tableCode;
			scom.Parameters["@tax_tableName"].Value = tax_tableName;
			scom.Parameters["@tax_StartRange"].Value = tax_StartRange;
			scom.Parameters["@tax_EndRange"].Value = tax_EndRange;
			scom.Parameters["@tax_Rate"].Value = tax_Rate;
			scom.Parameters["@cola_Amt"].Value = cola_Amt;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@glcode_CR"].Value = glcode_CR;
			scom.Parameters["@glcode_DR"].Value = glcode_DR;
			scom.Parameters["@status"].Value = status;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Checked"].Value = userID_Checked;
			scom.Parameters["@userID_Approved"].Value = userID_Approved;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Checked"].Value = terminalID_Checked;
			scom.Parameters["@terminalID_Approved"].Value = terminalID_Approved;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Checked"].Value = date_Checked;
			scom.Parameters["@date_Approved"].Value = date_Approved;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payMas_PAYE_TaxTable_1 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tax_table_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tax_tableCode", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tax_tableName", SqlDbType.VarChar,150);
			scom.Parameters.Add("@tax_StartRange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tax_EndRange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tax_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cola_Amt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@glcode_CR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glcode_DR", SqlDbType.VarChar,20);
			scom.Parameters.Add("@status", SqlDbType.Int,4);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Checked", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Approved", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Checked", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Approved", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,100);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Approved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@tax_table_ID"].Value = tax_table_ID;
			scom.Parameters["@tax_tableCode"].Value = tax_tableCode;
			scom.Parameters["@tax_tableName"].Value = tax_tableName;
			scom.Parameters["@tax_StartRange"].Value = tax_StartRange;
			scom.Parameters["@tax_EndRange"].Value = tax_EndRange;
			scom.Parameters["@tax_Rate"].Value = tax_Rate;
			scom.Parameters["@cola_Amt"].Value = cola_Amt;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@glcode_CR"].Value = glcode_CR;
			scom.Parameters["@glcode_DR"].Value = glcode_DR;
			scom.Parameters["@status"].Value = status;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Checked"].Value = userID_Checked;
			scom.Parameters["@userID_Approved"].Value = userID_Approved;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Checked"].Value = terminalID_Checked;
			scom.Parameters["@terminalID_Approved"].Value = terminalID_Approved;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Checked"].Value = date_Checked;
			scom.Parameters["@date_Approved"].Value = date_Approved;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payMas_PAYE_TaxTable_1 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tax_table_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tax_table_ID"].Value = tax_table_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Approved(string userID_Approved) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1DeleteAllByUserID_Approved", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Approved", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Approved"].Value = userID_Approved;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Modified(string userID_Modified) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1DeleteAllByUserID_Modified", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Created(string userID_Created) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1DeleteAllByUserID_Created", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Created"].Value = userID_Created;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Checked(string userID_Checked) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1DeleteAllByUserID_Checked", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Checked", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Checked"].Value = userID_Checked;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Canceled(string userID_Canceled) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1DeleteAllByUserID_Canceled", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payMas_PAYE_TaxTable_1 table.
		/// </summary>
		public static tbl_payMas_PAYE_TaxTable_1 Select(string tax_table_ID_Incoming){

			tbl_payMas_PAYE_TaxTable_1 tbl_payMas_PAYE_TaxTable_1ins = new tbl_payMas_PAYE_TaxTable_1();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tax_table_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tax_table_ID"].Value = tax_table_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payMas_PAYE_TaxTable_1ins = Maketbl_payMas_PAYE_TaxTable_1(dataReader);
				} else {
					tbl_payMas_PAYE_TaxTable_1ins = null;
				}
			}
			scon.Close();
			return tbl_payMas_PAYE_TaxTable_1ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table.
		/// </summary>
		public static List<tbl_payMas_PAYE_TaxTable_1> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payMas_PAYE_TaxTable_1> tbl_payMas_PAYE_TaxTable_1List = new List<tbl_payMas_PAYE_TaxTable_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PAYE_TaxTable_1 tbl_payMas_PAYE_TaxTable_1 = Maketbl_payMas_PAYE_TaxTable_1(dataReader);
					tbl_payMas_PAYE_TaxTable_1List.Add(tbl_payMas_PAYE_TaxTable_1);
				}
			}
			scon.Close();
			return tbl_payMas_PAYE_TaxTable_1List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PAYE_TaxTable_1> SelectAllByUserID_Approved(string userID_Approved) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1SelectAllByUserID_Approved", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Approved", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Approved"].Value = userID_Approved;
				List<tbl_payMas_PAYE_TaxTable_1> tbl_payMas_PAYE_TaxTable_1List = new List<tbl_payMas_PAYE_TaxTable_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PAYE_TaxTable_1 tbl_payMas_PAYE_TaxTable_1 = Maketbl_payMas_PAYE_TaxTable_1(dataReader);
					tbl_payMas_PAYE_TaxTable_1List.Add(tbl_payMas_PAYE_TaxTable_1);
				}
			}
			scon.Close();
			return tbl_payMas_PAYE_TaxTable_1List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PAYE_TaxTable_1> SelectAllByUserID_Modified(string userID_Modified) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1SelectAllByUserID_Modified", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
				List<tbl_payMas_PAYE_TaxTable_1> tbl_payMas_PAYE_TaxTable_1List = new List<tbl_payMas_PAYE_TaxTable_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PAYE_TaxTable_1 tbl_payMas_PAYE_TaxTable_1 = Maketbl_payMas_PAYE_TaxTable_1(dataReader);
					tbl_payMas_PAYE_TaxTable_1List.Add(tbl_payMas_PAYE_TaxTable_1);
				}
			}
			scon.Close();
			return tbl_payMas_PAYE_TaxTable_1List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PAYE_TaxTable_1> SelectAllByUserID_Created(string userID_Created) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1SelectAllByUserID_Created", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Created"].Value = userID_Created;
				List<tbl_payMas_PAYE_TaxTable_1> tbl_payMas_PAYE_TaxTable_1List = new List<tbl_payMas_PAYE_TaxTable_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PAYE_TaxTable_1 tbl_payMas_PAYE_TaxTable_1 = Maketbl_payMas_PAYE_TaxTable_1(dataReader);
					tbl_payMas_PAYE_TaxTable_1List.Add(tbl_payMas_PAYE_TaxTable_1);
				}
			}
			scon.Close();
			return tbl_payMas_PAYE_TaxTable_1List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PAYE_TaxTable_1> SelectAllByUserID_Checked(string userID_Checked) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1SelectAllByUserID_Checked", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Checked", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Checked"].Value = userID_Checked;
				List<tbl_payMas_PAYE_TaxTable_1> tbl_payMas_PAYE_TaxTable_1List = new List<tbl_payMas_PAYE_TaxTable_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PAYE_TaxTable_1 tbl_payMas_PAYE_TaxTable_1 = Maketbl_payMas_PAYE_TaxTable_1(dataReader);
					tbl_payMas_PAYE_TaxTable_1List.Add(tbl_payMas_PAYE_TaxTable_1);
				}
			}
			scon.Close();
			return tbl_payMas_PAYE_TaxTable_1List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PAYE_TaxTable_1 table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PAYE_TaxTable_1> SelectAllByUserID_Canceled(string userID_Canceled) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PAYE_TaxTable_1SelectAllByUserID_Canceled", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
				List<tbl_payMas_PAYE_TaxTable_1> tbl_payMas_PAYE_TaxTable_1List = new List<tbl_payMas_PAYE_TaxTable_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PAYE_TaxTable_1 tbl_payMas_PAYE_TaxTable_1 = Maketbl_payMas_PAYE_TaxTable_1(dataReader);
					tbl_payMas_PAYE_TaxTable_1List.Add(tbl_payMas_PAYE_TaxTable_1);
				}
			}
			scon.Close();
			return tbl_payMas_PAYE_TaxTable_1List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payMas_PAYE_TaxTable_1 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payMas_PAYE_TaxTable_1 Maketbl_payMas_PAYE_TaxTable_1(SqlDataReader dataReader) {
			tbl_payMas_PAYE_TaxTable_1 tbl_payMas_PAYE_TaxTable_1 = new tbl_payMas_PAYE_TaxTable_1();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payMas_PAYE_TaxTable_1.Tax_table_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payMas_PAYE_TaxTable_1.Tax_tableCode = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payMas_PAYE_TaxTable_1.Tax_tableName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payMas_PAYE_TaxTable_1.Tax_StartRange = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payMas_PAYE_TaxTable_1.Tax_EndRange = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payMas_PAYE_TaxTable_1.Tax_Rate = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payMas_PAYE_TaxTable_1.Cola_Amt = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_payMas_PAYE_TaxTable_1.StartDate = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_payMas_PAYE_TaxTable_1.EndDate = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_payMas_PAYE_TaxTable_1.Glcode_CR = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_payMas_PAYE_TaxTable_1.Glcode_DR = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_payMas_PAYE_TaxTable_1.Status = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_payMas_PAYE_TaxTable_1.IsChecked = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_payMas_PAYE_TaxTable_1.IsApproved = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_payMas_PAYE_TaxTable_1.IsCanceled = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_payMas_PAYE_TaxTable_1.UserID_Created = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_payMas_PAYE_TaxTable_1.UserID_Modified = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_payMas_PAYE_TaxTable_1.UserID_Checked = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_payMas_PAYE_TaxTable_1.UserID_Approved = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_payMas_PAYE_TaxTable_1.UserID_Canceled = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_payMas_PAYE_TaxTable_1.TerminalID_Created = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_payMas_PAYE_TaxTable_1.TerminalID_Modified = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_payMas_PAYE_TaxTable_1.TerminalID_Checked = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_payMas_PAYE_TaxTable_1.TerminalID_Approved = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_payMas_PAYE_TaxTable_1.TerminalID_Canceled = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_payMas_PAYE_TaxTable_1.Date_Created = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_payMas_PAYE_TaxTable_1.Date_Modified = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_payMas_PAYE_TaxTable_1.Date_Checked = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_payMas_PAYE_TaxTable_1.Date_Approved = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_payMas_PAYE_TaxTable_1.Date_Canceled = dataReader.GetDateTime(29);
			}

			return tbl_payMas_PAYE_TaxTable_1;
		}
		/// <summary>
		/// This makes tbl_payMas_PAYE_TaxTable_1 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payMas_PAYE_TaxTable_1 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payMas_PAYE_TaxTable_1  tbl_payMas_PAYE_TaxTable_1   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tax_table_ID = new DataColumn("tax_table_ID" , typeof(string));
			DataColumn col_tax_tableCode = new DataColumn("tax_tableCode" , typeof(string));
			DataColumn col_tax_tableName = new DataColumn("tax_tableName" , typeof(string));
			DataColumn col_tax_StartRange = new DataColumn("tax_StartRange" , typeof(decimal));
			DataColumn col_tax_EndRange = new DataColumn("tax_EndRange" , typeof(decimal));
			DataColumn col_tax_Rate = new DataColumn("tax_Rate" , typeof(decimal));
			DataColumn col_cola_Amt = new DataColumn("cola_Amt" , typeof(decimal));
			DataColumn col_startDate = new DataColumn("startDate" , typeof(DateTime));
			DataColumn col_endDate = new DataColumn("endDate" , typeof(DateTime));
			DataColumn col_glcode_CR = new DataColumn("glcode_CR" , typeof(string));
			DataColumn col_glcode_DR = new DataColumn("glcode_DR" , typeof(string));
			DataColumn col_status = new DataColumn("status" , typeof(int));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Checked = new DataColumn("userID_Checked" , typeof(string));
			DataColumn col_userID_Approved = new DataColumn("userID_Approved" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Checked = new DataColumn("terminalID_Checked" , typeof(string));
			DataColumn col_terminalID_Approved = new DataColumn("terminalID_Approved" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Checked = new DataColumn("date_Checked" , typeof(DateTime));
			DataColumn col_date_Approved = new DataColumn("date_Approved" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_tax_table_ID,col_tax_tableCode,col_tax_tableName,col_tax_StartRange,col_tax_EndRange,col_tax_Rate,col_cola_Amt,col_startDate,col_endDate,col_glcode_CR,col_glcode_DR,col_status,col_isChecked,col_isApproved,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Checked,col_userID_Approved,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Checked,col_terminalID_Approved,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Checked,col_date_Approved,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payMas_PAYE_TaxTable_1 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payMas_PAYE_TaxTable_1 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payMas_PAYE_TaxTable_1 user) {
		DataRow drow = dt.NewRow();
		
			drow["tax_table_ID"] = user.tax_table_ID;
			drow["tax_tableCode"] = user.tax_tableCode;
			drow["tax_tableName"] = user.tax_tableName;
			drow["tax_StartRange"] = user.tax_StartRange;
			drow["tax_EndRange"] = user.tax_EndRange;
			drow["tax_Rate"] = user.tax_Rate;
			drow["cola_Amt"] = user.cola_Amt;
			drow["startDate"] = user.startDate;
			drow["endDate"] = user.endDate;
			drow["glcode_CR"] = user.glcode_CR;
			drow["glcode_DR"] = user.glcode_DR;
			drow["status"] = user.status;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Checked"] = user.userID_Checked;
			drow["userID_Approved"] = user.userID_Approved;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Checked"] = user.terminalID_Checked;
			drow["terminalID_Approved"] = user.terminalID_Approved;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Checked"] = user.date_Checked;
			drow["date_Approved"] = user.date_Approved;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
