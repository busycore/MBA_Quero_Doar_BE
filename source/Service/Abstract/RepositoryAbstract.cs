using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Abstract
{
    public abstract class RepositoryAbstract<T> : IRepository<T> where T : class
    {
        public abstract Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> filter);

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
