using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityFunctionMaster_Permission {
		#region Fields
		private string companyBranch_ID;
		private string user_ID;
		private int function_ID;
		private bool allowRead;
		private bool allowWrite;
		private bool allowDelete;
		private bool allowApprovable;
		private bool allowCheckable;
		private bool allowUpdate;
		private bool allowPrint;
		private bool allowRePrint;
		private bool allowExport;
		private bool allowView;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Permission class.
		/// </summary>
		public tbl_securityFunctionMaster_Permission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Permission class.
		/// </summary>
		public tbl_securityFunctionMaster_Permission(string companyBranch_ID, string user_ID, int function_ID, bool allowRead, bool allowWrite, bool allowDelete, bool allowApprovable, bool allowCheckable, bool allowUpdate, bool allowPrint, bool allowRePrint, bool allowExport, bool allowView) {
			this.companyBranch_ID = companyBranch_ID;
			this.user_ID = user_ID;
			this.function_ID = function_ID;
			this.allowRead = allowRead;
			this.allowWrite = allowWrite;
			this.allowDelete = allowDelete;
			this.allowApprovable = allowApprovable;
			this.allowCheckable = allowCheckable;
			this.allowUpdate = allowUpdate;
			this.allowPrint = allowPrint;
			this.allowRePrint = allowRePrint;
			this.allowExport = allowExport;
			this.allowView = allowView;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Function_ID value.
		/// </summary>
		public int Function_ID {
			get { return function_ID; }
			set { function_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowRead value.
		/// </summary>
		public bool AllowRead {
			get { return allowRead; }
			set { allowRead = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowWrite value.
		/// </summary>
		public bool AllowWrite {
			get { return allowWrite; }
			set { allowWrite = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowDelete value.
		/// </summary>
		public bool AllowDelete {
			get { return allowDelete; }
			set { allowDelete = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowApprovable value.
		/// </summary>
		public bool AllowApprovable {
			get { return allowApprovable; }
			set { allowApprovable = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowCheckable value.
		/// </summary>
		public bool AllowCheckable {
			get { return allowCheckable; }
			set { allowCheckable = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowUpdate value.
		/// </summary>
		public bool AllowUpdate {
			get { return allowUpdate; }
			set { allowUpdate = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowPrint value.
		/// </summary>
		public bool AllowPrint {
			get { return allowPrint; }
			set { allowPrint = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowRePrint value.
		/// </summary>
		public bool AllowRePrint {
			get { return allowRePrint; }
			set { allowRePrint = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowExport value.
		/// </summary>
		public bool AllowExport {
			get { return allowExport; }
			set { allowExport = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowView value.
		/// </summary>
		public bool AllowView {
			get { return allowView; }
			set { allowView = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityFunctionMaster_Permission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowUpdate", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowPrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowRePrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowExport", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowView", SqlDbType.Bit,1);
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@allowRead"].Value = allowRead;
			scom.Parameters["@allowWrite"].Value = allowWrite;
			scom.Parameters["@allowDelete"].Value = allowDelete;
			scom.Parameters["@allowApprovable"].Value = allowApprovable;
			scom.Parameters["@allowCheckable"].Value = allowCheckable;
			scom.Parameters["@allowUpdate"].Value = allowUpdate;
			scom.Parameters["@allowPrint"].Value = allowPrint;
			scom.Parameters["@allowRePrint"].Value = allowRePrint;
			scom.Parameters["@allowExport"].Value = allowExport;
			scom.Parameters["@allowView"].Value = allowView;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityFunctionMaster_Permission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowUpdate", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowPrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowRePrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowExport", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowView", SqlDbType.Bit,1);
 
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@allowRead"].Value = allowRead;
			scom.Parameters["@allowWrite"].Value = allowWrite;
			scom.Parameters["@allowDelete"].Value = allowDelete;
			scom.Parameters["@allowApprovable"].Value = allowApprovable;
			scom.Parameters["@allowCheckable"].Value = allowCheckable;
			scom.Parameters["@allowUpdate"].Value = allowUpdate;
			scom.Parameters["@allowPrint"].Value = allowPrint;
			scom.Parameters["@allowRePrint"].Value = allowRePrint;
			scom.Parameters["@allowExport"].Value = allowExport;
			scom.Parameters["@allowView"].Value = allowView;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityFunctionMaster_Permission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@function_ID"].Value = function_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionDeleteAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFunctionMaster_Permission table.
		/// </summary>
		public static tbl_securityFunctionMaster_Permission Select(string companyBranch_ID_Incoming, string user_ID_Incoming, int function_ID_Incoming){

			tbl_securityFunctionMaster_Permission tbl_securityFunctionMaster_Permissionins = new tbl_securityFunctionMaster_Permission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@function_ID"].Value = function_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFunctionMaster_Permissionins = Maketbl_securityFunctionMaster_Permission(dataReader);
				} else {
					tbl_securityFunctionMaster_Permissionins = null;
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Permissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Permission table.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Permission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFunctionMaster_Permission> tbl_securityFunctionMaster_PermissionList = new List<tbl_securityFunctionMaster_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Permission tbl_securityFunctionMaster_Permission = Maketbl_securityFunctionMaster_Permission(dataReader);
					tbl_securityFunctionMaster_PermissionList.Add(tbl_securityFunctionMaster_Permission);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Permission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_securityFunctionMaster_Permission> tbl_securityFunctionMaster_PermissionList = new List<tbl_securityFunctionMaster_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Permission tbl_securityFunctionMaster_Permission = Maketbl_securityFunctionMaster_Permission(dataReader);
					tbl_securityFunctionMaster_PermissionList.Add(tbl_securityFunctionMaster_Permission);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Permission> SelectAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionSelectAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
				List<tbl_securityFunctionMaster_Permission> tbl_securityFunctionMaster_PermissionList = new List<tbl_securityFunctionMaster_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Permission tbl_securityFunctionMaster_Permission = Maketbl_securityFunctionMaster_Permission(dataReader);
					tbl_securityFunctionMaster_PermissionList.Add(tbl_securityFunctionMaster_Permission);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Permission> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_PermissionSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_securityFunctionMaster_Permission> tbl_securityFunctionMaster_PermissionList = new List<tbl_securityFunctionMaster_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Permission tbl_securityFunctionMaster_Permission = Maketbl_securityFunctionMaster_Permission(dataReader);
					tbl_securityFunctionMaster_PermissionList.Add(tbl_securityFunctionMaster_Permission);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_PermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFunctionMaster_Permission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFunctionMaster_Permission Maketbl_securityFunctionMaster_Permission(SqlDataReader dataReader) {
			tbl_securityFunctionMaster_Permission tbl_securityFunctionMaster_Permission = new tbl_securityFunctionMaster_Permission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFunctionMaster_Permission.CompanyBranch_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFunctionMaster_Permission.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFunctionMaster_Permission.Function_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityFunctionMaster_Permission.AllowRead = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityFunctionMaster_Permission.AllowWrite = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityFunctionMaster_Permission.AllowDelete = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityFunctionMaster_Permission.AllowApprovable = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityFunctionMaster_Permission.AllowCheckable = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_securityFunctionMaster_Permission.AllowUpdate = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_securityFunctionMaster_Permission.AllowPrint = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_securityFunctionMaster_Permission.AllowRePrint = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_securityFunctionMaster_Permission.AllowExport = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_securityFunctionMaster_Permission.AllowView = dataReader.GetBoolean(12);
			}

			return tbl_securityFunctionMaster_Permission;
		}
		/// <summary>
		/// This makes tbl_securityFunctionMaster_Permission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Permission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFunctionMaster_Permission  tbl_securityFunctionMaster_Permission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_function_ID = new DataColumn("function_ID" , typeof(int));
			DataColumn col_allowRead = new DataColumn("allowRead" , typeof(bool));
			DataColumn col_allowWrite = new DataColumn("allowWrite" , typeof(bool));
			DataColumn col_allowDelete = new DataColumn("allowDelete" , typeof(bool));
			DataColumn col_allowApprovable = new DataColumn("allowApprovable" , typeof(bool));
			DataColumn col_allowCheckable = new DataColumn("allowCheckable" , typeof(bool));
			DataColumn col_allowUpdate = new DataColumn("allowUpdate" , typeof(bool));
			DataColumn col_allowPrint = new DataColumn("allowPrint" , typeof(bool));
			DataColumn col_allowRePrint = new DataColumn("allowRePrint" , typeof(bool));
			DataColumn col_allowExport = new DataColumn("allowExport" , typeof(bool));
			DataColumn col_allowView = new DataColumn("allowView" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_companyBranch_ID,col_user_ID,col_function_ID,col_allowRead,col_allowWrite,col_allowDelete,col_allowApprovable,col_allowCheckable,col_allowUpdate,col_allowPrint,col_allowRePrint,col_allowExport,col_allowView,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFunctionMaster_Permission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Permission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFunctionMaster_Permission user) {
		DataRow drow = dt.NewRow();
		
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["user_ID"] = user.user_ID;
			drow["function_ID"] = user.function_ID;
			drow["allowRead"] = user.allowRead;
			drow["allowWrite"] = user.allowWrite;
			drow["allowDelete"] = user.allowDelete;
			drow["allowApprovable"] = user.allowApprovable;
			drow["allowCheckable"] = user.allowCheckable;
			drow["allowUpdate"] = user.allowUpdate;
			drow["allowPrint"] = user.allowPrint;
			drow["allowRePrint"] = user.allowRePrint;
			drow["allowExport"] = user.allowExport;
			drow["allowView"] = user.allowView;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
