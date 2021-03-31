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
        public Task<IEnumerable<Doador>> GetByAsync(Expression<Func<Doador, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Doador entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Doador entity)
        {
            throw new NotImplementedException();
        }
    }
}