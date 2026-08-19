using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_Mast_HoliDay_Type {
		#region Fields
		private int iD;
		private string holyday_type_Code;
		private string holyday_type_title;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_Mast_HoliDay_Type class.
		/// </summary>
		public tbl_Mast_HoliDay_Type() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_Mast_HoliDay_Type class.
		/// </summary>
		public tbl_Mast_HoliDay_Type(string holyday_type_Code, string holyday_type_title) {
			this.holyday_type_Code = holyday_type_Code;
			this.holyday_type_title = holyday_type_title;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_Mast_HoliDay_Type class.
		/// </summary>
		public tbl_Mast_HoliDay_Type(int iD, string holyday_type_Code, string holyday_type_title) {
			this.iD = iD;
			this.holyday_type_Code = holyday_type_Code;
			this.holyday_type_title = holyday_type_title;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ID value.
		/// </summary>
		public int ID {
			get { return iD; }
			set { iD = value; }
		}
		
		/// <summary>
		/// Gets or sets the Holyday_type_Code value.
		/// </summary>
		public string Holyday_type_Code {
			get { return holyday_type_Code; }
			set { holyday_type_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Holyday_type_title value.
		/// </summary>
		public string Holyday_type_title {
			get { return holyday_type_title; }
			set { holyday_type_title = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_Mast_HoliDay_Type table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Mast_HoliDay_TypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@holyday_type_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@holyday_type_title", SqlDbType.VarChar,500);
 
			scom.Parameters["@holyday_type_Code"].Value = holyday_type_Code;
			scom.Parameters["@holyday_type_title"].Value = holyday_type_title;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_Mast_HoliDay_Type table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Mast_HoliDay_TypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@holyday_type_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@holyday_type_title", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@holyday_type_Code"].Value = holyday_type_Code;
			scom.Parameters["@holyday_type_title"].Value = holyday_type_title;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_Mast_HoliDay_Type table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Mast_HoliDay_TypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@holyday_type_Code", SqlDbType.VarChar, 20);
            scom.Parameters["@holyday_type_Code"].Value = holyday_type_Code;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_Mast_HoliDay_Type table.
		/// </summary>
		public static tbl_Mast_HoliDay_Type Select(string iD_Incoming){

			tbl_Mast_HoliDay_Type tbl_Mast_HoliDay_Typeins = new tbl_Mast_HoliDay_Type();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Mast_HoliDay_TypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@holyday_type_Code", SqlDbType.VarChar, 20);
            scom.Parameters["@holyday_type_Code"].Value = iD_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_Mast_HoliDay_Typeins = Maketbl_Mast_HoliDay_Type(dataReader);
				} else {
					tbl_Mast_HoliDay_Typeins = null;
				}
			}
			scon.Close();
			return tbl_Mast_HoliDay_Typeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_Mast_HoliDay_Type table.
		/// </summary>
		public static List<tbl_Mast_HoliDay_Type> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_Mast_HoliDay_TypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_Mast_HoliDay_Type> tbl_Mast_HoliDay_TypeList = new List<tbl_Mast_HoliDay_Type>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_Mast_HoliDay_Type tbl_Mast_HoliDay_Type = Maketbl_Mast_HoliDay_Type(dataReader);
					tbl_Mast_HoliDay_TypeList.Add(tbl_Mast_HoliDay_Type);
				}
			}
			scon.Close();
			return tbl_Mast_HoliDay_TypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_Mast_HoliDay_Type class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_Mast_HoliDay_Type Maketbl_Mast_HoliDay_Type(SqlDataReader dataReader) {
			tbl_Mast_HoliDay_Type tbl_Mast_HoliDay_Type = new tbl_Mast_HoliDay_Type();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_Mast_HoliDay_Type.ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_Mast_HoliDay_Type.Holyday_type_Code = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_Mast_HoliDay_Type.Holyday_type_title = dataReader.GetString(2);
			}

			return tbl_Mast_HoliDay_Type;
		}
		/// <summary>
		/// This makes tbl_Mast_HoliDay_Type datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_Mast_HoliDay_Type object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_Mast_HoliDay_Type  tbl_Mast_HoliDay_Type   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_ID = new DataColumn("ID" , typeof(int));
			DataColumn col_holyday_type_Code = new DataColumn("holyday_type_Code" , typeof(string));
			DataColumn col_holyday_type_title = new DataColumn("holyday_type_title" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_ID,col_holyday_type_Code,col_holyday_type_title,});		return dt;
		}
		/// <summary>
		/// This fills tbl_Mast_HoliDay_Type datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_Mast_HoliDay_Type object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_Mast_HoliDay_Type user) {
		DataRow drow = dt.NewRow();
		
			drow["ID"] = user.ID;
			drow["holyday_type_Code"] = user.holyday_type_Code;
			drow["holyday_type_title"] = user.holyday_type_title;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
