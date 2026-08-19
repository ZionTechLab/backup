using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobSealingMethod {
		#region Fields
		private string sealingMethod_ID;
		private string sealingMethod;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobSealingMethod class.
		/// </summary>
		public tbl_zJobSealingMethod() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobSealingMethod class.
		/// </summary>
		public tbl_zJobSealingMethod(string sealingMethod_ID, string sealingMethod) {
			this.sealingMethod_ID = sealingMethod_ID;
			this.sealingMethod = sealingMethod;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SealingMethod_ID value.
		/// </summary>
		public string SealingMethod_ID {
			get { return sealingMethod_ID; }
			set { sealingMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SealingMethod value.
		/// </summary>
		public string SealingMethod {
			get { return sealingMethod; }
			set { sealingMethod = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobSealingMethod table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingMethodInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sealingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingMethod", SqlDbType.VarChar,50);
 
			scom.Parameters["@sealingMethod_ID"].Value = sealingMethod_ID;
			scom.Parameters["@sealingMethod"].Value = sealingMethod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobSealingMethod table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingMethodUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sealingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingMethod", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@sealingMethod_ID"].Value = sealingMethod_ID;
			scom.Parameters["@sealingMethod"].Value = sealingMethod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobSealingMethod table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingMethodDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sealingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingMethod_ID"].Value = sealingMethod_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobSealingMethod table.
		/// </summary>
		public static tbl_zJobSealingMethod Select(string sealingMethod_ID_Incoming){

			tbl_zJobSealingMethod tbl_zJobSealingMethodins = new tbl_zJobSealingMethod();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingMethodSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sealingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingMethod_ID"].Value = sealingMethod_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobSealingMethodins = Maketbl_zJobSealingMethod(dataReader);
				} else {
					tbl_zJobSealingMethodins = null;
				}
			}
			scon.Close();
			return tbl_zJobSealingMethodins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobSealingMethod table.
		/// </summary>
		public static List<tbl_zJobSealingMethod> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobSealingMethodSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobSealingMethod> tbl_zJobSealingMethodList = new List<tbl_zJobSealingMethod>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobSealingMethod tbl_zJobSealingMethod = Maketbl_zJobSealingMethod(dataReader);
					tbl_zJobSealingMethodList.Add(tbl_zJobSealingMethod);
				}
			}
			scon.Close();
			return tbl_zJobSealingMethodList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobSealingMethod class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobSealingMethod Maketbl_zJobSealingMethod(SqlDataReader dataReader) {
			tbl_zJobSealingMethod tbl_zJobSealingMethod = new tbl_zJobSealingMethod();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobSealingMethod.SealingMethod_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobSealingMethod.SealingMethod = dataReader.GetString(1);
			}

			return tbl_zJobSealingMethod;
		}
		/// <summary>
		/// This makes tbl_zJobSealingMethod datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobSealingMethod object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobSealingMethod  tbl_zJobSealingMethod   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_sealingMethod_ID = new DataColumn("sealingMethod_ID" , typeof(string));
			DataColumn col_sealingMethod = new DataColumn("sealingMethod" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_sealingMethod_ID,col_sealingMethod,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobSealingMethod datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobSealingMethod object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobSealingMethod user) {
		DataRow drow = dt.NewRow();
		
			drow["sealingMethod_ID"] = user.sealingMethod_ID;
			drow["sealingMethod"] = user.sealingMethod;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
