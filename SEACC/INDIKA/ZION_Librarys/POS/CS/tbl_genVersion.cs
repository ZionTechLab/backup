using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genVersion {
		#region Fields
		private int assembly_ID;
		private string assembly_Name;
		private string assembly_File;
		private string version;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genVersion class.
		/// </summary>
		public tbl_genVersion() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genVersion class.
		/// </summary>
		public tbl_genVersion(int assembly_ID, string assembly_Name, string assembly_File, string version) {
			this.assembly_ID = assembly_ID;
			this.assembly_Name = assembly_Name;
			this.assembly_File = assembly_File;
			this.version = version;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Assembly_ID value.
		/// </summary>
		public int Assembly_ID {
			get { return assembly_ID; }
			set { assembly_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Assembly_Name value.
		/// </summary>
		public string Assembly_Name {
			get { return assembly_Name; }
			set { assembly_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Assembly_File value.
		/// </summary>
		public string Assembly_File {
			get { return assembly_File; }
			set { assembly_File = value; }
		}
		
		/// <summary>
		/// Gets or sets the Version value.
		/// </summary>
		public string Version {
			get { return version; }
			set { version = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genVersion table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genVersionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@assembly_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@assembly_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@assembly_File", SqlDbType.VarChar,100);
			scom.Parameters.Add("@version", SqlDbType.VarChar,25);
 
			scom.Parameters["@assembly_ID"].Value = assembly_ID;
			scom.Parameters["@assembly_Name"].Value = assembly_Name;
			scom.Parameters["@assembly_File"].Value = assembly_File;
			scom.Parameters["@version"].Value = version;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genVersion table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genVersionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@assembly_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@assembly_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@assembly_File", SqlDbType.VarChar,100);
			scom.Parameters.Add("@version", SqlDbType.VarChar,25);
 
 
			scom.Parameters["@assembly_ID"].Value = assembly_ID;
			scom.Parameters["@assembly_Name"].Value = assembly_Name;
			scom.Parameters["@assembly_File"].Value = assembly_File;
			scom.Parameters["@version"].Value = version;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genVersion table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genVersionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@assembly_ID", SqlDbType.Int,4);
			scom.Parameters["@assembly_ID"].Value = assembly_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genVersion table.
		/// </summary>
		public static tbl_genVersion Select(int assembly_ID_Incoming){

			tbl_genVersion tbl_genVersionins = new tbl_genVersion();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genVersionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assembly_ID", SqlDbType.Int,4);
			scom.Parameters["@assembly_ID"].Value = assembly_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genVersionins = Maketbl_genVersion(dataReader);
				} else {
					tbl_genVersionins = null;
				}
			}
			scon.Close();
			return tbl_genVersionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genVersion table.
		/// </summary>
		public static List<tbl_genVersion> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genVersionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genVersion> tbl_genVersionList = new List<tbl_genVersion>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genVersion tbl_genVersion = Maketbl_genVersion(dataReader);
					tbl_genVersionList.Add(tbl_genVersion);
				}
			}
			scon.Close();
			return tbl_genVersionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genVersion class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genVersion Maketbl_genVersion(SqlDataReader dataReader) {
			tbl_genVersion tbl_genVersion = new tbl_genVersion();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genVersion.Assembly_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genVersion.Assembly_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genVersion.Assembly_File = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genVersion.Version = dataReader.GetString(3);
			}

			return tbl_genVersion;
		}
		/// <summary>
		/// This makes tbl_genVersion datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genVersion object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genVersion  tbl_genVersion   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_assembly_ID = new DataColumn("assembly_ID" , typeof(int));
			DataColumn col_assembly_Name = new DataColumn("assembly_Name" , typeof(string));
			DataColumn col_assembly_File = new DataColumn("assembly_File" , typeof(string));
			DataColumn col_version = new DataColumn("version" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_assembly_ID,col_assembly_Name,col_assembly_File,col_version,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genVersion datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genVersion object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genVersion user) {
		DataRow drow = dt.NewRow();
		
			drow["assembly_ID"] = user.assembly_ID;
			drow["assembly_Name"] = user.assembly_Name;
			drow["assembly_File"] = user.assembly_File;
			drow["version"] = user.version;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
