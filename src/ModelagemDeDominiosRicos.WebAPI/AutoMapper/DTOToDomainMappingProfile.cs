using AutoMapper;
using ModelagemDeDominiosRicos.Catalogo.Application.DTOs;
using ModelagemDeDominiosRicos.Catalogo.Domain;
using ModelagemDeDominiosRicos.Catalogo.Domain.ValueObjects;

namespace ModelagemDeDominiosRicos.WebAPI.AutoMapper
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<ProdutoDTO, Produto>()
                .ConstructUsing(p => new Produto(p.CategoriaId, p.Nome, p.Descricao, p.Ativo,
                                            p.Valor, p.DataCadastro, p.Imagem,
                                            new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaDTO, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
