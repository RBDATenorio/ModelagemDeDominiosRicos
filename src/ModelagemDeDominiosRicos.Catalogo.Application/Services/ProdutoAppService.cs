using AutoMapper;
using ModelagemDeDominiosRicos.Catalogo.Application.DTOs;
using ModelagemDeDominiosRicos.Catalogo.Domain;
using ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces;
using ModelagemDeDominiosRicos.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEstoqueService _estoqueService;

        public ProdutoAppService(IProdutoRepository repository, 
                                IMapper mapper, 
                                IEstoqueService estoqueService)
        {
            _repository = repository;
            _mapper = mapper;
            _estoqueService = estoqueService;
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _repository.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoDTO> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(await _repository.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _repository.ObterTodos());
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(await _repository.ObterPorCategorias());
        }

        public async Task AdicionarProduto(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            _repository.Adicionar(produto);

            await _repository.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            _repository.Atualizar(produto);

            await _repository.UnitOfWork.Commit();
        }

        public async Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
            {
                throw new DomainException("Falha ao debitar estoque");
            }

            return _mapper.Map<ProdutoDTO>(await _repository.ObterPorId(id));
        }

        public async Task<ProdutoDTO> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
            {
                throw new DomainException("Falha ao repor estoque");
            }

            return _mapper.Map<ProdutoDTO>(await _repository.ObterPorId(id));
        }
    }
}
