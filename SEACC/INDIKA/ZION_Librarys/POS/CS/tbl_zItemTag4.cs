using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemTag4 {
		#region Fields
		private string tag4_ID;
		private string description;
		private string remark;
		private string prefix;
		private string prefrix2;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemTag4 class.
		/// </summary>
		public tbl_zItemTag4() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemTag4 class.
		/// </summary>
		public tbl_zItemTag4(string tag4_ID, string description, string remark, string prefix, string prefrix2, bool isDeleted) {
			this.tag4_ID = tag4_ID;
			this.description = description;
			this.remark = remark;
			this.prefix = prefix;
			this.prefrix2 = prefrix2;
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tag4_ID value.
		/// </summary>
		public string Tag4_ID {
			get { return tag4_ID; }
			set { tag4_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix2 value.
		/// </summary>
		public string Prefrix2 {
			get { return prefrix2; }
			set { prefrix2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemTag4 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag4Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tag4_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@tag4_ID"].Value = tag4_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemTag4 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag4Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tag4_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@tag4_ID"].Value = tag4_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemTag4 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag4Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tag4_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag4_ID"].Value = tag4_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemTag4 table.
		/// </summary>
		public static tbl_zItemTag4 Select(string tag4_ID_Incoming){

			tbl_zItemTag4 tbl_zItemTag4ins = new tbl_zItemTag4();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag4Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tag4_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag4_ID"].Value = tag4_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemTag4ins = Maketbl_zItemTag4(dataReader);
				} else {
					tbl_zItemTag4ins = null;
				}
			}
			scon.Close();
			return tbl_zItemTag4ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag4 table.
		/// </summary>
		public static List<tbl_zItemTag4> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag4SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemTag4> tbl_zItemTag4List = new List<tbl_zItemTag4>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag4 tbl_zItemTag4 = Maketbl_zItemTag4(dataReader);
					tbl_zItemTag4List.Add(tbl_zItemTag4);
				}
			}
			scon.Close();
			return tbl_zItemTag4List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemTag4 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemTag4 Maketbl_zItemTag4(SqlDataReader dataReader) {
			tbl_zItemTag4 tbl_zItemTag4 = new tbl_zItemTag4();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemTag4.Tag4_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemTag4.Description = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemTag4.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zItemTag4.Prefix = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zItemTag4.Prefrix2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zItemTag4.IsDeleted = dataReader.GetBoolean(5);
			}

			return tbl_zItemTag4;
		}
		/// <summary>
		/// This makes tbl_zItemTag4 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemTag4 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemTag4  tbl_zItemTag4   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tag4_ID = new DataColumn("tag4_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_prefrix2 = new DataColumn("prefrix2" , typeof(string));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_tag4_ID,col_description,col_remark,col_prefix,col_prefrix2,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemTag4 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemTag4 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemTag4 user) {
		DataRow drow = dt.NewRow();
		
			drow["tag4_ID"] = user.tag4_ID;
			drow["description"] = user.description;
			drow["remark"] = user.remark;
			drow["prefix"] = user.prefix;
			drow["prefrix2"] = user.prefrix2;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
