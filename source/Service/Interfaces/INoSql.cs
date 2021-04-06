using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Interfaces
{
    public interface INoSql : IDisposable
    {
        Task<T> InsertOrUpdateAsync<T>(T value) where T : IModelBase;
        Task<IEnumerable<T>> GetDocumentsByFilter<T>(Expression<Func<T, bool>> filter) where T : IModelBase;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> filter) where T : IModelBase;
        Task<T> GetDocumentByID<T>(string _id) where T : IModelBase;
        Task<IEnumerable<T>> GetAllDocument<T>() where T : IModelBase;
    }
}