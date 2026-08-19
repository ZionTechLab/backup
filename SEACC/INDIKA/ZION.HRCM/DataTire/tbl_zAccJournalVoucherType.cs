using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccJournalVoucherType {
		#region Fields
		private string journalEntryType_ID;
		private string journalEntryName;
		private int counter;
		private int length;
		private string prefix1;
		private string seperator1;
		private string prefix2;
		private string seperator2;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccJournalVoucherType class.
		/// </summary>
		public tbl_zAccJournalVoucherType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccJournalVoucherType class.
		/// </summary>
		public tbl_zAccJournalVoucherType(string journalEntryType_ID, string journalEntryName, int counter, int length, string prefix1, string seperator1, string prefix2, string seperator2) {
			this.journalEntryType_ID = journalEntryType_ID;
			this.journalEntryName = journalEntryName;
			this.counter = counter;
			this.length = length;
			this.prefix1 = prefix1;
			this.seperator1 = seperator1;
			this.prefix2 = prefix2;
			this.seperator2 = seperator2;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the JournalEntryType_ID value.
		/// </summary>
		public string JournalEntryType_ID {
			get { return journalEntryType_ID; }
			set { journalEntryType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the JournalEntryName value.
		/// </summary>
		public string JournalEntryName {
			get { return journalEntryName; }
			set { journalEntryName = value; }
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
		/// Gets or sets the Prefix1 value.
		/// </summary>
		public string Prefix1 {
			get { return prefix1; }
			set { prefix1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Seperator1 value.
		/// </summary>
		public string Seperator1 {
			get { return seperator1; }
			set { seperator1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix2 value.
		/// </summary>
		public string Prefix2 {
			get { return prefix2; }
			set { prefix2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Seperator2 value.
		/// </summary>
		public string Seperator2 {
			get { return seperator2; }
			set { seperator2 = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccJournalVoucherType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccJournalVoucherTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@journalEntryType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@JournalEntryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator2", SqlDbType.VarChar,50);
 
			scom.Parameters["@journalEntryType_ID"].Value = journalEntryType_ID;
			scom.Parameters["@JournalEntryName"].Value = journalEntryName;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix1"].Value = prefix1;
			scom.Parameters["@seperator1"].Value = seperator1;
			scom.Parameters["@prefix2"].Value = prefix2;
			scom.Parameters["@seperator2"].Value = seperator2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccJournalVoucherType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccJournalVoucherTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@journalEntryType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@JournalEntryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator2", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@journalEntryType_ID"].Value = journalEntryType_ID;
			scom.Parameters["@JournalEntryName"].Value = journalEntryName;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix1"].Value = prefix1;
			scom.Parameters["@seperator1"].Value = seperator1;
			scom.Parameters["@prefix2"].Value = prefix2;
			scom.Parameters["@seperator2"].Value = seperator2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccJournalVoucherType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccJournalVoucherTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@journalEntryType_ID", SqlDbType.VarChar,20);
			scom.Parameters["@journalEntryType_ID"].Value = journalEntryType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccJournalVoucherType table.
		/// </summary>
		public static tbl_zAccJournalVoucherType Select(string journalEntryType_ID_Incoming){

			tbl_zAccJournalVoucherType tbl_zAccJournalVoucherTypeins = new tbl_zAccJournalVoucherType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccJournalVoucherTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@journalEntryType_ID", SqlDbType.VarChar,20);
			scom.Parameters["@journalEntryType_ID"].Value = journalEntryType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccJournalVoucherTypeins = Maketbl_zAccJournalVoucherType(dataReader);
				} else {
					tbl_zAccJournalVoucherTypeins = null;
				}
			}
			scon.Close();
			return tbl_zAccJournalVoucherTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccJournalVoucherType table.
		/// </summary>
		public static List<tbl_zAccJournalVoucherType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccJournalVoucherTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccJournalVoucherType> tbl_zAccJournalVoucherTypeList = new List<tbl_zAccJournalVoucherType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccJournalVoucherType tbl_zAccJournalVoucherType = Maketbl_zAccJournalVoucherType(dataReader);
					tbl_zAccJournalVoucherTypeList.Add(tbl_zAccJournalVoucherType);
				}
			}
			scon.Close();
			return tbl_zAccJournalVoucherTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccJournalVoucherType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccJournalVoucherType Maketbl_zAccJournalVoucherType(SqlDataReader dataReader) {
			tbl_zAccJournalVoucherType tbl_zAccJournalVoucherType = new tbl_zAccJournalVoucherType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccJournalVoucherType.JournalEntryType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccJournalVoucherType.JournalEntryName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zAccJournalVoucherType.Counter = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zAccJournalVoucherType.Length = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zAccJournalVoucherType.Prefix1 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zAccJournalVoucherType.Seperator1 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zAccJournalVoucherType.Prefix2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zAccJournalVoucherType.Seperator2 = dataReader.GetString(7);
			}

			return tbl_zAccJournalVoucherType;
		}
		/// <summary>
		/// This makes tbl_zAccJournalVoucherType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccJournalVoucherType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccJournalVoucherType  tbl_zAccJournalVoucherType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_journalEntryType_ID = new DataColumn("journalEntryType_ID" , typeof(string));
			DataColumn col_JournalEntryName = new DataColumn("JournalEntryName" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_prefix1 = new DataColumn("prefix1" , typeof(string));
			DataColumn col_seperator1 = new DataColumn("seperator1" , typeof(string));
			DataColumn col_prefix2 = new DataColumn("prefix2" , typeof(string));
			DataColumn col_seperator2 = new DataColumn("seperator2" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_journalEntryType_ID,col_JournalEntryName,col_counter,col_length,col_prefix1,col_seperator1,col_prefix2,col_seperator2,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccJournalVoucherType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccJournalVoucherType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccJournalVoucherType user) {
		DataRow drow = dt.NewRow();
		
			drow["journalEntryType_ID"] = user.journalEntryType_ID;
			drow["JournalEntryName"] = user.JournalEntryName;
			drow["counter"] = user.counter;
			drow["length"] = user.length;
			drow["prefix1"] = user.prefix1;
			drow["seperator1"] = user.seperator1;
			drow["prefix2"] = user.prefix2;
			drow["seperator2"] = user.seperator2;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
