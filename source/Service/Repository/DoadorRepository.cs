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
    public class DoadorRepository : IRepository<Doador>
    {
        private readonly INoSql _noSql;

        public DoadorRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public async Task<IEnumerable<Doador>> GetByAsync(Expression<Func<Doador, bool>> filter)
        {
            var doador = await _noSql.GetDocumentsByFilter<Doador>(filter);
            return doador;
        }

        public async Task<Doador> GetDocumentByID(string _id)
        {
            var doador = await _noSql.GetDocumentByID<Doador>(_id);
            return doador;
        }

        public async Task InsertOrUpdateAsync(Doador entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}