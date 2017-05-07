using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaAuxiliarPesquisaZika.Data.Repository
{
    public class RepositoryBase<TEntity> : Domain.RecemNascido, IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        protected AuxSystemResearchContext _db = new AuxSystemResearchContext();
        private bool _disposed;

        public void Delete(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Deleted;
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges();
        }

        public void Insert(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        public IEnumerable<TEntity> SelectAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity SelectById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }

        #region Implementaçao do Pattern IDisposable

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_db != null)
                    {
                        _db.Dispose();
                        _db = null;
                    }
                }
                _disposed = true;
            }
        }

        ~RepositoryBase()
        {
            dispose(false);
        }

        #endregion
    }
}
