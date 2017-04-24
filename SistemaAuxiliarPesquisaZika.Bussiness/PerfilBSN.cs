using SistemaAuxiliarPesquisaZika.Data.Repository;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class PerfilBSN : IRepositoryBase<Perfil>
    {
        protected RepositoryBase<Perfil> _repository;

        public PerfilBSN()
        {
            _repository = new RepositoryBase<Perfil>();
        }
        public void Delete(Perfil obj)
        {
            _repository.Delete(obj);
        }

        public void Insert(Perfil obj)
        {
            _repository.Insert(obj);
        }

        public IEnumerable<Perfil> SelectAll()
        {
            return _repository.SelectAll();
        }

        public Perfil SelectById(int id)
        {
            return _repository.SelectById(id);
        }

        public void Update(Perfil obj)
        {
            _repository.Update(obj);
        }
    }
}
