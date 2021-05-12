using source.Models;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Repository
{
    public class DoadorRepository : IRepository<Doador>
    {
        private readonly INoSql _noSql;

        public DoadorRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public Task<IEnumerable<Doador>> GetAllDocument()
        {
            return _noSql.GetAllDocument<Doador>();
        }

        public Task<IEnumerable<Doador>> GetByAsync(Expression<Func<Doador, bool>> filter)
        {
            return _noSql.GetDocumentsByFilter<Doador>(filter);
        }

        public Task<Doador> GetDocumentByID(string _id)
        {
            return _noSql.GetDocumentByID<Doador>(_id);
        }

        public Task InsertOrUpdateAsync(Doador entity)
        {
            return _noSql.InsertOrUpdateAsync(entity);
        }
    }
}