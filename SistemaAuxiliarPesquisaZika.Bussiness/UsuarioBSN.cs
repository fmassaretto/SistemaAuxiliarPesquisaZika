using System.Collections.Generic;
using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;
using SistemaAuxiliarPesquisaZika.Data.Context;
using System;
using SistemaAuxiliarPesquisaZika.Domain;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class UsuarioBSN : RepositoryBSN<Usuario>, IDisposable
    {
        protected AuxSystemResearchContext _db = new AuxSystemResearchContext();

        public override void Delete(Usuario obj)
        {
            base.Delete(obj);
        }

        public override void Insert(Usuario obj)
        {
           base.Insert(obj);
        }

        public override IEnumerable<Usuario> SelectAll()
        {
            return base.SelectAll();
        }

        public override Usuario SelectById(int id)
        {
            return base.SelectById(id);
        }

        public override void Update(Usuario obj)
        {
            base.Update(obj);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
