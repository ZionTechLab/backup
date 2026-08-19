using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccGLMaster_MainCatagory {
		#region Fields
		private int line_No;
		private string glMainCatagory_ID;
		private string glMainCatagory_3rdPartyCode;
		private string glMainCatagoryName;
		private bool isActive;
		private int counter;
		private int length;
		private string prefix;
		private string seperator;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccGLMaster_MainCatagory class.
		/// </summary>
		public tbl_zAccGLMaster_MainCatagory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccGLMaster_MainCatagory class.
		/// </summary>
		public tbl_zAccGLMaster_MainCatagory(int line_No, string glMainCatagory_ID, string glMainCatagory_3rdPartyCode, string glMainCatagoryName, bool isActive, int counter, int length, string prefix, string seperator) {
			this.line_No = line_No;
			this.glMainCatagory_ID = glMainCatagory_ID;
			this.glMainCatagory_3rdPartyCode = glMainCatagory_3rdPartyCode;
			this.glMainCatagoryName = glMainCatagoryName;
			this.isActive = isActive;
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
		/// Gets or sets the GlMainCatagory_ID value.
		/// </summary>
		public string GlMainCatagory_ID {
			get { return glMainCatagory_ID; }
			set { glMainCatagory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlMainCatagory_3rdPartyCode value.
		/// </summary>
		public string GlMainCatagory_3rdPartyCode {
			get { return glMainCatagory_3rdPartyCode; }
			set { glMainCatagory_3rdPartyCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlMainCatagoryName value.
		/// </summary>
		public string GlMainCatagoryName {
			get { return glMainCatagoryName; }
			set { glMainCatagoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
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
		/// Saves a record to the tbl_zAccGLMaster_MainCatagory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_MainCatagoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glMainCatagory_3rdPartyCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glMainCatagoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator", SqlDbType.VarChar,50);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
			scom.Parameters["@glMainCatagory_3rdPartyCode"].Value = glMainCatagory_3rdPartyCode;
			scom.Parameters["@glMainCatagoryName"].Value = glMainCatagoryName;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@seperator"].Value = seperator;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccGLMaster_MainCatagory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_MainCatagoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glMainCatagory_3rdPartyCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glMainCatagoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
			scom.Parameters["@glMainCatagory_3rdPartyCode"].Value = glMainCatagory_3rdPartyCode;
			scom.Parameters["@glMainCatagoryName"].Value = glMainCatagoryName;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@seperator"].Value = seperator;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccGLMaster_MainCatagory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_MainCatagoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccGLMaster_MainCatagory table.
		/// </summary>
		public static tbl_zAccGLMaster_MainCatagory Select(string glMainCatagory_ID_Incoming){

			tbl_zAccGLMaster_MainCatagory tbl_zAccGLMaster_MainCatagoryins = new tbl_zAccGLMaster_MainCatagory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_MainCatagorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccGLMaster_MainCatagoryins = Maketbl_zAccGLMaster_MainCatagory(dataReader);
				} else {
					tbl_zAccGLMaster_MainCatagoryins = null;
				}
			}
			scon.Close();
			return tbl_zAccGLMaster_MainCatagoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccGLMaster_MainCatagory table.
		/// </summary>
		public static List<tbl_zAccGLMaster_MainCatagory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_MainCatagorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccGLMaster_MainCatagory> tbl_zAccGLMaster_MainCatagoryList = new List<tbl_zAccGLMaster_MainCatagory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccGLMaster_MainCatagory tbl_zAccGLMaster_MainCatagory = Maketbl_zAccGLMaster_MainCatagory(dataReader);
					tbl_zAccGLMaster_MainCatagoryList.Add(tbl_zAccGLMaster_MainCatagory);
				}
			}
			scon.Close();
			return tbl_zAccGLMaster_MainCatagoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccGLMaster_MainCatagory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccGLMaster_MainCatagory Maketbl_zAccGLMaster_MainCatagory(SqlDataReader dataReader) {
			tbl_zAccGLMaster_MainCatagory tbl_zAccGLMaster_MainCatagory = new tbl_zAccGLMaster_MainCatagory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccGLMaster_MainCatagory.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccGLMaster_MainCatagory.GlMainCatagory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zAccGLMaster_MainCatagory.GlMainCatagory_3rdPartyCode = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zAccGLMaster_MainCatagory.GlMainCatagoryName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zAccGLMaster_MainCatagory.IsActive = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zAccGLMaster_MainCatagory.Counter = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zAccGLMaster_MainCatagory.Length = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zAccGLMaster_MainCatagory.Prefix = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zAccGLMaster_MainCatagory.Seperator = dataReader.GetString(8);
			}

			return tbl_zAccGLMaster_MainCatagory;
		}
		/// <summary>
		/// This makes tbl_zAccGLMaster_MainCatagory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccGLMaster_MainCatagory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccGLMaster_MainCatagory  tbl_zAccGLMaster_MainCatagory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_glMainCatagory_ID = new DataColumn("glMainCatagory_ID" , typeof(string));
			DataColumn col_glMainCatagory_3rdPartyCode = new DataColumn("glMainCatagory_3rdPartyCode" , typeof(string));
			DataColumn col_glMainCatagoryName = new DataColumn("glMainCatagoryName" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_seperator = new DataColumn("seperator" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_glMainCatagory_ID,col_glMainCatagory_3rdPartyCode,col_glMainCatagoryName,col_isActive,col_counter,col_length,col_prefix,col_seperator,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccGLMaster_MainCatagory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccGLMaster_MainCatagory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccGLMaster_MainCatagory user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["glMainCatagory_ID"] = user.glMainCatagory_ID;
			drow["glMainCatagory_3rdPartyCode"] = user.glMainCatagory_3rdPartyCode;
			drow["glMainCatagoryName"] = user.glMainCatagoryName;
			drow["isActive"] = user.isActive;
			drow["counter"] = user.counter;
			drow["length"] = user.length;
			drow["prefix"] = user.prefix;
			drow["seperator"] = user.seperator;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
