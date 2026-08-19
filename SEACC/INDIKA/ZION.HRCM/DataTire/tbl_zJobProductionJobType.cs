using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobProductionJobType {
		#region Fields
		private string productionJobType_ID;
		private string productionJobTypeName;
		private string doPrefix;
		private int doCounter;
		private int doLength;
		private string invPrefix;
		private int invCounter;
		private int invLength;
		private string jobPrefix;
		private int jobCounter;
		private int jobLength;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobProductionJobType class.
		/// </summary>
		public tbl_zJobProductionJobType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobProductionJobType class.
		/// </summary>
		public tbl_zJobProductionJobType(string productionJobType_ID, string productionJobTypeName, string doPrefix, int doCounter, int doLength, string invPrefix, int invCounter, int invLength, string jobPrefix, int jobCounter, int jobLength) {
			this.productionJobType_ID = productionJobType_ID;
			this.productionJobTypeName = productionJobTypeName;
			this.doPrefix = doPrefix;
			this.doCounter = doCounter;
			this.doLength = doLength;
			this.invPrefix = invPrefix;
			this.invCounter = invCounter;
			this.invLength = invLength;
			this.jobPrefix = jobPrefix;
			this.jobCounter = jobCounter;
			this.jobLength = jobLength;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProductionJobType_ID value.
		/// </summary>
		public string ProductionJobType_ID {
			get { return productionJobType_ID; }
			set { productionJobType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJobTypeName value.
		/// </summary>
		public string ProductionJobTypeName {
			get { return productionJobTypeName; }
			set { productionJobTypeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DoPrefix value.
		/// </summary>
		public string DoPrefix {
			get { return doPrefix; }
			set { doPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the DoCounter value.
		/// </summary>
		public int DoCounter {
			get { return doCounter; }
			set { doCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the DoLength value.
		/// </summary>
		public int DoLength {
			get { return doLength; }
			set { doLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvPrefix value.
		/// </summary>
		public string InvPrefix {
			get { return invPrefix; }
			set { invPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvCounter value.
		/// </summary>
		public int InvCounter {
			get { return invCounter; }
			set { invCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvLength value.
		/// </summary>
		public int InvLength {
			get { return invLength; }
			set { invLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobPrefix value.
		/// </summary>
		public string JobPrefix {
			get { return jobPrefix; }
			set { jobPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobCounter value.
		/// </summary>
		public int JobCounter {
			get { return jobCounter; }
			set { jobCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobLength value.
		/// </summary>
		public int JobLength {
			get { return jobLength; }
			set { jobLength = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobProductionJobType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobProductionJobTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@productionJobTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@doPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@doCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@doLength", SqlDbType.Int,4);
			scom.Parameters.Add("@invPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@invLength", SqlDbType.Int,4);
			scom.Parameters.Add("@jobPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@jobCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@jobLength", SqlDbType.Int,4);
 
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
			scom.Parameters["@productionJobTypeName"].Value = productionJobTypeName;
			scom.Parameters["@doPrefix"].Value = doPrefix;
			scom.Parameters["@doCounter"].Value = doCounter;
			scom.Parameters["@doLength"].Value = doLength;
			scom.Parameters["@invPrefix"].Value = invPrefix;
			scom.Parameters["@invCounter"].Value = invCounter;
			scom.Parameters["@invLength"].Value = invLength;
			scom.Parameters["@jobPrefix"].Value = jobPrefix;
			scom.Parameters["@jobCounter"].Value = jobCounter;
			scom.Parameters["@jobLength"].Value = jobLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobProductionJobType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobProductionJobTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@productionJobTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@doPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@doCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@doLength", SqlDbType.Int,4);
			scom.Parameters.Add("@invPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@invLength", SqlDbType.Int,4);
			scom.Parameters.Add("@jobPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@jobCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@jobLength", SqlDbType.Int,4);
 
 
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
			scom.Parameters["@productionJobTypeName"].Value = productionJobTypeName;
			scom.Parameters["@doPrefix"].Value = doPrefix;
			scom.Parameters["@doCounter"].Value = doCounter;
			scom.Parameters["@doLength"].Value = doLength;
			scom.Parameters["@invPrefix"].Value = invPrefix;
			scom.Parameters["@invCounter"].Value = invCounter;
			scom.Parameters["@invLength"].Value = invLength;
			scom.Parameters["@jobPrefix"].Value = jobPrefix;
			scom.Parameters["@jobCounter"].Value = jobCounter;
			scom.Parameters["@jobLength"].Value = jobLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobProductionJobType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobProductionJobTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobProductionJobType table.
		/// </summary>
		public static tbl_zJobProductionJobType Select(string productionJobType_ID_Incoming){

			tbl_zJobProductionJobType tbl_zJobProductionJobTypeins = new tbl_zJobProductionJobType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobProductionJobTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobProductionJobTypeins = Maketbl_zJobProductionJobType(dataReader);
				} else {
					tbl_zJobProductionJobTypeins = null;
				}
			}
			scon.Close();
			return tbl_zJobProductionJobTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobProductionJobType table.
		/// </summary>
		public static List<tbl_zJobProductionJobType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobProductionJobTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobProductionJobType> tbl_zJobProductionJobTypeList = new List<tbl_zJobProductionJobType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobProductionJobType tbl_zJobProductionJobType = Maketbl_zJobProductionJobType(dataReader);
					tbl_zJobProductionJobTypeList.Add(tbl_zJobProductionJobType);
				}
			}
			scon.Close();
			return tbl_zJobProductionJobTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobProductionJobType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobProductionJobType Maketbl_zJobProductionJobType(SqlDataReader dataReader) {
			tbl_zJobProductionJobType tbl_zJobProductionJobType = new tbl_zJobProductionJobType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobProductionJobType.ProductionJobType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobProductionJobType.ProductionJobTypeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zJobProductionJobType.DoPrefix = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zJobProductionJobType.DoCounter = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zJobProductionJobType.DoLength = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zJobProductionJobType.InvPrefix = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zJobProductionJobType.InvCounter = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zJobProductionJobType.InvLength = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zJobProductionJobType.JobPrefix = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zJobProductionJobType.JobCounter = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_zJobProductionJobType.JobLength = dataReader.GetInt32(10);
			}

			return tbl_zJobProductionJobType;
		}
		/// <summary>
		/// This makes tbl_zJobProductionJobType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobProductionJobType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobProductionJobType  tbl_zJobProductionJobType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_productionJobType_ID = new DataColumn("productionJobType_ID" , typeof(string));
			DataColumn col_productionJobTypeName = new DataColumn("productionJobTypeName" , typeof(string));
			DataColumn col_doPrefix = new DataColumn("doPrefix" , typeof(string));
			DataColumn col_doCounter = new DataColumn("doCounter" , typeof(int));
			DataColumn col_doLength = new DataColumn("doLength" , typeof(int));
			DataColumn col_invPrefix = new DataColumn("invPrefix" , typeof(string));
			DataColumn col_invCounter = new DataColumn("invCounter" , typeof(int));
			DataColumn col_invLength = new DataColumn("invLength" , typeof(int));
			DataColumn col_jobPrefix = new DataColumn("jobPrefix" , typeof(string));
			DataColumn col_jobCounter = new DataColumn("jobCounter" , typeof(int));
			DataColumn col_jobLength = new DataColumn("jobLength" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_productionJobType_ID,col_productionJobTypeName,col_doPrefix,col_doCounter,col_doLength,col_invPrefix,col_invCounter,col_invLength,col_jobPrefix,col_jobCounter,col_jobLength,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobProductionJobType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobProductionJobType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobProductionJobType user) {
		DataRow drow = dt.NewRow();
		
			drow["productionJobType_ID"] = user.productionJobType_ID;
			drow["productionJobTypeName"] = user.productionJobTypeName;
			drow["doPrefix"] = user.doPrefix;
			drow["doCounter"] = user.doCounter;
			drow["doLength"] = user.doLength;
			drow["invPrefix"] = user.invPrefix;
			drow["invCounter"] = user.invCounter;
			drow["invLength"] = user.invLength;
			drow["jobPrefix"] = user.jobPrefix;
			drow["jobCounter"] = user.jobCounter;
			drow["jobLength"] = user.jobLength;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
