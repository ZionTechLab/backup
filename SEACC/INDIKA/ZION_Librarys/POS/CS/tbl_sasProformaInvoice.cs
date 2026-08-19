using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class tbl_sasProformaInvoice
    {
        #region Fields
        private string proformaInvoice_ID;
        private DateTime proformaInvoiceDate;
        private string remark;
        private string customer_ID;
        private string inquiry_ID;
        private string quotation_ID;
        private string job_ID;
        private string orderRefNo_ID;
        private string paymentTerms;
        private string paymentMode;
        private string creditPeriod;
        private DateTime paymentDueDate;
        private string currency_ID;
        private string glPosting_ID;
        private string postingStatus_ID;
        private string financialYear_ID;
        private string accountNumber;
        private string companyID;
        private decimal currencyRate;
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
        private decimal recommendedSubTotal;
        private decimal recommendedGrandTotal;
        private string createUser_ID;
        private string modifiedUser_ID;
        private string checkedUser_ID;
        private string approvedUser_ID;
        private string deletedUser_ID;
        private string printedUser_ID;
        private string createTerminal_ID;
        private string modifiedTerminal_ID;
        private string deletedTerminal_ID;
        private string printedTerminal_ID;
        private DateTime dateCreate;
        private DateTime dateModified;
        private DateTime dateChecked;
        private DateTime dateApproved;
        private DateTime dateDeleted;
        private DateTime datePrinted;
        private bool isChecked;
        private bool isApproved;
        private bool isFinished;
        private bool isDeleted;
        private bool isLocked;
        private bool isSeattled;
        private bool isWeightCalculation;
        private int printCount;
        private bool isPriceEnabled;
        private bool isTaxReverseCalulation;
        private bool isFreeOrder;
        private bool isVAT;
        private bool isSVAT;
        private string branch_ID;
        private string customerPO_No;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the tbl_sasProformaInvoice class.
        /// </summary>
        public tbl_sasProformaInvoice()
        {
        }

        /// <summary>
        /// Initializes a new instance of the tbl_sasProformaInvoice class.
        /// </summary>
        public tbl_sasProformaInvoice(string proformaInvoice_ID, DateTime proformaInvoiceDate, string remark, string customer_ID, string inquiry_ID, string quotation_ID, string job_ID, string orderRefNo_ID, string paymentTerms, string paymentMode, string creditPeriod, DateTime paymentDueDate, string currency_ID, string glPosting_ID, string postingStatus_ID, string financialYear_ID, string accountNumber, string companyID, decimal currencyRate, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, decimal recommendedSubTotal, decimal recommendedGrandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled, bool isWeightCalculation, int printCount, bool isPriceEnabled, bool isTaxReverseCalulation, bool isFreeOrder, bool isVAT, bool isSVAT, string branch_ID, string customerPO_No)
        {
            this.proformaInvoice_ID = proformaInvoice_ID;
            this.proformaInvoiceDate = proformaInvoiceDate;
            this.remark = remark;
            this.customer_ID = customer_ID;
            this.inquiry_ID = inquiry_ID;
            this.quotation_ID = quotation_ID;
            this.job_ID = job_ID;
            this.orderRefNo_ID = orderRefNo_ID;
            this.paymentTerms = paymentTerms;
            this.paymentMode = paymentMode;
            this.creditPeriod = creditPeriod;
            this.paymentDueDate = paymentDueDate;
            this.currency_ID = currency_ID;
            this.glPosting_ID = glPosting_ID;
            this.postingStatus_ID = postingStatus_ID;
            this.financialYear_ID = financialYear_ID;
            this.accountNumber = accountNumber;
            this.companyID = companyID;
            this.currencyRate = currencyRate;
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
            this.recommendedSubTotal = recommendedSubTotal;
            this.recommendedGrandTotal = recommendedGrandTotal;
            this.createUser_ID = createUser_ID;
            this.modifiedUser_ID = modifiedUser_ID;
            this.checkedUser_ID = checkedUser_ID;
            this.approvedUser_ID = approvedUser_ID;
            this.deletedUser_ID = deletedUser_ID;
            this.printedUser_ID = printedUser_ID;
            this.createTerminal_ID = createTerminal_ID;
            this.modifiedTerminal_ID = modifiedTerminal_ID;
            this.deletedTerminal_ID = deletedTerminal_ID;
            this.printedTerminal_ID = printedTerminal_ID;
            this.dateCreate = dateCreate;
            this.dateModified = dateModified;
            this.dateChecked = dateChecked;
            this.dateApproved = dateApproved;
            this.dateDeleted = dateDeleted;
            this.datePrinted = datePrinted;
            this.isChecked = isChecked;
            this.isApproved = isApproved;
            this.isFinished = isFinished;
            this.isDeleted = isDeleted;
            this.isLocked = isLocked;
            this.isSeattled = isSeattled;
            this.isWeightCalculation = isWeightCalculation;
            this.printCount = printCount;
            this.isPriceEnabled = isPriceEnabled;
            this.isTaxReverseCalulation = isTaxReverseCalulation;
            this.isFreeOrder = isFreeOrder;
            this.isVAT = isVAT;
            this.isSVAT = isSVAT;
            this.branch_ID = branch_ID;
            this.customerPO_No = customerPO_No;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ProformaInvoice_ID value.
        /// </summary>
        public string ProformaInvoice_ID
        {
            get { return proformaInvoice_ID; }
            set { proformaInvoice_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ProformaInvoiceDate value.
        /// </summary>
        public DateTime ProformaInvoiceDate
        {
            get { return proformaInvoiceDate; }
            set { proformaInvoiceDate = value; }
        }

        /// <summary>
        /// Gets or sets the Remark value.
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// Gets or sets the Customer_ID value.
        /// </summary>
        public string Customer_ID
        {
            get { return customer_ID; }
            set { customer_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Inquiry_ID value.
        /// </summary>
        public string Inquiry_ID
        {
            get { return inquiry_ID; }
            set { inquiry_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Quotation_ID value.
        /// </summary>
        public string Quotation_ID
        {
            get { return quotation_ID; }
            set { quotation_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Job_ID value.
        /// </summary>
        public string Job_ID
        {
            get { return job_ID; }
            set { job_ID = value; }
        }

        /// <summary>
        /// Gets or sets the OrderRefNo_ID value.
        /// </summary>
        public string OrderRefNo_ID
        {
            get { return orderRefNo_ID; }
            set { orderRefNo_ID = value; }
        }

        /// <summary>
        /// Gets or sets the PaymentTerms value.
        /// </summary>
        public string PaymentTerms
        {
            get { return paymentTerms; }
            set { paymentTerms = value; }
        }

        /// <summary>
        /// Gets or sets the PaymentMode value.
        /// </summary>
        public string PaymentMode
        {
            get { return paymentMode; }
            set { paymentMode = value; }
        }

        /// <summary>
        /// Gets or sets the CreditPeriod value.
        /// </summary>
        public string CreditPeriod
        {
            get { return creditPeriod; }
            set { creditPeriod = value; }
        }

        /// <summary>
        /// Gets or sets the PaymentDueDate value.
        /// </summary>
        public DateTime PaymentDueDate
        {
            get { return paymentDueDate; }
            set { paymentDueDate = value; }
        }

        /// <summary>
        /// Gets or sets the Currency_ID value.
        /// </summary>
        public string Currency_ID
        {
            get { return currency_ID; }
            set { currency_ID = value; }
        }

        /// <summary>
        /// Gets or sets the GlPosting_ID value.
        /// </summary>
        public string GlPosting_ID
        {
            get { return glPosting_ID; }
            set { glPosting_ID = value; }
        }

        /// <summary>
        /// Gets or sets the PostingStatus_ID value.
        /// </summary>
        public string PostingStatus_ID
        {
            get { return postingStatus_ID; }
            set { postingStatus_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FinancialYear_ID value.
        /// </summary>
        public string FinancialYear_ID
        {
            get { return financialYear_ID; }
            set { financialYear_ID = value; }
        }

        /// <summary>
        /// Gets or sets the AccountNumber value.
        /// </summary>
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        /// <summary>
        /// Gets or sets the CompanyID value.
        /// </summary>
        public string CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        /// <summary>
        /// Gets or sets the CurrencyRate value.
        /// </summary>
        public decimal CurrencyRate
        {
            get { return currencyRate; }
            set { currencyRate = value; }
        }

        /// <summary>
        /// Gets or sets the DiscountPercentage value.
        /// </summary>
        public decimal DiscountPercentage
        {
            get { return discountPercentage; }
            set { discountPercentage = value; }
        }

        /// <summary>
        /// Gets or sets the NbtPercentage value.
        /// </summary>
        public decimal NbtPercentage
        {
            get { return nbtPercentage; }
            set { nbtPercentage = value; }
        }

        /// <summary>
        /// Gets or sets the VatPercentage value.
        /// </summary>
        public decimal VatPercentage
        {
            get { return vatPercentage; }
            set { vatPercentage = value; }
        }

        /// <summary>
        /// Gets or sets the OtherTaxPercentage value.
        /// </summary>
        public decimal OtherTaxPercentage
        {
            get { return otherTaxPercentage; }
            set { otherTaxPercentage = value; }
        }

        /// <summary>
        /// Gets or sets the SubTotal value.
        /// </summary>
        public decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        /// <summary>
        /// Gets or sets the DiscountTotal value.
        /// </summary>
        public decimal DiscountTotal
        {
            get { return discountTotal; }
            set { discountTotal = value; }
        }

        /// <summary>
        /// Gets or sets the NbtTotal value.
        /// </summary>
        public decimal NbtTotal
        {
            get { return nbtTotal; }
            set { nbtTotal = value; }
        }

        /// <summary>
        /// Gets or sets the VatTotal value.
        /// </summary>
        public decimal VatTotal
        {
            get { return vatTotal; }
            set { vatTotal = value; }
        }

        /// <summary>
        /// Gets or sets the OtherTaxTotal value.
        /// </summary>
        public decimal OtherTaxTotal
        {
            get { return otherTaxTotal; }
            set { otherTaxTotal = value; }
        }

        /// <summary>
        /// Gets or sets the GrandTotal value.
        /// </summary>
        public decimal GrandTotal
        {
            get { return grandTotal; }
            set { grandTotal = value; }
        }

        /// <summary>
        /// Gets or sets the RecommendedSubTotal value.
        /// </summary>
        public decimal RecommendedSubTotal
        {
            get { return recommendedSubTotal; }
            set { recommendedSubTotal = value; }
        }

        /// <summary>
        /// Gets or sets the RecommendedGrandTotal value.
        /// </summary>
        public decimal RecommendedGrandTotal
        {
            get { return recommendedGrandTotal; }
            set { recommendedGrandTotal = value; }
        }

        /// <summary>
        /// Gets or sets the CreateUser_ID value.
        /// </summary>
        public string CreateUser_ID
        {
            get { return createUser_ID; }
            set { createUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedUser_ID value.
        /// </summary>
        public string ModifiedUser_ID
        {
            get { return modifiedUser_ID; }
            set { modifiedUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CheckedUser_ID value.
        /// </summary>
        public string CheckedUser_ID
        {
            get { return checkedUser_ID; }
            set { checkedUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ApprovedUser_ID value.
        /// </summary>
        public string ApprovedUser_ID
        {
            get { return approvedUser_ID; }
            set { approvedUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DeletedUser_ID value.
        /// </summary>
        public string DeletedUser_ID
        {
            get { return deletedUser_ID; }
            set { deletedUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the PrintedUser_ID value.
        /// </summary>
        public string PrintedUser_ID
        {
            get { return printedUser_ID; }
            set { printedUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CreateTerminal_ID value.
        /// </summary>
        public string CreateTerminal_ID
        {
            get { return createTerminal_ID; }
            set { createTerminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedTerminal_ID value.
        /// </summary>
        public string ModifiedTerminal_ID
        {
            get { return modifiedTerminal_ID; }
            set { modifiedTerminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DeletedTerminal_ID value.
        /// </summary>
        public string DeletedTerminal_ID
        {
            get { return deletedTerminal_ID; }
            set { deletedTerminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the PrintedTerminal_ID value.
        /// </summary>
        public string PrintedTerminal_ID
        {
            get { return printedTerminal_ID; }
            set { printedTerminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DateCreate value.
        /// </summary>
        public DateTime DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; }
        }

        /// <summary>
        /// Gets or sets the DateModified value.
        /// </summary>
        public DateTime DateModified
        {
            get { return dateModified; }
            set { dateModified = value; }
        }

        /// <summary>
        /// Gets or sets the DateChecked value.
        /// </summary>
        public DateTime DateChecked
        {
            get { return dateChecked; }
            set { dateChecked = value; }
        }

        /// <summary>
        /// Gets or sets the DateApproved value.
        /// </summary>
        public DateTime DateApproved
        {
            get { return dateApproved; }
            set { dateApproved = value; }
        }

        /// <summary>
        /// Gets or sets the DateDeleted value.
        /// </summary>
        public DateTime DateDeleted
        {
            get { return dateDeleted; }
            set { dateDeleted = value; }
        }

        /// <summary>
        /// Gets or sets the DatePrinted value.
        /// </summary>
        public DateTime DatePrinted
        {
            get { return datePrinted; }
            set { datePrinted = value; }
        }

        /// <summary>
        /// Gets or sets the IsChecked value.
        /// </summary>
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        /// <summary>
        /// Gets or sets the IsApproved value.
        /// </summary>
        public bool IsApproved
        {
            get { return isApproved; }
            set { isApproved = value; }
        }

        /// <summary>
        /// Gets or sets the IsFinished value.
        /// </summary>
        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }

        /// <summary>
        /// Gets or sets the IsDeleted value.
        /// </summary>
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        /// <summary>
        /// Gets or sets the IsLocked value.
        /// </summary>
        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }

        /// <summary>
        /// Gets or sets the IsSeattled value.
        /// </summary>
        public bool IsSeattled
        {
            get { return isSeattled; }
            set { isSeattled = value; }
        }

        /// <summary>
        /// Gets or sets the IsWeightCalculation value.
        /// </summary>
        public bool IsWeightCalculation
        {
            get { return isWeightCalculation; }
            set { isWeightCalculation = value; }
        }

        /// <summary>
        /// Gets or sets the PrintCount value.
        /// </summary>
        public int PrintCount
        {
            get { return printCount; }
            set { printCount = value; }
        }

        /// <summary>
        /// Gets or sets the IsPriceEnabled value.
        /// </summary>
        public bool IsPriceEnabled
        {
            get { return isPriceEnabled; }
            set { isPriceEnabled = value; }
        }

        /// <summary>
        /// Gets or sets the IsTaxReverseCalulation value.
        /// </summary>
        public bool IsTaxReverseCalulation
        {
            get { return isTaxReverseCalulation; }
            set { isTaxReverseCalulation = value; }
        }

        /// <summary>
        /// Gets or sets the IsFreeOrder value.
        /// </summary>
        public bool IsFreeOrder
        {
            get { return isFreeOrder; }
            set { isFreeOrder = value; }
        }

        /// <summary>
        /// Gets or sets the IsVAT value.
        /// </summary>
        public bool IsVAT
        {
            get { return isVAT; }
            set { isVAT = value; }
        }

        /// <summary>
        /// Gets or sets the IsSVAT value.
        /// </summary>
        public bool IsSVAT
        {
            get { return isSVAT; }
            set { isSVAT = value; }
        }

        /// <summary>
        /// Gets or sets the Branch_ID value.
        /// </summary>
        public string Branch_ID
        {
            get { return branch_ID; }
            set { branch_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CustomerPO_No value.
        /// </summary>
        public string CustomerPO_No
        {
            get { return customerPO_No; }
            set { customerPO_No = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the tbl_sasProformaInvoice table.
        /// </summary>
        public void Insert()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceInsert", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@proformaInvoiceDate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@remark", SqlDbType.VarChar, 500);
            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@paymentTerms", SqlDbType.VarChar, 100);
            scom.Parameters.Add("@paymentMode", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@creditPeriod", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@paymentDueDate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@currency_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@accountNumber", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@currencyRate", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@subTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@grandTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@recommendedSubTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@recommendedGrandTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@dateCreate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateModified", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateChecked", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateApproved", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@datePrinted", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@isChecked", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isApproved", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isFinished", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isDeleted", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isLocked", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSeattled", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit, 1);
            scom.Parameters.Add("@printCount", SqlDbType.Int, 4);
            scom.Parameters.Add("@isPriceEnabled", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isFreeOrder", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isVAT", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSVAT", SqlDbType.Bit, 1);
            scom.Parameters.Add("@branch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerPO_No", SqlDbType.VarChar, 50);

            scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
            scom.Parameters["@proformaInvoiceDate"].Value = proformaInvoiceDate;
            scom.Parameters["@remark"].Value = remark;
            scom.Parameters["@customer_ID"].Value = customer_ID;
            scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
            scom.Parameters["@quotation_ID"].Value = quotation_ID;
            scom.Parameters["@job_ID"].Value = job_ID;
            scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
            scom.Parameters["@paymentTerms"].Value = paymentTerms;
            scom.Parameters["@paymentMode"].Value = paymentMode;
            scom.Parameters["@creditPeriod"].Value = creditPeriod;
            scom.Parameters["@paymentDueDate"].Value = paymentDueDate;
            scom.Parameters["@currency_ID"].Value = currency_ID;
            scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
            scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
            scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
            scom.Parameters["@accountNumber"].Value = accountNumber;
            scom.Parameters["@companyID"].Value = companyID;
            scom.Parameters["@currencyRate"].Value = currencyRate;
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
            scom.Parameters["@recommendedSubTotal"].Value = recommendedSubTotal;
            scom.Parameters["@recommendedGrandTotal"].Value = recommendedGrandTotal;
            scom.Parameters["@createUser_ID"].Value = createUser_ID;
            scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
            scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
            scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
            scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
            scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
            scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
            scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
            scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
            scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
            scom.Parameters["@dateCreate"].Value = dateCreate;
            scom.Parameters["@dateModified"].Value = dateModified;
            scom.Parameters["@dateChecked"].Value = dateChecked;
            scom.Parameters["@dateApproved"].Value = dateApproved;
            scom.Parameters["@dateDeleted"].Value = dateDeleted;
            scom.Parameters["@datePrinted"].Value = datePrinted;
            scom.Parameters["@isChecked"].Value = isChecked;
            scom.Parameters["@isApproved"].Value = isApproved;
            scom.Parameters["@isFinished"].Value = isFinished;
            scom.Parameters["@isDeleted"].Value = isDeleted;
            scom.Parameters["@isLocked"].Value = isLocked;
            scom.Parameters["@isSeattled"].Value = isSeattled;
            scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
            scom.Parameters["@printCount"].Value = printCount;
            scom.Parameters["@isPriceEnabled"].Value = isPriceEnabled;
            scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
            scom.Parameters["@isFreeOrder"].Value = isFreeOrder;
            scom.Parameters["@isVAT"].Value = isVAT;
            scom.Parameters["@isSVAT"].Value = isSVAT;
            scom.Parameters["@branch_ID"].Value = branch_ID;
            scom.Parameters["@customerPO_No"].Value = customerPO_No;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Updates a record in the tbl_sasProformaInvoice table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@proformaInvoiceDate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@remark", SqlDbType.VarChar, 500);
            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@paymentTerms", SqlDbType.VarChar, 100);
            scom.Parameters.Add("@paymentMode", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@creditPeriod", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@paymentDueDate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@currency_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@accountNumber", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@currencyRate", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@subTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@grandTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@recommendedSubTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@recommendedGrandTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@dateCreate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateModified", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateChecked", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateApproved", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@datePrinted", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@isChecked", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isApproved", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isFinished", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isDeleted", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isLocked", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSeattled", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit, 1);
            scom.Parameters.Add("@printCount", SqlDbType.Int, 4);
            scom.Parameters.Add("@isPriceEnabled", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isFreeOrder", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isVAT", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSVAT", SqlDbType.Bit, 1);
            scom.Parameters.Add("@branch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerPO_No", SqlDbType.VarChar, 50);


            scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
            scom.Parameters["@proformaInvoiceDate"].Value = proformaInvoiceDate;
            scom.Parameters["@remark"].Value = remark;
            scom.Parameters["@customer_ID"].Value = customer_ID;
            scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
            scom.Parameters["@quotation_ID"].Value = quotation_ID;
            scom.Parameters["@job_ID"].Value = job_ID;
            scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
            scom.Parameters["@paymentTerms"].Value = paymentTerms;
            scom.Parameters["@paymentMode"].Value = paymentMode;
            scom.Parameters["@creditPeriod"].Value = creditPeriod;
            scom.Parameters["@paymentDueDate"].Value = paymentDueDate;
            scom.Parameters["@currency_ID"].Value = currency_ID;
            scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
            scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
            scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
            scom.Parameters["@accountNumber"].Value = accountNumber;
            scom.Parameters["@companyID"].Value = companyID;
            scom.Parameters["@currencyRate"].Value = currencyRate;
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
            scom.Parameters["@recommendedSubTotal"].Value = recommendedSubTotal;
            scom.Parameters["@recommendedGrandTotal"].Value = recommendedGrandTotal;
            scom.Parameters["@createUser_ID"].Value = createUser_ID;
            scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
            scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
            scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
            scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
            scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
            scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
            scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
            scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
            scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
            scom.Parameters["@dateCreate"].Value = dateCreate;
            scom.Parameters["@dateModified"].Value = dateModified;
            scom.Parameters["@dateChecked"].Value = dateChecked;
            scom.Parameters["@dateApproved"].Value = dateApproved;
            scom.Parameters["@dateDeleted"].Value = dateDeleted;
            scom.Parameters["@datePrinted"].Value = datePrinted;
            scom.Parameters["@isChecked"].Value = isChecked;
            scom.Parameters["@isApproved"].Value = isApproved;
            scom.Parameters["@isFinished"].Value = isFinished;
            scom.Parameters["@isDeleted"].Value = isDeleted;
            scom.Parameters["@isLocked"].Value = isLocked;
            scom.Parameters["@isSeattled"].Value = isSeattled;
            scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
            scom.Parameters["@printCount"].Value = printCount;
            scom.Parameters["@isPriceEnabled"].Value = isPriceEnabled;
            scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
            scom.Parameters["@isFreeOrder"].Value = isFreeOrder;
            scom.Parameters["@isVAT"].Value = isVAT;
            scom.Parameters["@isSVAT"].Value = isSVAT;
            scom.Parameters["@branch_ID"].Value = branch_ID;
            scom.Parameters["@customerPO_No"].Value = customerPO_No;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Deletes a record from the tbl_sasProformaInvoice table by its primary key.
        /// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasProformaInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByQuotation_ID(string quotation_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceDeleteAllByQuotation_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();

            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@quotation_ID"].Value = quotation_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasProformaInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByInquiry_ID(string inquiry_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceDeleteAllByInquiry_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();

            scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@inquiry_ID"].Value = inquiry_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasProformaInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceDeleteAllByOrderRefNo_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();

            scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the tbl_sasProformaInvoice table.
        /// </summary>
        public static tbl_sasProformaInvoice Select(string proformaInvoice_ID_Incoming)
        {

            tbl_sasProformaInvoice tbl_sasProformaInvoiceins = new tbl_sasProformaInvoice();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_sasProformaInvoiceins = Maketbl_sasProformaInvoice(dataReader);
                }
                else
                {
                    tbl_sasProformaInvoiceins = null;
                }
            }
            scon.Close();
            return tbl_sasProformaInvoiceins;
        }

        /// <summary>
        /// Selects all records from the tbl_sasProformaInvoice table.
        /// </summary>
        public static List<tbl_sasProformaInvoice> SelectAll()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<tbl_sasProformaInvoice> tbl_sasProformaInvoiceList = new List<tbl_sasProformaInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasProformaInvoice tbl_sasProformaInvoice = Maketbl_sasProformaInvoice(dataReader);
                    tbl_sasProformaInvoiceList.Add(tbl_sasProformaInvoice);
                }
            }
            scon.Close();
            return tbl_sasProformaInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasProformaInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasProformaInvoice> SelectAllByQuotation_ID(string quotation_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceSelectAllByQuotation_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@quotation_ID"].Value = quotation_ID;
            List<tbl_sasProformaInvoice> tbl_sasProformaInvoiceList = new List<tbl_sasProformaInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasProformaInvoice tbl_sasProformaInvoice = Maketbl_sasProformaInvoice(dataReader);
                    tbl_sasProformaInvoiceList.Add(tbl_sasProformaInvoice);
                }
            }
            scon.Close();
            return tbl_sasProformaInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasProformaInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasProformaInvoice> SelectAllByInquiry_ID(string inquiry_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceSelectAllByInquiry_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
            List<tbl_sasProformaInvoice> tbl_sasProformaInvoiceList = new List<tbl_sasProformaInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasProformaInvoice tbl_sasProformaInvoice = Maketbl_sasProformaInvoice(dataReader);
                    tbl_sasProformaInvoiceList.Add(tbl_sasProformaInvoice);
                }
            }
            scon.Close();
            return tbl_sasProformaInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasProformaInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasProformaInvoice> SelectAllByOrderRefNo_ID(string orderRefNo_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasProformaInvoiceSelectAllByOrderRefNo_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
            List<tbl_sasProformaInvoice> tbl_sasProformaInvoiceList = new List<tbl_sasProformaInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasProformaInvoice tbl_sasProformaInvoice = Maketbl_sasProformaInvoice(dataReader);
                    tbl_sasProformaInvoiceList.Add(tbl_sasProformaInvoice);
                }
            }
            scon.Close();
            return tbl_sasProformaInvoiceList;
        }

        /// <summary>
        /// Creates a new instance of the tbl_sasProformaInvoice class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_sasProformaInvoice Maketbl_sasProformaInvoice(SqlDataReader dataReader)
        {
            tbl_sasProformaInvoice tbl_sasProformaInvoice = new tbl_sasProformaInvoice();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_sasProformaInvoice.ProformaInvoice_ID = dataReader.GetString(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_sasProformaInvoice.ProformaInvoiceDate = dataReader.GetDateTime(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                tbl_sasProformaInvoice.Remark = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_sasProformaInvoice.Customer_ID = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_sasProformaInvoice.Inquiry_ID = dataReader.GetString(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                tbl_sasProformaInvoice.Quotation_ID = dataReader.GetString(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                tbl_sasProformaInvoice.Job_ID = dataReader.GetString(6);
            }
            if (dataReader.IsDBNull(7) == false)
            {
                tbl_sasProformaInvoice.OrderRefNo_ID = dataReader.GetString(7);
            }
            if (dataReader.IsDBNull(8) == false)
            {
                tbl_sasProformaInvoice.PaymentTerms = dataReader.GetString(8);
            }
            if (dataReader.IsDBNull(9) == false)
            {
                tbl_sasProformaInvoice.PaymentMode = dataReader.GetString(9);
            }
            if (dataReader.IsDBNull(10) == false)
            {
                tbl_sasProformaInvoice.CreditPeriod = dataReader.GetString(10);
            }
            if (dataReader.IsDBNull(11) == false)
            {
                tbl_sasProformaInvoice.PaymentDueDate = dataReader.GetDateTime(11);
            }
            if (dataReader.IsDBNull(12) == false)
            {
                tbl_sasProformaInvoice.Currency_ID = dataReader.GetString(12);
            }
            if (dataReader.IsDBNull(13) == false)
            {
                tbl_sasProformaInvoice.GlPosting_ID = dataReader.GetString(13);
            }
            if (dataReader.IsDBNull(14) == false)
            {
                tbl_sasProformaInvoice.PostingStatus_ID = dataReader.GetString(14);
            }
            if (dataReader.IsDBNull(15) == false)
            {
                tbl_sasProformaInvoice.FinancialYear_ID = dataReader.GetString(15);
            }
            if (dataReader.IsDBNull(16) == false)
            {
                tbl_sasProformaInvoice.AccountNumber = dataReader.GetString(16);
            }
            if (dataReader.IsDBNull(17) == false)
            {
                tbl_sasProformaInvoice.CompanyID = dataReader.GetString(17);
            }
            if (dataReader.IsDBNull(18) == false)
            {
                tbl_sasProformaInvoice.CurrencyRate = dataReader.GetDecimal(18);
            }
            if (dataReader.IsDBNull(19) == false)
            {
                tbl_sasProformaInvoice.DiscountPercentage = dataReader.GetDecimal(19);
            }
            if (dataReader.IsDBNull(20) == false)
            {
                tbl_sasProformaInvoice.NbtPercentage = dataReader.GetDecimal(20);
            }
            if (dataReader.IsDBNull(21) == false)
            {
                tbl_sasProformaInvoice.VatPercentage = dataReader.GetDecimal(21);
            }
            if (dataReader.IsDBNull(22) == false)
            {
                tbl_sasProformaInvoice.OtherTaxPercentage = dataReader.GetDecimal(22);
            }
            if (dataReader.IsDBNull(23) == false)
            {
                tbl_sasProformaInvoice.SubTotal = dataReader.GetDecimal(23);
            }
            if (dataReader.IsDBNull(24) == false)
            {
                tbl_sasProformaInvoice.DiscountTotal = dataReader.GetDecimal(24);
            }
            if (dataReader.IsDBNull(25) == false)
            {
                tbl_sasProformaInvoice.NbtTotal = dataReader.GetDecimal(25);
            }
            if (dataReader.IsDBNull(26) == false)
            {
                tbl_sasProformaInvoice.VatTotal = dataReader.GetDecimal(26);
            }
            if (dataReader.IsDBNull(27) == false)
            {
                tbl_sasProformaInvoice.OtherTaxTotal = dataReader.GetDecimal(27);
            }
            if (dataReader.IsDBNull(28) == false)
            {
                tbl_sasProformaInvoice.GrandTotal = dataReader.GetDecimal(28);
            }
            if (dataReader.IsDBNull(29) == false)
            {
                tbl_sasProformaInvoice.RecommendedSubTotal = dataReader.GetDecimal(29);
            }
            if (dataReader.IsDBNull(30) == false)
            {
                tbl_sasProformaInvoice.RecommendedGrandTotal = dataReader.GetDecimal(30);
            }
            if (dataReader.IsDBNull(31) == false)
            {
                tbl_sasProformaInvoice.CreateUser_ID = dataReader.GetString(31);
            }
            if (dataReader.IsDBNull(32) == false)
            {
                tbl_sasProformaInvoice.ModifiedUser_ID = dataReader.GetString(32);
            }
            if (dataReader.IsDBNull(33) == false)
            {
                tbl_sasProformaInvoice.CheckedUser_ID = dataReader.GetString(33);
            }
            if (dataReader.IsDBNull(34) == false)
            {
                tbl_sasProformaInvoice.ApprovedUser_ID = dataReader.GetString(34);
            }
            if (dataReader.IsDBNull(35) == false)
            {
                tbl_sasProformaInvoice.DeletedUser_ID = dataReader.GetString(35);
            }
            if (dataReader.IsDBNull(36) == false)
            {
                tbl_sasProformaInvoice.PrintedUser_ID = dataReader.GetString(36);
            }
            if (dataReader.IsDBNull(37) == false)
            {
                tbl_sasProformaInvoice.CreateTerminal_ID = dataReader.GetString(37);
            }
            if (dataReader.IsDBNull(38) == false)
            {
                tbl_sasProformaInvoice.ModifiedTerminal_ID = dataReader.GetString(38);
            }
            if (dataReader.IsDBNull(39) == false)
            {
                tbl_sasProformaInvoice.DeletedTerminal_ID = dataReader.GetString(39);
            }
            if (dataReader.IsDBNull(40) == false)
            {
                tbl_sasProformaInvoice.PrintedTerminal_ID = dataReader.GetString(40);
            }
            if (dataReader.IsDBNull(41) == false)
            {
                tbl_sasProformaInvoice.DateCreate = dataReader.GetDateTime(41);
            }
            if (dataReader.IsDBNull(42) == false)
            {
                tbl_sasProformaInvoice.DateModified = dataReader.GetDateTime(42);
            }
            if (dataReader.IsDBNull(43) == false)
            {
                tbl_sasProformaInvoice.DateChecked = dataReader.GetDateTime(43);
            }
            if (dataReader.IsDBNull(44) == false)
            {
                tbl_sasProformaInvoice.DateApproved = dataReader.GetDateTime(44);
            }
            if (dataReader.IsDBNull(45) == false)
            {
                tbl_sasProformaInvoice.DateDeleted = dataReader.GetDateTime(45);
            }
            if (dataReader.IsDBNull(46) == false)
            {
                tbl_sasProformaInvoice.DatePrinted = dataReader.GetDateTime(46);
            }
            if (dataReader.IsDBNull(47) == false)
            {
                tbl_sasProformaInvoice.IsChecked = dataReader.GetBoolean(47);
            }
            if (dataReader.IsDBNull(48) == false)
            {
                tbl_sasProformaInvoice.IsApproved = dataReader.GetBoolean(48);
            }
            if (dataReader.IsDBNull(49) == false)
            {
                tbl_sasProformaInvoice.IsFinished = dataReader.GetBoolean(49);
            }
            if (dataReader.IsDBNull(50) == false)
            {
                tbl_sasProformaInvoice.IsDeleted = dataReader.GetBoolean(50);
            }
            if (dataReader.IsDBNull(51) == false)
            {
                tbl_sasProformaInvoice.IsLocked = dataReader.GetBoolean(51);
            }
            if (dataReader.IsDBNull(52) == false)
            {
                tbl_sasProformaInvoice.IsSeattled = dataReader.GetBoolean(52);
            }
            if (dataReader.IsDBNull(53) == false)
            {
                tbl_sasProformaInvoice.IsWeightCalculation = dataReader.GetBoolean(53);
            }
            if (dataReader.IsDBNull(54) == false)
            {
                tbl_sasProformaInvoice.PrintCount = dataReader.GetInt32(54);
            }
            if (dataReader.IsDBNull(55) == false)
            {
                tbl_sasProformaInvoice.IsPriceEnabled = dataReader.GetBoolean(55);
            }
            if (dataReader.IsDBNull(56) == false)
            {
                tbl_sasProformaInvoice.IsTaxReverseCalulation = dataReader.GetBoolean(56);
            }
            if (dataReader.IsDBNull(57) == false)
            {
                tbl_sasProformaInvoice.IsFreeOrder = dataReader.GetBoolean(57);
            }
            if (dataReader.IsDBNull(58) == false)
            {
                tbl_sasProformaInvoice.IsVAT = dataReader.GetBoolean(58);
            }
            if (dataReader.IsDBNull(59) == false)
            {
                tbl_sasProformaInvoice.IsSVAT = dataReader.GetBoolean(59);
            }
            if (dataReader.IsDBNull(60) == false)
            {
                tbl_sasProformaInvoice.Branch_ID = dataReader.GetString(60);
            }
            if (dataReader.IsDBNull(61) == false)
            {
                tbl_sasProformaInvoice.CustomerPO_No = dataReader.GetString(61);
            }

            return tbl_sasProformaInvoice;
        }
        /// <summary>
        /// This makes tbl_sasProformaInvoice datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new tbl_sasProformaInvoice object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(tbl_sasProformaInvoice tbl_sasProformaInvoice)
        {
            DataTable dt = new DataTable();

            DataColumn col_proformaInvoice_ID = new DataColumn("proformaInvoice_ID", typeof(string));
            DataColumn col_proformaInvoiceDate = new DataColumn("proformaInvoiceDate", typeof(DateTime));
            DataColumn col_remark = new DataColumn("remark", typeof(string));
            DataColumn col_customer_ID = new DataColumn("customer_ID", typeof(string));
            DataColumn col_inquiry_ID = new DataColumn("inquiry_ID", typeof(string));
            DataColumn col_quotation_ID = new DataColumn("quotation_ID", typeof(string));
            DataColumn col_job_ID = new DataColumn("job_ID", typeof(string));
            DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID", typeof(string));
            DataColumn col_paymentTerms = new DataColumn("paymentTerms", typeof(string));
            DataColumn col_paymentMode = new DataColumn("paymentMode", typeof(string));
            DataColumn col_creditPeriod = new DataColumn("creditPeriod", typeof(string));
            DataColumn col_paymentDueDate = new DataColumn("paymentDueDate", typeof(DateTime));
            DataColumn col_currency_ID = new DataColumn("currency_ID", typeof(string));
            DataColumn col_glPosting_ID = new DataColumn("glPosting_ID", typeof(string));
            DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID", typeof(string));
            DataColumn col_financialYear_ID = new DataColumn("financialYear_ID", typeof(string));
            DataColumn col_accountNumber = new DataColumn("accountNumber", typeof(string));
            DataColumn col_companyID = new DataColumn("companyID", typeof(string));
            DataColumn col_currencyRate = new DataColumn("currencyRate", typeof(decimal));
            DataColumn col_discountPercentage = new DataColumn("discountPercentage", typeof(decimal));
            DataColumn col_nbtPercentage = new DataColumn("nbtPercentage", typeof(decimal));
            DataColumn col_vatPercentage = new DataColumn("vatPercentage", typeof(decimal));
            DataColumn col_otherTaxPercentage = new DataColumn("otherTaxPercentage", typeof(decimal));
            DataColumn col_subTotal = new DataColumn("subTotal", typeof(decimal));
            DataColumn col_discountTotal = new DataColumn("discountTotal", typeof(decimal));
            DataColumn col_nbtTotal = new DataColumn("nbtTotal", typeof(decimal));
            DataColumn col_vatTotal = new DataColumn("vatTotal", typeof(decimal));
            DataColumn col_otherTaxTotal = new DataColumn("otherTaxTotal", typeof(decimal));
            DataColumn col_grandTotal = new DataColumn("grandTotal", typeof(decimal));
            DataColumn col_recommendedSubTotal = new DataColumn("recommendedSubTotal", typeof(decimal));
            DataColumn col_recommendedGrandTotal = new DataColumn("recommendedGrandTotal", typeof(decimal));
            DataColumn col_createUser_ID = new DataColumn("createUser_ID", typeof(string));
            DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID", typeof(string));
            DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID", typeof(string));
            DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID", typeof(string));
            DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID", typeof(string));
            DataColumn col_printedUser_ID = new DataColumn("printedUser_ID", typeof(string));
            DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID", typeof(string));
            DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID", typeof(string));
            DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID", typeof(string));
            DataColumn col_printedTerminal_ID = new DataColumn("printedTerminal_ID", typeof(string));
            DataColumn col_dateCreate = new DataColumn("dateCreate", typeof(DateTime));
            DataColumn col_dateModified = new DataColumn("dateModified", typeof(DateTime));
            DataColumn col_dateChecked = new DataColumn("dateChecked", typeof(DateTime));
            DataColumn col_dateApproved = new DataColumn("dateApproved", typeof(DateTime));
            DataColumn col_dateDeleted = new DataColumn("dateDeleted", typeof(DateTime));
            DataColumn col_datePrinted = new DataColumn("datePrinted", typeof(DateTime));
            DataColumn col_isChecked = new DataColumn("isChecked", typeof(bool));
            DataColumn col_isApproved = new DataColumn("isApproved", typeof(bool));
            DataColumn col_isFinished = new DataColumn("isFinished", typeof(bool));
            DataColumn col_isDeleted = new DataColumn("isDeleted", typeof(bool));
            DataColumn col_isLocked = new DataColumn("isLocked", typeof(bool));
            DataColumn col_isSeattled = new DataColumn("isSeattled", typeof(bool));
            DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation", typeof(bool));
            DataColumn col_printCount = new DataColumn("printCount", typeof(int));
            DataColumn col_isPriceEnabled = new DataColumn("isPriceEnabled", typeof(bool));
            DataColumn col_isTaxReverseCalulation = new DataColumn("isTaxReverseCalulation", typeof(bool));
            DataColumn col_isFreeOrder = new DataColumn("isFreeOrder", typeof(bool));
            DataColumn col_isVAT = new DataColumn("isVAT", typeof(bool));
            DataColumn col_isSVAT = new DataColumn("isSVAT", typeof(bool));
            DataColumn col_branch_ID = new DataColumn("branch_ID", typeof(string));
            DataColumn col_customerPO_No = new DataColumn("customerPO_No", typeof(string));
            dt.Columns.AddRange(new DataColumn[] { col_proformaInvoice_ID, col_proformaInvoiceDate, col_remark, col_customer_ID, col_inquiry_ID, col_quotation_ID, col_job_ID, col_orderRefNo_ID, col_paymentTerms, col_paymentMode, col_creditPeriod, col_paymentDueDate, col_currency_ID, col_glPosting_ID, col_postingStatus_ID, col_financialYear_ID, col_accountNumber, col_companyID, col_currencyRate, col_discountPercentage, col_nbtPercentage, col_vatPercentage, col_otherTaxPercentage, col_subTotal, col_discountTotal, col_nbtTotal, col_vatTotal, col_otherTaxTotal, col_grandTotal, col_recommendedSubTotal, col_recommendedGrandTotal, col_createUser_ID, col_modifiedUser_ID, col_checkedUser_ID, col_approvedUser_ID, col_deletedUser_ID, col_printedUser_ID, col_createTerminal_ID, col_modifiedTerminal_ID, col_deletedTerminal_ID, col_printedTerminal_ID, col_dateCreate, col_dateModified, col_dateChecked, col_dateApproved, col_dateDeleted, col_datePrinted, col_isChecked, col_isApproved, col_isFinished, col_isDeleted, col_isLocked, col_isSeattled, col_isWeightCalculation, col_printCount, col_isPriceEnabled, col_isTaxReverseCalulation, col_isFreeOrder, col_isVAT, col_isSVAT, col_branch_ID, col_customerPO_No, }); return dt;
        }
        /// <summary>
        /// This fills tbl_sasProformaInvoice datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new tbl_sasProformaInvoice object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, tbl_sasProformaInvoice user)
        {
            DataRow drow = dt.NewRow();

            drow["proformaInvoice_ID"] = user.proformaInvoice_ID;
            drow["proformaInvoiceDate"] = user.proformaInvoiceDate;
            drow["remark"] = user.remark;
            drow["customer_ID"] = user.customer_ID;
            drow["inquiry_ID"] = user.inquiry_ID;
            drow["quotation_ID"] = user.quotation_ID;
            drow["job_ID"] = user.job_ID;
            drow["orderRefNo_ID"] = user.orderRefNo_ID;
            drow["paymentTerms"] = user.paymentTerms;
            drow["paymentMode"] = user.paymentMode;
            drow["creditPeriod"] = user.creditPeriod;
            drow["paymentDueDate"] = user.paymentDueDate;
            drow["currency_ID"] = user.currency_ID;
            drow["glPosting_ID"] = user.glPosting_ID;
            drow["postingStatus_ID"] = user.postingStatus_ID;
            drow["financialYear_ID"] = user.financialYear_ID;
            drow["accountNumber"] = user.accountNumber;
            drow["companyID"] = user.companyID;
            drow["currencyRate"] = user.currencyRate;
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
            drow["recommendedSubTotal"] = user.recommendedSubTotal;
            drow["recommendedGrandTotal"] = user.recommendedGrandTotal;
            drow["createUser_ID"] = user.createUser_ID;
            drow["modifiedUser_ID"] = user.modifiedUser_ID;
            drow["checkedUser_ID"] = user.checkedUser_ID;
            drow["approvedUser_ID"] = user.approvedUser_ID;
            drow["deletedUser_ID"] = user.deletedUser_ID;
            drow["printedUser_ID"] = user.printedUser_ID;
            drow["createTerminal_ID"] = user.createTerminal_ID;
            drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
            drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
            drow["printedTerminal_ID"] = user.printedTerminal_ID;
            drow["dateCreate"] = user.dateCreate;
            drow["dateModified"] = user.dateModified;
            drow["dateChecked"] = user.dateChecked;
            drow["dateApproved"] = user.dateApproved;
            drow["dateDeleted"] = user.dateDeleted;
            drow["datePrinted"] = user.datePrinted;
            drow["isChecked"] = user.isChecked;
            drow["isApproved"] = user.isApproved;
            drow["isFinished"] = user.isFinished;
            drow["isDeleted"] = user.isDeleted;
            drow["isLocked"] = user.isLocked;
            drow["isSeattled"] = user.isSeattled;
            drow["isWeightCalculation"] = user.isWeightCalculation;
            drow["printCount"] = user.printCount;
            drow["isPriceEnabled"] = user.isPriceEnabled;
            drow["isTaxReverseCalulation"] = user.isTaxReverseCalulation;
            drow["isFreeOrder"] = user.isFreeOrder;
            drow["isVAT"] = user.isVAT;
            drow["isSVAT"] = user.isSVAT;
            drow["branch_ID"] = user.branch_ID;
            drow["customerPO_No"] = user.customerPO_No;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}
