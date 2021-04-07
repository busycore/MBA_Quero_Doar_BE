using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task InsertOrUpdateAsync(T entity);
        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> filter);
        Task<T> GetDocumentByID(string _id);
        Task<IEnumerable<T>> GetAllDocument();
    }
}