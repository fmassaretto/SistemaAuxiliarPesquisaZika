using SistemaAuxiliarPesquisaZika.Domain;
using System.Collections.Generic;
using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class PerfilBSN : RepositoryBSN<Perfil>
    {
        //private readonly RepositoryBase<Perfil> _repository;

        //public PerfilBSN()
        //{
        //    _repository = new RepositoryBase<Perfil>();
        //}
        public void Delete(Perfil obj)
        {
            base.Delete(obj);
        }

        public void Insert(Perfil obj)
        {
            base.Insert(obj);
        }

        public IEnumerable<Perfil> SelectAll()
        {
            return base.SelectAll();
        }

        public Perfil SelectById(int id)
        {
            return base.SelectById(id);
        }

        public void Update(Perfil obj)
        {
            base.Update(obj);
        }
    }
}
