using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MHE_Api.Models
{
    public class AuthRepository
    {
        string[] auth = ConfigurationManager.AppSettings["Auth"].Split(',');
        public bool ValidateUser(string username, string password)
        {
            string un = auth[0];
            string pw = auth[1];
            if (username == un && password == pw)
                return true;

            return false;
        }
    }
}