using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_comItemCategory_comissionRates {
		#region Fields
		private string itemCategory_ID;
		private decimal normalSalesRate_SR;
		private decimal discountedSalesRate_SR;
		private decimal targetForSalePeriod_SR;
		private decimal normalSalesRate_AM;
		private decimal discountedSalesRate_AM;
		private decimal targetForSalePeriod_AM;
		private decimal normalSalesRate_SM;
		private decimal discountedSalesRate_SM;
		private decimal targetForSalePeriod_SM;
		private decimal normalSalesRate_Col;
		private decimal discountedSalesRate_Col;
		private decimal targetForSalePeriod_Col;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_comItemCategory_comissionRates class.
		/// </summary>
		public tbl_comItemCategory_comissionRates() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_comItemCategory_comissionRates class.
		/// </summary>
		public tbl_comItemCategory_comissionRates(string itemCategory_ID, decimal normalSalesRate_SR, decimal discountedSalesRate_SR, decimal targetForSalePeriod_SR, decimal normalSalesRate_AM, decimal discountedSalesRate_AM, decimal targetForSalePeriod_AM, decimal normalSalesRate_SM, decimal discountedSalesRate_SM, decimal targetForSalePeriod_SM, decimal normalSalesRate_Col, decimal discountedSalesRate_Col, decimal targetForSalePeriod_Col) {
			this.itemCategory_ID = itemCategory_ID;
			this.normalSalesRate_SR = normalSalesRate_SR;
			this.discountedSalesRate_SR = discountedSalesRate_SR;
			this.targetForSalePeriod_SR = targetForSalePeriod_SR;
			this.normalSalesRate_AM = normalSalesRate_AM;
			this.discountedSalesRate_AM = discountedSalesRate_AM;
			this.targetForSalePeriod_AM = targetForSalePeriod_AM;
			this.normalSalesRate_SM = normalSalesRate_SM;
			this.discountedSalesRate_SM = discountedSalesRate_SM;
			this.targetForSalePeriod_SM = targetForSalePeriod_SM;
			this.normalSalesRate_Col = normalSalesRate_Col;
			this.discountedSalesRate_Col = discountedSalesRate_Col;
			this.targetForSalePeriod_Col = targetForSalePeriod_Col;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the NormalSalesRate_SR value.
		/// </summary>
		public decimal NormalSalesRate_SR {
			get { return normalSalesRate_SR; }
			set { normalSalesRate_SR = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountedSalesRate_SR value.
		/// </summary>
		public decimal DiscountedSalesRate_SR {
			get { return discountedSalesRate_SR; }
			set { discountedSalesRate_SR = value; }
		}
		
		/// <summary>
		/// Gets or sets the TargetForSalePeriod_SR value.
		/// </summary>
		public decimal TargetForSalePeriod_SR {
			get { return targetForSalePeriod_SR; }
			set { targetForSalePeriod_SR = value; }
		}
		
		/// <summary>
		/// Gets or sets the NormalSalesRate_AM value.
		/// </summary>
		public decimal NormalSalesRate_AM {
			get { return normalSalesRate_AM; }
			set { normalSalesRate_AM = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountedSalesRate_AM value.
		/// </summary>
		public decimal DiscountedSalesRate_AM {
			get { return discountedSalesRate_AM; }
			set { discountedSalesRate_AM = value; }
		}
		
		/// <summary>
		/// Gets or sets the TargetForSalePeriod_AM value.
		/// </summary>
		public decimal TargetForSalePeriod_AM {
			get { return targetForSalePeriod_AM; }
			set { targetForSalePeriod_AM = value; }
		}
		
		/// <summary>
		/// Gets or sets the NormalSalesRate_SM value.
		/// </summary>
		public decimal NormalSalesRate_SM {
			get { return normalSalesRate_SM; }
			set { normalSalesRate_SM = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountedSalesRate_SM value.
		/// </summary>
		public decimal DiscountedSalesRate_SM {
			get { return discountedSalesRate_SM; }
			set { discountedSalesRate_SM = value; }
		}
		
		/// <summary>
		/// Gets or sets the TargetForSalePeriod_SM value.
		/// </summary>
		public decimal TargetForSalePeriod_SM {
			get { return targetForSalePeriod_SM; }
			set { targetForSalePeriod_SM = value; }
		}
		
		/// <summary>
		/// Gets or sets the NormalSalesRate_Col value.
		/// </summary>
		public decimal NormalSalesRate_Col {
			get { return normalSalesRate_Col; }
			set { normalSalesRate_Col = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountedSalesRate_Col value.
		/// </summary>
		public decimal DiscountedSalesRate_Col {
			get { return discountedSalesRate_Col; }
			set { discountedSalesRate_Col = value; }
		}
		
		/// <summary>
		/// Gets or sets the TargetForSalePeriod_Col value.
		/// </summary>
		public decimal TargetForSalePeriod_Col {
			get { return targetForSalePeriod_Col; }
			set { targetForSalePeriod_Col = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_comItemCategory_comissionRates table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comItemCategory_comissionRatesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@NormalSalesRate_SR", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DiscountedSalesRate_SR", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TargetForSalePeriod_SR", SqlDbType.Decimal,9);
			scom.Parameters.Add("@NormalSalesRate_AM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DiscountedSalesRate_AM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TargetForSalePeriod_AM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@NormalSalesRate_SM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DiscountedSalesRate_SM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TargetForSalePeriod_SM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@NormalSalesRate_Col", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DiscountedSalesRate_Col", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TargetForSalePeriod_Col", SqlDbType.Decimal,9);
 
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@NormalSalesRate_SR"].Value = normalSalesRate_SR;
			scom.Parameters["@DiscountedSalesRate_SR"].Value = discountedSalesRate_SR;
			scom.Parameters["@TargetForSalePeriod_SR"].Value = targetForSalePeriod_SR;
			scom.Parameters["@NormalSalesRate_AM"].Value = normalSalesRate_AM;
			scom.Parameters["@DiscountedSalesRate_AM"].Value = discountedSalesRate_AM;
			scom.Parameters["@TargetForSalePeriod_AM"].Value = targetForSalePeriod_AM;
			scom.Parameters["@NormalSalesRate_SM"].Value = normalSalesRate_SM;
			scom.Parameters["@DiscountedSalesRate_SM"].Value = discountedSalesRate_SM;
			scom.Parameters["@TargetForSalePeriod_SM"].Value = targetForSalePeriod_SM;
			scom.Parameters["@NormalSalesRate_Col"].Value = normalSalesRate_Col;
			scom.Parameters["@DiscountedSalesRate_Col"].Value = discountedSalesRate_Col;
			scom.Parameters["@TargetForSalePeriod_Col"].Value = targetForSalePeriod_Col;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_comItemCategory_comissionRates table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comItemCategory_comissionRatesUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@NormalSalesRate_SR", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DiscountedSalesRate_SR", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TargetForSalePeriod_SR", SqlDbType.Decimal,9);
			scom.Parameters.Add("@NormalSalesRate_AM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DiscountedSalesRate_AM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TargetForSalePeriod_AM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@NormalSalesRate_SM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DiscountedSalesRate_SM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TargetForSalePeriod_SM", SqlDbType.Decimal,9);
			scom.Parameters.Add("@NormalSalesRate_Col", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DiscountedSalesRate_Col", SqlDbType.Decimal,9);
			scom.Parameters.Add("@TargetForSalePeriod_Col", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@NormalSalesRate_SR"].Value = normalSalesRate_SR;
			scom.Parameters["@DiscountedSalesRate_SR"].Value = discountedSalesRate_SR;
			scom.Parameters["@TargetForSalePeriod_SR"].Value = targetForSalePeriod_SR;
			scom.Parameters["@NormalSalesRate_AM"].Value = normalSalesRate_AM;
			scom.Parameters["@DiscountedSalesRate_AM"].Value = discountedSalesRate_AM;
			scom.Parameters["@TargetForSalePeriod_AM"].Value = targetForSalePeriod_AM;
			scom.Parameters["@NormalSalesRate_SM"].Value = normalSalesRate_SM;
			scom.Parameters["@DiscountedSalesRate_SM"].Value = discountedSalesRate_SM;
			scom.Parameters["@TargetForSalePeriod_SM"].Value = targetForSalePeriod_SM;
			scom.Parameters["@NormalSalesRate_Col"].Value = normalSalesRate_Col;
			scom.Parameters["@DiscountedSalesRate_Col"].Value = discountedSalesRate_Col;
			scom.Parameters["@TargetForSalePeriod_Col"].Value = targetForSalePeriod_Col;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_comItemCategory_comissionRates table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comItemCategory_comissionRatesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_comItemCategory_comissionRates table.
		/// </summary>
		public static tbl_comItemCategory_comissionRates Select(string itemCategory_ID_Incoming){

			tbl_comItemCategory_comissionRates tbl_comItemCategory_comissionRatesins = new tbl_comItemCategory_comissionRates();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comItemCategory_comissionRatesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_comItemCategory_comissionRatesins = Maketbl_comItemCategory_comissionRates(dataReader);
				} else {
					tbl_comItemCategory_comissionRatesins = null;
				}
			}
			scon.Close();
			return tbl_comItemCategory_comissionRatesins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comItemCategory_comissionRates table.
		/// </summary>
		public static List<tbl_comItemCategory_comissionRates> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comItemCategory_comissionRatesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_comItemCategory_comissionRates> tbl_comItemCategory_comissionRatesList = new List<tbl_comItemCategory_comissionRates>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comItemCategory_comissionRates tbl_comItemCategory_comissionRates = Maketbl_comItemCategory_comissionRates(dataReader);
					tbl_comItemCategory_comissionRatesList.Add(tbl_comItemCategory_comissionRates);
				}
			}
			scon.Close();
			return tbl_comItemCategory_comissionRatesList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_comItemCategory_comissionRates class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_comItemCategory_comissionRates Maketbl_comItemCategory_comissionRates(SqlDataReader dataReader) {
			tbl_comItemCategory_comissionRates tbl_comItemCategory_comissionRates = new tbl_comItemCategory_comissionRates();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_comItemCategory_comissionRates.ItemCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_comItemCategory_comissionRates.NormalSalesRate_SR = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_comItemCategory_comissionRates.DiscountedSalesRate_SR = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_comItemCategory_comissionRates.TargetForSalePeriod_SR = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_comItemCategory_comissionRates.NormalSalesRate_AM = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_comItemCategory_comissionRates.DiscountedSalesRate_AM = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_comItemCategory_comissionRates.TargetForSalePeriod_AM = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_comItemCategory_comissionRates.NormalSalesRate_SM = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_comItemCategory_comissionRates.DiscountedSalesRate_SM = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_comItemCategory_comissionRates.TargetForSalePeriod_SM = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_comItemCategory_comissionRates.NormalSalesRate_Col = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_comItemCategory_comissionRates.DiscountedSalesRate_Col = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_comItemCategory_comissionRates.TargetForSalePeriod_Col = dataReader.GetDecimal(12);
			}

			return tbl_comItemCategory_comissionRates;
		}
		/// <summary>
		/// This makes tbl_comItemCategory_comissionRates datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_comItemCategory_comissionRates object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_comItemCategory_comissionRates  tbl_comItemCategory_comissionRates   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_NormalSalesRate_SR = new DataColumn("NormalSalesRate_SR" , typeof(decimal));
			DataColumn col_DiscountedSalesRate_SR = new DataColumn("DiscountedSalesRate_SR" , typeof(decimal));
			DataColumn col_TargetForSalePeriod_SR = new DataColumn("TargetForSalePeriod_SR" , typeof(decimal));
			DataColumn col_NormalSalesRate_AM = new DataColumn("NormalSalesRate_AM" , typeof(decimal));
			DataColumn col_DiscountedSalesRate_AM = new DataColumn("DiscountedSalesRate_AM" , typeof(decimal));
			DataColumn col_TargetForSalePeriod_AM = new DataColumn("TargetForSalePeriod_AM" , typeof(decimal));
			DataColumn col_NormalSalesRate_SM = new DataColumn("NormalSalesRate_SM" , typeof(decimal));
			DataColumn col_DiscountedSalesRate_SM = new DataColumn("DiscountedSalesRate_SM" , typeof(decimal));
			DataColumn col_TargetForSalePeriod_SM = new DataColumn("TargetForSalePeriod_SM" , typeof(decimal));
			DataColumn col_NormalSalesRate_Col = new DataColumn("NormalSalesRate_Col" , typeof(decimal));
			DataColumn col_DiscountedSalesRate_Col = new DataColumn("DiscountedSalesRate_Col" , typeof(decimal));
			DataColumn col_TargetForSalePeriod_Col = new DataColumn("TargetForSalePeriod_Col" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_itemCategory_ID,col_NormalSalesRate_SR,col_DiscountedSalesRate_SR,col_TargetForSalePeriod_SR,col_NormalSalesRate_AM,col_DiscountedSalesRate_AM,col_TargetForSalePeriod_AM,col_NormalSalesRate_SM,col_DiscountedSalesRate_SM,col_TargetForSalePeriod_SM,col_NormalSalesRate_Col,col_DiscountedSalesRate_Col,col_TargetForSalePeriod_Col,});		return dt;
		}
		/// <summary>
		/// This fills tbl_comItemCategory_comissionRates datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_comItemCategory_comissionRates object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_comItemCategory_comissionRates user) {
		DataRow drow = dt.NewRow();
		
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["NormalSalesRate_SR"] = user.NormalSalesRate_SR;
			drow["DiscountedSalesRate_SR"] = user.DiscountedSalesRate_SR;
			drow["TargetForSalePeriod_SR"] = user.TargetForSalePeriod_SR;
			drow["NormalSalesRate_AM"] = user.NormalSalesRate_AM;
			drow["DiscountedSalesRate_AM"] = user.DiscountedSalesRate_AM;
			drow["TargetForSalePeriod_AM"] = user.TargetForSalePeriod_AM;
			drow["NormalSalesRate_SM"] = user.NormalSalesRate_SM;
			drow["DiscountedSalesRate_SM"] = user.DiscountedSalesRate_SM;
			drow["TargetForSalePeriod_SM"] = user.TargetForSalePeriod_SM;
			drow["NormalSalesRate_Col"] = user.NormalSalesRate_Col;
			drow["DiscountedSalesRate_Col"] = user.DiscountedSalesRate_Col;
			drow["TargetForSalePeriod_Col"] = user.TargetForSalePeriod_Col;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
