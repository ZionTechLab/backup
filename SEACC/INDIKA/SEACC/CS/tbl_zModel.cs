using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zModel {
		#region Fields
		private string model_ID;
		private string modelName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zModel class.
		/// </summary>
		public tbl_zModel() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zModel class.
		/// </summary>
		public tbl_zModel(string model_ID, string modelName) {
			this.model_ID = model_ID;
			this.modelName = modelName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Model_ID value.
		/// </summary>
		public string Model_ID {
			get { return model_ID; }
			set { model_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModelName value.
		/// </summary>
		public string ModelName {
			get { return modelName; }
			set { modelName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zModel table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zModelInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@modelName", SqlDbType.VarChar,50);
 
			scom.Parameters["@model_ID"].Value = model_ID;
			scom.Parameters["@modelName"].Value = modelName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zModel table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zModelUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@modelName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@model_ID"].Value = model_ID;
			scom.Parameters["@modelName"].Value = modelName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zModel table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zModelDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters["@model_ID"].Value = model_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zModel table.
		/// </summary>
		public static tbl_zModel Select(string model_ID_Incoming){

			tbl_zModel tbl_zModelins = new tbl_zModel();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zModelSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters["@model_ID"].Value = model_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zModelins = Maketbl_zModel(dataReader);
				} else {
					tbl_zModelins = null;
				}
			}
			scon.Close();
			return tbl_zModelins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zModel table.
		/// </summary>
		public static List<tbl_zModel> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zModelSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zModel> tbl_zModelList = new List<tbl_zModel>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zModel tbl_zModel = Maketbl_zModel(dataReader);
					tbl_zModelList.Add(tbl_zModel);
				}
			}
			scon.Close();
			return tbl_zModelList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zModel class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zModel Maketbl_zModel(SqlDataReader dataReader) {
			tbl_zModel tbl_zModel = new tbl_zModel();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zModel.Model_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zModel.ModelName = dataReader.GetString(1);
			}

			return tbl_zModel;
		}
		/// <summary>
		/// This makes tbl_zModel datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zModel object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zModel  tbl_zModel   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_model_ID = new DataColumn("model_ID" , typeof(string));
			DataColumn col_modelName = new DataColumn("modelName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_model_ID,col_modelName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zModel datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zModel object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zModel user) {
		DataRow drow = dt.NewRow();
		
			drow["model_ID"] = user.model_ID;
			drow["modelName"] = user.modelName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
