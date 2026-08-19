using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityProject {
		#region Fields
		private string projectID;
		private string projectName;
		private byte[] image;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityProject class.
		/// </summary>
		public tbl_securityProject() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityProject class.
		/// </summary>
		public tbl_securityProject(string projectID, string projectName, byte[] image) {
			this.projectID = projectID;
			this.projectName = projectName;
			this.image = image;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProjectID value.
		/// </summary>
		public string ProjectID {
			get { return projectID; }
			set { projectID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProjectName value.
		/// </summary>
		public string ProjectName {
			get { return projectName; }
			set { projectName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityProject table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProjectInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@projectID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@projectName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
 
			scom.Parameters["@projectID"].Value = projectID;
			scom.Parameters["@projectName"].Value = projectName;
			scom.Parameters["@image"].Value = image;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityProject table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProjectUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@projectID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@projectName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
 
 
			scom.Parameters["@projectID"].Value = projectID;
			scom.Parameters["@projectName"].Value = projectName;
			scom.Parameters["@image"].Value = image;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityProject table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProjectDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@projectID", SqlDbType.VarChar,20);
			scom.Parameters["@projectID"].Value = projectID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityProject table.
		/// </summary>
		public static tbl_securityProject Select(string projectID_Incoming){

			tbl_securityProject tbl_securityProjectins = new tbl_securityProject();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProjectSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@projectID", SqlDbType.VarChar,20);
			scom.Parameters["@projectID"].Value = projectID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityProjectins = Maketbl_securityProject(dataReader);
				} else {
					tbl_securityProjectins = null;
				}
			}
			scon.Close();
			return tbl_securityProjectins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityProject table.
		/// </summary>
		public static List<tbl_securityProject> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityProjectSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityProject> tbl_securityProjectList = new List<tbl_securityProject>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityProject tbl_securityProject = Maketbl_securityProject(dataReader);
					tbl_securityProjectList.Add(tbl_securityProject);
				}
			}
			scon.Close();
			return tbl_securityProjectList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityProject class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityProject Maketbl_securityProject(SqlDataReader dataReader) {
			tbl_securityProject tbl_securityProject = new tbl_securityProject();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityProject.ProjectID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityProject.ProjectName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityProject.Image = (byte[]) dataReader[2];
			}

			return tbl_securityProject;
		}
		/// <summary>
		/// This makes tbl_securityProject datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityProject object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityProject  tbl_securityProject   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_projectID = new DataColumn("projectID" , typeof(string));
			DataColumn col_projectName = new DataColumn("projectName" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
		dt.Columns.AddRange(new DataColumn[] { col_projectID,col_projectName,col_image,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityProject datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityProject object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityProject user) {
		DataRow drow = dt.NewRow();
		
			drow["projectID"] = user.projectID;
			drow["projectName"] = user.projectName;
			drow["image"] = user.image;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
