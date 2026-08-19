using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCompanyBranchMaster {
		#region Fields
		private int lineNO;
		private string companyBranch_ID;
		private string branchName;
		private string companyCountry_ID;
		private string adress;
		private string telephone;
		private string fax;
		private string contactPerson;
		private string prefix;
		private int counter;
		private int length;
		private string cOprefix;
		private int cOcounter;
		private int cOlength;
		private string dOprefix;
		private int dOcounter;
		private int dOlength;
		private string invprefix;
		private int invcounter;
		private int invlength;
		private string cRprefix;
		private int cRcounter;
		private int cRlength;
		private string dRprefix;
		private int dRcounter;
		private int dRlength;
		private string sRprefix;
		private int sRcounter;
		private int sRlength;
		private string cUSprefix;
		private int cUScounter;
		private int cUSlength;
		private string sUPprefix;
		private int sUPcounter;
		private int sUPlength;
		private string sRTprefix;
		private int sRTcounter;
		private int sRTlength;
		private string iGRNprefix;
		private int iGRNcounter;
		private int iGRNlength;
		private string iGINprefix;
		private int iGINcounter;
		private int iGINlength;
		private int shortorder;
		private string receiptPrefix;
		private int receiptCounter;
		private int receiptLength;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyBranchMaster class.
		/// </summary>
		public tbl_genCompanyBranchMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyBranchMaster class.
		/// </summary>
		public tbl_genCompanyBranchMaster(int lineNO, string companyBranch_ID, string branchName, string companyCountry_ID, string adress, string telephone, string fax, string contactPerson, string prefix, int counter, int length, string cOprefix, int cOcounter, int cOlength, string dOprefix, int dOcounter, int dOlength, string invprefix, int invcounter, int invlength, string cRprefix, int cRcounter, int cRlength, string dRprefix, int dRcounter, int dRlength, string sRprefix, int sRcounter, int sRlength, string cUSprefix, int cUScounter, int cUSlength, string sUPprefix, int sUPcounter, int sUPlength, string sRTprefix, int sRTcounter, int sRTlength, string iGRNprefix, int iGRNcounter, int iGRNlength, string iGINprefix, int iGINcounter, int iGINlength, int shortorder, string receiptPrefix, int receiptCounter, int receiptLength) {
			this.lineNO = lineNO;
			this.companyBranch_ID = companyBranch_ID;
			this.branchName = branchName;
			this.companyCountry_ID = companyCountry_ID;
			this.adress = adress;
			this.telephone = telephone;
			this.fax = fax;
			this.contactPerson = contactPerson;
			this.prefix = prefix;
			this.counter = counter;
			this.length = length;
			this.cOprefix = cOprefix;
			this.cOcounter = cOcounter;
			this.cOlength = cOlength;
			this.dOprefix = dOprefix;
			this.dOcounter = dOcounter;
			this.dOlength = dOlength;
			this.invprefix = invprefix;
			this.invcounter = invcounter;
			this.invlength = invlength;
			this.cRprefix = cRprefix;
			this.cRcounter = cRcounter;
			this.cRlength = cRlength;
			this.dRprefix = dRprefix;
			this.dRcounter = dRcounter;
			this.dRlength = dRlength;
			this.sRprefix = sRprefix;
			this.sRcounter = sRcounter;
			this.sRlength = sRlength;
			this.cUSprefix = cUSprefix;
			this.cUScounter = cUScounter;
			this.cUSlength = cUSlength;
			this.sUPprefix = sUPprefix;
			this.sUPcounter = sUPcounter;
			this.sUPlength = sUPlength;
			this.sRTprefix = sRTprefix;
			this.sRTcounter = sRTcounter;
			this.sRTlength = sRTlength;
			this.iGRNprefix = iGRNprefix;
			this.iGRNcounter = iGRNcounter;
			this.iGRNlength = iGRNlength;
			this.iGINprefix = iGINprefix;
			this.iGINcounter = iGINcounter;
			this.iGINlength = iGINlength;
			this.shortorder = shortorder;
			this.receiptPrefix = receiptPrefix;
			this.receiptCounter = receiptCounter;
			this.receiptLength = receiptLength;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the LineNO value.
		/// </summary>
		public int LineNO {
			get { return lineNO; }
			set { lineNO = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BranchName value.
		/// </summary>
		public string BranchName {
			get { return branchName; }
			set { branchName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyCountry_ID value.
		/// </summary>
		public string CompanyCountry_ID {
			get { return companyCountry_ID; }
			set { companyCountry_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Adress value.
		/// </summary>
		public string Adress {
			get { return adress; }
			set { adress = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone {
			get { return telephone; }
			set { telephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fax value.
		/// </summary>
		public string Fax {
			get { return fax; }
			set { fax = value; }
		}
		
		/// <summary>
		/// Gets or sets the ContactPerson value.
		/// </summary>
		public string ContactPerson {
			get { return contactPerson; }
			set { contactPerson = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public int Counter {
			get { return counter; }
			set { counter = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public int Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the COprefix value.
		/// </summary>
		public string COprefix {
			get { return cOprefix; }
			set { cOprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the COcounter value.
		/// </summary>
		public int COcounter {
			get { return cOcounter; }
			set { cOcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the COlength value.
		/// </summary>
		public int COlength {
			get { return cOlength; }
			set { cOlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the DOprefix value.
		/// </summary>
		public string DOprefix {
			get { return dOprefix; }
			set { dOprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the DOcounter value.
		/// </summary>
		public int DOcounter {
			get { return dOcounter; }
			set { dOcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the DOlength value.
		/// </summary>
		public int DOlength {
			get { return dOlength; }
			set { dOlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invprefix value.
		/// </summary>
		public string Invprefix {
			get { return invprefix; }
			set { invprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invcounter value.
		/// </summary>
		public int Invcounter {
			get { return invcounter; }
			set { invcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invlength value.
		/// </summary>
		public int Invlength {
			get { return invlength; }
			set { invlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the CRprefix value.
		/// </summary>
		public string CRprefix {
			get { return cRprefix; }
			set { cRprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the CRcounter value.
		/// </summary>
		public int CRcounter {
			get { return cRcounter; }
			set { cRcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the CRlength value.
		/// </summary>
		public int CRlength {
			get { return cRlength; }
			set { cRlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the DRprefix value.
		/// </summary>
		public string DRprefix {
			get { return dRprefix; }
			set { dRprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the DRcounter value.
		/// </summary>
		public int DRcounter {
			get { return dRcounter; }
			set { dRcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the DRlength value.
		/// </summary>
		public int DRlength {
			get { return dRlength; }
			set { dRlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the SRprefix value.
		/// </summary>
		public string SRprefix {
			get { return sRprefix; }
			set { sRprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the SRcounter value.
		/// </summary>
		public int SRcounter {
			get { return sRcounter; }
			set { sRcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the SRlength value.
		/// </summary>
		public int SRlength {
			get { return sRlength; }
			set { sRlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the CUSprefix value.
		/// </summary>
		public string CUSprefix {
			get { return cUSprefix; }
			set { cUSprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the CUScounter value.
		/// </summary>
		public int CUScounter {
			get { return cUScounter; }
			set { cUScounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the CUSlength value.
		/// </summary>
		public int CUSlength {
			get { return cUSlength; }
			set { cUSlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the SUPprefix value.
		/// </summary>
		public string SUPprefix {
			get { return sUPprefix; }
			set { sUPprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the SUPcounter value.
		/// </summary>
		public int SUPcounter {
			get { return sUPcounter; }
			set { sUPcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the SUPlength value.
		/// </summary>
		public int SUPlength {
			get { return sUPlength; }
			set { sUPlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the SRTprefix value.
		/// </summary>
		public string SRTprefix {
			get { return sRTprefix; }
			set { sRTprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the SRTcounter value.
		/// </summary>
		public int SRTcounter {
			get { return sRTcounter; }
			set { sRTcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the SRTlength value.
		/// </summary>
		public int SRTlength {
			get { return sRTlength; }
			set { sRTlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the IGRNprefix value.
		/// </summary>
		public string IGRNprefix {
			get { return iGRNprefix; }
			set { iGRNprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the IGRNcounter value.
		/// </summary>
		public int IGRNcounter {
			get { return iGRNcounter; }
			set { iGRNcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the IGRNlength value.
		/// </summary>
		public int IGRNlength {
			get { return iGRNlength; }
			set { iGRNlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the IGINprefix value.
		/// </summary>
		public string IGINprefix {
			get { return iGINprefix; }
			set { iGINprefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the IGINcounter value.
		/// </summary>
		public int IGINcounter {
			get { return iGINcounter; }
			set { iGINcounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the IGINlength value.
		/// </summary>
		public int IGINlength {
			get { return iGINlength; }
			set { iGINlength = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shortorder value.
		/// </summary>
		public int Shortorder {
			get { return shortorder; }
			set { shortorder = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptPrefix value.
		/// </summary>
		public string ReceiptPrefix {
			get { return receiptPrefix; }
			set { receiptPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptCounter value.
		/// </summary>
		public int ReceiptCounter {
			get { return receiptCounter; }
			set { receiptCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptLength value.
		/// </summary>
		public int ReceiptLength {
			get { return receiptLength; }
			set { receiptLength = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCompanyBranchMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyBranchMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@LineNO", SqlDbType.Int,4);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyCountry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@COprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@COcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@COlength", SqlDbType.Int,4);
			scom.Parameters.Add("@DOprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@DOcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@DOlength", SqlDbType.Int,4);
			scom.Parameters.Add("@Invprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@Invcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@Invlength", SqlDbType.Int,4);
			scom.Parameters.Add("@CRprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@CRcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@CRlength", SqlDbType.Int,4);
			scom.Parameters.Add("@DRprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@DRcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@DRlength", SqlDbType.Int,4);
			scom.Parameters.Add("@SRprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@SRcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@SRlength", SqlDbType.Int,4);
			scom.Parameters.Add("@CUSprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@CUScounter", SqlDbType.Int,4);
			scom.Parameters.Add("@CUSlength", SqlDbType.Int,4);
			scom.Parameters.Add("@SUPprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@SUPcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@SUPlength", SqlDbType.Int,4);
			scom.Parameters.Add("@SRTprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@SRTcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@SRTlength", SqlDbType.Int,4);
			scom.Parameters.Add("@IGRNprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@IGRNcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@IGRNlength", SqlDbType.Int,4);
			scom.Parameters.Add("@IGINprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@IGINcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@IGINlength", SqlDbType.Int,4);
			scom.Parameters.Add("@Shortorder", SqlDbType.Int,4);
			scom.Parameters.Add("@ReceiptPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ReceiptCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@ReceiptLength", SqlDbType.Int,4);
 
			scom.Parameters["@LineNO"].Value = lineNO;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@companyCountry_ID"].Value = companyCountry_ID;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@COprefix"].Value = cOprefix;
			scom.Parameters["@COcounter"].Value = cOcounter;
			scom.Parameters["@COlength"].Value = cOlength;
			scom.Parameters["@DOprefix"].Value = dOprefix;
			scom.Parameters["@DOcounter"].Value = dOcounter;
			scom.Parameters["@DOlength"].Value = dOlength;
			scom.Parameters["@Invprefix"].Value = invprefix;
			scom.Parameters["@Invcounter"].Value = invcounter;
			scom.Parameters["@Invlength"].Value = invlength;
			scom.Parameters["@CRprefix"].Value = cRprefix;
			scom.Parameters["@CRcounter"].Value = cRcounter;
			scom.Parameters["@CRlength"].Value = cRlength;
			scom.Parameters["@DRprefix"].Value = dRprefix;
			scom.Parameters["@DRcounter"].Value = dRcounter;
			scom.Parameters["@DRlength"].Value = dRlength;
			scom.Parameters["@SRprefix"].Value = sRprefix;
			scom.Parameters["@SRcounter"].Value = sRcounter;
			scom.Parameters["@SRlength"].Value = sRlength;
			scom.Parameters["@CUSprefix"].Value = cUSprefix;
			scom.Parameters["@CUScounter"].Value = cUScounter;
			scom.Parameters["@CUSlength"].Value = cUSlength;
			scom.Parameters["@SUPprefix"].Value = sUPprefix;
			scom.Parameters["@SUPcounter"].Value = sUPcounter;
			scom.Parameters["@SUPlength"].Value = sUPlength;
			scom.Parameters["@SRTprefix"].Value = sRTprefix;
			scom.Parameters["@SRTcounter"].Value = sRTcounter;
			scom.Parameters["@SRTlength"].Value = sRTlength;
			scom.Parameters["@IGRNprefix"].Value = iGRNprefix;
			scom.Parameters["@IGRNcounter"].Value = iGRNcounter;
			scom.Parameters["@IGRNlength"].Value = iGRNlength;
			scom.Parameters["@IGINprefix"].Value = iGINprefix;
			scom.Parameters["@IGINcounter"].Value = iGINcounter;
			scom.Parameters["@IGINlength"].Value = iGINlength;
			scom.Parameters["@Shortorder"].Value = shortorder;
			scom.Parameters["@ReceiptPrefix"].Value = receiptPrefix;
			scom.Parameters["@ReceiptCounter"].Value = receiptCounter;
			scom.Parameters["@ReceiptLength"].Value = receiptLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCompanyBranchMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyBranchMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@LineNO", SqlDbType.Int,4);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyCountry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@COprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@COcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@COlength", SqlDbType.Int,4);
			scom.Parameters.Add("@DOprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@DOcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@DOlength", SqlDbType.Int,4);
			scom.Parameters.Add("@Invprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@Invcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@Invlength", SqlDbType.Int,4);
			scom.Parameters.Add("@CRprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@CRcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@CRlength", SqlDbType.Int,4);
			scom.Parameters.Add("@DRprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@DRcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@DRlength", SqlDbType.Int,4);
			scom.Parameters.Add("@SRprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@SRcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@SRlength", SqlDbType.Int,4);
			scom.Parameters.Add("@CUSprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@CUScounter", SqlDbType.Int,4);
			scom.Parameters.Add("@CUSlength", SqlDbType.Int,4);
			scom.Parameters.Add("@SUPprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@SUPcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@SUPlength", SqlDbType.Int,4);
			scom.Parameters.Add("@SRTprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@SRTcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@SRTlength", SqlDbType.Int,4);
			scom.Parameters.Add("@IGRNprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@IGRNcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@IGRNlength", SqlDbType.Int,4);
			scom.Parameters.Add("@IGINprefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@IGINcounter", SqlDbType.Int,4);
			scom.Parameters.Add("@IGINlength", SqlDbType.Int,4);
			scom.Parameters.Add("@Shortorder", SqlDbType.Int,4);
			scom.Parameters.Add("@ReceiptPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ReceiptCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@ReceiptLength", SqlDbType.Int,4);
 
 
			scom.Parameters["@LineNO"].Value = lineNO;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@companyCountry_ID"].Value = companyCountry_ID;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@COprefix"].Value = cOprefix;
			scom.Parameters["@COcounter"].Value = cOcounter;
			scom.Parameters["@COlength"].Value = cOlength;
			scom.Parameters["@DOprefix"].Value = dOprefix;
			scom.Parameters["@DOcounter"].Value = dOcounter;
			scom.Parameters["@DOlength"].Value = dOlength;
			scom.Parameters["@Invprefix"].Value = invprefix;
			scom.Parameters["@Invcounter"].Value = invcounter;
			scom.Parameters["@Invlength"].Value = invlength;
			scom.Parameters["@CRprefix"].Value = cRprefix;
			scom.Parameters["@CRcounter"].Value = cRcounter;
			scom.Parameters["@CRlength"].Value = cRlength;
			scom.Parameters["@DRprefix"].Value = dRprefix;
			scom.Parameters["@DRcounter"].Value = dRcounter;
			scom.Parameters["@DRlength"].Value = dRlength;
			scom.Parameters["@SRprefix"].Value = sRprefix;
			scom.Parameters["@SRcounter"].Value = sRcounter;
			scom.Parameters["@SRlength"].Value = sRlength;
			scom.Parameters["@CUSprefix"].Value = cUSprefix;
			scom.Parameters["@CUScounter"].Value = cUScounter;
			scom.Parameters["@CUSlength"].Value = cUSlength;
			scom.Parameters["@SUPprefix"].Value = sUPprefix;
			scom.Parameters["@SUPcounter"].Value = sUPcounter;
			scom.Parameters["@SUPlength"].Value = sUPlength;
			scom.Parameters["@SRTprefix"].Value = sRTprefix;
			scom.Parameters["@SRTcounter"].Value = sRTcounter;
			scom.Parameters["@SRTlength"].Value = sRTlength;
			scom.Parameters["@IGRNprefix"].Value = iGRNprefix;
			scom.Parameters["@IGRNcounter"].Value = iGRNcounter;
			scom.Parameters["@IGRNlength"].Value = iGRNlength;
			scom.Parameters["@IGINprefix"].Value = iGINprefix;
			scom.Parameters["@IGINcounter"].Value = iGINcounter;
			scom.Parameters["@IGINlength"].Value = iGINlength;
			scom.Parameters["@Shortorder"].Value = shortorder;
			scom.Parameters["@ReceiptPrefix"].Value = receiptPrefix;
			scom.Parameters["@ReceiptCounter"].Value = receiptCounter;
			scom.Parameters["@ReceiptLength"].Value = receiptLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCompanyBranchMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyBranchMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyBranchMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyCountry_ID(string companyCountry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyBranchMasterDeleteAllByCompanyCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyCountry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyCountry_ID"].Value = companyCountry_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCompanyBranchMaster table.
		/// </summary>
		public static tbl_genCompanyBranchMaster Select(string companyBranch_ID_Incoming){

			tbl_genCompanyBranchMaster tbl_genCompanyBranchMasterins = new tbl_genCompanyBranchMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyBranchMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCompanyBranchMasterins = Maketbl_genCompanyBranchMaster(dataReader);
				} else {
					tbl_genCompanyBranchMasterins = null;
				}
			}
			scon.Close();
			return tbl_genCompanyBranchMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyBranchMaster table.
		/// </summary>
		public static List<tbl_genCompanyBranchMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyBranchMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCompanyBranchMaster> tbl_genCompanyBranchMasterList = new List<tbl_genCompanyBranchMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyBranchMaster tbl_genCompanyBranchMaster = Maketbl_genCompanyBranchMaster(dataReader);
					tbl_genCompanyBranchMasterList.Add(tbl_genCompanyBranchMaster);
				}
			}
			scon.Close();
			return tbl_genCompanyBranchMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyBranchMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genCompanyBranchMaster> SelectAllByCompanyCountry_ID(string companyCountry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyBranchMasterSelectAllByCompanyCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyCountry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyCountry_ID"].Value = companyCountry_ID;
				List<tbl_genCompanyBranchMaster> tbl_genCompanyBranchMasterList = new List<tbl_genCompanyBranchMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyBranchMaster tbl_genCompanyBranchMaster = Maketbl_genCompanyBranchMaster(dataReader);
					tbl_genCompanyBranchMasterList.Add(tbl_genCompanyBranchMaster);
				}
			}
			scon.Close();
			return tbl_genCompanyBranchMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCompanyBranchMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCompanyBranchMaster Maketbl_genCompanyBranchMaster(SqlDataReader dataReader) {
			tbl_genCompanyBranchMaster tbl_genCompanyBranchMaster = new tbl_genCompanyBranchMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCompanyBranchMaster.LineNO = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCompanyBranchMaster.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCompanyBranchMaster.BranchName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCompanyBranchMaster.CompanyCountry_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCompanyBranchMaster.Adress = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genCompanyBranchMaster.Telephone = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genCompanyBranchMaster.Fax = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genCompanyBranchMaster.ContactPerson = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genCompanyBranchMaster.Prefix = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genCompanyBranchMaster.Counter = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genCompanyBranchMaster.Length = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genCompanyBranchMaster.COprefix = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genCompanyBranchMaster.COcounter = dataReader.GetInt32(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genCompanyBranchMaster.COlength = dataReader.GetInt32(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genCompanyBranchMaster.DOprefix = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genCompanyBranchMaster.DOcounter = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genCompanyBranchMaster.DOlength = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genCompanyBranchMaster.Invprefix = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genCompanyBranchMaster.Invcounter = dataReader.GetInt32(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genCompanyBranchMaster.Invlength = dataReader.GetInt32(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genCompanyBranchMaster.CRprefix = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genCompanyBranchMaster.CRcounter = dataReader.GetInt32(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genCompanyBranchMaster.CRlength = dataReader.GetInt32(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genCompanyBranchMaster.DRprefix = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genCompanyBranchMaster.DRcounter = dataReader.GetInt32(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genCompanyBranchMaster.DRlength = dataReader.GetInt32(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genCompanyBranchMaster.SRprefix = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_genCompanyBranchMaster.SRcounter = dataReader.GetInt32(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_genCompanyBranchMaster.SRlength = dataReader.GetInt32(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_genCompanyBranchMaster.CUSprefix = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_genCompanyBranchMaster.CUScounter = dataReader.GetInt32(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_genCompanyBranchMaster.CUSlength = dataReader.GetInt32(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_genCompanyBranchMaster.SUPprefix = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_genCompanyBranchMaster.SUPcounter = dataReader.GetInt32(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_genCompanyBranchMaster.SUPlength = dataReader.GetInt32(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_genCompanyBranchMaster.SRTprefix = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_genCompanyBranchMaster.SRTcounter = dataReader.GetInt32(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_genCompanyBranchMaster.SRTlength = dataReader.GetInt32(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_genCompanyBranchMaster.IGRNprefix = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_genCompanyBranchMaster.IGRNcounter = dataReader.GetInt32(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_genCompanyBranchMaster.IGRNlength = dataReader.GetInt32(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_genCompanyBranchMaster.IGINprefix = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_genCompanyBranchMaster.IGINcounter = dataReader.GetInt32(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_genCompanyBranchMaster.IGINlength = dataReader.GetInt32(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_genCompanyBranchMaster.Shortorder = dataReader.GetInt32(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_genCompanyBranchMaster.ReceiptPrefix = dataReader.GetString(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_genCompanyBranchMaster.ReceiptCounter = dataReader.GetInt32(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_genCompanyBranchMaster.ReceiptLength = dataReader.GetInt32(47);
			}

			return tbl_genCompanyBranchMaster;
		}
		/// <summary>
		/// This makes tbl_genCompanyBranchMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCompanyBranchMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCompanyBranchMaster  tbl_genCompanyBranchMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_LineNO = new DataColumn("LineNO" , typeof(int));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_branchName = new DataColumn("branchName" , typeof(string));
			DataColumn col_companyCountry_ID = new DataColumn("companyCountry_ID" , typeof(string));
			DataColumn col_adress = new DataColumn("adress" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_contactPerson = new DataColumn("contactPerson" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_COprefix = new DataColumn("COprefix" , typeof(string));
			DataColumn col_COcounter = new DataColumn("COcounter" , typeof(int));
			DataColumn col_COlength = new DataColumn("COlength" , typeof(int));
			DataColumn col_DOprefix = new DataColumn("DOprefix" , typeof(string));
			DataColumn col_DOcounter = new DataColumn("DOcounter" , typeof(int));
			DataColumn col_DOlength = new DataColumn("DOlength" , typeof(int));
			DataColumn col_Invprefix = new DataColumn("Invprefix" , typeof(string));
			DataColumn col_Invcounter = new DataColumn("Invcounter" , typeof(int));
			DataColumn col_Invlength = new DataColumn("Invlength" , typeof(int));
			DataColumn col_CRprefix = new DataColumn("CRprefix" , typeof(string));
			DataColumn col_CRcounter = new DataColumn("CRcounter" , typeof(int));
			DataColumn col_CRlength = new DataColumn("CRlength" , typeof(int));
			DataColumn col_DRprefix = new DataColumn("DRprefix" , typeof(string));
			DataColumn col_DRcounter = new DataColumn("DRcounter" , typeof(int));
			DataColumn col_DRlength = new DataColumn("DRlength" , typeof(int));
			DataColumn col_SRprefix = new DataColumn("SRprefix" , typeof(string));
			DataColumn col_SRcounter = new DataColumn("SRcounter" , typeof(int));
			DataColumn col_SRlength = new DataColumn("SRlength" , typeof(int));
			DataColumn col_CUSprefix = new DataColumn("CUSprefix" , typeof(string));
			DataColumn col_CUScounter = new DataColumn("CUScounter" , typeof(int));
			DataColumn col_CUSlength = new DataColumn("CUSlength" , typeof(int));
			DataColumn col_SUPprefix = new DataColumn("SUPprefix" , typeof(string));
			DataColumn col_SUPcounter = new DataColumn("SUPcounter" , typeof(int));
			DataColumn col_SUPlength = new DataColumn("SUPlength" , typeof(int));
			DataColumn col_SRTprefix = new DataColumn("SRTprefix" , typeof(string));
			DataColumn col_SRTcounter = new DataColumn("SRTcounter" , typeof(int));
			DataColumn col_SRTlength = new DataColumn("SRTlength" , typeof(int));
			DataColumn col_IGRNprefix = new DataColumn("IGRNprefix" , typeof(string));
			DataColumn col_IGRNcounter = new DataColumn("IGRNcounter" , typeof(int));
			DataColumn col_IGRNlength = new DataColumn("IGRNlength" , typeof(int));
			DataColumn col_IGINprefix = new DataColumn("IGINprefix" , typeof(string));
			DataColumn col_IGINcounter = new DataColumn("IGINcounter" , typeof(int));
			DataColumn col_IGINlength = new DataColumn("IGINlength" , typeof(int));
			DataColumn col_Shortorder = new DataColumn("Shortorder" , typeof(int));
			DataColumn col_ReceiptPrefix = new DataColumn("ReceiptPrefix" , typeof(string));
			DataColumn col_ReceiptCounter = new DataColumn("ReceiptCounter" , typeof(int));
			DataColumn col_ReceiptLength = new DataColumn("ReceiptLength" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_LineNO,col_companyBranch_ID,col_branchName,col_companyCountry_ID,col_adress,col_telephone,col_fax,col_contactPerson,col_prefix,col_counter,col_length,col_COprefix,col_COcounter,col_COlength,col_DOprefix,col_DOcounter,col_DOlength,col_Invprefix,col_Invcounter,col_Invlength,col_CRprefix,col_CRcounter,col_CRlength,col_DRprefix,col_DRcounter,col_DRlength,col_SRprefix,col_SRcounter,col_SRlength,col_CUSprefix,col_CUScounter,col_CUSlength,col_SUPprefix,col_SUPcounter,col_SUPlength,col_SRTprefix,col_SRTcounter,col_SRTlength,col_IGRNprefix,col_IGRNcounter,col_IGRNlength,col_IGINprefix,col_IGINcounter,col_IGINlength,col_Shortorder,col_ReceiptPrefix,col_ReceiptCounter,col_ReceiptLength,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCompanyBranchMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCompanyBranchMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCompanyBranchMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["LineNO"] = user.LineNO;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["branchName"] = user.branchName;
			drow["companyCountry_ID"] = user.companyCountry_ID;
			drow["adress"] = user.adress;
			drow["telephone"] = user.telephone;
			drow["fax"] = user.fax;
			drow["contactPerson"] = user.contactPerson;
			drow["prefix"] = user.prefix;
			drow["counter"] = user.counter;
			drow["length"] = user.length;
			drow["COprefix"] = user.COprefix;
			drow["COcounter"] = user.COcounter;
			drow["COlength"] = user.COlength;
			drow["DOprefix"] = user.DOprefix;
			drow["DOcounter"] = user.DOcounter;
			drow["DOlength"] = user.DOlength;
			drow["Invprefix"] = user.Invprefix;
			drow["Invcounter"] = user.Invcounter;
			drow["Invlength"] = user.Invlength;
			drow["CRprefix"] = user.CRprefix;
			drow["CRcounter"] = user.CRcounter;
			drow["CRlength"] = user.CRlength;
			drow["DRprefix"] = user.DRprefix;
			drow["DRcounter"] = user.DRcounter;
			drow["DRlength"] = user.DRlength;
			drow["SRprefix"] = user.SRprefix;
			drow["SRcounter"] = user.SRcounter;
			drow["SRlength"] = user.SRlength;
			drow["CUSprefix"] = user.CUSprefix;
			drow["CUScounter"] = user.CUScounter;
			drow["CUSlength"] = user.CUSlength;
			drow["SUPprefix"] = user.SUPprefix;
			drow["SUPcounter"] = user.SUPcounter;
			drow["SUPlength"] = user.SUPlength;
			drow["SRTprefix"] = user.SRTprefix;
			drow["SRTcounter"] = user.SRTcounter;
			drow["SRTlength"] = user.SRTlength;
			drow["IGRNprefix"] = user.IGRNprefix;
			drow["IGRNcounter"] = user.IGRNcounter;
			drow["IGRNlength"] = user.IGRNlength;
			drow["IGINprefix"] = user.IGINprefix;
			drow["IGINcounter"] = user.IGINcounter;
			drow["IGINlength"] = user.IGINlength;
			drow["Shortorder"] = user.Shortorder;
			drow["ReceiptPrefix"] = user.ReceiptPrefix;
			drow["ReceiptCounter"] = user.ReceiptCounter;
			drow["ReceiptLength"] = user.ReceiptLength;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
