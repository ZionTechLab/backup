using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_RefBooks {
		#region Fields
		private int book_ID;
		private int route_ID;
		private string book_No;
		private string preFix;
		private int start_Serial;
		private int end_Serial;
		private int length;
		public string Remarks;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_RefBooks class.
		/// </summary>
		public tbl_RefBooks() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_RefBooks class.
		/// </summary>
		public tbl_RefBooks(int book_ID, int route_ID, string book_No, string preFix, int start_Serial, int end_Serial, int length,string Remarks) {
			this.book_ID = book_ID;
			this.route_ID = route_ID;
			this.book_No = book_No;
			this.preFix = preFix;
			this.start_Serial = start_Serial;
			this.end_Serial = end_Serial;
			this.length = length;
			this.Remarks = Remarks;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Book_ID value.
		/// </summary>
		public int Book_ID {
			get { return book_ID; }
			set { book_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public int Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Book_No value.
		/// </summary>
		public string Book_No {
			get { return book_No; }
			set { book_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreFix value.
		/// </summary>
		public string PreFix {
			get { return preFix; }
			set { preFix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Start_Serial value.
		/// </summary>
		public int Start_Serial {
			get { return start_Serial; }
			set { start_Serial = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_Serial value.
		/// </summary>
		public int End_Serial {
			get { return end_Serial; }
			set { end_Serial = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public int Length {
			get { return length; }
			set { length = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_RefBooks table.
		/// </summary>
		public string Insert() {
            string valur = "";
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_RefBooksInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@book_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@book_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@preFix", SqlDbType.VarChar,5);
			scom.Parameters.Add("@start_Serial", SqlDbType.Int,4);
			scom.Parameters.Add("@end_Serial", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@Remarks", SqlDbType.VarChar, 200);

			scom.Parameters["@book_ID"].Value = book_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@book_No"].Value = book_No;
			scom.Parameters["@preFix"].Value = preFix;
			scom.Parameters["@start_Serial"].Value = start_Serial;
			scom.Parameters["@end_Serial"].Value = end_Serial;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@Remarks"].Value = Remarks;

			scon.Open();
		valur=	scom.ExecuteScalar().ToString();
			scon.Close();

            return valur;

        }
		
		/// <summary>
		/// Updates a record in the tbl_RefBooks table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_RefBooksUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@book_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@book_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@preFix", SqlDbType.VarChar,5);
			scom.Parameters.Add("@start_Serial", SqlDbType.Int,4);
			scom.Parameters.Add("@end_Serial", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
 
 
			scom.Parameters["@book_ID"].Value = book_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@book_No"].Value = book_No;
			scom.Parameters["@preFix"].Value = preFix;
			scom.Parameters["@start_Serial"].Value = start_Serial;
			scom.Parameters["@end_Serial"].Value = end_Serial;
			scom.Parameters["@length"].Value = length;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_RefBooks table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_RefBooksDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@book_ID", SqlDbType.Int,4);
			scom.Parameters["@book_ID"].Value = book_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_RefBooks table.
		/// </summary>
		public static tbl_RefBooks Select(int book_ID_Incoming){

			tbl_RefBooks tbl_RefBooksins = new tbl_RefBooks();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_RefBooksSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@book_ID", SqlDbType.Int,4);
			scom.Parameters["@book_ID"].Value = book_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_RefBooksins = Maketbl_RefBooks(dataReader);
				} else {
					tbl_RefBooksins = null;
				}
			}
			scon.Close();
			return tbl_RefBooksins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_RefBooks table.
		/// </summary>
		public static List<tbl_RefBooks> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_RefBooksSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_RefBooks> tbl_RefBooksList = new List<tbl_RefBooks>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_RefBooks tbl_RefBooks = Maketbl_RefBooks(dataReader);
					tbl_RefBooksList.Add(tbl_RefBooks);
				}
			}
			scon.Close();
			return tbl_RefBooksList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_RefBooks class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_RefBooks Maketbl_RefBooks(SqlDataReader dataReader) {
			tbl_RefBooks tbl_RefBooks = new tbl_RefBooks();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_RefBooks.Book_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_RefBooks.Route_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_RefBooks.Book_No = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_RefBooks.PreFix = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_RefBooks.Start_Serial = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_RefBooks.End_Serial = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_RefBooks.Length = dataReader.GetInt32(6);
			}

			return tbl_RefBooks;
		}
		/// <summary>
		/// This makes tbl_RefBooks datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_RefBooks object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_RefBooks  tbl_RefBooks   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_book_ID = new DataColumn("book_ID" , typeof(int));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(int));
			DataColumn col_book_No = new DataColumn("book_No" , typeof(string));
			DataColumn col_preFix = new DataColumn("preFix" , typeof(string));
			DataColumn col_start_Serial = new DataColumn("start_Serial" , typeof(int));
			DataColumn col_end_Serial = new DataColumn("end_Serial" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_book_ID,col_route_ID,col_book_No,col_preFix,col_start_Serial,col_end_Serial,col_length,});		return dt;
		}
		/// <summary>
		/// This fills tbl_RefBooks datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_RefBooks object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_RefBooks user) {
		DataRow drow = dt.NewRow();
		
			drow["book_ID"] = user.book_ID;
			drow["route_ID"] = user.route_ID;
			drow["book_No"] = user.book_No;
			drow["preFix"] = user.preFix;
			drow["start_Serial"] = user.start_Serial;
			drow["end_Serial"] = user.end_Serial;
			drow["length"] = user.length;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
