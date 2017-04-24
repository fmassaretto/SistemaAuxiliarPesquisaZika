using SistemaAuxiliarPesquisaZika.Data.Repository;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Domain.Interface;
using System.Collections.Generic;
using System;
using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class UsuarioBSN : RepositoryBSN<Usuario>
    {
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
    }
}
