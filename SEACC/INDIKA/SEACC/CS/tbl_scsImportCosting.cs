using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsImportCosting {
		#region Fields
		private int ic_ID;
		private string item_ID;
		private string cusDeclaration_ID;
		private string supplier_ID;
		private string hs_Code;
		private string bl_No;
		private string comInv_No;
		private string bank_ID;
		private string branch_ID;
		private string bankLc_No;
		private string container_No;
		private string grn_ID;
		private string currency_ID;
		private decimal itemCost;
		private decimal incoterm_ID;
		private decimal carriageCost;
		private decimal insuranceCost;
		private decimal freightCost;
		private decimal portCost;
		private decimal demurrageCost;
		private decimal demurrageDays;
		private decimal portTax1;
		private decimal portTax2;
		private decimal portTax3;
		private decimal portVat;
		private decimal customsPanaltyCost;
		private decimal customsTax1;
		private decimal customsTax2;
		private decimal customsTax3;
		private decimal customsVat;
		private decimal inboundTransportCost;
		private decimal inboundTransportTax;
		private decimal inboundTransportNbt;
		private decimal inboundTransportVat;
		private decimal clearingAgentCost;
		private decimal clearingAgentTax;
		private decimal clearingAgentNbt;
		private decimal clearingAgentVat;
		private decimal lcCost;
		private decimal lcInterest;
		private decimal lcTax;
		private decimal lcNBT;
		private decimal lcVAT;
		private decimal subTotal;
		private decimal preCost;
		private decimal profitMargin;
		private decimal salesCost;
		private string remarks1;
		private string remarks2;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsImportCosting class.
		/// </summary>
		public tbl_scsImportCosting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsImportCosting class.
		/// </summary>
		public tbl_scsImportCosting(int ic_ID, string item_ID, string cusDeclaration_ID, string supplier_ID, string hs_Code, string bl_No, string comInv_No, string bank_ID, string branch_ID, string bankLc_No, string container_No, string grn_ID, string currency_ID, decimal itemCost, decimal incoterm_ID, decimal carriageCost, decimal insuranceCost, decimal freightCost, decimal portCost, decimal demurrageCost, decimal demurrageDays, decimal portTax1, decimal portTax2, decimal portTax3, decimal portVat, decimal customsPanaltyCost, decimal customsTax1, decimal customsTax2, decimal customsTax3, decimal customsVat, decimal inboundTransportCost, decimal inboundTransportTax, decimal inboundTransportNbt, decimal inboundTransportVat, decimal clearingAgentCost, decimal clearingAgentTax, decimal clearingAgentNbt, decimal clearingAgentVat, decimal lcCost, decimal lcInterest, decimal lcTax, decimal lcNBT, decimal lcVAT, decimal subTotal, decimal preCost, decimal profitMargin, decimal salesCost, string remarks1, string remarks2) {
			this.ic_ID = ic_ID;
			this.item_ID = item_ID;
			this.cusDeclaration_ID = cusDeclaration_ID;
			this.supplier_ID = supplier_ID;
			this.hs_Code = hs_Code;
			this.bl_No = bl_No;
			this.comInv_No = comInv_No;
			this.bank_ID = bank_ID;
			this.branch_ID = branch_ID;
			this.bankLc_No = bankLc_No;
			this.container_No = container_No;
			this.grn_ID = grn_ID;
			this.currency_ID = currency_ID;
			this.itemCost = itemCost;
			this.incoterm_ID = incoterm_ID;
			this.carriageCost = carriageCost;
			this.insuranceCost = insuranceCost;
			this.freightCost = freightCost;
			this.portCost = portCost;
			this.demurrageCost = demurrageCost;
			this.demurrageDays = demurrageDays;
			this.portTax1 = portTax1;
			this.portTax2 = portTax2;
			this.portTax3 = portTax3;
			this.portVat = portVat;
			this.customsPanaltyCost = customsPanaltyCost;
			this.customsTax1 = customsTax1;
			this.customsTax2 = customsTax2;
			this.customsTax3 = customsTax3;
			this.customsVat = customsVat;
			this.inboundTransportCost = inboundTransportCost;
			this.inboundTransportTax = inboundTransportTax;
			this.inboundTransportNbt = inboundTransportNbt;
			this.inboundTransportVat = inboundTransportVat;
			this.clearingAgentCost = clearingAgentCost;
			this.clearingAgentTax = clearingAgentTax;
			this.clearingAgentNbt = clearingAgentNbt;
			this.clearingAgentVat = clearingAgentVat;
			this.lcCost = lcCost;
			this.lcInterest = lcInterest;
			this.lcTax = lcTax;
			this.lcNBT = lcNBT;
			this.lcVAT = lcVAT;
			this.subTotal = subTotal;
			this.preCost = preCost;
			this.profitMargin = profitMargin;
			this.salesCost = salesCost;
			this.remarks1 = remarks1;
			this.remarks2 = remarks2;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Ic_ID value.
		/// </summary>
		public int Ic_ID {
			get { return ic_ID; }
			set { ic_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CusDeclaration_ID value.
		/// </summary>
		public string CusDeclaration_ID {
			get { return cusDeclaration_ID; }
			set { cusDeclaration_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Hs_Code value.
		/// </summary>
		public string Hs_Code {
			get { return hs_Code; }
			set { hs_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bl_No value.
		/// </summary>
		public string Bl_No {
			get { return bl_No; }
			set { bl_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the ComInv_No value.
		/// </summary>
		public string ComInv_No {
			get { return comInv_No; }
			set { comInv_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankLc_No value.
		/// </summary>
		public string BankLc_No {
			get { return bankLc_No; }
			set { bankLc_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Container_No value.
		/// </summary>
		public string Container_No {
			get { return container_No; }
			set { container_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Grn_ID value.
		/// </summary>
		public string Grn_ID {
			get { return grn_ID; }
			set { grn_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCost value.
		/// </summary>
		public decimal ItemCost {
			get { return itemCost; }
			set { itemCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the Incoterm_ID value.
		/// </summary>
		public decimal Incoterm_ID {
			get { return incoterm_ID; }
			set { incoterm_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CarriageCost value.
		/// </summary>
		public decimal CarriageCost {
			get { return carriageCost; }
			set { carriageCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the InsuranceCost value.
		/// </summary>
		public decimal InsuranceCost {
			get { return insuranceCost; }
			set { insuranceCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the FreightCost value.
		/// </summary>
		public decimal FreightCost {
			get { return freightCost; }
			set { freightCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the PortCost value.
		/// </summary>
		public decimal PortCost {
			get { return portCost; }
			set { portCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the DemurrageCost value.
		/// </summary>
		public decimal DemurrageCost {
			get { return demurrageCost; }
			set { demurrageCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the DemurrageDays value.
		/// </summary>
		public decimal DemurrageDays {
			get { return demurrageDays; }
			set { demurrageDays = value; }
		}
		
		/// <summary>
		/// Gets or sets the PortTax1 value.
		/// </summary>
		public decimal PortTax1 {
			get { return portTax1; }
			set { portTax1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PortTax2 value.
		/// </summary>
		public decimal PortTax2 {
			get { return portTax2; }
			set { portTax2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PortTax3 value.
		/// </summary>
		public decimal PortTax3 {
			get { return portTax3; }
			set { portTax3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PortVat value.
		/// </summary>
		public decimal PortVat {
			get { return portVat; }
			set { portVat = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomsPanaltyCost value.
		/// </summary>
		public decimal CustomsPanaltyCost {
			get { return customsPanaltyCost; }
			set { customsPanaltyCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomsTax1 value.
		/// </summary>
		public decimal CustomsTax1 {
			get { return customsTax1; }
			set { customsTax1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomsTax2 value.
		/// </summary>
		public decimal CustomsTax2 {
			get { return customsTax2; }
			set { customsTax2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomsTax3 value.
		/// </summary>
		public decimal CustomsTax3 {
			get { return customsTax3; }
			set { customsTax3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomsVat value.
		/// </summary>
		public decimal CustomsVat {
			get { return customsVat; }
			set { customsVat = value; }
		}
		
		/// <summary>
		/// Gets or sets the InboundTransportCost value.
		/// </summary>
		public decimal InboundTransportCost {
			get { return inboundTransportCost; }
			set { inboundTransportCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the InboundTransportTax value.
		/// </summary>
		public decimal InboundTransportTax {
			get { return inboundTransportTax; }
			set { inboundTransportTax = value; }
		}
		
		/// <summary>
		/// Gets or sets the InboundTransportNbt value.
		/// </summary>
		public decimal InboundTransportNbt {
			get { return inboundTransportNbt; }
			set { inboundTransportNbt = value; }
		}
		
		/// <summary>
		/// Gets or sets the InboundTransportVat value.
		/// </summary>
		public decimal InboundTransportVat {
			get { return inboundTransportVat; }
			set { inboundTransportVat = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClearingAgentCost value.
		/// </summary>
		public decimal ClearingAgentCost {
			get { return clearingAgentCost; }
			set { clearingAgentCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClearingAgentTax value.
		/// </summary>
		public decimal ClearingAgentTax {
			get { return clearingAgentTax; }
			set { clearingAgentTax = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClearingAgentNbt value.
		/// </summary>
		public decimal ClearingAgentNbt {
			get { return clearingAgentNbt; }
			set { clearingAgentNbt = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClearingAgentVat value.
		/// </summary>
		public decimal ClearingAgentVat {
			get { return clearingAgentVat; }
			set { clearingAgentVat = value; }
		}
		
		/// <summary>
		/// Gets or sets the LcCost value.
		/// </summary>
		public decimal LcCost {
			get { return lcCost; }
			set { lcCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the LcInterest value.
		/// </summary>
		public decimal LcInterest {
			get { return lcInterest; }
			set { lcInterest = value; }
		}
		
		/// <summary>
		/// Gets or sets the LcTax value.
		/// </summary>
		public decimal LcTax {
			get { return lcTax; }
			set { lcTax = value; }
		}
		
		/// <summary>
		/// Gets or sets the LcNBT value.
		/// </summary>
		public decimal LcNBT {
			get { return lcNBT; }
			set { lcNBT = value; }
		}
		
		/// <summary>
		/// Gets or sets the LcVAT value.
		/// </summary>
		public decimal LcVAT {
			get { return lcVAT; }
			set { lcVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubTotal value.
		/// </summary>
		public decimal SubTotal {
			get { return subTotal; }
			set { subTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreCost value.
		/// </summary>
		public decimal PreCost {
			get { return preCost; }
			set { preCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProfitMargin value.
		/// </summary>
		public decimal ProfitMargin {
			get { return profitMargin; }
			set { profitMargin = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesCost value.
		/// </summary>
		public decimal SalesCost {
			get { return salesCost; }
			set { salesCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks1 value.
		/// </summary>
		public string Remarks1 {
			get { return remarks1; }
			set { remarks1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks2 value.
		/// </summary>
		public string Remarks2 {
			get { return remarks2; }
			set { remarks2 = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsImportCosting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@ic_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cusDeclaration_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@hs_Code", SqlDbType.VarChar,50);
			scom.Parameters.Add("@bl_No", SqlDbType.VarChar,50);
			scom.Parameters.Add("@comInv_No", SqlDbType.VarChar,50);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankLc_No", SqlDbType.VarChar,50);
			scom.Parameters.Add("@container_No", SqlDbType.VarChar,50);
			scom.Parameters.Add("@grn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@incoterm_ID", SqlDbType.Decimal,9);
			scom.Parameters.Add("@carriageCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@insuranceCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@freightCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@demurrageCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@demurrageDays", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portTax1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portTax2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portTax3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portVat", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsPanaltyCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsTax1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsTax2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsTax3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsVat", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inboundTransportCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inboundTransportTax", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inboundTransportNbt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inboundTransportVat", SqlDbType.Decimal,9);
			scom.Parameters.Add("@clearingAgentCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@clearingAgentTax", SqlDbType.Decimal,9);
			scom.Parameters.Add("@clearingAgentNbt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@clearingAgentVat", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcInterest", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcTax", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcNBT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@preCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@profitMargin", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salesCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks1", SqlDbType.VarChar,250);
			scom.Parameters.Add("@remarks2", SqlDbType.VarChar,250);
 
			scom.Parameters["@ic_ID"].Value = ic_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@cusDeclaration_ID"].Value = cusDeclaration_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@hs_Code"].Value = hs_Code;
			scom.Parameters["@bl_No"].Value = bl_No;
			scom.Parameters["@comInv_No"].Value = comInv_No;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@bankLc_No"].Value = bankLc_No;
			scom.Parameters["@container_No"].Value = container_No;
			scom.Parameters["@grn_ID"].Value = grn_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@itemCost"].Value = itemCost;
			scom.Parameters["@incoterm_ID"].Value = incoterm_ID;
			scom.Parameters["@carriageCost"].Value = carriageCost;
			scom.Parameters["@insuranceCost"].Value = insuranceCost;
			scom.Parameters["@freightCost"].Value = freightCost;
			scom.Parameters["@portCost"].Value = portCost;
			scom.Parameters["@demurrageCost"].Value = demurrageCost;
			scom.Parameters["@demurrageDays"].Value = demurrageDays;
			scom.Parameters["@portTax1"].Value = portTax1;
			scom.Parameters["@portTax2"].Value = portTax2;
			scom.Parameters["@portTax3"].Value = portTax3;
			scom.Parameters["@portVat"].Value = portVat;
			scom.Parameters["@customsPanaltyCost"].Value = customsPanaltyCost;
			scom.Parameters["@customsTax1"].Value = customsTax1;
			scom.Parameters["@customsTax2"].Value = customsTax2;
			scom.Parameters["@customsTax3"].Value = customsTax3;
			scom.Parameters["@customsVat"].Value = customsVat;
			scom.Parameters["@inboundTransportCost"].Value = inboundTransportCost;
			scom.Parameters["@inboundTransportTax"].Value = inboundTransportTax;
			scom.Parameters["@inboundTransportNbt"].Value = inboundTransportNbt;
			scom.Parameters["@inboundTransportVat"].Value = inboundTransportVat;
			scom.Parameters["@clearingAgentCost"].Value = clearingAgentCost;
			scom.Parameters["@clearingAgentTax"].Value = clearingAgentTax;
			scom.Parameters["@clearingAgentNbt"].Value = clearingAgentNbt;
			scom.Parameters["@clearingAgentVat"].Value = clearingAgentVat;
			scom.Parameters["@lcCost"].Value = lcCost;
			scom.Parameters["@lcInterest"].Value = lcInterest;
			scom.Parameters["@lcTax"].Value = lcTax;
			scom.Parameters["@lcNBT"].Value = lcNBT;
			scom.Parameters["@lcVAT"].Value = lcVAT;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@preCost"].Value = preCost;
			scom.Parameters["@profitMargin"].Value = profitMargin;
			scom.Parameters["@salesCost"].Value = salesCost;
			scom.Parameters["@remarks1"].Value = remarks1;
			scom.Parameters["@remarks2"].Value = remarks2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsImportCosting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@ic_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cusDeclaration_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@hs_Code", SqlDbType.VarChar,50);
			scom.Parameters.Add("@bl_No", SqlDbType.VarChar,50);
			scom.Parameters.Add("@comInv_No", SqlDbType.VarChar,50);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankLc_No", SqlDbType.VarChar,50);
			scom.Parameters.Add("@container_No", SqlDbType.VarChar,50);
			scom.Parameters.Add("@grn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@incoterm_ID", SqlDbType.Decimal,9);
			scom.Parameters.Add("@carriageCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@insuranceCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@freightCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@demurrageCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@demurrageDays", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portTax1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portTax2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portTax3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@portVat", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsPanaltyCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsTax1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsTax2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsTax3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customsVat", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inboundTransportCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inboundTransportTax", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inboundTransportNbt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@inboundTransportVat", SqlDbType.Decimal,9);
			scom.Parameters.Add("@clearingAgentCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@clearingAgentTax", SqlDbType.Decimal,9);
			scom.Parameters.Add("@clearingAgentNbt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@clearingAgentVat", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcInterest", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcTax", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcNBT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lcVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@preCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@profitMargin", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salesCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks1", SqlDbType.VarChar,250);
			scom.Parameters.Add("@remarks2", SqlDbType.VarChar,250);
 
 
			scom.Parameters["@ic_ID"].Value = ic_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@cusDeclaration_ID"].Value = cusDeclaration_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@hs_Code"].Value = hs_Code;
			scom.Parameters["@bl_No"].Value = bl_No;
			scom.Parameters["@comInv_No"].Value = comInv_No;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@bankLc_No"].Value = bankLc_No;
			scom.Parameters["@container_No"].Value = container_No;
			scom.Parameters["@grn_ID"].Value = grn_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@itemCost"].Value = itemCost;
			scom.Parameters["@incoterm_ID"].Value = incoterm_ID;
			scom.Parameters["@carriageCost"].Value = carriageCost;
			scom.Parameters["@insuranceCost"].Value = insuranceCost;
			scom.Parameters["@freightCost"].Value = freightCost;
			scom.Parameters["@portCost"].Value = portCost;
			scom.Parameters["@demurrageCost"].Value = demurrageCost;
			scom.Parameters["@demurrageDays"].Value = demurrageDays;
			scom.Parameters["@portTax1"].Value = portTax1;
			scom.Parameters["@portTax2"].Value = portTax2;
			scom.Parameters["@portTax3"].Value = portTax3;
			scom.Parameters["@portVat"].Value = portVat;
			scom.Parameters["@customsPanaltyCost"].Value = customsPanaltyCost;
			scom.Parameters["@customsTax1"].Value = customsTax1;
			scom.Parameters["@customsTax2"].Value = customsTax2;
			scom.Parameters["@customsTax3"].Value = customsTax3;
			scom.Parameters["@customsVat"].Value = customsVat;
			scom.Parameters["@inboundTransportCost"].Value = inboundTransportCost;
			scom.Parameters["@inboundTransportTax"].Value = inboundTransportTax;
			scom.Parameters["@inboundTransportNbt"].Value = inboundTransportNbt;
			scom.Parameters["@inboundTransportVat"].Value = inboundTransportVat;
			scom.Parameters["@clearingAgentCost"].Value = clearingAgentCost;
			scom.Parameters["@clearingAgentTax"].Value = clearingAgentTax;
			scom.Parameters["@clearingAgentNbt"].Value = clearingAgentNbt;
			scom.Parameters["@clearingAgentVat"].Value = clearingAgentVat;
			scom.Parameters["@lcCost"].Value = lcCost;
			scom.Parameters["@lcInterest"].Value = lcInterest;
			scom.Parameters["@lcTax"].Value = lcTax;
			scom.Parameters["@lcNBT"].Value = lcNBT;
			scom.Parameters["@lcVAT"].Value = lcVAT;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@preCost"].Value = preCost;
			scom.Parameters["@profitMargin"].Value = profitMargin;
			scom.Parameters["@salesCost"].Value = salesCost;
			scom.Parameters["@remarks1"].Value = remarks1;
			scom.Parameters["@remarks2"].Value = remarks2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsImportCosting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@ic_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@ic_ID"].Value = ic_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static void DeleteAllByGrn_ID(string grn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingDeleteAllByGrn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@grn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@grn_ID"].Value = grn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static void DeleteAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingDeleteAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static void DeleteAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingDeleteAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsImportCosting table.
		/// </summary>
		public static tbl_scsImportCosting Select(int ic_ID_Incoming, string item_ID_Incoming){

			tbl_scsImportCosting tbl_scsImportCostingins = new tbl_scsImportCosting();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@ic_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@ic_ID"].Value = ic_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsImportCostingins = Maketbl_scsImportCosting(dataReader);
				} else {
					tbl_scsImportCostingins = null;
				}
			}
			scon.Close();
			return tbl_scsImportCostingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table.
		/// </summary>
		public static List<tbl_scsImportCosting> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsImportCosting> tbl_scsImportCostingList = new List<tbl_scsImportCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsImportCosting tbl_scsImportCosting = Maketbl_scsImportCosting(dataReader);
					tbl_scsImportCostingList.Add(tbl_scsImportCosting);
				}
			}
			scon.Close();
			return tbl_scsImportCostingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static List<tbl_scsImportCosting> SelectAllByGrn_ID(string grn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingSelectAllByGrn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@grn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@grn_ID"].Value = grn_ID;
				List<tbl_scsImportCosting> tbl_scsImportCostingList = new List<tbl_scsImportCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsImportCosting tbl_scsImportCosting = Maketbl_scsImportCosting(dataReader);
					tbl_scsImportCostingList.Add(tbl_scsImportCosting);
				}
			}
			scon.Close();
			return tbl_scsImportCostingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static List<tbl_scsImportCosting> SelectAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingSelectAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
				List<tbl_scsImportCosting> tbl_scsImportCostingList = new List<tbl_scsImportCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsImportCosting tbl_scsImportCosting = Maketbl_scsImportCosting(dataReader);
					tbl_scsImportCostingList.Add(tbl_scsImportCosting);
				}
			}
			scon.Close();
			return tbl_scsImportCostingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static List<tbl_scsImportCosting> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsImportCosting> tbl_scsImportCostingList = new List<tbl_scsImportCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsImportCosting tbl_scsImportCosting = Maketbl_scsImportCosting(dataReader);
					tbl_scsImportCostingList.Add(tbl_scsImportCosting);
				}
			}
			scon.Close();
			return tbl_scsImportCostingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static List<tbl_scsImportCosting> SelectAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingSelectAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
				List<tbl_scsImportCosting> tbl_scsImportCostingList = new List<tbl_scsImportCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsImportCosting tbl_scsImportCosting = Maketbl_scsImportCosting(dataReader);
					tbl_scsImportCostingList.Add(tbl_scsImportCosting);
				}
			}
			scon.Close();
			return tbl_scsImportCostingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static List<tbl_scsImportCosting> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_scsImportCosting> tbl_scsImportCostingList = new List<tbl_scsImportCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsImportCosting tbl_scsImportCosting = Maketbl_scsImportCosting(dataReader);
					tbl_scsImportCostingList.Add(tbl_scsImportCosting);
				}
			}
			scon.Close();
			return tbl_scsImportCostingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsImportCosting table by a foreign key.
		/// </summary>
		public static List<tbl_scsImportCosting> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsImportCostingSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_scsImportCosting> tbl_scsImportCostingList = new List<tbl_scsImportCosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsImportCosting tbl_scsImportCosting = Maketbl_scsImportCosting(dataReader);
					tbl_scsImportCostingList.Add(tbl_scsImportCosting);
				}
			}
			scon.Close();
			return tbl_scsImportCostingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsImportCosting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsImportCosting Maketbl_scsImportCosting(SqlDataReader dataReader) {
			tbl_scsImportCosting tbl_scsImportCosting = new tbl_scsImportCosting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsImportCosting.Ic_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsImportCosting.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsImportCosting.CusDeclaration_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsImportCosting.Supplier_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsImportCosting.Hs_Code = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsImportCosting.Bl_No = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsImportCosting.ComInv_No = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsImportCosting.Bank_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsImportCosting.Branch_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsImportCosting.BankLc_No = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsImportCosting.Container_No = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsImportCosting.Grn_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsImportCosting.Currency_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsImportCosting.ItemCost = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsImportCosting.Incoterm_ID = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsImportCosting.CarriageCost = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsImportCosting.InsuranceCost = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsImportCosting.FreightCost = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsImportCosting.PortCost = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsImportCosting.DemurrageCost = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsImportCosting.DemurrageDays = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsImportCosting.PortTax1 = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsImportCosting.PortTax2 = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsImportCosting.PortTax3 = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsImportCosting.PortVat = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsImportCosting.CustomsPanaltyCost = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsImportCosting.CustomsTax1 = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_scsImportCosting.CustomsTax2 = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_scsImportCosting.CustomsTax3 = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_scsImportCosting.CustomsVat = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_scsImportCosting.InboundTransportCost = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_scsImportCosting.InboundTransportTax = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_scsImportCosting.InboundTransportNbt = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_scsImportCosting.InboundTransportVat = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_scsImportCosting.ClearingAgentCost = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_scsImportCosting.ClearingAgentTax = dataReader.GetDecimal(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_scsImportCosting.ClearingAgentNbt = dataReader.GetDecimal(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_scsImportCosting.ClearingAgentVat = dataReader.GetDecimal(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_scsImportCosting.LcCost = dataReader.GetDecimal(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_scsImportCosting.LcInterest = dataReader.GetDecimal(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_scsImportCosting.LcTax = dataReader.GetDecimal(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_scsImportCosting.LcNBT = dataReader.GetDecimal(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_scsImportCosting.LcVAT = dataReader.GetDecimal(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_scsImportCosting.SubTotal = dataReader.GetDecimal(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_scsImportCosting.PreCost = dataReader.GetDecimal(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_scsImportCosting.ProfitMargin = dataReader.GetDecimal(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_scsImportCosting.SalesCost = dataReader.GetDecimal(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_scsImportCosting.Remarks1 = dataReader.GetString(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_scsImportCosting.Remarks2 = dataReader.GetString(48);
			}

			return tbl_scsImportCosting;
		}
		/// <summary>
		/// This makes tbl_scsImportCosting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsImportCosting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsImportCosting  tbl_scsImportCosting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_ic_ID = new DataColumn("ic_ID" , typeof(int));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_cusDeclaration_ID = new DataColumn("cusDeclaration_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_hs_Code = new DataColumn("hs_Code" , typeof(string));
			DataColumn col_bl_No = new DataColumn("bl_No" , typeof(string));
			DataColumn col_comInv_No = new DataColumn("comInv_No" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_bankLc_No = new DataColumn("bankLc_No" , typeof(string));
			DataColumn col_container_No = new DataColumn("container_No" , typeof(string));
			DataColumn col_grn_ID = new DataColumn("grn_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_itemCost = new DataColumn("itemCost" , typeof(decimal));
			DataColumn col_incoterm_ID = new DataColumn("incoterm_ID" , typeof(decimal));
			DataColumn col_carriageCost = new DataColumn("carriageCost" , typeof(decimal));
			DataColumn col_insuranceCost = new DataColumn("insuranceCost" , typeof(decimal));
			DataColumn col_freightCost = new DataColumn("freightCost" , typeof(decimal));
			DataColumn col_portCost = new DataColumn("portCost" , typeof(decimal));
			DataColumn col_demurrageCost = new DataColumn("demurrageCost" , typeof(decimal));
			DataColumn col_demurrageDays = new DataColumn("demurrageDays" , typeof(decimal));
			DataColumn col_portTax1 = new DataColumn("portTax1" , typeof(decimal));
			DataColumn col_portTax2 = new DataColumn("portTax2" , typeof(decimal));
			DataColumn col_portTax3 = new DataColumn("portTax3" , typeof(decimal));
			DataColumn col_portVat = new DataColumn("portVat" , typeof(decimal));
			DataColumn col_customsPanaltyCost = new DataColumn("customsPanaltyCost" , typeof(decimal));
			DataColumn col_customsTax1 = new DataColumn("customsTax1" , typeof(decimal));
			DataColumn col_customsTax2 = new DataColumn("customsTax2" , typeof(decimal));
			DataColumn col_customsTax3 = new DataColumn("customsTax3" , typeof(decimal));
			DataColumn col_customsVat = new DataColumn("customsVat" , typeof(decimal));
			DataColumn col_inboundTransportCost = new DataColumn("inboundTransportCost" , typeof(decimal));
			DataColumn col_inboundTransportTax = new DataColumn("inboundTransportTax" , typeof(decimal));
			DataColumn col_inboundTransportNbt = new DataColumn("inboundTransportNbt" , typeof(decimal));
			DataColumn col_inboundTransportVat = new DataColumn("inboundTransportVat" , typeof(decimal));
			DataColumn col_clearingAgentCost = new DataColumn("clearingAgentCost" , typeof(decimal));
			DataColumn col_clearingAgentTax = new DataColumn("clearingAgentTax" , typeof(decimal));
			DataColumn col_clearingAgentNbt = new DataColumn("clearingAgentNbt" , typeof(decimal));
			DataColumn col_clearingAgentVat = new DataColumn("clearingAgentVat" , typeof(decimal));
			DataColumn col_lcCost = new DataColumn("lcCost" , typeof(decimal));
			DataColumn col_lcInterest = new DataColumn("lcInterest" , typeof(decimal));
			DataColumn col_lcTax = new DataColumn("lcTax" , typeof(decimal));
			DataColumn col_lcNBT = new DataColumn("lcNBT" , typeof(decimal));
			DataColumn col_lcVAT = new DataColumn("lcVAT" , typeof(decimal));
			DataColumn col_subTotal = new DataColumn("subTotal" , typeof(decimal));
			DataColumn col_preCost = new DataColumn("preCost" , typeof(decimal));
			DataColumn col_profitMargin = new DataColumn("profitMargin" , typeof(decimal));
			DataColumn col_salesCost = new DataColumn("salesCost" , typeof(decimal));
			DataColumn col_remarks1 = new DataColumn("remarks1" , typeof(string));
			DataColumn col_remarks2 = new DataColumn("remarks2" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_ic_ID,col_item_ID,col_cusDeclaration_ID,col_supplier_ID,col_hs_Code,col_bl_No,col_comInv_No,col_bank_ID,col_branch_ID,col_bankLc_No,col_container_No,col_grn_ID,col_currency_ID,col_itemCost,col_incoterm_ID,col_carriageCost,col_insuranceCost,col_freightCost,col_portCost,col_demurrageCost,col_demurrageDays,col_portTax1,col_portTax2,col_portTax3,col_portVat,col_customsPanaltyCost,col_customsTax1,col_customsTax2,col_customsTax3,col_customsVat,col_inboundTransportCost,col_inboundTransportTax,col_inboundTransportNbt,col_inboundTransportVat,col_clearingAgentCost,col_clearingAgentTax,col_clearingAgentNbt,col_clearingAgentVat,col_lcCost,col_lcInterest,col_lcTax,col_lcNBT,col_lcVAT,col_subTotal,col_preCost,col_profitMargin,col_salesCost,col_remarks1,col_remarks2,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsImportCosting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsImportCosting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsImportCosting user) {
		DataRow drow = dt.NewRow();
		
			drow["ic_ID"] = user.ic_ID;
			drow["item_ID"] = user.item_ID;
			drow["cusDeclaration_ID"] = user.cusDeclaration_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["hs_Code"] = user.hs_Code;
			drow["bl_No"] = user.bl_No;
			drow["comInv_No"] = user.comInv_No;
			drow["bank_ID"] = user.bank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["bankLc_No"] = user.bankLc_No;
			drow["container_No"] = user.container_No;
			drow["grn_ID"] = user.grn_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["itemCost"] = user.itemCost;
			drow["incoterm_ID"] = user.incoterm_ID;
			drow["carriageCost"] = user.carriageCost;
			drow["insuranceCost"] = user.insuranceCost;
			drow["freightCost"] = user.freightCost;
			drow["portCost"] = user.portCost;
			drow["demurrageCost"] = user.demurrageCost;
			drow["demurrageDays"] = user.demurrageDays;
			drow["portTax1"] = user.portTax1;
			drow["portTax2"] = user.portTax2;
			drow["portTax3"] = user.portTax3;
			drow["portVat"] = user.portVat;
			drow["customsPanaltyCost"] = user.customsPanaltyCost;
			drow["customsTax1"] = user.customsTax1;
			drow["customsTax2"] = user.customsTax2;
			drow["customsTax3"] = user.customsTax3;
			drow["customsVat"] = user.customsVat;
			drow["inboundTransportCost"] = user.inboundTransportCost;
			drow["inboundTransportTax"] = user.inboundTransportTax;
			drow["inboundTransportNbt"] = user.inboundTransportNbt;
			drow["inboundTransportVat"] = user.inboundTransportVat;
			drow["clearingAgentCost"] = user.clearingAgentCost;
			drow["clearingAgentTax"] = user.clearingAgentTax;
			drow["clearingAgentNbt"] = user.clearingAgentNbt;
			drow["clearingAgentVat"] = user.clearingAgentVat;
			drow["lcCost"] = user.lcCost;
			drow["lcInterest"] = user.lcInterest;
			drow["lcTax"] = user.lcTax;
			drow["lcNBT"] = user.lcNBT;
			drow["lcVAT"] = user.lcVAT;
			drow["subTotal"] = user.subTotal;
			drow["preCost"] = user.preCost;
			drow["profitMargin"] = user.profitMargin;
			drow["salesCost"] = user.salesCost;
			drow["remarks1"] = user.remarks1;
			drow["remarks2"] = user.remarks2;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
