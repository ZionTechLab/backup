using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedexExpress.View.Domain.AdminConfiguration
{
    public class MapScanTypeDomainView
    {
        public int Seqno { get; set; }

        public int CMPY { get; set; }

        public int AgncyCode { get; set; }

        public string ScanTypeS { get; set; }

        public string ScanTypeP { get; set; }
       
        public string RemarkS { get; set; }
       
        public string RemarkP { get; set; }

        public bool Active { get; set; }
    }
}
