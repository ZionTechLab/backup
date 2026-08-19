using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_CombinationMaterail {
		#region Fields
		private decimal width;
		private decimal thickness;
		private string polytheneType_ID;
		private string polytheneMaterailType_ID;
		private string laminationMaterailType_ID;
		private bool isPrinted;
		private string item_ID;
		private string itemName;
		private bool isLamination;
		private bool isPolythine;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_CombinationMaterail class.
		/// </summary>
		public tbl_genItemMaster_CombinationMaterail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_CombinationMaterail class.
		/// </summary>
		public tbl_genItemMaster_CombinationMaterail(decimal width, decimal thickness, string polytheneType_ID, string polytheneMaterailType_ID, string laminationMaterailType_ID, bool isPrinted, string item_ID, string itemName, bool isLamination, bool isPolythine) {
			this.width = width;
			this.thickness = thickness;
			this.polytheneType_ID = polytheneType_ID;
			this.polytheneMaterailType_ID = polytheneMaterailType_ID;
			this.laminationMaterailType_ID = laminationMaterailType_ID;
			this.isPrinted = isPrinted;
			this.item_ID = item_ID;
			this.itemName = itemName;
			this.isLamination = isLamination;
			this.isPolythine = isPolythine;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Width value.
		/// </summary>
		public decimal Width {
			get { return width; }
			set { width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Thickness value.
		/// </summary>
		public decimal Thickness {
			get { return thickness; }
			set { thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the PolytheneType_ID value.
		/// </summary>
		public string PolytheneType_ID {
			get { return polytheneType_ID; }
			set { polytheneType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PolytheneMaterailType_ID value.
		/// </summary>
		public string PolytheneMaterailType_ID {
			get { return polytheneMaterailType_ID; }
			set { polytheneMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LaminationMaterailType_ID value.
		/// </summary>
		public string LaminationMaterailType_ID {
			get { return laminationMaterailType_ID; }
			set { laminationMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPrinted value.
		/// </summary>
		public bool IsPrinted {
			get { return isPrinted; }
			set { isPrinted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLamination value.
		/// </summary>
		public bool IsLamination {
			get { return isLamination; }
			set { isLamination = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPolythine value.
		/// </summary>
		public bool IsPolythine {
			get { return isPolythine; }
			set { isPolythine = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_CombinationMaterail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isLamination", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPolythine", SqlDbType.Bit,1);
 
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
			scom.Parameters["@isPrinted"].Value = isPrinted;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@isLamination"].Value = isLamination;
			scom.Parameters["@isPolythine"].Value = isPolythine;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_CombinationMaterail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isLamination", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPolythine", SqlDbType.Bit,1);
 
 
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
			scom.Parameters["@isPrinted"].Value = isPrinted;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@isLamination"].Value = isLamination;
			scom.Parameters["@isPolythine"].Value = isPolythine;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_CombinationMaterail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table by a foreign key.
		/// </summary>
		public static void DeleteAllByLaminationMaterailType_ID(string laminationMaterailType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailDeleteAllByLaminationMaterailType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPolytheneType_ID(string polytheneType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailDeleteAllByPolytheneType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPolytheneMaterailType_ID(string polytheneMaterailType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailDeleteAllByPolytheneMaterailType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_CombinationMaterail table.
		/// </summary>
		public static tbl_genItemMaster_CombinationMaterail Select(string item_ID_Incoming){

			tbl_genItemMaster_CombinationMaterail tbl_genItemMaster_CombinationMaterailins = new tbl_genItemMaster_CombinationMaterail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_CombinationMaterailins = Maketbl_genItemMaster_CombinationMaterail(dataReader);
				} else {
					tbl_genItemMaster_CombinationMaterailins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_CombinationMaterailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table.
		/// </summary>
		public static List<tbl_genItemMaster_CombinationMaterail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_CombinationMaterail> tbl_genItemMaster_CombinationMaterailList = new List<tbl_genItemMaster_CombinationMaterail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_CombinationMaterail tbl_genItemMaster_CombinationMaterail = Maketbl_genItemMaster_CombinationMaterail(dataReader);
					tbl_genItemMaster_CombinationMaterailList.Add(tbl_genItemMaster_CombinationMaterail);
				}
			}
			scon.Close();
			return tbl_genItemMaster_CombinationMaterailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_CombinationMaterail> SelectAllByLaminationMaterailType_ID(string laminationMaterailType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailSelectAllByLaminationMaterailType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
				List<tbl_genItemMaster_CombinationMaterail> tbl_genItemMaster_CombinationMaterailList = new List<tbl_genItemMaster_CombinationMaterail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_CombinationMaterail tbl_genItemMaster_CombinationMaterail = Maketbl_genItemMaster_CombinationMaterail(dataReader);
					tbl_genItemMaster_CombinationMaterailList.Add(tbl_genItemMaster_CombinationMaterail);
				}
			}
			scon.Close();
			return tbl_genItemMaster_CombinationMaterailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_CombinationMaterail> SelectAllByPolytheneType_ID(string polytheneType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailSelectAllByPolytheneType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
				List<tbl_genItemMaster_CombinationMaterail> tbl_genItemMaster_CombinationMaterailList = new List<tbl_genItemMaster_CombinationMaterail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_CombinationMaterail tbl_genItemMaster_CombinationMaterail = Maketbl_genItemMaster_CombinationMaterail(dataReader);
					tbl_genItemMaster_CombinationMaterailList.Add(tbl_genItemMaster_CombinationMaterail);
				}
			}
			scon.Close();
			return tbl_genItemMaster_CombinationMaterailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_CombinationMaterail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_CombinationMaterail> tbl_genItemMaster_CombinationMaterailList = new List<tbl_genItemMaster_CombinationMaterail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_CombinationMaterail tbl_genItemMaster_CombinationMaterail = Maketbl_genItemMaster_CombinationMaterail(dataReader);
					tbl_genItemMaster_CombinationMaterailList.Add(tbl_genItemMaster_CombinationMaterail);
				}
			}
			scon.Close();
			return tbl_genItemMaster_CombinationMaterailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_CombinationMaterail table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_CombinationMaterail> SelectAllByPolytheneMaterailType_ID(string polytheneMaterailType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_CombinationMaterailSelectAllByPolytheneMaterailType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
				List<tbl_genItemMaster_CombinationMaterail> tbl_genItemMaster_CombinationMaterailList = new List<tbl_genItemMaster_CombinationMaterail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_CombinationMaterail tbl_genItemMaster_CombinationMaterail = Maketbl_genItemMaster_CombinationMaterail(dataReader);
					tbl_genItemMaster_CombinationMaterailList.Add(tbl_genItemMaster_CombinationMaterail);
				}
			}
			scon.Close();
			return tbl_genItemMaster_CombinationMaterailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_CombinationMaterail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_CombinationMaterail Maketbl_genItemMaster_CombinationMaterail(SqlDataReader dataReader) {
			tbl_genItemMaster_CombinationMaterail tbl_genItemMaster_CombinationMaterail = new tbl_genItemMaster_CombinationMaterail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_CombinationMaterail.Width = dataReader.GetDecimal(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_CombinationMaterail.Thickness = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_CombinationMaterail.PolytheneType_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_CombinationMaterail.PolytheneMaterailType_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_CombinationMaterail.LaminationMaterailType_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_CombinationMaterail.IsPrinted = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_CombinationMaterail.Item_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_CombinationMaterail.ItemName = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_CombinationMaterail.IsLamination = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster_CombinationMaterail.IsPolythine = dataReader.GetBoolean(9);
			}

			return tbl_genItemMaster_CombinationMaterail;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_CombinationMaterail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_CombinationMaterail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_CombinationMaterail  tbl_genItemMaster_CombinationMaterail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_thickness = new DataColumn("thickness" , typeof(decimal));
			DataColumn col_polytheneType_ID = new DataColumn("polytheneType_ID" , typeof(string));
			DataColumn col_polytheneMaterailType_ID = new DataColumn("polytheneMaterailType_ID" , typeof(string));
			DataColumn col_laminationMaterailType_ID = new DataColumn("laminationMaterailType_ID" , typeof(string));
			DataColumn col_isPrinted = new DataColumn("isPrinted" , typeof(bool));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_isLamination = new DataColumn("isLamination" , typeof(bool));
			DataColumn col_isPolythine = new DataColumn("isPolythine" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_width,col_thickness,col_polytheneType_ID,col_polytheneMaterailType_ID,col_laminationMaterailType_ID,col_isPrinted,col_item_ID,col_itemName,col_isLamination,col_isPolythine,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_CombinationMaterail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_CombinationMaterail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_CombinationMaterail user) {
		DataRow drow = dt.NewRow();
		
			drow["width"] = user.width;
			drow["thickness"] = user.thickness;
			drow["polytheneType_ID"] = user.polytheneType_ID;
			drow["polytheneMaterailType_ID"] = user.polytheneMaterailType_ID;
			drow["laminationMaterailType_ID"] = user.laminationMaterailType_ID;
			drow["isPrinted"] = user.isPrinted;
			drow["item_ID"] = user.item_ID;
			drow["itemName"] = user.itemName;
			drow["isLamination"] = user.isLamination;
			drow["isPolythine"] = user.isPolythine;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
