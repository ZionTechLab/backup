using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF
{
    internal interface IExpressUnitOfWork<TEntity> : IDisposable where TEntity : class
    {
        IRepository<TEntity> Reposotery { get; }
        void Commit();
    }
}
