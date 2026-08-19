using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securtiyConfigActive {
		#region Fields
		private int valueID;
		private string valueName;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securtiyConfigActive class.
		/// </summary>
		public tbl_securtiyConfigActive() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securtiyConfigActive class.
		/// </summary>
		public tbl_securtiyConfigActive(int valueID, string valueName, bool isActive) {
			this.valueID = valueID;
			this.valueName = valueName;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ValueID value.
		/// </summary>
		public int ValueID {
			get { return valueID; }
			set { valueID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ValueName value.
		/// </summary>
		public string ValueName {
			get { return valueName; }
			set { valueName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securtiyConfigActive table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securtiyConfigActiveInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters.Add("@valueName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@valueID"].Value = valueID;
			scom.Parameters["@valueName"].Value = valueName;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securtiyConfigActive table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securtiyConfigActiveUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters.Add("@valueName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@valueID"].Value = valueID;
			scom.Parameters["@valueName"].Value = valueName;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securtiyConfigActive table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securtiyConfigActiveDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters["@valueID"].Value = valueID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securtiyConfigActive table.
		/// </summary>
		public static tbl_securtiyConfigActive Select(int valueID_Incoming){

			tbl_securtiyConfigActive tbl_securtiyConfigActiveins = new tbl_securtiyConfigActive();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securtiyConfigActiveSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters["@valueID"].Value = valueID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securtiyConfigActiveins = Maketbl_securtiyConfigActive(dataReader);
				} else {
					tbl_securtiyConfigActiveins = null;
				}
			}
			scon.Close();
			return tbl_securtiyConfigActiveins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securtiyConfigActive table.
		/// </summary>
		public static List<tbl_securtiyConfigActive> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securtiyConfigActiveSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securtiyConfigActive> tbl_securtiyConfigActiveList = new List<tbl_securtiyConfigActive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securtiyConfigActive tbl_securtiyConfigActive = Maketbl_securtiyConfigActive(dataReader);
					tbl_securtiyConfigActiveList.Add(tbl_securtiyConfigActive);
				}
			}
			scon.Close();
			return tbl_securtiyConfigActiveList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securtiyConfigActive class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securtiyConfigActive Maketbl_securtiyConfigActive(SqlDataReader dataReader) {
			tbl_securtiyConfigActive tbl_securtiyConfigActive = new tbl_securtiyConfigActive();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securtiyConfigActive.ValueID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securtiyConfigActive.ValueName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securtiyConfigActive.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_securtiyConfigActive;
		}
		/// <summary>
		/// This makes tbl_securtiyConfigActive datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securtiyConfigActive object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securtiyConfigActive  tbl_securtiyConfigActive   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_valueID = new DataColumn("valueID" , typeof(int));
			DataColumn col_valueName = new DataColumn("valueName" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_valueID,col_valueName,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securtiyConfigActive datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securtiyConfigActive object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securtiyConfigActive user) {
		DataRow drow = dt.NewRow();
		
			drow["valueID"] = user.valueID;
			drow["valueName"] = user.valueName;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
