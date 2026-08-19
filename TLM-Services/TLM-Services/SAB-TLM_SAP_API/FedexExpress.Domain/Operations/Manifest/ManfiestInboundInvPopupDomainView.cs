using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class ManfiestInboundInvPopupDomainView
    {
        public decimal CustomPayAmount { get; set; }
        public DateTime PayDate { get; set; }

        [Required(ErrorMessage = "Please enter Bayan number")]
        public string BayanNo { get; set; }
        public string PaymentRef { get; set; }

        [Required(ErrorMessage = "Please select Payment account")]
        public string PaymentAcc { get; set; }

    }
}
