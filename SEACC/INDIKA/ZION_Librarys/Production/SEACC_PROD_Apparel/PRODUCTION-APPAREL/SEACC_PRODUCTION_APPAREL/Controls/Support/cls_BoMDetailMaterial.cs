using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_PRODUCTION_APPAREL
{
    public class cls_BoMDetailMaterial
    {
        private int iLineNo = 0;
        private int iLine_No_Sub1 = 0;
        private int iLine_No_Sub2 = 0;
        private string sItem_ID = "default";
        private bool bIsWIP_SF = false;

        public int ILineNo
        {
            get
            {
                return iLineNo;
            }

            set
            {
                iLineNo = value;
            }
        }

        public string SItem_ID
        {
            get
            {
                return sItem_ID;
            }

            set
            {
                sItem_ID = value;
            }
        }

        public bool BIsWIP_SF
        {
            get
            {
                return bIsWIP_SF;
            }

            set
            {
                bIsWIP_SF = value;
            }
        }

        public int ILine_No_Sub1
        {
            get
            {
                return iLine_No_Sub1;
            }

            set
            {
                iLine_No_Sub1 = value;
            }
        }

        public int ILine_No_Sub2
        {
            get
            {
                return iLine_No_Sub2;
            }

            set
            {
                iLine_No_Sub2 = value;
            }
        }
    }
}
