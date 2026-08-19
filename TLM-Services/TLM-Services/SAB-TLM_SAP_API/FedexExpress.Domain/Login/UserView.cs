
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Express.View.Domain.Login
{
    public class UserView
    {
        /// <summary>
        /// check for delete
        /// </summary>
        public int UserID { get; set; }

        public string UserLoginName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
               
       // public IList <CompanyView> UserCompany { get; set; }
        
        //public UserProjectCompany UserComPro { get; set; }

    }
}