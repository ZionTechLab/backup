using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
   public  class ManifestInbLVProPramDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }

        [Required(ErrorMessage = "Please enter bayan no")]
        [RegularExpression((@"^[\sa-zA-Z0-9]*$"),
         ErrorMessage = "Please remove special character.")]
        public string BayanNo { get; set; }

        [Required(ErrorMessage = "Please enter payment ref")]
        [RegularExpression((@"^[\sa-zA-Z0-9]*$"),
         ErrorMessage = "Please remove special character.")]
        public string PaymentRef { get; set; }
        public int PaymentAcc { get; set; }
        public string ConsIds { get; set; }

        public string ExpressCons { get; set; }
        public int UserID { get; set; }
        public DateTime PaymentDate { get; set; }
        public string BillTo { get; set; }
        public string PayVouNumber { get; set; }
    }
}
