using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_RefBook_Pages {
		#region Fields
		private int book_ID;
		private string page;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_RefBook_Pages class.
		/// </summary>
		public tbl_RefBook_Pages() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_RefBook_Pages class.
		/// </summary>
		public tbl_RefBook_Pages(int book_ID, string page) {
			this.book_ID = book_ID;
			this.page = page;
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
		/// Gets or sets the Page value.
		/// </summary>
		public string Page {
			get { return page; }
			set { page = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_RefBook_Pages table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_RefBook_PagesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@book_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@Page", SqlDbType.VarChar,20);
 
			scom.Parameters["@book_ID"].Value = book_ID;
			scom.Parameters["@Page"].Value = page;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_RefBook_Pages table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_RefBook_PagesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@book_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@Page", SqlDbType.VarChar,20);
			scom.Parameters["@book_ID"].Value = book_ID;
 
			scom.Parameters["@Page"].Value = page;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_RefBook_Pages table.
		/// </summary>
		public static tbl_RefBook_Pages Select(int book_ID_Incoming, string page_Incoming){

			tbl_RefBook_Pages tbl_RefBook_Pagesins = new tbl_RefBook_Pages();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_RefBook_PagesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@book_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@Page", SqlDbType.VarChar,20);
			scom.Parameters["@book_ID"].Value = book_ID_Incoming;
			scom.Parameters["@Page"].Value = page_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_RefBook_Pagesins = Maketbl_RefBook_Pages(dataReader);
				} else {
					tbl_RefBook_Pagesins = null;
				}
			}
			scon.Close();
			return tbl_RefBook_Pagesins;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_RefBook_Pages class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_RefBook_Pages Maketbl_RefBook_Pages(SqlDataReader dataReader) {
			tbl_RefBook_Pages tbl_RefBook_Pages = new tbl_RefBook_Pages();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_RefBook_Pages.Book_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_RefBook_Pages.Page = dataReader.GetString(1);
			}

			return tbl_RefBook_Pages;
		}
		/// <summary>
		/// This makes tbl_RefBook_Pages datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_RefBook_Pages object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_RefBook_Pages  tbl_RefBook_Pages   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_book_ID = new DataColumn("book_ID" , typeof(int));
			DataColumn col_Page = new DataColumn("Page" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_book_ID,col_Page,});		return dt;
		}
		/// <summary>
		/// This fills tbl_RefBook_Pages datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_RefBook_Pages object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_RefBook_Pages user) {
		DataRow drow = dt.NewRow();
		
			drow["book_ID"] = user.book_ID;
			drow["Page"] = user.Page;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
