using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemType {
		#region Fields
		private string itemType_ID;
		private string typeName;
		private string itemClass_ID;
		private string prefrix;
		private int typeCounter;
		private int typeLength;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemType class.
		/// </summary>
		public tbl_zItemType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemType class.
		/// </summary>
		public tbl_zItemType(string itemType_ID, string typeName, string itemClass_ID, string prefrix, int typeCounter, int typeLength) {
			this.itemType_ID = itemType_ID;
			this.typeName = typeName;
			this.itemClass_ID = itemClass_ID;
			this.prefrix = prefrix;
			this.typeCounter = typeCounter;
			this.typeLength = typeLength;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemType_ID value.
		/// </summary>
		public string ItemType_ID {
			get { return itemType_ID; }
			set { itemType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemClass_ID value.
		/// </summary>
		public string ItemClass_ID {
			get { return itemClass_ID; }
			set { itemClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix value.
		/// </summary>
		public string Prefrix {
			get { return prefrix; }
			set { prefrix = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeCounter value.
		/// </summary>
		public int TypeCounter {
			get { return typeCounter; }
			set { typeCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeLength value.
		/// </summary>
		public int TypeLength {
			get { return typeLength; }
			set { typeLength = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@typeLength", SqlDbType.Int,4);
 
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@typeName"].Value = typeName;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@prefrix"].Value = prefrix;
			scom.Parameters["@typeCounter"].Value = typeCounter;
			scom.Parameters["@typeLength"].Value = typeLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@typeLength", SqlDbType.Int,4);
 
 
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@typeName"].Value = typeName;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@prefrix"].Value = prefrix;
			scom.Parameters["@typeCounter"].Value = typeCounter;
			scom.Parameters["@typeLength"].Value = typeLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemType table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemClass_ID(string itemClass_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTypeDeleteAllByItemClass_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemType table.
		/// </summary>
		public static tbl_zItemType Select(string itemType_ID_Incoming){

			tbl_zItemType tbl_zItemTypeins = new tbl_zItemType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemType_ID"].Value = itemType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemTypeins = Maketbl_zItemType(dataReader);
				} else {
					tbl_zItemTypeins = null;
				}
			}
			scon.Close();
			return tbl_zItemTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemType table.
		/// </summary>
		public static List<tbl_zItemType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemType> tbl_zItemTypeList = new List<tbl_zItemType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemType tbl_zItemType = Maketbl_zItemType(dataReader);
					tbl_zItemTypeList.Add(tbl_zItemType);
				}
			}
			scon.Close();
			return tbl_zItemTypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemType table by a foreign key.
		/// </summary>
		public static List<tbl_zItemType> SelectAllByItemClass_ID(string itemClass_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTypeSelectAllByItemClass_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
				List<tbl_zItemType> tbl_zItemTypeList = new List<tbl_zItemType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemType tbl_zItemType = Maketbl_zItemType(dataReader);
					tbl_zItemTypeList.Add(tbl_zItemType);
				}
			}
			scon.Close();
			return tbl_zItemTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemType Maketbl_zItemType(SqlDataReader dataReader) {
			tbl_zItemType tbl_zItemType = new tbl_zItemType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemType.ItemType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemType.TypeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemType.ItemClass_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zItemType.Prefrix = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zItemType.TypeCounter = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zItemType.TypeLength = dataReader.GetInt32(5);
			}

			return tbl_zItemType;
		}
		/// <summary>
		/// This makes tbl_zItemType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemType  tbl_zItemType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemType_ID = new DataColumn("itemType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
			DataColumn col_itemClass_ID = new DataColumn("itemClass_ID" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
			DataColumn col_typeCounter = new DataColumn("typeCounter" , typeof(int));
			DataColumn col_typeLength = new DataColumn("typeLength" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_itemType_ID,col_typeName,col_itemClass_ID,col_prefrix,col_typeCounter,col_typeLength,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemType user) {
		DataRow drow = dt.NewRow();
		
			drow["itemType_ID"] = user.itemType_ID;
			drow["typeName"] = user.typeName;
			drow["itemClass_ID"] = user.itemClass_ID;
			drow["prefrix"] = user.prefrix;
			drow["typeCounter"] = user.typeCounter;
			drow["typeLength"] = user.typeLength;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
