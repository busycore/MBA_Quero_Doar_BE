using AutoMapper;
using source.Models;
using source.Service.Repository;
using source.ViewModel.Instituicao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Service
{
    public class InstituicaoService
    {
        private readonly InstituicaoRepository _instituicaoRepository;
        private readonly IMapper _mapper;

        public InstituicaoService(InstituicaoRepository instituicaoRepository, IMapper mapper)
        {
            _instituicaoRepository = instituicaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DadosInstituicaoVM>> GetAll()
        {
            var _inst = await _instituicaoRepository.GetAllDocument();
            var _list = _mapper.Map<IEnumerable<DadosInstituicaoVM>>(_inst);

            return _list;
        }

        public Task<Instituicao> ConsultarInstituicao(string id)
        {
            return _instituicaoRepository.GetDocumentByID(id);
        }

        public async Task<DadosInstituicaoVM> Consultar(string id)
        {
            var institucacaoModel = await ConsultarInstituicao(id);
            var dadosInstituicaoVM = _mapper.Map<DadosInstituicaoVM>(institucacaoModel);
            return dadosInstituicaoVM;
        }

        public async Task<string> Salvar(CadastroInstituicaoVM cadastroInstituicaoVM)
        {
            return "";
        }

        public async Task Atualizar(AtualizaInstituicaoVM atualizaInstituicaoVM)
        {
        }
    }
}