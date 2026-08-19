using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsDepartmentReqositionNote_Detail {
		#region Fields
		private int line_No;
		private string departmentReqositionNote_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string job_ID;
		private string fromStore_ID;
		private string toSelectArea_ID;
		private string toDepartment_ID;
		private string toSection_ID;
		private string toStore_ID;
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
		/// Initializes a new instance of the tbl_scsDepartmentReqositionNote_Detail class.
		/// </summary>
		public tbl_scsDepartmentReqositionNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsDepartmentReqositionNote_Detail class.
		/// </summary>
		public tbl_scsDepartmentReqositionNote_Detail(int line_No, string departmentReqositionNote_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string job_ID, string fromStore_ID, string toSelectArea_ID, string toDepartment_ID, string toSection_ID, string toStore_ID, string uom_ID, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal tatalCost_FIFO, decimal tatalCost_WA, string remark, bool isLocked) {
			this.line_No = line_No;
			this.departmentReqositionNote_ID = departmentReqositionNote_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.job_ID = job_ID;
			this.fromStore_ID = fromStore_ID;
			this.toSelectArea_ID = toSelectArea_ID;
			this.toDepartment_ID = toDepartment_ID;
			this.toSection_ID = toSection_ID;
			this.toStore_ID = toStore_ID;
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
		/// Gets or sets the DepartmentReqositionNote_ID value.
		/// </summary>
		public string DepartmentReqositionNote_ID {
			get { return departmentReqositionNote_ID; }
			set { departmentReqositionNote_ID = value; }
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
		/// Gets or sets the FromStore_ID value.
		/// </summary>
		public string FromStore_ID {
			get { return fromStore_ID; }
			set { fromStore_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToSelectArea_ID value.
		/// </summary>
		public string ToSelectArea_ID {
			get { return toSelectArea_ID; }
			set { toSelectArea_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToDepartment_ID value.
		/// </summary>
		public string ToDepartment_ID {
			get { return toDepartment_ID; }
			set { toDepartment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToSection_ID value.
		/// </summary>
		public string ToSection_ID {
			get { return toSection_ID; }
			set { toSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToStore_ID value.
		/// </summary>
		public string ToStore_ID {
			get { return toStore_ID; }
			set { toStore_ID = value; }
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
		/// Saves a record to the tbl_scsDepartmentReqositionNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentReqositionNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
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
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
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
		/// Updates a record in the tbl_scsDepartmentReqositionNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentReqositionNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
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
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
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
		/// Deletes a record from the tbl_scsDepartmentReqositionNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentReqositionNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
 
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
		/// Selects all records from the tbl_scsDepartmentReqositionNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByDepartmentReqositionNote_ID(string departmentReqositionNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentReqositionNote_DetailDeleteAllByDepartmentReqositionNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsDepartmentReqositionNote_Detail table.
		/// </summary>
		public static tbl_scsDepartmentReqositionNote_Detail Select(int line_No_Incoming, string departmentReqositionNote_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsDepartmentReqositionNote_Detail tbl_scsDepartmentReqositionNote_Detailins = new tbl_scsDepartmentReqositionNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentReqositionNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsDepartmentReqositionNote_Detailins = Maketbl_scsDepartmentReqositionNote_Detail(dataReader);
				} else {
					tbl_scsDepartmentReqositionNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsDepartmentReqositionNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentReqositionNote_Detail table.
		/// </summary>
		public static List<tbl_scsDepartmentReqositionNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentReqositionNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsDepartmentReqositionNote_Detail> tbl_scsDepartmentReqositionNote_DetailList = new List<tbl_scsDepartmentReqositionNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentReqositionNote_Detail tbl_scsDepartmentReqositionNote_Detail = Maketbl_scsDepartmentReqositionNote_Detail(dataReader);
					tbl_scsDepartmentReqositionNote_DetailList.Add(tbl_scsDepartmentReqositionNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentReqositionNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentReqositionNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentReqositionNote_Detail> SelectAllByDepartmentReqositionNote_ID(string departmentReqositionNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentReqositionNote_DetailSelectAllByDepartmentReqositionNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
				List<tbl_scsDepartmentReqositionNote_Detail> tbl_scsDepartmentReqositionNote_DetailList = new List<tbl_scsDepartmentReqositionNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentReqositionNote_Detail tbl_scsDepartmentReqositionNote_Detail = Maketbl_scsDepartmentReqositionNote_Detail(dataReader);
					tbl_scsDepartmentReqositionNote_DetailList.Add(tbl_scsDepartmentReqositionNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDepartmentReqositionNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsDepartmentReqositionNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsDepartmentReqositionNote_Detail Maketbl_scsDepartmentReqositionNote_Detail(SqlDataReader dataReader) {
			tbl_scsDepartmentReqositionNote_Detail tbl_scsDepartmentReqositionNote_Detail = new tbl_scsDepartmentReqositionNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsDepartmentReqositionNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsDepartmentReqositionNote_Detail.DepartmentReqositionNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsDepartmentReqositionNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsDepartmentReqositionNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsDepartmentReqositionNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsDepartmentReqositionNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsDepartmentReqositionNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsDepartmentReqositionNote_Detail.Job_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsDepartmentReqositionNote_Detail.FromStore_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsDepartmentReqositionNote_Detail.ToSelectArea_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsDepartmentReqositionNote_Detail.ToDepartment_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsDepartmentReqositionNote_Detail.ToSection_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsDepartmentReqositionNote_Detail.ToStore_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsDepartmentReqositionNote_Detail.Uom_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsDepartmentReqositionNote_Detail.Qty = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsDepartmentReqositionNote_Detail.QtySettle = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsDepartmentReqositionNote_Detail.Weight = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsDepartmentReqositionNote_Detail.WeightSettle = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsDepartmentReqositionNote_Detail.TatalCost_FIFO = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsDepartmentReqositionNote_Detail.TatalCost_WA = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsDepartmentReqositionNote_Detail.Remark = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsDepartmentReqositionNote_Detail.IsLocked = dataReader.GetBoolean(21);
			}

			return tbl_scsDepartmentReqositionNote_Detail;
		}
		/// <summary>
		/// This makes tbl_scsDepartmentReqositionNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsDepartmentReqositionNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsDepartmentReqositionNote_Detail  tbl_scsDepartmentReqositionNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_departmentReqositionNote_ID = new DataColumn("departmentReqositionNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_fromStore_ID = new DataColumn("fromStore_ID" , typeof(string));
			DataColumn col_toSelectArea_ID = new DataColumn("toSelectArea_ID" , typeof(string));
			DataColumn col_toDepartment_ID = new DataColumn("toDepartment_ID" , typeof(string));
			DataColumn col_toSection_ID = new DataColumn("toSection_ID" , typeof(string));
			DataColumn col_toStore_ID = new DataColumn("toStore_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_tatalCost_FIFO = new DataColumn("tatalCost_FIFO" , typeof(decimal));
			DataColumn col_tatalCost_WA = new DataColumn("tatalCost_WA" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_departmentReqositionNote_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_job_ID,col_fromStore_ID,col_toSelectArea_ID,col_toDepartment_ID,col_toSection_ID,col_toStore_ID,col_uom_ID,col_qty,col_qtySettle,col_weight,col_weightSettle,col_tatalCost_FIFO,col_tatalCost_WA,col_remark,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsDepartmentReqositionNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsDepartmentReqositionNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsDepartmentReqositionNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["departmentReqositionNote_ID"] = user.departmentReqositionNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["job_ID"] = user.job_ID;
			drow["fromStore_ID"] = user.fromStore_ID;
			drow["toSelectArea_ID"] = user.toSelectArea_ID;
			drow["toDepartment_ID"] = user.toDepartment_ID;
			drow["toSection_ID"] = user.toSection_ID;
			drow["toStore_ID"] = user.toStore_ID;
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
