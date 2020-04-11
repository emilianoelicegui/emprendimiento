using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Layer
{
    public interface IRepository<T> where T : class
    {
        Task Save(T entity);

        Task Update(T entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> Get(IEnumerable<int> ids);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        public Task Save(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
