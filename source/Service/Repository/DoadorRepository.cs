using source.Models;
using source.Service.Abstract;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Repository
{
    public class DoadorRepository : RepositoryAbstract<Doador>
    {
        public override Task<IEnumerable<Doador>> GetByAsync(Expression<Func<Doador, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}