using source.Models;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Repository
{
    public class DoacaoRepository : IRepository<Doacao>
    {
        private readonly INoSql _noSql;

        public DoacaoRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public async Task<IEnumerable<Doacao>> GetAllDocument()
        {
            return await _noSql.GetAllDocument<Doacao>();
        }

        public async Task<IEnumerable<Doacao>> GetByAsync(Expression<Func<Doacao, bool>> filter)
        {
            return await _noSql.GetDocumentsByFilter<Doacao>(filter);
        }

        public async Task<Doacao> GetDocumentByID(string _id)
        {
            return await _noSql.GetDocumentByID<Doacao>(_id);
        }

        public async Task InsertOrUpdateAsync(Doacao entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}