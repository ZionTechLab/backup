using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderIndent {
		#region Fields
		private string indent_ID;
		private string tender_ID;
		private string po_No;
		private DateTime po_Date;
		private string letter_Ref;
		private string payment_Terms;
		private string indent_Conditions;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderIndent class.
		/// </summary>
		public tbl_ttsTenderIndent() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderIndent class.
		/// </summary>
		public tbl_ttsTenderIndent(string indent_ID, string tender_ID, string po_No, DateTime po_Date, string letter_Ref, string payment_Terms, string indent_Conditions) {
			this.indent_ID = indent_ID;
			this.tender_ID = tender_ID;
			this.po_No = po_No;
			this.po_Date = po_Date;
			this.letter_Ref = letter_Ref;
			this.payment_Terms = payment_Terms;
			this.indent_Conditions = indent_Conditions;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Indent_ID value.
		/// </summary>
		public string Indent_ID {
			get { return indent_ID; }
			set { indent_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Po_No value.
		/// </summary>
		public string Po_No {
			get { return po_No; }
			set { po_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Po_Date value.
		/// </summary>
		public DateTime Po_Date {
			get { return po_Date; }
			set { po_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Letter_Ref value.
		/// </summary>
		public string Letter_Ref {
			get { return letter_Ref; }
			set { letter_Ref = value; }
		}
		
		/// <summary>
		/// Gets or sets the Payment_Terms value.
		/// </summary>
		public string Payment_Terms {
			get { return payment_Terms; }
			set { payment_Terms = value; }
		}
		
		/// <summary>
		/// Gets or sets the Indent_Conditions value.
		/// </summary>
		public string Indent_Conditions {
			get { return indent_Conditions; }
			set { indent_Conditions = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderIndent table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderIndentInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@indent_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@po_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@po_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@letter_Ref", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payment_Terms", SqlDbType.VarChar,50);
			scom.Parameters.Add("@indent_Conditions", SqlDbType.VarChar,200);
 
			scom.Parameters["@indent_ID"].Value = indent_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@po_No"].Value = po_No;
			scom.Parameters["@po_Date"].Value = po_Date;
			scom.Parameters["@letter_Ref"].Value = letter_Ref;
			scom.Parameters["@payment_Terms"].Value = payment_Terms;
			scom.Parameters["@indent_Conditions"].Value = indent_Conditions;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderIndent table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderIndentUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@indent_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@po_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@po_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@letter_Ref", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payment_Terms", SqlDbType.VarChar,50);
			scom.Parameters.Add("@indent_Conditions", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@indent_ID"].Value = indent_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@po_No"].Value = po_No;
			scom.Parameters["@po_Date"].Value = po_Date;
			scom.Parameters["@letter_Ref"].Value = letter_Ref;
			scom.Parameters["@payment_Terms"].Value = payment_Terms;
			scom.Parameters["@indent_Conditions"].Value = indent_Conditions;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderIndent table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderIndentDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@indent_ID", SqlDbType.VarChar,20);
			scom.Parameters["@indent_ID"].Value = indent_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderIndent table.
		/// </summary>
		public static tbl_ttsTenderIndent Select(string indent_ID_Incoming){

			tbl_ttsTenderIndent tbl_ttsTenderIndentins = new tbl_ttsTenderIndent();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderIndentSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@indent_ID", SqlDbType.VarChar,20);
			scom.Parameters["@indent_ID"].Value = indent_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderIndentins = Maketbl_ttsTenderIndent(dataReader);
				} else {
					tbl_ttsTenderIndentins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderIndentins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderIndent table.
		/// </summary>
		public static List<tbl_ttsTenderIndent> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderIndentSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderIndent> tbl_ttsTenderIndentList = new List<tbl_ttsTenderIndent>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderIndent tbl_ttsTenderIndent = Maketbl_ttsTenderIndent(dataReader);
					tbl_ttsTenderIndentList.Add(tbl_ttsTenderIndent);
				}
			}
			scon.Close();
			return tbl_ttsTenderIndentList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderIndent class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderIndent Maketbl_ttsTenderIndent(SqlDataReader dataReader) {
			tbl_ttsTenderIndent tbl_ttsTenderIndent = new tbl_ttsTenderIndent();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderIndent.Indent_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderIndent.Tender_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderIndent.Po_No = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsTenderIndent.Po_Date = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsTenderIndent.Letter_Ref = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsTenderIndent.Payment_Terms = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsTenderIndent.Indent_Conditions = dataReader.GetString(6);
			}

			return tbl_ttsTenderIndent;
		}
		/// <summary>
		/// This makes tbl_ttsTenderIndent datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderIndent object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderIndent  tbl_ttsTenderIndent   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_indent_ID = new DataColumn("indent_ID" , typeof(string));
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_po_No = new DataColumn("po_No" , typeof(string));
			DataColumn col_po_Date = new DataColumn("po_Date" , typeof(DateTime));
			DataColumn col_letter_Ref = new DataColumn("letter_Ref" , typeof(string));
			DataColumn col_payment_Terms = new DataColumn("payment_Terms" , typeof(string));
			DataColumn col_indent_Conditions = new DataColumn("indent_Conditions" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_indent_ID,col_tender_ID,col_po_No,col_po_Date,col_letter_Ref,col_payment_Terms,col_indent_Conditions,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderIndent datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderIndent object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderIndent user) {
		DataRow drow = dt.NewRow();
		
			drow["indent_ID"] = user.indent_ID;
			drow["tender_ID"] = user.tender_ID;
			drow["po_No"] = user.po_No;
			drow["po_Date"] = user.po_Date;
			drow["letter_Ref"] = user.letter_Ref;
			drow["payment_Terms"] = user.payment_Terms;
			drow["indent_Conditions"] = user.indent_Conditions;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
