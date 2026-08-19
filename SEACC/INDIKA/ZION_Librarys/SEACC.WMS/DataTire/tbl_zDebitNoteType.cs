using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zDebitNoteType {
		#region Fields
		private string debitNoteType_ID;
		private string debitNoteTypeName;
		private string prefix;
		private int counter;
		private int length;
		private string gl_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zDebitNoteType class.
		/// </summary>
		public tbl_zDebitNoteType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zDebitNoteType class.
		/// </summary>
		public tbl_zDebitNoteType(string debitNoteType_ID, string debitNoteTypeName, string prefix, int counter, int length, string gl_ID) {
			this.debitNoteType_ID = debitNoteType_ID;
			this.debitNoteTypeName = debitNoteTypeName;
			this.prefix = prefix;
			this.counter = counter;
			this.length = length;
			this.gl_ID = gl_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DebitNoteType_ID value.
		/// </summary>
		public string DebitNoteType_ID {
			get { return debitNoteType_ID; }
			set { debitNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DebitNoteTypeName value.
		/// </summary>
		public string DebitNoteTypeName {
			get { return debitNoteTypeName; }
			set { debitNoteTypeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
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
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zDebitNoteType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDebitNoteTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@debitNoteTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@debitNoteType_ID"].Value = debitNoteType_ID;
			scom.Parameters["@debitNoteTypeName"].Value = debitNoteTypeName;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zDebitNoteType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDebitNoteTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@debitNoteTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@debitNoteType_ID"].Value = debitNoteType_ID;
			scom.Parameters["@debitNoteTypeName"].Value = debitNoteTypeName;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zDebitNoteType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDebitNoteTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@debitNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@debitNoteType_ID"].Value = debitNoteType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zDebitNoteType table.
		/// </summary>
		public static tbl_zDebitNoteType Select(string debitNoteType_ID_Incoming){

			tbl_zDebitNoteType tbl_zDebitNoteTypeins = new tbl_zDebitNoteType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDebitNoteTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@debitNoteType_ID"].Value = debitNoteType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zDebitNoteTypeins = Maketbl_zDebitNoteType(dataReader);
				} else {
					tbl_zDebitNoteTypeins = null;
				}
			}
			scon.Close();
			return tbl_zDebitNoteTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDebitNoteType table.
		/// </summary>
		public static List<tbl_zDebitNoteType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDebitNoteTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zDebitNoteType> tbl_zDebitNoteTypeList = new List<tbl_zDebitNoteType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zDebitNoteType tbl_zDebitNoteType = Maketbl_zDebitNoteType(dataReader);
					tbl_zDebitNoteTypeList.Add(tbl_zDebitNoteType);
				}
			}
			scon.Close();
			return tbl_zDebitNoteTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zDebitNoteType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zDebitNoteType Maketbl_zDebitNoteType(SqlDataReader dataReader) {
			tbl_zDebitNoteType tbl_zDebitNoteType = new tbl_zDebitNoteType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zDebitNoteType.DebitNoteType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zDebitNoteType.DebitNoteTypeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zDebitNoteType.Prefix = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zDebitNoteType.Counter = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zDebitNoteType.Length = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zDebitNoteType.Gl_ID = dataReader.GetString(5);
			}

			return tbl_zDebitNoteType;
		}
		/// <summary>
		/// This makes tbl_zDebitNoteType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zDebitNoteType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zDebitNoteType  tbl_zDebitNoteType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_debitNoteType_ID = new DataColumn("debitNoteType_ID" , typeof(string));
			DataColumn col_debitNoteTypeName = new DataColumn("debitNoteTypeName" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_debitNoteType_ID,col_debitNoteTypeName,col_prefix,col_counter,col_length,col_gl_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zDebitNoteType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zDebitNoteType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zDebitNoteType user) {
		DataRow drow = dt.NewRow();
		
			drow["debitNoteType_ID"] = user.debitNoteType_ID;
			drow["debitNoteTypeName"] = user.debitNoteTypeName;
			drow["prefix"] = user.prefix;
			drow["counter"] = user.counter;
			drow["length"] = user.length;
			drow["gl_ID"] = user.gl_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
