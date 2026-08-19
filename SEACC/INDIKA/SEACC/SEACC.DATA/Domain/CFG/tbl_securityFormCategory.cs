using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.CFG
{
  public  class tbl_securityFormCategory
    {
        public string FormCategory_ID { get; set; }
        public int SortOrder { get; set; }
        public string CategoryName { get; set; }
        public object  Image_ { get; set; }
        public string DisplayName { get; set; }
        public bool IsEnable { get; set; }
        public bool IsVisible { get; set; }
        public byte[] Image
        {
            get { return (byte[])Image_; }
            set { Image_ = value; }
        }
    }
}
