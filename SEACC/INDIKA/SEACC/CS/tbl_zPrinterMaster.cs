using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPrinterMaster {
		#region Fields
		private string printer_ID;
		private string printerName;
		private string printerPort;
		private string remark;
		private bool isDefaultPrinter;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPrinterMaster class.
		/// </summary>
		public tbl_zPrinterMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPrinterMaster class.
		/// </summary>
		public tbl_zPrinterMaster(string printer_ID, string printerName, string printerPort, string remark, bool isDefaultPrinter) {
			this.printer_ID = printer_ID;
			this.printerName = printerName;
			this.printerPort = printerPort;
			this.remark = remark;
			this.isDefaultPrinter = isDefaultPrinter;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Printer_ID value.
		/// </summary>
		public string Printer_ID {
			get { return printer_ID; }
			set { printer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrinterName value.
		/// </summary>
		public string PrinterName {
			get { return printerName; }
			set { printerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrinterPort value.
		/// </summary>
		public string PrinterPort {
			get { return printerPort; }
			set { printerPort = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDefaultPrinter value.
		/// </summary>
		public bool IsDefaultPrinter {
			get { return isDefaultPrinter; }
			set { isDefaultPrinter = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zPrinterMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPrinterMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printerPort", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDefaultPrinter", SqlDbType.Bit,1);
 
			scom.Parameters["@printer_ID"].Value = printer_ID;
			scom.Parameters["@printerName"].Value = printerName;
			scom.Parameters["@printerPort"].Value = printerPort;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isDefaultPrinter"].Value = isDefaultPrinter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPrinterMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPrinterMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printerPort", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDefaultPrinter", SqlDbType.Bit,1);
 
 
			scom.Parameters["@printer_ID"].Value = printer_ID;
			scom.Parameters["@printerName"].Value = printerName;
			scom.Parameters["@printerPort"].Value = printerPort;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isDefaultPrinter"].Value = isDefaultPrinter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPrinterMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPrinterMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printer_ID"].Value = printer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPrinterMaster table.
		/// </summary>
		public static tbl_zPrinterMaster Select(string printer_ID_Incoming){

			tbl_zPrinterMaster tbl_zPrinterMasterins = new tbl_zPrinterMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPrinterMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printer_ID"].Value = printer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPrinterMasterins = Maketbl_zPrinterMaster(dataReader);
				} else {
					tbl_zPrinterMasterins = null;
				}
			}
			scon.Close();
			return tbl_zPrinterMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPrinterMaster table.
		/// </summary>
		public static List<tbl_zPrinterMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPrinterMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPrinterMaster> tbl_zPrinterMasterList = new List<tbl_zPrinterMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPrinterMaster tbl_zPrinterMaster = Maketbl_zPrinterMaster(dataReader);
					tbl_zPrinterMasterList.Add(tbl_zPrinterMaster);
				}
			}
			scon.Close();
			return tbl_zPrinterMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPrinterMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPrinterMaster Maketbl_zPrinterMaster(SqlDataReader dataReader) {
			tbl_zPrinterMaster tbl_zPrinterMaster = new tbl_zPrinterMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPrinterMaster.Printer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPrinterMaster.PrinterName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zPrinterMaster.PrinterPort = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zPrinterMaster.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zPrinterMaster.IsDefaultPrinter = dataReader.GetBoolean(4);
			}

			return tbl_zPrinterMaster;
		}
		/// <summary>
		/// This makes tbl_zPrinterMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPrinterMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPrinterMaster  tbl_zPrinterMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_printer_ID = new DataColumn("printer_ID" , typeof(string));
			DataColumn col_printerName = new DataColumn("printerName" , typeof(string));
			DataColumn col_printerPort = new DataColumn("printerPort" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isDefaultPrinter = new DataColumn("isDefaultPrinter" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_printer_ID,col_printerName,col_printerPort,col_remark,col_isDefaultPrinter,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPrinterMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPrinterMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPrinterMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["printer_ID"] = user.printer_ID;
			drow["printerName"] = user.printerName;
			drow["printerPort"] = user.printerPort;
			drow["remark"] = user.remark;
			drow["isDefaultPrinter"] = user.isDefaultPrinter;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
