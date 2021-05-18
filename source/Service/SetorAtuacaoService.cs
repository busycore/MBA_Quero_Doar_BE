using AutoMapper;
using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.SetorAtuacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Service
{
    public class SetorAtuacaoService : IService
    {
        private readonly SetorAtuacaoRepository _setorAtuacaoRepository;
        private readonly IMapper _mapper;

        public SetorAtuacaoService(SetorAtuacaoRepository setorAtuacaoRepository, IMapper mapper)
        {
            _setorAtuacaoRepository = setorAtuacaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DadosSetorAtuacaoVM>> ListarTodos()
        {
            var SetorAtuacaoTodos = await _setorAtuacaoRepository.GetAllDocument();
            var list = _mapper.Map<IEnumerable<DadosSetorAtuacaoVM>>(SetorAtuacaoTodos);

            return list;
        }

        public async Task<DadosSetorAtuacaoVM> Consultar(string id)
        {
            var setorModel = await _setorAtuacaoRepository.GetDocumentByID(id);
            var list = _mapper.Map<DadosSetorAtuacaoVM>(setorModel);

            return dadosSetorAtuacaoVM;
        }
    }
}