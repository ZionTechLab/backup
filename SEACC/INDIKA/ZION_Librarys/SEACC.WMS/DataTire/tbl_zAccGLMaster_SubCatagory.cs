using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccGLMaster_SubCatagory {
		#region Fields
		private int line_No;
		private string glSubCatagory_ID;
		private string glSubCatagory_3rdPartyCode;
		private string glSubCatagoryName;
		private bool isActive;
		private string glMainCatagory_ID;
		private int counter;
		private int length;
		private string prefix;
		private string seperator;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccGLMaster_SubCatagory class.
		/// </summary>
		public tbl_zAccGLMaster_SubCatagory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccGLMaster_SubCatagory class.
		/// </summary>
		public tbl_zAccGLMaster_SubCatagory(int line_No, string glSubCatagory_ID, string glSubCatagory_3rdPartyCode, string glSubCatagoryName, bool isActive, string glMainCatagory_ID, int counter, int length, string prefix, string seperator) {
			this.line_No = line_No;
			this.glSubCatagory_ID = glSubCatagory_ID;
			this.glSubCatagory_3rdPartyCode = glSubCatagory_3rdPartyCode;
			this.glSubCatagoryName = glSubCatagoryName;
			this.isActive = isActive;
			this.glMainCatagory_ID = glMainCatagory_ID;
			this.counter = counter;
			this.length = length;
			this.prefix = prefix;
			this.seperator = seperator;
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
		/// Gets or sets the GlSubCatagory_ID value.
		/// </summary>
		public string GlSubCatagory_ID {
			get { return glSubCatagory_ID; }
			set { glSubCatagory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlSubCatagory_3rdPartyCode value.
		/// </summary>
		public string GlSubCatagory_3rdPartyCode {
			get { return glSubCatagory_3rdPartyCode; }
			set { glSubCatagory_3rdPartyCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlSubCatagoryName value.
		/// </summary>
		public string GlSubCatagoryName {
			get { return glSubCatagoryName; }
			set { glSubCatagoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlMainCatagory_ID value.
		/// </summary>
		public string GlMainCatagory_ID {
			get { return glMainCatagory_ID; }
			set { glMainCatagory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public int Counter {
			get { return counter; }
			set { counter = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public int Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Seperator value.
		/// </summary>
		public string Seperator {
			get { return seperator; }
			set { seperator = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccGLMaster_SubCatagory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_SubCatagoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glSubCatagory_3rdPartyCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glSubCatagoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator", SqlDbType.VarChar,50);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
			scom.Parameters["@glSubCatagory_3rdPartyCode"].Value = glSubCatagory_3rdPartyCode;
			scom.Parameters["@glSubCatagoryName"].Value = glSubCatagoryName;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@seperator"].Value = seperator;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccGLMaster_SubCatagory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_SubCatagoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glSubCatagory_3rdPartyCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glSubCatagoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
			scom.Parameters["@glSubCatagory_3rdPartyCode"].Value = glSubCatagory_3rdPartyCode;
			scom.Parameters["@glSubCatagoryName"].Value = glSubCatagoryName;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@seperator"].Value = seperator;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccGLMaster_SubCatagory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_SubCatagoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccGLMaster_SubCatagory table by a foreign key.
		/// </summary>
		public static void DeleteAllByGlMainCatagory_ID(string glMainCatagory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_SubCatagoryDeleteAllByGlMainCatagory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccGLMaster_SubCatagory table.
		/// </summary>
        public static tbl_zAccGLMaster_SubCatagory Select(string glSubCatagory_ID_Incoming)
        {

            tbl_zAccGLMaster_SubCatagory tbl_zAccGLMaster_SubCatagoryins = new tbl_zAccGLMaster_SubCatagory();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_SubCatagorySelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_zAccGLMaster_SubCatagoryins = Maketbl_zAccGLMaster_SubCatagory(dataReader);
                }
                else
                {
                    tbl_zAccGLMaster_SubCatagoryins = null;
                }
            }
            scon.Close();
            return tbl_zAccGLMaster_SubCatagoryins;
        }
		
		/// <summary>
		/// Selects all records from the tbl_zAccGLMaster_SubCatagory table.
		/// </summary>
		public static List<tbl_zAccGLMaster_SubCatagory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_SubCatagorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccGLMaster_SubCatagory> tbl_zAccGLMaster_SubCatagoryList = new List<tbl_zAccGLMaster_SubCatagory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccGLMaster_SubCatagory tbl_zAccGLMaster_SubCatagory = Maketbl_zAccGLMaster_SubCatagory(dataReader);
					tbl_zAccGLMaster_SubCatagoryList.Add(tbl_zAccGLMaster_SubCatagory);
				}
			}
			scon.Close();
			return tbl_zAccGLMaster_SubCatagoryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccGLMaster_SubCatagory table by a foreign key.
		/// </summary>
		public static List<tbl_zAccGLMaster_SubCatagory> SelectAllByGlMainCatagory_ID(string glMainCatagory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_SubCatagorySelectAllByGlMainCatagory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
				List<tbl_zAccGLMaster_SubCatagory> tbl_zAccGLMaster_SubCatagoryList = new List<tbl_zAccGLMaster_SubCatagory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccGLMaster_SubCatagory tbl_zAccGLMaster_SubCatagory = Maketbl_zAccGLMaster_SubCatagory(dataReader);
					tbl_zAccGLMaster_SubCatagoryList.Add(tbl_zAccGLMaster_SubCatagory);
				}
			}
			scon.Close();
			return tbl_zAccGLMaster_SubCatagoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccGLMaster_SubCatagory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccGLMaster_SubCatagory Maketbl_zAccGLMaster_SubCatagory(SqlDataReader dataReader) {
			tbl_zAccGLMaster_SubCatagory tbl_zAccGLMaster_SubCatagory = new tbl_zAccGLMaster_SubCatagory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccGLMaster_SubCatagory.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccGLMaster_SubCatagory.GlSubCatagory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zAccGLMaster_SubCatagory.GlSubCatagory_3rdPartyCode = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zAccGLMaster_SubCatagory.GlSubCatagoryName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zAccGLMaster_SubCatagory.IsActive = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zAccGLMaster_SubCatagory.GlMainCatagory_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zAccGLMaster_SubCatagory.Counter = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zAccGLMaster_SubCatagory.Length = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zAccGLMaster_SubCatagory.Prefix = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zAccGLMaster_SubCatagory.Seperator = dataReader.GetString(9);
			}

			return tbl_zAccGLMaster_SubCatagory;
		}
		/// <summary>
		/// This makes tbl_zAccGLMaster_SubCatagory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccGLMaster_SubCatagory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccGLMaster_SubCatagory  tbl_zAccGLMaster_SubCatagory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_glSubCatagory_ID = new DataColumn("glSubCatagory_ID" , typeof(string));
			DataColumn col_glSubCatagory_3rdPartyCode = new DataColumn("glSubCatagory_3rdPartyCode" , typeof(string));
			DataColumn col_glSubCatagoryName = new DataColumn("glSubCatagoryName" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_glMainCatagory_ID = new DataColumn("glMainCatagory_ID" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_seperator = new DataColumn("seperator" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_glSubCatagory_ID,col_glSubCatagory_3rdPartyCode,col_glSubCatagoryName,col_isActive,col_glMainCatagory_ID,col_counter,col_length,col_prefix,col_seperator,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccGLMaster_SubCatagory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccGLMaster_SubCatagory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccGLMaster_SubCatagory user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["glSubCatagory_ID"] = user.glSubCatagory_ID;
			drow["glSubCatagory_3rdPartyCode"] = user.glSubCatagory_3rdPartyCode;
			drow["glSubCatagoryName"] = user.glSubCatagoryName;
			drow["isActive"] = user.isActive;
			drow["glMainCatagory_ID"] = user.glMainCatagory_ID;
			drow["counter"] = user.counter;
			drow["length"] = user.length;
			drow["prefix"] = user.prefix;
			drow["seperator"] = user.seperator;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
