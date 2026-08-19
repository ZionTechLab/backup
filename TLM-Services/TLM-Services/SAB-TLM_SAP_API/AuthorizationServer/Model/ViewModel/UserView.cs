using AuthorizationServer.Model.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationServer.Model.ViewModel
{
    public class UserView
    {
        public int UserID { get; set; }
        public string UserLoginName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }


        public IList<UserComBranchView> UserComBranch { get; set; }
        public IList <CompanyView> UserCompany { get; set; }
        public IList<UserBranchView> UserBranch { get; set; }

    }
}