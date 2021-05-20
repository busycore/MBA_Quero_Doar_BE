using AutoMapper;
using MongoDB.Bson;
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
        private readonly CupomService _cupomService;
        private readonly IMapper _mapper;

        public DoacaoService(DoacaoRepository doacaoRepository, DoadorService doadorService,
                             InstituicaoService instituicaoService, PagamentoService pagamentoService,
                             CupomService cupomService,
                             IMapper mapper)
        {
            _doacaoRepository = doacaoRepository;
            _doadorService = doadorService;
            _instituicaoService = instituicaoService;
            _pagamentoService = pagamentoService;
            _cupomService = cupomService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MinhasDoacoesVM>> ListarMinhasDoacoes(string idDoador)
        {
            var _doacao = await _doacaoRepository.GetAllDoacaoByDoadorLastYear(idDoador);
            var _minhasDoacoes = _mapper.Map<IEnumerable<MinhasDoacoesVM>>(_doacao);

            return _minhasDoacoes;
        }

        public async Task<IEnumerable<MinhasDoacoesCupomVM>> ListarMeusCupons(string idDoador)
        {
            var _doacao = await _doacaoRepository.GetAllDoacaoByCupomLastYear(idDoador);
            var _listaCupom = _doacao.Select(m => m.Cupom);
            var _meusCupons = _mapper.Map<IEnumerable<MinhasDoacoesCupomVM>>(_listaCupom);
            return _meusCupons;
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
            return null;
        }
    }
}