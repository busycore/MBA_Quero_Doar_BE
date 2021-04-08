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
    public class CupomRepository : IRepository<Cupom>
    {
        private readonly INoSql _noSql;

        public CupomRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public async Task<IEnumerable<Cupom>> GetAllDocument()
        {
            return await _noSql.GetAllDocument<Cupom>();
        }

        public async Task<IEnumerable<Cupom>> GetByAsync(Expression<Func<Cupom, bool>> filter)
        {
            return await _noSql.GetDocumentsByFilter<Cupom>(filter);
        }

        public async Task<Cupom> GetDocumentByID(string _id)
        {
            return await _noSql.GetDocumentByID<Cupom>(_id);
        }

        public async Task InsertOrUpdateAsync(Cupom entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}