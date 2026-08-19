using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityStorePermission {
		#region Fields
		private string user_ID;
		private string store_ID;
		private bool allowRead;
		private bool allowWrite;
		private bool allowDelete;
		private bool allowApprovable;
		private bool allowCheckable;
		private bool allowUpdate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityStorePermission class.
		/// </summary>
		public tbl_securityStorePermission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityStorePermission class.
		/// </summary>
		public tbl_securityStorePermission(string user_ID, string store_ID, bool allowRead, bool allowWrite, bool allowDelete, bool allowApprovable, bool allowCheckable, bool allowUpdate) {
			this.user_ID = user_ID;
			this.store_ID = store_ID;
			this.allowRead = allowRead;
			this.allowWrite = allowWrite;
			this.allowDelete = allowDelete;
			this.allowApprovable = allowApprovable;
			this.allowCheckable = allowCheckable;
			this.allowUpdate = allowUpdate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityStorePermission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowUpdate", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@allowRead"].Value = allowRead;
			scom.Parameters["@allowWrite"].Value = allowWrite;
			scom.Parameters["@allowDelete"].Value = allowDelete;
			scom.Parameters["@allowApprovable"].Value = allowApprovable;
			scom.Parameters["@allowCheckable"].Value = allowCheckable;
			scom.Parameters["@allowUpdate"].Value = allowUpdate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityStorePermission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowUpdate", SqlDbType.Bit,1);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@allowRead"].Value = allowRead;
			scom.Parameters["@allowWrite"].Value = allowWrite;
			scom.Parameters["@allowDelete"].Value = allowDelete;
			scom.Parameters["@allowApprovable"].Value = allowApprovable;
			scom.Parameters["@allowCheckable"].Value = allowCheckable;
			scom.Parameters["@allowUpdate"].Value = allowUpdate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityStorePermission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStorePermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStorePermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityStorePermission table.
		/// </summary>
		public static tbl_securityStorePermission Select(string user_ID_Incoming, string store_ID_Incoming){

			tbl_securityStorePermission tbl_securityStorePermissionins = new tbl_securityStorePermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@store_ID"].Value = store_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityStorePermissionins = Maketbl_securityStorePermission(dataReader);
				} else {
					tbl_securityStorePermissionins = null;
				}
			}
			scon.Close();
			return tbl_securityStorePermissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStorePermission table.
		/// </summary>
		public static List<tbl_securityStorePermission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityStorePermission> tbl_securityStorePermissionList = new List<tbl_securityStorePermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityStorePermission tbl_securityStorePermission = Maketbl_securityStorePermission(dataReader);
					tbl_securityStorePermissionList.Add(tbl_securityStorePermission);
				}
			}
			scon.Close();
			return tbl_securityStorePermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStorePermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityStorePermission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_securityStorePermission> tbl_securityStorePermissionList = new List<tbl_securityStorePermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityStorePermission tbl_securityStorePermission = Maketbl_securityStorePermission(dataReader);
					tbl_securityStorePermissionList.Add(tbl_securityStorePermission);
				}
			}
			scon.Close();
			return tbl_securityStorePermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityStorePermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityStorePermission> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityStorePermissionSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_securityStorePermission> tbl_securityStorePermissionList = new List<tbl_securityStorePermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityStorePermission tbl_securityStorePermission = Maketbl_securityStorePermission(dataReader);
					tbl_securityStorePermissionList.Add(tbl_securityStorePermission);
				}
			}
			scon.Close();
			return tbl_securityStorePermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityStorePermission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityStorePermission Maketbl_securityStorePermission(SqlDataReader dataReader) {
			tbl_securityStorePermission tbl_securityStorePermission = new tbl_securityStorePermission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityStorePermission.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityStorePermission.Store_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityStorePermission.AllowRead = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityStorePermission.AllowWrite = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityStorePermission.AllowDelete = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityStorePermission.AllowApprovable = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityStorePermission.AllowCheckable = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityStorePermission.AllowUpdate = dataReader.GetBoolean(7);
			}

			return tbl_securityStorePermission;
		}
		/// <summary>
		/// This makes tbl_securityStorePermission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityStorePermission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityStorePermission  tbl_securityStorePermission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_allowRead = new DataColumn("allowRead" , typeof(bool));
			DataColumn col_allowWrite = new DataColumn("allowWrite" , typeof(bool));
			DataColumn col_allowDelete = new DataColumn("allowDelete" , typeof(bool));
			DataColumn col_allowApprovable = new DataColumn("allowApprovable" , typeof(bool));
			DataColumn col_allowCheckable = new DataColumn("allowCheckable" , typeof(bool));
			DataColumn col_allowUpdate = new DataColumn("allowUpdate" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_store_ID,col_allowRead,col_allowWrite,col_allowDelete,col_allowApprovable,col_allowCheckable,col_allowUpdate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityStorePermission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityStorePermission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityStorePermission user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["store_ID"] = user.store_ID;
			drow["allowRead"] = user.allowRead;
			drow["allowWrite"] = user.allowWrite;
			drow["allowDelete"] = user.allowDelete;
			drow["allowApprovable"] = user.allowApprovable;
			drow["allowCheckable"] = user.allowCheckable;
			drow["allowUpdate"] = user.allowUpdate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
