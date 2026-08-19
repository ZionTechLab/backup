using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zSalesNoteType {
		#region Fields
		private string salesNoteType_ID;
		private string salesNoteName;
		private string coPrefix;
		private int coCounter;
		private int coLength;
		private string doPrefix;
		private int doCounter;
		private int doLength;
		private string invPrefix;
		private int invCounter;
		private int invLength;
		private string crnPrefix;
		private int crnCounter;
		private int crnLength;
		private string drnPrefix;
		private int drnCounter;
		private int drnLength;
		private string srnPrefix;
		private int srnCounter;
		private int srnLength;
		private string receiptPrefix;
		private int receiptCounter;
		private int receiptLength;
		private string advanceReceiptPrefix;
		private int advanceReceiptCounter;
		private int advanceReceiptLength;
		private string gl_ID;
		private bool isPostingEnable_VAT;
		private bool isPostingEnable_NBT;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zSalesNoteType class.
		/// </summary>
		public tbl_zSalesNoteType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zSalesNoteType class.
		/// </summary>
		public tbl_zSalesNoteType(string salesNoteType_ID, string salesNoteName, string coPrefix, int coCounter, int coLength, string doPrefix, int doCounter, int doLength, string invPrefix, int invCounter, int invLength, string crnPrefix, int crnCounter, int crnLength, string drnPrefix, int drnCounter, int drnLength, string srnPrefix, int srnCounter, int srnLength, string receiptPrefix, int receiptCounter, int receiptLength, string advanceReceiptPrefix, int advanceReceiptCounter, int advanceReceiptLength, string gl_ID, bool isPostingEnable_VAT, bool isPostingEnable_NBT, string companyID, string companyBranch_ID) {
			this.salesNoteType_ID = salesNoteType_ID;
			this.salesNoteName = salesNoteName;
			this.coPrefix = coPrefix;
			this.coCounter = coCounter;
			this.coLength = coLength;
			this.doPrefix = doPrefix;
			this.doCounter = doCounter;
			this.doLength = doLength;
			this.invPrefix = invPrefix;
			this.invCounter = invCounter;
			this.invLength = invLength;
			this.crnPrefix = crnPrefix;
			this.crnCounter = crnCounter;
			this.crnLength = crnLength;
			this.drnPrefix = drnPrefix;
			this.drnCounter = drnCounter;
			this.drnLength = drnLength;
			this.srnPrefix = srnPrefix;
			this.srnCounter = srnCounter;
			this.srnLength = srnLength;
			this.receiptPrefix = receiptPrefix;
			this.receiptCounter = receiptCounter;
			this.receiptLength = receiptLength;
			this.advanceReceiptPrefix = advanceReceiptPrefix;
			this.advanceReceiptCounter = advanceReceiptCounter;
			this.advanceReceiptLength = advanceReceiptLength;
			this.gl_ID = gl_ID;
			this.isPostingEnable_VAT = isPostingEnable_VAT;
			this.isPostingEnable_NBT = isPostingEnable_NBT;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SalesNoteType_ID value.
		/// </summary>
		public string SalesNoteType_ID {
			get { return salesNoteType_ID; }
			set { salesNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesNoteName value.
		/// </summary>
		public string SalesNoteName {
			get { return salesNoteName; }
			set { salesNoteName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CoPrefix value.
		/// </summary>
		public string CoPrefix {
			get { return coPrefix; }
			set { coPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the CoCounter value.
		/// </summary>
		public int CoCounter {
			get { return coCounter; }
			set { coCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the CoLength value.
		/// </summary>
		public int CoLength {
			get { return coLength; }
			set { coLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the DoPrefix value.
		/// </summary>
		public string DoPrefix {
			get { return doPrefix; }
			set { doPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the DoCounter value.
		/// </summary>
		public int DoCounter {
			get { return doCounter; }
			set { doCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the DoLength value.
		/// </summary>
		public int DoLength {
			get { return doLength; }
			set { doLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvPrefix value.
		/// </summary>
		public string InvPrefix {
			get { return invPrefix; }
			set { invPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvCounter value.
		/// </summary>
		public int InvCounter {
			get { return invCounter; }
			set { invCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvLength value.
		/// </summary>
		public int InvLength {
			get { return invLength; }
			set { invLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the CrnPrefix value.
		/// </summary>
		public string CrnPrefix {
			get { return crnPrefix; }
			set { crnPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the CrnCounter value.
		/// </summary>
		public int CrnCounter {
			get { return crnCounter; }
			set { crnCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the CrnLength value.
		/// </summary>
		public int CrnLength {
			get { return crnLength; }
			set { crnLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the DrnPrefix value.
		/// </summary>
		public string DrnPrefix {
			get { return drnPrefix; }
			set { drnPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the DrnCounter value.
		/// </summary>
		public int DrnCounter {
			get { return drnCounter; }
			set { drnCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the DrnLength value.
		/// </summary>
		public int DrnLength {
			get { return drnLength; }
			set { drnLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the SrnPrefix value.
		/// </summary>
		public string SrnPrefix {
			get { return srnPrefix; }
			set { srnPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the SrnCounter value.
		/// </summary>
		public int SrnCounter {
			get { return srnCounter; }
			set { srnCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the SrnLength value.
		/// </summary>
		public int SrnLength {
			get { return srnLength; }
			set { srnLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptPrefix value.
		/// </summary>
		public string ReceiptPrefix {
			get { return receiptPrefix; }
			set { receiptPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptCounter value.
		/// </summary>
		public int ReceiptCounter {
			get { return receiptCounter; }
			set { receiptCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptLength value.
		/// </summary>
		public int ReceiptLength {
			get { return receiptLength; }
			set { receiptLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the AdvanceReceiptPrefix value.
		/// </summary>
		public string AdvanceReceiptPrefix {
			get { return advanceReceiptPrefix; }
			set { advanceReceiptPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the AdvanceReceiptCounter value.
		/// </summary>
		public int AdvanceReceiptCounter {
			get { return advanceReceiptCounter; }
			set { advanceReceiptCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the AdvanceReceiptLength value.
		/// </summary>
		public int AdvanceReceiptLength {
			get { return advanceReceiptLength; }
			set { advanceReceiptLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPostingEnable_VAT value.
		/// </summary>
		public bool IsPostingEnable_VAT {
			get { return isPostingEnable_VAT; }
			set { isPostingEnable_VAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPostingEnable_NBT value.
		/// </summary>
		public bool IsPostingEnable_NBT {
			get { return isPostingEnable_NBT; }
			set { isPostingEnable_NBT = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zSalesNoteType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesNoteName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@coPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@coCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@coLength", SqlDbType.Int,4);
			scom.Parameters.Add("@doPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@doCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@doLength", SqlDbType.Int,4);
			scom.Parameters.Add("@invPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@invLength", SqlDbType.Int,4);
			scom.Parameters.Add("@crnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@crnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@crnLength", SqlDbType.Int,4);
			scom.Parameters.Add("@drnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@drnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@drnLength", SqlDbType.Int,4);
			scom.Parameters.Add("@srnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@srnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@srnLength", SqlDbType.Int,4);
			scom.Parameters.Add("@ReceiptPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ReceiptCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@ReceiptLength", SqlDbType.Int,4);
			scom.Parameters.Add("@advanceReceiptPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@advanceReceiptCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@advanceReceiptLength", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isPostingEnable_VAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPostingEnable_NBT", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@salesNoteName"].Value = salesNoteName;
			scom.Parameters["@coPrefix"].Value = coPrefix;
			scom.Parameters["@coCounter"].Value = coCounter;
			scom.Parameters["@coLength"].Value = coLength;
			scom.Parameters["@doPrefix"].Value = doPrefix;
			scom.Parameters["@doCounter"].Value = doCounter;
			scom.Parameters["@doLength"].Value = doLength;
			scom.Parameters["@invPrefix"].Value = invPrefix;
			scom.Parameters["@invCounter"].Value = invCounter;
			scom.Parameters["@invLength"].Value = invLength;
			scom.Parameters["@crnPrefix"].Value = crnPrefix;
			scom.Parameters["@crnCounter"].Value = crnCounter;
			scom.Parameters["@crnLength"].Value = crnLength;
			scom.Parameters["@drnPrefix"].Value = drnPrefix;
			scom.Parameters["@drnCounter"].Value = drnCounter;
			scom.Parameters["@drnLength"].Value = drnLength;
			scom.Parameters["@srnPrefix"].Value = srnPrefix;
			scom.Parameters["@srnCounter"].Value = srnCounter;
			scom.Parameters["@srnLength"].Value = srnLength;
			scom.Parameters["@ReceiptPrefix"].Value = receiptPrefix;
			scom.Parameters["@ReceiptCounter"].Value = receiptCounter;
			scom.Parameters["@ReceiptLength"].Value = receiptLength;
			scom.Parameters["@advanceReceiptPrefix"].Value = advanceReceiptPrefix;
			scom.Parameters["@advanceReceiptCounter"].Value = advanceReceiptCounter;
			scom.Parameters["@advanceReceiptLength"].Value = advanceReceiptLength;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isPostingEnable_VAT"].Value = isPostingEnable_VAT;
			scom.Parameters["@isPostingEnable_NBT"].Value = isPostingEnable_NBT;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zSalesNoteType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesNoteName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@coPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@coCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@coLength", SqlDbType.Int,4);
			scom.Parameters.Add("@doPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@doCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@doLength", SqlDbType.Int,4);
			scom.Parameters.Add("@invPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@invLength", SqlDbType.Int,4);
			scom.Parameters.Add("@crnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@crnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@crnLength", SqlDbType.Int,4);
			scom.Parameters.Add("@drnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@drnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@drnLength", SqlDbType.Int,4);
			scom.Parameters.Add("@srnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@srnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@srnLength", SqlDbType.Int,4);
			scom.Parameters.Add("@ReceiptPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ReceiptCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@ReceiptLength", SqlDbType.Int,4);
			scom.Parameters.Add("@advanceReceiptPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@advanceReceiptCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@advanceReceiptLength", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isPostingEnable_VAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPostingEnable_NBT", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@salesNoteName"].Value = salesNoteName;
			scom.Parameters["@coPrefix"].Value = coPrefix;
			scom.Parameters["@coCounter"].Value = coCounter;
			scom.Parameters["@coLength"].Value = coLength;
			scom.Parameters["@doPrefix"].Value = doPrefix;
			scom.Parameters["@doCounter"].Value = doCounter;
			scom.Parameters["@doLength"].Value = doLength;
			scom.Parameters["@invPrefix"].Value = invPrefix;
			scom.Parameters["@invCounter"].Value = invCounter;
			scom.Parameters["@invLength"].Value = invLength;
			scom.Parameters["@crnPrefix"].Value = crnPrefix;
			scom.Parameters["@crnCounter"].Value = crnCounter;
			scom.Parameters["@crnLength"].Value = crnLength;
			scom.Parameters["@drnPrefix"].Value = drnPrefix;
			scom.Parameters["@drnCounter"].Value = drnCounter;
			scom.Parameters["@drnLength"].Value = drnLength;
			scom.Parameters["@srnPrefix"].Value = srnPrefix;
			scom.Parameters["@srnCounter"].Value = srnCounter;
			scom.Parameters["@srnLength"].Value = srnLength;
			scom.Parameters["@ReceiptPrefix"].Value = receiptPrefix;
			scom.Parameters["@ReceiptCounter"].Value = receiptCounter;
			scom.Parameters["@ReceiptLength"].Value = receiptLength;
			scom.Parameters["@advanceReceiptPrefix"].Value = advanceReceiptPrefix;
			scom.Parameters["@advanceReceiptCounter"].Value = advanceReceiptCounter;
			scom.Parameters["@advanceReceiptLength"].Value = advanceReceiptLength;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isPostingEnable_VAT"].Value = isPostingEnable_VAT;
			scom.Parameters["@isPostingEnable_NBT"].Value = isPostingEnable_NBT;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zSalesNoteType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSalesNoteType table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSalesNoteType table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zSalesNoteType table.
		/// </summary>
		public static tbl_zSalesNoteType Select(string salesNoteType_ID_Incoming){

			tbl_zSalesNoteType tbl_zSalesNoteTypeins = new tbl_zSalesNoteType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zSalesNoteTypeins = Maketbl_zSalesNoteType(dataReader);
				} else {
					tbl_zSalesNoteTypeins = null;
				}
			}
			scon.Close();
			return tbl_zSalesNoteTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSalesNoteType table.
		/// </summary>
		public static List<tbl_zSalesNoteType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zSalesNoteType> tbl_zSalesNoteTypeList = new List<tbl_zSalesNoteType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zSalesNoteType tbl_zSalesNoteType = Maketbl_zSalesNoteType(dataReader);
					tbl_zSalesNoteTypeList.Add(tbl_zSalesNoteType);
				}
			}
			scon.Close();
			return tbl_zSalesNoteTypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSalesNoteType table by a foreign key.
		/// </summary>
		public static List<tbl_zSalesNoteType> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_zSalesNoteType> tbl_zSalesNoteTypeList = new List<tbl_zSalesNoteType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zSalesNoteType tbl_zSalesNoteType = Maketbl_zSalesNoteType(dataReader);
					tbl_zSalesNoteTypeList.Add(tbl_zSalesNoteType);
				}
			}
			scon.Close();
			return tbl_zSalesNoteTypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSalesNoteType table by a foreign key.
		/// </summary>
		public static List<tbl_zSalesNoteType> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSalesNoteTypeSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_zSalesNoteType> tbl_zSalesNoteTypeList = new List<tbl_zSalesNoteType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zSalesNoteType tbl_zSalesNoteType = Maketbl_zSalesNoteType(dataReader);
					tbl_zSalesNoteTypeList.Add(tbl_zSalesNoteType);
				}
			}
			scon.Close();
			return tbl_zSalesNoteTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zSalesNoteType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zSalesNoteType Maketbl_zSalesNoteType(SqlDataReader dataReader) {
			tbl_zSalesNoteType tbl_zSalesNoteType = new tbl_zSalesNoteType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zSalesNoteType.SalesNoteType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zSalesNoteType.SalesNoteName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zSalesNoteType.CoPrefix = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zSalesNoteType.CoCounter = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zSalesNoteType.CoLength = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zSalesNoteType.DoPrefix = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zSalesNoteType.DoCounter = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zSalesNoteType.DoLength = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zSalesNoteType.InvPrefix = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zSalesNoteType.InvCounter = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_zSalesNoteType.InvLength = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_zSalesNoteType.CrnPrefix = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_zSalesNoteType.CrnCounter = dataReader.GetInt32(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_zSalesNoteType.CrnLength = dataReader.GetInt32(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_zSalesNoteType.DrnPrefix = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_zSalesNoteType.DrnCounter = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_zSalesNoteType.DrnLength = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_zSalesNoteType.SrnPrefix = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_zSalesNoteType.SrnCounter = dataReader.GetInt32(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_zSalesNoteType.SrnLength = dataReader.GetInt32(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_zSalesNoteType.ReceiptPrefix = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_zSalesNoteType.ReceiptCounter = dataReader.GetInt32(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_zSalesNoteType.ReceiptLength = dataReader.GetInt32(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_zSalesNoteType.AdvanceReceiptPrefix = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_zSalesNoteType.AdvanceReceiptCounter = dataReader.GetInt32(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_zSalesNoteType.AdvanceReceiptLength = dataReader.GetInt32(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_zSalesNoteType.Gl_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_zSalesNoteType.IsPostingEnable_VAT = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_zSalesNoteType.IsPostingEnable_NBT = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_zSalesNoteType.CompanyID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_zSalesNoteType.CompanyBranch_ID = dataReader.GetString(30);
			}

			return tbl_zSalesNoteType;
		}
		/// <summary>
		/// This makes tbl_zSalesNoteType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zSalesNoteType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zSalesNoteType  tbl_zSalesNoteType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
			DataColumn col_salesNoteName = new DataColumn("salesNoteName" , typeof(string));
			DataColumn col_coPrefix = new DataColumn("coPrefix" , typeof(string));
			DataColumn col_coCounter = new DataColumn("coCounter" , typeof(int));
			DataColumn col_coLength = new DataColumn("coLength" , typeof(int));
			DataColumn col_doPrefix = new DataColumn("doPrefix" , typeof(string));
			DataColumn col_doCounter = new DataColumn("doCounter" , typeof(int));
			DataColumn col_doLength = new DataColumn("doLength" , typeof(int));
			DataColumn col_invPrefix = new DataColumn("invPrefix" , typeof(string));
			DataColumn col_invCounter = new DataColumn("invCounter" , typeof(int));
			DataColumn col_invLength = new DataColumn("invLength" , typeof(int));
			DataColumn col_crnPrefix = new DataColumn("crnPrefix" , typeof(string));
			DataColumn col_crnCounter = new DataColumn("crnCounter" , typeof(int));
			DataColumn col_crnLength = new DataColumn("crnLength" , typeof(int));
			DataColumn col_drnPrefix = new DataColumn("drnPrefix" , typeof(string));
			DataColumn col_drnCounter = new DataColumn("drnCounter" , typeof(int));
			DataColumn col_drnLength = new DataColumn("drnLength" , typeof(int));
			DataColumn col_srnPrefix = new DataColumn("srnPrefix" , typeof(string));
			DataColumn col_srnCounter = new DataColumn("srnCounter" , typeof(int));
			DataColumn col_srnLength = new DataColumn("srnLength" , typeof(int));
			DataColumn col_ReceiptPrefix = new DataColumn("ReceiptPrefix" , typeof(string));
			DataColumn col_ReceiptCounter = new DataColumn("ReceiptCounter" , typeof(int));
			DataColumn col_ReceiptLength = new DataColumn("ReceiptLength" , typeof(int));
			DataColumn col_advanceReceiptPrefix = new DataColumn("advanceReceiptPrefix" , typeof(string));
			DataColumn col_advanceReceiptCounter = new DataColumn("advanceReceiptCounter" , typeof(int));
			DataColumn col_advanceReceiptLength = new DataColumn("advanceReceiptLength" , typeof(int));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_isPostingEnable_VAT = new DataColumn("isPostingEnable_VAT" , typeof(bool));
			DataColumn col_isPostingEnable_NBT = new DataColumn("isPostingEnable_NBT" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_salesNoteType_ID,col_salesNoteName,col_coPrefix,col_coCounter,col_coLength,col_doPrefix,col_doCounter,col_doLength,col_invPrefix,col_invCounter,col_invLength,col_crnPrefix,col_crnCounter,col_crnLength,col_drnPrefix,col_drnCounter,col_drnLength,col_srnPrefix,col_srnCounter,col_srnLength,col_ReceiptPrefix,col_ReceiptCounter,col_ReceiptLength,col_advanceReceiptPrefix,col_advanceReceiptCounter,col_advanceReceiptLength,col_gl_ID,col_isPostingEnable_VAT,col_isPostingEnable_NBT,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zSalesNoteType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zSalesNoteType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zSalesNoteType user) {
		DataRow drow = dt.NewRow();
		
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
			drow["salesNoteName"] = user.salesNoteName;
			drow["coPrefix"] = user.coPrefix;
			drow["coCounter"] = user.coCounter;
			drow["coLength"] = user.coLength;
			drow["doPrefix"] = user.doPrefix;
			drow["doCounter"] = user.doCounter;
			drow["doLength"] = user.doLength;
			drow["invPrefix"] = user.invPrefix;
			drow["invCounter"] = user.invCounter;
			drow["invLength"] = user.invLength;
			drow["crnPrefix"] = user.crnPrefix;
			drow["crnCounter"] = user.crnCounter;
			drow["crnLength"] = user.crnLength;
			drow["drnPrefix"] = user.drnPrefix;
			drow["drnCounter"] = user.drnCounter;
			drow["drnLength"] = user.drnLength;
			drow["srnPrefix"] = user.srnPrefix;
			drow["srnCounter"] = user.srnCounter;
			drow["srnLength"] = user.srnLength;
			drow["ReceiptPrefix"] = user.ReceiptPrefix;
			drow["ReceiptCounter"] = user.ReceiptCounter;
			drow["ReceiptLength"] = user.ReceiptLength;
			drow["advanceReceiptPrefix"] = user.advanceReceiptPrefix;
			drow["advanceReceiptCounter"] = user.advanceReceiptCounter;
			drow["advanceReceiptLength"] = user.advanceReceiptLength;
			drow["gl_ID"] = user.gl_ID;
			drow["isPostingEnable_VAT"] = user.isPostingEnable_VAT;
			drow["isPostingEnable_NBT"] = user.isPostingEnable_NBT;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
