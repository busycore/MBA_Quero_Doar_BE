using AutoMapper;
using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Doador;
using System.Threading.Tasks;

namespace source.Service
{
    public class DoadorService : IService
    {
        private readonly DoadorRepository _doadorRepository;
        private readonly IMapper _mapper;

        public DoadorService(DoadorRepository doadorRepository, IMapper mapper)
        {
            _doadorRepository = doadorRepository;
            _mapper = mapper;
        }

        public Task<Doador> ConsultarDoador(string id)
        {
            return _doadorRepository.GetDocumentByID(id);
        }

        public async Task<DadosDoadorVM> Consultar(string id)
        {
            var doadorModel = await _doadorRepository.GetDocumentByID(id);
            var dadosDoadorVM = _mapper.Map<DadosDoadorVM>(doadorModel);

            return dadosDoadorVM;
        }

        public async Task<string> Salvar(CadastroDoadorVM cadastroDoadorVM)
        {
            var _doador = _mapper.Map<Doador>(cadastroDoadorVM);
            await _doadorRepository.InsertOrUpdateAsync(_doador);
            return _doador._id.ToString();
        }

        public async Task Atualizar(AtualizaDoadorVM atualizaDoadorVM)
        {
        }
    }
}