using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayMVC.DOMAIN.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        List<TEntity> Get(string includeProperties = "");
        TEntity Find(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(object id);
        void Remove(TEntity entity);

        //This was an example to show compiler enforcement of all interface members
        //string DoStuff(int thing);
        int CountRecords();

    }
}
