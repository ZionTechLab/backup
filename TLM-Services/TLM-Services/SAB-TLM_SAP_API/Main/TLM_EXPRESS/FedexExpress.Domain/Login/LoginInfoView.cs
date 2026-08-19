using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Login
{
    public class LoginInfoView
    {
        public static string BEARERTOKEN { get; set; }
        public static object WEBSERVERCLIENT { get; set; }
        public static string SERVICEHOSTURL { get; set; }
        public static int COMPANYID { get; set; }  // Set Default company
        public static string COMPANYNAME { get; set; }
        public static string BRANCHCODE { get; set; }
        public static string BARNCHNAME { get; set; }
        public static int AGENCYID { get; set; } // Set Detfault Agencies
        public static int USERID { get; set; }
        public static string USERlOGINNAME { get; set; } // User login display name
        public static string USERNAME { get; set; }
        public static string PASSWORD { get; set; }
        public static string USERLOGDATETIME { get; set; }
        public static object USERLOGFORM { get; set; }
        public static bool ISFROMPORTAL { get; set; }
        public static string SERVICEPATH { get; set; }
        public static string PROJECTNAME { get; set; }     
        public static int MODULEID { get; set; }
        public static int MENUCODE { get; set; }
        public static byte[] USERIMAGE { get; set; }

        public static List<ConUserAccessDomainView> UserCompanyList { get; set; }

        public static ConUserAccessDomainView SelectedCompany { get; set; }

        public static int ONECUSTCODE { get; set; }
        public static string REPORTPATH { get; set; }
        public static int DECIMALPRECION { get; set; }


    }
}
