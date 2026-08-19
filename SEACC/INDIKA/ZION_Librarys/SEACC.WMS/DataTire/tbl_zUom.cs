using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zUom {
		#region Fields
		private string uom_ID;
		private string uomName;
		private string uomCategory_ID;
		private string uomCode;
		private bool isVisible;
		private bool isForSales;
		private bool isForPacking;
		private bool isForKiloCalculation;
		private bool isForBagCalculation;
		private bool isQty;
		private bool isWeight;
		private bool isLength;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zUom class.
		/// </summary>
		public tbl_zUom() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zUom class.
		/// </summary>
		public tbl_zUom(string uom_ID, string uomName, string uomCategory_ID, string uomCode, bool isVisible, bool isForSales, bool isForPacking, bool isForKiloCalculation, bool isForBagCalculation, bool isQty, bool isWeight, bool isLength) {
			this.uom_ID = uom_ID;
			this.uomName = uomName;
			this.uomCategory_ID = uomCategory_ID;
			this.uomCode = uomCode;
			this.isVisible = isVisible;
			this.isForSales = isForSales;
			this.isForPacking = isForPacking;
			this.isForKiloCalculation = isForKiloCalculation;
			this.isForBagCalculation = isForBagCalculation;
			this.isQty = isQty;
			this.isWeight = isWeight;
			this.isLength = isLength;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomName value.
		/// </summary>
		public string UomName {
			get { return uomName; }
			set { uomName = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomCategory_ID value.
		/// </summary>
		public string UomCategory_ID {
			get { return uomCategory_ID; }
			set { uomCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomCode value.
		/// </summary>
		public string UomCode {
			get { return uomCode; }
			set { uomCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVisible value.
		/// </summary>
		public bool IsVisible {
			get { return isVisible; }
			set { isVisible = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForSales value.
		/// </summary>
		public bool IsForSales {
			get { return isForSales; }
			set { isForSales = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForPacking value.
		/// </summary>
		public bool IsForPacking {
			get { return isForPacking; }
			set { isForPacking = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForKiloCalculation value.
		/// </summary>
		public bool IsForKiloCalculation {
			get { return isForKiloCalculation; }
			set { isForKiloCalculation = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForBagCalculation value.
		/// </summary>
		public bool IsForBagCalculation {
			get { return isForBagCalculation; }
			set { isForBagCalculation = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsQty value.
		/// </summary>
		public bool IsQty {
			get { return isQty; }
			set { isQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeight value.
		/// </summary>
		public bool IsWeight {
			get { return isWeight; }
			set { isWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLength value.
		/// </summary>
		public bool IsLength {
			get { return isLength; }
			set { isLength = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zUom table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uomName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uomCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uomCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isVisible", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForSales", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForPacking", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForKiloCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForBagCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isQty", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeight", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLength", SqlDbType.Bit,1);
 
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uomName"].Value = uomName;
			scom.Parameters["@uomCategory_ID"].Value = uomCategory_ID;
			scom.Parameters["@uomCode"].Value = uomCode;
			scom.Parameters["@isVisible"].Value = isVisible;
			scom.Parameters["@isForSales"].Value = isForSales;
			scom.Parameters["@isForPacking"].Value = isForPacking;
			scom.Parameters["@isForKiloCalculation"].Value = isForKiloCalculation;
			scom.Parameters["@isForBagCalculation"].Value = isForBagCalculation;
			scom.Parameters["@isQty"].Value = isQty;
			scom.Parameters["@isWeight"].Value = isWeight;
			scom.Parameters["@isLength"].Value = isLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zUom table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uomName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uomCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uomCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isVisible", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForSales", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForPacking", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForKiloCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForBagCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isQty", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeight", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLength", SqlDbType.Bit,1);
 
 
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uomName"].Value = uomName;
			scom.Parameters["@uomCategory_ID"].Value = uomCategory_ID;
			scom.Parameters["@uomCode"].Value = uomCode;
			scom.Parameters["@isVisible"].Value = isVisible;
			scom.Parameters["@isForSales"].Value = isForSales;
			scom.Parameters["@isForPacking"].Value = isForPacking;
			scom.Parameters["@isForKiloCalculation"].Value = isForKiloCalculation;
			scom.Parameters["@isForBagCalculation"].Value = isForBagCalculation;
			scom.Parameters["@isQty"].Value = isQty;
			scom.Parameters["@isWeight"].Value = isWeight;
			scom.Parameters["@isLength"].Value = isLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zUom table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zUom table by a foreign key.
		/// </summary>
		public static void DeleteAllByUomCategory_ID(string uomCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomDeleteAllByUomCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uomCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uomCategory_ID"].Value = uomCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zUom table.
		/// </summary>
		public static tbl_zUom Select(string uom_ID_Incoming){

			tbl_zUom tbl_zUomins = new tbl_zUom();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zUomins = Maketbl_zUom(dataReader);
				} else {
					tbl_zUomins = null;
				}
			}
			scon.Close();
			return tbl_zUomins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zUom table.
		/// </summary>
		public static List<tbl_zUom> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zUom> tbl_zUomList = new List<tbl_zUom>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zUom tbl_zUom = Maketbl_zUom(dataReader);
					tbl_zUomList.Add(tbl_zUom);
				}
			}
			scon.Close();
			return tbl_zUomList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zUom table by a foreign key.
		/// </summary>
		public static List<tbl_zUom> SelectAllByUomCategory_ID(string uomCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomSelectAllByUomCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uomCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uomCategory_ID"].Value = uomCategory_ID;
				List<tbl_zUom> tbl_zUomList = new List<tbl_zUom>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zUom tbl_zUom = Maketbl_zUom(dataReader);
					tbl_zUomList.Add(tbl_zUom);
				}
			}
			scon.Close();
			return tbl_zUomList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zUom class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zUom Maketbl_zUom(SqlDataReader dataReader) {
			tbl_zUom tbl_zUom = new tbl_zUom();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zUom.Uom_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zUom.UomName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zUom.UomCategory_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zUom.UomCode = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zUom.IsVisible = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zUom.IsForSales = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zUom.IsForPacking = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zUom.IsForKiloCalculation = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zUom.IsForBagCalculation = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zUom.IsQty = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_zUom.IsWeight = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_zUom.IsLength = dataReader.GetBoolean(11);
			}

			return tbl_zUom;
		}
		/// <summary>
		/// This makes tbl_zUom datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zUom object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zUom  tbl_zUom   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_uomName = new DataColumn("uomName" , typeof(string));
			DataColumn col_uomCategory_ID = new DataColumn("uomCategory_ID" , typeof(string));
			DataColumn col_uomCode = new DataColumn("uomCode" , typeof(string));
			DataColumn col_isVisible = new DataColumn("isVisible" , typeof(bool));
			DataColumn col_isForSales = new DataColumn("isForSales" , typeof(bool));
			DataColumn col_isForPacking = new DataColumn("isForPacking" , typeof(bool));
			DataColumn col_isForKiloCalculation = new DataColumn("isForKiloCalculation" , typeof(bool));
			DataColumn col_isForBagCalculation = new DataColumn("isForBagCalculation" , typeof(bool));
			DataColumn col_isQty = new DataColumn("isQty" , typeof(bool));
			DataColumn col_isWeight = new DataColumn("isWeight" , typeof(bool));
			DataColumn col_isLength = new DataColumn("isLength" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_uom_ID,col_uomName,col_uomCategory_ID,col_uomCode,col_isVisible,col_isForSales,col_isForPacking,col_isForKiloCalculation,col_isForBagCalculation,col_isQty,col_isWeight,col_isLength,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zUom datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zUom object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zUom user) {
		DataRow drow = dt.NewRow();
		
			drow["uom_ID"] = user.uom_ID;
			drow["uomName"] = user.uomName;
			drow["uomCategory_ID"] = user.uomCategory_ID;
			drow["uomCode"] = user.uomCode;
			drow["isVisible"] = user.isVisible;
			drow["isForSales"] = user.isForSales;
			drow["isForPacking"] = user.isForPacking;
			drow["isForKiloCalculation"] = user.isForKiloCalculation;
			drow["isForBagCalculation"] = user.isForBagCalculation;
			drow["isQty"] = user.isQty;
			drow["isWeight"] = user.isWeight;
			drow["isLength"] = user.isLength;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
