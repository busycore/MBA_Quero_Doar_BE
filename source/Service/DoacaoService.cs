using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Doacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Service
{
    public class DoacaoService : IService
    {
        private readonly DoacaoRepository _doacaoRepository;
        private readonly DoadorService _doadorService;
        private readonly InstituicaoService _instituicaoService;
        private readonly PagamentoService _pagamentoService;

        public DoacaoService(DoacaoRepository doacaoRepository, DoadorService doadorService,
                             InstituicaoService instituicaoService, PagamentoService pagamentoService)
        {
            _doacaoRepository = doacaoRepository;
            _doadorService = doadorService;
            _instituicaoService = instituicaoService;
            _pagamentoService = pagamentoService;
        }

        public async Task<string> Salvar(CadastroDoacaoVM cadastroDoacaoVM)
        {
            Doador doador = await _doadorService.ConsultarDoador(cadastroDoacaoVM.IdDoador);
            Instituicao instituicao = await _instituicaoService.ConsultarInstituicao(cadastroDoacaoVM.IdInstituicao);
            Pagamento pagamento = await _pagamentoService.ConsultarPagamento(cadastroDoacaoVM.IdPagamento);

            Doacao doacao = new Doacao();
            doacao.Doador = doador;
            doacao.Instituicao = instituicao;
            doacao.Pagamento = pagamento;
            //doacao.Cupons = null;
            doacao.DataDoacao = DateTime.Now;
            doacao.ValorInstituicao = cadastroDoacaoVM.Valor;

            await _doacaoRepository.InsertOrUpdateAsync(doacao);
            return doacao._id.ToString();
        }
    }
}