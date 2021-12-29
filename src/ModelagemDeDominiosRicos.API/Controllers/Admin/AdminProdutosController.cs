using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelagemDeDominiosRicos.Catalogo.Application.DTOs;
using ModelagemDeDominiosRicos.Catalogo.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.API.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMapper _mapper;
        public AdminProdutosController(IProdutoAppService produtoAppService,
                                        IMapper mapper)
        {
            _produtoAppService = produtoAppService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _produtoAppService.ObterTodos();

            produtos = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

            return Ok(produtos);
        }
    }
}
