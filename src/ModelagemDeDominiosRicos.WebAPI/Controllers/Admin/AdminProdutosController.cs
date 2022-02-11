using Microsoft.AspNetCore.Mvc;
using ModelagemDeDominiosRicos.Catalogo.Application.DTOs;
using ModelagemDeDominiosRicos.Catalogo.Application.Services;
using System;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        public AdminProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("testes")]
        public async Task<IActionResult> Teste()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _produtoAppService.ObterTodos());
        }

        [HttpGet]
        [Route("detalhe/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await _produtoAppService.ObterPorId(id);

            if (produto is null) return NotFound("Produto não encontrado");

            return Ok(produto);
        }

        [HttpPost]
        [Route("cadastrar-produto")]
        public async Task<IActionResult> CadastrarProduto(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _produtoAppService.AdicionarProduto(produtoDTO);

            return Created($"api/AdminProdutos/{produtoDTO.Id}", produtoDTO);
        }

        [HttpPost]
        [Route("cadastrar-categoria")]
        public async Task<IActionResult> CadastrarCategoria(CategoriaDTO categoriaDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _produtoAppService.AdicionarCategoria(categoriaDTO);

            return Created("", categoriaDTO);
        }

        [HttpPost]
        [Route("atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if(quantidade < 0)
            {
                await _produtoAppService.DebitarEstoque(id, quantidade);
            }
            else
            {
                await _produtoAppService.ReporEstoque(id, quantidade);
            }

            return Ok("Estoque atualizado com sucesso!");
        }
    }
}
