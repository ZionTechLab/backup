using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHE_Api.Models
{
    public class CreditInfoResultView
    {
        public bool Credit_Active { get; set; }
        public bool Cash_Only { get; set; }
        public string Remarks { get; set; }
    }
}