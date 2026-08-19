using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCustomerAddressBook {
		#region Fields
		private int line_No;
		private string customer_ID;
		private string contactName;
		private string designation;
		private string telephone;
		private string mobile;
		private string fax;
		private string email;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerAddressBook class.
		/// </summary>
		public tbl_genCustomerAddressBook() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerAddressBook class.
		/// </summary>
		public tbl_genCustomerAddressBook(int line_No, string customer_ID, string contactName, string designation, string telephone, string mobile, string fax, string email) {
			this.line_No = line_No;
			this.customer_ID = customer_ID;
			this.contactName = contactName;
			this.designation = designation;
			this.telephone = telephone;
			this.mobile = mobile;
			this.fax = fax;
			this.email = email;
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
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ContactName value.
		/// </summary>
		public string ContactName {
			get { return contactName; }
			set { contactName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Designation value.
		/// </summary>
		public string Designation {
			get { return designation; }
			set { designation = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone {
			get { return telephone; }
			set { telephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mobile value.
		/// </summary>
		public string Mobile {
			get { return mobile; }
			set { mobile = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fax value.
		/// </summary>
		public string Fax {
			get { return fax; }
			set { fax = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email {
			get { return email; }
			set { email = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCustomerAddressBook table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAddressBookInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@contactName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@designation", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mobile", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@contactName"].Value = contactName;
			scom.Parameters["@designation"].Value = designation;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@mobile"].Value = mobile;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCustomerAddressBook table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAddressBookUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@contactName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@designation", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mobile", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@contactName"].Value = contactName;
			scom.Parameters["@designation"].Value = designation;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@mobile"].Value = mobile;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCustomerAddressBook table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAddressBookDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@contactName", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scom.Parameters["@contactName"].Value = contactName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAddressBook table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAddressBookDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCustomerAddressBook table.
		/// </summary>
		public static tbl_genCustomerAddressBook Select(int line_No_Incoming, string customer_ID_Incoming, string contactName_Incoming){

			tbl_genCustomerAddressBook tbl_genCustomerAddressBookins = new tbl_genCustomerAddressBook();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAddressBookSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@contactName", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			scom.Parameters["@contactName"].Value = contactName_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCustomerAddressBookins = Maketbl_genCustomerAddressBook(dataReader);
				} else {
					tbl_genCustomerAddressBookins = null;
				}
			}
			scon.Close();
			return tbl_genCustomerAddressBookins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAddressBook table.
		/// </summary>
		public static List<tbl_genCustomerAddressBook> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAddressBookSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCustomerAddressBook> tbl_genCustomerAddressBookList = new List<tbl_genCustomerAddressBook>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerAddressBook tbl_genCustomerAddressBook = Maketbl_genCustomerAddressBook(dataReader);
					tbl_genCustomerAddressBookList.Add(tbl_genCustomerAddressBook);
				}
			}
			scon.Close();
			return tbl_genCustomerAddressBookList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAddressBook table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerAddressBook> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAddressBookSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genCustomerAddressBook> tbl_genCustomerAddressBookList = new List<tbl_genCustomerAddressBook>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerAddressBook tbl_genCustomerAddressBook = Maketbl_genCustomerAddressBook(dataReader);
					tbl_genCustomerAddressBookList.Add(tbl_genCustomerAddressBook);
				}
			}
			scon.Close();
			return tbl_genCustomerAddressBookList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCustomerAddressBook class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCustomerAddressBook Maketbl_genCustomerAddressBook(SqlDataReader dataReader) {
			tbl_genCustomerAddressBook tbl_genCustomerAddressBook = new tbl_genCustomerAddressBook();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCustomerAddressBook.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCustomerAddressBook.Customer_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCustomerAddressBook.ContactName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCustomerAddressBook.Designation = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCustomerAddressBook.Telephone = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genCustomerAddressBook.Mobile = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genCustomerAddressBook.Fax = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genCustomerAddressBook.Email = dataReader.GetString(7);
			}

			return tbl_genCustomerAddressBook;
		}
		/// <summary>
		/// This makes tbl_genCustomerAddressBook datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCustomerAddressBook object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCustomerAddressBook  tbl_genCustomerAddressBook   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_contactName = new DataColumn("contactName" , typeof(string));
			DataColumn col_designation = new DataColumn("designation" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_mobile = new DataColumn("mobile" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_customer_ID,col_contactName,col_designation,col_telephone,col_mobile,col_fax,col_email,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCustomerAddressBook datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCustomerAddressBook object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCustomerAddressBook user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["customer_ID"] = user.customer_ID;
			drow["contactName"] = user.contactName;
			drow["designation"] = user.designation;
			drow["telephone"] = user.telephone;
			drow["mobile"] = user.mobile;
			drow["fax"] = user.fax;
			drow["email"] = user.email;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
