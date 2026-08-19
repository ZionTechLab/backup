using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsFactoringInterest {
		#region Fields
		private string factoringInterest_ID;
		private decimal interest_Credit;
		private decimal interest_Recurse;
		private string factoringAgreement_ID;
		private string createUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string createTerminal_ID;
		private string checkedTerminal_ID;
		private string approvedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateChecked;
		private DateTime dateApproved;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsFactoringInterest class.
		/// </summary>
		public tbl_bpsFactoringInterest() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsFactoringInterest class.
		/// </summary>
		public tbl_bpsFactoringInterest(string factoringInterest_ID, decimal interest_Credit, decimal interest_Recurse, string factoringAgreement_ID, string createUser_ID, string checkedUser_ID, string approvedUser_ID, string createTerminal_ID, string checkedTerminal_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateChecked, DateTime dateApproved) {
			this.factoringInterest_ID = factoringInterest_ID;
			this.interest_Credit = interest_Credit;
			this.interest_Recurse = interest_Recurse;
			this.factoringAgreement_ID = factoringAgreement_ID;
			this.createUser_ID = createUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.checkedTerminal_ID = checkedTerminal_ID;
			this.approvedTerminal_ID = approvedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FactoringInterest_ID value.
		/// </summary>
		public string FactoringInterest_ID {
			get { return factoringInterest_ID; }
			set { factoringInterest_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Interest_Credit value.
		/// </summary>
		public decimal Interest_Credit {
			get { return interest_Credit; }
			set { interest_Credit = value; }
		}
		
		/// <summary>
		/// Gets or sets the Interest_Recurse value.
		/// </summary>
		public decimal Interest_Recurse {
			get { return interest_Recurse; }
			set { interest_Recurse = value; }
		}
		
		/// <summary>
		/// Gets or sets the FactoringAgreement_ID value.
		/// </summary>
		public string FactoringAgreement_ID {
			get { return factoringAgreement_ID; }
			set { factoringAgreement_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedTerminal_ID value.
		/// </summary>
		public string CheckedTerminal_ID {
			get { return checkedTerminal_ID; }
			set { checkedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedTerminal_ID value.
		/// </summary>
		public string ApprovedTerminal_ID {
			get { return approvedTerminal_ID; }
			set { approvedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateChecked value.
		/// </summary>
		public DateTime DateChecked {
			get { return dateChecked; }
			set { dateChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime DateApproved {
			get { return dateApproved; }
			set { dateApproved = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsFactoringInterest table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringInterestInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@factoringInterest_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Interest_Credit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Interest_Recurse", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
 
			scom.Parameters["@factoringInterest_ID"].Value = factoringInterest_ID;
			scom.Parameters["@Interest_Credit"].Value = interest_Credit;
			scom.Parameters["@Interest_Recurse"].Value = interest_Recurse;
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsFactoringInterest table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringInterestUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@factoringInterest_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Interest_Credit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Interest_Recurse", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@factoringInterest_ID"].Value = factoringInterest_ID;
			scom.Parameters["@Interest_Credit"].Value = interest_Credit;
			scom.Parameters["@Interest_Recurse"].Value = interest_Recurse;
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsFactoringInterest table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringInterestDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@factoringInterest_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringInterest_ID"].Value = factoringInterest_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsFactoringInterest table.
		/// </summary>
		public static tbl_bpsFactoringInterest Select(string factoringInterest_ID_Incoming){

			tbl_bpsFactoringInterest tbl_bpsFactoringInterestins = new tbl_bpsFactoringInterest();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringInterestSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringInterest_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringInterest_ID"].Value = factoringInterest_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsFactoringInterestins = Maketbl_bpsFactoringInterest(dataReader);
				} else {
					tbl_bpsFactoringInterestins = null;
				}
			}
			scon.Close();
			return tbl_bpsFactoringInterestins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringInterest table.
		/// </summary>
		public static List<tbl_bpsFactoringInterest> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringInterestSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsFactoringInterest> tbl_bpsFactoringInterestList = new List<tbl_bpsFactoringInterest>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringInterest tbl_bpsFactoringInterest = Maketbl_bpsFactoringInterest(dataReader);
					tbl_bpsFactoringInterestList.Add(tbl_bpsFactoringInterest);
				}
			}
			scon.Close();
			return tbl_bpsFactoringInterestList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsFactoringInterest class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsFactoringInterest Maketbl_bpsFactoringInterest(SqlDataReader dataReader) {
			tbl_bpsFactoringInterest tbl_bpsFactoringInterest = new tbl_bpsFactoringInterest();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsFactoringInterest.FactoringInterest_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsFactoringInterest.Interest_Credit = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsFactoringInterest.Interest_Recurse = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsFactoringInterest.FactoringAgreement_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsFactoringInterest.CreateUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsFactoringInterest.CheckedUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsFactoringInterest.ApprovedUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsFactoringInterest.CreateTerminal_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsFactoringInterest.CheckedTerminal_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsFactoringInterest.ApprovedTerminal_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsFactoringInterest.DateCreate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsFactoringInterest.DateChecked = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsFactoringInterest.DateApproved = dataReader.GetDateTime(12);
			}

			return tbl_bpsFactoringInterest;
		}
		/// <summary>
		/// This makes tbl_bpsFactoringInterest datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsFactoringInterest object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsFactoringInterest  tbl_bpsFactoringInterest   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_factoringInterest_ID = new DataColumn("factoringInterest_ID" , typeof(string));
			DataColumn col_Interest_Credit = new DataColumn("Interest_Credit" , typeof(decimal));
			DataColumn col_Interest_Recurse = new DataColumn("Interest_Recurse" , typeof(decimal));
			DataColumn col_factoringAgreement_ID = new DataColumn("factoringAgreement_ID" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_checkedTerminal_ID = new DataColumn("checkedTerminal_ID" , typeof(string));
			DataColumn col_approvedTerminal_ID = new DataColumn("approvedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_factoringInterest_ID,col_Interest_Credit,col_Interest_Recurse,col_factoringAgreement_ID,col_createUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_createTerminal_ID,col_checkedTerminal_ID,col_approvedTerminal_ID,col_dateCreate,col_dateChecked,col_dateApproved,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsFactoringInterest datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsFactoringInterest object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsFactoringInterest user) {
		DataRow drow = dt.NewRow();
		
			drow["factoringInterest_ID"] = user.factoringInterest_ID;
			drow["Interest_Credit"] = user.Interest_Credit;
			drow["Interest_Recurse"] = user.Interest_Recurse;
			drow["factoringAgreement_ID"] = user.factoringAgreement_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["checkedTerminal_ID"] = user.checkedTerminal_ID;
			drow["approvedTerminal_ID"] = user.approvedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
