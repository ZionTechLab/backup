using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zChequePrinting {
		#region Fields
		private string bankID;
		private int elementID;
		private string accountNo;
		private string elementDiscription;
		private int xValue;
		private int yValue;
		private string fontType;
		private int length;
		private bool isPrint;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zChequePrinting class.
		/// </summary>
		public tbl_zChequePrinting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zChequePrinting class.
		/// </summary>
		public tbl_zChequePrinting(string bankID, int elementID, string accountNo, string elementDiscription, int xValue, int yValue, string fontType, int length, bool isPrint) {
			this.bankID = bankID;
			this.elementID = elementID;
			this.accountNo = accountNo;
			this.elementDiscription = elementDiscription;
			this.xValue = xValue;
			this.yValue = yValue;
			this.fontType = fontType;
			this.length = length;
			this.isPrint = isPrint;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the BankID value.
		/// </summary>
		public string BankID {
			get { return bankID; }
			set { bankID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ElementID value.
		/// </summary>
		public int ElementID {
			get { return elementID; }
			set { elementID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNo value.
		/// </summary>
		public string AccountNo {
			get { return accountNo; }
			set { accountNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ElementDiscription value.
		/// </summary>
		public string ElementDiscription {
			get { return elementDiscription; }
			set { elementDiscription = value; }
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
		/// Gets or sets the FontType value.
		/// </summary>
		public string FontType {
			get { return fontType; }
			set { fontType = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public int Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPrint value.
		/// </summary>
		public bool IsPrint {
			get { return isPrint; }
			set { isPrint = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zChequePrinting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequePrintingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@bankID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters.Add("@accountNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@elementDiscription", SqlDbType.VarChar,100);
			scom.Parameters.Add("@xValue", SqlDbType.Int,4);
			scom.Parameters.Add("@yValue", SqlDbType.Int,4);
			scom.Parameters.Add("@fontType", SqlDbType.VarChar,100);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@isPrint", SqlDbType.Bit,1);
 
			scom.Parameters["@bankID"].Value = bankID;
			scom.Parameters["@elementID"].Value = elementID;
			scom.Parameters["@accountNo"].Value = accountNo;
			scom.Parameters["@elementDiscription"].Value = elementDiscription;
			scom.Parameters["@xValue"].Value = xValue;
			scom.Parameters["@yValue"].Value = yValue;
			scom.Parameters["@fontType"].Value = fontType;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@isPrint"].Value = isPrint;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zChequePrinting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequePrintingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@bankID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters.Add("@accountNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@elementDiscription", SqlDbType.VarChar,100);
			scom.Parameters.Add("@xValue", SqlDbType.Int,4);
			scom.Parameters.Add("@yValue", SqlDbType.Int,4);
			scom.Parameters.Add("@fontType", SqlDbType.VarChar,100);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@isPrint", SqlDbType.Bit,1);
 
 
			scom.Parameters["@bankID"].Value = bankID;
			scom.Parameters["@elementID"].Value = elementID;
			scom.Parameters["@accountNo"].Value = accountNo;
			scom.Parameters["@elementDiscription"].Value = elementDiscription;
			scom.Parameters["@xValue"].Value = xValue;
			scom.Parameters["@yValue"].Value = yValue;
			scom.Parameters["@fontType"].Value = fontType;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@isPrint"].Value = isPrint;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zChequePrinting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequePrintingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@bankID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters["@bankID"].Value = bankID;
 
			scom.Parameters["@elementID"].Value = elementID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zChequePrinting table.
		/// </summary>
		public static tbl_zChequePrinting Select(string bankID_Incoming, int elementID_Incoming){

			tbl_zChequePrinting tbl_zChequePrintingins = new tbl_zChequePrinting();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequePrintingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bankID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters["@bankID"].Value = bankID_Incoming;
			scom.Parameters["@elementID"].Value = elementID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zChequePrintingins = Maketbl_zChequePrinting(dataReader);
				} else {
					tbl_zChequePrintingins = null;
				}
			}
			scon.Close();
			return tbl_zChequePrintingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zChequePrinting table.
		/// </summary>
		public static List<tbl_zChequePrinting> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequePrintingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zChequePrinting> tbl_zChequePrintingList = new List<tbl_zChequePrinting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zChequePrinting tbl_zChequePrinting = Maketbl_zChequePrinting(dataReader);
					tbl_zChequePrintingList.Add(tbl_zChequePrinting);
				}
			}
			scon.Close();
			return tbl_zChequePrintingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zChequePrinting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zChequePrinting Maketbl_zChequePrinting(SqlDataReader dataReader) {
			tbl_zChequePrinting tbl_zChequePrinting = new tbl_zChequePrinting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zChequePrinting.BankID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zChequePrinting.ElementID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zChequePrinting.AccountNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zChequePrinting.ElementDiscription = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zChequePrinting.XValue = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zChequePrinting.YValue = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zChequePrinting.FontType = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zChequePrinting.Length = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zChequePrinting.IsPrint = dataReader.GetBoolean(8);
			}

			return tbl_zChequePrinting;
		}
		/// <summary>
		/// This makes tbl_zChequePrinting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zChequePrinting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zChequePrinting  tbl_zChequePrinting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_bankID = new DataColumn("bankID" , typeof(string));
			DataColumn col_elementID = new DataColumn("elementID" , typeof(int));
			DataColumn col_accountNo = new DataColumn("accountNo" , typeof(string));
			DataColumn col_elementDiscription = new DataColumn("elementDiscription" , typeof(string));
			DataColumn col_xValue = new DataColumn("xValue" , typeof(int));
			DataColumn col_yValue = new DataColumn("yValue" , typeof(int));
			DataColumn col_fontType = new DataColumn("fontType" , typeof(string));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_isPrint = new DataColumn("isPrint" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_bankID,col_elementID,col_accountNo,col_elementDiscription,col_xValue,col_yValue,col_fontType,col_length,col_isPrint,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zChequePrinting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zChequePrinting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zChequePrinting user) {
		DataRow drow = dt.NewRow();
		
			drow["bankID"] = user.bankID;
			drow["elementID"] = user.elementID;
			drow["accountNo"] = user.accountNo;
			drow["elementDiscription"] = user.elementDiscription;
			drow["xValue"] = user.xValue;
			drow["yValue"] = user.yValue;
			drow["fontType"] = user.fontType;
			drow["length"] = user.length;
			drow["isPrint"] = user.isPrint;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
