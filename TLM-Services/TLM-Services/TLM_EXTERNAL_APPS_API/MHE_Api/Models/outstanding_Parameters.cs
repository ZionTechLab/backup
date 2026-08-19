using System;

namespace MHE_Api.Models
{
    public class outstanding_Parameters
    {
        public long Invoice_No
        {
            get;
            set;
        }

        public string AWB_No
        {
            get;
            set;
        }

        public string RPI_No
        {
            get;
            set;
        }
    }

    public class invsummary_Parameters
    {
        public string icpcNo { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public string shippingType { get; set; }
        public string paymentStatus { get; set; }
    }
    public class invlist_Parameters
    {
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
    }
}
