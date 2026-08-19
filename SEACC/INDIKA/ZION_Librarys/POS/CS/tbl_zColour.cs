using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zColour {
		#region Fields
		private string colour_ID;
		private string colourName;
		private string prefrix;
		private string prefrix2;
		private string rgbCode;
		private string cmykCode;
		private string pmsCode;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zColour class.
		/// </summary>
		public tbl_zColour() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zColour class.
		/// </summary>
		public tbl_zColour(string colour_ID, string colourName, string prefrix, string prefrix2, string rgbCode, string cmykCode, string pmsCode, string remark) {
			this.colour_ID = colour_ID;
			this.colourName = colourName;
			this.prefrix = prefrix;
			this.prefrix2 = prefrix2;
			this.rgbCode = rgbCode;
			this.cmykCode = cmykCode;
			this.pmsCode = pmsCode;
			this.remark = remark;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Colour_ID value.
		/// </summary>
		public string Colour_ID {
			get { return colour_ID; }
			set { colour_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ColourName value.
		/// </summary>
		public string ColourName {
			get { return colourName; }
			set { colourName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix value.
		/// </summary>
		public string Prefrix {
			get { return prefrix; }
			set { prefrix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix2 value.
		/// </summary>
		public string Prefrix2 {
			get { return prefrix2; }
			set { prefrix2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the RgbCode value.
		/// </summary>
		public string RgbCode {
			get { return rgbCode; }
			set { rgbCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the CmykCode value.
		/// </summary>
		public string CmykCode {
			get { return cmykCode; }
			set { cmykCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the PmsCode value.
		/// </summary>
		public string PmsCode {
			get { return pmsCode; }
			set { pmsCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zColour table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zColourInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@colourName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rgbCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cmykCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pmsCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@colour_ID"].Value = colour_ID;
			scom.Parameters["@colourName"].Value = colourName;
			scom.Parameters["@prefrix"].Value = prefrix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@rgbCode"].Value = rgbCode;
			scom.Parameters["@cmykCode"].Value = cmykCode;
			scom.Parameters["@pmsCode"].Value = pmsCode;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zColour table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zColourUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@colourName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rgbCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cmykCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pmsCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@colour_ID"].Value = colour_ID;
			scom.Parameters["@colourName"].Value = colourName;
			scom.Parameters["@prefrix"].Value = prefrix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@rgbCode"].Value = rgbCode;
			scom.Parameters["@cmykCode"].Value = cmykCode;
			scom.Parameters["@pmsCode"].Value = pmsCode;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zColour table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zColourDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters["@colour_ID"].Value = colour_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zColour table.
		/// </summary>
		public static tbl_zColour Select(string colour_ID_Incoming){

			tbl_zColour tbl_zColourins = new tbl_zColour();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zColourSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters["@colour_ID"].Value = colour_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zColourins = Maketbl_zColour(dataReader);
				} else {
					tbl_zColourins = null;
				}
			}
			scon.Close();
			return tbl_zColourins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zColour table.
		/// </summary>
		public static List<tbl_zColour> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zColourSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zColour> tbl_zColourList = new List<tbl_zColour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zColour tbl_zColour = Maketbl_zColour(dataReader);
					tbl_zColourList.Add(tbl_zColour);
				}
			}
			scon.Close();
			return tbl_zColourList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zColour class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zColour Maketbl_zColour(SqlDataReader dataReader) {
			tbl_zColour tbl_zColour = new tbl_zColour();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zColour.Colour_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zColour.ColourName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zColour.Prefrix = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zColour.Prefrix2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zColour.RgbCode = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zColour.CmykCode = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zColour.PmsCode = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zColour.Remark = dataReader.GetString(7);
			}

			return tbl_zColour;
		}
		/// <summary>
		/// This makes tbl_zColour datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zColour object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zColour  tbl_zColour   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_colour_ID = new DataColumn("colour_ID" , typeof(string));
			DataColumn col_colourName = new DataColumn("colourName" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
			DataColumn col_prefrix2 = new DataColumn("prefrix2" , typeof(string));
			DataColumn col_rgbCode = new DataColumn("rgbCode" , typeof(string));
			DataColumn col_cmykCode = new DataColumn("cmykCode" , typeof(string));
			DataColumn col_pmsCode = new DataColumn("pmsCode" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_colour_ID,col_colourName,col_prefrix,col_prefrix2,col_rgbCode,col_cmykCode,col_pmsCode,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zColour datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zColour object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zColour user) {
		DataRow drow = dt.NewRow();
		
			drow["colour_ID"] = user.colour_ID;
			drow["colourName"] = user.colourName;
			drow["prefrix"] = user.prefrix;
			drow["prefrix2"] = user.prefrix2;
			drow["rgbCode"] = user.rgbCode;
			drow["cmykCode"] = user.cmykCode;
			drow["pmsCode"] = user.pmsCode;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
