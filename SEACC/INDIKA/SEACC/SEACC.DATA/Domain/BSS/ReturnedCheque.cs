using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.BSS
{
    public class ReturnedCheque
    {
        public string Txn_ID { get; set; }
        public DateTime Txn_Date { get; set; }
        public string Customer_ID { get; set; }
        public string employee_ID { get; set; }
        public string OrderRefNo_ID { get; set; }
        public string ChequeRegister_ID { get; set; }
        public string CurrencyCode { get; set; }
        public string FinancialYearID { get; set; }
        public string SalesNoteType_ID { get; set; }
        public decimal Amount { get; set; }
        public string UserID { get; set; }
        public string TerminalID { get; set; }
        public string CompanyID { get; set; }
        public string CompanyBranch_ID { get; set; }
        public string chequeStatus_ID { get; set; }
    }
}