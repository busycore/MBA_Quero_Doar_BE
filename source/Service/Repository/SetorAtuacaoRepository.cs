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

        public Task<IEnumerable<SetorAtuacao>> GetAllDocument()
        {
            return _noSql.GetAllDocument<SetorAtuacao>();
        }

        public Task<IEnumerable<SetorAtuacao>> GetByAsync(Expression<Func<SetorAtuacao, bool>> filter)
        {
            return _noSql.GetDocumentsByFilter<SetorAtuacao>(filter);
        }

        public Task<SetorAtuacao> GetDocumentByID(string _id)
        {
            return _noSql.GetDocumentByID<SetorAtuacao>(_id);
        }

        public Task InsertOrUpdateAsync(SetorAtuacao entity)
        {
            return _noSql.InsertOrUpdateAsync(entity);
        }
    }
}