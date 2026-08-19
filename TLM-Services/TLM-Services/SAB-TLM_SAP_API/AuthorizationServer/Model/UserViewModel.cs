using AuthorizationServer.Model.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationServer.Model
{
    public class UserViewModel
    {
        
        public int UserId { get; set; }      
          
        public string UserName { get; set; }       
        public string Password { get; set; }
        public virtual IQueryable<ConUserBranch> ConUserBranches { get; set; }

    }
}