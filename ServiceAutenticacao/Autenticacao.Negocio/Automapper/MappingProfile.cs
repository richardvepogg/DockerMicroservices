using Autenticacao.Dominio.Entidades;
using Autenticacao.Dominio.ValueObjects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.Negocio.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Usuario, UsuarioVO>(); 
            CreateMap<UsuarioVO, Usuario>();
        }
    }
}
