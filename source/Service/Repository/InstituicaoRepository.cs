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

        public Task<IEnumerable<Instituicao>> GetAllDocument()
        {
            return _noSql.GetAllDocument<Instituicao>();
        }

        public Task<IEnumerable<Instituicao>> GetByAsync(Expression<Func<Instituicao, bool>> filter)
        {
            return _noSql.GetDocumentsByFilter<Instituicao>(filter);
        }

        public Task<Instituicao> GetDocumentByID(string _id)
        {
            return _noSql.GetDocumentByID<Instituicao>(_id);
        }

        public Task InsertOrUpdateAsync(Instituicao entity)
        {
            return _noSql.InsertOrUpdateAsync(entity);
        }
    }
}