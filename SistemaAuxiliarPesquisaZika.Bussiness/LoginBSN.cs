using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Domain.DTO;
using SistemaAuxiliarPesquisaZika.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class LoginBSN : IDisposable
    {
        private AuxSystemResearchContext _db = new AuxSystemResearchContext();
        Usuario usuario;
        public Usuario Login(string email, string senha)
        {
            senha = senha.GerarHash();

            var retorno = (from u in _db.Usuarios
                           join p in _db.Perfil on u.IdPerfil equals p.Id
                           where (u.Email == email) && (u.Senha == senha) && (u.Ativo == true)
                           select new {
                               Id = u.Id,
                               Nome = u.Nome,
                               Email = u.Email,
                               Ativo = u.Ativo,
                               IdPerfil = p.Id,
                               NomePerfil = p.Nome }).ToList();

            

            foreach (var item in retorno)
            {
                usuario = new Usuario()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Email = item.Email,
                    Ativo = item.Ativo,
                    IdPerfil = item.IdPerfil,
                    NomePerfil = item.NomePerfil
                };
            }
            //IEnumerable<Usuario> retornoViewModel = retorno.Select(x => new Usuario(x.Id, x.Nome, x.Email, x.Ativo, new Perfil { Id = x.IdPerfil, Nome = x.PNome })
            //);
            return usuario;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
