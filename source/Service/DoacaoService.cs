using MongoDB.Bson;
using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Doacao;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<DoacaoMinhasDoacoesVM>> ListarMinhasDoacoes(string idDoador)
        {
            ObjectId id = new ObjectId(idDoador);
            DateTime umAnoAtras = DateTime.Now.AddYears(-1).Date;

            List<DoacaoMinhasDoacoesVM> listaDadosDoacaoVM = new List<DoacaoMinhasDoacoesVM>();
            var listaDoacao = await _doacaoRepository.GetByAsync(p => p.Doador._id == id && p.DataDoacao >= umAnoAtras);

            foreach (var doacao in listaDoacao)
            {
                DoacaoMinhasDoacoesVM dadosMinhasDoacoesVM = new DoacaoMinhasDoacoesVM();
                dadosMinhasDoacoesVM.Cartao = doacao.Pagamento.NumeroCartao;
                dadosMinhasDoacoesVM.Valor = doacao.Pagamento.Valor;
                dadosMinhasDoacoesVM.DataDoacao = doacao.DataDoacao;
                listaDadosDoacaoVM.Add(dadosMinhasDoacoesVM);
            }

            return listaDadosDoacaoVM;
        }

        public async Task<IEnumerable<DoacaoInstituicoesAjudadasVM>> ListarInstituicoesAjudadas(string idDoador)
        {
            ObjectId id = new ObjectId(idDoador);
            DateTime umAnoAtras = DateTime.Now.AddYears(-1).Date;

            List<DoacaoInstituicoesAjudadasVM> listaInstituicoesAjudadasVM = new List<DoacaoInstituicoesAjudadasVM>();
            var listaDoacao = await _doacaoRepository.GetByAsync(p => p.Doador._id == id && p.DataDoacao >= umAnoAtras);

            foreach (var doacao in listaDoacao)
            {
                DoacaoInstituicoesAjudadasVM instituicoesAjudadasVM = new DoacaoInstituicoesAjudadasVM();
                instituicoesAjudadasVM.Nome = doacao.Instituicao.Nome;
                instituicoesAjudadasVM.Valor = doacao.ValorInstituicao;
                instituicoesAjudadasVM.DataDoacao = doacao.DataDoacao;
                instituicoesAjudadasVM.Site = doacao.Instituicao.Site;
                listaInstituicoesAjudadasVM.Add(instituicoesAjudadasVM);
            }

            return listaInstituicoesAjudadasVM;
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