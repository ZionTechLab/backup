using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_LaminatedMaterialSingle {
		#region Fields
		private string item1_ID;
		private string item2_ID;
		private decimal item1Width;
		private decimal item1Thickness;
		private string item1PolytheneType_ID;
		private string item1PolytheneMaterailType_ID;
		private string item1LaminationMaterailType_ID;
		private bool item1IsPrinted;
		private bool item1IsPolythene;
		private string item1Name;
		private string item1Polythene;
		private decimal item2Width;
		private decimal item2Thickness;
		private string item2PolytheneType_ID;
		private string item2PolytheneMaterailType_ID;
		private string item2LaminationMaterailType_ID;
		private bool item2IsPrinted;
		private bool item2IsPolythene;
		private string item2Name;
		private string itemName;
		private string item_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_LaminatedMaterialSingle class.
		/// </summary>
		public tbl_genItemMaster_LaminatedMaterialSingle() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_LaminatedMaterialSingle class.
		/// </summary>
		public tbl_genItemMaster_LaminatedMaterialSingle(string item1_ID, string item2_ID, decimal item1Width, decimal item1Thickness, string item1PolytheneType_ID, string item1PolytheneMaterailType_ID, string item1LaminationMaterailType_ID, bool item1IsPrinted, bool item1IsPolythene, string item1Name, string item1Polythene, decimal item2Width, decimal item2Thickness, string item2PolytheneType_ID, string item2PolytheneMaterailType_ID, string item2LaminationMaterailType_ID, bool item2IsPrinted, bool item2IsPolythene, string item2Name, string itemName, string item_ID) {
			this.item1_ID = item1_ID;
			this.item2_ID = item2_ID;
			this.item1Width = item1Width;
			this.item1Thickness = item1Thickness;
			this.item1PolytheneType_ID = item1PolytheneType_ID;
			this.item1PolytheneMaterailType_ID = item1PolytheneMaterailType_ID;
			this.item1LaminationMaterailType_ID = item1LaminationMaterailType_ID;
			this.item1IsPrinted = item1IsPrinted;
			this.item1IsPolythene = item1IsPolythene;
			this.item1Name = item1Name;
			this.item1Polythene = item1Polythene;
			this.item2Width = item2Width;
			this.item2Thickness = item2Thickness;
			this.item2PolytheneType_ID = item2PolytheneType_ID;
			this.item2PolytheneMaterailType_ID = item2PolytheneMaterailType_ID;
			this.item2LaminationMaterailType_ID = item2LaminationMaterailType_ID;
			this.item2IsPrinted = item2IsPrinted;
			this.item2IsPolythene = item2IsPolythene;
			this.item2Name = item2Name;
			this.itemName = itemName;
			this.item_ID = item_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Item1_ID value.
		/// </summary>
		public string Item1_ID {
			get { return item1_ID; }
			set { item1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2_ID value.
		/// </summary>
		public string Item2_ID {
			get { return item2_ID; }
			set { item2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1Width value.
		/// </summary>
		public decimal Item1Width {
			get { return item1Width; }
			set { item1Width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1Thickness value.
		/// </summary>
		public decimal Item1Thickness {
			get { return item1Thickness; }
			set { item1Thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1PolytheneType_ID value.
		/// </summary>
		public string Item1PolytheneType_ID {
			get { return item1PolytheneType_ID; }
			set { item1PolytheneType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1PolytheneMaterailType_ID value.
		/// </summary>
		public string Item1PolytheneMaterailType_ID {
			get { return item1PolytheneMaterailType_ID; }
			set { item1PolytheneMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1LaminationMaterailType_ID value.
		/// </summary>
		public string Item1LaminationMaterailType_ID {
			get { return item1LaminationMaterailType_ID; }
			set { item1LaminationMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1IsPrinted value.
		/// </summary>
		public bool Item1IsPrinted {
			get { return item1IsPrinted; }
			set { item1IsPrinted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1IsPolythene value.
		/// </summary>
		public bool Item1IsPolythene {
			get { return item1IsPolythene; }
			set { item1IsPolythene = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1Name value.
		/// </summary>
		public string Item1Name {
			get { return item1Name; }
			set { item1Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item1Polythene value.
		/// </summary>
		public string Item1Polythene {
			get { return item1Polythene; }
			set { item1Polythene = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2Width value.
		/// </summary>
		public decimal Item2Width {
			get { return item2Width; }
			set { item2Width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2Thickness value.
		/// </summary>
		public decimal Item2Thickness {
			get { return item2Thickness; }
			set { item2Thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2PolytheneType_ID value.
		/// </summary>
		public string Item2PolytheneType_ID {
			get { return item2PolytheneType_ID; }
			set { item2PolytheneType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2PolytheneMaterailType_ID value.
		/// </summary>
		public string Item2PolytheneMaterailType_ID {
			get { return item2PolytheneMaterailType_ID; }
			set { item2PolytheneMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2LaminationMaterailType_ID value.
		/// </summary>
		public string Item2LaminationMaterailType_ID {
			get { return item2LaminationMaterailType_ID; }
			set { item2LaminationMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2IsPrinted value.
		/// </summary>
		public bool Item2IsPrinted {
			get { return item2IsPrinted; }
			set { item2IsPrinted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2IsPolythene value.
		/// </summary>
		public bool Item2IsPolythene {
			get { return item2IsPolythene; }
			set { item2IsPolythene = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item2Name value.
		/// </summary>
		public string Item2Name {
			get { return item2Name; }
			set { item2Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_LaminatedMaterialSingle table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialSingleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item1Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item1Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item1PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item1IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item1Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item1Polythene", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item2Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item2Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item2PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item2IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item2Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@item1_ID"].Value = item1_ID;
			scom.Parameters["@item2_ID"].Value = item2_ID;
			scom.Parameters["@item1Width"].Value = item1Width;
			scom.Parameters["@item1Thickness"].Value = item1Thickness;
			scom.Parameters["@item1PolytheneType_ID"].Value = item1PolytheneType_ID;
			scom.Parameters["@item1PolytheneMaterailType_ID"].Value = item1PolytheneMaterailType_ID;
			scom.Parameters["@item1LaminationMaterailType_ID"].Value = item1LaminationMaterailType_ID;
			scom.Parameters["@item1IsPrinted"].Value = item1IsPrinted;
			scom.Parameters["@item1IsPolythene"].Value = item1IsPolythene;
			scom.Parameters["@item1Name"].Value = item1Name;
			scom.Parameters["@item1Polythene"].Value = item1Polythene;
			scom.Parameters["@item2Width"].Value = item2Width;
			scom.Parameters["@item2Thickness"].Value = item2Thickness;
			scom.Parameters["@item2PolytheneType_ID"].Value = item2PolytheneType_ID;
			scom.Parameters["@item2PolytheneMaterailType_ID"].Value = item2PolytheneMaterailType_ID;
			scom.Parameters["@item2LaminationMaterailType_ID"].Value = item2LaminationMaterailType_ID;
			scom.Parameters["@item2IsPrinted"].Value = item2IsPrinted;
			scom.Parameters["@item2IsPolythene"].Value = item2IsPolythene;
			scom.Parameters["@item2Name"].Value = item2Name;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_LaminatedMaterialSingle table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialSingleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item1Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item1Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item1PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item1IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item1Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item1Polythene", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item2Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item2Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item2PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item2IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item2Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@item1_ID"].Value = item1_ID;
			scom.Parameters["@item2_ID"].Value = item2_ID;
			scom.Parameters["@item1Width"].Value = item1Width;
			scom.Parameters["@item1Thickness"].Value = item1Thickness;
			scom.Parameters["@item1PolytheneType_ID"].Value = item1PolytheneType_ID;
			scom.Parameters["@item1PolytheneMaterailType_ID"].Value = item1PolytheneMaterailType_ID;
			scom.Parameters["@item1LaminationMaterailType_ID"].Value = item1LaminationMaterailType_ID;
			scom.Parameters["@item1IsPrinted"].Value = item1IsPrinted;
			scom.Parameters["@item1IsPolythene"].Value = item1IsPolythene;
			scom.Parameters["@item1Name"].Value = item1Name;
			scom.Parameters["@item1Polythene"].Value = item1Polythene;
			scom.Parameters["@item2Width"].Value = item2Width;
			scom.Parameters["@item2Thickness"].Value = item2Thickness;
			scom.Parameters["@item2PolytheneType_ID"].Value = item2PolytheneType_ID;
			scom.Parameters["@item2PolytheneMaterailType_ID"].Value = item2PolytheneMaterailType_ID;
			scom.Parameters["@item2LaminationMaterailType_ID"].Value = item2LaminationMaterailType_ID;
			scom.Parameters["@item2IsPrinted"].Value = item2IsPrinted;
			scom.Parameters["@item2IsPolythene"].Value = item2IsPolythene;
			scom.Parameters["@item2Name"].Value = item2Name;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_LaminatedMaterialSingle table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialSingleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item1_ID"].Value = item1_ID;
 
			scom.Parameters["@item2_ID"].Value = item2_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_LaminatedMaterialSingle table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem1_ID(string item1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialSingleDeleteAllByItem1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item1_ID"].Value = item1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_LaminatedMaterialSingle table.
		/// </summary>
		public static tbl_genItemMaster_LaminatedMaterialSingle Select(string item1_ID_Incoming, string item2_ID_Incoming){

			tbl_genItemMaster_LaminatedMaterialSingle tbl_genItemMaster_LaminatedMaterialSingleins = new tbl_genItemMaster_LaminatedMaterialSingle();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialSingleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item1_ID"].Value = item1_ID_Incoming;
			scom.Parameters["@item2_ID"].Value = item2_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_LaminatedMaterialSingleins = Maketbl_genItemMaster_LaminatedMaterialSingle(dataReader);
				} else {
					tbl_genItemMaster_LaminatedMaterialSingleins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_LaminatedMaterialSingleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_LaminatedMaterialSingle table.
		/// </summary>
		public static List<tbl_genItemMaster_LaminatedMaterialSingle> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialSingleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_LaminatedMaterialSingle> tbl_genItemMaster_LaminatedMaterialSingleList = new List<tbl_genItemMaster_LaminatedMaterialSingle>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_LaminatedMaterialSingle tbl_genItemMaster_LaminatedMaterialSingle = Maketbl_genItemMaster_LaminatedMaterialSingle(dataReader);
					tbl_genItemMaster_LaminatedMaterialSingleList.Add(tbl_genItemMaster_LaminatedMaterialSingle);
				}
			}
			scon.Close();
			return tbl_genItemMaster_LaminatedMaterialSingleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_LaminatedMaterialSingle table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_LaminatedMaterialSingle> SelectAllByItem1_ID(string item1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialSingleSelectAllByItem1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item1_ID"].Value = item1_ID;
				List<tbl_genItemMaster_LaminatedMaterialSingle> tbl_genItemMaster_LaminatedMaterialSingleList = new List<tbl_genItemMaster_LaminatedMaterialSingle>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_LaminatedMaterialSingle tbl_genItemMaster_LaminatedMaterialSingle = Maketbl_genItemMaster_LaminatedMaterialSingle(dataReader);
					tbl_genItemMaster_LaminatedMaterialSingleList.Add(tbl_genItemMaster_LaminatedMaterialSingle);
				}
			}
			scon.Close();
			return tbl_genItemMaster_LaminatedMaterialSingleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_LaminatedMaterialSingle class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_LaminatedMaterialSingle Maketbl_genItemMaster_LaminatedMaterialSingle(SqlDataReader dataReader) {
			tbl_genItemMaster_LaminatedMaterialSingle tbl_genItemMaster_LaminatedMaterialSingle = new tbl_genItemMaster_LaminatedMaterialSingle();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1Width = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1Thickness = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1PolytheneType_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1PolytheneMaterailType_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1LaminationMaterailType_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1IsPrinted = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1IsPolythene = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1Name = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item1Polythene = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2Width = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2Thickness = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2PolytheneType_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2PolytheneMaterailType_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2LaminationMaterailType_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2IsPrinted = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2IsPolythene = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item2Name = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.ItemName = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genItemMaster_LaminatedMaterialSingle.Item_ID = dataReader.GetString(20);
			}

			return tbl_genItemMaster_LaminatedMaterialSingle;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_LaminatedMaterialSingle datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_LaminatedMaterialSingle object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_LaminatedMaterialSingle  tbl_genItemMaster_LaminatedMaterialSingle   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item1_ID = new DataColumn("item1_ID" , typeof(string));
			DataColumn col_item2_ID = new DataColumn("item2_ID" , typeof(string));
			DataColumn col_item1Width = new DataColumn("item1Width" , typeof(decimal));
			DataColumn col_item1Thickness = new DataColumn("item1Thickness" , typeof(decimal));
			DataColumn col_item1PolytheneType_ID = new DataColumn("item1PolytheneType_ID" , typeof(string));
			DataColumn col_item1PolytheneMaterailType_ID = new DataColumn("item1PolytheneMaterailType_ID" , typeof(string));
			DataColumn col_item1LaminationMaterailType_ID = new DataColumn("item1LaminationMaterailType_ID" , typeof(string));
			DataColumn col_item1IsPrinted = new DataColumn("item1IsPrinted" , typeof(bool));
			DataColumn col_item1IsPolythene = new DataColumn("item1IsPolythene" , typeof(bool));
			DataColumn col_item1Name = new DataColumn("item1Name" , typeof(string));
			DataColumn col_item1Polythene = new DataColumn("item1Polythene" , typeof(string));
			DataColumn col_item2Width = new DataColumn("item2Width" , typeof(decimal));
			DataColumn col_item2Thickness = new DataColumn("item2Thickness" , typeof(decimal));
			DataColumn col_item2PolytheneType_ID = new DataColumn("item2PolytheneType_ID" , typeof(string));
			DataColumn col_item2PolytheneMaterailType_ID = new DataColumn("item2PolytheneMaterailType_ID" , typeof(string));
			DataColumn col_item2LaminationMaterailType_ID = new DataColumn("item2LaminationMaterailType_ID" , typeof(string));
			DataColumn col_item2IsPrinted = new DataColumn("item2IsPrinted" , typeof(bool));
			DataColumn col_item2IsPolythene = new DataColumn("item2IsPolythene" , typeof(bool));
			DataColumn col_item2Name = new DataColumn("item2Name" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_item1_ID,col_item2_ID,col_item1Width,col_item1Thickness,col_item1PolytheneType_ID,col_item1PolytheneMaterailType_ID,col_item1LaminationMaterailType_ID,col_item1IsPrinted,col_item1IsPolythene,col_item1Name,col_item1Polythene,col_item2Width,col_item2Thickness,col_item2PolytheneType_ID,col_item2PolytheneMaterailType_ID,col_item2LaminationMaterailType_ID,col_item2IsPrinted,col_item2IsPolythene,col_item2Name,col_itemName,col_item_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_LaminatedMaterialSingle datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_LaminatedMaterialSingle object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_LaminatedMaterialSingle user) {
		DataRow drow = dt.NewRow();
		
			drow["item1_ID"] = user.item1_ID;
			drow["item2_ID"] = user.item2_ID;
			drow["item1Width"] = user.item1Width;
			drow["item1Thickness"] = user.item1Thickness;
			drow["item1PolytheneType_ID"] = user.item1PolytheneType_ID;
			drow["item1PolytheneMaterailType_ID"] = user.item1PolytheneMaterailType_ID;
			drow["item1LaminationMaterailType_ID"] = user.item1LaminationMaterailType_ID;
			drow["item1IsPrinted"] = user.item1IsPrinted;
			drow["item1IsPolythene"] = user.item1IsPolythene;
			drow["item1Name"] = user.item1Name;
			drow["item1Polythene"] = user.item1Polythene;
			drow["item2Width"] = user.item2Width;
			drow["item2Thickness"] = user.item2Thickness;
			drow["item2PolytheneType_ID"] = user.item2PolytheneType_ID;
			drow["item2PolytheneMaterailType_ID"] = user.item2PolytheneMaterailType_ID;
			drow["item2LaminationMaterailType_ID"] = user.item2LaminationMaterailType_ID;
			drow["item2IsPrinted"] = user.item2IsPrinted;
			drow["item2IsPolythene"] = user.item2IsPolythene;
			drow["item2Name"] = user.item2Name;
			drow["itemName"] = user.itemName;
			drow["item_ID"] = user.item_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
