using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityUserRole_Permission {
		#region Fields
		private string userRole_ID;
		private int form_ID;
		private bool allowRead;
		private bool allowWrite;
		private bool allowDelete;
		private bool allowApprovable;
		private bool allowCheckable;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserRole_Permission class.
		/// </summary>
		public tbl_securityUserRole_Permission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserRole_Permission class.
		/// </summary>
		public tbl_securityUserRole_Permission(string userRole_ID, int form_ID, bool allowRead, bool allowWrite, bool allowDelete, bool allowApprovable, bool allowCheckable) {
			this.userRole_ID = userRole_ID;
			this.form_ID = form_ID;
			this.allowRead = allowRead;
			this.allowWrite = allowWrite;
			this.allowDelete = allowDelete;
			this.allowApprovable = allowApprovable;
			this.allowCheckable = allowCheckable;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the UserRole_ID value.
		/// </summary>
		public string UserRole_ID {
			get { return userRole_ID; }
			set { userRole_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityUserRole_Permission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
 
			scom.Parameters["@userRole_ID"].Value = userRole_ID;
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@allowRead"].Value = allowRead;
			scom.Parameters["@allowWrite"].Value = allowWrite;
			scom.Parameters["@allowDelete"].Value = allowDelete;
			scom.Parameters["@allowApprovable"].Value = allowApprovable;
			scom.Parameters["@allowCheckable"].Value = allowCheckable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityUserRole_Permission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
 
 
			scom.Parameters["@userRole_ID"].Value = userRole_ID;
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@allowRead"].Value = allowRead;
			scom.Parameters["@allowWrite"].Value = allowWrite;
			scom.Parameters["@allowDelete"].Value = allowDelete;
			scom.Parameters["@allowApprovable"].Value = allowApprovable;
			scom.Parameters["@allowCheckable"].Value = allowCheckable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityUserRole_Permission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@userRole_ID"].Value = userRole_ID;
 
			scom.Parameters["@form_ID"].Value = form_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserRole_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserRole_ID(string userRole_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionDeleteAllByUserRole_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters["@userRole_ID"].Value = userRole_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserRole_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityUserRole_Permission table.
		/// </summary>
		public static tbl_securityUserRole_Permission Select(string userRole_ID_Incoming, int form_ID_Incoming){

			tbl_securityUserRole_Permission tbl_securityUserRole_Permissionins = new tbl_securityUserRole_Permission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@userRole_ID"].Value = userRole_ID_Incoming;
			scom.Parameters["@form_ID"].Value = form_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityUserRole_Permissionins = Maketbl_securityUserRole_Permission(dataReader);
				} else {
					tbl_securityUserRole_Permissionins = null;
				}
			}
			scon.Close();
			return tbl_securityUserRole_Permissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserRole_Permission table.
		/// </summary>
		public static List<tbl_securityUserRole_Permission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityUserRole_Permission> tbl_securityUserRole_PermissionList = new List<tbl_securityUserRole_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserRole_Permission tbl_securityUserRole_Permission = Maketbl_securityUserRole_Permission(dataReader);
					tbl_securityUserRole_PermissionList.Add(tbl_securityUserRole_Permission);
				}
			}
			scon.Close();
			return tbl_securityUserRole_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserRole_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_securityUserRole_Permission> SelectAllByUserRole_ID(string userRole_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionSelectAllByUserRole_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userRole_ID", SqlDbType.VarChar,20);
			scom.Parameters["@userRole_ID"].Value = userRole_ID;
				List<tbl_securityUserRole_Permission> tbl_securityUserRole_PermissionList = new List<tbl_securityUserRole_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserRole_Permission tbl_securityUserRole_Permission = Maketbl_securityUserRole_Permission(dataReader);
					tbl_securityUserRole_PermissionList.Add(tbl_securityUserRole_Permission);
				}
			}
			scon.Close();
			return tbl_securityUserRole_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserRole_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_securityUserRole_Permission> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserRole_PermissionSelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_securityUserRole_Permission> tbl_securityUserRole_PermissionList = new List<tbl_securityUserRole_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserRole_Permission tbl_securityUserRole_Permission = Maketbl_securityUserRole_Permission(dataReader);
					tbl_securityUserRole_PermissionList.Add(tbl_securityUserRole_Permission);
				}
			}
			scon.Close();
			return tbl_securityUserRole_PermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityUserRole_Permission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityUserRole_Permission Maketbl_securityUserRole_Permission(SqlDataReader dataReader) {
			tbl_securityUserRole_Permission tbl_securityUserRole_Permission = new tbl_securityUserRole_Permission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityUserRole_Permission.UserRole_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityUserRole_Permission.Form_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityUserRole_Permission.AllowRead = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityUserRole_Permission.AllowWrite = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityUserRole_Permission.AllowDelete = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityUserRole_Permission.AllowApprovable = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityUserRole_Permission.AllowCheckable = dataReader.GetBoolean(6);
			}

			return tbl_securityUserRole_Permission;
		}
		/// <summary>
		/// This makes tbl_securityUserRole_Permission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityUserRole_Permission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityUserRole_Permission  tbl_securityUserRole_Permission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_userRole_ID = new DataColumn("userRole_ID" , typeof(string));
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_allowRead = new DataColumn("allowRead" , typeof(bool));
			DataColumn col_allowWrite = new DataColumn("allowWrite" , typeof(bool));
			DataColumn col_allowDelete = new DataColumn("allowDelete" , typeof(bool));
			DataColumn col_allowApprovable = new DataColumn("allowApprovable" , typeof(bool));
			DataColumn col_allowCheckable = new DataColumn("allowCheckable" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_userRole_ID,col_form_ID,col_allowRead,col_allowWrite,col_allowDelete,col_allowApprovable,col_allowCheckable,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityUserRole_Permission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityUserRole_Permission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityUserRole_Permission user) {
		DataRow drow = dt.NewRow();
		
			drow["userRole_ID"] = user.userRole_ID;
			drow["form_ID"] = user.form_ID;
			drow["allowRead"] = user.allowRead;
			drow["allowWrite"] = user.allowWrite;
			drow["allowDelete"] = user.allowDelete;
			drow["allowApprovable"] = user.allowApprovable;
			drow["allowCheckable"] = user.allowCheckable;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
