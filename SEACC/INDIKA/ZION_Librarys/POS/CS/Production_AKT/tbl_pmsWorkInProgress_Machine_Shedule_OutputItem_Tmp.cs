using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp {
		#region Fields
		private int line_NoShedule;
		private string workInProgress_ID;
		private int line_No;
		private string prePlan_ID;
		private string section_ID;
		private string machine_ID;
		private string item_ID;
		private string uomLength_ID;
		private decimal length;
		private decimal qty;
		private decimal weightFinished;
		private decimal weightWasteage;
		private decimal weighOut;
		private decimal cylinderSize;
		private decimal counter;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp class.
		/// </summary>
		public tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp class.
		/// </summary>
		public tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp(int line_NoShedule, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID, string item_ID, string uomLength_ID, decimal length, decimal qty, decimal weightFinished, decimal weightWasteage, decimal weighOut, decimal cylinderSize, decimal counter) {
			this.line_NoShedule = line_NoShedule;
			this.workInProgress_ID = workInProgress_ID;
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.machine_ID = machine_ID;
			this.item_ID = item_ID;
			this.uomLength_ID = uomLength_ID;
			this.length = length;
			this.qty = qty;
			this.weightFinished = weightFinished;
			this.weightWasteage = weightWasteage;
			this.weighOut = weighOut;
			this.cylinderSize = cylinderSize;
			this.counter = counter;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_NoShedule value.
		/// </summary>
		public int Line_NoShedule {
			get { return line_NoShedule; }
			set { line_NoShedule = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomLength_ID value.
		/// </summary>
		public string UomLength_ID {
			get { return uomLength_ID; }
			set { uomLength_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public decimal Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightFinished value.
		/// </summary>
		public decimal WeightFinished {
			get { return weightFinished; }
			set { weightFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightWasteage value.
		/// </summary>
		public decimal WeightWasteage {
			get { return weightWasteage; }
			set { weightWasteage = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeighOut value.
		/// </summary>
		public decimal WeighOut {
			get { return weighOut; }
			set { weighOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the CylinderSize value.
		/// </summary>
		public decimal CylinderSize {
			get { return cylinderSize; }
			set { cylinderSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public decimal Counter {
			get { return counter; }
			set { counter = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uomLength_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightFinished", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightWasteage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weighOut", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cylinderSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@counter", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uomLength_ID"].Value = uomLength_ID;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weightFinished"].Value = weightFinished;
			scom.Parameters["@weightWasteage"].Value = weightWasteage;
			scom.Parameters["@weighOut"].Value = weighOut;
			scom.Parameters["@cylinderSize"].Value = cylinderSize;
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uomLength_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightFinished", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightWasteage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weighOut", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cylinderSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@counter", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uomLength_ID"].Value = uomLength_ID;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weightFinished"].Value = weightFinished;
			scom.Parameters["@weightWasteage"].Value = weightWasteage;
			scom.Parameters["@weighOut"].Value = weighOut;
			scom.Parameters["@cylinderSize"].Value = cylinderSize;
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
 
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_NoShedule_WorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID(int line_NoShedule, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWIPOutput_TmpDeleteAllByLine_NoShedule_WorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp table.
		/// </summary>
		public static tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp Select(int line_NoShedule_Incoming, string workInProgress_ID_Incoming, int line_No_Incoming, string prePlan_ID_Incoming, string section_ID_Incoming, string machine_ID_Incoming, string item_ID_Incoming){

			tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmpins = new tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule_Incoming;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmpins = Maketbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp(dataReader);
				} else {
					tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmpins = null;
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmpins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp table.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp> tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpList = new List<tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp = Maketbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp(dataReader);
					tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpList.Add(tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp> SelectAllByLine_NoShedule_WorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID(int line_NoShedule, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWIPOutput_TmpSelectAllByLine_NoShedule_WorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
				List<tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp> tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpList = new List<tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp = Maketbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp(dataReader);
					tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpList.Add(tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_TmpList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp Maketbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp(SqlDataReader dataReader) {
			tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp = new tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.Line_NoShedule = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.WorkInProgress_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.Line_No = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.PrePlan_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.Section_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.Machine_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.Item_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.UomLength_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.Length = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.WeightFinished = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.WeightWasteage = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.WeighOut = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.CylinderSize = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp.Counter = dataReader.GetDecimal(14);
			}

			return tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp;
		}
		/// <summary>
		/// This makes tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp  tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_NoShedule = new DataColumn("line_NoShedule" , typeof(int));
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uomLength_ID = new DataColumn("uomLength_ID" , typeof(string));
			DataColumn col_length = new DataColumn("length" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weightFinished = new DataColumn("weightFinished" , typeof(decimal));
			DataColumn col_weightWasteage = new DataColumn("weightWasteage" , typeof(decimal));
			DataColumn col_weighOut = new DataColumn("weighOut" , typeof(decimal));
			DataColumn col_cylinderSize = new DataColumn("cylinderSize" , typeof(decimal));
			DataColumn col_counter = new DataColumn("counter" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_NoShedule,col_workInProgress_ID,col_line_No,col_prePlan_ID,col_section_ID,col_machine_ID,col_item_ID,col_uomLength_ID,col_length,col_qty,col_weightFinished,col_weightWasteage,col_weighOut,col_cylinderSize,col_counter,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsWorkInProgress_Machine_Shedule_OutputItem_Tmp user) {
		DataRow drow = dt.NewRow();
		
			drow["line_NoShedule"] = user.line_NoShedule;
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["line_No"] = user.line_No;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["item_ID"] = user.item_ID;
			drow["uomLength_ID"] = user.uomLength_ID;
			drow["length"] = user.length;
			drow["qty"] = user.qty;
			drow["weightFinished"] = user.weightFinished;
			drow["weightWasteage"] = user.weightWasteage;
			drow["weighOut"] = user.weighOut;
			drow["cylinderSize"] = user.cylinderSize;
			drow["counter"] = user.counter;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
