using AutoMapper;
using ModelagemDeDominiosRicos.Catalogo.Application.DTOs;
using ModelagemDeDominiosRicos.Catalogo.Domain;

namespace ModelagemDeDominiosRicos.Catalogo.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(p => p.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
                .ForMember(p => p.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
                .ForMember(p => p.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
