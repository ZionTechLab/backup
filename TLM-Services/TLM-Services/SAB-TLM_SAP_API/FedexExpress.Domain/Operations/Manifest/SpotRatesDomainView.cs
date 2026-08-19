using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Pricing
{
    public class SpotRatesDomainView
    {
        public int AutoID { get; set; }

        public bool Deleted { get; set; }
       
        public string ExpressID { get; set; }

        public string AgnAWBNo { get; set; }

        public string Remarks { get; set; }

        public DateTime EnterDate { get; set; }

        [Required(ErrorMessage = "Please Enter Rate ")]
        [RegularExpression((@"^(0*[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*)$"),ErrorMessage = "Invalid Rate")]
        public decimal Rate { get; set; }

        public DateTime TransDate { get; set; }

        public int USM_ID { get; set; }

        public string FullName { get; set; }

        public DateTime USM_DATE { get; set; }
    }
}
