using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KayMVC.DATA;
namespace KayMVC.DOMAIN.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DbContext db;
        public GenericRepository(DbContext context)
        {
            this.db = context;
        }
        public virtual List<TEntity> Get(string includeProperties = "")
        {
            IQueryable<TEntity> query = db.Set<TEntity>();
            foreach (var prop in includeProperties.Split(new char[] { ',' },
                                StringSplitOptions.RemoveEmptyEntries))
            {
                //add the property to be included in the query
                //to the return value
                query = query.Include(prop);
            }
            return query.ToList();
        }
        public virtual TEntity Find(object id)
        {
            return db.Set<TEntity>().Find(id);
        }
        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            //db.SaveChanges(); Now handled by the UOW
        }
        public void Update(TEntity entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
        }
        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            //db.SaveChanges();
        }
        public void Remove(object id)
        {
            var entity = db.Set<TEntity>().Find(id);
            Remove(entity);
            //db.SaveChanges();
        }

        public int CountRecords()
        {
            return Get().Count();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
