using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class srh_bssCustomerOutstanding
    {
        #region Fields
        private string customer_ID;
        private int transactionType;
        private string transaction_ID;
        private string remarks;
        private DateTime transactionDate;
        private string deliveryOrder_ID;    //
        private string purchaseOrder_ID;    //
        private string currencyCode;        //
        private decimal currencyRate;       //
        private decimal transactionAmount;
        private decimal outstanding;
        private bool isChecueInHand;
        private string employee_ID;
        private int age;
        private bool isCredit;
        private bool isAdvance;
        private string orderRefNo;

        private static bool isHideSettled;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the srh_bssCustomerOutstanding class.
        /// </summary>
        public srh_bssCustomerOutstanding()
        {
        }

        /// <summary>
        /// Initializes a new instance of the srh_bssCustomerOutstanding class.
        /// </summary>
        public srh_bssCustomerOutstanding(string customer_ID, string invoice_ID, int transactionType, string transaction_ID, string remarks, DateTime transactionDate, string deliveryOrder_ID, string PurchaseOrder_ID, string currencyCode, decimal currencyRate, decimal transactionAmount, decimal outstanding, bool isChecueInHand, string employee_ID, int age, bool isCredit, bool isAdvance,string orderRefNo)
        {
            this.customer_ID = customer_ID;
            this.transactionType = transactionType;
            this.transaction_ID = transaction_ID;
            this.remarks = remarks;
            this.transactionDate = transactionDate;
            this.deliveryOrder_ID = deliveryOrder_ID;
            this.purchaseOrder_ID = PurchaseOrder_ID;
            this.currencyCode = currencyCode;
            this.currencyRate = currencyRate;
            this.transactionAmount = transactionAmount;
            this.outstanding = outstanding;
            this.isChecueInHand = isChecueInHand;
            this.employee_ID = employee_ID;
            this.age = age;
            this.isCredit = isCredit;
            this.isAdvance = isAdvance;
            this.orderRefNo = orderRefNo;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Customer_ID value.
        /// </summary>
        public string Customer_ID
        {
            get { return customer_ID; }
            set { customer_ID = value; }
        }

        /// <summary>
        /// Gets or sets the TransactionType value.
        /// </summary>
        public int TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }

        /// <summary>
        /// Gets or sets the Transaction_ID value.
        /// </summary>
        public string Transaction_ID
        {
            get { return transaction_ID; }
            set { transaction_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Remarks value.
        /// </summary>
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        /// <summary>
        /// Gets or sets the TransactionDate value.
        /// </summary>
        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }

        /// <summary>
        /// Gets or sets the deliveryOrder_ID value.
        /// </summary>
        public string DeliveryOrder_ID
        {
            get { return deliveryOrder_ID; }
            set { deliveryOrder_ID = value; }
        }

        /// <summary>
        /// Gets or sets the PurchaseOrder_ID value.
        /// </summary>
        public string PurchaseOrder_ID
        {
            get { return purchaseOrder_ID; }
            set { purchaseOrder_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CurrencyCode value.
        /// </summary>
        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        /// <summary>
        /// Gets or sets the currencyRate value.
        /// </summary>
        public decimal CurrencyRate
        {
            get { return currencyRate; }
            set { currencyRate = value; }
        }

        /// <summary>
        /// Gets or sets the TransactionAmount value.
        /// </summary>
        public decimal TransactionAmount
        {
            get { return transactionAmount; }
            set { transactionAmount = value; }
        }

        /// <summary>
        /// Gets or sets the Outstanding value.
        /// </summary>
        public decimal Outstanding
        {
            get { return outstanding; }
            set { outstanding = value; }
        }

        /// <summary>
        /// Gets or sets the Risk value.
        /// </summary>
        public bool IsChecueInHand
        {
            get { return isChecueInHand; }
            set { isChecueInHand = value; }
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
        /// Gets or sets the age value.
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// Gets or sets the isCredit value.
        /// </summary>
        public bool IsCredit
        {
            get { return isCredit; }
            set { isCredit = value; }
        }

 /// <summary>
        /// Gets or sets the isAdvance value.
        /// </summary>
        public bool IsAdvance
        {
            get { return isAdvance; }
            set { isAdvance = value; }
        }

        public string OrderRefNo
        {
            get { return orderRefNo; }
            set { orderRefNo = value; }
        }
        #endregion

        #region Methods
        public static List<srh_bssCustomerOutstanding> SelectAllByCustomerId(string customer_ID, string branch_ID,  DateTime fromDate, DateTime toDate, bool HideSettled)
        {
            isHideSettled = HideSettled;

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_bssCustomerOutstandingSelectAllByCustomerID", scon);
            scom.CommandTimeout = 9000;
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@Branch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@dtmFromDate", SqlDbType.DateTime);
            scom.Parameters.Add("@dtmToDate", SqlDbType.DateTime);

            scom.Parameters["@customer_ID"].Value = customer_ID;
            scom.Parameters["@Branch_ID"].Value = branch_ID;
            scom.Parameters["@dtmFromDate"].Value = fromDate;
            scom.Parameters["@dtmToDate"].Value = toDate;

            //no sales rep<0>  
            //order ref sales rep<1>    
            //customer master sales rep<2>

            List<srh_bssCustomerOutstanding> srh_bssCustomerOutstandingList = new List<srh_bssCustomerOutstanding>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_bssCustomerOutstanding srh_bssCustomerOutstanding = Makesrh_bssCustomerOutstanding(dataReader);
                    if (srh_bssCustomerOutstanding.Outstanding == 0)
                        continue;
                    srh_bssCustomerOutstandingList.Add(srh_bssCustomerOutstanding);
                }
            }
            scon.Close();
            return srh_bssCustomerOutstandingList;
        }

        /// <summary>
        /// Creates a new instance of the srh_bssCustomerOutstanding class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static srh_bssCustomerOutstanding Makesrh_bssCustomerOutstanding(SqlDataReader dataReader)
        {
            srh_bssCustomerOutstanding srh_bssCustomerOutstanding = new srh_bssCustomerOutstanding();

            if (dataReader.IsDBNull(0) == false)
            {
                srh_bssCustomerOutstanding.Customer_ID = dataReader.GetString(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                srh_bssCustomerOutstanding.TransactionType = dataReader.GetInt32(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                srh_bssCustomerOutstanding.Transaction_ID = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                srh_bssCustomerOutstanding.Remarks = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                srh_bssCustomerOutstanding.TransactionDate = dataReader.GetDateTime(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                //decimal x = dataReader.GetDecimal(5);
                srh_bssCustomerOutstanding.DeliveryOrder_ID = dataReader.GetString(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                srh_bssCustomerOutstanding.PurchaseOrder_ID = dataReader.GetString(6);
            }
            if (dataReader.IsDBNull(7) == false)
            {
                srh_bssCustomerOutstanding.CurrencyCode = dataReader.GetString(7);
            }
            if (dataReader.IsDBNull(8) == false)
            {
                srh_bssCustomerOutstanding.CurrencyRate = dataReader.GetDecimal(8);
            }
            if (dataReader.IsDBNull(9) == false)
            {
                srh_bssCustomerOutstanding.TransactionAmount = dataReader.GetDecimal(9);
            }
            if (dataReader.IsDBNull(10) == false)
            {
                srh_bssCustomerOutstanding.Outstanding = dataReader.GetDecimal(10);
            }
            if (dataReader.IsDBNull(11) == false)
            {
                srh_bssCustomerOutstanding.IsChecueInHand = dataReader.GetInt32(11) == 1 ? true : false;
            }
            if (dataReader.IsDBNull(12) == false)
            {
                srh_bssCustomerOutstanding.Employee_ID = dataReader.GetString(12);
            }
            if (dataReader.IsDBNull(13) == false)
            {
                srh_bssCustomerOutstanding.Age = dataReader.GetInt32(13);
            }
            if (dataReader.IsDBNull(14) == false)
            {
                srh_bssCustomerOutstanding.IsCredit = dataReader.GetInt32(14)==1?true:false;
            } 
            if (dataReader.IsDBNull(15) == false)
            {
                srh_bssCustomerOutstanding.IsAdvance = dataReader.GetInt32(15)==1?true:false;
            }
            if (dataReader.IsDBNull(16) == false)
            {
                srh_bssCustomerOutstanding.OrderRefNo = dataReader.GetString(16);
            }
            return srh_bssCustomerOutstanding;
        }
        /// <summary>
        /// This makes srh_bssCustomerOutstanding datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new srh_bssCustomerOutstanding object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(srh_bssCustomerOutstanding srh_bssCustomerOutstanding)
        {
            DataTable dt = new DataTable();

            DataColumn col_customer_ID = new DataColumn("customer_ID", typeof(string));
            DataColumn col_transactionType = new DataColumn("transactionType", typeof(int));
            DataColumn col_transaction_ID = new DataColumn("transaction_ID", typeof(string));
            DataColumn col_remarks = new DataColumn("remarks", typeof(string));
            DataColumn col_transactionDate = new DataColumn("transactionDate", typeof(DateTime));
            DataColumn col_transactionAmount = new DataColumn("transactionAmount", typeof(decimal));
            DataColumn col_outstanding = new DataColumn("outstanding", typeof(decimal));
            DataColumn col_isChecueInHand = new DataColumn("isChecueInHand", typeof(int));
            DataColumn col_employee_ID = new DataColumn("employee_ID", typeof(string));
            DataColumn col_age = new DataColumn("age", typeof(int));
            DataColumn col_isCredit = new DataColumn("isCredit", typeof(int));
            dt.Columns.AddRange(new DataColumn[] { col_customer_ID, col_transactionType, col_transaction_ID, col_remarks, col_transactionDate, col_transactionAmount, col_outstanding, col_isChecueInHand, col_employee_ID, col_age, col_isCredit, }); return dt;
        }
        /// <summary>
        /// This fills srh_bssCustomerOutstanding datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new srh_bssCustomerOutstanding object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, srh_bssCustomerOutstanding user)
        {
            DataRow drow = dt.NewRow();

            drow["customer_ID"] = user.customer_ID;
            drow["transactionType"] = user.transactionType;
            drow["transaction_ID"] = user.transaction_ID;
            drow["remarks"] = user.remarks;
            drow["transactionDate"] = user.transactionDate;
            drow["transactionAmount"] = user.transactionAmount;
            drow["outstanding"] = user.outstanding;
            drow["isChecueInHand"] = user.isChecueInHand;
            drow["employee_ID"] = user.employee_ID;
            drow["age"] = user.age;
            drow["isCredit"] = user.isCredit;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}
