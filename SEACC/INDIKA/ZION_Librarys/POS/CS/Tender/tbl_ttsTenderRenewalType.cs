using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderRenewalType {
		#region Fields
		private int renewal_ID;
		private string renewal_Name;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderRenewalType class.
		/// </summary>
		public tbl_ttsTenderRenewalType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderRenewalType class.
		/// </summary>
		public tbl_ttsTenderRenewalType(int renewal_ID, string renewal_Name) {
			this.renewal_ID = renewal_ID;
			this.renewal_Name = renewal_Name;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Renewal_ID value.
		/// </summary>
		public int Renewal_ID {
			get { return renewal_ID; }
			set { renewal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Renewal_Name value.
		/// </summary>
		public string Renewal_Name {
			get { return renewal_Name; }
			set { renewal_Name = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderRenewalType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderRenewalTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@renewal_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@renewal_Name", SqlDbType.VarChar,100);
 
			scom.Parameters["@renewal_ID"].Value = renewal_ID;
			scom.Parameters["@renewal_Name"].Value = renewal_Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderRenewalType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderRenewalTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@renewal_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@renewal_Name", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@renewal_ID"].Value = renewal_ID;
			scom.Parameters["@renewal_Name"].Value = renewal_Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderRenewalType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderRenewalTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@renewal_ID", SqlDbType.Int,4);
			scom.Parameters["@renewal_ID"].Value = renewal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderRenewalType table.
		/// </summary>
		public static tbl_ttsTenderRenewalType Select(int renewal_ID_Incoming){

			tbl_ttsTenderRenewalType tbl_ttsTenderRenewalTypeins = new tbl_ttsTenderRenewalType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderRenewalTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@renewal_ID", SqlDbType.Int,4);
			scom.Parameters["@renewal_ID"].Value = renewal_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderRenewalTypeins = Maketbl_ttsTenderRenewalType(dataReader);
				} else {
					tbl_ttsTenderRenewalTypeins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderRenewalTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderRenewalType table.
		/// </summary>
		public static List<tbl_ttsTenderRenewalType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderRenewalTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderRenewalType> tbl_ttsTenderRenewalTypeList = new List<tbl_ttsTenderRenewalType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderRenewalType tbl_ttsTenderRenewalType = Maketbl_ttsTenderRenewalType(dataReader);
					tbl_ttsTenderRenewalTypeList.Add(tbl_ttsTenderRenewalType);
				}
			}
			scon.Close();
			return tbl_ttsTenderRenewalTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderRenewalType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderRenewalType Maketbl_ttsTenderRenewalType(SqlDataReader dataReader) {
			tbl_ttsTenderRenewalType tbl_ttsTenderRenewalType = new tbl_ttsTenderRenewalType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderRenewalType.Renewal_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderRenewalType.Renewal_Name = dataReader.GetString(1);
			}

			return tbl_ttsTenderRenewalType;
		}
		/// <summary>
		/// This makes tbl_ttsTenderRenewalType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderRenewalType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderRenewalType  tbl_ttsTenderRenewalType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_renewal_ID = new DataColumn("renewal_ID" , typeof(int));
			DataColumn col_renewal_Name = new DataColumn("renewal_Name" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_renewal_ID,col_renewal_Name,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderRenewalType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderRenewalType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderRenewalType user) {
		DataRow drow = dt.NewRow();
		
			drow["renewal_ID"] = user.renewal_ID;
			drow["renewal_Name"] = user.renewal_Name;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
