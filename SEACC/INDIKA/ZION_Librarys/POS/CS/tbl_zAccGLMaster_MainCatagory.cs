using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccGLMaster_MainCatagory {
		#region Fields
		private string glMainCatagory_ID;
		private string glMainCatagoryName;
		private bool isActive;
		private bool isPNLAccount;
		private int balanceSheet_Node;
		private bool isCredit;
		private int line_No;
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
		public tbl_zAccGLMaster_MainCatagory(string glMainCatagory_ID, string glMainCatagoryName, bool isActive, bool isPNLAccount, int balanceSheet_Node, bool isCredit, int line_No) {
			this.glMainCatagory_ID = glMainCatagory_ID;
			this.glMainCatagoryName = glMainCatagoryName;
			this.isActive = isActive;
			this.isPNLAccount = isPNLAccount;
			this.balanceSheet_Node = balanceSheet_Node;
			this.isCredit = isCredit;
			this.line_No = line_No;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GlMainCatagory_ID value.
		/// </summary>
		public string GlMainCatagory_ID {
			get { return glMainCatagory_ID; }
			set { glMainCatagory_ID = value; }
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
		/// Gets or sets the IsPNLAccount value.
		/// </summary>
		public bool IsPNLAccount {
			get { return isPNLAccount; }
			set { isPNLAccount = value; }
		}
		
		/// <summary>
		/// Gets or sets the BalanceSheet_Node value.
		/// </summary>
		public int BalanceSheet_Node {
			get { return balanceSheet_Node; }
			set { balanceSheet_Node = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCredit value.
		/// </summary>
		public bool IsCredit {
			get { return isCredit; }
			set { isCredit = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
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
 
 
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glMainCatagoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPNLAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@balanceSheet_Node", SqlDbType.Int,4);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
 
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
			scom.Parameters["@glMainCatagoryName"].Value = glMainCatagoryName;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@isPNLAccount"].Value = isPNLAccount;
			scom.Parameters["@balanceSheet_Node"].Value = balanceSheet_Node;
			scom.Parameters["@isCredit"].Value = isCredit;
			scom.Parameters["@line_No"].Value = line_No;
 
 
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
 
 
			scom.Parameters.Add("@glMainCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glMainCatagoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPNLAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@balanceSheet_Node", SqlDbType.Int,4);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
 
 
			scom.Parameters["@glMainCatagory_ID"].Value = glMainCatagory_ID;
			scom.Parameters["@glMainCatagoryName"].Value = glMainCatagoryName;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@isPNLAccount"].Value = isPNLAccount;
			scom.Parameters["@balanceSheet_Node"].Value = balanceSheet_Node;
			scom.Parameters["@isCredit"].Value = isCredit;
			scom.Parameters["@line_No"].Value = line_No;
 
 
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
				tbl_zAccGLMaster_MainCatagory.GlMainCatagory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccGLMaster_MainCatagory.GlMainCatagoryName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zAccGLMaster_MainCatagory.IsActive = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zAccGLMaster_MainCatagory.IsPNLAccount = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zAccGLMaster_MainCatagory.BalanceSheet_Node = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zAccGLMaster_MainCatagory.IsCredit = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zAccGLMaster_MainCatagory.Line_No = dataReader.GetInt32(6);
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
		
			DataColumn col_glMainCatagory_ID = new DataColumn("glMainCatagory_ID" , typeof(string));
			DataColumn col_glMainCatagoryName = new DataColumn("glMainCatagoryName" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_isPNLAccount = new DataColumn("isPNLAccount" , typeof(bool));
			DataColumn col_balanceSheet_Node = new DataColumn("balanceSheet_Node" , typeof(int));
			DataColumn col_isCredit = new DataColumn("isCredit" , typeof(bool));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_glMainCatagory_ID,col_glMainCatagoryName,col_isActive,col_isPNLAccount,col_balanceSheet_Node,col_isCredit,col_line_No,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccGLMaster_MainCatagory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccGLMaster_MainCatagory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccGLMaster_MainCatagory user) {
		DataRow drow = dt.NewRow();
		
			drow["glMainCatagory_ID"] = user.glMainCatagory_ID;
			drow["glMainCatagoryName"] = user.glMainCatagoryName;
			drow["isActive"] = user.isActive;
			drow["isPNLAccount"] = user.isPNLAccount;
			drow["balanceSheet_Node"] = user.balanceSheet_Node;
			drow["isCredit"] = user.isCredit;
			drow["line_No"] = user.line_No;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
