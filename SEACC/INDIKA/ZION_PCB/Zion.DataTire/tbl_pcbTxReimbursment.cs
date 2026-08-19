using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pcbTxReimbursment {
		#region Fields
		private string reimbursment_ID;
		private DateTime reimbursmentDate;
		private string pcbAccount_ID;
		private DateTime reimbursmentTo;
		private decimal noOfExpences;
		private decimal totalAmount;
		private bool isApproved;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string approvedUser_ID;
		private string canceldUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateApproved;
		private DateTime dateCanceled;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string approvedUserTerminal_ID;
		private string canceledUserTerminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxReimbursment class.
		/// </summary>
		public tbl_pcbTxReimbursment() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxReimbursment class.
		/// </summary>
		public tbl_pcbTxReimbursment(string reimbursment_ID, DateTime reimbursmentDate, string pcbAccount_ID, DateTime reimbursmentTo, decimal noOfExpences, decimal totalAmount, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID) {
			this.reimbursment_ID = reimbursment_ID;
			this.reimbursmentDate = reimbursmentDate;
			this.pcbAccount_ID = pcbAccount_ID;
			this.reimbursmentTo = reimbursmentTo;
			this.noOfExpences = noOfExpences;
			this.totalAmount = totalAmount;
			this.isApproved = isApproved;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateApproved = dateApproved;
			this.dateCanceled = dateCanceled;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.approvedUserTerminal_ID = approvedUserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Reimbursment_ID value.
		/// </summary>
		public string Reimbursment_ID {
			get { return reimbursment_ID; }
			set { reimbursment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReimbursmentDate value.
		/// </summary>
		public DateTime ReimbursmentDate {
			get { return reimbursmentDate; }
			set { reimbursmentDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PcbAccount_ID value.
		/// </summary>
		public string PcbAccount_ID {
			get { return pcbAccount_ID; }
			set { pcbAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReimbursmentTo value.
		/// </summary>
		public DateTime ReimbursmentTo {
			get { return reimbursmentTo; }
			set { reimbursmentTo = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoOfExpences value.
		/// </summary>
		public decimal NoOfExpences {
			get { return noOfExpences; }
			set { noOfExpences = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
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
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
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
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime DateApproved {
			get { return dateApproved; }
			set { dateApproved = value; }
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
		/// Gets or sets the ApprovedUserTerminal_ID value.
		/// </summary>
		public string ApprovedUserTerminal_ID {
			get { return approvedUserTerminal_ID; }
			set { approvedUserTerminal_ID = value; }
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
		/// Saves a record to the tbl_pcbTxReimbursment table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxReimbursmentInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@Reimbursment_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@ReimbursmentDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@ReimbursmentTo", SqlDbType.DateTime,8);
			scom.Parameters.Add("@noOfExpences", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@Reimbursment_ID"].Value = reimbursment_ID;
			scom.Parameters["@ReimbursmentDate"].Value = reimbursmentDate;
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@ReimbursmentTo"].Value = reimbursmentTo;
			scom.Parameters["@noOfExpences"].Value = noOfExpences;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pcbTxReimbursment table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxReimbursmentUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@Reimbursment_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@ReimbursmentDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@ReimbursmentTo", SqlDbType.DateTime,8);
			scom.Parameters.Add("@noOfExpences", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@Reimbursment_ID"].Value = reimbursment_ID;
			scom.Parameters["@ReimbursmentDate"].Value = reimbursmentDate;
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@ReimbursmentTo"].Value = reimbursmentTo;
			scom.Parameters["@noOfExpences"].Value = noOfExpences;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pcbTxReimbursment table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxReimbursmentDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@Reimbursment_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Reimbursment_ID"].Value = reimbursment_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxReimbursment table by a foreign key.
		/// </summary>
		public static void DeleteAllByPcbAccount_ID(string pcbAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxReimbursmentDeleteAllByPcbAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbTxReimbursment table.
		/// </summary>
		public static tbl_pcbTxReimbursment Select(string reimbursment_ID_Incoming){

			tbl_pcbTxReimbursment tbl_pcbTxReimbursmentins = new tbl_pcbTxReimbursment();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxReimbursmentSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@Reimbursment_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Reimbursment_ID"].Value = reimbursment_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbTxReimbursmentins = Maketbl_pcbTxReimbursment(dataReader);
				} else {
					tbl_pcbTxReimbursmentins = null;
				}
			}
			scon.Close();
			return tbl_pcbTxReimbursmentins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxReimbursment table.
		/// </summary>
		public static List<tbl_pcbTxReimbursment> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxReimbursmentSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbTxReimbursment> tbl_pcbTxReimbursmentList = new List<tbl_pcbTxReimbursment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxReimbursment tbl_pcbTxReimbursment = Maketbl_pcbTxReimbursment(dataReader);
					tbl_pcbTxReimbursmentList.Add(tbl_pcbTxReimbursment);
				}
			}
			scon.Close();
			return tbl_pcbTxReimbursmentList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxReimbursment table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxReimbursment> SelectAllByPcbAccount_ID(string pcbAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxReimbursmentSelectAllByPcbAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
				List<tbl_pcbTxReimbursment> tbl_pcbTxReimbursmentList = new List<tbl_pcbTxReimbursment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxReimbursment tbl_pcbTxReimbursment = Maketbl_pcbTxReimbursment(dataReader);
					tbl_pcbTxReimbursmentList.Add(tbl_pcbTxReimbursment);
				}
			}
			scon.Close();
			return tbl_pcbTxReimbursmentList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbTxReimbursment class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbTxReimbursment Maketbl_pcbTxReimbursment(SqlDataReader dataReader) {
			tbl_pcbTxReimbursment tbl_pcbTxReimbursment = new tbl_pcbTxReimbursment();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbTxReimbursment.Reimbursment_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbTxReimbursment.ReimbursmentDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbTxReimbursment.PcbAccount_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbTxReimbursment.ReimbursmentTo = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbTxReimbursment.NoOfExpences = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pcbTxReimbursment.TotalAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pcbTxReimbursment.IsApproved = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pcbTxReimbursment.IsCanceled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pcbTxReimbursment.CreateUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pcbTxReimbursment.ModifiedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pcbTxReimbursment.ApprovedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pcbTxReimbursment.CanceldUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pcbTxReimbursment.DateCreate = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pcbTxReimbursment.DateModified = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pcbTxReimbursment.DateApproved = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pcbTxReimbursment.DateCanceled = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pcbTxReimbursment.CreateUserTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pcbTxReimbursment.ModifiedUserTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pcbTxReimbursment.ApprovedUserTerminal_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_pcbTxReimbursment.CanceledUserTerminal_ID = dataReader.GetString(19);
			}

			return tbl_pcbTxReimbursment;
		}
		/// <summary>
		/// This makes tbl_pcbTxReimbursment datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbTxReimbursment object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbTxReimbursment  tbl_pcbTxReimbursment   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_Reimbursment_ID = new DataColumn("Reimbursment_ID" , typeof(string));
			DataColumn col_ReimbursmentDate = new DataColumn("ReimbursmentDate" , typeof(DateTime));
			DataColumn col_pcbAccount_ID = new DataColumn("pcbAccount_ID" , typeof(string));
			DataColumn col_ReimbursmentTo = new DataColumn("ReimbursmentTo" , typeof(DateTime));
			DataColumn col_noOfExpences = new DataColumn("noOfExpences" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_approvedUserTerminal_ID = new DataColumn("approvedUserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_Reimbursment_ID,col_ReimbursmentDate,col_pcbAccount_ID,col_ReimbursmentTo,col_noOfExpences,col_totalAmount,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbTxReimbursment datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbTxReimbursment object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbTxReimbursment user) {
		DataRow drow = dt.NewRow();
		
			drow["Reimbursment_ID"] = user.Reimbursment_ID;
			drow["ReimbursmentDate"] = user.ReimbursmentDate;
			drow["pcbAccount_ID"] = user.pcbAccount_ID;
			drow["ReimbursmentTo"] = user.ReimbursmentTo;
			drow["noOfExpences"] = user.noOfExpences;
			drow["totalAmount"] = user.totalAmount;
			drow["isApproved"] = user.isApproved;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateApproved"] = user.dateApproved;
			drow["dateCanceled"] = user.dateCanceled;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["approvedUserTerminal_ID"] = user.approvedUserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
