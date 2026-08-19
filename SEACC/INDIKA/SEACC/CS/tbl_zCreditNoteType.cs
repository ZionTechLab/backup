using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCreditNoteType {
		#region Fields
		private string creditNoteType_ID;
		private string creditNoteTypeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCreditNoteType class.
		/// </summary>
		public tbl_zCreditNoteType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCreditNoteType class.
		/// </summary>
		public tbl_zCreditNoteType(string creditNoteType_ID, string creditNoteTypeName) {
			this.creditNoteType_ID = creditNoteType_ID;
			this.creditNoteTypeName = creditNoteTypeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CreditNoteType_ID value.
		/// </summary>
		public string CreditNoteType_ID {
			get { return creditNoteType_ID; }
			set { creditNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditNoteTypeName value.
		/// </summary>
		public string CreditNoteTypeName {
			get { return creditNoteTypeName; }
			set { creditNoteTypeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zCreditNoteType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCreditNoteTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@creditNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@creditNoteTypeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@creditNoteType_ID"].Value = creditNoteType_ID;
			scom.Parameters["@creditNoteTypeName"].Value = creditNoteTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCreditNoteType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCreditNoteTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@creditNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@creditNoteTypeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@creditNoteType_ID"].Value = creditNoteType_ID;
			scom.Parameters["@creditNoteTypeName"].Value = creditNoteTypeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCreditNoteType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCreditNoteTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@creditNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@creditNoteType_ID"].Value = creditNoteType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCreditNoteType table.
		/// </summary>
		public static tbl_zCreditNoteType Select(string creditNoteType_ID_Incoming){

			tbl_zCreditNoteType tbl_zCreditNoteTypeins = new tbl_zCreditNoteType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCreditNoteTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@creditNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@creditNoteType_ID"].Value = creditNoteType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCreditNoteTypeins = Maketbl_zCreditNoteType(dataReader);
				} else {
					tbl_zCreditNoteTypeins = null;
				}
			}
			scon.Close();
			return tbl_zCreditNoteTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCreditNoteType table.
		/// </summary>
		public static List<tbl_zCreditNoteType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCreditNoteTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCreditNoteType> tbl_zCreditNoteTypeList = new List<tbl_zCreditNoteType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCreditNoteType tbl_zCreditNoteType = Maketbl_zCreditNoteType(dataReader);
					tbl_zCreditNoteTypeList.Add(tbl_zCreditNoteType);
				}
			}
			scon.Close();
			return tbl_zCreditNoteTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCreditNoteType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCreditNoteType Maketbl_zCreditNoteType(SqlDataReader dataReader) {
			tbl_zCreditNoteType tbl_zCreditNoteType = new tbl_zCreditNoteType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCreditNoteType.CreditNoteType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCreditNoteType.CreditNoteTypeName = dataReader.GetString(1);
			}

			return tbl_zCreditNoteType;
		}
		/// <summary>
		/// This makes tbl_zCreditNoteType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zCreditNoteType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zCreditNoteType  tbl_zCreditNoteType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_creditNoteType_ID = new DataColumn("creditNoteType_ID" , typeof(string));
			DataColumn col_creditNoteTypeName = new DataColumn("creditNoteTypeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_creditNoteType_ID,col_creditNoteTypeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zCreditNoteType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCreditNoteType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCreditNoteType user) {
		DataRow drow = dt.NewRow();
		
			drow["creditNoteType_ID"] = user.creditNoteType_ID;
			drow["creditNoteTypeName"] = user.creditNoteTypeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
