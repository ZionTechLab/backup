using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderSponsor {
		#region Fields
		private string sponsor_ID;
		private string sponsor_Name;
		private string sponsor_Email;
		private int sponsor_Mobile;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderSponsor class.
		/// </summary>
		public tbl_ttsTenderSponsor() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderSponsor class.
		/// </summary>
		public tbl_ttsTenderSponsor(string sponsor_ID, string sponsor_Name, string sponsor_Email, int sponsor_Mobile, bool isCanceled) {
			this.sponsor_ID = sponsor_ID;
			this.sponsor_Name = sponsor_Name;
			this.sponsor_Email = sponsor_Email;
			this.sponsor_Mobile = sponsor_Mobile;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Sponsor_ID value.
		/// </summary>
		public string Sponsor_ID {
			get { return sponsor_ID; }
			set { sponsor_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Sponsor_Name value.
		/// </summary>
		public string Sponsor_Name {
			get { return sponsor_Name; }
			set { sponsor_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Sponsor_Email value.
		/// </summary>
		public string Sponsor_Email {
			get { return sponsor_Email; }
			set { sponsor_Email = value; }
		}
		
		/// <summary>
		/// Gets or sets the Sponsor_Mobile value.
		/// </summary>
		public int Sponsor_Mobile {
			get { return sponsor_Mobile; }
			set { sponsor_Mobile = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderSponsor table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSponsorInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sponsor_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sponsor_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@sponsor_Email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sponsor_Mobile", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@sponsor_ID"].Value = sponsor_ID;
			scom.Parameters["@sponsor_Name"].Value = sponsor_Name;
			scom.Parameters["@sponsor_Email"].Value = sponsor_Email;
			scom.Parameters["@sponsor_Mobile"].Value = sponsor_Mobile;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderSponsor table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSponsorUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sponsor_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sponsor_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@sponsor_Email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sponsor_Mobile", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@sponsor_ID"].Value = sponsor_ID;
			scom.Parameters["@sponsor_Name"].Value = sponsor_Name;
			scom.Parameters["@sponsor_Email"].Value = sponsor_Email;
			scom.Parameters["@sponsor_Mobile"].Value = sponsor_Mobile;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderSponsor table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSponsorDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sponsor_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sponsor_ID"].Value = sponsor_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderSponsor table.
		/// </summary>
		public static tbl_ttsTenderSponsor Select(string sponsor_ID_Incoming){

			tbl_ttsTenderSponsor tbl_ttsTenderSponsorins = new tbl_ttsTenderSponsor();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSponsorSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sponsor_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sponsor_ID"].Value = sponsor_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderSponsorins = Maketbl_ttsTenderSponsor(dataReader);
				} else {
					tbl_ttsTenderSponsorins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderSponsorins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderSponsor table.
		/// </summary>
		public static List<tbl_ttsTenderSponsor> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderSponsorSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderSponsor> tbl_ttsTenderSponsorList = new List<tbl_ttsTenderSponsor>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderSponsor tbl_ttsTenderSponsor = Maketbl_ttsTenderSponsor(dataReader);
					tbl_ttsTenderSponsorList.Add(tbl_ttsTenderSponsor);
				}
			}
			scon.Close();
			return tbl_ttsTenderSponsorList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderSponsor class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderSponsor Maketbl_ttsTenderSponsor(SqlDataReader dataReader) {
			tbl_ttsTenderSponsor tbl_ttsTenderSponsor = new tbl_ttsTenderSponsor();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderSponsor.Sponsor_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderSponsor.Sponsor_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderSponsor.Sponsor_Email = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsTenderSponsor.Sponsor_Mobile = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsTenderSponsor.IsCanceled = dataReader.GetBoolean(4);
			}

			return tbl_ttsTenderSponsor;
		}
		/// <summary>
		/// This makes tbl_ttsTenderSponsor datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderSponsor object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderSponsor  tbl_ttsTenderSponsor   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_sponsor_ID = new DataColumn("sponsor_ID" , typeof(string));
			DataColumn col_sponsor_Name = new DataColumn("sponsor_Name" , typeof(string));
			DataColumn col_sponsor_Email = new DataColumn("sponsor_Email" , typeof(string));
			DataColumn col_sponsor_Mobile = new DataColumn("sponsor_Mobile" , typeof(int));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_sponsor_ID,col_sponsor_Name,col_sponsor_Email,col_sponsor_Mobile,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderSponsor datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderSponsor object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderSponsor user) {
		DataRow drow = dt.NewRow();
		
			drow["sponsor_ID"] = user.sponsor_ID;
			drow["sponsor_Name"] = user.sponsor_Name;
			drow["sponsor_Email"] = user.sponsor_Email;
			drow["sponsor_Mobile"] = user.sponsor_Mobile;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
