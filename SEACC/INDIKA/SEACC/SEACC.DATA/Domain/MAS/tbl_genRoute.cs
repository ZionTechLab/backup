using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.MAS
{
  public  class tbl_genRoute
    {
        public int route_ID { get; set; }
        public string route_Code { get; set; }
        public string routeName { get; set; }
        public DateTime LockUntill { get; set; }
        public bool isLocked { get; set; }
        public string salesManager_ID { get; set; }
        public string areaManager_ID { get; set; }
        public string salesRep_ID { get; set; }
        public string salesExecutive_ID { get; set; }
        public string salesManagerName { get; set; }
        public string areaManagerName { get; set; }
        public string selesRepName{ get; set; }
}
}
