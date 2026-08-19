using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemTag3 {
		#region Fields
		private string tag3_ID;
		private string description;
		private string remark;
		private string prefix;
		private string prefrix2;
		private decimal length;
		private string uom_ID_length;
		private decimal width;
		private string uom_ID_width;
		private decimal height;
		private string uom_ID_height;
		private decimal diameter;
		private string uom_ID_diameter;
		private decimal radius;
		private string uom_ID_radius;
		private decimal thickness;
		private string uom_ID_thickness;
		private decimal weight;
		private string uom_ID_weight;
		private bool isDeleted;
		private bool isWidthComesFirst;
		private bool isLengthComesFirst;
		private bool isDiameterComesFirst;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemTag3 class.
		/// </summary>
		public tbl_zItemTag3() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemTag3 class.
		/// </summary>
		public tbl_zItemTag3(string tag3_ID, string description, string remark, string prefix, string prefrix2, decimal length, string uom_ID_length, decimal width, string uom_ID_width, decimal height, string uom_ID_height, decimal diameter, string uom_ID_diameter, decimal radius, string uom_ID_radius, decimal thickness, string uom_ID_thickness, decimal weight, string uom_ID_weight, bool isDeleted, bool isWidthComesFirst, bool isLengthComesFirst, bool isDiameterComesFirst) {
			this.tag3_ID = tag3_ID;
			this.description = description;
			this.remark = remark;
			this.prefix = prefix;
			this.prefrix2 = prefrix2;
			this.length = length;
			this.uom_ID_length = uom_ID_length;
			this.width = width;
			this.uom_ID_width = uom_ID_width;
			this.height = height;
			this.uom_ID_height = uom_ID_height;
			this.diameter = diameter;
			this.uom_ID_diameter = uom_ID_diameter;
			this.radius = radius;
			this.uom_ID_radius = uom_ID_radius;
			this.thickness = thickness;
			this.uom_ID_thickness = uom_ID_thickness;
			this.weight = weight;
			this.uom_ID_weight = uom_ID_weight;
			this.isDeleted = isDeleted;
			this.isWidthComesFirst = isWidthComesFirst;
			this.isLengthComesFirst = isLengthComesFirst;
			this.isDiameterComesFirst = isDiameterComesFirst;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tag3_ID value.
		/// </summary>
		public string Tag3_ID {
			get { return tag3_ID; }
			set { tag3_ID = value; }
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
		/// Gets or sets the Length value.
		/// </summary>
		public decimal Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_length value.
		/// </summary>
		public string Uom_ID_length {
			get { return uom_ID_length; }
			set { uom_ID_length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Width value.
		/// </summary>
		public decimal Width {
			get { return width; }
			set { width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_width value.
		/// </summary>
		public string Uom_ID_width {
			get { return uom_ID_width; }
			set { uom_ID_width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Height value.
		/// </summary>
		public decimal Height {
			get { return height; }
			set { height = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_height value.
		/// </summary>
		public string Uom_ID_height {
			get { return uom_ID_height; }
			set { uom_ID_height = value; }
		}
		
		/// <summary>
		/// Gets or sets the Diameter value.
		/// </summary>
		public decimal Diameter {
			get { return diameter; }
			set { diameter = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_diameter value.
		/// </summary>
		public string Uom_ID_diameter {
			get { return uom_ID_diameter; }
			set { uom_ID_diameter = value; }
		}
		
		/// <summary>
		/// Gets or sets the Radius value.
		/// </summary>
		public decimal Radius {
			get { return radius; }
			set { radius = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_radius value.
		/// </summary>
		public string Uom_ID_radius {
			get { return uom_ID_radius; }
			set { uom_ID_radius = value; }
		}
		
		/// <summary>
		/// Gets or sets the Thickness value.
		/// </summary>
		public decimal Thickness {
			get { return thickness; }
			set { thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_thickness value.
		/// </summary>
		public string Uom_ID_thickness {
			get { return uom_ID_thickness; }
			set { uom_ID_thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_weight value.
		/// </summary>
		public string Uom_ID_weight {
			get { return uom_ID_weight; }
			set { uom_ID_weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWidthComesFirst value.
		/// </summary>
		public bool IsWidthComesFirst {
			get { return isWidthComesFirst; }
			set { isWidthComesFirst = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLengthComesFirst value.
		/// </summary>
		public bool IsLengthComesFirst {
			get { return isLengthComesFirst; }
			set { isLengthComesFirst = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDiameterComesFirst value.
		/// </summary>
		public bool IsDiameterComesFirst {
			get { return isDiameterComesFirst; }
			set { isDiameterComesFirst = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemTag3 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tag3_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_length", SqlDbType.VarChar,10);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_width", SqlDbType.VarChar,10);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_height", SqlDbType.VarChar,10);
			scom.Parameters.Add("@diameter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_diameter", SqlDbType.VarChar,10);
			scom.Parameters.Add("@radius", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_radius", SqlDbType.VarChar,10);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_thickness", SqlDbType.VarChar,10);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWidthComesFirst", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLengthComesFirst", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDiameterComesFirst", SqlDbType.Bit,1);
 
			scom.Parameters["@tag3_ID"].Value = tag3_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@uom_ID_length"].Value = uom_ID_length;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@uom_ID_width"].Value = uom_ID_width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@uom_ID_height"].Value = uom_ID_height;
			scom.Parameters["@diameter"].Value = diameter;
			scom.Parameters["@uom_ID_diameter"].Value = uom_ID_diameter;
			scom.Parameters["@radius"].Value = radius;
			scom.Parameters["@uom_ID_radius"].Value = uom_ID_radius;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@uom_ID_thickness"].Value = uom_ID_thickness;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@uom_ID_weight"].Value = uom_ID_weight;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isWidthComesFirst"].Value = isWidthComesFirst;
			scom.Parameters["@isLengthComesFirst"].Value = isLengthComesFirst;
			scom.Parameters["@isDiameterComesFirst"].Value = isDiameterComesFirst;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemTag3 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tag3_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_length", SqlDbType.VarChar,10);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_width", SqlDbType.VarChar,10);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_height", SqlDbType.VarChar,10);
			scom.Parameters.Add("@diameter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_diameter", SqlDbType.VarChar,10);
			scom.Parameters.Add("@radius", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_radius", SqlDbType.VarChar,10);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_thickness", SqlDbType.VarChar,10);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWidthComesFirst", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLengthComesFirst", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDiameterComesFirst", SqlDbType.Bit,1);
 
 
			scom.Parameters["@tag3_ID"].Value = tag3_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@uom_ID_length"].Value = uom_ID_length;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@uom_ID_width"].Value = uom_ID_width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@uom_ID_height"].Value = uom_ID_height;
			scom.Parameters["@diameter"].Value = diameter;
			scom.Parameters["@uom_ID_diameter"].Value = uom_ID_diameter;
			scom.Parameters["@radius"].Value = radius;
			scom.Parameters["@uom_ID_radius"].Value = uom_ID_radius;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@uom_ID_thickness"].Value = uom_ID_thickness;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@uom_ID_weight"].Value = uom_ID_weight;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isWidthComesFirst"].Value = isWidthComesFirst;
			scom.Parameters["@isLengthComesFirst"].Value = isLengthComesFirst;
			scom.Parameters["@isDiameterComesFirst"].Value = isDiameterComesFirst;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemTag3 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tag3_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag3_ID"].Value = tag3_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID_radius(string uom_ID_radius) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3DeleteAllByUom_ID_radius", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID_radius", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_radius"].Value = uom_ID_radius;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID_diameter(string uom_ID_diameter) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3DeleteAllByUom_ID_diameter", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID_diameter", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_diameter"].Value = uom_ID_diameter;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID_length(string uom_ID_length) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3DeleteAllByUom_ID_length", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID_length", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_length"].Value = uom_ID_length;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID_height(string uom_ID_height) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3DeleteAllByUom_ID_height", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID_height", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_height"].Value = uom_ID_height;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID_weight(string uom_ID_weight) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3DeleteAllByUom_ID_weight", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID_weight", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_weight"].Value = uom_ID_weight;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID_width(string uom_ID_width) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3DeleteAllByUom_ID_width", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID_width", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_width"].Value = uom_ID_width;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID_thickness(string uom_ID_thickness) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3DeleteAllByUom_ID_thickness", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID_thickness", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_thickness"].Value = uom_ID_thickness;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemTag3 table.
		/// </summary>
		public static tbl_zItemTag3 Select(string tag3_ID_Incoming){

			tbl_zItemTag3 tbl_zItemTag3ins = new tbl_zItemTag3();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tag3_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag3_ID"].Value = tag3_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemTag3ins = Maketbl_zItemTag3(dataReader);
				} else {
					tbl_zItemTag3ins = null;
				}
			}
			scon.Close();
			return tbl_zItemTag3ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table.
		/// </summary>
		public static List<tbl_zItemTag3> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemTag3> tbl_zItemTag3List = new List<tbl_zItemTag3>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag3 tbl_zItemTag3 = Maketbl_zItemTag3(dataReader);
					tbl_zItemTag3List.Add(tbl_zItemTag3);
				}
			}
			scon.Close();
			return tbl_zItemTag3List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static List<tbl_zItemTag3> SelectAllByUom_ID_radius(string uom_ID_radius) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3SelectAllByUom_ID_radius", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_radius", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_radius"].Value = uom_ID_radius;
				List<tbl_zItemTag3> tbl_zItemTag3List = new List<tbl_zItemTag3>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag3 tbl_zItemTag3 = Maketbl_zItemTag3(dataReader);
					tbl_zItemTag3List.Add(tbl_zItemTag3);
				}
			}
			scon.Close();
			return tbl_zItemTag3List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static List<tbl_zItemTag3> SelectAllByUom_ID_diameter(string uom_ID_diameter) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3SelectAllByUom_ID_diameter", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_diameter", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_diameter"].Value = uom_ID_diameter;
				List<tbl_zItemTag3> tbl_zItemTag3List = new List<tbl_zItemTag3>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag3 tbl_zItemTag3 = Maketbl_zItemTag3(dataReader);
					tbl_zItemTag3List.Add(tbl_zItemTag3);
				}
			}
			scon.Close();
			return tbl_zItemTag3List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static List<tbl_zItemTag3> SelectAllByUom_ID_length(string uom_ID_length) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3SelectAllByUom_ID_length", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_length", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_length"].Value = uom_ID_length;
				List<tbl_zItemTag3> tbl_zItemTag3List = new List<tbl_zItemTag3>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag3 tbl_zItemTag3 = Maketbl_zItemTag3(dataReader);
					tbl_zItemTag3List.Add(tbl_zItemTag3);
				}
			}
			scon.Close();
			return tbl_zItemTag3List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static List<tbl_zItemTag3> SelectAllByUom_ID_height(string uom_ID_height) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3SelectAllByUom_ID_height", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_height", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_height"].Value = uom_ID_height;
				List<tbl_zItemTag3> tbl_zItemTag3List = new List<tbl_zItemTag3>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag3 tbl_zItemTag3 = Maketbl_zItemTag3(dataReader);
					tbl_zItemTag3List.Add(tbl_zItemTag3);
				}
			}
			scon.Close();
			return tbl_zItemTag3List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static List<tbl_zItemTag3> SelectAllByUom_ID_weight(string uom_ID_weight) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3SelectAllByUom_ID_weight", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_weight", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_weight"].Value = uom_ID_weight;
				List<tbl_zItemTag3> tbl_zItemTag3List = new List<tbl_zItemTag3>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag3 tbl_zItemTag3 = Maketbl_zItemTag3(dataReader);
					tbl_zItemTag3List.Add(tbl_zItemTag3);
				}
			}
			scon.Close();
			return tbl_zItemTag3List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static List<tbl_zItemTag3> SelectAllByUom_ID_width(string uom_ID_width) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3SelectAllByUom_ID_width", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_width", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_width"].Value = uom_ID_width;
				List<tbl_zItemTag3> tbl_zItemTag3List = new List<tbl_zItemTag3>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag3 tbl_zItemTag3 = Maketbl_zItemTag3(dataReader);
					tbl_zItemTag3List.Add(tbl_zItemTag3);
				}
			}
			scon.Close();
			return tbl_zItemTag3List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemTag3 table by a foreign key.
		/// </summary>
		public static List<tbl_zItemTag3> SelectAllByUom_ID_thickness(string uom_ID_thickness) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemTag3SelectAllByUom_ID_thickness", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID_thickness", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID_thickness"].Value = uom_ID_thickness;
				List<tbl_zItemTag3> tbl_zItemTag3List = new List<tbl_zItemTag3>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemTag3 tbl_zItemTag3 = Maketbl_zItemTag3(dataReader);
					tbl_zItemTag3List.Add(tbl_zItemTag3);
				}
			}
			scon.Close();
			return tbl_zItemTag3List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemTag3 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemTag3 Maketbl_zItemTag3(SqlDataReader dataReader) {
			tbl_zItemTag3 tbl_zItemTag3 = new tbl_zItemTag3();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemTag3.Tag3_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemTag3.Description = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemTag3.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zItemTag3.Prefix = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zItemTag3.Prefrix2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zItemTag3.Length = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zItemTag3.Uom_ID_length = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zItemTag3.Width = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zItemTag3.Uom_ID_width = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zItemTag3.Height = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_zItemTag3.Uom_ID_height = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_zItemTag3.Diameter = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_zItemTag3.Uom_ID_diameter = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_zItemTag3.Radius = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_zItemTag3.Uom_ID_radius = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_zItemTag3.Thickness = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_zItemTag3.Uom_ID_thickness = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_zItemTag3.Weight = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_zItemTag3.Uom_ID_weight = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_zItemTag3.IsDeleted = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_zItemTag3.IsWidthComesFirst = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_zItemTag3.IsLengthComesFirst = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_zItemTag3.IsDiameterComesFirst = dataReader.GetBoolean(22);
			}

			return tbl_zItemTag3;
		}
		/// <summary>
		/// This makes tbl_zItemTag3 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemTag3 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemTag3  tbl_zItemTag3   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tag3_ID = new DataColumn("tag3_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_prefrix2 = new DataColumn("prefrix2" , typeof(string));
			DataColumn col_length = new DataColumn("length" , typeof(decimal));
			DataColumn col_uom_ID_length = new DataColumn("uom_ID_length" , typeof(string));
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_uom_ID_width = new DataColumn("uom_ID_width" , typeof(string));
			DataColumn col_height = new DataColumn("height" , typeof(decimal));
			DataColumn col_uom_ID_height = new DataColumn("uom_ID_height" , typeof(string));
			DataColumn col_diameter = new DataColumn("diameter" , typeof(decimal));
			DataColumn col_uom_ID_diameter = new DataColumn("uom_ID_diameter" , typeof(string));
			DataColumn col_radius = new DataColumn("radius" , typeof(decimal));
			DataColumn col_uom_ID_radius = new DataColumn("uom_ID_radius" , typeof(string));
			DataColumn col_thickness = new DataColumn("thickness" , typeof(decimal));
			DataColumn col_uom_ID_thickness = new DataColumn("uom_ID_thickness" , typeof(string));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_uom_ID_weight = new DataColumn("uom_ID_weight" , typeof(string));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isWidthComesFirst = new DataColumn("isWidthComesFirst" , typeof(bool));
			DataColumn col_isLengthComesFirst = new DataColumn("isLengthComesFirst" , typeof(bool));
			DataColumn col_isDiameterComesFirst = new DataColumn("isDiameterComesFirst" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_tag3_ID,col_description,col_remark,col_prefix,col_prefrix2,col_length,col_uom_ID_length,col_width,col_uom_ID_width,col_height,col_uom_ID_height,col_diameter,col_uom_ID_diameter,col_radius,col_uom_ID_radius,col_thickness,col_uom_ID_thickness,col_weight,col_uom_ID_weight,col_isDeleted,col_isWidthComesFirst,col_isLengthComesFirst,col_isDiameterComesFirst,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemTag3 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemTag3 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemTag3 user) {
		DataRow drow = dt.NewRow();
		
			drow["tag3_ID"] = user.tag3_ID;
			drow["description"] = user.description;
			drow["remark"] = user.remark;
			drow["prefix"] = user.prefix;
			drow["prefrix2"] = user.prefrix2;
			drow["length"] = user.length;
			drow["uom_ID_length"] = user.uom_ID_length;
			drow["width"] = user.width;
			drow["uom_ID_width"] = user.uom_ID_width;
			drow["height"] = user.height;
			drow["uom_ID_height"] = user.uom_ID_height;
			drow["diameter"] = user.diameter;
			drow["uom_ID_diameter"] = user.uom_ID_diameter;
			drow["radius"] = user.radius;
			drow["uom_ID_radius"] = user.uom_ID_radius;
			drow["thickness"] = user.thickness;
			drow["uom_ID_thickness"] = user.uom_ID_thickness;
			drow["weight"] = user.weight;
			drow["uom_ID_weight"] = user.uom_ID_weight;
			drow["isDeleted"] = user.isDeleted;
			drow["isWidthComesFirst"] = user.isWidthComesFirst;
			drow["isLengthComesFirst"] = user.isLengthComesFirst;
			drow["isDiameterComesFirst"] = user.isDiameterComesFirst;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
