using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityProcessNoteMaster {
		#region Fields
		private int processNote_ID;
		private string processNoteName;
		private int processNoteCategory_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityProcessNoteMaster class.
		/// </summary>
		public tbl_securityProcessNoteMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityProcessNoteMaster class.
		/// </summary>
		public tbl_securityProcessNoteMaster(int processNote_ID, string processNoteName, int processNoteCategory_ID) {
			this.processNote_ID = processNote_ID;
			this.processNoteName = processNoteName;
			this.processNoteCategory_ID = processNoteCategory_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProcessNote_ID value.
		/// </summary>
		public int ProcessNote_ID {
			get { return processNote_ID; }
			set { processNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessNoteName value.
		/// </summary>
		public string ProcessNoteName {
			get { return processNoteName; }
			set { processNoteName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessNoteCategory_ID value.
		/// </summary>
		public int ProcessNoteCategory_ID {
			get { return processNoteCategory_ID; }
			set { processNoteCategory_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityProcessNoteMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processNoteName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@processNoteCategory_ID", SqlDbType.Int,4);
 
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@processNoteName"].Value = processNoteName;
			scom.Parameters["@processNoteCategory_ID"].Value = processNoteCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityProcessNoteMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processNoteName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@processNoteCategory_ID", SqlDbType.Int,4);
 
 
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@processNoteName"].Value = processNoteName;
			scom.Parameters["@processNoteCategory_ID"].Value = processNoteCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityProcessNoteMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityProcessNoteMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByProcessNoteCategory_ID(int processNoteCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteMasterDeleteAllByProcessNoteCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNoteCategory_ID", SqlDbType.Int,4);
			scom.Parameters["@processNoteCategory_ID"].Value = processNoteCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityProcessNoteMaster table.
		/// </summary>
		public static tbl_securityProcessNoteMaster Select(int processNote_ID_Incoming){

			tbl_securityProcessNoteMaster tbl_securityProcessNoteMasterins = new tbl_securityProcessNoteMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityProcessNoteMasterins = Maketbl_securityProcessNoteMaster(dataReader);
				} else {
					tbl_securityProcessNoteMasterins = null;
				}
			}
			scon.Close();
			return tbl_securityProcessNoteMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityProcessNoteMaster table.
		/// </summary>
		public static List<tbl_securityProcessNoteMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityProcessNoteMaster> tbl_securityProcessNoteMasterList = new List<tbl_securityProcessNoteMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityProcessNoteMaster tbl_securityProcessNoteMaster = Maketbl_securityProcessNoteMaster(dataReader);
					tbl_securityProcessNoteMasterList.Add(tbl_securityProcessNoteMaster);
				}
			}
			scon.Close();
			return tbl_securityProcessNoteMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityProcessNoteMaster table by a foreign key.
		/// </summary>
		public static List<tbl_securityProcessNoteMaster> SelectAllByProcessNoteCategory_ID(int processNoteCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProcessNoteMasterSelectAllByProcessNoteCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNoteCategory_ID", SqlDbType.Int,4);
			scom.Parameters["@processNoteCategory_ID"].Value = processNoteCategory_ID;
				List<tbl_securityProcessNoteMaster> tbl_securityProcessNoteMasterList = new List<tbl_securityProcessNoteMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityProcessNoteMaster tbl_securityProcessNoteMaster = Maketbl_securityProcessNoteMaster(dataReader);
					tbl_securityProcessNoteMasterList.Add(tbl_securityProcessNoteMaster);
				}
			}
			scon.Close();
			return tbl_securityProcessNoteMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityProcessNoteMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityProcessNoteMaster Maketbl_securityProcessNoteMaster(SqlDataReader dataReader) {
			tbl_securityProcessNoteMaster tbl_securityProcessNoteMaster = new tbl_securityProcessNoteMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityProcessNoteMaster.ProcessNote_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityProcessNoteMaster.ProcessNoteName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityProcessNoteMaster.ProcessNoteCategory_ID = dataReader.GetInt32(2);
			}

			return tbl_securityProcessNoteMaster;
		}
		/// <summary>
		/// This makes tbl_securityProcessNoteMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityProcessNoteMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityProcessNoteMaster  tbl_securityProcessNoteMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_processNote_ID = new DataColumn("processNote_ID" , typeof(int));
			DataColumn col_processNoteName = new DataColumn("processNoteName" , typeof(string));
			DataColumn col_processNoteCategory_ID = new DataColumn("processNoteCategory_ID" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_processNote_ID,col_processNoteName,col_processNoteCategory_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityProcessNoteMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityProcessNoteMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityProcessNoteMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["processNote_ID"] = user.processNote_ID;
			drow["processNoteName"] = user.processNoteName;
			drow["processNoteCategory_ID"] = user.processNoteCategory_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
