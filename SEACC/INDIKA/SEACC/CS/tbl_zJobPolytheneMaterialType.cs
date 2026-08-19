using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobPolytheneMaterialType {
		#region Fields
		private string polytheneMaterailType_ID;
		private string polytheneMaterailTypeName;
		private decimal dencity;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPolytheneMaterialType class.
		/// </summary>
		public tbl_zJobPolytheneMaterialType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobPolytheneMaterialType class.
		/// </summary>
		public tbl_zJobPolytheneMaterialType(string polytheneMaterailType_ID, string polytheneMaterailTypeName, decimal dencity) {
			this.polytheneMaterailType_ID = polytheneMaterailType_ID;
			this.polytheneMaterailTypeName = polytheneMaterailTypeName;
			this.dencity = dencity;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PolytheneMaterailType_ID value.
		/// </summary>
		public string PolytheneMaterailType_ID {
			get { return polytheneMaterailType_ID; }
			set { polytheneMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PolytheneMaterailTypeName value.
		/// </summary>
		public string PolytheneMaterailTypeName {
			get { return polytheneMaterailTypeName; }
			set { polytheneMaterailTypeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Dencity value.
		/// </summary>
		public decimal Dencity {
			get { return dencity; }
			set { dencity = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobPolytheneMaterialType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneMaterialTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneMaterailTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@Dencity", SqlDbType.Decimal,9);
 
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
			scom.Parameters["@polytheneMaterailTypeName"].Value = polytheneMaterailTypeName;
			scom.Parameters["@Dencity"].Value = dencity;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobPolytheneMaterialType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneMaterialTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneMaterailTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@Dencity", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
			scom.Parameters["@polytheneMaterailTypeName"].Value = polytheneMaterailTypeName;
			scom.Parameters["@Dencity"].Value = dencity;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobPolytheneMaterialType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneMaterialTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobPolytheneMaterialType table.
		/// </summary>
		public static tbl_zJobPolytheneMaterialType Select(string polytheneMaterailType_ID_Incoming){

			tbl_zJobPolytheneMaterialType tbl_zJobPolytheneMaterialTypeins = new tbl_zJobPolytheneMaterialType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneMaterialTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobPolytheneMaterialTypeins = Maketbl_zJobPolytheneMaterialType(dataReader);
				} else {
					tbl_zJobPolytheneMaterialTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobPolytheneMaterialTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobPolytheneMaterialType table.
		/// </summary>
		public static List<tbl_zJobPolytheneMaterialType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobPolytheneMaterialTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobPolytheneMaterialType> tbl_zJobPolytheneMaterialTypeList = new List<tbl_zJobPolytheneMaterialType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobPolytheneMaterialType tbl_zJobPolytheneMaterialType = Maketbl_zJobPolytheneMaterialType(dataReader);
					tbl_zJobPolytheneMaterialTypeList.Add(tbl_zJobPolytheneMaterialType);
				}
			}
			scon.Close();
			return tbl_zJobPolytheneMaterialTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobPolytheneMaterialType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobPolytheneMaterialType Maketbl_zJobPolytheneMaterialType(SqlDataReader dataReader) {
			tbl_zJobPolytheneMaterialType tbl_zJobPolytheneMaterialType = new tbl_zJobPolytheneMaterialType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobPolytheneMaterialType.PolytheneMaterailType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobPolytheneMaterialType.PolytheneMaterailTypeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zJobPolytheneMaterialType.Dencity = dataReader.GetDecimal(2);
			}

			return tbl_zJobPolytheneMaterialType;
		}
		/// <summary>
		/// This makes tbl_zJobPolytheneMaterialType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobPolytheneMaterialType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobPolytheneMaterialType  tbl_zJobPolytheneMaterialType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_polytheneMaterailType_ID = new DataColumn("polytheneMaterailType_ID" , typeof(string));
			DataColumn col_polytheneMaterailTypeName = new DataColumn("polytheneMaterailTypeName" , typeof(string));
			DataColumn col_Dencity = new DataColumn("Dencity" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_polytheneMaterailType_ID,col_polytheneMaterailTypeName,col_Dencity,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobPolytheneMaterialType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobPolytheneMaterialType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobPolytheneMaterialType user) {
		DataRow drow = dt.NewRow();
		
			drow["polytheneMaterailType_ID"] = user.polytheneMaterailType_ID;
			drow["polytheneMaterailTypeName"] = user.polytheneMaterailTypeName;
			drow["Dencity"] = user.Dencity;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
