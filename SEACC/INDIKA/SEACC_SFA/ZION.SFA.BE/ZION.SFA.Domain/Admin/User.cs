using System;
using System.Collections.Generic;
using System.Text;

namespace ZION.SFA.Domain.Admin
{
    public class UserData
    {
        public string user_ID { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string moible { get; set; }
        public string employee_ID { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; } 
        public bool isNewMode { get; set; } 
        public int userType { get; set; }
    }
}
