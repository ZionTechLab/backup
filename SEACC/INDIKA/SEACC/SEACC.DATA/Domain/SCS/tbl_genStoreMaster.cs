using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.SCS
{
    public class tbl_genStoreMaster
    {
        public string store_ID { get; set; }
        public string storeName { get; set; }
        public bool isSalesStore { get; set; }
        public string store_ShortName { get; set; }
    }
}
