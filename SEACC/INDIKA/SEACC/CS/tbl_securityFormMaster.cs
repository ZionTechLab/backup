using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_securityFormMaster {
		#region Fields
		private int form_ID;
		private int sortOrder;
		private string formName;
		private byte[] image;
		private string formCategory_ID;
		private string displayName;
		private bool isEnable;
		private bool isVisible;
		private bool isViewer;
		private string documentCode;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFormMaster class.
		/// </summary>
		public tbl_securityFormMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFormMaster class.
		/// </summary>
		public tbl_securityFormMaster(int form_ID, int sortOrder, string formName, byte[] image, string formCategory_ID, string displayName, bool isEnable, bool isVisible, bool isViewer, string documentCode) {
			this.form_ID = form_ID;
			this.sortOrder = sortOrder;
			this.formName = formName;
			this.image = image;
			this.formCategory_ID = formCategory_ID;
			this.displayName = displayName;
			this.isEnable = isEnable;
			this.isVisible = isVisible;
			this.isViewer = isViewer;
			this.documentCode = documentCode;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SortOrder value.
		/// </summary>
		public int SortOrder {
			get { return sortOrder; }
			set { sortOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the FormName value.
		/// </summary>
		public string FormName {
			get { return formName; }
			set { formName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		
		/// <summary>
		/// Gets or sets the FormCategory_ID value.
		/// </summary>
		public string FormCategory_ID {
			get { return formCategory_ID; }
			set { formCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayName value.
		/// </summary>
		public string DisplayName {
			get { return displayName; }
			set { displayName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEnable value.
		/// </summary>
		public bool IsEnable {
			get { return isEnable; }
			set { isEnable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVisible value.
		/// </summary>
		public bool IsVisible {
			get { return isVisible; }
			set { isVisible = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsViewer value.
		/// </summary>
		public bool IsViewer {
			get { return isViewer; }
			set { isViewer = value; }
		}
		
		/// <summary>
		/// Gets or sets the DocumentCode value.
		/// </summary>
		public string DocumentCode {
			get { return documentCode; }
			set { documentCode = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityFormMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@formName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVisible", SqlDbType.Bit,1);
			scom.Parameters.Add("@isViewer", SqlDbType.Bit,1);
			scom.Parameters.Add("@documentCode", SqlDbType.VarChar,4);
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@formName"].Value = formName;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isVisible"].Value = isVisible;
			scom.Parameters["@isViewer"].Value = isViewer;
			scom.Parameters["@documentCode"].Value = documentCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityFormMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@formName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVisible", SqlDbType.Bit,1);
			scom.Parameters.Add("@isViewer", SqlDbType.Bit,1);
			scom.Parameters.Add("@documentCode", SqlDbType.VarChar,4);
 
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@formName"].Value = formName;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isVisible"].Value = isVisible;
			scom.Parameters["@isViewer"].Value = isViewer;
			scom.Parameters["@documentCode"].Value = documentCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityFormMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFormMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByFormCategory_ID(string formCategory_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormMasterDeleteAllByFormCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFormMaster table.
		/// </summary>
		public static tbl_securityFormMaster Select(int form_ID_Incoming){

			tbl_securityFormMaster tbl_securityFormMasterins = new tbl_securityFormMaster();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFormMasterins = Maketbl_securityFormMaster(dataReader);
				} else {
					tbl_securityFormMasterins = null;
				}
			}
			scon.Close();
			return tbl_securityFormMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFormMaster table.
		/// </summary>
		public static List<tbl_securityFormMaster> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFormMaster> tbl_securityFormMasterList = new List<tbl_securityFormMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFormMaster tbl_securityFormMaster = Maketbl_securityFormMaster(dataReader);
					tbl_securityFormMasterList.Add(tbl_securityFormMaster);
				}
			}
			scon.Close();
			return tbl_securityFormMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFormMaster table by a foreign key.
		/// </summary>
		public static List<tbl_securityFormMaster> SelectAllByFormCategory_ID(string formCategory_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormMasterSelectAllByFormCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
				List<tbl_securityFormMaster> tbl_securityFormMasterList = new List<tbl_securityFormMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFormMaster tbl_securityFormMaster = Maketbl_securityFormMaster(dataReader);
					tbl_securityFormMasterList.Add(tbl_securityFormMaster);
				}
			}
			scon.Close();
			return tbl_securityFormMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFormMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFormMaster Maketbl_securityFormMaster(SqlDataReader dataReader) {
			tbl_securityFormMaster tbl_securityFormMaster = new tbl_securityFormMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFormMaster.Form_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFormMaster.SortOrder = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFormMaster.FormName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityFormMaster.Image = (byte[])dataReader[3];
            }
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityFormMaster.FormCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityFormMaster.DisplayName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityFormMaster.IsEnable = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityFormMaster.IsVisible = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_securityFormMaster.IsViewer = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_securityFormMaster.DocumentCode = dataReader.GetString(9);
			}

			return tbl_securityFormMaster;
		}
		/// <summary>
		/// This makes tbl_securityFormMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFormMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFormMaster  tbl_securityFormMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_sortOrder = new DataColumn("sortOrder" , typeof(int));
			DataColumn col_formName = new DataColumn("formName" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
			DataColumn col_formCategory_ID = new DataColumn("formCategory_ID" , typeof(string));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
			DataColumn col_isVisible = new DataColumn("isVisible" , typeof(bool));
			DataColumn col_isViewer = new DataColumn("isViewer" , typeof(bool));
			DataColumn col_documentCode = new DataColumn("documentCode" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_form_ID,col_sortOrder,col_formName,col_image,col_formCategory_ID,col_displayName,col_isEnable,col_isVisible,col_isViewer,col_documentCode,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFormMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFormMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFormMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["form_ID"] = user.form_ID;
			drow["sortOrder"] = user.sortOrder;
			drow["formName"] = user.formName;
			drow["image"] = user.image;
			drow["formCategory_ID"] = user.formCategory_ID;
			drow["displayName"] = user.displayName;
			drow["isEnable"] = user.isEnable;
			drow["isVisible"] = user.isVisible;
			drow["isViewer"] = user.isViewer;
			drow["documentCode"] = user.documentCode;
		dt.Rows.Add(drow);
		}
		#endregion
        public static DataTable SelectAllbyFormCategory_ID_DataTable(string formCategory_ID,bool isViewer)
        {
            DataTable dt_tbl_audBackupLogList = new DataTable();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("select [form_ID],[sortOrder],[formName],[image] from [dbo].[tbl_securityFormMaster] where [formCategory_ID]='" + formCategory_ID + "' AND IsVisible=1 AND IsViewer="+(isViewer?1:0).ToString()+" order by [sortOrder]", scon);
            scom.CommandType = CommandType.Text;
            scon.Open();

            SqlDataAdapter da = new SqlDataAdapter(scom);
            da.Fill(dt_tbl_audBackupLogList);

            da.Dispose();
            scon.Close();
            return dt_tbl_audBackupLogList;
        }
	}
}
