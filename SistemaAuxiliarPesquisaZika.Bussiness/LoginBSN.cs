using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;
using System;
using System.Linq;
using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class LoginBSN : RepositoryBSN<Usuario>, IDisposable
    {
        private readonly AuxSystemResearchContext _db = new AuxSystemResearchContext();
        private Usuario _usuario;
        public Usuario Login(string email, string senha)
        {
            //senha = senha.GerarHash();

            try
            {
                var retorno = (from u in _db.Usuarios
                               join p in _db.Perfil on u.IdPerfil equals p.Id
                               where (u.Email == email) && (u.Senha == senha) && u.Ativo
                               select new
                               {
                                   u.Id,
                                   u.Nome,
                                   u.Email,
                                   u.Ativo,
                                   IdPerfil = p.Id,
                                   NomePerfil = p.Nome
                               }).ToList();

                foreach (var item in retorno)
                {
                    _usuario = new Usuario()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Email = item.Email,
                        Ativo = item.Ativo,
                        IdPerfil = item.IdPerfil,
                        NomePerfil = item.NomePerfil
                    };
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                throw new Exception("Problemas com a conexão com banco de dados", sqlException);
            }
            //IEnumerable<Usuario> retornoViewModel = retorno.Select(x => new Usuario(x.Id, x.Nome, x.Email, x.Ativo, new Perfil { Id = x.IdPerfil, Nome = x.PNome })
            //);
            return _usuario;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
