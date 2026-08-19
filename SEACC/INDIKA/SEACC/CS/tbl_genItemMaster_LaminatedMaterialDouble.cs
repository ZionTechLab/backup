using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_LaminatedMaterialDouble {
		#region Fields
		private string item1_ID;
		private string item2_ID;
		private string item3_ID;
		private decimal item1Width;
		private decimal item1Thickness;
		private string item1PolytheneType_ID;
		private string item1PolytheneMaterailType_ID;
		private string item1LaminationMaterailType_ID;
		private bool item1IsPrinted;
		private bool item1IsPolythene;
		private string item1Name;
		private decimal item2Width;
		private decimal item2Thickness;
		private string item2PolytheneType_ID;
		private string item2PolytheneMaterailType_ID;
		private string item2LaminationMaterailType_ID;
		private bool item2IsPrinted;
		private bool item2IsPolythene;
		private string item2Name;
		private decimal item3Width;
		private decimal item3Thickness;
		private string item3PolytheneType_ID;
		private string item3PolytheneMaterailType_ID;
		private string item3LaminationMaterailType_ID;
		private bool item3IsPrinted;
		private bool item3IsPolythene;
		private string item3Name;
		private string itemName;
		private string item_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_LaminatedMaterialDouble class.
		/// </summary>
		public tbl_genItemMaster_LaminatedMaterialDouble() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_LaminatedMaterialDouble class.
		/// </summary>
		public tbl_genItemMaster_LaminatedMaterialDouble(string item1_ID, string item2_ID, string item3_ID, decimal item1Width, decimal item1Thickness, string item1PolytheneType_ID, string item1PolytheneMaterailType_ID, string item1LaminationMaterailType_ID, bool item1IsPrinted, bool item1IsPolythene, string item1Name, decimal item2Width, decimal item2Thickness, string item2PolytheneType_ID, string item2PolytheneMaterailType_ID, string item2LaminationMaterailType_ID, bool item2IsPrinted, bool item2IsPolythene, string item2Name, decimal item3Width, decimal item3Thickness, string item3PolytheneType_ID, string item3PolytheneMaterailType_ID, string item3LaminationMaterailType_ID, bool item3IsPrinted, bool item3IsPolythene, string item3Name, string itemName, string item_ID) {
			this.item1_ID = item1_ID;
			this.item2_ID = item2_ID;
			this.item3_ID = item3_ID;
			this.item1Width = item1Width;
			this.item1Thickness = item1Thickness;
			this.item1PolytheneType_ID = item1PolytheneType_ID;
			this.item1PolytheneMaterailType_ID = item1PolytheneMaterailType_ID;
			this.item1LaminationMaterailType_ID = item1LaminationMaterailType_ID;
			this.item1IsPrinted = item1IsPrinted;
			this.item1IsPolythene = item1IsPolythene;
			this.item1Name = item1Name;
			this.item2Width = item2Width;
			this.item2Thickness = item2Thickness;
			this.item2PolytheneType_ID = item2PolytheneType_ID;
			this.item2PolytheneMaterailType_ID = item2PolytheneMaterailType_ID;
			this.item2LaminationMaterailType_ID = item2LaminationMaterailType_ID;
			this.item2IsPrinted = item2IsPrinted;
			this.item2IsPolythene = item2IsPolythene;
			this.item2Name = item2Name;
			this.item3Width = item3Width;
			this.item3Thickness = item3Thickness;
			this.item3PolytheneType_ID = item3PolytheneType_ID;
			this.item3PolytheneMaterailType_ID = item3PolytheneMaterailType_ID;
			this.item3LaminationMaterailType_ID = item3LaminationMaterailType_ID;
			this.item3IsPrinted = item3IsPrinted;
			this.item3IsPolythene = item3IsPolythene;
			this.item3Name = item3Name;
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
		/// Gets or sets the Item3_ID value.
		/// </summary>
		public string Item3_ID {
			get { return item3_ID; }
			set { item3_ID = value; }
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
		/// Gets or sets the Item3Width value.
		/// </summary>
		public decimal Item3Width {
			get { return item3Width; }
			set { item3Width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item3Thickness value.
		/// </summary>
		public decimal Item3Thickness {
			get { return item3Thickness; }
			set { item3Thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item3PolytheneType_ID value.
		/// </summary>
		public string Item3PolytheneType_ID {
			get { return item3PolytheneType_ID; }
			set { item3PolytheneType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item3PolytheneMaterailType_ID value.
		/// </summary>
		public string Item3PolytheneMaterailType_ID {
			get { return item3PolytheneMaterailType_ID; }
			set { item3PolytheneMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item3LaminationMaterailType_ID value.
		/// </summary>
		public string Item3LaminationMaterailType_ID {
			get { return item3LaminationMaterailType_ID; }
			set { item3LaminationMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item3IsPrinted value.
		/// </summary>
		public bool Item3IsPrinted {
			get { return item3IsPrinted; }
			set { item3IsPrinted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item3IsPolythene value.
		/// </summary>
		public bool Item3IsPolythene {
			get { return item3IsPolythene; }
			set { item3IsPolythene = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item3Name value.
		/// </summary>
		public string Item3Name {
			get { return item3Name; }
			set { item3Name = value; }
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
		/// Saves a record to the tbl_genItemMaster_LaminatedMaterialDouble table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialDoubleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item3_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item1Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item1Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item1PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item1IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item1Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item2Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item2Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item2PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item2IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item2Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item3Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item3Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item3PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item3PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item3LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item3IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item3IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item3Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@item1_ID"].Value = item1_ID;
			scom.Parameters["@item2_ID"].Value = item2_ID;
			scom.Parameters["@item3_ID"].Value = item3_ID;
			scom.Parameters["@item1Width"].Value = item1Width;
			scom.Parameters["@item1Thickness"].Value = item1Thickness;
			scom.Parameters["@item1PolytheneType_ID"].Value = item1PolytheneType_ID;
			scom.Parameters["@item1PolytheneMaterailType_ID"].Value = item1PolytheneMaterailType_ID;
			scom.Parameters["@item1LaminationMaterailType_ID"].Value = item1LaminationMaterailType_ID;
			scom.Parameters["@item1IsPrinted"].Value = item1IsPrinted;
			scom.Parameters["@item1IsPolythene"].Value = item1IsPolythene;
			scom.Parameters["@item1Name"].Value = item1Name;
			scom.Parameters["@item2Width"].Value = item2Width;
			scom.Parameters["@item2Thickness"].Value = item2Thickness;
			scom.Parameters["@item2PolytheneType_ID"].Value = item2PolytheneType_ID;
			scom.Parameters["@item2PolytheneMaterailType_ID"].Value = item2PolytheneMaterailType_ID;
			scom.Parameters["@item2LaminationMaterailType_ID"].Value = item2LaminationMaterailType_ID;
			scom.Parameters["@item2IsPrinted"].Value = item2IsPrinted;
			scom.Parameters["@item2IsPolythene"].Value = item2IsPolythene;
			scom.Parameters["@item2Name"].Value = item2Name;
			scom.Parameters["@item3Width"].Value = item3Width;
			scom.Parameters["@item3Thickness"].Value = item3Thickness;
			scom.Parameters["@item3PolytheneType_ID"].Value = item3PolytheneType_ID;
			scom.Parameters["@item3PolytheneMaterailType_ID"].Value = item3PolytheneMaterailType_ID;
			scom.Parameters["@item3LaminationMaterailType_ID"].Value = item3LaminationMaterailType_ID;
			scom.Parameters["@item3IsPrinted"].Value = item3IsPrinted;
			scom.Parameters["@item3IsPolythene"].Value = item3IsPolythene;
			scom.Parameters["@item3Name"].Value = item3Name;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_LaminatedMaterialDouble table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialDoubleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item3_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item1Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item1Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item1PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item1IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item1IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item1Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item2Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item2Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item2PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item2IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item2IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item2Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item3Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item3Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item3PolytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item3PolytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item3LaminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item3IsPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item3IsPolythene", SqlDbType.Bit,1);
			scom.Parameters.Add("@item3Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@item1_ID"].Value = item1_ID;
			scom.Parameters["@item2_ID"].Value = item2_ID;
			scom.Parameters["@item3_ID"].Value = item3_ID;
			scom.Parameters["@item1Width"].Value = item1Width;
			scom.Parameters["@item1Thickness"].Value = item1Thickness;
			scom.Parameters["@item1PolytheneType_ID"].Value = item1PolytheneType_ID;
			scom.Parameters["@item1PolytheneMaterailType_ID"].Value = item1PolytheneMaterailType_ID;
			scom.Parameters["@item1LaminationMaterailType_ID"].Value = item1LaminationMaterailType_ID;
			scom.Parameters["@item1IsPrinted"].Value = item1IsPrinted;
			scom.Parameters["@item1IsPolythene"].Value = item1IsPolythene;
			scom.Parameters["@item1Name"].Value = item1Name;
			scom.Parameters["@item2Width"].Value = item2Width;
			scom.Parameters["@item2Thickness"].Value = item2Thickness;
			scom.Parameters["@item2PolytheneType_ID"].Value = item2PolytheneType_ID;
			scom.Parameters["@item2PolytheneMaterailType_ID"].Value = item2PolytheneMaterailType_ID;
			scom.Parameters["@item2LaminationMaterailType_ID"].Value = item2LaminationMaterailType_ID;
			scom.Parameters["@item2IsPrinted"].Value = item2IsPrinted;
			scom.Parameters["@item2IsPolythene"].Value = item2IsPolythene;
			scom.Parameters["@item2Name"].Value = item2Name;
			scom.Parameters["@item3Width"].Value = item3Width;
			scom.Parameters["@item3Thickness"].Value = item3Thickness;
			scom.Parameters["@item3PolytheneType_ID"].Value = item3PolytheneType_ID;
			scom.Parameters["@item3PolytheneMaterailType_ID"].Value = item3PolytheneMaterailType_ID;
			scom.Parameters["@item3LaminationMaterailType_ID"].Value = item3LaminationMaterailType_ID;
			scom.Parameters["@item3IsPrinted"].Value = item3IsPrinted;
			scom.Parameters["@item3IsPolythene"].Value = item3IsPolythene;
			scom.Parameters["@item3Name"].Value = item3Name;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_LaminatedMaterialDouble table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialDoubleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item3_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item1_ID"].Value = item1_ID;
 
			scom.Parameters["@item2_ID"].Value = item2_ID;
 
			scom.Parameters["@item3_ID"].Value = item3_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_LaminatedMaterialDouble table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem1_ID(string item1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialDoubleDeleteAllByItem1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item1_ID"].Value = item1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_LaminatedMaterialDouble table.
		/// </summary>
		public static tbl_genItemMaster_LaminatedMaterialDouble Select(string item1_ID_Incoming, string item2_ID_Incoming, string item3_ID_Incoming){

			tbl_genItemMaster_LaminatedMaterialDouble tbl_genItemMaster_LaminatedMaterialDoubleins = new tbl_genItemMaster_LaminatedMaterialDouble();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialDoubleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item3_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item1_ID"].Value = item1_ID_Incoming;
			scom.Parameters["@item2_ID"].Value = item2_ID_Incoming;
			scom.Parameters["@item3_ID"].Value = item3_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_LaminatedMaterialDoubleins = Maketbl_genItemMaster_LaminatedMaterialDouble(dataReader);
				} else {
					tbl_genItemMaster_LaminatedMaterialDoubleins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_LaminatedMaterialDoubleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_LaminatedMaterialDouble table.
		/// </summary>
		public static List<tbl_genItemMaster_LaminatedMaterialDouble> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialDoubleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_LaminatedMaterialDouble> tbl_genItemMaster_LaminatedMaterialDoubleList = new List<tbl_genItemMaster_LaminatedMaterialDouble>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_LaminatedMaterialDouble tbl_genItemMaster_LaminatedMaterialDouble = Maketbl_genItemMaster_LaminatedMaterialDouble(dataReader);
					tbl_genItemMaster_LaminatedMaterialDoubleList.Add(tbl_genItemMaster_LaminatedMaterialDouble);
				}
			}
			scon.Close();
			return tbl_genItemMaster_LaminatedMaterialDoubleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_LaminatedMaterialDouble table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_LaminatedMaterialDouble> SelectAllByItem1_ID(string item1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_LaminatedMaterialDoubleSelectAllByItem1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item1_ID"].Value = item1_ID;
				List<tbl_genItemMaster_LaminatedMaterialDouble> tbl_genItemMaster_LaminatedMaterialDoubleList = new List<tbl_genItemMaster_LaminatedMaterialDouble>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_LaminatedMaterialDouble tbl_genItemMaster_LaminatedMaterialDouble = Maketbl_genItemMaster_LaminatedMaterialDouble(dataReader);
					tbl_genItemMaster_LaminatedMaterialDoubleList.Add(tbl_genItemMaster_LaminatedMaterialDouble);
				}
			}
			scon.Close();
			return tbl_genItemMaster_LaminatedMaterialDoubleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_LaminatedMaterialDouble class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_LaminatedMaterialDouble Maketbl_genItemMaster_LaminatedMaterialDouble(SqlDataReader dataReader) {
			tbl_genItemMaster_LaminatedMaterialDouble tbl_genItemMaster_LaminatedMaterialDouble = new tbl_genItemMaster_LaminatedMaterialDouble();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1Width = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1Thickness = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1PolytheneType_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1PolytheneMaterailType_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1LaminationMaterailType_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1IsPrinted = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1IsPolythene = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item1Name = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2Width = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2Thickness = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2PolytheneType_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2PolytheneMaterailType_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2LaminationMaterailType_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2IsPrinted = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2IsPolythene = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item2Name = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3Width = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3Thickness = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3PolytheneType_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3PolytheneMaterailType_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3LaminationMaterailType_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3IsPrinted = dataReader.GetBoolean(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3IsPolythene = dataReader.GetBoolean(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item3Name = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.ItemName = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_genItemMaster_LaminatedMaterialDouble.Item_ID = dataReader.GetString(28);
			}

			return tbl_genItemMaster_LaminatedMaterialDouble;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_LaminatedMaterialDouble datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_LaminatedMaterialDouble object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_LaminatedMaterialDouble  tbl_genItemMaster_LaminatedMaterialDouble   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item1_ID = new DataColumn("item1_ID" , typeof(string));
			DataColumn col_item2_ID = new DataColumn("item2_ID" , typeof(string));
			DataColumn col_item3_ID = new DataColumn("item3_ID" , typeof(string));
			DataColumn col_item1Width = new DataColumn("item1Width" , typeof(decimal));
			DataColumn col_item1Thickness = new DataColumn("item1Thickness" , typeof(decimal));
			DataColumn col_item1PolytheneType_ID = new DataColumn("item1PolytheneType_ID" , typeof(string));
			DataColumn col_item1PolytheneMaterailType_ID = new DataColumn("item1PolytheneMaterailType_ID" , typeof(string));
			DataColumn col_item1LaminationMaterailType_ID = new DataColumn("item1LaminationMaterailType_ID" , typeof(string));
			DataColumn col_item1IsPrinted = new DataColumn("item1IsPrinted" , typeof(bool));
			DataColumn col_item1IsPolythene = new DataColumn("item1IsPolythene" , typeof(bool));
			DataColumn col_item1Name = new DataColumn("item1Name" , typeof(string));
			DataColumn col_item2Width = new DataColumn("item2Width" , typeof(decimal));
			DataColumn col_item2Thickness = new DataColumn("item2Thickness" , typeof(decimal));
			DataColumn col_item2PolytheneType_ID = new DataColumn("item2PolytheneType_ID" , typeof(string));
			DataColumn col_item2PolytheneMaterailType_ID = new DataColumn("item2PolytheneMaterailType_ID" , typeof(string));
			DataColumn col_item2LaminationMaterailType_ID = new DataColumn("item2LaminationMaterailType_ID" , typeof(string));
			DataColumn col_item2IsPrinted = new DataColumn("item2IsPrinted" , typeof(bool));
			DataColumn col_item2IsPolythene = new DataColumn("item2IsPolythene" , typeof(bool));
			DataColumn col_item2Name = new DataColumn("item2Name" , typeof(string));
			DataColumn col_item3Width = new DataColumn("item3Width" , typeof(decimal));
			DataColumn col_item3Thickness = new DataColumn("item3Thickness" , typeof(decimal));
			DataColumn col_item3PolytheneType_ID = new DataColumn("item3PolytheneType_ID" , typeof(string));
			DataColumn col_item3PolytheneMaterailType_ID = new DataColumn("item3PolytheneMaterailType_ID" , typeof(string));
			DataColumn col_item3LaminationMaterailType_ID = new DataColumn("item3LaminationMaterailType_ID" , typeof(string));
			DataColumn col_item3IsPrinted = new DataColumn("item3IsPrinted" , typeof(bool));
			DataColumn col_item3IsPolythene = new DataColumn("item3IsPolythene" , typeof(bool));
			DataColumn col_item3Name = new DataColumn("item3Name" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_item1_ID,col_item2_ID,col_item3_ID,col_item1Width,col_item1Thickness,col_item1PolytheneType_ID,col_item1PolytheneMaterailType_ID,col_item1LaminationMaterailType_ID,col_item1IsPrinted,col_item1IsPolythene,col_item1Name,col_item2Width,col_item2Thickness,col_item2PolytheneType_ID,col_item2PolytheneMaterailType_ID,col_item2LaminationMaterailType_ID,col_item2IsPrinted,col_item2IsPolythene,col_item2Name,col_item3Width,col_item3Thickness,col_item3PolytheneType_ID,col_item3PolytheneMaterailType_ID,col_item3LaminationMaterailType_ID,col_item3IsPrinted,col_item3IsPolythene,col_item3Name,col_itemName,col_item_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_LaminatedMaterialDouble datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_LaminatedMaterialDouble object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_LaminatedMaterialDouble user) {
		DataRow drow = dt.NewRow();
		
			drow["item1_ID"] = user.item1_ID;
			drow["item2_ID"] = user.item2_ID;
			drow["item3_ID"] = user.item3_ID;
			drow["item1Width"] = user.item1Width;
			drow["item1Thickness"] = user.item1Thickness;
			drow["item1PolytheneType_ID"] = user.item1PolytheneType_ID;
			drow["item1PolytheneMaterailType_ID"] = user.item1PolytheneMaterailType_ID;
			drow["item1LaminationMaterailType_ID"] = user.item1LaminationMaterailType_ID;
			drow["item1IsPrinted"] = user.item1IsPrinted;
			drow["item1IsPolythene"] = user.item1IsPolythene;
			drow["item1Name"] = user.item1Name;
			drow["item2Width"] = user.item2Width;
			drow["item2Thickness"] = user.item2Thickness;
			drow["item2PolytheneType_ID"] = user.item2PolytheneType_ID;
			drow["item2PolytheneMaterailType_ID"] = user.item2PolytheneMaterailType_ID;
			drow["item2LaminationMaterailType_ID"] = user.item2LaminationMaterailType_ID;
			drow["item2IsPrinted"] = user.item2IsPrinted;
			drow["item2IsPolythene"] = user.item2IsPolythene;
			drow["item2Name"] = user.item2Name;
			drow["item3Width"] = user.item3Width;
			drow["item3Thickness"] = user.item3Thickness;
			drow["item3PolytheneType_ID"] = user.item3PolytheneType_ID;
			drow["item3PolytheneMaterailType_ID"] = user.item3PolytheneMaterailType_ID;
			drow["item3LaminationMaterailType_ID"] = user.item3LaminationMaterailType_ID;
			drow["item3IsPrinted"] = user.item3IsPrinted;
			drow["item3IsPolythene"] = user.item3IsPolythene;
			drow["item3Name"] = user.item3Name;
			drow["itemName"] = user.itemName;
			drow["item_ID"] = user.item_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
