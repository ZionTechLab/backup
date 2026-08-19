using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationServer.Model
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetDetails();
        IQueryable<TEntity> GetDetails(string code);
        
        IQueryable<TEntity> GetDetails(TEntity objPara);
        IQueryable<TEntity> GetDataBySp(string spName, SqlParameter[] paraList);
        string SaveDetails(TEntity objPara);
        string EditDetails(TEntity objPara);
        string DeleteDetail(TEntity objPara);
    }
}
