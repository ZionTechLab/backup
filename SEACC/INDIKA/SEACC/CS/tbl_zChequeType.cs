using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zChequeType {
		#region Fields
		private string chequeType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zChequeType class.
		/// </summary>
		public tbl_zChequeType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zChequeType class.
		/// </summary>
		public tbl_zChequeType(string chequeType_ID, string typeName) {
			this.chequeType_ID = chequeType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeType_ID value.
		/// </summary>
		public string ChequeType_ID {
			get { return chequeType_ID; }
			set { chequeType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zChequeType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zChequeType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zChequeType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zChequeType table.
		/// </summary>
		public static tbl_zChequeType Select(string chequeType_ID_Incoming){

			tbl_zChequeType tbl_zChequeTypeins = new tbl_zChequeType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zChequeTypeins = Maketbl_zChequeType(dataReader);
				} else {
					tbl_zChequeTypeins = null;
				}
			}
			scon.Close();
			return tbl_zChequeTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zChequeType table.
		/// </summary>
		public static List<tbl_zChequeType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zChequeType> tbl_zChequeTypeList = new List<tbl_zChequeType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zChequeType tbl_zChequeType = Maketbl_zChequeType(dataReader);
					tbl_zChequeTypeList.Add(tbl_zChequeType);
				}
			}
			scon.Close();
			return tbl_zChequeTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zChequeType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zChequeType Maketbl_zChequeType(SqlDataReader dataReader) {
			tbl_zChequeType tbl_zChequeType = new tbl_zChequeType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zChequeType.ChequeType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zChequeType.TypeName = dataReader.GetString(1);
			}

			return tbl_zChequeType;
		}
		/// <summary>
		/// This fills tbl_zChequeType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zChequeType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zChequeType user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeType_ID"] = user.chequeType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
