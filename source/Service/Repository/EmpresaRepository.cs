using source.Models;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Repository
{
    public class EmpresaRepository : IRepository<Empresa>
    {
        private readonly INoSql _noSql;

        public EmpresaRepository(INoSql noSql)
        {
            _noSql = noSql;
        }

        public async Task<IEnumerable<Empresa>> GetByAsync(Expression<Func<Empresa, bool>> filter)
        {
            var empresas = await _noSql.GetDocumentsByFilter<Empresa>(filter);
            return empresas;
        }

        public Task<Empresa> GetDocumentByID(string _id)
        {
            throw new NotImplementedException();
        }

        public Task InsertOrUpdateAsync(Empresa entity)
        {
            throw new NotImplementedException();
        }
    }
}
