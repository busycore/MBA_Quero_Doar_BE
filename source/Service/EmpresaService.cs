using AutoMapper;
using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Empresa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Service
{
    public class EmpresaService : IService
    {
        private readonly EmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaService(EmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public Task<Empresa> ConsultarEmpresa(string id)
        {
            return _empresaRepository.GetDocumentByID(id);
        }

        public async Task<IEnumerable<DadosEmpresaVM>> GetAll()
        {
            var _listRepo = await _empresaRepository.GetAllDocument();
            var _list = _mapper.Map<IEnumerable<DadosEmpresaVM>>(_listRepo);
            return _list;
        }

        public async Task<DadosEmpresaVM> Consultar(string id)
        {
            var empresaModel = await ConsultarEmpresa(id);
            var empresaVM = _mapper.Map<DadosEmpresaVM>(empresaModel);

            return empresaVM;
        }

        public async Task<string> Salvar(CadastroEmpresaVM cadastroEmpresaVM)
        {
            return "";
        }

        public async Task Atualizar(AtualizaEmpresaVM atualizaEmpresaVM)
        {
        }
    }
}