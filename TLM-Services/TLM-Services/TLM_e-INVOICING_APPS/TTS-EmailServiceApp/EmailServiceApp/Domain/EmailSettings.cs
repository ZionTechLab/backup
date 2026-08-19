using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{
    public sealed class EmailSettings
    {
        public static EmailConfigDomainView Settings { get; set; }
        private EmailSettings()
        {

        }
    }
}
