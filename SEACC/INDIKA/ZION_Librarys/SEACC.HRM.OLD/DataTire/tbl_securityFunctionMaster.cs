using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityFunctionMaster {
		#region Fields
		private int function_ID;
		private int function_Code;
		private string functionName;
		private byte[] image;
		private string functionCategory_ID;
		private bool isEnable;
		private bool isReport;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster class.
		/// </summary>
		public tbl_securityFunctionMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster class.
		/// </summary>
		public tbl_securityFunctionMaster(int function_ID, int function_Code, string functionName, byte[] image, string functionCategory_ID, bool isEnable, bool isReport) {
			this.function_ID = function_ID;
			this.function_Code = function_Code;
			this.functionName = functionName;
			this.image = image;
			this.functionCategory_ID = functionCategory_ID;
			this.isEnable = isEnable;
			this.isReport = isReport;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Function_ID value.
		/// </summary>
		public int Function_ID {
			get { return function_ID; }
			set { function_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Function_Code value.
		/// </summary>
		public int Function_Code {
			get { return function_Code; }
			set { function_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the FunctionName value.
		/// </summary>
		public string FunctionName {
			get { return functionName; }
			set { functionName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		
		/// <summary>
		/// Gets or sets the FunctionCategory_ID value.
		/// </summary>
		public string FunctionCategory_ID {
			get { return functionCategory_ID; }
			set { functionCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEnable value.
		/// </summary>
		public bool IsEnable {
			get { return isEnable; }
			set { isEnable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReport value.
		/// </summary>
		public bool IsReport {
			get { return isReport; }
			set { isReport = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityFunctionMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@function_Code", SqlDbType.Int,4);
			scom.Parameters.Add("@functionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@functionCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReport", SqlDbType.Bit,1);
 
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@function_Code"].Value = function_Code;
			scom.Parameters["@functionName"].Value = functionName;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@functionCategory_ID"].Value = functionCategory_ID;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isReport"].Value = isReport;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityFunctionMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@function_Code", SqlDbType.Int,4);
			scom.Parameters.Add("@functionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@functionCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReport", SqlDbType.Bit,1);
 
 
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@function_Code"].Value = function_Code;
			scom.Parameters["@functionName"].Value = functionName;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@functionCategory_ID"].Value = functionCategory_ID;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isReport"].Value = isReport;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityFunctionMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunctionCategory_ID(string functionCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMasterDeleteAllByFunctionCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@functionCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@functionCategory_ID"].Value = functionCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFunctionMaster table.
		/// </summary>
		public static tbl_securityFunctionMaster Select(int function_ID_Incoming){

			tbl_securityFunctionMaster tbl_securityFunctionMasterins = new tbl_securityFunctionMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFunctionMasterins = Maketbl_securityFunctionMaster(dataReader);
				} else {
					tbl_securityFunctionMasterins = null;
				}
			}
			scon.Close();
			return tbl_securityFunctionMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster table.
		/// </summary>
		public static List<tbl_securityFunctionMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFunctionMaster> tbl_securityFunctionMasterList = new List<tbl_securityFunctionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster tbl_securityFunctionMaster = Maketbl_securityFunctionMaster(dataReader);
					tbl_securityFunctionMasterList.Add(tbl_securityFunctionMaster);
				}
			}
			scon.Close();
			return tbl_securityFunctionMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster> SelectAllByFunctionCategory_ID(string functionCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMasterSelectAllByFunctionCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@functionCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@functionCategory_ID"].Value = functionCategory_ID;
				List<tbl_securityFunctionMaster> tbl_securityFunctionMasterList = new List<tbl_securityFunctionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster tbl_securityFunctionMaster = Maketbl_securityFunctionMaster(dataReader);
					tbl_securityFunctionMasterList.Add(tbl_securityFunctionMaster);
				}
			}
			scon.Close();
			return tbl_securityFunctionMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFunctionMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFunctionMaster Maketbl_securityFunctionMaster(SqlDataReader dataReader) {
			tbl_securityFunctionMaster tbl_securityFunctionMaster = new tbl_securityFunctionMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFunctionMaster.Function_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFunctionMaster.Function_Code = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFunctionMaster.FunctionName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityFunctionMaster.Image = (byte[])dataReader[3];
            }
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityFunctionMaster.FunctionCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityFunctionMaster.IsEnable = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityFunctionMaster.IsReport = dataReader.GetBoolean(6);
			}

			return tbl_securityFunctionMaster;
		}
		/// <summary>
		/// This makes tbl_securityFunctionMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFunctionMaster  tbl_securityFunctionMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_function_ID = new DataColumn("function_ID" , typeof(int));
			DataColumn col_function_Code = new DataColumn("function_Code" , typeof(int));
			DataColumn col_functionName = new DataColumn("functionName" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
			DataColumn col_functionCategory_ID = new DataColumn("functionCategory_ID" , typeof(string));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
			DataColumn col_isReport = new DataColumn("isReport" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_function_ID,col_function_Code,col_functionName,col_image,col_functionCategory_ID,col_isEnable,col_isReport,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFunctionMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFunctionMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["function_ID"] = user.function_ID;
			drow["function_Code"] = user.function_Code;
			drow["functionName"] = user.functionName;
			drow["image"] = user.image;
			drow["functionCategory_ID"] = user.functionCategory_ID;
			drow["isEnable"] = user.isEnable;
			drow["isReport"] = user.isReport;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
