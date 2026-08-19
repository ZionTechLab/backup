using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.AdminConfiguration
{
    public class ProductSubView
    {
        public int CompanyID { get; set; }
        public string ShipmentType { get; set; }
        public string ServiceType { get; set; }
        public string ProductMain { get; set; }
        [Required(ErrorMessage = "Please select product sub.")]
        public string ProductSub { get; set; }
        public string ProductSubName { get; set; }
      public string  Active { get; set; }
    }
}
