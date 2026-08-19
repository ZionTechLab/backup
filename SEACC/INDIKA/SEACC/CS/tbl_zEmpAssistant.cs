using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zEmpAssistant {
		#region Fields
		private string assistant_ID;
		private string assistantName;
		private string operator_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zEmpAssistant class.
		/// </summary>
		public tbl_zEmpAssistant() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zEmpAssistant class.
		/// </summary>
		public tbl_zEmpAssistant(string assistant_ID, string assistantName, string operator_ID) {
			this.assistant_ID = assistant_ID;
			this.assistantName = assistantName;
			this.operator_ID = operator_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Assistant_ID value.
		/// </summary>
		public string Assistant_ID {
			get { return assistant_ID; }
			set { assistant_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AssistantName value.
		/// </summary>
		public string AssistantName {
			get { return assistantName; }
			set { assistantName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Operator_ID value.
		/// </summary>
		public string Operator_ID {
			get { return operator_ID; }
			set { operator_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zEmpAssistant table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpAssistantInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@assistant_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@assistantName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@assistant_ID"].Value = assistant_ID;
			scom.Parameters["@assistantName"].Value = assistantName;
			scom.Parameters["@operator_ID"].Value = operator_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zEmpAssistant table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpAssistantUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@assistant_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@assistantName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@assistant_ID"].Value = assistant_ID;
			scom.Parameters["@assistantName"].Value = assistantName;
			scom.Parameters["@operator_ID"].Value = operator_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zEmpAssistant table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpAssistantDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@assistant_ID", SqlDbType.VarChar,20);
			scom.Parameters["@assistant_ID"].Value = assistant_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpAssistant table by a foreign key.
		/// </summary>
		public static void DeleteAllByOperator_ID(string operator_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpAssistantDeleteAllByOperator_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
			scom.Parameters["@operator_ID"].Value = operator_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zEmpAssistant table.
		/// </summary>
		public static tbl_zEmpAssistant Select(string assistant_ID_Incoming){

			tbl_zEmpAssistant tbl_zEmpAssistantins = new tbl_zEmpAssistant();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpAssistantSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assistant_ID", SqlDbType.VarChar,20);
			scom.Parameters["@assistant_ID"].Value = assistant_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zEmpAssistantins = Maketbl_zEmpAssistant(dataReader);
				} else {
					tbl_zEmpAssistantins = null;
				}
			}
			scon.Close();
			return tbl_zEmpAssistantins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpAssistant table.
		/// </summary>
		public static List<tbl_zEmpAssistant> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpAssistantSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zEmpAssistant> tbl_zEmpAssistantList = new List<tbl_zEmpAssistant>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zEmpAssistant tbl_zEmpAssistant = Maketbl_zEmpAssistant(dataReader);
					tbl_zEmpAssistantList.Add(tbl_zEmpAssistant);
				}
			}
			scon.Close();
			return tbl_zEmpAssistantList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpAssistant table by a foreign key.
		/// </summary>
		public static List<tbl_zEmpAssistant> SelectAllByOperator_ID(string operator_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpAssistantSelectAllByOperator_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
			scom.Parameters["@operator_ID"].Value = operator_ID;
				List<tbl_zEmpAssistant> tbl_zEmpAssistantList = new List<tbl_zEmpAssistant>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zEmpAssistant tbl_zEmpAssistant = Maketbl_zEmpAssistant(dataReader);
					tbl_zEmpAssistantList.Add(tbl_zEmpAssistant);
				}
			}
			scon.Close();
			return tbl_zEmpAssistantList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zEmpAssistant class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zEmpAssistant Maketbl_zEmpAssistant(SqlDataReader dataReader) {
			tbl_zEmpAssistant tbl_zEmpAssistant = new tbl_zEmpAssistant();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zEmpAssistant.Assistant_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zEmpAssistant.AssistantName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zEmpAssistant.Operator_ID = dataReader.GetString(2);
			}

			return tbl_zEmpAssistant;
		}
		/// <summary>
		/// This makes tbl_zEmpAssistant datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zEmpAssistant object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zEmpAssistant  tbl_zEmpAssistant   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_assistant_ID = new DataColumn("assistant_ID" , typeof(string));
			DataColumn col_assistantName = new DataColumn("assistantName" , typeof(string));
			DataColumn col_operator_ID = new DataColumn("operator_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_assistant_ID,col_assistantName,col_operator_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zEmpAssistant datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zEmpAssistant object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zEmpAssistant user) {
		DataRow drow = dt.NewRow();
		
			drow["assistant_ID"] = user.assistant_ID;
			drow["assistantName"] = user.assistantName;
			drow["operator_ID"] = user.operator_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
