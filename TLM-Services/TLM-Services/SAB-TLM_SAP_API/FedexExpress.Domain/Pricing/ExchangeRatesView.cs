using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Pricing
{
    public class ExchangeRatesView
    {
       

       
        [Required(ErrorMessage = "Please enter Exchange Rate Tarrif Type")]
        [RegularExpression((@"^[1-9]\d*(\.\d{0,2})?$"),
         ErrorMessage = "Please select Exchange Rate Tarrif Type.")]
        public int ExgRateTarif { get; set; }
        
        [Required(ErrorMessage = "Please enter currency")]
        public string Currency { get; set; }      

        [Display(Name = "Effective Date")]
        [Required(ErrorMessage = "Please enter Effective Date")]
        public DateTime EffectDate { get; set; }       
       
        [Required(ErrorMessage = "Please enter Exchange Rate")]
        ////[RegularExpression((@"^[1-9]\d*(\.\d{0,3})?$"),      
        //// ErrorMessage = "Invalid Exchange Rate ")]
        public decimal  ExgRate { get; set; }


       
        public string Remarks { get; set; }
        public int UserID { get; set; }
    }
}
