using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_Report.Excel_DataTable
{
    public class cls_sasMonthlyReturnsAgainst_Sales_DTO
    {
        public string Route { get; set; }
        public string SalesRep { get; set; }
        public string InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Month { get; set; }

        public decimal GrossValue { get; set; }
        public decimal ReturnValue { get; set; }

        public cls_sasMonthlyReturnsAgainst_Sales_DTO(string _Route, string _SalesRep, string _InvoiceID, DateTime _InvoiceDate, int _Month, decimal _GrossValue, decimal _ReturnValue)
        {
            Route = _Route;
            SalesRep = _SalesRep;
            InvoiceID = _InvoiceID;
            InvoiceDate = _InvoiceDate;
            Month = _Month;
            GrossValue = _GrossValue;
            ReturnValue = _ReturnValue;
        }

        public cls_sasMonthlyReturnsAgainst_Sales_DTO()
        {

        }
    }
}
