using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public DoacaoService(DoacaoRepository doacaoRepository, IMapper mapper, IServiceProvider serviceProvider)
        {
            _doacaoRepository = doacaoRepository;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<MinhasDoacoesVM>> ListarMinhasDoacoes(string idDoador)
        {
            var _doacao = await _doacaoRepository.GetAllDoacaoByDoadorLastYear(idDoador);
            var _minhasDoacoes = _mapper.Map<IEnumerable<MinhasDoacoesVM>>(_doacao);

            return _minhasDoacoes;
        }

        public async Task<IEnumerable<MinhasDoacoesCupomVM>> ListarMeusCupons(string idDoador)
        {
            var _doacao = await _doacaoRepository.GetAllDoacaoByDoadorLastYear(idDoador);
            var _meusCuponsVM = _mapper.Map<IEnumerable<MinhasDoacoesCupomVM>>(_doacao.SelectMany(m => m.Cupom));
            return _meusCuponsVM;
        }

        public async Task<IEnumerable<MinhasDoacoesInstituicaoVM>> ListarInstituicaoAjudada(string idDoador)
        {
            var _doacao = await _doacaoRepository.GetAllDoacaoByDoadorLastYear(idDoador);
            var _listaInstituicao = _doacao.Select(m => m.Instituicao);
            var _meusInstituicaoVM = _mapper.Map<IEnumerable<MinhasDoacoesInstituicaoVM>>(_listaInstituicao);
            return _meusInstituicaoVM;
        }

        public async Task Salvar(CadastroDoacaoVM cadastroDoacaoVM)
        {
            Instituicao _instituicao = await BuscarInstituicaoDoacao(cadastroDoacaoVM);
            Doador _doador = await BuscarDoadorDoacao(cadastroDoacaoVM);
            IEnumerable<Cupom> _listCupom = await BuscarCuponsDoacao(cadastroDoacaoVM);
            Pagamento pagamento = await EfetuarPagamentoDoacao(cadastroDoacaoVM);

            Doacao doacao = new()
            {
                DataDoacao = DateTime.Now,
                ValorInstituicao = cadastroDoacaoVM.Valor,
                Instituicao = _instituicao,
                Doador = _doador,
                Cupom = _listCupom,
                Pagamento = pagamento
            };
            await _doacaoRepository.InsertOrUpdateAsync(doacao);
        }

        private async Task<Pagamento> EfetuarPagamentoDoacao(CadastroDoacaoVM cadastroDoacaoVM)
        {
            var pagamento = _mapper.Map<Pagamento>(cadastroDoacaoVM.pagamento);
            var _pagamentoRepo = _serviceProvider.GetRequiredService<PagamentoRepository>();
            await _pagamentoRepo.InsertOrUpdateAsync(pagamento);
            return pagamento;
        }

        private async Task<IEnumerable<Cupom>> BuscarCuponsDoacao(CadastroDoacaoVM cadastroDoacaoVM)
        {
            List<Cupom> _listCupom = new(cadastroDoacaoVM.IdCupom.Count());
            var _cupomRepo = _serviceProvider.GetRequiredService<CupomRepository>();
            foreach (var idcupom in cadastroDoacaoVM.IdCupom)
            {
                var _cupom = await _cupomRepo.GetDocumentByID(idcupom);
                if (_cupom == null)
                    throw new NullReferenceException("Cupom informado não encontrada");

                _listCupom.Add(_cupom);
            }

            return _listCupom;
        }

        private async Task<Doador> BuscarDoadorDoacao(CadastroDoacaoVM cadastroDoacaoVM)
        {
            var _doadorRepo = _serviceProvider.GetRequiredService<DoadorRepository>();
            var _doador = await _doadorRepo.GetDocumentByID(cadastroDoacaoVM.IdDoador);
            if (_doador == null)
                throw new NullReferenceException("Doador informada não encontrada");
            return _doador;
        }

        private async Task<Instituicao> BuscarInstituicaoDoacao(CadastroDoacaoVM cadastroDoacaoVM)
        {
            var _instituicaoRepo = _serviceProvider.GetRequiredService<InstituicaoRepository>();
            var _instituicao = await _instituicaoRepo.GetDocumentByID(cadastroDoacaoVM.IdInstituicao);
            if (_instituicao == null)
                throw new NullReferenceException("Instituição informada não encontrada");
            return _instituicao;
        }
    }
}