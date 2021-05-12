using source.Models;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task<IEnumerable<Empresa>> GetAllDocument()
        {
            return _noSql.GetAllDocument<Empresa>();
        }

        public Task<IEnumerable<Empresa>> GetByAsync(Expression<Func<Empresa, bool>> filter)
        {
            return _noSql.GetDocumentsByFilter<Empresa>(filter);
        }

        public Task<Empresa> GetDocumentByID(string _id)
        {
            return _noSql.GetDocumentByID<Empresa>(_id);
        }

        public Task InsertOrUpdateAsync(Empresa entity)
        {
            return _noSql.InsertOrUpdateAsync(entity);
        }
    }
}