using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_PNL {
		#region Fields
		private int pnl_LineNo;
		private string glSubCatagory_ID;
		private string glSubCatagory_Name;
		private bool isAddition;
		private bool isTotal;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_PNL class.
		/// </summary>
		public tbl_accGLMaster_PNL() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_PNL class.
		/// </summary>
		public tbl_accGLMaster_PNL(int pnl_LineNo, string glSubCatagory_ID, string glSubCatagory_Name, bool isAddition, bool isTotal) {
			this.pnl_LineNo = pnl_LineNo;
			this.glSubCatagory_ID = glSubCatagory_ID;
			this.glSubCatagory_Name = glSubCatagory_Name;
			this.isAddition = isAddition;
			this.isTotal = isTotal;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Pnl_LineNo value.
		/// </summary>
		public int Pnl_LineNo {
			get { return pnl_LineNo; }
			set { pnl_LineNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlSubCatagory_ID value.
		/// </summary>
		public string GlSubCatagory_ID {
			get { return glSubCatagory_ID; }
			set { glSubCatagory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlSubCatagory_Name value.
		/// </summary>
		public string GlSubCatagory_Name {
			get { return glSubCatagory_Name; }
			set { glSubCatagory_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAddition value.
		/// </summary>
		public bool IsAddition {
			get { return isAddition; }
			set { isAddition = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTotal value.
		/// </summary>
		public bool IsTotal {
			get { return isTotal; }
			set { isTotal = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLMaster_PNL table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_PNLInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pnl_LineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glSubCatagory_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAddition", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTotal", SqlDbType.Bit,1);
 
			scom.Parameters["@pnl_LineNo"].Value = pnl_LineNo;
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
			scom.Parameters["@glSubCatagory_Name"].Value = glSubCatagory_Name;
			scom.Parameters["@isAddition"].Value = isAddition;
			scom.Parameters["@isTotal"].Value = isTotal;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_PNL table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_PNLUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pnl_LineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glSubCatagory_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAddition", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTotal", SqlDbType.Bit,1);
 
 
			scom.Parameters["@pnl_LineNo"].Value = pnl_LineNo;
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
			scom.Parameters["@glSubCatagory_Name"].Value = glSubCatagory_Name;
			scom.Parameters["@isAddition"].Value = isAddition;
			scom.Parameters["@isTotal"].Value = isTotal;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_PNL table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_PNLDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pnl_LineNo", SqlDbType.Int,4);
			scom.Parameters["@pnl_LineNo"].Value = pnl_LineNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
        public static void DeleteAll()
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accGLMaster_PNLDeleteALL", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_PNL table.
		/// </summary>
		public static tbl_accGLMaster_PNL Select(int pnl_LineNo_Incoming){

			tbl_accGLMaster_PNL tbl_accGLMaster_PNLins = new tbl_accGLMaster_PNL();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_PNLSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pnl_LineNo", SqlDbType.Int,4);
			scom.Parameters["@pnl_LineNo"].Value = pnl_LineNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_PNLins = Maketbl_accGLMaster_PNL(dataReader);
				} else {
					tbl_accGLMaster_PNLins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_PNLins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_PNL table.
		/// </summary>
		public static List<tbl_accGLMaster_PNL> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_PNLSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_PNL> tbl_accGLMaster_PNLList = new List<tbl_accGLMaster_PNL>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_PNL tbl_accGLMaster_PNL = Maketbl_accGLMaster_PNL(dataReader);
					tbl_accGLMaster_PNLList.Add(tbl_accGLMaster_PNL);
				}
			}
			scon.Close();
			return tbl_accGLMaster_PNLList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_PNL class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_PNL Maketbl_accGLMaster_PNL(SqlDataReader dataReader) {
			tbl_accGLMaster_PNL tbl_accGLMaster_PNL = new tbl_accGLMaster_PNL();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_PNL.Pnl_LineNo = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_PNL.GlSubCatagory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_PNL.GlSubCatagory_Name = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLMaster_PNL.IsAddition = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLMaster_PNL.IsTotal = dataReader.GetBoolean(4);
			}

			return tbl_accGLMaster_PNL;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_PNL datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_PNL object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_PNL  tbl_accGLMaster_PNL   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pnl_LineNo = new DataColumn("pnl_LineNo" , typeof(int));
			DataColumn col_glSubCatagory_ID = new DataColumn("glSubCatagory_ID" , typeof(string));
			DataColumn col_glSubCatagory_Name = new DataColumn("glSubCatagory_Name" , typeof(string));
			DataColumn col_isAddition = new DataColumn("isAddition" , typeof(bool));
			DataColumn col_isTotal = new DataColumn("isTotal" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_pnl_LineNo,col_glSubCatagory_ID,col_glSubCatagory_Name,col_isAddition,col_isTotal,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_PNL datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_PNL object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_PNL user) {
		DataRow drow = dt.NewRow();
		
			drow["pnl_LineNo"] = user.pnl_LineNo;
			drow["glSubCatagory_ID"] = user.glSubCatagory_ID;
			drow["glSubCatagory_Name"] = user.glSubCatagory_Name;
			drow["isAddition"] = user.isAddition;
			drow["isTotal"] = user.isTotal;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
