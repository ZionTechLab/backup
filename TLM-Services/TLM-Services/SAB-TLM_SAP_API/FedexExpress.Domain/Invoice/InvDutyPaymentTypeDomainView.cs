using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    [NotMapped]
    public class InvDutyPaymentTypeDomainView
    {
        public string ShipValueType { get; set; }
        public string ShipValueTypeN { get; set; }
    }
}
