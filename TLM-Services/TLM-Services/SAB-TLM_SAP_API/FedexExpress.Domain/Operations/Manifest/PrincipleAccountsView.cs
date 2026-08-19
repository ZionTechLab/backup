using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class PrincipleAccountsView
    {
        public int USM_ID { get; set; }
        // public Nullable<DateTime> USM_Date { get; set; }
        public DateTime USM_Date { get; set; }
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string AgncyName { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string AcNo { get; set; }
        public string CurrentActNo { get; set; }
        public string Active { get; set; }
        public string Remarks { get; set; }
        //public Nullable<DateTime> DelUSM_Date { get; set; }
        public DateTime DelUSM_Date { get; set; }
        public int Deleted { get; set; }
        //public Nullable<int> DelUSM_ID { get; set; }
        public int DelUSM_ID { get; set; }




    }
}
