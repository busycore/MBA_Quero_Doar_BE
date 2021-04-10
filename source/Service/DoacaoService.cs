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
        private readonly CupomService _cupomService;

        public DoacaoService(DoacaoRepository doacaoRepository, DoadorService doadorService,
                             InstituicaoService instituicaoService, PagamentoService pagamentoService,
                             CupomService cupomService)
        {
            _doacaoRepository = doacaoRepository;
            _doadorService = doadorService;
            _instituicaoService = instituicaoService;
            _pagamentoService = pagamentoService;
            _cupomService = cupomService;
        }

        public async Task<IEnumerable<DoacaoMinhasDoacoesVM>> ListarMinhasDoacoes(string idDoador)
        {
            ObjectId id = new ObjectId(idDoador);
            DateTime umAnoAtras = DateTime.Now.AddYears(-1).Date;

            List<DoacaoMinhasDoacoesVM> listaDadosDoacaoVM = new();
            var listaDoacao = await _doacaoRepository.GetByAsync(p => p.Doador._id == id && p.DataDoacao >= umAnoAtras);

            foreach (var doacao in listaDoacao)
            {
                DoacaoMinhasDoacoesVM dadosMinhasDoacoesVM = new DoacaoMinhasDoacoesVM
                {
                    Cartao = doacao.Pagamento.NumeroCartao,
                    Valor = doacao.Pagamento.Valor,
                    DataDoacao = doacao.DataDoacao
                };
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
                DoacaoInstituicoesAjudadasVM instituicoesAjudadasVM = new DoacaoInstituicoesAjudadasVM
                {
                    Nome = doacao.Instituicao.Nome,
                    Valor = doacao.ValorInstituicao,
                    DataDoacao = doacao.DataDoacao,
                    Site = doacao.Instituicao.Site
                };
                listaInstituicoesAjudadasVM.Add(instituicoesAjudadasVM);
            }

            return listaInstituicoesAjudadasVM;
        }

        public async Task<string> Salvar(CadastroDoacaoVM cadastroDoacaoVM)
        {
            Doador doador = await _doadorService.ConsultarDoador(cadastroDoacaoVM.IdDoador);
            Instituicao instituicao = await _instituicaoService.ConsultarInstituicao(cadastroDoacaoVM.IdInstituicao);
            Pagamento pagamento = await _pagamentoService.ConsultarPagamento(cadastroDoacaoVM.IdPagamento);
            Cupom cupom = await _cupomService.ConsultarCupom(cadastroDoacaoVM.IdCupom);


            Doacao doacao = new Doacao
            {
                Doador = doador,
                Instituicao = instituicao,
                Pagamento = pagamento,
                Cupom = cupom,
                DataDoacao = DateTime.Now,
                ValorInstituicao = cadastroDoacaoVM.Valor
            };

            await _doacaoRepository.InsertOrUpdateAsync(doacao);
            return doacao._id.ToString();
        }
    }
}