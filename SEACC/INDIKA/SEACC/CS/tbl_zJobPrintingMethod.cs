using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobPrintingMethod {
		#region Fields
		private string printingMethod_ID;
		private string printingMethod;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPrintingMethod class.
		/// </summary>
		public tbl_zJobPrintingMethod() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPrintingMethod class.
		/// </summary>
		public tbl_zJobPrintingMethod(string printingMethod_ID, string printingMethod) {
			this.printingMethod_ID = printingMethod_ID;
			this.printingMethod = printingMethod;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PrintingMethod_ID value.
		/// </summary>
		public string PrintingMethod_ID {
			get { return printingMethod_ID; }
			set { printingMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintingMethod value.
		/// </summary>
		public string PrintingMethod {
			get { return printingMethod; }
			set { printingMethod = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobPrintingMethod table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingMethodInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@printingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printingMethod", SqlDbType.VarChar,50);
 
			scom.Parameters["@printingMethod_ID"].Value = printingMethod_ID;
			scom.Parameters["@printingMethod"].Value = printingMethod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobPrintingMethod table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingMethodUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@printingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printingMethod", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@printingMethod_ID"].Value = printingMethod_ID;
			scom.Parameters["@printingMethod"].Value = printingMethod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobPrintingMethod table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingMethodDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@printingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printingMethod_ID"].Value = printingMethod_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobPrintingMethod table.
		/// </summary>
		public static tbl_zJobPrintingMethod Select(string printingMethod_ID_Incoming){

			tbl_zJobPrintingMethod tbl_zJobPrintingMethodins = new tbl_zJobPrintingMethod();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingMethodSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printingMethod_ID"].Value = printingMethod_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobPrintingMethodins = Maketbl_zJobPrintingMethod(dataReader);
				} else {
					tbl_zJobPrintingMethodins = null;
				}
			}
			scon.Close();
			return tbl_zJobPrintingMethodins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobPrintingMethod table.
		/// </summary>
		public static List<tbl_zJobPrintingMethod> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingMethodSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobPrintingMethod> tbl_zJobPrintingMethodList = new List<tbl_zJobPrintingMethod>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobPrintingMethod tbl_zJobPrintingMethod = Maketbl_zJobPrintingMethod(dataReader);
					tbl_zJobPrintingMethodList.Add(tbl_zJobPrintingMethod);
				}
			}
			scon.Close();
			return tbl_zJobPrintingMethodList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobPrintingMethod class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobPrintingMethod Maketbl_zJobPrintingMethod(SqlDataReader dataReader) {
			tbl_zJobPrintingMethod tbl_zJobPrintingMethod = new tbl_zJobPrintingMethod();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobPrintingMethod.PrintingMethod_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobPrintingMethod.PrintingMethod = dataReader.GetString(1);
			}

			return tbl_zJobPrintingMethod;
		}
		/// <summary>
		/// This makes tbl_zJobPrintingMethod datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobPrintingMethod object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobPrintingMethod  tbl_zJobPrintingMethod   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_printingMethod_ID = new DataColumn("printingMethod_ID" , typeof(string));
			DataColumn col_printingMethod = new DataColumn("printingMethod" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_printingMethod_ID,col_printingMethod,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobPrintingMethod datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobPrintingMethod object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobPrintingMethod user) {
		DataRow drow = dt.NewRow();
		
			drow["printingMethod_ID"] = user.printingMethod_ID;
			drow["printingMethod"] = user.printingMethod;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
