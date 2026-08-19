using System;

namespace MHE_Api.Models
{
    public class OutstandingResultView
    {
        public int Customer_Code
        {
            get;
            set;
        }

        public string Customer_Name
        {
            get;
            set;
        }

        public long Invoice_No
        {
            get;
            set;
        }

        public decimal Invoice_Amount
        {
            get;
            set;
        }

        public DateTime Invoice_Date
        {
            get;
            set;
        }

        public string Pay_Mode
        {
            get;
            set;
        }

        public string Product_Service
        {
            get;
            set;
        }

        public decimal Outstanding_Amount
        {
            get;
            set;
        }

        public int Advance_booking_Number
        {
            get;
            set;
        }

        public int Advance_Amount
        {
            get;
            set;
        }

        public int RPI_Amount
        {
            get;
            set;
        }
    }

    public class InvSummaryResult
    {
        public long Invoice_No { get; set; }
        public string Invoice_Type { get; set; }
        public string Tracking_No { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Due_Date { get; set; }
        public string Payment_Status { get; set; }
        public decimal Outstanding_FCAmt { get; set; }
        public decimal Outstanding_LCAmt { get; set; }
        public decimal Total_FCAmt { get; set; }
        public decimal Total_LCAmt { get; set; }
        public decimal Dimension { get; set; }
        public decimal Actual_WGT { get; set; }
        public decimal Bill_WGT { get; set; }
        public string Shipper_Name { get; set; }
        public string Shipper_Address { get; set; }
        public string Consignee_Name { get; set; }
        public string Consignee_Address { get; set; }

    }
    public class InvListResult
    {
        public DateTime Date { get; set; }
        public string Invoice_type { get; set; }
        public long Invoice_no { get; set; }
        public string AWB_no { get; set; }
        public int Org_code { get; set; }
        public string Debtor_name { get; set; }
        public string Org_city { get; set; }
        public decimal Value_fc { get; set; }
        public decimal Value_lc { get; set; }
        public decimal Balance_lc { get; set; }
        public decimal Currency_rate { get; set; }
        public string Ref_no { get; set; }
        public string Remarks { get; set; }

    }
}
