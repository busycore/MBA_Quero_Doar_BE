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

        public Task<IEnumerable<Cupom>> GetAllDocument()
        {
            return _noSql.GetAllDocument<Cupom>();
        }

        public Task<IEnumerable<Cupom>> GetByAsync(Expression<Func<Cupom, bool>> filter)
        {
            return _noSql.GetDocumentsByFilter(filter);
        }

        public Task<Cupom> GetDocumentByID(string _id)
        {
            return _noSql.GetDocumentByID<Cupom>(_id);
        }

        public Task InsertOrUpdateAsync(Cupom entity)
        {
            return _noSql.InsertOrUpdateAsync(entity);
        }
    }
}