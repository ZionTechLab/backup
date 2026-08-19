using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class PodScanUploadParaDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }
        public int UserID { get; set; } 
        public string UDate { get; set; }      
        public string CurrierID { get; set; }
        public string RoutID { get; set; }
        public int AllCurrier { get; set; }
        public int AllRoute { get; set; }
        public int UnprocessScan { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public IList<PodScanUploadDomainView> PodList { get; set; }

    }
}
