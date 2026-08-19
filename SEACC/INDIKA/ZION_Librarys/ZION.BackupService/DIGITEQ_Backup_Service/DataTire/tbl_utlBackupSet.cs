using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlBackupSet {
		#region Fields
		private int backUpSet_ID;
		private string backUpSet_Name;
		private string db;
		private string folderPath1;
		private string folderPath2;
		private string folderPath3;
		private string targetPath;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlBackupSet class.
		/// </summary>
		public tbl_utlBackupSet() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlBackupSet class.
		/// </summary>
		public tbl_utlBackupSet(int backUpSet_ID, string backUpSet_Name, string db, string folderPath1, string folderPath2, string folderPath3, string targetPath) {
			this.backUpSet_ID = backUpSet_ID;
			this.backUpSet_Name = backUpSet_Name;
			this.db = db;
			this.folderPath1 = folderPath1;
			this.folderPath2 = folderPath2;
			this.folderPath3 = folderPath3;
			this.targetPath = targetPath;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the BackUpSet_ID value.
		/// </summary>
		public int BackUpSet_ID {
			get { return backUpSet_ID; }
			set { backUpSet_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BackUpSet_Name value.
		/// </summary>
		public string BackUpSet_Name {
			get { return backUpSet_Name; }
			set { backUpSet_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Db value.
		/// </summary>
		public string Db {
			get { return db; }
			set { db = value; }
		}
		
		/// <summary>
		/// Gets or sets the FolderPath1 value.
		/// </summary>
		public string FolderPath1 {
			get { return folderPath1; }
			set { folderPath1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the FolderPath2 value.
		/// </summary>
		public string FolderPath2 {
			get { return folderPath2; }
			set { folderPath2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the FolderPath3 value.
		/// </summary>
		public string FolderPath3 {
			get { return folderPath3; }
			set { folderPath3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the TargetPath value.
		/// </summary>
		public string TargetPath {
			get { return targetPath; }
			set { targetPath = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlBackupSet table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackupSetInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@backUpSet_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@backUpSet_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@db", SqlDbType.VarChar,100);
			scom.Parameters.Add("@folderPath1", SqlDbType.VarChar,500);
			scom.Parameters.Add("@folderPath2", SqlDbType.VarChar,500);
			scom.Parameters.Add("@folderPath3", SqlDbType.VarChar,500);
			scom.Parameters.Add("@targetPath", SqlDbType.VarChar,500);
 
			scom.Parameters["@backUpSet_ID"].Value = backUpSet_ID;
			scom.Parameters["@backUpSet_Name"].Value = backUpSet_Name;
			scom.Parameters["@db"].Value = db;
			scom.Parameters["@folderPath1"].Value = folderPath1;
			scom.Parameters["@folderPath2"].Value = folderPath2;
			scom.Parameters["@folderPath3"].Value = folderPath3;
			scom.Parameters["@targetPath"].Value = targetPath;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlBackupSet table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackupSetUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@backUpSet_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@backUpSet_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@db", SqlDbType.VarChar,100);
			scom.Parameters.Add("@folderPath1", SqlDbType.VarChar,500);
			scom.Parameters.Add("@folderPath2", SqlDbType.VarChar,500);
			scom.Parameters.Add("@folderPath3", SqlDbType.VarChar,500);
			scom.Parameters.Add("@targetPath", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@backUpSet_ID"].Value = backUpSet_ID;
			scom.Parameters["@backUpSet_Name"].Value = backUpSet_Name;
			scom.Parameters["@db"].Value = db;
			scom.Parameters["@folderPath1"].Value = folderPath1;
			scom.Parameters["@folderPath2"].Value = folderPath2;
			scom.Parameters["@folderPath3"].Value = folderPath3;
			scom.Parameters["@targetPath"].Value = targetPath;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlBackupSet table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackupSetDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@backUpSet_ID", SqlDbType.Int,4);
			scom.Parameters["@backUpSet_ID"].Value = backUpSet_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlBackupSet table.
		/// </summary>
		public static tbl_utlBackupSet Select(int backUpSet_ID_Incoming){

			tbl_utlBackupSet tbl_utlBackupSetins = new tbl_utlBackupSet();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackupSetSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@backUpSet_ID", SqlDbType.Int,4);
			scom.Parameters["@backUpSet_ID"].Value = backUpSet_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlBackupSetins = Maketbl_utlBackupSet(dataReader);
				} else {
					tbl_utlBackupSetins = null;
				}
			}
			scon.Close();
			return tbl_utlBackupSetins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlBackupSet table.
		/// </summary>
		public static List<tbl_utlBackupSet> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackupSetSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlBackupSet> tbl_utlBackupSetList = new List<tbl_utlBackupSet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlBackupSet tbl_utlBackupSet = Maketbl_utlBackupSet(dataReader);
					tbl_utlBackupSetList.Add(tbl_utlBackupSet);
				}
			}
			scon.Close();
			return tbl_utlBackupSetList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlBackupSet class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlBackupSet Maketbl_utlBackupSet(SqlDataReader dataReader) {
			tbl_utlBackupSet tbl_utlBackupSet = new tbl_utlBackupSet();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlBackupSet.BackUpSet_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlBackupSet.BackUpSet_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlBackupSet.Db = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlBackupSet.FolderPath1 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlBackupSet.FolderPath2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlBackupSet.FolderPath3 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_utlBackupSet.TargetPath = dataReader.GetString(6);
			}

			return tbl_utlBackupSet;
		}
		/// <summary>
		/// This makes tbl_utlBackupSet datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlBackupSet object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlBackupSet  tbl_utlBackupSet   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_backUpSet_ID = new DataColumn("backUpSet_ID" , typeof(int));
			DataColumn col_backUpSet_Name = new DataColumn("backUpSet_Name" , typeof(string));
			DataColumn col_db = new DataColumn("db" , typeof(string));
			DataColumn col_folderPath1 = new DataColumn("folderPath1" , typeof(string));
			DataColumn col_folderPath2 = new DataColumn("folderPath2" , typeof(string));
			DataColumn col_folderPath3 = new DataColumn("folderPath3" , typeof(string));
			DataColumn col_targetPath = new DataColumn("targetPath" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_backUpSet_ID,col_backUpSet_Name,col_db,col_folderPath1,col_folderPath2,col_folderPath3,col_targetPath,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlBackupSet datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlBackupSet object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlBackupSet user) {
		DataRow drow = dt.NewRow();
		
			drow["backUpSet_ID"] = user.backUpSet_ID;
			drow["backUpSet_Name"] = user.backUpSet_Name;
			drow["db"] = user.db;
			drow["folderPath1"] = user.folderPath1;
			drow["folderPath2"] = user.folderPath2;
			drow["folderPath3"] = user.folderPath3;
			drow["targetPath"] = user.targetPath;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
