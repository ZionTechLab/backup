using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAssistant {
		#region Fields
		private string assistant_ID;
		private string assistantName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAssistant class.
		/// </summary>
		public tbl_zAssistant() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAssistant class.
		/// </summary>
		public tbl_zAssistant(string assistant_ID, string assistantName) {
			this.assistant_ID = assistant_ID;
			this.assistantName = assistantName;
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAssistant table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAssistantInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@assistant_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@assistantName", SqlDbType.VarChar,50);
 
			scom.Parameters["@assistant_ID"].Value = assistant_ID;
			scom.Parameters["@assistantName"].Value = assistantName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAssistant table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAssistantUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@assistant_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@assistantName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@assistant_ID"].Value = assistant_ID;
			scom.Parameters["@assistantName"].Value = assistantName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAssistant table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAssistantDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@assistant_ID", SqlDbType.VarChar,10);
			scom.Parameters["@assistant_ID"].Value = assistant_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAssistant table.
		/// </summary>
		public static tbl_zAssistant Select(string assistant_ID_Incoming){

			tbl_zAssistant tbl_zAssistantins = new tbl_zAssistant();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAssistantSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assistant_ID", SqlDbType.VarChar,10);
			scom.Parameters["@assistant_ID"].Value = assistant_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAssistantins = Maketbl_zAssistant(dataReader);
				} else {
					tbl_zAssistantins = null;
				}
			}
			scon.Close();
			return tbl_zAssistantins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAssistant table.
		/// </summary>
		public static List<tbl_zAssistant> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAssistantSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAssistant> tbl_zAssistantList = new List<tbl_zAssistant>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAssistant tbl_zAssistant = Maketbl_zAssistant(dataReader);
					tbl_zAssistantList.Add(tbl_zAssistant);
				}
			}
			scon.Close();
			return tbl_zAssistantList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAssistant class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAssistant Maketbl_zAssistant(SqlDataReader dataReader) {
			tbl_zAssistant tbl_zAssistant = new tbl_zAssistant();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAssistant.Assistant_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAssistant.AssistantName = dataReader.GetString(1);
			}

			return tbl_zAssistant;
		}
		/// <summary>
		/// This fills tbl_zAssistant datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAssistant object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAssistant user) {
		DataRow drow = dt.NewRow();
		
			drow["assistant_ID"] = user.assistant_ID;
			drow["assistantName"] = user.assistantName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
