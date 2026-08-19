using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsDepartmentGoodReceiveNote_Detail {
		#region Fields
		private int line_No;
		private string departmentGoodReceiveNote_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string job_ID;
		private string fromSelectArea_ID;
		private string fromDepartment_ID;
		private string fromSection_ID;
		private string fromStore_ID;
		private string toDepartment_ID;
		private string departmentGoodIssueNote_ID;
		private string sectionGoodIssueNote_ID;
		private string storeGoodIssueNote_ID;
		private string uom_ID;
		private decimal width;
		private decimal length;
		private decimal height;
		private decimal gauge;
		private decimal gusset;
		private decimal qty;
		private decimal weight;
		private decimal weightActual;
		private string remark;
		private bool isLocked;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsDepartmentGoodReceiveNote_Detail class.
		/// </summary>
		public tbl_scsDepartmentGoodReceiveNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsDepartmentGoodReceiveNote_Detail class.
		/// </summary>
		public tbl_scsDepartmentGoodReceiveNote_Detail(int line_No, string departmentGoodReceiveNote_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string job_ID, string fromSelectArea_ID, string fromDepartment_ID, string fromSection_ID, string fromStore_ID, string toDepartment_ID, string departmentGoodIssueNote_ID, string sectionGoodIssueNote_ID, string storeGoodIssueNote_ID, string uom_ID, decimal width, decimal length, decimal height, decimal gauge, decimal gusset, decimal qty, decimal weight, decimal weightActual, string remark, bool isLocked) {
			this.line_No = line_No;
			this.departmentGoodReceiveNote_ID = departmentGoodReceiveNote_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.job_ID = job_ID;
			this.fromSelectArea_ID = fromSelectArea_ID;
			this.fromDepartment_ID = fromDepartment_ID;
			this.fromSection_ID = fromSection_ID;
			this.fromStore_ID = fromStore_ID;
			this.toDepartment_ID = toDepartment_ID;
			this.departmentGoodIssueNote_ID = departmentGoodIssueNote_ID;
			this.sectionGoodIssueNote_ID = sectionGoodIssueNote_ID;
			this.storeGoodIssueNote_ID = storeGoodIssueNote_ID;
			this.uom_ID = uom_ID;
			this.width = width;
			this.length = length;
			this.height = height;
			this.gauge = gauge;
			this.gusset = gusset;
			this.qty = qty;
			this.weight = weight;
			this.weightActual = weightActual;
			this.remark = remark;
			this.isLocked = isLocked;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepartmentGoodReceiveNote_ID value.
		/// </summary>
		public string DepartmentGoodReceiveNote_ID {
			get { return departmentGoodReceiveNote_ID; }
			set { departmentGoodReceiveNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID {
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo2 value.
		/// </summary>
		public string ItemSerialNo2 {
			get { return itemSerialNo2; }
			set { itemSerialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromSelectArea_ID value.
		/// </summary>
		public string FromSelectArea_ID {
			get { return fromSelectArea_ID; }
			set { fromSelectArea_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromDepartment_ID value.
		/// </summary>
		public string FromDepartment_ID {
			get { return fromDepartment_ID; }
			set { fromDepartment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromSection_ID value.
		/// </summary>
		public string FromSection_ID {
			get { return fromSection_ID; }
			set { fromSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromStore_ID value.
		/// </summary>
		public string FromStore_ID {
			get { return fromStore_ID; }
			set { fromStore_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToDepartment_ID value.
		/// </summary>
		public string ToDepartment_ID {
			get { return toDepartment_ID; }
			set { toDepartment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepartmentGoodIssueNote_ID value.
		/// </summary>
		public string DepartmentGoodIssueNote_ID {
			get { return departmentGoodIssueNote_ID; }
			set { departmentGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionGoodIssueNote_ID value.
		/// </summary>
		public string SectionGoodIssueNote_ID {
			get { return sectionGoodIssueNote_ID; }
			set { sectionGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreGoodIssueNote_ID value.
		/// </summary>
		public string StoreGoodIssueNote_ID {
			get { return storeGoodIssueNote_ID; }
			set { storeGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Width value.
		/// </summary>
		public decimal Width {
			get { return width; }
			set { width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public decimal Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Height value.
		/// </summary>
		public decimal Height {
			get { return height; }
			set { height = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gauge value.
		/// </summary>
		public decimal Gauge {
			get { return gauge; }
			set { gauge = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gusset value.
		/// </summary>
		public decimal Gusset {
			get { return gusset; }
			set { gusset = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightActual value.
		/// </summary>
		public decimal WeightActual {
			get { return weightActual; }
			set { weightActual = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsDepartmentGoodReceiveNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@departmentGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fromDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,30);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gauge", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightActual", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@departmentGoodReceiveNote_ID"].Value = departmentGoodReceiveNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
			scom.Parameters["@fromDepartment_ID"].Value = fromDepartment_ID;
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@gauge"].Value = gauge;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightActual"].Value = weightActual;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsDepartmentGoodReceiveNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@departmentGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fromDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,30);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gauge", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightActual", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@departmentGoodReceiveNote_ID"].Value = departmentGoodReceiveNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
			scom.Parameters["@fromDepartment_ID"].Value = fromDepartment_ID;
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@gauge"].Value = gauge;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightActual"].Value = weightActual;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsDepartmentGoodReceiveNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@departmentGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@departmentGoodReceiveNote_ID"].Value = departmentGoodReceiveNote_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByToDepartment_ID(string toDepartment_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailDeleteAllByToDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByDepartmentGoodReceiveNote_ID(string departmentGoodReceiveNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailDeleteAllByDepartmentGoodReceiveNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@departmentGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@departmentGoodReceiveNote_ID"].Value = departmentGoodReceiveNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByFromSelectArea_ID(string fromSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailDeleteAllByFromSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsDepartmentGoodReceiveNote_Detail table.
		/// </summary>
		public static tbl_scsDepartmentGoodReceiveNote_Detail Select(int line_No_Incoming, string departmentGoodReceiveNote_ID_Incoming, string item_ID_Incoming){

			tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detailins = new tbl_scsDepartmentGoodReceiveNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@departmentGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@departmentGoodReceiveNote_ID"].Value = departmentGoodReceiveNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detailins = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
				} else {
					tbl_scsDepartmentGoodReceiveNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table.
		/// </summary>
		public static List<tbl_scsDepartmentGoodReceiveNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsDepartmentGoodReceiveNote_Detail> tbl_scsDepartmentGoodReceiveNote_DetailList = new List<tbl_scsDepartmentGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
					tbl_scsDepartmentGoodReceiveNote_DetailList.Add(tbl_scsDepartmentGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodReceiveNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsDepartmentGoodReceiveNote_Detail> tbl_scsDepartmentGoodReceiveNote_DetailList = new List<tbl_scsDepartmentGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
					tbl_scsDepartmentGoodReceiveNote_DetailList.Add(tbl_scsDepartmentGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodReceiveNote_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_scsDepartmentGoodReceiveNote_Detail> tbl_scsDepartmentGoodReceiveNote_DetailList = new List<tbl_scsDepartmentGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
					tbl_scsDepartmentGoodReceiveNote_DetailList.Add(tbl_scsDepartmentGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodReceiveNote_Detail> SelectAllByToDepartment_ID(string toDepartment_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelectAllByToDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
				List<tbl_scsDepartmentGoodReceiveNote_Detail> tbl_scsDepartmentGoodReceiveNote_DetailList = new List<tbl_scsDepartmentGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
					tbl_scsDepartmentGoodReceiveNote_DetailList.Add(tbl_scsDepartmentGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodReceiveNote_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_scsDepartmentGoodReceiveNote_Detail> tbl_scsDepartmentGoodReceiveNote_DetailList = new List<tbl_scsDepartmentGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
					tbl_scsDepartmentGoodReceiveNote_DetailList.Add(tbl_scsDepartmentGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodReceiveNote_Detail> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_scsDepartmentGoodReceiveNote_Detail> tbl_scsDepartmentGoodReceiveNote_DetailList = new List<tbl_scsDepartmentGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
					tbl_scsDepartmentGoodReceiveNote_DetailList.Add(tbl_scsDepartmentGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodReceiveNote_Detail> SelectAllByDepartmentGoodReceiveNote_ID(string departmentGoodReceiveNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelectAllByDepartmentGoodReceiveNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@departmentGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@departmentGoodReceiveNote_ID"].Value = departmentGoodReceiveNote_ID;
				List<tbl_scsDepartmentGoodReceiveNote_Detail> tbl_scsDepartmentGoodReceiveNote_DetailList = new List<tbl_scsDepartmentGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
					tbl_scsDepartmentGoodReceiveNote_DetailList.Add(tbl_scsDepartmentGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodReceiveNote_Detail> SelectAllByFromSelectArea_ID(string fromSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodReceiveNote_DetailSelectAllByFromSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
				List<tbl_scsDepartmentGoodReceiveNote_Detail> tbl_scsDepartmentGoodReceiveNote_DetailList = new List<tbl_scsDepartmentGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = Maketbl_scsDepartmentGoodReceiveNote_Detail(dataReader);
					tbl_scsDepartmentGoodReceiveNote_DetailList.Add(tbl_scsDepartmentGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsDepartmentGoodReceiveNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsDepartmentGoodReceiveNote_Detail Maketbl_scsDepartmentGoodReceiveNote_Detail(SqlDataReader dataReader) {
			tbl_scsDepartmentGoodReceiveNote_Detail tbl_scsDepartmentGoodReceiveNote_Detail = new tbl_scsDepartmentGoodReceiveNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.DepartmentGoodReceiveNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Job_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.FromSelectArea_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.FromDepartment_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.FromSection_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.FromStore_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.ToDepartment_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.DepartmentGoodIssueNote_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.SectionGoodIssueNote_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.StoreGoodIssueNote_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Uom_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Width = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Length = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Height = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Gauge = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Gusset = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Qty = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Weight = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.WeightActual = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.Remark = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsDepartmentGoodReceiveNote_Detail.IsLocked = dataReader.GetBoolean(26);
			}

			return tbl_scsDepartmentGoodReceiveNote_Detail;
		}
		/// <summary>
		/// This makes tbl_scsDepartmentGoodReceiveNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsDepartmentGoodReceiveNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsDepartmentGoodReceiveNote_Detail  tbl_scsDepartmentGoodReceiveNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_departmentGoodReceiveNote_ID = new DataColumn("departmentGoodReceiveNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_fromSelectArea_ID = new DataColumn("fromSelectArea_ID" , typeof(string));
			DataColumn col_fromDepartment_ID = new DataColumn("fromDepartment_ID" , typeof(string));
			DataColumn col_fromSection_ID = new DataColumn("fromSection_ID" , typeof(string));
			DataColumn col_fromStore_ID = new DataColumn("fromStore_ID" , typeof(string));
			DataColumn col_toDepartment_ID = new DataColumn("toDepartment_ID" , typeof(string));
			DataColumn col_departmentGoodIssueNote_ID = new DataColumn("departmentGoodIssueNote_ID" , typeof(string));
			DataColumn col_sectionGoodIssueNote_ID = new DataColumn("sectionGoodIssueNote_ID" , typeof(string));
			DataColumn col_storeGoodIssueNote_ID = new DataColumn("storeGoodIssueNote_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_length = new DataColumn("length" , typeof(decimal));
			DataColumn col_height = new DataColumn("height" , typeof(decimal));
			DataColumn col_gauge = new DataColumn("gauge" , typeof(decimal));
			DataColumn col_gusset = new DataColumn("gusset" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightActual = new DataColumn("weightActual" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_departmentGoodReceiveNote_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_job_ID,col_fromSelectArea_ID,col_fromDepartment_ID,col_fromSection_ID,col_fromStore_ID,col_toDepartment_ID,col_departmentGoodIssueNote_ID,col_sectionGoodIssueNote_ID,col_storeGoodIssueNote_ID,col_uom_ID,col_width,col_length,col_height,col_gauge,col_gusset,col_qty,col_weight,col_weightActual,col_remark,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsDepartmentGoodReceiveNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsDepartmentGoodReceiveNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsDepartmentGoodReceiveNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["departmentGoodReceiveNote_ID"] = user.departmentGoodReceiveNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["job_ID"] = user.job_ID;
			drow["fromSelectArea_ID"] = user.fromSelectArea_ID;
			drow["fromDepartment_ID"] = user.fromDepartment_ID;
			drow["fromSection_ID"] = user.fromSection_ID;
			drow["fromStore_ID"] = user.fromStore_ID;
			drow["toDepartment_ID"] = user.toDepartment_ID;
			drow["departmentGoodIssueNote_ID"] = user.departmentGoodIssueNote_ID;
			drow["sectionGoodIssueNote_ID"] = user.sectionGoodIssueNote_ID;
			drow["storeGoodIssueNote_ID"] = user.storeGoodIssueNote_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["width"] = user.width;
			drow["length"] = user.length;
			drow["height"] = user.height;
			drow["gauge"] = user.gauge;
			drow["gusset"] = user.gusset;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["weightActual"] = user.weightActual;
			drow["remark"] = user.remark;
			drow["isLocked"] = user.isLocked;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
