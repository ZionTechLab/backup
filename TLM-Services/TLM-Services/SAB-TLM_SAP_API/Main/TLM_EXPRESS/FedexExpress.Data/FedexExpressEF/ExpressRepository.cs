using Express.Data.FedexExpressEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF
{
    internal class ExpressRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ExpressContext db;
        protected readonly DbSet<TEntity> dbset;

        public ExpressRepository(ExpressContext _db)
        {
            if (db == null)
            {
                this.db = _db;
                db.Database.CommandTimeout = 2000;
            }
            dbset = db.Set<TEntity>();
            
        }

        public string SaveDetails(TEntity typePara)
        {
            try
            {
                dbset.Add(typePara);
                return "Saved";
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IQueryable<TEntity> GetDataBySp(string spName, SqlParameter[] paraList)
        {
            try
            {
                string spTemp = spName + " ";
                foreach (var item in paraList)
                {
                    spTemp = spTemp + item.ParameterName.ToString() + ",";
                }

                spTemp = spTemp.Remove(spTemp.Length - 1, 1);
                var result = db.Database
                    .SqlQuery<TEntity>(spTemp, paraList).AsQueryable();

                //////var result = db.Database
                ////// .SqlQuery<ProductCategory_Sp_Result>("[dbo].[USP_GetProductCategory] @varCateCode", new SqlParameter("@varCateCode", DBNull.Value)).ToList();
                
                return result;

            }
            catch(SqlException )
            {
                throw;
            }
            catch(DbUpdateException )
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ;
            }

        }

        public string EditDetails(TEntity typePara)
        {
            try
            {


                DbEntityEntry entry = db.Entry(typePara);
                if (entry.State == EntityState.Detached)
                {
                    dbset.Attach(typePara);
                }
                entry.State = EntityState.Modified;

                return "Update";
            }
            catch (DbUpdateException )
            {
                throw;
            }
            catch(Exception )
            {
                throw;
            }
        }
             
        public string DeleteDetail(TEntity typePara)
        {
          try
            {
                dbset.Remove(typePara);
                return "Deleted";
            }
            catch (Exception )
            {
                throw;
            }
        }

        public string DeleteDetailRange(IEnumerable<TEntity> typePara)
        {
            try
            {
                dbset.RemoveRange(typePara);
                return "Deleted";
                  
            }
            catch (DbUpdateException )
            {
                throw;
            }
            catch(Exception )
            {
                throw;
            }
        }

        public IQueryable<TEntity> GetDetails()
        {
            try
            {
                return dbset;
            }

            catch (Exception )
            {
                throw;
            }
        }

        public IQueryable<TEntity> GetDetails(TEntity typePara)
        {
            throw new NotImplementedException("Not implemented method");
        }

        public IQueryable<TEntity> GetDetails(string code)
        {
            throw new NotImplementedException("Not implemented method");            
        }

        
    }
}
