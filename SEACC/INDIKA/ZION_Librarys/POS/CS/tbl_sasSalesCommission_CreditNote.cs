using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission_CreditNote {
		#region Fields
		private string commission_ID;
		private string creditNote_ID;
		private string customerName;
		private DateTime creditNoteDate;
		private string remark;
		private decimal creditNoteAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_CreditNote class.
		/// </summary>
		public tbl_sasSalesCommission_CreditNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_CreditNote class.
		/// </summary>
		public tbl_sasSalesCommission_CreditNote(string commission_ID, string creditNote_ID, string customerName, DateTime creditNoteDate, string remark, decimal creditNoteAmount) {
			this.commission_ID = commission_ID;
			this.creditNote_ID = creditNote_ID;
			this.customerName = customerName;
			this.creditNoteDate = creditNoteDate;
			this.remark = remark;
			this.creditNoteAmount = creditNoteAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Commission_ID value.
		/// </summary>
		public string Commission_ID {
			get { return commission_ID; }
			set { commission_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditNote_ID value.
		/// </summary>
		public string CreditNote_ID {
			get { return creditNote_ID; }
			set { creditNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditNoteDate value.
		/// </summary>
		public DateTime CreditNoteDate {
			get { return creditNoteDate; }
			set { creditNoteDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditNoteAmount value.
		/// </summary>
		public decimal CreditNoteAmount {
			get { return creditNoteAmount; }
			set { creditNoteAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission_CreditNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_CreditNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@creditNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@creditNoteAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@creditNoteDate"].Value = creditNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@creditNoteAmount"].Value = creditNoteAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission_CreditNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_CreditNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@creditNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@creditNoteAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@creditNoteDate"].Value = creditNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@creditNoteAmount"].Value = creditNoteAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission_CreditNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_CreditNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_CreditNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_CreditNoteDeleteAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission_CreditNote table.
		/// </summary>
		public static tbl_sasSalesCommission_CreditNote Select(string commission_ID_Incoming, string creditNote_ID_Incoming){

			tbl_sasSalesCommission_CreditNote tbl_sasSalesCommission_CreditNoteins = new tbl_sasSalesCommission_CreditNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_CreditNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommission_CreditNoteins = Maketbl_sasSalesCommission_CreditNote(dataReader);
				} else {
					tbl_sasSalesCommission_CreditNoteins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_CreditNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_CreditNote table.
		/// </summary>
		public static List<tbl_sasSalesCommission_CreditNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_CreditNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission_CreditNote> tbl_sasSalesCommission_CreditNoteList = new List<tbl_sasSalesCommission_CreditNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_CreditNote tbl_sasSalesCommission_CreditNote = Maketbl_sasSalesCommission_CreditNote(dataReader);
					tbl_sasSalesCommission_CreditNoteList.Add(tbl_sasSalesCommission_CreditNote);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_CreditNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_CreditNote table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_CreditNote> SelectAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_CreditNoteSelectAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
				List<tbl_sasSalesCommission_CreditNote> tbl_sasSalesCommission_CreditNoteList = new List<tbl_sasSalesCommission_CreditNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_CreditNote tbl_sasSalesCommission_CreditNote = Maketbl_sasSalesCommission_CreditNote(dataReader);
					tbl_sasSalesCommission_CreditNoteList.Add(tbl_sasSalesCommission_CreditNote);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_CreditNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission_CreditNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission_CreditNote Maketbl_sasSalesCommission_CreditNote(SqlDataReader dataReader) {
			tbl_sasSalesCommission_CreditNote tbl_sasSalesCommission_CreditNote = new tbl_sasSalesCommission_CreditNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission_CreditNote.Commission_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission_CreditNote.CreditNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission_CreditNote.CustomerName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission_CreditNote.CreditNoteDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesCommission_CreditNote.Remark = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesCommission_CreditNote.CreditNoteAmount = dataReader.GetDecimal(5);
			}

			return tbl_sasSalesCommission_CreditNote;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission_CreditNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_CreditNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission_CreditNote  tbl_sasSalesCommission_CreditNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_creditNote_ID = new DataColumn("creditNote_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_creditNoteDate = new DataColumn("creditNoteDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_creditNoteAmount = new DataColumn("creditNoteAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_commission_ID,col_creditNote_ID,col_customerName,col_creditNoteDate,col_remark,col_creditNoteAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission_CreditNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_CreditNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission_CreditNote user) {
		DataRow drow = dt.NewRow();
		
			drow["commission_ID"] = user.commission_ID;
			drow["creditNote_ID"] = user.creditNote_ID;
			drow["customerName"] = user.customerName;
			drow["creditNoteDate"] = user.creditNoteDate;
			drow["remark"] = user.remark;
			drow["creditNoteAmount"] = user.creditNoteAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
