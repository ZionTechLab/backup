using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasEmployeeCategory {
		#region Fields
		private string empCatagory_ID;
		private string description;
		private bool isDelete;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string deletedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeCategory class.
		/// </summary>
		public tbl_tasEmployeeCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeCategory class.
		/// </summary>
		public tbl_tasEmployeeCategory(string empCatagory_ID, string description, bool isDelete, string createUser_ID, string modifiedUser_ID, string deletedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDeleted) {
			this.empCatagory_ID = empCatagory_ID;
			this.description = description;
			this.isDelete = isDelete;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.deletedUser_ID = deletedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateDeleted = dateDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the EmpCatagory_ID value.
		/// </summary>
		public string EmpCatagory_ID {
			get { return empCatagory_ID; }
			set { empCatagory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelete value.
		/// </summary>
		public bool IsDelete {
			get { return isDelete; }
			set { isDelete = value; }
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
		/// Gets or sets the DeletedUser_ID value.
		/// </summary>
		public string DeletedUser_ID {
			get { return deletedUser_ID; }
			set { deletedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedTerminal_ID value.
		/// </summary>
		public string DeletedTerminal_ID {
			get { return deletedTerminal_ID; }
			set { deletedTerminal_ID = value; }
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
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasEmployeeCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@empCatagory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@description", SqlDbType.VarChar,500);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
 
			scom.Parameters["@empCatagory_ID"].Value = empCatagory_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@isDelete"].Value = isDelete;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasEmployeeCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@empCatagory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@description", SqlDbType.VarChar,500);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@empCatagory_ID"].Value = empCatagory_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@isDelete"].Value = isDelete;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasEmployeeCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@empCatagory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@empCatagory_ID"].Value = empCatagory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasEmployeeCategory table.
		/// </summary>
		public static tbl_tasEmployeeCategory Select(string empCatagory_ID_Incoming){

			tbl_tasEmployeeCategory tbl_tasEmployeeCategoryins = new tbl_tasEmployeeCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@empCatagory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@empCatagory_ID"].Value = empCatagory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasEmployeeCategoryins = Maketbl_tasEmployeeCategory(dataReader);
				} else {
					tbl_tasEmployeeCategoryins = null;
				}
			}
			scon.Close();
			return tbl_tasEmployeeCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeCategory table.
		/// </summary>
		public static List<tbl_tasEmployeeCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasEmployeeCategory> tbl_tasEmployeeCategoryList = new List<tbl_tasEmployeeCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeCategory tbl_tasEmployeeCategory = Maketbl_tasEmployeeCategory(dataReader);
					tbl_tasEmployeeCategoryList.Add(tbl_tasEmployeeCategory);
				}
			}
			scon.Close();
			return tbl_tasEmployeeCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasEmployeeCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasEmployeeCategory Maketbl_tasEmployeeCategory(SqlDataReader dataReader) {
			tbl_tasEmployeeCategory tbl_tasEmployeeCategory = new tbl_tasEmployeeCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasEmployeeCategory.EmpCatagory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasEmployeeCategory.Description = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasEmployeeCategory.IsDelete = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasEmployeeCategory.CreateUser_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasEmployeeCategory.ModifiedUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasEmployeeCategory.DeletedUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasEmployeeCategory.CreateTerminal_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasEmployeeCategory.ModifiedTerminal_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasEmployeeCategory.DeletedTerminal_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasEmployeeCategory.DateCreate = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasEmployeeCategory.DateModified = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasEmployeeCategory.DateDeleted = dataReader.GetDateTime(11);
			}

			return tbl_tasEmployeeCategory;
		}
		/// <summary>
		/// This makes tbl_tasEmployeeCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasEmployeeCategory  tbl_tasEmployeeCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_empCatagory_ID = new DataColumn("empCatagory_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_isDelete = new DataColumn("isDelete" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_empCatagory_ID,col_description,col_isDelete,col_createUser_ID,col_modifiedUser_ID,col_deletedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_dateCreate,col_dateModified,col_dateDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasEmployeeCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasEmployeeCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["empCatagory_ID"] = user.empCatagory_ID;
			drow["description"] = user.description;
			drow["isDelete"] = user.isDelete;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["deletedUser_ID"] = user.deletedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateDeleted"] = user.dateDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
