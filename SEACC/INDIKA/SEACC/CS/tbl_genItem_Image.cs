using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItem_Image {
		#region Fields
		private string item_ID;
		private byte[] image;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItem_Image class.
		/// </summary>
		public tbl_genItem_Image() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItem_Image class.
		/// </summary>
		public tbl_genItem_Image(string item_ID, byte[] image) {
			this.item_ID = item_ID;
			this.image = image;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
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
		/// Saves a record to the tbl_genItem_Image table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItem_ImageInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@image", SqlDbType.Image);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@image"].Value = image;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItem_Image table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItem_ImageUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@image", SqlDbType.Image);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@image"].Value = image;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItem_Image table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItem_ImageDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItem_Image table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItem_ImageDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItem_Image table.
		/// </summary>
		public static tbl_genItem_Image Select(string item_ID_Incoming){

			tbl_genItem_Image tbl_genItem_Imageins = new tbl_genItem_Image();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItem_ImageSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItem_Imageins = Maketbl_genItem_Image(dataReader);
				} else {
					tbl_genItem_Imageins = null;
				}
			}
			scon.Close();
			return tbl_genItem_Imageins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItem_Image table.
		/// </summary>
		public static List<tbl_genItem_Image> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItem_ImageSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItem_Image> tbl_genItem_ImageList = new List<tbl_genItem_Image>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItem_Image tbl_genItem_Image = Maketbl_genItem_Image(dataReader);
					tbl_genItem_ImageList.Add(tbl_genItem_Image);
				}
			}
			scon.Close();
			return tbl_genItem_ImageList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItem_Image table by a foreign key.
		/// </summary>
		public static List<tbl_genItem_Image> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItem_ImageSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItem_Image> tbl_genItem_ImageList = new List<tbl_genItem_Image>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItem_Image tbl_genItem_Image = Maketbl_genItem_Image(dataReader);
					tbl_genItem_ImageList.Add(tbl_genItem_Image);
				}
			}
			scon.Close();
			return tbl_genItem_ImageList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItem_Image class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItem_Image Maketbl_genItem_Image(SqlDataReader dataReader) {
			tbl_genItem_Image tbl_genItem_Image = new tbl_genItem_Image();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItem_Image.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItem_Image.Image = (byte[])dataReader[1];
			}

			return tbl_genItem_Image;
		}
		/// <summary>
		/// This makes tbl_genItem_Image datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItem_Image object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItem_Image  tbl_genItem_Image   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_image,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItem_Image datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItem_Image object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItem_Image user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["image"] = user.image;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
