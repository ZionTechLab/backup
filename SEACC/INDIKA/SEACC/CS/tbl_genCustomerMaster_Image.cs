using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCustomerMaster_Image {
		#region Fields
		private string customer_ID;
		private byte[] image;
		public byte[] image2;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerMaster_Image class.
		/// </summary>
		public tbl_genCustomerMaster_Image() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerMaster_Image class.
		/// </summary>
		public tbl_genCustomerMaster_Image(string customer_ID, byte[] image, byte[] image2) {
			this.customer_ID = customer_ID;
			this.image = image;
			this.image2 = image2;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
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
		/// Saves a record to the tbl_genCustomerMaster_Image table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ImageInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@image2", SqlDbType.Image);

			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@image2"].Value = image2;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCustomerMaster_Image table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ImageUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@image2", SqlDbType.Image);

			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@image2"].Value = image2;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCustomerMaster_Image table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ImageDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCustomerMaster_Image table.
		/// </summary>
		public static tbl_genCustomerMaster_Image Select(string customer_ID_Incoming){

			tbl_genCustomerMaster_Image tbl_genCustomerMaster_Imageins = new tbl_genCustomerMaster_Image();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ImageSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCustomerMaster_Imageins = Maketbl_genCustomerMaster_Image(dataReader);
				} else {
					tbl_genCustomerMaster_Imageins = null;
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_Imageins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Image table.
		/// </summary>
		public static List<tbl_genCustomerMaster_Image> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ImageSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCustomerMaster_Image> tbl_genCustomerMaster_ImageList = new List<tbl_genCustomerMaster_Image>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Image tbl_genCustomerMaster_Image = Maketbl_genCustomerMaster_Image(dataReader);
					tbl_genCustomerMaster_ImageList.Add(tbl_genCustomerMaster_Image);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_ImageList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCustomerMaster_Image class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCustomerMaster_Image Maketbl_genCustomerMaster_Image(SqlDataReader dataReader) {
			tbl_genCustomerMaster_Image tbl_genCustomerMaster_Image = new tbl_genCustomerMaster_Image();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCustomerMaster_Image.Customer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCustomerMaster_Image.Image = (byte[]) dataReader[1];
			}
			if (dataReader.IsDBNull(2) == false)
			{
				tbl_genCustomerMaster_Image.image2 = (byte[])dataReader[2];
			}
			return tbl_genCustomerMaster_Image;
		}
		/// <summary>
		/// This makes tbl_genCustomerMaster_Image datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCustomerMaster_Image object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCustomerMaster_Image  tbl_genCustomerMaster_Image   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
		dt.Columns.AddRange(new DataColumn[] { col_customer_ID,col_image,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCustomerMaster_Image datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCustomerMaster_Image object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCustomerMaster_Image user) {
		DataRow drow = dt.NewRow();
		
			drow["customer_ID"] = user.customer_ID;
			drow["image"] = user.image;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
