using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasDeliveryPlan_CustomerOrder {
		#region Fields
		private string deliveryPlan_ID;
		private string customerOrder_ID;
		private string route_ID;
		private string deliveryOrder_ID;
		private string invoice_ID;
		private decimal discountPercentage;
		private decimal nbtPercentage;
		private decimal vatPercentage;
		private decimal otherTaxPercentage;
		private decimal subTotal;
		private decimal discountTotal;
		private decimal nbtTotal;
		private decimal vatTotal;
		private decimal otherTaxTotal;
		private decimal grandTotal;
		private int printCountDeliveryOrder;
		private int printCountInvoice;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryPlan_CustomerOrder class.
		/// </summary>
		public tbl_sasDeliveryPlan_CustomerOrder() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryPlan_CustomerOrder class.
		/// </summary>
		public tbl_sasDeliveryPlan_CustomerOrder(string deliveryPlan_ID, string customerOrder_ID, string route_ID, string deliveryOrder_ID, string invoice_ID, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, int printCountDeliveryOrder, int printCountInvoice) {
			this.deliveryPlan_ID = deliveryPlan_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.route_ID = route_ID;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.invoice_ID = invoice_ID;
			this.discountPercentage = discountPercentage;
			this.nbtPercentage = nbtPercentage;
			this.vatPercentage = vatPercentage;
			this.otherTaxPercentage = otherTaxPercentage;
			this.subTotal = subTotal;
			this.discountTotal = discountTotal;
			this.nbtTotal = nbtTotal;
			this.vatTotal = vatTotal;
			this.otherTaxTotal = otherTaxTotal;
			this.grandTotal = grandTotal;
			this.printCountDeliveryOrder = printCountDeliveryOrder;
			this.printCountInvoice = printCountInvoice;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DeliveryPlan_ID value.
		/// </summary>
		public string DeliveryPlan_ID {
			get { return deliveryPlan_ID; }
			set { deliveryPlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public string Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPercentage value.
		/// </summary>
		public decimal DiscountPercentage {
			get { return discountPercentage; }
			set { discountPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtPercentage value.
		/// </summary>
		public decimal NbtPercentage {
			get { return nbtPercentage; }
			set { nbtPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatPercentage value.
		/// </summary>
		public decimal VatPercentage {
			get { return vatPercentage; }
			set { vatPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherTaxPercentage value.
		/// </summary>
		public decimal OtherTaxPercentage {
			get { return otherTaxPercentage; }
			set { otherTaxPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubTotal value.
		/// </summary>
		public decimal SubTotal {
			get { return subTotal; }
			set { subTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountTotal value.
		/// </summary>
		public decimal DiscountTotal {
			get { return discountTotal; }
			set { discountTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtTotal value.
		/// </summary>
		public decimal NbtTotal {
			get { return nbtTotal; }
			set { nbtTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatTotal value.
		/// </summary>
		public decimal VatTotal {
			get { return vatTotal; }
			set { vatTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherTaxTotal value.
		/// </summary>
		public decimal OtherTaxTotal {
			get { return otherTaxTotal; }
			set { otherTaxTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public decimal GrandTotal {
			get { return grandTotal; }
			set { grandTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCountDeliveryOrder value.
		/// </summary>
		public int PrintCountDeliveryOrder {
			get { return printCountDeliveryOrder; }
			set { printCountDeliveryOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCountInvoice value.
		/// </summary>
		public int PrintCountInvoice {
			get { return printCountInvoice; }
			set { printCountInvoice = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasDeliveryPlan_CustomerOrder table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@printCountDeliveryOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@printCountInvoice", SqlDbType.Int,4);
 
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@nbtTotal"].Value = nbtTotal;
			scom.Parameters["@vatTotal"].Value = vatTotal;
			scom.Parameters["@otherTaxTotal"].Value = otherTaxTotal;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@printCountDeliveryOrder"].Value = printCountDeliveryOrder;
			scom.Parameters["@printCountInvoice"].Value = printCountInvoice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasDeliveryPlan_CustomerOrder table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@printCountDeliveryOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@printCountInvoice", SqlDbType.Int,4);
 
 
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@nbtTotal"].Value = nbtTotal;
			scom.Parameters["@vatTotal"].Value = vatTotal;
			scom.Parameters["@otherTaxTotal"].Value = otherTaxTotal;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@printCountDeliveryOrder"].Value = printCountDeliveryOrder;
			scom.Parameters["@printCountInvoice"].Value = printCountInvoice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasDeliveryPlan_CustomerOrder table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
 
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderDeleteAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryPlan_ID(string deliveryPlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderDeleteAllByDeliveryPlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasDeliveryPlan_CustomerOrder table.
		/// </summary>
		public static tbl_sasDeliveryPlan_CustomerOrder Select(string deliveryPlan_ID_Incoming, string customerOrder_ID_Incoming){

			tbl_sasDeliveryPlan_CustomerOrder tbl_sasDeliveryPlan_CustomerOrderins = new tbl_sasDeliveryPlan_CustomerOrder();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID_Incoming;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrderins = Maketbl_sasDeliveryPlan_CustomerOrder(dataReader);
				} else {
					tbl_sasDeliveryPlan_CustomerOrderins = null;
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrderins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasDeliveryPlan_CustomerOrder> tbl_sasDeliveryPlan_CustomerOrderList = new List<tbl_sasDeliveryPlan_CustomerOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder tbl_sasDeliveryPlan_CustomerOrder = Maketbl_sasDeliveryPlan_CustomerOrder(dataReader);
					tbl_sasDeliveryPlan_CustomerOrderList.Add(tbl_sasDeliveryPlan_CustomerOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder> tbl_sasDeliveryPlan_CustomerOrderList = new List<tbl_sasDeliveryPlan_CustomerOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder tbl_sasDeliveryPlan_CustomerOrder = Maketbl_sasDeliveryPlan_CustomerOrder(dataReader);
					tbl_sasDeliveryPlan_CustomerOrderList.Add(tbl_sasDeliveryPlan_CustomerOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderSelectAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder> tbl_sasDeliveryPlan_CustomerOrderList = new List<tbl_sasDeliveryPlan_CustomerOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder tbl_sasDeliveryPlan_CustomerOrder = Maketbl_sasDeliveryPlan_CustomerOrder(dataReader);
					tbl_sasDeliveryPlan_CustomerOrderList.Add(tbl_sasDeliveryPlan_CustomerOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder> SelectAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder> tbl_sasDeliveryPlan_CustomerOrderList = new List<tbl_sasDeliveryPlan_CustomerOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder tbl_sasDeliveryPlan_CustomerOrder = Maketbl_sasDeliveryPlan_CustomerOrder(dataReader);
					tbl_sasDeliveryPlan_CustomerOrderList.Add(tbl_sasDeliveryPlan_CustomerOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder> tbl_sasDeliveryPlan_CustomerOrderList = new List<tbl_sasDeliveryPlan_CustomerOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder tbl_sasDeliveryPlan_CustomerOrder = Maketbl_sasDeliveryPlan_CustomerOrder(dataReader);
					tbl_sasDeliveryPlan_CustomerOrderList.Add(tbl_sasDeliveryPlan_CustomerOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder> SelectAllByDeliveryPlan_ID(string deliveryPlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrderSelectAllByDeliveryPlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder> tbl_sasDeliveryPlan_CustomerOrderList = new List<tbl_sasDeliveryPlan_CustomerOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder tbl_sasDeliveryPlan_CustomerOrder = Maketbl_sasDeliveryPlan_CustomerOrder(dataReader);
					tbl_sasDeliveryPlan_CustomerOrderList.Add(tbl_sasDeliveryPlan_CustomerOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrderList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasDeliveryPlan_CustomerOrder class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasDeliveryPlan_CustomerOrder Maketbl_sasDeliveryPlan_CustomerOrder(SqlDataReader dataReader) {
			tbl_sasDeliveryPlan_CustomerOrder tbl_sasDeliveryPlan_CustomerOrder = new tbl_sasDeliveryPlan_CustomerOrder();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.DeliveryPlan_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.CustomerOrder_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.Route_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.DeliveryOrder_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.Invoice_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.DiscountPercentage = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.NbtPercentage = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.VatPercentage = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.OtherTaxPercentage = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.SubTotal = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.DiscountTotal = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.NbtTotal = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.VatTotal = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.OtherTaxTotal = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.GrandTotal = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.PrintCountDeliveryOrder = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasDeliveryPlan_CustomerOrder.PrintCountInvoice = dataReader.GetInt32(16);
			}

			return tbl_sasDeliveryPlan_CustomerOrder;
		}
		/// <summary>
		/// This makes tbl_sasDeliveryPlan_CustomerOrder datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryPlan_CustomerOrder object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasDeliveryPlan_CustomerOrder  tbl_sasDeliveryPlan_CustomerOrder   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_deliveryPlan_ID = new DataColumn("deliveryPlan_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_discountPercentage = new DataColumn("discountPercentage" , typeof(decimal));
			DataColumn col_nbtPercentage = new DataColumn("nbtPercentage" , typeof(decimal));
			DataColumn col_vatPercentage = new DataColumn("vatPercentage" , typeof(decimal));
			DataColumn col_otherTaxPercentage = new DataColumn("otherTaxPercentage" , typeof(decimal));
			DataColumn col_subTotal = new DataColumn("subTotal" , typeof(decimal));
			DataColumn col_discountTotal = new DataColumn("discountTotal" , typeof(decimal));
			DataColumn col_nbtTotal = new DataColumn("nbtTotal" , typeof(decimal));
			DataColumn col_vatTotal = new DataColumn("vatTotal" , typeof(decimal));
			DataColumn col_otherTaxTotal = new DataColumn("otherTaxTotal" , typeof(decimal));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_printCountDeliveryOrder = new DataColumn("printCountDeliveryOrder" , typeof(int));
			DataColumn col_printCountInvoice = new DataColumn("printCountInvoice" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_deliveryPlan_ID,col_customerOrder_ID,col_route_ID,col_deliveryOrder_ID,col_invoice_ID,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_printCountDeliveryOrder,col_printCountInvoice,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasDeliveryPlan_CustomerOrder datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryPlan_CustomerOrder object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasDeliveryPlan_CustomerOrder user) {
		DataRow drow = dt.NewRow();
		
			drow["deliveryPlan_ID"] = user.deliveryPlan_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["route_ID"] = user.route_ID;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["discountPercentage"] = user.discountPercentage;
			drow["nbtPercentage"] = user.nbtPercentage;
			drow["vatPercentage"] = user.vatPercentage;
			drow["otherTaxPercentage"] = user.otherTaxPercentage;
			drow["subTotal"] = user.subTotal;
			drow["discountTotal"] = user.discountTotal;
			drow["nbtTotal"] = user.nbtTotal;
			drow["vatTotal"] = user.vatTotal;
			drow["otherTaxTotal"] = user.otherTaxTotal;
			drow["grandTotal"] = user.grandTotal;
			drow["printCountDeliveryOrder"] = user.printCountDeliveryOrder;
			drow["printCountInvoice"] = user.printCountInvoice;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
