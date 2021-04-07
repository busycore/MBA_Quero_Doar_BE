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

        public async Task<IEnumerable<Empresa>> GetAllDocument()
        {
            return await _noSql.GetAllDocument<Empresa>();
        }

        public async Task<IEnumerable<Empresa>> GetByAsync(Expression<Func<Empresa, bool>> filter)
        {
            return await _noSql.GetDocumentsByFilter<Empresa>(filter);
        }

        public async Task<Empresa> GetDocumentByID(string _id)
        {
            return await _noSql.GetDocumentByID<Empresa>(_id);
        }

        public async Task InsertOrUpdateAsync(Empresa entity)
        {
            await _noSql.InsertOrUpdateAsync(entity);
        }
    }
}
