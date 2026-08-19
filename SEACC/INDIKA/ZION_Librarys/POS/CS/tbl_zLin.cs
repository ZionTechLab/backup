using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zLin {
		#region Fields
		private string uALID;
		private string iNVNO;
		private string qTY;
		private string sTDD;
		private string eNDD;
		private DateTime aDDD;
		private string aDDBY;
		private string aCNO;
		private bool iSAN;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zLin class.
		/// </summary>
		public tbl_zLin() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zLin class.
		/// </summary>
		public tbl_zLin(string uALID, string iNVNO, string qTY, string sTDD, string eNDD, DateTime aDDD, string aDDBY, string aCNO, bool iSAN) {
			this.uALID = uALID;
			this.iNVNO = iNVNO;
			this.qTY = qTY;
			this.sTDD = sTDD;
			this.eNDD = eNDD;
			this.aDDD = aDDD;
			this.aDDBY = aDDBY;
			this.aCNO = aCNO;
			this.iSAN = iSAN;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the UALID value.
		/// </summary>
		public string UALID {
			get { return uALID; }
			set { uALID = value; }
		}
		
		/// <summary>
		/// Gets or sets the INVNO value.
		/// </summary>
		public string INVNO {
			get { return iNVNO; }
			set { iNVNO = value; }
		}
		
		/// <summary>
		/// Gets or sets the QTY value.
		/// </summary>
		public string QTY {
			get { return qTY; }
			set { qTY = value; }
		}
		
		/// <summary>
		/// Gets or sets the STDD value.
		/// </summary>
		public string STDD {
			get { return sTDD; }
			set { sTDD = value; }
		}
		
		/// <summary>
		/// Gets or sets the ENDD value.
		/// </summary>
		public string ENDD {
			get { return eNDD; }
			set { eNDD = value; }
		}
		
		/// <summary>
		/// Gets or sets the ADDD value.
		/// </summary>
		public DateTime ADDD {
			get { return aDDD; }
			set { aDDD = value; }
		}
		
		/// <summary>
		/// Gets or sets the ADDBY value.
		/// </summary>
		public string ADDBY {
			get { return aDDBY; }
			set { aDDBY = value; }
		}
		
		/// <summary>
		/// Gets or sets the ACNO value.
		/// </summary>
		public string ACNO {
			get { return aCNO; }
			set { aCNO = value; }
		}
		
		/// <summary>
		/// Gets or sets the ISAN value.
		/// </summary>
		public bool ISAN {
			get { return iSAN; }
			set { iSAN = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zLin table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zLinInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@UALID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@INVNO", SqlDbType.VarChar,50);
			scom.Parameters.Add("@QTY", SqlDbType.VarChar,50);
			scom.Parameters.Add("@STDD", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ENDD", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ADDD", SqlDbType.DateTime,8);
			scom.Parameters.Add("@ADDBY", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ACNO", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ISAN", SqlDbType.Bit,1);
 
			scom.Parameters["@UALID"].Value = uALID;
			scom.Parameters["@INVNO"].Value = iNVNO;
			scom.Parameters["@QTY"].Value = qTY;
			scom.Parameters["@STDD"].Value = sTDD;
			scom.Parameters["@ENDD"].Value = eNDD;
			scom.Parameters["@ADDD"].Value = aDDD;
			scom.Parameters["@ADDBY"].Value = aDDBY;
			scom.Parameters["@ACNO"].Value = aCNO;
			scom.Parameters["@ISAN"].Value = iSAN;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zLin table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zLinUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@UALID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@INVNO", SqlDbType.VarChar,50);
			scom.Parameters.Add("@QTY", SqlDbType.VarChar,50);
			scom.Parameters.Add("@STDD", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ENDD", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ADDD", SqlDbType.DateTime,8);
			scom.Parameters.Add("@ADDBY", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ACNO", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ISAN", SqlDbType.Bit,1);
 
 
			scom.Parameters["@UALID"].Value = uALID;
			scom.Parameters["@INVNO"].Value = iNVNO;
			scom.Parameters["@QTY"].Value = qTY;
			scom.Parameters["@STDD"].Value = sTDD;
			scom.Parameters["@ENDD"].Value = eNDD;
			scom.Parameters["@ADDD"].Value = aDDD;
			scom.Parameters["@ADDBY"].Value = aDDBY;
			scom.Parameters["@ACNO"].Value = aCNO;
			scom.Parameters["@ISAN"].Value = iSAN;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zLin table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zLinDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@UALID", SqlDbType.VarChar,20);
			scom.Parameters["@UALID"].Value = uALID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zLin table.
		/// </summary>
		public static tbl_zLin Select(string uALID_Incoming){

			tbl_zLin tbl_zLinins = new tbl_zLin();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zLinSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@UALID", SqlDbType.VarChar,20);
			scom.Parameters["@UALID"].Value = uALID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zLinins = Maketbl_zLin(dataReader);
				} else {
					tbl_zLinins = null;
				}
			}
			scon.Close();
			return tbl_zLinins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zLin table.
		/// </summary>
		public static List<tbl_zLin> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zLinSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zLin> tbl_zLinList = new List<tbl_zLin>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zLin tbl_zLin = Maketbl_zLin(dataReader);
					tbl_zLinList.Add(tbl_zLin);
				}
			}
			scon.Close();
			return tbl_zLinList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zLin class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zLin Maketbl_zLin(SqlDataReader dataReader) {
			tbl_zLin tbl_zLin = new tbl_zLin();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zLin.UALID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zLin.INVNO = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zLin.QTY = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zLin.STDD = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zLin.ENDD = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zLin.ADDD = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zLin.ADDBY = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zLin.ACNO = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zLin.ISAN = dataReader.GetBoolean(8);
			}

			return tbl_zLin;
		}
		/// <summary>
		/// This makes tbl_zLin datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zLin object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zLin  tbl_zLin   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_UALID = new DataColumn("UALID" , typeof(string));
			DataColumn col_INVNO = new DataColumn("INVNO" , typeof(string));
			DataColumn col_QTY = new DataColumn("QTY" , typeof(string));
			DataColumn col_STDD = new DataColumn("STDD" , typeof(string));
			DataColumn col_ENDD = new DataColumn("ENDD" , typeof(string));
			DataColumn col_ADDD = new DataColumn("ADDD" , typeof(DateTime));
			DataColumn col_ADDBY = new DataColumn("ADDBY" , typeof(string));
			DataColumn col_ACNO = new DataColumn("ACNO" , typeof(string));
			DataColumn col_ISAN = new DataColumn("ISAN" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_UALID,col_INVNO,col_QTY,col_STDD,col_ENDD,col_ADDD,col_ADDBY,col_ACNO,col_ISAN,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zLin datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zLin object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zLin user) {
		DataRow drow = dt.NewRow();
		
			drow["UALID"] = user.UALID;
			drow["INVNO"] = user.INVNO;
			drow["QTY"] = user.QTY;
			drow["STDD"] = user.STDD;
			drow["ENDD"] = user.ENDD;
			drow["ADDD"] = user.ADDD;
			drow["ADDBY"] = user.ADDBY;
			drow["ACNO"] = user.ACNO;
			drow["ISAN"] = user.ISAN;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
