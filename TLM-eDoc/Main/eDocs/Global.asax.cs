using eDocs;
using eDocs.Models;
using eDocs_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace eDocs
{
    public class MvcApplication : System.Web.HttpApplication
    {
     string con=  System.Configuration.ConfigurationManager.
    ConnectionStrings["DefaultConnection"].ConnectionString;
     
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

           // SqlDependency.Start(con);
        }


       

      
    }


}
