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

        public async Task<IEnumerable<MeusCupons>> GetAllDocument()
        {
            return await _noSql.GetAllDocument<MeusCupons>();
        }

        public async Task<IEnumerable<MeusCupons>> GetByAsync(Expression<Func<MeusCupons, bool>> filter)
        {
            return await _noSql.GetDocumentsByFilter<MeusCupons>(filter);
        }

        public async Task<MeusCupons> GetDocumentByID(string _id)
        {
            return await _noSql.GetDocumentByID<MeusCupons>(_id);
        }

        public async Task InsertOrUpdateAsync(MeusCupons entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}