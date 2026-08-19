using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCompanyImage {
		#region Fields
		private string companyID;
		private byte[] mainLogo;
		private byte[] logoOnly;
		private byte[] textOnly;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyImage class.
		/// </summary>
		public tbl_genCompanyImage() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyImage class.
		/// </summary>
		public tbl_genCompanyImage(string companyID, byte[] mainLogo, byte[] logoOnly, byte[] textOnly) {
			this.companyID = companyID;
			this.mainLogo = mainLogo;
			this.logoOnly = logoOnly;
			this.textOnly = textOnly;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MainLogo value.
		/// </summary>
		public byte[] MainLogo {
			get { return mainLogo; }
			set { mainLogo = value; }
		}
		
		/// <summary>
		/// Gets or sets the LogoOnly value.
		/// </summary>
		public byte[] LogoOnly {
			get { return logoOnly; }
			set { logoOnly = value; }
		}
		
		/// <summary>
		/// Gets or sets the TextOnly value.
		/// </summary>
		public byte[] TextOnly {
			get { return textOnly; }
			set { textOnly = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCompanyImage table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyImageInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@mainLogo", SqlDbType.Image);
			scom.Parameters.Add("@logoOnly", SqlDbType.Image);
            scom.Parameters.Add("@textOnly", SqlDbType.Image);
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@mainLogo"].Value = mainLogo;
			scom.Parameters["@logoOnly"].Value = logoOnly;
			scom.Parameters["@textOnly"].Value = textOnly;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCompanyImage table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyImageUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@mainLogo", SqlDbType.Image);
			scom.Parameters.Add("@logoOnly", SqlDbType.Image);
            scom.Parameters.Add("@textOnly", SqlDbType.Image);
 
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@mainLogo"].Value = mainLogo;
			scom.Parameters["@logoOnly"].Value = logoOnly;
			scom.Parameters["@textOnly"].Value = textOnly;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCompanyImage table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyImageDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCompanyImage table.
		/// </summary>
		public static tbl_genCompanyImage Select(string companyID_Incoming){

			tbl_genCompanyImage tbl_genCompanyImageins = new tbl_genCompanyImage();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyImageSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCompanyImageins = Maketbl_genCompanyImage(dataReader);
				} else {
					tbl_genCompanyImageins = null;
				}
			}
			scon.Close();
			return tbl_genCompanyImageins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyImage table.
		/// </summary>
		public static List<tbl_genCompanyImage> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyImageSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCompanyImage> tbl_genCompanyImageList = new List<tbl_genCompanyImage>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyImage tbl_genCompanyImage = Maketbl_genCompanyImage(dataReader);
					tbl_genCompanyImageList.Add(tbl_genCompanyImage);
				}
			}
			scon.Close();
			return tbl_genCompanyImageList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCompanyImage class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCompanyImage Maketbl_genCompanyImage(SqlDataReader dataReader) {
			tbl_genCompanyImage tbl_genCompanyImage = new tbl_genCompanyImage();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCompanyImage.CompanyID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCompanyImage.MainLogo = (byte[]) dataReader[1];
			}
			if (dataReader.IsDBNull(2) == false) {
                tbl_genCompanyImage.LogoOnly = (byte[])dataReader[2];
			}
			if (dataReader.IsDBNull(3) == false) {
                tbl_genCompanyImage.TextOnly = (byte[])dataReader[3];
			}

			return tbl_genCompanyImage;
		}
		/// <summary>
		/// This makes tbl_genCompanyImage datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCompanyImage object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCompanyImage  tbl_genCompanyImage   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_mainLogo = new DataColumn("mainLogo" , typeof(byte[]));
			DataColumn col_logoOnly = new DataColumn("logoOnly" , typeof(byte[]));
			DataColumn col_textOnly = new DataColumn("textOnly" , typeof(byte[]));
		dt.Columns.AddRange(new DataColumn[] { col_companyID,col_mainLogo,col_logoOnly,col_textOnly,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCompanyImage datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCompanyImage object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCompanyImage user) {
		DataRow drow = dt.NewRow();
		
			drow["companyID"] = user.companyID;
			drow["mainLogo"] = user.mainLogo;
			drow["logoOnly"] = user.logoOnly;
			drow["textOnly"] = user.textOnly;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
