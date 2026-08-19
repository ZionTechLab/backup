using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class ManifestProcessParamDomainView
    {
        public string ConsID { get; set; }
        public string AgnTrackNo { get; set; }
        public string ExpressID { get; set; }
        public DateTime TransDate { get; set; }
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }
        public string Currency { get; set; }
        public int UserID { get; set; }
        public int ClearenceTarif { get; set; }
        public int ClearenceValue { get; set; }
        public string ClearanceCurr { get; set; }
        public string  PayParty { get; set; } // all --'' / Shipper --S / Consingnee --C / 3 party -- O

        //New ExpressCons
        public string ExpressCons { get; set; }
       
    }
}
