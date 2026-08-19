using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsPettyCashAccount_Permission {
		#region Fields
		private string pettyCashAccount_ID;
		private string user_ID;
		private bool allowRead;
		private bool allowWrite;
		private bool allowDelete;
		private bool allowApprovable;
		private bool allowCheckable;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount_Permission class.
		/// </summary>
		public tbl_bpsPettyCashAccount_Permission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount_Permission class.
		/// </summary>
		public tbl_bpsPettyCashAccount_Permission(string pettyCashAccount_ID, string user_ID, bool allowRead, bool allowWrite, bool allowDelete, bool allowApprovable, bool allowCheckable) {
			this.pettyCashAccount_ID = pettyCashAccount_ID;
			this.user_ID = user_ID;
			this.allowRead = allowRead;
			this.allowWrite = allowWrite;
			this.allowDelete = allowDelete;
			this.allowApprovable = allowApprovable;
			this.allowCheckable = allowCheckable;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PettyCashAccount_ID value.
		/// </summary>
		public string PettyCashAccount_ID {
			get { return pettyCashAccount_ID; }
			set { pettyCashAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
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
		/// Saves a record to the tbl_bpsPettyCashAccount_Permission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
 
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
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
		/// Updates a record in the tbl_bpsPettyCashAccount_Permission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
 
 
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
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
		/// Deletes a record from the tbl_bpsPettyCashAccount_Permission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByPettyCashAccount_ID(string pettyCashAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionDeleteAllByPettyCashAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsPettyCashAccount_Permission table.
		/// </summary>
		public static tbl_bpsPettyCashAccount_Permission Select(string pettyCashAccount_ID_Incoming, string user_ID_Incoming){

			tbl_bpsPettyCashAccount_Permission tbl_bpsPettyCashAccount_Permissionins = new tbl_bpsPettyCashAccount_Permission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Permissionins = Maketbl_bpsPettyCashAccount_Permission(dataReader);
				} else {
					tbl_bpsPettyCashAccount_Permissionins = null;
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_Permissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Permission table.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Permission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsPettyCashAccount_Permission> tbl_bpsPettyCashAccount_PermissionList = new List<tbl_bpsPettyCashAccount_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Permission tbl_bpsPettyCashAccount_Permission = Maketbl_bpsPettyCashAccount_Permission(dataReader);
					tbl_bpsPettyCashAccount_PermissionList.Add(tbl_bpsPettyCashAccount_Permission);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Permission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_bpsPettyCashAccount_Permission> tbl_bpsPettyCashAccount_PermissionList = new List<tbl_bpsPettyCashAccount_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Permission tbl_bpsPettyCashAccount_Permission = Maketbl_bpsPettyCashAccount_Permission(dataReader);
					tbl_bpsPettyCashAccount_PermissionList.Add(tbl_bpsPettyCashAccount_Permission);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Permission> SelectAllByPettyCashAccount_ID(string pettyCashAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_PermissionSelectAllByPettyCashAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
				List<tbl_bpsPettyCashAccount_Permission> tbl_bpsPettyCashAccount_PermissionList = new List<tbl_bpsPettyCashAccount_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Permission tbl_bpsPettyCashAccount_Permission = Maketbl_bpsPettyCashAccount_Permission(dataReader);
					tbl_bpsPettyCashAccount_PermissionList.Add(tbl_bpsPettyCashAccount_Permission);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_PermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsPettyCashAccount_Permission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsPettyCashAccount_Permission Maketbl_bpsPettyCashAccount_Permission(SqlDataReader dataReader) {
			tbl_bpsPettyCashAccount_Permission tbl_bpsPettyCashAccount_Permission = new tbl_bpsPettyCashAccount_Permission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsPettyCashAccount_Permission.PettyCashAccount_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsPettyCashAccount_Permission.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsPettyCashAccount_Permission.AllowRead = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsPettyCashAccount_Permission.AllowWrite = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsPettyCashAccount_Permission.AllowDelete = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsPettyCashAccount_Permission.AllowApprovable = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsPettyCashAccount_Permission.AllowCheckable = dataReader.GetBoolean(6);
			}

			return tbl_bpsPettyCashAccount_Permission;
		}
		/// <summary>
		/// This makes tbl_bpsPettyCashAccount_Permission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount_Permission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsPettyCashAccount_Permission  tbl_bpsPettyCashAccount_Permission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pettyCashAccount_ID = new DataColumn("pettyCashAccount_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_allowRead = new DataColumn("allowRead" , typeof(bool));
			DataColumn col_allowWrite = new DataColumn("allowWrite" , typeof(bool));
			DataColumn col_allowDelete = new DataColumn("allowDelete" , typeof(bool));
			DataColumn col_allowApprovable = new DataColumn("allowApprovable" , typeof(bool));
			DataColumn col_allowCheckable = new DataColumn("allowCheckable" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_pettyCashAccount_ID,col_user_ID,col_allowRead,col_allowWrite,col_allowDelete,col_allowApprovable,col_allowCheckable,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsPettyCashAccount_Permission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount_Permission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsPettyCashAccount_Permission user) {
		DataRow drow = dt.NewRow();
		
			drow["pettyCashAccount_ID"] = user.pettyCashAccount_ID;
			drow["user_ID"] = user.user_ID;
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
