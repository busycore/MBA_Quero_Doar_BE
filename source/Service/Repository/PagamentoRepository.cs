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

        public async Task<IEnumerable<Pagamento>> GetAllDocument()
        {
            return await _noSql.GetAllDocument<Pagamento>();
        }

        public async Task<IEnumerable<Pagamento>> GetByAsync(Expression<Func<Pagamento, bool>> filter)
        {
            return await _noSql.GetDocumentsByFilter<Pagamento>(filter);
        }

        public async Task<Pagamento> GetDocumentByID(string _id)
        {
            return await _noSql.GetDocumentByID<Pagamento>(_id);
        }

        public async Task InsertOrUpdateAsync(Pagamento entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}