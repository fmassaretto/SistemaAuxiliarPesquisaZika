using SistemaAuxiliarPesquisaZika.Data.Repository;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Domain.Interface;
using System.Collections.Generic;
using System;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class UsuarioBSN : IRepositoryBase<Usuario>
    {
        protected RepositoryBase<Usuario> _repository;
        public UsuarioBSN()
        {
            _repository = new RepositoryBase<Usuario>();
        }
        public void Delete(Usuario obj)
        {
            _repository.Delete(obj);
        }

        public void Insert(Usuario obj)
        {
            _repository.Insert(obj);
        }

        public IEnumerable<Usuario> SelectAll()
        {
            return _repository.SelectAll();
        }

        public Usuario SelectById(int id)
        {
            return _repository.SelectById(id);
        }

        public void Update(Usuario obj)
        {
            _repository.Update(obj);
        }
    }
}
