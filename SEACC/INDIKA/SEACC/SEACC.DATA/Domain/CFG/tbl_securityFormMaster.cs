using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.CFG
{
    public class tbl_securityFormMaster
    {
        public int Form_ID { get; set; }
        public int SortOrder { get; set; }
        public string FormName { get; set; }
        public object Image { get; set; }
        public string FormCategory_ID { get; set; }
        public string DisplayName { get; set; }
        public bool IsEnable { get; set; }
        public bool IsVisible { get; set; }
        public bool IsViewer { get; set; }
        public string DocumentCode { get; set; }
        public string Namespace { get; set; }
        public string Class { get; set; }
        public string FormType { get; set; }
        public byte[] Image2
        {
            get { return (byte[])Image; }
            set { Image = value; }
        }
    }
}
