using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Doacao;
using source.ViewModel.Pagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Service
{
    public class PagamentoService : IService
    {
        private readonly PagamentoRepository _pagamentoRepository;
        //private readonly DoacaoService _doacaoService;

        //public PagamentoService(PagamentoRepository pagamentoRepository, DoacaoService doacaoService)
        public PagamentoService(PagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            //_doacaoService = doacaoService;
        }

        public async Task<Pagamento> ConsultarPagamento(string id)
        {
            return await _pagamentoRepository.GetDocumentByID(id);
        }

        public async Task<string> Salvar(CadastroPagamentoVM cadastroPagamentoVM)
        {
            var pagamento = Converter(cadastroPagamentoVM);
            await _pagamentoRepository.InsertOrUpdateAsync(pagamento);
            return pagamento._id.ToString();
        }

        public async Task<CadastroDoacaoVM> GerarDoacao(CadastroPagamentoVM cadastroPagamentoVM)
        {
            string idPagamento = await Salvar(cadastroPagamentoVM);

            CadastroDoacaoVM cadastroDoacaoVM = new CadastroDoacaoVM();
            cadastroDoacaoVM.IdDoador = cadastroPagamentoVM.IdDoador;
            cadastroDoacaoVM.IdInstituicao = cadastroPagamentoVM.IdInstituicao;
            cadastroDoacaoVM.Valor = cadastroPagamentoVM.Valor;
            cadastroDoacaoVM.IdPagamento = idPagamento;

            //string retorno = await _doacaoService.Salvar(cadastroDoacaoVM);
            //return retorno;

            return cadastroDoacaoVM;
        }

        private Pagamento Converter(CadastroPagamentoVM cadastroPagamentoVM)
        {
            Pagamento pagamento = new Pagamento();
            pagamento.Valor = cadastroPagamentoVM.Valor;
            pagamento.NomeCartao = cadastroPagamentoVM.NomeCartao;
            pagamento.NumeroCartao = cadastroPagamentoVM.NumeroCartao;
            pagamento.CodigoSegurancaCartao = cadastroPagamentoVM.CodigoSegurancaCartao;
            pagamento.ValidadeCartao = cadastroPagamentoVM.ValidadeCartao;
            return pagamento;
        }
    }
}