using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> filter);
    }
}