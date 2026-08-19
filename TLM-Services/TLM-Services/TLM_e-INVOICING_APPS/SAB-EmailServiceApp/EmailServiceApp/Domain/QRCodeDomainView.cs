using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{
    public class QRCodeDomainView
    {
        public int Tag { get; set; }
        public string Value { get; set; }
    }
    public class InvoiceQRCode
    {
        public string InvNo { get; set; }
        public Byte[] QR { get; set; }
    }
    public class objTot
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string InvNo { get; set; }
        public DateTime DocDate { get; set; }
        public string TaxRegNo { get; set; }
        public decimal LineAmount { get; set; }
        public decimal TAX1 { get; set; }
        public string DocType { get; set; }
    }



}
