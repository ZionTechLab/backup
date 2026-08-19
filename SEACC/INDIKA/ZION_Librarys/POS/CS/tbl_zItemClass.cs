using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemClass {
		#region Fields
		private string itemClass_ID;
		private string className;
		private string prefrix;
		private string prefrix2;
		private string remark;
		private bool isProd_Class;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemClass class.
		/// </summary>
		public tbl_zItemClass() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemClass class.
		/// </summary>
		public tbl_zItemClass(string itemClass_ID, string className, string prefrix, string prefrix2, string remark, bool isProd_Class) {
			this.itemClass_ID = itemClass_ID;
			this.className = className;
			this.prefrix = prefrix;
			this.prefrix2 = prefrix2;
			this.remark = remark;
			this.isProd_Class = isProd_Class;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemClass_ID value.
		/// </summary>
		public string ItemClass_ID {
			get { return itemClass_ID; }
			set { itemClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClassName value.
		/// </summary>
		public string ClassName {
			get { return className; }
			set { className = value; }
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
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsProd_Class value.
		/// </summary>
		public bool IsProd_Class {
			get { return isProd_Class; }
			set { isProd_Class = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemClass table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemClassInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@className", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isProd_Class", SqlDbType.Bit,1);
 
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@className"].Value = className;
			scom.Parameters["@prefrix"].Value = prefrix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isProd_Class"].Value = isProd_Class;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemClass table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemClassUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@className", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isProd_Class", SqlDbType.Bit,1);
 
 
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@className"].Value = className;
			scom.Parameters["@prefrix"].Value = prefrix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isProd_Class"].Value = isProd_Class;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemClass table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemClassDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemClass table.
		/// </summary>
		public static tbl_zItemClass Select(string itemClass_ID_Incoming){

			tbl_zItemClass tbl_zItemClassins = new tbl_zItemClass();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemClassSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemClassins = Maketbl_zItemClass(dataReader);
				} else {
					tbl_zItemClassins = null;
				}
			}
			scon.Close();
			return tbl_zItemClassins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemClass table.
		/// </summary>
		public static List<tbl_zItemClass> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemClassSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemClass> tbl_zItemClassList = new List<tbl_zItemClass>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemClass tbl_zItemClass = Maketbl_zItemClass(dataReader);
					tbl_zItemClassList.Add(tbl_zItemClass);
				}
			}
			scon.Close();
			return tbl_zItemClassList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemClass class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemClass Maketbl_zItemClass(SqlDataReader dataReader) {
			tbl_zItemClass tbl_zItemClass = new tbl_zItemClass();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemClass.ItemClass_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemClass.ClassName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemClass.Prefrix = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zItemClass.Prefrix2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zItemClass.Remark = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zItemClass.IsProd_Class = dataReader.GetBoolean(5);
			}

			return tbl_zItemClass;
		}
		/// <summary>
		/// This makes tbl_zItemClass datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemClass object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemClass  tbl_zItemClass   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemClass_ID = new DataColumn("itemClass_ID" , typeof(string));
			DataColumn col_className = new DataColumn("className" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
			DataColumn col_prefrix2 = new DataColumn("prefrix2" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isProd_Class = new DataColumn("isProd_Class" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_itemClass_ID,col_className,col_prefrix,col_prefrix2,col_remark,col_isProd_Class,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemClass datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemClass object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemClass user) {
		DataRow drow = dt.NewRow();
		
			drow["itemClass_ID"] = user.itemClass_ID;
			drow["className"] = user.className;
			drow["prefrix"] = user.prefrix;
			drow["prefrix2"] = user.prefrix2;
			drow["remark"] = user.remark;
			drow["isProd_Class"] = user.isProd_Class;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
