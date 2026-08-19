using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pcbTxExpenditure {
		#region Fields
		private string expenditure_ID;
		private DateTime expenditureDate;
		private string pcbAccount_ID;
		private string spentUser_ID;
		private string cost_Center_ID;
		private string remarks;
		private decimal totalAmount;
		private decimal allocatedAmount;
		private string reimbursment_ID;
		private bool isReimburst;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string canceldUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateCanceled;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string canceledUserTerminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxExpenditure class.
		/// </summary>
		public tbl_pcbTxExpenditure() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxExpenditure class.
		/// </summary>
		public tbl_pcbTxExpenditure(string expenditure_ID, DateTime expenditureDate, string pcbAccount_ID, string spentUser_ID, string cost_Center_ID, string remarks, decimal totalAmount, decimal allocatedAmount, string reimbursment_ID, bool isReimburst, bool isCanceled, string createUser_ID, string modifiedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string canceledUserTerminal_ID) {
			this.expenditure_ID = expenditure_ID;
			this.expenditureDate = expenditureDate;
			this.pcbAccount_ID = pcbAccount_ID;
			this.spentUser_ID = spentUser_ID;
			this.cost_Center_ID = cost_Center_ID;
			this.remarks = remarks;
			this.totalAmount = totalAmount;
			this.allocatedAmount = allocatedAmount;
			this.reimbursment_ID = reimbursment_ID;
			this.isReimburst = isReimburst;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateCanceled = dateCanceled;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
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
		/// Gets or sets the ExpenditureDate value.
		/// </summary>
		public DateTime ExpenditureDate {
			get { return expenditureDate; }
			set { expenditureDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PcbAccount_ID value.
		/// </summary>
		public string PcbAccount_ID {
			get { return pcbAccount_ID; }
			set { pcbAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SpentUser_ID value.
		/// </summary>
		public string SpentUser_ID {
			get { return spentUser_ID; }
			set { spentUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center_ID value.
		/// </summary>
		public string Cost_Center_ID {
			get { return cost_Center_ID; }
			set { cost_Center_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllocatedAmount value.
		/// </summary>
		public decimal AllocatedAmount {
			get { return allocatedAmount; }
			set { allocatedAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Reimbursment_ID value.
		/// </summary>
		public string Reimbursment_ID {
			get { return reimbursment_ID; }
			set { reimbursment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReimburst value.
		/// </summary>
		public bool IsReimburst {
			get { return isReimburst; }
			set { isReimburst = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceldUser_ID value.
		/// </summary>
		public string CanceldUser_ID {
			get { return canceldUser_ID; }
			set { canceldUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCanceled value.
		/// </summary>
		public DateTime DateCanceled {
			get { return dateCanceled; }
			set { dateCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUserTerminal_ID value.
		/// </summary>
		public string CreateUserTerminal_ID {
			get { return createUserTerminal_ID; }
			set { createUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUserTerminal_ID value.
		/// </summary>
		public string ModifiedUserTerminal_ID {
			get { return modifiedUserTerminal_ID; }
			set { modifiedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceledUserTerminal_ID value.
		/// </summary>
		public string CanceledUserTerminal_ID {
			get { return canceledUserTerminal_ID; }
			set { canceledUserTerminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pcbTxExpenditure table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditureInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@ExpenditureDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@spentUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocatedAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Reimbursment_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isReimburst", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
			scom.Parameters["@ExpenditureDate"].Value = expenditureDate;
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@spentUser_ID"].Value = spentUser_ID;
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@allocatedAmount"].Value = allocatedAmount;
			scom.Parameters["@Reimbursment_ID"].Value = reimbursment_ID;
			scom.Parameters["@isReimburst"].Value = isReimburst;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pcbTxExpenditure table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditureUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@ExpenditureDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@spentUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allocatedAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Reimbursment_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isReimburst", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
			scom.Parameters["@ExpenditureDate"].Value = expenditureDate;
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@spentUser_ID"].Value = spentUser_ID;
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@allocatedAmount"].Value = allocatedAmount;
			scom.Parameters["@Reimbursment_ID"].Value = reimbursment_ID;
			scom.Parameters["@isReimburst"].Value = isReimburst;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pcbTxExpenditure table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditureDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxExpenditure table by a foreign key.
		/// </summary>
		public static void DeleteAllBySpentUser_ID(string spentUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditureDeleteAllBySpentUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@spentUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@spentUser_ID"].Value = spentUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbTxExpenditure table.
		/// </summary>
		public static tbl_pcbTxExpenditure Select(string expenditure_ID_Incoming){

			tbl_pcbTxExpenditure tbl_pcbTxExpenditureins = new tbl_pcbTxExpenditure();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditureSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbTxExpenditureins = Maketbl_pcbTxExpenditure(dataReader);
				} else {
					tbl_pcbTxExpenditureins = null;
				}
			}
			scon.Close();
			return tbl_pcbTxExpenditureins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxExpenditure table.
		/// </summary>
		public static List<tbl_pcbTxExpenditure> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditureSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbTxExpenditure> tbl_pcbTxExpenditureList = new List<tbl_pcbTxExpenditure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxExpenditure tbl_pcbTxExpenditure = Maketbl_pcbTxExpenditure(dataReader);
					tbl_pcbTxExpenditureList.Add(tbl_pcbTxExpenditure);
				}
			}
			scon.Close();
			return tbl_pcbTxExpenditureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxExpenditure table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxExpenditure> SelectAllBySpentUser_ID(string spentUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditureSelectAllBySpentUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@spentUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@spentUser_ID"].Value = spentUser_ID;
				List<tbl_pcbTxExpenditure> tbl_pcbTxExpenditureList = new List<tbl_pcbTxExpenditure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxExpenditure tbl_pcbTxExpenditure = Maketbl_pcbTxExpenditure(dataReader);
					tbl_pcbTxExpenditureList.Add(tbl_pcbTxExpenditure);
				}
			}
			scon.Close();
			return tbl_pcbTxExpenditureList;
		}

        /// <summary>
        ///  /// Selects all records from the tbl_pcbTxExpenditure table by a foreign key.
        /// </summary>
        public static List<tbl_pcbTxExpenditure> SelectAllByPcbAccount_ID(string pcbAccount_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_pcbTxExpenditureSelectAllByPcbAccount_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
            List<tbl_pcbTxExpenditure> tbl_pcbTxExpenditureList = new List<tbl_pcbTxExpenditure>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_pcbTxExpenditure tbl_pcbTxExpenditure = Maketbl_pcbTxExpenditure(dataReader);
                    tbl_pcbTxExpenditureList.Add(tbl_pcbTxExpenditure);
                }
            }
            scon.Close();
            return tbl_pcbTxExpenditureList;
        }
        /// Creates a new instance of the tbl_pcbTxExpenditure class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_pcbTxExpenditure Maketbl_pcbTxExpenditure(SqlDataReader dataReader) {
			tbl_pcbTxExpenditure tbl_pcbTxExpenditure = new tbl_pcbTxExpenditure();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbTxExpenditure.Expenditure_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbTxExpenditure.ExpenditureDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbTxExpenditure.PcbAccount_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbTxExpenditure.SpentUser_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbTxExpenditure.Cost_Center_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pcbTxExpenditure.Remarks = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pcbTxExpenditure.TotalAmount = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pcbTxExpenditure.AllocatedAmount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pcbTxExpenditure.Reimbursment_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pcbTxExpenditure.IsReimburst = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pcbTxExpenditure.IsCanceled = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pcbTxExpenditure.CreateUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pcbTxExpenditure.ModifiedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pcbTxExpenditure.CanceldUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pcbTxExpenditure.DateCreate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pcbTxExpenditure.DateModified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pcbTxExpenditure.DateCanceled = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pcbTxExpenditure.CreateUserTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pcbTxExpenditure.ModifiedUserTerminal_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_pcbTxExpenditure.CanceledUserTerminal_ID = dataReader.GetString(19);
			}

			return tbl_pcbTxExpenditure;
		}
		/// <summary>
		/// This makes tbl_pcbTxExpenditure datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbTxExpenditure object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbTxExpenditure  tbl_pcbTxExpenditure   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_Expenditure_ID = new DataColumn("Expenditure_ID" , typeof(string));
			DataColumn col_ExpenditureDate = new DataColumn("ExpenditureDate" , typeof(DateTime));
			DataColumn col_pcbAccount_ID = new DataColumn("pcbAccount_ID" , typeof(string));
			DataColumn col_spentUser_ID = new DataColumn("spentUser_ID" , typeof(string));
			DataColumn col_cost_Center_ID = new DataColumn("cost_Center_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_allocatedAmount = new DataColumn("allocatedAmount" , typeof(decimal));
			DataColumn col_Reimbursment_ID = new DataColumn("Reimbursment_ID" , typeof(string));
			DataColumn col_isReimburst = new DataColumn("isReimburst" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_Expenditure_ID,col_ExpenditureDate,col_pcbAccount_ID,col_spentUser_ID,col_cost_Center_ID,col_remarks,col_totalAmount,col_allocatedAmount,col_Reimbursment_ID,col_isReimburst,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_canceledUserTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbTxExpenditure datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbTxExpenditure object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbTxExpenditure user) {
		DataRow drow = dt.NewRow();
		
			drow["Expenditure_ID"] = user.Expenditure_ID;
			drow["ExpenditureDate"] = user.ExpenditureDate;
			drow["pcbAccount_ID"] = user.pcbAccount_ID;
			drow["spentUser_ID"] = user.spentUser_ID;
			drow["cost_Center_ID"] = user.cost_Center_ID;
			drow["remarks"] = user.remarks;
			drow["totalAmount"] = user.totalAmount;
			drow["allocatedAmount"] = user.allocatedAmount;
			drow["Reimbursment_ID"] = user.Reimbursment_ID;
			drow["isReimburst"] = user.isReimburst;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateCanceled"] = user.dateCanceled;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
