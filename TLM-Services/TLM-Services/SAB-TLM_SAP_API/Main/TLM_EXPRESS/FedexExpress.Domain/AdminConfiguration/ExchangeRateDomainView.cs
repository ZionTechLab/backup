using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.AdminConfiguration
{
   public class ExchangeRateDomainView
    {

        public int CMPY { get; set; }

        [Display(Name = "ExgRatTarif")]
        [Required(ErrorMessage = "Please enter Exchange Rate ID")]
        public int ExgRatTarif { get; set; }

        [Display(Name = "Exg Rat Tarif Name")]
        [Required(ErrorMessage = "Please enter Exchange  Rate Tarif Name")]
        public string ExgRatTarifN { get; set; }
        public String FromCurrency { get; set; }
        public String ToCurrency { get; set; }
        public bool Active { get; set; }
        public DateTime EffectDate { get; set; }
        public decimal ExtRate { get; set; }
    }
}
