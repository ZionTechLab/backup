using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{
    public class EmailConfigDomainView
    {
       public int SmtpID { get; set; }
        public string SmtpServerN { get; set; }
        public int PortCode { get; set; }
       public string  UserName { get; set; }
       public string  Password { get; set; }
    }
}
