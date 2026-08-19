
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationServer.Model
{
    internal class UserManageRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UserManagerContext db;
        protected readonly DbSet<TEntity> dbset;

        public UserManageRepository(UserManagerContext _db)
        {
            if (db == null)
            {
                this.db = _db;
            }
            dbset = db.Set<TEntity>();
        }


        public string DeleteDetail(TEntity objPara)
        {
            throw new NotImplementedException();
        }

        public string EditDetails(TEntity objPara)
        {
            try
            {


                DbEntityEntry entry = db.Entry(objPara);
                if (entry.State == EntityState.Detached)
                {
                    dbset.Attach(objPara);
                }
                entry.State = EntityState.Modified;

                return "Update";
            }
            catch(Exception )
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public IQueryable<TEntity> GetDetails()
        {
            return dbset;
        }

        public IQueryable<TEntity> GetDetails(TEntity objPara)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetDetails(string code)
        {
            throw new NotImplementedException();            
        }

       

        public string SaveDetails(TEntity objPara)
        {
            try
            {
                dbset.Add(objPara);
                return "Saved";            
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
