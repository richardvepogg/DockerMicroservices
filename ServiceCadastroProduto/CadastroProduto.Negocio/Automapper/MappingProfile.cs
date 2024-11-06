using AutoMapper;
using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Dominio.ValueObjects;


namespace CadastroProduto.Negocio.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoVO>();
            CreateMap<ProdutoVO, Produto>();
        }
    }
}
