using AutoMapper;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        //protected static void Configure()
        //{
        //    Mapper.Map<UsuarioViewModel, Usuario>();
        //    Mapper.Map<PerfilViewModel, Perfil>();
        //}
    }
}