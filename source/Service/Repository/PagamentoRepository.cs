using source.Models;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Repository
{
    public class PagamentoRepository : IRepository<Pagamento>
    {
        private readonly INoSql _noSql;

        public PagamentoRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public Task<IEnumerable<Pagamento>> GetAllDocument()
        {
            return _noSql.GetAllDocument<Pagamento>();
        }

        public Task<IEnumerable<Pagamento>> GetByAsync(Expression<Func<Pagamento, bool>> filter)
        {
            return _noSql.GetDocumentsByFilter<Pagamento>(filter);
        }

        public Task<Pagamento> GetDocumentByID(string _id)
        {
            return _noSql.GetDocumentByID<Pagamento>(_id);
        }

        public Task InsertOrUpdateAsync(Pagamento entity)
        {
            return _noSql.InsertOrUpdateAsync(entity);
        }
    }
}