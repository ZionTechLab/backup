using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderDocumentRenewals {
		#region Fields
		private string doc_Renewal_ID;
		private string item_ID;
		private string doc_ID;
		private int renewal_Type1_ID;
		private int renewal_Type2_ID;
		private DateTime expiryDate;
		private string remarks;
		private int reminderDays;
		private int reminderFrequence;
		private DateTime reminderTime;
		private bool isActive;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderDocumentRenewals class.
		/// </summary>
		public tbl_ttsTenderDocumentRenewals() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderDocumentRenewals class.
		/// </summary>
		public tbl_ttsTenderDocumentRenewals(string doc_Renewal_ID, string item_ID, string doc_ID, int renewal_Type1_ID, int renewal_Type2_ID, DateTime expiryDate, string remarks, int reminderDays, int reminderFrequence, DateTime reminderTime, bool isActive, bool isCanceled) {
			this.doc_Renewal_ID = doc_Renewal_ID;
			this.item_ID = item_ID;
			this.doc_ID = doc_ID;
			this.renewal_Type1_ID = renewal_Type1_ID;
			this.renewal_Type2_ID = renewal_Type2_ID;
			this.expiryDate = expiryDate;
			this.remarks = remarks;
			this.reminderDays = reminderDays;
			this.reminderFrequence = reminderFrequence;
			this.reminderTime = reminderTime;
			this.isActive = isActive;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Doc_Renewal_ID value.
		/// </summary>
		public string Doc_Renewal_ID {
			get { return doc_Renewal_ID; }
			set { doc_Renewal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Doc_ID value.
		/// </summary>
		public string Doc_ID {
			get { return doc_ID; }
			set { doc_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Renewal_Type1_ID value.
		/// </summary>
		public int Renewal_Type1_ID {
			get { return renewal_Type1_ID; }
			set { renewal_Type1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Renewal_Type2_ID value.
		/// </summary>
		public int Renewal_Type2_ID {
			get { return renewal_Type2_ID; }
			set { renewal_Type2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExpiryDate value.
		/// </summary>
		public DateTime ExpiryDate {
			get { return expiryDate; }
			set { expiryDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReminderDays value.
		/// </summary>
		public int ReminderDays {
			get { return reminderDays; }
			set { reminderDays = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReminderFrequence value.
		/// </summary>
		public int ReminderFrequence {
			get { return reminderFrequence; }
			set { reminderFrequence = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReminderTime value.
		/// </summary>
		public DateTime ReminderTime {
			get { return reminderTime; }
			set { reminderTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderDocumentRenewals table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@doc_Renewal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@renewal_Type1_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@renewal_Type2_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@expiryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
			scom.Parameters.Add("@reminderDays", SqlDbType.Int,4);
			scom.Parameters.Add("@reminderFrequence", SqlDbType.Int,4);
			scom.Parameters.Add("@reminderTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@doc_Renewal_ID"].Value = doc_Renewal_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@doc_ID"].Value = doc_ID;
			scom.Parameters["@renewal_Type1_ID"].Value = renewal_Type1_ID;
			scom.Parameters["@renewal_Type2_ID"].Value = renewal_Type2_ID;
			scom.Parameters["@expiryDate"].Value = expiryDate;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@reminderDays"].Value = reminderDays;
			scom.Parameters["@reminderFrequence"].Value = reminderFrequence;
			scom.Parameters["@reminderTime"].Value = reminderTime;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderDocumentRenewals table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@doc_Renewal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@renewal_Type1_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@renewal_Type2_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@expiryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
			scom.Parameters.Add("@reminderDays", SqlDbType.Int,4);
			scom.Parameters.Add("@reminderFrequence", SqlDbType.Int,4);
			scom.Parameters.Add("@reminderTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@doc_Renewal_ID"].Value = doc_Renewal_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@doc_ID"].Value = doc_ID;
			scom.Parameters["@renewal_Type1_ID"].Value = renewal_Type1_ID;
			scom.Parameters["@renewal_Type2_ID"].Value = renewal_Type2_ID;
			scom.Parameters["@expiryDate"].Value = expiryDate;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@reminderDays"].Value = reminderDays;
			scom.Parameters["@reminderFrequence"].Value = reminderFrequence;
			scom.Parameters["@reminderTime"].Value = reminderTime;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderDocumentRenewals table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@doc_Renewal_ID", SqlDbType.VarChar,20);
			scom.Parameters["@doc_Renewal_ID"].Value = doc_Renewal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderDocumentRenewals table by a foreign key.
		/// </summary>
		public static void DeleteAllByDoc_ID(string doc_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsDeleteAllByDoc_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters["@doc_ID"].Value = doc_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderDocumentRenewals table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderDocumentRenewals table by a foreign key.
		/// </summary>
		public static void DeleteAllByRenewal_Type1_ID(int renewal_Type1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsDeleteAllByRenewal_Type1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@renewal_Type1_ID", SqlDbType.Int,4);
			scom.Parameters["@renewal_Type1_ID"].Value = renewal_Type1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderDocumentRenewals table.
		/// </summary>
		public static tbl_ttsTenderDocumentRenewals Select(string doc_Renewal_ID_Incoming){

			tbl_ttsTenderDocumentRenewals tbl_ttsTenderDocumentRenewalsins = new tbl_ttsTenderDocumentRenewals();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@doc_Renewal_ID", SqlDbType.VarChar,20);
			scom.Parameters["@doc_Renewal_ID"].Value = doc_Renewal_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderDocumentRenewalsins = Maketbl_ttsTenderDocumentRenewals(dataReader);
				} else {
					tbl_ttsTenderDocumentRenewalsins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderDocumentRenewalsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderDocumentRenewals table.
		/// </summary>
		public static List<tbl_ttsTenderDocumentRenewals> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderDocumentRenewals> tbl_ttsTenderDocumentRenewalsList = new List<tbl_ttsTenderDocumentRenewals>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderDocumentRenewals tbl_ttsTenderDocumentRenewals = Maketbl_ttsTenderDocumentRenewals(dataReader);
					tbl_ttsTenderDocumentRenewalsList.Add(tbl_ttsTenderDocumentRenewals);
				}
			}
			scon.Close();
			return tbl_ttsTenderDocumentRenewalsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderDocumentRenewals table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderDocumentRenewals> SelectAllByDoc_ID(string doc_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsSelectAllByDoc_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters["@doc_ID"].Value = doc_ID;
				List<tbl_ttsTenderDocumentRenewals> tbl_ttsTenderDocumentRenewalsList = new List<tbl_ttsTenderDocumentRenewals>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderDocumentRenewals tbl_ttsTenderDocumentRenewals = Maketbl_ttsTenderDocumentRenewals(dataReader);
					tbl_ttsTenderDocumentRenewalsList.Add(tbl_ttsTenderDocumentRenewals);
				}
			}
			scon.Close();
			return tbl_ttsTenderDocumentRenewalsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderDocumentRenewals table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderDocumentRenewals> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_ttsTenderDocumentRenewals> tbl_ttsTenderDocumentRenewalsList = new List<tbl_ttsTenderDocumentRenewals>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderDocumentRenewals tbl_ttsTenderDocumentRenewals = Maketbl_ttsTenderDocumentRenewals(dataReader);
					tbl_ttsTenderDocumentRenewalsList.Add(tbl_ttsTenderDocumentRenewals);
				}
			}
			scon.Close();
			return tbl_ttsTenderDocumentRenewalsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderDocumentRenewals table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderDocumentRenewals> SelectAllByRenewal_Type1_ID(int renewal_Type1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentRenewalsSelectAllByRenewal_Type1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@renewal_Type1_ID", SqlDbType.Int,4);
			scom.Parameters["@renewal_Type1_ID"].Value = renewal_Type1_ID;
				List<tbl_ttsTenderDocumentRenewals> tbl_ttsTenderDocumentRenewalsList = new List<tbl_ttsTenderDocumentRenewals>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderDocumentRenewals tbl_ttsTenderDocumentRenewals = Maketbl_ttsTenderDocumentRenewals(dataReader);
					tbl_ttsTenderDocumentRenewalsList.Add(tbl_ttsTenderDocumentRenewals);
				}
			}
			scon.Close();
			return tbl_ttsTenderDocumentRenewalsList;
		}
			
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderDocumentRenewals class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderDocumentRenewals Maketbl_ttsTenderDocumentRenewals(SqlDataReader dataReader) {
			tbl_ttsTenderDocumentRenewals tbl_ttsTenderDocumentRenewals = new tbl_ttsTenderDocumentRenewals();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderDocumentRenewals.Doc_Renewal_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderDocumentRenewals.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderDocumentRenewals.Doc_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsTenderDocumentRenewals.Renewal_Type1_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsTenderDocumentRenewals.Renewal_Type2_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsTenderDocumentRenewals.ExpiryDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsTenderDocumentRenewals.Remarks = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ttsTenderDocumentRenewals.ReminderDays = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ttsTenderDocumentRenewals.ReminderFrequence = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ttsTenderDocumentRenewals.ReminderTime = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ttsTenderDocumentRenewals.IsActive = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_ttsTenderDocumentRenewals.IsCanceled = dataReader.GetBoolean(11);
			}

			return tbl_ttsTenderDocumentRenewals;
		}
		/// <summary>
		/// This makes tbl_ttsTenderDocumentRenewals datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderDocumentRenewals object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderDocumentRenewals  tbl_ttsTenderDocumentRenewals   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_doc_Renewal_ID = new DataColumn("doc_Renewal_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_doc_ID = new DataColumn("doc_ID" , typeof(string));
			DataColumn col_renewal_Type1_ID = new DataColumn("renewal_Type1_ID" , typeof(int));
			DataColumn col_renewal_Type2_ID = new DataColumn("renewal_Type2_ID" , typeof(int));
			DataColumn col_expiryDate = new DataColumn("expiryDate" , typeof(DateTime));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_reminderDays = new DataColumn("reminderDays" , typeof(int));
			DataColumn col_reminderFrequence = new DataColumn("reminderFrequence" , typeof(int));
			DataColumn col_reminderTime = new DataColumn("reminderTime" , typeof(DateTime));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_doc_Renewal_ID,col_item_ID,col_doc_ID,col_renewal_Type1_ID,col_renewal_Type2_ID,col_expiryDate,col_remarks,col_reminderDays,col_reminderFrequence,col_reminderTime,col_isActive,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderDocumentRenewals datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderDocumentRenewals object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderDocumentRenewals user) {
		DataRow drow = dt.NewRow();
		
			drow["doc_Renewal_ID"] = user.doc_Renewal_ID;
			drow["item_ID"] = user.item_ID;
			drow["doc_ID"] = user.doc_ID;
			drow["renewal_Type1_ID"] = user.renewal_Type1_ID;
			drow["renewal_Type2_ID"] = user.renewal_Type2_ID;
			drow["expiryDate"] = user.expiryDate;
			drow["remarks"] = user.remarks;
			drow["reminderDays"] = user.reminderDays;
			drow["reminderFrequence"] = user.reminderFrequence;
			drow["reminderTime"] = user.reminderTime;
			drow["isActive"] = user.isActive;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
