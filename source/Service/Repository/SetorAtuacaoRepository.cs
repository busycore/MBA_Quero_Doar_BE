using source.Models;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Repository
{
    public class SetorAtuacaoRepository : IRepository<SetorAtuacao>
    {
        private readonly INoSql _noSql;

        public SetorAtuacaoRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public async Task<IEnumerable<SetorAtuacao>> GetAllDocument()
        {
            return await _noSql.GetAllDocument<SetorAtuacao>();
        }

        public async Task<IEnumerable<SetorAtuacao>> GetByAsync(Expression<Func<SetorAtuacao, bool>> filter)
        {
            return await _noSql.GetDocumentsByFilter<SetorAtuacao>(filter);
        }

        public async Task<SetorAtuacao> GetDocumentByID(string _id)
        {
            return await _noSql.GetDocumentByID<SetorAtuacao>(_id);
        }

        public async Task InsertOrUpdateAsync(SetorAtuacao entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}