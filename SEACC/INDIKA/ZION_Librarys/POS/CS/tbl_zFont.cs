using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zFont {
		#region Fields
		private int fontType_ID;
		private string fontType_Name;
		private string fontName;
		private int size;
		private string style;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zFont class.
		/// </summary>
		public tbl_zFont() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zFont class.
		/// </summary>
		public tbl_zFont(int fontType_ID, string fontType_Name, string fontName, int size, string style) {
			this.fontType_ID = fontType_ID;
			this.fontType_Name = fontType_Name;
			this.fontName = fontName;
			this.size = size;
			this.style = style;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FontType_ID value.
		/// </summary>
		public int FontType_ID {
			get { return fontType_ID; }
			set { fontType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FontType_Name value.
		/// </summary>
		public string FontType_Name {
			get { return fontType_Name; }
			set { fontType_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the FontName value.
		/// </summary>
		public string FontName {
			get { return fontName; }
			set { fontName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Size value.
		/// </summary>
		public int Size {
			get { return size; }
			set { size = value; }
		}
		
		/// <summary>
		/// Gets or sets the Style value.
		/// </summary>
		public string Style {
			get { return style; }
			set { style = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zFont table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFontInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@fontType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@fontType_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fontName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@size", SqlDbType.Int,4);
			scom.Parameters.Add("@style", SqlDbType.VarChar,50);
 
			scom.Parameters["@fontType_ID"].Value = fontType_ID;
			scom.Parameters["@fontType_Name"].Value = fontType_Name;
			scom.Parameters["@fontName"].Value = fontName;
			scom.Parameters["@size"].Value = size;
			scom.Parameters["@style"].Value = style;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zFont table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFontUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@fontType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@fontType_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fontName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@size", SqlDbType.Int,4);
			scom.Parameters.Add("@style", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@fontType_ID"].Value = fontType_ID;
			scom.Parameters["@fontType_Name"].Value = fontType_Name;
			scom.Parameters["@fontName"].Value = fontName;
			scom.Parameters["@size"].Value = size;
			scom.Parameters["@style"].Value = style;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zFont table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFontDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@fontType_ID", SqlDbType.Int,4);
			scom.Parameters["@fontType_ID"].Value = fontType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zFont table.
		/// </summary>
		public static tbl_zFont Select(string fontType_ID_Incoming){

			tbl_zFont tbl_zFontins = new tbl_zFont();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFontSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fontType_ID", SqlDbType.Int,4);
			scom.Parameters["@fontType_ID"].Value = fontType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zFontins = Maketbl_zFont(dataReader);
				} else {
					tbl_zFontins = null;
				}
			}
			scon.Close();
			return tbl_zFontins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zFont table.
		/// </summary>
		public static List<tbl_zFont> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zFontSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zFont> tbl_zFontList = new List<tbl_zFont>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zFont tbl_zFont = Maketbl_zFont(dataReader);
					tbl_zFontList.Add(tbl_zFont);
				}
			}
			scon.Close();
			return tbl_zFontList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zFont class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zFont Maketbl_zFont(SqlDataReader dataReader) {
			tbl_zFont tbl_zFont = new tbl_zFont();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zFont.FontType_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zFont.FontType_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zFont.FontName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zFont.Size = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zFont.Style = dataReader.GetString(4);
			}

			return tbl_zFont;
		}
		/// <summary>
		/// This makes tbl_zFont datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zFont object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zFont  tbl_zFont   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_fontType_ID = new DataColumn("fontType_ID" , typeof(int));
			DataColumn col_fontType_Name = new DataColumn("fontType_Name" , typeof(string));
			DataColumn col_fontName = new DataColumn("fontName" , typeof(string));
			DataColumn col_size = new DataColumn("size" , typeof(int));
			DataColumn col_style = new DataColumn("style" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_fontType_ID,col_fontType_Name,col_fontName,col_size,col_style,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zFont datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zFont object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zFont user) {
		DataRow drow = dt.NewRow();
		
			drow["fontType_ID"] = user.fontType_ID;
			drow["fontType_Name"] = user.fontType_Name;
			drow["fontName"] = user.fontName;
			drow["size"] = user.size;
			drow["style"] = user.style;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
