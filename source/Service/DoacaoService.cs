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
        private readonly IMapper _mapper;

        public DoacaoService(DoacaoRepository doacaoRepository, IMapper mapper)
        {
            _doacaoRepository = doacaoRepository;
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
            var _doacao = await _doacaoRepository.GetAllDoacaoByDoadorLastYear(idDoador);
            var _listaCupom = _doacao.Select(m => m.Cupom);
            var _meusCuponsVM = _mapper.Map<IEnumerable<MinhasDoacoesCupomVM>>(_listaCupom);
            return _meusCuponsVM;
        }

        public async Task<IEnumerable<MinhasDoacoesInstituicaoVM>> ListarInstituicaoAjudada(string idDoador)
        {
            var _doacao = await _doacaoRepository.GetAllDoacaoByDoadorLastYear(idDoador);
            var _listaInstituicao = _doacao.Select(m => m.Instituicao);
            var _meusInstituicaoVM = _mapper.Map<IEnumerable<MinhasDoacoesInstituicaoVM>>(_listaInstituicao);
            return _meusInstituicaoVM;
        }

        public async Task<string> Salvar(CadastroDoacaoVM cadastroDoacaoVM)
        {
            return null;
        }
    }
}