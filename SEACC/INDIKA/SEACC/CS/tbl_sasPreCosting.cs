using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasPreCosting {
		#region Fields
		private string preCosting_ID;
		private DateTime preCostingDate;
		private string remark;
		private string job_ID;
		private decimal costMaterial;
		private decimal costMachine;
		private decimal costLabour;
		private decimal costOther;
		private decimal costTotal;
		private decimal rejectionCost;
		private decimal rejectionCostPercentage;
		private decimal kiloPrice;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting class.
		/// </summary>
		public tbl_sasPreCosting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting class.
		/// </summary>
		public tbl_sasPreCosting(string preCosting_ID, DateTime preCostingDate, string remark, string job_ID, decimal costMaterial, decimal costMachine, decimal costLabour, decimal costOther, decimal costTotal, decimal rejectionCost, decimal rejectionCostPercentage, decimal kiloPrice, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked) {
			this.preCosting_ID = preCosting_ID;
			this.preCostingDate = preCostingDate;
			this.remark = remark;
			this.job_ID = job_ID;
			this.costMaterial = costMaterial;
			this.costMachine = costMachine;
			this.costLabour = costLabour;
			this.costOther = costOther;
			this.costTotal = costTotal;
			this.rejectionCost = rejectionCost;
			this.rejectionCostPercentage = rejectionCostPercentage;
			this.kiloPrice = kiloPrice;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PreCosting_ID value.
		/// </summary>
		public string PreCosting_ID {
			get { return preCosting_ID; }
			set { preCosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreCostingDate value.
		/// </summary>
		public DateTime PreCostingDate {
			get { return preCostingDate; }
			set { preCostingDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostMaterial value.
		/// </summary>
		public decimal CostMaterial {
			get { return costMaterial; }
			set { costMaterial = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostMachine value.
		/// </summary>
		public decimal CostMachine {
			get { return costMachine; }
			set { costMachine = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostLabour value.
		/// </summary>
		public decimal CostLabour {
			get { return costLabour; }
			set { costLabour = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostOther value.
		/// </summary>
		public decimal CostOther {
			get { return costOther; }
			set { costOther = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostTotal value.
		/// </summary>
		public decimal CostTotal {
			get { return costTotal; }
			set { costTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the RejectionCost value.
		/// </summary>
		public decimal RejectionCost {
			get { return rejectionCost; }
			set { rejectionCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the RejectionCostPercentage value.
		/// </summary>
		public decimal RejectionCostPercentage {
			get { return rejectionCostPercentage; }
			set { rejectionCostPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the KiloPrice value.
		/// </summary>
		public decimal KiloPrice {
			get { return kiloPrice; }
			set { kiloPrice = value; }
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
		/// Gets or sets the IsFinished value.
		/// </summary>
		public bool IsFinished {
			get { return isFinished; }
			set { isFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasPreCosting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCostingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@preCostingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costMaterial", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costMachine", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costLabour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costOther", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rejectionCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rejectionCostPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@preCostingDate"].Value = preCostingDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@costMaterial"].Value = costMaterial;
			scom.Parameters["@costMachine"].Value = costMachine;
			scom.Parameters["@costLabour"].Value = costLabour;
			scom.Parameters["@costOther"].Value = costOther;
			scom.Parameters["@costTotal"].Value = costTotal;
			scom.Parameters["@rejectionCost"].Value = rejectionCost;
			scom.Parameters["@rejectionCostPercentage"].Value = rejectionCostPercentage;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasPreCosting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCostingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@preCostingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costMaterial", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costMachine", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costLabour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costOther", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rejectionCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rejectionCostPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
 
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@preCostingDate"].Value = preCostingDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@costMaterial"].Value = costMaterial;
			scom.Parameters["@costMachine"].Value = costMachine;
			scom.Parameters["@costLabour"].Value = costLabour;
			scom.Parameters["@costOther"].Value = costOther;
			scom.Parameters["@costTotal"].Value = costTotal;
			scom.Parameters["@rejectionCost"].Value = rejectionCost;
			scom.Parameters["@rejectionCostPercentage"].Value = rejectionCostPercentage;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasPreCosting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCostingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCostingDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasPreCosting table.
		/// </summary>
		public static tbl_sasPreCosting Select(string preCosting_ID_Incoming){

			tbl_sasPreCosting tbl_sasPreCostingins = new tbl_sasPreCosting();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCostingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasPreCostingins = Maketbl_sasPreCosting(dataReader);
				} else {
					tbl_sasPreCostingins = null;
				}
			}
			scon.Close();
			return tbl_sasPreCostingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting table.
		/// </summary>
		public static List<tbl_sasPreCosting> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCostingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasPreCosting> tbl_sasPreCostingList = new List<tbl_sasPreCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting tbl_sasPreCosting = Maketbl_sasPreCosting(dataReader);
					tbl_sasPreCostingList.Add(tbl_sasPreCosting);
				}
			}
			scon.Close();
			return tbl_sasPreCostingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCostingSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_sasPreCosting> tbl_sasPreCostingList = new List<tbl_sasPreCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting tbl_sasPreCosting = Maketbl_sasPreCosting(dataReader);
					tbl_sasPreCostingList.Add(tbl_sasPreCosting);
				}
			}
			scon.Close();
			return tbl_sasPreCostingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasPreCosting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasPreCosting Maketbl_sasPreCosting(SqlDataReader dataReader) {
			tbl_sasPreCosting tbl_sasPreCosting = new tbl_sasPreCosting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasPreCosting.PreCosting_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasPreCosting.PreCostingDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasPreCosting.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasPreCosting.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasPreCosting.CostMaterial = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasPreCosting.CostMachine = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasPreCosting.CostLabour = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasPreCosting.CostOther = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasPreCosting.CostTotal = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasPreCosting.RejectionCost = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasPreCosting.RejectionCostPercentage = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasPreCosting.KiloPrice = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasPreCosting.CreateUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasPreCosting.ModifiedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasPreCosting.CheckedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasPreCosting.ApprovedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasPreCosting.DateCreate = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasPreCosting.DateModified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasPreCosting.DateChecked = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasPreCosting.DateApproved = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasPreCosting.IsChecked = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasPreCosting.IsApproved = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasPreCosting.IsFinished = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasPreCosting.IsDeleted = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasPreCosting.IsLocked = dataReader.GetBoolean(24);
			}

			return tbl_sasPreCosting;
		}
		/// <summary>
		/// This makes tbl_sasPreCosting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasPreCosting  tbl_sasPreCosting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_preCosting_ID = new DataColumn("preCosting_ID" , typeof(string));
			DataColumn col_preCostingDate = new DataColumn("preCostingDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_costMaterial = new DataColumn("costMaterial" , typeof(decimal));
			DataColumn col_costMachine = new DataColumn("costMachine" , typeof(decimal));
			DataColumn col_costLabour = new DataColumn("costLabour" , typeof(decimal));
			DataColumn col_costOther = new DataColumn("costOther" , typeof(decimal));
			DataColumn col_costTotal = new DataColumn("costTotal" , typeof(decimal));
			DataColumn col_rejectionCost = new DataColumn("rejectionCost" , typeof(decimal));
			DataColumn col_rejectionCostPercentage = new DataColumn("rejectionCostPercentage" , typeof(decimal));
			DataColumn col_kiloPrice = new DataColumn("kiloPrice" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_preCosting_ID,col_preCostingDate,col_remark,col_job_ID,col_costMaterial,col_costMachine,col_costLabour,col_costOther,col_costTotal,col_rejectionCost,col_rejectionCostPercentage,col_kiloPrice,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasPreCosting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasPreCosting user) {
		DataRow drow = dt.NewRow();
		
			drow["preCosting_ID"] = user.preCosting_ID;
			drow["preCostingDate"] = user.preCostingDate;
			drow["remark"] = user.remark;
			drow["job_ID"] = user.job_ID;
			drow["costMaterial"] = user.costMaterial;
			drow["costMachine"] = user.costMachine;
			drow["costLabour"] = user.costLabour;
			drow["costOther"] = user.costOther;
			drow["costTotal"] = user.costTotal;
			drow["rejectionCost"] = user.rejectionCost;
			drow["rejectionCostPercentage"] = user.rejectionCostPercentage;
			drow["kiloPrice"] = user.kiloPrice;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
