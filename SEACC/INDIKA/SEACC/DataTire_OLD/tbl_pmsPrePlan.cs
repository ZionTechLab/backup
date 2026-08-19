using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsPrePlan {
		#region Fields
		private string prePlan_ID;
		private DateTime prePlanDate;
		private string remark;
		private string productionJob_ID;
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
		/// Initializes a new instance of the tbl_pmsPrePlan class.
		/// </summary>
		public tbl_pmsPrePlan() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsPrePlan class.
		/// </summary>
		public tbl_pmsPrePlan(string prePlan_ID, DateTime prePlanDate, string remark, string productionJob_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked) {
			this.prePlan_ID = prePlan_ID;
			this.prePlanDate = prePlanDate;
			this.remark = remark;
			this.productionJob_ID = productionJob_ID;
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
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlanDate value.
		/// </summary>
		public DateTime PrePlanDate {
			get { return prePlanDate; }
			set { prePlanDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
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
		/// Saves a record to the tbl_pmsPrePlan table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlanInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prePlanDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
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
 
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@prePlanDate"].Value = prePlanDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
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
		/// Updates a record in the tbl_pmsPrePlan table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlanUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prePlanDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
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
 
 
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@prePlanDate"].Value = prePlanDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
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
		/// Deletes a record from the tbl_pmsPrePlan table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlanDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan table by a foreign key.
		/// </summary>
		public static void DeleteAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlanDeleteAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsPrePlan table.
		/// </summary>
		public static tbl_pmsPrePlan Select(string prePlan_ID_Incoming){

			tbl_pmsPrePlan tbl_pmsPrePlanins = new tbl_pmsPrePlan();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlanSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsPrePlanins = Maketbl_pmsPrePlan(dataReader);
				} else {
					tbl_pmsPrePlanins = null;
				}
			}
			scon.Close();
			return tbl_pmsPrePlanins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan table.
		/// </summary>
		public static List<tbl_pmsPrePlan> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlanSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsPrePlan> tbl_pmsPrePlanList = new List<tbl_pmsPrePlan>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan tbl_pmsPrePlan = Maketbl_pmsPrePlan(dataReader);
					tbl_pmsPrePlanList.Add(tbl_pmsPrePlan);
				}
			}
			scon.Close();
			return tbl_pmsPrePlanList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan> SelectAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlanSelectAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
				List<tbl_pmsPrePlan> tbl_pmsPrePlanList = new List<tbl_pmsPrePlan>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan tbl_pmsPrePlan = Maketbl_pmsPrePlan(dataReader);
					tbl_pmsPrePlanList.Add(tbl_pmsPrePlan);
				}
			}
			scon.Close();
			return tbl_pmsPrePlanList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsPrePlan class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsPrePlan Maketbl_pmsPrePlan(SqlDataReader dataReader) {
			tbl_pmsPrePlan tbl_pmsPrePlan = new tbl_pmsPrePlan();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsPrePlan.PrePlan_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsPrePlan.PrePlanDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsPrePlan.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsPrePlan.ProductionJob_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsPrePlan.CreateUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsPrePlan.ModifiedUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsPrePlan.CheckedUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsPrePlan.ApprovedUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsPrePlan.DateCreate = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsPrePlan.DateModified = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsPrePlan.DateChecked = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsPrePlan.DateApproved = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsPrePlan.IsChecked = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsPrePlan.IsApproved = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsPrePlan.IsFinished = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pmsPrePlan.IsDeleted = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pmsPrePlan.IsLocked = dataReader.GetBoolean(16);
			}

			return tbl_pmsPrePlan;
		}
		/// <summary>
		/// This makes tbl_pmsPrePlan datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsPrePlan object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsPrePlan  tbl_pmsPrePlan   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_prePlanDate = new DataColumn("prePlanDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_prePlan_ID,col_prePlanDate,col_remark,col_productionJob_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsPrePlan datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsPrePlan object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsPrePlan user) {
		DataRow drow = dt.NewRow();
		
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["prePlanDate"] = user.prePlanDate;
			drow["remark"] = user.remark;
			drow["productionJob_ID"] = user.productionJob_ID;
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
