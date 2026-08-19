using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsSectionGoodReceiveNote_Detail {
		#region Fields
		private int line_No;
		private string sectionGoodReceiveNote_ID;
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
		private string toSection_ID;
		private string departmentGoodIssueNote_ID;
		private string sectionGoodIssueNote_ID;
		private string storeGoodIssueNote_ID;
		private string uom_ID;
		private decimal qty;
		private decimal qtySettle;
		private decimal weight;
		private decimal weightSettle;
		private decimal tatalCost_FIFO;
		private decimal tatalCost_WA;
		private string remark;
		private bool isLocked;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsSectionGoodReceiveNote_Detail class.
		/// </summary>
		public tbl_scsSectionGoodReceiveNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsSectionGoodReceiveNote_Detail class.
		/// </summary>
		public tbl_scsSectionGoodReceiveNote_Detail(int line_No, string sectionGoodReceiveNote_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string job_ID, string fromSelectArea_ID, string fromDepartment_ID, string fromSection_ID, string fromStore_ID, string toSection_ID, string departmentGoodIssueNote_ID, string sectionGoodIssueNote_ID, string storeGoodIssueNote_ID, string uom_ID, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal tatalCost_FIFO, decimal tatalCost_WA, string remark, bool isLocked) {
			this.line_No = line_No;
			this.sectionGoodReceiveNote_ID = sectionGoodReceiveNote_ID;
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
			this.toSection_ID = toSection_ID;
			this.departmentGoodIssueNote_ID = departmentGoodIssueNote_ID;
			this.sectionGoodIssueNote_ID = sectionGoodIssueNote_ID;
			this.storeGoodIssueNote_ID = storeGoodIssueNote_ID;
			this.uom_ID = uom_ID;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.tatalCost_FIFO = tatalCost_FIFO;
			this.tatalCost_WA = tatalCost_WA;
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
		/// Gets or sets the SectionGoodReceiveNote_ID value.
		/// </summary>
		public string SectionGoodReceiveNote_ID {
			get { return sectionGoodReceiveNote_ID; }
			set { sectionGoodReceiveNote_ID = value; }
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
		/// Gets or sets the ToSection_ID value.
		/// </summary>
		public string ToSection_ID {
			get { return toSection_ID; }
			set { toSection_ID = value; }
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
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle value.
		/// </summary>
		public decimal QtySettle {
			get { return qtySettle; }
			set { qtySettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightSettle value.
		/// </summary>
		public decimal WeightSettle {
			get { return weightSettle; }
			set { weightSettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalCost_FIFO value.
		/// </summary>
		public decimal TatalCost_FIFO {
			get { return tatalCost_FIFO; }
			set { tatalCost_FIFO = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalCost_WA value.
		/// </summary>
		public decimal TatalCost_WA {
			get { return tatalCost_WA; }
			set { tatalCost_WA = value; }
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
		/// Saves a record to the tbl_scsSectionGoodReceiveNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@sectionGoodReceiveNote_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,30);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@sectionGoodReceiveNote_ID"].Value = sectionGoodReceiveNote_ID;
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
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsSectionGoodReceiveNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@sectionGoodReceiveNote_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,30);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@sectionGoodReceiveNote_ID"].Value = sectionGoodReceiveNote_ID;
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
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsSectionGoodReceiveNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sectionGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@sectionGoodReceiveNote_ID"].Value = sectionGoodReceiveNote_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySectionGoodReceiveNote_ID(string sectionGoodReceiveNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailDeleteAllBySectionGoodReceiveNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sectionGoodReceiveNote_ID"].Value = sectionGoodReceiveNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByToSection_ID(string toSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailDeleteAllByToSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByFromSelectArea_ID(string fromSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailDeleteAllByFromSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsSectionGoodReceiveNote_Detail table.
		/// </summary>
		public static tbl_scsSectionGoodReceiveNote_Detail Select(string sectionGoodReceiveNote_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detailins = new tbl_scsSectionGoodReceiveNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@sectionGoodReceiveNote_ID"].Value = sectionGoodReceiveNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detailins = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
				} else {
					tbl_scsSectionGoodReceiveNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table.
		/// </summary>
		public static List<tbl_scsSectionGoodReceiveNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsSectionGoodReceiveNote_Detail> tbl_scsSectionGoodReceiveNote_DetailList = new List<tbl_scsSectionGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
					tbl_scsSectionGoodReceiveNote_DetailList.Add(tbl_scsSectionGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionGoodReceiveNote_Detail> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_scsSectionGoodReceiveNote_Detail> tbl_scsSectionGoodReceiveNote_DetailList = new List<tbl_scsSectionGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
					tbl_scsSectionGoodReceiveNote_DetailList.Add(tbl_scsSectionGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionGoodReceiveNote_Detail> SelectAllBySectionGoodReceiveNote_ID(string sectionGoodReceiveNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelectAllBySectionGoodReceiveNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sectionGoodReceiveNote_ID"].Value = sectionGoodReceiveNote_ID;
				List<tbl_scsSectionGoodReceiveNote_Detail> tbl_scsSectionGoodReceiveNote_DetailList = new List<tbl_scsSectionGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
					tbl_scsSectionGoodReceiveNote_DetailList.Add(tbl_scsSectionGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionGoodReceiveNote_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_scsSectionGoodReceiveNote_Detail> tbl_scsSectionGoodReceiveNote_DetailList = new List<tbl_scsSectionGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
					tbl_scsSectionGoodReceiveNote_DetailList.Add(tbl_scsSectionGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionGoodReceiveNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsSectionGoodReceiveNote_Detail> tbl_scsSectionGoodReceiveNote_DetailList = new List<tbl_scsSectionGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
					tbl_scsSectionGoodReceiveNote_DetailList.Add(tbl_scsSectionGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionGoodReceiveNote_Detail> SelectAllByToSection_ID(string toSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelectAllByToSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
				List<tbl_scsSectionGoodReceiveNote_Detail> tbl_scsSectionGoodReceiveNote_DetailList = new List<tbl_scsSectionGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
					tbl_scsSectionGoodReceiveNote_DetailList.Add(tbl_scsSectionGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionGoodReceiveNote_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_scsSectionGoodReceiveNote_Detail> tbl_scsSectionGoodReceiveNote_DetailList = new List<tbl_scsSectionGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
					tbl_scsSectionGoodReceiveNote_DetailList.Add(tbl_scsSectionGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionGoodReceiveNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionGoodReceiveNote_Detail> SelectAllByFromSelectArea_ID(string fromSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionGoodReceiveNote_DetailSelectAllByFromSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
				List<tbl_scsSectionGoodReceiveNote_Detail> tbl_scsSectionGoodReceiveNote_DetailList = new List<tbl_scsSectionGoodReceiveNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = Maketbl_scsSectionGoodReceiveNote_Detail(dataReader);
					tbl_scsSectionGoodReceiveNote_DetailList.Add(tbl_scsSectionGoodReceiveNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsSectionGoodReceiveNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsSectionGoodReceiveNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsSectionGoodReceiveNote_Detail Maketbl_scsSectionGoodReceiveNote_Detail(SqlDataReader dataReader) {
			tbl_scsSectionGoodReceiveNote_Detail tbl_scsSectionGoodReceiveNote_Detail = new tbl_scsSectionGoodReceiveNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.SectionGoodReceiveNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.Job_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.FromSelectArea_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.FromDepartment_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.FromSection_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.FromStore_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.ToSection_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.DepartmentGoodIssueNote_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.SectionGoodIssueNote_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.StoreGoodIssueNote_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.Uom_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.Qty = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.QtySettle = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.Weight = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.WeightSettle = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.TatalCost_FIFO = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.TatalCost_WA = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.Remark = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsSectionGoodReceiveNote_Detail.IsLocked = dataReader.GetBoolean(24);
			}

			return tbl_scsSectionGoodReceiveNote_Detail;
		}
		/// <summary>
		/// This makes tbl_scsSectionGoodReceiveNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsSectionGoodReceiveNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsSectionGoodReceiveNote_Detail  tbl_scsSectionGoodReceiveNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_sectionGoodReceiveNote_ID = new DataColumn("sectionGoodReceiveNote_ID" , typeof(string));
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
			DataColumn col_toSection_ID = new DataColumn("toSection_ID" , typeof(string));
			DataColumn col_departmentGoodIssueNote_ID = new DataColumn("departmentGoodIssueNote_ID" , typeof(string));
			DataColumn col_sectionGoodIssueNote_ID = new DataColumn("sectionGoodIssueNote_ID" , typeof(string));
			DataColumn col_storeGoodIssueNote_ID = new DataColumn("storeGoodIssueNote_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_tatalCost_FIFO = new DataColumn("tatalCost_FIFO" , typeof(decimal));
			DataColumn col_tatalCost_WA = new DataColumn("tatalCost_WA" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_sectionGoodReceiveNote_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_job_ID,col_fromSelectArea_ID,col_fromDepartment_ID,col_fromSection_ID,col_fromStore_ID,col_toSection_ID,col_departmentGoodIssueNote_ID,col_sectionGoodIssueNote_ID,col_storeGoodIssueNote_ID,col_uom_ID,col_qty,col_qtySettle,col_weight,col_weightSettle,col_tatalCost_FIFO,col_tatalCost_WA,col_remark,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsSectionGoodReceiveNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsSectionGoodReceiveNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsSectionGoodReceiveNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["sectionGoodReceiveNote_ID"] = user.sectionGoodReceiveNote_ID;
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
			drow["toSection_ID"] = user.toSection_ID;
			drow["departmentGoodIssueNote_ID"] = user.departmentGoodIssueNote_ID;
			drow["sectionGoodIssueNote_ID"] = user.sectionGoodIssueNote_ID;
			drow["storeGoodIssueNote_ID"] = user.storeGoodIssueNote_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["weight"] = user.weight;
			drow["weightSettle"] = user.weightSettle;
			drow["tatalCost_FIFO"] = user.tatalCost_FIFO;
			drow["tatalCost_WA"] = user.tatalCost_WA;
			drow["remark"] = user.remark;
			drow["isLocked"] = user.isLocked;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
