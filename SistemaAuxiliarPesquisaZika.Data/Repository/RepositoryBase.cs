using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaAuxiliarPesquisaZika.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        protected AuxSystemResearchContext _db = new AuxSystemResearchContext();

        public Domain.RecemNascido RecemNascido
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Domain.PesquisaSocioSaude PesquisaSocioSaude
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Domain.Paciente Paciente
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

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

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
