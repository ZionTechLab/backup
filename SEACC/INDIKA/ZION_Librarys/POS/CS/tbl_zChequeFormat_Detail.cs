using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zChequeFormat_Detail {
		#region Fields
		private int chequeFormat_ID;
		private int element_ID;
		private string element_Desc;
		private int fontType_ID;
		private int xValue;
		private int yValue;
		private int length;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zChequeFormat_Detail class.
		/// </summary>
		public tbl_zChequeFormat_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zChequeFormat_Detail class.
		/// </summary>
		public tbl_zChequeFormat_Detail(int chequeFormat_ID, int element_ID, string element_Desc, int fontType_ID, int xValue, int yValue, int length) {
			this.chequeFormat_ID = chequeFormat_ID;
			this.element_ID = element_ID;
			this.element_Desc = element_Desc;
			this.fontType_ID = fontType_ID;
			this.xValue = xValue;
			this.yValue = yValue;
			this.length = length;
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
		/// Gets or sets the Element_ID value.
		/// </summary>
		public int Element_ID {
			get { return element_ID; }
			set { element_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Element_Desc value.
		/// </summary>
		public string Element_Desc {
			get { return element_Desc; }
			set { element_Desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the FontType_ID value.
		/// </summary>
		public int FontType_ID {
			get { return fontType_ID; }
			set { fontType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the XValue value.
		/// </summary>
		public int XValue {
			get { return xValue; }
			set { xValue = value; }
		}
		
		/// <summary>
		/// Gets or sets the YValue value.
		/// </summary>
		public int YValue {
			get { return yValue; }
			set { yValue = value; }
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
		/// Saves a record to the tbl_zChequeFormat_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormat_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@element_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@element_Desc", SqlDbType.VarChar,100);
			scom.Parameters.Add("@fontType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@xValue", SqlDbType.Int,4);
			scom.Parameters.Add("@yValue", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
 
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID;
			scom.Parameters["@element_ID"].Value = element_ID;
			scom.Parameters["@element_Desc"].Value = element_Desc;
			scom.Parameters["@fontType_ID"].Value = fontType_ID;
			scom.Parameters["@xValue"].Value = xValue;
			scom.Parameters["@yValue"].Value = yValue;
			scom.Parameters["@length"].Value = length;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zChequeFormat_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormat_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@element_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@element_Desc", SqlDbType.VarChar,100);
			scom.Parameters.Add("@fontType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@xValue", SqlDbType.Int,4);
			scom.Parameters.Add("@yValue", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
 
 
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID;
			scom.Parameters["@element_ID"].Value = element_ID;
			scom.Parameters["@element_Desc"].Value = element_Desc;
			scom.Parameters["@fontType_ID"].Value = fontType_ID;
			scom.Parameters["@xValue"].Value = xValue;
			scom.Parameters["@yValue"].Value = yValue;
			scom.Parameters["@length"].Value = length;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zChequeFormat_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormat_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@element_ID", SqlDbType.Int,4);
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID;
 
			scom.Parameters["@element_ID"].Value = element_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zChequeFormat_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByFontType_ID(int fontType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormat_DetailDeleteAllByFontType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fontType_ID", SqlDbType.Int,4);
			scom.Parameters["@fontType_ID"].Value = fontType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zChequeFormat_Detail table.
		/// </summary>
		public static tbl_zChequeFormat_Detail Select(int chequeFormat_ID_Incoming, int element_ID_Incoming){

			tbl_zChequeFormat_Detail tbl_zChequeFormat_Detailins = new tbl_zChequeFormat_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormat_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@element_ID", SqlDbType.Int,4);
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID_Incoming;
			scom.Parameters["@element_ID"].Value = element_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zChequeFormat_Detailins = Maketbl_zChequeFormat_Detail(dataReader);
				} else {
					tbl_zChequeFormat_Detailins = null;
				}
			}
			scon.Close();
			return tbl_zChequeFormat_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zChequeFormat_Detail table.
		/// </summary>
		public static List<tbl_zChequeFormat_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormat_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zChequeFormat_Detail> tbl_zChequeFormat_DetailList = new List<tbl_zChequeFormat_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zChequeFormat_Detail tbl_zChequeFormat_Detail = Maketbl_zChequeFormat_Detail(dataReader);
					tbl_zChequeFormat_DetailList.Add(tbl_zChequeFormat_Detail);
				}
			}
			scon.Close();
			return tbl_zChequeFormat_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zChequeFormat_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_zChequeFormat_Detail> SelectAllByFontType_ID(int fontType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeFormat_DetailSelectAllByFontType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fontType_ID", SqlDbType.Int,4);
			scom.Parameters["@fontType_ID"].Value = fontType_ID;
				List<tbl_zChequeFormat_Detail> tbl_zChequeFormat_DetailList = new List<tbl_zChequeFormat_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zChequeFormat_Detail tbl_zChequeFormat_Detail = Maketbl_zChequeFormat_Detail(dataReader);
					tbl_zChequeFormat_DetailList.Add(tbl_zChequeFormat_Detail);
				}
			}
			scon.Close();
			return tbl_zChequeFormat_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zChequeFormat_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zChequeFormat_Detail Maketbl_zChequeFormat_Detail(SqlDataReader dataReader) {
			tbl_zChequeFormat_Detail tbl_zChequeFormat_Detail = new tbl_zChequeFormat_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zChequeFormat_Detail.ChequeFormat_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zChequeFormat_Detail.Element_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zChequeFormat_Detail.Element_Desc = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zChequeFormat_Detail.FontType_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zChequeFormat_Detail.XValue = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zChequeFormat_Detail.YValue = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zChequeFormat_Detail.Length = dataReader.GetInt32(6);
			}

			return tbl_zChequeFormat_Detail;
		}
		/// <summary>
		/// This makes tbl_zChequeFormat_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zChequeFormat_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zChequeFormat_Detail  tbl_zChequeFormat_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeFormat_ID = new DataColumn("chequeFormat_ID" , typeof(int));
			DataColumn col_element_ID = new DataColumn("element_ID" , typeof(int));
			DataColumn col_element_Desc = new DataColumn("element_Desc" , typeof(string));
			DataColumn col_fontType_ID = new DataColumn("fontType_ID" , typeof(int));
			DataColumn col_xValue = new DataColumn("xValue" , typeof(int));
			DataColumn col_yValue = new DataColumn("yValue" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_chequeFormat_ID,col_element_ID,col_element_Desc,col_fontType_ID,col_xValue,col_yValue,col_length,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zChequeFormat_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zChequeFormat_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zChequeFormat_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeFormat_ID"] = user.chequeFormat_ID;
			drow["element_ID"] = user.element_ID;
			drow["element_Desc"] = user.element_Desc;
			drow["fontType_ID"] = user.fontType_ID;
			drow["xValue"] = user.xValue;
			drow["yValue"] = user.yValue;
			drow["length"] = user.length;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
