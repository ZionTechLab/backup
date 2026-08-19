using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.SAP
{
    public class InvoiceHeaderView
    {
        public string AcDocNo { get; set; }
        public string HeaderTxt { get; set; }
        public string CompCode{ get; set; }
        public string DocDate { get; set; }
        public string PstingDate { get; set; }
        public string TransDate { get; set; }
        public int FiscYear { get; set; }
        public int FisPeriod { get; set; }
        public string DocType { get; set; }
        public string RefDocNo{ get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SAPDocNo { get; set; }
        public string ErrorMessage { get; set; }
        public bool SendStatus { get; set; }
        public int SuccessStatus  { get; set; }
        public int SAPSendBy  { get; set; }
        public DateTime SAPSendDate { get; set; }

        public string ErrorType { get; set; }


        public string Customer { get; set; }


        public string ObjKeyInv { get; set; }

        public string Name { get; set; }




    }
}
