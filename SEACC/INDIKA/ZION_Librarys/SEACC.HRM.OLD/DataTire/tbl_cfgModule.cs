using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_cfgModule {
		#region Fields
		private string module_ID;
		private int sortOrder;
		private string moduleName;
		private byte[] image;
		private bool isEnable;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_cfgModule class.
		/// </summary>
		public tbl_cfgModule() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_cfgModule class.
		/// </summary>
		public tbl_cfgModule(string module_ID, int sortOrder, string moduleName, byte[] image, bool isEnable) {
			this.module_ID = module_ID;
			this.sortOrder = sortOrder;
			this.moduleName = moduleName;
			this.image = image;
			this.isEnable = isEnable;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Module_ID value.
		/// </summary>
		public string Module_ID {
			get { return module_ID; }
			set { module_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SortOrder value.
		/// </summary>
		public int SortOrder {
			get { return sortOrder; }
			set { sortOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModuleName value.
		/// </summary>
		public string ModuleName {
			get { return moduleName; }
			set { moduleName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEnable value.
		/// </summary>
		public bool IsEnable {
			get { return isEnable; }
			set { isEnable = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_cfgModule table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModuleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@module_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@moduleName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
 
			scom.Parameters["@module_ID"].Value = module_ID;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@moduleName"].Value = moduleName;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@isEnable"].Value = isEnable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_cfgModule table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModuleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@module_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@moduleName", SqlDbType.VarChar,50);
            scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
 
 
			scom.Parameters["@module_ID"].Value = module_ID;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@moduleName"].Value = moduleName;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@isEnable"].Value = isEnable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_cfgModule table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModuleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@module_ID", SqlDbType.VarChar,8);
			scom.Parameters["@module_ID"].Value = module_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_cfgModule table.
		/// </summary>
		public static tbl_cfgModule Select(string module_ID_Incoming){

			tbl_cfgModule tbl_cfgModuleins = new tbl_cfgModule();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModuleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@module_ID", SqlDbType.VarChar,8);
			scom.Parameters["@module_ID"].Value = module_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_cfgModuleins = Maketbl_cfgModule(dataReader);
				} else {
					tbl_cfgModuleins = null;
				}
			}
			scon.Close();
			return tbl_cfgModuleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgModule table.
		/// </summary>
		public static List<tbl_cfgModule> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModuleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_cfgModule> tbl_cfgModuleList = new List<tbl_cfgModule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgModule tbl_cfgModule = Maketbl_cfgModule(dataReader);
					tbl_cfgModuleList.Add(tbl_cfgModule);
				}
			}
			scon.Close();
			return tbl_cfgModuleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_cfgModule class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_cfgModule Maketbl_cfgModule(SqlDataReader dataReader) {
			tbl_cfgModule tbl_cfgModule = new tbl_cfgModule();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_cfgModule.Module_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_cfgModule.SortOrder = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_cfgModule.ModuleName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
                tbl_cfgModule.Image = (byte[])dataReader[3];
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_cfgModule.IsEnable = dataReader.GetBoolean(4);
			}

			return tbl_cfgModule;
		}
		/// <summary>
		/// This makes tbl_cfgModule datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_cfgModule object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_cfgModule  tbl_cfgModule   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_module_ID = new DataColumn("module_ID" , typeof(string));
			DataColumn col_sortOrder = new DataColumn("sortOrder" , typeof(int));
			DataColumn col_moduleName = new DataColumn("moduleName" , typeof(string));
            DataColumn col_image = new DataColumn("image", typeof(byte[]));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_module_ID,col_sortOrder,col_moduleName,col_image,col_isEnable,});		return dt;
		}
		/// <summary>
		/// This fills tbl_cfgModule datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_cfgModule object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_cfgModule user) {
		DataRow drow = dt.NewRow();
		
			drow["module_ID"] = user.module_ID;
			drow["sortOrder"] = user.sortOrder;
			drow["moduleName"] = user.moduleName;
			drow["image"] = user.image;
			drow["isEnable"] = user.isEnable;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
