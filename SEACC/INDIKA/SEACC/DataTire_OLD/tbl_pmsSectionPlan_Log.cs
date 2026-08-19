using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_pmsSectionPlan_Log {
		#region Fields
		private Int64 sectionPlan_ID;
		private DateTime sectionPlanDate;
		private string section_ID;
		private string remark;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string deleteUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deleteTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateDelete;
		private bool isDelete;
		private bool isLocked;
		private bool isRemoveFromSection;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsSectionPlan_Log class.
		/// </summary>
		public tbl_pmsSectionPlan_Log() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsSectionPlan_Log class.
		/// </summary>
		public tbl_pmsSectionPlan_Log(DateTime sectionPlanDate, string section_ID, string remark, string createUser_ID, string modifiedUser_ID, string deleteUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deleteTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDelete, bool isDelete, bool isLocked, bool isRemoveFromSection) {
			this.sectionPlanDate = sectionPlanDate;
			this.section_ID = section_ID;
			this.remark = remark;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.deleteUser_ID = deleteUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deleteTerminal_ID = deleteTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateDelete = dateDelete;
			this.isDelete = isDelete;
			this.isLocked = isLocked;
			this.isRemoveFromSection = isRemoveFromSection;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsSectionPlan_Log class.
		/// </summary>
		public tbl_pmsSectionPlan_Log(Int64 sectionPlan_ID, DateTime sectionPlanDate, string section_ID, string remark, string createUser_ID, string modifiedUser_ID, string deleteUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deleteTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDelete, bool isDelete, bool isLocked, bool isRemoveFromSection) {
			this.sectionPlan_ID = sectionPlan_ID;
			this.sectionPlanDate = sectionPlanDate;
			this.section_ID = section_ID;
			this.remark = remark;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.deleteUser_ID = deleteUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deleteTerminal_ID = deleteTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateDelete = dateDelete;
			this.isDelete = isDelete;
			this.isLocked = isLocked;
			this.isRemoveFromSection = isRemoveFromSection;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SectionPlan_ID value.
		/// </summary>
		public Int64 SectionPlan_ID {
			get { return sectionPlan_ID; }
			set { sectionPlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionPlanDate value.
		/// </summary>
		public DateTime SectionPlanDate {
			get { return sectionPlanDate; }
			set { sectionPlanDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
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
		/// Gets or sets the DeleteUser_ID value.
		/// </summary>
		public string DeleteUser_ID {
			get { return deleteUser_ID; }
			set { deleteUser_ID = value; }
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
		/// Gets or sets the DeleteTerminal_ID value.
		/// </summary>
		public string DeleteTerminal_ID {
			get { return deleteTerminal_ID; }
			set { deleteTerminal_ID = value; }
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
		/// Gets or sets the DateDelete value.
		/// </summary>
		public DateTime DateDelete {
			get { return dateDelete; }
			set { dateDelete = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelete value.
		/// </summary>
		public bool IsDelete {
			get { return isDelete; }
			set { isDelete = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRemoveFromSection value.
		/// </summary>
		public bool IsRemoveFromSection {
			get { return isRemoveFromSection; }
			set { isRemoveFromSection = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsSectionPlan_Log table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sectionPlanDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deleteUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deleteTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDelete", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRemoveFromSection", SqlDbType.Bit,1);
 
			scom.Parameters["@sectionPlanDate"].Value = sectionPlanDate;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deleteUser_ID"].Value = deleteUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deleteTerminal_ID"].Value = deleteTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDelete"].Value = dateDelete;
			scom.Parameters["@isDelete"].Value = isDelete;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isRemoveFromSection"].Value = isRemoveFromSection;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsSectionPlan_Log table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@sectionPlan_ID", SqlDbType.BigInt, 8);
			scom.Parameters.Add("@sectionPlanDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deleteUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deleteTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDelete", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRemoveFromSection", SqlDbType.Bit,1);

            scom.Parameters["@sectionPlan_ID"].Value = sectionPlan_ID;
			scom.Parameters["@sectionPlanDate"].Value = sectionPlanDate;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deleteUser_ID"].Value = deleteUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deleteTerminal_ID"].Value = deleteTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDelete"].Value = dateDelete;
			scom.Parameters["@isDelete"].Value = isDelete;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isRemoveFromSection"].Value = isRemoveFromSection;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsSectionPlan_Log table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sectionPlan_ID", SqlDbType.BigInt,8);
			scom.Parameters["@sectionPlan_ID"].Value = sectionPlan_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsSectionPlan_Log table.
		/// </summary>
		public static tbl_pmsSectionPlan_Log Select(Int64 sectionPlan_ID_Incoming){

			tbl_pmsSectionPlan_Log tbl_pmsSectionPlan_Logins = new tbl_pmsSectionPlan_Log();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@sectionPlan_ID", SqlDbType.BigInt, 8);
			scom.Parameters["@sectionPlan_ID"].Value = sectionPlan_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsSectionPlan_Logins = Maketbl_pmsSectionPlan_Log(dataReader);
				} else {
					tbl_pmsSectionPlan_Logins = null;
				}
			}
			scon.Close();
			return tbl_pmsSectionPlan_Logins;
		}
        public static Int64 SelectMaxSectionPlan_ID()
        {
            Int64 SectionPlan_ID = -99;
           
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogSectionPlan_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
           
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) == false)
                    {
                        SectionPlan_ID = dataReader.GetInt64(0);
                    }
                }
                else
                {
                    SectionPlan_ID = -99;
                }
            }
            scon.Close();
            return SectionPlan_ID;
        }
		/// <summary>
		/// Selects all records from the tbl_pmsSectionPlan_Log table.
		/// </summary>
		public static List<tbl_pmsSectionPlan_Log> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsSectionPlan_LogSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsSectionPlan_Log> tbl_pmsSectionPlan_LogList = new List<tbl_pmsSectionPlan_Log>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsSectionPlan_Log tbl_pmsSectionPlan_Log = Maketbl_pmsSectionPlan_Log(dataReader);
					tbl_pmsSectionPlan_LogList.Add(tbl_pmsSectionPlan_Log);
				}
			}
			scon.Close();
			return tbl_pmsSectionPlan_LogList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsSectionPlan_Log class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsSectionPlan_Log Maketbl_pmsSectionPlan_Log(SqlDataReader dataReader) {
			tbl_pmsSectionPlan_Log tbl_pmsSectionPlan_Log = new tbl_pmsSectionPlan_Log();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsSectionPlan_Log.SectionPlan_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsSectionPlan_Log.SectionPlanDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsSectionPlan_Log.Section_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsSectionPlan_Log.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsSectionPlan_Log.CreateUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsSectionPlan_Log.ModifiedUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsSectionPlan_Log.DeleteUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsSectionPlan_Log.CreateTerminal_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsSectionPlan_Log.ModifiedTerminal_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsSectionPlan_Log.DeleteTerminal_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsSectionPlan_Log.DateCreate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsSectionPlan_Log.DateModified = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsSectionPlan_Log.DateDelete = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsSectionPlan_Log.IsDelete = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsSectionPlan_Log.IsLocked = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pmsSectionPlan_Log.IsRemoveFromSection = dataReader.GetBoolean(15);
			}

			return tbl_pmsSectionPlan_Log;
		}
		/// <summary>
		/// This makes tbl_pmsSectionPlan_Log datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsSectionPlan_Log object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsSectionPlan_Log  tbl_pmsSectionPlan_Log   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_sectionPlan_ID = new DataColumn("sectionPlan_ID" , typeof(Int64));
			DataColumn col_sectionPlanDate = new DataColumn("sectionPlanDate" , typeof(DateTime));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_deleteUser_ID = new DataColumn("deleteUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deleteTerminal_ID = new DataColumn("deleteTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateDelete = new DataColumn("dateDelete" , typeof(DateTime));
			DataColumn col_isDelete = new DataColumn("isDelete" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isRemoveFromSection = new DataColumn("isRemoveFromSection" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_sectionPlan_ID,col_sectionPlanDate,col_section_ID,col_remark,col_createUser_ID,col_modifiedUser_ID,col_deleteUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deleteTerminal_ID,col_dateCreate,col_dateModified,col_dateDelete,col_isDelete,col_isLocked,col_isRemoveFromSection,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsSectionPlan_Log datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsSectionPlan_Log object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsSectionPlan_Log user) {
		DataRow drow = dt.NewRow();
		
			drow["sectionPlan_ID"] = user.sectionPlan_ID;
			drow["sectionPlanDate"] = user.sectionPlanDate;
			drow["section_ID"] = user.section_ID;
			drow["remark"] = user.remark;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["deleteUser_ID"] = user.deleteUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deleteTerminal_ID"] = user.deleteTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateDelete"] = user.dateDelete;
			drow["isDelete"] = user.isDelete;
			drow["isLocked"] = user.isLocked;
			drow["isRemoveFromSection"] = user.isRemoveFromSection;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
