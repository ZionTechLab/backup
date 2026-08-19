using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLPosting_UnpostedTXN {
		#region Fields
		private string glPosting_ID;
		private string batch_ID;
		private DateTime glPostingDate;
		private string remark;
		private string createUser_ID;
		private string createTerminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLPosting_UnpostedTXN class.
		/// </summary>
		public tbl_accGLPosting_UnpostedTXN() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLPosting_UnpostedTXN class.
		/// </summary>
		public tbl_accGLPosting_UnpostedTXN(string glPosting_ID, string batch_ID, DateTime glPostingDate, string remark, string createUser_ID, string createTerminal_ID) {
			this.glPosting_ID = glPosting_ID;
			this.batch_ID = batch_ID;
			this.glPostingDate = glPostingDate;
			this.remark = remark;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Batch_ID value.
		/// </summary>
		public string Batch_ID {
			get { return batch_ID; }
			set { batch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPostingDate value.
		/// </summary>
		public DateTime GlPostingDate {
			get { return glPostingDate; }
			set { glPostingDate = value; }
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
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLPosting_UnpostedTXN table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_UnpostedTXNInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPostingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@glPostingDate"].Value = glPostingDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLPosting_UnpostedTXN table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_UnpostedTXNUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPostingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@glPostingDate"].Value = glPostingDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLPosting_UnpostedTXN table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_UnpostedTXNDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
 
			scom.Parameters["@batch_ID"].Value = batch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLPosting_UnpostedTXN table.
		/// </summary>
		public static tbl_accGLPosting_UnpostedTXN Select(string glPosting_ID_Incoming, string batch_ID_Incoming){

			tbl_accGLPosting_UnpostedTXN tbl_accGLPosting_UnpostedTXNins = new tbl_accGLPosting_UnpostedTXN();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_UnpostedTXNSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID_Incoming;
			scom.Parameters["@batch_ID"].Value = batch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLPosting_UnpostedTXNins = Maketbl_accGLPosting_UnpostedTXN(dataReader);
				} else {
					tbl_accGLPosting_UnpostedTXNins = null;
				}
			}
			scon.Close();
			return tbl_accGLPosting_UnpostedTXNins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLPosting_UnpostedTXN table.
		/// </summary>
		public static List<tbl_accGLPosting_UnpostedTXN> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPosting_UnpostedTXNSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLPosting_UnpostedTXN> tbl_accGLPosting_UnpostedTXNList = new List<tbl_accGLPosting_UnpostedTXN>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLPosting_UnpostedTXN tbl_accGLPosting_UnpostedTXN = Maketbl_accGLPosting_UnpostedTXN(dataReader);
					tbl_accGLPosting_UnpostedTXNList.Add(tbl_accGLPosting_UnpostedTXN);
				}
			}
			scon.Close();
			return tbl_accGLPosting_UnpostedTXNList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLPosting_UnpostedTXN class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLPosting_UnpostedTXN Maketbl_accGLPosting_UnpostedTXN(SqlDataReader dataReader) {
			tbl_accGLPosting_UnpostedTXN tbl_accGLPosting_UnpostedTXN = new tbl_accGLPosting_UnpostedTXN();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLPosting_UnpostedTXN.GlPosting_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLPosting_UnpostedTXN.Batch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLPosting_UnpostedTXN.GlPostingDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLPosting_UnpostedTXN.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLPosting_UnpostedTXN.CreateUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accGLPosting_UnpostedTXN.CreateTerminal_ID = dataReader.GetString(5);
			}

			return tbl_accGLPosting_UnpostedTXN;
		}
		/// <summary>
		/// This makes tbl_accGLPosting_UnpostedTXN datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLPosting_UnpostedTXN object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLPosting_UnpostedTXN  tbl_accGLPosting_UnpostedTXN   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_batch_ID = new DataColumn("batch_ID" , typeof(string));
			DataColumn col_glPostingDate = new DataColumn("glPostingDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_glPosting_ID,col_batch_ID,col_glPostingDate,col_remark,col_createUser_ID,col_createTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLPosting_UnpostedTXN datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLPosting_UnpostedTXN object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLPosting_UnpostedTXN user) {
		DataRow drow = dt.NewRow();
		
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["batch_ID"] = user.batch_ID;
			drow["glPostingDate"] = user.glPostingDate;
			drow["remark"] = user.remark;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
