
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using POS.Entity.Entities;

namespace POS.Repository
{
    ///Created by Srikanth Kotnala on 8/4/2016
    ///Generic Repository pattern for POS project.
    public class GenericRepository<TEntity> : IDisposable
        where TEntity : class
    {
        internal DbContext context;
        internal IDbSet<TEntity> dbSet;

        /// <summary>
        /// Initialize entity objects in constructor.
        /// In case create object based on the entity we are calling through repository.
        /// In default assign entity which might be used commonly for many modules.
        /// </summary>
        /// <param name="entityName"></param>
        public GenericRepository(string entityName)
        {
            switch (entityName)
            {
                case EntityConstant.POS:                                                                                                                                                               
                    this.context = new POSEntities();
                    break;
                //case EntityConst.Test:
                //    //this.context = new Test_Entity();
                //    break;
                default:
                    this.context = null;     
                    break;
            }
            this.dbSet = this.context.Set<TEntity>();
        }

        /// <summary>
        /// Get list of rows by condition or orderby
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Insert Row
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Delete by ID
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Delete by model
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == System.Data.Entity.EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Edit record
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            //if(dbSet.Local.Count>0)
            //{
            //    dbSet.Local.Clear();
                
            //}

            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Stored procedure expecting a model back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="spName"></param>
        /// <returns></returns>
        public IEnumerable<T> ExecStoreProcedure<T>(string spName)
        {
            return context.Database.SqlQuery<T>("Exec " + spName);
        }


        /// <summary>
        /// Fire and forget
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        public void ExecStoreProcedure(string spName, params object[] parameters)
        {
            context.Database.ExecuteSqlCommand("Exec " + spName, parameters);
        }

        private bool disposed = false;
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose context
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ///
    }

}
