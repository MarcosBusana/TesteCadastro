using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dominio.Empresas
{
    public interface IEmpresaRepository
    {
        void Remove(Guid id);
        Empresa Add(Empresa entity);
        void Update(Empresa entity);
        IEnumerable<Empresa> Find(Expression<Func<Empresa, bool>> predicate);
        IQueryable<Empresa> GetAll();
    }
}
