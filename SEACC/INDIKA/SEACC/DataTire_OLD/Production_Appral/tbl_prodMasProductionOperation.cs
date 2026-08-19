using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodMasProductionOperation {
		#region Fields
		private string operation_ID;
		private string description;
		private string remark;
		private decimal smv_Per_Pc;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodMasProductionOperation class.
		/// </summary>
		public tbl_prodMasProductionOperation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodMasProductionOperation class.
		/// </summary>
		public tbl_prodMasProductionOperation(string operation_ID, string description, string remark, decimal smv_Per_Pc) {
			this.operation_ID = operation_ID;
			this.description = description;
			this.remark = remark;
			this.smv_Per_Pc = smv_Per_Pc;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Operation_ID value.
		/// </summary>
		public string Operation_ID {
			get { return operation_ID; }
			set { operation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Smv_Per_Pc value.
		/// </summary>
		public decimal Smv_Per_Pc {
			get { return smv_Per_Pc; }
			set { smv_Per_Pc = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodMasProductionOperation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasProductionOperationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@operation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,2000);
			scom.Parameters.Add("@smv_Per_Pc", SqlDbType.Decimal,9);
 
			scom.Parameters["@operation_ID"].Value = operation_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@smv_Per_Pc"].Value = smv_Per_Pc;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodMasProductionOperation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasProductionOperationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@operation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,2000);
			scom.Parameters.Add("@smv_Per_Pc", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@operation_ID"].Value = operation_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@smv_Per_Pc"].Value = smv_Per_Pc;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodMasProductionOperation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasProductionOperationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@operation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@operation_ID"].Value = operation_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodMasProductionOperation table.
		/// </summary>
		public static tbl_prodMasProductionOperation Select(string operation_ID_Incoming){

			tbl_prodMasProductionOperation tbl_prodMasProductionOperationins = new tbl_prodMasProductionOperation();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasProductionOperationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@operation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@operation_ID"].Value = operation_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodMasProductionOperationins = Maketbl_prodMasProductionOperation(dataReader);
				} else {
					tbl_prodMasProductionOperationins = null;
				}
			}
			scon.Close();
			return tbl_prodMasProductionOperationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodMasProductionOperation table.
		/// </summary>
		public static List<tbl_prodMasProductionOperation> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasProductionOperationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodMasProductionOperation> tbl_prodMasProductionOperationList = new List<tbl_prodMasProductionOperation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodMasProductionOperation tbl_prodMasProductionOperation = Maketbl_prodMasProductionOperation(dataReader);
					tbl_prodMasProductionOperationList.Add(tbl_prodMasProductionOperation);
				}
			}
			scon.Close();
			return tbl_prodMasProductionOperationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodMasProductionOperation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodMasProductionOperation Maketbl_prodMasProductionOperation(SqlDataReader dataReader) {
			tbl_prodMasProductionOperation tbl_prodMasProductionOperation = new tbl_prodMasProductionOperation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodMasProductionOperation.Operation_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodMasProductionOperation.Description = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodMasProductionOperation.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodMasProductionOperation.Smv_Per_Pc = dataReader.GetDecimal(3);
			}

			return tbl_prodMasProductionOperation;
		}
		/// <summary>
		/// This makes tbl_prodMasProductionOperation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodMasProductionOperation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodMasProductionOperation  tbl_prodMasProductionOperation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_operation_ID = new DataColumn("operation_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_smv_Per_Pc = new DataColumn("smv_Per_Pc" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_operation_ID,col_description,col_remark,col_smv_Per_Pc,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodMasProductionOperation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodMasProductionOperation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodMasProductionOperation user) {
		DataRow drow = dt.NewRow();
		
			drow["operation_ID"] = user.operation_ID;
			drow["description"] = user.description;
			drow["remark"] = user.remark;
			drow["smv_Per_Pc"] = user.smv_Per_Pc;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
