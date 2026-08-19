using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxJobCard_ProductionOperation {
		#region Fields
		private int line_No;
		private string prodJob_ID;
		private string operation_ID;
		private decimal smv_Per_Pc;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_ProductionOperation class.
		/// </summary>
		public tbl_prodTxJobCard_ProductionOperation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxJobCard_ProductionOperation class.
		/// </summary>
		public tbl_prodTxJobCard_ProductionOperation(int line_No, string prodJob_ID, string operation_ID, decimal smv_Per_Pc) {
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.operation_ID = operation_ID;
			this.smv_Per_Pc = smv_Per_Pc;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Operation_ID value.
		/// </summary>
		public string Operation_ID {
			get { return operation_ID; }
			set { operation_ID = value; }
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
		/// Saves a record to the tbl_prodTxJobCard_ProductionOperation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@operation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@smv_Per_Pc", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@operation_ID"].Value = operation_ID;
			scom.Parameters["@smv_Per_Pc"].Value = smv_Per_Pc;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxJobCard_ProductionOperation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@operation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@smv_Per_Pc", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@operation_ID"].Value = operation_ID;
			scom.Parameters["@smv_Per_Pc"].Value = smv_Per_Pc;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxJobCard_ProductionOperation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_ProductionOperation table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_ProductionOperation table by a foreign key.
		/// </summary>
		public static void DeleteAllByOperation_ID(string operation_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationDeleteAllByOperation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@operation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@operation_ID"].Value = operation_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxJobCard_ProductionOperation table.
		/// </summary>
		public static tbl_prodTxJobCard_ProductionOperation Select(int line_No_Incoming, string prodJob_ID_Incoming){

			tbl_prodTxJobCard_ProductionOperation tbl_prodTxJobCard_ProductionOperationins = new tbl_prodTxJobCard_ProductionOperation();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxJobCard_ProductionOperationins = Maketbl_prodTxJobCard_ProductionOperation(dataReader);
				} else {
					tbl_prodTxJobCard_ProductionOperationins = null;
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_ProductionOperationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_ProductionOperation table.
		/// </summary>
		public static List<tbl_prodTxJobCard_ProductionOperation> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxJobCard_ProductionOperation> tbl_prodTxJobCard_ProductionOperationList = new List<tbl_prodTxJobCard_ProductionOperation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_ProductionOperation tbl_prodTxJobCard_ProductionOperation = Maketbl_prodTxJobCard_ProductionOperation(dataReader);
					tbl_prodTxJobCard_ProductionOperationList.Add(tbl_prodTxJobCard_ProductionOperation);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_ProductionOperationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_ProductionOperation table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_ProductionOperation> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxJobCard_ProductionOperation> tbl_prodTxJobCard_ProductionOperationList = new List<tbl_prodTxJobCard_ProductionOperation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_ProductionOperation tbl_prodTxJobCard_ProductionOperation = Maketbl_prodTxJobCard_ProductionOperation(dataReader);
					tbl_prodTxJobCard_ProductionOperationList.Add(tbl_prodTxJobCard_ProductionOperation);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_ProductionOperationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxJobCard_ProductionOperation table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxJobCard_ProductionOperation> SelectAllByOperation_ID(string operation_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxJobCard_ProductionOperationSelectAllByOperation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@operation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@operation_ID"].Value = operation_ID;
				List<tbl_prodTxJobCard_ProductionOperation> tbl_prodTxJobCard_ProductionOperationList = new List<tbl_prodTxJobCard_ProductionOperation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxJobCard_ProductionOperation tbl_prodTxJobCard_ProductionOperation = Maketbl_prodTxJobCard_ProductionOperation(dataReader);
					tbl_prodTxJobCard_ProductionOperationList.Add(tbl_prodTxJobCard_ProductionOperation);
				}
			}
			scon.Close();
			return tbl_prodTxJobCard_ProductionOperationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxJobCard_ProductionOperation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxJobCard_ProductionOperation Maketbl_prodTxJobCard_ProductionOperation(SqlDataReader dataReader) {
			tbl_prodTxJobCard_ProductionOperation tbl_prodTxJobCard_ProductionOperation = new tbl_prodTxJobCard_ProductionOperation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxJobCard_ProductionOperation.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxJobCard_ProductionOperation.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxJobCard_ProductionOperation.Operation_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxJobCard_ProductionOperation.Smv_Per_Pc = dataReader.GetDecimal(3);
			}

			return tbl_prodTxJobCard_ProductionOperation;
		}
		/// <summary>
		/// This makes tbl_prodTxJobCard_ProductionOperation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_ProductionOperation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxJobCard_ProductionOperation  tbl_prodTxJobCard_ProductionOperation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_operation_ID = new DataColumn("operation_ID" , typeof(string));
			DataColumn col_smv_Per_Pc = new DataColumn("smv_Per_Pc" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_prodJob_ID,col_operation_ID,col_smv_Per_Pc,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxJobCard_ProductionOperation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxJobCard_ProductionOperation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxJobCard_ProductionOperation user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["operation_ID"] = user.operation_ID;
			drow["smv_Per_Pc"] = user.smv_Per_Pc;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
