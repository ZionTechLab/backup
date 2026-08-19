using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationServer.Model
{
   internal class UserManageUnitOfWork<TEntity> : IUserManageUnitOfWork<TEntity> where TEntity : class
    {
        private readonly UserManagerContext _dbCtx;
      

        public UserManageUnitOfWork()
        {
            _dbCtx = CreateDb();

        }

        private UserManagerContext CreateDb()
        {
            return new UserManagerContext();
        }


        public void Commit()
        {
            _dbCtx.SaveChanges();
        }


        public IRepository<TEntity> Reposotery
        {
            get
            {
                return new UserManageRepository<TEntity>(_dbCtx); ;
            }
        }



        private bool disposed = false;     

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbCtx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
