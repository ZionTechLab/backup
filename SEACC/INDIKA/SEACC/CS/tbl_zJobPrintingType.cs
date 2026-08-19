using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobPrintingType {
		#region Fields
		private string printingType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPrintingType class.
		/// </summary>
		public tbl_zJobPrintingType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPrintingType class.
		/// </summary>
		public tbl_zJobPrintingType(string printingType_ID, string typeName) {
			this.printingType_ID = printingType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PrintingType_ID value.
		/// </summary>
		public string PrintingType_ID {
			get { return printingType_ID; }
			set { printingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobPrintingType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@printingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@printingType_ID"].Value = printingType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobPrintingType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@printingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@printingType_ID"].Value = printingType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobPrintingType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@printingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printingType_ID"].Value = printingType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobPrintingType table.
		/// </summary>
		public static tbl_zJobPrintingType Select(string printingType_ID_Incoming){

			tbl_zJobPrintingType tbl_zJobPrintingTypeins = new tbl_zJobPrintingType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printingType_ID"].Value = printingType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobPrintingTypeins = Maketbl_zJobPrintingType(dataReader);
				} else {
					tbl_zJobPrintingTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobPrintingTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobPrintingType table.
		/// </summary>
		public static List<tbl_zJobPrintingType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPrintingTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobPrintingType> tbl_zJobPrintingTypeList = new List<tbl_zJobPrintingType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobPrintingType tbl_zJobPrintingType = Maketbl_zJobPrintingType(dataReader);
					tbl_zJobPrintingTypeList.Add(tbl_zJobPrintingType);
				}
			}
			scon.Close();
			return tbl_zJobPrintingTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobPrintingType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobPrintingType Maketbl_zJobPrintingType(SqlDataReader dataReader) {
			tbl_zJobPrintingType tbl_zJobPrintingType = new tbl_zJobPrintingType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobPrintingType.PrintingType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobPrintingType.TypeName = dataReader.GetString(1);
			}

			return tbl_zJobPrintingType;
		}
		/// <summary>
		/// This makes tbl_zJobPrintingType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobPrintingType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobPrintingType  tbl_zJobPrintingType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_printingType_ID = new DataColumn("printingType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_printingType_ID,col_typeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobPrintingType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobPrintingType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobPrintingType user) {
		DataRow drow = dt.NewRow();
		
			drow["printingType_ID"] = user.printingType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
