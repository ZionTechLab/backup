using Express.UI.Insfastructure.SAP;
using Express.View.Domain.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Common.SrvReference
{
   public sealed class HttpSapReference
    {
        private HttpSapReference()
        {

        }
        public static string SapSend()
        {
            try
            {
                SAPRest<SAPInvoiceHeaderViewModel> RST = new SAPRest<SAPInvoiceHeaderViewModel>();
                var result = RST.Post("INVOICE", null).Result;
                //textBox1.Text = result.Message;
                return result.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
                //textBox1.Text = ex.InnerException.Message;

            }
        }
    }
}
