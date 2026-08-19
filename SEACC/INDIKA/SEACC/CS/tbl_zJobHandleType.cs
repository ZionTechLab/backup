using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobHandleType {
		#region Fields
		private string handleType_ID;
		private string handleTypeeName;
		private decimal handleWeight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobHandleType class.
		/// </summary>
		public tbl_zJobHandleType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobHandleType class.
		/// </summary>
		public tbl_zJobHandleType(string handleType_ID, string handleTypeeName, decimal handleWeight) {
			this.handleType_ID = handleType_ID;
			this.handleTypeeName = handleTypeeName;
			this.handleWeight = handleWeight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the HandleType_ID value.
		/// </summary>
		public string HandleType_ID {
			get { return handleType_ID; }
			set { handleType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the HandleTypeeName value.
		/// </summary>
		public string HandleTypeeName {
			get { return handleTypeeName; }
			set { handleTypeeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the HandleWeight value.
		/// </summary>
		public decimal HandleWeight {
			get { return handleWeight; }
			set { handleWeight = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobHandleType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobHandleTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@handleType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@handleTypeeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@handleWeight", SqlDbType.Decimal,9);
 
			scom.Parameters["@handleType_ID"].Value = handleType_ID;
			scom.Parameters["@handleTypeeName"].Value = handleTypeeName;
			scom.Parameters["@handleWeight"].Value = handleWeight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobHandleType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobHandleTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@handleType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@handleTypeeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@handleWeight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@handleType_ID"].Value = handleType_ID;
			scom.Parameters["@handleTypeeName"].Value = handleTypeeName;
			scom.Parameters["@handleWeight"].Value = handleWeight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobHandleType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobHandleTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@handleType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@handleType_ID"].Value = handleType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobHandleType table.
		/// </summary>
		public static tbl_zJobHandleType Select(string handleType_ID_Incoming){

			tbl_zJobHandleType tbl_zJobHandleTypeins = new tbl_zJobHandleType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobHandleTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@handleType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@handleType_ID"].Value = handleType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobHandleTypeins = Maketbl_zJobHandleType(dataReader);
				} else {
					tbl_zJobHandleTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobHandleTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobHandleType table.
		/// </summary>
		public static List<tbl_zJobHandleType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobHandleTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobHandleType> tbl_zJobHandleTypeList = new List<tbl_zJobHandleType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobHandleType tbl_zJobHandleType = Maketbl_zJobHandleType(dataReader);
					tbl_zJobHandleTypeList.Add(tbl_zJobHandleType);
				}
			}
			scon.Close();
			return tbl_zJobHandleTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobHandleType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobHandleType Maketbl_zJobHandleType(SqlDataReader dataReader) {
			tbl_zJobHandleType tbl_zJobHandleType = new tbl_zJobHandleType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobHandleType.HandleType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobHandleType.HandleTypeeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zJobHandleType.HandleWeight = dataReader.GetDecimal(2);
			}

			return tbl_zJobHandleType;
		}
		/// <summary>
		/// This makes tbl_zJobHandleType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobHandleType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobHandleType  tbl_zJobHandleType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_handleType_ID = new DataColumn("handleType_ID" , typeof(string));
			DataColumn col_handleTypeeName = new DataColumn("handleTypeeName" , typeof(string));
			DataColumn col_handleWeight = new DataColumn("handleWeight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_handleType_ID,col_handleTypeeName,col_handleWeight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobHandleType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobHandleType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobHandleType user) {
		DataRow drow = dt.NewRow();
		
			drow["handleType_ID"] = user.handleType_ID;
			drow["handleTypeeName"] = user.handleTypeeName;
			drow["handleWeight"] = user.handleWeight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
