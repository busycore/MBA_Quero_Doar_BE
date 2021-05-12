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
    public class MeusCuponsRepository : IRepository<MeusCupons>
    {
        private readonly INoSql _noSql;

        public MeusCuponsRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public Task<IEnumerable<MeusCupons>> GetAllDocument()
        {
            return _noSql.GetAllDocument<MeusCupons>();
        }

        public Task<IEnumerable<MeusCupons>> GetByAsync(Expression<Func<MeusCupons, bool>> filter)
        {
            return _noSql.GetDocumentsByFilter<MeusCupons>(filter);
        }

        public Task<MeusCupons> GetDocumentByID(string _id)
        {
            return _noSql.GetDocumentByID<MeusCupons>(_id);
        }

        public Task InsertOrUpdateAsync(MeusCupons entity)
        {
            return _noSql.InsertOrUpdateAsync(entity);
        }
    }
}