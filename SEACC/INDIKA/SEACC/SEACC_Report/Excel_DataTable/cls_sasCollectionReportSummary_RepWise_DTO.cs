using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_Report.Excel_DataTable
{
    public class cls_sasCollectionReportSummary_RepWise_DTO
    {
        public string SalesRep { get; set; }
        public string Customer_Code { get; set; }
        public string Customer_Name { get; set; }
        public string CustomerClass { get; set; }
        public string CustomerType { get; set; }
        public string CustomerCategory { get; set; }
       

        public decimal Credit_Period { get; set; }
        public decimal Credit_Limit { get; set; }

        public string Invoice_No { get; set; }
        public decimal Less_Than_60_Days { get; set; }
        public decimal Over_60_Days { get; set; }
        public decimal Total { get; set; }
        public decimal Advance_Payment { get; set; }
        public decimal PartFullPayment { get; set; }
        public decimal Total_Collection_Amount { get; set; }

        public decimal Percentage { get; set; }
        public decimal Pd_Cheques_InHand { get; set; }
        public decimal NotRealizedCheques { get; set; }
    }
}
