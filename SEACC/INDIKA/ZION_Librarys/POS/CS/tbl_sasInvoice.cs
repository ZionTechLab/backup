using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class tbl_sasInvoice
    {
        #region Fields
        private string invoice_ID;
        private string configForm_ID;
        private DateTime invoiceDate;
        private string remark;
        private string address;
        private string tatalAmountInWord;
        private string customer_ID;
        private string quotation_ID;
        private string customerOrder_ID;
        private string deliveryOrder_ID;
        private string job_ID;
        private string employee_ID;
        private string orderRefNo_ID;
        private string chequeRegister_ID;
        private string currency_ID;
        private string glPosting_ID;
        private string postingStatus_ID;
        private string postingStatus_ID2;
        private string financialYear_ID;
        private string salesNoteType_ID;
        private decimal currencyRate;
        private decimal discountPercentage;
        private decimal discountPercentage1;
        private decimal discountPercentage2;
        private decimal discountPercentage3;
        private decimal nbtPercentage;
        private decimal vatPercentage;
        private decimal otherTaxPercentage;
        private decimal subTotal;
        private decimal discountTotal;
        private decimal discountTotal1;
        private decimal discountTotal2;
        private decimal discountTotal3;
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
        private string paymentTerms;
        private string paymentMode;
        private string creditPeriod;
        private DateTime paymentDueDate;
        private bool isLocked;
        private decimal seattleAmount;
        private bool isSeattled;
        private bool isSeattled_DO;
        private int printCount;
        private bool isDebitNote;
        private bool isOpeningBalance;
        private bool isReturnedCheque;
        private bool isPartPayment;
        private bool isAdvancePayment;
        private bool isWeightCalculation;
        private bool isTaxReverseCalulation;
        private bool isVatInvoice;
        private bool isSVatInvoice;
        private string branch_ID;
        private string customerGrnNo;
        private string itemPriceCategory;
        private bool isPosInvoice;
        private string companyID;
        private string companyBranch_ID;
        private bool isTaxExcludedInvoice;
        private decimal nbtPercentage_EX;
        private decimal vatPercentage_EX;
        private decimal otherTaxPercentage_EX;
        private decimal subTotal_EX;
        private decimal nbtTotal_EX;
        private decimal vatTotal_EX;
        private decimal otherTaxTotal_EX;
        private decimal grandTotal_EX;
        private decimal dAmount_AdvancePayment;
        private int route_ID;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the tbl_sasInvoice class.
        /// </summary>
        public tbl_sasInvoice()
        {
        }

        /// <summary>
        /// Initializes a new instance of the tbl_sasInvoice class.
        /// </summary>
        public tbl_sasInvoice(string invoice_ID, string configForm_ID, DateTime invoiceDate, string remark, string address, string tatalAmountInWord, string customer_ID, string quotation_ID, string customerOrder_ID, string deliveryOrder_ID, string job_ID, string employee_ID, string orderRefNo_ID, string chequeRegister_ID, string currency_ID, string glPosting_ID, string postingStatus_ID, string postingStatus_ID2, string financialYear_ID, string salesNoteType_ID, decimal currencyRate, decimal discountPercentage, decimal discountPercentage1, decimal discountPercentage2, decimal discountPercentage3, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal discountTotal1, decimal discountTotal2, decimal discountTotal3, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, decimal recommendedSubTotal, decimal recommendedGrandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, string paymentTerms, string paymentMode, string creditPeriod, DateTime paymentDueDate, bool isLocked, decimal seattleAmount, bool isSeattled, bool isSeattled_DO, int printCount, bool isDebitNote, bool isOpeningBalance, bool isReturnedCheque, bool isPartPayment, bool isAdvancePayment, bool isWeightCalculation, bool isTaxReverseCalulation, bool isVatInvoice, bool isSVatInvoice, string branch_ID, string customerGrnNo, string itemPriceCategory, bool isPosInvoice, string companyID, string companyBranch_ID, bool isTaxExcludedInvoice, decimal nbtPercentage_EX, decimal vatPercentage_EX, decimal otherTaxPercentage_EX, decimal subTotal_EX, decimal nbtTotal_EX, decimal vatTotal_EX, decimal otherTaxTotal_EX, decimal grandTotal_EX, decimal dAmount_AdvancePayment, int route_ID)
        {
            this.invoice_ID = invoice_ID;
            this.configForm_ID = configForm_ID;
            this.invoiceDate = invoiceDate;
            this.remark = remark;
            this.address = address;
            this.tatalAmountInWord = tatalAmountInWord;
            this.customer_ID = customer_ID;
            this.quotation_ID = quotation_ID;
            this.customerOrder_ID = customerOrder_ID;
            this.deliveryOrder_ID = deliveryOrder_ID;
            this.job_ID = job_ID;
            this.employee_ID = employee_ID;
            this.orderRefNo_ID = orderRefNo_ID;
            this.chequeRegister_ID = chequeRegister_ID;
            this.currency_ID = currency_ID;
            this.glPosting_ID = glPosting_ID;
            this.postingStatus_ID = postingStatus_ID;
            this.postingStatus_ID2 = postingStatus_ID2;
            this.financialYear_ID = financialYear_ID;
            this.salesNoteType_ID = salesNoteType_ID;
            this.currencyRate = currencyRate;
            this.discountPercentage = discountPercentage;
            this.discountPercentage1 = discountPercentage1;
            this.discountPercentage2 = discountPercentage2;
            this.discountPercentage3 = discountPercentage3;
            this.nbtPercentage = nbtPercentage;
            this.vatPercentage = vatPercentage;
            this.otherTaxPercentage = otherTaxPercentage;
            this.subTotal = subTotal;
            this.discountTotal = discountTotal;
            this.discountTotal1 = discountTotal1;
            this.discountTotal2 = discountTotal2;
            this.discountTotal3 = discountTotal3;
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
            this.paymentTerms = paymentTerms;
            this.paymentMode = paymentMode;
            this.creditPeriod = creditPeriod;
            this.paymentDueDate = paymentDueDate;
            this.isLocked = isLocked;
            this.seattleAmount = seattleAmount;
            this.isSeattled = isSeattled;
            this.isSeattled_DO = isSeattled_DO;
            this.printCount = printCount;
            this.isDebitNote = isDebitNote;
            this.isOpeningBalance = isOpeningBalance;
            this.isReturnedCheque = isReturnedCheque;
            this.isPartPayment = isPartPayment;
            this.isAdvancePayment = isAdvancePayment;
            this.isWeightCalculation = isWeightCalculation;
            this.isTaxReverseCalulation = isTaxReverseCalulation;
            this.isVatInvoice = isVatInvoice;
            this.isSVatInvoice = isSVatInvoice;
            this.branch_ID = branch_ID;
            this.customerGrnNo = customerGrnNo;
            this.itemPriceCategory = itemPriceCategory;
            this.isPosInvoice = isPosInvoice;
            this.companyID = companyID;
            this.companyBranch_ID = companyBranch_ID;
            this.isTaxExcludedInvoice = isTaxExcludedInvoice;
            this.nbtPercentage_EX = nbtPercentage_EX;
            this.vatPercentage_EX = vatPercentage_EX;
            this.otherTaxPercentage_EX = otherTaxPercentage_EX;
            this.subTotal_EX = subTotal_EX;
            this.nbtTotal_EX = nbtTotal_EX;
            this.vatTotal_EX = vatTotal_EX;
            this.otherTaxTotal_EX = otherTaxTotal_EX;
            this.grandTotal_EX = grandTotal_EX;
            this.dAmount_AdvancePayment = dAmount_AdvancePayment;
            this.route_ID = route_ID;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Invoice_ID value.
        /// </summary>
        public string Invoice_ID
        {
            get { return invoice_ID; }
            set { invoice_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ConfigForm_ID value.
        /// </summary>
        public string ConfigForm_ID
        {
            get { return configForm_ID; }
            set { configForm_ID = value; }
        }

        /// <summary>
        /// Gets or sets the InvoiceDate value.
        /// </summary>
        public DateTime InvoiceDate
        {
            get { return invoiceDate; }
            set { invoiceDate = value; }
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
        /// Gets or sets the Address value.
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Gets or sets the TatalAmountInWord value.
        /// </summary>
        public string TatalAmountInWord
        {
            get { return tatalAmountInWord; }
            set { tatalAmountInWord = value; }
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
        /// Gets or sets the Quotation_ID value.
        /// </summary>
        public string Quotation_ID
        {
            get { return quotation_ID; }
            set { quotation_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CustomerOrder_ID value.
        /// </summary>
        public string CustomerOrder_ID
        {
            get { return customerOrder_ID; }
            set { customerOrder_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DeliveryOrder_ID value.
        /// </summary>
        public string DeliveryOrder_ID
        {
            get { return deliveryOrder_ID; }
            set { deliveryOrder_ID = value; }
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
        /// Gets or sets the Employee_ID value.
        /// </summary>
        public string Employee_ID
        {
            get { return employee_ID; }
            set { employee_ID = value; }
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
        /// Gets or sets the ChequeRegister_ID value.
        /// </summary>
        public string ChequeRegister_ID
        {
            get { return chequeRegister_ID; }
            set { chequeRegister_ID = value; }
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
        /// Gets or sets the PostingStatus_ID2 value.
        /// </summary>
        public string PostingStatus_ID2
        {
            get { return postingStatus_ID2; }
            set { postingStatus_ID2 = value; }
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
        /// Gets or sets the SalesNoteType_ID value.
        /// </summary>
        public string SalesNoteType_ID
        {
            get { return salesNoteType_ID; }
            set { salesNoteType_ID = value; }
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
        /// Gets or sets the DiscountPercentage1 value.
        /// </summary>
        public decimal DiscountPercentage1
        {
            get { return discountPercentage1; }
            set { discountPercentage1 = value; }
        }

        /// <summary>
        /// Gets or sets the DiscountPercentage2 value.
        /// </summary>
        public decimal DiscountPercentage2
        {
            get { return discountPercentage2; }
            set { discountPercentage2 = value; }
        }

        /// <summary>
        /// Gets or sets the DiscountPercentage3 value.
        /// </summary>
        public decimal DiscountPercentage3
        {
            get { return discountPercentage3; }
            set { discountPercentage3 = value; }
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
        /// Gets or sets the DiscountTotal1 value.
        /// </summary>
        public decimal DiscountTotal1
        {
            get { return discountTotal1; }
            set { discountTotal1 = value; }
        }

        /// <summary>
        /// Gets or sets the DiscountTotal2 value.
        /// </summary>
        public decimal DiscountTotal2
        {
            get { return discountTotal2; }
            set { discountTotal2 = value; }
        }

        /// <summary>
        /// Gets or sets the DiscountTotal3 value.
        /// </summary>
        public decimal DiscountTotal3
        {
            get { return discountTotal3; }
            set { discountTotal3 = value; }
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
        /// Gets or sets the IsLocked value.
        /// </summary>
        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }

        /// <summary>
        /// Gets or sets the SeattleAmount value.
        /// </summary>
        public decimal SeattleAmount
        {
            get { return seattleAmount; }
            set { seattleAmount = value; }
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
        /// Gets or sets the IsSeattled_DO value.
        /// </summary>
        public bool IsSeattled_DO
        {
            get { return isSeattled_DO; }
            set { isSeattled_DO = value; }
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
        /// Gets or sets the IsDebitNote value.
        /// </summary>
        public bool IsDebitNote
        {
            get { return isDebitNote; }
            set { isDebitNote = value; }
        }

        /// <summary>
        /// Gets or sets the IsOpeningBalance value.
        /// </summary>
        public bool IsOpeningBalance
        {
            get { return isOpeningBalance; }
            set { isOpeningBalance = value; }
        }

        /// <summary>
        /// Gets or sets the IsReturnedCheque value.
        /// </summary>
        public bool IsReturnedCheque
        {
            get { return isReturnedCheque; }
            set { isReturnedCheque = value; }
        }

        /// <summary>
        /// Gets or sets the IsPartPayment value.
        /// </summary>
        public bool IsPartPayment
        {
            get { return isPartPayment; }
            set { isPartPayment = value; }
        }

        /// <summary>
        /// Gets or sets the IsAdvancePayment value.
        /// </summary>
        public bool IsAdvancePayment
        {
            get { return isAdvancePayment; }
            set { isAdvancePayment = value; }
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
        /// Gets or sets the IsTaxReverseCalulation value.
        /// </summary>
        public bool IsTaxReverseCalulation
        {
            get { return isTaxReverseCalulation; }
            set { isTaxReverseCalulation = value; }
        }

        /// <summary>
        /// Gets or sets the IsVatInvoice value.
        /// </summary>
        public bool IsVatInvoice
        {
            get { return isVatInvoice; }
            set { isVatInvoice = value; }
        }

        /// <summary>
        /// Gets or sets the IsSVatInvoice value.
        /// </summary>
        public bool IsSVatInvoice
        {
            get { return isSVatInvoice; }
            set { isSVatInvoice = value; }
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
        /// Gets or sets the CustomerGrnNo value.
        /// </summary>
        public string CustomerGrnNo
        {
            get { return customerGrnNo; }
            set { customerGrnNo = value; }
        }

        /// <summary>
        /// Gets or sets the ItemPriceCategory value.
        /// </summary>
        public string ItemPriceCategory
        {
            get { return itemPriceCategory; }
            set { itemPriceCategory = value; }
        }

        /// <summary>
        /// Gets or sets the IsPosInvoice value.
        /// </summary>
        public bool IsPosInvoice
        {
            get { return isPosInvoice; }
            set { isPosInvoice = value; }
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
        /// Gets or sets the CompanyBranch_ID value.
        /// </summary>
        public string CompanyBranch_ID
        {
            get { return companyBranch_ID; }
            set { companyBranch_ID = value; }
        }

        /// <summary>
        /// Gets or sets the IsTaxExcludedInvoice value.
        /// </summary>
        public bool IsTaxExcludedInvoice
        {
            get { return isTaxExcludedInvoice; }
            set { isTaxExcludedInvoice = value; }
        }

        /// <summary>
        /// Gets or sets the NbtPercentage_EX value.
        /// </summary>
        public decimal NbtPercentage_EX
        {
            get { return nbtPercentage_EX; }
            set { nbtPercentage_EX = value; }
        }

        /// <summary>
        /// Gets or sets the VatPercentage_EX value.
        /// </summary>
        public decimal VatPercentage_EX
        {
            get { return vatPercentage_EX; }
            set { vatPercentage_EX = value; }
        }

        /// <summary>
        /// Gets or sets the OtherTaxPercentage_EX value.
        /// </summary>
        public decimal OtherTaxPercentage_EX
        {
            get { return otherTaxPercentage_EX; }
            set { otherTaxPercentage_EX = value; }
        }

        /// <summary>
        /// Gets or sets the SubTotal_EX value.
        /// </summary>
        public decimal SubTotal_EX
        {
            get { return subTotal_EX; }
            set { subTotal_EX = value; }
        }

        /// <summary>
        /// Gets or sets the NbtTotal_EX value.
        /// </summary>
        public decimal NbtTotal_EX
        {
            get { return nbtTotal_EX; }
            set { nbtTotal_EX = value; }
        }

        /// <summary>
        /// Gets or sets the VatTotal_EX value.
        /// </summary>
        public decimal VatTotal_EX
        {
            get { return vatTotal_EX; }
            set { vatTotal_EX = value; }
        }

        /// <summary>
        /// Gets or sets the OtherTaxTotal_EX value.
        /// </summary>
        public decimal OtherTaxTotal_EX
        {
            get { return otherTaxTotal_EX; }
            set { otherTaxTotal_EX = value; }
        }

        /// <summary>
        /// Gets or sets the GrandTotal_EX value.
        /// </summary>
        public decimal GrandTotal_EX
        {
            get { return grandTotal_EX; }
            set { grandTotal_EX = value; }
        }

        /// <summary>
        /// Gets or sets the DAmount_AdvancePayment value.
        /// </summary>
        public decimal DAmount_AdvancePayment
        {
            get { return dAmount_AdvancePayment; }
            set { dAmount_AdvancePayment = value; }
        }

        /// <summary>
        /// Gets or sets the Route_ID value.
        /// </summary>
        public int Route_ID
        {
            get { return route_ID; }
            set { route_ID = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the tbl_sasInvoice table.
        /// </summary>
        public void Insert()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceInsert", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@configForm_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@remark", SqlDbType.VarChar, 1000);
            scom.Parameters.Add("@address", SqlDbType.VarChar, 100);
            scom.Parameters.Add("@tatalAmountInWord", SqlDbType.VarChar, 200);
            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@currency_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@postingStatus_ID2", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@currencyRate", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage1", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage2", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage3", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@subTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal1", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal2", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal3", SqlDbType.Decimal, 9);
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
            scom.Parameters.Add("@paymentTerms", SqlDbType.VarChar, 100);
            scom.Parameters.Add("@paymentMode", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@creditPeriod", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@paymentDueDate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@isLocked", SqlDbType.Bit, 1);
            scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@isSeattled", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSeattled_DO", SqlDbType.Bit, 1);
            scom.Parameters.Add("@printCount", SqlDbType.Int, 4);
            scom.Parameters.Add("@isDebitNote", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isOpeningBalance", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReturnedCheque", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isPartPayment", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isAdvancePayment", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isVatInvoice", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSVatInvoice", SqlDbType.Bit, 1);
            scom.Parameters.Add("@branch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerGrnNo", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@isPosInvoice", SqlDbType.Bit, 1);
            scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@isTaxExcludedInvoice", SqlDbType.Bit, 1);
            scom.Parameters.Add("@nbtPercentage_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatPercentage_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxPercentage_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@subTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@nbtTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@grandTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@dAmount_AdvancePayment", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@route_ID", SqlDbType.Int, 4);

            scom.Parameters["@invoice_ID"].Value = invoice_ID;
            scom.Parameters["@configForm_ID"].Value = configForm_ID;
            scom.Parameters["@invoiceDate"].Value = invoiceDate;
            scom.Parameters["@remark"].Value = remark;
            scom.Parameters["@address"].Value = address;
            scom.Parameters["@tatalAmountInWord"].Value = tatalAmountInWord;
            scom.Parameters["@customer_ID"].Value = customer_ID;
            scom.Parameters["@quotation_ID"].Value = quotation_ID;
            scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
            scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
            scom.Parameters["@job_ID"].Value = job_ID;
            scom.Parameters["@employee_ID"].Value = employee_ID;
            scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@currency_ID"].Value = currency_ID;
            scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
            scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
            scom.Parameters["@postingStatus_ID2"].Value = postingStatus_ID2;
            scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
            scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
            scom.Parameters["@currencyRate"].Value = currencyRate;
            scom.Parameters["@discountPercentage"].Value = discountPercentage;
            scom.Parameters["@discountPercentage1"].Value = discountPercentage1;
            scom.Parameters["@discountPercentage2"].Value = discountPercentage2;
            scom.Parameters["@discountPercentage3"].Value = discountPercentage3;
            scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
            scom.Parameters["@vatPercentage"].Value = vatPercentage;
            scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
            scom.Parameters["@subTotal"].Value = subTotal;
            scom.Parameters["@discountTotal"].Value = discountTotal;
            scom.Parameters["@discountTotal1"].Value = discountTotal1;
            scom.Parameters["@discountTotal2"].Value = discountTotal2;
            scom.Parameters["@discountTotal3"].Value = discountTotal3;
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
            scom.Parameters["@paymentTerms"].Value = paymentTerms;
            scom.Parameters["@paymentMode"].Value = paymentMode;
            scom.Parameters["@creditPeriod"].Value = creditPeriod;
            scom.Parameters["@paymentDueDate"].Value = paymentDueDate;
            scom.Parameters["@isLocked"].Value = isLocked;
            scom.Parameters["@seattleAmount"].Value = seattleAmount;
            scom.Parameters["@isSeattled"].Value = isSeattled;
            scom.Parameters["@isSeattled_DO"].Value = isSeattled_DO;
            scom.Parameters["@printCount"].Value = printCount;
            scom.Parameters["@isDebitNote"].Value = isDebitNote;
            scom.Parameters["@isOpeningBalance"].Value = isOpeningBalance;
            scom.Parameters["@isReturnedCheque"].Value = isReturnedCheque;
            scom.Parameters["@isPartPayment"].Value = isPartPayment;
            scom.Parameters["@isAdvancePayment"].Value = isAdvancePayment;
            scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
            scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
            scom.Parameters["@isVatInvoice"].Value = isVatInvoice;
            scom.Parameters["@isSVatInvoice"].Value = isSVatInvoice;
            scom.Parameters["@branch_ID"].Value = branch_ID;
            scom.Parameters["@customerGrnNo"].Value = customerGrnNo;
            scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
            scom.Parameters["@isPosInvoice"].Value = isPosInvoice;
            scom.Parameters["@companyID"].Value = companyID;
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@isTaxExcludedInvoice"].Value = isTaxExcludedInvoice;
            scom.Parameters["@nbtPercentage_EX"].Value = nbtPercentage_EX;
            scom.Parameters["@vatPercentage_EX"].Value = vatPercentage_EX;
            scom.Parameters["@otherTaxPercentage_EX"].Value = otherTaxPercentage_EX;
            scom.Parameters["@subTotal_EX"].Value = subTotal_EX;
            scom.Parameters["@nbtTotal_EX"].Value = nbtTotal_EX;
            scom.Parameters["@vatTotal_EX"].Value = vatTotal_EX;
            scom.Parameters["@otherTaxTotal_EX"].Value = otherTaxTotal_EX;
            scom.Parameters["@grandTotal_EX"].Value = grandTotal_EX;
            scom.Parameters["@dAmount_AdvancePayment"].Value = dAmount_AdvancePayment;
            scom.Parameters["@route_ID"].Value = route_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Updates a record in the tbl_sasInvoice table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@configForm_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@invoiceDate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@remark", SqlDbType.VarChar, 1000);
            scom.Parameters.Add("@address", SqlDbType.VarChar, 100);
            scom.Parameters.Add("@tatalAmountInWord", SqlDbType.VarChar, 200);
            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@currency_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@postingStatus_ID2", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@currencyRate", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage1", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage2", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountPercentage3", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@subTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal1", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal2", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@discountTotal3", SqlDbType.Decimal, 9);
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
            scom.Parameters.Add("@paymentTerms", SqlDbType.VarChar, 100);
            scom.Parameters.Add("@paymentMode", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@creditPeriod", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@paymentDueDate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@isLocked", SqlDbType.Bit, 1);
            scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@isSeattled", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSeattled_DO", SqlDbType.Bit, 1);
            scom.Parameters.Add("@printCount", SqlDbType.Int, 4);
            scom.Parameters.Add("@isDebitNote", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isOpeningBalance", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReturnedCheque", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isPartPayment", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isAdvancePayment", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isVatInvoice", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSVatInvoice", SqlDbType.Bit, 1);
            scom.Parameters.Add("@branch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerGrnNo", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@isPosInvoice", SqlDbType.Bit, 1);
            scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@isTaxExcludedInvoice", SqlDbType.Bit, 1);
            scom.Parameters.Add("@nbtPercentage_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatPercentage_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxPercentage_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@subTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@nbtTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@vatTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@otherTaxTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@grandTotal_EX", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@dAmount_AdvancePayment", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@route_ID", SqlDbType.Int, 4);


            scom.Parameters["@invoice_ID"].Value = invoice_ID;
            scom.Parameters["@configForm_ID"].Value = configForm_ID;
            scom.Parameters["@invoiceDate"].Value = invoiceDate;
            scom.Parameters["@remark"].Value = remark;
            scom.Parameters["@address"].Value = address;
            scom.Parameters["@tatalAmountInWord"].Value = tatalAmountInWord;
            scom.Parameters["@customer_ID"].Value = customer_ID;
            scom.Parameters["@quotation_ID"].Value = quotation_ID;
            scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
            scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
            scom.Parameters["@job_ID"].Value = job_ID;
            scom.Parameters["@employee_ID"].Value = employee_ID;
            scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@currency_ID"].Value = currency_ID;
            scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
            scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
            scom.Parameters["@postingStatus_ID2"].Value = postingStatus_ID2;
            scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
            scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
            scom.Parameters["@currencyRate"].Value = currencyRate;
            scom.Parameters["@discountPercentage"].Value = discountPercentage;
            scom.Parameters["@discountPercentage1"].Value = discountPercentage1;
            scom.Parameters["@discountPercentage2"].Value = discountPercentage2;
            scom.Parameters["@discountPercentage3"].Value = discountPercentage3;
            scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
            scom.Parameters["@vatPercentage"].Value = vatPercentage;
            scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
            scom.Parameters["@subTotal"].Value = subTotal;
            scom.Parameters["@discountTotal"].Value = discountTotal;
            scom.Parameters["@discountTotal1"].Value = discountTotal1;
            scom.Parameters["@discountTotal2"].Value = discountTotal2;
            scom.Parameters["@discountTotal3"].Value = discountTotal3;
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
            scom.Parameters["@paymentTerms"].Value = paymentTerms;
            scom.Parameters["@paymentMode"].Value = paymentMode;
            scom.Parameters["@creditPeriod"].Value = creditPeriod;
            scom.Parameters["@paymentDueDate"].Value = paymentDueDate;
            scom.Parameters["@isLocked"].Value = isLocked;
            scom.Parameters["@seattleAmount"].Value = seattleAmount;
            scom.Parameters["@isSeattled"].Value = isSeattled;
            scom.Parameters["@isSeattled_DO"].Value = isSeattled_DO;
            scom.Parameters["@printCount"].Value = printCount;
            scom.Parameters["@isDebitNote"].Value = isDebitNote;
            scom.Parameters["@isOpeningBalance"].Value = isOpeningBalance;
            scom.Parameters["@isReturnedCheque"].Value = isReturnedCheque;
            scom.Parameters["@isPartPayment"].Value = isPartPayment;
            scom.Parameters["@isAdvancePayment"].Value = isAdvancePayment;
            scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
            scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
            scom.Parameters["@isVatInvoice"].Value = isVatInvoice;
            scom.Parameters["@isSVatInvoice"].Value = isSVatInvoice;
            scom.Parameters["@branch_ID"].Value = branch_ID;
            scom.Parameters["@customerGrnNo"].Value = customerGrnNo;
            scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
            scom.Parameters["@isPosInvoice"].Value = isPosInvoice;
            scom.Parameters["@companyID"].Value = companyID;
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@isTaxExcludedInvoice"].Value = isTaxExcludedInvoice;
            scom.Parameters["@nbtPercentage_EX"].Value = nbtPercentage_EX;
            scom.Parameters["@vatPercentage_EX"].Value = vatPercentage_EX;
            scom.Parameters["@otherTaxPercentage_EX"].Value = otherTaxPercentage_EX;
            scom.Parameters["@subTotal_EX"].Value = subTotal_EX;
            scom.Parameters["@nbtTotal_EX"].Value = nbtTotal_EX;
            scom.Parameters["@vatTotal_EX"].Value = vatTotal_EX;
            scom.Parameters["@otherTaxTotal_EX"].Value = otherTaxTotal_EX;
            scom.Parameters["@grandTotal_EX"].Value = grandTotal_EX;
            scom.Parameters["@dAmount_AdvancePayment"].Value = dAmount_AdvancePayment;
            scom.Parameters["@route_ID"].Value = route_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Deletes a record from the tbl_sasInvoice table by its primary key.
        /// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@invoice_ID"].Value = invoice_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByEmployee_ID(string employee_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByEmployee_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@employee_ID"].Value = employee_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByDeliveryOrder_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByRoute_ID(int route_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByRoute_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@route_ID", SqlDbType.Int, 4);
            scom.Parameters["@route_ID"].Value = route_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByJob_ID(string job_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByJob_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@job_ID"].Value = job_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByQuotation_ID(string quotation_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByQuotation_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@quotation_ID"].Value = quotation_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByCustomerOrder_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByChequeRegister_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByCustomer_ID(string customer_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByCustomer_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@customer_ID"].Value = customer_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceDeleteAllByOrderRefNo_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the tbl_sasInvoice table.
        /// </summary>
        public static tbl_sasInvoice Select(string invoice_ID_Incoming)
        {

            tbl_sasInvoice tbl_sasInvoiceins = new tbl_sasInvoice();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_sasInvoiceins = Maketbl_sasInvoice(dataReader);
                }
                else
                {
                    tbl_sasInvoiceins = null;
                }
            }
            scon.Close();
            return tbl_sasInvoiceins;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAll()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByEmployee_ID(string employee_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByEmployee_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@employee_ID"].Value = employee_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByDeliveryOrder_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByRoute_ID(int route_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByRoute_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@route_ID", SqlDbType.Int, 4);
            scom.Parameters["@route_ID"].Value = route_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByJob_ID(string job_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByJob_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@job_ID"].Value = job_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByQuotation_ID(string quotation_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByQuotation_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@quotation_ID"].Value = quotation_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }
        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        /// 
        public static List<tbl_sasInvoice> SelectAllByCompanyBranch_ID(string companyBranch_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByCompanyBranch_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByCustomerOrder_ID(string customerOrder_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByCustomerOrder_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByChequeRegister_ID(string chequeRegister_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByChequeRegister_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByCustomer_ID(string customer_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByCustomer_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@customer_ID"].Value = customer_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasInvoice table by a foreign key.
        /// </summary>
        public static List<tbl_sasInvoice> SelectAllByOrderRefNo_ID(string orderRefNo_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAllByOrderRefNo_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }
        public static List<tbl_sasInvoice> SelectAll_ByCustomerIDandDateRange(DateTime dateFrom, DateTime dateTo, string sCustomerID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasInvoiceSelectAll_ByCustomerIDandDateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);

            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@customer_ID"].Value = sCustomerID;
            List<tbl_sasInvoice> tbl_sasInvoiceList = new List<tbl_sasInvoice>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasInvoice tbl_sasInvoice = Maketbl_sasInvoice(dataReader);
                    tbl_sasInvoiceList.Add(tbl_sasInvoice);
                }
            }
            scon.Close();
            return tbl_sasInvoiceList;
        }

        /// <summary>
        /// Creates a new instance of the tbl_sasInvoice class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_sasInvoice Maketbl_sasInvoice(SqlDataReader dataReader)
        {
            tbl_sasInvoice tbl_sasInvoice = new tbl_sasInvoice();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_sasInvoice.Invoice_ID = dataReader.GetString(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_sasInvoice.ConfigForm_ID = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                tbl_sasInvoice.InvoiceDate = dataReader.GetDateTime(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_sasInvoice.Remark = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_sasInvoice.Address = dataReader.GetString(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                tbl_sasInvoice.TatalAmountInWord = dataReader.GetString(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                tbl_sasInvoice.Customer_ID = dataReader.GetString(6);
            }
            if (dataReader.IsDBNull(7) == false)
            {
                tbl_sasInvoice.Quotation_ID = dataReader.GetString(7);
            }
            if (dataReader.IsDBNull(8) == false)
            {
                tbl_sasInvoice.CustomerOrder_ID = dataReader.GetString(8);
            }
            if (dataReader.IsDBNull(9) == false)
            {
                tbl_sasInvoice.DeliveryOrder_ID = dataReader.GetString(9);
            }
            if (dataReader.IsDBNull(10) == false)
            {
                tbl_sasInvoice.Job_ID = dataReader.GetString(10);
            }
            if (dataReader.IsDBNull(11) == false)
            {
                tbl_sasInvoice.Employee_ID = dataReader.GetString(11);
            }
            if (dataReader.IsDBNull(12) == false)
            {
                tbl_sasInvoice.OrderRefNo_ID = dataReader.GetString(12);
            }
            if (dataReader.IsDBNull(13) == false)
            {
                tbl_sasInvoice.ChequeRegister_ID = dataReader.GetString(13);
            }
            if (dataReader.IsDBNull(14) == false)
            {
                tbl_sasInvoice.Currency_ID = dataReader.GetString(14);
            }
            if (dataReader.IsDBNull(15) == false)
            {
                tbl_sasInvoice.GlPosting_ID = dataReader.GetString(15);
            }
            if (dataReader.IsDBNull(16) == false)
            {
                tbl_sasInvoice.PostingStatus_ID = dataReader.GetString(16);
            }
            if (dataReader.IsDBNull(17) == false)
            {
                tbl_sasInvoice.PostingStatus_ID2 = dataReader.GetString(17);
            }
            if (dataReader.IsDBNull(18) == false)
            {
                tbl_sasInvoice.FinancialYear_ID = dataReader.GetString(18);
            }
            if (dataReader.IsDBNull(19) == false)
            {
                tbl_sasInvoice.SalesNoteType_ID = dataReader.GetString(19);
            }
            if (dataReader.IsDBNull(20) == false)
            {
                tbl_sasInvoice.CurrencyRate = dataReader.GetDecimal(20);
            }
            if (dataReader.IsDBNull(21) == false)
            {
                tbl_sasInvoice.DiscountPercentage = dataReader.GetDecimal(21);
            }
            if (dataReader.IsDBNull(22) == false)
            {
                tbl_sasInvoice.DiscountPercentage1 = dataReader.GetDecimal(22);
            }
            if (dataReader.IsDBNull(23) == false)
            {
                tbl_sasInvoice.DiscountPercentage2 = dataReader.GetDecimal(23);
            }
            if (dataReader.IsDBNull(24) == false)
            {
                tbl_sasInvoice.DiscountPercentage3 = dataReader.GetDecimal(24);
            }
            if (dataReader.IsDBNull(25) == false)
            {
                tbl_sasInvoice.NbtPercentage = dataReader.GetDecimal(25);
            }
            if (dataReader.IsDBNull(26) == false)
            {
                tbl_sasInvoice.VatPercentage = dataReader.GetDecimal(26);
            }
            if (dataReader.IsDBNull(27) == false)
            {
                tbl_sasInvoice.OtherTaxPercentage = dataReader.GetDecimal(27);
            }
            if (dataReader.IsDBNull(28) == false)
            {
                tbl_sasInvoice.SubTotal = dataReader.GetDecimal(28);
            }
            if (dataReader.IsDBNull(29) == false)
            {
                tbl_sasInvoice.DiscountTotal = dataReader.GetDecimal(29);
            }
            if (dataReader.IsDBNull(30) == false)
            {
                tbl_sasInvoice.DiscountTotal1 = dataReader.GetDecimal(30);
            }
            if (dataReader.IsDBNull(31) == false)
            {
                tbl_sasInvoice.DiscountTotal2 = dataReader.GetDecimal(31);
            }
            if (dataReader.IsDBNull(32) == false)
            {
                tbl_sasInvoice.DiscountTotal3 = dataReader.GetDecimal(32);
            }
            if (dataReader.IsDBNull(33) == false)
            {
                tbl_sasInvoice.NbtTotal = dataReader.GetDecimal(33);
            }
            if (dataReader.IsDBNull(34) == false)
            {
                tbl_sasInvoice.VatTotal = dataReader.GetDecimal(34);
            }
            if (dataReader.IsDBNull(35) == false)
            {
                tbl_sasInvoice.OtherTaxTotal = dataReader.GetDecimal(35);
            }
            if (dataReader.IsDBNull(36) == false)
            {
                tbl_sasInvoice.GrandTotal = dataReader.GetDecimal(36);
            }
            if (dataReader.IsDBNull(37) == false)
            {
                tbl_sasInvoice.RecommendedSubTotal = dataReader.GetDecimal(37);
            }
            if (dataReader.IsDBNull(38) == false)
            {
                tbl_sasInvoice.RecommendedGrandTotal = dataReader.GetDecimal(38);
            }
            if (dataReader.IsDBNull(39) == false)
            {
                tbl_sasInvoice.CreateUser_ID = dataReader.GetString(39);
            }
            if (dataReader.IsDBNull(40) == false)
            {
                tbl_sasInvoice.ModifiedUser_ID = dataReader.GetString(40);
            }
            if (dataReader.IsDBNull(41) == false)
            {
                tbl_sasInvoice.CheckedUser_ID = dataReader.GetString(41);
            }
            if (dataReader.IsDBNull(42) == false)
            {
                tbl_sasInvoice.ApprovedUser_ID = dataReader.GetString(42);
            }
            if (dataReader.IsDBNull(43) == false)
            {
                tbl_sasInvoice.DeletedUser_ID = dataReader.GetString(43);
            }
            if (dataReader.IsDBNull(44) == false)
            {
                tbl_sasInvoice.PrintedUser_ID = dataReader.GetString(44);
            }
            if (dataReader.IsDBNull(45) == false)
            {
                tbl_sasInvoice.CreateTerminal_ID = dataReader.GetString(45);
            }
            if (dataReader.IsDBNull(46) == false)
            {
                tbl_sasInvoice.ModifiedTerminal_ID = dataReader.GetString(46);
            }
            if (dataReader.IsDBNull(47) == false)
            {
                tbl_sasInvoice.DeletedTerminal_ID = dataReader.GetString(47);
            }
            if (dataReader.IsDBNull(48) == false)
            {
                tbl_sasInvoice.PrintedTerminal_ID = dataReader.GetString(48);
            }
            if (dataReader.IsDBNull(49) == false)
            {
                tbl_sasInvoice.DateCreate = dataReader.GetDateTime(49);
            }
            if (dataReader.IsDBNull(50) == false)
            {
                tbl_sasInvoice.DateModified = dataReader.GetDateTime(50);
            }
            if (dataReader.IsDBNull(51) == false)
            {
                tbl_sasInvoice.DateChecked = dataReader.GetDateTime(51);
            }
            if (dataReader.IsDBNull(52) == false)
            {
                tbl_sasInvoice.DateApproved = dataReader.GetDateTime(52);
            }
            if (dataReader.IsDBNull(53) == false)
            {
                tbl_sasInvoice.DateDeleted = dataReader.GetDateTime(53);
            }
            if (dataReader.IsDBNull(54) == false)
            {
                tbl_sasInvoice.DatePrinted = dataReader.GetDateTime(54);
            }
            if (dataReader.IsDBNull(55) == false)
            {
                tbl_sasInvoice.IsChecked = dataReader.GetBoolean(55);
            }
            if (dataReader.IsDBNull(56) == false)
            {
                tbl_sasInvoice.IsApproved = dataReader.GetBoolean(56);
            }
            if (dataReader.IsDBNull(57) == false)
            {
                tbl_sasInvoice.IsFinished = dataReader.GetBoolean(57);
            }
            if (dataReader.IsDBNull(58) == false)
            {
                tbl_sasInvoice.IsDeleted = dataReader.GetBoolean(58);
            }
            if (dataReader.IsDBNull(59) == false)
            {
                tbl_sasInvoice.PaymentTerms = dataReader.GetString(59);
            }
            if (dataReader.IsDBNull(60) == false)
            {
                tbl_sasInvoice.PaymentMode = dataReader.GetString(60);
            }
            if (dataReader.IsDBNull(61) == false)
            {
                tbl_sasInvoice.CreditPeriod = dataReader.GetString(61);
            }
            if (dataReader.IsDBNull(62) == false)
            {
                tbl_sasInvoice.PaymentDueDate = dataReader.GetDateTime(62);
            }
            if (dataReader.IsDBNull(63) == false)
            {
                tbl_sasInvoice.IsLocked = dataReader.GetBoolean(63);
            }
            if (dataReader.IsDBNull(64) == false)
            {
                tbl_sasInvoice.SeattleAmount = dataReader.GetDecimal(64);
            }
            if (dataReader.IsDBNull(65) == false)
            {
                tbl_sasInvoice.IsSeattled = dataReader.GetBoolean(65);
            }
            if (dataReader.IsDBNull(66) == false)
            {
                tbl_sasInvoice.IsSeattled_DO = dataReader.GetBoolean(66);
            }
            if (dataReader.IsDBNull(67) == false)
            {
                tbl_sasInvoice.PrintCount = dataReader.GetInt32(67);
            }
            if (dataReader.IsDBNull(68) == false)
            {
                tbl_sasInvoice.IsDebitNote = dataReader.GetBoolean(68);
            }
            if (dataReader.IsDBNull(69) == false)
            {
                tbl_sasInvoice.IsOpeningBalance = dataReader.GetBoolean(69);
            }
            if (dataReader.IsDBNull(70) == false)
            {
                tbl_sasInvoice.IsReturnedCheque = dataReader.GetBoolean(70);
            }
            if (dataReader.IsDBNull(71) == false)
            {
                tbl_sasInvoice.IsPartPayment = dataReader.GetBoolean(71);
            }
            if (dataReader.IsDBNull(72) == false)
            {
                tbl_sasInvoice.IsAdvancePayment = dataReader.GetBoolean(72);
            }
            if (dataReader.IsDBNull(73) == false)
            {
                tbl_sasInvoice.IsWeightCalculation = dataReader.GetBoolean(73);
            }
            if (dataReader.IsDBNull(74) == false)
            {
                tbl_sasInvoice.IsTaxReverseCalulation = dataReader.GetBoolean(74);
            }
            if (dataReader.IsDBNull(75) == false)
            {
                tbl_sasInvoice.IsVatInvoice = dataReader.GetBoolean(75);
            }
            if (dataReader.IsDBNull(76) == false)
            {
                tbl_sasInvoice.IsSVatInvoice = dataReader.GetBoolean(76);
            }
            if (dataReader.IsDBNull(77) == false)
            {
                tbl_sasInvoice.Branch_ID = dataReader.GetString(77);
            }
            if (dataReader.IsDBNull(78) == false)
            {
                tbl_sasInvoice.CustomerGrnNo = dataReader.GetString(78);
            }
            if (dataReader.IsDBNull(79) == false)
            {
                tbl_sasInvoice.ItemPriceCategory = dataReader.GetString(79);
            }
            if (dataReader.IsDBNull(80) == false)
            {
                tbl_sasInvoice.IsPosInvoice = dataReader.GetBoolean(80);
            }
            if (dataReader.IsDBNull(81) == false)
            {
                tbl_sasInvoice.CompanyID = dataReader.GetString(81);
            }
            if (dataReader.IsDBNull(82) == false)
            {
                tbl_sasInvoice.CompanyBranch_ID = dataReader.GetString(82);
            }
            if (dataReader.IsDBNull(83) == false)
            {
                tbl_sasInvoice.IsTaxExcludedInvoice = dataReader.GetBoolean(83);
            }
            if (dataReader.IsDBNull(84) == false)
            {
                tbl_sasInvoice.NbtPercentage_EX = dataReader.GetDecimal(84);
            }
            if (dataReader.IsDBNull(85) == false)
            {
                tbl_sasInvoice.VatPercentage_EX = dataReader.GetDecimal(85);
            }
            if (dataReader.IsDBNull(86) == false)
            {
                tbl_sasInvoice.OtherTaxPercentage_EX = dataReader.GetDecimal(86);
            }
            if (dataReader.IsDBNull(87) == false)
            {
                tbl_sasInvoice.SubTotal_EX = dataReader.GetDecimal(87);
            }
            if (dataReader.IsDBNull(88) == false)
            {
                tbl_sasInvoice.NbtTotal_EX = dataReader.GetDecimal(88);
            }
            if (dataReader.IsDBNull(89) == false)
            {
                tbl_sasInvoice.VatTotal_EX = dataReader.GetDecimal(89);
            }
            if (dataReader.IsDBNull(90) == false)
            {
                tbl_sasInvoice.OtherTaxTotal_EX = dataReader.GetDecimal(90);
            }
            if (dataReader.IsDBNull(91) == false)
            {
                tbl_sasInvoice.GrandTotal_EX = dataReader.GetDecimal(91);
            }
            if (dataReader.IsDBNull(92) == false)
            {
                tbl_sasInvoice.DAmount_AdvancePayment = dataReader.GetDecimal(92);
            }
            if (dataReader.IsDBNull(93) == false)
            {
                tbl_sasInvoice.Route_ID = dataReader.GetInt32(93);
            }

            return tbl_sasInvoice;
        }
        /// <summary>
        /// This makes tbl_sasInvoice datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new tbl_sasInvoice object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(tbl_sasInvoice tbl_sasInvoice)
        {
            DataTable dt = new DataTable();

            DataColumn col_invoice_ID = new DataColumn("invoice_ID", typeof(string));
            DataColumn col_configForm_ID = new DataColumn("configForm_ID", typeof(string));
            DataColumn col_invoiceDate = new DataColumn("invoiceDate", typeof(DateTime));
            DataColumn col_remark = new DataColumn("remark", typeof(string));
            DataColumn col_address = new DataColumn("address", typeof(string));
            DataColumn col_tatalAmountInWord = new DataColumn("tatalAmountInWord", typeof(string));
            DataColumn col_customer_ID = new DataColumn("customer_ID", typeof(string));
            DataColumn col_quotation_ID = new DataColumn("quotation_ID", typeof(string));
            DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID", typeof(string));
            DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID", typeof(string));
            DataColumn col_job_ID = new DataColumn("job_ID", typeof(string));
            DataColumn col_employee_ID = new DataColumn("employee_ID", typeof(string));
            DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID", typeof(string));
            DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID", typeof(string));
            DataColumn col_currency_ID = new DataColumn("currency_ID", typeof(string));
            DataColumn col_glPosting_ID = new DataColumn("glPosting_ID", typeof(string));
            DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID", typeof(string));
            DataColumn col_postingStatus_ID2 = new DataColumn("postingStatus_ID2", typeof(string));
            DataColumn col_financialYear_ID = new DataColumn("financialYear_ID", typeof(string));
            DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID", typeof(string));
            DataColumn col_currencyRate = new DataColumn("currencyRate", typeof(decimal));
            DataColumn col_discountPercentage = new DataColumn("discountPercentage", typeof(decimal));
            DataColumn col_discountPercentage1 = new DataColumn("discountPercentage1", typeof(decimal));
            DataColumn col_discountPercentage2 = new DataColumn("discountPercentage2", typeof(decimal));
            DataColumn col_discountPercentage3 = new DataColumn("discountPercentage3", typeof(decimal));
            DataColumn col_nbtPercentage = new DataColumn("nbtPercentage", typeof(decimal));
            DataColumn col_vatPercentage = new DataColumn("vatPercentage", typeof(decimal));
            DataColumn col_otherTaxPercentage = new DataColumn("otherTaxPercentage", typeof(decimal));
            DataColumn col_subTotal = new DataColumn("subTotal", typeof(decimal));
            DataColumn col_discountTotal = new DataColumn("discountTotal", typeof(decimal));
            DataColumn col_discountTotal1 = new DataColumn("discountTotal1", typeof(decimal));
            DataColumn col_discountTotal2 = new DataColumn("discountTotal2", typeof(decimal));
            DataColumn col_discountTotal3 = new DataColumn("discountTotal3", typeof(decimal));
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
            DataColumn col_paymentTerms = new DataColumn("paymentTerms", typeof(string));
            DataColumn col_paymentMode = new DataColumn("paymentMode", typeof(string));
            DataColumn col_creditPeriod = new DataColumn("creditPeriod", typeof(string));
            DataColumn col_paymentDueDate = new DataColumn("paymentDueDate", typeof(DateTime));
            DataColumn col_isLocked = new DataColumn("isLocked", typeof(bool));
            DataColumn col_seattleAmount = new DataColumn("seattleAmount", typeof(decimal));
            DataColumn col_isSeattled = new DataColumn("isSeattled", typeof(bool));
            DataColumn col_isSeattled_DO = new DataColumn("isSeattled_DO", typeof(bool));
            DataColumn col_printCount = new DataColumn("printCount", typeof(int));
            DataColumn col_isDebitNote = new DataColumn("isDebitNote", typeof(bool));
            DataColumn col_isOpeningBalance = new DataColumn("isOpeningBalance", typeof(bool));
            DataColumn col_isReturnedCheque = new DataColumn("isReturnedCheque", typeof(bool));
            DataColumn col_isPartPayment = new DataColumn("isPartPayment", typeof(bool));
            DataColumn col_isAdvancePayment = new DataColumn("isAdvancePayment", typeof(bool));
            DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation", typeof(bool));
            DataColumn col_isTaxReverseCalulation = new DataColumn("isTaxReverseCalulation", typeof(bool));
            DataColumn col_isVatInvoice = new DataColumn("isVatInvoice", typeof(bool));
            DataColumn col_isSVatInvoice = new DataColumn("isSVatInvoice", typeof(bool));
            DataColumn col_branch_ID = new DataColumn("branch_ID", typeof(string));
            DataColumn col_customerGrnNo = new DataColumn("customerGrnNo", typeof(string));
            DataColumn col_itemPriceCategory = new DataColumn("itemPriceCategory", typeof(string));
            DataColumn col_isPosInvoice = new DataColumn("isPosInvoice", typeof(bool));
            DataColumn col_companyID = new DataColumn("companyID", typeof(string));
            DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID", typeof(string));
            DataColumn col_isTaxExcludedInvoice = new DataColumn("isTaxExcludedInvoice", typeof(bool));
            DataColumn col_nbtPercentage_EX = new DataColumn("nbtPercentage_EX", typeof(decimal));
            DataColumn col_vatPercentage_EX = new DataColumn("vatPercentage_EX", typeof(decimal));
            DataColumn col_otherTaxPercentage_EX = new DataColumn("otherTaxPercentage_EX", typeof(decimal));
            DataColumn col_subTotal_EX = new DataColumn("subTotal_EX", typeof(decimal));
            DataColumn col_nbtTotal_EX = new DataColumn("nbtTotal_EX", typeof(decimal));
            DataColumn col_vatTotal_EX = new DataColumn("vatTotal_EX", typeof(decimal));
            DataColumn col_otherTaxTotal_EX = new DataColumn("otherTaxTotal_EX", typeof(decimal));
            DataColumn col_grandTotal_EX = new DataColumn("grandTotal_EX", typeof(decimal));
            DataColumn col_dAmount_AdvancePayment = new DataColumn("dAmount_AdvancePayment", typeof(decimal));
            DataColumn col_route_ID = new DataColumn("route_ID", typeof(int));
            dt.Columns.AddRange(new DataColumn[] { col_invoice_ID, col_configForm_ID, col_invoiceDate, col_remark, col_address, col_tatalAmountInWord, col_customer_ID, col_quotation_ID, col_customerOrder_ID, col_deliveryOrder_ID, col_job_ID, col_employee_ID, col_orderRefNo_ID, col_chequeRegister_ID, col_currency_ID, col_glPosting_ID, col_postingStatus_ID, col_postingStatus_ID2, col_financialYear_ID, col_salesNoteType_ID, col_currencyRate, col_discountPercentage, col_discountPercentage1, col_discountPercentage2, col_discountPercentage3, col_nbtPercentage, col_vatPercentage, col_otherTaxPercentage, col_subTotal, col_discountTotal, col_discountTotal1, col_discountTotal2, col_discountTotal3, col_nbtTotal, col_vatTotal, col_otherTaxTotal, col_grandTotal, col_recommendedSubTotal, col_recommendedGrandTotal, col_createUser_ID, col_modifiedUser_ID, col_checkedUser_ID, col_approvedUser_ID, col_deletedUser_ID, col_printedUser_ID, col_createTerminal_ID, col_modifiedTerminal_ID, col_deletedTerminal_ID, col_printedTerminal_ID, col_dateCreate, col_dateModified, col_dateChecked, col_dateApproved, col_dateDeleted, col_datePrinted, col_isChecked, col_isApproved, col_isFinished, col_isDeleted, col_paymentTerms, col_paymentMode, col_creditPeriod, col_paymentDueDate, col_isLocked, col_seattleAmount, col_isSeattled, col_isSeattled_DO, col_printCount, col_isDebitNote, col_isOpeningBalance, col_isReturnedCheque, col_isPartPayment, col_isAdvancePayment, col_isWeightCalculation, col_isTaxReverseCalulation, col_isVatInvoice, col_isSVatInvoice, col_branch_ID, col_customerGrnNo, col_itemPriceCategory, col_isPosInvoice, col_companyID, col_companyBranch_ID, col_isTaxExcludedInvoice, col_nbtPercentage_EX, col_vatPercentage_EX, col_otherTaxPercentage_EX, col_subTotal_EX, col_nbtTotal_EX, col_vatTotal_EX, col_otherTaxTotal_EX, col_grandTotal_EX, col_dAmount_AdvancePayment, col_route_ID, }); return dt;
        }
        /// <summary>
        /// This fills tbl_sasInvoice datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new tbl_sasInvoice object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, tbl_sasInvoice user)
        {
            DataRow drow = dt.NewRow();

            drow["invoice_ID"] = user.invoice_ID;
            drow["configForm_ID"] = user.configForm_ID;
            drow["invoiceDate"] = user.invoiceDate;
            drow["remark"] = user.remark;
            drow["address"] = user.address;
            drow["tatalAmountInWord"] = user.tatalAmountInWord;
            drow["customer_ID"] = user.customer_ID;
            drow["quotation_ID"] = user.quotation_ID;
            drow["customerOrder_ID"] = user.customerOrder_ID;
            drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
            drow["job_ID"] = user.job_ID;
            drow["employee_ID"] = user.employee_ID;
            drow["orderRefNo_ID"] = user.orderRefNo_ID;
            drow["chequeRegister_ID"] = user.chequeRegister_ID;
            drow["currency_ID"] = user.currency_ID;
            drow["glPosting_ID"] = user.glPosting_ID;
            drow["postingStatus_ID"] = user.postingStatus_ID;
            drow["postingStatus_ID2"] = user.postingStatus_ID2;
            drow["financialYear_ID"] = user.financialYear_ID;
            drow["salesNoteType_ID"] = user.salesNoteType_ID;
            drow["currencyRate"] = user.currencyRate;
            drow["discountPercentage"] = user.discountPercentage;
            drow["discountPercentage1"] = user.discountPercentage1;
            drow["discountPercentage2"] = user.discountPercentage2;
            drow["discountPercentage3"] = user.discountPercentage3;
            drow["nbtPercentage"] = user.nbtPercentage;
            drow["vatPercentage"] = user.vatPercentage;
            drow["otherTaxPercentage"] = user.otherTaxPercentage;
            drow["subTotal"] = user.subTotal;
            drow["discountTotal"] = user.discountTotal;
            drow["discountTotal1"] = user.discountTotal1;
            drow["discountTotal2"] = user.discountTotal2;
            drow["discountTotal3"] = user.discountTotal3;
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
            drow["paymentTerms"] = user.paymentTerms;
            drow["paymentMode"] = user.paymentMode;
            drow["creditPeriod"] = user.creditPeriod;
            drow["paymentDueDate"] = user.paymentDueDate;
            drow["isLocked"] = user.isLocked;
            drow["seattleAmount"] = user.seattleAmount;
            drow["isSeattled"] = user.isSeattled;
            drow["isSeattled_DO"] = user.isSeattled_DO;
            drow["printCount"] = user.printCount;
            drow["isDebitNote"] = user.isDebitNote;
            drow["isOpeningBalance"] = user.isOpeningBalance;
            drow["isReturnedCheque"] = user.isReturnedCheque;
            drow["isPartPayment"] = user.isPartPayment;
            drow["isAdvancePayment"] = user.isAdvancePayment;
            drow["isWeightCalculation"] = user.isWeightCalculation;
            drow["isTaxReverseCalulation"] = user.isTaxReverseCalulation;
            drow["isVatInvoice"] = user.isVatInvoice;
            drow["isSVatInvoice"] = user.isSVatInvoice;
            drow["branch_ID"] = user.branch_ID;
            drow["customerGrnNo"] = user.customerGrnNo;
            drow["itemPriceCategory"] = user.itemPriceCategory;
            drow["isPosInvoice"] = user.isPosInvoice;
            drow["companyID"] = user.companyID;
            drow["companyBranch_ID"] = user.companyBranch_ID;
            drow["isTaxExcludedInvoice"] = user.isTaxExcludedInvoice;
            drow["nbtPercentage_EX"] = user.nbtPercentage_EX;
            drow["vatPercentage_EX"] = user.vatPercentage_EX;
            drow["otherTaxPercentage_EX"] = user.otherTaxPercentage_EX;
            drow["subTotal_EX"] = user.subTotal_EX;
            drow["nbtTotal_EX"] = user.nbtTotal_EX;
            drow["vatTotal_EX"] = user.vatTotal_EX;
            drow["otherTaxTotal_EX"] = user.otherTaxTotal_EX;
            drow["grandTotal_EX"] = user.grandTotal_EX;
            drow["dAmount_AdvancePayment"] = user.dAmount_AdvancePayment;
            drow["route_ID"] = user.route_ID;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}
