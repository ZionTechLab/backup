using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityProcessNoteCatogory {
		#region Fields
		private int processNoteCategory_ID;
		private string processNoteCategoryName;
		private bool isEnable_bulkApprove;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityProcessNoteCatogory class.
		/// </summary>
		public tbl_securityProcessNoteCatogory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityProcessNoteCatogory class.
		/// </summary>
		public tbl_securityProcessNoteCatogory(int processNoteCategory_ID, string processNoteCategoryName, bool isEnable_bulkApprove) {
			this.processNoteCategory_ID = processNoteCategory_ID;
			this.processNoteCategoryName = processNoteCategoryName;
			this.isEnable_bulkApprove = isEnable_bulkApprove;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProcessNoteCategory_ID value.
		/// </summary>
		public int ProcessNoteCategory_ID {
			get { return processNoteCategory_ID; }
			set { processNoteCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessNoteCategoryName value.
		/// </summary>
		public string ProcessNoteCategoryName {
			get { return processNoteCategoryName; }
			set { processNoteCategoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEnable_bulkApprove value.
		/// </summary>
		public bool IsEnable_bulkApprove {
			get { return isEnable_bulkApprove; }
			set { isEnable_bulkApprove = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityProcessNoteCatogory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteCatogoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@processNoteCategory_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processNoteCategoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isEnable_bulkApprove", SqlDbType.Bit,1);
 
			scom.Parameters["@processNoteCategory_ID"].Value = processNoteCategory_ID;
			scom.Parameters["@processNoteCategoryName"].Value = processNoteCategoryName;
			scom.Parameters["@isEnable_bulkApprove"].Value = isEnable_bulkApprove;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityProcessNoteCatogory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteCatogoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@processNoteCategory_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processNoteCategoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isEnable_bulkApprove", SqlDbType.Bit,1);
 
 
			scom.Parameters["@processNoteCategory_ID"].Value = processNoteCategory_ID;
			scom.Parameters["@processNoteCategoryName"].Value = processNoteCategoryName;
			scom.Parameters["@isEnable_bulkApprove"].Value = isEnable_bulkApprove;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityProcessNoteCatogory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteCatogoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@processNoteCategory_ID", SqlDbType.Int,4);
			scom.Parameters["@processNoteCategory_ID"].Value = processNoteCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityProcessNoteCatogory table.
		/// </summary>
		public static tbl_securityProcessNoteCatogory Select(int processNoteCategory_ID_Incoming){

			tbl_securityProcessNoteCatogory tbl_securityProcessNoteCatogoryins = new tbl_securityProcessNoteCatogory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteCatogorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNoteCategory_ID", SqlDbType.Int,4);
			scom.Parameters["@processNoteCategory_ID"].Value = processNoteCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityProcessNoteCatogoryins = Maketbl_securityProcessNoteCatogory(dataReader);
				} else {
					tbl_securityProcessNoteCatogoryins = null;
				}
			}
			scon.Close();
			return tbl_securityProcessNoteCatogoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityProcessNoteCatogory table.
		/// </summary>
		public static List<tbl_securityProcessNoteCatogory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteCatogorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityProcessNoteCatogory> tbl_securityProcessNoteCatogoryList = new List<tbl_securityProcessNoteCatogory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityProcessNoteCatogory tbl_securityProcessNoteCatogory = Maketbl_securityProcessNoteCatogory(dataReader);
					tbl_securityProcessNoteCatogoryList.Add(tbl_securityProcessNoteCatogory);
				}
			}
			scon.Close();
			return tbl_securityProcessNoteCatogoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityProcessNoteCatogory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityProcessNoteCatogory Maketbl_securityProcessNoteCatogory(SqlDataReader dataReader) {
			tbl_securityProcessNoteCatogory tbl_securityProcessNoteCatogory = new tbl_securityProcessNoteCatogory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityProcessNoteCatogory.ProcessNoteCategory_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityProcessNoteCatogory.ProcessNoteCategoryName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityProcessNoteCatogory.IsEnable_bulkApprove = dataReader.GetBoolean(2);
			}

			return tbl_securityProcessNoteCatogory;
		}
		/// <summary>
		/// This makes tbl_securityProcessNoteCatogory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityProcessNoteCatogory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityProcessNoteCatogory  tbl_securityProcessNoteCatogory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_processNoteCategory_ID = new DataColumn("processNoteCategory_ID" , typeof(int));
			DataColumn col_processNoteCategoryName = new DataColumn("processNoteCategoryName" , typeof(string));
			DataColumn col_isEnable_bulkApprove = new DataColumn("isEnable_bulkApprove" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_processNoteCategory_ID,col_processNoteCategoryName,col_isEnable_bulkApprove,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityProcessNoteCatogory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityProcessNoteCatogory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityProcessNoteCatogory user) {
		DataRow drow = dt.NewRow();
		
			drow["processNoteCategory_ID"] = user.processNoteCategory_ID;
			drow["processNoteCategoryName"] = user.processNoteCategoryName;
			drow["isEnable_bulkApprove"] = user.isEnable_bulkApprove;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
