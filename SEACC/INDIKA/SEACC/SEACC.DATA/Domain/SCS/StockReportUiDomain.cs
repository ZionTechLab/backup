using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.SCS
{
    public class StockReportUiDomain
    {
        public List<tbl_genStoreMaster> Store {get;set;}
        public List<tbl_zItemClass> ItemClass { get; set; }
        public List<tbl_zItemType> ItemType { get; set; }
        public List<tbl_zItemCategory> ItemCategory { get; set; }
    }
}
