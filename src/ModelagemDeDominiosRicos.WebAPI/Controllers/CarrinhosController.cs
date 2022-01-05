﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModelagemDeDominiosRicos.Catalogo.Application.Services;
using ModelagemDeDominiosRicos.Core.Communication;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.Notifications;
using ModelagemDeDominiosRicos.Vendas.Application.Commands;
using ModelagemDeDominiosRicos.Vendas.Application.Queries;
using System;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhosController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IPedidoQueries _pedidoQueries;
        private readonly IMediatrHandler _mediatrHandler;

        public CarrinhosController(INotificationHandler<DomainNotification> notifications,
                                   IProdutoAppService produtoAppService,
                                   IPedidoQueries pedidoQueries,
                                   IMediatrHandler mediatrHandler) : base(notifications, mediatrHandler)
        {
            _produtoAppService = produtoAppService;
            _pedidoQueries = pedidoQueries;
            _mediatrHandler = mediatrHandler;
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);

            if (produto is null) return NotFound("Pedido não encontrado.");

            if(produto.QuantidadeEmEstoque < quantidade)
            {
                return BadRequest("Produto com estoque insuficiente.");
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, produto.QuantidadeEmEstoque, produto.Valor);
            await _mediatrHandler.EnviarCommand(command);

            if (!OperacaoValida())
            {
                return BadRequest(_notifications.ObterMensagensDeNotificacoes());
            }

            return Ok();
        }
    
        [HttpGet]
        [Route("meus-pedidos")]
        public async Task<IActionResult> ObterPedidos()
        {
            var pedidos = await _pedidoQueries.ObterCarrinhoCliente(ClienteId);
            
            if (pedidos is null) return NotFound("Nenhum pedido para esse cliente");
            
            return Ok(pedidos);

        }
    }
}
