using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetDetails();
        IQueryable<TEntity> GetDetails(string code);
        IQueryable<TEntity> GetDetails(TEntity typePara);
        IQueryable<TEntity> GetDataBySp(string spName, SqlParameter[] paraList);
        string SaveDetails(TEntity typePara);
        string EditDetails(TEntity typePara);
        string DeleteDetail(TEntity typePara);
        string DeleteDetailRange(IEnumerable<TEntity>  typePara);
    }
}
