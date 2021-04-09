using source.Models;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Repository
{
    public class InstituicaoRepository : IRepository<Instituicao>
    {
        private readonly INoSql _noSql;

        public InstituicaoRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public async Task<IEnumerable<Instituicao>> GetAllDocument()
        {
            return await _noSql.GetAllDocument<Instituicao>();
        }

        public async Task<IEnumerable<Instituicao>> GetByAsync(Expression<Func<Instituicao, bool>> filter)
        {
            return await _noSql.GetDocumentsByFilter<Instituicao>(filter);
        }

        public async Task<Instituicao> GetDocumentByID(string _id)
        {
            return await _noSql.GetDocumentByID<Instituicao>(_id);
        }

        public async Task InsertOrUpdateAsync(Instituicao entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}