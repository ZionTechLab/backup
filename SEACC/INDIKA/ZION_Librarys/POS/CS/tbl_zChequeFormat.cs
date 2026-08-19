using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zChequeFormat {
		#region Fields
		private int chequeFormat_ID;
		private string chequeFormat_Code;
		private string chequeFormat_Desc;
		private int xMargin;
		private int yMargin;
		private bool isActive;
		private int counterBookLength;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zChequeFormat class.
		/// </summary>
		public tbl_zChequeFormat() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zChequeFormat class.
		/// </summary>
		public tbl_zChequeFormat(int chequeFormat_ID, string chequeFormat_Code, string chequeFormat_Desc, int xMargin, int yMargin, bool isActive, int counterBookLength) {
			this.chequeFormat_ID = chequeFormat_ID;
			this.chequeFormat_Code = chequeFormat_Code;
			this.chequeFormat_Desc = chequeFormat_Desc;
			this.xMargin = xMargin;
			this.yMargin = yMargin;
			this.isActive = isActive;
			this.counterBookLength = counterBookLength;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeFormat_ID value.
		/// </summary>
		public int ChequeFormat_ID {
			get { return chequeFormat_ID; }
			set { chequeFormat_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeFormat_Code value.
		/// </summary>
		public string ChequeFormat_Code {
			get { return chequeFormat_Code; }
			set { chequeFormat_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeFormat_Desc value.
		/// </summary>
		public string ChequeFormat_Desc {
			get { return chequeFormat_Desc; }
			set { chequeFormat_Desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the XMargin value.
		/// </summary>
		public int XMargin {
			get { return xMargin; }
			set { xMargin = value; }
		}
		
		/// <summary>
		/// Gets or sets the YMargin value.
		/// </summary>
		public int YMargin {
			get { return yMargin; }
			set { yMargin = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		
		/// <summary>
		/// Gets or sets the CounterBookLength value.
		/// </summary>
		public int CounterBookLength {
			get { return counterBookLength; }
			set { counterBookLength = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zChequeFormat table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormatInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@chequeFormat_Code", SqlDbType.VarChar,8);
			scom.Parameters.Add("@chequeFormat_Desc", SqlDbType.VarChar,100);
			scom.Parameters.Add("@xMargin", SqlDbType.Int,4);
			scom.Parameters.Add("@yMargin", SqlDbType.Int,4);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@counterBookLength", SqlDbType.Int,4);
 
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID;
			scom.Parameters["@chequeFormat_Code"].Value = chequeFormat_Code;
			scom.Parameters["@chequeFormat_Desc"].Value = chequeFormat_Desc;
			scom.Parameters["@xMargin"].Value = xMargin;
			scom.Parameters["@yMargin"].Value = yMargin;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@counterBookLength"].Value = counterBookLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zChequeFormat table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormatUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@chequeFormat_Code", SqlDbType.VarChar,8);
			scom.Parameters.Add("@chequeFormat_Desc", SqlDbType.VarChar,100);
			scom.Parameters.Add("@xMargin", SqlDbType.Int,4);
			scom.Parameters.Add("@yMargin", SqlDbType.Int,4);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@counterBookLength", SqlDbType.Int,4);
 
 
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID;
			scom.Parameters["@chequeFormat_Code"].Value = chequeFormat_Code;
			scom.Parameters["@chequeFormat_Desc"].Value = chequeFormat_Desc;
			scom.Parameters["@xMargin"].Value = xMargin;
			scom.Parameters["@yMargin"].Value = yMargin;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@counterBookLength"].Value = counterBookLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zChequeFormat table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormatDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zChequeFormat table.
		/// </summary>
		public static tbl_zChequeFormat Select(int chequeFormat_ID_Incoming){

			tbl_zChequeFormat tbl_zChequeFormatins = new tbl_zChequeFormat();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormatSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zChequeFormatins = Maketbl_zChequeFormat(dataReader);
				} else {
					tbl_zChequeFormatins = null;
				}
			}
			scon.Close();
			return tbl_zChequeFormatins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zChequeFormat table.
		/// </summary>
		public static List<tbl_zChequeFormat> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormatSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zChequeFormat> tbl_zChequeFormatList = new List<tbl_zChequeFormat>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zChequeFormat tbl_zChequeFormat = Maketbl_zChequeFormat(dataReader);
					tbl_zChequeFormatList.Add(tbl_zChequeFormat);
				}
			}
			scon.Close();
			return tbl_zChequeFormatList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zChequeFormat class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zChequeFormat Maketbl_zChequeFormat(SqlDataReader dataReader) {
			tbl_zChequeFormat tbl_zChequeFormat = new tbl_zChequeFormat();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zChequeFormat.ChequeFormat_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zChequeFormat.ChequeFormat_Code = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zChequeFormat.ChequeFormat_Desc = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zChequeFormat.XMargin = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zChequeFormat.YMargin = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zChequeFormat.IsActive = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zChequeFormat.CounterBookLength = dataReader.GetInt32(6);
			}

			return tbl_zChequeFormat;
		}
		/// <summary>
		/// This makes tbl_zChequeFormat datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zChequeFormat object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zChequeFormat  tbl_zChequeFormat   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeFormat_ID = new DataColumn("chequeFormat_ID" , typeof(int));
			DataColumn col_chequeFormat_Code = new DataColumn("chequeFormat_Code" , typeof(string));
			DataColumn col_chequeFormat_Desc = new DataColumn("chequeFormat_Desc" , typeof(string));
			DataColumn col_xMargin = new DataColumn("xMargin" , typeof(int));
			DataColumn col_yMargin = new DataColumn("yMargin" , typeof(int));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_counterBookLength = new DataColumn("counterBookLength" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_chequeFormat_ID,col_chequeFormat_Code,col_chequeFormat_Desc,col_xMargin,col_yMargin,col_isActive,col_counterBookLength,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zChequeFormat datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zChequeFormat object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zChequeFormat user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeFormat_ID"] = user.chequeFormat_ID;
			drow["chequeFormat_Code"] = user.chequeFormat_Code;
			drow["chequeFormat_Desc"] = user.chequeFormat_Desc;
			drow["xMargin"] = user.xMargin;
			drow["yMargin"] = user.yMargin;
			drow["isActive"] = user.isActive;
			drow["counterBookLength"] = user.counterBookLength;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
