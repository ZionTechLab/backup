using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.View.Domain.SAP
{
    public class SAPInvoiceHeaderViewModel
    {
        public string ACDocNo { get; set; }
        public string HeaderTxt { get; set; }
        public string CompCode { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime TransDate { get; set; }
        public int FiscYear { get; set; }
        public int FiscPeriod { get; set; }

        public string DocType { get; set; }
        public string RefDocNo { get; set; }
        public string Company { get; set; }
        public int AgencyCode { get; set; }
        public string AgencyID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SapDocNo { get; set; }
        public string ErrorMessage { get; set; }
        public bool Sent { get; set; }
        public bool Success { get; set; }
        public DateTime SAPSentDate { get; set; }
        public List<AccountGLViewModel> AccountGL { get; set; }
        public List<AccountReceivableViewModel> AccountReceivable { get; set; }
        public List<AccountTaxViewModel> AccountTax { get; set; }
        public List<CurrencyAmountViewModel> CurrencyAmount { get; set; }


        public string Message { get; set; }


    }
}