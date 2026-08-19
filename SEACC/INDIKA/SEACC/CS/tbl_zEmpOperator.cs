using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zEmpOperator {
		#region Fields
		private string operator_ID;
		private string operatorName;
		private string supervisor_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zEmpOperator class.
		/// </summary>
		public tbl_zEmpOperator() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zEmpOperator class.
		/// </summary>
		public tbl_zEmpOperator(string operator_ID, string operatorName, string supervisor_ID) {
			this.operator_ID = operator_ID;
			this.operatorName = operatorName;
			this.supervisor_ID = supervisor_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Operator_ID value.
		/// </summary>
		public string Operator_ID {
			get { return operator_ID; }
			set { operator_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OperatorName value.
		/// </summary>
		public string OperatorName {
			get { return operatorName; }
			set { operatorName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supervisor_ID value.
		/// </summary>
		public string Supervisor_ID {
			get { return supervisor_ID; }
			set { supervisor_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zEmpOperator table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpOperatorInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@operatorName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@operator_ID"].Value = operator_ID;
			scom.Parameters["@operatorName"].Value = operatorName;
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zEmpOperator table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpOperatorUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@operatorName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@operator_ID"].Value = operator_ID;
			scom.Parameters["@operatorName"].Value = operatorName;
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zEmpOperator table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpOperatorDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
			scom.Parameters["@operator_ID"].Value = operator_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpOperator table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupervisor_ID(string supervisor_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpOperatorDeleteAllBySupervisor_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zEmpOperator table.
		/// </summary>
		public static tbl_zEmpOperator Select(string operator_ID_Incoming){

			tbl_zEmpOperator tbl_zEmpOperatorins = new tbl_zEmpOperator();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpOperatorSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
			scom.Parameters["@operator_ID"].Value = operator_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zEmpOperatorins = Maketbl_zEmpOperator(dataReader);
				} else {
					tbl_zEmpOperatorins = null;
				}
			}
			scon.Close();
			return tbl_zEmpOperatorins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpOperator table.
		/// </summary>
		public static List<tbl_zEmpOperator> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpOperatorSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zEmpOperator> tbl_zEmpOperatorList = new List<tbl_zEmpOperator>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zEmpOperator tbl_zEmpOperator = Maketbl_zEmpOperator(dataReader);
					tbl_zEmpOperatorList.Add(tbl_zEmpOperator);
				}
			}
			scon.Close();
			return tbl_zEmpOperatorList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpOperator table by a foreign key.
		/// </summary>
		public static List<tbl_zEmpOperator> SelectAllBySupervisor_ID(string supervisor_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpOperatorSelectAllBySupervisor_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
				List<tbl_zEmpOperator> tbl_zEmpOperatorList = new List<tbl_zEmpOperator>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zEmpOperator tbl_zEmpOperator = Maketbl_zEmpOperator(dataReader);
					tbl_zEmpOperatorList.Add(tbl_zEmpOperator);
				}
			}
			scon.Close();
			return tbl_zEmpOperatorList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zEmpOperator class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zEmpOperator Maketbl_zEmpOperator(SqlDataReader dataReader) {
			tbl_zEmpOperator tbl_zEmpOperator = new tbl_zEmpOperator();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zEmpOperator.Operator_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zEmpOperator.OperatorName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zEmpOperator.Supervisor_ID = dataReader.GetString(2);
			}

			return tbl_zEmpOperator;
		}
		/// <summary>
		/// This makes tbl_zEmpOperator datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zEmpOperator object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zEmpOperator  tbl_zEmpOperator   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_operator_ID = new DataColumn("operator_ID" , typeof(string));
			DataColumn col_operatorName = new DataColumn("operatorName" , typeof(string));
			DataColumn col_supervisor_ID = new DataColumn("supervisor_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_operator_ID,col_operatorName,col_supervisor_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zEmpOperator datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zEmpOperator object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zEmpOperator user) {
		DataRow drow = dt.NewRow();
		
			drow["operator_ID"] = user.operator_ID;
			drow["operatorName"] = user.operatorName;
			drow["supervisor_ID"] = user.supervisor_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
