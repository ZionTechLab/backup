using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zIssuedRefNo {
		#region Fields
		private string issuedRefNo_ID;
		private string issuedRefNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zIssuedRefNo class.
		/// </summary>
		public tbl_zIssuedRefNo() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zIssuedRefNo class.
		/// </summary>
		public tbl_zIssuedRefNo(string issuedRefNo_ID, string issuedRefNo) {
			this.issuedRefNo_ID = issuedRefNo_ID;
			this.issuedRefNo = issuedRefNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the IssuedRefNo_ID value.
		/// </summary>
		public string IssuedRefNo_ID {
			get { return issuedRefNo_ID; }
			set { issuedRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IssuedRefNo value.
		/// </summary>
		public string IssuedRefNo {
			get { return issuedRefNo; }
			set { issuedRefNo = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zIssuedRefNo table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zIssuedRefNoInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@IssuedRefNo", SqlDbType.VarChar,50);
 
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@IssuedRefNo"].Value = issuedRefNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zIssuedRefNo table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zIssuedRefNoUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@IssuedRefNo", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@IssuedRefNo"].Value = issuedRefNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zIssuedRefNo table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zIssuedRefNoDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zIssuedRefNo table.
		/// </summary>
		public static tbl_zIssuedRefNo Select(string issuedRefNo_ID_Incoming){

			tbl_zIssuedRefNo tbl_zIssuedRefNoins = new tbl_zIssuedRefNo();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zIssuedRefNoSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zIssuedRefNoins = Maketbl_zIssuedRefNo(dataReader);
				} else {
					tbl_zIssuedRefNoins = null;
				}
			}
			scon.Close();
			return tbl_zIssuedRefNoins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zIssuedRefNo table.
		/// </summary>
		public static List<tbl_zIssuedRefNo> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zIssuedRefNoSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zIssuedRefNo> tbl_zIssuedRefNoList = new List<tbl_zIssuedRefNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zIssuedRefNo tbl_zIssuedRefNo = Maketbl_zIssuedRefNo(dataReader);
					tbl_zIssuedRefNoList.Add(tbl_zIssuedRefNo);
				}
			}
			scon.Close();
			return tbl_zIssuedRefNoList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zIssuedRefNo class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zIssuedRefNo Maketbl_zIssuedRefNo(SqlDataReader dataReader) {
			tbl_zIssuedRefNo tbl_zIssuedRefNo = new tbl_zIssuedRefNo();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zIssuedRefNo.IssuedRefNo_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zIssuedRefNo.IssuedRefNo = dataReader.GetString(1);
			}

			return tbl_zIssuedRefNo;
		}
		/// <summary>
		/// This makes tbl_zIssuedRefNo datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zIssuedRefNo object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zIssuedRefNo  tbl_zIssuedRefNo   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_IssuedRefNo_ID = new DataColumn("IssuedRefNo_ID" , typeof(string));
			DataColumn col_IssuedRefNo = new DataColumn("IssuedRefNo" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_IssuedRefNo_ID,col_IssuedRefNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zIssuedRefNo datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zIssuedRefNo object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zIssuedRefNo user) {
		DataRow drow = dt.NewRow();
		
			drow["IssuedRefNo_ID"] = user.IssuedRefNo_ID;
			drow["IssuedRefNo"] = user.IssuedRefNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
