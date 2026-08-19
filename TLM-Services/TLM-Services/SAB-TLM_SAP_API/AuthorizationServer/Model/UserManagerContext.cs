using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AuthorizationServer.Model.DBEntity;

namespace AuthorizationServer.Model
{
   public class UserManagerContext:DbContext
    {
        public UserManagerContext()
            : base("name=FedexExpressEntityFramwork")
        {
           
        }

        //public virtual DbSet<Users> AdmCities { get; set; }

        public virtual DbSet<ConBranch> ConBranches { get; set; }
        public virtual DbSet<ConCompany> ConCompanies { get; set; }
        public virtual DbSet<ConUserBranch> ConUserBranches { get; set; }

        public virtual DbSet<ConUserDetail> ConUserDetailes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserManagerContext>(null);            
        }
    }
}
