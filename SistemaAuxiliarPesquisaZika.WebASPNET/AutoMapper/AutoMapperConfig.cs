using AutoMapper;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x => 
            {
                x.CreateMap<Usuario, UsuariosViewModel>();
                x.CreateMap<Perfil, PerfilViewModel>();
                x.CreateMap<UsuariosViewModel, Usuario>();
                x.CreateMap<PerfilViewModel, Perfil>();
            });
        }
    }
}