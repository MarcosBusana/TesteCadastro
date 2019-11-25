using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Empresas;
using Microsoft.EntityFrameworkCore;

namespace Hbsis.Wms.Infra.Repositorios
{
    public class EmpresaRepository : IEmpresaRepository
    {
        protected readonly DbContext _context;
        protected readonly DbSet<Empresa> _set;

        public EmpresaRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<Empresa>();
        }

        public void Remove(params Guid[] ids)
        {
            var entity = _set.Where(d => ids.Contains(d.Id)).First();

            if (entity != null)
                _context.Set<Empresa>().Remove(entity);
        }
        public Empresa Add(Empresa entity)
        {
            return _context.Set<Empresa>().Add(entity).Entity;
        }

        public void Update(Empresa entity)
        {
            var exist = _set.Find(entity.Id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
        }

        public IEnumerable<Empresa> Find(Expression<Func<Empresa, bool>> predicate)
        {
            return _set.Where(predicate);
        }

        public IQueryable<Empresa> GetAll()
        {
            return _set;
        }

        public void Remove(Guid id)
        {
            var entity = _set.Find(id);
            _context.Set<Empresa>().Remove(entity);
        }

    }
}
