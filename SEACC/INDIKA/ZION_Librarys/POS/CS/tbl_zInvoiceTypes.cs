using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zInvoiceTypes {
		#region Fields
		private int invoiceType_ID;
		private string invoiceType_Name;
		private string prefix;
		private int length;
		private int counter;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zInvoiceTypes class.
		/// </summary>
		public tbl_zInvoiceTypes() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zInvoiceTypes class.
		/// </summary>
		public tbl_zInvoiceTypes(int invoiceType_ID, string invoiceType_Name, string prefix, int length, int counter) {
			this.invoiceType_ID = invoiceType_ID;
			this.invoiceType_Name = invoiceType_Name;
			this.prefix = prefix;
			this.length = length;
			this.counter = counter;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the InvoiceType_ID value.
		/// </summary>
		public int InvoiceType_ID {
			get { return invoiceType_ID; }
			set { invoiceType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceType_Name value.
		/// </summary>
		public string InvoiceType_Name {
			get { return invoiceType_Name; }
			set { invoiceType_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public int Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public int Counter {
			get { return counter; }
			set { counter = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zInvoiceTypes table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zInvoiceTypesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@invoiceType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@invoiceType_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
 
			scom.Parameters["@invoiceType_ID"].Value = invoiceType_ID;
			scom.Parameters["@invoiceType_Name"].Value = invoiceType_Name;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zInvoiceTypes table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zInvoiceTypesUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@invoiceType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@invoiceType_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
 
 
			scom.Parameters["@invoiceType_ID"].Value = invoiceType_ID;
			scom.Parameters["@invoiceType_Name"].Value = invoiceType_Name;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zInvoiceTypes table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zInvoiceTypesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@invoiceType_ID", SqlDbType.Int,4);
			scom.Parameters["@invoiceType_ID"].Value = invoiceType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zInvoiceTypes table.
		/// </summary>
		public static tbl_zInvoiceTypes Select(int invoiceType_ID_Incoming){

			tbl_zInvoiceTypes tbl_zInvoiceTypesins = new tbl_zInvoiceTypes();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zInvoiceTypesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoiceType_ID", SqlDbType.Int,4);
			scom.Parameters["@invoiceType_ID"].Value = invoiceType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zInvoiceTypesins = Maketbl_zInvoiceTypes(dataReader);
				} else {
					tbl_zInvoiceTypesins = null;
				}
			}
			scon.Close();
			return tbl_zInvoiceTypesins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zInvoiceTypes table.
		/// </summary>
		public static List<tbl_zInvoiceTypes> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zInvoiceTypesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zInvoiceTypes> tbl_zInvoiceTypesList = new List<tbl_zInvoiceTypes>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zInvoiceTypes tbl_zInvoiceTypes = Maketbl_zInvoiceTypes(dataReader);
					tbl_zInvoiceTypesList.Add(tbl_zInvoiceTypes);
				}
			}
			scon.Close();
			return tbl_zInvoiceTypesList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zInvoiceTypes class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zInvoiceTypes Maketbl_zInvoiceTypes(SqlDataReader dataReader) {
			tbl_zInvoiceTypes tbl_zInvoiceTypes = new tbl_zInvoiceTypes();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zInvoiceTypes.InvoiceType_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zInvoiceTypes.InvoiceType_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zInvoiceTypes.Prefix = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zInvoiceTypes.Length = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zInvoiceTypes.Counter = dataReader.GetInt32(4);
			}

			return tbl_zInvoiceTypes;
		}
		/// <summary>
		/// This makes tbl_zInvoiceTypes datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zInvoiceTypes object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zInvoiceTypes  tbl_zInvoiceTypes   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_invoiceType_ID = new DataColumn("invoiceType_ID" , typeof(int));
			DataColumn col_invoiceType_Name = new DataColumn("invoiceType_Name" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_invoiceType_ID,col_invoiceType_Name,col_prefix,col_length,col_counter,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zInvoiceTypes datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zInvoiceTypes object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zInvoiceTypes user) {
		DataRow drow = dt.NewRow();
		
			drow["invoiceType_ID"] = user.invoiceType_ID;
			drow["invoiceType_Name"] = user.invoiceType_Name;
			drow["prefix"] = user.prefix;
			drow["length"] = user.length;
			drow["counter"] = user.counter;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
