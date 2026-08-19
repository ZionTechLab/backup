using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zChequeStatus {
		#region Fields
		private string chequeStatus_ID;
		private string statusName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zChequeStatus class.
		/// </summary>
		public tbl_zChequeStatus() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zChequeStatus class.
		/// </summary>
		public tbl_zChequeStatus(string chequeStatus_ID, string statusName) {
			this.chequeStatus_ID = chequeStatus_ID;
			this.statusName = statusName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeStatus_ID value.
		/// </summary>
		public string ChequeStatus_ID {
			get { return chequeStatus_ID; }
			set { chequeStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatusName value.
		/// </summary>
		public string StatusName {
			get { return statusName; }
			set { statusName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zChequeStatus table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeStatusInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statusName", SqlDbType.VarChar,50);
 
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@statusName"].Value = statusName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zChequeStatus table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeStatusUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statusName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@statusName"].Value = statusName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zChequeStatus table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeStatusDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zChequeStatus table.
		/// </summary>
		public static tbl_zChequeStatus Select(string chequeStatus_ID_Incoming){

			tbl_zChequeStatus tbl_zChequeStatusins = new tbl_zChequeStatus();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeStatusSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zChequeStatusins = Maketbl_zChequeStatus(dataReader);
				} else {
					tbl_zChequeStatusins = null;
				}
			}
			scon.Close();
			return tbl_zChequeStatusins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zChequeStatus table.
		/// </summary>
		public static List<tbl_zChequeStatus> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zChequeStatusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zChequeStatus> tbl_zChequeStatusList = new List<tbl_zChequeStatus>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zChequeStatus tbl_zChequeStatus = Maketbl_zChequeStatus(dataReader);
					tbl_zChequeStatusList.Add(tbl_zChequeStatus);
				}
			}
			scon.Close();
			return tbl_zChequeStatusList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zChequeStatus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zChequeStatus Maketbl_zChequeStatus(SqlDataReader dataReader) {
			tbl_zChequeStatus tbl_zChequeStatus = new tbl_zChequeStatus();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zChequeStatus.ChequeStatus_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zChequeStatus.StatusName = dataReader.GetString(1);
			}

			return tbl_zChequeStatus;
		}
		/// <summary>
		/// This fills tbl_zChequeStatus datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zChequeStatus object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zChequeStatus user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeStatus_ID"] = user.chequeStatus_ID;
			drow["statusName"] = user.statusName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
