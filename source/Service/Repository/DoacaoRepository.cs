using MongoDB.Bson;
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

        public Task<IEnumerable<Doacao>> GetAllDocument()
        {
            return _noSql.GetAllDocument<Doacao>();
        }

        public Task<IEnumerable<Doacao>> GetByAsync(Expression<Func<Doacao, bool>> filter)
        {
            return _noSql.GetDocumentsByFilter<Doacao>(filter);
        }

        public Task<Doacao> GetDocumentByID(string _id)
        {
            return _noSql.GetDocumentByID<Doacao>(_id);
        }

        public Task<IEnumerable<Doacao>> GetAllDoacaoByDoadorLastYear(string idDoador)
        {
            return _noSql.GetDocumentsByFilter<Doacao>(m =>
                    m.Doador._id == new ObjectId(idDoador)
                    && m.DataDoacao >= DateTime.Now.Date.AddYears(-1));
        }

        public Task InsertOrUpdateAsync(Doacao entity)
        {
            return _noSql.InsertOrUpdateAsync(entity);
        }
    }
}