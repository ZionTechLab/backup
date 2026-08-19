using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityUserPermission {
		#region Fields
		private string user_ID;
		private int form_ID;
		private bool allowRead;
		private bool allowWrite;
		private bool allowDelete;
		private bool allowApprovable;
		private bool allowCheckable;
		private bool allowUpdate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserPermission class.
		/// </summary>
		public tbl_securityUserPermission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserPermission class.
		/// </summary>
		public tbl_securityUserPermission(string user_ID, int form_ID, bool allowRead, bool allowWrite, bool allowDelete, bool allowApprovable, bool allowCheckable, bool allowUpdate) {
			this.user_ID = user_ID;
			this.form_ID = form_ID;
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
		/// Saves a record to the tbl_securityUserPermission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowUpdate", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@form_ID"].Value = form_ID;
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
		/// Updates a record in the tbl_securityUserPermission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowUpdate", SqlDbType.Bit,1);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@form_ID"].Value = form_ID;
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
		/// Deletes a record from the tbl_securityUserPermission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@form_ID"].Value = form_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityUserPermission table.
		/// </summary>
		public static tbl_securityUserPermission Select(string user_ID_Incoming, int form_ID_Incoming){

			tbl_securityUserPermission tbl_securityUserPermissionins = new tbl_securityUserPermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@form_ID"].Value = form_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityUserPermissionins = Maketbl_securityUserPermission(dataReader);
				} else {
					tbl_securityUserPermissionins = null;
				}
			}
			scon.Close();
			return tbl_securityUserPermissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserPermission table.
		/// </summary>
		public static List<tbl_securityUserPermission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityUserPermission> tbl_securityUserPermissionList = new List<tbl_securityUserPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserPermission tbl_securityUserPermission = Maketbl_securityUserPermission(dataReader);
					tbl_securityUserPermissionList.Add(tbl_securityUserPermission);
				}
			}
			scon.Close();
			return tbl_securityUserPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityUserPermission> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionSelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_securityUserPermission> tbl_securityUserPermissionList = new List<tbl_securityUserPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserPermission tbl_securityUserPermission = Maketbl_securityUserPermission(dataReader);
					tbl_securityUserPermissionList.Add(tbl_securityUserPermission);
				}
			}
			scon.Close();
			return tbl_securityUserPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityUserPermission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserPermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_securityUserPermission> tbl_securityUserPermissionList = new List<tbl_securityUserPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserPermission tbl_securityUserPermission = Maketbl_securityUserPermission(dataReader);
					tbl_securityUserPermissionList.Add(tbl_securityUserPermission);
				}
			}
			scon.Close();
			return tbl_securityUserPermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityUserPermission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityUserPermission Maketbl_securityUserPermission(SqlDataReader dataReader) {
			tbl_securityUserPermission tbl_securityUserPermission = new tbl_securityUserPermission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityUserPermission.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityUserPermission.Form_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityUserPermission.AllowRead = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityUserPermission.AllowWrite = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityUserPermission.AllowDelete = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityUserPermission.AllowApprovable = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityUserPermission.AllowCheckable = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityUserPermission.AllowUpdate = dataReader.GetBoolean(7);
			}

			return tbl_securityUserPermission;
		}
		/// <summary>
		/// This makes tbl_securityUserPermission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityUserPermission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityUserPermission  tbl_securityUserPermission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_allowRead = new DataColumn("allowRead" , typeof(bool));
			DataColumn col_allowWrite = new DataColumn("allowWrite" , typeof(bool));
			DataColumn col_allowDelete = new DataColumn("allowDelete" , typeof(bool));
			DataColumn col_allowApprovable = new DataColumn("allowApprovable" , typeof(bool));
			DataColumn col_allowCheckable = new DataColumn("allowCheckable" , typeof(bool));
			DataColumn col_allowUpdate = new DataColumn("allowUpdate" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_form_ID,col_allowRead,col_allowWrite,col_allowDelete,col_allowApprovable,col_allowCheckable,col_allowUpdate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityUserPermission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityUserPermission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityUserPermission user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["form_ID"] = user.form_ID;
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
