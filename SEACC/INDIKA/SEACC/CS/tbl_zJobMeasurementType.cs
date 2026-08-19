using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobMeasurementType {
		#region Fields
		private string measureType_ID;
		private string typeName;
		private decimal translateValue;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobMeasurementType class.
		/// </summary>
		public tbl_zJobMeasurementType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobMeasurementType class.
		/// </summary>
		public tbl_zJobMeasurementType(string measureType_ID, string typeName, decimal translateValue) {
			this.measureType_ID = measureType_ID;
			this.typeName = typeName;
			this.translateValue = translateValue;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MeasureType_ID value.
		/// </summary>
		public string MeasureType_ID {
			get { return measureType_ID; }
			set { measureType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the TranslateValue value.
		/// </summary>
		public decimal TranslateValue {
			get { return translateValue; }
			set { translateValue = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobMeasurementType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobMeasurementTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@translateValue", SqlDbType.Decimal,9);
 
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
			scom.Parameters["@typeName"].Value = typeName;
			scom.Parameters["@translateValue"].Value = translateValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobMeasurementType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobMeasurementTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@translateValue", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
			scom.Parameters["@typeName"].Value = typeName;
			scom.Parameters["@translateValue"].Value = translateValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobMeasurementType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobMeasurementTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobMeasurementType table.
		/// </summary>
		public static tbl_zJobMeasurementType Select(string measureType_ID_Incoming){

			tbl_zJobMeasurementType tbl_zJobMeasurementTypeins = new tbl_zJobMeasurementType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobMeasurementTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@measureType_ID"].Value = measureType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobMeasurementTypeins = Maketbl_zJobMeasurementType(dataReader);
				} else {
					tbl_zJobMeasurementTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobMeasurementTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobMeasurementType table.
		/// </summary>
		public static List<tbl_zJobMeasurementType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobMeasurementTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobMeasurementType> tbl_zJobMeasurementTypeList = new List<tbl_zJobMeasurementType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobMeasurementType tbl_zJobMeasurementType = Maketbl_zJobMeasurementType(dataReader);
					tbl_zJobMeasurementTypeList.Add(tbl_zJobMeasurementType);
				}
			}
			scon.Close();
			return tbl_zJobMeasurementTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobMeasurementType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobMeasurementType Maketbl_zJobMeasurementType(SqlDataReader dataReader) {
			tbl_zJobMeasurementType tbl_zJobMeasurementType = new tbl_zJobMeasurementType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobMeasurementType.MeasureType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobMeasurementType.TypeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zJobMeasurementType.TranslateValue = dataReader.GetDecimal(2);
			}

			return tbl_zJobMeasurementType;
		}
		/// <summary>
		/// This makes tbl_zJobMeasurementType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobMeasurementType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobMeasurementType  tbl_zJobMeasurementType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_measureType_ID = new DataColumn("measureType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
			DataColumn col_translateValue = new DataColumn("translateValue" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_measureType_ID,col_typeName,col_translateValue,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobMeasurementType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobMeasurementType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobMeasurementType user) {
		DataRow drow = dt.NewRow();
		
			drow["measureType_ID"] = user.measureType_ID;
			drow["typeName"] = user.typeName;
			drow["translateValue"] = user.translateValue;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
