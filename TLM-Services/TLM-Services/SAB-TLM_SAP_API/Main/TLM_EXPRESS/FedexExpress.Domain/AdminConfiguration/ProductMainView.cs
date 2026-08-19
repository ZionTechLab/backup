using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.AdminConfiguration
{
    public class ProductMainView
    {
        public int CompanyID { get; set; }
        public string ShipmentType { get; set; }
        [Required(ErrorMessage = "Please select product main.")]
        public string ProductMain { get; set; }
        public string ProductMainName { get; set; }
    }
}
