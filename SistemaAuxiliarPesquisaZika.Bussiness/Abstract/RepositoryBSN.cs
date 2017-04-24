using SistemaAuxiliarPesquisaZika.Data.Repository;
using SistemaAuxiliarPesquisaZika.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAuxiliarPesquisaZika.Bussiness.Abstract
{
    public abstract class RepositoryBSN<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryBase<T> _repository;
        protected RepositoryBSN()
        {
            _repository = new RepositoryBase<T>();
        }

        public virtual void Delete(T obj)
        {
            _repository.Delete(obj);
        }

        public virtual void Insert(T obj)
        {
            _repository.Insert(obj);
        }

        public virtual IEnumerable<T> SelectAll()
        {
            return _repository.SelectAll();
        }

        public virtual T SelectById(int id)
        {
            return _repository.SelectById(id);
        }

        public virtual void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
