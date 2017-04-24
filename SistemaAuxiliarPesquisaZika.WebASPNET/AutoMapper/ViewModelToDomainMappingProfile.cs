using AutoMapper;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        //protected static void Configure()
        //{
        //    Mapper.CreateMap<Usuario, UsuarioViewModel>();
        //    Mapper.Map<Perfil, PerfilViewModel>();
        //}
    }
}