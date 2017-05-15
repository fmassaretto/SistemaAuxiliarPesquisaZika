using System.Collections.Generic;
using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;
using SistemaAuxiliarPesquisaZika.Domain;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class UsuarioBSN : RepositoryBSN<Usuario>
    {
        //private readonly AuxSystemResearchContext _db = new AuxSystemResearchContext();

        public new void Delete(Usuario obj)
        {
            base.Delete(obj);
        }

        public new void Insert(Usuario obj)
        {
           base.Insert(obj);
        }

        public new IEnumerable<Usuario> SelectAll()
        {
            return base.SelectAll();
        }

        public new Usuario SelectById(int id)
        {
            return base.SelectById(id);
        }

        public new void Update(Usuario obj)
        {
            base.Update(obj);
        }

        public void Dispose()
        {
            base.Disposed();
        }
    }
}
