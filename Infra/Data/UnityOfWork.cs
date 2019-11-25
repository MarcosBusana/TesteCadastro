using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infra.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ContextoBase _contexto;
        private IDbContextTransaction _transaction;

        public UnityOfWork(ContextoBase contexto, IDbContextTransaction transaction)
        {
            _contexto = contexto;
            _transaction = transaction;
        }
        public void BeginTransaction()
        {
            _transaction = _contexto.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            try
            {
                var result = _contexto.ChangeTracker.HasChanges() ? _contexto.SaveChanges() : 0;

                return result;
            }
            catch (Exception)
            {
                _transaction?.Dispose();
                return 0;
            }
        }

        public int SaveAndCommit()
        {
            try
            {
                var result = this.Save();
                this.Commit();
                return result;
            }
            catch (Exception)
            {
                _transaction?.Dispose();
                return 0;
            }
        }
    }   
}
