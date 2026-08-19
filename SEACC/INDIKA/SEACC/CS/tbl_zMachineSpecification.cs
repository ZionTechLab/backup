using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zMachineSpecification {
		#region Fields
		private string machineSepcification_ID;
		private string machineCategory_ID;
		private string sepcificationName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineSpecification class.
		/// </summary>
		public tbl_zMachineSpecification() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineSpecification class.
		/// </summary>
		public tbl_zMachineSpecification(string machineSepcification_ID, string machineCategory_ID, string sepcificationName) {
			this.machineSepcification_ID = machineSepcification_ID;
			this.machineCategory_ID = machineCategory_ID;
			this.sepcificationName = sepcificationName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MachineSepcification_ID value.
		/// </summary>
		public string MachineSepcification_ID {
			get { return machineSepcification_ID; }
			set { machineSepcification_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineCategory_ID value.
		/// </summary>
		public string MachineCategory_ID {
			get { return machineCategory_ID; }
			set { machineCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SepcificationName value.
		/// </summary>
		public string SepcificationName {
			get { return sepcificationName; }
			set { sepcificationName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zMachineSpecification table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineSpecificationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sepcificationName", SqlDbType.VarChar,50);
 
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@sepcificationName"].Value = sepcificationName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zMachineSpecification table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineSpecificationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sepcificationName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@sepcificationName"].Value = sepcificationName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zMachineSpecification table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineSpecificationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineSpecification table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachineCategory_ID(string machineCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineSpecificationDeleteAllByMachineCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zMachineSpecification table.
		/// </summary>
		public static tbl_zMachineSpecification Select(string machineSepcification_ID_Incoming){

			tbl_zMachineSpecification tbl_zMachineSpecificationins = new tbl_zMachineSpecification();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineSpecificationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zMachineSpecificationins = Maketbl_zMachineSpecification(dataReader);
				} else {
					tbl_zMachineSpecificationins = null;
				}
			}
			scon.Close();
			return tbl_zMachineSpecificationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineSpecification table.
		/// </summary>
		public static List<tbl_zMachineSpecification> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineSpecificationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zMachineSpecification> tbl_zMachineSpecificationList = new List<tbl_zMachineSpecification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineSpecification tbl_zMachineSpecification = Maketbl_zMachineSpecification(dataReader);
					tbl_zMachineSpecificationList.Add(tbl_zMachineSpecification);
				}
			}
			scon.Close();
			return tbl_zMachineSpecificationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineSpecification table by a foreign key.
		/// </summary>
		public static List<tbl_zMachineSpecification> SelectAllByMachineCategory_ID(string machineCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineSpecificationSelectAllByMachineCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
				List<tbl_zMachineSpecification> tbl_zMachineSpecificationList = new List<tbl_zMachineSpecification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineSpecification tbl_zMachineSpecification = Maketbl_zMachineSpecification(dataReader);
					tbl_zMachineSpecificationList.Add(tbl_zMachineSpecification);
				}
			}
			scon.Close();
			return tbl_zMachineSpecificationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zMachineSpecification class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zMachineSpecification Maketbl_zMachineSpecification(SqlDataReader dataReader) {
			tbl_zMachineSpecification tbl_zMachineSpecification = new tbl_zMachineSpecification();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zMachineSpecification.MachineSepcification_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zMachineSpecification.MachineCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zMachineSpecification.SepcificationName = dataReader.GetString(2);
			}

			return tbl_zMachineSpecification;
		}
		/// <summary>
		/// This makes tbl_zMachineSpecification datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zMachineSpecification object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zMachineSpecification  tbl_zMachineSpecification   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_machineSepcification_ID = new DataColumn("machineSepcification_ID" , typeof(string));
			DataColumn col_machineCategory_ID = new DataColumn("machineCategory_ID" , typeof(string));
			DataColumn col_sepcificationName = new DataColumn("sepcificationName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_machineSepcification_ID,col_machineCategory_ID,col_sepcificationName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zMachineSpecification datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zMachineSpecification object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zMachineSpecification user) {
		DataRow drow = dt.NewRow();
		
			drow["machineSepcification_ID"] = user.machineSepcification_ID;
			drow["machineCategory_ID"] = user.machineCategory_ID;
			drow["sepcificationName"] = user.sepcificationName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
