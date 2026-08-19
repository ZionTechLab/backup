using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.WinFormControls.Validations
{
    public class xSearchQuary
    {
        StringBuilder sb = new StringBuilder();
        public void Append(string s)
        {
            if (s != "")
                sb.Append((sb.Length == 0 ? "" : " | ") + s);
        }

        public void Clear()
        {
            sb.Clear();
        }

        public string GetQuary()
        {
            return sb.ToString();
        }
    }
}
