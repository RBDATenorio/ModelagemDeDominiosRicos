﻿using MediatR;
using ModelagemDeDominiosRicos.Core.Communication;
using ModelagemDeDominiosRicos.Core.DomainObjects.DTOs;
using ModelagemDeDominiosRicos.Core.Extensions;
using ModelagemDeDominiosRicos.Core.Messages;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.IntegrationEvents;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.Notifications;
using ModelagemDeDominiosRicos.Vendas.Application.Events;
using ModelagemDeDominiosRicos.Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>,
                                        IRequestHandler<AtualizarItemPedidoCommand, bool>,
                                        IRequestHandler<RemoverItemPedidoCommand, bool>,
                                        IRequestHandler<AplicarVoucherPedidoCommand, bool>,
                                        IRequestHandler<IniciarPedidoCommand, bool>    
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMediatrHandler _mediatorHandler;
        public PedidoCommandHandler(IPedidoRepository pedidoRepository,
                                    IMediatrHandler mediatorHandler)
        {
            _pedidoRepository = pedidoRepository;
            _mediatorHandler = mediatorHandler;
        }
        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(message)) return false;
            
            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(message.ClientId);
            
            var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);

            if (pedido is null)
            {
                pedido = Pedido.PedidoFactory.NovoPedidoRascunho(message.ClientId);
                pedido.AdicionarItem(pedidoItem);

                _pedidoRepository.Adicionar(pedido);
                pedido.AdicionarEvento(new PedidoRascunhoIniciadoEvent(message.ClientId, message.ProdutoId));
            }
            else
            {
                var pedidoItemExistente = pedido.PedidoItemExistente(pedidoItem);
                pedido.AdicionarItem(pedidoItem);

                if (pedidoItemExistente)
                {
                    _pedidoRepository.AtualizarItem(pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId));
                }
                else
                {
                    _pedidoRepository.AdicionarItem(pedidoItem);
                }

                pedido.AdicionarEvento(new PedidoAtualizadoEvent(pedido.ClienteId, pedido.Id, pedido.ValorTotal));
            }

            pedido.AdicionarEvento(new PedidoRascunhoItemAdicionadoEvent(pedido.ClienteId, pedido.Id, message.ProdutoId, message.ValorUnitario, message.Quantidade));
            return await _pedidoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AtualizarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(message)) return false;

            var pedido = await ChecarPedido(message.ClienteId);

            if (pedido is null) return false;

            var pedidoItem = await ChecarPedidoItem(pedido, message.PedidoId, message.ProdutoId);

            if (pedidoItem is null) return false;

            pedido.AtualizarUnidades(pedidoItem, message.Quantidade);

            pedido.AdicionarEvento(new PedidoAtualizadoEvent(pedido.ClienteId, pedido.Id, pedido.ValorTotal));
            pedido.AdicionarEvento(new PedidoProdutoAtualizadoEvent(message.ClienteId, pedido.Id, message.ProdutoId, message.Quantidade));

            _pedidoRepository.AtualizarItem(pedidoItem);
            _pedidoRepository.Atualizar(pedido);

            return await _pedidoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(RemoverItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(message)) return false;

            var pedido = await ChecarPedido(message.ClienteId);

            if (pedido is null) return false;

            var pedidoItem = await ChecarPedidoItem(pedido, message.PedidoId, message.ProdutoId);

            if (pedidoItem is null) return false;

            pedido.RemoverItem(pedidoItem);
            
            pedido.AdicionarEvento(new PedidoProdutoRemovidoEvent(message.ClienteId, pedido.Id, message.ProdutoId));

            _pedidoRepository.RemoverItem(pedidoItem);
            _pedidoRepository.Atualizar(pedido);

            return await _pedidoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AplicarVoucherPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(message)) return false;

            var pedido = await ChecarPedido(message.ClienteId);

            if (pedido is null) return false;

            var voucher = await _pedidoRepository.ObterVoucherPorCodigo(message.CodigoVoucher);

            if(voucher is null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("pedido", "Voucher não encontrado."));
                return false;
            }

            var voucherAplicacaoValidation = pedido.AplicarVoucher(voucher);

            if (!voucherAplicacaoValidation.IsValid)
            {
                foreach (var error in voucherAplicacaoValidation.Errors)
                {
                    await _mediatorHandler.PublicarNotificacao(new DomainNotification(error.ErrorCode, error.ErrorMessage));
                }

                return false;
            }

            pedido.AdicionarEvento(new PedidoAtualizadoEvent(pedido.ClienteId, pedido.Id, pedido.ValorTotal));
            pedido.AdicionarEvento(new VoucherAplicadoPedidoEvent(message.ClienteId, pedido.Id, voucher.Id));

            _pedidoRepository.Atualizar(pedido);

            return await _pedidoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(IniciarPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(message)) return false;

            var pedido = await ChecarPedido(message.ClienteId);

            if (pedido is null) return false;

            pedido.IniciarPedido();

            var itensList = new List<Item>();

            pedido.PedidoItems.ForEach(i => itensList.Add(new Item {
                Id = i.ProdutoId, Quantidade = i.Quantidade }));

            var listaProdutosPedido = new ListaProdutoPedido { PedidoId = pedido.Id, Itens = itensList };

            pedido.AdicionarEvento(new PedidoIniciadoEvent(pedido.Id, pedido.ClienteId, pedido.ValorTotal, listaProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));


            _pedidoRepository.Atualizar(pedido);

            return await _pedidoRepository.UnitOfWork.Commit();
        }

        public bool ValidarCommand(Command message)
        {
            if (message.EhValido()) return true;

            foreach(var erro in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, erro.ErrorMessage));
            }

            return false;
        }

        private async Task<Pedido> ChecarPedido(Guid clientId)
        {
            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(clientId);

            if (pedido is null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("pedido", "Pedido não encontrado."));
                return null;
            }

            return pedido;
        }

        private async Task<PedidoItem> ChecarPedidoItem(Pedido pedido, Guid pedidoId, Guid produtoId)
        {
            var pedidoItem = await _pedidoRepository.ObterItemPorPedido(pedidoId, produtoId);

            if (!pedido.PedidoItemExistente(pedidoItem))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("pedido", "Item não encontrado."));
                return null;
            }

            return pedidoItem;
        }
    }
}
