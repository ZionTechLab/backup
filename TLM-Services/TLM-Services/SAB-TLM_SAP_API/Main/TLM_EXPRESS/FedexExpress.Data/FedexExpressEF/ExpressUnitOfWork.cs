using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF
{
   internal class ExpressUnitOfWork<TEntity> : IExpressUnitOfWork<TEntity> where TEntity : class
    {
        private readonly ExpressContext _dbCtx;
      

        public ExpressUnitOfWork()
        {
            _dbCtx = CreateDb();
         
        }

        private ExpressContext CreateDb()
        {
            return new ExpressContext();
        }


        public void Commit()
        {
            _dbCtx.SaveChanges();
        }


        public IRepository<TEntity> Reposotery
        {
            get
            {
                return new ExpressRepository<TEntity>(_dbCtx); ;
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
