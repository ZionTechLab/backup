using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityGroupPermission {
		#region Fields
		private string group_ID;
		private int form_ID;
		private bool allowRead;
		private bool allowWrite;
		private bool allowDelete;
		private bool allowApprovable;
		private bool allowCheckable;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityGroupPermission class.
		/// </summary>
		public tbl_securityGroupPermission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityGroupPermission class.
		/// </summary>
		public tbl_securityGroupPermission(string group_ID, int form_ID, bool allowRead, bool allowWrite, bool allowDelete, bool allowApprovable, bool allowCheckable) {
			this.group_ID = group_ID;
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
		/// Gets or sets the Group_ID value.
		/// </summary>
		public string Group_ID {
			get { return group_ID; }
			set { group_ID = value; }
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
		/// Saves a record to the tbl_securityGroupPermission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
 
			scom.Parameters["@group_ID"].Value = group_ID;
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
		/// Updates a record in the tbl_securityGroupPermission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@allowRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowWrite", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
 
 
			scom.Parameters["@group_ID"].Value = group_ID;
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
		/// Deletes a record from the tbl_securityGroupPermission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@group_ID"].Value = group_ID;
 
			scom.Parameters["@form_ID"].Value = form_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityGroupPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByGroup_ID(string group_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionDeleteAllByGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
			scom.Parameters["@group_ID"].Value = group_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityGroupPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityGroupPermission table.
		/// </summary>
		public static tbl_securityGroupPermission Select(string group_ID_Incoming, int form_ID_Incoming){

			tbl_securityGroupPermission tbl_securityGroupPermissionins = new tbl_securityGroupPermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@group_ID"].Value = group_ID_Incoming;
			scom.Parameters["@form_ID"].Value = form_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityGroupPermissionins = Maketbl_securityGroupPermission(dataReader);
				} else {
					tbl_securityGroupPermissionins = null;
				}
			}
			scon.Close();
			return tbl_securityGroupPermissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityGroupPermission table.
		/// </summary>
		public static List<tbl_securityGroupPermission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityGroupPermission> tbl_securityGroupPermissionList = new List<tbl_securityGroupPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityGroupPermission tbl_securityGroupPermission = Maketbl_securityGroupPermission(dataReader);
					tbl_securityGroupPermissionList.Add(tbl_securityGroupPermission);
				}
			}
			scon.Close();
			return tbl_securityGroupPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityGroupPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityGroupPermission> SelectAllByGroup_ID(string group_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionSelectAllByGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
			scom.Parameters["@group_ID"].Value = group_ID;
				List<tbl_securityGroupPermission> tbl_securityGroupPermissionList = new List<tbl_securityGroupPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityGroupPermission tbl_securityGroupPermission = Maketbl_securityGroupPermission(dataReader);
					tbl_securityGroupPermissionList.Add(tbl_securityGroupPermission);
				}
			}
			scon.Close();
			return tbl_securityGroupPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityGroupPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityGroupPermission> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupPermissionSelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_securityGroupPermission> tbl_securityGroupPermissionList = new List<tbl_securityGroupPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityGroupPermission tbl_securityGroupPermission = Maketbl_securityGroupPermission(dataReader);
					tbl_securityGroupPermissionList.Add(tbl_securityGroupPermission);
				}
			}
			scon.Close();
			return tbl_securityGroupPermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityGroupPermission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityGroupPermission Maketbl_securityGroupPermission(SqlDataReader dataReader) {
			tbl_securityGroupPermission tbl_securityGroupPermission = new tbl_securityGroupPermission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityGroupPermission.Group_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityGroupPermission.Form_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityGroupPermission.AllowRead = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityGroupPermission.AllowWrite = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityGroupPermission.AllowDelete = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityGroupPermission.AllowApprovable = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityGroupPermission.AllowCheckable = dataReader.GetBoolean(6);
			}

			return tbl_securityGroupPermission;
		}
		/// <summary>
		/// This fills tbl_securityGroupPermission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityGroupPermission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityGroupPermission user) {
		DataRow drow = dt.NewRow();
		
			drow["group_ID"] = user.group_ID;
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
