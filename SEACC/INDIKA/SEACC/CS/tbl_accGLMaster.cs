using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster {
		#region Fields
		private int line_No;
		private string gl_ID;
		private string glName;
		private string glAccountType_ID;
		private string glNote_ID;
		private string createUser_ID;
		private string createTerminal_ID;
		private string modifiedUser_ID;
		private string modifiedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private bool isDeleted;
		private string controlAcc_Type;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster class.
		/// </summary>
		public tbl_accGLMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster class.
		/// </summary>
		public tbl_accGLMaster(int line_No, string gl_ID, string glName, string glAccountType_ID, string glNote_ID, string createUser_ID, string createTerminal_ID, string modifiedUser_ID, string modifiedTerminal_ID, DateTime dateCreate, DateTime dateModified, bool isDeleted, string controlAcc_Type) {
			this.line_No = line_No;
			this.gl_ID = gl_ID;
			this.glName = glName;
			this.glAccountType_ID = glAccountType_ID;
			this.glNote_ID = glNote_ID;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.isDeleted = isDeleted;
			this.controlAcc_Type = controlAcc_Type;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlName value.
		/// </summary>
		public string GlName {
			get { return glName; }
			set { glName = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlAccountType_ID value.
		/// </summary>
		public string GlAccountType_ID {
			get { return glAccountType_ID; }
			set { glAccountType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlNote_ID value.
		/// </summary>
		public string GlNote_ID {
			get { return glNote_ID; }
			set { glNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
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
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the ControlAcc_Type value.
		/// </summary>
		public string ControlAcc_Type {
			get { return controlAcc_Type; }
			set { controlAcc_Type = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@controlAcc_Type", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@glName"].Value = glName;
			scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID;
			scom.Parameters["@glNote_ID"].Value = glNote_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@controlAcc_Type"].Value = controlAcc_Type;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@controlAcc_Type", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@glName"].Value = glName;
			scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID;
			scom.Parameters["@glNote_ID"].Value = glNote_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@controlAcc_Type"].Value = controlAcc_Type;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster table.
		/// </summary>
		public static tbl_accGLMaster Select(string gl_ID_Incoming){

			tbl_accGLMaster tbl_accGLMasterins = new tbl_accGLMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMasterins = Maketbl_accGLMaster(dataReader);
				} else {
					tbl_accGLMasterins = null;
				}
			}
			scon.Close();
			return tbl_accGLMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster table.
		/// </summary>
		public static List<tbl_accGLMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster> tbl_accGLMasterList = new List<tbl_accGLMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster tbl_accGLMaster = Maketbl_accGLMaster(dataReader);
					tbl_accGLMasterList.Add(tbl_accGLMaster);
				}
			}
			scon.Close();
			return tbl_accGLMasterList;
		}
        /// <summary>
        /// Selects all records from the tbl_accGLMaster table by a foreign key.
        /// </summary>
        public static List<tbl_accGLMaster> SelectAllByGlAccountType_ID(string glAccountType_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accGLMasterSelectAllByGlAccountType_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID;
            List<tbl_accGLMaster> tbl_accGLMasterList = new List<tbl_accGLMaster>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_accGLMaster tbl_accGLMaster = Maketbl_accGLMaster(dataReader);
                    tbl_accGLMasterList.Add(tbl_accGLMaster);
                }
            }
            scon.Close();
            return tbl_accGLMasterList;
        }
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster Maketbl_accGLMaster(SqlDataReader dataReader) {
			tbl_accGLMaster tbl_accGLMaster = new tbl_accGLMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster.Gl_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster.GlName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLMaster.GlAccountType_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLMaster.GlNote_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accGLMaster.CreateUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accGLMaster.CreateTerminal_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accGLMaster.ModifiedUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accGLMaster.ModifiedTerminal_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accGLMaster.DateCreate = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accGLMaster.DateModified = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accGLMaster.IsDeleted = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accGLMaster.ControlAcc_Type = dataReader.GetString(12);
			}

			return tbl_accGLMaster;
		}
		/// <summary>
		/// This makes tbl_accGLMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster  tbl_accGLMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_glName = new DataColumn("glName" , typeof(string));
			DataColumn col_glAccountType_ID = new DataColumn("glAccountType_ID" , typeof(string));
			DataColumn col_glNote_ID = new DataColumn("glNote_ID" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_controlAcc_Type = new DataColumn("controlAcc_Type" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_gl_ID,col_glName,col_glAccountType_ID,col_glNote_ID,col_createUser_ID,col_createTerminal_ID,col_modifiedUser_ID,col_modifiedTerminal_ID,col_dateCreate,col_dateModified,col_isDeleted,col_controlAcc_Type,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["gl_ID"] = user.gl_ID;
			drow["glName"] = user.glName;
			drow["glAccountType_ID"] = user.glAccountType_ID;
			drow["glNote_ID"] = user.glNote_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["isDeleted"] = user.isDeleted;
			drow["controlAcc_Type"] = user.controlAcc_Type;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
