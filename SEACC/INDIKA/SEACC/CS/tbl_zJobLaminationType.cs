using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobLaminationType {
		#region Fields
		private string laminationType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobLaminationType class.
		/// </summary>
		public tbl_zJobLaminationType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobLaminationType class.
		/// </summary>
		public tbl_zJobLaminationType(string laminationType_ID, string typeName) {
			this.laminationType_ID = laminationType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the LaminationType_ID value.
		/// </summary>
		public string LaminationType_ID {
			get { return laminationType_ID; }
			set { laminationType_ID = value; }
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
		/// Saves a record to the tbl_zJobLaminationType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@laminationType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@laminationType_ID"].Value = laminationType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobLaminationType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@laminationType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@laminationType_ID"].Value = laminationType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobLaminationType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@laminationType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationType_ID"].Value = laminationType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobLaminationType table.
		/// </summary>
		public static tbl_zJobLaminationType Select(string laminationType_ID_Incoming){

			tbl_zJobLaminationType tbl_zJobLaminationTypeins = new tbl_zJobLaminationType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@laminationType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationType_ID"].Value = laminationType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobLaminationTypeins = Maketbl_zJobLaminationType(dataReader);
				} else {
					tbl_zJobLaminationTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobLaminationTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobLaminationType table.
		/// </summary>
		public static List<tbl_zJobLaminationType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobLaminationTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobLaminationType> tbl_zJobLaminationTypeList = new List<tbl_zJobLaminationType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobLaminationType tbl_zJobLaminationType = Maketbl_zJobLaminationType(dataReader);
					tbl_zJobLaminationTypeList.Add(tbl_zJobLaminationType);
				}
			}
			scon.Close();
			return tbl_zJobLaminationTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobLaminationType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobLaminationType Maketbl_zJobLaminationType(SqlDataReader dataReader) {
			tbl_zJobLaminationType tbl_zJobLaminationType = new tbl_zJobLaminationType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobLaminationType.LaminationType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobLaminationType.TypeName = dataReader.GetString(1);
			}

			return tbl_zJobLaminationType;
		}
		/// <summary>
		/// This makes tbl_zJobLaminationType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobLaminationType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobLaminationType  tbl_zJobLaminationType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_laminationType_ID = new DataColumn("laminationType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_laminationType_ID,col_typeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobLaminationType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobLaminationType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobLaminationType user) {
		DataRow drow = dt.NewRow();
		
			drow["laminationType_ID"] = user.laminationType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
