using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderDocumentMaster {
		#region Fields
		private string doc_ID;
		private string doc_Code;
		private int doc_Type;
		private string doc_Description;
		private bool tenderWise;
		private bool itemWise;
		private bool manufactureWise;
		private bool other;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderDocumentMaster class.
		/// </summary>
		public tbl_ttsTenderDocumentMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderDocumentMaster class.
		/// </summary>
		public tbl_ttsTenderDocumentMaster(string doc_ID, string doc_Code, int doc_Type, string doc_Description, bool tenderWise, bool itemWise, bool manufactureWise, bool other, bool isCanceled) {
			this.doc_ID = doc_ID;
			this.doc_Code = doc_Code;
			this.doc_Type = doc_Type;
			this.doc_Description = doc_Description;
			this.tenderWise = tenderWise;
			this.itemWise = itemWise;
			this.manufactureWise = manufactureWise;
			this.other = other;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Doc_ID value.
		/// </summary>
		public string Doc_ID {
			get { return doc_ID; }
			set { doc_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Doc_Code value.
		/// </summary>
		public string Doc_Code {
			get { return doc_Code; }
			set { doc_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Doc_Type value.
		/// </summary>
		public int Doc_Type {
			get { return doc_Type; }
			set { doc_Type = value; }
		}
		
		/// <summary>
		/// Gets or sets the Doc_Description value.
		/// </summary>
		public string Doc_Description {
			get { return doc_Description; }
			set { doc_Description = value; }
		}
		
		/// <summary>
		/// Gets or sets the TenderWise value.
		/// </summary>
		public bool TenderWise {
			get { return tenderWise; }
			set { tenderWise = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemWise value.
		/// </summary>
		public bool ItemWise {
			get { return itemWise; }
			set { itemWise = value; }
		}
		
		/// <summary>
		/// Gets or sets the ManufactureWise value.
		/// </summary>
		public bool ManufactureWise {
			get { return manufactureWise; }
			set { manufactureWise = value; }
		}
		
		/// <summary>
		/// Gets or sets the Other value.
		/// </summary>
		public bool Other {
			get { return other; }
			set { other = value; }
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
		/// Saves a record to the tbl_ttsTenderDocumentMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@doc_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@doc_Type", SqlDbType.Int,4);
			scom.Parameters.Add("@doc_Description", SqlDbType.VarChar,500);
			scom.Parameters.Add("@tenderWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@manufactureWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@other", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@doc_ID"].Value = doc_ID;
			scom.Parameters["@doc_Code"].Value = doc_Code;
			scom.Parameters["@doc_Type"].Value = doc_Type;
			scom.Parameters["@doc_Description"].Value = doc_Description;
			scom.Parameters["@tenderWise"].Value = tenderWise;
			scom.Parameters["@itemWise"].Value = itemWise;
			scom.Parameters["@manufactureWise"].Value = manufactureWise;
			scom.Parameters["@other"].Value = other;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderDocumentMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@doc_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@doc_Type", SqlDbType.Int,4);
			scom.Parameters.Add("@doc_Description", SqlDbType.VarChar,500);
			scom.Parameters.Add("@tenderWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@manufactureWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@other", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@doc_ID"].Value = doc_ID;
			scom.Parameters["@doc_Code"].Value = doc_Code;
			scom.Parameters["@doc_Type"].Value = doc_Type;
			scom.Parameters["@doc_Description"].Value = doc_Description;
			scom.Parameters["@tenderWise"].Value = tenderWise;
			scom.Parameters["@itemWise"].Value = itemWise;
			scom.Parameters["@manufactureWise"].Value = manufactureWise;
			scom.Parameters["@other"].Value = other;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderDocumentMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters["@doc_ID"].Value = doc_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderDocumentMaster table.
		/// </summary>
		public static tbl_ttsTenderDocumentMaster Select(string doc_ID_Incoming){

			tbl_ttsTenderDocumentMaster tbl_ttsTenderDocumentMasterins = new tbl_ttsTenderDocumentMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters["@doc_ID"].Value = doc_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderDocumentMasterins = Maketbl_ttsTenderDocumentMaster(dataReader);
				} else {
					tbl_ttsTenderDocumentMasterins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderDocumentMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderDocumentMaster table.
		/// </summary>
		public static List<tbl_ttsTenderDocumentMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderDocumentMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderDocumentMaster> tbl_ttsTenderDocumentMasterList = new List<tbl_ttsTenderDocumentMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderDocumentMaster tbl_ttsTenderDocumentMaster = Maketbl_ttsTenderDocumentMaster(dataReader);
					tbl_ttsTenderDocumentMasterList.Add(tbl_ttsTenderDocumentMaster);
				}
			}
			scon.Close();
			return tbl_ttsTenderDocumentMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderDocumentMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderDocumentMaster Maketbl_ttsTenderDocumentMaster(SqlDataReader dataReader) {
			tbl_ttsTenderDocumentMaster tbl_ttsTenderDocumentMaster = new tbl_ttsTenderDocumentMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderDocumentMaster.Doc_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderDocumentMaster.Doc_Code = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderDocumentMaster.Doc_Type = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsTenderDocumentMaster.Doc_Description = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsTenderDocumentMaster.TenderWise = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsTenderDocumentMaster.ItemWise = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsTenderDocumentMaster.ManufactureWise = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ttsTenderDocumentMaster.Other = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ttsTenderDocumentMaster.IsCanceled = dataReader.GetBoolean(8);
			}

			return tbl_ttsTenderDocumentMaster;
		}
		/// <summary>
		/// This makes tbl_ttsTenderDocumentMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderDocumentMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderDocumentMaster  tbl_ttsTenderDocumentMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_doc_ID = new DataColumn("doc_ID" , typeof(string));
			DataColumn col_doc_Code = new DataColumn("doc_Code" , typeof(string));
			DataColumn col_doc_Type = new DataColumn("doc_Type" , typeof(int));
			DataColumn col_doc_Description = new DataColumn("doc_Description" , typeof(string));
			DataColumn col_tenderWise = new DataColumn("tenderWise" , typeof(bool));
			DataColumn col_itemWise = new DataColumn("itemWise" , typeof(bool));
			DataColumn col_manufactureWise = new DataColumn("manufactureWise" , typeof(bool));
			DataColumn col_other = new DataColumn("other" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_doc_ID,col_doc_Code,col_doc_Type,col_doc_Description,col_tenderWise,col_itemWise,col_manufactureWise,col_other,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderDocumentMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderDocumentMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderDocumentMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["doc_ID"] = user.doc_ID;
			drow["doc_Code"] = user.doc_Code;
			drow["doc_Type"] = user.doc_Type;
			drow["doc_Description"] = user.doc_Description;
			drow["tenderWise"] = user.tenderWise;
			drow["itemWise"] = user.itemWise;
			drow["manufactureWise"] = user.manufactureWise;
			drow["other"] = user.other;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
