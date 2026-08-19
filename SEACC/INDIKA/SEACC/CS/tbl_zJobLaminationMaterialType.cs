using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobLaminationMaterialType {
		#region Fields
		private string laminationMaterailType_ID;
		private string laminationMaterailTypeName;
		private decimal dencity;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobLaminationMaterialType class.
		/// </summary>
		public tbl_zJobLaminationMaterialType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobLaminationMaterialType class.
		/// </summary>
		public tbl_zJobLaminationMaterialType(string laminationMaterailType_ID, string laminationMaterailTypeName, decimal dencity) {
			this.laminationMaterailType_ID = laminationMaterailType_ID;
			this.laminationMaterailTypeName = laminationMaterailTypeName;
			this.dencity = dencity;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the LaminationMaterailType_ID value.
		/// </summary>
		public string LaminationMaterailType_ID {
			get { return laminationMaterailType_ID; }
			set { laminationMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LaminationMaterailTypeName value.
		/// </summary>
		public string LaminationMaterailTypeName {
			get { return laminationMaterailTypeName; }
			set { laminationMaterailTypeName = value; }
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
		/// Saves a record to the tbl_zJobLaminationMaterialType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationMaterialTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@laminationMaterailTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@Dencity", SqlDbType.Decimal,9);
 
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
			scom.Parameters["@laminationMaterailTypeName"].Value = laminationMaterailTypeName;
			scom.Parameters["@Dencity"].Value = dencity;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobLaminationMaterialType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationMaterialTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@laminationMaterailTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@Dencity", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
			scom.Parameters["@laminationMaterailTypeName"].Value = laminationMaterailTypeName;
			scom.Parameters["@Dencity"].Value = dencity;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobLaminationMaterialType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationMaterialTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobLaminationMaterialType table.
		/// </summary>
		public static tbl_zJobLaminationMaterialType Select(string laminationMaterailType_ID_Incoming){

			tbl_zJobLaminationMaterialType tbl_zJobLaminationMaterialTypeins = new tbl_zJobLaminationMaterialType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationMaterialTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobLaminationMaterialTypeins = Maketbl_zJobLaminationMaterialType(dataReader);
				} else {
					tbl_zJobLaminationMaterialTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobLaminationMaterialTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobLaminationMaterialType table.
		/// </summary>
		public static List<tbl_zJobLaminationMaterialType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationMaterialTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobLaminationMaterialType> tbl_zJobLaminationMaterialTypeList = new List<tbl_zJobLaminationMaterialType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobLaminationMaterialType tbl_zJobLaminationMaterialType = Maketbl_zJobLaminationMaterialType(dataReader);
					tbl_zJobLaminationMaterialTypeList.Add(tbl_zJobLaminationMaterialType);
				}
			}
			scon.Close();
			return tbl_zJobLaminationMaterialTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobLaminationMaterialType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobLaminationMaterialType Maketbl_zJobLaminationMaterialType(SqlDataReader dataReader) {
			tbl_zJobLaminationMaterialType tbl_zJobLaminationMaterialType = new tbl_zJobLaminationMaterialType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobLaminationMaterialType.LaminationMaterailType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobLaminationMaterialType.LaminationMaterailTypeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zJobLaminationMaterialType.Dencity = dataReader.GetDecimal(2);
			}

			return tbl_zJobLaminationMaterialType;
		}
		/// <summary>
		/// This makes tbl_zJobLaminationMaterialType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobLaminationMaterialType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobLaminationMaterialType  tbl_zJobLaminationMaterialType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_laminationMaterailType_ID = new DataColumn("laminationMaterailType_ID" , typeof(string));
			DataColumn col_laminationMaterailTypeName = new DataColumn("laminationMaterailTypeName" , typeof(string));
			DataColumn col_Dencity = new DataColumn("Dencity" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_laminationMaterailType_ID,col_laminationMaterailTypeName,col_Dencity,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobLaminationMaterialType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobLaminationMaterialType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobLaminationMaterialType user) {
		DataRow drow = dt.NewRow();
		
			drow["laminationMaterailType_ID"] = user.laminationMaterailType_ID;
			drow["laminationMaterailTypeName"] = user.laminationMaterailTypeName;
			drow["Dencity"] = user.Dencity;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
