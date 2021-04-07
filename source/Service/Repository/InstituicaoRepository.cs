using MongoDB.Bson;
using source.Models;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Instituicao>> GetByAsync(Expression<Func<Instituicao, bool>> filter)
        {
            var instiuicao = await _noSql.GetDocumentsByFilter<Instituicao>(filter);
            return instiuicao;
        }

        public async Task<Instituicao> GetDocumentByID(string _id)
        {
            var instiuicao = await _noSql.GetDocumentByID<Instituicao>(_id);
            return instiuicao;
        }

        public async Task InsertOrUpdateAsync(Instituicao entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}